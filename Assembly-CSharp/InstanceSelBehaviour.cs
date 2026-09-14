using System;
using System.Collections;
using System.Collections.Generic;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x02000690 RID: 1680
public class InstanceSelBehaviour : StepBehaviour, IQuestServiceNotificationListerner, IQuestUINotificationListerner
{
	// Token: 0x06002B84 RID: 11140 RVA: 0x0001CD04 File Offset: 0x0001AF04
	public override void OnShow(FrontEndStepManager.StepState lastStep, object data = null)
	{
		MonoSingleton<AppManager>.Instance.method_0().vmethod_12(true);
		base.StartCoroutine(this.method_1(lastStep));
	}

	// Token: 0x06002B85 RID: 11141 RVA: 0x000CBA7C File Offset: 0x000C9C7C
	public override void vmethod_0(FrontEndStepManager.StepState stepState_0)
	{
		MonoSingleton<AppManager>.Instance.method_0().vmethod_12(true);
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<InventoryView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<CharInfoView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<QuestListView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<NPCDialogView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<QuestTrackView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<MatchMakingView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<SkillTreeView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InstanceSelectView>()._enterLevelFunc = null;
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<InstanceSelectView>();
		QuestUIDataManager.smethod_0().method_6();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_3();
		QuestUIDataManager.smethod_0().method_1(this);
	}

	// Token: 0x06002B86 RID: 11142 RVA: 0x000CBB54 File Offset: 0x000C9D54
	private void method_0()
	{
		GameObject gameObject = GameObject.Find("LA");
		if (gameObject != null)
		{
			Transform transform = gameObject.transform.FindChild("Camera/LobbyCameraContainer");
			if (transform != null)
			{
				transform.gameObject.SetActive(true);
			}
			transform = gameObject.transform.FindChild("Scenes/Character_sellection");
			if (transform != null)
			{
				transform.gameObject.SetActive(false);
			}
			transform = gameObject.transform.FindChild("Camera/Class_selection_Camera");
			if (transform != null)
			{
				transform.gameObject.SetActive(false);
			}
		}
		gameObject = GameObject.Find("LD");
		LobbyBehaviour[] componentsInChildren = gameObject.GetComponentsInChildren<LobbyBehaviour>(true);
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i]._EnterLevelProc = new Delegate_EnterLevelProc(this.method_3);
			componentsInChildren[i].method_0();
		}
	}

	// Token: 0x06002B87 RID: 11143 RVA: 0x000CBC24 File Offset: 0x000C9E24
	private IEnumerator method_1(FrontEndStepManager.StepState stepState_0)
	{
		if (!ns0.MonoSingleton<AppManager>.Instance.m_offlineMode)
		{
			CharacterService.GetSelectedCharacterAsyncTask getSelectedCharacter = new CharacterService.GetSelectedCharacterAsyncTask();
			getSelectedCharacter.method_4();
			ns0.MonoSingleton<AsyncTaskManager>.Instance.method_1(getSelectedCharacter);
			while (!getSelectedCharacter.IsStatus())
			{
				yield return 0;
			}
		}
		if ("Lobby_01" != Application.loadedLevelName)
		{
			yield return StartCoroutine(ns0.MonoSingleton<GameFlowManager>.Instance.method_16("Lobby_01"));
		}
		LevelLockingManager.smethod_0().method_9();
		QuestUIDataManager.smethod_0().method_5();
		method_2();
		QuestUIDataManager.smethod_0().method_0(this);
	}
	// Token: 0x06002B88 RID: 11144 RVA: 0x000CBC40 File Offset: 0x000C9E40
	private void Update()
	{
		if (this._funcWaitingCheck != null)
		{
			this._funcWaitingCheck();
		}
		if (LevelLockingManager.smethod_0().m_bQuestInited && GameObject.Find("LA") != null && GameObject.Find("LD") != null)
		{
			LevelLockingManager.smethod_0().m_bQuestInited = false;
			this.method_0();
		}
		this.method_4();
	}

	// Token: 0x06002B89 RID: 11145 RVA: 0x000CBCA8 File Offset: 0x000C9EA8
	public void method_2()
	{
		InstanceSelectView instanceSelectView = MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InstanceSelectView>();
		instanceSelectView.vmethod_2();
		instanceSelectView._enterLevelFunc = new Delegate_EnterLevelProc(this.method_3);
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<InventoryView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<CharInfoView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<QuestTrackView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<QuestListView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<NPCDialogView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<MatchMakingView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<SkillTreeView>();
	}

	// Token: 0x06002B8A RID: 11146 RVA: 0x000CBD50 File Offset: 0x000C9F50
	public void method_3(int int_0)
	{
		if (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<MatchMakingView>().Boolean_0)
		{
			MonoSingleton<AppManager>.Instance.method_0().Boolean_0 = true;
			if (int_0 != 3 && int_0 != 4)
			{
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<MatchMakingView>().vmethod_5();
			}
			MonoSingleton<GameFlowManager>.Instance.method_8(int_0);
		}
	}

	// Token: 0x06002B8B RID: 11147 RVA: 0x000CBDAC File Offset: 0x000C9FAC
	private void method_4()
	{
		PlayerProperties playerProperties = new PlayerProperties();
		playerProperties.m_name = ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_9();
		playerProperties.m_exp = ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_7();
		playerProperties.m_avatarDna = ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_13();
		playerProperties.m_level = ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_8();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InstanceSelectView>().vmethod_7(playerProperties);
		if (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<CharInfoView>() != null)
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<CharInfoView>().vmethod_6(playerProperties);
		}
	}

	// Token: 0x06002B8C RID: 11148 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnQuestUpdate(int characterId, int questId, QuestState questState)
	{
	}

	// Token: 0x06002B8D RID: 11149 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnQuestAccepted(int characterId, int questId)
	{
	}

	// Token: 0x06002B8E RID: 11150 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnQuestAbandoned(int characterId, int questId)
	{
	}

	// Token: 0x06002B8F RID: 11151 RVA: 0x0001CD24 File Offset: 0x0001AF24
	public void OnQuestRewardClaimed(int characterId, int questId, QuestReward[] rewards)
	{
		if (LevelLockingManager.smethod_0().method_3())
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<QuestListView>().Boolean_1 = false;
		}
	}

	// Token: 0x06002B90 RID: 11152 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnNewTask(int iCharacterID, int iQuestID, int iNewTaskID)
	{
	}

	// Token: 0x06002B91 RID: 11153 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnQuestProgress(int characterId, Dictionary<int, QuestProgress> playerQuestProgress)
	{
	}

	// Token: 0x06002B92 RID: 11154 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnTaskProgressUpgrade(int questID, int taskID, int count)
	{
	}

	// Token: 0x04001EAA RID: 7850
	private const string SCENE_NAME = "Lobby_01";

	// Token: 0x04001EAB RID: 7851
	protected LobbyCameraController _camController;

	// Token: 0x04001EAC RID: 7852
	private InstanceSelBehaviour.InputCheckFunc _funcWaitingCheck;

	// Token: 0x02000691 RID: 1681
	// (Invoke) Token: 0x06002B94 RID: 11156
	private delegate void InputCheckFunc();
}
