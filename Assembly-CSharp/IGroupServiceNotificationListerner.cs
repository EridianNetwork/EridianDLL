using System;

// Token: 0x020002DC RID: 732
public interface IGroupServiceNotificationListerner
{
	// Token: 0x06001052 RID: 4178
	void OnReceivedGroupInvitation(int senderCharacterId, int groupId, int messageId);

	// Token: 0x06001053 RID: 4179
	void OnKickedFromGroup();

	// Token: 0x06001054 RID: 4180
	void OnNewGroupLeader(int characterId);

	// Token: 0x06001055 RID: 4181
	void OnNewGroupMember(Presence characterinfo);

	// Token: 0x06001056 RID: 4182
	void OnGroupInviteRejected(int characterId, string characterName);

	// Token: 0x06001057 RID: 4183
	void OnGroupMemberLeft(int characterId);

	// Token: 0x06001058 RID: 4184
	void OnGroupDisbanded();

	// Token: 0x06001059 RID: 4185
	void OnGroupMatchmakingStarted();
}
