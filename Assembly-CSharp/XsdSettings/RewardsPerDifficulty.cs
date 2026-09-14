using System;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x020009EB RID: 2539
	public class RewardsPerDifficulty
	{
		// Token: 0x060045FE RID: 17918 RVA: 0x0002E3CC File Offset: 0x0002C5CC
		public RewardsPerDifficulty()
		{
			this.m_difficulty = ELevelDifficulty.Normal;
		}

		// Token: 0x17000640 RID: 1600
		// (get) Token: 0x060045FF RID: 17919 RVA: 0x0002E3DB File Offset: 0x0002C5DB
		// (set) Token: 0x06004600 RID: 17920 RVA: 0x0002E3E3 File Offset: 0x0002C5E3
		public ELevelDifficulty m_difficulty { get; set; }

		// Token: 0x17000641 RID: 1601
		// (get) Token: 0x06004601 RID: 17921 RVA: 0x0002E3EC File Offset: 0x0002C5EC
		// (set) Token: 0x06004602 RID: 17922 RVA: 0x0002E3F4 File Offset: 0x0002C5F4
		[XmlArrayItem("m_reward", IsNullable = false)]
		public RewardPerGrade[] m_rewards { get; set; }

		// Token: 0x040031BE RID: 12734
		private RewardPerGrade[] m_rewardsField;
	}
}
