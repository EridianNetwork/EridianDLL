using System;

// Token: 0x02000317 RID: 791
public interface ILobbyServiceNotificationListerner
{
	// Token: 0x06001303 RID: 4867
	void OnNewLobby(Lobby newLobby);

	// Token: 0x06001304 RID: 4868
	void OnPlayerJoinLobby(Presence newPlayer);

	// Token: 0x06001305 RID: 4869
	void OnPlayerLeaveLobby(int characterId);

	// Token: 0x06001306 RID: 4870
	void OnLobbyCreated(Lobby room);

	// Token: 0x06001307 RID: 4871
	void OnLobbyGameStart();

	// Token: 0x06001308 RID: 4872
	void OnLobbyClose();

	// Token: 0x06001309 RID: 4873
	void OnLobbyOwnerChange(int newOwnerCharacterId);

	// Token: 0x0600130A RID: 4874
	void OnGroupJoinLobby(int newGroup);

	// Token: 0x0600130B RID: 4875
	void OnGroupLeaveLobby(int newGroup);

	// Token: 0x0600130C RID: 4876
	void OnLobbyInvitationRecieved(int sender, int messageId);
}
