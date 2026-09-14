using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	// Token: 0x0200092A RID: 2346
	public class BHVFSMSettingsGrenade : BHVPropertySettings
	{
		// Token: 0x060040FA RID: 16634 RVA: 0x0002B56F File Offset: 0x0002976F
		public BHVFSMSettingsGrenade()
		{
			this.m_timeBeforeExplosion = 1f;
		}

		// Token: 0x17000411 RID: 1041
		// (get) Token: 0x060040FB RID: 16635 RVA: 0x0002B582 File Offset: 0x00029782
		// (set) Token: 0x060040FC RID: 16636 RVA: 0x0002B58A File Offset: 0x0002978A
		[DefaultValue(typeof(float), "1")]
		public float m_timeBeforeExplosion { get; set; }

		// Token: 0x04002D70 RID: 11632
		[CompilerGenerated]
		private float float_0;
	}
}
