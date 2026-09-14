using System;
using System.Runtime.CompilerServices;

namespace BHV_Skill
{
	// Token: 0x02000963 RID: 2403
	public class BHVSkillSettingsHunter : BHVSkillSettings
	{
		// Token: 0x060042C4 RID: 17092 RVA: 0x0012EFFC File Offset: 0x0012D1FC
		public BHVSkillSettingsHunter()
		{
			this.m_droid_lifetime = 0f;
			this.m_long_cooldown = 0f;
			this.m_short_cooldown = 0f;
			this.m_velocity_mark = 0f;
			this.m_spawndroid_delay = 0f;
			this.m_spawnVfx_delay = 0f;
			this.m_retrievedroid_delay = 0f;
			this.m_DOTdamage_fire = 0f;
			this.m_DOTdamage_shock = 0f;
			this.m_DOTdamage_corrosive = 0f;
			this.m_damage_trackshot = 0f;
			this.m_offsetX_droid_1st = 0f;
			this.m_offsetY_droid_1st = 0f;
			this.m_offsetZ_droid_1st = 0f;
			this.m_offsetX_droid_3rd = 0f;
			this.m_offsetY_droid_3rd = 0f;
			this.m_offsetZ_droid_3rd = 0f;
			this.m_yaw_droid = 0f;
			this.m_pitch_droid = 0f;
			this.m_hold_duration = 0f;
			this.m_decay_duration = 0f;
			this.m_baseMarkLength = 0f;
			this.m_powercoeff_markvelocity = 0f;
			this.m_dmgbonus_perlevel = 0f;
		}

		// Token: 0x170004DA RID: 1242
		// (get) Token: 0x060042C5 RID: 17093 RVA: 0x0002C7DC File Offset: 0x0002A9DC
		// (set) Token: 0x060042C6 RID: 17094 RVA: 0x0002C7E4 File Offset: 0x0002A9E4
		public float m_droid_lifetime { get; set; }

		// Token: 0x170004DB RID: 1243
		// (get) Token: 0x060042C7 RID: 17095 RVA: 0x0002C7ED File Offset: 0x0002A9ED
		// (set) Token: 0x060042C8 RID: 17096 RVA: 0x0002C7F5 File Offset: 0x0002A9F5
		public float m_long_cooldown { get; set; }

		// Token: 0x170004DC RID: 1244
		// (get) Token: 0x060042C9 RID: 17097 RVA: 0x0002C7FE File Offset: 0x0002A9FE
		// (set) Token: 0x060042CA RID: 17098 RVA: 0x0002C806 File Offset: 0x0002AA06
		public float m_short_cooldown { get; set; }

		// Token: 0x170004DD RID: 1245
		// (get) Token: 0x060042CB RID: 17099 RVA: 0x0002C80F File Offset: 0x0002AA0F
		// (set) Token: 0x060042CC RID: 17100 RVA: 0x0002C817 File Offset: 0x0002AA17
		public float m_velocity_mark { get; set; }

		// Token: 0x170004DE RID: 1246
		// (get) Token: 0x060042CD RID: 17101 RVA: 0x0002C820 File Offset: 0x0002AA20
		// (set) Token: 0x060042CE RID: 17102 RVA: 0x0002C828 File Offset: 0x0002AA28
		public float m_spawndroid_delay { get; set; }

		// Token: 0x170004DF RID: 1247
		// (get) Token: 0x060042CF RID: 17103 RVA: 0x0002C831 File Offset: 0x0002AA31
		// (set) Token: 0x060042D0 RID: 17104 RVA: 0x0002C839 File Offset: 0x0002AA39
		public float m_spawnVfx_delay { get; set; }

		// Token: 0x170004E0 RID: 1248
		// (get) Token: 0x060042D1 RID: 17105 RVA: 0x0002C842 File Offset: 0x0002AA42
		// (set) Token: 0x060042D2 RID: 17106 RVA: 0x0002C84A File Offset: 0x0002AA4A
		public float m_retrievedroid_delay { get; set; }

