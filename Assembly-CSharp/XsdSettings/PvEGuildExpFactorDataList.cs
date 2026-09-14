using System;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x020009CB RID: 2507
	public class PvEGuildExpFactorDataList
	{
		// Token: 0x17000605 RID: 1541
		// (get) Token: 0x0600456C RID: 17772 RVA: 0x0002DEC5 File Offset: 0x0002C0C5
		// (set) Token: 0x0600456D RID: 17773 RVA: 0x0002DECD File Offset: 0x0002C0CD
		[XmlArrayItem("m_expPlaytime", IsNullable = false)]
		public PlaytimePvEGuildExpFactorData[] m_playtimeFactors { get; set; }

		// Token: 0x17000606 RID: 1542
		// (get) Token: 0x0600456E RID: 17774 RVA: 0x0002DED6 File Offset: 0x0002C0D6
		// (set) Token: 0x0600456F RID: 17775 RVA: 0x0002DEDE File Offset: 0x0002C0DE
		[XmlArrayItem("m_expScore", IsNullable = false)]
		public ScorePvEGuildExpFactorData[] m_scoreFactors { get; set; }

		// Token: 0x17000607 RID: 1543
		// (get) Token: 0x06004570 RID: 17776 RVA: 0x0002DEE7 File Offset: 0x0002C0E7
		// (set) Token: 0x06004571 RID: 17777 RVA: 0x0002DEEF File Offset: 0x0002C0EF
		[XmlArrayItem("m_expDifficulty", IsNullable = false)]
		public DifficultyPvEGuildExpFactorData[] m_difficultyFactors { get; set; }

		// Token: 0x04003126 RID: 12582
		private PlaytimePvEGuildExpFactorData[] m_playtimeFactorsField;

		// Token: 0x04003127 RID: 12583
		private ScorePvEGuildExpFactorData[] m_scoreFactorsField;

		// Token: 0x04003128 RID: 12584
		private DifficultyPvEGuildExpFactorData[] m_difficultyFactorsField;
	}
}
