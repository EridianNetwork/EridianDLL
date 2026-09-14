using System;
using System.Runtime.CompilerServices;

namespace BHV
{
	// Token: 0x0200096C RID: 2412
	public class BHVRechargeSettings : BHVTaskSettings
	{
		// Token: 0x06004368 RID: 17256 RVA: 0x0002CD12 File Offset: 0x0002AF12
		public BHVRechargeSettings()
		{
			this.m_rechargeSpeed = 1f;
		}

		// Token: 0x17000528 RID: 1320
		// (get) Token: 0x06004369 RID: 17257 RVA: 0x0002CD25 File Offset: 0x0002AF25
		// (set) Token: 0x0600436A RID: 17258 RVA: 0x0002CD2D File Offset: 0x0002AF2D
		public float m_rechargeSpeed { get; set; }

		// Token: 0x04002EB1 RID: 11953
		[CompilerGenerated]
		private float float_0;
	}
}
