using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace BHV_Anim
{
	// Token: 0x02000918 RID: 2328
	public class BHVAnimationManagerSettings
	{
		// Token: 0x06004012 RID: 16402 RVA: 0x0012EA74 File Offset: 0x0012CC74
		public BHVAnimationManagerSettings()
		{
			this.m_weaponHolderName = string.Empty;
			this.m_weaponPrefabName = string.Empty;
			this.m_hasDeathAnimation = false;
			this.m_animationHostName = string.Empty;
			this.m_animationSpeedFactor = 1f;
			this.m_normalDeathAnimCount = 0;
			this.m_headShotDeathAnimCount = 0;
		}

		// Token: 0x170003A6 RID: 934
		// (get) Token: 0x06004013 RID: 16403 RVA: 0x0002AE13 File Offset: 0x00029013
		// (set) Token: 0x06004014 RID: 16404 RVA: 0x0002AE1B File Offset: 0x0002901B
		[DefaultValue("")]
		public string m_weaponHolderName { get; set; }

		// Token: 0x170003A7 RID: 935
		// (get) Token: 0x06004015 RID: 16405 RVA: 0x0002AE24 File Offset: 0x00029024
		// (set) Token: 0x06004016 RID: 16406 RVA: 0x0002AE2C File Offset: 0x0002902C
		[DefaultValue("")]
		public string m_weaponPrefabName { get; set; }

		// Token: 0x170003A8 RID: 936
		// (get) Token: 0x06004017 RID: 16407 RVA: 0x0002AE35 File Offset: 0x00029035
		// (set) Token: 0x06004018 RID: 16408 RVA: 0x0002AE3D File Offset: 0x0002903D
		[DefaultValue(false)]
		public bool m_hasDeathAnimation { get; set; }

		// Token: 0x170003A9 RID: 937
		// (get) Token: 0x06004019 RID: 16409 RVA: 0x0002AE46 File Offset: 0x00029046
		// (set) Token: 0x0600401A RID: 16410 RVA: 0x0002AE4E File Offset: 0x0002904E
		[DefaultValue("")]
		public string m_animationHostName { get; set; }

		// Token: 0x170003AA RID: 938
		// (get) Token: 0x0600401B RID: 16411 RVA: 0x0002AE57 File Offset: 0x00029057
		// (set) Token: 0x0600401C RID: 16412 RVA: 0x0002AE5F File Offset: 0x0002905F
		[DefaultValue(typeof(float), "1")]
		public float m_animationSpeedFactor { get; set; }

		// Token: 0x170003AB RID: 939
		// (get) Token: 0x0600401D RID: 16413 RVA: 0x0002AE68 File Offset: 0x00029068
		// (set) Token: 0x0600401E RID: 16414 RVA: 0x0002AE70 File Offset: 0x00029070
		[DefaultValue(0)]
		public int m_normalDeathAnimCount { get; set; }

		// Token: 0x170003AC RID: 940
		// (get) Token: 0x0600401F RID: 16415 RVA: 0x0002AE79 File Offset: 0x00029079
		// (set) Token: 0x06004020 RID: 16416 RVA: 0x0002AE81 File Offset: 0x00029081
		[DefaultValue(0)]
		public int m_headShotDeathAnimCount { get; set; }

		// Token: 0x170003AD RID: 941
		// (get) Token: 0x06004021 RID: 16417 RVA: 0x0002AE8A File Offset: 0x0002908A
		// (set) Token: 0x06004022 RID: 16418 RVA: 0x0002AE92 File Offset: 0x00029092
		public float m_invisibleChance { get; set; }

		// Token: 0x170003AE RID: 942
		// (get) Token: 0x06004023 RID: 16419 RVA: 0x0002AE9B File Offset: 0x0002909B
		// (set) Token: 0x06004024 RID: 16420 RVA: 0x0002AEA3 File Offset: 0x000290A3
		[XmlIgnore]
		public bool m_invisibleChanceSpecified { get; set; }

		// Token: 0x04002D03 RID: 11523
		[CompilerGenerated]
		private string string_0;

		// Token: 0x04002D04 RID: 11524
		[CompilerGenerated]
		private string string_1;

		// Token: 0x04002D05 RID: 11525
		[CompilerGenerated]
		private bool bool_0;

		// Token: 0x04002D06 RID: 11526
		[CompilerGenerated]
		private string string_2;

		// Token: 0x04002D07 RID: 11527
		[CompilerGenerated]
		private float float_0;

		// Token: 0x04002D08 RID: 11528
		[CompilerGenerated]
		private int int_0;

		// Token: 0x04002D09 RID: 11529
		[CompilerGenerated]
		private int int_1;

		// Token: 0x04002D0A RID: 11530
		[CompilerGenerated]
		private float float_1;

		// Token: 0x04002D0B RID: 11531
		[CompilerGenerated]
		private bool bool_1;
	}
}
