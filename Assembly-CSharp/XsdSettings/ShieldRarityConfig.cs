using System;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x02000A36 RID: 2614
	public class ShieldRarityConfig
	{
		// Token: 0x170006E7 RID: 1767
		// (get) Token: 0x06004787 RID: 18311 RVA: 0x0002EFD0 File Offset: 0x0002D1D0
		// (set) Token: 0x06004788 RID: 18312 RVA: 0x0002EFD8 File Offset: 0x0002D1D8
		public ShieldRarity m_rarity { get; set; }

		// Token: 0x170006E8 RID: 1768
		// (get) Token: 0x06004789 RID: 18313 RVA: 0x0002EFE1 File Offset: 0x0002D1E1
		// (set) Token: 0x0600478A RID: 18314 RVA: 0x0002EFE9 File Offset: 0x0002D1E9
		[XmlArrayItem("m_subpartsInRarity", IsNullable = false)]
		public ShieldSubpartsInRarity[] m_subparts { get; set; }

		// Token: 0x0400336B RID: 13163
		private ShieldRarity m_rarityField;

		// Token: 0x0400336C RID: 13164
		private ShieldSubpartsInRarity[] m_subpartsField;
	}
}
