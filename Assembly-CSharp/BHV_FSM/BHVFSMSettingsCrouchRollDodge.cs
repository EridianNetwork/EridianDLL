using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	// Token: 0x02000931 RID: 2353
	public class BHVFSMSettingsCrouchRollDodge : BHVPropertySettings
	{
		// Token: 0x0600412F RID: 16687 RVA: 0x0002B7CB File Offset: 0x000299CB
		public BHVFSMSettingsCrouchRollDodge()
		{
			this.m_changeStanceChanceSafe = 1f;
			this.m_changeStanceChanceDanger = 1f;
			this.m_dodgeRepeatTime = 2f;
			this.m_dodgeChance = 1f;
			this.m_rollChance = 1f;
		}

		// Token: 0x17000428 RID: 1064
		// (get) Token: 0x06004130 RID: 16688 RVA: 0x0002B80A File Offset: 0x00029A0A
		// (set) Token: 0x06004131 RID: 16689 RVA: 0x0002B812 File Offset: 0x00029A12
		[DefaultValue(typeof(float), "1")]
		public float m_changeStanceChanceSafe { get; set; }

		// Token: 0x17000429 RID: 1065
		// (get) Token: 0x06004132 RID: 16690 RVA: 0x0002B81B File Offset: 0x00029A1B
		// (set) Token: 0x06004133 RID: 16691 RVA: 0x0002B823 File Offset: 0x00029A23
		[DefaultValue(typeof(float), "1")]
		public float m_changeStanceChanceDanger { get; set; }

		// Token: 0x1700042A RID: 1066
		// (get) Token: 0x06004134 RID: 16692 RVA: 0x0002B82C File Offset: 0x00029A2C
		// (set) Token: 0x06004135 RID: 16693 RVA: 0x0002B834 File Offset: 0x00029A34
		[DefaultValue(typeof(float), "2")]
		public float m_dodgeRepeatTime { get; set; }

		// Token: 0x1700042B RID: 1067
		// (get) Token: 0x06004136 RID: 16694 RVA: 0x0002B83D File Offset: 0x00029A3D
		// (set) Token: 0x06004137 RID: 16695 RVA: 0x0002B845 File Offset: 0x00029A45
		[DefaultValue(typeof(float), "1")]
		public float m_dodgeChance { get; set; }

		// Token: 0x1700042C RID: 1068
		// (get) Token: 0x06004138 RID: 16696 RVA: 0x0002B84E File Offset: 0x00029A4E
		// (set) Token: 0x06004139 RID: 16697 RVA: 0x0002B856 File Offset: 0x00029A56
		[DefaultValue(typeof(float), "1")]
		public float m_rollChance { get; set; }

		// Token: 0x04002D87 RID: 11655
		[CompilerGenerated]
		private float float_0;

		// Token: 0x04002D88 RID: 11656
		[CompilerGenerated]
		private float float_1;

		// Token: 0x04002D89 RID: 11657
		[CompilerGenerated]
		private float float_2;

		// Token: 0x04002D8A RID: 11658
		[CompilerGenerated]
		private float float_3;

		// Token: 0x04002D8B RID: 11659
		[CompilerGenerated]
		private float float_4;
	}
}
