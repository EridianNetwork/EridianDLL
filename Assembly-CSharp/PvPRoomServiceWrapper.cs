using System;
using System.Collections.Generic;

// Token: 0x0200033C RID: 828
public class PvPRoomServiceWrapper : ServiceWrapper<IPvPRoomServiceWrapper, PvPRoomServiceWrapper>
{
	// Token: 0x060014D6 RID: 5334 RVA: 0x0000F651 File Offset: 0x0000D851
	public void method_0(IPvPRoomServiceNotificationListerner ipvPRoomServiceNotificationListerner_0)
	{
		this.m_listerner.Add(ipvPRoomServiceNotificationListerner_0);
	}

	// Token: 0x060014D7 RID: 5335 RVA: 0x0000F65F File Offset: 0x0000D85F
	public void method_1(IPvPRoomServiceNotificationListerner ipvPRoomServiceNotificationListerner_0)
	{
		this.m_listerner.Remove(ipvPRoomServiceNotificationListerner_0);
	}

	// Token: 0x060014D8 RID: 5336 RVA: 0x0000F66E File Offset: 0x0000D86E
	public override void vmethod_1()
	{
		this.m_wrapperOnline = new PvPRoomServiceWrapperOnline();
		base.vmethod_1();
	}

	// Token: 0x060014D9 RID: 5337 RVA: 0x0000F681 File Offset: 0x0000D881
	public void method_2(OnInviteToLobby onInviteToLobby_0, int int_0)
	{
		this.vmethod_0().imethod_2(onInviteToLobby_0, int_0);
	}

	// Token: 0x060014DA RID: 5338 RVA: 0x0000F690 File Offset: 0x0000D890
	public void method_3(OnAcceptLobbyInvitation onAcceptLobbyInvitation_0, int int_0)
	{
		this.vmethod_0().imethod_3(onAcceptLobbyInvitation_0, int_0);
	}

	// Token: 0x060014DB RID: 5339 RVA: 0x0000F69F File Offset: 0x0000D89F
	public void method_4(OnRejectLobbyInvitation onRejectLobbyInvitation_0, int int_0)
	{
		this.vmethod_0().imethod_4(onRejectLobbyInvitation_0, int_0);
	}

	// Token: 0x060014DC RID: 5340 RVA: 0x0000F6AE File Offset: 0x0000D8AE
	public void method_5(OnKickPlayerFromLobby onKickPlayerFromLobby_0, int int_0)
	{
		this.vmethod_0().imethod_5(onKickPlayerFromLobby_0, int_0);
	}

	// Token: 0x060014DD RID: 5341 RVA: 0x0000F6BD File Offset: 0x0000D8BD
	public void method_6(OnLeaveLobby onLeaveLobby_0)
	{
		this.vmethod_0().imethod_6(onLeaveLobby_0);
	}

	// Token: 0x060014DE RID: 5342 RVA: 0x0000F6CB File Offset: 0x0000D8CB
	public void method_7(OnStartLobbyGame onStartLobbyGame_0)
	{
		this.vmethod_0().imethod_7(onStartLobbyGame_0);
	}

	// Token: 0x060014DF RID: 5343 RVA: 0x0000F6D9 File Offset: 0x0000D8D9
	public void method_8(OnGetLobby onGetLobby_0)
	{
		this.vmethod_0().imethod_8(onGetLobby_0);
	}

	// Token: 0x060014E0 RID: 5344 RVA: 0x000787C4 File Offset: 0x000769C4
	public void OnPlayerJoinPvPRoom(Presence newPlayer)
	{
		for (int i = 0; i < this.m_listerner.Count; i++)
		{
			this.m_listerner[i].OnPlayerJoinPvPRoom(newPlayer);
		}
	}

	// Token: 0x060014E1 RID: 5345 RVA: 0x000787FC File Offset: 0x000769FC
	public void OnPlayerLeavePvPRoom(int characterId)
	{
		for (int i = 0; i < this.m_listerner.Count; i++)
		{
			this.m_listerner[i].OnPlayerLeavePvPRoom(characterId);
		}
	}

	// Token: 0x060014E2 RID: 5346 RVA: 0x00078834 File Offset: 0x00076A34
	public void OnPvPGameStart()
	{
		for (int i = 0; i < this.m_listerner.Count; i++)
		{
			this.m_listerner[i].OnPvPGameStart();
		}
	}

	// Token: 0x060014E3 RID: 5347 RVA: 0x00078868 File Offset: 0x00076A68
	public void OnPvPRoomClose()
	{
		for (int i = 0; i < this.m_listerner.Count; i++)
		{
			this.m_listerner[i].OnPvPRoomClose();
		}
	}

	// Token: 0x060014E4 RID: 5348 RVA: 0x0007889C File Offset: 0x00076A9C
	public void OnPvPRoomDelete()
	{
		for (int i = 0; i < this.m_listerner.Count; i++)
		{
			this.m_listerner[i].OnPvPRoomDelete();
		}
	}

	// Token: 0x060014E5 RID: 5349 RVA: 0x000788D0 File Offset: 0x00076AD0
	public void OnPvPRoomOwnerChange(int newOwnerCharacterId)
	{
		for (int i = 0; i < this.m_listerner.Count; i++)
		{
			this.m_listerner[i].OnPvPRoomOwnerChange(newOwnerCharacterId);
		}
	}

	// Token: 0x060014E6 RID: 5350 RVA: 0x00078908 File Offset: 0x00076B08
	public void OnGroupJoinPvPRoom(int newGroup)
	{
		for (int i = 0; i < this.m_listerner.Count; i++)
		{
			this.m_listerner[i].OnGroupJoinPvPRoom(newGroup);
		}
	}

	// Token: 0x060014E7 RID: 5351 RVA: 0x00078940 File Offset: 0x00076B40
	public void OnGroupLeavePvPRoom(int newGroup)
	{
		for (int i = 0; i < this.m_listerner.Count; i++)
		{
			this.m_listerner[i].OnGroupLeavePvPRoom(newGroup);
		}
	}

	// Token: 0x060014E8 RID: 5352 RVA: 0x00078978 File Offset: 0x00076B78
	public void OnPvPInvitationRecieved(int sender, int messageId)
	{
		for (int i = 0; i < this.m_listerner.Count; i++)
		{
			this.m_listerner[i].OnPvPInvitationRecieved(sender, messageId);
		}
	}

	// Token: 0x04000E79 RID: 3705
	private List<IPvPRoomServiceNotificationListerner> m_listerner = new List<IPvPRoomServiceNotificationListerner>();
}
