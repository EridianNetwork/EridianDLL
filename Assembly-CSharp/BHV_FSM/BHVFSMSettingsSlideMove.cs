using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	// Token: 0x02000935 RID: 2357
	public class BHVFSMSettingsSlideMove : BHVPropertySettings
	{
		// Token: 0x06004163 RID: 16739 RVA: 0x0002B9FF File Offset: 0x00029BFF
		public BHVFSMSettingsSlideMove()
		{
			this.m_slideMoveSpeed = 5f;
			this.m_slideRushSpeed = 10f;
			this.m_acceleration = 20f;
		}

		// Token: 0x17000440 RID: 1088
		// (get) Token: 0x06004164 RID: 16740 RVA: 0x0002BA28 File Offset: 0x00029C28
		// (set) Token: 0x06004165 RID: 16741 RVA: 0x0002BA30 File Offset: 0x00029C30
		[DefaultValue(typeof(float), "5")]
		public float m_slideMoveSpeed { get; set; }

		// Token: 0x17000441 RID: 1089
		// (get) Token: 0x06004166 RID: 16742 RVA: 0x0002BA39 File Offset: 0x00029C39
		// (set) Token: 0x06004167 RID: 16743 RVA: 0x0002BA41 File Offset: 0x00029C41
		[DefaultValue(typeof(float), "10")]
		public float m_slideRushSpeed { get; set; }

		// Token: 0x17000442 RID: 1090
		// (get) Token: 0x06004168 RID: 16744 RVA: 0x0002BA4A File Offset: 0x00029C4A
		// (set) Token: 0x06004169 RID: 16745 RVA: 0x0002BA52 File Offset: 0x00029C52
		[DefaultValue(typeof(float), "20")]
		public float m_acceleration { get; set; }

		// Token: 0x04002D9F RID: 11679
		[CompilerGenerated]
		private float float_0;

		// Token: 0x04002DA0 RID: 11680
		[CompilerGenerated]
		private float float_1;

		// Token: 0x04002DA1 RID: 11681
		[CompilerGenerated]
		private float float_2;
	}
}
