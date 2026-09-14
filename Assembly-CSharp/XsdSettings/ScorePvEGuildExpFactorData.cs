using System;

namespace XsdSettings
{
	// Token: 0x020009C9 RID: 2505
	public class ScorePvEGuildExpFactorData
	{
		// Token: 0x0600455F RID: 17759 RVA: 0x0002DE39 File Offset: 0x0002C039
		public ScorePvEGuildExpFactorData()
		{
			this.m_grade = "S";
			this.m_expValue = 0;
		}

		// Token: 0x17000600 RID: 1536
		// (get) Token: 0x06004560 RID: 17760 RVA: 0x0002DE53 File Offset: 0x0002C053
		// (set) Token: 0x06004561 RID: 17761 RVA: 0x0002DE5B File Offset: 0x0002C05B
		public string m_grade { get; set; }

		// Token: 0x17000601 RID: 1537
		// (get) Token: 0x06004562 RID: 17762 RVA: 0x0002DE64 File Offset: 0x0002C064
		// (set) Token: 0x06004563 RID: 17763 RVA: 0x0002DE6C File Offset: 0x0002C06C
		public int m_expValue { get; set; }
	}
}
