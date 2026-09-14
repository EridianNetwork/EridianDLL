using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	// Token: 0x02000929 RID: 2345
	public class BHVFSMSettingsCover : BHVPropertySettings
	{
		// Token: 0x060040D9 RID: 16601 RVA: 0x0012EC9C File Offset: 0x0012CE9C
		public BHVFSMSettingsCover()
		{
			this.m_coverIdleTimeMin = 0f;
			this.m_coverIdleTimeMax = 0f;
			this.m_coverIdleCombatSafeTimeMin = 0f;
			this.m_coverIdleCombatSafeTimeMax = 0f;
			this.m_coverIdleCombatDangerTimeMin = 0f;
			this.m_coverIdleCombatDangerTimeMax = 0f;
			this.m_coverPeakOutLookAroundTimeMin = 0f;
			this.m_coverPeakOutLookAroundTimeMax = 0f;
			this.m_coverPeakOutCombatTimeMin = 0f;
			this.m_coverPeakOutCombatTimeMax = 0f;
			this.m_coverFireIdleTimeMin = 0f;
			this.m_coverFireIdleTimeMax = 0f;
			this.m_leaveCoverDistance = 0f;
			this.m_seekCoverDistance = 5f;
			this.m_peakInTimer = 2f;
			this.m_coverBurstChainedFireLoopCount = 0;
		}

		// Token: 0x17000401 RID: 1025
		// (get) Token: 0x060040DA RID: 16602 RVA: 0x0002B45F File Offset: 0x0002965F
		// (set) Token: 0x060040DB RID: 16603 RVA: 0x0002B467 File Offset: 0x00029667
		[DefaultValue(typeof(float), "0")]
		public float m_coverIdleTimeMin { get; set; }

		// Token: 0x17000402 RID: 1026
		// (get) Token: 0x060040DC RID: 16604 RVA: 0x0002B470 File Offset: 0x00029670
		// (set) Token: 0x060040DD RID: 16605 RVA: 0x0002B478 File Offset: 0x00029678
		[DefaultValue(typeof(float), "0")]
		public float m_coverIdleTimeMax { get; set; }

		// Token: 0x17000403 RID: 1027
		// (get) Token: 0x060040DE RID: 16606 RVA: 0x0002B481 File Offset: 0x00029681
		// (set) Token: 0x060040DF RID: 16607 RVA: 0x0002B489 File Offset: 0x00029689
		[DefaultValue(typeof(float), "0")]
		public float m_coverIdleCombatSafeTimeMin { get; set; }

		// Token: 0x17000404 RID: 1028
		// (get) Token: 0x060040E0 RID: 16608 RVA: 0x0002B492 File Offset: 0x00029692
		// (set) Token: 0x060040E1 RID: 16609 RVA: 0x0002B49A File Offset: 0x0002969A
		[DefaultValue(typeof(float), "0")]
		public float m_coverIdleCombatSafeTimeMax { get; set; }

		// Token: 0x17000405 RID: 1029
		// (get) Token: 0x060040E2 RID: 16610 RVA: 0x0002B4A3 File Offset: 0x000296A3
		// (set) Token: 0x060040E3 RID: 16611 RVA: 0x0002B4AB File Offset: 0x000296AB
		[DefaultValue(typeof(float), "0")]
		public float m_coverIdleCombatDangerTimeMin { get; set; }

		// Token: 0x17000406 RID: 1030
		// (get) Token: 0x060040E4 RID: 16612 RVA: 0x0002B4B4 File Offset: 0x000296B4
		// (set) Token: 0x060040E5 RID: 16613 RVA: 0x0002B4BC File Offset: 0x000296BC
		[DefaultValue(typeof(float), "0")]
		public float m_coverIdleCombatDangerTimeMax { get; set; }

		// Token: 0x17000407 RID: 1031
		// (get) Token: 0x060040E6 RID: 16614 RVA: 0x0002B4C5 File Offset: 0x000296C5
		// (set) Token: 0x060040E7 RID: 16615 RVA: 0x0002B4CD File Offset: 0x000296CD
		[DefaultValue(typeof(float), "0")]
		public float m_coverPeakOutLookAroundTimeMin { get; set; }

		// Token: 0x17000408 RID: 1032
		// (get) Token: 0x060040E8 RID: 16616 RVA: 0x0002B4D6 File Offset: 0x000296D6
		// (set) Token: 0x060040E9 RID: 16617 RVA: 0x0002B4DE File Offset: 0x000296DE
		[DefaultValue(typeof(float), "0")]
		public float m_coverPeakOutLookAroundTimeMax { get; set; }

		// Token: 0x17000409 RID: 1033
		// (get) Token: 0x060040EA RID: 16618 RVA: 0x0002B4E7 File Offset: 0x000296E7
		// (set) Token: 0x060040EB RID: 16619 RVA: 0x0002B4EF File Offset: 0x000296EF
		[DefaultValue(typeof(float), "0")]
		public float m_coverPeakOutCombatTimeMin { get; set; }

		// Token: 0x1700040A RID: 1034
		// (get) Token: 0x060040EC RID: 16620 RVA: 0x0002B4F8 File Offset: 0x000296F8
		// (set) Token: 0x060040ED RID: 16621 RVA: 0x0002B500 File Offset: 0x00029700
		[DefaultValue(typeof(float), "0")]
		public float m_coverPeakOutCombatTimeMax { get; set; }

		// Token: 0x1700040B RID: 1035
		// (get) Token: 0x060040EE RID: 16622 RVA: 0x0002B509 File Offset: 0x00029709
		// (set) Token: 0x060040EF RID: 16623 RVA: 0x0002B511 File Offset: 0x00029711
		[DefaultValue(typeof(float), "0")]
		public float m_coverFireIdleTimeMin { get; set; }

		// Token: 0x1700040C RID: 1036
		// (get) Token: 0x060040F0 RID: 16624 RVA: 0x0002B51A File Offset: 0x0002971A
		// (set) Token: 0x060040F1 RID: 16625 RVA: 0x0002B522 File Offset: 0x00029722
		[DefaultValue(typeof(float), "0")]
		public float m_coverFireIdleTimeMax { get; set; }

		// Token: 0x1700040D RID: 1037
		// (get) Token: 0x060040F2 RID: 16626 RVA: 0x0002B52B File Offset: 0x0002972B
		// (set) Token: 0x060040F3 RID: 16627 RVA: 0x0002B533 File Offset: 0x00029733
		[DefaultValue(typeof(float), "0")]
		public float m_leaveCoverDistance { get; set; }

		// Token: 0x1700040E RID: 1038
		// (get) Token: 0x060040F4 RID: 16628 RVA: 0x0002B53C File Offset: 0x0002973C
		// (set) Token: 0x060040F5 RID: 16629 RVA: 0x0002B544 File Offset: 0x00029744
		[DefaultValue(typeof(float), "5")]
		public float m_seekCoverDistance { get; set; }

		// Token: 0x1700040F RID: 1039
		// (get) Token: 0x060040F6 RID: 16630 RVA: 0x0002B54D File Offset: 0x0002974D
		// (set) Token: 0x060040F7 RID: 16631 RVA: 0x0002B555 File Offset: 0x00029755
		[DefaultValue(typeof(float), "2")]
		public float m_peakInTimer { get; set; }

		// Token: 0x17000410 RID: 1040
		// (get) Token: 0x060040F8 RID: 16632 RVA: 0x0002B55E File Offset: 0x0002975E
		// (set) Token: 0x060040F9 RID: 16633 RVA: 0x0002B566 File Offset: 0x00029766
		[DefaultValue(0)]
		public int m_coverBurstChainedFireLoopCount { get; set; }

		// Token: 0x04002D60 RID: 11616
		[CompilerGenerated]
		private float float_0;

		// Token: 0x04002D61 RID: 11617
		[CompilerGenerated]
		private float float_1;

		// Token: 0x04002D62 RID: 11618
		[CompilerGenerated]
		private float float_2;

		// Token: 0x04002D63 RID: 11619
		[CompilerGenerated]
		private float float_3;

		// Token: 0x04002D64 RID: 11620
		[CompilerGenerated]
		private float float_4;

		// Token: 0x04002D65 RID: 11621
		[CompilerGenerated]
		private float float_5;

		// Token: 0x04002D66 RID: 11622
		[CompilerGenerated]
		private float float_6;

		// Token: 0x04002D67 RID: 11623
		[CompilerGenerated]
		private float float_7;

		// Token: 0x04002D68 RID: 11624
		[CompilerGenerated]
		private float float_8;

		// Token: 0x04002D69 RID: 11625
		[CompilerGenerated]
		private float float_9;

		// Token: 0x04002D6A RID: 11626
		[CompilerGenerated]
		private float float_10;

		// Token: 0x04002D6B RID: 11627
		[CompilerGenerated]
		private float float_11;

		// Token: 0x04002D6C RID: 11628
		[CompilerGenerated]
		private float float_12;

		// Token: 0x04002D6D RID: 11629
		[CompilerGenerated]
		private float float_13;

		// Token: 0x04002D6E RID: 11630
		[CompilerGenerated]
		private float float_14;

		// Token: 0x04002D6F RID: 11631
		[CompilerGenerated]
		private int int_0;
	}
}
