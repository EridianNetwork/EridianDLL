using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Core;
using ns0;
using XsdSettings;

// Token: 0x020003A1 RID: 929
internal class LobbyService : OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>, ILobbyService
{
	// Token: 0x06001781 RID: 6017 RVA: 0x0007F678 File Offset: 0x0007D878
	public LobbyService()
	{
		PhotonNetwork.onlinePeer.method_5(87, new OperationResponseCallback(this.OnCreateLobbyResponse));
		PhotonNetwork.onlinePeer.method_5(96, new OperationResponseCallback(this.OnOpenLobbyResponse));
		PhotonNetwork.onlinePeer.method_5(132, new OperationResponseCallback(this.OnInviteToLobbyResponse));
		PhotonNetwork.onlinePeer.method_5(131, new OperationResponseCallback(this.OnAcceptLobbyInvitationResponse));
		PhotonNetwork.onlinePeer.method_5(130, new OperationResponseCallback(this.OnRejectLobbyInvitationResponse));
		PhotonNetwork.onlinePeer.method_5(129, new OperationResponseCallback(this.OnKickPlayerFromLobbyResponse));
		PhotonNetwork.onlinePeer.method_5(228, new OperationResponseCallback(this.OnLeaveLobbyResponse));
		PhotonNetwork.onlinePeer.method_5(126, new OperationResponseCallback(this.OnGetLobbyResponse));
		PhotonNetwork.onlinePeer.method_5(125, new OperationResponseCallback(this.OnCloseLobbyResponse));
		PhotonNetwork.onlinePeer.method_5(56, new OperationResponseCallback(this.OnSubmitPvPResultsResponse));
		PhotonNetwork.onlinePeer.method_7(194, new EventCallback(this.OnPlayerJoinLobbyEvent));
		PhotonNetwork.onlinePeer.method_7(193, new EventCallback(this.OnPlayerLeftLobbyEvent));
		PhotonNetwork.onlinePeer.method_7(166, new EventCallback(this.OnLobbyCreatedEvent));
		PhotonNetwork.onlinePeer.method_7(164, new EventCallback(this.OnNewLobbyEvent));
		PhotonNetwork.onlinePeer.method_7(192, new EventCallback(this.OnLobbyGameStartEvent));
		PhotonNetwork.onlinePeer.method_7(191, new EventCallback(this.OnLobbyCloseEvent));
		PhotonNetwork.onlinePeer.method_7(152, new EventCallback(this.OnLobbyDeleteEvent));
		PhotonNetwork.onlinePeer.method_7(190, new EventCallback(this.OnLobbyOwnerChangeEvent));
		PhotonNetwork.onlinePeer.method_7(189, new EventCallback(this.OnGroupJoinedLobbyEvent));
		PhotonNetwork.onlinePeer.method_7(188, new EventCallback(this.OnGroupLeaveLobbyEvent));
		PhotonNetwork.networkingPeer.RegisterOperationResponseCallback(124, new OperationResponseCallback(this.OnAcceptLobbyGameInvitation));
		PhotonNetwork.networkingPeer.RegisterOperationResponseCallback(122, new OperationResponseCallback(this.OnSetPlayerTeamIDResponse));
		PhotonNetwork.networkingPeer.RegisterEventCallback(192, new EventCallback(this.OnPvPGameCreatedEvent));
		OnAccessSingleton<IMessagingService, MessagingService, MessagingServiceOffline>.Prop_0.imethod_5("lobby_invite", new OnRecieveMessage(this.OnLobbyInvitationReceived));
		this.mOnSubmitPvPResults = new List<OnSubmitPvPResults>();
		this.mOnPlayerJoinLobby = new List<OnPlayerJoinLobby>();
		this.mOnPlayerLeaveLobby = new List<OnPlayerLeaveLobby>();
		this.mOnLobbyCreated = new List<OnLobbyCreated>();
		this.mOnLobbyGameStart = new List<OnLobbyGameStart>();
		this.mOnLobbyClose = new List<OnLobbyClose>();
		this.mOnLobbyDelete = new List<OnLobbyDelete>();
		this.mOnLobbyOwnerChange = new List<OnLobbyOwnerChange>();
		this.mOnGroupJoinLobby = new List<OnGroupJoinLobby>();
		this.mOnGroupLeaveLobby = new List<OnGroupLeaveLobby>();
		this.mOnLobbyInvitationReceived = new List<OnLobbyInvitationRecieved>();
		this.mOnNewLobby = new List<OnNewLobby>();
		this.mCachedEvents = new List<LobbyService.CachedEvent>();
		this.mState = LobbyService.State.Closed;
	}

