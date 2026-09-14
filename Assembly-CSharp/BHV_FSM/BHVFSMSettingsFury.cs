using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	// Token: 0x0200093B RID: 2363
	public class BHVFSMSettingsFury : BHVPropertySettings
	{
		// Token: 0x0600419D RID: 16797 RVA: 0x0002BCA4 File Offset: 0x00029EA4
		public BHVFSMSettingsFury()
		{
			this.m_startFuryHealthPoint = 200;
		}

		// Token: 0x1700045A RID: 1114
		// (get) Token: 0x0600419E RID: 16798 RVA: 0x0002BCB7 File Offset: 0x00029EB7
		// (set) Token: 0x0600419F RID: 16799 RVA: 0x0002BCBF File Offset: 0x00029EBF
		[DefaultValue(200)]
		public int m_startFuryHealthPoint { get; set; }

		// Token: 0x04002DB9 RID: 11705
		[CompilerGenerated]
		private int int_0;
	}
}
