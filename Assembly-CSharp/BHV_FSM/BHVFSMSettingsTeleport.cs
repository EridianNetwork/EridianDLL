using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	// Token: 0x0200092B RID: 2347
	public class BHVFSMSettingsTeleport : BHVPropertySettings
	{
		// Token: 0x060040FD RID: 16637 RVA: 0x0012ED5C File Offset: 0x0012CF5C
		public BHVFSMSettingsTeleport()
		{
			this.m_teleportDistanceMin = 10f;
			this.m_teleportDistanceMax = 50f;
			this.m_teleportDistanceToTarget = 5f;
			this.m_telepartAngelToTarge = 360f;
			this.m_attackChanceWeight = 1f;
			this.m_teleportTimeMin = 0.5f;
			this.m_teleportTimeMax = 3f;
			this.m_idleTimeBeforeHide = 0.5f;
		}

		// Token: 0x17000412 RID: 1042
		// (get) Token: 0x060040FE RID: 16638 RVA: 0x0002B593 File Offset: 0x00029793
		// (set) Token: 0x060040FF RID: 16639 RVA: 0x0002B59B File Offset: 0x0002979B
		[DefaultValue(typeof(float), "10")]
		public float m_teleportDistanceMin { get; set; }

		// Token: 0x17000413 RID: 1043
		// (get) Token: 0x06004100 RID: 16640 RVA: 0x0002B5A4 File Offset: 0x000297A4
		// (set) Token: 0x06004101 RID: 16641 RVA: 0x0002B5AC File Offset: 0x000297AC
		[DefaultValue(typeof(float), "50")]
		public float m_teleportDistanceMax { get; set; }

		// Token: 0x17000414 RID: 1044
		// (get) Token: 0x06004102 RID: 16642 RVA: 0x0002B5B5 File Offset: 0x000297B5
		// (set) Token: 0x06004103 RID: 16643 RVA: 0x0002B5BD File Offset: 0x000297BD
		[DefaultValue(typeof(float), "5")]
		public float m_teleportDistanceToTarget { get; set; }

		// Token: 0x17000415 RID: 1045
		// (get) Token: 0x06004104 RID: 16644 RVA: 0x0002B5C6 File Offset: 0x000297C6
		// (set) Token: 0x06004105 RID: 16645 RVA: 0x0002B5CE File Offset: 0x000297CE
		[DefaultValue(typeof(float), "360")]
		public float m_telepartAngelToTarge { get; set; }

		// Token: 0x17000416 RID: 1046
		// (get) Token: 0x06004106 RID: 16646 RVA: 0x0002B5D7 File Offset: 0x000297D7
		// (set) Token: 0x06004107 RID: 16647 RVA: 0x0002B5DF File Offset: 0x000297DF
		[DefaultValue(typeof(float), "1")]
		public float m_attackChanceWeight { get; set; }

		// Token: 0x17000417 RID: 1047
		// (get) Token: 0x06004108 RID: 16648 RVA: 0x0002B5E8 File Offset: 0x000297E8
		// (set) Token: 0x06004109 RID: 16649 RVA: 0x0002B5F0 File Offset: 0x000297F0
		[DefaultValue(typeof(float), "0.5")]
		public float m_teleportTimeMin { get; set; }

		// Token: 0x17000418 RID: 1048
		// (get) Token: 0x0600410A RID: 16650 RVA: 0x0002B5F9 File Offset: 0x000297F9
		// (set) Token: 0x0600410B RID: 16651 RVA: 0x0002B601 File Offset: 0x00029801
		[DefaultValue(typeof(float), "3")]
		public float m_teleportTimeMax { get; set; }

		// Token: 0x17000419 RID: 1049
		// (get) Token: 0x0600410C RID: 16652 RVA: 0x0002B60A File Offset: 0x0002980A
		// (set) Token: 0x0600410D RID: 16653 RVA: 0x0002B612 File Offset: 0x00029812
		[DefaultValue(typeof(float), "0.5")]
		public float m_idleTimeBeforeHide { get; set; }

		// Token: 0x04002D71 RID: 11633
		[CompilerGenerated]
		private float float_0;

		// Token: 0x04002D72 RID: 11634
		[CompilerGenerated]
		private float float_1;

		// Token: 0x04002D73 RID: 11635
		[CompilerGenerated]
		private float float_2;

		// Token: 0x04002D74 RID: 11636
		[CompilerGenerated]
		private float float_3;

		// Token: 0x04002D75 RID: 11637
		[CompilerGenerated]
		private float float_4;

		// Token: 0x04002D76 RID: 11638
		[CompilerGenerated]
		private float float_5;

		// Token: 0x04002D77 RID: 11639
		[CompilerGenerated]
		private float float_6;

		// Token: 0x04002D78 RID: 11640
		[CompilerGenerated]
		private float float_7;
	}
}
