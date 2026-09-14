using System;
using System.Runtime.CompilerServices;

namespace BHV
{
	// Token: 0x0200096A RID: 2410
	public class BHVTaskDrillAttackSettings : BHVTaskSettings
	{
		// Token: 0x17000521 RID: 1313
		// (get) Token: 0x06004359 RID: 17241 RVA: 0x0002CC9B File Offset: 0x0002AE9B
		// (set) Token: 0x0600435A RID: 17242 RVA: 0x0002CCA3 File Offset: 0x0002AEA3
		public float m_drillAttackDistance { get; set; }

		// Token: 0x17000522 RID: 1314
		// (get) Token: 0x0600435B RID: 17243 RVA: 0x0002CCAC File Offset: 0x0002AEAC
		// (set) Token: 0x0600435C RID: 17244 RVA: 0x0002CCB4 File Offset: 0x0002AEB4
		public float m_drillDuration { get; set; }

		// Token: 0x17000523 RID: 1315
		// (get) Token: 0x0600435D RID: 17245 RVA: 0x0002CCBD File Offset: 0x0002AEBD
		// (set) Token: 0x0600435E RID: 17246 RVA: 0x0002CCC5 File Offset: 0x0002AEC5
		public int m_damagePoint { get; set; }

		// Token: 0x17000524 RID: 1316
		// (get) Token: 0x0600435F RID: 17247 RVA: 0x0002CCCE File Offset: 0x0002AECE
		// (set) Token: 0x06004360 RID: 17248 RVA: 0x0002CCD6 File Offset: 0x0002AED6
		public bool m_bKnockback { get; set; }

		// Token: 0x04002EAA RID: 11946
		[CompilerGenerated]
		private float float_0;

		// Token: 0x04002EAB RID: 11947
		[CompilerGenerated]
		private float float_1;

		// Token: 0x04002EAC RID: 11948
		[CompilerGenerated]
		private int int_0;

		// Token: 0x04002EAD RID: 11949
		[CompilerGenerated]
		private bool bool_0;
	}
}
