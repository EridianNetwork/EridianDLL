using System;
using System.Collections.Generic;
using Core;
using ns0;
using UnityEngine;

// Token: 0x0200058E RID: 1422
public class CameraEffectMgr
{
	// Token: 0x0600245F RID: 9311 RVA: 0x000AE10C File Offset: 0x000AC30C
	public void method_0(Camera camera_0, bool bool_0)
	{
		if (!bool_0)
		{
			this.mCurPostEffect.Clear();
			this.imageEffectArray = camera_0.GetComponents<PostEffectsBase>();
			if (this.imageEffectArray != null)
			{
				for (int i = 0; i < this.imageEffectArray.Length; i++)
				{
					PostEffectsBase postEffectsBase = this.imageEffectArray[i];
					if (postEffectsBase.enabled)
					{
						postEffectsBase.enabled = false;
						this.mCurPostEffect.Add(postEffectsBase);
					}
				}
			}
		}
		else
		{
			for (int j = 0; j < this.mCurPostEffect.Count; j++)
			{
				PostEffectsBase postEffectsBase2 = this.mCurPostEffect[j];
				postEffectsBase2.enabled = true;
			}
		}
	}

	// Token: 0x06002460 RID: 9312 RVA: 0x000AE1A0 File Offset: 0x000AC3A0
	public void method_1()
	{
		if (this.mFpsCamera != null)
		{
			ImageEffectBase[] components = this.mFpsCamera.GetComponents<ImageEffectBase>();
			if (components != null)
			{
				for (int i = 0; i < components.Length; i++)
				{
					global::UnityEngine.Object.DestroyImmediate(components[i]);
				}
			}
			PostEffectsBase[] components2 = this.mFpsCamera.GetComponents<PostEffectsBase>();
			if (components2 != null)
			{
				for (int j = 0; j < components2.Length; j++)
				{
					global::UnityEngine.Object.DestroyImmediate(components2[j]);
				}
			}
			SSAOEffect component = this.mFpsCamera.GetComponent<SSAOEffect>();
			if (component != null)
			{
				global::UnityEngine.Object.DestroyImmediate(component);
			}
			this.method_4();
		}
	}

	// Token: 0x06002461 RID: 9313 RVA: 0x000AE22C File Offset: 0x000AC42C
	private void method_2()
	{
		if (MonoSingleton<AppManager>.Instance.OnlineHostMinResMode)
		{
			return;
		}
		Camera component = this.mFpsCamera.GetComponent<Camera>();
		component.farClipPlane = MonoSingleton<LevelLoadingManager>.Instance.m_farClip;
		component.cullingMask &= -21102593;
	}

	// Token: 0x06002462 RID: 9314 RVA: 0x00018D70 File Offset: 0x00016F70
	public void method_3(GameObject gameObject_0)
	{
		this.mFpsCamera = gameObject_0;
	}

