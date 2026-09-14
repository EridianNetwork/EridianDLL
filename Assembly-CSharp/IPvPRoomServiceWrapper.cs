using System;

// Token: 0x0200033A RID: 826
public interface IPvPRoomServiceWrapper : IServiceWrapper
{
	// Token: 0x060014C5 RID: 5317
	void imethod_2(OnInviteToLobby onInviteToLobby_0, int int_0);

	// Token: 0x060014C6 RID: 5318
	void imethod_3(OnAcceptLobbyInvitation onAcceptLobbyInvitation_0, int int_0);

	// Token: 0x060014C7 RID: 5319
	void imethod_4(OnRejectLobbyInvitation onRejectLobbyInvitation_0, int int_0);

	// Token: 0x060014C8 RID: 5320
	void imethod_5(OnKickPlayerFromLobby onKickPlayerFromLobby_0, int int_0);

	// Token: 0x060014C9 RID: 5321
	void imethod_6(OnLeaveLobby onLeaveLobby_0);

	// Token: 0x060014CA RID: 5322
	void imethod_7(OnStartLobbyGame onStartLobbyGame_0);

	// Token: 0x060014CB RID: 5323
	void imethod_8(OnGetLobby onGetLobby_0);
}
