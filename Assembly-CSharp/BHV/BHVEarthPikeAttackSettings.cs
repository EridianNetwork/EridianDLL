using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV
{
	// Token: 0x02000972 RID: 2418
	public class BHVEarthPikeAttackSettings : BHVTaskSettings
	{
		// Token: 0x0600439C RID: 17308 RVA: 0x0002CF0A File Offset: 0x0002B10A
		public BHVEarthPikeAttackSettings()
		{
			this.m_pikeDamage = 30;
			this.m_pikeAmount = 3;
			this.m_pikeDamageRadius = 1.5f;
			this.m_distanceToPlayer = 1.5f;
		}

		// Token: 0x1700053F RID: 1343
		// (get) Token: 0x0600439D RID: 17309 RVA: 0x0002CF37 File Offset: 0x0002B137
		// (set) Token: 0x0600439E RID: 17310 RVA: 0x0002CF3F File Offset: 0x0002B13F
		[DefaultValue(30)]
		public int m_pikeDamage { get; set; }

		// Token: 0x17000540 RID: 1344
		// (get) Token: 0x0600439F RID: 17311 RVA: 0x0002CF48 File Offset: 0x0002B148
		// (set) Token: 0x060043A0 RID: 17312 RVA: 0x0002CF50 File Offset: 0x0002B150
		[DefaultValue(3)]
		public int m_pikeAmount { get; set; }

		// Token: 0x17000541 RID: 1345
		// (get) Token: 0x060043A1 RID: 17313 RVA: 0x0002CF59 File Offset: 0x0002B159
		// (set) Token: 0x060043A2 RID: 17314 RVA: 0x0002CF61 File Offset: 0x0002B161
		[DefaultValue(typeof(float), "1.5")]
		public float m_pikeDamageRadius { get; set; }

		// Token: 0x17000542 RID: 1346
		// (get) Token: 0x060043A3 RID: 17315 RVA: 0x0002CF6A File Offset: 0x0002B16A
		// (set) Token: 0x060043A4 RID: 17316 RVA: 0x0002CF72 File Offset: 0x0002B172
		[DefaultValue(typeof(float), "1.5")]
		public float m_distanceToPlayer { get; set; }

		// Token: 0x04002EC9 RID: 11977
		[CompilerGenerated]
		private int int_0;

		// Token: 0x04002ECA RID: 11978
		[CompilerGenerated]
		private int int_1;

		// Token: 0x04002ECB RID: 11979
		[CompilerGenerated]
		private float float_0;

		// Token: 0x04002ECC RID: 11980
		[CompilerGenerated]
		private float float_1;
	}
}
