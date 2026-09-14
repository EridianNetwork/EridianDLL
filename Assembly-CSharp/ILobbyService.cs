using System;
using XsdSettings;

// Token: 0x020002F4 RID: 756
internal interface ILobbyService
{
	// Token: 0x06001181 RID: 4481
	void imethod_0(OnCreateLobby onCreateLobby_0, bool bool_0);

	// Token: 0x06001182 RID: 4482
	void imethod_1(OnOpenLobby onOpenLobby_0, GamemodeType gamemodeType_0, int int_0, ELevelDifficulty elevelDifficulty_0);

	// Token: 0x06001183 RID: 4483
	void imethod_2(OnInviteToLobby onInviteToLobby_0, int int_0);

	// Token: 0x06001184 RID: 4484
	void imethod_3(OnAcceptLobbyInvitation onAcceptLobbyInvitation_0, int int_0);

	// Token: 0x06001185 RID: 4485
	void imethod_4(OnRejectLobbyInvitation onRejectLobbyInvitation_0, int int_0);

	// Token: 0x06001186 RID: 4486
	void imethod_5(OnKickPlayerFromLobby onKickPlayerFromLobby_0, int int_0);

	// Token: 0x06001187 RID: 4487
	void imethod_6(OnLeaveLobby onLeaveLobby_0);

	// Token: 0x06001188 RID: 4488
	void imethod_7(OnStartLobbyGame onStartLobbyGame_0);

	// Token: 0x06001189 RID: 4489
	void imethod_8(OnGetLobby onGetLobby_0);

	// Token: 0x0600118A RID: 4490
	void imethod_9(OnCloseLobby onCloseLobby_0);

	// Token: 0x0600118B RID: 4491
	void imethod_10(OnPlayerJoinLobby onPlayerJoinLobby_0);

	// Token: 0x0600118C RID: 4492
	void imethod_11(OnPlayerJoinLobby onPlayerJoinLobby_0);

	// Token: 0x0600118D RID: 4493
	void imethod_12(OnPlayerLeaveLobby onPlayerLeaveLobby_0);

	// Token: 0x0600118E RID: 4494
	void imethod_13(OnPlayerLeaveLobby onPlayerLeaveLobby_0);

	// Token: 0x0600118F RID: 4495
	void imethod_14(OnLobbyCreated onLobbyCreated_0);

	// Token: 0x06001190 RID: 4496
	void imethod_15(OnLobbyCreated onLobbyCreated_0);

	// Token: 0x06001191 RID: 4497
	void imethod_16(OnLobbyGameStart onLobbyGameStart_0);

	// Token: 0x06001192 RID: 4498
	void imethod_17(OnLobbyGameStart onLobbyGameStart_0);

	// Token: 0x06001193 RID: 4499
	void imethod_18(OnLobbyClose onLobbyClose_0);

	// Token: 0x06001194 RID: 4500
	void imethod_19(OnLobbyClose onLobbyClose_0);

	// Token: 0x06001195 RID: 4501
	void imethod_20(OnLobbyDelete onLobbyDelete_0);

	// Token: 0x06001196 RID: 4502
	void imethod_21(OnLobbyDelete onLobbyDelete_0);

	// Token: 0x06001197 RID: 4503
	void imethod_22(OnLobbyOwnerChange onLobbyOwnerChange_0);

	// Token: 0x06001198 RID: 4504
	void imethod_23(OnLobbyOwnerChange onLobbyOwnerChange_0);

	// Token: 0x06001199 RID: 4505
	void imethod_24(OnLobbyInvitationRecieved onLobbyInvitationRecieved_0);

	// Token: 0x0600119A RID: 4506
	void imethod_25(OnLobbyInvitationRecieved onLobbyInvitationRecieved_0);

	// Token: 0x0600119B RID: 4507
	void imethod_26(OnGroupJoinLobby onGroupJoinLobby_0);

	// Token: 0x0600119C RID: 4508
	void imethod_27(OnGroupJoinLobby onGroupJoinLobby_0);

	// Token: 0x0600119D RID: 4509
	void imethod_28(OnGroupLeaveLobby onGroupLeaveLobby_0);

	// Token: 0x0600119E RID: 4510
	void imethod_29(OnGroupLeaveLobby onGroupLeaveLobby_0);

	// Token: 0x0600119F RID: 4511
	void imethod_30(OnNewLobby onNewLobby_0);

	// Token: 0x060011A0 RID: 4512
	void imethod_31(OnNewLobby onNewLobby_0);
}
