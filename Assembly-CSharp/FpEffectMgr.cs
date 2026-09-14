using System;
using BHV;
using ns0;
using UnityEngine;

// Token: 0x020005A5 RID: 1445
public class FpEffectMgr
{
	// Token: 0x060024AD RID: 9389 RVA: 0x00018FD9 File Offset: 0x000171D9
	public void method_0(bool bool_0)
	{
		this.mEnableRageEffect = bool_0;
	}

	// Token: 0x060024AE RID: 9390 RVA: 0x00018FE2 File Offset: 0x000171E2
	public void method_1(bool bool_0)
	{
		this.mEnableDash = bool_0;
	}

	// Token: 0x060024AF RID: 9391 RVA: 0x000AF6D8 File Offset: 0x000AD8D8
	private void method_2()
	{
		this.mEnableRageEffect = false;
		RageEffectData component = (Resources.Load("Graphics/GraphicsData") as GameObject).GetComponent<RageEffectData>();
		this.mRefractionMat = component.mRefractionMaterial;
		GameObject gameObject = global::UnityEngine.Object.Instantiate(Resources.Load("Graphics/CHR_RagePlane") as GameObject) as GameObject;
		this.mPlane = global::UnityEngine.Object.Instantiate(gameObject.GetComponent<MeshFilter>().mesh) as Mesh;
		Vector3 vector = new Vector3(0f, 0f, 11f);
		Quaternion quaternion = Quaternion.Euler(270f, 0f, 0f);
		Vector3 vector2 = new Vector3(1.8f, 0.9f, 1f);
		this.mLocalMatrix = Matrix4x4.TRS(vector, quaternion, vector2);
		this.mShaderMotionBlur = component.mCustomMotionBlurShader;
		this.mBlurMaskTex = component.mBlurMaskTex;
		this.mblurAmount = component.mAccPara;
	}

	// Token: 0x060024B0 RID: 9392 RVA: 0x00018FEB File Offset: 0x000171EB
	public void method_3(GameObject gameObject_0)
	{
		this.mGraphicMgrObj = gameObject_0;
		this.mGraphicMgrObj.AddComponent<FpDrawEffectLogic>();
		this.method_2();
	}

	// Token: 0x060024B1 RID: 9393 RVA: 0x000AF7B8 File Offset: 0x000AD9B8
	public void method_4(float float_0, CharacterFxMgr.FX_TYPE fx_TYPE_0)
	{
		this.mTimer = new Utils.Timer();
		this.mTimer.Start(float_0);
		this.mType = fx_TYPE_0;
		this.mHasEffect = true;
		if (this.mType == CharacterFxMgr.FX_TYPE.FX_REVIVE)
		{
			if (this.mRespawnTexture == null)
			{
				CharacterEffectData component = (Resources.Load("Graphics/GraphicsData") as GameObject).GetComponent<CharacterEffectData>();
				this.mRespawnTexture = component.mFirstPersonRespawnTexture;
				this.mRespawnStrength = component.mFirstPersonRespawnStrength;
				this.mRespawnSpeedU = component.mFirstPersonRespawnSpeedU;
				this.mRespawnSpeedV = component.mFirstPersonRespawnSpeedV;
			}
		}
		else
		{
			this.mNeedSetMaterialParameter = true;
		}
	}

	// Token: 0x060024B2 RID: 9394 RVA: 0x00019006 File Offset: 0x00017206
	public void method_5()
	{
		if (this.mType == CharacterFxMgr.FX_TYPE.FX_REVIVE)
		{
			this.mInterruptReviveEffect = true;
		}
	}

	// Token: 0x060024B3 RID: 9395 RVA: 0x000AF850 File Offset: 0x000ADA50
	private void method_6(Material material_0)
	{
		CharacterFxMgr characterFxMgr = MonoSingleton<GraphicsMgr>.Instance.method_16();
		Color color = characterFxMgr.method_1()[(int)this.mType].method_0();
		material_0.SetColor("_Effect_Color", color);
		material_0.SetFloat("_Effect_Para", characterFxMgr.method_1()[(int)this.mType].method_1().r);
	}

