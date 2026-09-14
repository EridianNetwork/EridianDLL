using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	// Token: 0x02000938 RID: 2360
	public class BHVFSMSettingsSpacing : BHVPropertySettings
	{
		// Token: 0x06004186 RID: 16774 RVA: 0x0002BB77 File Offset: 0x00029D77
		public BHVFSMSettingsSpacing()
		{
			this.m_spacingTime = 5f;
			this.m_spacingRangeMin = 10f;
			this.m_spacingRangeMax = 18f;
		}

		// Token: 0x17000450 RID: 1104
		// (get) Token: 0x06004187 RID: 16775 RVA: 0x0002BBA0 File Offset: 0x00029DA0
		// (set) Token: 0x06004188 RID: 16776 RVA: 0x0002BBA8 File Offset: 0x00029DA8
		[DefaultValue(typeof(float), "5")]
		public float m_spacingTime { get; set; }

		// Token: 0x17000451 RID: 1105
		// (get) Token: 0x06004189 RID: 16777 RVA: 0x0002BBB1 File Offset: 0x00029DB1
		// (set) Token: 0x0600418A RID: 16778 RVA: 0x0002BBB9 File Offset: 0x00029DB9
		[DefaultValue(typeof(float), "10")]
		public float m_spacingRangeMin { get; set; }

		// Token: 0x17000452 RID: 1106
		// (get) Token: 0x0600418B RID: 16779 RVA: 0x0002BBC2 File Offset: 0x00029DC2
		// (set) Token: 0x0600418C RID: 16780 RVA: 0x0002BBCA File Offset: 0x00029DCA
		[DefaultValue(typeof(float), "18")]
		public float m_spacingRangeMax { get; set; }

		// Token: 0x04002DAF RID: 11695
		[CompilerGenerated]
		private float float_0;

		// Token: 0x04002DB0 RID: 11696
		[CompilerGenerated]
		private float float_1;

		// Token: 0x04002DB1 RID: 11697
		[CompilerGenerated]
		private float float_2;
	}
}