	// Token: 0x06001782 RID: 6018 RVA: 0x0001164B File Offset: 0x0000F84B
	public void imethod_0(OnCreateLobby onCreateLobby_0, bool bool_0)
	{
		this.mState = LobbyService.State.Creating;
		this.mOnCreateLobby = onCreateLobby_0;
		PhotonNetwork.onlinePeer.method_3(87, new object[] { bool_0 });
	}

	// Token: 0x06001783 RID: 6019 RVA: 0x0007F9A0 File Offset: 0x0007DBA0
	private void OnCreateLobbyResponse(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (operationResponse == 0)
		{
			this.mState = LobbyService.State.Created;
			Lobby lobby = new Lobby((Hashtable)parameters[0]);
			if (this.mOnCreateLobby != null)
			{
				this.mOnCreateLobby(lobby);
			}
			this.method_5(lobby.Id);
		}
		else
		{
			this.mState = LobbyService.State.Closed;
			if (this.mOnCreateLobby != null)
			{
				this.mOnCreateLobby(null);
			}
		}
		this.mOnCreateLobby = null;
	}

	// Token: 0x06001784 RID: 6020 RVA: 0x00011677 File Offset: 0x0000F877
	public void imethod_1(OnOpenLobby onOpenLobby_0, GamemodeType gamemodeType_0, int int_0, ELevelDifficulty elevelDifficulty_0)
	{
		this.mState = LobbyService.State.Opening;
		this.mOnOpenLobby = onOpenLobby_0;
		PhotonNetwork.onlinePeer.method_3(96, new object[]
		{
			(int)gamemodeType_0,
			int_0,
			(int)elevelDifficulty_0
		});
	}

	// Token: 0x06001785 RID: 6021 RVA: 0x0007FA10 File Offset: 0x0007DC10
	private void OnOpenLobbyResponse(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (operationResponse == 0)
		{
			this.mState = LobbyService.State.Opened;
			Lobby lobby = new Lobby((Hashtable)parameters[0]);
			if (this.mOnOpenLobby != null)
			{
				this.mOnOpenLobby(lobby);
			}
			this.method_5(lobby.Id);
		}
		else
		{
			this.mState = LobbyService.State.Closed;
			if (this.mOnOpenLobby != null)
			{
				this.mOnOpenLobby(null);
			}
		}
		this.mOnOpenLobby = null;
	}

	// Token: 0x06001786 RID: 6022 RVA: 0x000116B6 File Offset: 0x0000F8B6
	public void imethod_2(OnInviteToLobby onInviteToLobby_0, int int_0)
	{
		this.mOnInviteToLobby = onInviteToLobby_0;
		PhotonNetwork.onlinePeer.method_3(132, new object[] { int_0 });
	}

	// Token: 0x06001787 RID: 6023 RVA: 0x000116DE File Offset: 0x0000F8DE
	private void OnInviteToLobbyResponse(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (this.mOnInviteToLobby != null)
		{
			if (operationResponse == 0)
			{
				this.mOnInviteToLobby(true);
			}
			else
			{
				this.mOnInviteToLobby(false);
			}
			this.mOnInviteToLobby = null;
		}
	}

	// Token: 0x06001788 RID: 6024 RVA: 0x0001170C File Offset: 0x0000F90C
	public void imethod_3(OnAcceptLobbyInvitation onAcceptLobbyInvitation_0, int int_0)
	{
		this.mState = LobbyService.State.Joining;
		this.mOnAcceptLobbyInvitation = onAcceptLobbyInvitation_0;
		PhotonNetwork.onlinePeer.method_3(131, new object[] { int_0 });
	}

	// Token: 0x06001789 RID: 6025 RVA: 0x0007FA80 File Offset: 0x0007DC80
	private void OnAcceptLobbyInvitationResponse(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (operationResponse == 0)
		{
			this.mState = LobbyService.State.Joined;
			Lobby lobby = new Lobby((Hashtable)parameters[0]);
			if (this.mOnAcceptLobbyInvitation != null)
			{
				this.mOnAcceptLobbyInvitation(lobby);
			}
			this.method_5(lobby.Id);
		}
		else
		{
			this.mState = LobbyService.State.Closed;
			if (this.mOnAcceptLobbyInvitation != null)
			{
				this.mOnAcceptLobbyInvitation(null);
			}
		}
		this.mOnAcceptLobbyInvitation = null;
	}

