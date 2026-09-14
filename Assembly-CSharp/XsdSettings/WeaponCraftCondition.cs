using System;

namespace XsdSettings
{
	// Token: 0x02000A7E RID: 2686
	public class WeaponCraftCondition
	{
		// Token: 0x17000761 RID: 1889
		// (get) Token: 0x060048BC RID: 18620 RVA: 0x0002F8BD File Offset: 0x0002DABD
		// (set) Token: 0x060048BD RID: 18621 RVA: 0x0002F8C5 File Offset: 0x0002DAC5
		public MaterialType m_MatCondition { get; set; }

		// Token: 0x17000762 RID: 1890
		// (get) Token: 0x060048BE RID: 18622 RVA: 0x0002F8CE File Offset: 0x0002DACE
		// (set) Token: 0x060048BF RID: 18623 RVA: 0x0002F8D6 File Offset: 0x0002DAD6
		public int m_MatConditionQuantity { get; set; }

		// Token: 0x04003561 RID: 13665
		private MaterialType m_MatConditionField;
	}
}
