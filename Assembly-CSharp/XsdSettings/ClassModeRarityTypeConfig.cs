using System;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x0200099E RID: 2462
	public class ClassModeRarityTypeConfig
	{
		// Token: 0x170005AD RID: 1453
		// (get) Token: 0x06004494 RID: 17556 RVA: 0x0002D7BB File Offset: 0x0002B9BB
		// (set) Token: 0x06004495 RID: 17557 RVA: 0x0002D7C3 File Offset: 0x0002B9C3
		public ItemRarity m_rarity { get; set; }

		// Token: 0x170005AE RID: 1454
		// (get) Token: 0x06004496 RID: 17558 RVA: 0x0002D7CC File Offset: 0x0002B9CC
		// (set) Token: 0x06004497 RID: 17559 RVA: 0x0002D7D4 File Offset: 0x0002B9D4
		[XmlArrayItem("m_subpartsInRarity", IsNullable = false)]
		public ClassModeSubpartsInRarity[] m_subparts { get; set; }

		// Token: 0x04003009 RID: 12297
		private ItemRarity m_rarityField;

		// Token: 0x0400300A RID: 12298
		private ClassModeSubpartsInRarity[] m_subpartsField;
	}
}
