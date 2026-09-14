using System;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x020009B3 RID: 2483
	public class ItemPriceSetting
	{
		// Token: 0x060044DC RID: 17628 RVA: 0x0002D9C0 File Offset: 0x0002BBC0
		public ItemPriceSetting()
		{
			this.m_itemType = ItemType.Weapon;
			this.m_basicValue = 0;
		}

		// Token: 0x170005C9 RID: 1481
		// (get) Token: 0x060044DD RID: 17629 RVA: 0x0002D9D6 File Offset: 0x0002BBD6
		// (set) Token: 0x060044DE RID: 17630 RVA: 0x0002D9DE File Offset: 0x0002BBDE
		public ItemType m_itemType { get; set; }

		// Token: 0x170005CA RID: 1482
		// (get) Token: 0x060044DF RID: 17631 RVA: 0x0002D9E7 File Offset: 0x0002BBE7
		// (set) Token: 0x060044E0 RID: 17632 RVA: 0x0002D9EF File Offset: 0x0002BBEF
		public int m_basicValue { get; set; }

		// Token: 0x170005CB RID: 1483
		// (get) Token: 0x060044E1 RID: 17633 RVA: 0x0002D9F8 File Offset: 0x0002BBF8
		// (set) Token: 0x060044E2 RID: 17634 RVA: 0x0002DA00 File Offset: 0x0002BC00
		[XmlArrayItem("m_raretyAdjustValue", IsNullable = false)]
		public RaretyAdjustValue[] m_adjustements { get; set; }

		// Token: 0x040030CD RID: 12493
		private RaretyAdjustValue[] m_adjustementsField;
	}
}
