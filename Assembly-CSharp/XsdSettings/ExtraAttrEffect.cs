using System;

namespace XsdSettings
{
	// Token: 0x020009B7 RID: 2487
	public class ExtraAttrEffect
	{
		// Token: 0x170005D0 RID: 1488
		// (get) Token: 0x060044EF RID: 17647 RVA: 0x0002DA67 File Offset: 0x0002BC67
		// (set) Token: 0x060044F0 RID: 17648 RVA: 0x0002DA6F File Offset: 0x0002BC6F
		public ItemRarity m_rarity { get; set; }

		// Token: 0x170005D1 RID: 1489
		// (get) Token: 0x060044F1 RID: 17649 RVA: 0x0002DA78 File Offset: 0x0002BC78
		// (set) Token: 0x060044F2 RID: 17650 RVA: 0x0002DA80 File Offset: 0x0002BC80
		public EffectType m_effect { get; set; }

		// Token: 0x170005D2 RID: 1490
		// (get) Token: 0x060044F3 RID: 17651 RVA: 0x0002DA89 File Offset: 0x0002BC89
		// (set) Token: 0x060044F4 RID: 17652 RVA: 0x0002DA91 File Offset: 0x0002BC91
		public byte m_index { get; set; }

		// Token: 0x170005D3 RID: 1491
		// (get) Token: 0x060044F5 RID: 17653 RVA: 0x0002DA9A File Offset: 0x0002BC9A
		// (set) Token: 0x060044F6 RID: 17654 RVA: 0x0002DAA2 File Offset: 0x0002BCA2
		public AffectType m_affectType { get; set; }

		// Token: 0x170005D4 RID: 1492
		// (get) Token: 0x060044F7 RID: 17655 RVA: 0x0002DAAB File Offset: 0x0002BCAB
		// (set) Token: 0x060044F8 RID: 17656 RVA: 0x0002DAB3 File Offset: 0x0002BCB3
		public float m_attributeValue { get; set; }

		// Token: 0x170005D5 RID: 1493
		// (get) Token: 0x060044F9 RID: 17657 RVA: 0x0002DABC File Offset: 0x0002BCBC
		// (set) Token: 0x060044FA RID: 17658 RVA: 0x0002DAC4 File Offset: 0x0002BCC4
		public int m_probability { get; set; }

		// Token: 0x170005D6 RID: 1494
		// (get) Token: 0x060044FB RID: 17659 RVA: 0x0002DACD File Offset: 0x0002BCCD
		// (set) Token: 0x060044FC RID: 17660 RVA: 0x0002DAD5 File Offset: 0x0002BCD5
		public string m_partName { get; set; }

		// Token: 0x170005D7 RID: 1495
		// (get) Token: 0x060044FD RID: 17661 RVA: 0x0002DADE File Offset: 0x0002BCDE
		// (set) Token: 0x060044FE RID: 17662 RVA: 0x0002DAE6 File Offset: 0x0002BCE6
		public int m_namePriority { get; set; }

		// Token: 0x170005D8 RID: 1496
		// (get) Token: 0x060044FF RID: 17663 RVA: 0x0002DAEF File Offset: 0x0002BCEF
		// (set) Token: 0x06004500 RID: 17664 RVA: 0x0002DAF7 File Offset: 0x0002BCF7
		public int m_minLevel { get; set; }

		// Token: 0x170005D9 RID: 1497
		// (get) Token: 0x06004501 RID: 17665 RVA: 0x0002DB00 File Offset: 0x0002BD00
		// (set) Token: 0x06004502 RID: 17666 RVA: 0x0002DB08 File Offset: 0x0002BD08
		public int m_maxLevel { get; set; }

		// Token: 0x040030D7 RID: 12503
		private ItemRarity m_rarityField;

		// Token: 0x040030D8 RID: 12504
		private EffectType m_effectField;

		// Token: 0x040030D9 RID: 12505
		private AffectType m_affectTypeField;
	}
}
