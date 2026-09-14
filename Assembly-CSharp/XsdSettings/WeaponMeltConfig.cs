using System;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x02000A84 RID: 2692
	public class WeaponMeltConfig
	{
		// Token: 0x060048D1 RID: 18641 RVA: 0x0002F945 File Offset: 0x0002DB45
		public WeaponMeltConfig()
		{
			this.m_cost = 0;
		}

		// Token: 0x17000769 RID: 1897
		// (get) Token: 0x060048D2 RID: 18642 RVA: 0x0002F954 File Offset: 0x0002DB54
		// (set) Token: 0x060048D3 RID: 18643 RVA: 0x0002F95C File Offset: 0x0002DB5C
		public int m_MinWeaponLevel { get; set; }

		// Token: 0x1700076A RID: 1898
		// (get) Token: 0x060048D4 RID: 18644 RVA: 0x0002F965 File Offset: 0x0002DB65
		// (set) Token: 0x060048D5 RID: 18645 RVA: 0x0002F96D File Offset: 0x0002DB6D
		public int m_MaxWeaponLevel { get; set; }

		// Token: 0x1700076B RID: 1899
		// (get) Token: 0x060048D6 RID: 18646 RVA: 0x0002F976 File Offset: 0x0002DB76
		// (set) Token: 0x060048D7 RID: 18647 RVA: 0x0002F97E File Offset: 0x0002DB7E
		public WeaponRarity m_WeaponRarity { get; set; }

		// Token: 0x1700076C RID: 1900
		// (get) Token: 0x060048D8 RID: 18648 RVA: 0x0002F987 File Offset: 0x0002DB87
		// (set) Token: 0x060048D9 RID: 18649 RVA: 0x0002F98F File Offset: 0x0002DB8F
		public WeaponType m_WeaponType { get; set; }

		// Token: 0x1700076D RID: 1901
		// (get) Token: 0x060048DA RID: 18650 RVA: 0x0002F998 File Offset: 0x0002DB98
		// (set) Token: 0x060048DB RID: 18651 RVA: 0x0002F9A0 File Offset: 0x0002DBA0
		public int m_cost { get; set; }

		// Token: 0x1700076E RID: 1902
		// (get) Token: 0x060048DC RID: 18652 RVA: 0x0002F9A9 File Offset: 0x0002DBA9
		// (set) Token: 0x060048DD RID: 18653 RVA: 0x0002F9B1 File Offset: 0x0002DBB1
		[XmlArrayItem("m_AcquiredMaterial", IsNullable = false)]
		public AcquiredMaterial[] m_AcquiredMaterials { get; set; }

		// Token: 0x0400356F RID: 13679
		private WeaponRarity m_WeaponRarityField;

		// Token: 0x04003570 RID: 13680
		private WeaponType m_WeaponTypeField;

		// Token: 0x04003571 RID: 13681
		private AcquiredMaterial[] m_AcquiredMaterialsField;
	}
}
