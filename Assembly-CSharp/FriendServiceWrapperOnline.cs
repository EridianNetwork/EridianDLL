using System;
using ns0;

// Token: 0x020002D9 RID: 729
public class FriendServiceWrapperOnline : IFriendServiceWrapper, IServiceWrapper
{
	// Token: 0x06001039 RID: 4153 RVA: 0x00075B74 File Offset: 0x00073D74
	public void imethod_0()
	{
		if (!this.m_isInitializing && !this.m_initialized)
		{
			this.m_isInitializing = true;
			OnAccessSingleton<IFriendsListsService, FriendsListsService, FriendsListsServiceOffline>.Prop_0.imethod_11(new OnFriendRequestReceived(ServiceWrapperBase<FriendServiceWrapper>.Instance.OnFriendRequestReceived));
			OnAccessSingleton<IFriendsListsService, FriendsListsService, FriendsListsServiceOffline>.Prop_0.imethod_13(new OnNewFriend(ServiceWrapperBase<FriendServiceWrapper>.Instance.OnNewFriend));
			OnAccessSingleton<IFriendsListsService, FriendsListsService, FriendsListsServiceOffline>.Prop_0.imethod_15(new OnUnfriended(ServiceWrapperBase<FriendServiceWrapper>.Instance.OnUnfriended));
			OnAccessSingleton<IFriendsListsService, FriendsListsService, FriendsListsServiceOffline>.Prop_0.imethod_0(new OnGetMyFriendsList(this.OnGetMyFriendsList));
			FriendManager.smethod_0();
		}
	}

	// Token: 0x0600103A RID: 4154 RVA: 0x0000DC3E File Offset: 0x0000BE3E
	public bool imethod_1()
	{
		return this.m_initialized;
	}

	// Token: 0x0600103B RID: 4155 RVA: 0x0000DC46 File Offset: 0x0000BE46
	private void OnGetMyFriendsList(int[] characterIds)
	{
		this.m_initialized = true;
	}

	// Token: 0x0600103C RID: 4156 RVA: 0x0000DC4F File Offset: 0x0000BE4F
	public void imethod_2(OnGetMyFriendsList onGetMyFriendsList_0)
	{
		OnAccessSingleton<IFriendsListsService, FriendsListsService, FriendsListsServiceOffline>.Prop_0.imethod_0(onGetMyFriendsList_0);
	}

	// Token: 0x0600103D RID: 4157 RVA: 0x0000DC5C File Offset: 0x0000BE5C
	public void imethod_3(int int_0)
	{
		OnAccessSingleton<IFriendsListsService, FriendsListsService, FriendsListsServiceOffline>.Prop_0.imethod_1(int_0);
	}

	// Token: 0x0600103E RID: 4158 RVA: 0x0000DC69 File Offset: 0x0000BE69
	public void imethod_4(int int_0)
	{
		OnAccessSingleton<IFriendsListsService, FriendsListsService, FriendsListsServiceOffline>.Prop_0.imethod_2(int_0);
	}

	// Token: 0x0600103F RID: 4159 RVA: 0x0000DC76 File Offset: 0x0000BE76
	public void imethod_5(int int_0)
	{
		OnAccessSingleton<IFriendsListsService, FriendsListsService, FriendsListsServiceOffline>.Prop_0.imethod_3(int_0);
	}

	// Token: 0x06001040 RID: 4160 RVA: 0x0000DC83 File Offset: 0x0000BE83
	public void imethod_6(int int_0)
	{
		OnAccessSingleton<IFriendsListsService, FriendsListsService, FriendsListsServiceOffline>.Prop_0.imethod_4(int_0);
	}

	// Token: 0x06001041 RID: 4161 RVA: 0x0000DC90 File Offset: 0x0000BE90
	public void imethod_7(int int_0)
	{
		OnAccessSingleton<IFriendsListsService, FriendsListsService, FriendsListsServiceOffline>.Prop_0.imethod_5(int_0);
	}

	// Token: 0x06001042 RID: 4162 RVA: 0x0000DC9D File Offset: 0x0000BE9D
	public void imethod_8(int int_0)
	{
		OnAccessSingleton<IFriendsListsService, FriendsListsService, FriendsListsServiceOffline>.Prop_0.imethod_6(int_0);
	}

	// Token: 0x06001043 RID: 4163 RVA: 0x0000DCAA File Offset: 0x0000BEAA
	public void imethod_9(OnIsUserAFriend onIsUserAFriend_0, int int_0)
	{
		OnAccessSingleton<IFriendsListsService, FriendsListsService, FriendsListsServiceOffline>.Prop_0.imethod_7(onIsUserAFriend_0, int_0);
	}

	// Token: 0x06001044 RID: 4164 RVA: 0x0000DCB8 File Offset: 0x0000BEB8
	public void imethod_10(OnIsUserIgnored onIsUserIgnored_0, int int_0)
	{
		OnAccessSingleton<IFriendsListsService, FriendsListsService, FriendsListsServiceOffline>.Prop_0.imethod_8(onIsUserIgnored_0, int_0);
	}

	// Token: 0x06001045 RID: 4165 RVA: 0x0000DCC6 File Offset: 0x0000BEC6
	public void imethod_11(OnGetFriendsCharacterInfo onGetFriendsCharacterInfo_0)
	{
		OnAccessSingleton<IFriendsListsService, FriendsListsService, FriendsListsServiceOffline>.Prop_0.imethod_9(onGetFriendsCharacterInfo_0);
	}

	// Token: 0x06001046 RID: 4166 RVA: 0x0000DCD3 File Offset: 0x0000BED3
	public void imethod_12(OnGetMyPendingFriendRequests onGetMyPendingFriendRequests_0)
	{
		OnAccessSingleton<IFriendsListsService, FriendsListsService, FriendsListsServiceOffline>.Prop_0.imethod_10(onGetMyPendingFriendRequests_0);
	}

	// Token: 0x04000DC6 RID: 3526
	private bool m_isInitializing;

	// Token: 0x04000DC7 RID: 3527
	private bool m_initialized;
}
