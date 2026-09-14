using System;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x020005EA RID: 1514
public class UIPreviewMgr
{
	// Token: 0x06002639 RID: 9785 RVA: 0x000B8AFC File Offset: 0x000B6CFC
	public UIPreviewMgr()
	{
		this.mSrcUVRect = new Rect(0f, 0f, 1f, 1f);
	}

	// Token: 0x0600263A RID: 9786 RVA: 0x00019DA0 File Offset: 0x00017FA0
	public float[] method_0()
	{
		return this.mWpnLocalPos;
	}

	// Token: 0x0600263B RID: 9787 RVA: 0x00019DA8 File Offset: 0x00017FA8
	public float[] method_1()
	{
		return this.mWpnRotSpeed;
	}

	// Token: 0x0600263C RID: 9788 RVA: 0x00019DB0 File Offset: 0x00017FB0
	public float[] method_2()
	{
		return this.mAccessoryLocalPos;
	}

	// Token: 0x0600263D RID: 9789 RVA: 0x00019DB8 File Offset: 0x00017FB8
	public float method_3()
	{
		return this.mShieldLocalPos;
	}

	// Token: 0x0600263E RID: 9790 RVA: 0x000B8B5C File Offset: 0x000B6D5C
	private Rect method_4(Renderer renderer_0)
	{
		Rect rect = new Rect(0.3f, 0f, 0.4f, 1f);
		return rect;
	}

	// Token: 0x0600263F RID: 9791 RVA: 0x000B8B88 File Offset: 0x000B6D88
	private void method_5(GameObject gameObject_0)
	{
		if (gameObject_0 != null)
		{
			SkinnedMeshRenderer skinnedMeshRenderer = BuildingKitGenerator.smethod_1(gameObject_0);
			if (skinnedMeshRenderer == null)
			{
				skinnedMeshRenderer = gameObject_0.GetComponentInChildren<SkinnedMeshRenderer>();
			}
			this.mSrcUVRect = this.method_4(skinnedMeshRenderer);
		}
		else
		{
			this.mSrcUVRect = new Rect(0f, 0f, 1f, 1f);
		}
	}

	// Token: 0x06002640 RID: 9792 RVA: 0x00019DC0 File Offset: 0x00017FC0
	public int method_6()
	{
		return this.mUIPreviewLayer;
	}

	// Token: 0x06002641 RID: 9793 RVA: 0x000B8BE4 File Offset: 0x000B6DE4
	public void method_7()
	{
		if (this.mCamObj != null && this.mCamObj.animation != null && !this.m_zoomIn)
		{
			this.mCamObj.animation["ANI_UIPreviewMotion"].speed = -1f;
			this.mCamObj.animation["ANI_UIPreviewMotion"].time = this.mCamObj.animation.clip.length;
			this.mCamObj.animation.Play("ANI_UIPreviewMotion");
			this.m_zoomIn = true;
		}
	}

	// Token: 0x06002642 RID: 9794 RVA: 0x000B8C88 File Offset: 0x000B6E88
	public void method_8()
	{
		if (this.mCamObj.animation != null && this.mCamObj.animation != null && this.m_zoomIn)
		{
			this.mCamObj.animation["ANI_UIPreviewMotion"].speed = 1f;
			this.mCamObj.animation["ANI_UIPreviewMotion"].time = 0f;
			this.mCamObj.animation.Play("ANI_UIPreviewMotion");
			this.m_zoomIn = false;
		}
	}

	// Token: 0x06002643 RID: 9795 RVA: 0x000B8D20 File Offset: 0x000B6F20
	public void method_9()
	{
		this.m_zoomIn = true;
		if (this.mCamObj != null)
		{
			this.mCamObj.animation["ANI_UIPreviewMotion"].speed = 0f;
			this.mCamObj.animation["ANI_UIPreviewMotion"].time = 0f;
			this.mCamObj.animation.Play("ANI_UIPreviewMotion");
		}
	}

