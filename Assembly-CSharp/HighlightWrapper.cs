using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020005AB RID: 1451
public class HighlightWrapper
{
	// Token: 0x170001CE RID: 462
	// (get) Token: 0x060024F6 RID: 9462 RVA: 0x0001913D File Offset: 0x0001733D
	// (set) Token: 0x060024F7 RID: 9463 RVA: 0x00019145 File Offset: 0x00017345
	public E_HighlightType E_HighlightType_0
	{
		get
		{
			return this.m_state_highlight;
		}
		set
		{
			this.m_state_highlight = value;
		}
	}

	// Token: 0x060024F8 RID: 9464 RVA: 0x000B11B4 File Offset: 0x000AF3B4
	public void method_0(GameObject gameObject_0, E_HighlightType e_HighlightType_0, bool bool_0)
	{
		if (this.E_HighlightType_0 == e_HighlightType_0 && this.m_bOtherEntityExit == bool_0)
		{
			return;
		}
		if (this.matHighlightTransparent == null)
		{
			GameObject gameObject = Resources.Load("Graphics/GraphicsData") as GameObject;
			CharacterOutlineEffectData component = gameObject.GetComponent<CharacterOutlineEffectData>();
			this.matHighlightTransparent = component.matHighlightTransparent;
			this.m_colorDic[E_HighlightType.None] = component.noneColor;
			this.m_colorDic[E_HighlightType.Silver] = component.silverColor;
			this.m_colorDic[E_HighlightType.Golden] = component.goldenColor;
		}
		if (this.matHighlightTransparent == null)
		{
			return;
		}
		this.m_bOtherEntityExit = bool_0;
		this.bDrawingInTransparentQueue = bool_0;
		this.E_HighlightType_0 = e_HighlightType_0;
		Color color = this.m_colorDic[this.E_HighlightType_0];
		float num = 0f;
		if (this.E_HighlightType_0 != E_HighlightType.None && !this.bDrawingInTransparentQueue)
		{
			num = this.matHighlightTransparent.GetFloat("_OutlineWidth");
		}
		foreach (SkinnedMeshRenderer skinnedMeshRenderer in gameObject_0.GetComponentsInChildren<SkinnedMeshRenderer>())
		{
			if (skinnedMeshRenderer)
			{
				for (int j = 0; j < skinnedMeshRenderer.materials.Length; j++)
				{
					Material material = skinnedMeshRenderer.materials[j];
					if (material.shader.name == "Custom/BOL_Charactor_BRDF" || material.shader.name == "Custom/BOL_Wpn_MaskReflect")
					{
						material.SetColor("_OutlineColor", color);
						material.SetFloat("_OutlineWidth", num);
					}
				}
			}
		}
	}

	// Token: 0x060024F9 RID: 9465 RVA: 0x000B1338 File Offset: 0x000AF538
	public void method_1(GameObject gameObject_0, E_HighlightType e_HighlightType_0, bool bool_0)
	{
		if (this.E_HighlightType_0 == e_HighlightType_0 && this.m_bOtherEntityExit == bool_0)
		{
			return;
		}
		if (this.matHighlight == null || this.matHighlightTransparent == null)
		{
			GameObject gameObject = Resources.Load("Graphics/GraphicsData") as GameObject;
			CharacterOutlineEffectData component = gameObject.GetComponent<CharacterOutlineEffectData>();
			this.matHighlight = component.matHighlight;
			this.matHighlightTransparent = component.matHighlightTransparent;
			this.m_colorDic[E_HighlightType.None] = component.noneColor;
			this.m_colorDic[E_HighlightType.Silver] = component.silverColor;
			this.m_colorDic[E_HighlightType.Golden] = component.goldenColor;
		}
		if (!(this.matHighlight == null) && !(this.matHighlightTransparent == null))
		{
			this.m_bOtherEntityExit = bool_0;
			Material material = ((!bool_0) ? this.matHighlight : this.matHighlightTransparent);
			E_HighlightType e_HighlightType_ = this.E_HighlightType_0;
			this.E_HighlightType_0 = e_HighlightType_0;
			Color color = this.m_colorDic[this.E_HighlightType_0];
			foreach (MeshRenderer meshRenderer in gameObject_0.GetComponentsInChildren<MeshRenderer>())
			{
				if (meshRenderer)
				{
					if (this.E_HighlightType_0 != E_HighlightType.None)
					{
						int num;
						if (e_HighlightType_ == E_HighlightType.None)
						{
							num = meshRenderer.materials.Length + 1;
						}
						else
						{
							num = meshRenderer.materials.Length;
						}
						if (this.arrHighlightMatCache == null || this.arrHighlightMatCache.Length != num)
						{
							this.arrHighlightMatCache = new Material[num];
						}
						for (int j = 0; j < num - 1; j++)
						{
							this.arrHighlightMatCache[j] = meshRenderer.materials[j];
						}
						this.arrHighlightMatCache[num - 1] = material;
						material.SetColor("_OutlineColor", color);
						meshRenderer.materials = this.arrHighlightMatCache;
					}
					else
					{
						if (this.arrOriginalMatCache == null || this.arrOriginalMatCache.Length != meshRenderer.materials.Length - 1)
						{
							this.arrOriginalMatCache = new Material[meshRenderer.materials.Length - 1];
						}
						for (int k = 0; k < meshRenderer.materials.Length - 1; k++)
						{
							this.arrOriginalMatCache[k] = meshRenderer.materials[k];
						}
						meshRenderer.materials = this.arrOriginalMatCache;
					}
				}
			}
			return;
		}
	}

