using System;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x02000A7D RID: 2685
	public class WeaponCraftConfig
	{
		// Token: 0x1700075B RID: 1883
		// (get) Token: 0x060048AF RID: 18607 RVA: 0x0002F857 File Offset: 0x0002DA57
		// (set) Token: 0x060048B0 RID: 18608 RVA: 0x0002F85F File Offset: 0x0002DA5F
		public int m_MinLevel { get; set; }

		// Token: 0x1700075C RID: 1884
		// (get) Token: 0x060048B1 RID: 18609 RVA: 0x0002F868 File Offset: 0x0002DA68
		// (set) Token: 0x060048B2 RID: 18610 RVA: 0x0002F870 File Offset: 0x0002DA70
		public int m_MaxLevel { get; set; }

		// Token: 0x1700075D RID: 1885
		// (get) Token: 0x060048B3 RID: 18611 RVA: 0x0002F879 File Offset: 0x0002DA79
		// (set) Token: 0x060048B4 RID: 18612 RVA: 0x0002F881 File Offset: 0x0002DA81
		public int m_Currency { get; set; }

		// Token: 0x1700075E RID: 1886
		// (get) Token: 0x060048B5 RID: 18613 RVA: 0x0002F88A File Offset: 0x0002DA8A
		// (set) Token: 0x060048B6 RID: 18614 RVA: 0x0002F892 File Offset: 0x0002DA92
		public WeaponType m_WeaponType { get; set; }

		// Token: 0x1700075F RID: 1887
		// (get) Token: 0x060048B7 RID: 18615 RVA: 0x0002F89B File Offset: 0x0002DA9B
		// (set) Token: 0x060048B8 RID: 18616 RVA: 0x0002F8A3 File Offset: 0x0002DAA3
		[XmlArrayItem("m_CraftCondition", IsNullable = false)]
		public WeaponCraftCondition[] m_CraftConditions { get; set; }

		// Token: 0x17000760 RID: 1888
		// (get) Token: 0x060048B9 RID: 18617 RVA: 0x0002F8AC File Offset: 0x0002DAAC
		// (set) Token: 0x060048BA RID: 18618 RVA: 0x0002F8B4 File Offset: 0x0002DAB4
		[XmlArrayItem("m_rarity", IsNullable = false)]
		public WeaponCraftRarity[] m_rarityList { get; set; }

		// Token: 0x04003558 RID: 13656
		private WeaponType m_WeaponTypeField;

		// Token: 0x04003559 RID: 13657
		private WeaponCraftCondition[] m_CraftConditionsField;

		// Token: 0x0400355A RID: 13658
		private WeaponCraftRarity[] m_rarityListField;
	}
}
