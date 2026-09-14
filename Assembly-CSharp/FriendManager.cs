using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using ns0;

// Token: 0x0200066D RID: 1645
public class FriendManager : IFriendServiceNotificationListerner
{
	// Token: 0x0600296A RID: 10602 RVA: 0x000C3064 File Offset: 0x000C1264
	private FriendManager()
	{
		if (this.m_FriendMap == null)
		{
			this.m_FriendMap = new Dictionary<int, PlayerProperties>();
			this.m_FriendMap.Clear();
		}
		if (this.m_FriendInvitationMap == null)
		{
			this.m_FriendInvitationMap = new Dictionary<int, int>();
			this.m_FriendInvitationMap.Clear();
		}
		if (this.m_FriendInvitationInfoMap == null)
		{
			this.m_FriendInvitationInfoMap = new Dictionary<int, PlayerProperties>();
			this.m_FriendInvitationInfoMap.Clear();
		}
		if (this.m_FriendPresenceMap == null)
		{
			this.m_FriendPresenceMap = new Dictionary<int, Presence>();
			this.m_FriendPresenceMap.Clear();
		}
		if (this.m_SearchResultMap == null)
		{
			this.m_SearchResultMap = new Dictionary<int, Presence>();
			this.m_SearchResultMap.Clear();
		}
		if (this.m_FriendIds == null)
		{
			this.m_FriendIds = new List<int>();
			this.m_FriendIds.Clear();
		}
		ServiceWrapperBase<FriendServiceWrapper>.Instance.method_11(this);
		OnAccessSingleton<IPresenceService, PresenceService, PresenceServiceOffline>.Prop_0.imethod_4(new OnPresenceUpdated(this.OnPresenceUpdated));
	}

	// Token: 0x0600296B RID: 10603 RVA: 0x000C315C File Offset: 0x000C135C
	void IFriendServiceNotificationListerner.OnFriendRequestReceived(FriendRequest friendRequest)
	{
		DebugUtils.Log(LogCategory.GUI, MonoSingleton<Session>.Instance.GetLocalPlayer().m_name + " Received friend request from " + friendRequest.mSender);
		if (this.m_FriendInvitationMap.ContainsKey(friendRequest.mSender))
		{
			this.m_FriendInvitationMap[friendRequest.mSender] = friendRequest.mMessageId;
		}
		else
		{
			this.m_FriendInvitationMap.Add(friendRequest.mSender, friendRequest.mMessageId);
		}
		OnAccessSingleton<IPresenceService, PresenceService, PresenceServiceOffline>.Prop_0.imethod_0(friendRequest.mSender, new OnGetPresence(this.method_6));
	}

	// Token: 0x0600296C RID: 10604 RVA: 0x0001B2B4 File Offset: 0x000194B4
	void IFriendServiceNotificationListerner.OnRejectFriend(int characterId, string characterName)
	{
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<ChatView>().method_8(ChatParameter.System, string.Empty, Utility.smethod_5(characterName, LocalizedString.smethod_0(new LocalizedString("FRIEND_REFUSE"))), 0, string.Empty);
	}

	// Token: 0x0600296D RID: 10605 RVA: 0x000C31FC File Offset: 0x000C13FC
	void IFriendServiceNotificationListerner.OnNewFriend(Presence friendInfo)
	{
		if (friendInfo != null && !this.m_FriendPresenceMap.ContainsKey(friendInfo.mCharacterId))
		{
			if (!this.m_FriendIds.Contains(friendInfo.mCharacterId))
			{
				this.m_FriendIds.Add(friendInfo.mCharacterId);
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<ChatView>().method_8(ChatParameter.System, string.Empty, Utility.smethod_5(friendInfo.mCharacterName, LocalizedString.smethod_0(new LocalizedString("FRIEND_SUCCESS"))), 0, string.Empty);
			}
			this.m_FriendPresenceMap.Add(friendInfo.mCharacterId, friendInfo);
			this.method_4();
		}
	}

