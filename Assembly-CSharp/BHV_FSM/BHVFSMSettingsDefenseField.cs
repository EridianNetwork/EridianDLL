using System;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	// Token: 0x0200091D RID: 2333
	public class BHVFSMSettingsDefenseField : BHVPropertySettings
	{
		// Token: 0x170003B4 RID: 948
		// (get) Token: 0x06004034 RID: 16436 RVA: 0x0002AF09 File Offset: 0x00029109
		// (set) Token: 0x06004035 RID: 16437 RVA: 0x0002AF11 File Offset: 0x00029111
		public float m_triggleChance { get; set; }

		// Token: 0x170003B5 RID: 949
		// (get) Token: 0x06004036 RID: 16438 RVA: 0x0002AF1A File Offset: 0x0002911A
		// (set) Token: 0x06004037 RID: 16439 RVA: 0x0002AF22 File Offset: 0x00029122
		public bool m_bCanKnockBack { get; set; }

		// Token: 0x170003B6 RID: 950
		// (get) Token: 0x06004038 RID: 16440 RVA: 0x0002AF2B File Offset: 0x0002912B
		// (set) Token: 0x06004039 RID: 16441 RVA: 0x0002AF33 File Offset: 0x00029133
		public float m_knockBackForce { get; set; }

		// Token: 0x170003B7 RID: 951
		// (get) Token: 0x0600403A RID: 16442 RVA: 0x0002AF3C File Offset: 0x0002913C
		// (set) Token: 0x0600403B RID: 16443 RVA: 0x0002AF44 File Offset: 0x00029144
		public float m_knockBackAngle { get; set; }

		// Token: 0x04002D13 RID: 11539
		[CompilerGenerated]
		private float float_0;

		// Token: 0x04002D14 RID: 11540
		[CompilerGenerated]
		private bool bool_0;

		// Token: 0x04002D15 RID: 11541
		[CompilerGenerated]
		private float float_1;

		// Token: 0x04002D16 RID: 11542
		[CompilerGenerated]
		private float float_2;
	}
}
