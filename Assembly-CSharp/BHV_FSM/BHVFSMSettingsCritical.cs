using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BHV_FSM
{
	// Token: 0x02000939 RID: 2361
	public class BHVFSMSettingsCritical : BHVPropertySettings
	{
		// Token: 0x0600418D RID: 16781 RVA: 0x0002BBD3 File Offset: 0x00029DD3
		public BHVFSMSettingsCritical()
		{
			this.m_damageMultiplier = 2f;
			this.m_coolDownTime = 5f;
			this.m_time = 2f;
			this.m_damageOfMaxHPPercent = 0.01f;
		}

		// Token: 0x17000453 RID: 1107
		// (get) Token: 0x0600418E RID: 16782 RVA: 0x0002BC07 File Offset: 0x00029E07
		// (set) Token: 0x0600418F RID: 16783 RVA: 0x0002BC0F File Offset: 0x00029E0F
		[DefaultValue(typeof(float), "2")]
		public float m_damageMultiplier { get; set; }

		// Token: 0x17000454 RID: 1108
		// (get) Token: 0x06004190 RID: 16784 RVA: 0x0002BC18 File Offset: 0x00029E18
		// (set) Token: 0x06004191 RID: 16785 RVA: 0x0002BC20 File Offset: 0x00029E20
		[DefaultValue(typeof(float), "5")]
		public float m_coolDownTime { get; set; }

		// Token: 0x17000455 RID: 1109
		// (get) Token: 0x06004192 RID: 16786 RVA: 0x0002BC29 File Offset: 0x00029E29
		// (set) Token: 0x06004193 RID: 16787 RVA: 0x0002BC31 File Offset: 0x00029E31
		[DefaultValue(typeof(float), "2")]
		public float m_time { get; set; }

		// Token: 0x17000456 RID: 1110
		// (get) Token: 0x06004194 RID: 16788 RVA: 0x0002BC3A File Offset: 0x00029E3A
		// (set) Token: 0x06004195 RID: 16789 RVA: 0x0002BC42 File Offset: 0x00029E42
		[DefaultValue(typeof(float), "0.01")]
		public float m_damageOfMaxHPPercent { get; set; }

		// Token: 0x04002DB2 RID: 11698
		[CompilerGenerated]
		private float float_0;

		// Token: 0x04002DB3 RID: 11699
		[CompilerGenerated]
		private float float_1;

		// Token: 0x04002DB4 RID: 11700
		[CompilerGenerated]
		private float float_2;

		// Token: 0x04002DB5 RID: 11701
		[CompilerGenerated]
		private float float_3;
	}
}
