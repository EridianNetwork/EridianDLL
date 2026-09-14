using System;

// Token: 0x020002D7 RID: 727
public interface IFriendServiceNotificationListerner
{
	// Token: 0x06001021 RID: 4129
	void OnFriendRequestReceived(FriendRequest friendRequest);

	// Token: 0x06001022 RID: 4130
	void OnNewFriend(Presence friendInfo);

	// Token: 0x06001023 RID: 4131
	void OnUnfriended(int friendCharacterId);

	// Token: 0x06001024 RID: 4132
	void OnRejectFriend(int characterId, string characterName);
}
