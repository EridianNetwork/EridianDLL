using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using XsdSettings;

namespace BHV
{
	// Token: 0x02000974 RID: 2420
	public class BHVRadiusAttackSettings : BHVTaskSettings
	{
		// Token: 0x060043AA RID: 17322 RVA: 0x0002CFB4 File Offset: 0x0002B1B4
		public BHVRadiusAttackSettings()
		{
			this.m_attackDamage = 15;
			this.m_attackSubType = AttackSubType.AreaGeneric;
		}

		// Token: 0x17000545 RID: 1349
		// (get) Token: 0x060043AB RID: 17323 RVA: 0x0002CFCC File Offset: 0x0002B1CC
		// (set) Token: 0x060043AC RID: 17324 RVA: 0x0002CFD4 File Offset: 0x0002B1D4
		[DefaultValue(15)]
		public int m_attackDamage { get; set; }

		// Token: 0x17000546 RID: 1350
		// (get) Token: 0x060043AD RID: 17325 RVA: 0x0002CFDD File Offset: 0x0002B1DD
		// (set) Token: 0x060043AE RID: 17326 RVA: 0x0002CFE5 File Offset: 0x0002B1E5
		[DefaultValue(AttackSubType.AreaGeneric)]
		public AttackSubType m_attackSubType { get; set; }

		// Token: 0x04002ECF RID: 11983
		[CompilerGenerated]
		private int int_0;

		// Token: 0x04002ED0 RID: 11984
		[CompilerGenerated]
		private AttackSubType attackSubType_0;
	}
}