	// Token: 0x060024B4 RID: 9396 RVA: 0x000AF8AC File Offset: 0x000ADAAC
	private void method_7()
	{
		if (this.mFpsCamera != null)
		{
			if (this.mEnableRageEffect)
			{
				float num = 0.017453292f * this.mFpsCamera.fieldOfView;
				float num2 = 0.017453292f * this.mOriFov;
				float num3 = Mathf.Tan(num * 0.5f) / Mathf.Tan(num2 * 0.5f);
				Matrix4x4 matrix4x = Matrix4x4.Scale(new Vector3(num3, num3, 1f));
				Matrix4x4 localToWorldMatrix = this.mFpsCamera.gameObject.transform.localToWorldMatrix;
				this.mToWorldMat = localToWorldMatrix * matrix4x * this.mLocalMatrix;
				Graphics.DrawMesh(this.mPlane, this.mToWorldMat, this.mRefractionMat, 0, null);
			}
			if (this.mEnableDash)
			{
				if (this.mCustomMotionBlur == null)
				{
					this.mCustomMotionBlur = this.mFpsCamera.gameObject.AddComponent<CustomMotionBlur>();
					this.mCustomMotionBlur.shader = this.mShaderMotionBlur;
					this.mCustomMotionBlur.mBlurMaskTex = this.mBlurMaskTex;
					this.mCustomMotionBlur.blurAmount = this.mblurAmount;
				}
			}
			else if (this.mCustomMotionBlur != null)
			{
				global::UnityEngine.Object.Destroy(this.mCustomMotionBlur);
			}
		}
	}

	// Token: 0x060024B5 RID: 9397 RVA: 0x000AF9E4 File Offset: 0x000ADBE4
	private void method_8()
	{
		EntityWeapon equipedWeapon = this.mEntityPlay.m_equipedWeapon;
		if (this.mEntityPlay != null && this.mEntityPlay.method_45() != null)
		{
			this.mFpsCamera = this.mEntityPlay.method_45().camera;
			this.mOriFov = this.mEntityPlay.vmethod_14().vmethod_0<BHVFirstPersonSettings>().m_FOVDefault;
		}
		if (equipedWeapon != null)
		{
			SkinnedMeshRenderer mWpnRenderer = equipedWeapon.mWpnRenderer;
			if (mWpnRenderer != null)
			{
				if (this.mNeedSetMaterialParameter)
				{
					this.method_6(mWpnRenderer.materials[1]);
				}
				this.method_9(mWpnRenderer.materials[1]);
			}
		}
	}

	// Token: 0x060024B6 RID: 9398 RVA: 0x000AFA8C File Offset: 0x000ADC8C
	private void method_9(Material material_0)
	{
		if ((this.mHasEffect && this.mTimer != null && this.mTimer.method_7()) || this.mInterruptReviveEffect)
		{
			this.mHasEffect = false;
			this.mTimer = null;
			if (this.mType == CharacterFxMgr.FX_TYPE.FX_REVIVE)
			{
				material_0.DisableKeyword("RESPAWN_ON");
				material_0.SetTexture("_RespawnTexture", null);
				material_0.SetFloat("_RespawnStrength", 0f);
				material_0.SetFloat("_RespawnSpeedU", 0f);
				material_0.SetFloat("_RespawnSpeedV", 0f);
			}
			else
			{
				material_0.SetFloat("_Effect_Para", 0f);
				material_0.SetColor("_Effect_Color", new Color(1f, 1f, 1f));
			}
		}
		if (this.mHasEffect && this.mType == CharacterFxMgr.FX_TYPE.FX_REVIVE)
		{
			material_0.EnableKeyword("RESPAWN_ON");
			material_0.SetTexture("_RespawnTexture", this.mRespawnTexture);
			material_0.SetFloat("_RespawnStrength", this.mRespawnStrength);
			material_0.SetFloat("_RespawnSpeedU", this.mRespawnSpeedU);
			material_0.SetFloat("_RespawnSpeedV", this.mRespawnSpeedV);
		}
	}

	// Token: 0x060024B7 RID: 9399 RVA: 0x000AFBB0 File Offset: 0x000ADDB0
	private void method_10()
	{
		if (this.mEntityPlay != null && this.mHandModel == null && this.mEntityPlay.vmethod_17() != null)
		{
			Transform transform = this.mEntityPlay.method_60();
			if (transform == null)
			{
				return;
			}
			this.mHandModel = transform.gameObject;
		}
		if (this.mHandModel == null)
		{
			return;
		}
		if (this.mEntityPlay.m_equipedWeapon == null)
		{
			return;
		}
		SkinnedMeshRenderer component = this.mHandModel.GetComponent<SkinnedMeshRenderer>();
		if (component != null)
		{
			if (this.mNeedSetMaterialParameter)
			{
				this.method_6(component.materials[1]);
			}
			this.method_11(component.materials[1]);
		}
	}

