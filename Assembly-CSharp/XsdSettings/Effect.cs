using System;

namespace XsdSettings
{
	// Token: 0x02000A4A RID: 2634
	public class Effect
	{
		// Token: 0x060047E1 RID: 18401 RVA: 0x0002F2BE File Offset: 0x0002D4BE
		public Effect()
		{
			this.m_type = EffectType.Invalid;
		}

		// Token: 0x1700070B RID: 1803
		// (get) Token: 0x060047E2 RID: 18402 RVA: 0x0002F2CD File Offset: 0x0002D4CD
		// (set) Token: 0x060047E3 RID: 18403 RVA: 0x0002F2D5 File Offset: 0x0002D4D5
		public EffectType m_type { get; set; }

		// Token: 0x1700070C RID: 1804
		// (get) Token: 0x060047E4 RID: 18404 RVA: 0x0002F2DE File Offset: 0x0002D4DE
		// (set) Token: 0x060047E5 RID: 18405 RVA: 0x0002F2E6 File Offset: 0x0002D4E6
		public string m_attribute { get; set; }

		// Token: 0x1700070D RID: 1805
		// (get) Token: 0x060047E6 RID: 18406 RVA: 0x0002F2EF File Offset: 0x0002D4EF
		// (set) Token: 0x060047E7 RID: 18407 RVA: 0x0002F2F7 File Offset: 0x0002D4F7
		public string m_behavior { get; set; }

		// Token: 0x1700070E RID: 1806
		// (get) Token: 0x060047E8 RID: 18408 RVA: 0x0002F300 File Offset: 0x0002D500
		// (set) Token: 0x060047E9 RID: 18409 RVA: 0x0002F308 File Offset: 0x0002D508
		public string m_operation { get; set; }

		// Token: 0x1700070F RID: 1807
		// (get) Token: 0x060047EA RID: 18410 RVA: 0x0002F311 File Offset: 0x0002D511
		// (set) Token: 0x060047EB RID: 18411 RVA: 0x0002F319 File Offset: 0x0002D519
		public float m_firstGrade { get; set; }

		// Token: 0x17000710 RID: 1808
		// (get) Token: 0x060047EC RID: 18412 RVA: 0x0002F322 File Offset: 0x0002D522
		// (set) Token: 0x060047ED RID: 18413 RVA: 0x0002F32A File Offset: 0x0002D52A
		public float m_perGrade { get; set; }

		// Token: 0x17000711 RID: 1809
		// (get) Token: 0x060047EE RID: 18414 RVA: 0x0002F333 File Offset: 0x0002D533
		// (set) Token: 0x060047EF RID: 18415 RVA: 0x0002F33B File Offset: 0x0002D53B
		public float m_duration { get; set; }
	}
}
