using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Core;
using ns0;

// Token: 0x02000377 RID: 887
public class GroupService : OnAccessSingleton<IGroupService, GroupService, GroupServiceOffline>, IGroupService
{
	// Token: 0x06001649 RID: 5705 RVA: 0x0007B9E8 File Offset: 0x00079BE8
	public GroupService()
	{
		PhotonNetwork.onlinePeer.method_5(158, new OperationResponseCallback(this.OnMyGroupInfoGot));
		PhotonNetwork.onlinePeer.method_5(163, new OperationResponseCallback(this.OnGroupInvitationSent));
		PhotonNetwork.onlinePeer.method_5(162, new OperationResponseCallback(this.OnGroupInvitationAccepted));
		PhotonNetwork.onlinePeer.method_5(160, new OperationResponseCallback(this.OnPlayerKickedFromGroup));
		PhotonNetwork.onlinePeer.method_5(159, new OperationResponseCallback(this.OnGroupLeft));
		PhotonNetwork.onlinePeer.method_5(151, new OperationResponseCallback(this.OnGroupRejoined));
		PhotonNetwork.onlinePeer.method_7(215, new EventCallback(this.OnKickedFromGroupEvent));
		PhotonNetwork.onlinePeer.method_7(214, new EventCallback(this.OnNewGroupLeaderEvent));
		PhotonNetwork.onlinePeer.method_7(213, new EventCallback(this.OnNewGroupMemberEvent));
		PhotonNetwork.onlinePeer.method_7(212, new EventCallback(this.OnGroupInviteRejectedEvent));
		PhotonNetwork.onlinePeer.method_7(211, new EventCallback(this.OnGroupMemberLeftEvent));
		PhotonNetwork.onlinePeer.method_7(210, new EventCallback(this.OnGroupGameStarted));
		PhotonNetwork.onlinePeer.method_7(209, new EventCallback(this.OnGroupDisbanded));
		PhotonNetwork.networkingPeer.method_77(165, new EventCallback(this.OnGroupMatchmakingStarted));
		PhotonNetwork.networkingPeer.method_79(199, new OperationResponseCallback(this.OnGameInvitationAccepted));
		PhotonNetwork.networkingPeer.method_77(210, new EventCallback(this.OnHostCreated));
		OnAccessSingleton<IMessagingService, MessagingService, MessagingServiceOffline>.Prop_0.imethod_5("group_invitation", new OnRecieveMessage(this.OnGroupInvitationReceived));
	}

	// Token: 0x0600164A RID: 5706 RVA: 0x00010626 File Offset: 0x0000E826
	public void imethod_0(OnGotMyGroupInfo onGotMyGroupInfo_0)
	{
		this.mOnGotMyGroupInfo = onGotMyGroupInfo_0;
		PhotonNetwork.onlinePeer.method_3(158, new object[0]);
	}

	// Token: 0x0600164B RID: 5707 RVA: 0x0007BC3C File Offset: 0x00079E3C
	private void OnMyGroupInfoGot(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (this.mOnGotMyGroupInfo != null)
		{
			if (operationResponse == 0)
			{
				if (parameters[0] == null)
				{
					this.mOnGotMyGroupInfo(-1, new List<Presence>());
				}
				else
				{
					int num = (int)parameters[0];
					List<Presence> list = new List<Presence>();
					if (num > 0)
					{
						Hashtable[] array = (Hashtable[])parameters[1];
						foreach (Hashtable hashtable in array)
						{
							list.Add(new Presence(hashtable));
						}
					}
					this.mOnGotMyGroupInfo(num, list);
				}
			}
			else
			{
				this.mOnGotMyGroupInfo(-1, new List<Presence>());
			}
			this.mOnGotMyGroupInfo = null;
		}
	}

	// Token: 0x0600164C RID: 5708 RVA: 0x00010645 File Offset: 0x0000E845
	public void imethod_7(OnGotMyGroupInfo onGotMyGroupInfo_0)
	{
		this.mOnRejoinGroup = onGotMyGroupInfo_0;
		PhotonNetwork.onlinePeer.method_3(151, new object[0]);
	}

