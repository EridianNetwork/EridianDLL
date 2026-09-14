using System;

namespace XsdSettings
{
	// Token: 0x020009BD RID: 2493
	public class GlobalSettings
	{
		// Token: 0x0600451E RID: 17694 RVA: 0x0002DBCC File Offset: 0x0002BDCC
		public GlobalSettings()
		{
			this.m_interactionDistance = 3f;
			this.m_visualInteractionDistance = 20f;
			this.m_lootSpinningMoveSpeed = 5f;
			this.m_lootSpinningRotateSpeed = 150f;
			this.m_lootSpinningHeightOffset = 1f;
		}

		// Token: 0x170005E5 RID: 1509
		// (get) Token: 0x0600451F RID: 17695 RVA: 0x0002DC0B File Offset: 0x0002BE0B
		// (set) Token: 0x06004520 RID: 17696 RVA: 0x0002DC13 File Offset: 0x0002BE13
		public float m_interactionDistance { get; set; }

		// Token: 0x170005E6 RID: 1510
		// (get) Token: 0x06004521 RID: 17697 RVA: 0x0002DC1C File Offset: 0x0002BE1C
		// (set) Token: 0x06004522 RID: 17698 RVA: 0x0002DC24 File Offset: 0x0002BE24
		public float m_visualInteractionDistance { get; set; }

		// Token: 0x170005E7 RID: 1511
		// (get) Token: 0x06004523 RID: 17699 RVA: 0x0002DC2D File Offset: 0x0002BE2D
		// (set) Token: 0x06004524 RID: 17700 RVA: 0x0002DC35 File Offset: 0x0002BE35
		public float m_lootSpinningMoveSpeed { get; set; }

		// Token: 0x170005E8 RID: 1512
		// (get) Token: 0x06004525 RID: 17701 RVA: 0x0002DC3E File Offset: 0x0002BE3E
		// (set) Token: 0x06004526 RID: 17702 RVA: 0x0002DC46 File Offset: 0x0002BE46
		public float m_lootSpinningRotateSpeed { get; set; }

		// Token: 0x170005E9 RID: 1513
		// (get) Token: 0x06004527 RID: 17703 RVA: 0x0002DC4F File Offset: 0x0002BE4F
		// (set) Token: 0x06004528 RID: 17704 RVA: 0x0002DC57 File Offset: 0x0002BE57
		public float m_lootSpinningHeightOffset { get; set; }
	}
}
