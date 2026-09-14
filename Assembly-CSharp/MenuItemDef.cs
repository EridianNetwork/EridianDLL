using System;

// Token: 0x02000741 RID: 1857
public struct MenuItemDef
{
	// Token: 0x0600310A RID: 12554 RVA: 0x0001FE9A File Offset: 0x0001E09A
	public MenuItemDef(string string_0, object object_0, MenuItemProcessFunc menuItemProcessFunc_0)
	{
		this.itemTitle = string_0;
		this.itemData = object_0;
		this.itemFunc = menuItemProcessFunc_0;
	}

	// Token: 0x04002205 RID: 8709
	public string itemTitle;

	// Token: 0x04002206 RID: 8710
	public object itemData;

	// Token: 0x04002207 RID: 8711
	public MenuItemProcessFunc itemFunc;
}
