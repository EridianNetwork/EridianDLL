using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	// Token: 0x02000959 RID: 2393
	public class BHVFSMSettingsJumpAttack : BHVPropertySettingsAttackBase
	{
		// Token: 0x0600428A RID: 17034 RVA: 0x0002C578 File Offset: 0x0002A778
		public BHVFSMSettingsJumpAttack()
		{
			this.m_jumpDistanceMin = 4f;
			this.m_jumpDistanceMax = 8f;
			this.m_jumpHightMax = 4f;
			this.m_jumpAttackAngle = 15f;
			this.m_jumpAttackIdleTime = 0.5f;
		}

		// Token: 0x170004C2 RID: 1218
		// (get) Token: 0x0600428B RID: 17035 RVA: 0x0002C5B7 File Offset: 0x0002A7B7
		// (set) Token: 0x0600428C RID: 17036 RVA: 0x0002C5BF File Offset: 0x0002A7BF
		[DefaultValue(typeof(float), "4")]
		public float m_jumpDistanceMin { get; set; }

		// Token: 0x170004C3 RID: 1219
		// (get) Token: 0x0600428D RID: 17037 RVA: 0x0002C5C8 File Offset: 0x0002A7C8
		// (set) Token: 0x0600428E RID: 17038 RVA: 0x0002C5D0 File Offset: 0x0002A7D0
		[DefaultValue(typeof(float), "8")]
		public float m_jumpDistanceMax { get; set; }

		// Token: 0x170004C4 RID: 1220
		// (get) Token: 0x0600428F RID: 17039 RVA: 0x0002C5D9 File Offset: 0x0002A7D9
		// (set) Token: 0x06004290 RID: 17040 RVA: 0x0002C5E1 File Offset: 0x0002A7E1
		[DefaultValue(typeof(float), "4")]
		public float m_jumpHightMax { get; set; }

		// Token: 0x170004C5 RID: 1221
		// (get) Token: 0x06004291 RID: 17041 RVA: 0x0002C5EA File Offset: 0x0002A7EA
		// (set) Token: 0x06004292 RID: 17042 RVA: 0x0002C5F2 File Offset: 0x0002A7F2
		[DefaultValue(typeof(float), "15")]
		public float m_jumpAttackAngle { get; set; }

		// Token: 0x170004C6 RID: 1222
		// (get) Token: 0x06004293 RID: 17043 RVA: 0x0002C5FB File Offset: 0x0002A7FB
		// (set) Token: 0x06004294 RID: 17044 RVA: 0x0002C603 File Offset: 0x0002A803
		[DefaultValue(typeof(float), "0.5")]
		public float m_jumpAttackIdleTime { get; set; }

		// Token: 0x04002E45 RID: 11845
		[CompilerGenerated]
		private float float_3;

		// Token: 0x04002E46 RID: 11846
		[CompilerGenerated]
		private float float_4;

		// Token: 0x04002E47 RID: 11847
		[CompilerGenerated]
		private float float_5;

		// Token: 0x04002E48 RID: 11848
		[CompilerGenerated]
		private float float_6;

		// Token: 0x04002E49 RID: 11849
		[CompilerGenerated]
		private float float_7;
	}
}
