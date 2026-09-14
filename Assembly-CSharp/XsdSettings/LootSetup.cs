using System;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x020009D7 RID: 2519
	public class LootSetup
	{
		// Token: 0x060045A1 RID: 17825 RVA: 0x0002E07E File Offset: 0x0002C27E
		public LootSetup()
		{
			this.m_lootLifetime = 5f;
			this.m_lootDropFromNpcForce = 1f;
		}

		// Token: 0x1700061A RID: 1562
		// (get) Token: 0x060045A2 RID: 17826 RVA: 0x0002E09C File Offset: 0x0002C29C
		// (set) Token: 0x060045A3 RID: 17827 RVA: 0x0002E0A4 File Offset: 0x0002C2A4
		public float m_lootLifetime { get; set; }

		// Token: 0x1700061B RID: 1563
		// (get) Token: 0x060045A4 RID: 17828 RVA: 0x0002E0AD File Offset: 0x0002C2AD
		// (set) Token: 0x060045A5 RID: 17829 RVA: 0x0002E0B5 File Offset: 0x0002C2B5
		public float m_lootDropFromNpcForce { get; set; }

		// Token: 0x1700061C RID: 1564
		// (get) Token: 0x060045A6 RID: 17830 RVA: 0x0002E0BE File Offset: 0x0002C2BE
		// (set) Token: 0x060045A7 RID: 17831 RVA: 0x0002E0C6 File Offset: 0x0002C2C6
		[XmlArrayItem("m_lootDefaultQuantity", IsNullable = false)]
		public DefaultLootQuantity[] m_lootDefaultQuantityList { get; set; }

		// Token: 0x1700061D RID: 1565
		// (get) Token: 0x060045A8 RID: 17832 RVA: 0x0002E0CF File Offset: 0x0002C2CF
		// (set) Token: 0x060045A9 RID: 17833 RVA: 0x0002E0D7 File Offset: 0x0002C2D7
		[XmlArrayItem("m_looting", IsNullable = false)]
		public Looting[] m_lootingList { get; set; }

		// Token: 0x04003148 RID: 12616
		private DefaultLootQuantity[] m_lootDefaultQuantityListField;

		// Token: 0x04003149 RID: 12617
		private Looting[] m_lootingListField;
	}
}
