using System;
using System.Runtime.CompilerServices;

namespace BHV_Skill
{
	// Token: 0x02000965 RID: 2405
	public class BHVSkillSettingsFireBird : BHVSkillSettings
	{
		// Token: 0x0600430A RID: 17162 RVA: 0x0012F19C File Offset: 0x0012D39C
		public BHVSkillSettingsFireBird()
		{
			this.m_fireRadius = 0f;
			this.m_fireDamageOverTime = 0f;
			this.m_explosionRadius = 0f;
			this.m_explosionDamage = 0f;
			this.m_cooldown_explode = 0f;
			this.m_cooldown_flyback = 0f;
			this.m_flyaway_duration = 0f;
			this.m_flyaway_velocity = 0f;
			this.m_flyback_initVelocity = 0f;
			this.m_flyback_accel = 0f;
			this.m_sizeScale = 0f;
			this.m_radius_recall = 0f;
			this.m_behavior = FireBirdBehaviorType.Hover;
			this.m_chainInterval = 0f;
			this.m_chainRadius = 0f;
			this.m_spawnDelay = 0f;
			this.m_cooldown_revive = 0f;
		}

		// Token: 0x170004FC RID: 1276
		// (get) Token: 0x0600430B RID: 17163 RVA: 0x0002CA1E File Offset: 0x0002AC1E
		// (set) Token: 0x0600430C RID: 17164 RVA: 0x0002CA26 File Offset: 0x0002AC26
		public float m_fireRadius { get; set; }

		// Token: 0x170004FD RID: 1277
		// (get) Token: 0x0600430D RID: 17165 RVA: 0x0002CA2F File Offset: 0x0002AC2F
		// (set) Token: 0x0600430E RID: 17166 RVA: 0x0002CA37 File Offset: 0x0002AC37
		public float m_fireDamageOverTime { get; set; }

		// Token: 0x170004FE RID: 1278
		// (get) Token: 0x0600430F RID: 17167 RVA: 0x0002CA40 File Offset: 0x0002AC40
		// (set) Token: 0x06004310 RID: 17168 RVA: 0x0002CA48 File Offset: 0x0002AC48
		public float m_explosionRadius { get; set; }

		// Token: 0x170004FF RID: 1279
		// (get) Token: 0x06004311 RID: 17169 RVA: 0x0002CA51 File Offset: 0x0002AC51
		// (set) Token: 0x06004312 RID: 17170 RVA: 0x0002CA59 File Offset: 0x0002AC59
		public float m_explosionDamage { get; set; }

		// Token: 0x17000500 RID: 1280
		// (get) Token: 0x06004313 RID: 17171 RVA: 0x0002CA62 File Offset: 0x0002AC62
		// (set) Token: 0x06004314 RID: 17172 RVA: 0x0002CA6A File Offset: 0x0002AC6A
		public float m_cooldown_explode { get; set; }

		// Token: 0x17000501 RID: 1281
		// (get) Token: 0x06004315 RID: 17173 RVA: 0x0002CA73 File Offset: 0x0002AC73
		// (set) Token: 0x06004316 RID: 17174 RVA: 0x0002CA7B File Offset: 0x0002AC7B
		public float m_cooldown_flyback { get; set; }

		// Token: 0x17000502 RID: 1282
		// (get) Token: 0x06004317 RID: 17175 RVA: 0x0002CA84 File Offset: 0x0002AC84
		// (set) Token: 0x06004318 RID: 17176 RVA: 0x0002CA8C File Offset: 0x0002AC8C
		public float m_flyaway_duration { get; set; }

		// Token: 0x17000503 RID: 1283
		// (get) Token: 0x06004319 RID: 17177 RVA: 0x0002CA95 File Offset: 0x0002AC95
		// (set) Token: 0x0600431A RID: 17178 RVA: 0x0002CA9D File Offset: 0x0002AC9D
		public float m_flyaway_velocity { get; set; }

		// Token: 0x17000504 RID: 1284
		// (get) Token: 0x0600431B RID: 17179 RVA: 0x0002CAA6 File Offset: 0x0002ACA6
		// (set) Token: 0x0600431C RID: 17180 RVA: 0x0002CAAE File Offset: 0x0002ACAE
		public float m_flyback_initVelocity { get; set; }

