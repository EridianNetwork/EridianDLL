using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	// Token: 0x02000950 RID: 2384
	public class BHVFSMSettingsMinionSummon : BHVPropertySettingsAttackBase
	{
		// Token: 0x0600423D RID: 16957 RVA: 0x0002C1FB File Offset: 0x0002A3FB
		public BHVFSMSettingsMinionSummon()
		{
			this.m_summonInterval = 10f;
		}

		// Token: 0x170004A0 RID: 1184
		// (get) Token: 0x0600423E RID: 16958 RVA: 0x0002C20E File Offset: 0x0002A40E
		// (set) Token: 0x0600423F RID: 16959 RVA: 0x0002C216 File Offset: 0x0002A416
		[DefaultValue(typeof(float), "10")]
		public float m_summonInterval { get; set; }

		// Token: 0x04002E23 RID: 11811
		[CompilerGenerated]
		private float float_3;
	}
}
