using System;

namespace XsdSettings
{
	// Token: 0x02000998 RID: 2456
	public class ItemSetup
	{
		// Token: 0x170005A5 RID: 1445
		// (get) Token: 0x0600447E RID: 17534 RVA: 0x0002D733 File Offset: 0x0002B933
		// (set) Token: 0x0600447F RID: 17535 RVA: 0x0002D73B File Offset: 0x0002B93B
		public int m_itemId { get; set; }

		// Token: 0x170005A6 RID: 1446
		// (get) Token: 0x06004480 RID: 17536 RVA: 0x0002D744 File Offset: 0x0002B944
		// (set) Token: 0x06004481 RID: 17537 RVA: 0x0002D74C File Offset: 0x0002B94C
		public ItemType m_itemType { get; set; }

		// Token: 0x04002FFA RID: 12282
		private ItemType m_itemTypeField;
	}
}
