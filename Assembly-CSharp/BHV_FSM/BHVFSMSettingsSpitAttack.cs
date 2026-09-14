using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	// Token: 0x0200095A RID: 2394
	public class BHVFSMSettingsSpitAttack : BHVPropertySettingsAttackBase
	{
		// Token: 0x06004295 RID: 17045 RVA: 0x0002C60C File Offset: 0x0002A80C
		public BHVFSMSettingsSpitAttack()
		{
			this.m_attackDistanceMax = 15f;
			this.m_attackDistanceMin = 2f;
			this.m_attackAngle = 15f;
			this.m_attackIdleTime = 3f;
			this.m_spitAttackAnimCount = 1;
		}

		// Token: 0x170004C7 RID: 1223
		// (get) Token: 0x06004296 RID: 17046 RVA: 0x0002C647 File Offset: 0x0002A847
		// (set) Token: 0x06004297 RID: 17047 RVA: 0x0002C64F File Offset: 0x0002A84F
		[DefaultValue(typeof(float), "15")]
		public float m_attackDistanceMax { get; set; }

		// Token: 0x170004C8 RID: 1224
		// (get) Token: 0x06004298 RID: 17048 RVA: 0x0002C658 File Offset: 0x0002A858
		// (set) Token: 0x06004299 RID: 17049 RVA: 0x0002C660 File Offset: 0x0002A860
		[DefaultValue(typeof(float), "2")]
		public float m_attackDistanceMin { get; set; }

		// Token: 0x170004C9 RID: 1225
		// (get) Token: 0x0600429A RID: 17050 RVA: 0x0002C669 File Offset: 0x0002A869
		// (set) Token: 0x0600429B RID: 17051 RVA: 0x0002C671 File Offset: 0x0002A871
		[DefaultValue(typeof(float), "15")]
		public float m_attackAngle { get; set; }

		// Token: 0x170004CA RID: 1226
		// (get) Token: 0x0600429C RID: 17052 RVA: 0x0002C67A File Offset: 0x0002A87A
		// (set) Token: 0x0600429D RID: 17053 RVA: 0x0002C682 File Offset: 0x0002A882
		[DefaultValue(typeof(float), "3")]
		public float m_attackIdleTime { get; set; }

		// Token: 0x170004CB RID: 1227
		// (get) Token: 0x0600429E RID: 17054 RVA: 0x0002C68B File Offset: 0x0002A88B
		// (set) Token: 0x0600429F RID: 17055 RVA: 0x0002C693 File Offset: 0x0002A893
		[DefaultValue(1)]
		public int m_spitAttackAnimCount { get; set; }

		// Token: 0x04002E4A RID: 11850
		[CompilerGenerated]
		private float float_3;

		// Token: 0x04002E4B RID: 11851
		[CompilerGenerated]
		private float float_4;

		// Token: 0x04002E4C RID: 11852
		[CompilerGenerated]
		private float float_5;

		// Token: 0x04002E4D RID: 11853
		[CompilerGenerated]
		private float float_6;

		// Token: 0x04002E4E RID: 11854
		[CompilerGenerated]
		private int int_0;
	}
}
