using System;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x02000A3F RID: 2623
	public class ItemAvailabilitySettings
	{
		// Token: 0x060047AA RID: 18346 RVA: 0x0002F0EB File Offset: 0x0002D2EB
		public ItemAvailabilitySettings()
		{
			this.m_itemType = ItemType.Weapon;
		}

		// Token: 0x170006F5 RID: 1781
		// (get) Token: 0x060047AB RID: 18347 RVA: 0x0002F0FA File Offset: 0x0002D2FA
		// (set) Token: 0x060047AC RID: 18348 RVA: 0x0002F102 File Offset: 0x0002D302
		public ItemType m_itemType { get; set; }

		// Token: 0x170006F6 RID: 1782
		// (get) Token: 0x060047AD RID: 18349 RVA: 0x0002F10B File Offset: 0x0002D30B
		// (set) Token: 0x060047AE RID: 18350 RVA: 0x0002F113 File Offset: 0x0002D313
		[XmlArrayItem("m_weightedRarity", IsNullable = false)]
		public WeightedRarity[] m_rarityDistribution { get; set; }

		// Token: 0x170006F7 RID: 1783
		// (get) Token: 0x060047AF RID: 18351 RVA: 0x0002F11C File Offset: 0x0002D31C
		// (set) Token: 0x060047B0 RID: 18352 RVA: 0x0002F124 File Offset: 0x0002D324
		[XmlArrayItem("m_weightedWeaponType", IsNullable = false)]
		public WeightedWeaponType[] m_weaponDistribution { get; set; }

		// Token: 0x170006F8 RID: 1784
		// (get) Token: 0x060047B1 RID: 18353 RVA: 0x0002F12D File Offset: 0x0002D32D
		// (set) Token: 0x060047B2 RID: 18354 RVA: 0x0002F135 File Offset: 0x0002D335
		[XmlArrayItem("m_weightedModType", IsNullable = false)]
		public WeightedModType[] m_modDistribution { get; set; }

		// Token: 0x0400338A RID: 13194
		private WeightedRarity[] m_rarityDistributionField;

		// Token: 0x0400338B RID: 13195
		private WeightedWeaponType[] m_weaponDistributionField;

		// Token: 0x0400338C RID: 13196
		private WeightedModType[] m_modDistributionField;
	}
}
