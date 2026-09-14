using System;

namespace XsdSettings
{
	// Token: 0x020009E9 RID: 2537
	public class RewardPerGrade
	{
		// Token: 0x060045F3 RID: 17907 RVA: 0x0002E344 File Offset: 0x0002C544
		public RewardPerGrade()
		{
			this.m_grade = InstanceGrade.S;
			this.m_normalRank = LuckyBoxRank.Platinum;
			this.m_normalReward = "KimBox";
			this.m_lockedRank = LuckyBoxRank.Diamond;
			this.m_lockedReward = "KimBox";
		}

		// Token: 0x1700063B RID: 1595
		// (get) Token: 0x060045F4 RID: 17908 RVA: 0x0002E377 File Offset: 0x0002C577
		// (set) Token: 0x060045F5 RID: 17909 RVA: 0x0002E37F File Offset: 0x0002C57F
		public InstanceGrade m_grade { get; set; }

		// Token: 0x1700063C RID: 1596
		// (get) Token: 0x060045F6 RID: 17910 RVA: 0x0002E388 File Offset: 0x0002C588
		// (set) Token: 0x060045F7 RID: 17911 RVA: 0x0002E390 File Offset: 0x0002C590
		public LuckyBoxRank m_normalRank { get; set; }

		// Token: 0x1700063D RID: 1597
		// (get) Token: 0x060045F8 RID: 17912 RVA: 0x0002E399 File Offset: 0x0002C599
		// (set) Token: 0x060045F9 RID: 17913 RVA: 0x0002E3A1 File Offset: 0x0002C5A1
		public string m_normalReward { get; set; }

		// Token: 0x1700063E RID: 1598
		// (get) Token: 0x060045FA RID: 17914 RVA: 0x0002E3AA File Offset: 0x0002C5AA
		// (set) Token: 0x060045FB RID: 17915 RVA: 0x0002E3B2 File Offset: 0x0002C5B2
		public LuckyBoxRank m_lockedRank { get; set; }

		// Token: 0x1700063F RID: 1599
		// (get) Token: 0x060045FC RID: 17916 RVA: 0x0002E3BB File Offset: 0x0002C5BB
		// (set) Token: 0x060045FD RID: 17917 RVA: 0x0002E3C3 File Offset: 0x0002C5C3
		public string m_lockedReward { get; set; }
	}
}