	// Token: 0x0600178A RID: 6026 RVA: 0x0001173B File Offset: 0x0000F93B
	public void imethod_4(OnRejectLobbyInvitation onRejectLobbyInvitation_0, int int_0)
	{
		this.mOnRejectLobbyInvitation = onRejectLobbyInvitation_0;
		PhotonNetwork.onlinePeer.method_3(130, new object[] { int_0 });
	}

	// Token: 0x0600178B RID: 6027 RVA: 0x00011763 File Offset: 0x0000F963
	private void OnRejectLobbyInvitationResponse(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (this.mOnRejectLobbyInvitation != null)
		{
			if (operationResponse == 0)
			{
				this.mOnRejectLobbyInvitation(true);
			}
			else
			{
				this.mOnRejectLobbyInvitation(false);
			}
			this.mOnRejectLobbyInvitation = null;
		}
	}

	// Token: 0x0600178C RID: 6028 RVA: 0x00011791 File Offset: 0x0000F991
	public void imethod_5(OnKickPlayerFromLobby onKickPlayerFromLobby_0, int int_0)
	{
		this.mOnKickPlayerFromLobby = onKickPlayerFromLobby_0;
		PhotonNetwork.onlinePeer.method_3(129, new object[] { int_0 });
	}

	// Token: 0x0600178D RID: 6029 RVA: 0x0007FAF0 File Offset: 0x0007DCF0
	private void OnKickPlayerFromLobbyResponse(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (this.mOnKickPlayerFromLobby != null)
		{
			if (operationResponse == 0)
			{
				int num = (int)parameters[0];
				this.mOnKickPlayerFromLobby(true, num);
			}
			else
			{
				this.mOnKickPlayerFromLobby(false, -1);
			}
			this.mOnKickPlayerFromLobby = null;
		}
	}

	// Token: 0x0600178E RID: 6030 RVA: 0x000117B9 File Offset: 0x0000F9B9
	public void imethod_6(OnLeaveLobby onLeaveLobby_0)
	{
		this.mState = LobbyService.State.Leaving;
		this.mOnLeaveLobby = onLeaveLobby_0;
		PhotonNetwork.onlinePeer.method_3(228, new object[0]);
	}

	// Token: 0x0600178F RID: 6031 RVA: 0x0007FB38 File Offset: 0x0007DD38
	private void OnLeaveLobbyResponse(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (operationResponse == 0)
		{
			this.mState = LobbyService.State.Left;
			if (this.mOnLeaveLobby != null)
			{
				this.mOnLeaveLobby(true);
			}
			this.method_5(0);
		}
		else
		{
			this.mState = LobbyService.State.Closed;
			if (this.mOnLeaveLobby != null)
			{
				this.mOnLeaveLobby(false);
			}
		}
		this.mOnLeaveLobby = null;
	}

	// Token: 0x06001790 RID: 6032 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_7(OnStartLobbyGame onStartLobbyGame_0)
	{
	}

	// Token: 0x06001791 RID: 6033 RVA: 0x000117DF File Offset: 0x0000F9DF
	public void imethod_10(OnPlayerJoinLobby onPlayerJoinLobby_0)
	{
		this.mOnPlayerJoinLobby.Add(onPlayerJoinLobby_0);
	}

	// Token: 0x06001792 RID: 6034 RVA: 0x000117ED File Offset: 0x0000F9ED
	public void imethod_11(OnPlayerJoinLobby onPlayerJoinLobby_0)
	{
		this.mOnPlayerJoinLobby.Remove(onPlayerJoinLobby_0);
	}

	// Token: 0x06001793 RID: 6035 RVA: 0x0007FB90 File Offset: 0x0007DD90
	private void OnPlayerJoinLobbyEvent(Dictionary<byte, object> parameters)
	{
		if (Boolean_0)
		{
			mCachedEvents.Add(new CachedEvent
			{
				Parameters = parameters,
				Callback = OnPlayerJoinLobbyEvent,
				RoomId = (int)parameters[1]
			});
		}
		else
		{
			Presence character = new Presence((Hashtable)parameters[0]);
			mOnPlayerJoinLobby.ForEach(delegate(OnPlayerJoinLobby onPlayerJoinLobby_0)
			{
				onPlayerJoinLobby_0(character);
			});
		}
	}
	// Token: 0x06001794 RID: 6036 RVA: 0x000117FC File Offset: 0x0000F9FC
	public void imethod_12(OnPlayerLeaveLobby onPlayerLeaveLobby_0)
	{
		this.mOnPlayerLeaveLobby.Add(onPlayerLeaveLobby_0);
	}

