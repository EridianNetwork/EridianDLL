using System;

// Token: 0x0200033B RID: 827
public interface IPvPRoomServiceNotificationListerner
{
	// Token: 0x060014CC RID: 5324
	void OnPlayerJoinPvPRoom(Presence newPlayer);

	// Token: 0x060014CD RID: 5325
	void OnPlayerLeavePvPRoom(int characterId);

	// Token: 0x060014CE RID: 5326
	void OnPvPGameStart();

	// Token: 0x060014CF RID: 5327
	void OnPvPRoomClose();

	// Token: 0x060014D0 RID: 5328
	void OnPvPRoomDelete();

	// Token: 0x060014D1 RID: 5329
	void OnPvPRoomOwnerChange(int newOwnerCharacterId);

	// Token: 0x060014D2 RID: 5330
	void OnGroupJoinPvPRoom(int newGroup);

	// Token: 0x060014D3 RID: 5331
	void OnGroupLeavePvPRoom(int newGroup);

	// Token: 0x060014D4 RID: 5332
	void OnPvPInvitationRecieved(int sender, int messageId);
}
