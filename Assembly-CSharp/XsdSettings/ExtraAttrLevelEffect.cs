using System;

namespace XsdSettings
{
	// Token: 0x020009B9 RID: 2489
	public class ExtraAttrLevelEffect
	{
		// Token: 0x170005DB RID: 1499
		// (get) Token: 0x06004507 RID: 17671 RVA: 0x0002DB22 File Offset: 0x0002BD22
		// (set) Token: 0x06004508 RID: 17672 RVA: 0x0002DB2A File Offset: 0x0002BD2A
		public int m_minLevel { get; set; }

		// Token: 0x170005DC RID: 1500
		// (get) Token: 0x06004509 RID: 17673 RVA: 0x0002DB33 File Offset: 0x0002BD33
		// (set) Token: 0x0600450A RID: 17674 RVA: 0x0002DB3B File Offset: 0x0002BD3B
		public int m_maxLevel { get; set; }

		// Token: 0x170005DD RID: 1501
		// (get) Token: 0x0600450B RID: 17675 RVA: 0x0002DB44 File Offset: 0x0002BD44
		// (set) Token: 0x0600450C RID: 17676 RVA: 0x0002DB4C File Offset: 0x0002BD4C
		public EffectType m_effectType { get; set; }

		// Token: 0x170005DE RID: 1502
		// (get) Token: 0x0600450D RID: 17677 RVA: 0x0002DB55 File Offset: 0x0002BD55
		// (set) Token: 0x0600450E RID: 17678 RVA: 0x0002DB5D File Offset: 0x0002BD5D
		public int m_probability { get; set; }

		// Token: 0x170005DF RID: 1503
		// (get) Token: 0x0600450F RID: 17679 RVA: 0x0002DB66 File Offset: 0x0002BD66
		// (set) Token: 0x06004510 RID: 17680 RVA: 0x0002DB6E File Offset: 0x0002BD6E
		public ItemRarity m_rarity { get; set; }

		// Token: 0x040030E6 RID: 12518
		private EffectType m_effectTypeField;

		// Token: 0x040030E7 RID: 12519
		private ItemRarity m_rarityField;
	}
}
