using System;

namespace XsdSettings
{
	// Token: 0x020009BB RID: 2491
	public class ExtraAttrSlot
	{
		// Token: 0x170005E1 RID: 1505
		// (get) Token: 0x06004515 RID: 17685 RVA: 0x0002DB88 File Offset: 0x0002BD88
		// (set) Token: 0x06004516 RID: 17686 RVA: 0x0002DB90 File Offset: 0x0002BD90
		public ItemRarity m_rarity { get; set; }

		// Token: 0x170005E2 RID: 1506
		// (get) Token: 0x06004517 RID: 17687 RVA: 0x0002DB99 File Offset: 0x0002BD99
		// (set) Token: 0x06004518 RID: 17688 RVA: 0x0002DBA1 File Offset: 0x0002BDA1
		public int m_slotNum { get; set; }

		// Token: 0x170005E3 RID: 1507
		// (get) Token: 0x06004519 RID: 17689 RVA: 0x0002DBAA File Offset: 0x0002BDAA
		// (set) Token: 0x0600451A RID: 17690 RVA: 0x0002DBB2 File Offset: 0x0002BDB2
		public int m_probability { get; set; }

		// Token: 0x040030EF RID: 12527
		private ItemRarity m_rarityField;
	}
}
