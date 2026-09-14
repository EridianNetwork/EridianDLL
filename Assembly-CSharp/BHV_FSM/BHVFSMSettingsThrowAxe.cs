using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	// Token: 0x0200092E RID: 2350
	public class BHVFSMSettingsThrowAxe : BHVPropertySettings
	{
		// Token: 0x0600411C RID: 16668 RVA: 0x0002B6D3 File Offset: 0x000298D3
		public BHVFSMSettingsThrowAxe()
		{
			this.m_throwAxeDistanceMin = 5f;
			this.m_throwAxeDistanceMax = 30f;
		}

		// Token: 0x17000420 RID: 1056
		// (get) Token: 0x0600411D RID: 16669 RVA: 0x0002B6F1 File Offset: 0x000298F1
		// (set) Token: 0x0600411E RID: 16670 RVA: 0x0002B6F9 File Offset: 0x000298F9
		[DefaultValue(typeof(float), "5")]
		public float m_throwAxeDistanceMin { get; set; }

		// Token: 0x17000421 RID: 1057
		// (get) Token: 0x0600411F RID: 16671 RVA: 0x0002B702 File Offset: 0x00029902
		// (set) Token: 0x06004120 RID: 16672 RVA: 0x0002B70A File Offset: 0x0002990A
		[DefaultValue(typeof(float), "30")]
		public float m_throwAxeDistanceMax { get; set; }

		// Token: 0x04002D7F RID: 11647
		[CompilerGenerated]
		private float float_0;

		// Token: 0x04002D80 RID: 11648
		[CompilerGenerated]
		private float float_1;
	}
}
