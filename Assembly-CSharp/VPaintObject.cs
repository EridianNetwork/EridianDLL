using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Core;
using UnityEngine;
using Valkyrie.VPaint;

// Token: 0x02000B7F RID: 2943
[AddComponentMenu("VPaint/VPaint Object")]
[RequireComponent(typeof(MeshFilter))]
[ExecuteInEditMode]
[RequireComponent(typeof(MeshRenderer))]
public class VPaintObject : MonoBehaviour, IVPaintIdentifier
{
	// Token: 0x06004FA0 RID: 20384 RVA: 0x00151D58 File Offset: 0x0014FF58
	public static List<VPaintObject> smethod_0(Vector3 vector3_0, float float_0)
	{
		float num = float_0 * float_0;
		List<VPaintObject> list = new List<VPaintObject>();
		foreach (VPaintObject vpaintObject in VPaintObject.all)
		{
			if (vpaintObject && vpaintObject.renderer.bounds.SqrDistance(vector3_0) < num)
			{
				list.Add(vpaintObject);
			}
		}
		return list;
	}

	// Token: 0x1700080B RID: 2059
	// (get) Token: 0x06004FA1 RID: 20385 RVA: 0x00033F6B File Offset: 0x0003216B
	private MeshRenderer MeshRenderer_0
	{
		get
		{
			if (!this._meshRenderer)
			{
				this._meshRenderer = base.GetComponent<MeshRenderer>();
			}
			return this._meshRenderer;
		}
	}

	// Token: 0x1700080C RID: 2060
	// (get) Token: 0x06004FA2 RID: 20386 RVA: 0x00033F8C File Offset: 0x0003218C
	private MeshFilter MeshFilter_0
	{
		get
		{
			if (!this._meshFilter)
			{
				this._meshFilter = base.GetComponent<MeshFilter>();
			}
			return this._meshFilter;
		}
	}

	// Token: 0x1700080D RID: 2061
	// (get) Token: 0x06004FA3 RID: 20387 RVA: 0x00033FAD File Offset: 0x000321AD
	// (set) Token: 0x06004FA4 RID: 20388 RVA: 0x00033FB5 File Offset: 0x000321B5
	public bool Boolean_0
	{
		get
		{
			return this._isDynamic;
		}
		set
		{
			if (value != this._isDynamic)
			{
				if (!value && this.editorCollider)
				{
					global::UnityEngine.Object.Destroy(this.editorCollider.gameObject);
				}
				else
				{
					this.method_0();
				}
				value = this._isDynamic;
			}
		}
	}

	// Token: 0x06004FA5 RID: 20389 RVA: 0x00151DD4 File Offset: 0x0014FFD4
	private void method_0()
	{
		this.editorCollider = new GameObject(base.name + " Collider")
		{
			hideFlags = HideFlags.HideInHierarchy
		}.AddComponent<MeshCollider>();
		this.editorCollider.sharedMesh = this.originalMesh;
	}

	// Token: 0x06004FA6 RID: 20390 RVA: 0x00033FF2 File Offset: 0x000321F2
	public void OnApplicationQuit()
	{
		if (!AppManager.s_allowQuit)
		{
			return;
		}
		this.OnDestroy();
	}

	// Token: 0x06004FA7 RID: 20391 RVA: 0x00151E1C File Offset: 0x0015001C
	public void OnDestroy()
	{
		if (this._mesh && this._mesh != this.originalMesh)
		{
			global::UnityEngine.Object.DestroyImmediate(this._mesh);
		}
		VPaintObject.all.Remove(this);
		if (this.editorCollider)
		{
			global::UnityEngine.Object.DestroyImmediate(this.editorCollider.gameObject);
		}
	}

	// Token: 0x06004FA8 RID: 20392 RVA: 0x00151E80 File Offset: 0x00150080
	public void OnEnable()
	{
		if (!Application.isPlaying)
		{
			if (!this._mesh)
			{
				return;
			}
			global::UnityEngine.Object[] array = global::UnityEngine.Object.FindObjectsOfType(typeof(VPaintObject));
			foreach (global::UnityEngine.Object @object in array)
			{
				VPaintObject vpaintObject = @object as VPaintObject;
				if (!(vpaintObject == this) && vpaintObject._mesh == this._mesh)
				{
					this._mesh = null;
					this.method_7();
					break;
				}
			}
		}
	}

	// Token: 0x06004FA9 RID: 20393 RVA: 0x00034002 File Offset: 0x00032202
	public void Awake()
	{
		if (!Application.isPlaying)
		{
			return;
		}
		if (this._isDynamic)
		{
			this.method_0();
		}
	}

	// Token: 0x06004FAA RID: 20394 RVA: 0x0003401A File Offset: 0x0003221A
	public Color[] method_1()
	{
		return this.method_6().colors;
	}

	// Token: 0x06004FAB RID: 20395 RVA: 0x00034027 File Offset: 0x00032227
	public Vector3[] method_2()
	{
		return this.method_6().vertices;
	}

