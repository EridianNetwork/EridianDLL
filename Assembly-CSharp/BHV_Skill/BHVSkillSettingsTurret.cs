using System;
using System.Runtime.CompilerServices;

namespace BHV_Skill
{
	// Token: 0x02000964 RID: 2404
	public class BHVSkillSettingsTurret : BHVSkillSettings
	{
		// Token: 0x060042F5 RID: 17141 RVA: 0x0012F118 File Offset: 0x0012D318
		public BHVSkillSettingsTurret()
		{
			this.m_spawnTurretDelay = 0f;
			this.m_k_turretLifeTime = 0f;
			this.m_k_longCooldown = 0f;
			this.m_k_shortCooldown = 0f;
			this.m_radius_AOEHealthRegen = 0f;
			this.m_radius_AOEAmmoRegen = 0f;
			this.m_radius_AOEShield = 0f;
			this.m_deployDistance = 3f;
			this.m_dmg_deployExplode = 0f;
			this.m_spawnAnimDuration = 0f;
		}

		// Token: 0x170004F2 RID: 1266
		// (get) Token: 0x060042F6 RID: 17142 RVA: 0x0002C974 File Offset: 0x0002AB74
		// (set) Token: 0x060042F7 RID: 17143 RVA: 0x0002C97C File Offset: 0x0002AB7C
		public float m_spawnTurretDelay { get; set; }

		// Token: 0x170004F3 RID: 1267
		// (get) Token: 0x060042F8 RID: 17144 RVA: 0x0002C985 File Offset: 0x0002AB85
		// (set) Token: 0x060042F9 RID: 17145 RVA: 0x0002C98D File Offset: 0x0002AB8D
		public float m_k_turretLifeTime { get; set; }

		// Token: 0x170004F4 RID: 1268
		// (get) Token: 0x060042FA RID: 17146 RVA: 0x0002C996 File Offset: 0x0002AB96
		// (set) Token: 0x060042FB RID: 17147 RVA: 0x0002C99E File Offset: 0x0002AB9E
		public float m_k_longCooldown { get; set; }

		// Token: 0x170004F5 RID: 1269
		// (get) Token: 0x060042FC RID: 17148 RVA: 0x0002C9A7 File Offset: 0x0002ABA7
		// (set) Token: 0x060042FD RID: 17149 RVA: 0x0002C9AF File Offset: 0x0002ABAF
		public float m_k_shortCooldown { get; set; }

		// Token: 0x170004F6 RID: 1270
		// (get) Token: 0x060042FE RID: 17150 RVA: 0x0002C9B8 File Offset: 0x0002ABB8
		// (set) Token: 0x060042FF RID: 17151 RVA: 0x0002C9C0 File Offset: 0x0002ABC0
		public float m_radius_AOEHealthRegen { get; set; }

		// Token: 0x170004F7 RID: 1271
		// (get) Token: 0x06004300 RID: 17152 RVA: 0x0002C9C9 File Offset: 0x0002ABC9
		// (set) Token: 0x06004301 RID: 17153 RVA: 0x0002C9D1 File Offset: 0x0002ABD1
		public float m_radius_AOEAmmoRegen { get; set; }

		// Token: 0x170004F8 RID: 1272
		// (get) Token: 0x06004302 RID: 17154 RVA: 0x0002C9DA File Offset: 0x0002ABDA
		// (set) Token: 0x06004303 RID: 17155 RVA: 0x0002C9E2 File Offset: 0x0002ABE2
		public float m_radius_AOEShield { get; set; }

		// Token: 0x170004F9 RID: 1273
		// (get) Token: 0x06004304 RID: 17156 RVA: 0x0002C9EB File Offset: 0x0002ABEB
		// (set) Token: 0x06004305 RID: 17157 RVA: 0x0002C9F3 File Offset: 0x0002ABF3
		public float m_deployDistance { get; set; }

		// Token: 0x170004FA RID: 1274
		// (get) Token: 0x06004306 RID: 17158 RVA: 0x0002C9FC File Offset: 0x0002ABFC
		// (set) Token: 0x06004307 RID: 17159 RVA: 0x0002CA04 File Offset: 0x0002AC04
		public float m_dmg_deployExplode { get; set; }

		// Token: 0x170004FB RID: 1275
		// (get) Token: 0x06004308 RID: 17160 RVA: 0x0002CA0D File Offset: 0x0002AC0D
		// (set) Token: 0x06004309 RID: 17161 RVA: 0x0002CA15 File Offset: 0x0002AC15
		public float m_spawnAnimDuration { get; set; }

		// Token: 0x04002E77 RID: 11895
		[CompilerGenerated]
		private float float_0;

		// Token: 0x04002E78 RID: 11896
		[CompilerGenerated]
		private float float_1;

		// Token: 0x04002E79 RID: 11897
		[CompilerGenerated]
		private float float_2;

		// Token: 0x04002E7A RID: 11898
		[CompilerGenerated]
		private float float_3;

		// Token: 0x04002E7B RID: 11899
		[CompilerGenerated]
		private float float_4;

		// Token: 0x04002E7C RID: 11900
		[CompilerGenerated]
		private float float_5;

		// Token: 0x04002E7D RID: 11901
		[CompilerGenerated]
		private float float_6;

		// Token: 0x04002E7E RID: 11902
		[CompilerGenerated]
		private float float_7;

		// Token: 0x04002E7F RID: 11903
		[CompilerGenerated]
		private float float_8;

		// Token: 0x04002E80 RID: 11904
		[CompilerGenerated]
		private float float_9;
	}
}
