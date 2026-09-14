using System;

namespace XsdSettings
{
	// Token: 0x020009DC RID: 2524
	public class LootingLevelRange
	{
		// Token: 0x060045C2 RID: 17858 RVA: 0x0002E1B7 File Offset: 0x0002C3B7
		public LootingLevelRange()
		{
			this.m_lootGroups = new LootGroups();
			this.m_randomLoots = new RandomLoots();
			this.m_levelMin = 1;
			this.m_levelMax = 10;
		}

		// Token: 0x17000628 RID: 1576
		// (get) Token: 0x060045C3 RID: 17859 RVA: 0x0002E1E4 File Offset: 0x0002C3E4
		// (set) Token: 0x060045C4 RID: 17860 RVA: 0x0002E1EC File Offset: 0x0002C3EC
		public int m_levelMin { get; set; }

		// Token: 0x17000629 RID: 1577
		// (get) Token: 0x060045C5 RID: 17861 RVA: 0x0002E1F5 File Offset: 0x0002C3F5
		// (set) Token: 0x060045C6 RID: 17862 RVA: 0x0002E1FD File Offset: 0x0002C3FD
		public int m_levelMax { get; set; }

		// Token: 0x1700062A RID: 1578
		// (get) Token: 0x060045C7 RID: 17863 RVA: 0x0002E206 File Offset: 0x0002C406
		// (set) Token: 0x060045C8 RID: 17864 RVA: 0x0002E20E File Offset: 0x0002C40E
		public RandomLoots m_randomLoots { get; set; }

		// Token: 0x1700062B RID: 1579
		// (get) Token: 0x060045C9 RID: 17865 RVA: 0x0002E217 File Offset: 0x0002C417
		// (set) Token: 0x060045CA RID: 17866 RVA: 0x0002E21F File Offset: 0x0002C41F
		public LootGroups m_lootGroups { get; set; }
	}
}