	// Token: 0x06001795 RID: 6037 RVA: 0x0001180A File Offset: 0x0000FA0A
	public void imethod_13(OnPlayerLeaveLobby onPlayerLeaveLobby_0)
	{
		this.mOnPlayerLeaveLobby.Remove(onPlayerLeaveLobby_0);
	}

	// Token: 0x06001796 RID: 6038 RVA: 0x0007FC20 File Offset: 0x0007DE20
	private void OnPlayerLeftLobbyEvent(Dictionary<byte, object> parameters)
	{
		int player = (int)parameters[0];
		mOnPlayerLeaveLobby.ForEach(delegate(OnPlayerLeaveLobby onPlayerLeaveLobby_0)
		{
			onPlayerLeaveLobby_0(player);
		});
	}
	// Token: 0x06001797 RID: 6039 RVA: 0x00011819 File Offset: 0x0000FA19
	public void imethod_14(OnLobbyCreated onLobbyCreated_0)
	{
		this.mOnLobbyCreated.Add(onLobbyCreated_0);
	}

	// Token: 0x06001798 RID: 6040 RVA: 0x00011827 File Offset: 0x0000FA27
	public void imethod_15(OnLobbyCreated onLobbyCreated_0)
	{
		this.mOnLobbyCreated.Remove(onLobbyCreated_0);
	}

	// Token: 0x06001799 RID: 6041 RVA: 0x0007FC5C File Offset: 0x0007DE5C
	private void OnLobbyCreatedEvent(Dictionary<byte, object> parameters)
	{
		Lobby room = new Lobby((Hashtable)parameters[0]);
		mOnLobbyCreated.ForEach(delegate(OnLobbyCreated onLobbyCreated_0)
		{
			onLobbyCreated_0(room);
		});
	}
	// Token: 0x0600179A RID: 6042 RVA: 0x00011836 File Offset: 0x0000FA36
	public void imethod_16(OnLobbyGameStart onLobbyGameStart_0)
	{
		this.mOnLobbyGameStart.Add(onLobbyGameStart_0);
	}

	// Token: 0x0600179B RID: 6043 RVA: 0x00011844 File Offset: 0x0000FA44
	public void imethod_17(OnLobbyGameStart onLobbyGameStart_0)
	{
		this.mOnLobbyGameStart.Remove(onLobbyGameStart_0);
	}

	// Token: 0x0600179C RID: 6044 RVA: 0x0007FCA0 File Offset: 0x0007DEA0
	private void OnLobbyGameStartEvent(Dictionary<byte, object> parameters)
	{
		if (this.Boolean_0)
		{
			this.mCachedEvents.Add(new LobbyService.CachedEvent
			{
				Parameters = parameters,
				Callback = new EventCallback(this.OnLobbyGameStartEvent),
				RoomId = (int)parameters[0]
			});
		}
		else
		{
			PhotonNetwork.networkingPeer.OpCustomWithArgs(124, new object[0]);
			this.mOnLobbyGameStart.ForEach(new Action<OnLobbyGameStart>(LobbyService.smethod_0));
		}
	}

	// Token: 0x0600179D RID: 6045 RVA: 0x00011853 File Offset: 0x0000FA53
	public void imethod_18(OnLobbyClose onLobbyClose_0)
	{
		this.mOnLobbyClose.Add(onLobbyClose_0);
	}

	// Token: 0x0600179E RID: 6046 RVA: 0x00011861 File Offset: 0x0000FA61
	public void imethod_19(OnLobbyClose onLobbyClose_0)
	{
		this.mOnLobbyClose.Remove(onLobbyClose_0);
	}

	// Token: 0x0600179F RID: 6047 RVA: 0x00011870 File Offset: 0x0000FA70
	private void OnLobbyCloseEvent(Dictionary<byte, object> parameters)
	{
		this.mState = LobbyService.State.Closed;
		this.mOnLobbyClose.ForEach(new Action<OnLobbyClose>(LobbyService.smethod_1));
	}

	// Token: 0x060017A0 RID: 6048 RVA: 0x000118A1 File Offset: 0x0000FAA1
	public void imethod_20(OnLobbyDelete onLobbyDelete_0)
	{
		this.mOnLobbyDelete.Add(onLobbyDelete_0);
	}

	// Token: 0x060017A1 RID: 6049 RVA: 0x000118AF File Offset: 0x0000FAAF
	public void imethod_21(OnLobbyDelete onLobbyDelete_0)
	{
		this.mOnLobbyDelete.Remove(onLobbyDelete_0);
	}

