using System;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x020009DA RID: 2522
	public class LootGroups
	{
		// Token: 0x17000624 RID: 1572
		// (get) Token: 0x060045B9 RID: 17849 RVA: 0x0002E164 File Offset: 0x0002C364
		// (set) Token: 0x060045BA RID: 17850 RVA: 0x0002E16C File Offset: 0x0002C36C
		public string m_name { get; set; }

		// Token: 0x17000625 RID: 1573
		// (get) Token: 0x060045BB RID: 17851 RVA: 0x0002E175 File Offset: 0x0002C375
		// (set) Token: 0x060045BC RID: 17852 RVA: 0x0002E17D File Offset: 0x0002C37D
		[XmlArrayItem("m_lootGroup", IsNullable = false)]
		public LootGroup[] m_lootGroupList { get; set; }

		// Token: 0x04003156 RID: 12630
		private LootGroup[] m_lootGroupListField;
	}
}
