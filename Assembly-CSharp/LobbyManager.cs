using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x0200067E RID: 1662
public class LobbyManager : ILobbyServiceNotificationListerner
{
	// Token: 0x06002A96 RID: 10902 RVA: 0x000C7560 File Offset: 0x000C5760
	private LobbyManager()
	{
		if (this.m_PlayerRecord == null)
		{
			this.m_PlayerRecord = new Dictionary<int, MatchRecord>();
			this.m_PlayerRecord.Clear();
			this.m_RankList = new List<Rank>();
			this.m_RankList.Clear();
			this.m_FriendAndGuildRankList = new List<Rank>();
			this.m_FriendAndGuildRankList.Clear();
		}
	}

	// Token: 0x17000214 RID: 532
	// (get) Token: 0x06002A97 RID: 10903 RVA: 0x0001C1FD File Offset: 0x0001A3FD
	public Lobby Lobby_0
	{
		get
		{
			return this.m_MyRoom;
		}
	}

	// Token: 0x17000215 RID: 533
	// (get) Token: 0x06002A98 RID: 10904 RVA: 0x0001C205 File Offset: 0x0001A405
	public Lobby Lobby_1
	{
		get
		{
			return this.m_MyPvERoom;
		}
	}

	// Token: 0x06002A99 RID: 10905 RVA: 0x0001C20D File Offset: 0x0001A40D
	public static LobbyManager smethod_0()
	{
		if (LobbyManager._LobbyInstance == null)
		{
			LobbyManager._LobbyInstance = new LobbyManager();
			ServiceWrapperBase<LobbyServiceWrapper>.Instance.method_0(LobbyManager._LobbyInstance);
		}
		return LobbyManager._LobbyInstance;
	}

	// Token: 0x06002A9A RID: 10906 RVA: 0x0001C234 File Offset: 0x0001A434
	public bool method_0()
	{
		return this.m_MyRoom != null;
	}

	// Token: 0x06002A9B RID: 10907 RVA: 0x0001C241 File Offset: 0x0001A441
	public bool method_1()
	{
		return this.m_MyRoom != null && !(MonoSingleton<Session>.Instance.GetLocalPlayer() == null) && MonoSingleton<Session>.Instance.GetLocalPlayer().m_characterId == this.m_MyRoom.Owner;
	}

	// Token: 0x06002A9C RID: 10908 RVA: 0x0001C280 File Offset: 0x0001A480
	public bool method_2(int int_0)
	{
		return this.m_MyRoom != null && int_0 == this.m_MyRoom.Owner;
	}

	// Token: 0x06002A9D RID: 10909 RVA: 0x0001C29D File Offset: 0x0001A49D
	private int method_3(Presence presence_0, Presence presence_1)
	{
		if (presence_1.mCharacterId == this.m_MyRoom.Owner)
		{
			return 1;
		}
		return -1;
	}

	// Token: 0x06002A9E RID: 10910 RVA: 0x0001C2B5 File Offset: 0x0001A4B5
	public bool method_4()
	{
		return this.m_MyRoom != null && this.m_MyRoom.Members.Count >= 8;
	}

	// Token: 0x06002A9F RID: 10911 RVA: 0x000C75E0 File Offset: 0x000C57E0
	public int method_5()
	{
		int num = 0;
		if (this.m_MyRoom != null)
		{
			num = this.m_MyRoom.Members.Count;
		}
		return num;
	}

	// Token: 0x06002AA0 RID: 10912 RVA: 0x000C760C File Offset: 0x000C580C
	public Presence method_6()
	{
		Presence presence = null;
		if (this.m_MyRoom != null && MonoSingleton<Session>.Instance.GetLocalPlayer() != null)
		{
			int characterId = MonoSingleton<Session>.Instance.GetLocalPlayer().m_characterId;
			for (int i = 0; i < this.m_MyRoom.Members.Count; i++)
			{
				if (this.m_MyRoom.Members[i].mCharacterId == characterId)
				{
					presence = this.m_MyRoom.Members[i];
					break;
				}
			}
		}
		return presence;
	}

	// Token: 0x06002AA1 RID: 10913 RVA: 0x0001C2D7 File Offset: 0x0001A4D7
	public Presence method_7(int int_0)
	{
		if (this.m_MyRoom == null)
		{
			return null;
		}
		if (int_0 >= 0 && int_0 < this.m_MyRoom.Members.Count)
		{
			return this.m_MyRoom.Members[int_0];
		}
		return null;
	}

	// Token: 0x06002AA2 RID: 10914 RVA: 0x0001C30D File Offset: 0x0001A50D
	public void method_8()
	{
		if (this.m_MyRoom == null)
		{
			ServiceWrapperBase<LobbyServiceWrapper>.Instance.method_8(new OnGetLobby(this.OnGetMyLobby));
		}
	}

