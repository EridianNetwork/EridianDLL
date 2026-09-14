using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	// Token: 0x0200095B RID: 2395
	public class BHVFSMSettingsSuicide : BHVPropertySettingsAttackBase
	{
		// Token: 0x060042A0 RID: 17056 RVA: 0x0002C69C File Offset: 0x0002A89C
		public BHVFSMSettingsSuicide()
		{
			this.m_distanceToTarget = 5f;
			this.m_timeBeforeExplosion = 2f;
		}

		// Token: 0x170004CC RID: 1228
		// (get) Token: 0x060042A1 RID: 17057 RVA: 0x0002C6BA File Offset: 0x0002A8BA
		// (set) Token: 0x060042A2 RID: 17058 RVA: 0x0002C6C2 File Offset: 0x0002A8C2
		[DefaultValue(typeof(float), "5")]
		public float m_distanceToTarget { get; set; }

		// Token: 0x170004CD RID: 1229
		// (get) Token: 0x060042A3 RID: 17059 RVA: 0x0002C6CB File Offset: 0x0002A8CB
		// (set) Token: 0x060042A4 RID: 17060 RVA: 0x0002C6D3 File Offset: 0x0002A8D3
		[DefaultValue(typeof(float), "2")]
		public float m_timeBeforeExplosion { get; set; }

		// Token: 0x04002E4F RID: 11855
		[CompilerGenerated]
		private float float_3;

		// Token: 0x04002E50 RID: 11856
		[CompilerGenerated]
		private float float_4;
	}
}
