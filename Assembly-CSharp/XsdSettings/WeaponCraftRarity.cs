using System;

namespace XsdSettings
{
	// Token: 0x02000A7F RID: 2687
	public class WeaponCraftRarity
	{
		// Token: 0x17000763 RID: 1891
		// (get) Token: 0x060048C1 RID: 18625 RVA: 0x0002F8DF File Offset: 0x0002DADF
		// (set) Token: 0x060048C2 RID: 18626 RVA: 0x0002F8E7 File Offset: 0x0002DAE7
		public ItemRarity m_itemRarity { get; set; }

		// Token: 0x17000764 RID: 1892
		// (get) Token: 0x060048C3 RID: 18627 RVA: 0x0002F8F0 File Offset: 0x0002DAF0
		// (set) Token: 0x060048C4 RID: 18628 RVA: 0x0002F8F8 File Offset: 0x0002DAF8
		public int m_probability { get; set; }

		// Token: 0x04003564 RID: 13668
		private ItemRarity m_itemRarityField;
	}
}
