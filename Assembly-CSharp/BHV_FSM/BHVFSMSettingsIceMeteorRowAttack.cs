using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	// Token: 0x02000951 RID: 2385
	public class BHVFSMSettingsIceMeteorRowAttack : BHVPropertySettingsAttackBase
	{
		// Token: 0x06004240 RID: 16960 RVA: 0x0002C21F File Offset: 0x0002A41F
		public BHVFSMSettingsIceMeteorRowAttack()
		{
			this.m_shardAmount = 3;
			this.m_shardDamage = 30;
			this.m_shardDamageRadius = 1.5f;
			this.m_shardDistanceInterval = 1.5f;
		}

		// Token: 0x170004A1 RID: 1185
		// (get) Token: 0x06004241 RID: 16961 RVA: 0x0002C24C File Offset: 0x0002A44C
		// (set) Token: 0x06004242 RID: 16962 RVA: 0x0002C254 File Offset: 0x0002A454
		[DefaultValue(3)]
		public int m_shardAmount { get; set; }

		// Token: 0x170004A2 RID: 1186
		// (get) Token: 0x06004243 RID: 16963 RVA: 0x0002C25D File Offset: 0x0002A45D
		// (set) Token: 0x06004244 RID: 16964 RVA: 0x0002C265 File Offset: 0x0002A465
		[DefaultValue(30)]
		public int m_shardDamage { get; set; }

		// Token: 0x170004A3 RID: 1187
		// (get) Token: 0x06004245 RID: 16965 RVA: 0x0002C26E File Offset: 0x0002A46E
		// (set) Token: 0x06004246 RID: 16966 RVA: 0x0002C276 File Offset: 0x0002A476
		[DefaultValue(typeof(float), "1.5")]
		public float m_shardDamageRadius { get; set; }

		// Token: 0x170004A4 RID: 1188
		// (get) Token: 0x06004247 RID: 16967 RVA: 0x0002C27F File Offset: 0x0002A47F
		// (set) Token: 0x06004248 RID: 16968 RVA: 0x0002C287 File Offset: 0x0002A487
		[DefaultValue(typeof(float), "1.5")]
		public float m_shardDistanceInterval { get; set; }

		// Token: 0x04002E24 RID: 11812
		[CompilerGenerated]
		private int int_0;

		// Token: 0x04002E25 RID: 11813
		[CompilerGenerated]
		private int int_1;

		// Token: 0x04002E26 RID: 11814
		[CompilerGenerated]
		private float float_3;

		// Token: 0x04002E27 RID: 11815
		[CompilerGenerated]
		private float float_4;
	}
}
