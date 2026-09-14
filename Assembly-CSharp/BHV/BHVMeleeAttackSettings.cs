using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using XsdSettings;

namespace BHV
{
	// Token: 0x02000975 RID: 2421
	public class BHVMeleeAttackSettings : BHVTaskSettings
	{
		// Token: 0x060043AF RID: 17327 RVA: 0x0012F348 File Offset: 0x0012D548
		public BHVMeleeAttackSettings()
		{
			this.m_attackDamage = 1;
			this.m_attackDamageMultiplier = 1f;
			this.m_playerAttackDamageMultiplier = 1f;
			this.m_attackAngle = 90f;
			this.m_attackRange = 3f;
			this.m_canKnockBack = false;
			this.m_canShakeCamera = false;
			this.m_knockBackForce = 1f;
			this.m_knockBackAngle = 10f;
		}

		// Token: 0x17000547 RID: 1351
		// (get) Token: 0x060043B0 RID: 17328 RVA: 0x0002CFEE File Offset: 0x0002B1EE
		// (set) Token: 0x060043B1 RID: 17329 RVA: 0x0002CFF6 File Offset: 0x0002B1F6
		[DefaultValue(1)]
		public int m_attackDamage { get; set; }

		// Token: 0x17000548 RID: 1352
		// (get) Token: 0x060043B2 RID: 17330 RVA: 0x0002CFFF File Offset: 0x0002B1FF
		// (set) Token: 0x060043B3 RID: 17331 RVA: 0x0002D007 File Offset: 0x0002B207
		[DefaultValue(typeof(float), "1")]
		public float m_attackDamageMultiplier { get; set; }

		// Token: 0x17000549 RID: 1353
		// (get) Token: 0x060043B4 RID: 17332 RVA: 0x0002D010 File Offset: 0x0002B210
		// (set) Token: 0x060043B5 RID: 17333 RVA: 0x0002D018 File Offset: 0x0002B218
		[DefaultValue(typeof(float), "1")]
		public float m_playerAttackDamageMultiplier { get; set; }

		// Token: 0x1700054A RID: 1354
		// (get) Token: 0x060043B6 RID: 17334 RVA: 0x0002D021 File Offset: 0x0002B221
		// (set) Token: 0x060043B7 RID: 17335 RVA: 0x0002D029 File Offset: 0x0002B229
		[DefaultValue(typeof(float), "90")]
		public float m_attackAngle { get; set; }

		// Token: 0x1700054B RID: 1355
		// (get) Token: 0x060043B8 RID: 17336 RVA: 0x0002D032 File Offset: 0x0002B232
		// (set) Token: 0x060043B9 RID: 17337 RVA: 0x0002D03A File Offset: 0x0002B23A
		[DefaultValue(typeof(float), "3")]
		public float m_attackRange { get; set; }

		// Token: 0x1700054C RID: 1356
		// (get) Token: 0x060043BA RID: 17338 RVA: 0x0002D043 File Offset: 0x0002B243
		// (set) Token: 0x060043BB RID: 17339 RVA: 0x0002D04B File Offset: 0x0002B24B
		[XmlArrayItem("m_attackSubType", IsNullable = false)]
		public AttackSubType[] m_attackSubTypeList { get; set; }

		// Token: 0x1700054D RID: 1357
		// (get) Token: 0x060043BC RID: 17340 RVA: 0x0002D054 File Offset: 0x0002B254
		// (set) Token: 0x060043BD RID: 17341 RVA: 0x0002D05C File Offset: 0x0002B25C
		[DefaultValue(false)]
		public bool m_canKnockBack { get; set; }

		// Token: 0x1700054E RID: 1358
		// (get) Token: 0x060043BE RID: 17342 RVA: 0x0002D065 File Offset: 0x0002B265
		// (set) Token: 0x060043BF RID: 17343 RVA: 0x0002D06D File Offset: 0x0002B26D
		[DefaultValue(false)]
		public bool m_canShakeCamera { get; set; }

		// Token: 0x1700054F RID: 1359
		// (get) Token: 0x060043C0 RID: 17344 RVA: 0x0002D076 File Offset: 0x0002B276
		// (set) Token: 0x060043C1 RID: 17345 RVA: 0x0002D07E File Offset: 0x0002B27E
		[DefaultValue(typeof(float), "1")]
		public float m_knockBackForce { get; set; }

		// Token: 0x17000550 RID: 1360
		// (get) Token: 0x060043C2 RID: 17346 RVA: 0x0002D087 File Offset: 0x0002B287
		// (set) Token: 0x060043C3 RID: 17347 RVA: 0x0002D08F File Offset: 0x0002B28F
		public float m_knockBackAngle { get; set; }

		// Token: 0x04002ED1 RID: 11985
		private AttackSubType[] attackSubType_0;

		// Token: 0x04002ED2 RID: 11986
		[CompilerGenerated]
		private int int_0;

		// Token: 0x04002ED3 RID: 11987
		[CompilerGenerated]
		private float float_0;

		// Token: 0x04002ED4 RID: 11988
		[CompilerGenerated]
		private float float_1;

		// Token: 0x04002ED5 RID: 11989
		[CompilerGenerated]
		private float float_2;

		// Token: 0x04002ED6 RID: 11990
		[CompilerGenerated]
		private float float_3;

		// Token: 0x04002ED7 RID: 11991
		[CompilerGenerated]
		private AttackSubType[] attackSubType_1;

		// Token: 0x04002ED8 RID: 11992
		[CompilerGenerated]
		private bool bool_0;

		// Token: 0x04002ED9 RID: 11993
		[CompilerGenerated]
		private bool bool_1;

		// Token: 0x04002EDA RID: 11994
		[CompilerGenerated]
		private float float_4;

		// Token: 0x04002EDB RID: 11995
		[CompilerGenerated]
		private float float_5;
	}
}
