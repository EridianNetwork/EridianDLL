using System;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x02000A1D RID: 2589
	public class ScoringSetupPVE : ScoringBase
	{
		// Token: 0x170006BE RID: 1726
		// (get) Token: 0x06004722 RID: 18210 RVA: 0x0002ECF2 File Offset: 0x0002CEF2
		// (set) Token: 0x06004723 RID: 18211 RVA: 0x0002ECFA File Offset: 0x0002CEFA
		[XmlArrayItem("m_performanceRank", IsNullable = false)]
		public PerformanceRankDifficulty[] m_performanceRankBonus { get; set; }

		// Token: 0x170006BF RID: 1727
		// (get) Token: 0x06004724 RID: 18212 RVA: 0x0002ED03 File Offset: 0x0002CF03
		// (set) Token: 0x06004725 RID: 18213 RVA: 0x0002ED0B File Offset: 0x0002CF0B
		[XmlArrayItem("m_levelAdjustment", IsNullable = false)]
		public LevelAdjustmentData[] m_levelAdjustments { get; set; }

		// Token: 0x170006C0 RID: 1728
		// (get) Token: 0x06004726 RID: 18214 RVA: 0x0002ED14 File Offset: 0x0002CF14
		// (set) Token: 0x06004727 RID: 18215 RVA: 0x0002ED1C File Offset: 0x0002CF1C
		public float m_timeScoreConversionRate { get; set; }

		// Token: 0x170006C1 RID: 1729
		// (get) Token: 0x06004728 RID: 18216 RVA: 0x0002ED25 File Offset: 0x0002CF25
		// (set) Token: 0x06004729 RID: 18217 RVA: 0x0002ED2D File Offset: 0x0002CF2D
		[XmlArrayItem("m_killScore", IsNullable = false)]
		public KillScoreType[] m_killScores { get; set; }

		// Token: 0x040032FF RID: 13055
		private PerformanceRankDifficulty[] m_performanceRankBonusField;

		// Token: 0x04003300 RID: 13056
		private LevelAdjustmentData[] m_levelAdjustmentsField;

		// Token: 0x04003301 RID: 13057
		private KillScoreType[] m_killScoresField;
	}
}
