using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using XsdSettings;

namespace BHV
{
	// Token: 0x0200097B RID: 2427
	public class BHVChargeAttackSettings : BHVTaskSettings
	{
		// Token: 0x06004427 RID: 17447 RVA: 0x0002D42B File Offset: 0x0002B62B
		public BHVChargeAttackSettings()
		{
			this.m_attackDamage = 1;
			this.m_checkRadius = 0.5f;
			this.m_attackSubType = AttackSubType.MeleeGeneric;
		}

		// Token: 0x17000580 RID: 1408
		// (get) Token: 0x06004428 RID: 17448 RVA: 0x0002D44D File Offset: 0x0002B64D
		// (set) Token: 0x06004429 RID: 17449 RVA: 0x0002D455 File Offset: 0x0002B655
		[DefaultValue(1)]
		public int m_attackDamage { get; set; }

		// Token: 0x17000581 RID: 1409
		// (get) Token: 0x0600442A RID: 17450 RVA: 0x0002D45E File Offset: 0x0002B65E
		// (set) Token: 0x0600442B RID: 17451 RVA: 0x0002D466 File Offset: 0x0002B666
		[DefaultValue(typeof(float), "0.5")]
		public float m_checkRadius { get; set; }

		// Token: 0x17000582 RID: 1410
		// (get) Token: 0x0600442C RID: 17452 RVA: 0x0002D46F File Offset: 0x0002B66F
		// (set) Token: 0x0600442D RID: 17453 RVA: 0x0002D477 File Offset: 0x0002B677
		[DefaultValue(AttackSubType.MeleeGeneric)]
		public AttackSubType m_attackSubType { get; set; }

		// Token: 0x04002F0B RID: 12043
		[CompilerGenerated]
		private int int_0;

		// Token: 0x04002F0C RID: 12044
		[CompilerGenerated]
		private float float_0;

		// Token: 0x04002F0D RID: 12045
		[CompilerGenerated]
		private AttackSubType attackSubType_0;
	}
}
