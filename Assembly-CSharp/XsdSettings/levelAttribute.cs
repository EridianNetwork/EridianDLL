using System;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x02000A5D RID: 2653
	public class levelAttribute
	{
		// Token: 0x1700072B RID: 1835
		// (get) Token: 0x06004834 RID: 18484 RVA: 0x0002F4ED File Offset: 0x0002D6ED
		// (set) Token: 0x06004835 RID: 18485 RVA: 0x0002F4F5 File Offset: 0x0002D6F5
		public int m_starLevel { get; set; }

		// Token: 0x1700072C RID: 1836
		// (get) Token: 0x06004836 RID: 18486 RVA: 0x0002F4FE File Offset: 0x0002D6FE
		// (set) Token: 0x06004837 RID: 18487 RVA: 0x0002F506 File Offset: 0x0002D706
		[XmlArrayItem("m_weaponAttribute", IsNullable = false)]
		public SingleWeaponAttribute[] m_weaponAttributeList { get; set; }

		// Token: 0x0400346B RID: 13419
		private SingleWeaponAttribute[] m_weaponAttributeListField;
	}
}
