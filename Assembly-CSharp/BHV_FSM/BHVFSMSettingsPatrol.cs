using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	// Token: 0x02000934 RID: 2356
	public class BHVFSMSettingsPatrol : BHVPropertySettings
	{
		// Token: 0x06004158 RID: 16728 RVA: 0x0002B96B File Offset: 0x00029B6B
		public BHVFSMSettingsPatrol()
		{
			this.m_patrolRadius = 0f;
			this.m_patrolTime = 0f;
			this.m_chanceToIdleWhenReachPatrolPoint = 0f;
			this.m_stayIdleTimeMin = 0f;
			this.m_stayIdleTimeMax = 0f;
		}

		// Token: 0x1700043B RID: 1083
		// (get) Token: 0x06004159 RID: 16729 RVA: 0x0002B9AA File Offset: 0x00029BAA
		// (set) Token: 0x0600415A RID: 16730 RVA: 0x0002B9B2 File Offset: 0x00029BB2
		[DefaultValue(typeof(float), "0")]
		public float m_patrolRadius { get; set; }

		// Token: 0x1700043C RID: 1084
		// (get) Token: 0x0600415B RID: 16731 RVA: 0x0002B9BB File Offset: 0x00029BBB
		// (set) Token: 0x0600415C RID: 16732 RVA: 0x0002B9C3 File Offset: 0x00029BC3
		[DefaultValue(typeof(float), "0")]
		public float m_patrolTime { get; set; }

		// Token: 0x1700043D RID: 1085
		// (get) Token: 0x0600415D RID: 16733 RVA: 0x0002B9CC File Offset: 0x00029BCC
		// (set) Token: 0x0600415E RID: 16734 RVA: 0x0002B9D4 File Offset: 0x00029BD4
		[DefaultValue(typeof(float), "0")]
		public float m_chanceToIdleWhenReachPatrolPoint { get; set; }

		// Token: 0x1700043E RID: 1086
		// (get) Token: 0x0600415F RID: 16735 RVA: 0x0002B9DD File Offset: 0x00029BDD
		// (set) Token: 0x06004160 RID: 16736 RVA: 0x0002B9E5 File Offset: 0x00029BE5
		[DefaultValue(typeof(float), "0")]
		public float m_stayIdleTimeMin { get; set; }

		// Token: 0x1700043F RID: 1087
		// (get) Token: 0x06004161 RID: 16737 RVA: 0x0002B9EE File Offset: 0x00029BEE
		// (set) Token: 0x06004162 RID: 16738 RVA: 0x0002B9F6 File Offset: 0x00029BF6
		[DefaultValue(typeof(float), "0")]
		public float m_stayIdleTimeMax { get; set; }

		// Token: 0x04002D9A RID: 11674
		[CompilerGenerated]
		private float float_0;

		// Token: 0x04002D9B RID: 11675
		[CompilerGenerated]
		private float float_1;

		// Token: 0x04002D9C RID: 11676
		[CompilerGenerated]
		private float float_2;

		// Token: 0x04002D9D RID: 11677
		[CompilerGenerated]
		private float float_3;

		// Token: 0x04002D9E RID: 11678
		[CompilerGenerated]
		private float float_4;
	}
}
