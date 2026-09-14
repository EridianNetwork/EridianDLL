using System;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	// Token: 0x02000920 RID: 2336
	public class BHVFSMSettingsDeployAidStation : BHVPropertySettings
	{
		// Token: 0x06004050 RID: 16464 RVA: 0x0002AFE6 File Offset: 0x000291E6
		public BHVFSMSettingsDeployAidStation()
		{
			this.m_deployChance = 0.5f;
			this.m_healthPoints = 100;
			this.m_healRange = 10f;
			this.m_healRate = 10f;
		}

		// Token: 0x170003C1 RID: 961
		// (get) Token: 0x06004051 RID: 16465 RVA: 0x0002B017 File Offset: 0x00029217
		// (set) Token: 0x06004052 RID: 16466 RVA: 0x0002B01F File Offset: 0x0002921F
		public float m_deployChance { get; set; }

		// Token: 0x170003C2 RID: 962
		// (get) Token: 0x06004053 RID: 16467 RVA: 0x0002B028 File Offset: 0x00029228
		// (set) Token: 0x06004054 RID: 16468 RVA: 0x0002B030 File Offset: 0x00029230
		public int m_healthPoints { get; set; }

		// Token: 0x170003C3 RID: 963
		// (get) Token: 0x06004055 RID: 16469 RVA: 0x0002B039 File Offset: 0x00029239
		// (set) Token: 0x06004056 RID: 16470 RVA: 0x0002B041 File Offset: 0x00029241
		public float m_healRange { get; set; }

		// Token: 0x170003C4 RID: 964
		// (get) Token: 0x06004057 RID: 16471 RVA: 0x0002B04A File Offset: 0x0002924A
		// (set) Token: 0x06004058 RID: 16472 RVA: 0x0002B052 File Offset: 0x00029252
		public float m_healRate { get; set; }

		// Token: 0x04002D20 RID: 11552
		[CompilerGenerated]
		private float float_0;

		// Token: 0x04002D21 RID: 11553
		[CompilerGenerated]
		private int int_0;

		// Token: 0x04002D22 RID: 11554
		[CompilerGenerated]
		private float float_1;

		// Token: 0x04002D23 RID: 11555
		[CompilerGenerated]
		private float float_2;
	}
}