	// Token: 0x06004FAC RID: 20396 RVA: 0x00151EFC File Offset: 0x001500FC
	public void method_3(Color[] color_0)
	{
		Mesh mesh = this.method_6();
		if (color_0.Length != this.myVertices.Length)
		{
			for (int i = 0; i < color_0.Length; i++)
			{
				color_0[i] = Color.magenta;
			}
			DebugUtils.LogWarning(LogCategory.Graphics, "Invalid vertex colors assigned to " + base.name + ". Check the Maintenance window for your VPaint Group for more info.");
			return;
		}
		for (int j = 0; j < color_0.Length; j++)
		{
			this.myColors[j] = color_0[j];
		}
		mesh.colors = this.myColors;
	}

	// Token: 0x06004FAD RID: 20397 RVA: 0x00034034 File Offset: 0x00032234
	public bool IsEqualTo(IVPaintIdentifier obj)
	{
		return obj == this;
	}

	// Token: 0x06004FAE RID: 20398 RVA: 0x0003403A File Offset: 0x0003223A
	public Bounds method_4()
	{
		if (this.editorCollider)
		{
			return this.editorCollider.bounds;
		}
		return base.renderer.bounds;
	}

	// Token: 0x06004FAF RID: 20399 RVA: 0x00151F90 File Offset: 0x00150190
	public void method_5()
	{
		if (this.colorsBuilder == null)
		{
			return;
		}
		if (this.transparencyBuilder == null)
		{
			return;
		}
		Mesh mesh = this.method_6();
		mesh.colors = this.colorsBuilder;
		this.myColors = this.colorsBuilder;
		this.colorsBuilder = null;
		this.transparencyBuilder = null;
	}

	// Token: 0x06004FB0 RID: 20400 RVA: 0x00151FDC File Offset: 0x001501DC
	public Mesh method_6()
	{
		if (!this)
		{
			return null;
		}
		if (!this.MeshFilter_0)
		{
			return null;
		}
		if (!this._mesh)
		{
			if (this._meshNonSerialized)
			{
				this._mesh = this._meshNonSerialized;
			}
			else
			{
				if (!this.MeshFilter_0.sharedMesh && !this.originalMesh)
				{
					return null;
				}
				if (this.originalMesh)
				{
					this.MeshFilter_0.sharedMesh = this.originalMesh;
				}
				this.originalMesh = this.MeshFilter_0.sharedMesh;
				VertexDataCache component = base.GetComponent<VertexDataCache>();
				if (component)
				{
					this._mesh = component.method_1();
				}
				else
				{
					this._mesh = global::UnityEngine.Object.Instantiate(this.MeshFilter_0.sharedMesh) as Mesh;
				}
				this.MeshFilter_0.sharedMesh = this._mesh;
				this.myVertices = this._mesh.vertices;
				Color[] colors = this._mesh.colors;
				if (colors == null || colors.Length != this.myVertices.Length)
				{
					Color[] array = new Color[this.myVertices.Length];
					this.myColors = array;
					this._mesh.colors = array;
				}
				if (this._mesh.uv2.Length == 0)
				{
					this._mesh.uv2 = this._mesh.uv;
				}
				this._mesh.RecalculateBounds();
			}
		}
		this.MeshFilter_0.sharedMesh = this._mesh;
		this._meshNonSerialized = this._mesh;
		if (this.myVertices == null)
		{
			this.myVertices = this._mesh.vertices;
		}
		if (this.myColors == null)
		{
			this.myColors = this._mesh.colors;
		}
		return this._mesh;
	}

	// Token: 0x06004FB1 RID: 20401 RVA: 0x0015219C File Offset: 0x0015039C
	public void method_7()
	{
		if (this._mesh && this._mesh != this.originalMesh)
		{
			global::UnityEngine.Object.DestroyImmediate(this._mesh);
		}
		this._mesh = null;
		this._meshNonSerialized = null;
		MeshFilter component = base.GetComponent<MeshFilter>();
		if (!component)
		{
			return;
		}
		component.sharedMesh = this.originalMesh;
		this.method_15();
	}

	// Token: 0x06004FB2 RID: 20402 RVA: 0x00152204 File Offset: 0x00150404
	public void method_8(Color[] color_0)
	{
		Mesh mesh = this.method_6();
		if (color_0.Length != this.myVertices.Length)
		{
			DebugUtils.LogWarning(LogCategory.Graphics, "Colors length of " + base.name + " is different than vertices length");
			return;
		}
		Vector4[] array = new Vector4[color_0.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = color_0[i];
		}
		mesh.tangents = array;
	}

