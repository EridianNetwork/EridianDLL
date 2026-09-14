using System;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x020009DF RID: 2527
	public class Looting
	{
		// Token: 0x1700062E RID: 1582
		// (get) Token: 0x060045D1 RID: 17873 RVA: 0x0002E24A File Offset: 0x0002C44A
		// (set) Token: 0x060045D2 RID: 17874 RVA: 0x0002E252 File Offset: 0x0002C452
		public ELootingType m_lootingType { get; set; }

		// Token: 0x1700062F RID: 1583
		// (get) Token: 0x060045D3 RID: 17875 RVA: 0x0002E25B File Offset: 0x0002C45B
		// (set) Token: 0x060045D4 RID: 17876 RVA: 0x0002E263 File Offset: 0x0002C463
		[XmlArrayItem("m_lootingSubType", IsNullable = false)]
		public LootingSubType[] m_lootingSubTypeList { get; set; }

		// Token: 0x04003169 RID: 12649
		private ELootingType m_lootingTypeField;

		// Token: 0x0400316A RID: 12650
		private LootingSubType[] m_lootingSubTypeListField;
	}
}
