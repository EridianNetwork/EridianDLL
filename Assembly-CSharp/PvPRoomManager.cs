using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ns0;

// Token: 0x02000680 RID: 1664
public class PvPRoomManager : IPvPRoomServiceNotificationListerner
{
	// Token: 0x06002AEE RID: 10990 RVA: 0x0001C73E File Offset: 0x0001A93E
	private PvPRoomManager()
	{
		this.m_RoomInfoMap = new Dictionary<int, Presence>();
		this.m_RoomInfoMap.Clear();
	}

	// Token: 0x06002AEF RID: 10991 RVA: 0x0001C763 File Offset: 0x0001A963
	public static PvPRoomManager smethod_0()
	{
		if (PvPRoomManager._PvPRoomInstance == null)
		{
			PvPRoomManager._PvPRoomInstance = new PvPRoomManager();
			ServiceWrapperBase<PvPRoomServiceWrapper>.Instance.method_0(PvPRoomManager._PvPRoomInstance);
		}
		return PvPRoomManager._PvPRoomInstance;
	}

	// Token: 0x06002AF0 RID: 10992 RVA: 0x0001C78A File Offset: 0x0001A98A
	public bool method_0()
	{
		return this.m_bInRoom;
	}

	// Token: 0x06002AF1 RID: 10993 RVA: 0x0001C792 File Offset: 0x0001A992
	public bool method_1()
	{
		return OnlineService.s_characterId == this.m_nRoomOwnerId;
	}

	// Token: 0x06002AF2 RID: 10994 RVA: 0x0001C7A1 File Offset: 0x0001A9A1
	public bool method_2()
	{
		return !this.m_bInRoom && (!GroupManager.smethod_0().method_18() || GroupManager.smethod_0().method_19());
	}

	// Token: 0x06002AF3 RID: 10995 RVA: 0x0001C7CA File Offset: 0x0001A9CA
	private void method_3()
	{
		this.m_bInRoom = false;
		this.m_nRoomOwnerId = -1;
		this.m_RoomInfoMap.Clear();
	}

	// Token: 0x06002AF4 RID: 10996 RVA: 0x0001C7E5 File Offset: 0x0001A9E5
	public void OnPlayerJoinPvPRoom(Presence newPlayer)
	{
		if (newPlayer != null && !this.m_RoomInfoMap.ContainsKey(newPlayer.mCharacterId))
		{
			this.m_RoomInfoMap.Add(newPlayer.mCharacterId, newPlayer);
		}
	}

	// Token: 0x06002AF5 RID: 10997 RVA: 0x0001C80F File Offset: 0x0001AA0F
	public void OnPlayerLeavePvPRoom(int characterId)
	{
		if (this.m_RoomInfoMap.ContainsKey(characterId))
		{
			this.m_RoomInfoMap.Remove(characterId);
		}
	}

	// Token: 0x06002AF6 RID: 10998 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnPvPGameStart()
	{
	}

	// Token: 0x06002AF7 RID: 10999 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnPvPRoomClose()
	{
	}

	// Token: 0x06002AF8 RID: 11000 RVA: 0x0001C82C File Offset: 0x0001AA2C
	public void OnPvPRoomDelete()
	{
		this.method_3();
	}

	// Token: 0x06002AF9 RID: 11001 RVA: 0x0001C834 File Offset: 0x0001AA34
	public void OnPvPRoomOwnerChange(int newOwnerCharacterId)
	{
		this.m_nRoomOwnerId = newOwnerCharacterId;
	}

	// Token: 0x06002AFA RID: 11002 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnGroupJoinPvPRoom(int newGroup)
	{
	}

	// Token: 0x06002AFB RID: 11003 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnGroupLeavePvPRoom(int newGroup)
	{
	}

	// Token: 0x06002AFC RID: 11004 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnPvPInvitationRecieved(int sender, int messageId)
	{
	}

