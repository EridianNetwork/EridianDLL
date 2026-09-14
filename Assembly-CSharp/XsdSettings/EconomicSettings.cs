using System;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x020009B2 RID: 2482
	public class EconomicSettings
	{
		// Token: 0x170005C8 RID: 1480
		// (get) Token: 0x060044DA RID: 17626 RVA: 0x0002D9AF File Offset: 0x0002BBAF
		// (set) Token: 0x060044DB RID: 17627 RVA: 0x0002D9B7 File Offset: 0x0002BBB7
		[XmlArrayItem("m_itemPriceSetting", IsNullable = false)]
		public ItemPriceSetting[] m_priceSettings { get; set; }

		// Token: 0x040030CB RID: 12491
		private ItemPriceSetting[] m_priceSettingsField;
	}
}
