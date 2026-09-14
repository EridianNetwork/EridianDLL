using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Core;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x02000688 RID: 1672
public class ClassSelectBehaviour : StepBehaviour
{
	// Token: 0x06002B33 RID: 11059 RVA: 0x0000311B File Offset: 0x0000131B
	private void Awake()
	{
	}

	// Token: 0x06002B34 RID: 11060 RVA: 0x0001CA3F File Offset: 0x0001AC3F
	public override void OnShow(FrontEndStepManager.StepState lastStep, object data = null)
	{
		base.StartCoroutine(this.method_3(lastStep));
	}

	// Token: 0x06002B35 RID: 11061 RVA: 0x0001CA4F File Offset: 0x0001AC4F
	public override void vmethod_0(FrontEndStepManager.StepState stepState_0)
	{
		this.method_0();
	}

	// Token: 0x06002B36 RID: 11062 RVA: 0x0001CA57 File Offset: 0x0001AC57
	private void method_0()
	{
		this._avatarManager.method_3();
		this._classSelectView.vmethod_3();
		this._classSelectView = null;
	}

	// Token: 0x06002B37 RID: 11063 RVA: 0x000C9BAC File Offset: 0x000C7DAC
	private void method_1()
	{
		this._classSelectView = MonoSingleton<AppManager>.Instance.method_0().vmethod_5<ClassSelectView>();
		this._classSelectView._logicBehaviour = this;
		this._classSelectView.vmethod_2();
		this._classSelectView.vmethod_6(new ClassSelectView.ClassChangeEvent(this.method_7));
		this._classSelectView.vmethod_5(new ClassSelectView.ClassChangeEvent(this.method_8));
	}

	// Token: 0x06002B38 RID: 11064 RVA: 0x000C9C14 File Offset: 0x000C7E14
	private void method_2()
	{
		MonoSingleton<AppManager>.Instance.GetComponent<FrontEndStepManager>().method_0();
		this._camera = GameObject.Find("Class_selection_Camera").camera;
		this._camera.enabled = true;
		this._fastTravelModel = GameObject.Find("PRO_FastTravel");
		if (this._fastTravelModel == null)
		{
			DebugUtils.Log(LogCategory.GUI, "No fastTravelModel found!!");
		}
		this._modelGroup = GameObject.Find("Model_Group");
		if (this._modelGroup != null)
		{
			this._avatarManager = this._modelGroup.GetComponent<UIAvatarManager>();
		}
	}

	// Token: 0x06002B39 RID: 11065 RVA: 0x000C9CAC File Offset: 0x000C7EAC
	private IEnumerator method_3(FrontEndStepManager.StepState stepState_0)
	{
		if ("Lobby_01" != Application.loadedLevelName)
		{
			yield return StartCoroutine(ns0.MonoSingleton<GameFlowManager>.Instance.method_16("Lobby_01"));
		}
		method_2();
		method_1();
		method_12();
		_classSelectView.vmethod_8();
		_classSelectView.vmethod_9(ns0.MonoSingleton<AppManager>.Instance.GetComponent<FrontEndStepManager>().AvatarType_0);
	}
	// Token: 0x06002B3A RID: 11066 RVA: 0x0001CA76 File Offset: 0x0001AC76
	private GameObject method_4(AvatarType avatarType_0)
	{
		if (avatarType_0 == AvatarType.SOLDIER)
		{
			return GameObject.Find("CHR_Soldier_03");
		}
		return null;
	}

	// Token: 0x06002B3B RID: 11067 RVA: 0x0001CA88 File Offset: 0x0001AC88
	public void method_5()
	{
		MonoSingleton<AppManager>.Instance.GetComponent<FrontEndStepManager>().method_3(FrontEndStepManager.StepState.Login, null);
	}

	// Token: 0x06002B3C RID: 11068 RVA: 0x0001CA9B File Offset: 0x0001AC9B
	public void method_6()
	{
		MonoSingleton<AppManager>.Instance.GetComponent<FrontEndStepManager>().AvatarType_0 = this._curClassType;
		MonoSingleton<AppManager>.Instance.GetComponent<FrontEndStepManager>().method_3(FrontEndStepManager.StepState.CharacterCreate, null);
	}

	// Token: 0x06002B3D RID: 11069 RVA: 0x000C9CC8 File Offset: 0x000C7EC8
	public void method_7(AvatarType avatarType_0)
	{
		FE_ClassInfo fe_ClassInfo = this._avatarManager.method_1(avatarType_0);
		if (fe_ClassInfo == null)
		{
			return;
		}
		if (this._curModel != null)
		{
			this._curModel.SetActive(false);
		}
		this._curModel = fe_ClassInfo.classModel;
		this._curModel.SetActive(true);
		base.StartCoroutine(this.method_10(fe_ClassInfo.classModel, fe_ClassInfo.bFirstTimeShow));
		this._classSelectView.vmethod_7(avatarType_0, fe_ClassInfo.strDisplayName, fe_ClassInfo.strIntro, fe_ClassInfo.bFirstTimeShow);
		this._avatarManager.method_0(this._curModel.GetComponentInChildren<Animator>());
		fe_ClassInfo.bFirstTimeShow = false;
		this._curClassType = avatarType_0;
	}

