using System;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x02000A0F RID: 2575
	public class DailyQuestConfig
	{
		// Token: 0x060046D9 RID: 18137 RVA: 0x0002EA96 File Offset: 0x0002CC96
		public DailyQuestConfig()
		{
			this.mMaxAcceptDailyQuestCount = 5;
		}

		// Token: 0x170006A0 RID: 1696
		// (get) Token: 0x060046DA RID: 18138 RVA: 0x0002EAA5 File Offset: 0x0002CCA5
		// (set) Token: 0x060046DB RID: 18139 RVA: 0x0002EAAD File Offset: 0x0002CCAD
		public int mMaxAcceptDailyQuestCount { get; set; }

		// Token: 0x170006A1 RID: 1697
		// (get) Token: 0x060046DC RID: 18140 RVA: 0x0002EAB6 File Offset: 0x0002CCB6
		// (set) Token: 0x060046DD RID: 18141 RVA: 0x0002EABE File Offset: 0x0002CCBE
		[XmlArrayItem("mLevelDailyQuest", IsNullable = false)]
		public LevelDailyQuest[] mLevelDailyQuestList { get; set; }

		// Token: 0x040032A5 RID: 12965
		private LevelDailyQuest[] mLevelDailyQuestListField;
	}
}