	// Token: 0x060017A2 RID: 6050 RVA: 0x000118BE File Offset: 0x0000FABE
	private void OnLobbyDeleteEvent(Dictionary<byte, object> parameters)
	{
		this.mState = LobbyService.State.Deleted;
		this.mOnLobbyDelete.ForEach(new Action<OnLobbyDelete>(LobbyService.smethod_2));
	}

	// Token: 0x060017A3 RID: 6051 RVA: 0x000118F0 File Offset: 0x0000FAF0
	public void imethod_22(OnLobbyOwnerChange onLobbyOwnerChange_0)
	{
		this.mOnLobbyOwnerChange.Add(onLobbyOwnerChange_0);
	}

	// Token: 0x060017A4 RID: 6052 RVA: 0x000118FE File Offset: 0x0000FAFE
	public void imethod_23(OnLobbyOwnerChange onLobbyOwnerChange_0)
	{
		this.mOnLobbyOwnerChange.Remove(onLobbyOwnerChange_0);
	}

	// Token: 0x060017A5 RID: 6053 RVA: 0x0007FD34 File Offset: 0x0007DF34
	private void OnLobbyOwnerChangeEvent(Dictionary<byte, object> parameters)
	{
		int newOwner = (int)parameters[0];
		mOnLobbyOwnerChange.ForEach(delegate(OnLobbyOwnerChange onLobbyOwnerChange_0)
		{
			onLobbyOwnerChange_0(newOwner);
		});
	}
	// Token: 0x060017A6 RID: 6054 RVA: 0x0001190D File Offset: 0x0000FB0D
	public void imethod_24(OnLobbyInvitationRecieved onLobbyInvitationRecieved_0)
	{
		this.mOnLobbyInvitationReceived.Add(onLobbyInvitationRecieved_0);
	}

	// Token: 0x060017A7 RID: 6055 RVA: 0x0001191B File Offset: 0x0000FB1B
	public void imethod_25(OnLobbyInvitationRecieved onLobbyInvitationRecieved_0)
	{
		this.mOnLobbyInvitationReceived.Remove(onLobbyInvitationRecieved_0);
	}

	// Token: 0x060017A8 RID: 6056 RVA: 0x0007FD70 File Offset: 0x0007DF70
	private void OnLobbyInvitationReceived(Message message)
	{
		mOnLobbyInvitationReceived.ForEach(delegate(OnLobbyInvitationRecieved onLobbyInvitationRecieved_0)
		{
			onLobbyInvitationRecieved_0(message.mSender, message.mId);
		});
	}
	// Token: 0x060017A9 RID: 6057 RVA: 0x0001192A File Offset: 0x0000FB2A
	public void imethod_26(OnGroupJoinLobby onGroupJoinLobby_0)
	{
		this.mOnGroupJoinLobby.Add(onGroupJoinLobby_0);
	}

	// Token: 0x060017AA RID: 6058 RVA: 0x00011938 File Offset: 0x0000FB38
	public void imethod_27(OnGroupJoinLobby onGroupJoinLobby_0)
	{
		this.mOnGroupJoinLobby.Remove(onGroupJoinLobby_0);
	}

	// Token: 0x060017AB RID: 6059 RVA: 0x0007FDA4 File Offset: 0x0007DFA4
	private void OnGroupJoinedLobbyEvent(Dictionary<byte, object> parameters)
	{
		if (Boolean_0)
		{
			mCachedEvents.Add(new CachedEvent
			{
				Parameters = parameters,
				Callback = OnGroupJoinedLobbyEvent,
				RoomId = (int)parameters[1]
			});
		}
		else
		{
			int newGroup = (int)parameters[0];
			mOnGroupJoinLobby.ForEach(delegate(OnGroupJoinLobby onGroupJoinLobby_0)
			{
				onGroupJoinLobby_0(newGroup);
			});
		}
	}
	// Token: 0x060017AC RID: 6060 RVA: 0x00011947 File Offset: 0x0000FB47
	public void imethod_28(OnGroupLeaveLobby onGroupLeaveLobby_0)
	{
		this.mOnGroupLeaveLobby.Add(onGroupLeaveLobby_0);
	}

	// Token: 0x060017AD RID: 6061 RVA: 0x00011955 File Offset: 0x0000FB55
	public void imethod_29(OnGroupLeaveLobby onGroupLeaveLobby_0)
	{
		this.mOnGroupLeaveLobby.Remove(onGroupLeaveLobby_0);
	}

