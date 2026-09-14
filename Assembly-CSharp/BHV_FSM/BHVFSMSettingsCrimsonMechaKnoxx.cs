using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	// Token: 0x02000926 RID: 2342
	public class BHVFSMSettingsCrimsonMechaKnoxx : BHVPropertySettingsPhase
	{
		// Token: 0x0600408A RID: 16522 RVA: 0x0012EAC8 File Offset: 0x0012CCC8
		public BHVFSMSettingsCrimsonMechaKnoxx()
		{
			this.m_exitPhase_hp = 0.66f;
			this.m_damageBuffMultiplier = 1f;
			this.m_meleeAttackWeight = 1f;
			this.m_railgunAttackWeight = 1f;
			this.m_jetAttackWeight = 1f;
			this.m_chargeAttackWeight = 1f;
			this.m_mortarAttackWeight = 1f;
			this.m_spacingTime = 5f;
			this.m_spacingRangeMin = 10f;
			this.m_spacingRangeMax = 18f;
			this.m_plasmaBallDamage = 80f;
			this.m_plasmaBallSpeed = 20f;
			this.m_plasmaBallDamageRadius = 1.5f;
			this.m_plasmaBallDamageDuration = 2f;
			this.m_laserSweepWeight = 1f;
		}

		// Token: 0x170003DB RID: 987
		// (get) Token: 0x0600408B RID: 16523 RVA: 0x0002B1D9 File Offset: 0x000293D9
		// (set) Token: 0x0600408C RID: 16524 RVA: 0x0002B1E1 File Offset: 0x000293E1
		[DefaultValue(typeof(float), "0.66")]
		public float m_exitPhase_hp { get; set; }

		// Token: 0x170003DC RID: 988
		// (get) Token: 0x0600408D RID: 16525 RVA: 0x0002B1EA File Offset: 0x000293EA
		// (set) Token: 0x0600408E RID: 16526 RVA: 0x0002B1F2 File Offset: 0x000293F2
		[DefaultValue(typeof(float), "1")]
		public float m_damageBuffMultiplier { get; set; }

		// Token: 0x170003DD RID: 989
		// (get) Token: 0x0600408F RID: 16527 RVA: 0x0002B1FB File Offset: 0x000293FB
		// (set) Token: 0x06004090 RID: 16528 RVA: 0x0002B203 File Offset: 0x00029403
		[DefaultValue(typeof(float), "1")]
		public float m_meleeAttackWeight { get; set; }

		// Token: 0x170003DE RID: 990
		// (get) Token: 0x06004091 RID: 16529 RVA: 0x0002B20C File Offset: 0x0002940C
		// (set) Token: 0x06004092 RID: 16530 RVA: 0x0002B214 File Offset: 0x00029414
		[DefaultValue(typeof(float), "1")]
		public float m_railgunAttackWeight { get; set; }

		// Token: 0x170003DF RID: 991
		// (get) Token: 0x06004093 RID: 16531 RVA: 0x0002B21D File Offset: 0x0002941D
		// (set) Token: 0x06004094 RID: 16532 RVA: 0x0002B225 File Offset: 0x00029425
		[DefaultValue(typeof(float), "1")]
		public float m_jetAttackWeight { get; set; }

		// Token: 0x170003E0 RID: 992
		// (get) Token: 0x06004095 RID: 16533 RVA: 0x0002B22E File Offset: 0x0002942E
		// (set) Token: 0x06004096 RID: 16534 RVA: 0x0002B236 File Offset: 0x00029436
		[DefaultValue(typeof(float), "1")]
		public float m_chargeAttackWeight { get; set; }

		// Token: 0x170003E1 RID: 993
		// (get) Token: 0x06004097 RID: 16535 RVA: 0x0002B23F File Offset: 0x0002943F
		// (set) Token: 0x06004098 RID: 16536 RVA: 0x0002B247 File Offset: 0x00029447
		[DefaultValue(typeof(float), "1")]
		public float m_mortarAttackWeight { get; set; }

		// Token: 0x170003E2 RID: 994
		// (get) Token: 0x06004099 RID: 16537 RVA: 0x0002B250 File Offset: 0x00029450
		// (set) Token: 0x0600409A RID: 16538 RVA: 0x0002B258 File Offset: 0x00029458
		[DefaultValue(typeof(float), "5")]
		public float m_spacingTime { get; set; }

		// Token: 0x170003E3 RID: 995
		// (get) Token: 0x0600409B RID: 16539 RVA: 0x0002B261 File Offset: 0x00029461
		// (set) Token: 0x0600409C RID: 16540 RVA: 0x0002B269 File Offset: 0x00029469
		[DefaultValue(typeof(float), "10")]
		public float m_spacingRangeMin { get; set; }

		// Token: 0x170003E4 RID: 996
		// (get) Token: 0x0600409D RID: 16541 RVA: 0x0002B272 File Offset: 0x00029472
		// (set) Token: 0x0600409E RID: 16542 RVA: 0x0002B27A File Offset: 0x0002947A
		[DefaultValue(typeof(float), "18")]
		public float m_spacingRangeMax { get; set; }

		// Token: 0x170003E5 RID: 997
		// (get) Token: 0x0600409F RID: 16543 RVA: 0x0002B283 File Offset: 0x00029483
		// (set) Token: 0x060040A0 RID: 16544 RVA: 0x0002B28B File Offset: 0x0002948B
		[DefaultValue(typeof(float), "80")]
		public float m_plasmaBallDamage { get; set; }

		// Token: 0x170003E6 RID: 998
		// (get) Token: 0x060040A1 RID: 16545 RVA: 0x0002B294 File Offset: 0x00029494
		// (set) Token: 0x060040A2 RID: 16546 RVA: 0x0002B29C File Offset: 0x0002949C
		[DefaultValue(typeof(float), "20")]
		public float m_plasmaBallSpeed { get; set; }

		// Token: 0x170003E7 RID: 999
		// (get) Token: 0x060040A3 RID: 16547 RVA: 0x0002B2A5 File Offset: 0x000294A5
		// (set) Token: 0x060040A4 RID: 16548 RVA: 0x0002B2AD File Offset: 0x000294AD
		[DefaultValue(typeof(float), "1.5")]
		public float m_plasmaBallDamageRadius { get; set; }

		// Token: 0x170003E8 RID: 1000
		// (get) Token: 0x060040A5 RID: 16549 RVA: 0x0002B2B6 File Offset: 0x000294B6
		// (set) Token: 0x060040A6 RID: 16550 RVA: 0x0002B2BE File Offset: 0x000294BE
		[DefaultValue(typeof(float), "2")]
		public float m_plasmaBallDamageDuration { get; set; }

		// Token: 0x170003E9 RID: 1001
		// (get) Token: 0x060040A7 RID: 16551 RVA: 0x0002B2C7 File Offset: 0x000294C7
		// (set) Token: 0x060040A8 RID: 16552 RVA: 0x0002B2CF File Offset: 0x000294CF
		[DefaultValue(typeof(float), "1")]
		public float m_laserSweepWeight { get; set; }

		// Token: 0x04002D3A RID: 11578
		[CompilerGenerated]
		private float float_0;

		// Token: 0x04002D3B RID: 11579
		[CompilerGenerated]
		private float float_1;

		// Token: 0x04002D3C RID: 11580
		[CompilerGenerated]
		private float float_2;

		// Token: 0x04002D3D RID: 11581
		[CompilerGenerated]
		private float float_3;

		// Token: 0x04002D3E RID: 11582
		[CompilerGenerated]
		private float float_4;

		// Token: 0x04002D3F RID: 11583
		[CompilerGenerated]
		private float float_5;

		// Token: 0x04002D40 RID: 11584
		[CompilerGenerated]
		private float float_6;

		// Token: 0x04002D41 RID: 11585
		[CompilerGenerated]
		private float float_7;

		// Token: 0x04002D42 RID: 11586
		[CompilerGenerated]
		private float float_8;

		// Token: 0x04002D43 RID: 11587
		[CompilerGenerated]
		private float float_9;

		// Token: 0x04002D44 RID: 11588
		[CompilerGenerated]
		private float float_10;

		// Token: 0x04002D45 RID: 11589
		[CompilerGenerated]
		private float float_11;

		// Token: 0x04002D46 RID: 11590
		[CompilerGenerated]
		private float float_12;

		// Token: 0x04002D47 RID: 11591
		[CompilerGenerated]
		private float float_13;

		// Token: 0x04002D48 RID: 11592
		[CompilerGenerated]
		private float float_14;
	}
}
