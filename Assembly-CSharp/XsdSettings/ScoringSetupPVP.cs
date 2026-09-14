using System;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x02000A1E RID: 2590
	public class ScoringSetupPVP : ScoringBase
	{
		// Token: 0x170006C2 RID: 1730
		// (get) Token: 0x0600472B RID: 18219 RVA: 0x0002ED36 File Offset: 0x0002CF36
		// (set) Token: 0x0600472C RID: 18220 RVA: 0x0002ED3E File Offset: 0x0002CF3E
		public int m_honorWinBonus { get; set; }

		// Token: 0x170006C3 RID: 1731
		// (get) Token: 0x0600472D RID: 18221 RVA: 0x0002ED47 File Offset: 0x0002CF47
		// (set) Token: 0x0600472E RID: 18222 RVA: 0x0002ED4F File Offset: 0x0002CF4F
		public int m_honorStandardReward { get; set; }

		// Token: 0x170006C4 RID: 1732
		// (get) Token: 0x0600472F RID: 18223 RVA: 0x0002ED58 File Offset: 0x0002CF58
		// (set) Token: 0x06004730 RID: 18224 RVA: 0x0002ED60 File Offset: 0x0002CF60
		public float m_expStandardReward { get; set; }

		// Token: 0x170006C5 RID: 1733
		// (get) Token: 0x06004731 RID: 18225 RVA: 0x0002ED69 File Offset: 0x0002CF69
		// (set) Token: 0x06004732 RID: 18226 RVA: 0x0002ED71 File Offset: 0x0002CF71
		[XmlArrayItem("m_performanceRank", IsNullable = false)]
		public PerformanceRankPVP[] m_performanceRankBonus { get; set; }

		// Token: 0x170006C6 RID: 1734
		// (get) Token: 0x06004733 RID: 18227 RVA: 0x0002ED7A File Offset: 0x0002CF7A
		// (set) Token: 0x06004734 RID: 18228 RVA: 0x0002ED82 File Offset: 0x0002CF82
		[XmlArrayItem("m_scoringAction", IsNullable = false)]
		public ScoringAction[] m_scoringActions { get; set; }

		// Token: 0x04003306 RID: 13062
		private PerformanceRankPVP[] m_performanceRankBonusField;

		// Token: 0x04003307 RID: 13063
		private ScoringAction[] m_scoringActionsField;
	}
}
