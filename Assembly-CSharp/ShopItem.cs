using System;
using System.Collections;

// Token: 0x020003DC RID: 988
public class ShopItem
{
	// Token: 0x060018DC RID: 6364 RVA: 0x00003197 File Offset: 0x00001397
	public ShopItem()
	{
	}

	// Token: 0x060018DD RID: 6365 RVA: 0x00082E2C File Offset: 0x0008102C
	public ShopItem(Hashtable hashtable_0)
	{
		this.Item = ItemDNA.smethod_12(hashtable_0);
		this.Price = (int)hashtable_0[hashtable_0.Count - 2];
		this.Quantity = (int)hashtable_0[hashtable_0.Count - 1];
	}

	// Token: 0x1700014E RID: 334
	// (get) Token: 0x060018DE RID: 6366 RVA: 0x000129B3 File Offset: 0x00010BB3
	// (set) Token: 0x060018DF RID: 6367 RVA: 0x000129BB File Offset: 0x00010BBB
	public ItemDNA Item { get; set; }

	// Token: 0x1700014F RID: 335
	// (get) Token: 0x060018E0 RID: 6368 RVA: 0x000129C4 File Offset: 0x00010BC4
	// (set) Token: 0x060018E1 RID: 6369 RVA: 0x000129CC File Offset: 0x00010BCC
	public int Price { get; set; }

	// Token: 0x17000150 RID: 336
	// (get) Token: 0x060018E2 RID: 6370 RVA: 0x000129D5 File Offset: 0x00010BD5
	// (set) Token: 0x060018E3 RID: 6371 RVA: 0x000129DD File Offset: 0x00010BDD
	public int Quantity { get; set; }
}
