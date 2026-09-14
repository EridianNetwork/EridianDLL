using System;

namespace XsdSettings
{
	// Token: 0x02000A42 RID: 2626
	public class WeightedWeaponType
	{
		// Token: 0x060047BD RID: 18365 RVA: 0x0002F1B6 File Offset: 0x0002D3B6
		public WeightedWeaponType()
		{
			this.m_weaponType = WeaponType.SMG;
			this.m_weight = 1f;
		}

		// Token: 0x170006FD RID: 1789
		// (get) Token: 0x060047BE RID: 18366 RVA: 0x0002F1D0 File Offset: 0x0002D3D0
		// (set) Token: 0x060047BF RID: 18367 RVA: 0x0002F1D8 File Offset: 0x0002D3D8
		public WeaponType m_weaponType { get; set; }

		// Token: 0x170006FE RID: 1790
		// (get) Token: 0x060047C0 RID: 18368 RVA: 0x0002F1E1 File Offset: 0x0002D3E1
		// (set) Token: 0x060047C1 RID: 18369 RVA: 0x0002F1E9 File Offset: 0x0002D3E9
		public float m_weight { get; set; }
	}
}