	// Token: 0x0600164D RID: 5709 RVA: 0x0007BCE8 File Offset: 0x00079EE8
	private void OnGroupRejoined(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (this.mOnRejoinGroup != null)
		{
			if (operationResponse == 0)
			{
				if (parameters[0] == null)
				{
					this.mOnRejoinGroup(-1, new List<Presence>());
				}
				else
				{
					int num = (int)parameters[0];
					List<Presence> list = new List<Presence>();
					if (num > 0)
					{
						Hashtable[] array = (Hashtable[])parameters[1];
						foreach (Hashtable hashtable in array)
						{
							list.Add(new Presence(hashtable));
						}
					}
					this.mOnRejoinGroup(num, list);
				}
			}
			else
			{
				this.mOnRejoinGroup(-1, new List<Presence>());
			}
			this.mOnRejoinGroup = null;
		}
	}

	// Token: 0x0600164E RID: 5710 RVA: 0x00010664 File Offset: 0x0000E864
	public void imethod_1(OnSendGroupInvitation onSendGroupInvitation_0, int int_0)
	{
		this.mOnSendGroupInvitation = onSendGroupInvitation_0;
		PhotonNetwork.onlinePeer.method_3(163, new object[] { int_0 });
	}

	// Token: 0x0600164F RID: 5711 RVA: 0x0007BD94 File Offset: 0x00079F94
	private void OnGroupInvitationSent(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (this.mOnSendGroupInvitation != null)
		{
			if (operationResponse == 0)
			{
				int num = (int)parameters[0];
				this.mOnSendGroupInvitation(num);
			}
			else
			{
				this.mOnSendGroupInvitation(-1);
			}
			this.mOnSendGroupInvitation = null;
		}
	}

	// Token: 0x06001650 RID: 5712 RVA: 0x0001068C File Offset: 0x0000E88C
	public void imethod_2()
	{
		PhotonNetwork.onlinePeer.method_3(157, new object[0]);
	}

	// Token: 0x06001651 RID: 5713 RVA: 0x000106A4 File Offset: 0x0000E8A4
	public void imethod_3(OnGroupInviteAccepted onGroupInviteAccepted_0, int int_0)
	{
		this.mOnGroupInviteAccepted = onGroupInviteAccepted_0;
		PhotonNetwork.onlinePeer.method_3(162, new object[] { int_0 });
	}

	// Token: 0x06001652 RID: 5714 RVA: 0x0007BDDC File Offset: 0x00079FDC
	private void OnGroupInvitationAccepted(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (this.mOnGroupInviteAccepted != null)
		{
			if (operationResponse == 0)
			{
				int num = (int)parameters[0];
				List<Presence> list = new List<Presence>();
				if (num > 0)
				{
					Hashtable[] array = (Hashtable[])parameters[2];
					foreach (Hashtable hashtable in array)
					{
						list.Add(new Presence(hashtable));
					}
				}
				this.mOnGroupInviteAccepted(true, (int)parameters[0], (int)parameters[1], list);
			}
			else
			{
				this.mOnGroupInviteAccepted(false, -1, -1, new List<Presence>());
			}
			this.mOnGroupInviteAccepted = null;
		}
	}

	// Token: 0x06001653 RID: 5715 RVA: 0x000106CC File Offset: 0x0000E8CC
	public void imethod_4(int int_0)
	{
		PhotonNetwork.onlinePeer.method_3(161, new object[] { int_0 });
	}

	// Token: 0x06001654 RID: 5716 RVA: 0x000106ED File Offset: 0x0000E8ED
	public void imethod_5(OnKickPlayerFromGroup onKickPlayerFromGroup_0, int int_0)
	{
		this.mOnKickPlayerFromGroup = onKickPlayerFromGroup_0;
		PhotonNetwork.onlinePeer.method_3(160, new object[] { int_0 });
	}

	// Token: 0x06001655 RID: 5717 RVA: 0x00010715 File Offset: 0x0000E915
	private void OnPlayerKickedFromGroup(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (this.mOnKickPlayerFromGroup != null)
		{
			if (operationResponse == 0)
			{
				this.mOnKickPlayerFromGroup(true, (int)parameters[0]);
			}
			else
			{
				this.mOnKickPlayerFromGroup(false, -1);
			}
			this.mOnKickPlayerFromGroup = null;
		}
	}

