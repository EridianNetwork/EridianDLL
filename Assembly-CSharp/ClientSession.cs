using System;
using Core;
using ns0;
using UnityEngine;

// Token: 0x020005FB RID: 1531
public class ClientSession : SessionLogic, IClientSession
{
	// Token: 0x060026DE RID: 9950 RVA: 0x0001A29C File Offset: 0x0001849C
	public override bool vmethod_4()
	{
		return this.m_SessionSM.method_3("Playing");
	}

	// Token: 0x060026DF RID: 9951 RVA: 0x000BB7D4 File Offset: 0x000B99D4
	public override void vmethod_0()
	{
		ShootingTestMenu shootingTestMenu = MonoSingleton<Session>.Instance.gameObject.AddComponent<ShootingTestMenu>();
		shootingTestMenu.m_Visible = false;
	}

	// Token: 0x060026E0 RID: 9952 RVA: 0x000BB7F8 File Offset: 0x000B99F8
	public override void vmethod_2()
	{
		if (!this.m_isDisplayingWrapupPage)
		{
			GameFlowManager prop_ = MonoSingleton<GameFlowManager>.Instance;
			if (prop_ != null)
			{
				prop_.method_11();
			}
		}
		if (MonoSingleton<GraphicsMgr>.Instance != null)
		{
			MonoSingleton<GraphicsMgr>.Instance.method_20().method_0(false);
			MonoSingleton<GraphicsMgr>.Instance.method_20().method_1(false);
		}
	}

	// Token: 0x060026E1 RID: 9953 RVA: 0x000BB850 File Offset: 0x000B9A50
	public override void vmethod_1()
	{
		this.m_SessionSM.method_0("Waiting");
		this.m_SessionSM["Waiting"].onUpdate += this.method_0;
		this.m_SessionSM["Waiting"].onExit += this.method_1;
		this.m_SessionSM.method_0("Loading");
		this.m_SessionSM["Loading"].onEnter += this.method_2;
		this.m_SessionSM["Loading"].onExit += this.method_3;
		this.m_SessionSM.method_0("StaticSynchronizing");
		this.m_SessionSM["StaticSynchronizing"].onEnter += this.method_4;
		this.m_SessionSM["StaticSynchronizing"].onUpdate += this.method_5;
		this.m_SessionSM.method_0("DynamicSynchronizing");
		this.m_SessionSM["DynamicSynchronizing"].onEnter += this.method_6;
		this.m_SessionSM["DynamicSynchronizing"].onUpdate += this.method_7;
		this.m_SessionSM["DynamicSynchronizing"].onExit += this.method_8;
		this.m_SessionSM.method_0("IntroCutscene");
		this.m_SessionSM["IntroCutscene"].onEnter += this.method_9;
		this.m_SessionSM["IntroCutscene"].onUpdate += this.method_10;
		this.m_SessionSM["IntroCutscene"].onExit += this.method_11;
		this.m_SessionSM.method_0("Playing");
		this.m_SessionSM["Playing"].onEnter += this.method_12;
		this.m_SessionSM["Playing"].onUpdate += this.method_13;
		this.m_SessionSM["Playing"].onExit += this.method_14;
		this.m_SessionSM.method_0("Interlude");
		this.m_SessionSM["Interlude"].onEnter += this.method_15;
		this.m_SessionSM["Interlude"].onUpdate += this.method_16;
		this.m_SessionSM.method_1("Waiting");
	}

	// Token: 0x060026E2 RID: 9954 RVA: 0x000BBB10 File Offset: 0x000B9D10
	private void method_0()
	{
		if (this.m_waitingTimer.method_7())
		{
			DebugUtils.LogError(LogCategory.Framework, string.Concat(new object[]
			{
				"SessionInfo_Waiting_OnUpdate [",
				PhotonNetwork.room.String_1,
				"][",
				PhotonNetwork.room.Boolean_2,
				"][",
				PhotonNetwork.room.Int32_0,
				"/",
				PhotonNetwork.room.maxPlayers,
				"][",
				MonoSingleton<Session>.Instance.method_5(),
				"]"
			}));
			MonoSingleton<GameFlowManager>.Instance.method_20();
		}
		if (!this.m_waitingTimer.method_6())
		{
			this.m_waitingTimer.Start(60f);
		}
	}