		// Token: 0x170004E1 RID: 1249
		// (get) Token: 0x060042D3 RID: 17107 RVA: 0x0002C853 File Offset: 0x0002AA53
		// (set) Token: 0x060042D4 RID: 17108 RVA: 0x0002C85B File Offset: 0x0002AA5B
		public float m_DOTdamage_fire { get; set; }

		// Token: 0x170004E2 RID: 1250
		// (get) Token: 0x060042D5 RID: 17109 RVA: 0x0002C864 File Offset: 0x0002AA64
		// (set) Token: 0x060042D6 RID: 17110 RVA: 0x0002C86C File Offset: 0x0002AA6C
		public float m_DOTdamage_shock { get; set; }

		// Token: 0x170004E3 RID: 1251
		// (get) Token: 0x060042D7 RID: 17111 RVA: 0x0002C875 File Offset: 0x0002AA75
		// (set) Token: 0x060042D8 RID: 17112 RVA: 0x0002C87D File Offset: 0x0002AA7D
		public float m_DOTdamage_corrosive { get; set; }

		// Token: 0x170004E4 RID: 1252
		// (get) Token: 0x060042D9 RID: 17113 RVA: 0x0002C886 File Offset: 0x0002AA86
		// (set) Token: 0x060042DA RID: 17114 RVA: 0x0002C88E File Offset: 0x0002AA8E
		public float m_damage_trackshot { get; set; }

		// Token: 0x170004E5 RID: 1253
		// (get) Token: 0x060042DB RID: 17115 RVA: 0x0002C897 File Offset: 0x0002AA97
		// (set) Token: 0x060042DC RID: 17116 RVA: 0x0002C89F File Offset: 0x0002AA9F
		public float m_offsetX_droid_1st { get; set; }

		// Token: 0x170004E6 RID: 1254
		// (get) Token: 0x060042DD RID: 17117 RVA: 0x0002C8A8 File Offset: 0x0002AAA8
		// (set) Token: 0x060042DE RID: 17118 RVA: 0x0002C8B0 File Offset: 0x0002AAB0
		public float m_offsetY_droid_1st { get; set; }

		// Token: 0x170004E7 RID: 1255
		// (get) Token: 0x060042DF RID: 17119 RVA: 0x0002C8B9 File Offset: 0x0002AAB9
		// (set) Token: 0x060042E0 RID: 17120 RVA: 0x0002C8C1 File Offset: 0x0002AAC1
		public float m_offsetZ_droid_1st { get; set; }

		// Token: 0x170004E8 RID: 1256
		// (get) Token: 0x060042E1 RID: 17121 RVA: 0x0002C8CA File Offset: 0x0002AACA
		// (set) Token: 0x060042E2 RID: 17122 RVA: 0x0002C8D2 File Offset: 0x0002AAD2
		public float m_offsetX_droid_3rd { get; set; }

		// Token: 0x170004E9 RID: 1257
		// (get) Token: 0x060042E3 RID: 17123 RVA: 0x0002C8DB File Offset: 0x0002AADB
		// (set) Token: 0x060042E4 RID: 17124 RVA: 0x0002C8E3 File Offset: 0x0002AAE3
		public float m_offsetY_droid_3rd { get; set; }

		// Token: 0x170004EA RID: 1258
		// (get) Token: 0x060042E5 RID: 17125 RVA: 0x0002C8EC File Offset: 0x0002AAEC
		// (set) Token: 0x060042E6 RID: 17126 RVA: 0x0002C8F4 File Offset: 0x0002AAF4
		public float m_offsetZ_droid_3rd { get; set; }

		// Token: 0x170004EB RID: 1259
		// (get) Token: 0x060042E7 RID: 17127 RVA: 0x0002C8FD File Offset: 0x0002AAFD
		// (set) Token: 0x060042E8 RID: 17128 RVA: 0x0002C905 File Offset: 0x0002AB05
		public float m_yaw_droid { get; set; }

		// Token: 0x170004EC RID: 1260
		// (get) Token: 0x060042E9 RID: 17129 RVA: 0x0002C90E File Offset: 0x0002AB0E
		// (set) Token: 0x060042EA RID: 17130 RVA: 0x0002C916 File Offset: 0x0002AB16
		public float m_pitch_droid { get; set; }

