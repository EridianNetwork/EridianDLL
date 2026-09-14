using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000AE1 RID: 2785
[Serializable]
public class MB_MultiMaterial
{
	// Token: 0x040036FB RID: 14075
	public Material combinedMaterial;

	// Token: 0x040036FC RID: 14076
	public List<Material> sourceMaterials = new List<Material>();
}
