using System;
using System.ComponentModel;

namespace XsdSettings
{
	// Token: 0x020009D8 RID: 2520
	public class DefaultLootQuantity
	{
		// Token: 0x060045AA RID: 17834 RVA: 0x0002E0E0 File Offset: 0x0002C2E0
		public DefaultLootQuantity()
		{
			this.m_lootDefaultQuantity = 1;
			this.m_materialType = MaterialType.TOTAL;
			this.m_ammoType = AmmoType.TOTAL;
		}

		// Token: 0x1700061E RID: 1566
		// (get) Token: 0x060045AB RID: 17835 RVA: 0x0002E0FE File Offset: 0x0002C2FE
		// (set) Token: 0x060045AC RID: 17836 RVA: 0x0002E106 File Offset: 0x0002C306
		public ItemType m_lootType { get; set; }

		// Token: 0x1700061F RID: 1567
		// (get) Token: 0x060045AD RID: 17837 RVA: 0x0002E10F File Offset: 0x0002C30F
		// (set) Token: 0x060045AE RID: 17838 RVA: 0x0002E117 File Offset: 0x0002C317
		public int m_lootDefaultQuantity { get; set; }

		// Token: 0x17000620 RID: 1568
		// (get) Token: 0x060045AF RID: 17839 RVA: 0x0002E120 File Offset: 0x0002C320
		// (set) Token: 0x060045B0 RID: 17840 RVA: 0x0002E128 File Offset: 0x0002C328
		[DefaultValue(MaterialType.TOTAL)]
		public MaterialType m_materialType { get; set; }

		// Token: 0x17000621 RID: 1569
		// (get) Token: 0x060045B1 RID: 17841 RVA: 0x0002E131 File Offset: 0x0002C331
		// (set) Token: 0x060045B2 RID: 17842 RVA: 0x0002E139 File Offset: 0x0002C339
		[DefaultValue(AmmoType.TOTAL)]
		public AmmoType m_ammoType { get; set; }

		// Token: 0x0400314E RID: 12622
		private ItemType m_lootTypeField;
	}
}
