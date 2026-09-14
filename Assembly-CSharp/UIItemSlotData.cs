using System;

// Token: 0x02000712 RID: 1810
public class UIItemSlotData
{
	// Token: 0x06003007 RID: 12295 RVA: 0x0001F762 File Offset: 0x0001D962
	public UIItemSlotData(ItemDNA itemDNA_0, string string_0, int int_0, bool bool_0 = false)
	{
		this.item = itemDNA_0;
		this.identifier = string_0;
		this.index = int_0;
		this.isNew = bool_0;
	}

	// Token: 0x0400215F RID: 8543
	public ItemDNA item;

	// Token: 0x04002160 RID: 8544
	public string identifier;

	// Token: 0x04002161 RID: 8545
	public int index;

	// Token: 0x04002162 RID: 8546
	public bool isNew;
}
