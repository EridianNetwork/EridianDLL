using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000AE0 RID: 2784
[Serializable]
public class MB_AtlasesAndRects
{
	// Token: 0x040036F8 RID: 14072
	public Texture2D[] atlases;

	// Token: 0x040036F9 RID: 14073
	public Dictionary<Material, Rect> mat2rect_map;

	// Token: 0x040036FA RID: 14074
	public string[] texPropertyNames;
}
