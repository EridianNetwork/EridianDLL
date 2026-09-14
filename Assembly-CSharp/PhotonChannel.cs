using System;

// Token: 0x02000B2E RID: 2862
public class PhotonChannel
{
	// Token: 0x06004DB0 RID: 19888 RVA: 0x00149C9C File Offset: 0x00147E9C
	public PhotonChannel(int int_0, int int_1)
	{
		this.m_sendingInterval = int_0;
		this.m_priorityCeil = default(PhotonPriority);
		this.m_priorityCeil.priority = int_1;
	}

	// Token: 0x06004DB1 RID: 19889 RVA: 0x00032705 File Offset: 0x00030905
	public PhotonChannel(int int_0)
	{
		this.m_sendingInterval = int_0;
	}

	// Token: 0x04003A2F RID: 14895
	public PhotonPriority m_priorityCeil;

	// Token: 0x04003A30 RID: 14896
	public int m_sendingInterval;
}