	// Token: 0x06002B3E RID: 11070 RVA: 0x000C9D74 File Offset: 0x000C7F74
	public void method_8(AvatarType avatarType_0)
	{
		FE_ClassInfo fe_ClassInfo = this._avatarManager.method_1(avatarType_0);
		if (fe_ClassInfo == null)
		{
			return;
		}
		this._classSelectView.vmethod_7(avatarType_0, fe_ClassInfo.strDisplayName, fe_ClassInfo.strIntro, fe_ClassInfo.bFirstTimeShow);
	}

	// Token: 0x06002B3F RID: 11071 RVA: 0x0001CAC3 File Offset: 0x0001ACC3
	private void OnDNACreateProcess(int errorCode)
	{
		if (errorCode == 0)
		{
			if (MonoSingleton<AppManager>.Instance.m_skipTutorial)
			{
				MonoSingleton<GameFlowManager>.Instance.method_11();
			}
			else
			{
				MonoSingleton<GameFlowManager>.Instance.method_3();
			}
		}
	}

	// Token: 0x06002B40 RID: 11072 RVA: 0x0000311B File Offset: 0x0000131B
	private void method_9()
	{
	}

	// Token: 0x06002B41 RID: 11073 RVA: 0x000C9DB0 File Offset: 0x000C7FB0
	private IEnumerator method_10(GameObject gameObject_0, bool bool_0)
	{
		if (!(gameObject_0 != null) || !bool_0)
		{
			yield break;
		}
		gameObject_0.SetActive(value: true);
		Transform effectParent = _modelGroup.transform.FindChild("PTL_Resurrection");
		if (effectParent == null)
		{
			yield break;
		}
		ParticleSystem effct = effectParent.particleSystem;
		if (effct == null)
		{
			yield break;
		}
		effectParent.gameObject.SetActive(value: true);
		effct.Play();
		ModelFadeIn tempfadeInEff = gameObject_0.GetComponentInChildren<ModelFadeIn>();
		if (tempfadeInEff != null)
		{
			tempfadeInEff.vmethod_0();
			while (tempfadeInEff.Boolean_0)
			{
				yield return null;
			}
		}
	}
	// Token: 0x06002B42 RID: 11074 RVA: 0x0001CAEA File Offset: 0x0001ACEA
	private void method_11()
	{
		if (this._fastTravelModel == null)
		{
			return;
		}
		this._fastTravelModel.transform.FindChild("Fast_Travel").animation.Rewind("Open");
	}

	// Token: 0x06002B43 RID: 11075 RVA: 0x000C9DE8 File Offset: 0x000C7FE8
	private void method_12()
	{
		if (this._fastTravelModel == null)
		{
			return;
		}
		Animation animation = this._fastTravelModel.transform.FindChild("Fast_Travel").animation;
		animation["Idle"].wrapMode = WrapMode.Loop;
		animation.CrossFade("Idle");
	}

	// Token: 0x06002B44 RID: 11076 RVA: 0x000C9E3C File Offset: 0x000C803C
	private IEnumerator method_13()
	{
		if (_fastTravelModel != null)
		{
			Animation tempAnimation = _fastTravelModel.transform.FindChild("Fast_Travel").animation;
			tempAnimation["Open"].wrapMode = WrapMode.Once;
			tempAnimation.Play("Open");
			while (tempAnimation.isPlaying)
			{
				yield return null;
			}
		}
	}
	// Token: 0x04001E67 RID: 7783
	private const string MODEL_FASTTRAVEL_NAME = "PRO_FastTravel";

	// Token: 0x04001E68 RID: 7784
	private const string SCENE_NAME = "Lobby_01";

	// Token: 0x04001E69 RID: 7785
	protected ClassSelectView _classSelectView;

	// Token: 0x04001E6A RID: 7786
	protected UIAvatarManager _avatarManager;

	// Token: 0x04001E6B RID: 7787
	protected Dictionary<AvatarType, FE_ClassInfo> _mapClassInfo;

	// Token: 0x04001E6C RID: 7788
	private GameObject _curModel;

	// Token: 0x04001E6D RID: 7789
	private GameObject _fastTravelModel;

	// Token: 0x04001E6E RID: 7790
	private GameObject _modelGroup;

	// Token: 0x04001E6F RID: 7791
	private Camera _camera;

	// Token: 0x04001E70 RID: 7792
	private AvatarType _curClassType = AvatarType.TOTAL;
}
