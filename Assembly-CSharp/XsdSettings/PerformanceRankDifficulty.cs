using System;

namespace XsdSettings
{
	// Token: 0x02000A17 RID: 2583
	public class PerformanceRankDifficulty
	{
		// Token: 0x060046F9 RID: 18169 RVA: 0x0002EB80 File Offset: 0x0002CD80
		public PerformanceRankDifficulty()
		{
			this.m_grade = "S";
		}

		// Token: 0x170006AC RID: 1708
		// (get) Token: 0x060046FA RID: 18170 RVA: 0x0002EB93 File Offset: 0x0002CD93
		// (set) Token: 0x060046FB RID: 18171 RVA: 0x0002EB9B File Offset: 0x0002CD9B
		public string m_grade { get; set; }

		// Token: 0x170006AD RID: 1709
		// (get) Token: 0x060046FC RID: 18172 RVA: 0x0002EBA4 File Offset: 0x0002CDA4
		// (set) Token: 0x060046FD RID: 18173 RVA: 0x0002EBAC File Offset: 0x0002CDAC
		public PerformanceRankPVE m_performanceRankNormal { get; set; }

		// Token: 0x170006AE RID: 1710
		// (get) Token: 0x060046FE RID: 18174 RVA: 0x0002EBB5 File Offset: 0x0002CDB5
		// (set) Token: 0x060046FF RID: 18175 RVA: 0x0002EBBD File Offset: 0x0002CDBD
		public PerformanceRankPVE m_performanceRankHard { get; set; }

		// Token: 0x170006AF RID: 1711
		// (get) Token: 0x06004700 RID: 18176 RVA: 0x0002EBC6 File Offset: 0x0002CDC6
		// (set) Token: 0x06004701 RID: 18177 RVA: 0x0002EBCE File Offset: 0x0002CDCE
		public PerformanceRankPVE m_performanceRankHell { get; set; }

		// Token: 0x040032B4 RID: 12980
		private PerformanceRankPVE m_performanceRankNormalField;

		// Token: 0x040032B5 RID: 12981
		private PerformanceRankPVE m_performanceRankHardField;

		// Token: 0x040032B6 RID: 12982
		private PerformanceRankPVE m_performanceRankHellField;
	}
}
