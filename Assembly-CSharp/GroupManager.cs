using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using ns0;
using XsdSettings;

// Token: 0x02000675 RID: 1653
public class GroupManager : IGroupServiceNotificationListerner
{
	// Token: 0x060029E5 RID: 10725 RVA: 0x000C4F34 File Offset: 0x000C3134
	private GroupManager()
	{
		this.m_bFirstLogin = true;
		if (this.m_InviteDataMap == null)
		{
			this.m_InviteDataMap = new Dictionary<int, GroupManager.GroupInviteData>();
			this.m_InviteDataMap.Clear();
		}
		if (this.m_InviteMessageMap == null)
		{
			this.m_InviteMessageMap = new Dictionary<int, int>();
			this.m_InviteMessageMap.Clear();
		}
		if (this.m_GroupInfoMap == null)
		{
			this.m_GroupInfoMap = new Dictionary<int, Presence>();
			this.m_GroupInfoMap.Clear();
		}
		OnAccessSingleton<IPresenceService, PresenceService, PresenceServiceOffline>.Prop_0.imethod_4(new OnPresenceUpdated(this.OnPresenceUpdated));
	}

	// Token: 0x060029E6 RID: 10726 RVA: 0x0001B7EB File Offset: 0x000199EB
	public static GroupManager smethod_0()
	{
		if (GroupManager._GroupInstance == null)
		{
			GroupManager._GroupInstance = new GroupManager();
			ServiceWrapperBase<GroupServiceWrapper>.Instance.method_0(GroupManager._GroupInstance);
		}
		return GroupManager._GroupInstance;
	}

	// Token: 0x060029E7 RID: 10727 RVA: 0x0001B812 File Offset: 0x00019A12
	public void method_0(int int_0)
	{
		this.m_TargetCharacterId = int_0;
	}

	// Token: 0x060029E8 RID: 10728 RVA: 0x000C4FD4 File Offset: 0x000C31D4
	protected void OnPresenceUpdated(Presence presence)
	{
		if (presence == null)
		{
			return;
		}
		if (this.m_GroupInfoMap.ContainsKey(presence.mCharacterId))
		{
			this.m_GroupInfoMap[presence.mCharacterId].mCharacterLevel = presence.mCharacterLevel;
			this.m_GroupInfoMap[presence.mCharacterId].mIsOnline = presence.mIsOnline;
			this.m_GroupInfoMap[presence.mCharacterId].mLastOnline = presence.mLastOnline;
			this.m_GroupInfoMap[presence.mCharacterId].mCurrentTown = presence.mCurrentTown;
			this.m_GroupInfoMap[presence.mCharacterId].mCurrentPlaylist = presence.mCurrentPlaylist;
		}
	}

	// Token: 0x060029E9 RID: 10729 RVA: 0x000C5088 File Offset: 0x000C3288
	public void method_1()
	{
		this.m_InviteDataMap.Clear();
		this.m_InviteMessageMap.Clear();
		for (int i = 0; i < 33; i++)
		{
			GroupManager.GroupInviteData groupInviteData = new GroupManager.GroupInviteData();
			groupInviteData.InviterInfo.m_level = i;
			groupInviteData.InviterInfo.m_name = "test" + i;
			groupInviteData.InviterInfo.m_id = i;
			this.m_InviteDataMap.Add(i, groupInviteData);
			this.m_InviteMessageMap.Add(i, i);
		}
	}

