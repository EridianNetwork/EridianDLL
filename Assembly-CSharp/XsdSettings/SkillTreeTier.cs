using System;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x02000A50 RID: 2640
	public class SkillTreeTier
	{
		// Token: 0x17000718 RID: 1816
		// (get) Token: 0x06004801 RID: 18433 RVA: 0x0002F3AA File Offset: 0x0002D5AA
		// (set) Token: 0x06004802 RID: 18434 RVA: 0x0002F3B2 File Offset: 0x0002D5B2
		public int m_id { get; set; }

		// Token: 0x17000719 RID: 1817
		// (get) Token: 0x06004803 RID: 18435 RVA: 0x0002F3BB File Offset: 0x0002D5BB
		// (set) Token: 0x06004804 RID: 18436 RVA: 0x0002F3C3 File Offset: 0x0002D5C3
		public int m_pointToUnlockNextTier { get; set; }

		// Token: 0x1700071A RID: 1818
		// (get) Token: 0x06004805 RID: 18437 RVA: 0x0002F3CC File Offset: 0x0002D5CC
		// (set) Token: 0x06004806 RID: 18438 RVA: 0x0002F3D4 File Offset: 0x0002D5D4
		[XmlArrayItem("m_nodeGroup", IsNullable = false)]
		public NodeGroup[] m_nodeGroupList { get; set; }

		// Token: 0x0400344B RID: 13387
		private NodeGroup[] m_nodeGroupListField;
	}
}
