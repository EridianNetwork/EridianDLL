using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	// Token: 0x02000932 RID: 2354
	public class BHVFSMSettingsTimers : BHVPropertySettings
	{
		// Token: 0x0600413A RID: 16698 RVA: 0x0012EDC8 File Offset: 0x0012CFC8
		public BHVFSMSettingsTimers()
		{
			this.m_selectTargetTimer = 0f;
			this.m_selectPositionTimer = 0f;
			this.m_checkAttackModeTimer = 1f;
			this.m_alertFightTimer = 3f;
			this.m_alertTimer = 30f;
			this.m_selectPositionInCoverTimer = 2f;
			this.m_lightDamageReactionCoolDownTimer = 1f;
			this.m_heaveDamageReactionCoolDownTimer = 5f;
			this.m_checkPositionMoveToCoverTimerMin = 2f;
			this.m_checkPositionMoveToCoverTimerMax = 4f;
			this.m_checkPositionMoveToOpenSpaceTimerMin = 1f;
			this.m_checkPositionMoveToOpenSpaceTimerMax = 2f;
		}

		// Token: 0x1700042D RID: 1069
		// (get) Token: 0x0600413B RID: 16699 RVA: 0x0002B85F File Offset: 0x00029A5F
		// (set) Token: 0x0600413C RID: 16700 RVA: 0x0002B867 File Offset: 0x00029A67
		[DefaultValue(typeof(float), "0")]
		public float m_selectTargetTimer { get; set; }

		// Token: 0x1700042E RID: 1070
		// (get) Token: 0x0600413D RID: 16701 RVA: 0x0002B870 File Offset: 0x00029A70
		// (set) Token: 0x0600413E RID: 16702 RVA: 0x0002B878 File Offset: 0x00029A78
		[DefaultValue(typeof(float), "0")]
		public float m_selectPositionTimer { get; set; }

		// Token: 0x1700042F RID: 1071
		// (get) Token: 0x0600413F RID: 16703 RVA: 0x0002B881 File Offset: 0x00029A81
		// (set) Token: 0x06004140 RID: 16704 RVA: 0x0002B889 File Offset: 0x00029A89
		[DefaultValue(typeof(float), "1")]
		public float m_checkAttackModeTimer { get; set; }

		// Token: 0x17000430 RID: 1072
		// (get) Token: 0x06004141 RID: 16705 RVA: 0x0002B892 File Offset: 0x00029A92
		// (set) Token: 0x06004142 RID: 16706 RVA: 0x0002B89A File Offset: 0x00029A9A
		[DefaultValue(typeof(float), "3")]
		public float m_alertFightTimer { get; set; }

		// Token: 0x17000431 RID: 1073
		// (get) Token: 0x06004143 RID: 16707 RVA: 0x0002B8A3 File Offset: 0x00029AA3
		// (set) Token: 0x06004144 RID: 16708 RVA: 0x0002B8AB File Offset: 0x00029AAB
		[DefaultValue(typeof(float), "30")]
		public float m_alertTimer { get; set; }

		// Token: 0x17000432 RID: 1074
		// (get) Token: 0x06004145 RID: 16709 RVA: 0x0002B8B4 File Offset: 0x00029AB4
		// (set) Token: 0x06004146 RID: 16710 RVA: 0x0002B8BC File Offset: 0x00029ABC
		[DefaultValue(typeof(float), "2")]
		public float m_selectPositionInCoverTimer { get; set; }

		// Token: 0x17000433 RID: 1075
		// (get) Token: 0x06004147 RID: 16711 RVA: 0x0002B8C5 File Offset: 0x00029AC5
		// (set) Token: 0x06004148 RID: 16712 RVA: 0x0002B8CD File Offset: 0x00029ACD
		[DefaultValue(typeof(float), "1")]
		public float m_lightDamageReactionCoolDownTimer { get; set; }

		// Token: 0x17000434 RID: 1076
		// (get) Token: 0x06004149 RID: 16713 RVA: 0x0002B8D6 File Offset: 0x00029AD6
		// (set) Token: 0x0600414A RID: 16714 RVA: 0x0002B8DE File Offset: 0x00029ADE
		[DefaultValue(typeof(float), "5")]
		public float m_heaveDamageReactionCoolDownTimer { get; set; }

		// Token: 0x17000435 RID: 1077
		// (get) Token: 0x0600414B RID: 16715 RVA: 0x0002B8E7 File Offset: 0x00029AE7
		// (set) Token: 0x0600414C RID: 16716 RVA: 0x0002B8EF File Offset: 0x00029AEF
		[DefaultValue(typeof(float), "2")]
		public float m_checkPositionMoveToCoverTimerMin { get; set; }

		// Token: 0x17000436 RID: 1078
		// (get) Token: 0x0600414D RID: 16717 RVA: 0x0002B8F8 File Offset: 0x00029AF8
		// (set) Token: 0x0600414E RID: 16718 RVA: 0x0002B900 File Offset: 0x00029B00
		[DefaultValue(typeof(float), "4")]
		public float m_checkPositionMoveToCoverTimerMax { get; set; }

		// Token: 0x17000437 RID: 1079
		// (get) Token: 0x0600414F RID: 16719 RVA: 0x0002B909 File Offset: 0x00029B09
		// (set) Token: 0x06004150 RID: 16720 RVA: 0x0002B911 File Offset: 0x00029B11
		[DefaultValue(typeof(float), "1")]
		public float m_checkPositionMoveToOpenSpaceTimerMin { get; set; }

		// Token: 0x17000438 RID: 1080
		// (get) Token: 0x06004151 RID: 16721 RVA: 0x0002B91A File Offset: 0x00029B1A
		// (set) Token: 0x06004152 RID: 16722 RVA: 0x0002B922 File Offset: 0x00029B22
		[DefaultValue(typeof(float), "2")]
		public float m_checkPositionMoveToOpenSpaceTimerMax { get; set; }

		// Token: 0x04002D8C RID: 11660
		[CompilerGenerated]
		private float float_0;

		// Token: 0x04002D8D RID: 11661
		[CompilerGenerated]
		private float float_1;

		// Token: 0x04002D8E RID: 11662
		[CompilerGenerated]
		private float float_2;

		// Token: 0x04002D8F RID: 11663
		[CompilerGenerated]
		private float float_3;

		// Token: 0x04002D90 RID: 11664
		[CompilerGenerated]
		private float float_4;

		// Token: 0x04002D91 RID: 11665
		[CompilerGenerated]
		private float float_5;

		// Token: 0x04002D92 RID: 11666
		[CompilerGenerated]
		private float float_6;

		// Token: 0x04002D93 RID: 11667
		[CompilerGenerated]
		private float float_7;

		// Token: 0x04002D94 RID: 11668
		[CompilerGenerated]
		private float float_8;

		// Token: 0x04002D95 RID: 11669
		[CompilerGenerated]
		private float float_9;

		// Token: 0x04002D96 RID: 11670
		[CompilerGenerated]
		private float float_10;

		// Token: 0x04002D97 RID: 11671
		[CompilerGenerated]
		private float float_11;
	}
}
