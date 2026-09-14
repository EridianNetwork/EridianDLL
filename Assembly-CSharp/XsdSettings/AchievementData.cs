using System;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x02000911 RID: 2321
	public class AchievementData
	{
		// Token: 0x17000394 RID: 916
		// (get) Token: 0x06003FE8 RID: 16360 RVA: 0x0002ACE1 File Offset: 0x00028EE1
		// (set) Token: 0x06003FE9 RID: 16361 RVA: 0x0002ACE9 File Offset: 0x00028EE9
		public int m_achievementId { get; set; }

		// Token: 0x17000395 RID: 917
		// (get) Token: 0x06003FEA RID: 16362 RVA: 0x0002ACF2 File Offset: 0x00028EF2
		// (set) Token: 0x06003FEB RID: 16363 RVA: 0x0002ACFA File Offset: 0x00028EFA
		public string m_achievementName { get; set; }

		// Token: 0x17000396 RID: 918
		// (get) Token: 0x06003FEC RID: 16364 RVA: 0x0002AD03 File Offset: 0x00028F03
		// (set) Token: 0x06003FED RID: 16365 RVA: 0x0002AD0B File Offset: 0x00028F0B
		[XmlArrayItem("m_stage", IsNullable = false)]
		public AchievementStageData[] m_achievementStages { get; set; }

		// Token: 0x04002CEC RID: 11500
		private AchievementStageData[] m_achievementStagesField;
	}
}
