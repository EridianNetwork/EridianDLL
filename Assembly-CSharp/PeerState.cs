using System;

// Token: 0x02000B05 RID: 2821
public enum PeerState
{
	// Token: 0x040037A6 RID: 14246
	Uninitialized,
	// Token: 0x040037A7 RID: 14247
	PeerCreated,
	// Token: 0x040037A8 RID: 14248
	Connecting,
	// Token: 0x040037A9 RID: 14249
	Connected,
	// Token: 0x040037AA RID: 14250
	Queued,
	// Token: 0x040037AB RID: 14251
	Authenticated,
	// Token: 0x040037AC RID: 14252
	JoinedLobby,
	// Token: 0x040037AD RID: 14253
	DisconnectingFromMasterserver,
	// Token: 0x040037AE RID: 14254
	ConnectingToGameserver,
	// Token: 0x040037AF RID: 14255
	ConnectedToGameserver,
	// Token: 0x040037B0 RID: 14256
	Joining,
	// Token: 0x040037B1 RID: 14257
	Joined,
	// Token: 0x040037B2 RID: 14258
	Leaving,
	// Token: 0x040037B3 RID: 14259
	DisconnectingFromGameserver,
	// Token: 0x040037B4 RID: 14260
	ConnectingToMasterserver,
	// Token: 0x040037B5 RID: 14261
	ConnectedComingFromGameserver,
	// Token: 0x040037B6 RID: 14262
	QueuedComingFromGameserver,
	// Token: 0x040037B7 RID: 14263
	Disconnecting,
	// Token: 0x040037B8 RID: 14264
	Disconnected,
	// Token: 0x040037B9 RID: 14265
	ConnectedToMaster
}
