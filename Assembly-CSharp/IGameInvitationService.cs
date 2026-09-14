using System;

// Token: 0x020002F0 RID: 752
internal interface IGameInvitationService
{
	// Token: 0x0600112D RID: 4397
	void imethod_0(GameInvitationCallback gameInvitationCallback_0);

	// Token: 0x0600112E RID: 4398
	void imethod_1(GameInvitationCallback gameInvitationCallback_0);

	// Token: 0x0600112F RID: 4399
	void imethod_2(string string_0);

	// Token: 0x06001130 RID: 4400
	void imethod_3(GameInvitation gameInvitation_0);

	// Token: 0x06001131 RID: 4401
	void imethod_4(GameInvitation gameInvitation_0);

	// Token: 0x06001132 RID: 4402
	bool imethod_5(string string_0);

	// Token: 0x06001133 RID: 4403
	void imethod_6(string string_0);

	// Token: 0x06001134 RID: 4404
	void OnIsFriendsGameJoinable(bool result);
}