	// Token: 0x060029EA RID: 10730 RVA: 0x000C510C File Offset: 0x000C330C
	public void method_2(Presence presence_0)
	{
		if (!this.m_InviteDataMap.ContainsKey(presence_0.mCharacterId))
		{
			GroupManager.GroupInviteData groupInviteData = new GroupManager.GroupInviteData();
			groupInviteData.m_nMessageId = this.m_InviteMessageMap[presence_0.mCharacterId];
			groupInviteData.InviterInfo.m_avatarDna = presence_0.mAvatarDNA;
			groupInviteData.InviterInfo.m_exp = presence_0.mCharacterExperience;
			groupInviteData.InviterInfo.m_id = presence_0.mCharacterId;
			groupInviteData.InviterInfo.m_level = presence_0.mCharacterLevel;
			groupInviteData.InviterInfo.m_bondCurrency = presence_0.mCurrency;
			groupInviteData.InviterInfo.m_name = presence_0.mCharacterName;
			this.m_InviteDataMap.Add(presence_0.mCharacterId, groupInviteData);
			if (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InstanceSelectView>().Boolean_0)
			{
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InstanceSelectView>().vmethod_12();
			}
		}
		else
		{
			this.m_InviteDataMap[presence_0.mCharacterId].m_nMessageId = this.m_InviteMessageMap[presence_0.mCharacterId];
		}
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<GroupView>().vmethod_5();
	}

	// Token: 0x060029EB RID: 10731 RVA: 0x0001B81B File Offset: 0x00019A1B
	public int method_3()
	{
		return this.m_InviteDataMap.Count<KeyValuePair<int, GroupManager.GroupInviteData>>();
	}

	// Token: 0x060029EC RID: 10732 RVA: 0x0001B828 File Offset: 0x00019A28
	public GroupManager.InviteMessageStatus method_4(int int_0)
	{
		return this.m_InviteDataMap[int_0].InviteStatus;
	}

	// Token: 0x060029ED RID: 10733 RVA: 0x000C522C File Offset: 0x000C342C
	public PlayerProperties method_5(int int_0)
	{
		if (int_0 >= 0 && int_0 < this.m_InviteDataMap.Count<KeyValuePair<int, GroupManager.GroupInviteData>>())
		{
			return this.m_InviteDataMap.ElementAt<KeyValuePair<int, GroupManager.GroupInviteData>>(int_0).Value.InviterInfo;
		}
		return null;
	}

	// Token: 0x060029EE RID: 10734 RVA: 0x000C5268 File Offset: 0x000C3468
	public GroupManager.InviteMessageStatus method_6(int int_0)
	{
		if (int_0 >= 0 && int_0 < this.m_InviteDataMap.Count<KeyValuePair<int, GroupManager.GroupInviteData>>())
		{
			return this.m_InviteDataMap.ElementAt<KeyValuePair<int, GroupManager.GroupInviteData>>(int_0).Value.InviteStatus;
		}
		return GroupManager.InviteMessageStatus.e_None;
	}

	// Token: 0x060029EF RID: 10735 RVA: 0x0001B83B File Offset: 0x00019A3B
	public bool method_7(int int_0)
	{
		return this.m_InviteDataMap.ContainsKey(int_0);
	}

	// Token: 0x060029F0 RID: 10736 RVA: 0x000C52A4 File Offset: 0x000C34A4
	public void method_8()
	{
		for (int i = 0; i < this.m_InviteDataMap.Count<KeyValuePair<int, GroupManager.GroupInviteData>>(); i++)
		{
			if (this.m_InviteDataMap.ElementAt<KeyValuePair<int, GroupManager.GroupInviteData>>(i).Value.InviteStatus == GroupManager.InviteMessageStatus.e_WaitingForDecide)
			{
				this.m_InviteDataMap.ElementAt<KeyValuePair<int, GroupManager.GroupInviteData>>(i).Value.InviteStatus = GroupManager.InviteMessageStatus.e_Locked;
			}
		}
	}

	// Token: 0x060029F1 RID: 10737 RVA: 0x000C5300 File Offset: 0x000C3500
	public void method_9()
	{
		for (int i = 0; i < this.m_InviteDataMap.Count<KeyValuePair<int, GroupManager.GroupInviteData>>(); i++)
		{
			if (this.m_InviteDataMap.ElementAt<KeyValuePair<int, GroupManager.GroupInviteData>>(i).Value.InviteStatus == GroupManager.InviteMessageStatus.e_Locked)
			{
				this.m_InviteDataMap.ElementAt<KeyValuePair<int, GroupManager.GroupInviteData>>(i).Value.InviteStatus = GroupManager.InviteMessageStatus.e_WaitingForDecide;
			}
		}
	}

