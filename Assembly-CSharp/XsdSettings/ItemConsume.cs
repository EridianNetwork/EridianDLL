using System;

namespace XsdSettings
{
	// Token: 0x02000A63 RID: 2659
	public class ItemConsume
	{
		// Token: 0x17000735 RID: 1845
		// (get) Token: 0x0600484E RID: 18510 RVA: 0x0002F597 File Offset: 0x0002D797
		// (set) Token: 0x0600484F RID: 18511 RVA: 0x0002F59F File Offset: 0x0002D79F
		public ItemType m_itemType { get; set; }

		// Token: 0x17000736 RID: 1846
		// (get) Token: 0x06004850 RID: 18512 RVA: 0x0002F5A8 File Offset: 0x0002D7A8
		// (set) Token: 0x06004851 RID: 18513 RVA: 0x0002F5B0 File Offset: 0x0002D7B0
		public int m_itemNums { get; set; }

		// Token: 0x17000737 RID: 1847
		// (get) Token: 0x06004852 RID: 18514 RVA: 0x0002F5B9 File Offset: 0x0002D7B9
		// (set) Token: 0x06004853 RID: 18515 RVA: 0x0002F5C1 File Offset: 0x0002D7C1
		public MaterialType m_materialType { get; set; }

		// Token: 0x17000738 RID: 1848
		// (get) Token: 0x06004854 RID: 18516 RVA: 0x0002F5CA File Offset: 0x0002D7CA
		// (set) Token: 0x06004855 RID: 18517 RVA: 0x0002F5D2 File Offset: 0x0002D7D2
		public int m_materialNums { get; set; }

		// Token: 0x0400347C RID: 13436
		private ItemType m_itemTypeField;

		// Token: 0x0400347D RID: 13437
		private MaterialType m_materialTypeField;
	}
}
