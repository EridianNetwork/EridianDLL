using System;
using System.Collections.Generic;
using XsdSettings;

// Token: 0x02000318 RID: 792
public class LobbyServiceWrapper : ServiceWrapper<ILobbyServiceWrapper, LobbyServiceWrapper>
{
	// Token: 0x0600130E RID: 4878 RVA: 0x0000ED7A File Offset: 0x0000CF7A
	public void method_0(ILobbyServiceNotificationListerner ilobbyServiceNotificationListerner_0)
	{
		this.m_listerner.Add(ilobbyServiceNotificationListerner_0);
	}

	// Token: 0x0600130F RID: 4879 RVA: 0x0000ED88 File Offset: 0x0000CF88
	public void method_1(ILobbyServiceNotificationListerner ilobbyServiceNotificationListerner_0)
	{
		this.m_listerner.Remove(ilobbyServiceNotificationListerner_0);
	}

	// Token: 0x06001310 RID: 4880 RVA: 0x0000ED97 File Offset: 0x0000CF97
	public override void vmethod_1()
	{
		if (this.m_wrapperOnline == null)
		{
			this.m_wrapperOnline = new LobbyServiceWrapperOnline();
		}
		base.vmethod_1();
	}

	// Token: 0x06001311 RID: 4881 RVA: 0x0000EDB2 File Offset: 0x0000CFB2
	public void method_2(OnInviteToLobby onInviteToLobby_0, int int_0)
	{
		this.vmethod_0().imethod_2(onInviteToLobby_0, int_0);
	}

	// Token: 0x06001312 RID: 4882 RVA: 0x0000EDC1 File Offset: 0x0000CFC1
	public void method_3(OnAcceptLobbyInvitation onAcceptLobbyInvitation_0, int int_0)
	{
		this.vmethod_0().imethod_3(onAcceptLobbyInvitation_0, int_0);
	}

	// Token: 0x06001313 RID: 4883 RVA: 0x0000EDD0 File Offset: 0x0000CFD0
	public void method_4(OnRejectLobbyInvitation onRejectLobbyInvitation_0, int int_0)
	{
		this.vmethod_0().imethod_4(onRejectLobbyInvitation_0, int_0);
	}

	// Token: 0x06001314 RID: 4884 RVA: 0x0000EDDF File Offset: 0x0000CFDF
	public void method_5(OnKickPlayerFromLobby onKickPlayerFromLobby_0, int int_0)
	{
		this.vmethod_0().imethod_5(onKickPlayerFromLobby_0, int_0);
	}

	// Token: 0x06001315 RID: 4885 RVA: 0x0000EDEE File Offset: 0x0000CFEE
	public void method_6(OnLeaveLobby onLeaveLobby_0)
	{
		this.vmethod_0().imethod_6(onLeaveLobby_0);
	}

	// Token: 0x06001316 RID: 4886 RVA: 0x0000EDFC File Offset: 0x0000CFFC
	public void method_7(OnStartLobbyGame onStartLobbyGame_0)
	{
		this.vmethod_0().imethod_7(onStartLobbyGame_0);
	}

	// Token: 0x06001317 RID: 4887 RVA: 0x0000EE0A File Offset: 0x0000D00A
	public void method_8(OnGetLobby onGetLobby_0)
	{
		this.vmethod_0().imethod_8(onGetLobby_0);
	}

	// Token: 0x06001318 RID: 4888 RVA: 0x0000EE18 File Offset: 0x0000D018
	public void method_9(OnCloseLobby onCloseLobby_0)
	{
		this.vmethod_0().imethod_9(onCloseLobby_0);
	}

	// Token: 0x06001319 RID: 4889 RVA: 0x0000EE26 File Offset: 0x0000D026
	public void method_10(OnOpenLobby onOpenLobby_0, GamemodeType gamemodeType_0, int int_0, ELevelDifficulty elevelDifficulty_0)
	{
		this.vmethod_0().imethod_11(onOpenLobby_0, gamemodeType_0, int_0, elevelDifficulty_0);
	}

	// Token: 0x0600131A RID: 4890 RVA: 0x0000EE38 File Offset: 0x0000D038
	public void method_11(OnCreateLobby onCreateLobby_0, bool bool_1)
	{
		this.vmethod_0().imethod_10(onCreateLobby_0, bool_1);
	}

	// Token: 0x0600131B RID: 4891 RVA: 0x000770C0 File Offset: 0x000752C0
	public void method_12(Presence presence_0)
	{
		for (int i = 0; i < this.m_listerner.Count; i++)
		{
			this.m_listerner[i].OnPlayerJoinLobby(presence_0);
		}
	}

	// Token: 0x0600131C RID: 4892 RVA: 0x000770F8 File Offset: 0x000752F8
	public void method_13(int int_0)
	{
		for (int i = 0; i < this.m_listerner.Count; i++)
		{
			this.m_listerner[i].OnPlayerLeaveLobby(int_0);
		}
	}

	// Token: 0x0600131D RID: 4893 RVA: 0x00077130 File Offset: 0x00075330
	public void method_14(Lobby lobby_0)
	{
		for (int i = 0; i < this.m_listerner.Count; i++)
		{
			this.m_listerner[i].OnLobbyCreated(lobby_0);
		}
	}

	// Token: 0x0600131E RID: 4894 RVA: 0x00077168 File Offset: 0x00075368
	public void method_15()
	{
		for (int i = 0; i < this.m_listerner.Count; i++)
		{
			this.m_listerner[i].OnLobbyGameStart();
		}
	}

	// Token: 0x0600131F RID: 4895 RVA: 0x0007719C File Offset: 0x0007539C
	public void method_16()
	{
		for (int i = 0; i < this.m_listerner.Count; i++)
		{
			this.m_listerner[i].OnLobbyClose();
		}
	}

	// Token: 0x06001320 RID: 4896 RVA: 0x000771D0 File Offset: 0x000753D0
	public void method_17(int int_0)
	{
		for (int i = 0; i < this.m_listerner.Count; i++)
		{
			this.m_listerner[i].OnLobbyOwnerChange(int_0);
		}
	}

	// Token: 0x06001321 RID: 4897 RVA: 0x00077208 File Offset: 0x00075408
	public void method_18(int int_0, int int_1)
	{
		for (int i = 0; i < this.m_listerner.Count; i++)
		{
			this.m_listerner[i].OnLobbyInvitationRecieved(int_0, int_1);
		}
	}

	// Token: 0x06001322 RID: 4898 RVA: 0x00077240 File Offset: 0x00075440
	public void method_19(int int_0)
	{
		for (int i = 0; i < this.m_listerner.Count; i++)
		{
			this.m_listerner[i].OnGroupJoinLobby(int_0);
		}
	}

	// Token: 0x06001323 RID: 4899 RVA: 0x00077278 File Offset: 0x00075478
	public void method_20(int int_0)
	{
		for (int i = 0; i < this.m_listerner.Count; i++)
		{
			this.m_listerner[i].OnGroupLeaveLobby(int_0);
		}
	}

	// Token: 0x06001324 RID: 4900 RVA: 0x000772B0 File Offset: 0x000754B0
	public void method_21(Lobby lobby_0)
	{
		for (int i = 0; i < this.m_listerner.Count; i++)
		{
			this.m_listerner[i].OnNewLobby(lobby_0);
		}
	}

	// Token: 0x04000E50 RID: 3664
	private List<ILobbyServiceNotificationListerner> m_listerner = new List<ILobbyServiceNotificationListerner>();
}
