using System;

namespace XsdSettings
{
	// Token: 0x02000980 RID: 2432
	public class NPCLevelMultipliers
	{
		// Token: 0x06004442 RID: 17474 RVA: 0x0012F558 File Offset: 0x0012D758
		public NPCLevelMultipliers()
		{
			this.m_levelID = 1;
			this.m_HPMultiplier = 1f;
			this.m_shieldPointsMultiplier = 1f;
			this.m_damageMeleeMultiplier = 1f;
			this.m_damageRangeMultiplier = 1f;
			this.m_expRewardMultiplier = 1f;
		}

		// Token: 0x1700058B RID: 1419
		// (get) Token: 0x06004443 RID: 17475 RVA: 0x0002D540 File Offset: 0x0002B740
		// (set) Token: 0x06004444 RID: 17476 RVA: 0x0002D548 File Offset: 0x0002B748
		public int m_levelID { get; set; }

		// Token: 0x1700058C RID: 1420
		// (get) Token: 0x06004445 RID: 17477 RVA: 0x0002D551 File Offset: 0x0002B751
		// (set) Token: 0x06004446 RID: 17478 RVA: 0x0002D559 File Offset: 0x0002B759
		public float m_HPMultiplier { get; set; }

		// Token: 0x1700058D RID: 1421
		// (get) Token: 0x06004447 RID: 17479 RVA: 0x0002D562 File Offset: 0x0002B762
		// (set) Token: 0x06004448 RID: 17480 RVA: 0x0002D56A File Offset: 0x0002B76A
		public float m_shieldPointsMultiplier { get; set; }

		// Token: 0x1700058E RID: 1422
		// (get) Token: 0x06004449 RID: 17481 RVA: 0x0002D573 File Offset: 0x0002B773
		// (set) Token: 0x0600444A RID: 17482 RVA: 0x0002D57B File Offset: 0x0002B77B
		public float m_damageMeleeMultiplier { get; set; }

		// Token: 0x1700058F RID: 1423
		// (get) Token: 0x0600444B RID: 17483 RVA: 0x0002D584 File Offset: 0x0002B784
		// (set) Token: 0x0600444C RID: 17484 RVA: 0x0002D58C File Offset: 0x0002B78C
		public float m_damageRangeMultiplier { get; set; }

		// Token: 0x17000590 RID: 1424
		// (get) Token: 0x0600444D RID: 17485 RVA: 0x0002D595 File Offset: 0x0002B795
		// (set) Token: 0x0600444E RID: 17486 RVA: 0x0002D59D File Offset: 0x0002B79D
		public float m_expRewardMultiplier { get; set; }
	}
}
