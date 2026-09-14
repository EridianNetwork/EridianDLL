using System;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x02000A65 RID: 2661
	public class StarLevelUpgrade
	{
		// Token: 0x1700073D RID: 1853
		// (get) Token: 0x06004860 RID: 18528 RVA: 0x0002F61F File Offset: 0x0002D81F
		// (set) Token: 0x06004861 RID: 18529 RVA: 0x0002F627 File Offset: 0x0002D827
		public WeaponType m_weaponType { get; set; }

		// Token: 0x1700073E RID: 1854
		// (get) Token: 0x06004862 RID: 18530 RVA: 0x0002F630 File Offset: 0x0002D830
		// (set) Token: 0x06004863 RID: 18531 RVA: 0x0002F638 File Offset: 0x0002D838
		[XmlArrayItem("m_starLevelConfig", IsNullable = false)]
		public StarLevelConfig[] m_starLevelConfigList { get; set; }

		// Token: 0x04003487 RID: 13447
		private WeaponType m_weaponTypeField;

		// Token: 0x04003488 RID: 13448
		private StarLevelConfig[] m_starLevelConfigListField;
	}
}
