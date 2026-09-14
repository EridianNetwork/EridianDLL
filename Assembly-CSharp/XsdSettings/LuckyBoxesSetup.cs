using System;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x020009E7 RID: 2535
	public class LuckyBoxesSetup
	{
		// Token: 0x17000636 RID: 1590
		// (get) Token: 0x060045E8 RID: 17896 RVA: 0x0002E2D2 File Offset: 0x0002C4D2
		// (set) Token: 0x060045E9 RID: 17897 RVA: 0x0002E2DA File Offset: 0x0002C4DA
		[XmlArrayItem("m_box", IsNullable = false)]
		public BoxRank[] m_boxRanks { get; set; }

		// Token: 0x17000637 RID: 1591
		// (get) Token: 0x060045EA RID: 17898 RVA: 0x0002E2E3 File Offset: 0x0002C4E3
		// (set) Token: 0x060045EB RID: 17899 RVA: 0x0002E2EB File Offset: 0x0002C4EB
		[XmlArrayItem("m_luckyBox", IsNullable = false)]
		public LuckyBoxSettings[] m_luckyBoxes { get; set; }

		// Token: 0x040031AB RID: 12715
		private BoxRank[] m_boxRanksField;

		// Token: 0x040031AC RID: 12716
		private LuckyBoxSettings[] m_luckyBoxesField;
	}
}
