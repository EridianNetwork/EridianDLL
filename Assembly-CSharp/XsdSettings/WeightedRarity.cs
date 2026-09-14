using System;

namespace XsdSettings
{
	// Token: 0x02000A40 RID: 2624
	public class WeightedRarity
	{
		// Token: 0x060047B3 RID: 18355 RVA: 0x0002F13E File Offset: 0x0002D33E
		public WeightedRarity()
		{
			this.m_rarity = WeaponRarity.Common;
			this.m_weight = 1f;
		}

		// Token: 0x170006F9 RID: 1785
		// (get) Token: 0x060047B4 RID: 18356 RVA: 0x0002F158 File Offset: 0x0002D358
		// (set) Token: 0x060047B5 RID: 18357 RVA: 0x0002F160 File Offset: 0x0002D360
		public WeaponRarity m_rarity { get; set; }

		// Token: 0x170006FA RID: 1786
		// (get) Token: 0x060047B6 RID: 18358 RVA: 0x0002F169 File Offset: 0x0002D369
		// (set) Token: 0x060047B7 RID: 18359 RVA: 0x0002F171 File Offset: 0x0002D371
		public float m_weight { get; set; }
	}
}
