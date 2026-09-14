using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV
{
	// Token: 0x02000977 RID: 2423
	public class BHVFurySettings : BHVTaskSettings
	{
		// Token: 0x060043D5 RID: 17365 RVA: 0x0002D15C File Offset: 0x0002B35C
		public BHVFurySettings()
		{
			this.m_damageModifier = 1f;
		}

		// Token: 0x17000559 RID: 1369
		// (get) Token: 0x060043D6 RID: 17366 RVA: 0x0002D16F File Offset: 0x0002B36F
		// (set) Token: 0x060043D7 RID: 17367 RVA: 0x0002D177 File Offset: 0x0002B377
		[DefaultValue(typeof(float), "1")]
		public float m_damageModifier { get; set; }

		// Token: 0x04002EE4 RID: 12004
		[CompilerGenerated]
		private float float_0;
	}
}
