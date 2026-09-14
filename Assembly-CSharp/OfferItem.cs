using System;
using System.Collections;

// Token: 0x020003DE RID: 990
public class OfferItem
{
	// Token: 0x060018E5 RID: 6373 RVA: 0x00003197 File Offset: 0x00001397
	public OfferItem()
	{
	}

	// Token: 0x060018E6 RID: 6374 RVA: 0x00082E88 File Offset: 0x00081088
	public OfferItem(Hashtable hashtable_0)
	{
		this.OfferId = (int)hashtable_0[0];
		this.ItemId = (string)hashtable_0[1];
		this.ItemName = (string)hashtable_0[2];
		this.Amount = (int)hashtable_0[3];
		this.AdjustAmount = (bool)hashtable_0[4];
		this.Duration = (int)hashtable_0[5];
		this.Tag = (string)hashtable_0[6];
		this.Price = (int)hashtable_0[7];
		this.CurrencyType = (int)hashtable_0[8];
		this.NotForSale = (bool)hashtable_0[9];
		this.Hidden = (bool)hashtable_0[10];
	}

	// Token: 0x040010F0 RID: 4336
	public int OfferId;

	// Token: 0x040010F1 RID: 4337
	public string ItemId;

	// Token: 0x040010F2 RID: 4338
	public string ItemName;

	// Token: 0x040010F3 RID: 4339
	public int Amount;

	// Token: 0x040010F4 RID: 4340
	public bool AdjustAmount;

	// Token: 0x040010F5 RID: 4341
	public int Duration;

	// Token: 0x040010F6 RID: 4342
	public string Tag;

	// Token: 0x040010F7 RID: 4343
	public int Price;

	// Token: 0x040010F8 RID: 4344
	public int CurrencyType;

	// Token: 0x040010F9 RID: 4345
	public bool NotForSale;

	// Token: 0x040010FA RID: 4346
	public bool Hidden;
}