	// Token: 0x060024FA RID: 9466 RVA: 0x000B1574 File Offset: 0x000AF774
	public void OnRenderObject(GameObject _gameObj)
	{
		if (this.bDrawingInTransparentQueue && this.E_HighlightType_0 != E_HighlightType.None && !(this.matHighlightTransparent == null))
		{
			SkinnedMeshRenderer[] componentsInChildren = _gameObj.GetComponentsInChildren<SkinnedMeshRenderer>();
			if (this.meshes == null || this.meshes.Length != componentsInChildren.Length)
			{
				this.meshes = new Mesh[componentsInChildren.Length];
				for (int i = 0; i < this.meshes.Length; i++)
				{
					this.meshes[i] = new Mesh();
				}
			}
			for (int j = 0; j < componentsInChildren.Length; j++)
			{
				Transform transform = componentsInChildren[j].gameObject.transform;
				Matrix4x4 matrix4x = transform.localToWorldMatrix;
				Matrix4x4 matrix4x2 = Matrix4x4.identity;
				matrix4x2 = Matrix4x4.Scale(new Vector3(1f / transform.lossyScale.x, 1f / transform.lossyScale.y, 1f / transform.lossyScale.z));
				matrix4x *= matrix4x2;
				componentsInChildren[j].BakeMesh(this.meshes[j]);
				this.matHighlightTransparent.SetColor("_OutlineColor", this.m_colorDic[this.E_HighlightType_0]);
				Graphics.DrawMesh(this.meshes[j], matrix4x, this.matHighlightTransparent, 0);
			}
			return;
		}
	}

	// Token: 0x04001A35 RID: 6709
	private E_HighlightType m_state_highlight;

	// Token: 0x04001A36 RID: 6710
	private Dictionary<E_HighlightType, Color> m_colorDic = new Dictionary<E_HighlightType, Color>
	{
		{
			E_HighlightType.None,
			Color.white
		},
		{
			E_HighlightType.Silver,
			new Color(0.78431374f, 0.78431374f, 0.78431374f)
		},
		{
			E_HighlightType.Golden,
			new Color(1f, 0.8156863f, 0.24705882f)
		}
	};

	// Token: 0x04001A37 RID: 6711
	private Material matHighlightTransparent;

	// Token: 0x04001A38 RID: 6712
	private bool bDrawingInTransparentQueue;

	// Token: 0x04001A39 RID: 6713
	private bool m_bOtherEntityExit;

	// Token: 0x04001A3A RID: 6714
	private Material matHighlight;

	// Token: 0x04001A3B RID: 6715
	private Material[] arrHighlightMatCache;

	// Token: 0x04001A3C RID: 6716
	private Material[] arrOriginalMatCache;

	// Token: 0x04001A3D RID: 6717
	private Mesh[] meshes;
}
