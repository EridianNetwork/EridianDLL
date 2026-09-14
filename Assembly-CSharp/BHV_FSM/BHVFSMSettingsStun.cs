using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	// Token: 0x0200093A RID: 2362
	public class BHVFSMSettingsStun : BHVPropertySettings
	{
		// Token: 0x06004196 RID: 16790 RVA: 0x0002BC4B File Offset: 0x00029E4B
		public BHVFSMSettingsStun()
		{
			this.m_damageAmount = 60;
			this.m_time = 2f;
			this.m_coolDownTime = 5f;
		}

		// Token: 0x17000457 RID: 1111
		// (get) Token: 0x06004197 RID: 16791 RVA: 0x0002BC71 File Offset: 0x00029E71
		// (set) Token: 0x06004198 RID: 16792 RVA: 0x0002BC79 File Offset: 0x00029E79
		[DefaultValue(60)]
		public int m_damageAmount { get; set; }

		// Token: 0x17000458 RID: 1112
		// (get) Token: 0x06004199 RID: 16793 RVA: 0x0002BC82 File Offset: 0x00029E82
		// (set) Token: 0x0600419A RID: 16794 RVA: 0x0002BC8A File Offset: 0x00029E8A
		[DefaultValue(typeof(float), "2")]
		public float m_time { get; set; }

		// Token: 0x17000459 RID: 1113
		// (get) Token: 0x0600419B RID: 16795 RVA: 0x0002BC93 File Offset: 0x00029E93
		// (set) Token: 0x0600419C RID: 16796 RVA: 0x0002BC9B File Offset: 0x00029E9B
		[DefaultValue(typeof(float), "5")]
		public float m_coolDownTime { get; set; }

		// Token: 0x04002DB6 RID: 11702
		[CompilerGenerated]
		private int int_0;

		// Token: 0x04002DB7 RID: 11703
		[CompilerGenerated]
		private float float_0;

		// Token: 0x04002DB8 RID: 11704
		[CompilerGenerated]
		private float float_1;
	}
}
