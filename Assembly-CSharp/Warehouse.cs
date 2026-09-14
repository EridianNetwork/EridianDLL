using System;
using System.Collections;
using System.Collections.Generic;

// Token: 0x020003E9 RID: 1001
public class Warehouse
{
	// Token: 0x0600191F RID: 6431 RVA: 0x00012CC5 File Offset: 0x00010EC5
	public Warehouse()
	{
	}

	// Token: 0x06001920 RID: 6432 RVA: 0x00083C10 File Offset: 0x00081E10
	public Warehouse(Hashtable hashtable_0)
	{
		this.mAccountId = (int)hashtable_0[0];
		this.mMaxSlots = (int)hashtable_0[1];
		Hashtable hashtable = (Hashtable)hashtable_0[2];
		foreach (object obj in hashtable)
		{
			DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
			int num = (int)dictionaryEntry.Key;
			Hashtable hashtable2 = (Hashtable)dictionaryEntry.Value;
			if (hashtable2 != null)
			{
				this.mItems[num] = new InventoryItem(hashtable2);
			}
		}
	}

	// Token: 0x06001921 RID: 6433 RVA: 0x00083CF0 File Offset: 0x00081EF0
	public Hashtable method_0()
	{
		Hashtable hashtable = new Hashtable();
		foreach (KeyValuePair<int, InventoryItem> keyValuePair in this.mItems)
		{
			if (keyValuePair.Value != null)
			{
				Hashtable hashtable2 = keyValuePair.Value.mItem.method_10();
				hashtable[keyValuePair.Key] = hashtable2;
			}
		}
		return new Hashtable
		{
			{ 0, this.mAccountId },
			{ 1, this.mMaxSlots },
			{ 2, hashtable }
		};
	}

	// Token: 0x06001922 RID: 6434 RVA: 0x00083DB8 File Offset: 0x00081FB8
	public ItemDNA[] method_1()
	{
		ItemDNA[] array = new ItemDNA[this.mMaxSlots];
		foreach (KeyValuePair<int, InventoryItem> keyValuePair in this.mItems)
		{
			if (keyValuePair.Key < array.Length)
			{
				array[keyValuePair.Key] = keyValuePair.Value.mItem;
			}
		}
		return array;
	}

	// Token: 0x0400111C RID: 4380
	private Dictionary<int, InventoryItem> mItems = new Dictionary<int, InventoryItem>();

	// Token: 0x0400111D RID: 4381
	private int mAccountId;

	// Token: 0x0400111E RID: 4382
	private int mMaxSlots = 60;
}
