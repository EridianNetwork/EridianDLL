using System;
using System.Collections.Generic;
using ns0;

// Token: 0x020002DE RID: 734
public class GroupServiceWrapperOnline : IGroupServiceWrapper, IServiceWrapper
{
	// Token: 0x0600106F RID: 4207 RVA: 0x00075E74 File Offset: 0x00074074
	public void imethod_0()
	{
		if (!this.m_isInitializing && !this.m_initialized)
		{
			this.m_isInitializing = true;
			OnAccessSingleton<IGroupService, GroupService, GroupServiceOffline>.Prop_0.imethod_0(new OnGotMyGroupInfo(this.OnGotMyGroupInfo));
			OnAccessSingleton<IGroupService, GroupService, GroupServiceOffline>.Prop_0.imethod_8(new OnReceivedGroupInvitation(ServiceWrapperBase<GroupServiceWrapper>.Instance.OnReceivedGroupInvitation));
			OnAccessSingleton<IGroupService, GroupService, GroupServiceOffline>.Prop_0.imethod_10(new OnKickedFromGroup(ServiceWrapperBase<GroupServiceWrapper>.Instance.OnKickedFromGroup));
			OnAccessSingleton<IGroupService, GroupService, GroupServiceOffline>.Prop_0.imethod_12(new OnNewGroupLeader(ServiceWrapperBase<GroupServiceWrapper>.Instance.OnNewGroupLeader));
			OnAccessSingleton<IGroupService, GroupService, GroupServiceOffline>.Prop_0.imethod_14(new OnNewGroupMember(ServiceWrapperBase<GroupServiceWrapper>.Instance.OnNewGroupMember));
			OnAccessSingleton<IGroupService, GroupService, GroupServiceOffline>.Prop_0.imethod_16(new OnGroupInviteRejected(ServiceWrapperBase<GroupServiceWrapper>.Instance.OnGroupInviteRejected));
			OnAccessSingleton<IGroupService, GroupService, GroupServiceOffline>.Prop_0.imethod_18(new OnGroupMemberLeft(ServiceWrapperBase<GroupServiceWrapper>.Instance.OnGroupMemberLeft));
			OnAccessSingleton<IGroupService, GroupService, GroupServiceOffline>.Prop_0.imethod_20(new OnGroupDisbanded(ServiceWrapperBase<GroupServiceWrapper>.Instance.OnGroupDisbanded));
			OnAccessSingleton<IGroupService, GroupService, GroupServiceOffline>.Prop_0.imethod_22(new OnGroupMatchmakingStarted(ServiceWrapperBase<GroupServiceWrapper>.Instance.OnGroupMatchmakingStarted));
			GroupManager.smethod_0();
		}
	}

	// Token: 0x06001070 RID: 4208 RVA: 0x0000DDB3 File Offset: 0x0000BFB3
	private void OnGotMyGroupInfo(int groupId, List<Presence> members)
	{
		this.m_initialized = true;
	}

	// Token: 0x06001071 RID: 4209 RVA: 0x0000DDBC File Offset: 0x0000BFBC
	public bool imethod_1()
	{
		return this.m_initialized;
	}

	// Token: 0x06001072 RID: 4210 RVA: 0x0000DDC4 File Offset: 0x0000BFC4
	public void imethod_2(OnGotMyGroupInfo onGotMyGroupInfo_0)
	{
		OnAccessSingleton<IGroupService, GroupService, GroupServiceOffline>.Prop_0.imethod_0(onGotMyGroupInfo_0);
	}

	// Token: 0x06001073 RID: 4211 RVA: 0x0000DDD1 File Offset: 0x0000BFD1
	public void imethod_3(OnSendGroupInvitation onSendGroupInvitation_0, int int_0)
	{
		OnAccessSingleton<IGroupService, GroupService, GroupServiceOffline>.Prop_0.imethod_1(onSendGroupInvitation_0, int_0);
	}

	// Token: 0x06001074 RID: 4212 RVA: 0x0000DDDF File Offset: 0x0000BFDF
	public void imethod_5(OnGroupInviteAccepted onGroupInviteAccepted_0, int int_0)
	{
		OnAccessSingleton<IGroupService, GroupService, GroupServiceOffline>.Prop_0.imethod_3(onGroupInviteAccepted_0, int_0);
	}

	// Token: 0x06001075 RID: 4213 RVA: 0x0000DDED File Offset: 0x0000BFED
	public void imethod_6(int int_0)
	{
		OnAccessSingleton<IGroupService, GroupService, GroupServiceOffline>.Prop_0.imethod_4(int_0);
	}

	// Token: 0x06001076 RID: 4214 RVA: 0x0000DDFA File Offset: 0x0000BFFA
	public void imethod_7(OnKickPlayerFromGroup onKickPlayerFromGroup_0, int int_0)
	{
		OnAccessSingleton<IGroupService, GroupService, GroupServiceOffline>.Prop_0.imethod_5(onKickPlayerFromGroup_0, int_0);
	}

	// Token: 0x06001077 RID: 4215 RVA: 0x0000DE08 File Offset: 0x0000C008
	public void imethod_8(OnLeaveGroup onLeaveGroup_0)
	{
		OnAccessSingleton<IGroupService, GroupService, GroupServiceOffline>.Prop_0.imethod_6(onLeaveGroup_0);
	}

	// Token: 0x06001078 RID: 4216 RVA: 0x0000DE15 File Offset: 0x0000C015
	public void imethod_4()
	{
		OnAccessSingleton<IGroupService, GroupService, GroupServiceOffline>.Prop_0.imethod_2();
	}

	// Token: 0x06001079 RID: 4217 RVA: 0x0000DE21 File Offset: 0x0000C021
	public void imethod_9(OnGotMyGroupInfo onGotMyGroupInfo_0)
	{
		OnAccessSingleton<IGroupService, GroupService, GroupServiceOffline>.Prop_0.imethod_7(onGotMyGroupInfo_0);
	}

	// Token: 0x04000DCD RID: 3533
	private bool m_isInitializing;

	// Token: 0x04000DCE RID: 3534
	private bool m_initialized;
}