	// Token: 0x060017AE RID: 6062 RVA: 0x0007FE2C File Offset: 0x0007E02C
	private void OnGroupLeaveLobbyEvent(Dictionary<byte, object> parameters)
	{
		if (Boolean_0)
		{
			mCachedEvents.Add(new CachedEvent
			{
				Parameters = parameters,
				Callback = OnGroupLeaveLobbyEvent,
				RoomId = (int)parameters[1]
			});
		}
		else
		{
			int newGroup = (int)parameters[0];
			mOnGroupLeaveLobby.ForEach(delegate(OnGroupLeaveLobby onGroupLeaveLobby_0)
			{
				onGroupLeaveLobby_0(newGroup);
			});
		}
	}
	// Token: 0x060017AF RID: 6063 RVA: 0x00011964 File Offset: 0x0000FB64
	public void imethod_30(OnNewLobby onNewLobby_0)
	{
		this.mOnNewLobby.Add(onNewLobby_0);
	}

	// Token: 0x060017B0 RID: 6064 RVA: 0x00011972 File Offset: 0x0000FB72
	public void imethod_31(OnNewLobby onNewLobby_0)
	{
		this.mOnNewLobby.Remove(onNewLobby_0);
	}

	// Token: 0x060017B1 RID: 6065 RVA: 0x0007FEB4 File Offset: 0x0007E0B4
	private void OnNewLobbyEvent(Dictionary<byte, object> parameters)
	{
		Lobby newLobby = new Lobby((Hashtable)parameters[0]);
		mOnNewLobby.ForEach(delegate(OnNewLobby onNewLobby_0)
		{
			onNewLobby_0(newLobby);
		});
	}
	// Token: 0x060017B2 RID: 6066 RVA: 0x00011981 File Offset: 0x0000FB81
	public void imethod_8(OnGetLobby onGetLobby_0)
	{
		this.mOnGetLobby = onGetLobby_0;
		PhotonNetwork.onlinePeer.method_3(126, new object[0]);
	}

	// Token: 0x060017B3 RID: 6067 RVA: 0x0001199D File Offset: 0x0000FB9D
	public void method_0(OnGetLobby onGetLobby_0, int int_0)
	{
		this.mOnGetLobby = onGetLobby_0;
		PhotonNetwork.onlinePeer.method_3(126, new object[] { int_0 });
	}

	// Token: 0x060017B4 RID: 6068 RVA: 0x0007FEF8 File Offset: 0x0007E0F8
	private void OnGetLobbyResponse(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (this.mOnGetLobby != null)
		{
			if (operationResponse == 0)
			{
				Lobby lobby = new Lobby((Hashtable)parameters[0]);
				this.mOnGetLobby(lobby);
			}
			else
			{
				this.mOnGetLobby(null);
			}
			this.mOnGetLobby = null;
		}
	}

	// Token: 0x060017B5 RID: 6069 RVA: 0x000119C2 File Offset: 0x0000FBC2
	public void imethod_9(OnCloseLobby onCloseLobby_0)
	{
		this.mOnCloseLobby = onCloseLobby_0;
		PhotonNetwork.onlinePeer.method_3(125, new object[0]);
	}

	// Token: 0x060017B6 RID: 6070 RVA: 0x000119DE File Offset: 0x0000FBDE
	public void method_1(OnCloseLobby onCloseLobby_0, int int_0)
	{
		this.mOnCloseLobby = onCloseLobby_0;
		PhotonNetwork.onlinePeer.method_3(125, new object[] { int_0 });
	}

	// Token: 0x060017B7 RID: 6071 RVA: 0x00011A03 File Offset: 0x0000FC03
	private void OnCloseLobbyResponse(short operationResponse, Dictionary<byte, object> parameters)
	{
		this.mState = LobbyService.State.Closed;
		if (this.mOnCloseLobby != null)
		{
			if (operationResponse == 0)
			{
				this.mOnCloseLobby(true);
			}
			else
			{
				this.mOnCloseLobby(false);
			}
			this.mOnCloseLobby = null;
		}
	}

	// Token: 0x060017B8 RID: 6072 RVA: 0x00011A38 File Offset: 0x0000FC38
	public void method_2(OnSetPlayerTeamID onSetPlayerTeamID_0, int int_0, int int_1)
	{
		this.mOnSetPlayerTeamID = onSetPlayerTeamID_0;
		PhotonNetwork.networkingPeer.OpCustomWithArgs(122, new object[] { int_0, int_1 });
	}

	// Token: 0x060017B9 RID: 6073 RVA: 0x00011A66 File Offset: 0x0000FC66
	public void method_3(OnSubmitPvPResults onSubmitPvPResults_0, int int_0, params int[] int_1)
	{
		if (onSubmitPvPResults_0 == null)
		{
			this.mOnSubmitPvPResults.Add(onSubmitPvPResults_0);
		}
		PhotonNetwork.onlinePeer.method_3(56, new object[] { int_0, int_1 });
	}

