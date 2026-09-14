using System;
using System.Collections.Generic;
using Core;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x020005FE RID: 1534
public class Session : MonoSingleton<Session>
{
	// Token: 0x06002707 RID: 9991 RVA: 0x0001A3F0 File Offset: 0x000185F0
	public CutScene method_0()
	{
		return this.m_currentCutscene;
	}

	// Token: 0x06002708 RID: 9992 RVA: 0x0001A3F8 File Offset: 0x000185F8
	public string method_1()
	{
		return this.m_instanceName;
	}

	// Token: 0x06002709 RID: 9993 RVA: 0x0001A400 File Offset: 0x00018600
	public ELevelDifficulty method_2()
	{
		return this.m_difficulty;
	}

	// Token: 0x0600270A RID: 9994 RVA: 0x0000311D File Offset: 0x0000131D
	public int method_3()
	{
		return 0;
	}

	// Token: 0x0600270B RID: 9995 RVA: 0x0001A408 File Offset: 0x00018608
	public byte method_4()
	{
		return this.m_mapLoadingCount;
	}

	// Token: 0x0600270C RID: 9996 RVA: 0x0001A410 File Offset: 0x00018610
	public string method_5()
	{
		return this.m_mapName;
	}

	// Token: 0x0600270D RID: 9997 RVA: 0x000BC180 File Offset: 0x000BA380
	public string method_6()
	{
		IHostSession hostSession = this.method_24();
		if (hostSession != null)
		{
			return hostSession.imethod_4().method_0();
		}
		return this.m_gamemodeName;
	}

	// Token: 0x0600270E RID: 9998 RVA: 0x0001A418 File Offset: 0x00018618
	public MissionTimer method_7()
	{
		return this.m_missionTimer;
	}

	// Token: 0x0600270F RID: 9999 RVA: 0x0001A420 File Offset: 0x00018620
	public double method_8()
	{
		return NetworkManager.smethod_6() - this.m_startTime;
	}

	// Token: 0x06002710 RID: 10000 RVA: 0x0001A42E File Offset: 0x0001862E
	public double method_9()
	{
		return this.m_startTime;
	}

	// Token: 0x06002711 RID: 10001 RVA: 0x0001A436 File Offset: 0x00018636
	public void method_10(double double_0)
	{
		this.m_startTime = double_0;
	}

	// Token: 0x06002712 RID: 10002 RVA: 0x0001A43F File Offset: 0x0001863F
	public bool method_11()
	{
		return this.method_6() == "GamemodePvE" || this.method_6() == "GameModeSurvival";
	}

	// Token: 0x06002713 RID: 10003 RVA: 0x0001A466 File Offset: 0x00018666
	public bool method_12()
	{
		return this.method_6() == "GameModePvP" || this.method_6() == "GamemodeTeamDeathmatch" || this.method_6() == "GamemodeClaptrapSoccer";
	}

	// Token: 0x06002714 RID: 10004 RVA: 0x0001A49F File Offset: 0x0001869F
	public bool method_13()
	{
		return this.method_6() == "GamemodeTutorial";
	}

	// Token: 0x06002715 RID: 10005 RVA: 0x0001A4B1 File Offset: 0x000186B1
	public bool method_14()
	{
		return this.method_6() == "GamemodeTeamDeathmatch" || this.method_6() == "GamemodeClaptrapSoccer";
	}

	// Token: 0x06002716 RID: 10006 RVA: 0x0001A4D8 File Offset: 0x000186D8
	public bool method_15()
	{
		return this.method_6() == "GamemodeClaptrapSoccer";
	}

	// Token: 0x06002717 RID: 10007 RVA: 0x0001A4EA File Offset: 0x000186EA
	public bool method_16()
	{
		return this.m_isATown;
	}

	// Token: 0x06002718 RID: 10008 RVA: 0x0001A4F2 File Offset: 0x000186F2
	public bool method_17()
	{
		return GamemodeType.GamemodeRV == MatchmakingService.smethod_0(this.method_6());
	}

	// Token: 0x06002719 RID: 10009 RVA: 0x000BC1AC File Offset: 0x000BA3AC
	public bool method_18()
	{
		IHostSession hostSession = this.method_24();
		return (hostSession == null) ? (null != this.m_currentCutscene) : hostSession.imethod_11();
	}

	// Token: 0x0600271A RID: 10010 RVA: 0x0001A502 File Offset: 0x00018702
	public bool method_19()
	{
		return this.m_isSessionReportReady;
	}

