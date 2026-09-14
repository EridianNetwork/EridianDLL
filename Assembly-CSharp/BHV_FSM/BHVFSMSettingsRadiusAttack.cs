using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	// Token: 0x02000956 RID: 2390
	public class BHVFSMSettingsRadiusAttack : BHVPropertySettingsAttackBase
	{
		// Token: 0x06004267 RID: 16999 RVA: 0x0002C40B File Offset: 0x0002A60B
		public BHVFSMSettingsRadiusAttack()
		{
			this.m_damageRadius = 5f;
			this.m_attackIdleTime = 1f;
		}

		// Token: 0x170004B2 RID: 1202
		// (get) Token: 0x06004268 RID: 17000 RVA: 0x0002C429 File Offset: 0x0002A629
		// (set) Token: 0x06004269 RID: 17001 RVA: 0x0002C431 File Offset: 0x0002A631
		[DefaultValue(typeof(float), "5")]
		public float m_damageRadius { get; set; }

		// Token: 0x170004B3 RID: 1203
		// (get) Token: 0x0600426A RID: 17002 RVA: 0x0002C43A File Offset: 0x0002A63A
		// (set) Token: 0x0600426B RID: 17003 RVA: 0x0002C442 File Offset: 0x0002A642
		[DefaultValue(typeof(float), "1")]
		public float m_attackIdleTime { get; set; }

		// Token: 0x04002E35 RID: 11829
		[CompilerGenerated]
		private float float_3;

		// Token: 0x04002E36 RID: 11830
		[CompilerGenerated]
		private float float_4;
	}
}
