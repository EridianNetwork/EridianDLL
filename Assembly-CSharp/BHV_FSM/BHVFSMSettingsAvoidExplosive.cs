using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	// Token: 0x02000930 RID: 2352
	public class BHVFSMSettingsAvoidExplosive : BHVPropertySettings
	{
		// Token: 0x06004124 RID: 16676 RVA: 0x0002B737 File Offset: 0x00029937
		public BHVFSMSettingsAvoidExplosive()
		{
			this.m_checkExplosiveTime = 1f;
			this.m_dodgeChance = 1f;
			this.m_dodgeDistance = 2.56f;
			this.m_distanceToExplosive = 5f;
			this.m_dodgeRepeatTime = 3f;
		}

		// Token: 0x17000423 RID: 1059
		// (get) Token: 0x06004125 RID: 16677 RVA: 0x0002B776 File Offset: 0x00029976
		// (set) Token: 0x06004126 RID: 16678 RVA: 0x0002B77E File Offset: 0x0002997E
		[DefaultValue(typeof(float), "1")]
		public float m_checkExplosiveTime { get; set; }

		// Token: 0x17000424 RID: 1060
		// (get) Token: 0x06004127 RID: 16679 RVA: 0x0002B787 File Offset: 0x00029987
		// (set) Token: 0x06004128 RID: 16680 RVA: 0x0002B78F File Offset: 0x0002998F
		[DefaultValue(typeof(float), "1")]
		public float m_dodgeChance { get; set; }

		// Token: 0x17000425 RID: 1061
		// (get) Token: 0x06004129 RID: 16681 RVA: 0x0002B798 File Offset: 0x00029998
		// (set) Token: 0x0600412A RID: 16682 RVA: 0x0002B7A0 File Offset: 0x000299A0
		[DefaultValue(typeof(float), "2.56")]
		public float m_dodgeDistance { get; set; }

		// Token: 0x17000426 RID: 1062
		// (get) Token: 0x0600412B RID: 16683 RVA: 0x0002B7A9 File Offset: 0x000299A9
		// (set) Token: 0x0600412C RID: 16684 RVA: 0x0002B7B1 File Offset: 0x000299B1
		[DefaultValue(typeof(float), "5")]
		public float m_distanceToExplosive { get; set; }

		// Token: 0x17000427 RID: 1063
		// (get) Token: 0x0600412D RID: 16685 RVA: 0x0002B7BA File Offset: 0x000299BA
		// (set) Token: 0x0600412E RID: 16686 RVA: 0x0002B7C2 File Offset: 0x000299C2
		[DefaultValue(typeof(float), "3")]
		public float m_dodgeRepeatTime { get; set; }

		// Token: 0x04002D82 RID: 11650
		[CompilerGenerated]
		private float float_0;

		// Token: 0x04002D83 RID: 11651
		[CompilerGenerated]
		private float float_1;

		// Token: 0x04002D84 RID: 11652
		[CompilerGenerated]
		private float float_2;

		// Token: 0x04002D85 RID: 11653
		[CompilerGenerated]
		private float float_3;

		// Token: 0x04002D86 RID: 11654
		[CompilerGenerated]
		private float float_4;
	}
}
