using System;
using ns0;
using UnityEngine;

// Token: 0x02000B3C RID: 2876
public class PreviewTest : MonoBehaviour
{
	// Token: 0x06004E6F RID: 20079 RVA: 0x0014C2EC File Offset: 0x0014A4EC
	private void Start()
	{
		this.mWeaponTexture = new Texture2D(1280, 720, TextureFormat.ARGB32, false);
		this.mWeaponTexture.name = "PreviewTest_mWeaponTexture";
		this.mChrRect = new Rect(0f, 0f, 250f, 370f);
		this.mDisplayTestTex = false;
	}

	// Token: 0x06004E70 RID: 20080 RVA: 0x000330F5 File Offset: 0x000312F5
	private void OnGUI()
	{
		if (this.mDisplayTestTex)
		{
			Graphics.DrawTexture(this.mChrRect, MonoSingleton<GraphicsMgr>.Instance.method_22().method_13(), MonoSingleton<GraphicsMgr>.Instance.method_22().method_14(), 0, 0, 0, 0);
		}
	}

	// Token: 0x06004E71 RID: 20081 RVA: 0x0014C348 File Offset: 0x0014A548
	private void FixedUpdate()
	{
		if (Input.GetKeyDown("d"))
		{
			this.mDisplayTestTex = !this.mDisplayTestTex;
		}
		if (Input.GetKeyDown("u"))
		{
			MonoSingleton<GraphicsMgr>.Instance.method_22().method_15(this.mDisplayUV);
		}
		if (Input.GetKeyDown("v") && this.mWeaponMesh != null)
		{
			Matrix4x4 identity = Matrix4x4.identity;
			identity.SetTRS(new Vector3(0f, 0f, 1f), Quaternion.Euler(new Vector3(0f, 90f, 0f)), Vector3.one * 2f);
			SkinnedMeshRenderer componentInChildren = this.mWeaponMesh.GetComponentInChildren<SkinnedMeshRenderer>();
			if (componentInChildren != null)
			{
				MonoSingleton<GraphicsMgr>.Instance.method_19().method_2(componentInChildren, ref identity, this.mWeaponTexture, TexPostEffectMgr.POST_EFFECT_TYPE.POST_EFFECT_UI);
			}
		}
		if (this.mThrCharDisplayPlane != null)
		{
			MeshRenderer component = this.mThrCharDisplayPlane.GetComponent<MeshRenderer>();
			if (component != null)
			{
				Material material = component.material;
				material.SetTexture("_MainTex", MonoSingleton<GraphicsMgr>.Instance.method_22().method_13());
			}
		}
		if (this.mWeaponDisplayPlane != null)
		{
			MeshRenderer component2 = this.mWeaponDisplayPlane.GetComponent<MeshRenderer>();
			if (component2 != null)
			{
				Material material2 = component2.material;
				material2.SetTexture("_MainTex", this.mWeaponTexture);
			}
		}
	}

	// Token: 0x04003A84 RID: 14980
	public GameObject mThrCharDisplayPlane;

	// Token: 0x04003A85 RID: 14981
	public GameObject mWeaponDisplayPlane;

	// Token: 0x04003A86 RID: 14982
	public GameObject mWeaponMesh;

	// Token: 0x04003A87 RID: 14983
	public Rect mDisplayUV;

	// Token: 0x04003A88 RID: 14984
	private Texture2D mWeaponTexture;

	// Token: 0x04003A89 RID: 14985
	private Rect mChrRect;

	// Token: 0x04003A8A RID: 14986
	private bool mDisplayTestTex;
}
