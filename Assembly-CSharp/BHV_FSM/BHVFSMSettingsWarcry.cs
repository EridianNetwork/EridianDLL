using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	// Token: 0x0200093C RID: 2364
	public class BHVFSMSettingsWarcry : BHVPropertySettings
	{
		// Token: 0x060041A0 RID: 16800 RVA: 0x0002BCC8 File Offset: 0x00029EC8
		public BHVFSMSettingsWarcry()
		{
			this.m_damageAmount = 60;
			this.m_time = 2f;
			this.m_CoolDownTime = 5f;
		}

		// Token: 0x1700045B RID: 1115
		// (get) Token: 0x060041A1 RID: 16801 RVA: 0x0002BCEE File Offset: 0x00029EEE
		// (set) Token: 0x060041A2 RID: 16802 RVA: 0x0002BCF6 File Offset: 0x00029EF6
		[DefaultValue(60)]
		public int m_damageAmount { get; set; }

		// Token: 0x1700045C RID: 1116
		// (get) Token: 0x060041A3 RID: 16803 RVA: 0x0002BCFF File Offset: 0x00029EFF
		// (set) Token: 0x060041A4 RID: 16804 RVA: 0x0002BD07 File Offset: 0x00029F07
		[DefaultValue(typeof(float), "2")]
		public float m_time { get; set; }

		// Token: 0x1700045D RID: 1117
		// (get) Token: 0x060041A5 RID: 16805 RVA: 0x0002BD10 File Offset: 0x00029F10
		// (set) Token: 0x060041A6 RID: 16806 RVA: 0x0002BD18 File Offset: 0x00029F18
		[DefaultValue(typeof(float), "5")]
		public float m_CoolDownTime { get; set; }

		// Token: 0x04002DBA RID: 11706
		[CompilerGenerated]
		private int int_0;

		// Token: 0x04002DBB RID: 11707
		[CompilerGenerated]
		private float float_0;

		// Token: 0x04002DBC RID: 11708
		[CompilerGenerated]
		private float float_1;
	}
}