	// Token: 0x0600271B RID: 10011 RVA: 0x0001A50A File Offset: 0x0001870A
	public void method_20()
	{
		this.m_isSessionReportReady = true;
	}

	// Token: 0x0600271C RID: 10012 RVA: 0x000BC1D8 File Offset: 0x000BA3D8
	public void method_21(string string_0, string string_1)
	{
		DebugUtils.Log(LogCategory.Gamelogic, "SetMapAndModeName:" + string_0 + " mode:" + string_1);
		this.m_mapName = string_0;
		this.m_gamemodeName = string_1;
		this.m_isATown = this.m_gamemodeName == "GameModeTown" || this.m_gamemodeName == "GamemodeRV";
		this.m_mapLoadingCount += 1;
		this.m_logic.OnMapChange();
	}

	// Token: 0x0600271D RID: 10013 RVA: 0x0001A513 File Offset: 0x00018713
	public void method_22(string string_0, ELevelDifficulty elevelDifficulty_0)
	{
		this.m_instanceName = string_0;
		this.m_difficulty = elevelDifficulty_0;
	}

	// Token: 0x0600271E RID: 10014 RVA: 0x0001A523 File Offset: 0x00018723
	public bool method_23()
	{
		return this.m_logic.m_isMapLoaded;
	}

	// Token: 0x0600271F RID: 10015 RVA: 0x00003727 File Offset: 0x00001927
	public IHostSession method_24()
	{
		return null;
	}

	// Token: 0x06002720 RID: 10016 RVA: 0x0001A530 File Offset: 0x00018730
	public IClientSession method_25()
	{
		return this.m_logic as ClientSession;
	}

	// Token: 0x06002721 RID: 10017 RVA: 0x000BC250 File Offset: 0x000BA450
	protected override void Awake()
	{
		base.Awake();
		if (PhotonNetwork.room == null)
		{
			DebugUtils.LogError(LogCategory.Framework, "Session.Awake - room is null, this is serious doctor? ]");
		}
		else
		{
			DebugUtils.Log(LogCategory.Framework, "Session.Awake - room[" + PhotonNetwork.room.String_1 + "]");
		}
		this.m_mapName = string.Empty;
		base.gameObject.transform.parent = MonoSingleton<AppManager>.Instance.transform;
		this.m_playerDirectory = new GameObject("Players");
		this.m_playerDirectory.transform.parent = base.transform;
		if (!string.IsNullOrEmpty(MonoSingleton<AppManager>.Instance.m_autoTestCase))
		{
			base.gameObject.AddComponent<AutoTestSync>();
			DebugUtils.Log(LogCategory.Framework, "AddComponent AutoTestSync");
		}
		this.m_logic = new ClientSession();
		this.m_logic.vmethod_0();
		this.m_logic.vmethod_1();
	}

	// Token: 0x06002722 RID: 10018 RVA: 0x0001A53D File Offset: 0x0001873D
	private void Update()
	{
		this.m_logic.vmethod_3();
	}

	// Token: 0x06002723 RID: 10019 RVA: 0x0001A54A File Offset: 0x0001874A
	public virtual void OnDestroy()
	{
		this.m_logic.vmethod_2();
		DebugUtils.Log(LogCategory.Gamelogic, "Session::OnDestroy - " + this.m_gamemodeName);
		this.method_26();
	}

	// Token: 0x06002724 RID: 10020 RVA: 0x0001A573 File Offset: 0x00018773
	private void method_26()
	{
		if (MonoSingleton<EntityManager>.Instance != null)
		{
			MonoSingleton<EntityManager>.Instance.method_8(Entity.EntityType.None);
		}
		this.m_allPlayers.Clear();
	}

	// Token: 0x06002725 RID: 10021 RVA: 0x0001A598 File Offset: 0x00018798
	public void method_27(PlayerInfoSync playerInfoSync_0)
	{
		this.m_allPlayers.Add(playerInfoSync_0);
	}

	// Token: 0x06002726 RID: 10022 RVA: 0x0001A5A6 File Offset: 0x000187A6
	public void method_28(PlayerInfoSync playerInfoSync_0)
	{
		if (this.m_localPlayer == playerInfoSync_0)
		{
			this.m_localPlayer = null;
		}
		this.m_allPlayers.Remove(playerInfoSync_0);
	}

