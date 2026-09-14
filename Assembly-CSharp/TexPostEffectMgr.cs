using System;
using UnityEngine;

// Token: 0x020005E4 RID: 1508
public class TexPostEffectMgr
{
	// Token: 0x0600261E RID: 9758 RVA: 0x00019D41 File Offset: 0x00017F41
	public Texture2D method_0()
	{
		return this.mOutputTex;
	}

	// Token: 0x0600261F RID: 9759 RVA: 0x000B7F9C File Offset: 0x000B619C
	private void method_1(GameObject gameObject_0, ref Camera camera_0, GameObject gameObject_1)
	{
		camera_0 = gameObject_0.AddComponent<Camera>();
		camera_0.clearFlags = CameraClearFlags.Nothing;
		camera_0.depth = 101f;
		camera_0.hdr = true;
		camera_0.gameObject.AddComponent<TexPostEffectLogicStart>();
		ComponentHelper.smethod_0(gameObject_1, camera_0.gameObject);
		camera_0.gameObject.AddComponent<TexPostEffectLogic>();
		camera_0.gameObject.SetActive(false);
	}

	// Token: 0x06002620 RID: 9760 RVA: 0x000B8004 File Offset: 0x000B6204
	private void method_2(GameObject gameObject_0, string string_0, ref Camera camera_0, string string_1)
	{
		GameObject gameObject = new GameObject(string_0);
		gameObject.transform.parent = gameObject_0.transform;
		gameObject.transform.localPosition = new Vector3(0f, 0f, 0f);
		GameObject gameObject2 = Resources.Load(string_1) as GameObject;
		this.method_1(gameObject, ref camera_0, gameObject2);
	}

	// Token: 0x06002621 RID: 9761 RVA: 0x000B8060 File Offset: 0x000B6260
	public void method_3(GameObject gameObject_0)
	{
		this.method_2(gameObject_0, "UI_PostEffect_Cam", ref this.mUIPostEffectCam, "CameraEffect/EffectCamera_UI_Snap");
		this.method_2(gameObject_0, "Font_PostEffect_Cam", ref this.mFontPostEffectCam, "CameraEffect/EffectCamera_UI_Snap");
		this.method_2(gameObject_0, "BluePrint_PostEffect_Cam", ref this.mBluePrintPostEffectCam, "CameraEffect/EffectCamera_UI_Snap_BluePrint");
		this.method_2(gameObject_0, "Craft_PostEffect_Cam", ref this.mCraftPostEffectCam, "CameraEffect/EffectCamera_UI_Snap_Craft");
		this.method_2(gameObject_0, "Lock_PostEffect_Cam", ref this.mLockPostEffectCam, "CameraEffect/EffectCamera_UI_Snap_Lock");
		this.method_2(gameObject_0, "Unlock_PostEffect_Cam", ref this.mUnlockPostEffectCam, "CameraEffect/EffectCamera_UI_Snap_Unlock");
	}

	// Token: 0x06002622 RID: 9762 RVA: 0x000B80F8 File Offset: 0x000B62F8
	public void method_4(Texture2D texture2D_0, TexPostEffectMgr.POST_EFFECT_TYPE post_EFFECT_TYPE_0)
	{
		if (post_EFFECT_TYPE_0 == TexPostEffectMgr.POST_EFFECT_TYPE.POST_EFFECT_UI)
		{
			this.mCurPostEfefctCam = this.mUIPostEffectCam;
		}
		else if (post_EFFECT_TYPE_0 == TexPostEffectMgr.POST_EFFECT_TYPE.POST_EFFECT_FONT)
		{
			this.mCurPostEfefctCam = this.mFontPostEffectCam;
		}
		else if (post_EFFECT_TYPE_0 == TexPostEffectMgr.POST_EFFECT_TYPE.POST_EFFECT_BlUEPRINT)
		{
			this.mCurPostEfefctCam = this.mBluePrintPostEffectCam;
		}
		else if (post_EFFECT_TYPE_0 == TexPostEffectMgr.POST_EFFECT_TYPE.POST_EFFECT_CRAFT)
		{
			this.mCurPostEfefctCam = this.mCraftPostEffectCam;
		}
		else if (post_EFFECT_TYPE_0 == TexPostEffectMgr.POST_EFFECT_TYPE.POST_EFFECT_LOCK)
		{
			this.mCurPostEfefctCam = this.mLockPostEffectCam;
		}
		else if (post_EFFECT_TYPE_0 == TexPostEffectMgr.POST_EFFECT_TYPE.POST_EFFECT_UNLOCK)
		{
			this.mCurPostEfefctCam = this.mUnlockPostEffectCam;
		}
		this.mCurPostEfefctCam.gameObject.SetActive(true);
		if (texture2D_0 == null)
		{
			return;
		}
		this.mRT = RenderTexture.GetTemporary(texture2D_0.width, texture2D_0.height);
		this.mCurPostEfefctCam.targetTexture = this.mRT;
		this.mOutputTex = texture2D_0;
	}

	// Token: 0x06002623 RID: 9763 RVA: 0x000B81B8 File Offset: 0x000B63B8
	public void method_5()
	{
		if (this.mRT != null)
		{
			RenderTexture.active = this.mRT;
			this.mOutputTex.ReadPixels(new Rect(0f, 0f, (float)this.mRT.width, (float)this.mRT.height), 0, 0);
			this.mOutputTex.Apply();
			RenderTexture.active = null;
			RenderTexture.ReleaseTemporary(this.mRT);
			this.mRT = null;
		}
		this.mCurPostEfefctCam.gameObject.SetActive(false);
	}

	// Token: 0x04001BBE RID: 7102
	private Camera mUIPostEffectCam;

	// Token: 0x04001BBF RID: 7103
	private Camera mFontPostEffectCam;

	// Token: 0x04001BC0 RID: 7104
	private Camera mBluePrintPostEffectCam;

	// Token: 0x04001BC1 RID: 7105
	private Camera mCraftPostEffectCam;

	// Token: 0x04001BC2 RID: 7106
	private Camera mLockPostEffectCam;

	// Token: 0x04001BC3 RID: 7107
	private Camera mUnlockPostEffectCam;

	// Token: 0x04001BC4 RID: 7108
	private Camera mCurPostEfefctCam;

	// Token: 0x04001BC5 RID: 7109
	private Texture2D mOutputTex;

	// Token: 0x04001BC6 RID: 7110
	private RenderTexture mRT;

	// Token: 0x020005E5 RID: 1509
	public enum POST_EFFECT_TYPE
	{
		// Token: 0x04001BC8 RID: 7112
		POST_EFFECT_UI,
		// Token: 0x04001BC9 RID: 7113
		POST_EFFECT_FONT,
		// Token: 0x04001BCA RID: 7114
		POST_EFFECT_BlUEPRINT,
		// Token: 0x04001BCB RID: 7115
		POST_EFFECT_CRAFT,
		// Token: 0x04001BCC RID: 7116
		POST_EFFECT_LOCK,
		// Token: 0x04001BCD RID: 7117
		POST_EFFECT_UNLOCK,
		// Token: 0x04001BCE RID: 7118
		POST_EFFECT_NUM
	}
}
