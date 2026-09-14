using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	// Token: 0x02000958 RID: 2392
	public class BHVFSMSettingsChargeAttack : BHVPropertySettingsAttackBase
	{
		// Token: 0x0600427F RID: 17023 RVA: 0x0002C4E4 File Offset: 0x0002A6E4
		public BHVFSMSettingsChargeAttack()
		{
			this.m_chargeDistanceMin = 8f;
			this.m_chargeDistanceMax = 16f;
			this.m_chargeAttackAngle = 15f;
			this.m_chargeAttackIdleTime = 0.5f;
			this.m_distanceBehindTarget = 2f;
		}

		// Token: 0x170004BD RID: 1213
		// (get) Token: 0x06004280 RID: 17024 RVA: 0x0002C523 File Offset: 0x0002A723
		// (set) Token: 0x06004281 RID: 17025 RVA: 0x0002C52B File Offset: 0x0002A72B
		[DefaultValue(typeof(float), "8")]
		public float m_chargeDistanceMin { get; set; }

		// Token: 0x170004BE RID: 1214
		// (get) Token: 0x06004282 RID: 17026 RVA: 0x0002C534 File Offset: 0x0002A734
		// (set) Token: 0x06004283 RID: 17027 RVA: 0x0002C53C File Offset: 0x0002A73C
		[DefaultValue(typeof(float), "16")]
		public float m_chargeDistanceMax { get; set; }

		// Token: 0x170004BF RID: 1215
		// (get) Token: 0x06004284 RID: 17028 RVA: 0x0002C545 File Offset: 0x0002A745
		// (set) Token: 0x06004285 RID: 17029 RVA: 0x0002C54D File Offset: 0x0002A74D
		[DefaultValue(typeof(float), "15")]
		public float m_chargeAttackAngle { get; set; }

		// Token: 0x170004C0 RID: 1216
		// (get) Token: 0x06004286 RID: 17030 RVA: 0x0002C556 File Offset: 0x0002A756
		// (set) Token: 0x06004287 RID: 17031 RVA: 0x0002C55E File Offset: 0x0002A75E
		[DefaultValue(typeof(float), "0.5")]
		public float m_chargeAttackIdleTime { get; set; }

		// Token: 0x170004C1 RID: 1217
		// (get) Token: 0x06004288 RID: 17032 RVA: 0x0002C567 File Offset: 0x0002A767
		// (set) Token: 0x06004289 RID: 17033 RVA: 0x0002C56F File Offset: 0x0002A76F
		[DefaultValue(typeof(float), "2")]
		public float m_distanceBehindTarget { get; set; }

		// Token: 0x04002E40 RID: 11840
		[CompilerGenerated]
		private float float_3;

		// Token: 0x04002E41 RID: 11841
		[CompilerGenerated]
		private float float_4;

		// Token: 0x04002E42 RID: 11842
		[CompilerGenerated]
		private float float_5;

		// Token: 0x04002E43 RID: 11843
		[CompilerGenerated]
		private float float_6;

		// Token: 0x04002E44 RID: 11844
		[CompilerGenerated]
		private float float_7;
	}
}
