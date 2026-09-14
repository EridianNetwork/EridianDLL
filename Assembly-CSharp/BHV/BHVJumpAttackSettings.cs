using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using XsdSettings;

namespace BHV
{
	// Token: 0x02000976 RID: 2422
	public class BHVJumpAttackSettings : BHVTaskSettings
	{
		// Token: 0x060043C4 RID: 17348 RVA: 0x0002D098 File Offset: 0x0002B298
		public BHVJumpAttackSettings()
		{
			this.m_attackDamage = 1;
			this.m_attackSubType = AttackSubType.MeleeGeneric;
			this.m_onTheSpotAttackDamage = 1;
			this.m_onTheSpotAttackRange = 0.01f;
			this.m_jumpAttackDetectRadius = 0.3f;
			this.m_onTheSpotAttackSubType = AttackSubType.AreaGeneric;
		}

		// Token: 0x17000551 RID: 1361
		// (get) Token: 0x060043C5 RID: 17349 RVA: 0x0002D0D4 File Offset: 0x0002B2D4
		// (set) Token: 0x060043C6 RID: 17350 RVA: 0x0002D0DC File Offset: 0x0002B2DC
		[DefaultValue(1)]
		public int m_attackDamage { get; set; }

		// Token: 0x17000552 RID: 1362
		// (get) Token: 0x060043C7 RID: 17351 RVA: 0x0002D0E5 File Offset: 0x0002B2E5
		// (set) Token: 0x060043C8 RID: 17352 RVA: 0x0002D0ED File Offset: 0x0002B2ED
		[DefaultValue(AttackSubType.MeleeGeneric)]
		public AttackSubType m_attackSubType { get; set; }

		// Token: 0x17000553 RID: 1363
		// (get) Token: 0x060043C9 RID: 17353 RVA: 0x0002D0F6 File Offset: 0x0002B2F6
		// (set) Token: 0x060043CA RID: 17354 RVA: 0x0002D0FE File Offset: 0x0002B2FE
		[DefaultValue(1)]
		public int m_onTheSpotAttackDamage { get; set; }

		// Token: 0x17000554 RID: 1364
		// (get) Token: 0x060043CB RID: 17355 RVA: 0x0002D107 File Offset: 0x0002B307
		// (set) Token: 0x060043CC RID: 17356 RVA: 0x0002D10F File Offset: 0x0002B30F
		[DefaultValue(typeof(float), "0.01")]
		public float m_onTheSpotAttackRange { get; set; }

		// Token: 0x17000555 RID: 1365
		// (get) Token: 0x060043CD RID: 17357 RVA: 0x0002D118 File Offset: 0x0002B318
		// (set) Token: 0x060043CE RID: 17358 RVA: 0x0002D120 File Offset: 0x0002B320
		[DefaultValue(typeof(float), "0.3")]
		public float m_jumpAttackDetectRadius { get; set; }

		// Token: 0x17000556 RID: 1366
		// (get) Token: 0x060043CF RID: 17359 RVA: 0x0002D129 File Offset: 0x0002B329
		// (set) Token: 0x060043D0 RID: 17360 RVA: 0x0002D131 File Offset: 0x0002B331
		[DefaultValue(AttackSubType.AreaGeneric)]
		public AttackSubType m_onTheSpotAttackSubType { get; set; }

		// Token: 0x17000557 RID: 1367
		// (get) Token: 0x060043D1 RID: 17361 RVA: 0x0002D13A File Offset: 0x0002B33A
		// (set) Token: 0x060043D2 RID: 17362 RVA: 0x0002D142 File Offset: 0x0002B342
		public float m_warningZoneRadius { get; set; }

		// Token: 0x17000558 RID: 1368
		// (get) Token: 0x060043D3 RID: 17363 RVA: 0x0002D14B File Offset: 0x0002B34B
		// (set) Token: 0x060043D4 RID: 17364 RVA: 0x0002D153 File Offset: 0x0002B353
		[XmlIgnore]
		public bool m_warningZoneRadiusSpecified { get; set; }

		// Token: 0x04002EDC RID: 11996
		[CompilerGenerated]
		private int int_0;

		// Token: 0x04002EDD RID: 11997
		[CompilerGenerated]
		private AttackSubType attackSubType_0;

		// Token: 0x04002EDE RID: 11998
		[CompilerGenerated]
		private int int_1;

		// Token: 0x04002EDF RID: 11999
		[CompilerGenerated]
		private float float_0;

		// Token: 0x04002EE0 RID: 12000
		[CompilerGenerated]
		private float float_1;

		// Token: 0x04002EE1 RID: 12001
		[CompilerGenerated]
		private AttackSubType attackSubType_1;

		// Token: 0x04002EE2 RID: 12002
		[CompilerGenerated]
		private float float_2;

		// Token: 0x04002EE3 RID: 12003
		[CompilerGenerated]
		private bool bool_0;
	}
}
