using System;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x02000A83 RID: 2691
	public class WeaponMeltManager
	{
		// Token: 0x17000768 RID: 1896
		// (get) Token: 0x060048CF RID: 18639 RVA: 0x0002F934 File Offset: 0x0002DB34
		// (set) Token: 0x060048D0 RID: 18640 RVA: 0x0002F93C File Offset: 0x0002DB3C
		[XmlArrayItem("m_WeaponMeltConfig", IsNullable = false)]
		public WeaponMeltConfig[] m_WeaponMeltConfigs { get; set; }

		// Token: 0x0400356D RID: 13677
		private WeaponMeltConfig[] m_WeaponMeltConfigsField;
	}
}