	// Token: 0x06002727 RID: 10023 RVA: 0x000BC32C File Offset: 0x000BA52C
	public int method_29()
	{
		HashSet<int> hashSet = new HashSet<int>();
		for (int i = 0; i < this.m_allPlayers.Count; i++)
		{
			hashSet.Add(this.m_allPlayers[i].m_teamID);
		}
		return hashSet.Count;
	}

	// Token: 0x06002728 RID: 10024 RVA: 0x000BC374 File Offset: 0x000BA574
	public Camera method_30()
	{
		if (this.GetLocalPlayer() == null)
		{
			return null;
		}
		EntityPlayer entityPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer().GetEntity() as EntityPlayer;
		if (entityPlayer == null)
		{
			return null;
		}
		return entityPlayer.method_45().camera;
	}

	// Token: 0x06002729 RID: 10025 RVA: 0x000BC3BC File Offset: 0x000BA5BC
	public PlayerInfoSync GetLocalPlayer()
	{
		if (this.m_localPlayer != null)
		{
			return this.m_localPlayer;
		}
		for (int i = 0; i < this.m_allPlayers.Count; i++)
		{
			if (this.m_allPlayers[i].m_id == NetworkManager.GetActorId())
			{
				this.m_localPlayer = this.m_allPlayers[i];
				return this.m_localPlayer;
			}
		}
		return null;
	}

	// Token: 0x0600272A RID: 10026 RVA: 0x000BC428 File Offset: 0x000BA628
	public PlayerInfoSync TryGetPlayerInfoSyncById(int int_0)
	{
		for (int i = 0; i < this.m_allPlayers.Count; i++)
		{
			if (this.m_allPlayers[i].m_id == int_0)
			{
				return this.m_allPlayers[i];
			}
		}
		return null;
	}

	// Token: 0x0600272B RID: 10027 RVA: 0x000BC470 File Offset: 0x000BA670
	public PlayerInfoSync TryGetPlayerInfoSyncByCharId(int int_0)
	{
		for (int i = 0; i < this.m_allPlayers.Count; i++)
		{
			if (this.m_allPlayers[i].m_characterId == int_0)
			{
				return this.m_allPlayers[i];
			}
		}
		return null;
	}

	// Token: 0x0600272C RID: 10028 RVA: 0x000BC4B8 File Offset: 0x000BA6B8
	public PlayerInfoSync method_34(int int_0)
	{
		for (int i = 0; i < this.m_allPlayers.Count; i++)
		{
			if (this.m_allPlayers[i].m_accountId == int_0)
			{
				return this.m_allPlayers[i];
			}
		}
		return null;
	}

	// Token: 0x0600272D RID: 10029 RVA: 0x000BC500 File Offset: 0x000BA700
	public PlayerInfoSync method_35(string string_0)
	{
		for (int i = 0; i < this.m_allPlayers.Count; i++)
		{
			if (this.m_allPlayers[i].m_name == string_0)
			{
				return this.m_allPlayers[i];
			}
		}
		return null;
	}

	// Token: 0x0600272E RID: 10030 RVA: 0x000BC470 File Offset: 0x000BA670
	public PlayerInfoSync method_36(int int_0)
	{
		for (int i = 0; i < this.m_allPlayers.Count; i++)
		{
			if (this.m_allPlayers[i].m_characterId == int_0)
			{
				return this.m_allPlayers[i];
			}
		}
		return null;
	}

	// Token: 0x0600272F RID: 10031 RVA: 0x0001A5CA File Offset: 0x000187CA
	public int method_37()
	{
		return this.m_allPlayers.Count;
	}

	// Token: 0x06002730 RID: 10032 RVA: 0x0001A5D7 File Offset: 0x000187D7
	public void method_38(out List<PlayerInfoSync> list_0)
	{
		list_0 = this.m_allPlayers;
	}

	// Token: 0x06002731 RID: 10033 RVA: 0x0001A5E1 File Offset: 0x000187E1
	public void method_39(string string_0)
	{
		MonoSingleton<GameFlowManager>.Instance.method_17(string_0);
	}

	// Token: 0x06002732 RID: 10034 RVA: 0x0001A5EE File Offset: 0x000187EE
	public void OnGoToSubInstance(string mapName)
	{
		if (this.m_logic == null)
		{
			return;
		}
		this.m_logic.OnGoToSubInstance(mapName);
	}

