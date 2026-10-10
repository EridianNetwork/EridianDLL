using System;
using System.Collections;
using System.Collections.Generic;

// Token: 0x020003DB RID: 987
public class Shop
{
	// Token: 0x060018D1 RID: 6353 RVA: 0x00082CF0 File Offset: 0x00080EF0
	public Shop(Hashtable hashtable_0)
	{
		this.Id = (int)hashtable_0[0];
		Hashtable hashtable = (Hashtable)hashtable_0[1];
		this.LastGenerated = (int)hashtable_0[2];
		this.RefreshTime = (int)hashtable_0[3];
		this.SellRatio = (double)hashtable_0[4];
		foreach (object obj in hashtable)
		{
			DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
			this.mInventory[(int)dictionaryEntry.Key] = new ShopItem((Hashtable)dictionaryEntry.Value);
		}
	}

	public Shop(int id, int refreshTime, double sellRatio)
	{
		this.Id = id;
		this.RefreshTime = refreshTime;
		this.SellRatio = sellRatio;
		this.LastGenerated = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
	}

	public void SetInventory(Dictionary<int, ShopItem> items)
	{
		this.mInventory = items ?? new Dictionary<int, ShopItem>();
	}

	// Token: 0x17000148 RID: 328
	// (get) Token: 0x060018D2 RID: 6354 RVA: 0x00012967 File Offset: 0x00010B67
	// (set) Token: 0x060018D3 RID: 6355 RVA: 0x0001296F File Offset: 0x00010B6F
	public int Id { get; set; }

	// Token: 0x17000149 RID: 329
	// (get) Token: 0x060018D4 RID: 6356 RVA: 0x00012978 File Offset: 0x00010B78
	public Dictionary<int, ShopItem> Dictionary_0
	{
		get
		{
			return this.mInventory;
		}
	}

	// Token: 0x1700014A RID: 330
	// (get) Token: 0x060018D5 RID: 6357 RVA: 0x00012980 File Offset: 0x00010B80
	// (set) Token: 0x060018D6 RID: 6358 RVA: 0x00012988 File Offset: 0x00010B88
	public int LastGenerated { get; set; }

	// Token: 0x1700014B RID: 331
	// (get) Token: 0x060018D7 RID: 6359 RVA: 0x00012991 File Offset: 0x00010B91
	// (set) Token: 0x060018D8 RID: 6360 RVA: 0x00012999 File Offset: 0x00010B99
	public int RefreshTime { get; set; }

	// Token: 0x1700014C RID: 332
	// (get) Token: 0x060018D9 RID: 6361 RVA: 0x000129A2 File Offset: 0x00010BA2
	// (set) Token: 0x060018DA RID: 6362 RVA: 0x000129AA File Offset: 0x00010BAA
	public double SellRatio { get; set; }

	// Token: 0x1700014D RID: 333
	// (get) Token: 0x060018DB RID: 6363 RVA: 0x00082DE8 File Offset: 0x00080FE8
	public int Int32_0
	{
		get
		{
			return this.LastGenerated + this.RefreshTime - (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
		}
	}

	// Token: 0x040010E6 RID: 4326
	private Dictionary<int, ShopItem> mInventory = new Dictionary<int, ShopItem>();
}
