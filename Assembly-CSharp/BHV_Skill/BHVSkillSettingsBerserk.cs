using System;
using System.Runtime.CompilerServices;

namespace BHV_Skill
{
	// Token: 0x02000967 RID: 2407
	public class BHVSkillSettingsBerserk : BHVSkillSettings
	{
		// Token: 0x0600432D RID: 17197 RVA: 0x0012F268 File Offset: 0x0012D468
		public BHVSkillSettingsBerserk()
		{
			this.m_duration = 0f;
			this.m_cooldown = 0f;
			this.m_fireRate = 0f;
			this.m_reload = 0f;
			this.m_shieldRefill = 0f;
			this.m_healthRefill = 0f;
			this.m_dashDuration = 0f;
			this.m_dashSpeed = 0f;
			this.m_stompRadius = 0f;
			this.m_stompDamage = 0f;
			this.m_punchRadius = 0f;
			this.m_punchDamage = 0f;
			this.m_punchAngle = 0f;
			this.m_regenHealthPerSecond = 0f;
			this.m_regenAmmoPerSecond = 0f;
			this.m_rotationMultiplier = 0f;
			this.m_fireBoostInterval = 0f;
			this.m_fireBoostMaxPow = 0;
			this.m_lifeThresholdForResist = 0f;
		}

		// Token: 0x1700050D RID: 1293
		// (get) Token: 0x0600432E RID: 17198 RVA: 0x0002CB3F File Offset: 0x0002AD3F
		// (set) Token: 0x0600432F RID: 17199 RVA: 0x0002CB47 File Offset: 0x0002AD47
		public float m_duration { get; set; }

		// Token: 0x1700050E RID: 1294
		// (get) Token: 0x06004330 RID: 17200 RVA: 0x0002CB50 File Offset: 0x0002AD50
		// (set) Token: 0x06004331 RID: 17201 RVA: 0x0002CB58 File Offset: 0x0002AD58
		public float m_cooldown { get; set; }

		// Token: 0x1700050F RID: 1295
		// (get) Token: 0x06004332 RID: 17202 RVA: 0x0002CB61 File Offset: 0x0002AD61
		// (set) Token: 0x06004333 RID: 17203 RVA: 0x0002CB69 File Offset: 0x0002AD69
		public float m_fireRate { get; set; }

		// Token: 0x17000510 RID: 1296
		// (get) Token: 0x06004334 RID: 17204 RVA: 0x0002CB72 File Offset: 0x0002AD72
		// (set) Token: 0x06004335 RID: 17205 RVA: 0x0002CB7A File Offset: 0x0002AD7A
		public float m_reload { get; set; }

		// Token: 0x17000511 RID: 1297
		// (get) Token: 0x06004336 RID: 17206 RVA: 0x0002CB83 File Offset: 0x0002AD83
		// (set) Token: 0x06004337 RID: 17207 RVA: 0x0002CB8B File Offset: 0x0002AD8B
		public float m_shieldRefill { get; set; }

		// Token: 0x17000512 RID: 1298
		// (get) Token: 0x06004338 RID: 17208 RVA: 0x0002CB94 File Offset: 0x0002AD94
		// (set) Token: 0x06004339 RID: 17209 RVA: 0x0002CB9C File Offset: 0x0002AD9C
		public float m_healthRefill { get; set; }

		// Token: 0x17000513 RID: 1299
		// (get) Token: 0x0600433A RID: 17210 RVA: 0x0002CBA5 File Offset: 0x0002ADA5
		// (set) Token: 0x0600433B RID: 17211 RVA: 0x0002CBAD File Offset: 0x0002ADAD
		public float m_dashDuration { get; set; }

		// Token: 0x17000514 RID: 1300
		// (get) Token: 0x0600433C RID: 17212 RVA: 0x0002CBB6 File Offset: 0x0002ADB6
		// (set) Token: 0x0600433D RID: 17213 RVA: 0x0002CBBE File Offset: 0x0002ADBE
		public float m_dashSpeed { get; set; }

		// Token: 0x17000515 RID: 1301
		// (get) Token: 0x0600433E RID: 17214 RVA: 0x0002CBC7 File Offset: 0x0002ADC7
		// (set) Token: 0x0600433F RID: 17215 RVA: 0x0002CBCF File Offset: 0x0002ADCF
		public float m_stompRadius { get; set; }

		// Token: 0x17000516 RID: 1302
		// (get) Token: 0x06004340 RID: 17216 RVA: 0x0002CBD8 File Offset: 0x0002ADD8
		// (set) Token: 0x06004341 RID: 17217 RVA: 0x0002CBE0 File Offset: 0x0002ADE0
		public float m_stompDamage { get; set; }

		// Token: 0x17000517 RID: 1303
		// (get) Token: 0x06004342 RID: 17218 RVA: 0x0002CBE9 File Offset: 0x0002ADE9
		// (set) Token: 0x06004343 RID: 17219 RVA: 0x0002CBF1 File Offset: 0x0002ADF1
		public float m_punchRadius { get; set; }

