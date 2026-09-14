using System;
using System.Collections.Generic;

// Token: 0x020002D8 RID: 728
public class FriendServiceWrapper : ServiceWrapper<IFriendServiceWrapper, FriendServiceWrapper>
{
	// Token: 0x06001026 RID: 4134 RVA: 0x0000DB72 File Offset: 0x0000BD72
	public override void vmethod_1()
	{
		this.m_wrapperOnline = new FriendServiceWrapperOnline();
		base.vmethod_1();
	}

	// Token: 0x06001027 RID: 4135 RVA: 0x0000DB85 File Offset: 0x0000BD85
	public void method_0(OnGetMyFriendsList onGetMyFriendsList_0)
	{
		this.vmethod_0().imethod_2(onGetMyFriendsList_0);
	}

	// Token: 0x06001028 RID: 4136 RVA: 0x0000DB93 File Offset: 0x0000BD93
	public void method_1(int int_0)
	{
		this.vmethod_0().imethod_3(int_0);
	}

	// Token: 0x06001029 RID: 4137 RVA: 0x0000DBA1 File Offset: 0x0000BDA1
	public void method_2(int int_0)
	{
		this.vmethod_0().imethod_4(int_0);
	}

	// Token: 0x0600102A RID: 4138 RVA: 0x0000DBAF File Offset: 0x0000BDAF
	public void method_3(int int_0)
	{
		this.vmethod_0().imethod_5(int_0);
	}

	// Token: 0x0600102B RID: 4139 RVA: 0x0000DBBD File Offset: 0x0000BDBD
	public void method_4(int int_0)
	{
		this.vmethod_0().imethod_6(int_0);
	}

	// Token: 0x0600102C RID: 4140 RVA: 0x0000DBCB File Offset: 0x0000BDCB
	public void method_5(int int_0)
	{
		this.vmethod_0().imethod_7(int_0);
	}

	// Token: 0x0600102D RID: 4141 RVA: 0x0000DBD9 File Offset: 0x0000BDD9
	public void method_6(int int_0)
	{
		this.vmethod_0().imethod_8(int_0);
	}

	// Token: 0x0600102E RID: 4142 RVA: 0x0000DBE7 File Offset: 0x0000BDE7
	public void method_7(OnIsUserAFriend onIsUserAFriend_0, int int_0)
	{
		this.vmethod_0().imethod_9(onIsUserAFriend_0, int_0);
	}

	// Token: 0x0600102F RID: 4143 RVA: 0x0000DBF6 File Offset: 0x0000BDF6
	public void method_8(OnIsUserIgnored onIsUserIgnored_0, int int_0)
	{
		this.vmethod_0().imethod_10(onIsUserIgnored_0, int_0);
	}

	// Token: 0x06001030 RID: 4144 RVA: 0x0000DC05 File Offset: 0x0000BE05
	public void method_9(OnGetFriendsCharacterInfo onGetFriendsCharacterInfo_0)
	{
		this.vmethod_0().imethod_11(onGetFriendsCharacterInfo_0);
	}

	// Token: 0x06001031 RID: 4145 RVA: 0x0000DC13 File Offset: 0x0000BE13
	public void method_10(OnGetMyPendingFriendRequests onGetMyPendingFriendRequests_0)
	{
		this.vmethod_0().imethod_12(onGetMyPendingFriendRequests_0);
	}

	// Token: 0x06001032 RID: 4146 RVA: 0x0000DC21 File Offset: 0x0000BE21
	public void method_11(IFriendServiceNotificationListerner ifriendServiceNotificationListerner_0)
	{
		this.m_listerner.Add(ifriendServiceNotificationListerner_0);
	}

	// Token: 0x06001033 RID: 4147 RVA: 0x0000DC2F File Offset: 0x0000BE2F
	public void method_12(IFriendServiceNotificationListerner ifriendServiceNotificationListerner_0)
	{
		this.m_listerner.Remove(ifriendServiceNotificationListerner_0);
	}

	// Token: 0x06001034 RID: 4148 RVA: 0x00075A94 File Offset: 0x00073C94
	public void OnFriendRequestReceived(FriendRequest friendRequest)
	{
		for (int i = 0; i < this.m_listerner.Count; i++)
		{
			this.m_listerner[i].OnFriendRequestReceived(friendRequest);
		}
	}

	// Token: 0x06001035 RID: 4149 RVA: 0x00075ACC File Offset: 0x00073CCC
	public void OnNewFriend(Presence friendInfo)
	{
		for (int i = 0; i < this.m_listerner.Count; i++)
		{
			this.m_listerner[i].OnNewFriend(friendInfo);
		}
	}

	// Token: 0x06001036 RID: 4150 RVA: 0x00075B04 File Offset: 0x00073D04
	public void OnUnfriended(int friendCharacterId)
	{
		for (int i = 0; i < this.m_listerner.Count; i++)
		{
			this.m_listerner[i].OnUnfriended(friendCharacterId);
		}
	}

	// Token: 0x06001037 RID: 4151 RVA: 0x00075B3C File Offset: 0x00073D3C
	public void OnRejectFriend(int characterId, string characterName)
	{
		for (int i = 0; i < this.m_listerner.Count; i++)
		{
			this.m_listerner[i].OnRejectFriend(characterId, characterName);
		}
	}

	// Token: 0x04000DC5 RID: 3525
	protected List<IFriendServiceNotificationListerner> m_listerner = new List<IFriendServiceNotificationListerner>();
}