	// Token: 0x060029F2 RID: 10738 RVA: 0x000C535C File Offset: 0x000C355C
	public void method_10()
	{
		List<int> list = new List<int>();
		list.Clear();
		for (int i = 0; i < this.m_InviteDataMap.Count<KeyValuePair<int, GroupManager.GroupInviteData>>(); i++)
		{
			if (this.m_InviteDataMap.ElementAt<KeyValuePair<int, GroupManager.GroupInviteData>>(i).Value.InviteStatus != GroupManager.InviteMessageStatus.e_WaitingForDecide)
			{
				list.Add(this.m_InviteDataMap.ElementAt<KeyValuePair<int, GroupManager.GroupInviteData>>(i).Key);
			}
		}
		for (int j = 0; j < list.Count<int>(); j++)
		{
			this.m_InviteDataMap.Remove(list[j]);
			this.m_InviteMessageMap.Remove(list[j]);
		}
	}

	// Token: 0x060029F3 RID: 10739 RVA: 0x000C53FC File Offset: 0x000C35FC
	private GroupManager.GroupInviteData method_11(int int_0)
	{
		return new GroupManager.GroupInviteData
		{
			InviteStatus = GroupManager.InviteMessageStatus.e_Accepted,
			m_nMessageId = this.m_InviteMessageMap[int_0],
			InviterInfo = 
			{
				m_avatarDna = this.m_InviteDataMap[int_0].InviterInfo.m_avatarDna,
				m_exp = this.m_InviteDataMap[int_0].InviterInfo.m_exp,
				m_id = this.m_InviteDataMap[int_0].InviterInfo.m_id,
				m_level = this.m_InviteDataMap[int_0].InviterInfo.m_level,
				m_bondCurrency = this.m_InviteDataMap[int_0].InviterInfo.m_bondCurrency,
				m_name = this.m_InviteDataMap[int_0].InviterInfo.m_name
			}
		};
	}

	// Token: 0x060029F4 RID: 10740 RVA: 0x000C54F0 File Offset: 0x000C36F0
	public void OnGroupInviteAccepted(bool successful, int sender, int groupId, List<Presence> members)
	{
		if (successful)
		{
			GroupManager.GroupInviteData groupInviteData = this.method_11(sender);
			for (int i = 0; i < this.m_InviteDataMap.Count<KeyValuePair<int, GroupManager.GroupInviteData>>(); i++)
			{
				if (this.m_InviteDataMap.ElementAt<KeyValuePair<int, GroupManager.GroupInviteData>>(i).Key != sender && this.m_InviteMessageMap.ContainsKey(this.m_InviteDataMap.ElementAt<KeyValuePair<int, GroupManager.GroupInviteData>>(i).Key))
				{
					this.m_InviteMessageMap.Remove(this.m_InviteDataMap.ElementAt<KeyValuePair<int, GroupManager.GroupInviteData>>(i).Key);
				}
			}
			this.m_InviteDataMap.Clear();
			this.m_InviteDataMap.Add(groupInviteData.InviterInfo.m_id, groupInviteData);
			this.m_bInGroup = true;
			this.m_nGroupId = groupId;
			this.method_32(members);
			if (this.m_cbOnGetGroupInfo != null)
			{
				this.m_cbOnGetGroupInfo(groupId, members);
			}
		}
		else
		{
			this.method_9();
			GroupManager.GroupInviteData groupInviteData2;
			if (this.m_InviteDataMap.TryGetValue(sender, out groupInviteData2))
			{
				groupInviteData2.InviteStatus = GroupManager.InviteMessageStatus.e_JoinFailed;
			}
		}
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<GroupView>().vmethod_5();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InstanceSelectView>().vmethod_25();
	}

