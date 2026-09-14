using System;
using ns0;
using XsdSettings;

// Token: 0x02000319 RID: 793
public class LobbyServiceWrapperOnline : ILobbyServiceWrapper, IServiceWrapper
{
	// Token: 0x06001326 RID: 4902 RVA: 0x000772E8 File Offset: 0x000754E8
	public void imethod_0()
	{
		if (!this.m_isInitializing && !this.m_initialized)
		{
			this.m_isInitializing = true;
			OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.Prop_0.imethod_26(new OnGroupJoinLobby(ServiceWrapperBase<LobbyServiceWrapper>.Instance.method_19));
			OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.Prop_0.imethod_28(new OnGroupLeaveLobby(ServiceWrapperBase<LobbyServiceWrapper>.Instance.method_20));
			OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.Prop_0.imethod_18(new OnLobbyClose(ServiceWrapperBase<LobbyServiceWrapper>.Instance.method_16));
			OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.Prop_0.imethod_14(new OnLobbyCreated(ServiceWrapperBase<LobbyServiceWrapper>.Instance.method_14));
			OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.Prop_0.imethod_16(new OnLobbyGameStart(ServiceWrapperBase<LobbyServiceWrapper>.Instance.method_15));
			OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.Prop_0.imethod_22(new OnLobbyOwnerChange(ServiceWrapperBase<LobbyServiceWrapper>.Instance.method_17));
			OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.Prop_0.imethod_10(new OnPlayerJoinLobby(ServiceWrapperBase<LobbyServiceWrapper>.Instance.method_12));
			OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.Prop_0.imethod_12(new OnPlayerLeaveLobby(ServiceWrapperBase<LobbyServiceWrapper>.Instance.method_13));
			OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.Prop_0.imethod_24(new OnLobbyInvitationRecieved(ServiceWrapperBase<LobbyServiceWrapper>.Instance.method_18));
			OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.Prop_0.imethod_30(new OnNewLobby(ServiceWrapperBase<LobbyServiceWrapper>.Instance.method_21));
			LobbyManager.smethod_0();
			this.m_initialized = true;
		}
	}

	// Token: 0x06001327 RID: 4903 RVA: 0x0000EE47 File Offset: 0x0000D047
	private void OnGetMyLobby(Lobby room)
	{
		this.m_initialized = true;
	}

	// Token: 0x06001328 RID: 4904 RVA: 0x0000EE50 File Offset: 0x0000D050
	public bool imethod_1()
	{
		return this.m_initialized;
	}

	// Token: 0x06001329 RID: 4905 RVA: 0x0000EE58 File Offset: 0x0000D058
	public void imethod_2(OnInviteToLobby onInviteToLobby_0, int int_0)
	{
		OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.Prop_0.imethod_2(onInviteToLobby_0, int_0);
	}

	// Token: 0x0600132A RID: 4906 RVA: 0x0000EE66 File Offset: 0x0000D066
	public void imethod_3(OnAcceptLobbyInvitation onAcceptLobbyInvitation_0, int int_0)
	{
		OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.Prop_0.imethod_3(onAcceptLobbyInvitation_0, int_0);
	}

	// Token: 0x0600132B RID: 4907 RVA: 0x0000EE74 File Offset: 0x0000D074
	public void imethod_4(OnRejectLobbyInvitation onRejectLobbyInvitation_0, int int_0)
	{
		OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.Prop_0.imethod_4(onRejectLobbyInvitation_0, int_0);
	}

	// Token: 0x0600132C RID: 4908 RVA: 0x0000EE82 File Offset: 0x0000D082
	public void imethod_5(OnKickPlayerFromLobby onKickPlayerFromLobby_0, int int_0)
	{
		OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.Prop_0.imethod_5(onKickPlayerFromLobby_0, int_0);
	}

	// Token: 0x0600132D RID: 4909 RVA: 0x0000EE90 File Offset: 0x0000D090
	public void imethod_6(OnLeaveLobby onLeaveLobby_0)
	{
		OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.Prop_0.imethod_6(onLeaveLobby_0);
	}

	// Token: 0x0600132E RID: 4910 RVA: 0x0000EE9D File Offset: 0x0000D09D
	public void imethod_7(OnStartLobbyGame onStartLobbyGame_0)
	{
		OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.Prop_0.imethod_7(onStartLobbyGame_0);
	}

	// Token: 0x0600132F RID: 4911 RVA: 0x0000EEAA File Offset: 0x0000D0AA
	public void imethod_8(OnGetLobby onGetLobby_0)
	{
		OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.Prop_0.imethod_8(onGetLobby_0);
	}

	// Token: 0x06001330 RID: 4912 RVA: 0x0000EEB7 File Offset: 0x0000D0B7
	public void imethod_9(OnCloseLobby onCloseLobby_0)
	{
		OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.Prop_0.imethod_9(onCloseLobby_0);
	}

	// Token: 0x06001331 RID: 4913 RVA: 0x0000EEC4 File Offset: 0x0000D0C4
	public void imethod_10(OnCreateLobby onCreateLobby_0, bool bool_0)
	{
		OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.Prop_0.imethod_0(onCreateLobby_0, bool_0);
	}

	// Token: 0x06001332 RID: 4914 RVA: 0x0000EED2 File Offset: 0x0000D0D2
	public void imethod_11(OnOpenLobby onOpenLobby_0, GamemodeType gamemodeType_0, int int_0, ELevelDifficulty elevelDifficulty_0)
	{
		OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.Prop_0.imethod_1(onOpenLobby_0, gamemodeType_0, int_0, elevelDifficulty_0);
	}

	// Token: 0x04000E51 RID: 3665
	private bool m_isInitializing;

	// Token: 0x04000E52 RID: 3666
	private bool m_initialized;
}