	// Token: 0x06002733 RID: 10035 RVA: 0x0001A605 File Offset: 0x00018805
	public void OnGoToInstance()
	{
		if (this.m_logic == null)
		{
			return;
		}
		this.m_logic.OnGoToInstance();
	}

	// Token: 0x06002734 RID: 10036 RVA: 0x0001A61B File Offset: 0x0001881B
	public bool method_40()
	{
		return this.m_logic.vmethod_4();
	}

	// Token: 0x06002735 RID: 10037 RVA: 0x000BC54C File Offset: 0x000BA74C
	public void method_41(CutScene cutScene_0)
	{
		DebugUtils.Log(LogCategory.Gamelogic, "Session.StartCutscene at[" + Time.time + "]");
		MonoSingleton<AppManager>.Instance.method_0().Boolean_1 = false;
		MonoSingleton<GameFlowManager>.Instance.method_18();
		List<PlayerInfoSync> list;
		MonoSingleton<Session>.Instance.method_38(out list);
		for (int i = 0; i < list.Count; i++)
		{
			PlayerInfoSync playerInfoSync = list[i];
			EntityPlayer entityPlayer = playerInfoSync.GetEntity() as EntityPlayer;
			if (playerInfoSync.IsMyActor())
			{
				if (playerInfoSync.PlayerState_0 == PlayerInfoSync.PlayerState.Spawned || cutScene_0.m_isIntro)
				{
					MonoSingleton<InputManager>.Instance.method_1(false);
					cutScene_0.gameObject.SetActive(true);
					if (entityPlayer != null)
					{
						entityPlayer.method_59(true);
					}
					this.m_currentCutscene = cutScene_0;
				}
			}
			else if (!(entityPlayer == null))
			{
				entityPlayer.method_117(true);
			}
		}
	}

	// Token: 0x06002736 RID: 10038 RVA: 0x000BC620 File Offset: 0x000BA820
	public void method_42(CutScene cutScene_0)
	{
		DebugUtils.Log(LogCategory.Gamelogic, "Session.StopCutscene at[" + Time.time + "]");
		MonoSingleton<AppManager>.Instance.method_0().Boolean_1 = true;
		List<PlayerInfoSync> list;
		MonoSingleton<Session>.Instance.method_38(out list);
		for (int i = 0; i < list.Count; i++)
		{
			PlayerInfoSync playerInfoSync = list[i];
			EntityPlayer entityPlayer = playerInfoSync.GetEntity() as EntityPlayer;
			if (playerInfoSync.IsMyActor())
			{
				if (playerInfoSync.PlayerState_0 == PlayerInfoSync.PlayerState.Spawned || cutScene_0.m_isIntro)
				{
					cutScene_0.gameObject.SetActive(false);
					if (entityPlayer != null)
					{
						entityPlayer.method_59(false);
					}
					MonoSingleton<InputManager>.Instance.method_2(false);
					this.m_currentCutscene = null;
				}
			}
			else if (!(entityPlayer == null))
			{
				entityPlayer.method_117(false);
			}
		}
	}

	// Token: 0x04001C45 RID: 7237
	private List<PlayerInfoSync> m_allPlayers = new List<PlayerInfoSync>(8);

	// Token: 0x04001C46 RID: 7238
	private PlayerInfoSync m_localPlayer;

	// Token: 0x04001C47 RID: 7239
	private SessionLogic m_logic;

	// Token: 0x04001C48 RID: 7240
	private byte m_mapLoadingCount;

	// Token: 0x04001C49 RID: 7241
	private double m_startTime;

	// Token: 0x04001C4A RID: 7242
	public bool m_showTimerOnScreen;

	// Token: 0x04001C4B RID: 7243
	protected MissionTimer m_missionTimer = new MissionTimer();

	// Token: 0x04001C4C RID: 7244
	[HideInInspector]
	public GameObject m_playerDirectory;

	// Token: 0x04001C4D RID: 7245
	private string m_mapName;

	// Token: 0x04001C4E RID: 7246
	private string m_gamemodeName;

	// Token: 0x04001C4F RID: 7247
	private string m_instanceName;

	// Token: 0x04001C50 RID: 7248
	private ELevelDifficulty m_difficulty;

	// Token: 0x04001C51 RID: 7249
	private bool m_isATown;

	// Token: 0x04001C52 RID: 7250
	private bool m_isSessionReportReady;

	// Token: 0x04001C53 RID: 7251
	private CutScene m_currentCutscene;
}