	// Token: 0x060029F5 RID: 10741 RVA: 0x000C5610 File Offset: 0x000C3810
	public void method_12(int int_0)
	{
		if (int_0 != -1 && this.m_InviteMessageMap.ContainsKey(int_0))
		{
			this.m_InviteDataMap[int_0].InviteStatus = GroupManager.InviteMessageStatus.e_Decided;
			this.method_8();
			this.m_nAcceptId = int_0;
			ServiceWrapperBase<GroupServiceWrapper>.Instance.method_4(new OnGroupInviteAccepted(this.OnGroupInviteAccepted), this.m_InviteMessageMap[int_0]);
		}
	}

	// Token: 0x060029F6 RID: 10742 RVA: 0x000C5670 File Offset: 0x000C3870
	public void method_13(int int_0)
	{
		if (int_0 != -1 && this.m_InviteMessageMap.ContainsKey(int_0))
		{
			ServiceWrapperBase<GroupServiceWrapper>.Instance.method_5(this.m_InviteMessageMap[int_0]);
			this.m_InviteDataMap[int_0].InviteStatus = GroupManager.InviteMessageStatus.e_Rejected;
			this.m_InviteDataMap.Remove(int_0);
			this.m_InviteMessageMap.Remove(int_0);
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<GroupView>().vmethod_5();
		}
	}

	// Token: 0x060029F7 RID: 10743 RVA: 0x0001B849 File Offset: 0x00019A49
	public void method_14(object object_0)
	{
		ServiceWrapperBase<GroupServiceWrapper>.Instance.method_3(new OnSendGroupInvitation(this.method_15), this.m_TargetCharacterId);
	}

	// Token: 0x060029F8 RID: 10744 RVA: 0x0000311B File Offset: 0x0000131B
	protected void method_15(int int_0)
	{
	}

	// Token: 0x060029F9 RID: 10745 RVA: 0x000C56E8 File Offset: 0x000C38E8
	public void OnReceivedGroupInvitation(int senderCharacterId, int groupId, int messageId)
	{
		if (this.m_InviteMessageMap.ContainsKey(senderCharacterId))
		{
			this.m_InviteMessageMap[senderCharacterId] = messageId;
		}
		else
		{
			this.m_InviteMessageMap.Add(senderCharacterId, messageId);
		}
		OnAccessSingleton<IPresenceService, PresenceService, PresenceServiceOffline>.Prop_0.imethod_0(senderCharacterId, new OnGetPresence(this.method_2));
	}

	// Token: 0x060029FA RID: 10746 RVA: 0x0001B867 File Offset: 0x00019A67
	public void OnKickedFromGroup()
	{
		this.m_bInGroup = false;
		this.m_nGroupId = -1;
		this.m_GroupInfoMap.Clear();
		if (!MonoSingleton<Session>.Instance.method_16())
		{
			MonoSingleton<GameFlowManager>.Instance.method_11();
		}
	}

	// Token: 0x060029FB RID: 10747 RVA: 0x0001B898 File Offset: 0x00019A98
	public void OnNewGroupLeader(int characterId)
	{
		if (characterId == -1)
		{
			return;
		}
		this.m_nLeaderId = characterId;
		if (this.method_19())
		{
			LevelLockingManager.smethod_0().method_10();
		}
		this.method_16();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InstanceSelectView>().vmethod_25();
	}

	// Token: 0x060029FC RID: 10748 RVA: 0x000C5738 File Offset: 0x000C3938
	public void method_16()
	{
		if (this.m_bInGroup)
		{
			if (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InstanceSelectView>().Boolean_0)
			{
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InstanceSelectView>().vmethod_11(this.method_19());
			}
			if (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDPlayerInfoView>().Boolean_0)
			{
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDPlayerInfoView>().vmethod_15(this.method_19());
			}
		}
		else
		{
			if (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InstanceSelectView>().Boolean_0)
			{
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InstanceSelectView>().vmethod_11(false);
			}
			if (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDPlayerInfoView>().Boolean_0)
			{
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDPlayerInfoView>().vmethod_15(false);
			}
		}
	}

