using System;
using XsdSettings;

// Token: 0x02000316 RID: 790
public interface ILobbyServiceWrapper : IServiceWrapper
{
	// Token: 0x060012F9 RID: 4857
	void imethod_2(OnInviteToLobby onInviteToLobby_0, int int_0);

	// Token: 0x060012FA RID: 4858
	void imethod_3(OnAcceptLobbyInvitation onAcceptLobbyInvitation_0, int int_0);

	// Token: 0x060012FB RID: 4859
	void imethod_4(OnRejectLobbyInvitation onRejectLobbyInvitation_0, int int_0);

	// Token: 0x060012FC RID: 4860
	void imethod_5(OnKickPlayerFromLobby onKickPlayerFromLobby_0, int int_0);

	// Token: 0x060012FD RID: 4861
	void imethod_6(OnLeaveLobby onLeaveLobby_0);

	// Token: 0x060012FE RID: 4862
	void imethod_7(OnStartLobbyGame onStartLobbyGame_0);

	// Token: 0x060012FF RID: 4863
	void imethod_8(OnGetLobby onGetLobby_0);

	// Token: 0x06001300 RID: 4864
	void imethod_9(OnCloseLobby onCloseLobby_0);

	// Token: 0x06001301 RID: 4865
	void imethod_10(OnCreateLobby onCreateLobby_0, bool bool_0);

	// Token: 0x06001302 RID: 4866
	void imethod_11(OnOpenLobby onOpenLobby_0, GamemodeType gamemodeType_0, int int_0, ELevelDifficulty elevelDifficulty_0);
}
