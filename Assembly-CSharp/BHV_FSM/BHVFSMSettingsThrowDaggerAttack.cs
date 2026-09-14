using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	// Token: 0x02000955 RID: 2389
	public class BHVFSMSettingsThrowDaggerAttack : BHVPropertySettingsAttackBase
	{
		// Token: 0x06004262 RID: 16994 RVA: 0x0002C3CB File Offset: 0x0002A5CB
		public BHVFSMSettingsThrowDaggerAttack()
		{
			this.m_damagePoint = 70f;
			this.m_throwChance = 0.5f;
		}

		// Token: 0x170004B0 RID: 1200
		// (get) Token: 0x06004263 RID: 16995 RVA: 0x0002C3E9 File Offset: 0x0002A5E9
		// (set) Token: 0x06004264 RID: 16996 RVA: 0x0002C3F1 File Offset: 0x0002A5F1
		[DefaultValue(typeof(float), "70")]
		public float m_damagePoint { get; set; }

		// Token: 0x170004B1 RID: 1201
		// (get) Token: 0x06004265 RID: 16997 RVA: 0x0002C3FA File Offset: 0x0002A5FA
		// (set) Token: 0x06004266 RID: 16998 RVA: 0x0002C402 File Offset: 0x0002A602
		[DefaultValue(typeof(float), "0.5")]
		public float m_throwChance { get; set; }

		// Token: 0x04002E33 RID: 11827
		[CompilerGenerated]
		private float float_3;

		// Token: 0x04002E34 RID: 11828
		[CompilerGenerated]
		private float float_4;
	}
}
