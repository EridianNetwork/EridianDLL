using System;
using System.Collections;

// Token: 0x02000396 RID: 918
public class InventoryItem
{
	// Token: 0x0600171C RID: 5916 RVA: 0x00003197 File Offset: 0x00001397
	public InventoryItem()
	{
	}

	// Token: 0x0600171D RID: 5917 RVA: 0x00011190 File Offset: 0x0000F390
	public InventoryItem(Hashtable hashtable_0)
	{
		this.mItem = ItemDNA.smethod_12(hashtable_0);
	}

	// Token: 0x17000133 RID: 307
	// (get) Token: 0x0600171E RID: 5918 RVA: 0x000111A4 File Offset: 0x0000F3A4
	// (set) Token: 0x0600171F RID: 5919 RVA: 0x000111B1 File Offset: 0x0000F3B1
	public int Int32_0
	{
		get
		{
			return this.mItem.m_value;
		}
		set
		{
			this.mItem.m_value = value;
		}
	}

	// Token: 0x04000FC0 RID: 4032
	public ItemDNA mItem;
}
