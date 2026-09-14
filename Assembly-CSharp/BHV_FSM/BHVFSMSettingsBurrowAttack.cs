using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	// Token: 0x02000954 RID: 2388
	public class BHVFSMSettingsBurrowAttack : BHVPropertySettingsAttackBase
	{
		// Token: 0x0600425D RID: 16989 RVA: 0x0002C38B File Offset: 0x0002A58B
		public BHVFSMSettingsBurrowAttack()
		{
			this.m_underGroundTime = 2f;
			this.m_undergroundTravelDistance = 10f;
		}

		// Token: 0x170004AE RID: 1198
		// (get) Token: 0x0600425E RID: 16990 RVA: 0x0002C3A9 File Offset: 0x0002A5A9
		// (set) Token: 0x0600425F RID: 16991 RVA: 0x0002C3B1 File Offset: 0x0002A5B1
		[DefaultValue(typeof(float), "2")]
		public float m_underGroundTime { get; set; }

		// Token: 0x170004AF RID: 1199
		// (get) Token: 0x06004260 RID: 16992 RVA: 0x0002C3BA File Offset: 0x0002A5BA
		// (set) Token: 0x06004261 RID: 16993 RVA: 0x0002C3C2 File Offset: 0x0002A5C2
		[DefaultValue(typeof(float), "10")]
		public float m_undergroundTravelDistance { get; set; }

		// Token: 0x04002E31 RID: 11825
		[CompilerGenerated]
		private float float_3;

		// Token: 0x04002E32 RID: 11826
		[CompilerGenerated]
		private float float_4;
	}
}
