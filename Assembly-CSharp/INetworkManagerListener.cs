using System;

// Token: 0x02000AC9 RID: 2761
public interface INetworkManagerListener
{
	// Token: 0x06004B0C RID: 19212
	void OnJoinedRoom();

	// Token: 0x06004B0D RID: 19213
	void OnPhotonJoinRoomFailed();

	// Token: 0x06004B0E RID: 19214
	void OnPhotonRandomJoinFailed();

	// Token: 0x06004B0F RID: 19215
	void OnDisconnectedFromPhoton();

	// Token: 0x06004B10 RID: 19216
	void OnLeftRoom();
}
