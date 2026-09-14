using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	// Token: 0x02000933 RID: 2355
	public class BHVFSMSettingsTakeCover : BHVPropertySettings
	{
		// Token: 0x06004153 RID: 16723 RVA: 0x0002B92B File Offset: 0x00029B2B
		public BHVFSMSettingsTakeCover()
		{
			this.m_initialCoverChance = 0.5f;
			this.m_dangerCoverChance = 1f;
		}

		// Token: 0x17000439 RID: 1081
		// (get) Token: 0x06004154 RID: 16724 RVA: 0x0002B949 File Offset: 0x00029B49
		// (set) Token: 0x06004155 RID: 16725 RVA: 0x0002B951 File Offset: 0x00029B51
		[DefaultValue(typeof(float), "0.5")]
		public float m_initialCoverChance { get; set; }

		// Token: 0x1700043A RID: 1082
		// (get) Token: 0x06004156 RID: 16726 RVA: 0x0002B95A File Offset: 0x00029B5A
		// (set) Token: 0x06004157 RID: 16727 RVA: 0x0002B962 File Offset: 0x00029B62
		[DefaultValue(typeof(float), "1")]
		public float m_dangerCoverChance { get; set; }

		// Token: 0x04002D98 RID: 11672
		[CompilerGenerated]
		private float float_0;

		// Token: 0x04002D99 RID: 11673
		[CompilerGenerated]
		private float float_1;
	}
}