	// Token: 0x06001656 RID: 5718 RVA: 0x00010750 File Offset: 0x0000E950
	public void imethod_6(OnLeaveGroup onLeaveGroup_0)
	{
		this.mOnLeaveGroup = onLeaveGroup_0;
		PhotonNetwork.onlinePeer.method_3(159, new object[0]);
	}

	// Token: 0x06001657 RID: 5719 RVA: 0x0001076F File Offset: 0x0000E96F
	private void OnGroupLeft(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (this.mOnLeaveGroup != null)
		{
			if (operationResponse == 0)
			{
				this.mOnLeaveGroup(true);
			}
			else
			{
				this.mOnLeaveGroup(false);
			}
			this.mOnLeaveGroup = null;
		}
	}

	// Token: 0x06001658 RID: 5720 RVA: 0x0007BE84 File Offset: 0x0007A084
	private void OnGroupInvitationReceived(Message message)
	{
		mOnReceivedGroupInvitation.ForEach(delegate(OnReceivedGroupInvitation onReceivedGroupInvitation_0)
		{
			onReceivedGroupInvitation_0(message.mSender, Convert.ToInt32(message.mPayload), message.mId);
		});
	}
	// Token: 0x06001659 RID: 5721 RVA: 0x0001079D File Offset: 0x0000E99D
	public void imethod_8(OnReceivedGroupInvitation onReceivedGroupInvitation_0)
	{
		this.mOnReceivedGroupInvitation.Add(onReceivedGroupInvitation_0);
	}

	// Token: 0x0600165A RID: 5722 RVA: 0x000107AB File Offset: 0x0000E9AB
	public void imethod_9(OnReceivedGroupInvitation onReceivedGroupInvitation_0)
	{
		this.mOnReceivedGroupInvitation.Remove(onReceivedGroupInvitation_0);
	}

	// Token: 0x0600165B RID: 5723 RVA: 0x000107BA File Offset: 0x0000E9BA
	private void OnKickedFromGroupEvent(Dictionary<byte, object> parameters)
	{
		this.mOnKickedFromGroup.ForEach(new Action<OnKickedFromGroup>(GroupService.smethod_0));
	}

	// Token: 0x0600165C RID: 5724 RVA: 0x000107E4 File Offset: 0x0000E9E4
	public void imethod_10(OnKickedFromGroup onKickedFromGroup_0)
	{
		this.mOnKickedFromGroup.Add(onKickedFromGroup_0);
	}

	// Token: 0x0600165D RID: 5725 RVA: 0x000107F2 File Offset: 0x0000E9F2
	public void imethod_11(OnKickedFromGroup onKickedFromGroup_0)
	{
		this.mOnKickedFromGroup.Remove(onKickedFromGroup_0);
	}

	// Token: 0x0600165E RID: 5726 RVA: 0x0007BEB8 File Offset: 0x0007A0B8
	private void OnNewGroupLeaderEvent(Dictionary<byte, object> parameters)
	{
		int characterId = (int)parameters[0];
		mOnNewGroupLeader.ForEach(delegate(OnNewGroupLeader onNewGroupLeader_0)
		{
			onNewGroupLeader_0(characterId);
		});
	}
	// Token: 0x0600165F RID: 5727 RVA: 0x00010801 File Offset: 0x0000EA01
	public void imethod_12(OnNewGroupLeader onNewGroupLeader_0)
	{
		this.mOnNewGroupLeader.Add(onNewGroupLeader_0);
	}

	// Token: 0x06001660 RID: 5728 RVA: 0x0001080F File Offset: 0x0000EA0F
	public void imethod_13(OnNewGroupLeader onNewGroupLeader_0)
	{
		this.mOnNewGroupLeader.Remove(onNewGroupLeader_0);
	}

	// Token: 0x06001661 RID: 5729 RVA: 0x0007BEF4 File Offset: 0x0007A0F4
	private void OnNewGroupMemberEvent(Dictionary<byte, object> parameters)
	{
		Hashtable hashtable_ = (Hashtable)parameters[0];
		Presence characterinfo = new Presence(hashtable_);
		mOnNewGroupMember.ForEach(delegate(OnNewGroupMember onNewGroupMember_0)
		{
			onNewGroupMember_0(characterinfo);
		});
	}
	// Token: 0x06001662 RID: 5730 RVA: 0x0001081E File Offset: 0x0000EA1E
	public void imethod_14(OnNewGroupMember onNewGroupMember_0)
	{
		this.mOnNewGroupMember.Add(onNewGroupMember_0);
	}

