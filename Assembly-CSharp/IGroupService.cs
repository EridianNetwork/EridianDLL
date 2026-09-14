using System;

// Token: 0x020002F1 RID: 753
public interface IGroupService
{
	// Token: 0x06001135 RID: 4405
	void imethod_0(OnGotMyGroupInfo onGotMyGroupInfo_0);

	// Token: 0x06001136 RID: 4406
	void imethod_1(OnSendGroupInvitation onSendGroupInvitation_0, int int_0);

	// Token: 0x06001137 RID: 4407
	void imethod_2();

	// Token: 0x06001138 RID: 4408
	void imethod_3(OnGroupInviteAccepted onGroupInviteAccepted_0, int int_0);

	// Token: 0x06001139 RID: 4409
	void imethod_4(int int_0);

	// Token: 0x0600113A RID: 4410
	void imethod_5(OnKickPlayerFromGroup onKickPlayerFromGroup_0, int int_0);

	// Token: 0x0600113B RID: 4411
	void imethod_6(OnLeaveGroup onLeaveGroup_0);

	// Token: 0x0600113C RID: 4412
	void imethod_7(OnGotMyGroupInfo onGotMyGroupInfo_0);

	// Token: 0x0600113D RID: 4413
	void imethod_8(OnReceivedGroupInvitation onReceivedGroupInvitation_0);

	// Token: 0x0600113E RID: 4414
	void imethod_9(OnReceivedGroupInvitation onReceivedGroupInvitation_0);

	// Token: 0x0600113F RID: 4415
	void imethod_10(OnKickedFromGroup onKickedFromGroup_0);

	// Token: 0x06001140 RID: 4416
	void imethod_11(OnKickedFromGroup onKickedFromGroup_0);

	// Token: 0x06001141 RID: 4417
	void imethod_12(OnNewGroupLeader onNewGroupLeader_0);

	// Token: 0x06001142 RID: 4418
	void imethod_13(OnNewGroupLeader onNewGroupLeader_0);

	// Token: 0x06001143 RID: 4419
	void imethod_14(OnNewGroupMember onNewGroupMember_0);

	// Token: 0x06001144 RID: 4420
	void imethod_15(OnNewGroupMember onNewGroupMember_0);

	// Token: 0x06001145 RID: 4421
	void imethod_16(OnGroupInviteRejected onGroupInviteRejected_0);

	// Token: 0x06001146 RID: 4422
	void imethod_17(OnGroupInviteRejected onGroupInviteRejected_0);

	// Token: 0x06001147 RID: 4423
	void imethod_18(OnGroupMemberLeft onGroupMemberLeft_0);

	// Token: 0x06001148 RID: 4424
	void imethod_19(OnGroupMemberLeft onGroupMemberLeft_0);

	// Token: 0x06001149 RID: 4425
	void imethod_20(OnGroupDisbanded onGroupDisbanded_0);

	// Token: 0x0600114A RID: 4426
	void imethod_21(OnGroupDisbanded onGroupDisbanded_0);

	// Token: 0x0600114B RID: 4427
	void imethod_22(OnGroupMatchmakingStarted onGroupMatchmakingStarted_0);

	// Token: 0x0600114C RID: 4428
	void imethod_23(OnGroupMatchmakingStarted onGroupMatchmakingStarted_0);
}
