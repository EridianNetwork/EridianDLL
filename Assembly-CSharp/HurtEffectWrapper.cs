using System;
using UnityEngine;

// Token: 0x020005AC RID: 1452
public class HurtEffectWrapper : MonoBehaviour
{
	// Token: 0x060024FC RID: 9468 RVA: 0x000B16C4 File Offset: 0x000AF8C4
	public void Start()
	{
		if (this.matHurtEffectTransparent == null)
		{
			GameObject gameObject = Resources.Load("Graphics/GraphicsData") as GameObject;
			CharacterEffectData component = gameObject.GetComponent<CharacterEffectData>();
			this.matHurtEffectTransparent = new Material(component.mHurtEffectTransparentMat);
		}
	}

	// Token: 0x060024FD RID: 9469 RVA: 0x000B1708 File Offset: 0x000AF908
	public void OnDestroy()
	{
		global::UnityEngine.Object.DestroyImmediate(this.matHurtEffectTransparent);
		foreach (Mesh mesh in this.cacheMeshes)
		{
			global::UnityEngine.Object.DestroyImmediate(mesh);
		}
		this.cacheMeshes = null;
	}

	// Token: 0x060024FE RID: 9470 RVA: 0x000B1748 File Offset: 0x000AF948
	public void method_0(HurtEffectWrapper.EParamType eparamType_0, string string_0, object object_0)
	{
		if (this.matHurtEffectTransparent == null)
		{
			return;
		}
		if (eparamType_0 == HurtEffectWrapper.EParamType.EPT_Float)
		{
			this.matHurtEffectTransparent.SetFloat(string_0, (float)object_0);
		}
		else if (eparamType_0 == HurtEffectWrapper.EParamType.EPT_Texture)
		{
			this.matHurtEffectTransparent.SetTexture(string_0, (Texture)object_0);
		}
		else if (eparamType_0 == HurtEffectWrapper.EParamType.EPT_Color)
		{
			this.matHurtEffectTransparent.SetColor(string_0, (Color)object_0);
		}
	}

	// Token: 0x060024FF RID: 9471 RVA: 0x000B17AC File Offset: 0x000AF9AC
	public void OnRenderObject()
	{
		if (this.matHurtEffectTransparent == null)
		{
			return;
		}
		SkinnedMeshRenderer[] componentsInChildren = base.gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();
		if (this.cacheMeshes == null || this.cacheMeshes.Length != componentsInChildren.Length)
		{
			this.cacheMeshes = new Mesh[componentsInChildren.Length];
			for (int i = 0; i < this.cacheMeshes.Length; i++)
			{
				this.cacheMeshes[i] = new Mesh();
			}
		}
		for (int j = 0; j < componentsInChildren.Length; j++)
		{
			Transform transform = componentsInChildren[j].gameObject.transform;
			Matrix4x4 matrix4x = transform.localToWorldMatrix;
			Matrix4x4 matrix4x2 = Matrix4x4.identity;
			matrix4x2 = Matrix4x4.Scale(new Vector3(1f / transform.lossyScale.x, 1f / transform.lossyScale.y, 1f / transform.lossyScale.z));
			matrix4x *= matrix4x2;
			componentsInChildren[j].BakeMesh(this.cacheMeshes[j]);
			Graphics.DrawMesh(this.cacheMeshes[j], matrix4x, this.matHurtEffectTransparent, 0);
		}
	}

	// Token: 0x04001A3E RID: 6718
	private Material matHurtEffectTransparent;

	// Token: 0x04001A3F RID: 6719
	private Mesh[] cacheMeshes;

	// Token: 0x020005AD RID: 1453
	public enum EParamType
	{
		// Token: 0x04001A41 RID: 6721
		EPT_Float,
		// Token: 0x04001A42 RID: 6722
		EPT_Texture,
		// Token: 0x04001A43 RID: 6723
		EPT_Color
	}
}