	// Token: 0x060024B8 RID: 9400 RVA: 0x000AFA8C File Offset: 0x000ADC8C
	private void method_11(Material material_0)
	{
		if ((this.mHasEffect && this.mTimer != null && this.mTimer.method_7()) || this.mInterruptReviveEffect)
		{
			this.mHasEffect = false;
			this.mTimer = null;
			if (this.mType == CharacterFxMgr.FX_TYPE.FX_REVIVE)
			{
				material_0.DisableKeyword("RESPAWN_ON");
				material_0.SetTexture("_RespawnTexture", null);
				material_0.SetFloat("_RespawnStrength", 0f);
				material_0.SetFloat("_RespawnSpeedU", 0f);
				material_0.SetFloat("_RespawnSpeedV", 0f);
			}
			else
			{
				material_0.SetFloat("_Effect_Para", 0f);
				material_0.SetColor("_Effect_Color", new Color(1f, 1f, 1f));
			}
		}
		if (this.mHasEffect && this.mType == CharacterFxMgr.FX_TYPE.FX_REVIVE)
		{
			material_0.EnableKeyword("RESPAWN_ON");
			material_0.SetTexture("_RespawnTexture", this.mRespawnTexture);
			material_0.SetFloat("_RespawnStrength", this.mRespawnStrength);
			material_0.SetFloat("_RespawnSpeedU", this.mRespawnSpeedU);
			material_0.SetFloat("_RespawnSpeedV", this.mRespawnSpeedV);
		}
	}

	// Token: 0x060024B9 RID: 9401 RVA: 0x000AFC6C File Offset: 0x000ADE6C
	public void method_12()
	{
		if (!MonoSingleton<GraphicsMgr>.Instance.mIsHideFpMesh)
		{
			if (this.mEntityPlay == null && MonoSingleton<Session>.Instance != null && MonoSingleton<Session>.Instance.GetLocalPlayer() != null)
			{
				this.mEntityPlay = (EntityPlayer)MonoSingleton<Session>.Instance.GetLocalPlayer().GetEntity();
			}
			if (this.mEntityPlay == null)
			{
				return;
			}
			this.method_8();
			this.method_10();
			this.mNeedSetMaterialParameter = false;
			this.mInterruptReviveEffect = false;
		}
	}

	// Token: 0x060024BA RID: 9402 RVA: 0x000AFCF8 File Offset: 0x000ADEF8
	public void method_13()
	{
		if (!MonoSingleton<GraphicsMgr>.Instance.mIsHideFpMesh)
		{
			if (this.mEntityPlay == null && MonoSingleton<Session>.Instance != null && MonoSingleton<Session>.Instance.GetLocalPlayer() != null)
			{
				this.mEntityPlay = (EntityPlayer)MonoSingleton<Session>.Instance.GetLocalPlayer().GetEntity();
			}
			if (this.mEntityPlay == null)
			{
				return;
			}
			this.method_7();
		}
	}

	// Token: 0x040019D0 RID: 6608
	private GameObject mGraphicMgrObj;

	// Token: 0x040019D1 RID: 6609
	private EntityPlayer mEntityPlay;

	// Token: 0x040019D2 RID: 6610
	private Camera mFpsCamera;

	// Token: 0x040019D3 RID: 6611
	private GameObject mHandModel;

	// Token: 0x040019D4 RID: 6612
	private bool mEnableRageEffect;

	// Token: 0x040019D5 RID: 6613
	private bool mEnableDash;

	// Token: 0x040019D6 RID: 6614
	private Material mRefractionMat;

	// Token: 0x040019D7 RID: 6615
	private Mesh mPlane;

	// Token: 0x040019D8 RID: 6616
	private Matrix4x4 mLocalMatrix;

	// Token: 0x040019D9 RID: 6617
	private Matrix4x4 mToWorldMat;

	// Token: 0x040019DA RID: 6618
	private float mOriFov;

	// Token: 0x040019DB RID: 6619
	private CustomMotionBlur mCustomMotionBlur;

	// Token: 0x040019DC RID: 6620
	private Shader mShaderMotionBlur;

	// Token: 0x040019DD RID: 6621
	private Texture mBlurMaskTex;

	// Token: 0x040019DE RID: 6622
	private float mblurAmount;

	// Token: 0x040019DF RID: 6623
	private bool mHasEffect;

	// Token: 0x040019E0 RID: 6624
	private Utils.Timer mTimer;

	// Token: 0x040019E1 RID: 6625
	private CharacterFxMgr.FX_TYPE mType;

	// Token: 0x040019E2 RID: 6626
	private Texture mRespawnTexture;

	// Token: 0x040019E3 RID: 6627
	private float mRespawnStrength = 1f;

	// Token: 0x040019E4 RID: 6628
	private float mRespawnSpeedU;

	// Token: 0x040019E5 RID: 6629
	private float mRespawnSpeedV;

	// Token: 0x040019E6 RID: 6630
	private bool mNeedSetMaterialParameter;

	// Token: 0x040019E7 RID: 6631
	private bool mInterruptReviveEffect;
}
