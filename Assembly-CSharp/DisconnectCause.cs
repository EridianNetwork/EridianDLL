using System;

// Token: 0x02000B08 RID: 2824
public enum DisconnectCause
{
	// Token: 0x040037D6 RID: 14294
	ExceptionOnConnect = 1023,
	// Token: 0x040037D7 RID: 14295
	SecurityExceptionOnConnect = 1022,
	// Token: 0x040037D8 RID: 14296
	TimeoutDisconnect = 1040,
	// Token: 0x040037D9 RID: 14297
	InternalReceiveException = 1039,
	// Token: 0x040037DA RID: 14298
	DisconnectByServer = 1041,
	// Token: 0x040037DB RID: 14299
	DisconnectByServerLogic = 1043,
	// Token: 0x040037DC RID: 14300
	DisconnectByServerUserLimit = 1042,
	// Token: 0x040037DD RID: 14301
	Exception = 1026,
	// Token: 0x040037DE RID: 14302
	InvalidRegion = 32756,
	// Token: 0x040037DF RID: 14303
	MaxCcuReached
}