		// Token: 0x17000518 RID: 1304
		// (get) Token: 0x06004344 RID: 17220 RVA: 0x0002CBFA File Offset: 0x0002ADFA
		// (set) Token: 0x06004345 RID: 17221 RVA: 0x0002CC02 File Offset: 0x0002AE02
		public float m_punchDamage { get; set; }

		// Token: 0x17000519 RID: 1305
		// (get) Token: 0x06004346 RID: 17222 RVA: 0x0002CC0B File Offset: 0x0002AE0B
		// (set) Token: 0x06004347 RID: 17223 RVA: 0x0002CC13 File Offset: 0x0002AE13
		public float m_punchAngle { get; set; }

		// Token: 0x1700051A RID: 1306
		// (get) Token: 0x06004348 RID: 17224 RVA: 0x0002CC1C File Offset: 0x0002AE1C
		// (set) Token: 0x06004349 RID: 17225 RVA: 0x0002CC24 File Offset: 0x0002AE24
		public float m_regenHealthPerSecond { get; set; }

		// Token: 0x1700051B RID: 1307
		// (get) Token: 0x0600434A RID: 17226 RVA: 0x0002CC2D File Offset: 0x0002AE2D
		// (set) Token: 0x0600434B RID: 17227 RVA: 0x0002CC35 File Offset: 0x0002AE35
		public float m_regenAmmoPerSecond { get; set; }

		// Token: 0x1700051C RID: 1308
		// (get) Token: 0x0600434C RID: 17228 RVA: 0x0002CC3E File Offset: 0x0002AE3E
		// (set) Token: 0x0600434D RID: 17229 RVA: 0x0002CC46 File Offset: 0x0002AE46
		public float m_rotationMultiplier { get; set; }

		// Token: 0x1700051D RID: 1309
		// (get) Token: 0x0600434E RID: 17230 RVA: 0x0002CC4F File Offset: 0x0002AE4F
		// (set) Token: 0x0600434F RID: 17231 RVA: 0x0002CC57 File Offset: 0x0002AE57
		public float m_fireBoostInterval { get; set; }

		// Token: 0x1700051E RID: 1310
		// (get) Token: 0x06004350 RID: 17232 RVA: 0x0002CC60 File Offset: 0x0002AE60
		// (set) Token: 0x06004351 RID: 17233 RVA: 0x0002CC68 File Offset: 0x0002AE68
		public int m_fireBoostMaxPow { get; set; }

		// Token: 0x1700051F RID: 1311
		// (get) Token: 0x06004352 RID: 17234 RVA: 0x0002CC71 File Offset: 0x0002AE71
		// (set) Token: 0x06004353 RID: 17235 RVA: 0x0002CC79 File Offset: 0x0002AE79
		public float m_lifeThresholdForResist { get; set; }

		// Token: 0x04002E95 RID: 11925
		[CompilerGenerated]
		private float float_0;

		// Token: 0x04002E96 RID: 11926
		[CompilerGenerated]
		private float float_1;

		// Token: 0x04002E97 RID: 11927
		[CompilerGenerated]
		private float float_2;

		// Token: 0x04002E98 RID: 11928
		[CompilerGenerated]
		private float float_3;

		// Token: 0x04002E99 RID: 11929
		[CompilerGenerated]
		private float float_4;

		// Token: 0x04002E9A RID: 11930
		[CompilerGenerated]
		private float float_5;

		// Token: 0x04002E9B RID: 11931
		[CompilerGenerated]
		private float float_6;

		// Token: 0x04002E9C RID: 11932
		[CompilerGenerated]
		private float float_7;

		// Token: 0x04002E9D RID: 11933
		[CompilerGenerated]
		private float float_8;

		// Token: 0x04002E9E RID: 11934
		[CompilerGenerated]
		private float float_9;

		// Token: 0x04002E9F RID: 11935
		[CompilerGenerated]
		private float float_10;

		// Token: 0x04002EA0 RID: 11936
		[CompilerGenerated]
		private float float_11;

		// Token: 0x04002EA1 RID: 11937
		[CompilerGenerated]
		private float float_12;

		// Token: 0x04002EA2 RID: 11938
		[CompilerGenerated]
		private float float_13;

		// Token: 0x04002EA3 RID: 11939
		[CompilerGenerated]
		private float float_14;

		// Token: 0x04002EA4 RID: 11940
		[CompilerGenerated]
		private float float_15;

		// Token: 0x04002EA5 RID: 11941
		[CompilerGenerated]
		private float float_16;

		// Token: 0x04002EA6 RID: 11942
		[CompilerGenerated]
		private int int_0;

		// Token: 0x04002EA7 RID: 11943
		[CompilerGenerated]
		private float float_17;
	}
}
