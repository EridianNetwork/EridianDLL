using System;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x020009EC RID: 2540
	public class LuckyBoxSettings
	{
		// Token: 0x17000642 RID: 1602
		// (get) Token: 0x06004604 RID: 17924 RVA: 0x0002E3FD File Offset: 0x0002C5FD
		// (set) Token: 0x06004605 RID: 17925 RVA: 0x0002E405 File Offset: 0x0002C605
		[XmlArrayItem("m_id", IsNullable = false)]
		public int[] m_playlists { get; set; }

		// Token: 0x17000643 RID: 1603
		// (get) Token: 0x06004606 RID: 17926 RVA: 0x0002E40E File Offset: 0x0002C60E
		// (set) Token: 0x06004607 RID: 17927 RVA: 0x0002E416 File Offset: 0x0002C616
		[XmlArrayItem("m_rewardPerDifficulty", IsNullable = false)]
		public RewardsPerDifficulty[] m_perDificultyList { get; set; }

		// Token: 0x040031C1 RID: 12737
		private RewardsPerDifficulty[] m_perDificultyListField;
	}
}
