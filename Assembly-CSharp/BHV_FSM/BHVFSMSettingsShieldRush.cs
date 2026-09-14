using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	// Token: 0x0200092D RID: 2349
	public class BHVFSMSettingsShieldRush : BHVPropertySettings
	{
		// Token: 0x06004113 RID: 16659 RVA: 0x0002B65B File Offset: 0x0002985B
		public BHVFSMSettingsShieldRush()
		{
			this.m_rushAttackDistanceMin = 10f;
			this.m_rushAttackDistanceMax = 50f;
			this.m_distanceBeforeTarget = 5f;
			this.m_attackChanceWeight = 1f;
		}

		// Token: 0x1700041C RID: 1052
		// (get) Token: 0x06004114 RID: 16660 RVA: 0x0002B68F File Offset: 0x0002988F
		// (set) Token: 0x06004115 RID: 16661 RVA: 0x0002B697 File Offset: 0x00029897
		[DefaultValue(typeof(float), "10")]
		public float m_rushAttackDistanceMin { get; set; }

		// Token: 0x1700041D RID: 1053
		// (get) Token: 0x06004116 RID: 16662 RVA: 0x0002B6A0 File Offset: 0x000298A0
		// (set) Token: 0x06004117 RID: 16663 RVA: 0x0002B6A8 File Offset: 0x000298A8
		[DefaultValue(typeof(float), "50")]
		public float m_rushAttackDistanceMax { get; set; }

		// Token: 0x1700041E RID: 1054
		// (get) Token: 0x06004118 RID: 16664 RVA: 0x0002B6B1 File Offset: 0x000298B1
		// (set) Token: 0x06004119 RID: 16665 RVA: 0x0002B6B9 File Offset: 0x000298B9
		[DefaultValue(typeof(float), "5")]
		public float m_distanceBeforeTarget { get; set; }

		// Token: 0x1700041F RID: 1055
		// (get) Token: 0x0600411A RID: 16666 RVA: 0x0002B6C2 File Offset: 0x000298C2
		// (set) Token: 0x0600411B RID: 16667 RVA: 0x0002B6CA File Offset: 0x000298CA
		[DefaultValue(typeof(float), "1")]
		public float m_attackChanceWeight { get; set; }

		// Token: 0x04002D7B RID: 11643
		[CompilerGenerated]
		private float float_0;

		// Token: 0x04002D7C RID: 11644
		[CompilerGenerated]
		private float float_1;

		// Token: 0x04002D7D RID: 11645
		[CompilerGenerated]
		private float float_2;

		// Token: 0x04002D7E RID: 11646
		[CompilerGenerated]
		private float float_3;
	}
}
