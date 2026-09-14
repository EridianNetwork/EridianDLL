using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Core;
using UnityEngine;
using Valkyrie.VPaint;

// Token: 0x02000B7B RID: 2939
[AddComponentMenu("VPaint/VPaint Group")]
[ExecuteInEditMode]
public class VPaintGroup : MonoBehaviour
{
	// Token: 0x06004F84 RID: 20356 RVA: 0x00033EB9 File Offset: 0x000320B9
	public VPaintLayerStack method_0()
	{
		return this.layerStack;
	}

	// Token: 0x06004F85 RID: 20357 RVA: 0x001515CC File Offset: 0x0014F7CC
	public VPaintObject[] method_1()
	{
		for (int i = 0; i < this.colorers.Count; i++)
		{
			if (!this.colorers[i])
			{
				this.colorers.RemoveAt(i--);
			}
		}
		return this.colorers.ToArray();
	}

	// Token: 0x06004F86 RID: 20358 RVA: 0x00033EC1 File Offset: 0x000320C1
	public VPaintLayer method_2()
	{
		return new VPaintLayer();
	}

	// Token: 0x06004F87 RID: 20359 RVA: 0x00151620 File Offset: 0x0014F820
	public void method_3(VPaintObject vpaintObject_0)
	{
		if (!vpaintObject_0)
		{
			return;
		}
		if (this.colorers.Contains(vpaintObject_0))
		{
			return;
		}
		if (vpaintObject_0.method_6() == null)
		{
			DebugUtils.LogError(LogCategory.AI, "VPaint Object is missing a mesh.");
			return;
		}
		this.colorers.Add(vpaintObject_0);
		this.vertexCache.Add(new VPaintVertexCache
		{
			vpaintObject = vpaintObject_0,
			vertices = vpaintObject_0.method_6().vertices
		});
	}

	// Token: 0x06004F88 RID: 20360 RVA: 0x00151698 File Offset: 0x0014F898
	public void method_4(VPaintObject vpaintObject_0)
	{
		colorers.Remove(vpaintObject_0);
		vertexCache.RemoveAll((VPaintVertexCache vpaintVertexCache_0) => vpaintVertexCache_0.vpaintObject == vpaintObject_0);
	}
	// Token: 0x06004F89 RID: 20361 RVA: 0x00033EC8 File Offset: 0x000320C8
	private void Awake()
	{
		if (!Application.isPlaying)
		{
			if (this.autoLoadInEditor)
			{
				this.method_5();
			}
		}
		else
		{
			this.paintLayer = this.layerStack.GetMergedLayer();
			if (this.autoApplySchedule == AutoApplySchedule.OnAwake)
			{
				this.method_5();
			}
		}
	}

	// Token: 0x06004F8A RID: 20362 RVA: 0x00033F01 File Offset: 0x00032101
	private void Start()
	{
		if (!Application.isPlaying)
		{
			return;
		}
		if (this.autoApplySchedule == AutoApplySchedule.OnStart)
		{
			this.method_5();
		}
	}

	// Token: 0x06004F8B RID: 20363 RVA: 0x001516DC File Offset: 0x0014F8DC
	[ContextMenu("Apply")]
	public void method_5()
	{
		if (this.paintLayer == null)
		{
			this.paintLayer = this.layerStack.GetMergedLayer();
		}
		foreach (VPaintVertexData vpaintVertexData in this.paintLayer.paintData)
		{
			VPaintObject vpaintObject = vpaintVertexData.vpaintObject;
			if (vpaintObject)
			{
				vpaintObject.method_3(vpaintVertexData.colors);
			}
		}
	}

	// Token: 0x06004F8C RID: 20364 RVA: 0x00033F19 File Offset: 0x00032119
	public void method_6()
	{
		this.method_7(this.layerStack.layers);
	}

	// Token: 0x06004F8D RID: 20365 RVA: 0x00151760 File Offset: 0x0014F960
	private void method_7(List<VPaintLayer> list_0)
	{
		foreach (VPaintObject vpaintObject in this.colorers)
		{
			vpaintObject.colorsBuilder = null;
			vpaintObject.transparencyBuilder = null;
		}
		List<VPaintObject> list = new List<VPaintObject>();
		foreach (VPaintLayer vpaintLayer in list_0)
		{
			if (vpaintLayer.enabled)
			{
				this.method_8(vpaintLayer, list);
			}
		}
		foreach (VPaintObject vpaintObject2 in list)
		{
			vpaintObject2.method_5();
		}
	}

	// Token: 0x06004F8E RID: 20366 RVA: 0x00151848 File Offset: 0x0014FA48
	private void method_8(VPaintLayer vpaintLayer_0, List<VPaintObject> list_0)
	{
		foreach (VPaintObject vpaintObject in this.colorers)
		{
			if (vpaintObject)
			{
				VPaintVertexData vpaintVertexData = vpaintLayer_0.Get(vpaintObject);
				if (vpaintVertexData != null)
				{
					this.method_9(vpaintObject, vpaintLayer_0, vpaintVertexData);
					if (!list_0.Contains(vpaintObject))
					{
						list_0.Add(vpaintObject);
					}
				}
			}
		}
	}

