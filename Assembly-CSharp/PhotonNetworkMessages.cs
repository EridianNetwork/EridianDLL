using System;

// Token: 0x02000B28 RID: 2856
internal class PhotonNetworkMessages
{
	// Token: 0x04003A15 RID: 14869
	public const byte RPC = 200;

	// Token: 0x04003A16 RID: 14870
	public const byte SendSerialize = 201;

	// Token: 0x04003A17 RID: 14871
	public const byte Instantiation = 202;

	// Token: 0x04003A18 RID: 14872
	public const byte CloseConnection = 203;

	// Token: 0x04003A19 RID: 14873
	public const byte Destroy = 204;

	// Token: 0x04003A1A RID: 14874
	public const byte RemoveCachedRPCs = 205;

	// Token: 0x04003A1B RID: 14875
	public const byte SendSerializeReliable = 206;

	// Token: 0x04003A1C RID: 14876
	public const byte PingToClient = 207;

	// Token: 0x04003A1D RID: 14877
	public const byte HostReady = 208;

	// Token: 0x04003A1E RID: 14878
	public const byte GameMetrics = 209;
}