	// Token: 0x060017BA RID: 6074 RVA: 0x00011A66 File Offset: 0x0000FC66
	public void method_4(OnSubmitPvPResults onSubmitPvPResults_0, int int_0, params int[] int_1)
	{
		if (onSubmitPvPResults_0 == null)
		{
			this.mOnSubmitPvPResults.Add(onSubmitPvPResults_0);
		}
		PhotonNetwork.onlinePeer.method_3(56, new object[] { int_0, int_1 });
	}

	// Token: 0x060017BB RID: 6075 RVA: 0x0007FF44 File Offset: 0x0007E144
	private void OnSubmitPvPResultsResponse(short operationResponse, Dictionary<byte, object> parameters)
	{
		mOnSubmitPvPResults.ForEach(delegate(OnSubmitPvPResults onSubmitPvPResults_0)
		{
			onSubmitPvPResults_0(operationResponse);
		});
		mOnSubmitPvPResults.Clear();
	}
	// Token: 0x060017BC RID: 6076 RVA: 0x00011A97 File Offset: 0x0000FC97
	private void OnSetPlayerTeamIDResponse(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (this.mOnSetPlayerTeamID != null)
		{
			if (operationResponse == 0)
			{
				this.mOnSetPlayerTeamID(true);
			}
			else
			{
				this.mOnSetPlayerTeamID(false);
			}
			this.mOnSetPlayerTeamID = null;
		}
	}

	// Token: 0x060017BD RID: 6077 RVA: 0x00011AC5 File Offset: 0x0000FCC5
	private void OnPvPGameCreatedEvent(Dictionary<byte, object> parameters)
	{
		PhotonNetwork.onlinePeer.method_3(123, new object[0]);
	}

	// Token: 0x060017BE RID: 6078 RVA: 0x0007FF80 File Offset: 0x0007E180
	private void OnAcceptLobbyGameInvitation(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (operationResponse == 0 && parameters != null && parameters.ContainsKey(0))
		{
			if (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<MatchMakingView>().Boolean_0)
			{
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<MatchMakingView>().Boolean_1 = false;
			}
			MonoSingleton<AppManager>.Instance.m_playlistId = (int)parameters[1];
			DebugUtils.Log(LogCategory.Network, "LobbyService.OnAcceptPvPGameInvitation - instance [" + MonoSingleton<AppManager>.Instance.m_playlistId + "]");
			MonoSingleton<GameFlowManager>.Instance.method_9((string)parameters[0]);
		}
	}

	// Token: 0x060017BF RID: 6079 RVA: 0x00080020 File Offset: 0x0007E220
	private void method_5(int int_0)
	{
		foreach (LobbyService.CachedEvent cachedEvent in this.mCachedEvents)
		{
			if (cachedEvent.RoomId == int_0)
			{
				cachedEvent.Callback(cachedEvent.Parameters);
			}
		}
		this.mCachedEvents.Clear();
	}

	// Token: 0x060017C0 RID: 6080 RVA: 0x0000311B File Offset: 0x0000131B
	private void OnSetPlayerTeamID(bool success)
	{
	}

	// Token: 0x17000135 RID: 309
	// (get) Token: 0x060017C1 RID: 6081 RVA: 0x00011ADA File Offset: 0x0000FCDA
	private bool Boolean_0
	{
		get
		{
			return this.mState == LobbyService.State.Creating || this.mState == LobbyService.State.Opening || this.mState == LobbyService.State.Joining || this.mState == LobbyService.State.Leaving;
		}
	}

	// Token: 0x060017C2 RID: 6082 RVA: 0x00011B03 File Offset: 0x0000FD03
	[CompilerGenerated]
	private static void smethod_0(OnLobbyGameStart onLobbyGameStart_0)
	{
		onLobbyGameStart_0();
	}

	// Token: 0x060017C3 RID: 6083 RVA: 0x00011B0B File Offset: 0x0000FD0B
	[CompilerGenerated]
	private static void smethod_1(OnLobbyClose onLobbyClose_0)
	{
		onLobbyClose_0();
	}

	// Token: 0x060017C4 RID: 6084 RVA: 0x00011B13 File Offset: 0x0000FD13
	[CompilerGenerated]
	private static void smethod_2(OnLobbyDelete onLobbyDelete_0)
	{
		onLobbyDelete_0();
	}

	// Token: 0x04000FF1 RID: 4081
	private OnCreateLobby mOnCreateLobby;

	// Token: 0x04000FF2 RID: 4082
	private OnOpenLobby mOnOpenLobby;

