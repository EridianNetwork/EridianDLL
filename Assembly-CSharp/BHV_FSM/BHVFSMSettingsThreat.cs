using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	// Token: 0x0200093D RID: 2365
	public class BHVFSMSettingsThreat : BHVPropertySettings
	{
		// Token: 0x060041A7 RID: 16807 RVA: 0x0002BD21 File Offset: 0x00029F21
		public BHVFSMSettingsThreat()
		{
			this.m_distanceFactor = -0.5f;
			this.m_damageFactor = 0.5f;
		}

		// Token: 0x1700045E RID: 1118
		// (get) Token: 0x060041A8 RID: 16808 RVA: 0x0002BD3F File Offset: 0x00029F3F
		// (set) Token: 0x060041A9 RID: 16809 RVA: 0x0002BD47 File Offset: 0x00029F47
		[DefaultValue(typeof(float), "-0.5")]
		public float m_distanceFactor { get; set; }

		// Token: 0x1700045F RID: 1119
		// (get) Token: 0x060041AA RID: 16810 RVA: 0x0002BD50 File Offset: 0x00029F50
		// (set) Token: 0x060041AB RID: 16811 RVA: 0x0002BD58 File Offset: 0x00029F58
		[DefaultValue(typeof(float), "0.5")]
		public float m_damageFactor { get; set; }

		// Token: 0x04002DBD RID: 11709
		[CompilerGenerated]
		private float float_0;

		// Token: 0x04002DBE RID: 11710
		[CompilerGenerated]
		private float float_1;
	}
}
