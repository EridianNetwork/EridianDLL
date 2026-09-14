using System;
using UnityEngine;

// Token: 0x02000774 RID: 1908
public class FontRect
{
	// Token: 0x06003297 RID: 12951 RVA: 0x000E7B00 File Offset: 0x000E5D00
	public FontRect(Rect rect_0)
	{
		this.rect = rect_0;
		this.upRect = (this.leftRect = null);
	}

	// Token: 0x0400230B RID: 8971
	public Rect rect;

	// Token: 0x0400230C RID: 8972
	public FontRect upRect;

	// Token: 0x0400230D RID: 8973
	public FontRect leftRect;

	// Token: 0x0400230E RID: 8974
	public bool downAlloc;

	// Token: 0x0400230F RID: 8975
	public bool rightAlloc;
}