	// Token: 0x06002AA3 RID: 10915 RVA: 0x000C7690 File Offset: 0x000C5890
	protected void OnGetMyLobby(Lobby room)
	{
		this.m_MyRoom = room;
		if (this.m_MyRoom != null)
		{
			this.m_MyRoom.Members.Sort(new Comparison<Presence>(this.method_3));
		}
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<PvPFlowView>().vmethod_7();
	}

	// Token: 0x06002AA4 RID: 10916 RVA: 0x0001C32D File Offset: 0x0001A52D
	public void method_9(int int_0)
	{
		this.m_nPvEInstance = int_0;
		ServiceWrapperBase<LobbyServiceWrapper>.Instance.method_11(new OnCreateLobby(this.OnPvELobbyCreated), false);
	}

	// Token: 0x06002AA5 RID: 10917 RVA: 0x000C76DC File Offset: 0x000C58DC
	public void OnPvELobbyCreated(Lobby room)
	{
		DebugUtils.Log(LogCategory.GUI, "OnPvELobbyCreated room=" + ((room == null) ? "NULL" : room.Id.ToString()));
		this.m_MyPvERoom = room;
		if (room != null)
		{
			this.method_10();
		}
	}

	// Token: 0x06002AA6 RID: 10918 RVA: 0x000C7724 File Offset: 0x000C5924
	public void method_10()
	{
		this.m_MyPvERoom.GameMode = GamemodeType.GamemodePvE;
		this.m_MyPvERoom.Playlist = this.m_nPvEInstance;
		if (this.method_11())
		{
			ServiceWrapperBase<LobbyServiceWrapper>.Instance.method_10(new OnOpenLobby(this.OnOpenPvELobby), GamemodeType.GamemodePvE, this.m_nPvEInstance, MonoSingleton<AppManager>.Instance.m_difficulty);
		}
	}

	// Token: 0x06002AA7 RID: 10919 RVA: 0x000C7780 File Offset: 0x000C5980
	protected void OnOpenPvELobby(Lobby lobby)
	{
		DebugUtils.Log(LogCategory.GUI, "OnOpenPvELobby lobby=" + ((lobby == null) ? "NULL" : lobby.Id.ToString()));
		MonoSingleton<global::ns0.EchoMessageManager>.Instance.method_8("80001");
	}

	// Token: 0x06002AA8 RID: 10920 RVA: 0x000C77C4 File Offset: 0x000C59C4
	public bool method_11()
	{
		if (this.Lobby_1 == null)
		{
			DebugUtils.Log(LogCategory.GUI, "~~~~~~~" + ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_9() + " MyPvELobby is null!!!");
			return false;
		}
		if (MonoSingleton<Session>.Instance.GetLocalPlayer() == null)
		{
			DebugUtils.Log(LogCategory.GUI, "~~~~~~~" + ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_9() + " Local Player is null!!!");
			return false;
		}
		if (MonoSingleton<Session>.Instance.GetLocalPlayer().m_characterId != this.Lobby_1.Owner)
		{
			DebugUtils.Log(LogCategory.GUI, string.Concat(new string[]
			{
				"~~~~~~~",
				ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_9(),
				" not PvE lobby owner!!! Id:",
				MonoSingleton<Session>.Instance.GetLocalPlayer().m_characterId.ToString(),
				"Owner Id:",
				this.m_MyPvERoom.Owner.ToString()
			}));
			return false;
		}
		return true;
	}

	// Token: 0x06002AA9 RID: 10921 RVA: 0x0001C34D File Offset: 0x0001A54D
	public bool method_12(int int_0)
	{
		return this.Lobby_1 != null && int_0 == this.Lobby_1.Owner;
	}

	// Token: 0x06002AAA RID: 10922 RVA: 0x0001C36A File Offset: 0x0001A56A
	public bool method_13()
	{
		return this.Lobby_1 != null && this.Lobby_1.Members.Count >= 4;
	}

	// Token: 0x06002AAB RID: 10923 RVA: 0x0001C38C File Offset: 0x0001A58C
	public void method_14()
	{
		ServiceWrapperBase<LobbyServiceWrapper>.Instance.method_11(new OnCreateLobby(this.OnLobbyCreated), true);
	}

	// Token: 0x06002AAC RID: 10924 RVA: 0x0001C3A6 File Offset: 0x0001A5A6
	public void method_15(GamemodeType gamemodeType_0, int int_0)
	{
		this.m_MyRoom.GameMode = gamemodeType_0;
		this.m_MyRoom.Playlist = int_0;
		if (this.method_1())
		{
			ServiceWrapperBase<LobbyServiceWrapper>.Instance.method_10(new OnOpenLobby(this.OnOpenLobby), gamemodeType_0, int_0, ELevelDifficulty.Normal);
		}
	}

