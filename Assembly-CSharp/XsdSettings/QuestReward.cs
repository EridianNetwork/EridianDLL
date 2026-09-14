using System;
using System.ComponentModel;

namespace XsdSettings
{
	// Token: 0x02000A02 RID: 2562
	public class QuestReward
	{
		// Token: 0x060046A1 RID: 18081 RVA: 0x0002E8D3 File Offset: 0x0002CAD3
		public QuestReward()
		{
			this.mType = QuestRewardType.Item;
			this.mRewardID = 0;
			this.mMaterialType = MaterialType.MT_Titanium;
			this.mLuckyBoxRankType = LuckyBoxRank.None;
			this.mCount = 1;
		}

		// Token: 0x17000688 RID: 1672
		// (get) Token: 0x060046A2 RID: 18082 RVA: 0x0002E8FE File Offset: 0x0002CAFE
		// (set) Token: 0x060046A3 RID: 18083 RVA: 0x0002E906 File Offset: 0x0002CB06
		public QuestRewardType mType { get; set; }

		// Token: 0x17000689 RID: 1673
		// (get) Token: 0x060046A4 RID: 18084 RVA: 0x0002E90F File Offset: 0x0002CB0F
		// (set) Token: 0x060046A5 RID: 18085 RVA: 0x0002E917 File Offset: 0x0002CB17
		[DefaultValue(0)]
		public int mRewardID { get; set; }

		// Token: 0x1700068A RID: 1674
		// (get) Token: 0x060046A6 RID: 18086 RVA: 0x0002E920 File Offset: 0x0002CB20
		// (set) Token: 0x060046A7 RID: 18087 RVA: 0x0002E928 File Offset: 0x0002CB28
		[DefaultValue(MaterialType.MT_Titanium)]
		public MaterialType mMaterialType { get; set; }

		// Token: 0x1700068B RID: 1675
		// (get) Token: 0x060046A8 RID: 18088 RVA: 0x0002E931 File Offset: 0x0002CB31
		// (set) Token: 0x060046A9 RID: 18089 RVA: 0x0002E939 File Offset: 0x0002CB39
		[DefaultValue(LuckyBoxRank.None)]
		public LuckyBoxRank mLuckyBoxRankType { get; set; }

		// Token: 0x1700068C RID: 1676
		// (get) Token: 0x060046AA RID: 18090 RVA: 0x0002E942 File Offset: 0x0002CB42
		// (set) Token: 0x060046AB RID: 18091 RVA: 0x0002E94A File Offset: 0x0002CB4A
		[DefaultValue(1)]
		public int mCount { get; set; }
	}
}
