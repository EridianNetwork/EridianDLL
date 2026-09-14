using System;

namespace XsdSettings
{
	// Token: 0x020009D5 RID: 2517
	public class LadderProgressionData
	{
		// Token: 0x06004595 RID: 17813 RVA: 0x0002E001 File Offset: 0x0002C201
		public LadderProgressionData()
		{
			this.m_levelNumber = 0;
			this.m_title = "0";
			this.m_minLadder = 0;
			this.m_maxLadder = 0;
		}

		// Token: 0x17000615 RID: 1557
		// (get) Token: 0x06004596 RID: 17814 RVA: 0x0002E029 File Offset: 0x0002C229
		// (set) Token: 0x06004597 RID: 17815 RVA: 0x0002E031 File Offset: 0x0002C231
		public int m_levelNumber { get; set; }

		// Token: 0x17000616 RID: 1558
		// (get) Token: 0x06004598 RID: 17816 RVA: 0x0002E03A File Offset: 0x0002C23A
		// (set) Token: 0x06004599 RID: 17817 RVA: 0x0002E042 File Offset: 0x0002C242
		public string m_title { get; set; }

		// Token: 0x17000617 RID: 1559
		// (get) Token: 0x0600459A RID: 17818 RVA: 0x0002E04B File Offset: 0x0002C24B
		// (set) Token: 0x0600459B RID: 17819 RVA: 0x0002E053 File Offset: 0x0002C253
		public int m_minLadder { get; set; }

		// Token: 0x17000618 RID: 1560
		// (get) Token: 0x0600459C RID: 17820 RVA: 0x0002E05C File Offset: 0x0002C25C
		// (set) Token: 0x0600459D RID: 17821 RVA: 0x0002E064 File Offset: 0x0002C264
		public int m_maxLadder { get; set; }
	}
}
