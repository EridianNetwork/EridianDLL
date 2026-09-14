using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	// Token: 0x02000928 RID: 2344
	public class BHVFSMSettingsSpiderantWidowmaker : BHVPropertySettingsPhase
	{
		// Token: 0x060040C4 RID: 16580 RVA: 0x0012EC18 File Offset: 0x0012CE18
		public BHVFSMSettingsSpiderantWidowmaker()
		{
			this.m_exitPhase_hp = 0.66f;
			this.m_damageBuffMultiplier = 1f;
			this.m_meleeAttackWeight = 1f;
			this.m_jumpAttackWeight = 1f;
			this.m_radiusAttackWeight = 1f;
			this.m_burrowAttackWeight = 1f;
			this.m_spacingTime = 5f;
			this.m_spacingRangeMin = 10f;
			this.m_spacingRangeMax = 18f;
			this.m_webTrapWeight = 0f;
		}

		// Token: 0x170003F7 RID: 1015
		// (get) Token: 0x060040C5 RID: 16581 RVA: 0x0002B3B5 File Offset: 0x000295B5
		// (set) Token: 0x060040C6 RID: 16582 RVA: 0x0002B3BD File Offset: 0x000295BD
		[DefaultValue(typeof(float), "0.66")]
		public float m_exitPhase_hp { get; set; }

		// Token: 0x170003F8 RID: 1016
		// (get) Token: 0x060040C7 RID: 16583 RVA: 0x0002B3C6 File Offset: 0x000295C6
		// (set) Token: 0x060040C8 RID: 16584 RVA: 0x0002B3CE File Offset: 0x000295CE
		[DefaultValue(typeof(float), "1")]
		public float m_damageBuffMultiplier { get; set; }

		// Token: 0x170003F9 RID: 1017
		// (get) Token: 0x060040C9 RID: 16585 RVA: 0x0002B3D7 File Offset: 0x000295D7
		// (set) Token: 0x060040CA RID: 16586 RVA: 0x0002B3DF File Offset: 0x000295DF
		[DefaultValue(typeof(float), "1")]
		public float m_meleeAttackWeight { get; set; }

		// Token: 0x170003FA RID: 1018
		// (get) Token: 0x060040CB RID: 16587 RVA: 0x0002B3E8 File Offset: 0x000295E8
		// (set) Token: 0x060040CC RID: 16588 RVA: 0x0002B3F0 File Offset: 0x000295F0
		[DefaultValue(typeof(float), "1")]
		public float m_jumpAttackWeight { get; set; }

		// Token: 0x170003FB RID: 1019
		// (get) Token: 0x060040CD RID: 16589 RVA: 0x0002B3F9 File Offset: 0x000295F9
		// (set) Token: 0x060040CE RID: 16590 RVA: 0x0002B401 File Offset: 0x00029601
		[DefaultValue(typeof(float), "1")]
		public float m_radiusAttackWeight { get; set; }

		// Token: 0x170003FC RID: 1020
		// (get) Token: 0x060040CF RID: 16591 RVA: 0x0002B40A File Offset: 0x0002960A
		// (set) Token: 0x060040D0 RID: 16592 RVA: 0x0002B412 File Offset: 0x00029612
		[DefaultValue(typeof(float), "1")]
		public float m_burrowAttackWeight { get; set; }

		// Token: 0x170003FD RID: 1021
		// (get) Token: 0x060040D1 RID: 16593 RVA: 0x0002B41B File Offset: 0x0002961B
		// (set) Token: 0x060040D2 RID: 16594 RVA: 0x0002B423 File Offset: 0x00029623
		[DefaultValue(typeof(float), "5")]
		public float m_spacingTime { get; set; }

		// Token: 0x170003FE RID: 1022
		// (get) Token: 0x060040D3 RID: 16595 RVA: 0x0002B42C File Offset: 0x0002962C
		// (set) Token: 0x060040D4 RID: 16596 RVA: 0x0002B434 File Offset: 0x00029634
		[DefaultValue(typeof(float), "10")]
		public float m_spacingRangeMin { get; set; }

		// Token: 0x170003FF RID: 1023
		// (get) Token: 0x060040D5 RID: 16597 RVA: 0x0002B43D File Offset: 0x0002963D
		// (set) Token: 0x060040D6 RID: 16598 RVA: 0x0002B445 File Offset: 0x00029645
		[DefaultValue(typeof(float), "18")]
		public float m_spacingRangeMax { get; set; }

		// Token: 0x17000400 RID: 1024
		// (get) Token: 0x060040D7 RID: 16599 RVA: 0x0002B44E File Offset: 0x0002964E
		// (set) Token: 0x060040D8 RID: 16600 RVA: 0x0002B456 File Offset: 0x00029656
		[DefaultValue(typeof(float), "0")]
		public float m_webTrapWeight { get; set; }

		// Token: 0x04002D56 RID: 11606
		[CompilerGenerated]
		private float float_0;

		// Token: 0x04002D57 RID: 11607
		[CompilerGenerated]
		private float float_1;

		// Token: 0x04002D58 RID: 11608
		[CompilerGenerated]
		private float float_2;

		// Token: 0x04002D59 RID: 11609
		[CompilerGenerated]
		private float float_3;

		// Token: 0x04002D5A RID: 11610
		[CompilerGenerated]
		private float float_4;

		// Token: 0x04002D5B RID: 11611
		[CompilerGenerated]
		private float float_5;

		// Token: 0x04002D5C RID: 11612
		[CompilerGenerated]
		private float float_6;

		// Token: 0x04002D5D RID: 11613
		[CompilerGenerated]
		private float float_7;

		// Token: 0x04002D5E RID: 11614
		[CompilerGenerated]
		private float float_8;

		// Token: 0x04002D5F RID: 11615
		[CompilerGenerated]
		private float float_9;
	}
}
