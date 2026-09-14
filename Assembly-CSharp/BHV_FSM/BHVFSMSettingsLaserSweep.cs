using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	// Token: 0x0200094E RID: 2382
	public class BHVFSMSettingsLaserSweep : BHVPropertySettingsAttackBase
	{
		// Token: 0x0600422F RID: 16943 RVA: 0x0002C143 File Offset: 0x0002A343
		public BHVFSMSettingsLaserSweep()
		{
			this.m_attackInterval = 16f;
		}

		// Token: 0x1700049A RID: 1178
		// (get) Token: 0x06004230 RID: 16944 RVA: 0x0002C156 File Offset: 0x0002A356
		// (set) Token: 0x06004231 RID: 16945 RVA: 0x0002C15E File Offset: 0x0002A35E
		[DefaultValue(typeof(float), "16")]
		public float m_attackInterval { get; set; }

		// Token: 0x04002E1D RID: 11805
		[CompilerGenerated]
		private float float_3;
	}
}