	// Token: 0x060026E3 RID: 9955 RVA: 0x000BBBE8 File Offset: 0x000B9DE8
	private void method_1()
	{
		MonoSingleton<Session>.Instance.gameObject.AddComponent<PlayerSkillTreeManage>();
		MonoSingleton<Session>.Instance.gameObject.AddComponent<PassiveSkillsManager>();
		if (MonoSingleton<Session>.Instance.method_16())
		{
			if (InteractionManager.InteractionManager_0 == null)
			{
				MonoSingleton<Session>.Instance.gameObject.AddComponent<InteractionManager>();
			}
			if (MonoSingleton<TownNpcManager>.Instance == null)
			{
				MonoSingleton<Session>.Instance.gameObject.AddComponent<TownNpcManager>();
			}
			if (MonoSingleton<VisibilityManager>.Instance == null)
			{
				MonoSingleton<Session>.Instance.gameObject.AddComponent<VisibilityManager>();
			}
		}
		else
		{
			MonoSingleton<Session>.Instance.gameObject.AddComponent<AttackManager>();
			MonoSingleton<Session>.Instance.gameObject.AddComponent<Arbitrator>();
			DamageManager damageManager = MonoSingleton<Session>.Instance.gameObject.AddComponent<DamageManager>();
			damageManager.method_3(MonoSingleton<LevelingManager>.Instance);
			damageManager.method_3(MonoSingleton<ScoringManager>.Instance);
		}
	}

	// Token: 0x060026E4 RID: 9956 RVA: 0x000BBCC0 File Offset: 0x000B9EC0
	private void method_2()
	{
		if (LevelObjectSyncManager.LevelObjectSyncManager_0)
		{
			LevelObjectSyncManager.LevelObjectSyncManager_0.method_2();
		}
		DebugUtils.Log(LogCategory.Gamelogic, "SessionInfo_Loading_OnEnter:" + Time.time);
		this.m_isMapLoaded = false;
		MonoSingleton<Session>.Instance.method_39(MonoSingleton<Session>.Instance.method_5());
		if (MonoSingleton<GuidanceTipsManager>.Instance != null)
		{
			MonoSingleton<GuidanceTipsManager>.Instance.method_2("guidance_selection");
		}
	}

	// Token: 0x060026E5 RID: 9957 RVA: 0x0001A2AE File Offset: 0x000184AE
	private void method_3()
	{
		DebugUtils.Log(LogCategory.Gamelogic, "SessionInfo_Loading_OnExit:" + Time.time);
		MonoSingleton<StatisticsManager>.Instance.method_1();
		this.m_isMapLoaded = true;
	}

	// Token: 0x060026E6 RID: 9958 RVA: 0x000BBD34 File Offset: 0x000B9F34
	private void method_4()
	{
		DebugUtils.Log(LogCategory.Gamelogic, "SessionInfo_StaticSynchronizing_OnEnter:" + Time.time);
		global::UnityEngine.Object[] array = global::UnityEngine.Object.FindObjectsOfType(typeof(StaticEntitySpawner));
		this.m_staticNetworkObjectCount = array.Length;
		PhotonNetwork.SetReceivingEnabled(1, true);
	}

	// Token: 0x060026E7 RID: 9959 RVA: 0x000BBD7C File Offset: 0x000B9F7C
	private void method_5()
	{
		int num = MonoSingleton<EntityManager>.Instance.method_9(Entity.EntityType.Object);
		if (num >= this.m_staticNetworkObjectCount)
		{
			this.m_SessionSM.method_1("DynamicSynchronizing");
		}
	}

	// Token: 0x060026E8 RID: 9960 RVA: 0x0001A2DB File Offset: 0x000184DB
	private void method_6()
	{
		DebugUtils.Log(LogCategory.Gamelogic, "SessionInfo_DynamicSynchronizing_OnEnter:" + Time.time);
		PhotonNetwork.SetReceivingEnabled(2, true);
		this.m_syncTimer.Start(1f);
	}

