using System;

namespace XsdSettings
{
	// Token: 0x020009C8 RID: 2504
	public class DifficultyPvEGuildExpFactorData
	{
		// Token: 0x0600455A RID: 17754 RVA: 0x0002DDFD File Offset: 0x0002BFFD
		public DifficultyPvEGuildExpFactorData()
		{
			this.m_grade = "Hell";
			this.m_expValue = 0;
		}

		// Token: 0x170005FE RID: 1534
		// (get) Token: 0x0600455B RID: 17755 RVA: 0x0002DE17 File Offset: 0x0002C017
		// (set) Token: 0x0600455C RID: 17756 RVA: 0x0002DE1F File Offset: 0x0002C01F
		public string m_grade { get; set; }

		// Token: 0x170005FF RID: 1535
		// (get) Token: 0x0600455D RID: 17757 RVA: 0x0002DE28 File Offset: 0x0002C028
		// (set) Token: 0x0600455E RID: 17758 RVA: 0x0002DE30 File Offset: 0x0002C030
		public int m_expValue { get; set; }
	}
}
