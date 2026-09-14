using System;

namespace XsdSettings
{
	// Token: 0x020009C7 RID: 2503
	public class PvPGuildExpFactorDataList
	{
		// Token: 0x170005FC RID: 1532
		// (get) Token: 0x06004556 RID: 17750 RVA: 0x0002DDDB File Offset: 0x0002BFDB
		// (set) Token: 0x06004557 RID: 17751 RVA: 0x0002DDE3 File Offset: 0x0002BFE3
		public WinPvPGuildExpFactorData m_expWinFactor { get; set; }

		// Token: 0x170005FD RID: 1533
		// (get) Token: 0x06004558 RID: 17752 RVA: 0x0002DDEC File Offset: 0x0002BFEC
		// (set) Token: 0x06004559 RID: 17753 RVA: 0x0002DDF4 File Offset: 0x0002BFF4
		public LosePvPGuildExpFactorData m_expLoseFactor { get; set; }

		// Token: 0x0400311B RID: 12571
		private WinPvPGuildExpFactorData m_expWinFactorField;

		// Token: 0x0400311C RID: 12572
		private LosePvPGuildExpFactorData m_expLoseFactorField;
	}
}
