using System;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x02000910 RID: 2320
	public class Achievements
	{
		// Token: 0x17000392 RID: 914
		// (get) Token: 0x06003FE3 RID: 16355 RVA: 0x0002ACBF File Offset: 0x00028EBF
		// (set) Token: 0x06003FE4 RID: 16356 RVA: 0x0002ACC7 File Offset: 0x00028EC7
		[XmlArrayItem("m_achievement", IsNullable = false)]
		public AchievementData[] m_achievementTable { get; set; }

		// Token: 0x17000393 RID: 915
		// (get) Token: 0x06003FE5 RID: 16357 RVA: 0x0002ACD0 File Offset: 0x00028ED0
		// (set) Token: 0x06003FE6 RID: 16358 RVA: 0x0002ACD8 File Offset: 0x00028ED8
		[XmlArrayItem("m_achievementLevel", IsNullable = false)]
		public AchievementLevelData[] m_achievementLevelTable { get; set; }

		// Token: 0x04002CE8 RID: 11496
		private AchievementData[] m_achievementTableField;

		// Token: 0x04002CE9 RID: 11497
		private AchievementLevelData[] m_achievementLevelTableField;
	}
}
