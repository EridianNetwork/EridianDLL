using System;

namespace XsdSettings
{
	// Token: 0x020009F5 RID: 2549
	public class ProgressionData
	{
		// Token: 0x0600461C RID: 17948 RVA: 0x0002E496 File Offset: 0x0002C696
		public ProgressionData()
		{
			this.m_requiredXp = 0;
			this.m_skillPointGain = 0;
			this.m_powerRating = 0f;
		}

		// Token: 0x1700064B RID: 1611
		// (get) Token: 0x0600461D RID: 17949 RVA: 0x0002E4B7 File Offset: 0x0002C6B7
		// (set) Token: 0x0600461E RID: 17950 RVA: 0x0002E4BF File Offset: 0x0002C6BF
		public int m_requiredXp { get; set; }

		// Token: 0x1700064C RID: 1612
		// (get) Token: 0x0600461F RID: 17951 RVA: 0x0002E4C8 File Offset: 0x0002C6C8
		// (set) Token: 0x06004620 RID: 17952 RVA: 0x0002E4D0 File Offset: 0x0002C6D0
		public int m_skillPointGain { get; set; }

		// Token: 0x1700064D RID: 1613
		// (get) Token: 0x06004621 RID: 17953 RVA: 0x0002E4D9 File Offset: 0x0002C6D9
		// (set) Token: 0x06004622 RID: 17954 RVA: 0x0002E4E1 File Offset: 0x0002C6E1
		public float m_powerRating { get; set; }
	}
}
