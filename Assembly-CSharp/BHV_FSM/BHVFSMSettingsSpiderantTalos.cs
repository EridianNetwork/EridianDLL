using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	// Token: 0x02000927 RID: 2343
	public class BHVFSMSettingsSpiderantTalos : BHVPropertySettingsPhase
	{
		// Token: 0x060040A9 RID: 16553 RVA: 0x0012EB80 File Offset: 0x0012CD80
		public BHVFSMSettingsSpiderantTalos()
		{
			this.m_exitPhase_hp = 0.66f;
			this.m_damageBuffMultiplier = 1f;
			this.m_meleeAttackWeight = 1f;
			this.m_iceEarthquakeAttackWeight = 1f;
			this.m_iceMeteorRandomAttackWeight = 1f;
			this.m_iceMeteorRowAttackWeight = 1f;
			this.m_chargeAttackWeight = 1f;
			this.m_minionSummonWeight = 1f;
			this.m_earthPikeAttackWeight = 1f;
			this.m_spacingTime = 5f;
			this.m_spacingRangeMin = 10f;
			this.m_spacingRangeMax = 18f;
		}

		// Token: 0x170003EA RID: 1002
		// (get) Token: 0x060040AA RID: 16554 RVA: 0x0002B2D8 File Offset: 0x000294D8
		// (set) Token: 0x060040AB RID: 16555 RVA: 0x0002B2E0 File Offset: 0x000294E0
		[DefaultValue(typeof(float), "0.66")]
		public float m_exitPhase_hp { get; set; }

		// Token: 0x170003EB RID: 1003
		// (get) Token: 0x060040AC RID: 16556 RVA: 0x0002B2E9 File Offset: 0x000294E9
		// (set) Token: 0x060040AD RID: 16557 RVA: 0x0002B2F1 File Offset: 0x000294F1
		[DefaultValue(typeof(float), "1")]
		public float m_damageBuffMultiplier { get; set; }

		// Token: 0x170003EC RID: 1004
		// (get) Token: 0x060040AE RID: 16558 RVA: 0x0002B2FA File Offset: 0x000294FA
		// (set) Token: 0x060040AF RID: 16559 RVA: 0x0002B302 File Offset: 0x00029502
		[DefaultValue(typeof(float), "1")]
		public float m_meleeAttackWeight { get; set; }

		// Token: 0x170003ED RID: 1005
		// (get) Token: 0x060040B0 RID: 16560 RVA: 0x0002B30B File Offset: 0x0002950B
		// (set) Token: 0x060040B1 RID: 16561 RVA: 0x0002B313 File Offset: 0x00029513
		[DefaultValue(typeof(float), "1")]
		public float m_iceEarthquakeAttackWeight { get; set; }

		// Token: 0x170003EE RID: 1006
		// (get) Token: 0x060040B2 RID: 16562 RVA: 0x0002B31C File Offset: 0x0002951C
		// (set) Token: 0x060040B3 RID: 16563 RVA: 0x0002B324 File Offset: 0x00029524
		[DefaultValue(typeof(float), "1")]
		public float m_iceMeteorRandomAttackWeight { get; set; }

		// Token: 0x170003EF RID: 1007
		// (get) Token: 0x060040B4 RID: 16564 RVA: 0x0002B32D File Offset: 0x0002952D
		// (set) Token: 0x060040B5 RID: 16565 RVA: 0x0002B335 File Offset: 0x00029535
		[DefaultValue(typeof(float), "1")]
		public float m_iceMeteorRowAttackWeight { get; set; }

		// Token: 0x170003F0 RID: 1008
		// (get) Token: 0x060040B6 RID: 16566 RVA: 0x0002B33E File Offset: 0x0002953E
		// (set) Token: 0x060040B7 RID: 16567 RVA: 0x0002B346 File Offset: 0x00029546
		[DefaultValue(typeof(float), "1")]
		public float m_chargeAttackWeight { get; set; }

		// Token: 0x170003F1 RID: 1009
		// (get) Token: 0x060040B8 RID: 16568 RVA: 0x0002B34F File Offset: 0x0002954F
		// (set) Token: 0x060040B9 RID: 16569 RVA: 0x0002B357 File Offset: 0x00029557
		[DefaultValue(typeof(float), "1")]
		public float m_minionSummonWeight { get; set; }

		// Token: 0x170003F2 RID: 1010
		// (get) Token: 0x060040BA RID: 16570 RVA: 0x0002B360 File Offset: 0x00029560
		// (set) Token: 0x060040BB RID: 16571 RVA: 0x0002B368 File Offset: 0x00029568
		[DefaultValue(typeof(float), "1")]
		public float m_earthPikeAttackWeight { get; set; }

		// Token: 0x170003F3 RID: 1011
		// (get) Token: 0x060040BC RID: 16572 RVA: 0x0002B371 File Offset: 0x00029571
		// (set) Token: 0x060040BD RID: 16573 RVA: 0x0002B379 File Offset: 0x00029579
		[DefaultValue(typeof(float), "5")]
		public float m_spacingTime { get; set; }

		// Token: 0x170003F4 RID: 1012
		// (get) Token: 0x060040BE RID: 16574 RVA: 0x0002B382 File Offset: 0x00029582
		// (set) Token: 0x060040BF RID: 16575 RVA: 0x0002B38A File Offset: 0x0002958A
		[DefaultValue(typeof(float), "10")]
		public float m_spacingRangeMin { get; set; }

		// Token: 0x170003F5 RID: 1013
		// (get) Token: 0x060040C0 RID: 16576 RVA: 0x0002B393 File Offset: 0x00029593
		// (set) Token: 0x060040C1 RID: 16577 RVA: 0x0002B39B File Offset: 0x0002959B
		[DefaultValue(typeof(float), "18")]
		public float m_spacingRangeMax { get; set; }

		// Token: 0x170003F6 RID: 1014
		// (get) Token: 0x060040C2 RID: 16578 RVA: 0x0002B3A4 File Offset: 0x000295A4
		// (set) Token: 0x060040C3 RID: 16579 RVA: 0x0002B3AC File Offset: 0x000295AC
		public float m_idleTimeBeforeSecondChargeAttack { get; set; }

		// Token: 0x04002D49 RID: 11593
		[CompilerGenerated]
		private float float_0;

		// Token: 0x04002D4A RID: 11594
		[CompilerGenerated]
		private float float_1;

		// Token: 0x04002D4B RID: 11595
		[CompilerGenerated]
		private float float_2;

		// Token: 0x04002D4C RID: 11596
		[CompilerGenerated]
		private float float_3;

		// Token: 0x04002D4D RID: 11597
		[CompilerGenerated]
		private float float_4;

		// Token: 0x04002D4E RID: 11598
		[CompilerGenerated]
		private float float_5;

		// Token: 0x04002D4F RID: 11599
		[CompilerGenerated]
		private float float_6;

		// Token: 0x04002D50 RID: 11600
		[CompilerGenerated]
		private float float_7;

		// Token: 0x04002D51 RID: 11601
		[CompilerGenerated]
		private float float_8;

		// Token: 0x04002D52 RID: 11602
		[CompilerGenerated]
		private float float_9;

		// Token: 0x04002D53 RID: 11603
		[CompilerGenerated]
		private float float_10;

		// Token: 0x04002D54 RID: 11604
		[CompilerGenerated]
		private float float_11;

		// Token: 0x04002D55 RID: 11605
		[CompilerGenerated]
		private float float_12;
	}
}
