using System;
using System.Collections.Generic;

// Token: 0x02000322 RID: 802
public class GroupServiceOffline : IGroupService
{
	// Token: 0x06001394 RID: 5012 RVA: 0x0000EFEA File Offset: 0x0000D1EA
	public void imethod_0(OnGotMyGroupInfo onGotMyGroupInfo_0)
	{
		if (onGotMyGroupInfo_0 != null)
		{
			onGotMyGroupInfo_0(-1, new List<Presence>());
		}
	}

	// Token: 0x06001395 RID: 5013 RVA: 0x0000EFFB File Offset: 0x0000D1FB
	public void imethod_1(OnSendGroupInvitation onSendGroupInvitation_0, int int_0)
	{
		if (onSendGroupInvitation_0 != null)
		{
			onSendGroupInvitation_0(-1);
		}
	}

	// Token: 0x06001396 RID: 5014 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_2()
	{
	}

	// Token: 0x06001397 RID: 5015 RVA: 0x0000F007 File Offset: 0x0000D207
	public void imethod_3(OnGroupInviteAccepted onGroupInviteAccepted_0, int int_0)
	{
		if (onGroupInviteAccepted_0 != null)
		{
			onGroupInviteAccepted_0(false, -1, -1, new List<Presence>());
		}
	}

	// Token: 0x06001398 RID: 5016 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_4(int int_0)
	{
	}

	// Token: 0x06001399 RID: 5017 RVA: 0x0000F01A File Offset: 0x0000D21A
	public void imethod_5(OnKickPlayerFromGroup onKickPlayerFromGroup_0, int int_0)
	{
		if (onKickPlayerFromGroup_0 != null)
		{
			onKickPlayerFromGroup_0(false, int_0);
		}
	}

	// Token: 0x0600139A RID: 5018 RVA: 0x0000F027 File Offset: 0x0000D227
	public void imethod_6(OnLeaveGroup onLeaveGroup_0)
	{
		if (onLeaveGroup_0 != null)
		{
			onLeaveGroup_0(false);
		}
	}

	// Token: 0x0600139B RID: 5019 RVA: 0x0000EFEA File Offset: 0x0000D1EA
	public void imethod_7(OnGotMyGroupInfo onGotMyGroupInfo_0)
	{
		if (onGotMyGroupInfo_0 != null)
		{
			onGotMyGroupInfo_0(-1, new List<Presence>());
		}
	}

	// Token: 0x0600139C RID: 5020 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_8(OnReceivedGroupInvitation onReceivedGroupInvitation_0)
	{
	}

	// Token: 0x0600139D RID: 5021 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_9(OnReceivedGroupInvitation onReceivedGroupInvitation_0)
	{
	}

	// Token: 0x0600139E RID: 5022 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_10(OnKickedFromGroup onKickedFromGroup_0)
	{
	}

	// Token: 0x0600139F RID: 5023 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_11(OnKickedFromGroup onKickedFromGroup_0)
	{
	}

	// Token: 0x060013A0 RID: 5024 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_12(OnNewGroupLeader onNewGroupLeader_0)
	{
	}

	// Token: 0x060013A1 RID: 5025 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_13(OnNewGroupLeader onNewGroupLeader_0)
	{
	}

	// Token: 0x060013A2 RID: 5026 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_14(OnNewGroupMember onNewGroupMember_0)
	{
	}

	// Token: 0x060013A3 RID: 5027 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_15(OnNewGroupMember onNewGroupMember_0)
	{
	}

	// Token: 0x060013A4 RID: 5028 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_16(OnGroupInviteRejected onGroupInviteRejected_0)
	{
	}

	// Token: 0x060013A5 RID: 5029 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_17(OnGroupInviteRejected onGroupInviteRejected_0)
	{
	}

	// Token: 0x060013A6 RID: 5030 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_18(OnGroupMemberLeft onGroupMemberLeft_0)
	{
	}

	// Token: 0x060013A7 RID: 5031 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_19(OnGroupMemberLeft onGroupMemberLeft_0)
	{
	}

	// Token: 0x060013A8 RID: 5032 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_20(OnGroupDisbanded onGroupDisbanded_0)
	{
	}

	// Token: 0x060013A9 RID: 5033 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_21(OnGroupDisbanded onGroupDisbanded_0)
	{
	}

	// Token: 0x060013AA RID: 5034 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_22(OnGroupMatchmakingStarted onGroupMatchmakingStarted_0)
	{
	}

	// Token: 0x060013AB RID: 5035 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_23(OnGroupMatchmakingStarted onGroupMatchmakingStarted_0)
	{
	}
}
