using System;
using System.Xml.Serialization;

namespace XsdSettings
{
	// Token: 0x02000996 RID: 2454
	public class InventorySetup
	{
		// Token: 0x06004461 RID: 17505 RVA: 0x0002D61D File Offset: 0x0002B81D
		public InventorySetup()
		{
			this.m_weapon1 = -1;
			this.m_weapon2 = -1;
			this.m_weapon3 = -1;
			this.m_weapon4 = -1;
			this.m_shield = -1;
			this.m_classMod = -1;
			this.m_grenadeMod = -1;
		}

		// Token: 0x17000598 RID: 1432
		// (get) Token: 0x06004462 RID: 17506 RVA: 0x0002D656 File Offset: 0x0002B856
		// (set) Token: 0x06004463 RID: 17507 RVA: 0x0002D65E File Offset: 0x0002B85E
		public int m_startingInventorySlotsCount { get; set; }

		// Token: 0x17000599 RID: 1433
		// (get) Token: 0x06004464 RID: 17508 RVA: 0x0002D667 File Offset: 0x0002B867
		// (set) Token: 0x06004465 RID: 17509 RVA: 0x0002D66F File Offset: 0x0002B86F
		public int m_maxInventorySlotsCount { get; set; }

		// Token: 0x1700059A RID: 1434
		// (get) Token: 0x06004466 RID: 17510 RVA: 0x0002D678 File Offset: 0x0002B878
		// (set) Token: 0x06004467 RID: 17511 RVA: 0x0002D680 File Offset: 0x0002B880
		public int m_weapon1 { get; set; }

		// Token: 0x1700059B RID: 1435
		// (get) Token: 0x06004468 RID: 17512 RVA: 0x0002D689 File Offset: 0x0002B889
		// (set) Token: 0x06004469 RID: 17513 RVA: 0x0002D691 File Offset: 0x0002B891
		public int m_weapon2 { get; set; }

		// Token: 0x1700059C RID: 1436
		// (get) Token: 0x0600446A RID: 17514 RVA: 0x0002D69A File Offset: 0x0002B89A
		// (set) Token: 0x0600446B RID: 17515 RVA: 0x0002D6A2 File Offset: 0x0002B8A2
		public int m_weapon3 { get; set; }

		// Token: 0x1700059D RID: 1437
		// (get) Token: 0x0600446C RID: 17516 RVA: 0x0002D6AB File Offset: 0x0002B8AB
		// (set) Token: 0x0600446D RID: 17517 RVA: 0x0002D6B3 File Offset: 0x0002B8B3
		public int m_weapon4 { get; set; }

		// Token: 0x1700059E RID: 1438
		// (get) Token: 0x0600446E RID: 17518 RVA: 0x0002D6BC File Offset: 0x0002B8BC
		// (set) Token: 0x0600446F RID: 17519 RVA: 0x0002D6C4 File Offset: 0x0002B8C4
		public int m_shield { get; set; }

		// Token: 0x1700059F RID: 1439
		// (get) Token: 0x06004470 RID: 17520 RVA: 0x0002D6CD File Offset: 0x0002B8CD
		// (set) Token: 0x06004471 RID: 17521 RVA: 0x0002D6D5 File Offset: 0x0002B8D5
		public int m_classMod { get; set; }

		// Token: 0x170005A0 RID: 1440
		// (get) Token: 0x06004472 RID: 17522 RVA: 0x0002D6DE File Offset: 0x0002B8DE
		// (set) Token: 0x06004473 RID: 17523 RVA: 0x0002D6E6 File Offset: 0x0002B8E6
		public int m_grenadeMod { get; set; }

		// Token: 0x170005A1 RID: 1441
		// (get) Token: 0x06004474 RID: 17524 RVA: 0x0002D6EF File Offset: 0x0002B8EF
		// (set) Token: 0x06004475 RID: 17525 RVA: 0x0002D6F7 File Offset: 0x0002B8F7
		[XmlArrayItem("m_ammoSetup", IsNullable = false)]
		public AmmoSetup[] m_ammos { get; set; }

		// Token: 0x170005A2 RID: 1442
		// (get) Token: 0x06004476 RID: 17526 RVA: 0x0002D700 File Offset: 0x0002B900
		// (set) Token: 0x06004477 RID: 17527 RVA: 0x0002D708 File Offset: 0x0002B908
		[XmlArrayItem("m_itemSetup", IsNullable = false)]
		public ItemSetup[] m_items { get; set; }

		// Token: 0x04002FEA RID: 12266
		private AmmoSetup[] m_ammosField;

		// Token: 0x04002FEB RID: 12267
		private ItemSetup[] m_itemsField;
	}
}
