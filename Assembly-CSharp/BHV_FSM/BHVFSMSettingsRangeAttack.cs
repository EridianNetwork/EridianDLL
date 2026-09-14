using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	// Token: 0x02000937 RID: 2359
	public class BHVFSMSettingsRangeAttack : BHVPropertySettings
	{
		// Token: 0x06004175 RID: 16757 RVA: 0x0012EE60 File Offset: 0x0012D060
		public BHVFSMSettingsRangeAttack()
		{
			this.m_bestAttackDistanceMax = 0f;
			this.m_bestAttackDistanceMin = 0f;
			this.m_shootIdleTime = 0f;
			this.m_burstChainedFireLoopCount = 0;
			this.m_fireRange = 0f;
			this.IdleSelectPositionTimer = 10f;
			this.OpenSpaceMoveDistanceMin = 3f;
			this.OpenSpaceMoveDistanceMax = 5f;
		}

		// Token: 0x17000448 RID: 1096
		// (get) Token: 0x06004176 RID: 16758 RVA: 0x0002BAEF File Offset: 0x00029CEF
		// (set) Token: 0x06004177 RID: 16759 RVA: 0x0002BAF7 File Offset: 0x00029CF7
		[DefaultValue(typeof(float), "0")]
		public float m_bestAttackDistanceMax { get; set; }

		// Token: 0x17000449 RID: 1097
		// (get) Token: 0x06004178 RID: 16760 RVA: 0x0002BB00 File Offset: 0x00029D00
		// (set) Token: 0x06004179 RID: 16761 RVA: 0x0002BB08 File Offset: 0x00029D08
		[DefaultValue(typeof(float), "0")]
		public float m_bestAttackDistanceMin { get; set; }

		// Token: 0x1700044A RID: 1098
		// (get) Token: 0x0600417A RID: 16762 RVA: 0x0002BB11 File Offset: 0x00029D11
		// (set) Token: 0x0600417B RID: 16763 RVA: 0x0002BB19 File Offset: 0x00029D19
		[DefaultValue(typeof(float), "0")]
		public float m_shootIdleTime { get; set; }

		// Token: 0x1700044B RID: 1099
		// (get) Token: 0x0600417C RID: 16764 RVA: 0x0002BB22 File Offset: 0x00029D22
		// (set) Token: 0x0600417D RID: 16765 RVA: 0x0002BB2A File Offset: 0x00029D2A
		[DefaultValue(0)]
		public int m_burstChainedFireLoopCount { get; set; }

		// Token: 0x1700044C RID: 1100
		// (get) Token: 0x0600417E RID: 16766 RVA: 0x0002BB33 File Offset: 0x00029D33
		// (set) Token: 0x0600417F RID: 16767 RVA: 0x0002BB3B File Offset: 0x00029D3B
		[DefaultValue(typeof(float), "0")]
		public float m_fireRange { get; set; }

		// Token: 0x1700044D RID: 1101
		// (get) Token: 0x06004180 RID: 16768 RVA: 0x0002BB44 File Offset: 0x00029D44
		// (set) Token: 0x06004181 RID: 16769 RVA: 0x0002BB4C File Offset: 0x00029D4C
		[DefaultValue(typeof(float), "10")]
		public float IdleSelectPositionTimer { get; set; }

		// Token: 0x1700044E RID: 1102
		// (get) Token: 0x06004182 RID: 16770 RVA: 0x0002BB55 File Offset: 0x00029D55
		// (set) Token: 0x06004183 RID: 16771 RVA: 0x0002BB5D File Offset: 0x00029D5D
		[DefaultValue(typeof(float), "3")]
		public float OpenSpaceMoveDistanceMin { get; set; }

		// Token: 0x1700044F RID: 1103
		// (get) Token: 0x06004184 RID: 16772 RVA: 0x0002BB66 File Offset: 0x00029D66
		// (set) Token: 0x06004185 RID: 16773 RVA: 0x0002BB6E File Offset: 0x00029D6E
		[DefaultValue(typeof(float), "5")]
		public float OpenSpaceMoveDistanceMax { get; set; }

		// Token: 0x04002DA7 RID: 11687
		[CompilerGenerated]
		private float float_0;

		// Token: 0x04002DA8 RID: 11688
		[CompilerGenerated]
		private float float_1;

		// Token: 0x04002DA9 RID: 11689
		[CompilerGenerated]
		private float float_2;

		// Token: 0x04002DAA RID: 11690
		[CompilerGenerated]
		private int int_0;

		// Token: 0x04002DAB RID: 11691
		[CompilerGenerated]
		private float float_3;

		// Token: 0x04002DAC RID: 11692
		[CompilerGenerated]
		private float float_4;

		// Token: 0x04002DAD RID: 11693
		[CompilerGenerated]
		private float float_5;

		// Token: 0x04002DAE RID: 11694
		[CompilerGenerated]
		private float float_6;
	}
}