	// Token: 0x060029FD RID: 10749 RVA: 0x000C5808 File Offset: 0x000C3A08
	public void OnNewGroupMember(Presence characterinfo)
	{
		if (characterinfo == null)
		{
			return;
		}
		if (characterinfo.mCharacterId == -1)
		{
			return;
		}
		if (!this.m_bInGroup)
		{
			this.m_nLeaderId = MonoSingleton<Session>.Instance.GetLocalPlayer().m_characterId;
			this.m_bInGroup = true;
			this.method_16();
		}
		if (!this.m_GroupInfoMap.ContainsKey(characterinfo.mCharacterId))
		{
			this.m_GroupInfoMap.Add(characterinfo.mCharacterId, characterinfo);
		}
		if (this.method_19())
		{
			LevelLockingManager.smethod_0().method_10();
		}
	}

	// Token: 0x060029FE RID: 10750 RVA: 0x0001B8D2 File Offset: 0x00019AD2
	public void OnGroupInviteRejected(int characterId, string characterName)
	{
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<ChatView>().method_8(ChatParameter.System, string.Empty, Utility.smethod_5(characterName, LocalizedString.smethod_0(new LocalizedString("GROUP_REFUSE"))), 0, string.Empty);
	}

	// Token: 0x060029FF RID: 10751 RVA: 0x0001B909 File Offset: 0x00019B09
	public void OnGroupMemberLeft(int characterId)
	{
		if (this.m_GroupInfoMap.ContainsKey(characterId))
		{
			this.m_GroupInfoMap.Remove(characterId);
		}
		if (this.method_19())
		{
			LevelLockingManager.smethod_0().method_10();
		}
	}

	// Token: 0x06002A00 RID: 10752 RVA: 0x0001B938 File Offset: 0x00019B38
	public void OnGroupDisbanded()
	{
		this.m_bInGroup = false;
		this.m_nGroupId = -1;
		this.m_nLeaderId = -1;
		this.m_GroupInfoMap.Clear();
		LevelLockingManager.smethod_0().method_10();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InstanceSelectView>().vmethod_25();
	}

	// Token: 0x06002A01 RID: 10753 RVA: 0x0001B978 File Offset: 0x00019B78
	public bool method_17(int int_0)
	{
		return this.m_GroupInfoMap.ContainsKey(int_0);
	}

	// Token: 0x06002A02 RID: 10754 RVA: 0x0001B986 File Offset: 0x00019B86
	public bool method_18()
	{
		return this.m_bInGroup;
	}

	// Token: 0x06002A03 RID: 10755 RVA: 0x0001B98E File Offset: 0x00019B8E
	public bool method_19()
	{
		return OnlineService.s_characterId == this.m_nLeaderId;
	}

	// Token: 0x06002A04 RID: 10756 RVA: 0x000C5884 File Offset: 0x000C3A84
	public bool method_20()
	{
		if (!this.m_bInGroup)
		{
			return !LobbyManager.smethod_0().method_0() || LobbyManager.smethod_0().method_1();
		}
		if (MonoSingleton<Session>.Instance.GetLocalPlayer().m_characterId == this.m_nLeaderId)
		{
			for (int i = 0; i < this.m_GroupInfoMap.Count; i++)
			{
				Playlist playlist = MatchmakingService.MatchmakingService_0.method_1(this.m_GroupInfoMap.ElementAt<KeyValuePair<int, Presence>>(i).Value.mCurrentPlaylist);
				if (playlist.m_gameMode != "GameModeTown")
				{
					return false;
				}
			}
			return true;
		}
		return false;
	}

