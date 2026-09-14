using System;

// Token: 0x020005F3 RID: 1523
public class ItemInstance
{
	// Token: 0x060026B9 RID: 9913 RVA: 0x0001A07E File Offset: 0x0001827E
	public ItemInstance(string string_0, int int_0 = 0)
	{
		this.m_id = string_0;
		this.m_exp = int_0;
	}

	// Token: 0x170001E9 RID: 489
	// (get) Token: 0x060026BA RID: 9914 RVA: 0x0001A094 File Offset: 0x00018294
	// (set) Token: 0x060026BB RID: 9915 RVA: 0x0001A09C File Offset: 0x0001829C
	public string m_id { get; private set; }

	// Token: 0x060026BC RID: 9916 RVA: 0x0001A0A5 File Offset: 0x000182A5
	public override string ToString()
	{
		return this.m_id;
	}

	// Token: 0x060026BD RID: 9917 RVA: 0x000BB344 File Offset: 0x000B9544
	public override bool Equals(object obj)
	{
		ItemInstance itemInstance = obj as ItemInstance;
		return itemInstance != null && itemInstance.m_id == this.m_id;
	}

	// Token: 0x060026BE RID: 9918 RVA: 0x0001A0AD File Offset: 0x000182AD
	public override int GetHashCode()
	{
		return this.m_id.GetHashCode();
	}

	// Token: 0x04001C2C RID: 7212
	public int m_exp;
}
