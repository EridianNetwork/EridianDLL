using System;

namespace XsdSettings
{
	// Token: 0x02000A64 RID: 2660
	public class StarLevelConfig
	{
		// Token: 0x17000739 RID: 1849
		// (get) Token: 0x06004857 RID: 18519 RVA: 0x0002F5DB File Offset: 0x0002D7DB
		// (set) Token: 0x06004858 RID: 18520 RVA: 0x0002F5E3 File Offset: 0x0002D7E3
		public int m_starLevel { get; set; }

		// Token: 0x1700073A RID: 1850
		// (get) Token: 0x06004859 RID: 18521 RVA: 0x0002F5EC File Offset: 0x0002D7EC
		// (set) Token: 0x0600485A RID: 18522 RVA: 0x0002F5F4 File Offset: 0x0002D7F4
		public int m_basicStarExp { get; set; }

		// Token: 0x1700073B RID: 1851
		// (get) Token: 0x0600485B RID: 18523 RVA: 0x0002F5FD File Offset: 0x0002D7FD
		// (set) Token: 0x0600485C RID: 18524 RVA: 0x0002F605 File Offset: 0x0002D805
		public float m_successRate { get; set; }

		// Token: 0x1700073C RID: 1852
		// (get) Token: 0x0600485D RID: 18525 RVA: 0x0002F60E File Offset: 0x0002D80E
		// (set) Token: 0x0600485E RID: 18526 RVA: 0x0002F616 File Offset: 0x0002D816
		public ItemConsume m_itemConsume { get; set; }

		// Token: 0x04003482 RID: 13442
		private ItemConsume m_itemConsumeField;
	}
}
