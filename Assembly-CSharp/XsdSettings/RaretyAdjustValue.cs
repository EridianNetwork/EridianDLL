using System;

namespace XsdSettings
{
	// Token: 0x020009B4 RID: 2484
	public class RaretyAdjustValue
	{
		// Token: 0x060044E3 RID: 17635 RVA: 0x0002DA09 File Offset: 0x0002BC09
		public RaretyAdjustValue()
		{
			this.m_rarety = WeaponRarity.Common;
			this.m_adjustValue = 0f;
		}

		// Token: 0x170005CC RID: 1484
		// (get) Token: 0x060044E4 RID: 17636 RVA: 0x0002DA23 File Offset: 0x0002BC23
		// (set) Token: 0x060044E5 RID: 17637 RVA: 0x0002DA2B File Offset: 0x0002BC2B
		public WeaponRarity m_rarety { get; set; }

		// Token: 0x170005CD RID: 1485
		// (get) Token: 0x060044E6 RID: 17638 RVA: 0x0002DA34 File Offset: 0x0002BC34
		// (set) Token: 0x060044E7 RID: 17639 RVA: 0x0002DA3C File Offset: 0x0002BC3C
		public float m_adjustValue { get; set; }
	}
}