	// Token: 0x06002AAD RID: 10925 RVA: 0x0001C3E1 File Offset: 0x0001A5E1
	protected void OnOpenLobby(Lobby lobby)
	{
		if (this.method_1())
		{
			MonoSingleton<global::ns0.EchoMessageManager>.Instance.method_8("80001");
		}
	}

	// Token: 0x06002AAE RID: 10926 RVA: 0x0001C3FA File Offset: 0x0001A5FA
	public void method_16(int int_0)
	{
		if (this.method_1())
		{
			ServiceWrapperBase<LobbyServiceWrapper>.Instance.method_2(new OnInviteToLobby(this.method_17), int_0);
		}
	}

	// Token: 0x06002AAF RID: 10927 RVA: 0x0000311B File Offset: 0x0000131B
	protected void method_17(bool bool_0)
	{
	}

	// Token: 0x06002AB0 RID: 10928 RVA: 0x000C78B0 File Offset: 0x000C5AB0
	public void method_18()
	{
		if (this.m_nMessageId != -1)
		{
			ServiceWrapperBase<LobbyServiceWrapper>.Instance.method_3(new OnAcceptLobbyInvitation(this.method_19), this.m_nMessageId);
		}
		else
		{
			this.m_nMessageId = -1;
			this.m_bCanShowMessage = true;
		}
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<PvPTipsView>().Boolean_1 = false;
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InstanceSelectView>().vmethod_4();
	}

	// Token: 0x06002AB1 RID: 10929 RVA: 0x000C791C File Offset: 0x000C5B1C
	protected void method_19(Lobby lobby_0)
	{
		this.m_MyRoom = lobby_0;
		if (this.m_MyRoom != null)
		{
			this.m_MyRoom.Members.Sort(new Comparison<Presence>(this.method_3));
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<PvPFlowView>().vmethod_7();
		}
	}

	// Token: 0x06002AB2 RID: 10930 RVA: 0x000C7968 File Offset: 0x000C5B68
	public void method_20()
	{
		if (this.m_nMessageId != -1)
		{
			ServiceWrapperBase<LobbyServiceWrapper>.Instance.method_4(new OnRejectLobbyInvitation(this.method_21), this.m_nMessageId);
		}
		this.m_nMessageId = -1;
		this.m_bCanShowMessage = true;
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<PvPTipsView>().Boolean_1 = false;
	}

	// Token: 0x06002AB3 RID: 10931 RVA: 0x0000311B File Offset: 0x0000131B
	protected void method_21(bool bool_0)
	{
	}

	// Token: 0x06002AB4 RID: 10932 RVA: 0x000C79C0 File Offset: 0x000C5BC0
	public void method_22(int int_0)
	{
		if (this.method_1())
		{
			ServiceWrapperBase<LobbyServiceWrapper>.Instance.method_5(new OnKickPlayerFromLobby(this.method_23), int_0);
			if (GroupManager.smethod_0().method_19() && GroupManager.smethod_0().method_17(int_0))
			{
				GroupManager.smethod_0().method_24(int_0);
			}
		}
	}

	// Token: 0x06002AB5 RID: 10933 RVA: 0x0001C41B File Offset: 0x0001A61B
	private void method_23(bool bool_0, int int_0)
	{
		if (bool_0 && this.m_MyRoom != null)
		{
			this.m_MyRoom.method_1(int_0);
		}
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<PvPFlowView>().vmethod_7();
	}

	// Token: 0x06002AB6 RID: 10934 RVA: 0x0001C449 File Offset: 0x0001A649
	public void method_24()
	{
		ServiceWrapperBase<LobbyServiceWrapper>.Instance.method_6(new OnLeaveLobby(this.method_25));
	}

	// Token: 0x06002AB7 RID: 10935 RVA: 0x000C7A10 File Offset: 0x000C5C10
	protected void method_25(bool bool_0)
	{
		if (bool_0)
		{
			if (this.m_MyRoom != null)
			{
				this.m_MyRoom = null;
				GroupManager.smethod_0().method_27();
			}
			this.m_MyPvERoom = null;
			if (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<PvPFlowView>().Boolean_0)
			{
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<PvPFlowView>().Boolean_1 = false;
			}
			if (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<MatchMakingView>().Boolean_0)
			{
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<MatchMakingView>().Boolean_1 = false;
			}
		}
	}

	// Token: 0x06002AB8 RID: 10936 RVA: 0x0001C461 File Offset: 0x0001A661
	public void method_26()
	{
		if (this.method_1())
		{
			OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.Prop_0.imethod_9(new OnCloseLobby(this.OnCloseLobby));
		}
	}

