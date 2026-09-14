using System;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x02000A75 RID: 2677
	public class UI_WeaponCraftConfigContainer
	{
		// Token: 0x17000751 RID: 1873
		// (get) Token: 0x06004894 RID: 18580 RVA: 0x0002F797 File Offset: 0x0002D997
		// (set) Token: 0x06004895 RID: 18581 RVA: 0x0002F79F File Offset: 0x0002D99F
		[XmlArrayItem(IsNullable = false)]
		public UI_WeaponCraftConfig[] UI_WeaponCraftConfigList { get; set; }

		// Token: 0x04003544 RID: 13636
		private UI_WeaponCraftConfig[] uI_WeaponCraftConfigListField;
	}
}
