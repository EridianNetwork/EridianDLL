using System;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x020009DD RID: 2525
	public class LootingSubType
	{
		// Token: 0x1700062C RID: 1580
		// (get) Token: 0x060045CC RID: 17868 RVA: 0x0002E228 File Offset: 0x0002C428
		// (set) Token: 0x060045CD RID: 17869 RVA: 0x0002E230 File Offset: 0x0002C430
		public ELootingSubType m_lootingSubType { get; set; }

		// Token: 0x1700062D RID: 1581
		// (get) Token: 0x060045CE RID: 17870 RVA: 0x0002E239 File Offset: 0x0002C439
		// (set) Token: 0x060045CF RID: 17871 RVA: 0x0002E241 File Offset: 0x0002C441
		[XmlArrayItem("m_lootingLevelRange", typeof(LootingLevelRange), IsNullable = false)]
		public LootingLevelRange[] m_lootingLevelRangeList { get; set; }

		// Token: 0x04003160 RID: 12640
		private ELootingSubType m_lootingSubTypeField;

		// Token: 0x04003161 RID: 12641
		private LootingLevelRange[] m_lootingLevelRangeListField;
	}
}
