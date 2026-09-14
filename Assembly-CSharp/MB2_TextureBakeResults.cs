using System;
using System.Collections.Generic;
using System.Text;
using Core;
using UnityEngine;

// Token: 0x02000AE2 RID: 2786
public class MB2_TextureBakeResults : ScriptableObject
{
	// Token: 0x06004B99 RID: 19353 RVA: 0x00139AD4 File Offset: 0x00137CD4
	public Dictionary<Material, Rect> method_0()
	{
		Dictionary<Material, Rect> dictionary = new Dictionary<Material, Rect>();
		if (this.materials != null && this.prefabUVRects != null)
		{
			if (this.materials.Length == this.prefabUVRects.Length)
			{
				for (int i = 0; i < this.materials.Length; i++)
				{
					dictionary.Add(this.materials[i], this.prefabUVRects[i]);
				}
				return dictionary;
			}
		}
		DebugUtils.LogWarning(LogCategory.Default, "Bad TextureBakeResults could not build mat2UVRect map");
		return dictionary;
	}

	// Token: 0x06004B9A RID: 19354 RVA: 0x00139B4C File Offset: 0x00137D4C
	public string method_1()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Shaders:\n");
		HashSet<Shader> hashSet = new HashSet<Shader>();
		if (this.materials != null)
		{
			for (int i = 0; i < this.materials.Length; i++)
			{
				hashSet.Add(this.materials[i].shader);
			}
		}
		foreach (Shader shader in hashSet)
		{
			stringBuilder.Append("  ").Append(shader.name).AppendLine();
		}
		stringBuilder.Append("Materials:\n");
		if (this.materials != null)
		{
			for (int j = 0; j < this.materials.Length; j++)
			{
				stringBuilder.Append("  ").Append(this.materials[j].name).AppendLine();
			}
		}
		return stringBuilder.ToString();
	}

	// Token: 0x040036FD RID: 14077
	public MB_AtlasesAndRects[] combinedMaterialInfo;

	// Token: 0x040036FE RID: 14078
	public Material[] materials;

	// Token: 0x040036FF RID: 14079
	public Rect[] prefabUVRects;

	// Token: 0x04003700 RID: 14080
	public Material resultMaterial;

	// Token: 0x04003701 RID: 14081
	public MB_MultiMaterial[] resultMaterials;

	// Token: 0x04003702 RID: 14082
	public bool doMultiMaterial;

	// Token: 0x04003703 RID: 14083
	public bool fixOutOfBoundsUVs;
}
