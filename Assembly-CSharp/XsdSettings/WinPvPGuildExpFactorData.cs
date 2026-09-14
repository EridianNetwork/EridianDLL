using System;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x020009C6 RID: 2502
	public class WinPvPGuildExpFactorData
	{
		// Token: 0x170005FA RID: 1530
		// (get) Token: 0x06004551 RID: 17745 RVA: 0x0002DDB9 File Offset: 0x0002BFB9
		// (set) Token: 0x06004552 RID: 17746 RVA: 0x0002DDC1 File Offset: 0x0002BFC1
		[XmlArrayItem("m_expRank", IsNullable = false)]
		public RankPvPGuildExpFactorData[] m_rankFactors { get; set; }

		// Token: 0x170005FB RID: 1531
		// (get) Token: 0x06004553 RID: 17747 RVA: 0x0002DDCA File Offset: 0x0002BFCA
		// (set) Token: 0x06004554 RID: 17748 RVA: 0x0002DDD2 File Offset: 0x0002BFD2
		public int m_basicExpValue { get; set; }

		// Token: 0x04003118 RID: 12568
		private RankPvPGuildExpFactorData[] m_rankFactorsField;
	}
}
