using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV
{
	// Token: 0x02000979 RID: 2425
	public class BHVFireStyleSettings : BHVTaskSettings
	{
		// Token: 0x06004411 RID: 17425 RVA: 0x0012F4FC File Offset: 0x0012D6FC
		public BHVFireStyleSettings()
		{
			this.m_burstSingle_FireTimeMin = 0.01f;
			this.m_burstSingle_FireTimeMax = 0.01f;
			this.m_burstChained_IdleTimeMin = 0.01f;
			this.m_burstChained_IdleTimeMax = 0.01f;
			this.m_burstChained_FireTimeMin = 0.01f;
			this.m_burstChained_FireTimeMax = 0.01f;
			this.m_canFallBackAfterFire = false;
		}

		// Token: 0x17000576 RID: 1398
		// (get) Token: 0x06004412 RID: 17426 RVA: 0x0002D35C File Offset: 0x0002B55C
		// (set) Token: 0x06004413 RID: 17427 RVA: 0x0002D364 File Offset: 0x0002B564
		[DefaultValue(typeof(float), "0.01")]
		public float m_burstSingle_FireTimeMin { get; set; }

		// Token: 0x17000577 RID: 1399
		// (get) Token: 0x06004414 RID: 17428 RVA: 0x0002D36D File Offset: 0x0002B56D
		// (set) Token: 0x06004415 RID: 17429 RVA: 0x0002D375 File Offset: 0x0002B575
		[DefaultValue(typeof(float), "0.01")]
		public float m_burstSingle_FireTimeMax { get; set; }

		// Token: 0x17000578 RID: 1400
		// (get) Token: 0x06004416 RID: 17430 RVA: 0x0002D37E File Offset: 0x0002B57E
		// (set) Token: 0x06004417 RID: 17431 RVA: 0x0002D386 File Offset: 0x0002B586
		[DefaultValue(typeof(float), "0.01")]
		public float m_burstChained_IdleTimeMin { get; set; }

		// Token: 0x17000579 RID: 1401
		// (get) Token: 0x06004418 RID: 17432 RVA: 0x0002D38F File Offset: 0x0002B58F
		// (set) Token: 0x06004419 RID: 17433 RVA: 0x0002D397 File Offset: 0x0002B597
		[DefaultValue(typeof(float), "0.01")]
		public float m_burstChained_IdleTimeMax { get; set; }

		// Token: 0x1700057A RID: 1402
		// (get) Token: 0x0600441A RID: 17434 RVA: 0x0002D3A0 File Offset: 0x0002B5A0
		// (set) Token: 0x0600441B RID: 17435 RVA: 0x0002D3A8 File Offset: 0x0002B5A8
		[DefaultValue(typeof(float), "0.01")]
		public float m_burstChained_FireTimeMin { get; set; }

		// Token: 0x1700057B RID: 1403
		// (get) Token: 0x0600441C RID: 17436 RVA: 0x0002D3B1 File Offset: 0x0002B5B1
		// (set) Token: 0x0600441D RID: 17437 RVA: 0x0002D3B9 File Offset: 0x0002B5B9
		[DefaultValue(typeof(float), "0.01")]
		public float m_burstChained_FireTimeMax { get; set; }

		// Token: 0x1700057C RID: 1404
		// (get) Token: 0x0600441E RID: 17438 RVA: 0x0002D3C2 File Offset: 0x0002B5C2
		// (set) Token: 0x0600441F RID: 17439 RVA: 0x0002D3CA File Offset: 0x0002B5CA
		[DefaultValue(false)]
		public bool m_canFallBackAfterFire { get; set; }

		// Token: 0x04002F01 RID: 12033
		[CompilerGenerated]
		private float float_0;

		// Token: 0x04002F02 RID: 12034
		[CompilerGenerated]
		private float float_1;

		// Token: 0x04002F03 RID: 12035
		[CompilerGenerated]
		private float float_2;

		// Token: 0x04002F04 RID: 12036
		[CompilerGenerated]
		private float float_3;

		// Token: 0x04002F05 RID: 12037
		[CompilerGenerated]
		private float float_4;

		// Token: 0x04002F06 RID: 12038
		[CompilerGenerated]
		private float float_5;

		// Token: 0x04002F07 RID: 12039
		[CompilerGenerated]
		private bool bool_0;
	}
}
