using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	// Token: 0x0200092C RID: 2348
	public class BHVFSMSettingsHoverPatrol : BHVPropertySettings
	{
		// Token: 0x0600410E RID: 16654 RVA: 0x0002B61B File Offset: 0x0002981B
		public BHVFSMSettingsHoverPatrol()
		{
			this.m_patrolTime = 20f;
			this.m_chanceToOtherPatrolPoint = 1f;
		}

		// Token: 0x1700041A RID: 1050
		// (get) Token: 0x0600410F RID: 16655 RVA: 0x0002B639 File Offset: 0x00029839
		// (set) Token: 0x06004110 RID: 16656 RVA: 0x0002B641 File Offset: 0x00029841
		[DefaultValue(typeof(float), "20")]
		public float m_patrolTime { get; set; }

		// Token: 0x1700041B RID: 1051
		// (get) Token: 0x06004111 RID: 16657 RVA: 0x0002B64A File Offset: 0x0002984A
		// (set) Token: 0x06004112 RID: 16658 RVA: 0x0002B652 File Offset: 0x00029852
		[DefaultValue(typeof(float), "1")]
		public float m_chanceToOtherPatrolPoint { get; set; }

		// Token: 0x04002D79 RID: 11641
		[CompilerGenerated]
		private float float_0;

		// Token: 0x04002D7A RID: 11642
		[CompilerGenerated]
		private float float_1;
	}
}
