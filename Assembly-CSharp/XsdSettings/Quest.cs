using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x02000A00 RID: 2560
	public class Quest
	{
		// Token: 0x06004678 RID: 18040 RVA: 0x0012F61C File Offset: 0x0012D81C
		public Quest()
		{
			this.mId = 0;
			this.mIsBoundInstance = true;
			this.mCategory = QuestCategory.Story;
			this.mRequiredDifficulty = -1;
			this.mRequiredLevel = 1;
			this.mHighestLevel = 0;
			this.mUnlockLevel = 0;
			this.mRecommendedlevel = 1;
			this.mOptionalRewardsCount = 0;
		}

		// Token: 0x17000674 RID: 1652
		// (get) Token: 0x06004679 RID: 18041 RVA: 0x0002E77F File Offset: 0x0002C97F
		// (set) Token: 0x0600467A RID: 18042 RVA: 0x0002E787 File Offset: 0x0002C987
		public int mId { get; set; }

		// Token: 0x17000675 RID: 1653
		// (get) Token: 0x0600467B RID: 18043 RVA: 0x0002E790 File Offset: 0x0002C990
		// (set) Token: 0x0600467C RID: 18044 RVA: 0x0002E798 File Offset: 0x0002C998
		[XmlArrayItem("m_int", IsNullable = false)]
		public int[] mGiverIdList { get; set; }

		// Token: 0x17000676 RID: 1654
		// (get) Token: 0x0600467D RID: 18045 RVA: 0x0002E7A1 File Offset: 0x0002C9A1
		// (set) Token: 0x0600467E RID: 18046 RVA: 0x0002E7A9 File Offset: 0x0002C9A9
		[XmlArrayItem("m_int", IsNullable = false)]
		public int[] mReclaimerIdList { get; set; }

		// Token: 0x17000677 RID: 1655
		// (get) Token: 0x0600467F RID: 18047 RVA: 0x0002E7B2 File Offset: 0x0002C9B2
		// (set) Token: 0x06004680 RID: 18048 RVA: 0x0002E7BA File Offset: 0x0002C9BA
		public bool mIsBoundInstance { get; set; }

		// Token: 0x17000678 RID: 1656
		// (get) Token: 0x06004681 RID: 18049 RVA: 0x0002E7C3 File Offset: 0x0002C9C3
		// (set) Token: 0x06004682 RID: 18050 RVA: 0x0002E7CB File Offset: 0x0002C9CB
		[XmlArrayItem("m_int", IsNullable = false)]
		public int[] mBoundInstanceList { get; set; }

		// Token: 0x17000679 RID: 1657
		// (get) Token: 0x06004683 RID: 18051 RVA: 0x0002E7D4 File Offset: 0x0002C9D4
		// (set) Token: 0x06004684 RID: 18052 RVA: 0x0002E7DC File Offset: 0x0002C9DC
		public QuestCategory mCategory { get; set; }

		// Token: 0x1700067A RID: 1658
		// (get) Token: 0x06004685 RID: 18053 RVA: 0x0002E7E5 File Offset: 0x0002C9E5
		// (set) Token: 0x06004686 RID: 18054 RVA: 0x0002E7ED File Offset: 0x0002C9ED
		public string mTitle { get; set; }

		// Token: 0x1700067B RID: 1659
		// (get) Token: 0x06004687 RID: 18055 RVA: 0x0002E7F6 File Offset: 0x0002C9F6
		// (set) Token: 0x06004688 RID: 18056 RVA: 0x0002E7FE File Offset: 0x0002C9FE
		public string mDescription { get; set; }

		// Token: 0x1700067C RID: 1660
		// (get) Token: 0x06004689 RID: 18057 RVA: 0x0002E807 File Offset: 0x0002CA07
		// (set) Token: 0x0600468A RID: 18058 RVA: 0x0002E80F File Offset: 0x0002CA0F
		[XmlArrayItem("m_text", IsNullable = false)]
		public string[] mAvailableDialog { get; set; }

		// Token: 0x1700067D RID: 1661
		// (get) Token: 0x0600468B RID: 18059 RVA: 0x0002E818 File Offset: 0x0002CA18
		// (set) Token: 0x0600468C RID: 18060 RVA: 0x0002E820 File Offset: 0x0002CA20
		[XmlArrayItem("m_text", IsNullable = false)]
		public string[] mInProgressDialog { get; set; }

		// Token: 0x1700067E RID: 1662
		// (get) Token: 0x0600468D RID: 18061 RVA: 0x0002E829 File Offset: 0x0002CA29
		// (set) Token: 0x0600468E RID: 18062 RVA: 0x0002E831 File Offset: 0x0002CA31
		[XmlArrayItem("m_text", IsNullable = false)]
		public string[] mCompletedDialog { get; set; }

		// Token: 0x1700067F RID: 1663
		// (get) Token: 0x0600468F RID: 18063 RVA: 0x0002E83A File Offset: 0x0002CA3A
		// (set) Token: 0x06004690 RID: 18064 RVA: 0x0002E842 File Offset: 0x0002CA42
		public int mRequiredDifficulty { get; set; }

		// Token: 0x17000680 RID: 1664
		// (get) Token: 0x06004691 RID: 18065 RVA: 0x0002E84B File Offset: 0x0002CA4B
		// (set) Token: 0x06004692 RID: 18066 RVA: 0x0002E853 File Offset: 0x0002CA53
		public sbyte mRequiredLevel { get; set; }

		// Token: 0x17000681 RID: 1665
		// (get) Token: 0x06004693 RID: 18067 RVA: 0x0002E85C File Offset: 0x0002CA5C
		// (set) Token: 0x06004694 RID: 18068 RVA: 0x0002E864 File Offset: 0x0002CA64
		public sbyte mHighestLevel { get; set; }

		// Token: 0x17000682 RID: 1666
		// (get) Token: 0x06004695 RID: 18069 RVA: 0x0002E86D File Offset: 0x0002CA6D
		// (set) Token: 0x06004696 RID: 18070 RVA: 0x0002E875 File Offset: 0x0002CA75
		public sbyte mUnlockLevel { get; set; }

		// Token: 0x17000683 RID: 1667
		// (get) Token: 0x06004697 RID: 18071 RVA: 0x0002E87E File Offset: 0x0002CA7E
		// (set) Token: 0x06004698 RID: 18072 RVA: 0x0002E886 File Offset: 0x0002CA86
		[DefaultValue(typeof(sbyte), "1")]
		public sbyte mRecommendedlevel { get; set; }

		// Token: 0x17000684 RID: 1668
		// (get) Token: 0x06004699 RID: 18073 RVA: 0x0002E88F File Offset: 0x0002CA8F
		// (set) Token: 0x0600469A RID: 18074 RVA: 0x0002E897 File Offset: 0x0002CA97
		[XmlArrayItem("mReward", IsNullable = false)]
		public QuestReward[] mRewards { get; set; }

		// Token: 0x17000685 RID: 1669
		// (get) Token: 0x0600469B RID: 18075 RVA: 0x0002E8A0 File Offset: 0x0002CAA0
		// (set) Token: 0x0600469C RID: 18076 RVA: 0x0002E8A8 File Offset: 0x0002CAA8
		[DefaultValue(0)]
		public int mOptionalRewardsCount { get; set; }

		// Token: 0x17000686 RID: 1670
		// (get) Token: 0x0600469D RID: 18077 RVA: 0x0002E8B1 File Offset: 0x0002CAB1
		// (set) Token: 0x0600469E RID: 18078 RVA: 0x0002E8B9 File Offset: 0x0002CAB9
		[XmlArrayItem("mReward", IsNullable = false)]
		public QuestReward[] mOptionalRewardList { get; set; }

		// Token: 0x17000687 RID: 1671
		// (get) Token: 0x0600469F RID: 18079 RVA: 0x0002E8C2 File Offset: 0x0002CAC2
		// (set) Token: 0x060046A0 RID: 18080 RVA: 0x0002E8CA File Offset: 0x0002CACA
		[XmlArrayItem("mTask", IsNullable = false)]
		public QuestTask[] mTasks { get; set; }

		// Token: 0x04003214 RID: 12820
		private QuestReward[] mRewardsField;

		// Token: 0x04003215 RID: 12821
		private QuestReward[] mOptionalRewardListField;

		// Token: 0x04003216 RID: 12822
		private QuestTask[] mTasksField;
	}
}