	// Token: 0x06002AFD RID: 11005 RVA: 0x0001C83D File Offset: 0x0001AA3D
	private void OnFindPvPRoom(Lobby room)
	{
		this.method_3();
		if (room != null)
		{
			this.m_bInRoom = true;
			this.m_nRoomOwnerId = room.Owner;
			room.Members.ForEach(new Action<Presence>(this.method_10));
		}
	}

	// Token: 0x06002AFE RID: 11006 RVA: 0x0001C872 File Offset: 0x0001AA72
	public void method_4()
	{
		ServiceWrapperBase<PvPRoomServiceWrapper>.Instance.method_8(new OnGetLobby(this.OnFindPvPRoom));
	}

	// Token: 0x06002AFF RID: 11007 RVA: 0x0001C88A File Offset: 0x0001AA8A
	public void method_5(int int_0)
	{
		ServiceWrapperBase<PvPRoomServiceWrapper>.Instance.method_2(new OnInviteToLobby(this.OnInviteToPvPRoom), int_0);
	}

	// Token: 0x06002B00 RID: 11008 RVA: 0x0000311B File Offset: 0x0000131B
	private void OnInviteToPvPRoom(bool success)
	{
	}

	// Token: 0x06002B01 RID: 11009 RVA: 0x0001C8A3 File Offset: 0x0001AAA3
	public void method_6(int int_0)
	{
		ServiceWrapperBase<PvPRoomServiceWrapper>.Instance.method_3(new OnAcceptLobbyInvitation(this.OnFindPvPRoom), int_0);
	}

	// Token: 0x06002B02 RID: 11010 RVA: 0x0001C8BC File Offset: 0x0001AABC
	public void method_7(int int_0)
	{
		ServiceWrapperBase<PvPRoomServiceWrapper>.Instance.method_4(new OnRejectLobbyInvitation(this.OnRejectPvPRoomInvitation), int_0);
	}

	// Token: 0x06002B03 RID: 11011 RVA: 0x0000311B File Offset: 0x0000131B
	private void OnRejectPvPRoomInvitation(bool success)
	{
	}

	// Token: 0x06002B04 RID: 11012 RVA: 0x0001C8D5 File Offset: 0x0001AAD5
	public void method_8(int int_0)
	{
		ServiceWrapperBase<PvPRoomServiceWrapper>.Instance.method_5(new OnKickPlayerFromLobby(this.OnKickPlayerFromPvPRoom), int_0);
	}

	// Token: 0x06002B05 RID: 11013 RVA: 0x0000311B File Offset: 0x0000131B
	private void OnKickPlayerFromPvPRoom(bool success, int characterId)
	{
	}

	// Token: 0x06002B06 RID: 11014 RVA: 0x0001C8EE File Offset: 0x0001AAEE
	public void method_9()
	{
		ServiceWrapperBase<PvPRoomServiceWrapper>.Instance.method_6(new OnLeaveLobby(this.OnLeavePvPRoom));
	}

	// Token: 0x06002B07 RID: 11015 RVA: 0x0001C906 File Offset: 0x0001AB06
	private void OnLeavePvPRoom(bool success)
	{
		if (success)
		{
			this.method_3();
		}
	}

	// Token: 0x06002B08 RID: 11016 RVA: 0x0001C911 File Offset: 0x0001AB11
	[CompilerGenerated]
	private void method_10(Presence presence_0)
	{
		this.m_RoomInfoMap.Add(presence_0.mCharacterId, presence_0);
	}

	// Token: 0x04001E22 RID: 7714
	public int m_nRoomOwnerId = -1;

	// Token: 0x04001E23 RID: 7715
	public bool m_bInRoom;

	// Token: 0x04001E24 RID: 7716
	protected static PvPRoomManager _PvPRoomInstance;

	// Token: 0x04001E25 RID: 7717
	public Dictionary<int, Presence> m_RoomInfoMap;
}
