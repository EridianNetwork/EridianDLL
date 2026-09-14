using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	// Token: 0x0200095E RID: 2398
	public class BHVFSMSettingsRailGunAttack : BHVPropertySettingsAttackBase
	{
		// Token: 0x060042B3 RID: 17075 RVA: 0x0002C742 File Offset: 0x0002A942
		public BHVFSMSettingsRailGunAttack()
		{
			this.m_plasmaBallDamage = 0.2f;
			this.m_plasmaBallSpeed = 20f;
			this.m_plasmaBallDamageRadius = 1.5f;
			this.m_plasmaBallDamageDuration = 2f;
		}

		// Token: 0x170004D4 RID: 1236
		// (get) Token: 0x060042B4 RID: 17076 RVA: 0x0002C776 File Offset: 0x0002A976
		// (set) Token: 0x060042B5 RID: 17077 RVA: 0x0002C77E File Offset: 0x0002A97E
		[DefaultValue(typeof(float), "0.2")]
		public float m_plasmaBallDamage { get; set; }

		// Token: 0x170004D5 RID: 1237
		// (get) Token: 0x060042B6 RID: 17078 RVA: 0x0002C787 File Offset: 0x0002A987
		// (set) Token: 0x060042B7 RID: 17079 RVA: 0x0002C78F File Offset: 0x0002A98F
		[DefaultValue(typeof(float), "20")]
		public float m_plasmaBallSpeed { get; set; }

		// Token: 0x170004D6 RID: 1238
		// (get) Token: 0x060042B8 RID: 17080 RVA: 0x0002C798 File Offset: 0x0002A998
		// (set) Token: 0x060042B9 RID: 17081 RVA: 0x0002C7A0 File Offset: 0x0002A9A0
		[DefaultValue(typeof(float), "1.5")]
		public float m_plasmaBallDamageRadius { get; set; }

		// Token: 0x170004D7 RID: 1239
		// (get) Token: 0x060042BA RID: 17082 RVA: 0x0002C7A9 File Offset: 0x0002A9A9
		// (set) Token: 0x060042BB RID: 17083 RVA: 0x0002C7B1 File Offset: 0x0002A9B1
		[DefaultValue(typeof(float), "2")]
		public float m_plasmaBallDamageDuration { get; set; }

		// Token: 0x04002E57 RID: 11863
		[CompilerGenerated]
		private float float_3;

		// Token: 0x04002E58 RID: 11864
		[CompilerGenerated]
		private float float_4;

		// Token: 0x04002E59 RID: 11865
		[CompilerGenerated]
		private float float_5;

		// Token: 0x04002E5A RID: 11866
		[CompilerGenerated]
		private float float_6;
	}
}