	// Token: 0x06004FB3 RID: 20403 RVA: 0x0015227C File Offset: 0x0015047C
	public void method_9(Color color_0)
	{
		Mesh mesh = this.method_6();
		Color[] array = this.myColors;
		if (array == null)
		{
			array = mesh.colors;
		}
		if (array == null || array.Length == 0)
		{
			array = new Color[mesh.vertices.Length];
		}
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = color_0;
		}
		mesh.colors = array;
	}

	// Token: 0x06004FB4 RID: 20404 RVA: 0x001522DC File Offset: 0x001504DC
	public void method_10(Vector3 vector3_0, VPaintObjectPositionalModifier vpaintObjectPositionalModifier_0)
	{
		Mesh mesh = this.method_6();
		Vector3[] array = this.myVertices;
		Color[] colors = this.myColors;
		if (colors == null)
		{
			colors = mesh.colors;
		}
		int num = array.Length;
		for (int i = 0; i < num; i++)
		{
			Vector3 vector = base.transform.TransformPoint(array[i]);
			float num2 = Vector3.Distance(vector, vector3_0);
			colors[i] = vpaintObjectPositionalModifier_0(colors[i], num2);
		}
		mesh.colors = colors;
		this.myColors = colors;
	}

	// Token: 0x06004FB5 RID: 20405 RVA: 0x00152370 File Offset: 0x00150570
	public IEnumerator method_11(Vector3 vector3_0, VPaintObjectPositionalModifier vpaintObjectPositionalModifier_0, float float_0)
	{
		Mesh j = method_6();
		Vector3[] vertices = myVertices;
		Color[] colors = myColors;
		if (colors == null)
		{
			colors = j.colors;
		}
		int len = vertices.Length;
		Color[] target = new Color[len];
		for (int i = 0; i < len; i++)
		{
			Vector3 v = base.transform.TransformPoint(vertices[i]);
			float distance = Vector3.Distance(v, vector3_0);
			ref Color reference = ref target[i];
			reference = vpaintObjectPositionalModifier_0(colors[i], distance);
		}
		IEnumerator routine = VPaintUtility.LerpColors(this, colors, target, float_0);
		while (routine.MoveNext())
		{
			yield return null;
		}
	}
	// Token: 0x06004FB6 RID: 20406 RVA: 0x001523B8 File Offset: 0x001505B8
	public void method_12(Color color_0, Vector3 vector3_0, float float_0, float float_1, float float_2)
	{
		method_10(vector3_0, delegate(Color color_1, float float_3)
		{
			if (float_3 < float_3)
			{
				return color_1;
			}
			float t = Mathf.Pow(1f - float_3 / float_3, float_1) * float_2;
			return Color.Lerp(color_1, color_1, t);
		});
	}
	// Token: 0x06004FB7 RID: 20407 RVA: 0x001523FC File Offset: 0x001505FC
	public void method_13(float float_0, Vector3 vector3_0, float float_1, float float_2, float float_3)
	{
		method_10(vector3_0, delegate(Color color_1, float float_4)
		{
			if (float_1 < float_4)
			{
				return color_1;
			}
			float t = Mathf.Pow(1f - float_4 / float_1, float_2) * float_3;
			color_1.a = Mathf.Lerp(color_1.a, float_4, t);
			return color_1;
		});
	}
	// Token: 0x06004FB8 RID: 20408 RVA: 0x00152440 File Offset: 0x00150640
	public void method_14(Material material_0)
	{
		if (!base.renderer)
		{
			return;
		}
		if (!this.originalMaterial)
		{
			this.originalMaterial = base.renderer.sharedMaterial;
		}
		base.renderer.sharedMaterial = material_0;
		this.instancedMaterial = material_0;
	}

	// Token: 0x06004FB9 RID: 20409 RVA: 0x0015248C File Offset: 0x0015068C
	public void method_15()
	{
		if (!base.renderer)
		{
			return;
		}
		if (base.renderer.sharedMaterial != this.instancedMaterial)
		{
			this.originalMaterial = base.renderer.sharedMaterial;
		}
		else if (this.originalMaterial)
		{
			base.renderer.sharedMaterial = this.originalMaterial;
		}
	}

	// Token: 0x04003BC8 RID: 15304
	public static List<VPaintObject> all = new List<VPaintObject>();

	// Token: 0x04003BC9 RID: 15305
	[HideInInspector]
	public Mesh _mesh;

	// Token: 0x04003BCA RID: 15306
	[NonSerialized]
	public Mesh _meshNonSerialized;

	// Token: 0x04003BCB RID: 15307
	[HideInInspector]
	public Material originalMaterial;

	// Token: 0x04003BCC RID: 15308
	[HideInInspector]
	public Mesh originalMesh;

	// Token: 0x04003BCD RID: 15309
	[NonSerialized]
	public Color[] colorsBuilder;

	// Token: 0x04003BCE RID: 15310
	[NonSerialized]
	public float[] transparencyBuilder;

	// Token: 0x04003BCF RID: 15311
	[NonSerialized]
	public int index;

	// Token: 0x04003BD0 RID: 15312
	[NonSerialized]
	public Color[] myColors;

	// Token: 0x04003BD1 RID: 15313
	[NonSerialized]
	public Vector3[] myVertices;

	// Token: 0x04003BD2 RID: 15314
	[HideInInspector]
	public MeshCollider editorCollider;

	// Token: 0x04003BD3 RID: 15315
	private MeshRenderer _meshRenderer;

	// Token: 0x04003BD4 RID: 15316
	private MeshFilter _meshFilter;

	// Token: 0x04003BD5 RID: 15317
	[SerializeField]
	private bool _isDynamic;

	// Token: 0x04003BD6 RID: 15318
	private Material instancedMaterial;
}