	// Token: 0x06001663 RID: 5731 RVA: 0x0001082C File Offset: 0x0000EA2C
	public void imethod_15(OnNewGroupMember onNewGroupMember_0)
	{
		this.mOnNewGroupMember.Remove(onNewGroupMember_0);
	}

	// Token: 0x06001664 RID: 5732 RVA: 0x0007BF38 File Offset: 0x0007A138
	private void OnGroupInviteRejectedEvent(Dictionary<byte, object> parameters)
	{
		int characterId = (int)parameters[0];
		string characterName = (string)parameters[1];
		mOnGroupInviteRejected.ForEach(delegate(OnGroupInviteRejected onGroupInviteRejected_0)
		{
			onGroupInviteRejected_0(characterId, characterName);
		});
	}
	// Token: 0x06001665 RID: 5733 RVA: 0x0001083B File Offset: 0x0000EA3B
	public void imethod_16(OnGroupInviteRejected onGroupInviteRejected_0)
	{
		this.mOnGroupInviteRejected.Add(onGroupInviteRejected_0);
	}

	// Token: 0x06001666 RID: 5734 RVA: 0x00010849 File Offset: 0x0000EA49
	public void imethod_17(OnGroupInviteRejected onGroupInviteRejected_0)
	{
		this.mOnGroupInviteRejected.Remove(onGroupInviteRejected_0);
	}

	// Token: 0x06001667 RID: 5735 RVA: 0x0007BF88 File Offset: 0x0007A188
	private void OnGroupMemberLeftEvent(Dictionary<byte, object> parameters)
	{
		int characterId = (int)parameters[0];
		mOnGroupMemberLeft.ForEach(delegate(OnGroupMemberLeft onGroupMemberLeft_0)
		{
			onGroupMemberLeft_0(characterId);
		});
	}
	// Token: 0x06001668 RID: 5736 RVA: 0x00010858 File Offset: 0x0000EA58
	public void imethod_18(OnGroupMemberLeft onGroupMemberLeft_0)
	{
		this.mOnGroupMemberLeft.Add(onGroupMemberLeft_0);
	}

	// Token: 0x06001669 RID: 5737 RVA: 0x00010866 File Offset: 0x0000EA66
	public void imethod_19(OnGroupMemberLeft onGroupMemberLeft_0)
	{
		this.mOnGroupMemberLeft.Remove(onGroupMemberLeft_0);
	}

	// Token: 0x0600166A RID: 5738 RVA: 0x00010875 File Offset: 0x0000EA75
	private void OnHostCreated(Dictionary<byte, object> parameters)
	{
		this.imethod_2();
	}

	// Token: 0x0600166B RID: 5739 RVA: 0x0001087D File Offset: 0x0000EA7D
	private void OnGroupGameStarted(Dictionary<byte, object> parameters)
	{
		PhotonNetwork.networkingPeer.method_81(199, new object[0]);
	}

	// Token: 0x0600166C RID: 5740 RVA: 0x0007BFC4 File Offset: 0x0007A1C4
	private void OnGameInvitationAccepted(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (operationResponse == 0 && parameters != null && parameters.ContainsKey(0))
		{
			MonoSingleton<AppManager>.Instance.m_playlistId = (int)parameters[1];
			DebugUtils.Log(LogCategory.Network, "GroupService.OnGameInvitationAccepted - " + MonoSingleton<AppManager>.Instance.m_playlistId);
			MonoSingleton<GameFlowManager>.Instance.method_9((string)parameters[0]);
		}
	}

	// Token: 0x0600166D RID: 5741 RVA: 0x00010895 File Offset: 0x0000EA95
	private void OnGroupDisbanded(Dictionary<byte, object> parameters)
	{
		this.mOnGroupDisbanded.ForEach(new Action<OnGroupDisbanded>(GroupService.smethod_1));
	}

	// Token: 0x0600166E RID: 5742 RVA: 0x000108BF File Offset: 0x0000EABF
	public void imethod_20(OnGroupDisbanded onGroupDisbanded_0)
	{
		this.mOnGroupDisbanded.Add(onGroupDisbanded_0);
	}

