using System;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x020009F4 RID: 2548
	public class PlayerProgressionSetup
	{
		// Token: 0x17000649 RID: 1609
		// (get) Token: 0x06004618 RID: 17944 RVA: 0x0002E474 File Offset: 0x0002C674
		// (set) Token: 0x06004619 RID: 17945 RVA: 0x0002E47C File Offset: 0x0002C67C
		[XmlArrayItem("m_level", IsNullable = false)]
		public ProgressionData[] m_experienceTable { get; set; }

		// Token: 0x1700064A RID: 1610
		// (get) Token: 0x0600461A RID: 17946 RVA: 0x0002E485 File Offset: 0x0002C685
		// (set) Token: 0x0600461B RID: 17947 RVA: 0x0002E48D File Offset: 0x0002C68D
		public DefaultAttributeData m_defaultAttribute { get; set; }

		// Token: 0x040031DB RID: 12763
		private ProgressionData[] m_experienceTableField;

		// Token: 0x040031DC RID: 12764
		private DefaultAttributeData m_defaultAttributeField;
	}
}
