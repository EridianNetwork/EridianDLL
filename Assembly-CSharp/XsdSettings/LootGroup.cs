using System;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x020009D9 RID: 2521
	public class LootGroup
	{
		// Token: 0x17000622 RID: 1570
		// (get) Token: 0x060045B4 RID: 17844 RVA: 0x0002E142 File Offset: 0x0002C342
		// (set) Token: 0x060045B5 RID: 17845 RVA: 0x0002E14A File Offset: 0x0002C34A
		public string m_name { get; set; }

		// Token: 0x17000623 RID: 1571
		// (get) Token: 0x060045B6 RID: 17846 RVA: 0x0002E153 File Offset: 0x0002C353
		// (set) Token: 0x060045B7 RID: 17847 RVA: 0x0002E15B File Offset: 0x0002C35B
		[XmlArrayItem("m_loot", IsNullable = false)]
		public Loot[] m_lootList { get; set; }

		// Token: 0x04003153 RID: 12627
		private Loot[] m_lootListField;
	}
}