	// Token: 0x060026E9 RID: 9961 RVA: 0x0001A30E File Offset: 0x0001850E
	private void method_7()
	{
		if (this.m_syncTimer.method_7())
		{
			this.m_SessionSM.method_1("IntroCutscene");
		}
	}

	// Token: 0x060026EA RID: 9962 RVA: 0x000BBDB0 File Offset: 0x000B9FB0
	private void method_8()
	{
		DebugUtils.Log(LogCategory.Gamelogic, "SessionInfo_DynamicSynchronizing_OnExit:" + Time.time);
		PlayerInfoSync localPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer();
		if (localPlayer != null)
		{
			PhotonNetwork.SetReceivingEnabled(3, true);
		}
	}

	// Token: 0x060026EB RID: 9963 RVA: 0x000BBDF4 File Offset: 0x000B9FF4
	private void method_9()
	{
		global::UnityEngine.Object[] array = Resources.FindObjectsOfTypeAll(typeof(CutScene));
		for (int i = 0; i < array.Length; i++)
		{
			CutScene cutScene = array[i] as CutScene;
			if (cutScene != null && cutScene.m_isIntro)
			{
				this.m_intro = cutScene;
				MonoSingleton<Session>.Instance.method_41(this.m_intro);
				return;
			}
		}
		this.m_SessionSM.method_1("Playing");
	}

	// Token: 0x060026EC RID: 9964 RVA: 0x000BBE64 File Offset: 0x000BA064
	private void method_10()
	{
		if (this.m_intro != null)
		{
			bool flag = false;
			Animation[] componentsInChildren = this.m_intro.gameObject.GetComponentsInChildren<Animation>(true);
			foreach (Animation animation in componentsInChildren)
			{
				if (animation != null)
				{
					flag |= animation.isPlaying;
				}
			}
			if (!flag)
			{
				this.m_SessionSM.method_1("Playing");
			}
		}
	}

	// Token: 0x060026ED RID: 9965 RVA: 0x0001A32D File Offset: 0x0001852D
	private void method_11()
	{
		if (this.m_intro != null)
		{
			MonoSingleton<Session>.Instance.method_42(this.m_intro);
		}
		this.m_intro = null;
		SessionInfo.SessionInfo_0.method_0();
	}

	// Token: 0x060026EE RID: 9966 RVA: 0x000BBED4 File Offset: 0x000BA0D4
	private void method_12()
	{
		DebugUtils.Log(LogCategory.Gamelogic, "SessionInfo_Playing_OnEnter:" + Time.time);
		MonoSingleton<ScoringManager>.Instance.method_1();
		PlayerInfoSync localPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer();
		if (localPlayer)
		{
			MonoSingleton<InputManager>.Instance.method_2(false);
		}
	}

	// Token: 0x060026EF RID: 9967 RVA: 0x0001A35E File Offset: 0x0001855E
	private void method_13()
	{
		if (MonoSingleton<Session>.Instance.method_12())
		{
			MonoSingleton<ScoringManager>.Instance.method_2();
		}
	}

	// Token: 0x060026F0 RID: 9968 RVA: 0x000BBF24 File Offset: 0x000BA124
	private void method_14()
	{
		DebugUtils.Log(LogCategory.Gamelogic, "SessionInfo_Playing_OnExit:" + Time.time);
		PlayerInfoSync localPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer();
		if (localPlayer)
		{
			switch (localPlayer.PlayerState_0)
			{
			case PlayerInfoSync.PlayerState.MapReady:
				localPlayer.PlayerState_0 = PlayerInfoSync.PlayerState.None;
				break;
			case PlayerInfoSync.PlayerState.PlayerAndMapReady:
			case PlayerInfoSync.PlayerState.Spawned:
				localPlayer.PlayerState_0 = PlayerInfoSync.PlayerState.PlayerReady;
				break;
			}
		}
		if (MonoSingleton<global::EchoMessageManager>.Instance != null)
		{
			MonoSingleton<global::EchoMessageManager>.Instance.method_1();
		}
		PhotonNetwork.SetReceivingEnabled(1, false);
		PhotonNetwork.SetReceivingEnabled(2, false);
		PhotonNetwork.SetReceivingEnabled(3, false);
	}