	// Token: 0x0600296E RID: 10606 RVA: 0x000C3298 File Offset: 0x000C1498
	void IFriendServiceNotificationListerner.OnUnfriended(int friendCharacterId)
	{
		if (this.m_FriendPresenceMap.ContainsKey(friendCharacterId))
		{
			this.m_FriendPresenceMap.Remove(friendCharacterId);
		}
		if (this.m_FriendIds.Contains(friendCharacterId))
		{
			this.m_FriendIds.Remove(friendCharacterId);
		}
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<FriendView>().vmethod_5(false);
	}

	// Token: 0x0600296F RID: 10607 RVA: 0x0001B2EB File Offset: 0x000194EB
	public static FriendManager smethod_0()
	{
		if (FriendManager._FriendInstance == null)
		{
			FriendManager._FriendInstance = new FriendManager();
		}
		return FriendManager._FriendInstance;
	}

	// Token: 0x06002970 RID: 10608 RVA: 0x000C32F0 File Offset: 0x000C14F0
	public void method_0()
	{
		this.m_FriendMap.Clear();
		this.m_FriendInvitationMap.Clear();
		this.m_FriendInvitationInfoMap.Clear();
		PlayerProperties playerProperties = new PlayerProperties();
		playerProperties.m_id = 4;
		playerProperties.m_level = 11;
		playerProperties.m_name = "hehe";
		PlayerProperties playerProperties2 = new PlayerProperties();
		playerProperties2.m_id = 5;
		playerProperties2.m_level = 13;
		playerProperties2.m_name = "heheaaa";
		PlayerProperties playerProperties3 = new PlayerProperties();
		playerProperties3.m_id = 6;
		playerProperties3.m_level = 16;
		playerProperties3.m_name = "absd";
		this.m_FriendMap.Add(4, playerProperties);
		this.m_FriendInvitationMap.Add(4, 100);
		this.m_FriendInvitationInfoMap.Add(4, playerProperties);
		this.m_FriendInvitationMap.Add(5, 101);
		this.m_FriendInvitationInfoMap.Add(5, playerProperties2);
		this.m_FriendInvitationMap.Add(6, 102);
		this.m_FriendInvitationInfoMap.Add(6, playerProperties3);
	}

	// Token: 0x06002971 RID: 10609 RVA: 0x0001B303 File Offset: 0x00019503
	public void method_1(int int_0)
	{
		this.m_TargetCharacterId = int_0;
	}

	// Token: 0x06002972 RID: 10610 RVA: 0x000C33DC File Offset: 0x000C15DC
	protected void OnGetFriendsPresence(Presence[] presence)
	{
		this.m_FriendIds.Clear();
		this.m_FriendPresenceMap.Clear();
		if (presence != null)
		{
			for (int i = 0; i < presence.Count<Presence>(); i++)
			{
				this.m_FriendIds.Add(presence[i].mCharacterId);
				this.m_FriendPresenceMap.Add(presence[i].mCharacterId, presence[i]);
			}
		}
		this.method_4();
	}

	// Token: 0x06002973 RID: 10611 RVA: 0x000C3444 File Offset: 0x000C1644
	public Presence method_2(int int_0)
	{
		int num = this.m_FriendIds[int_0];
		if (this.m_FriendPresenceMap.ContainsKey(num))
		{
			return this.m_FriendPresenceMap[num];
		}
		return null;
	}

	// Token: 0x06002974 RID: 10612 RVA: 0x0001B30C File Offset: 0x0001950C
	public Presence method_3(int int_0)
	{
		if (this.m_FriendPresenceMap.ContainsKey(int_0))
		{
			return this.m_FriendPresenceMap[int_0];
		}
		return null;
	}

