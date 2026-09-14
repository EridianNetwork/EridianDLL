using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using XsdSettings;

namespace BHV
{
	// Token: 0x02000973 RID: 2419
	public class BHVSpitAttackSettings : BHVTaskSettings
	{
		// Token: 0x060043A5 RID: 17317 RVA: 0x0002CF7B File Offset: 0x0002B17B
		public BHVSpitAttackSettings()
		{
			this.m_attackDamage = 60;
			this.m_attackSubType = AttackSubType.ProjectileSpit;
		}

		// Token: 0x17000543 RID: 1347
		// (get) Token: 0x060043A6 RID: 17318 RVA: 0x0002CF92 File Offset: 0x0002B192
		// (set) Token: 0x060043A7 RID: 17319 RVA: 0x0002CF9A File Offset: 0x0002B19A
		[DefaultValue(60)]
		public int m_attackDamage { get; set; }

		// Token: 0x17000544 RID: 1348
		// (get) Token: 0x060043A8 RID: 17320 RVA: 0x0002CFA3 File Offset: 0x0002B1A3
		// (set) Token: 0x060043A9 RID: 17321 RVA: 0x0002CFAB File Offset: 0x0002B1AB
		[DefaultValue(AttackSubType.ProjectileSpit)]
		public AttackSubType m_attackSubType { get; set; }

		// Token: 0x04002ECD RID: 11981
		[CompilerGenerated]
		private int int_0;

		// Token: 0x04002ECE RID: 11982
		[CompilerGenerated]
		private AttackSubType attackSubType_0;
	}
}