		// Token: 0x170004ED RID: 1261
		// (get) Token: 0x060042EB RID: 17131 RVA: 0x0002C91F File Offset: 0x0002AB1F
		// (set) Token: 0x060042EC RID: 17132 RVA: 0x0002C927 File Offset: 0x0002AB27
		public float m_hold_duration { get; set; }

		// Token: 0x170004EE RID: 1262
		// (get) Token: 0x060042ED RID: 17133 RVA: 0x0002C930 File Offset: 0x0002AB30
		// (set) Token: 0x060042EE RID: 17134 RVA: 0x0002C938 File Offset: 0x0002AB38
		public float m_decay_duration { get; set; }

		// Token: 0x170004EF RID: 1263
		// (get) Token: 0x060042EF RID: 17135 RVA: 0x0002C941 File Offset: 0x0002AB41
		// (set) Token: 0x060042F0 RID: 17136 RVA: 0x0002C949 File Offset: 0x0002AB49
		public float m_baseMarkLength { get; set; }

		// Token: 0x170004F0 RID: 1264
		// (get) Token: 0x060042F1 RID: 17137 RVA: 0x0002C952 File Offset: 0x0002AB52
		// (set) Token: 0x060042F2 RID: 17138 RVA: 0x0002C95A File Offset: 0x0002AB5A
		public float m_powercoeff_markvelocity { get; set; }

		// Token: 0x170004F1 RID: 1265
		// (get) Token: 0x060042F3 RID: 17139 RVA: 0x0002C963 File Offset: 0x0002AB63
		// (set) Token: 0x060042F4 RID: 17140 RVA: 0x0002C96B File Offset: 0x0002AB6B
		public float m_dmgbonus_perlevel { get; set; }

		// Token: 0x04002E5F RID: 11871
		[CompilerGenerated]
		private float float_0;

		// Token: 0x04002E60 RID: 11872
		[CompilerGenerated]
		private float float_1;

		// Token: 0x04002E61 RID: 11873
		[CompilerGenerated]
		private float float_2;

		// Token: 0x04002E62 RID: 11874
		[CompilerGenerated]
		private float float_3;

		// Token: 0x04002E63 RID: 11875
		[CompilerGenerated]
		private float float_4;

		// Token: 0x04002E64 RID: 11876
		[CompilerGenerated]
		private float float_5;

		// Token: 0x04002E65 RID: 11877
		[CompilerGenerated]
		private float float_6;

		// Token: 0x04002E66 RID: 11878
		[CompilerGenerated]
		private float float_7;

		// Token: 0x04002E67 RID: 11879
		[CompilerGenerated]
		private float float_8;

		// Token: 0x04002E68 RID: 11880
		[CompilerGenerated]
		private float float_9;

		// Token: 0x04002E69 RID: 11881
		[CompilerGenerated]
		private float float_10;

		// Token: 0x04002E6A RID: 11882
		[CompilerGenerated]
		private float float_11;

		// Token: 0x04002E6B RID: 11883
		[CompilerGenerated]
		private float float_12;

		// Token: 0x04002E6C RID: 11884
		[CompilerGenerated]
		private float float_13;

		// Token: 0x04002E6D RID: 11885
		[CompilerGenerated]
		private float float_14;

		// Token: 0x04002E6E RID: 11886
		[CompilerGenerated]
		private float float_15;

		// Token: 0x04002E6F RID: 11887
		[CompilerGenerated]
		private float float_16;

		// Token: 0x04002E70 RID: 11888
		[CompilerGenerated]
		private float float_17;

		// Token: 0x04002E71 RID: 11889
		[CompilerGenerated]
		private float float_18;

		// Token: 0x04002E72 RID: 11890
		[CompilerGenerated]
		private float float_19;

		// Token: 0x04002E73 RID: 11891
		[CompilerGenerated]
		private float float_20;

		// Token: 0x04002E74 RID: 11892
		[CompilerGenerated]
		private float float_21;

		// Token: 0x04002E75 RID: 11893
		[CompilerGenerated]
		private float float_22;

		// Token: 0x04002E76 RID: 11894
		[CompilerGenerated]
		private float float_23;
	}
}
