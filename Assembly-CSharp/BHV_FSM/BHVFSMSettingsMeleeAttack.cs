using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	// Token: 0x0200094F RID: 2383
	public class BHVFSMSettingsMeleeAttack : BHVPropertySettingsAttackBase
	{
		// Token: 0x06004232 RID: 16946 RVA: 0x0002C167 File Offset: 0x0002A367
		public BHVFSMSettingsMeleeAttack()
		{
			this.m_meleeAttackDistanceMin = 0f;
			this.m_meleeAttackDistanceMax = 0f;
			this.m_meleeAttackAngle = 0f;
			this.m_meleeAttackIdleTime = 0f;
			this.m_cancelMeleeAttackTimer = 6f;
		}

		// Token: 0x1700049B RID: 1179
		// (get) Token: 0x06004233 RID: 16947 RVA: 0x0002C1A6 File Offset: 0x0002A3A6
		// (set) Token: 0x06004234 RID: 16948 RVA: 0x0002C1AE File Offset: 0x0002A3AE
		[DefaultValue(typeof(float), "0")]
		public float m_meleeAttackDistanceMin { get; set; }

		// Token: 0x1700049C RID: 1180
		// (get) Token: 0x06004235 RID: 16949 RVA: 0x0002C1B7 File Offset: 0x0002A3B7
		// (set) Token: 0x06004236 RID: 16950 RVA: 0x0002C1BF File Offset: 0x0002A3BF
		[DefaultValue(typeof(float), "0")]
		public float m_meleeAttackDistanceMax { get; set; }

		// Token: 0x1700049D RID: 1181
		// (get) Token: 0x06004237 RID: 16951 RVA: 0x0002C1C8 File Offset: 0x0002A3C8
		// (set) Token: 0x06004238 RID: 16952 RVA: 0x0002C1D0 File Offset: 0x0002A3D0
		[DefaultValue(typeof(float), "0")]
		public float m_meleeAttackAngle { get; set; }

		// Token: 0x1700049E RID: 1182
		// (get) Token: 0x06004239 RID: 16953 RVA: 0x0002C1D9 File Offset: 0x0002A3D9
		// (set) Token: 0x0600423A RID: 16954 RVA: 0x0002C1E1 File Offset: 0x0002A3E1
		[DefaultValue(typeof(float), "0")]
		public float m_meleeAttackIdleTime { get; set; }

		// Token: 0x1700049F RID: 1183
		// (get) Token: 0x0600423B RID: 16955 RVA: 0x0002C1EA File Offset: 0x0002A3EA
		// (set) Token: 0x0600423C RID: 16956 RVA: 0x0002C1F2 File Offset: 0x0002A3F2
		[DefaultValue(typeof(float), "6")]
		public float m_cancelMeleeAttackTimer { get; set; }

		// Token: 0x04002E1E RID: 11806
		[CompilerGenerated]
		private float float_3;

		// Token: 0x04002E1F RID: 11807
		[CompilerGenerated]
		private float float_4;

		// Token: 0x04002E20 RID: 11808
		[CompilerGenerated]
		private float float_5;

		// Token: 0x04002E21 RID: 11809
		[CompilerGenerated]
		private float float_6;

		// Token: 0x04002E22 RID: 11810
		[CompilerGenerated]
		private float float_7;
	}
}
