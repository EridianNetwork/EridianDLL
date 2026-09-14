using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using ns0;
using UnityEngine;

// Token: 0x02000694 RID: 1684
public class LoginBehaviour : StepBehaviour
{
	// Token: 0x06002BAC RID: 11180 RVA: 0x0001CD7A File Offset: 0x0001AF7A
	public override void OnShow(FrontEndStepManager.StepState lastStep, object data = null)
	{
		base.StartCoroutine(this.method_0(lastStep));
	}

	// Token: 0x06002BAD RID: 11181 RVA: 0x0001CD8A File Offset: 0x0001AF8A
	public override void vmethod_0(FrontEndStepManager.StepState stepState_0)
	{
		this.method_1();
	}

	// Token: 0x06002BAE RID: 11182 RVA: 0x000CC5C4 File Offset: 0x000CA7C4
	private IEnumerator method_0(FrontEndStepManager.StepState stepState_0)
	{
		if ("Lobby_01" != Application.loadedLevelName)
		{
			yield return StartCoroutine(ns0.MonoSingleton<GameFlowManager>.Instance.method_16("Lobby_01"));
			if (!ns0.MonoSingleton<AppManager>.Instance.m_isRebooted)
			{
				_camera = GameObject.Find("Class_selection_Camera").camera;
				_camera.enabled = false;
				_modelGroup = GameObject.Find("Model_Group");
				if (_modelGroup != null)
				{
					yield return StartCoroutine(_modelGroup.GetComponent<UIAvatarManager>().method_5());
				}
				if (!ns0.MonoSingleton<AppManager>.Instance.m_enableSndaLogin)
				{
					_camera.enabled = true;
					_camera.animation.Play("ANI_Looby_LoginCameraMovement");
				}
			}
		}
		if (!ns0.MonoSingleton<AppManager>.Instance.m_isRebooted && !ns0.MonoSingleton<AppManager>.Instance.m_enableSndaLogin)
		{
			method_3();
			yield return StartCoroutine(method_6());
			method_7();
		}
		method_2();
	}
	// Token: 0x06002BAF RID: 11183 RVA: 0x000CC5E0 File Offset: 0x000CA7E0
	private void method_1()
	{
		GameObject gameObject = GameObject.Find("LA");
		if (gameObject != null)
		{
			Transform transform = gameObject.transform.FindChild("Scenes/PRO_Looby_Logo");
			if (transform != null)
			{
				transform.gameObject.SetActive(false);
			}
		}
		if (this._loginView != null)
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_3();
			this._loginView.vmethod_3();
			this._loginView = null;
		}
	}

	// Token: 0x06002BB0 RID: 11184 RVA: 0x000CC650 File Offset: 0x000CA850
	private void method_2()
	{
		if (MonoSingleton<AppManager>.Instance.m_enableSndaLogin)
		{
			this.method_4(ShandaWrapper.ShandaTicket, "*");
		}
		else if (MonoSingleton<AppManager>.Instance.m_isRebooted)
		{
			this.method_4(MonoSingleton<AppManager>.Instance.m_login, "*");
		}
		else
		{
			this._loginView = MonoSingleton<AppManager>.Instance.method_0().vmethod_5<LoginView>();
			this._loginView._logicBehaviour = this;
			this._loginView.vmethod_2();
			this._loginView.vmethod_6(MonoSingleton<AppManager>.Instance.GetComponent<FrontEndStepManager>().accountName, MonoSingleton<AppManager>.Instance.GetComponent<FrontEndStepManager>().password);
			if (!string.IsNullOrEmpty(MonoSingleton<AppManager>.Instance.m_login))
			{
				this._loginView.vmethod_6(MonoSingleton<AppManager>.Instance.m_login, "*");
			}
		}
	}

	// Token: 0x06002BB1 RID: 11185 RVA: 0x000CC724 File Offset: 0x000CA924
	private void method_3()
	{
		MonoSingleton<AppManager>.Instance.GetComponent<FrontEndStepManager>().method_2();
		this._fastTravelModel = GameObject.Find("PRO_FastTravel");
		if (this._fastTravelModel == null)
		{
			DebugUtils.Log(LogCategory.GUI, "No fastTravelModel found!!");
		}
		this._shinningLight = GameObject.Find("PTL_ShiningLight");
		if (this._shinningLight == null)
		{
			DebugUtils.Log(LogCategory.GUI, "No SHINNINGLIGHT found!!");
		}
		else
		{
			this._shinningLight.SetActive(false);
		}
	}

	// Token: 0x06002BB2 RID: 11186 RVA: 0x0001CD92 File Offset: 0x0001AF92
	public void method_4(string string_0, string string_1)
	{
		MonoSingleton<AppManager>.Instance.GetComponent<FrontEndStepManager>().accountName = string_0;
		MonoSingleton<AppManager>.Instance.GetComponent<FrontEndStepManager>().password = string_1;
		if (this._loginView != null)
		{
			this._loginView.vmethod_5(false);
		}
		this.method_5(string_0, string_1);
	}

	// Token: 0x06002BB3 RID: 11187 RVA: 0x000CC7A0 File Offset: 0x000CA9A0
	public void method_5(string string_0, string string_1)
	{
		MonoSingleton<AsyncTaskManager>.Instance.method_6(typeof(NetworkManager.AuthenticateAsyncTask));
		if (MonoSingleton<AppManager>.Instance.GetComponent<NetworkManager>() == null)
		{
			DebugUtils.Log(LogCategory.GUI, "fail to get network manager");
			if (this._loginView != null)
			{
				this._loginView.vmethod_5(true);
			}
		}
		else
		{
			DebugUtils.Log(LogCategory.GUI, "succeeded to get network manager");
		}
		if (!MonoSingleton<AsyncTaskManager>.Instance.method_5(typeof(NetworkManager.AuthenticateAsyncTask)))
		{
			NetworkManager.AuthenticateAsyncTask authenticateAsyncTask = new NetworkManager.AuthenticateAsyncTask();
			authenticateAsyncTask.SetAuth(string_0, string_1);
			MonoSingleton<AsyncTaskManager>.Instance.method_1(authenticateAsyncTask, new TaskCompletedDelegate(this.OnAuthenticate));
			return;
		}
		MonoSingleton<AppManager>.Instance.method_8();
	}

	// Token: 0x06002BB4 RID: 11188 RVA: 0x000CC848 File Offset: 0x000CAA48
	private void OnAuthenticate(AsyncTaskBase task, AsyncTaskStatus result)
	{
		if (result == AsyncTaskStatus.Success)
		{
			OnlineService.smethod_0((task as NetworkManager.AuthenticateAsyncTask).m_login);
			CharacterService.GetCharacterListAsyncTask getCharacterListAsyncTask = new CharacterService.GetCharacterListAsyncTask();
			getCharacterListAsyncTask.method_4();
			MonoSingleton<AsyncTaskManager>.Instance.method_1(getCharacterListAsyncTask, new TaskCompletedDelegate(this.OnGetCharacterList));
			return;
		}
		if (result == AsyncTaskStatus.Error_WrongPassword)
		{
			if (this._loginView != null)
			{
				this._loginView.vmethod_5(true);
			}
			DebugUtils.LogWarning(LogCategory.GUI, "Login failed: wrong user or password, try again");
			return;
		}
		if (result == AsyncTaskStatus.Error_AuthenticationFail)
		{
			if (this._loginView != null)
			{
				this._loginView.vmethod_5(true);
			}
			DebugUtils.LogWarning(LogCategory.GUI, "Login failed: authentication fail");
			return;
		}
		if (result == AsyncTaskStatus.Error_Disconnected)
		{
			MonoSingleton<AsyncTaskManager>.Instance.method_6(typeof(NetworkManager.AuthenticateAsyncTask));
			if (this._loginView != null)
			{
				this._loginView.vmethod_5(true);
			}
			DebugUtils.LogWarning(LogCategory.GUI, "Login failed: disconnected from server");
			return;
		}
		MonoSingleton<AppManager>.Instance.method_8();
	}

	// Token: 0x06002BB5 RID: 11189 RVA: 0x000CC918 File Offset: 0x000CAB18
	private void OnGetCharacterList(AsyncTaskBase task, AsyncTaskStatus result)
	{
		if (result != AsyncTaskStatus.Success)
		{
			MonoSingleton<GameFlowManager>.Instance.method_10(true);
		}
		List<Character> characters = (task as CharacterService.GetCharacterListAsyncTask).m_characters;
		if (characters.Count > 0)
		{
			MonoSingleton<AppManager>.Instance.GetComponent<FrontEndStepManager>().Boolean_0 = true;
			if (MonoSingleton<AppManager>.Instance.m_isRebooted)
			{
				CharacterService.SelectCharacterAsyncTask selectCharacterAsyncTask = new CharacterService.SelectCharacterAsyncTask();
				selectCharacterAsyncTask.method_4(MonoSingleton<AppManager>.Instance.m_rebootedCharacterId);
				MonoSingleton<AsyncTaskManager>.Instance.method_1(selectCharacterAsyncTask, new TaskCompletedDelegate(this.OnSelecteCharacter));
			}
			else
			{
				MonoSingleton<AppManager>.Instance.GetComponent<FrontEndStepManager>().Boolean_0 = true;
				MonoSingleton<AppManager>.Instance.GetComponent<FrontEndStepManager>().method_3(FrontEndStepManager.StepState.CharacterSelect, characters);
			}
		}
		else
		{
			MonoSingleton<AppManager>.Instance.GetComponent<FrontEndStepManager>().Boolean_0 = false;
			MonoSingleton<AppManager>.Instance.GetComponent<FrontEndStepManager>().method_3(FrontEndStepManager.StepState.ClassSelect, null);
		}
	}

	// Token: 0x06002BB6 RID: 11190 RVA: 0x000CC9D8 File Offset: 0x000CABD8
	public void OnSelecteCharacter(AsyncTaskBase task, AsyncTaskStatus result)
	{
		if (result == AsyncTaskStatus.Success)
		{
			Character character = (task as CharacterService.SelectCharacterAsyncTask).m_character;
			if (character == null)
			{
				MonoSingleton<AppManager>.Instance.method_8();
				return;
			}
			PlayerProperties playerProperties = new PlayerProperties();
			playerProperties.m_id = character.Id;
			playerProperties.m_name = character.Name;
			playerProperties.m_exp = character.Experience;
			playerProperties.m_level = character.Level;
			playerProperties.m_avatarDna = new AvatarDNA();
			playerProperties.m_avatarDna.method_8(character.AvatarType, character.AvatarParts, character.AvatarMaterials, character.AvatarId);
			MonoSingleton<PlayerManager>.Instance.method_0(playerProperties, true);
			MonoSingleton<GameFlowManager>.Instance.method_11();
			MonoSingleton<AppManager>.Instance.GetComponent<FrontEndStepManager>().method_3(FrontEndStepManager.StepState.none, null);
		}
		else
		{
			MonoSingleton<AppManager>.Instance.method_8();
		}
	}

	// Token: 0x06002BB7 RID: 11191 RVA: 0x000CCAA0 File Offset: 0x000CACA0
	private IEnumerator method_6()
	{
		if (_fastTravelModel != null)
		{
			Animation tempAnimation = _fastTravelModel.transform.FindChild("Fast_Travel").animation;
			tempAnimation["Open"].wrapMode = WrapMode.Once;
			tempAnimation.Play("Open");
			BaseEventTriggerCtl m_AudioCtl = _fastTravelModel.GetComponentInChildren<BaseEventTriggerCtl>();
			if (m_AudioCtl != null)
			{
				m_AudioCtl.vmethod_1(AudioEventName.UI_FastTravel_Open);
			}
			while (tempAnimation != null && tempAnimation.isPlaying)
			{
				yield return null;
			}
		}
	}
	// Token: 0x06002BB8 RID: 11192 RVA: 0x000CCABC File Offset: 0x000CACBC
	private void method_7()
	{
		if (this._shinningLight != null)
		{
			this._shinningLight.SetActive(true);
		}
		if (this._fastTravelModel == null)
		{
			return;
		}
		Animation animation = this._fastTravelModel.transform.FindChild("Fast_Travel").animation;
		animation["Idle"].wrapMode = WrapMode.Loop;
		animation.CrossFade("Idle");
	}

	// Token: 0x04001EB9 RID: 7865
	private const string SCENE_NAME = "Lobby_01";

	// Token: 0x04001EBA RID: 7866
	private const string MODEL_GROUP_NAME = "Model_Group";

	// Token: 0x04001EBB RID: 7867
	private const string MODEL_FASTTRAVEL_NAME = "PRO_FastTravel";

	// Token: 0x04001EBC RID: 7868
	private const string MODEL_SHINNINGLIGHT_NAME = "PTL_ShiningLight";

	// Token: 0x04001EBD RID: 7869
	protected LoginView _loginView;

	// Token: 0x04001EBE RID: 7870
	private GameObject _modelGroup;

	// Token: 0x04001EBF RID: 7871
	private GameObject _fastTravelModel;

	// Token: 0x04001EC0 RID: 7872
	private GameObject _shinningLight;

	// Token: 0x04001EC1 RID: 7873
	private Camera _camera;
}
