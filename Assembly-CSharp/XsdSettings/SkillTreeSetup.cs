using System;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x02000A4E RID: 2638
	public class SkillTreeSetup
	{
		// Token: 0x17000714 RID: 1812
		// (get) Token: 0x060047F7 RID: 18423 RVA: 0x0002F366 File Offset: 0x0002D566
		// (set) Token: 0x060047F8 RID: 18424 RVA: 0x0002F36E File Offset: 0x0002D56E
		[XmlArrayItem("m_tree", IsNullable = false)]
		public SkillTree[] m_trees { get; set; }

		// Token: 0x04003444 RID: 13380
		private SkillTree[] m_treesField;
	}
}
