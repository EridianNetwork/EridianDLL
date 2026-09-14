using System;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x020009C2 RID: 2498
	public class GuildProgression
	{
		// Token: 0x170005F0 RID: 1520
		// (get) Token: 0x06004539 RID: 17721 RVA: 0x0002DCDC File Offset: 0x0002BEDC
		// (set) Token: 0x0600453A RID: 17722 RVA: 0x0002DCE4 File Offset: 0x0002BEE4
		[XmlArrayItem("m_level", IsNullable = false)]
		public ExpProgressionData[] m_progressionTable { get; set; }

		// Token: 0x170005F1 RID: 1521
		// (get) Token: 0x0600453B RID: 17723 RVA: 0x0002DCED File Offset: 0x0002BEED
		// (set) Token: 0x0600453C RID: 17724 RVA: 0x0002DCF5 File Offset: 0x0002BEF5
		[XmlArrayItem("m_guildSkill", IsNullable = false)]
		public GuildSkillData[] m_guildSkills { get; set; }

		// Token: 0x170005F2 RID: 1522
		// (get) Token: 0x0600453D RID: 17725 RVA: 0x0002DCFE File Offset: 0x0002BEFE
		// (set) Token: 0x0600453E RID: 17726 RVA: 0x0002DD06 File Offset: 0x0002BF06
		public GuildExpFactorDataList m_guildExpFactors { get; set; }

		// Token: 0x170005F3 RID: 1523
		// (get) Token: 0x0600453F RID: 17727 RVA: 0x0002DD0F File Offset: 0x0002BF0F
		// (set) Token: 0x06004540 RID: 17728 RVA: 0x0002DD17 File Offset: 0x0002BF17
		public int m_guildSkillSelectStep { get; set; }

		// Token: 0x0400310B RID: 12555
		private ExpProgressionData[] m_progressionTableField;

		// Token: 0x0400310C RID: 12556
		private GuildSkillData[] m_guildSkillsField;

		// Token: 0x0400310D RID: 12557
		private GuildExpFactorDataList m_guildExpFactorsField;
	}
}
