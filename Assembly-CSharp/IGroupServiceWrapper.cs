using System;

// Token: 0x020002DB RID: 731
public interface IGroupServiceWrapper : IServiceWrapper
{
	// Token: 0x0600104A RID: 4170
	void imethod_2(OnGotMyGroupInfo onGotMyGroupInfo_0);

	// Token: 0x0600104B RID: 4171
	void imethod_3(OnSendGroupInvitation onSendGroupInvitation_0, int int_0);

	// Token: 0x0600104C RID: 4172
	void imethod_4();

	// Token: 0x0600104D RID: 4173
	void imethod_5(OnGroupInviteAccepted onGroupInviteAccepted_0, int int_0);

	// Token: 0x0600104E RID: 4174
	void imethod_6(int int_0);

	// Token: 0x0600104F RID: 4175
	void imethod_7(OnKickPlayerFromGroup onKickPlayerFromGroup_0, int int_0);

	// Token: 0x06001050 RID: 4176
	void imethod_8(OnLeaveGroup onLeaveGroup_0);

	// Token: 0x06001051 RID: 4177
	void imethod_9(OnGotMyGroupInfo onGotMyGroupInfo_0);
}
