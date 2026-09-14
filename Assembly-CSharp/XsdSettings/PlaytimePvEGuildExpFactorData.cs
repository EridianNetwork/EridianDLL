using System;

namespace XsdSettings
{
	// Token: 0x020009CA RID: 2506
	public class PlaytimePvEGuildExpFactorData
	{
		// Token: 0x06004564 RID: 17764 RVA: 0x0002DE75 File Offset: 0x0002C075
		public PlaytimePvEGuildExpFactorData()
		{
			this.m_minTime = 0;
			this.m_maxTime = 0;
			this.m_expValue = 0;
		}

		// Token: 0x17000602 RID: 1538
		// (get) Token: 0x06004565 RID: 17765 RVA: 0x0002DE92 File Offset: 0x0002C092
		// (set) Token: 0x06004566 RID: 17766 RVA: 0x0002DE9A File Offset: 0x0002C09A
		public int m_minTime { get; set; }

		// Token: 0x17000603 RID: 1539
		// (get) Token: 0x06004567 RID: 17767 RVA: 0x0002DEA3 File Offset: 0x0002C0A3
		// (set) Token: 0x06004568 RID: 17768 RVA: 0x0002DEAB File Offset: 0x0002C0AB
		public int m_maxTime { get; set; }

		// Token: 0x17000604 RID: 1540
		// (get) Token: 0x06004569 RID: 17769 RVA: 0x0002DEB4 File Offset: 0x0002C0B4
		// (set) Token: 0x0600456A RID: 17770 RVA: 0x0002DEBC File Offset: 0x0002C0BC
		public int m_expValue { get; set; }
	}
}
