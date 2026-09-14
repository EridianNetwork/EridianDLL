using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Core;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x02000279 RID: 633
public class GameFlowManager : MonoSingleton<GameFlowManager>
{
	// Token: 0x06000D81 RID: 3457 RVA: 0x0000C820 File Offset: 0x0000AA20
	protected override void Awake()
	{
		base.Awake();
		base.gameObject.AddComponent<NetworkManager>();
		if (SystemInfo.graphicsDeviceID != 0)
		{
			this.m_menuManager = base.gameObject.AddComponent<MenuManager>();
		}
	}

	// Token: 0x06000D82 RID: 3458 RVA: 0x0000C84C File Offset: 0x0000AA4C
	public void method_0()
	{
		GameFlowManager.m_needLockedCursor = true;
		Screen.lockCursor = true;
	}

	// Token: 0x06000D83 RID: 3459 RVA: 0x0000C85A File Offset: 0x0000AA5A
	public void method_1()
	{
		Screen.lockCursor = false;
		GameFlowManager.m_needLockedCursor = false;
	}

	// Token: 0x06000D84 RID: 3460 RVA: 0x00070074 File Offset: 0x0006E274
	private void Update()
	{
		if (!NetworkManager.smethod_3() || MonoSingleton<AppManager>.Instance.m_offlineMode)
		{
			if (GameFlowManager.m_needLockedCursor && !Screen.lockCursor)
			{
				Screen.lockCursor = GameFlowManager.m_needLockedCursor;
			}
			if (Input.GetKeyDown(KeyCode.F9))
			{
				HudFps componentInChildren = MonoSingleton<AppManager>.Instance.GetComponentInChildren<HudFps>();
				if (componentInChildren != null)
				{
					componentInChildren.enabled = !componentInChildren.enabled;
				}
			}
			if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Return))
			{
				Screen.lockCursor = false;
				if (!Screen.fullScreen)
				{
					Screen.SetResolution(Screen.width, Screen.height, true);
				}
				else
				{
					Screen.SetResolution(Screen.width, Screen.height, false);
				}
			}
		}
	}

	// Token: 0x06000D85 RID: 3461 RVA: 0x0000C868 File Offset: 0x0000AA68
	public void method_2()
	{
		if (!MonoSingleton<AppManager>.Instance.m_isRebooted)
		{
			Application.LoadLevelAdditiveAsync("LoadingPage");
		}
		else
		{
			this.OnLogoCutsceneFinished();
		}
	}

	// Token: 0x06000D86 RID: 3462 RVA: 0x0000C889 File Offset: 0x0000AA89
	public void OnLogoCutsceneFinished()
	{
		this.method_10(true);
	}

	// Token: 0x06000D87 RID: 3463 RVA: 0x0000C892 File Offset: 0x0000AA92
	public void method_3()
	{
		MonoSingleton<GameFlowManager>.Instance.method_0();
		base.StartCoroutine(this.method_4());
		if (this.m_menuManager != null)
		{
			this.m_menuManager.method_0(MenuManager.MenuPage.None);
		}
		MonoSingleton<AppManager>.Instance.method_1(false);
	}

	// Token: 0x06000D88 RID: 3464 RVA: 0x00070124 File Offset: 0x0006E324
	public IEnumerator method_4()
	{
		if (ns0.ComponentMonoSingleton<AudioSystem>.Boolean_0)
		{
			IEnumerator Loader = ns0.ComponentMonoSingleton<AudioSystem>.Instance.AudioResourceManager_0.method_5("CutsceneAudioResources", bool_0: false, "aud_pkg_manual_sfx_cutscene_introa_mix");
			while (Loader.MoveNext())
			{
				yield return Loader.Current;
			}
		}
		Application.LoadLevelAsync("IntroCutscene");
	}
	// Token: 0x06000D89 RID: 3465 RVA: 0x0000C8D0 File Offset: 0x0000AAD0
	public void OnIntroCutsceneFinished()
	{
		this.method_5();
	}

	// Token: 0x06000D8A RID: 3466 RVA: 0x00070138 File Offset: 0x0006E338
	public void method_5()
	{
		if (MonoSingleton<AppManager>.Instance.method_9())
		{
			return;
		}
		DebugUtils.Log(LogCategory.Framework, "GoToTutorial");
		MonoSingleton<AppManager>.Instance.method_0().vmethod_10(false);
		if (!this.m_transitionToLogin && !this.m_transitionToInstanceSelection && !this.m_transitionToIngame)
		{
			this.method_8(MatchmakingService.MatchmakingService_0.method_3("lvl_Tutorial_Part1").m_id);
		}
	}

	// Token: 0x06000D8B RID: 3467 RVA: 0x000701A0 File Offset: 0x0006E3A0
	public void method_6()
	{
		if (MonoSingleton<AppManager>.Instance.method_9())
		{
			return;
		}
		DebugUtils.Log(LogCategory.Framework, "GoToRV");
		MonoSingleton<AppManager>.Instance.method_0().vmethod_10(false);
		if (!this.m_transitionToLogin && !this.m_transitionToInstanceSelection && !this.m_transitionToIngame)
		{
			Playlist playlist = MatchmakingService.MatchmakingService_0.method_3("lvl_RV");
			this.method_8(playlist.m_id);
		}
	}

	// Token: 0x06000D8C RID: 3468 RVA: 0x0007020C File Offset: 0x0006E40C
	public void method_7()
	{
		if (MonoSingleton<AppManager>.Instance.method_9())
		{
			return;
		}
		DebugUtils.Log(LogCategory.Framework, "GoToTown");
		if (NetworkManager.smethod_4())
		{
			return;
		}
		if (MonoSingleton<AppManager>.Instance.method_18())
		{
			MonoSingleton<AppManager>.Instance.method_7();
		}
		MonoSingleton<AppManager>.Instance.method_0().vmethod_10(false);
		if (MonoSingleton<LevelLoadingManager>.Instance.method_3())
		{
			MonoSingleton<LevelLoadingManager>.Instance.method_5();
		}
		if (!this.m_transitionToIngame)
		{
			this.m_transitionToIngame = true;
			base.StartCoroutine(this.method_23());
		}
	}

	// Token: 0x06000D8D RID: 3469 RVA: 0x00070294 File Offset: 0x0006E494
	public void method_8(int int_0)
	{
		if (MonoSingleton<AppManager>.Instance.method_9())
		{
			return;
		}
		DebugUtils.Log(LogCategory.Framework, "GoToInstance");
		MonoSingleton<AppManager>.Instance.method_0().vmethod_10(false);
		if (MonoSingleton<LevelLoadingManager>.Instance.method_3())
		{
			MonoSingleton<LevelLoadingManager>.Instance.method_5();
		}
		if (!this.m_transitionToIngame)
		{
			this.m_transitionToIngame = true;
			base.StartCoroutine(this.method_24(int_0));
		}
	}

	// Token: 0x06000D8E RID: 3470 RVA: 0x000702FC File Offset: 0x0006E4FC
	public void method_9(string string_0)
	{
		if (MonoSingleton<AppManager>.Instance.method_9())
		{
			return;
		}
		DebugUtils.Log(LogCategory.Framework, "GoToInstance");
		MonoSingleton<AppManager>.Instance.method_0().vmethod_10(false);
		if (MonoSingleton<LevelLoadingManager>.Instance.method_3())
		{
			MonoSingleton<LevelLoadingManager>.Instance.method_5();
		}
		if (!this.m_transitionToIngame)
		{
			this.m_transitionToIngame = true;
			base.StartCoroutine(this.method_25(string_0));
		}
	}

	// Token: 0x06000D8F RID: 3471 RVA: 0x00070364 File Offset: 0x0006E564
	public void method_10(bool bool_0 = false)
	{
		if (MonoSingleton<AppManager>.Instance.method_9())
		{
			return;
		}
		DebugUtils.Log(LogCategory.Framework, "GoToLogin - " + bool_0);
		MonoSingleton<AppManager>.Instance.method_0().vmethod_10(false);
		if (bool_0)
		{
			ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_2();
			OnlineService.s_userName = string.Empty;
		}
		if (!this.m_transitionToInstanceSelection && !this.m_transitionToIngame)
		{
			this.m_transitionToLogin = true;
			base.StartCoroutine(this.method_13(false, false));
			this.method_18();
		}
	}

	// Token: 0x06000D90 RID: 3472 RVA: 0x000703E8 File Offset: 0x0006E5E8
	public void method_11()
	{
		if (MonoSingleton<AppManager>.Instance.method_9())
		{
			return;
		}
		if (NetworkManager.smethod_4())
		{
			return;
		}
		DebugUtils.Log(LogCategory.Framework, "GoToLobby");
		MonoSingleton<AppManager>.Instance.method_0().vmethod_10(false);
		if (!this.m_transitionToLogin && !this.m_transitionToInstanceSelection && !this.m_transitionToIngame)
		{
			MonoSingleton<StatisticsManager>.Instance.method_2();
			this.method_18();
			if (PhotonNetwork.networkingPeer != null && PhotonNetwork.networkingPeer.mLastJoinType == JoinType.JoinGame && MonoSingleton<Session>.Instance != null && !MonoSingleton<Session>.Instance.method_16())
			{
				if (GroupManager.smethod_0() != null && GroupManager.smethod_0().method_18())
				{
					MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDWarningView>().vmethod_7(LocalizedString.smethod_0(new LocalizedString("Leaving_instance_question_group")), new Delegate_EventProc(this.method_7), delegate
					{
					});
					return;
				}
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDWarningView>().vmethod_7(LocalizedString.smethod_0(new LocalizedString("Leaving_instance_question")), new Delegate_EventProc(this.method_7), delegate
				{
				});
				return;
			}
			else
			{
				Playlist playlist = null;
				if (MonoSingleton<Session>.Instance != null)
				{
					string text = MonoSingleton<Session>.Instance.method_1();
					if (!string.IsNullOrEmpty(text))
					{
						playlist = MatchmakingService.MatchmakingService_0.method_2(text);
					}
				}
				if (playlist != null)
				{
					this.method_8(playlist.m_id);
					return;
				}
				base.StartCoroutine(this.method_13(true, true));
			}
		}
	}

	// Token: 0x06000D91 RID: 3473 RVA: 0x00070590 File Offset: 0x0006E790
	public void method_12(int int_0, GamemodeType gamemodeType_0)
	{
		if (MonoSingleton<AppManager>.Instance.method_9())
		{
			return;
		}
		DebugUtils.Log(LogCategory.Framework, "GoToLobbyGame");
		MonoSingleton<AppManager>.Instance.method_0().vmethod_10(false);
		if (MonoSingleton<LevelLoadingManager>.Instance.method_3())
		{
			MonoSingleton<LevelLoadingManager>.Instance.method_5();
		}
		if (!this.m_transitionToIngame)
		{
			this.m_transitionToIngame = true;
			base.StartCoroutine(this.method_26(int_0, gamemodeType_0));
		}
	}

	// Token: 0x06000D92 RID: 3474 RVA: 0x000705FC File Offset: 0x0006E7FC
	private IEnumerator method_13(bool bool_0, bool bool_1)
	{
		DebugUtils.Log(LogCategory.Framework, "Loading Menu...");
		if (bool_0 && bool_1)
		{
			if (ns0.MonoSingleton<AppManager>.Instance.m_usePlaylistId)
			{
				method_8(ns0.MonoSingleton<AppManager>.Instance.m_playlistId);
			}
			else
			{
				method_7();
			}
			yield break;
		}
		MatchmakingService.LeaveRoomAsyncTask leaveRoom = new MatchmakingService.LeaveRoomAsyncTask();
		leaveRoom.method_4();
		ns0.MonoSingleton<AsyncTaskManager>.Instance.method_1(leaveRoom);
		while (!leaveRoom.IsStatus())
		{
			yield return 0;
		}
		yield return Application.LoadLevelAsync("ResourcesLoading");
		ns0.MonoSingleton<AppManager>.Instance.method_1(bool_0: true);
		if (bool_0)
		{
			ns0.MonoSingleton<AppManager>.Instance.method_12(bool_0: false);
		}
		ns0.MonoSingleton<AppManager>.Instance.method_0().vmethod_15();
		if (m_menuManager != null)
		{
			m_menuManager.method_0(MenuManager.MenuPage.None);
			ns0.MonoSingleton<GameFlowManager>.Instance.method_1();
		}
		if (bool_0)
		{
			if (!bool_1)
			{
				ns0.MonoSingleton<AppManager>.Instance.GetComponent<FrontEndStepManager>().method_3(FrontEndStepManager.StepState.WorldMap);
				m_transitionToInstanceSelection = false;
				OnAccessSingleton<IInventoryService, InventoryService, InventoryServiceOffline>.Prop_0.imethod_1(OnlineService.s_characterId);
			}
		}
		else
		{
			yield return ns0.MonoSingleton<AppManager>.Instance.StartCoroutine(ns0.MonoSingleton<AppManager>.Instance.GetComponent<NetworkManager>().method_7());
			ns0.MonoSingleton<AppManager>.Instance.method_0().vmethod_10(bool_0: true);
			ns0.MonoSingleton<AppManager>.Instance.GetComponent<FrontEndStepManager>().method_3(FrontEndStepManager.StepState.Login);
			m_transitionToLogin = false;
		}
	}
	// Token: 0x06000D93 RID: 3475 RVA: 0x00070634 File Offset: 0x0006E834
	private IEnumerator method_14()
	{
		if (ns0.ComponentMonoSingleton<AudioSystem>.Boolean_0)
		{
			int audioWaitCounter = 30;
			while (!ns0.MonoSingleton<AppManager>.Instance.method_0().vmethod_9() && audioWaitCounter != 0)
			{
				audioWaitCounter--;
				yield return new WaitForSeconds(1f);
			}
			if (audioWaitCounter == 0)
			{
				DebugUtils.LogError(LogCategory.Audio, "Timeout waiting for UI Music to load");
			}
		}
	}
	// Token: 0x06000D94 RID: 3476 RVA: 0x00070648 File Offset: 0x0006E848
	private IEnumerator method_15()
	{
		if (ns0.ComponentMonoSingleton<AudioSystem>.Boolean_0)
		{
			IEnumerator UIAudioResourceLoader = ns0.ComponentMonoSingleton<AudioSystem>.Instance.AudioResourceManager_0.method_5("FrontEndAudioResources", bool_0: false, string.Empty);
			while (UIAudioResourceLoader.MoveNext())
			{
				yield return UIAudioResourceLoader.Current;
			}
		}
	}
	// Token: 0x06000D95 RID: 3477 RVA: 0x0007065C File Offset: 0x0006E85C
	public IEnumerator method_16(string string_0)
	{
		float downloadProgress = 0f;
		IEnumerator loader = method_15();
		while (loader.MoveNext())
		{
			yield return loader.Current;
		}
		IEnumerator waiter = method_14();
		while (waiter.MoveNext())
		{
			yield return waiter.Current;
		}
		if (!ns0.MonoSingleton<AppManager>.Instance.m_isRebooted)
		{
			while (!Application.CanStreamedLevelBeLoaded(string_0))
			{
				downloadProgress = Application.GetStreamProgressForLevel(string_0);
				yield return null;
			}
			DebugUtils.Log(LogCategory.Framework, "LoadingDemoCorountine progress: " + downloadProgress);
			yield return Application.LoadLevelAsync(string_0);
		}
	}
	// Token: 0x06000D96 RID: 3478 RVA: 0x00070688 File Offset: 0x0006E888
	public void method_17(string string_0)
	{
		DebugUtils.Log(LogCategory.Framework, string.Concat(new object[]
		{
			"Go to sub level[",
			string_0,
			"] -",
			Time.realtimeSinceStartup
		}));
		base.StartCoroutine(this.method_19(string_0));
	}

	// Token: 0x06000D97 RID: 3479 RVA: 0x0000C8D8 File Offset: 0x0000AAD8
	public void method_18()
	{
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<LoadingInGameView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_12(true);
	}

	// Token: 0x06000D98 RID: 3480 RVA: 0x000706D8 File Offset: 0x0006E8D8
	private IEnumerator method_19(string string_0)
	{
		ns0.ServiceWrapperBase<PlayerSpawnClusterManager>.Instance.Reset();
		if (!ns0.MonoSingleton<LevelLoadingManager>.Instance.method_7(string_0))
		{
			m_transitionToIngame = false;
			method_20();
			yield break;
		}
		while (ns0.MonoSingleton<LevelLoadingManager>.Instance.method_3())
		{
			yield return null;
		}
		if (ns0.MonoSingleton<LevelLoadingManager>.Instance.method_4())
		{
			method_20();
		}
		else
		{
			ns0.MonoSingleton<Session>.Instance.OnGoToSubInstance(string_0);
		}
	}
	// Token: 0x06000D99 RID: 3481 RVA: 0x00070704 File Offset: 0x0006E904
	public void method_20()
	{
		if (NetworkManager.smethod_4())
		{
			return;
		}
		MonoSingleton<GameFlowManager>.Instance.method_18();
		MonoSingleton<AppManager>.Instance.method_1(true);
		MonoSingleton<AppManager>.Instance.method_0().vmethod_10(true);
		MonoSingleton<InputManager>.Instance.method_2(false);
		HUDWarningView hudwarningView = MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDWarningView>();
		hudwarningView.vmethod_7(LocalizedString.smethod_0(new LocalizedString("LoadingError_GoToTown")), new Delegate_EventProc(this.method_21), null);
	}

	// Token: 0x06000D9A RID: 3482 RVA: 0x0000C8FA File Offset: 0x0000AAFA
	private void method_21()
	{
		this.m_transitionToIngame = false;
		MonoSingleton<GameFlowManager>.Instance.method_7();
	}

	// Token: 0x06000D9B RID: 3483 RVA: 0x0007077C File Offset: 0x0006E97C
	private IEnumerator method_22()
	{
		PreJoinAsyncTask preJoin = new PreJoinAsyncTask();
		preJoin.method_4();
		ns0.MonoSingleton<AsyncTaskManager>.Instance.method_1(preJoin);
		while (!preJoin.IsStatus())
		{
			yield return 0;
		}
		if (preJoin.GetStatus() != AsyncTaskStatus.Success)
		{
			m_transitionToIngame = false;
			method_20();
		}
	}
	// Token: 0x06000D9C RID: 3484 RVA: 0x00070798 File Offset: 0x0006E998
	public IEnumerator method_23()
	{
		yield return StartCoroutine(method_22());
		int townID = ns0.ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_23();
		Playlist playlist = MatchmakingService.MatchmakingService_0.method_1(townID);
		if (playlist == null)
		{
			DebugUtils.Log(LogCategory.Network, "Trying to enter Playlist [" + townID + "]");
			playlist = MatchmakingService.MatchmakingService_0.method_3("lvl_Floasm_Small");
		}
		ns0.MonoSingleton<AppManager>.Instance.m_playlistId = playlist.m_id;
		bool playlistFound = false;
		while (true)
		{
			if (playlistFound)
			{
				yield return StartCoroutine(method_27());
				yield break;
			}
			if (ns0.MonoSingleton<AsyncTaskManager>.Instance.method_5(typeof(MatchmakingService.FindMeAPlaylistAsyncTask)))
			{
				break;
			}
			MatchmakingService.FindMeAPlaylistAsyncTask findSession = new MatchmakingService.FindMeAPlaylistAsyncTask();
			findSession.method_4(OnlineService.s_characterId, playlist.m_id);
			ns0.MonoSingleton<AsyncTaskManager>.Instance.method_1(findSession);
			while (!findSession.IsStatus())
			{
				yield return 0;
			}
			AsyncTaskStatus result = findSession.GetStatus();
			if (result == AsyncTaskStatus.Success)
			{
				playlistFound = true;
			}
			yield return 0;
		}
		ns0.MonoSingleton<AsyncTaskManager>.Instance.method_6(typeof(MatchmakingService.FindMeAPlaylistAsyncTask));
		method_20();
	}
	// Token: 0x06000D9D RID: 3485 RVA: 0x000707B4 File Offset: 0x0006E9B4
	public IEnumerator method_24(int int_0)
	{
		yield return StartCoroutine(method_22());
		ns0.MonoSingleton<AppManager>.Instance.m_playlistId = int_0;
		bool playlistFound = false;
		MatchmakingService.FindMeAPlaylistAsyncTask findSession2 = null;
		while (true)
		{
			if (playlistFound)
			{
				yield return StartCoroutine(method_27());
				yield break;
			}
			if (ns0.MonoSingleton<AsyncTaskManager>.Instance.method_5(typeof(MatchmakingService.FindMeAPlaylistAsyncTask)))
			{
				break;
			}
			findSession2 = new MatchmakingService.FindMeAPlaylistAsyncTask();
			findSession2.method_4(OnlineService.s_characterId, int_0);
			ns0.MonoSingleton<AsyncTaskManager>.Instance.method_1(findSession2);
			while (!findSession2.IsStatus())
			{
				yield return 0;
			}
			AsyncTaskStatus result = findSession2.GetStatus();
			if (result == AsyncTaskStatus.Success)
			{
				playlistFound = true;
			}
			yield return 0;
		}
		ns0.MonoSingleton<AsyncTaskManager>.Instance.method_6(typeof(MatchmakingService.FindMeAPlaylistAsyncTask));
		method_20();
	}
	// Token: 0x06000D9E RID: 3486 RVA: 0x000707E0 File Offset: 0x0006E9E0
	public IEnumerator method_25(string string_0)
	{
		yield return StartCoroutine(method_22());
		MatchmakingService.JoinRoomAsyncTask joinSession = new MatchmakingService.JoinRoomAsyncTask();
		joinSession.method_4(string_0);
		ns0.MonoSingleton<AsyncTaskManager>.Instance.method_1(joinSession);
		while (!joinSession.IsStatus())
		{
			yield return 0;
		}
		if (joinSession.GetStatus() != AsyncTaskStatus.Success)
		{
			m_transitionToIngame = false;
			if (ns0.MonoSingleton<AsyncTaskManager>.Instance.method_5(joinSession.GetType()))
			{
				ns0.MonoSingleton<AsyncTaskManager>.Instance.method_6(joinSession.GetType());
			}
			method_20();
		}
		else
		{
			yield return StartCoroutine(method_27());
		}
	}
	// Token: 0x06000D9F RID: 3487 RVA: 0x0007080C File Offset: 0x0006EA0C
	public IEnumerator method_26(int int_0, GamemodeType gamemodeType_0)
	{
		yield return StartCoroutine(method_22());
		ns0.MonoSingleton<AppManager>.Instance.m_playlistId = int_0;
		MatchmakingService.StartPvPMatchAsyncTask startPvPMatch = new MatchmakingService.StartPvPMatchAsyncTask();
		startPvPMatch.method_4(int_0, gamemodeType_0);
		ns0.MonoSingleton<AsyncTaskManager>.Instance.method_1(startPvPMatch);
		while (!startPvPMatch.IsStatus())
		{
			yield return 0;
		}
		if (startPvPMatch.GetStatus() != AsyncTaskStatus.Success)
		{
			method_20();
		}
		else
		{
			yield return StartCoroutine(method_27());
		}
	}
	// Token: 0x06000DA0 RID: 3488 RVA: 0x00070844 File Offset: 0x0006EA44
	private IEnumerator method_27()
	{
		PostJoinAsyncTask postJoin = new PostJoinAsyncTask();
		postJoin.method_4();
		ns0.MonoSingleton<AsyncTaskManager>.Instance.method_1(postJoin);
		while (!postJoin.IsStatus())
		{
			yield return 0;
		}
		m_transitionToIngame = false;
		if (postJoin.GetStatus() != AsyncTaskStatus.Success)
		{
			method_20();
		}
		else
		{
			ns0.MonoSingleton<Session>.Instance.OnGoToInstance();
		}
	}
	// Token: 0x06000DA1 RID: 3489 RVA: 0x0000311B File Offset: 0x0000131B
	private void method_28(Dictionary<int, int> dictionary_0)
	{
	}

	// Token: 0x04000C48 RID: 3144
	private const int MAX_WAIT_AUDIO_SECONDS = 30;

	// Token: 0x04000C49 RID: 3145
	private const string AUDIO_RESOURCES_LIST_NAME = "FrontEndAudioResources";

	// Token: 0x04000C4A RID: 3146
	private const string CUTSCENE_AUDIO_RESOURCES_LIST_NAME = "CutsceneAudioResources";

	// Token: 0x04000C4B RID: 3147
	[HideInInspector]
	public static bool m_isPause;

	// Token: 0x04000C4C RID: 3148
	[HideInInspector]
	public static bool m_needLockedCursor;

	// Token: 0x04000C4D RID: 3149
	[HideInInspector]
	private bool m_transitionToInstanceSelection;

	// Token: 0x04000C4E RID: 3150
	[HideInInspector]
	private bool m_transitionToIngame;

	// Token: 0x04000C4F RID: 3151
	[HideInInspector]
	private bool m_transitionToLogin;

	// Token: 0x04000C50 RID: 3152
	private MenuManager m_menuManager;
}
