using System;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x02000A48 RID: 2632
	public class SkillSetup
	{
		// Token: 0x17000704 RID: 1796
		// (get) Token: 0x060047D2 RID: 18386 RVA: 0x0002F247 File Offset: 0x0002D447
		// (set) Token: 0x060047D3 RID: 18387 RVA: 0x0002F24F File Offset: 0x0002D44F
		[XmlArrayItem("m_skill", IsNullable = false)]
		public Skill[] m_skills { get; set; }

		// Token: 0x040033A1 RID: 13217
		private Skill[] m_skillsField;
	}
}