	// Token: 0x06002AB9 RID: 10937 RVA: 0x000C7A98 File Offset: 0x000C5C98
	protected void OnCloseLobby(bool success)
	{
		if (success)
		{
			this.m_MyRoom = null;
			this.m_MyPvERoom = null;
			if (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<PvPFlowView>().Boolean_0)
			{
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<PvPFlowView>().Boolean_1 = false;
			}
			if (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<MatchMakingView>().Boolean_0)
			{
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<MatchMakingView>().Boolean_1 = false;
			}
		}
	}

	// Token: 0x06002ABA RID: 10938 RVA: 0x000C7B0C File Offset: 0x000C5D0C
	public void OnNewLobby(Lobby newLobby)
	{
		DebugUtils.Log(LogCategory.Network, "LobbyManager.OnNewLobby");
		if (newLobby.GameMode == GamemodeType.GamemodePvE)
		{
			this.m_MyPvERoom = newLobby;
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<MatchMakingView>().Boolean_1 = true;
		}
		else
		{
			this.m_MyRoom = newLobby;
			if (this.m_MyRoom != null)
			{
				this.m_MyRoom.Members.Sort(new Comparison<Presence>(this.method_3));
			}
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<PvPFlowView>().vmethod_7();
			if (!this.method_1())
			{
				if (this.m_bCanShowLobbyECHO)
				{
					MonoSingleton<global::ns0.EchoMessageManager>.Instance.method_8("80001");
					this.m_bCanShowLobbyECHO = false;
				}
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<PvPFlowView>().Boolean_1 = false;
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<MatchMakingView>().Boolean_1 = true;
			}
		}
	}

	// Token: 0x06002ABB RID: 10939 RVA: 0x000C7BE0 File Offset: 0x000C5DE0
	public void OnPlayerJoinLobby(Presence newPlayer)
	{
		if (newPlayer != null)
		{
			if (this.m_MyRoom != null)
			{
				this.m_MyRoom.method_0(newPlayer);
				this.m_MyRoom.Members.Sort(new Comparison<Presence>(this.method_3));
			}
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<PvPFlowView>().vmethod_7();
		}
	}

	// Token: 0x06002ABC RID: 10940 RVA: 0x000C7C34 File Offset: 0x000C5E34
	public void OnPlayerLeaveLobby(int characterId)
	{
		if (this.m_MyRoom == null)
		{
			return;
		}
		GameUIManager gameUIManager = MonoSingleton<AppManager>.Instance.method_0();
		if (MonoSingleton<Session>.Instance != null && MonoSingleton<Session>.Instance.GetLocalPlayer() != null)
		{
			if (characterId == MonoSingleton<Session>.Instance.GetLocalPlayer().m_characterId)
			{
				this.m_MyRoom = null;
				this.m_PlayerRecord.Clear();
				if (gameUIManager != null)
				{
					PvPFlowView pvPFlowView = gameUIManager.vmethod_5<PvPFlowView>();
					if (pvPFlowView != null)
					{
						pvPFlowView.Boolean_1 = false;
					}
					if (gameUIManager.vmethod_5<MatchMakingView>().Boolean_0)
					{
						gameUIManager.vmethod_5<MatchMakingView>().Boolean_1 = false;
					}
				}
			}
		}
		else
		{
			if (this.m_MyRoom != null)
			{
				this.m_MyRoom.method_1(characterId);
			}
			if (this.m_PlayerRecord != null && this.m_PlayerRecord.ContainsKey(characterId))
			{
				this.m_PlayerRecord.Remove(characterId);
			}
			if (gameUIManager != null)
			{
				PvPFlowView pvPFlowView2 = gameUIManager.vmethod_5<PvPFlowView>();
				if (pvPFlowView2 != null && pvPFlowView2.Boolean_0)
				{
					pvPFlowView2.vmethod_7();
				}
			}
		}
	}

