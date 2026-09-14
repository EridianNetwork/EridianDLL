using System;

namespace XsdSettings
{
	// Token: 0x02000913 RID: 2323
	public class AchievementLevelData
	{
		// Token: 0x1700039D RID: 925
		// (get) Token: 0x06003FFC RID: 16380 RVA: 0x0002AD7A File Offset: 0x00028F7A
		// (set) Token: 0x06003FFD RID: 16381 RVA: 0x0002AD82 File Offset: 0x00028F82
		public int m_levelId { get; set; }

		// Token: 0x1700039E RID: 926
		// (get) Token: 0x06003FFE RID: 16382 RVA: 0x0002AD8B File Offset: 0x00028F8B
		// (set) Token: 0x06003FFF RID: 16383 RVA: 0x0002AD93 File Offset: 0x00028F93
		public int m_levelMinPoint { get; set; }

		// Token: 0x1700039F RID: 927
		// (get) Token: 0x06004000 RID: 16384 RVA: 0x0002AD9C File Offset: 0x00028F9C
		// (set) Token: 0x06004001 RID: 16385 RVA: 0x0002ADA4 File Offset: 0x00028FA4
		public string m_levelTitle { get; set; }
	}
}
