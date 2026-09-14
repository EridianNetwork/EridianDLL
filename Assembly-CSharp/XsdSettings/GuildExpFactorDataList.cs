using System;

namespace XsdSettings
{
	// Token: 0x020009CC RID: 2508
	public class GuildExpFactorDataList
	{
		// Token: 0x17000608 RID: 1544
		// (get) Token: 0x06004573 RID: 17779 RVA: 0x0002DEF8 File Offset: 0x0002C0F8
		// (set) Token: 0x06004574 RID: 17780 RVA: 0x0002DF00 File Offset: 0x0002C100
		public PvEGuildExpFactorDataList m_PvEGuildExpFactors { get; set; }

		// Token: 0x17000609 RID: 1545
		// (get) Token: 0x06004575 RID: 17781 RVA: 0x0002DF09 File Offset: 0x0002C109
		// (set) Token: 0x06004576 RID: 17782 RVA: 0x0002DF11 File Offset: 0x0002C111
		public PvPGuildExpFactorDataList m_PvPGuildExpFactors { get; set; }

		// Token: 0x0400312C RID: 12588
		private PvEGuildExpFactorDataList m_PvEGuildExpFactorsField;

		// Token: 0x0400312D RID: 12589
		private PvPGuildExpFactorDataList m_PvPGuildExpFactorsField;
	}
}