	// Token: 0x06002A05 RID: 10757 RVA: 0x0001B99D File Offset: 0x00019B9D
	public void method_21()
	{
		ServiceWrapperBase<GroupServiceWrapper>.Instance.method_2(new OnGotMyGroupInfo(this.OnGotMyGroupInfo));
	}

	// Token: 0x06002A06 RID: 10758 RVA: 0x000C5920 File Offset: 0x000C3B20
	private void OnGotMyGroupInfo(int groupId, List<Presence> members)
	{
		this.m_GroupInfoMap.Clear();
		if (groupId != -1)
		{
			this.m_bInGroup = true;
			this.m_nGroupId = groupId;
			this.method_32(members);
			if (this.m_cbOnGetGroupInfo != null)
			{
				this.m_cbOnGetGroupInfo(groupId, members);
			}
		}
		else
		{
			this.m_bInGroup = false;
			this.m_nGroupId = -1;
		}
	}

	// Token: 0x06002A07 RID: 10759 RVA: 0x000C5978 File Offset: 0x000C3B78
	public void method_22(int int_0)
	{
		if (this.m_bInGroup)
		{
			if (this.method_19())
			{
				MenuItemDef[] array = new MenuItemDef[2];
				array[0].itemTitle = LocalizedString.smethod_0(new LocalizedString("Group_Exple"));
				array[0].itemData = int_0;
				array[0].itemFunc = new MenuItemProcessFunc(this.method_23);
				array[1].itemTitle = LocalizedString.smethod_0(new LocalizedString("Group_Leave"));
				array[1].itemData = int_0;
				array[1].itemFunc = new MenuItemProcessFunc(this.method_25);
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<PopupMenuView>().method_3(array);
			}
			else
			{
				MenuItemDef[] array2 = new MenuItemDef[1];
				array2[0].itemTitle = LocalizedString.smethod_0(new LocalizedString("Group_Leave"));
				array2[0].itemData = int_0;
				array2[0].itemFunc = new MenuItemProcessFunc(this.method_25);
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<PopupMenuView>().method_3(array2);
			}
		}
	}

	// Token: 0x06002A08 RID: 10760 RVA: 0x0001B9B5 File Offset: 0x00019BB5
	private void OnKickPlayerFromGroup(bool successful, int kickedCharacterId)
	{
		if (successful && this.m_GroupInfoMap.ContainsKey(kickedCharacterId))
		{
			this.m_GroupInfoMap.Remove(kickedCharacterId);
		}
	}

	// Token: 0x06002A09 RID: 10761 RVA: 0x000C5AA4 File Offset: 0x000C3CA4
	private void OnLeaveGroup(bool successful)
	{
		if (successful)
		{
			this.m_bInGroup = false;
			this.m_nGroupId = -1;
			this.m_GroupInfoMap.Clear();
			LevelLockingManager.smethod_0().method_10();
			if (!MonoSingleton<Session>.Instance.method_16())
			{
				MonoSingleton<GameFlowManager>.Instance.method_11();
			}
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InstanceSelectView>().vmethod_25();
		}
		else
		{
			DebugUtils.Log(LogCategory.GUI, MonoSingleton<Session>.Instance.GetLocalPlayer().m_name + " leave group failed!!!");
		}
	}

	// Token: 0x06002A0A RID: 10762 RVA: 0x0001B9D5 File Offset: 0x00019BD5
	public void method_23(object object_0)
	{
		ServiceWrapperBase<GroupServiceWrapper>.Instance.method_6(new OnKickPlayerFromGroup(this.OnKickPlayerFromGroup), (int)object_0);
	}

	// Token: 0x06002A0B RID: 10763 RVA: 0x0001B9F3 File Offset: 0x00019BF3
	public void method_24(int int_0)
	{
		ServiceWrapperBase<GroupServiceWrapper>.Instance.method_6(new OnKickPlayerFromGroup(this.OnKickPlayerFromGroup), int_0);
	}