	// Token: 0x06004F8F RID: 20367 RVA: 0x001518C0 File Offset: 0x0014FAC0
	private void method_9(VPaintObject vpaintObject_0, VPaintLayer vpaintLayer_0, VPaintVertexData vpaintVertexData_0)
	{
		if (vpaintObject_0.colorsBuilder == null)
		{
			vpaintObject_0.colorsBuilder = new Color[vpaintVertexData_0.colors.Length];
		}
		if (vpaintObject_0.transparencyBuilder == null)
		{
			vpaintObject_0.transparencyBuilder = new float[vpaintVertexData_0.colors.Length];
		}
		VPaintUtility.MergeColors(vpaintObject_0.colorsBuilder, vpaintObject_0.transparencyBuilder, vpaintVertexData_0.colors, vpaintVertexData_0.transparency, vpaintLayer_0.blendMode, vpaintLayer_0.opacity, vpaintLayer_0.maskR, vpaintLayer_0.maskG, vpaintLayer_0.maskB, vpaintLayer_0.maskA);
	}

	// Token: 0x06004F90 RID: 20368 RVA: 0x00151944 File Offset: 0x0014FB44
	public void method_10(List<VPaintObject> list_0)
	{
		foreach (VPaintObject vpaintObject in list_0)
		{
			this.method_11(vpaintObject);
		}
	}

	// Token: 0x06004F91 RID: 20369 RVA: 0x00151994 File Offset: 0x0014FB94
	private void method_11(VPaintObject vpaintObject_0)
	{
		vpaintObject_0.colorsBuilder = null;
		vpaintObject_0.transparencyBuilder = null;
		foreach (VPaintLayer vpaintLayer in this.layerStack.layers)
		{
			if (vpaintLayer.enabled)
			{
				VPaintVertexData vpaintVertexData = vpaintLayer.Get(vpaintObject_0);
				if (vpaintVertexData != null)
				{
					this.method_9(vpaintObject_0, vpaintLayer, vpaintVertexData);
				}
			}
		}
		vpaintObject_0.method_5();
	}

	// Token: 0x06004F92 RID: 20370 RVA: 0x00151A14 File Offset: 0x0014FC14
	public void method_12()
	{
		List<VPaintObject> list = new List<VPaintObject>();
		foreach (VPaintObject vpaintObject in this.colorers)
		{
			VPaintObject[] componentsInChildren = vpaintObject.GetComponentsInChildren<VPaintObject>();
			foreach (VPaintObject vpaintObject2 in componentsInChildren)
			{
				if (!list.Contains(vpaintObject2))
				{
					list.Add(vpaintObject2);
				}
			}
		}
		foreach (VPaintObject vpaintObject3 in list)
		{
			VPaintVertexData vpaintVertexData = this.paintLayer.Get(vpaintObject3);
			if (vpaintVertexData != null)
			{
				vpaintObject3.method_8(vpaintVertexData.colors);
			}
		}
	}

	// Token: 0x06004F93 RID: 20371 RVA: 0x00151AF4 File Offset: 0x0014FCF4
	public IEnumerator method_13(VPaintGroup vpaintGroup_0, float float_0)
	{
		VPaintLayer myBaseLayer = paintLayer;
		VPaintLayer targetBaseLayer = vpaintGroup_0.paintLayer;
		List<IEnumerator> routines = new List<IEnumerator>();
		VPaintObject[] array = method_1();
		foreach (VPaintObject obj in array)
		{
			if (vpaintGroup_0.colorers.Contains(obj))
			{
				int colorLength = obj.method_6().colors.Length;
				VPaintVertexData baseData = myBaseLayer.Get(obj);
				Color[] baseColors2 = null;
				baseColors2 = ((baseData != null) ? baseData.colors : new Color[colorLength]);
				VPaintVertexData targetData = targetBaseLayer.Get(obj);
				Color[] targetColors2 = null;
				targetColors2 = ((targetData != null) ? targetData.colors : new Color[colorLength]);
				routines.Add(VPaintUtility.LerpColors(obj, baseColors2, targetColors2, float_0));
			}
		}
		while (true)
		{
			bool b = true;
			foreach (IEnumerator r in routines)
			{
				if (r.MoveNext())
				{
					b = false;
				}
			}
			if (b)
			{
				break;
			}
			yield return null;
		}
	}
	// Token: 0x04003BAC RID: 15276
	[HideInInspector]
	public List<VPaintObject> colorers = new List<VPaintObject>();

	// Token: 0x04003BAD RID: 15277
	[HideInInspector]
	public VPaintLayerStack layerStack = new VPaintLayerStack();

	// Token: 0x04003BAE RID: 15278
	public AutoApplySchedule autoApplySchedule;

	// Token: 0x04003BAF RID: 15279
	public bool autoLoadInEditor = true;

	// Token: 0x04003BB0 RID: 15280
	[NonSerialized]
	public VPaintLayer paintLayer;

	// Token: 0x04003BB1 RID: 15281
	[HideInInspector]
	public List<VPaintVertexCache> vertexCache = new List<VPaintVertexCache>();
}
