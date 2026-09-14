using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using XsdSettings;

namespace BHV
{
	// Token: 0x0200097C RID: 2428
	public class BHVBlowUpAttackSettings : BHVTaskSettings
	{
		// Token: 0x0600442E RID: 17454 RVA: 0x0002D480 File Offset: 0x0002B680
		public BHVBlowUpAttackSettings()
		{
			this.m_attackRange = 0.01f;
			this.m_attackDamage = 1;
			this.m_attackDamageMultiplier = 1f;
			this.m_playerAttackDamageMultiplier = 1f;
			this.m_attackSubType = AttackSubType.AreaExplosion;
		}

		// Token: 0x17000583 RID: 1411
		// (get) Token: 0x0600442F RID: 17455 RVA: 0x0002D4B8 File Offset: 0x0002B6B8
		// (set) Token: 0x06004430 RID: 17456 RVA: 0x0002D4C0 File Offset: 0x0002B6C0
		[DefaultValue(typeof(float), "0.01")]
		public float m_attackRange { get; set; }

		// Token: 0x17000584 RID: 1412
		// (get) Token: 0x06004431 RID: 17457 RVA: 0x0002D4C9 File Offset: 0x0002B6C9
		// (set) Token: 0x06004432 RID: 17458 RVA: 0x0002D4D1 File Offset: 0x0002B6D1
		[DefaultValue(1)]
		public int m_attackDamage { get; set; }

		// Token: 0x17000585 RID: 1413
		// (get) Token: 0x06004433 RID: 17459 RVA: 0x0002D4DA File Offset: 0x0002B6DA
		// (set) Token: 0x06004434 RID: 17460 RVA: 0x0002D4E2 File Offset: 0x0002B6E2
		[DefaultValue(typeof(float), "1")]
		public float m_attackDamageMultiplier { get; set; }

		// Token: 0x17000586 RID: 1414
		// (get) Token: 0x06004435 RID: 17461 RVA: 0x0002D4EB File Offset: 0x0002B6EB
		// (set) Token: 0x06004436 RID: 17462 RVA: 0x0002D4F3 File Offset: 0x0002B6F3
		[DefaultValue(typeof(float), "1")]
		public float m_playerAttackDamageMultiplier { get; set; }

		// Token: 0x17000587 RID: 1415
		// (get) Token: 0x06004437 RID: 17463 RVA: 0x0002D4FC File Offset: 0x0002B6FC
		// (set) Token: 0x06004438 RID: 17464 RVA: 0x0002D504 File Offset: 0x0002B704
		[DefaultValue(AttackSubType.AreaExplosion)]
		public AttackSubType m_attackSubType { get; set; }

		// Token: 0x04002F0E RID: 12046
		[CompilerGenerated]
		private float float_0;

		// Token: 0x04002F0F RID: 12047
		[CompilerGenerated]
		private int int_0;

		// Token: 0x04002F10 RID: 12048
		[CompilerGenerated]
		private float float_1;

		// Token: 0x04002F11 RID: 12049
		[CompilerGenerated]
		private float float_2;

		// Token: 0x04002F12 RID: 12050
		[CompilerGenerated]
		private AttackSubType attackSubType_0;
	}
}