	// Token: 0x06002A0C RID: 10764 RVA: 0x0001BA0C File Offset: 0x00019C0C
	public void method_25(object object_0)
	{
		if (this.m_bInGroup)
		{
			ServiceWrapperBase<GroupServiceWrapper>.Instance.method_7(new OnLeaveGroup(this.OnLeaveGroup));
		}
	}

	// Token: 0x06002A0D RID: 10765 RVA: 0x000C5B24 File Offset: 0x000C3D24
	public void method_26()
	{
		if (this.m_bFirstLogin && this.m_bInGroup)
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDWarningView>().vmethod_7(LocalizedString.smethod_0(new LocalizedString("Group_Crash_Back")), new Delegate_EventProc(this.method_28), new Delegate_EventProc(this.method_27));
		}
		this.m_bFirstLogin = false;
	}

	// Token: 0x06002A0E RID: 10766 RVA: 0x0001BA0C File Offset: 0x00019C0C
	public void method_27()
	{
		if (this.m_bInGroup)
		{
			ServiceWrapperBase<GroupServiceWrapper>.Instance.method_7(new OnLeaveGroup(this.OnLeaveGroup));
		}
	}

	// Token: 0x06002A0F RID: 10767 RVA: 0x0001BA2C File Offset: 0x00019C2C
	protected void method_28()
	{
		if (this.m_bInGroup)
		{
			ServiceWrapperBase<GroupServiceWrapper>.Instance.method_9(new OnGotMyGroupInfo(this.method_29));
		}
	}

	// Token: 0x06002A10 RID: 10768 RVA: 0x000C5B84 File Offset: 0x000C3D84
	private void method_29(int int_0, List<Presence> list_0)
	{
		this.m_GroupInfoMap.Clear();
		if (int_0 == -1)
		{
			this.m_bInGroup = false;
			this.m_nGroupId = -1;
		}
		else
		{
			this.method_32(list_0);
			if (this.m_cbOnGetGroupInfo != null)
			{
				this.m_cbOnGetGroupInfo(int_0, list_0);
			}
		}
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InstanceSelectView>().vmethod_25();
	}

	// Token: 0x06002A11 RID: 10769 RVA: 0x0001BA4C File Offset: 0x00019C4C
	public void OnGroupMatchmakingStarted()
	{
		if (!this.method_19())
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<MatchMakingView>().Boolean_1 = true;
		}
	}

	// Token: 0x06002A12 RID: 10770 RVA: 0x0001BA6B File Offset: 0x00019C6B
	public void method_30(GroupManager.DeleOnGetGroupInfo deleOnGetGroupInfo_0)
	{
		this.m_cbOnGetGroupInfo = (GroupManager.DeleOnGetGroupInfo)Delegate.Combine(this.m_cbOnGetGroupInfo, deleOnGetGroupInfo_0);
	}

	// Token: 0x06002A13 RID: 10771 RVA: 0x0001BA84 File Offset: 0x00019C84
	public void method_31(GroupManager.DeleOnGetGroupInfo deleOnGetGroupInfo_0)
	{
		this.m_cbOnGetGroupInfo = (GroupManager.DeleOnGetGroupInfo)Delegate.Remove(this.m_cbOnGetGroupInfo, deleOnGetGroupInfo_0);
	}

	// Token: 0x06002A14 RID: 10772 RVA: 0x000C5BE0 File Offset: 0x000C3DE0
	private void method_32(List<Presence> list_0)
	{
		this.m_GroupInfoMap.Clear();
		for (int i = 0; i < list_0.Count; i++)
		{
			if (i == 0)
			{
				this.m_GroupInfoMap.Add(list_0[i].mCharacterId, list_0[i]);
				this.OnNewGroupLeader(list_0[i].mCharacterId);
			}
			else
			{
				this.OnNewGroupMember(list_0[i]);
			}
		}
	}

	// Token: 0x06002A15 RID: 10773 RVA: 0x0001BA9D File Offset: 0x00019C9D
	public int method_33(int int_0)
	{
		if (this.m_GroupInfoMap.ContainsKey(int_0))
		{
			return this.m_GroupInfoMap[int_0].mCharacterLevel;
		}
		return 0;
	}

	// Token: 0x06002A16 RID: 10774 RVA: 0x000C5C4C File Offset: 0x000C3E4C
	public Presence[] method_34()
	{
		List<Presence> list = new List<Presence>();
		if (this.m_GroupInfoMap.ContainsKey(this.m_nLeaderId) && !this.method_19())
		{
			list.Add(this.m_GroupInfoMap[this.m_nLeaderId]);
		}
		for (int i = 0; i < this.m_GroupInfoMap.Count; i++)
		{
			if (this.m_GroupInfoMap.ElementAt<KeyValuePair<int, Presence>>(i).Key != this.m_nLeaderId && this.m_GroupInfoMap.ElementAt<KeyValuePair<int, Presence>>(i).Key != OnlineService.s_characterId)
			{
				list.Add(this.m_GroupInfoMap.ElementAt<KeyValuePair<int, Presence>>(i).Value);
			}
		}
		return list.ToArray();
	}

	// Token: 0x04001DDC RID: 7644
	protected static GroupManager _GroupInstance;

	// Token: 0x04001DDD RID: 7645
	private Dictionary<int, GroupManager.GroupInviteData> m_InviteDataMap;

	// Token: 0x04001DDE RID: 7646
	private Dictionary<int, int> m_InviteMessageMap;

	// Token: 0x04001DDF RID: 7647
	public Dictionary<int, Presence> m_GroupInfoMap;

	// Token: 0x04001DE0 RID: 7648
	public int m_nLeaderId;

	// Token: 0x04001DE1 RID: 7649
	public bool m_bInGroup;

	// Token: 0x04001DE2 RID: 7650
	public int m_nAcceptId;

	// Token: 0x04001DE3 RID: 7651
	public int m_nGroupId = -1;

	// Token: 0x04001DE4 RID: 7652
	protected GroupManager.DeleOnGetGroupInfo m_cbOnGetGroupInfo;

	// Token: 0x04001DE5 RID: 7653
	private bool m_bFirstLogin = true;

	// Token: 0x04001DE6 RID: 7654
	private int m_TargetCharacterId = -1;

	// Token: 0x02000676 RID: 1654
	public enum InviteMessageStatus
	{
		// Token: 0x04001DE8 RID: 7656
		e_None,
		// Token: 0x04001DE9 RID: 7657
		e_WaitingForDecide,
		// Token: 0x04001DEA RID: 7658
		e_Decided,
		// Token: 0x04001DEB RID: 7659
		e_Locked,
		// Token: 0x04001DEC RID: 7660
		e_JoinFailed,
		// Token: 0x04001DED RID: 7661
		e_Accepted,
		// Token: 0x04001DEE RID: 7662
		e_Rejected
	}

	// Token: 0x02000677 RID: 1655
	private class GroupInviteData
	{
		// Token: 0x06002A17 RID: 10775 RVA: 0x0001BAC0 File Offset: 0x00019CC0
		public GroupInviteData()
		{
			this.InviterInfo = new PlayerProperties();
			this.InviteStatus = GroupManager.InviteMessageStatus.e_WaitingForDecide;
		}

		// Token: 0x04001DEF RID: 7663
		public int m_nMessageId;

		// Token: 0x04001DF0 RID: 7664
		public PlayerProperties InviterInfo;

		// Token: 0x04001DF1 RID: 7665
		public GroupManager.InviteMessageStatus InviteStatus;
	}

	// Token: 0x02000678 RID: 1656
	// (Invoke) Token: 0x06002A19 RID: 10777
	public delegate void DeleOnGetGroupInfo(int groupId, List<Presence> members);
}
