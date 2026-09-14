using System;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x02000A4F RID: 2639
	public class SkillTree
	{
		// Token: 0x17000715 RID: 1813
		// (get) Token: 0x060047FA RID: 18426 RVA: 0x0002F377 File Offset: 0x0002D577
		// (set) Token: 0x060047FB RID: 18427 RVA: 0x0002F37F File Offset: 0x0002D57F
		public AvatarType m_avatarType { get; set; }

		// Token: 0x17000716 RID: 1814
		// (get) Token: 0x060047FC RID: 18428 RVA: 0x0002F388 File Offset: 0x0002D588
		// (set) Token: 0x060047FD RID: 18429 RVA: 0x0002F390 File Offset: 0x0002D590
		[XmlArrayItem("m_tier", typeof(SkillTreeTier), IsNullable = false)]
		public SkillTreeTier[] m_tierList { get; set; }

		// Token: 0x17000717 RID: 1815
		// (get) Token: 0x060047FE RID: 18430 RVA: 0x0002F399 File Offset: 0x0002D599
		// (set) Token: 0x060047FF RID: 18431 RVA: 0x0002F3A1 File Offset: 0x0002D5A1
		[XmlArrayItem("m_name", IsNullable = false)]
		public string[] m_groupNameList { get; set; }

		// Token: 0x04003446 RID: 13382
		private AvatarType m_avatarTypeField;

		// Token: 0x04003447 RID: 13383
		private SkillTreeTier[] m_tierListField;
	}
}
