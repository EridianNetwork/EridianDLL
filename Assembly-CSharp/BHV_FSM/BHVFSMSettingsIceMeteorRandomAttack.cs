using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	// Token: 0x02000952 RID: 2386
	public class BHVFSMSettingsIceMeteorRandomAttack : BHVPropertySettingsAttackBase
	{
		// Token: 0x06004249 RID: 16969 RVA: 0x0002C290 File Offset: 0x0002A490
		public BHVFSMSettingsIceMeteorRandomAttack()
		{
			this.m_shardAmount = 3;
			this.m_shardDamage = 30;
			this.m_shardDamageRadius = 1.5f;
		}

		// Token: 0x170004A5 RID: 1189
		// (get) Token: 0x0600424A RID: 16970 RVA: 0x0002C2B2 File Offset: 0x0002A4B2
		// (set) Token: 0x0600424B RID: 16971 RVA: 0x0002C2BA File Offset: 0x0002A4BA
		[DefaultValue(3)]
		public int m_shardAmount { get; set; }

		// Token: 0x170004A6 RID: 1190
		// (get) Token: 0x0600424C RID: 16972 RVA: 0x0002C2C3 File Offset: 0x0002A4C3
		// (set) Token: 0x0600424D RID: 16973 RVA: 0x0002C2CB File Offset: 0x0002A4CB
		[DefaultValue(30)]
		public int m_shardDamage { get; set; }

		// Token: 0x170004A7 RID: 1191
		// (get) Token: 0x0600424E RID: 16974 RVA: 0x0002C2D4 File Offset: 0x0002A4D4
		// (set) Token: 0x0600424F RID: 16975 RVA: 0x0002C2DC File Offset: 0x0002A4DC
		[DefaultValue(typeof(float), "1.5")]
		public float m_shardDamageRadius { get; set; }

		// Token: 0x04002E28 RID: 11816
		[CompilerGenerated]
		private int int_0;

		// Token: 0x04002E29 RID: 11817
		[CompilerGenerated]
		private int int_1;

		// Token: 0x04002E2A RID: 11818
		[CompilerGenerated]
		private float float_3;
	}
}
