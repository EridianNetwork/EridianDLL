using System;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x02000A51 RID: 2641
	public class NodeGroup
	{
		// Token: 0x1700071B RID: 1819
		// (get) Token: 0x06004808 RID: 18440 RVA: 0x0002F3DD File Offset: 0x0002D5DD
		// (set) Token: 0x06004809 RID: 18441 RVA: 0x0002F3E5 File Offset: 0x0002D5E5
		public int m_id { get; set; }

		// Token: 0x1700071C RID: 1820
		// (get) Token: 0x0600480A RID: 18442 RVA: 0x0002F3EE File Offset: 0x0002D5EE
		// (set) Token: 0x0600480B RID: 18443 RVA: 0x0002F3F6 File Offset: 0x0002D5F6
		[XmlArrayItem("m_node", IsNullable = false)]
		public SkillNode[] m_nodeList { get; set; }

		// Token: 0x0400344F RID: 13391
		private SkillNode[] m_nodeListField;
	}
}