	// Token: 0x04000FF3 RID: 4083
	private OnInviteToLobby mOnInviteToLobby;

	// Token: 0x04000FF4 RID: 4084
	private OnAcceptLobbyInvitation mOnAcceptLobbyInvitation;

	// Token: 0x04000FF5 RID: 4085
	private OnRejectLobbyInvitation mOnRejectLobbyInvitation;

	// Token: 0x04000FF6 RID: 4086
	private OnKickPlayerFromLobby mOnKickPlayerFromLobby;

	// Token: 0x04000FF7 RID: 4087
	private OnLeaveLobby mOnLeaveLobby;

	// Token: 0x04000FF8 RID: 4088
	private OnStartLobbyGame mOnStartPvPGame;

	// Token: 0x04000FF9 RID: 4089
	private OnCloseLobby mOnCloseLobby;

	// Token: 0x04000FFA RID: 4090
	private OnSetPlayerTeamID mOnSetPlayerTeamID;

	// Token: 0x04000FFB RID: 4091
	private OnGetLobby mOnGetLobby;

	// Token: 0x04000FFC RID: 4092
	private List<OnSubmitPvPResults> mOnSubmitPvPResults;

	// Token: 0x04000FFD RID: 4093
	private List<OnPlayerJoinLobby> mOnPlayerJoinLobby;

	// Token: 0x04000FFE RID: 4094
	private List<OnPlayerLeaveLobby> mOnPlayerLeaveLobby;

	// Token: 0x04000FFF RID: 4095
	private List<OnLobbyCreated> mOnLobbyCreated;

	// Token: 0x04001000 RID: 4096
	private List<OnLobbyGameStart> mOnLobbyGameStart;

	// Token: 0x04001001 RID: 4097
	private List<OnLobbyClose> mOnLobbyClose;

	// Token: 0x04001002 RID: 4098
	private List<OnLobbyDelete> mOnLobbyDelete;

	// Token: 0x04001003 RID: 4099
	private List<OnLobbyOwnerChange> mOnLobbyOwnerChange;

	// Token: 0x04001004 RID: 4100
	private List<OnGroupJoinLobby> mOnGroupJoinLobby;

	// Token: 0x04001005 RID: 4101
	private List<OnGroupLeaveLobby> mOnGroupLeaveLobby;

	// Token: 0x04001006 RID: 4102
	private List<OnNewLobby> mOnNewLobby;

	// Token: 0x04001007 RID: 4103
	private List<OnLobbyInvitationRecieved> mOnLobbyInvitationReceived;

	// Token: 0x04001008 RID: 4104
	private List<LobbyService.CachedEvent> mCachedEvents;

	// Token: 0x04001009 RID: 4105
	private LobbyService.State mState;

	// Token: 0x020003A2 RID: 930
	private enum State
	{
		// Token: 0x0400100E RID: 4110
		Closed,
		// Token: 0x0400100F RID: 4111
		Creating,
		// Token: 0x04001010 RID: 4112
		Created,
		// Token: 0x04001011 RID: 4113
		Joining,
		// Token: 0x04001012 RID: 4114
		Joined,
		// Token: 0x04001013 RID: 4115
		Opening,
		// Token: 0x04001014 RID: 4116
		Opened,
		// Token: 0x04001015 RID: 4117
		Leaving,
		// Token: 0x04001016 RID: 4118
		Left,
		// Token: 0x04001017 RID: 4119
		Deleted
	}

	// Token: 0x020003A3 RID: 931
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	private struct CachedEvent
	{
		// Token: 0x17000136 RID: 310
		// (get) Token: 0x060017C5 RID: 6085 RVA: 0x00011B1B File Offset: 0x0000FD1B
		// (set) Token: 0x060017C6 RID: 6086 RVA: 0x00011B23 File Offset: 0x0000FD23
		public Dictionary<byte, object> Parameters { get; set; }

		// Token: 0x17000137 RID: 311
		// (get) Token: 0x060017C7 RID: 6087 RVA: 0x00011B2C File Offset: 0x0000FD2C
		// (set) Token: 0x060017C8 RID: 6088 RVA: 0x00011B34 File Offset: 0x0000FD34
		public EventCallback Callback { get; set; }

		// Token: 0x17000138 RID: 312
		// (get) Token: 0x060017C9 RID: 6089 RVA: 0x00011B3D File Offset: 0x0000FD3D
		// (set) Token: 0x060017CA RID: 6090 RVA: 0x00011B45 File Offset: 0x0000FD45
		public int RoomId { get; set; }
	}
}
