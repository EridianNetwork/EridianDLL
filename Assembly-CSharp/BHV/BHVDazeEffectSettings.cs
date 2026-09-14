using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV
{
	// Token: 0x0200097A RID: 2426
	public class BHVDazeEffectSettings : BHVTaskSettings
	{
		// Token: 0x06004420 RID: 17440 RVA: 0x0002D3D3 File Offset: 0x0002B5D3
		public BHVDazeEffectSettings()
		{
			this.m_bDazeResist = false;
			this.m_dazeDuration = 3f;
			this.m_speedRate = 0.3f;
		}

		// Token: 0x1700057D RID: 1405
		// (get) Token: 0x06004421 RID: 17441 RVA: 0x0002D3F8 File Offset: 0x0002B5F8
		// (set) Token: 0x06004422 RID: 17442 RVA: 0x0002D400 File Offset: 0x0002B600
		[DefaultValue(false)]
		public bool m_bDazeResist { get; set; }

		// Token: 0x1700057E RID: 1406
		// (get) Token: 0x06004423 RID: 17443 RVA: 0x0002D409 File Offset: 0x0002B609
		// (set) Token: 0x06004424 RID: 17444 RVA: 0x0002D411 File Offset: 0x0002B611
		[DefaultValue(typeof(float), "3")]
		public float m_dazeDuration { get; set; }

		// Token: 0x1700057F RID: 1407
		// (get) Token: 0x06004425 RID: 17445 RVA: 0x0002D41A File Offset: 0x0002B61A
		// (set) Token: 0x06004426 RID: 17446 RVA: 0x0002D422 File Offset: 0x0002B622
		[DefaultValue(typeof(float), "0.3")]
		public float m_speedRate { get; set; }

		// Token: 0x04002F08 RID: 12040
		[CompilerGenerated]
		private bool bool_0;

		// Token: 0x04002F09 RID: 12041
		[CompilerGenerated]
		private float float_0;

		// Token: 0x04002F0A RID: 12042
		[CompilerGenerated]
		private float float_1;
	}
}
