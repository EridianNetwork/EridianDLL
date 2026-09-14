using System;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x02000A7C RID: 2684
	public class WeaponCraftManager
	{
		// Token: 0x1700075A RID: 1882
		// (get) Token: 0x060048AC RID: 18604 RVA: 0x0002F846 File Offset: 0x0002DA46
		// (set) Token: 0x060048AD RID: 18605 RVA: 0x0002F84E File Offset: 0x0002DA4E
		[XmlArrayItem("m_WeaponCraftConfig", IsNullable = false)]
		public WeaponCraftConfig[] m_WeaponCraftConfigs { get; set; }

		// Token: 0x04003556 RID: 13654
		private WeaponCraftConfig[] m_WeaponCraftConfigsField;
	}
}
