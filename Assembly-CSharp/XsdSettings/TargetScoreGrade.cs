using System;

namespace XsdSettings
{
	// Token: 0x020009FA RID: 2554
	public class TargetScoreGrade
	{
		// Token: 0x06004663 RID: 18019 RVA: 0x0002E6E8 File Offset: 0x0002C8E8
		public TargetScoreGrade()
		{
			this.m_score = 0;
		}

		// Token: 0x1700066C RID: 1644
		// (get) Token: 0x06004664 RID: 18020 RVA: 0x0002E6F7 File Offset: 0x0002C8F7
		// (set) Token: 0x06004665 RID: 18021 RVA: 0x0002E6FF File Offset: 0x0002C8FF
		public string m_grade { get; set; }

		// Token: 0x1700066D RID: 1645
		// (get) Token: 0x06004666 RID: 18022 RVA: 0x0002E708 File Offset: 0x0002C908
		// (set) Token: 0x06004667 RID: 18023 RVA: 0x0002E710 File Offset: 0x0002C910
		public int m_score { get; set; }
	}
}