	// Token: 0x06002463 RID: 9315 RVA: 0x000AE274 File Offset: 0x000AC474
	public void method_4()
	{
		this.method_2();
		this.mCurPostEffect = new List<PostEffectsBase>();
		string text = MonoSingleton<LevelLoadingManager>.Instance.method_0();
		string text2 = "CameraEffect/" + text;
		GameObject gameObject = Resources.Load(text2) as GameObject;
		if (gameObject == null)
		{
			DebugUtils.LogWarning(LogCategory.Graphics, "Can't get the effectCamera base the level name : " + text + ". Use the default camera effect");
			gameObject = Resources.Load("EffectCamera_out") as GameObject;
		}
		GameObject gameObject2 = global::UnityEngine.Object.Instantiate(gameObject) as GameObject;
		if (gameObject2)
		{
			if (this.mFpsCamera != null)
			{
				ComponentHelper.smethod_0(gameObject2, this.mFpsCamera);
				MonoSingleton<QualityManager>.Instance.method_45(this.mFpsCamera);
				SunShafts component = this.mFpsCamera.GetComponent<SunShafts>();
				if (component != null)
				{
					GameObject gameObject3 = GameObject.Find("PRO_SunShaftObject");
					if (gameObject3 != null)
					{
						component.sunTransform = gameObject3.transform;
					}
					else
					{
						global::UnityEngine.Object.DestroyImmediate(component);
					}
				}
				global::UnityEngine.Object.DestroyImmediate(gameObject2);
			}
		}
		else
		{
			DebugUtils.LogWarning(LogCategory.Graphics, "*****LevelEffectCamera missing!");
		}
		PauseMenuBlurEffect component2 = (Resources.Load("Graphics/GraphicsData") as GameObject).GetComponent<PauseMenuBlurEffect>();
		if (component2)
		{
			this.mUiBlur = this.mFpsCamera.AddComponent<PauseMenuBlurEffect>();
			ComponentHelper.smethod_1(component2, this.mUiBlur);
			this.mUiBlur.enabled = false;
		}
		DizzyEffect component3 = (Resources.Load("Graphics/GraphicsData") as GameObject).GetComponent<DizzyEffect>();
		if (component3)
		{
			DizzyEffect dizzyEffect = this.mFpsCamera.AddComponent<DizzyEffect>();
			ComponentHelper.smethod_1(component3, dizzyEffect);
			dizzyEffect.enabled = false;
		}
		SecondWindEffect component4 = (Resources.Load("Graphics/GraphicsData") as GameObject).GetComponent<SecondWindEffect>();
		if (component4)
		{
			SecondWindEffect secondWindEffect = this.mFpsCamera.AddComponent<SecondWindEffect>();
			ComponentHelper.smethod_1(component4, secondWindEffect);
			secondWindEffect.enabled = false;
		}
		VignetteEffect component5 = (Resources.Load("Graphics/GraphicsData") as GameObject).GetComponent<VignetteEffect>();
		if (component5)
		{
			VignetteEffect vignetteEffect = this.mFpsCamera.AddComponent<VignetteEffect>();
			ComponentHelper.smethod_1(component5, vignetteEffect);
			vignetteEffect.enabled = true;
		}
	}

	// Token: 0x06002464 RID: 9316 RVA: 0x000AE480 File Offset: 0x000AC680
	public void method_5(bool bool_0 = true)
	{
		DizzyEffect component = this.mFpsCamera.GetComponent<DizzyEffect>();
		if (component != null)
		{
			component.enabled = bool_0;
		}
	}

	// Token: 0x06002465 RID: 9317 RVA: 0x000AE4AC File Offset: 0x000AC6AC
	public void method_6(bool bool_0)
	{
		if (this.mFpsCamera != null)
		{
			SecondWindEffect component = this.mFpsCamera.GetComponent<SecondWindEffect>();
			if (component != null)
			{
				component.enabled = bool_0;
			}
		}
	}

	// Token: 0x06002466 RID: 9318 RVA: 0x000AE4E4 File Offset: 0x000AC6E4
	public void method_7(float float_0)
	{
		SecondWindEffect component = this.mFpsCamera.GetComponent<SecondWindEffect>();
		if (component != null)
		{
			component.CurrentVignettePercentage = Mathf.Clamp(float_0, 0f, 1f);
		}
	}

	// Token: 0x06002467 RID: 9319 RVA: 0x000AE51C File Offset: 0x000AC71C
	public void method_8(bool bool_0)
	{
		if (this.mUiBlur != null)
		{
			this.mUiBlur.enabled = !bool_0;
		}
		if (this.mUiBlur != null && bool_0)
		{
			for (int i = 0; i < this.mCurPostEffect.Count; i++)
			{
				if (this.mUiBlur == this.mCurPostEffect[i])
				{
					this.mCurPostEffect.Remove(this.mCurPostEffect[i]);
					break;
				}
			}
		}
	}

	// Token: 0x0400192F RID: 6447
	private GameObject mFpsCamera;

	// Token: 0x04001930 RID: 6448
	private PostEffectsBase[] imageEffectArray;

	// Token: 0x04001931 RID: 6449
	private PauseMenuBlurEffect mUiBlur;

	// Token: 0x04001932 RID: 6450
	private List<PostEffectsBase> mCurPostEffect;
}
