using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using XsdSettings;

namespace BHV
{
	// Token: 0x0200096F RID: 2415
	public class BHVFlyMeleeAttackSettings : BHVTaskSettings
	{
		// Token: 0x06004379 RID: 17273 RVA: 0x0002CD9C File Offset: 0x0002AF9C
		public BHVFlyMeleeAttackSettings()
		{
			this.m_meleeAttackDistanceMin = 0f;
			this.m_meleeAttackDistanceMax = 2f;
			this.m_meleeAttackIdleTimeMin = 3f;
			this.m_attackDamage = 20;
		}

		// Token: 0x1700052F RID: 1327
		// (get) Token: 0x0600437A RID: 17274 RVA: 0x0002CDCD File Offset: 0x0002AFCD
		// (set) Token: 0x0600437B RID: 17275 RVA: 0x0002CDD5 File Offset: 0x0002AFD5
		[DefaultValue(typeof(float), "0")]
		public float m_meleeAttackDistanceMin { get; set; }

		// Token: 0x17000530 RID: 1328
		// (get) Token: 0x0600437C RID: 17276 RVA: 0x0002CDDE File Offset: 0x0002AFDE
		// (set) Token: 0x0600437D RID: 17277 RVA: 0x0002CDE6 File Offset: 0x0002AFE6
		[DefaultValue(typeof(float), "2")]
		public float m_meleeAttackDistanceMax { get; set; }

		// Token: 0x17000531 RID: 1329
		// (get) Token: 0x0600437E RID: 17278 RVA: 0x0002CDEF File Offset: 0x0002AFEF
		// (set) Token: 0x0600437F RID: 17279 RVA: 0x0002CDF7 File Offset: 0x0002AFF7
		[DefaultValue(typeof(float), "3")]
		public float m_meleeAttackIdleTimeMin { get; set; }

		// Token: 0x17000532 RID: 1330
		// (get) Token: 0x06004380 RID: 17280 RVA: 0x0002CE00 File Offset: 0x0002B000
		// (set) Token: 0x06004381 RID: 17281 RVA: 0x0002CE08 File Offset: 0x0002B008
		public float m_meleeAttackIdleTimeMax { get; set; }

		// Token: 0x17000533 RID: 1331
		// (get) Token: 0x06004382 RID: 17282 RVA: 0x0002CE11 File Offset: 0x0002B011
		// (set) Token: 0x06004383 RID: 17283 RVA: 0x0002CE19 File Offset: 0x0002B019
		[XmlIgnore]
		public bool m_meleeAttackIdleTimeMaxSpecified { get; set; }

		// Token: 0x17000534 RID: 1332
		// (get) Token: 0x06004384 RID: 17284 RVA: 0x0002CE22 File Offset: 0x0002B022
		// (set) Token: 0x06004385 RID: 17285 RVA: 0x0002CE2A File Offset: 0x0002B02A
		[DefaultValue(20)]
		public int m_attackDamage { get; set; }

		// Token: 0x17000535 RID: 1333
		// (get) Token: 0x06004386 RID: 17286 RVA: 0x0002CE33 File Offset: 0x0002B033
		// (set) Token: 0x06004387 RID: 17287 RVA: 0x0002CE3B File Offset: 0x0002B03B
		[XmlArrayItem("m_attackSubType", IsNullable = false)]
		public AttackSubType[] m_attackSubTypeList { get; set; }

		// Token: 0x04002EB8 RID: 11960
		private AttackSubType[] attackSubType_0;

		// Token: 0x04002EB9 RID: 11961
		[CompilerGenerated]
		private float float_0;

		// Token: 0x04002EBA RID: 11962
		[CompilerGenerated]
		private float float_1;

		// Token: 0x04002EBB RID: 11963
		[CompilerGenerated]
		private float float_2;

		// Token: 0x04002EBC RID: 11964
		[CompilerGenerated]
		private float float_3;

		// Token: 0x04002EBD RID: 11965
		[CompilerGenerated]
		private bool bool_0;

		// Token: 0x04002EBE RID: 11966
		[CompilerGenerated]
		private int int_0;

		// Token: 0x04002EBF RID: 11967
		[CompilerGenerated]
		private AttackSubType[] attackSubType_1;
	}
}
