using System;
using ns0;
using UnityEngine;

// Token: 0x02000B3D RID: 2877
public class snapTest : MonoBehaviour
{
	// Token: 0x06004E73 RID: 20083 RVA: 0x0014C4AC File Offset: 0x0014A6AC
	private void Start()
	{
		MeshRenderer component = base.gameObject.GetComponent<MeshRenderer>();
		if (component != null)
		{
			this.mPlaneMaterial = component.material;
		}
		this.mRotation = new Vector3(-90f, 90f, 0f);
		MonoSingleton<GraphicsMgr>.Instance.method_19().method_1(this.mCameraEffect);
		this.mSnapTex = new Texture2D(1280, 720, TextureFormat.ARGB32, false);
		this.mSnapTex.name = "snapTest_mSnapTex";
	}

	// Token: 0x06004E74 RID: 20084 RVA: 0x0014C530 File Offset: 0x0014A730
	private void FixedUpdate()
	{
		if (Input.GetKey("a"))
		{
			Matrix4x4 identity = Matrix4x4.identity;
			identity.SetTRS(new Vector3(0f, 0f, 1f), Quaternion.Euler(new Vector3(0f, 90f, 0f)), Vector3.one * 2f);
			SkinnedMeshRenderer componentInChildren = this.mSnapObj.GetComponentInChildren<SkinnedMeshRenderer>();
			MonoSingleton<GraphicsMgr>.Instance.method_19().method_2(componentInChildren, ref identity, this.mSnapTex, TexPostEffectMgr.POST_EFFECT_TYPE.POST_EFFECT_UI);
		}
		this.mPlaneMaterial.SetTexture("_MainTex", this.mSnapTex);
	}

	// Token: 0x04003A8B RID: 14987
	private Material mPlaneMaterial;

	// Token: 0x04003A8C RID: 14988
	public Vector3 mRotation;

	// Token: 0x04003A8D RID: 14989
	public Vector3 mTranslate;

	// Token: 0x04003A8E RID: 14990
	public Vector3 mScale;

	// Token: 0x04003A8F RID: 14991
	public GameObject mCameraEffect;

	// Token: 0x04003A90 RID: 14992
	public GameObject mSnapObj;

	// Token: 0x04003A91 RID: 14993
	private Texture2D mSnapTex;
}