		// Token: 0x17000505 RID: 1285
		// (get) Token: 0x0600431D RID: 17181 RVA: 0x0002CAB7 File Offset: 0x0002ACB7
		// (set) Token: 0x0600431E RID: 17182 RVA: 0x0002CABF File Offset: 0x0002ACBF
		public float m_flyback_accel { get; set; }

		// Token: 0x17000506 RID: 1286
		// (get) Token: 0x0600431F RID: 17183 RVA: 0x0002CAC8 File Offset: 0x0002ACC8
		// (set) Token: 0x06004320 RID: 17184 RVA: 0x0002CAD0 File Offset: 0x0002ACD0
		public float m_sizeScale { get; set; }

		// Token: 0x17000507 RID: 1287
		// (get) Token: 0x06004321 RID: 17185 RVA: 0x0002CAD9 File Offset: 0x0002ACD9
		// (set) Token: 0x06004322 RID: 17186 RVA: 0x0002CAE1 File Offset: 0x0002ACE1
		public float m_radius_recall { get; set; }

		// Token: 0x17000508 RID: 1288
		// (get) Token: 0x06004323 RID: 17187 RVA: 0x0002CAEA File Offset: 0x0002ACEA
		// (set) Token: 0x06004324 RID: 17188 RVA: 0x0002CAF2 File Offset: 0x0002ACF2
		public FireBirdBehaviorType m_behavior { get; set; }

		// Token: 0x17000509 RID: 1289
		// (get) Token: 0x06004325 RID: 17189 RVA: 0x0002CAFB File Offset: 0x0002ACFB
		// (set) Token: 0x06004326 RID: 17190 RVA: 0x0002CB03 File Offset: 0x0002AD03
		public float m_chainInterval { get; set; }

		// Token: 0x1700050A RID: 1290
		// (get) Token: 0x06004327 RID: 17191 RVA: 0x0002CB0C File Offset: 0x0002AD0C
		// (set) Token: 0x06004328 RID: 17192 RVA: 0x0002CB14 File Offset: 0x0002AD14
		public float m_chainRadius { get; set; }

		// Token: 0x1700050B RID: 1291
		// (get) Token: 0x06004329 RID: 17193 RVA: 0x0002CB1D File Offset: 0x0002AD1D
		// (set) Token: 0x0600432A RID: 17194 RVA: 0x0002CB25 File Offset: 0x0002AD25
		public float m_spawnDelay { get; set; }

		// Token: 0x1700050C RID: 1292
		// (get) Token: 0x0600432B RID: 17195 RVA: 0x0002CB2E File Offset: 0x0002AD2E
		// (set) Token: 0x0600432C RID: 17196 RVA: 0x0002CB36 File Offset: 0x0002AD36
		public float m_cooldown_revive { get; set; }

		// Token: 0x04002E81 RID: 11905
		[CompilerGenerated]
		private float float_0;

		// Token: 0x04002E82 RID: 11906
		[CompilerGenerated]
		private float float_1;

		// Token: 0x04002E83 RID: 11907
		[CompilerGenerated]
		private float float_2;

		// Token: 0x04002E84 RID: 11908
		[CompilerGenerated]
		private float float_3;

		// Token: 0x04002E85 RID: 11909
		[CompilerGenerated]
		private float float_4;

		// Token: 0x04002E86 RID: 11910
		[CompilerGenerated]
		private float float_5;

		// Token: 0x04002E87 RID: 11911
		[CompilerGenerated]
		private float float_6;

		// Token: 0x04002E88 RID: 11912
		[CompilerGenerated]
		private float float_7;

		// Token: 0x04002E89 RID: 11913
		[CompilerGenerated]
		private float float_8;

		// Token: 0x04002E8A RID: 11914
		[CompilerGenerated]
		private float float_9;

		// Token: 0x04002E8B RID: 11915
		[CompilerGenerated]
		private float float_10;

		// Token: 0x04002E8C RID: 11916
		[CompilerGenerated]
		private float float_11;

		// Token: 0x04002E8D RID: 11917
		[CompilerGenerated]
		private FireBirdBehaviorType fireBirdBehaviorType_0;

		// Token: 0x04002E8E RID: 11918
		[CompilerGenerated]
		private float float_12;

		// Token: 0x04002E8F RID: 11919
		[CompilerGenerated]
		private float float_13;

		// Token: 0x04002E90 RID: 11920
		[CompilerGenerated]
		private float float_14;

		// Token: 0x04002E91 RID: 11921
		[CompilerGenerated]
		private float float_15;
	}
}