	// Token: 0x06002644 RID: 9796 RVA: 0x000B8D98 File Offset: 0x000B6F98
	public void method_10(GameObject gameObject_0)
	{
		this.mUIPrivewRT = new RenderTexture(this.mPreviewRTWidth, this.mPreviewRTHeight, 24);
		this.mUIPrivewRT.name = "UIPreviewMgr_mUIPrivewRT";
		this.mUIPrivewRT.Create();
		this.mUIPriveCamObj = gameObject_0;
		this.mCamObj = global::UnityEngine.Object.Instantiate(Resources.Load("CameraEffect/EffectCamera_UI_Preview_Control")) as GameObject;
		this.mCamObj.transform.parent = this.mUIPriveCamObj.transform;
		this.mCamObj.animation["ANI_UIPreviewMotion"].speed = 0f;
		this.mCamObj.animation.playAutomatically = false;
		this.mUIPreviewCamera = this.mCamObj.GetComponent<Camera>();
		this.mUIPreviewCamera.renderingPath = RenderingPath.UsePlayerSettings;
		this.mUIPreviewCamera.cullingMask = 1 << this.mUIPreviewLayer;
		this.mUIPreviewCamera.targetTexture = this.mUIPrivewRT;
		this.mUIPreviewCamera.depth = 101f;
		this.mUIPreviewCamera.clearFlags = CameraClearFlags.Color;
		this.mUIPreviewCamera.backgroundColor = new Color(0f, 0f, 0f, 0f);
		this.mUIPreviewCamera.nearClipPlane = 0.01f;
		this.mUIPreviewCamera.hdr = true;
		this.mUIPreviewCamera.enabled = false;
		GameObject gameObject = Resources.Load("CameraEffect/EffectCamera_UI_Preview") as GameObject;
		if (gameObject != null)
		{
			ComponentHelper.smethod_0(gameObject, this.mCamObj.gameObject);
		}
		UIPrivewData component = (Resources.Load("Graphics/GraphicsData") as GameObject).GetComponent<UIPrivewData>();
		this.mSirenLocalPos = component.m_SIREN_LocalPos;
		this.mSoldierLocalPos = component.m_SOLDIER_LocalPos;
		this.mBerserkerLocalPos = component.m_BERSERKER_LocalPos;
		this.mHUNTERLocalPos = component.m_HUNTER_LocalPos;
		this.mWpnLocalPos = component.m_Wpn_LocalPos;
		this.mWpnRotSpeed = component.m_Wpn_RotSpeed;
		this.mAccessoryLocalPos = component.m_Accessory_LocalPos;
		this.mShieldLocalPos = component.m_Shield_LocalPos;
		this.mUIPreviewCamera.fieldOfView = component.m_Fov;
		EdgeDetectEffectNormals component2 = this.mUIPreviewCamera.GetComponent<EdgeDetectEffectNormals>();
		if (component2 != null)
		{
			component2.EnableAlphaCorrection(true);
		}
		this.method_12(false);
	}

	// Token: 0x06002645 RID: 9797 RVA: 0x000B8FC8 File Offset: 0x000B71C8
	public void method_11(int int_0, int int_1)
	{
		if (this.mPreviewRTWidth != int_0 || this.mPreviewRTHeight != int_1)
		{
			this.mPreviewRTWidth = int_0;
			this.mPreviewRTHeight = int_1;
			this.mUIPrivewRT.Release();
			this.mUIPrivewRT = new RenderTexture(int_0, int_1, 24);
			this.mUIPrivewRT.Create();
		}
	}

	// Token: 0x06002646 RID: 9798 RVA: 0x00019DC8 File Offset: 0x00017FC8
	public void method_12(bool bool_0)
	{
		if (this.mUIPriveCamObj == null)
		{
			return;
		}
		this.mUIPriveCamObj.SetActive(bool_0);
		this.mUIPreviewCamera.enabled = bool_0;
		MonoSingleton<GraphicsMgr>.Instance.method_25().method_2(LightsMgr.LightObjectType.LT_UIPreviewLightsGroup, bool_0);
	}

	// Token: 0x06002647 RID: 9799 RVA: 0x00019E02 File Offset: 0x00018002
	public Texture method_13()
	{
		return this.mUIPrivewRT;
	}

	// Token: 0x06002648 RID: 9800 RVA: 0x00019E0A File Offset: 0x0001800A
	public Rect method_14()
	{
		return this.mSrcUVRect;
	}

