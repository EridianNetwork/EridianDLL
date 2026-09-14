using System;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x02000A5C RID: 2652
	public class StarLevelAttribute
	{
		// Token: 0x17000729 RID: 1833
		// (get) Token: 0x0600482F RID: 18479 RVA: 0x0002F4CB File Offset: 0x0002D6CB
		// (set) Token: 0x06004830 RID: 18480 RVA: 0x0002F4D3 File Offset: 0x0002D6D3
		public WeaponType m_weaponType { get; set; }

		// Token: 0x1700072A RID: 1834
		// (get) Token: 0x06004831 RID: 18481 RVA: 0x0002F4DC File Offset: 0x0002D6DC
		// (set) Token: 0x06004832 RID: 18482 RVA: 0x0002F4E4 File Offset: 0x0002D6E4
		[XmlArrayItem("m_levelAttribute", IsNullable = false)]
		public levelAttribute[] m_levelAttributeList { get; set; }

		// Token: 0x04003467 RID: 13415
		private WeaponType m_weaponTypeField;

		// Token: 0x04003468 RID: 13416
		private levelAttribute[] m_levelAttributeListField;
	}
}
