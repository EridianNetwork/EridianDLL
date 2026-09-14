using System;
using ns0;

// Token: 0x0200033D RID: 829
public class PvPRoomServiceWrapperOnline : IPvPRoomServiceWrapper, IServiceWrapper
{
	// Token: 0x060014EA RID: 5354 RVA: 0x000789B0 File Offset: 0x00076BB0
	public void imethod_0()
	{
		if (!this.m_isInitializing && !this.m_initialized)
		{
			this.m_isInitializing = true;
			OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.Prop_0.imethod_8(new OnGetLobby(this.OnGetMyPvPRoom));
			OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.Prop_0.imethod_10(new OnPlayerJoinLobby(ServiceWrapperBase<PvPRoomServiceWrapper>.Instance.OnPlayerJoinPvPRoom));
			OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.Prop_0.imethod_12(new OnPlayerLeaveLobby(ServiceWrapperBase<PvPRoomServiceWrapper>.Instance.OnPlayerLeavePvPRoom));
			OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.Prop_0.imethod_16(new OnLobbyGameStart(ServiceWrapperBase<PvPRoomServiceWrapper>.Instance.OnPvPGameStart));
			OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.Prop_0.imethod_18(new OnLobbyClose(ServiceWrapperBase<PvPRoomServiceWrapper>.Instance.OnPvPRoomClose));
			OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.Prop_0.imethod_20(new OnLobbyDelete(ServiceWrapperBase<PvPRoomServiceWrapper>.Instance.OnPvPRoomDelete));
			OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.Prop_0.imethod_22(new OnLobbyOwnerChange(ServiceWrapperBase<PvPRoomServiceWrapper>.Instance.OnPvPRoomOwnerChange));
			OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.Prop_0.imethod_24(new OnLobbyInvitationRecieved(ServiceWrapperBase<PvPRoomServiceWrapper>.Instance.OnPvPInvitationRecieved));
			OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.Prop_0.imethod_26(new OnGroupJoinLobby(ServiceWrapperBase<PvPRoomServiceWrapper>.Instance.OnGroupJoinPvPRoom));
			OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.Prop_0.imethod_28(new OnGroupLeaveLobby(ServiceWrapperBase<PvPRoomServiceWrapper>.Instance.OnGroupLeavePvPRoom));
		}
	}

	// Token: 0x060014EB RID: 5355 RVA: 0x0000F6E7 File Offset: 0x0000D8E7
	private void OnGetMyPvPRoom(Lobby room)
	{
		this.m_initialized = true;
	}

	// Token: 0x060014EC RID: 5356 RVA: 0x0000F6F0 File Offset: 0x0000D8F0
	public bool imethod_1()
	{
		return this.m_initialized;
	}

	// Token: 0x060014ED RID: 5357 RVA: 0x0000EE58 File Offset: 0x0000D058
	public void imethod_2(OnInviteToLobby onInviteToLobby_0, int int_0)
	{
		OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.Prop_0.imethod_2(onInviteToLobby_0, int_0);
	}

	// Token: 0x060014EE RID: 5358 RVA: 0x0000EE66 File Offset: 0x0000D066
	public void imethod_3(OnAcceptLobbyInvitation onAcceptLobbyInvitation_0, int int_0)
	{
		OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.Prop_0.imethod_3(onAcceptLobbyInvitation_0, int_0);
	}

	// Token: 0x060014EF RID: 5359 RVA: 0x0000EE74 File Offset: 0x0000D074
	public void imethod_4(OnRejectLobbyInvitation onRejectLobbyInvitation_0, int int_0)
	{
		OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.Prop_0.imethod_4(onRejectLobbyInvitation_0, int_0);
	}

	// Token: 0x060014F0 RID: 5360 RVA: 0x0000EE82 File Offset: 0x0000D082
	public void imethod_5(OnKickPlayerFromLobby onKickPlayerFromLobby_0, int int_0)
	{
		OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.Prop_0.imethod_5(onKickPlayerFromLobby_0, int_0);
	}

	// Token: 0x060014F1 RID: 5361 RVA: 0x0000EE90 File Offset: 0x0000D090
	public void imethod_6(OnLeaveLobby onLeaveLobby_0)
	{
		OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.Prop_0.imethod_6(onLeaveLobby_0);
	}

	// Token: 0x060014F2 RID: 5362 RVA: 0x0000EE9D File Offset: 0x0000D09D
	public void imethod_7(OnStartLobbyGame onStartLobbyGame_0)
	{
		OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.Prop_0.imethod_7(onStartLobbyGame_0);
	}

	// Token: 0x060014F3 RID: 5363 RVA: 0x0000EEAA File Offset: 0x0000D0AA
	public void imethod_8(OnGetLobby onGetLobby_0)
	{
		OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.Prop_0.imethod_8(onGetLobby_0);
	}

	// Token: 0x04000E7A RID: 3706
	private bool m_isInitializing;

	// Token: 0x04000E7B RID: 3707
	private bool m_initialized;
}