	// Token: 0x0600166F RID: 5743 RVA: 0x000108CD File Offset: 0x0000EACD
	public void imethod_21(OnGroupDisbanded onGroupDisbanded_0)
	{
		this.mOnGroupDisbanded.Remove(onGroupDisbanded_0);
	}

	// Token: 0x06001670 RID: 5744 RVA: 0x000108DC File Offset: 0x0000EADC
	private void OnGroupMatchmakingStarted(Dictionary<byte, object> parameters)
	{
		this.mOnGroupMatchmakingStarted.ForEach(new Action<OnGroupMatchmakingStarted>(GroupService.smethod_2));
	}

	// Token: 0x06001671 RID: 5745 RVA: 0x00010906 File Offset: 0x0000EB06
	public void imethod_22(OnGroupMatchmakingStarted onGroupMatchmakingStarted_0)
	{
		this.mOnGroupMatchmakingStarted.Add(onGroupMatchmakingStarted_0);
	}

	// Token: 0x06001672 RID: 5746 RVA: 0x00010914 File Offset: 0x0000EB14
	public void imethod_23(OnGroupMatchmakingStarted onGroupMatchmakingStarted_0)
	{
		this.mOnGroupMatchmakingStarted.Remove(onGroupMatchmakingStarted_0);
	}

	// Token: 0x06001673 RID: 5747 RVA: 0x00010923 File Offset: 0x0000EB23
	[CompilerGenerated]
	private static void smethod_0(OnKickedFromGroup onKickedFromGroup_0)
	{
		onKickedFromGroup_0();
	}

	// Token: 0x06001674 RID: 5748 RVA: 0x0001092B File Offset: 0x0000EB2B
	[CompilerGenerated]
	private static void smethod_1(OnGroupDisbanded onGroupDisbanded_0)
	{
		onGroupDisbanded_0();
	}

	// Token: 0x06001675 RID: 5749 RVA: 0x00010933 File Offset: 0x0000EB33
	[CompilerGenerated]
	private static void smethod_2(OnGroupMatchmakingStarted onGroupMatchmakingStarted_0)
	{
		onGroupMatchmakingStarted_0();
	}

	// Token: 0x04000F0A RID: 3850
	public readonly DateTime EPOCH = new DateTime(1970, 1, 1, 0, 0, 0, 0);

	// Token: 0x04000F0B RID: 3851
	private List<OnReceivedGroupInvitation> mOnReceivedGroupInvitation = new List<OnReceivedGroupInvitation>();

	// Token: 0x04000F0C RID: 3852
	private List<OnKickedFromGroup> mOnKickedFromGroup = new List<OnKickedFromGroup>();

	// Token: 0x04000F0D RID: 3853
	private List<OnNewGroupLeader> mOnNewGroupLeader = new List<OnNewGroupLeader>();

	// Token: 0x04000F0E RID: 3854
	private List<OnNewGroupMember> mOnNewGroupMember = new List<OnNewGroupMember>();

	// Token: 0x04000F0F RID: 3855
	private List<OnGroupInviteRejected> mOnGroupInviteRejected = new List<OnGroupInviteRejected>();

	// Token: 0x04000F10 RID: 3856
	private List<OnGroupMemberLeft> mOnGroupMemberLeft = new List<OnGroupMemberLeft>();

	// Token: 0x04000F11 RID: 3857
	private List<OnGroupDisbanded> mOnGroupDisbanded = new List<OnGroupDisbanded>();

	// Token: 0x04000F12 RID: 3858
	private List<OnGroupMatchmakingStarted> mOnGroupMatchmakingStarted = new List<OnGroupMatchmakingStarted>();

	// Token: 0x04000F13 RID: 3859
	private OnGotMyGroupInfo mOnGotMyGroupInfo;

	// Token: 0x04000F14 RID: 3860
	private OnSendGroupInvitation mOnSendGroupInvitation;

	// Token: 0x04000F15 RID: 3861
	private OnGroupInviteAccepted mOnGroupInviteAccepted;

	// Token: 0x04000F16 RID: 3862
	private OnKickPlayerFromGroup mOnKickPlayerFromGroup;

	// Token: 0x04000F17 RID: 3863
	private OnLeaveGroup mOnLeaveGroup;

	// Token: 0x04000F18 RID: 3864
	private OnGotMyGroupInfo mOnRejoinGroup;
}
