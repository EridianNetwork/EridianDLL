using System;

namespace XsdSettings
{
	// Token: 0x020009C5 RID: 2501
	public class RankPvPGuildExpFactorData
	{
		// Token: 0x06004549 RID: 17737 RVA: 0x0002DD69 File Offset: 0x0002BF69
		public RankPvPGuildExpFactorData()
		{
			this.m_rankNumber = 0;
			this.m_minPlayer = 1;
			this.m_expValue = 0;
		}

		// Token: 0x170005F7 RID: 1527
		// (get) Token: 0x0600454A RID: 17738 RVA: 0x0002DD86 File Offset: 0x0002BF86
		// (set) Token: 0x0600454B RID: 17739 RVA: 0x0002DD8E File Offset: 0x0002BF8E
		public int m_rankNumber { get; set; }

		// Token: 0x170005F8 RID: 1528
		// (get) Token: 0x0600454C RID: 17740 RVA: 0x0002DD97 File Offset: 0x0002BF97
		// (set) Token: 0x0600454D RID: 17741 RVA: 0x0002DD9F File Offset: 0x0002BF9F
		public int m_minPlayer { get; set; }

		// Token: 0x170005F9 RID: 1529
		// (get) Token: 0x0600454E RID: 17742 RVA: 0x0002DDA8 File Offset: 0x0002BFA8
		// (set) Token: 0x0600454F RID: 17743 RVA: 0x0002DDB0 File Offset: 0x0002BFB0
		public int m_expValue { get; set; }
	}
}
