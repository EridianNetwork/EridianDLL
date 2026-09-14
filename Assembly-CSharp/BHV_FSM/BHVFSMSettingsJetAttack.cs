using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	// Token: 0x0200095D RID: 2397
	public class BHVFSMSettingsJetAttack : BHVPropertySettingsAttackBase
	{
		// Token: 0x060042A6 RID: 17062 RVA: 0x0012EFA8 File Offset: 0x0012D1A8
		public BHVFSMSettingsJetAttack()
		{
			this.m_jetAttackDamage = 60;
			this.m_attackDistanceMin = 30f;
			this.m_attackDistanceMax = 5f;
			this.m_damageRadius = 3f;
			this.m_jetFlyingSpeed = 15f;
			this.m_jetAttackIdleTime = 1f;
		}

		// Token: 0x170004CE RID: 1230
		// (get) Token: 0x060042A7 RID: 17063 RVA: 0x0002C6DC File Offset: 0x0002A8DC
		// (set) Token: 0x060042A8 RID: 17064 RVA: 0x0002C6E4 File Offset: 0x0002A8E4
		[DefaultValue(60)]
		public int m_jetAttackDamage { get; set; }

		// Token: 0x170004CF RID: 1231
		// (get) Token: 0x060042A9 RID: 17065 RVA: 0x0002C6ED File Offset: 0x0002A8ED
		// (set) Token: 0x060042AA RID: 17066 RVA: 0x0002C6F5 File Offset: 0x0002A8F5
		[DefaultValue(typeof(float), "30")]
		public float m_attackDistanceMin { get; set; }

		// Token: 0x170004D0 RID: 1232
		// (get) Token: 0x060042AB RID: 17067 RVA: 0x0002C6FE File Offset: 0x0002A8FE
		// (set) Token: 0x060042AC RID: 17068 RVA: 0x0002C706 File Offset: 0x0002A906
		[DefaultValue(typeof(float), "5")]
		public float m_attackDistanceMax { get; set; }

		// Token: 0x170004D1 RID: 1233
		// (get) Token: 0x060042AD RID: 17069 RVA: 0x0002C70F File Offset: 0x0002A90F
		// (set) Token: 0x060042AE RID: 17070 RVA: 0x0002C717 File Offset: 0x0002A917
		[DefaultValue(typeof(float), "3")]
		public float m_damageRadius { get; set; }

		// Token: 0x170004D2 RID: 1234
		// (get) Token: 0x060042AF RID: 17071 RVA: 0x0002C720 File Offset: 0x0002A920
		// (set) Token: 0x060042B0 RID: 17072 RVA: 0x0002C728 File Offset: 0x0002A928
		[DefaultValue(typeof(float), "15")]
		public float m_jetFlyingSpeed { get; set; }

		// Token: 0x170004D3 RID: 1235
		// (get) Token: 0x060042B1 RID: 17073 RVA: 0x0002C731 File Offset: 0x0002A931
		// (set) Token: 0x060042B2 RID: 17074 RVA: 0x0002C739 File Offset: 0x0002A939
		[DefaultValue(typeof(float), "1")]
		public float m_jetAttackIdleTime { get; set; }

		// Token: 0x04002E51 RID: 11857
		[CompilerGenerated]
		private int int_0;

		// Token: 0x04002E52 RID: 11858
		[CompilerGenerated]
		private float float_3;

		// Token: 0x04002E53 RID: 11859
		[CompilerGenerated]
		private float float_4;

		// Token: 0x04002E54 RID: 11860
		[CompilerGenerated]
		private float float_5;

		// Token: 0x04002E55 RID: 11861
		[CompilerGenerated]
		private float float_6;

		// Token: 0x04002E56 RID: 11862
		[CompilerGenerated]
		private float float_7;
	}
}