	// Token: 0x06002ABD RID: 10941 RVA: 0x000C7D2C File Offset: 0x000C5F2C
	public void OnLobbyCreated(Lobby room)
	{
		this.m_MyRoom = room;
		if (this.m_MyRoom != null)
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InstanceSelectView>().vmethod_25();
			this.m_MyRoom.Members.Sort(new Comparison<Presence>(this.method_3));
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<PvPFlowView>().vmethod_7();
		}
	}

	// Token: 0x06002ABE RID: 10942 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnLobbyGameStart()
	{
	}

	// Token: 0x06002ABF RID: 10943 RVA: 0x000C7D8C File Offset: 0x000C5F8C
	public void OnLobbyClose()
	{
		if (this.m_MyRoom != null)
		{
			if (MonoSingleton<Session>.Instance.method_16())
			{
				MonoSingleton<global::ns0.EchoMessageManager>.Instance.method_8("80002");
			}
			this.m_MyRoom = null;
			this.m_PlayerRecord.Clear();
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<PvPFlowView>().Boolean_1 = false;
			if (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<MatchMakingView>().Boolean_0)
			{
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<MatchMakingView>().Boolean_1 = false;
			}
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InstanceSelectView>().vmethod_25();
		}
		if (this.m_MyPvERoom != null)
		{
			this.m_MyPvERoom = null;
			if (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<MatchMakingView>().Boolean_0)
			{
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<MatchMakingView>().Boolean_1 = false;
			}
		}
	}

	// Token: 0x06002AC0 RID: 10944 RVA: 0x000C7E60 File Offset: 0x000C6060
	public void OnLobbyOwnerChange(int newOwnerCharacterId)
	{
		if (this.m_MyRoom != null)
		{
			this.m_MyRoom.Owner = newOwnerCharacterId;
			this.m_MyRoom.Members.Sort(new Comparison<Presence>(this.method_3));
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<PvPFlowView>().vmethod_7();
		}
		if (this.m_MyPvERoom != null)
		{
			this.m_MyPvERoom.Owner = newOwnerCharacterId;
		}
	}

	// Token: 0x06002AC1 RID: 10945 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnGroupJoinLobby(int newGroup)
	{
	}

	// Token: 0x06002AC2 RID: 10946 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnGroupLeaveLobby(int newGroup)
	{
	}

	// Token: 0x06002AC3 RID: 10947 RVA: 0x0001C481 File Offset: 0x0001A681
	public void OnLobbyInvitationRecieved(int sender, int messageId)
	{
		if (GroupManager.smethod_0().method_18())
		{
			return;
		}
		if (this.m_bCanShowMessage)
		{
			this.m_bCanShowMessage = false;
			this.m_nMessageId = messageId;
			OnAccessSingleton<IPresenceService, PresenceService, PresenceServiceOffline>.Prop_0.imethod_0(sender, new OnGetPresence(this.method_27));
		}
	}

	// Token: 0x06002AC4 RID: 10948 RVA: 0x0001C4BD File Offset: 0x0001A6BD
	public void method_27(Presence presence_0)
	{
		if (presence_0 != null)
		{
			this.m_senderInfo = presence_0;
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<PvPTipsView>().Boolean_1 = true;
		}
		else
		{
			this.m_nMessageId = -1;
			this.m_bCanShowMessage = true;
		}
	}

	// Token: 0x06002AC5 RID: 10949 RVA: 0x000C7EC8 File Offset: 0x000C60C8
	public string method_28()
	{
		string text = string.Empty;
		if (this.m_senderInfo != null)
		{
			text = this.m_senderInfo.mCharacterName;
		}
		return text;
	}

	// Token: 0x06002AC6 RID: 10950 RVA: 0x000C7EF0 File Offset: 0x000C60F0
	public void method_29(int int_0)
	{
		if (int_0 == -1)
		{
			return;
		}
		this.m_nTargetCharacterId = int_0;
		if (this.m_PlayerRecord.ContainsKey(int_0))
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<PvPFlowView>().vmethod_5(int_0);
		}
		else
		{
			OnAccessSingleton<IMatchRecordService, MatchRecordService, MatchRecordServiceOffline>.Prop_0.imethod_0(new GetMatchRecordCallback(this.method_30), int_0);
		}
	}

	// Token: 0x06002AC7 RID: 10951 RVA: 0x000C7F48 File Offset: 0x000C6148
	public void method_30(MatchRecord matchRecord_0)
	{
		if (matchRecord_0 != null && !this.m_PlayerRecord.ContainsKey(matchRecord_0.CharacterId))
		{
			this.m_PlayerRecord.Add(matchRecord_0.CharacterId, matchRecord_0);
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<PvPFlowView>().vmethod_5(matchRecord_0.CharacterId);
		}
	}

	// Token: 0x06002AC8 RID: 10952 RVA: 0x0001C4EE File Offset: 0x0001A6EE
	public int method_31(int int_0)
	{
		return this.m_PlayerRecord[int_0].TotalMatchCount;
	}

	// Token: 0x06002AC9 RID: 10953 RVA: 0x0001C501 File Offset: 0x0001A701
	public int method_32(int int_0)
	{
		return this.m_PlayerRecord[int_0].TotalHonorPoint;
	}

	// Token: 0x06002ACA RID: 10954 RVA: 0x000C7F98 File Offset: 0x000C6198
	public string method_33(int int_0)
	{
		return this.m_PlayerRecord[int_0].TotalKillCount.ToString() + "/" + this.m_PlayerRecord[int_0].TotalDeathCount.ToString();
	}

	// Token: 0x06002ACB RID: 10955 RVA: 0x000C7FE4 File Offset: 0x000C61E4
	public string method_34(int int_0)
	{
		return this.m_PlayerRecord[int_0].TotalWinCount.ToString() + "/" + this.m_PlayerRecord[int_0].TotalLossCount.ToString();
	}

	// Token: 0x06002ACC RID: 10956 RVA: 0x000C8030 File Offset: 0x000C6230
	public int method_35(int int_0)
	{
		if (this.m_PlayerRecord[int_0].mMatchTypeFactors.ContainsKey(GamemodeType.GamemodeDeathmatch))
		{
			Hashtable hashtable = this.m_PlayerRecord[int_0].mMatchTypeFactors[GamemodeType.GamemodeDeathmatch];
			return Convert.ToInt32(hashtable[4]);
		}
		return 0;
	}

	// Token: 0x06002ACD RID: 10957 RVA: 0x000C8084 File Offset: 0x000C6284
	public int method_36(int int_0)
	{
		if (this.m_PlayerRecord[int_0].mMatchTypeFactors.ContainsKey(GamemodeType.GamemodeDeathmatch))
		{
			Hashtable hashtable = this.m_PlayerRecord[int_0].mMatchTypeFactors[GamemodeType.GamemodeDeathmatch];
			return Convert.ToInt32(hashtable[6]);
		}
		return 0;
	}

	// Token: 0x06002ACE RID: 10958 RVA: 0x000C80D8 File Offset: 0x000C62D8
	public string method_37(int int_0)
	{
		if (this.m_PlayerRecord[int_0].mMatchTypeFactors.ContainsKey(GamemodeType.GamemodeDeathmatch))
		{
			Hashtable hashtable = this.m_PlayerRecord[int_0].mMatchTypeFactors[GamemodeType.GamemodeDeathmatch];
			return Convert.ToInt32(hashtable[2]).ToString() + "/" + Convert.ToInt32(hashtable[3]).ToString();
		}
		return "0/0";
	}

	// Token: 0x06002ACF RID: 10959 RVA: 0x000C8158 File Offset: 0x000C6358
	public string method_38(int int_0)
	{
		if (this.m_PlayerRecord[int_0].mMatchTypeFactors.ContainsKey(GamemodeType.GamemodeDeathmatch))
		{
			Hashtable hashtable = this.m_PlayerRecord[int_0].mMatchTypeFactors[GamemodeType.GamemodeDeathmatch];
			return Convert.ToInt32(hashtable[0]).ToString() + "/" + Convert.ToInt32(hashtable[1]).ToString();
		}
		return "0/0";
	}

	// Token: 0x06002AD0 RID: 10960 RVA: 0x000C81D8 File Offset: 0x000C63D8
	public int method_39(int int_0)
	{
		if (this.m_PlayerRecord[int_0].mMatchTypeFactors.ContainsKey(GamemodeType.GamemodeTeamDeathmatch))
		{
			Hashtable hashtable = this.m_PlayerRecord[int_0].mMatchTypeFactors[GamemodeType.GamemodeTeamDeathmatch];
			return Convert.ToInt32(hashtable[4]);
		}
		return 0;
	}

	// Token: 0x06002AD1 RID: 10961 RVA: 0x000C822C File Offset: 0x000C642C
	public int method_40(int int_0)
	{
		if (this.m_PlayerRecord[int_0].mMatchTypeFactors.ContainsKey(GamemodeType.GamemodeTeamDeathmatch))
		{
			Hashtable hashtable = this.m_PlayerRecord[int_0].mMatchTypeFactors[GamemodeType.GamemodeTeamDeathmatch];
			return Convert.ToInt32(hashtable[6]);
		}
		return 0;
	}

	// Token: 0x06002AD2 RID: 10962 RVA: 0x000C8280 File Offset: 0x000C6480
	public string method_41(int int_0)
	{
		if (this.m_PlayerRecord[int_0].mMatchTypeFactors.ContainsKey(GamemodeType.GamemodeTeamDeathmatch))
		{
			Hashtable hashtable = this.m_PlayerRecord[int_0].mMatchTypeFactors[GamemodeType.GamemodeTeamDeathmatch];
			return Convert.ToInt32(hashtable[2]).ToString() + "/" + Convert.ToInt32(hashtable[3]).ToString();
		}
		return "0/0";
	}

	// Token: 0x06002AD3 RID: 10963 RVA: 0x000C8300 File Offset: 0x000C6500
	public string method_42(int int_0)
	{
		if (this.m_PlayerRecord[int_0].mMatchTypeFactors.ContainsKey(GamemodeType.GamemodeTeamDeathmatch))
		{
			Hashtable hashtable = this.m_PlayerRecord[int_0].mMatchTypeFactors[GamemodeType.GamemodeTeamDeathmatch];
			return Convert.ToInt32(hashtable[0]).ToString() + "/" + Convert.ToInt32(hashtable[1]).ToString();
		}
		return "0/0";
	}

	// Token: 0x06002AD4 RID: 10964 RVA: 0x0001C514 File Offset: 0x0001A714
	public void method_43()
	{
		ServiceWrapperBase<RankServiceWrapper>.Instance.method_0(new GetRankingCallback(this.method_44), 1, 1, 0);
	}

	// Token: 0x06002AD5 RID: 10965 RVA: 0x000C8380 File Offset: 0x000C6580
	public void method_44(List<Rank> list_0)
	{
		this.m_RankList.Clear();
		this.m_FriendAndGuildRankList.Clear();
		if (list_0 != null)
		{
			int num = 0;
			bool flag = false;
			if (list_0.Count > 1)
			{
				num = 1;
			}
			for (int i = num; i < list_0.Count; i++)
			{
				this.m_RankList.Add(list_0[i]);
				if (list_0[i].characterName == ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_9())
				{
					flag = true;
					this.m_FriendAndGuildRankList.Add(list_0[i]);
				}
				else if (FriendManager.smethod_0().method_26(list_0[i].characterId) || list_0[i].guildId != 0)
				{
					this.m_FriendAndGuildRankList.Add(list_0[i]);
				}
			}
			if (!flag)
			{
				this.m_RankList.Add(list_0[0]);
				this.m_FriendAndGuildRankList.Add(list_0[0]);
			}
			this.m_RankList.Sort(new Comparison<Rank>(this.method_45));
			this.m_FriendAndGuildRankList.Sort(new Comparison<Rank>(this.method_45));
		}
		else
		{
			DebugUtils.Log(LogCategory.GUI, "RankList is null!!!");
		}
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<PvPFlowView>().vmethod_7();
	}

	// Token: 0x06002AD6 RID: 10966 RVA: 0x0001C52F File Offset: 0x0001A72F
	private int method_45(Rank rank_0, Rank rank_1)
	{
		if (rank_0.rank > rank_1.rank)
		{
			return 1;
		}
		if (rank_0.rank < rank_1.rank)
		{
			return -1;
		}
		return string.Compare(rank_0.characterName, rank_1.characterName);
	}

	// Token: 0x06002AD7 RID: 10967 RVA: 0x0001C562 File Offset: 0x0001A762
	public int method_46()
	{
		return this.m_RankList.Count;
	}

	// Token: 0x06002AD8 RID: 10968 RVA: 0x0001C56F File Offset: 0x0001A76F
	public int method_47()
	{
		return this.m_FriendAndGuildRankList.Count;
	}

	// Token: 0x06002AD9 RID: 10969 RVA: 0x0001C57C File Offset: 0x0001A77C
	public Rank method_48(int int_0)
	{
		if (int_0 >= 0 && int_0 < this.m_RankList.Count)
		{
			return this.m_RankList[int_0];
		}
		return null;
	}

	// Token: 0x06002ADA RID: 10970 RVA: 0x0001C59E File Offset: 0x0001A79E
	public Rank method_49(int int_0)
	{
		if (int_0 >= 0 && int_0 < this.m_FriendAndGuildRankList.Count)
		{
			return this.m_FriendAndGuildRankList[int_0];
		}
		return null;
	}

	// Token: 0x06002ADB RID: 10971 RVA: 0x0001C5C0 File Offset: 0x0001A7C0
	public void method_50()
	{
		ServiceWrapperBase<LobbyServiceWrapper>.Instance.method_11(new OnCreateLobby(this.OnPvPLobbyCreateAutoTest), true);
	}

	// Token: 0x06002ADC RID: 10972 RVA: 0x0001C5D9 File Offset: 0x0001A7D9
	public void OnPvPLobbyCreateAutoTest(Lobby room)
	{
		DebugUtils.Log(LogCategory.Gamelogic, "OnAutoTestPvELobbyCreated");
		this.m_MyRoom = room;
		if (room != null)
		{
			DebugUtils.Log(LogCategory.Gamelogic, "room not null");
			this.method_51();
		}
	}

	// Token: 0x06002ADD RID: 10973 RVA: 0x000C84C4 File Offset: 0x000C66C4
	public void method_51()
	{
		DebugUtils.Log(LogCategory.Gamelogic, "OpenAutoTestPvPLobby");
		if (this.method_1())
		{
			int[] array = new int[] { 1001, 1002, 1003, 1006, 1007 };
			int num = global::UnityEngine.Random.Range(0, array.Length);
			Playlist playlist = MatchmakingService.MatchmakingService_0.method_1(array[num]);
			if (playlist != null)
			{
				DebugUtils.Log(LogCategory.Gamelogic, "Open PvP game:" + playlist.m_id.ToString());
				this.m_MyRoom.GameMode = MatchmakingService.smethod_0(playlist.m_gameMode);
				this.m_MyRoom.Playlist = playlist.m_id;
				ServiceWrapperBase<LobbyServiceWrapper>.Instance.method_10(new OnOpenLobby(this.OnOpenAutoTestPvPLobby), this.m_MyRoom.GameMode, this.m_MyRoom.Playlist, MonoSingleton<AppManager>.Instance.m_difficulty);
			}
		}
	}

	// Token: 0x06002ADE RID: 10974 RVA: 0x000C8590 File Offset: 0x000C6790
	protected void OnOpenAutoTestPvPLobby(Lobby lobby)
	{
		DebugUtils.Log(LogCategory.Gamelogic, "OnOpenAutoTestPvPLobby");
		if (this.m_MyRoom.Owner != OnlineService.s_characterId)
		{
			return;
		}
		if (this.m_MyRoom != null)
		{
			MonoSingleton<GameFlowManager>.Instance.method_12(this.m_MyRoom.Playlist, this.m_MyRoom.GameMode);
		}
	}

	// Token: 0x06002ADF RID: 10975 RVA: 0x0001C601 File Offset: 0x0001A801
	public void method_52()
	{
		ServiceWrapperBase<LobbyServiceWrapper>.Instance.method_11(new OnCreateLobby(this.OnAutoTestPvELobbyCreated), false);
	}

	// Token: 0x06002AE0 RID: 10976 RVA: 0x0001C61A File Offset: 0x0001A81A
	public void OnAutoTestPvELobbyCreated(Lobby room)
	{
		DebugUtils.Log(LogCategory.Gamelogic, "OnAutoTestPvELobbyCreated");
		this.m_MyPvERoom = room;
		if (room != null)
		{
			DebugUtils.Log(LogCategory.Gamelogic, "room not null");
			this.method_53();
		}
	}

	// Token: 0x06002AE1 RID: 10977 RVA: 0x000C85E4 File Offset: 0x000C67E4
	public void method_53()
	{
		DebugUtils.Log(LogCategory.Gamelogic, "OpenAutoTestPvELobby");
		if (this.method_11())
		{
			int[] array = new int[]
			{
				32, 31, 30, 29, 27, 26, 25, 24, 18, 13,
				7, 6, 10, 11, 12, 14, 15, 16, 17, 19,
				20, 21, 22, 23
			};
			int num = global::UnityEngine.Random.Range(0, array.Length);
			Playlist playlist = MatchmakingService.MatchmakingService_0.method_1(array[num]);
			if (playlist != null)
			{
				DebugUtils.Log(LogCategory.Gamelogic, "Open PvE game:" + playlist.m_id.ToString());
				this.m_MyPvERoom.GameMode = GamemodeType.GamemodePvE;
				this.m_MyPvERoom.Playlist = playlist.m_id;
				ServiceWrapperBase<LobbyServiceWrapper>.Instance.method_10(new OnOpenLobby(this.OnOpenAutoTestPvELobby), GamemodeType.GamemodePvE, this.m_MyPvERoom.Playlist, MonoSingleton<AppManager>.Instance.m_difficulty);
			}
		}
	}

	// Token: 0x06002AE2 RID: 10978 RVA: 0x0001C642 File Offset: 0x0001A842
	protected void OnOpenAutoTestPvELobby(Lobby lobby)
	{
		DebugUtils.Log(LogCategory.Gamelogic, "OnOpenAutoTestPvELobby");
		TownBehaviour.smethod_2();
	}

	// Token: 0x04001E0F RID: 7695
	protected static LobbyManager _LobbyInstance;

	// Token: 0x04001E10 RID: 7696
	private Lobby m_MyRoom;

	// Token: 0x04001E11 RID: 7697
	public int m_nTargetCharacterId = -1;

	// Token: 0x04001E12 RID: 7698
	public bool m_bCanShowLobbyECHO = true;

	// Token: 0x04001E13 RID: 7699
	private int m_nMessageId = -1;

	// Token: 0x04001E14 RID: 7700
	private Lobby m_MyPvERoom;

	// Token: 0x04001E15 RID: 7701
	private int m_nPvEInstance = -1;

	// Token: 0x04001E16 RID: 7702
	protected List<Rank> m_RankList;

	// Token: 0x04001E17 RID: 7703
	protected List<Rank> m_FriendAndGuildRankList;

	// Token: 0x04001E18 RID: 7704
	public bool m_bCanShowMessage = true;

	// Token: 0x04001E19 RID: 7705
	private Presence m_senderInfo;

	// Token: 0x04001E1A RID: 7706
	private Dictionary<int, MatchRecord> m_PlayerRecord;
}
