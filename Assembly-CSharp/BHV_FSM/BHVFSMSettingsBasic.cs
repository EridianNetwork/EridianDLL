using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	// Token: 0x0200093E RID: 2366
	public class BHVFSMSettingsBasic : BHVPropertySettings
	{
		// Token: 0x060041AC RID: 16812 RVA: 0x0012EEC8 File Offset: 0x0012D0C8
		public BHVFSMSettingsBasic()
		{
			this.m_healthPoint = 0;
			this.m_shieldPoint = 0;
			this.m_beenShotAtDuration = 0f;
			this.m_enemyAlertRange = 30f;
			this.m_bHasLightHurtEffect = true;
			this.m_startMoveDistance = 5f;
			this.m_bHasCoverAbility = false;
			this.m_alertCoverChanceWeight = 1f;
			this.m_alertMoveToGPPChanceWeight = 1f;
			this.m_bHasFullbodyHitReaction = true;
		}

		// Token: 0x17000460 RID: 1120
		// (get) Token: 0x060041AD RID: 16813 RVA: 0x0002BD61 File Offset: 0x00029F61
		// (set) Token: 0x060041AE RID: 16814 RVA: 0x0002BD69 File Offset: 0x00029F69
		[DefaultValue(0)]
		public int m_healthPoint { get; set; }

		// Token: 0x17000461 RID: 1121
		// (get) Token: 0x060041AF RID: 16815 RVA: 0x0002BD72 File Offset: 0x00029F72
		// (set) Token: 0x060041B0 RID: 16816 RVA: 0x0002BD7A File Offset: 0x00029F7A
		[DefaultValue(0)]
		public int m_shieldPoint { get; set; }

		// Token: 0x17000462 RID: 1122
		// (get) Token: 0x060041B1 RID: 16817 RVA: 0x0002BD83 File Offset: 0x00029F83
		// (set) Token: 0x060041B2 RID: 16818 RVA: 0x0002BD8B File Offset: 0x00029F8B
		[DefaultValue(typeof(float), "0")]
		public float m_beenShotAtDuration { get; set; }

		// Token: 0x17000463 RID: 1123
		// (get) Token: 0x060041B3 RID: 16819 RVA: 0x0002BD94 File Offset: 0x00029F94
		// (set) Token: 0x060041B4 RID: 16820 RVA: 0x0002BD9C File Offset: 0x00029F9C
		[DefaultValue(typeof(float), "30")]
		public float m_enemyAlertRange { get; set; }

		// Token: 0x17000464 RID: 1124
		// (get) Token: 0x060041B5 RID: 16821 RVA: 0x0002BDA5 File Offset: 0x00029FA5
		// (set) Token: 0x060041B6 RID: 16822 RVA: 0x0002BDAD File Offset: 0x00029FAD
		[DefaultValue(true)]
		public bool m_bHasLightHurtEffect { get; set; }

		// Token: 0x17000465 RID: 1125
		// (get) Token: 0x060041B7 RID: 16823 RVA: 0x0002BDB6 File Offset: 0x00029FB6
		// (set) Token: 0x060041B8 RID: 16824 RVA: 0x0002BDBE File Offset: 0x00029FBE
		[DefaultValue(typeof(float), "5")]
		public float m_startMoveDistance { get; set; }

		// Token: 0x17000466 RID: 1126
		// (get) Token: 0x060041B9 RID: 16825 RVA: 0x0002BDC7 File Offset: 0x00029FC7
		// (set) Token: 0x060041BA RID: 16826 RVA: 0x0002BDCF File Offset: 0x00029FCF
		[DefaultValue(false)]
		public bool m_bHasCoverAbility { get; set; }

		// Token: 0x17000467 RID: 1127
		// (get) Token: 0x060041BB RID: 16827 RVA: 0x0002BDD8 File Offset: 0x00029FD8
		// (set) Token: 0x060041BC RID: 16828 RVA: 0x0002BDE0 File Offset: 0x00029FE0
		[DefaultValue(typeof(float), "1")]
		public float m_alertCoverChanceWeight { get; set; }

		// Token: 0x17000468 RID: 1128
		// (get) Token: 0x060041BD RID: 16829 RVA: 0x0002BDE9 File Offset: 0x00029FE9
		// (set) Token: 0x060041BE RID: 16830 RVA: 0x0002BDF1 File Offset: 0x00029FF1
		[DefaultValue(typeof(float), "1")]
		public float m_alertMoveToGPPChanceWeight { get; set; }

		// Token: 0x17000469 RID: 1129
		// (get) Token: 0x060041BF RID: 16831 RVA: 0x0002BDFA File Offset: 0x00029FFA
		// (set) Token: 0x060041C0 RID: 16832 RVA: 0x0002BE02 File Offset: 0x0002A002
		[DefaultValue(true)]
		public bool m_bHasFullbodyHitReaction { get; set; }

		// Token: 0x04002DBF RID: 11711
		[CompilerGenerated]
		private int int_0;

		// Token: 0x04002DC0 RID: 11712
		[CompilerGenerated]
		private int int_1;

		// Token: 0x04002DC1 RID: 11713
		[CompilerGenerated]
		private float float_0;

		// Token: 0x04002DC2 RID: 11714
		[CompilerGenerated]
		private float float_1;

		// Token: 0x04002DC3 RID: 11715
		[CompilerGenerated]
		private bool bool_0;

		// Token: 0x04002DC4 RID: 11716
		[CompilerGenerated]
		private float float_2;

		// Token: 0x04002DC5 RID: 11717
		[CompilerGenerated]
		private bool bool_1;

		// Token: 0x04002DC6 RID: 11718
		[CompilerGenerated]
		private float float_3;

		// Token: 0x04002DC7 RID: 11719
		[CompilerGenerated]
		private float float_4;

		// Token: 0x04002DC8 RID: 11720
		[CompilerGenerated]
		private bool bool_2;
	}
}
