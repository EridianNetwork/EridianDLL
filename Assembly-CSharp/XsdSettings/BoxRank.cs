using System;

namespace XsdSettings
{
	// Token: 0x020009E8 RID: 2536
	public class BoxRank
	{
		// Token: 0x060045EC RID: 17900 RVA: 0x0002E2F4 File Offset: 0x0002C4F4
		public BoxRank()
		{
			this.m_rank = LuckyBoxRank.Platinum;
			this.m_keyRank = LuckyBoxRank.None;
			this.m_keyCount = 0;
		}

		// Token: 0x17000638 RID: 1592
		// (get) Token: 0x060045ED RID: 17901 RVA: 0x0002E311 File Offset: 0x0002C511
		// (set) Token: 0x060045EE RID: 17902 RVA: 0x0002E319 File Offset: 0x0002C519
		public LuckyBoxRank m_rank { get; set; }

		// Token: 0x17000639 RID: 1593
		// (get) Token: 0x060045EF RID: 17903 RVA: 0x0002E322 File Offset: 0x0002C522
		// (set) Token: 0x060045F0 RID: 17904 RVA: 0x0002E32A File Offset: 0x0002C52A
		public LuckyBoxRank m_keyRank { get; set; }

		// Token: 0x1700063A RID: 1594
		// (get) Token: 0x060045F1 RID: 17905 RVA: 0x0002E333 File Offset: 0x0002C533
		// (set) Token: 0x060045F2 RID: 17906 RVA: 0x0002E33B File Offset: 0x0002C53B
		public int m_keyCount { get; set; }
	}
}