	// Token: 0x06002975 RID: 10613 RVA: 0x000C347C File Offset: 0x000C167C
	protected void OnPresenceUpdated(Presence presence)
	{
		if (presence == null)
		{
			return;
		}
		if (this.m_FriendPresenceMap.ContainsKey(presence.mCharacterId))
		{
			this.m_FriendPresenceMap[presence.mCharacterId].mCharacterLevel = presence.mCharacterLevel;
			this.m_FriendPresenceMap[presence.mCharacterId].mIsOnline = presence.mIsOnline;
			this.m_FriendPresenceMap[presence.mCharacterId].mLastOnline = presence.mLastOnline;
			this.m_FriendPresenceMap[presence.mCharacterId].mCurrentTown = presence.mCurrentTown;
			this.m_FriendPresenceMap[presence.mCharacterId].mMatchCount = presence.mMatchCount;
			this.m_FriendPresenceMap[presence.mCharacterId].mHonorPoint = presence.mHonorPoint;
			this.m_FriendPresenceMap[presence.mCharacterId].mKillCount = presence.mKillCount;
			this.m_FriendPresenceMap[presence.mCharacterId].mDeathCount = presence.mDeathCount;
			this.m_FriendPresenceMap[presence.mCharacterId].mWinCount = presence.mWinCount;
			this.m_FriendPresenceMap[presence.mCharacterId].mLossCount = presence.mLossCount;
			this.m_FriendPresenceMap[presence.mCharacterId].mCurrentPlaylist = presence.mCurrentPlaylist;
			this.method_4();
			if (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<FriendView>().Boolean_0)
			{
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<FriendView>().vmethod_5(false);
			}
		}
	}

	// Token: 0x06002976 RID: 10614 RVA: 0x0001B32A File Offset: 0x0001952A
	protected void OnGetMyFriendsList(int[] characterIds)
	{
		ServiceWrapperBase<FriendServiceWrapper>.Instance.method_9(new OnGetFriendsCharacterInfo(this.OnGetFriendsCharacterInfo));
	}

	// Token: 0x06002977 RID: 10615 RVA: 0x000C3608 File Offset: 0x000C1808
	protected void OnGetFriendsCharacterInfo(List<PlayerProperties> characterInfos)
	{
		this.m_FriendMap.Clear();
		for (int i = 0; i < characterInfos.Count<PlayerProperties>(); i++)
		{
			this.m_FriendMap.Add(characterInfos[i].m_id, characterInfos[i]);
		}
		this.method_4();
	}

