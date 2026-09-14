using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020007C7 RID: 1991
public class ItemTipsData
{
	// Token: 0x040024D6 RID: 9430
	public Color nameColor = Color.white;

	// Token: 0x040024D7 RID: 9431
	public string name = string.Empty;

	// Token: 0x040024D8 RID: 9432
	public ItemDNA item;

	// Token: 0x040024D9 RID: 9433
	public Color levelColor = Color.white;

	// Token: 0x040024DA RID: 9434
	public int level = 1;

	// Token: 0x040024DB RID: 9435
	public string brand = "none";

	// Token: 0x040024DC RID: 9436
	public bool bEquiped;

	// Token: 0x040024DD RID: 9437
	public int price = -1;

	// Token: 0x040024DE RID: 9438
	public List<ItemElement> attributeList = new List<ItemElement>();

	// Token: 0x040024DF RID: 9439
	public List<ItemElement> additionAttList = new List<ItemElement>();
}