	// Token: 0x060026F1 RID: 9969 RVA: 0x000BBFBC File Offset: 0x000BA1BC
	private void method_15()
	{
		DebugUtils.Log(LogCategory.Gamelogic, "SessionInfo_Interlude_OnEnter:" + Time.time);
		this.m_isDisplayingWrapupPage = false;
		if (string.IsNullOrEmpty(MonoSingleton<Session>.Instance.method_5()))
		{
			Camera[] allCameras = Camera.allCameras;
			for (int i = 0; i < allCameras.Length; i++)
			{
				if (allCameras[i].GetComponent<EstablishingShotCam>() != null)
				{
					allCameras[i].enabled = true;
				}
			}
			if (MonoSingleton<Session>.Instance != null && MonoSingleton<Session>.Instance.method_12())
			{
				DebugUtils.LogWarning(LogCategory.Framework, "Client Session -- Deinitialize  -- ShowSummaryBoard");
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDPvPInfoView>().vmethod_6();
				this.m_isDisplayingWrapupPage = true;
			}
			else if (MonoSingleton<AppManager>.Instance != null && (MonoSingleton<Session>.Instance.method_6() == "GamemodePvE" || MonoSingleton<Session>.Instance.method_6() == "GameModeSurvival"))
			{
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDWrapupView>().vmethod_6();
				this.m_isDisplayingWrapupPage = true;
			}
			MonoSingleton<ScoringManager>.Instance.method_6();
		}
		this.m_interludeTimer.Start(1f);
	}

	// Token: 0x060026F2 RID: 9970 RVA: 0x000BC0DC File Offset: 0x000BA2DC
	private void method_16()
	{
		if (string.IsNullOrEmpty(MonoSingleton<Session>.Instance.method_5()))
		{
			return;
		}
		if (this.m_interludeTimer.method_7())
		{
			if (MonoSingleton<GraphicsMgr>.Instance != null)
			{
				MonoSingleton<GraphicsMgr>.Instance.OnDestroyPerMapResources();
			}
			this.m_SessionSM.method_1("Loading");
		}
	}

	// Token: 0x060026F3 RID: 9971 RVA: 0x0001A376 File Offset: 0x00018576
	public void imethod_0()
	{
		this.m_isDisplayingWrapupPage = true;
	}

	// Token: 0x060026F4 RID: 9972 RVA: 0x0001A37F File Offset: 0x0001857F
	public override void OnMapChange()
	{
		if (this.m_SessionSM.method_3("Playing") || this.m_SessionSM.method_3("Waiting"))
		{
			this.m_SessionSM.method_1("Interlude");
		}
	}

	// Token: 0x060026F5 RID: 9973 RVA: 0x000BC130 File Offset: 0x000BA330
	public override void OnGoToSubInstance(string mapName)
	{
		DebugUtils.Log(LogCategory.Gamelogic, string.Concat(new object[]
		{
			"ClientSession.OnGoToSubInstance: ",
			mapName,
			" ...done - ",
			Time.realtimeSinceStartup
		}));
		this.m_SessionSM.method_1("StaticSynchronizing");
	}

	// Token: 0x060026F6 RID: 9974 RVA: 0x0001A3B5 File Offset: 0x000185B5
	public override void OnGoToInstance()
	{
		DebugUtils.Log(LogCategory.Gamelogic, "Am I ready");
		SessionInfo.SessionInfo_0.method_2(OnlineService.s_characterId);
	}

	// Token: 0x04001C3F RID: 7231
	private Utils.Timer m_interludeTimer = new Utils.Timer();

	// Token: 0x04001C40 RID: 7232
	private Utils.Timer m_syncTimer = new Utils.Timer();

	// Token: 0x04001C41 RID: 7233
	private int m_staticNetworkObjectCount;

	// Token: 0x04001C42 RID: 7234
	private bool m_isDisplayingWrapupPage;

	// Token: 0x04001C43 RID: 7235
	private CutScene m_intro;

	// Token: 0x04001C44 RID: 7236
	private Utils.Timer m_waitingTimer = new Utils.Timer();
}