	// Token: 0x06002978 RID: 10616 RVA: 0x000C3658 File Offset: 0x000C1858
	private void method_4()
	{
		if (this.m_FriendPresenceMap.Count <= 1)
		{
			if (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<FriendView>().Boolean_0)
			{
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<FriendView>().vmethod_5(false);
			}
			return;
		}
		this.m_FriendIds.Sort(new Comparison<int>(this.method_5));
		if (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<FriendView>().Boolean_0)
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<FriendView>().vmethod_5(false);
		}
	}

	// Token: 0x06002979 RID: 10617 RVA: 0x000C36E4 File Offset: 0x000C18E4
	private int method_5(int int_0, int int_1)
	{
		if (!this.m_FriendPresenceMap[int_0].mIsOnline && this.m_FriendPresenceMap[int_1].mIsOnline)
		{
			return 1;
		}
		if (this.m_FriendPresenceMap[int_0].mIsOnline && !this.m_FriendPresenceMap[int_1].mIsOnline)
		{
			return -1;
		}
		return string.Compare(this.m_FriendPresenceMap[int_0].mCharacterName, this.m_FriendPresenceMap[int_1].mCharacterName);
	}

	// Token: 0x0600297A RID: 10618 RVA: 0x000C3768 File Offset: 0x000C1968
	public void method_6(Presence presence_0)
	{
		DebugUtils.Log(LogCategory.GUI, string.Concat(new object[]
		{
			MonoSingleton<Session>.Instance.GetLocalPlayer().m_name,
			" get inviter info ",
			presence_0.mCharacterId,
			" name:",
			presence_0.mCharacterName
		}));
		if (!this.m_FriendInvitationInfoMap.ContainsKey(presence_0.mCharacterId))
		{
			PlayerProperties playerProperties = new PlayerProperties();
			playerProperties.m_avatarDna = presence_0.mAvatarDNA;
			playerProperties.m_exp = presence_0.mCharacterExperience;
			playerProperties.m_id = presence_0.mCharacterId;
			playerProperties.m_level = presence_0.mCharacterLevel;
			playerProperties.m_name = presence_0.mCharacterName;
			this.m_FriendInvitationInfoMap.Add(presence_0.mCharacterId, playerProperties);
			if (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InstanceSelectView>().Boolean_0)
			{
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InstanceSelectView>().vmethod_13();
			}
			else
			{
				this.m_bNewMessageUnread = true;
			}
		}
		else
		{
			this.m_FriendInvitationInfoMap[presence_0.mCharacterId].m_level = presence_0.mCharacterLevel;
		}
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<FriendView>().vmethod_5(false);
	}

	// Token: 0x0600297B RID: 10619 RVA: 0x0001B342 File Offset: 0x00019542
	public bool method_7(int int_0)
	{
		return this.m_FriendInvitationInfoMap.ContainsKey(int_0);
	}

	// Token: 0x0600297C RID: 10620 RVA: 0x0001B350 File Offset: 0x00019550
	public int method_8()
	{
		return this.m_FriendInvitationInfoMap.Count<KeyValuePair<int, PlayerProperties>>();
	}

	// Token: 0x0600297D RID: 10621 RVA: 0x000C3890 File Offset: 0x000C1A90
	public PlayerProperties method_9(int int_0)
	{
		if (int_0 >= 0 && int_0 < this.m_FriendInvitationInfoMap.Count<KeyValuePair<int, PlayerProperties>>())
		{
			return this.m_FriendInvitationInfoMap.ElementAt<KeyValuePair<int, PlayerProperties>>(int_0).Value;
		}
		return null;
	}

	// Token: 0x0600297E RID: 10622 RVA: 0x000C38C8 File Offset: 0x000C1AC8
	public int method_10()
	{
		int num = 0;
		for (int i = 0; i < this.m_FriendPresenceMap.Count<KeyValuePair<int, Presence>>(); i++)
		{
			if (this.m_FriendPresenceMap.ElementAt<KeyValuePair<int, Presence>>(i).Value.mIsOnline)
			{
				num++;
			}
		}
		return num;
	}

	// Token: 0x0600297F RID: 10623 RVA: 0x0001B35D File Offset: 0x0001955D
	public void method_11()
	{
		ServiceWrapperBase<FriendServiceWrapper>.Instance.method_10(new OnGetMyPendingFriendRequests(this.OnGetMyPendingFriendRequests));
	}

	// Token: 0x06002980 RID: 10624 RVA: 0x000C3910 File Offset: 0x000C1B10
	protected void OnGetMyPendingFriendRequests(FriendRequest[] pendingFriendRequests)
	{
		this.m_FriendInvitationInfoMap.Clear();
		for (int i = 0; i < pendingFriendRequests.Count<FriendRequest>(); i++)
		{
			if (this.m_FriendInvitationMap.ContainsKey(pendingFriendRequests[i].mSender))
			{
				this.m_FriendInvitationMap[pendingFriendRequests[i].mSender] = pendingFriendRequests[i].mMessageId;
			}
			else
			{
				this.m_FriendInvitationMap.Add(pendingFriendRequests[i].mSender, pendingFriendRequests[i].mMessageId);
			}
		}
	}

	// Token: 0x06002981 RID: 10625 RVA: 0x0001B375 File Offset: 0x00019575
	public void method_12()
	{
		OnAccessSingleton<IPresenceService, PresenceService, PresenceServiceOffline>.Prop_0.imethod_2(new OnGetFriendsPresence(this.OnGetFriendsPresence));
	}

	// Token: 0x06002982 RID: 10626 RVA: 0x0001B38D File Offset: 0x0001958D
	public bool method_13()
	{
		return this.method_17() < this.m_MaxFriendNumber;
	}

	// Token: 0x06002983 RID: 10627 RVA: 0x000C399C File Offset: 0x000C1B9C
	public void method_14(object object_0)
	{
		if (this.method_17() >= this.m_MaxFriendNumber)
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDWarningView>().vmethod_7(LocalizedString.smethod_0(new LocalizedString("Friend_Max")), new Delegate_EventProc(this.method_27), null);
		}
		else
		{
			ServiceWrapperBase<FriendServiceWrapper>.Instance.method_1(this.m_TargetCharacterId);
		}
	}

	// Token: 0x06002984 RID: 10628 RVA: 0x000C39FC File Offset: 0x000C1BFC
	public void method_15(int int_0)
	{
		if (int_0 != -1 && this.m_FriendInvitationMap.ContainsKey(int_0))
		{
			ServiceWrapperBase<FriendServiceWrapper>.Instance.method_2(this.m_FriendInvitationMap[int_0]);
			this.m_FriendInvitationMap.Remove(int_0);
			this.m_FriendInvitationInfoMap.Remove(int_0);
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<FriendView>().vmethod_5(false);
		}
	}

	// Token: 0x06002985 RID: 10629 RVA: 0x000C3A60 File Offset: 0x000C1C60
	public void method_16(int int_0)
	{
		if (int_0 != -1 && this.m_FriendInvitationInfoMap.ContainsKey(int_0))
		{
			ServiceWrapperBase<FriendServiceWrapper>.Instance.method_3(this.m_FriendInvitationMap[int_0]);
			this.m_FriendInvitationMap.Remove(int_0);
			this.m_FriendInvitationInfoMap.Remove(int_0);
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<FriendView>().vmethod_5(false);
		}
	}

	// Token: 0x06002986 RID: 10630 RVA: 0x0001B3A0 File Offset: 0x000195A0
	public int method_17()
	{
		return this.m_FriendIds.Count<int>();
	}

	// Token: 0x06002987 RID: 10631 RVA: 0x0001B3AD File Offset: 0x000195AD
	public int method_18(int int_0)
	{
		if (int_0 >= 0 && int_0 < this.m_FriendIds.Count<int>())
		{
			return this.m_FriendIds[int_0];
		}
		return -1;
	}

	// Token: 0x06002988 RID: 10632 RVA: 0x000C3AC4 File Offset: 0x000C1CC4
	public void method_19(int int_0)
	{
		if (int_0 == -1)
		{
			return;
		}
		Presence presence = this.method_3(int_0);
		MenuItemDef[] array = new MenuItemDef[4];
		array[0].itemTitle = LocalizedString.smethod_0(new LocalizedString("Group_Invitation"));
		array[0].itemData = int_0;
		if (GroupManager.smethod_0().method_18() && (!GroupManager.smethod_0().method_19() || GroupManager.smethod_0().method_17(int_0)))
		{
			array[0].itemFunc = null;
		}
		else if (presence != null)
		{
			if (presence.mIsOnline)
			{
				array[0].itemFunc = new MenuItemProcessFunc(this.method_20);
			}
			else
			{
				array[0].itemFunc = null;
			}
		}
		else
		{
			array[0].itemFunc = null;
		}
		array[1].itemTitle = LocalizedString.smethod_0(new LocalizedString("Friend_Delete"));
		array[1].itemData = int_0;
		array[1].itemFunc = new MenuItemProcessFunc(this.method_21);
		array[2].itemTitle = LocalizedString.smethod_0(new LocalizedString("GUILD_INVITATION"));
		array[2].itemData = int_0;
		if (!GuildManager.smethod_0().method_8() && !GuildManager.smethod_0().method_82())
		{
			array[2].itemFunc = null;
		}
		else if (presence != null)
		{
			if (presence.mIsOnline)
			{
				array[2].itemFunc = new MenuItemProcessFunc(GuildManager.smethod_0().method_31);
			}
			else
			{
				array[2].itemFunc = null;
			}
		}
		else
		{
			array[2].itemFunc = null;
		}
		array[3].itemTitle = LocalizedString.smethod_0(new LocalizedString("Chat_Send"));
		if (presence != null)
		{
			array[3].itemData = presence.mCharacterName;
			if (presence.mIsOnline)
			{
				array[3].itemFunc = new MenuItemProcessFunc(MonoSingleton<AppManager>.Instance.method_0().vmethod_5<ChatView>().method_3);
			}
			else
			{
				array[3].itemFunc = null;
			}
		}
		else
		{
			array[3].itemFunc = null;
		}
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<PopupMenuView>().method_3(array);
	}

	// Token: 0x06002989 RID: 10633 RVA: 0x0001B3CF File Offset: 0x000195CF
	protected void method_20(object object_0)
	{
		if (!GroupManager.smethod_0().method_17((int)object_0))
		{
			GroupManager.smethod_0().method_0((int)object_0);
			GroupManager.smethod_0().method_14(object_0);
		}
	}

	// Token: 0x0600298A RID: 10634 RVA: 0x000C3CF8 File Offset: 0x000C1EF8
	protected void method_21(object object_0)
	{
		if (this.method_26((int)object_0))
		{
			ServiceWrapperBase<FriendServiceWrapper>.Instance.method_4((int)object_0);
			this.m_FriendIds.Remove((int)object_0);
			this.m_FriendPresenceMap.Remove((int)object_0);
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<FriendView>().vmethod_5(false);
		}
	}

	// Token: 0x0600298B RID: 10635 RVA: 0x0001B3FE File Offset: 0x000195FE
	public void method_22(string string_0)
	{
		OnAccessSingleton<IPresenceService, PresenceService, PresenceServiceOffline>.Prop_0.imethod_3(new OnSearchForCharacter(this.OnGetSearchResult), string_0);
	}

	// Token: 0x0600298C RID: 10636 RVA: 0x000C3D5C File Offset: 0x000C1F5C
	private void OnGetSearchResult(Presence presence)
	{
		this.m_SearchResultMap.Clear();
		if (presence != null)
		{
			this.m_SearchResultMap.Add(presence.mCharacterId, presence);
		}
		else
		{
			MonoSingleton<global::ns0.EchoMessageManager>.Instance.method_8("81015");
		}
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<FriendView>().vmethod_5(false);
	}

	// Token: 0x0600298D RID: 10637 RVA: 0x000C3DB0 File Offset: 0x000C1FB0
	public Presence method_23(int int_0)
	{
		if (int_0 >= 0 && int_0 < this.m_SearchResultMap.Count<KeyValuePair<int, Presence>>())
		{
			return this.m_SearchResultMap.ElementAt<KeyValuePair<int, Presence>>(int_0).Value;
		}
		return null;
	}

	// Token: 0x0600298E RID: 10638 RVA: 0x0001B417 File Offset: 0x00019617
	public int method_24()
	{
		return this.m_SearchResultMap.Count<KeyValuePair<int, Presence>>();
	}

	// Token: 0x0600298F RID: 10639 RVA: 0x0001B424 File Offset: 0x00019624
	public void method_25()
	{
		this.m_SearchResultMap.Clear();
	}

	// Token: 0x06002990 RID: 10640 RVA: 0x0001B431 File Offset: 0x00019631
	public bool method_26(int int_0)
	{
		return this.m_FriendPresenceMap.ContainsKey(int_0);
	}

	// Token: 0x06002991 RID: 10641 RVA: 0x0001B43F File Offset: 0x0001963F
	protected void method_27()
	{
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDWarningView>().vmethod_8(true);
	}

	// Token: 0x04001DAD RID: 7597
	protected static FriendManager _FriendInstance;

	// Token: 0x04001DAE RID: 7598
	private Dictionary<int, PlayerProperties> m_FriendMap;

	// Token: 0x04001DAF RID: 7599
	private Dictionary<int, int> m_FriendInvitationMap;

	// Token: 0x04001DB0 RID: 7600
	private Dictionary<int, PlayerProperties> m_FriendInvitationInfoMap;

	// Token: 0x04001DB1 RID: 7601
	private Dictionary<int, Presence> m_FriendPresenceMap;

	// Token: 0x04001DB2 RID: 7602
	private Dictionary<int, Presence> m_SearchResultMap;

	// Token: 0x04001DB3 RID: 7603
	private List<int> m_FriendIds;

	// Token: 0x04001DB4 RID: 7604
	public bool m_bNewMessageUnread;

	// Token: 0x04001DB5 RID: 7605
	private int m_TargetCharacterId = -1;

	// Token: 0x04001DB6 RID: 7606
	private int m_MaxFriendNumber = 30;
}