	// Token: 0x06002649 RID: 9801 RVA: 0x00019E12 File Offset: 0x00018012
	public void method_15(Rect rect_0)
	{
		this.mSrcUVRect = rect_0;
	}

	// Token: 0x0600264A RID: 9802 RVA: 0x000B901C File Offset: 0x000B721C
	public void method_16(GameObject gameObject_0, Vector3 vector3_0, Vector3 vector3_1, bool bool_0)
	{
		if (gameObject_0 != null && this.mUIPriveCamObj != null)
		{
			this.mUIPreviewCamera.enabled = true;
			GameObject gameObject = gameObject_0.transform.Find("displayObj").gameObject;
			if (gameObject != null)
			{
				if (this.m_previousDisplayObj != null)
				{
					this.m_previousDisplayObj.layer = this.m_previousDisplayLayer;
				}
				this.m_previousDisplayObj = gameObject;
				this.m_previousDisplayLayer = gameObject.layer;
				gameObject.layer = MonoSingleton<GraphicsMgr>.Instance.method_22().method_6();
				SkinnedMeshRenderer component = gameObject.GetComponent<SkinnedMeshRenderer>();
				if (component != null)
				{
					component.useLightProbes = false;
					component.castShadows = false;
					component.receiveShadows = false;
				}
			}
			gameObject_0.transform.parent = this.mUIPriveCamObj.transform;
			Vector3 vector = Vector3.zero;
			if (bool_0)
			{
				vector = vector3_0;
			}
			else
			{
				PlayerInfoSync localPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer();
				AvatarType type = localPlayer.m_avatarDna.m_type;
				if (type == AvatarType.SIREN)
				{
					vector = this.mSirenLocalPos;
				}
				else if (type == AvatarType.SOLDIER)
				{
					vector = this.mSoldierLocalPos;
				}
				else if (type == AvatarType.BERSERKER)
				{
					vector = this.mBerserkerLocalPos;
				}
				else if (type == AvatarType.HUNTER)
				{
					vector = this.mHUNTERLocalPos;
				}
			}
			gameObject_0.transform.localPosition = vector;
			gameObject_0.transform.localRotation = Quaternion.Euler(vector3_1);
			this.method_5(gameObject_0);
		}
	}

	// Token: 0x04001BF3 RID: 7155
	private Camera mUIPreviewCamera;

	// Token: 0x04001BF4 RID: 7156
	private RenderTexture mUIPrivewRT;

	// Token: 0x04001BF5 RID: 7157
	private GameObject mUIPriveCamObj;

	// Token: 0x04001BF6 RID: 7158
	private GameObject mCamObj;

	// Token: 0x04001BF7 RID: 7159
	private int mPreviewRTWidth = 1280;

	// Token: 0x04001BF8 RID: 7160
	private int mPreviewRTHeight = 720;

	// Token: 0x04001BF9 RID: 7161
	private int mUIPreviewLayer = 24;

	// Token: 0x04001BFA RID: 7162
	private Rect mSrcUVRect;

	// Token: 0x04001BFB RID: 7163
	private Vector3 mSirenLocalPos;

	// Token: 0x04001BFC RID: 7164
	private Vector3 mSoldierLocalPos;

	// Token: 0x04001BFD RID: 7165
	private Vector3 mBerserkerLocalPos;

	// Token: 0x04001BFE RID: 7166
	private Vector3 mHUNTERLocalPos;

	// Token: 0x04001BFF RID: 7167
	private float[] mWpnLocalPos;

	// Token: 0x04001C00 RID: 7168
	private float[] mWpnRotSpeed;

	// Token: 0x04001C01 RID: 7169
	private float[] mAccessoryLocalPos;

	// Token: 0x04001C02 RID: 7170
	private float mShieldLocalPos;

	// Token: 0x04001C03 RID: 7171
	private GameObject m_previousDisplayObj;

	// Token: 0x04001C04 RID: 7172
	private int m_previousDisplayLayer = -1;

	// Token: 0x04001C05 RID: 7173
	private bool m_zoomIn = true;
}
