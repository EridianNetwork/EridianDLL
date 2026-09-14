using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x020009DB RID: 2523
	public class RandomLoots
	{
		// Token: 0x060045BD RID: 17853 RVA: 0x0002E186 File Offset: 0x0002C386
		public RandomLoots()
		{
			this.m_lootMax = 5;
		}

		// Token: 0x17000626 RID: 1574
		// (get) Token: 0x060045BE RID: 17854 RVA: 0x0002E195 File Offset: 0x0002C395
		// (set) Token: 0x060045BF RID: 17855 RVA: 0x0002E19D File Offset: 0x0002C39D
		[DefaultValue(5)]
		public int m_lootMax { get; set; }

		// Token: 0x17000627 RID: 1575
		// (get) Token: 0x060045C0 RID: 17856 RVA: 0x0002E1A6 File Offset: 0x0002C3A6
		// (set) Token: 0x060045C1 RID: 17857 RVA: 0x0002E1AE File Offset: 0x0002C3AE
		[XmlArrayItem("m_loot", IsNullable = false)]
		public Loot[] m_lootList { get; set; }

		// Token: 0x04003159 RID: 12633
		private Loot[] m_lootListField;
	}
}
