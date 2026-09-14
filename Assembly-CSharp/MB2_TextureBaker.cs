using System;
using System.Collections.Generic;
using Core;
using DigitalOpus.MB.Core;
using UnityEngine;

// Token: 0x02000AE3 RID: 2787
public class MB2_TextureBaker : MB2_MeshBakerRoot
{
	// Token: 0x06004B9C RID: 19356 RVA: 0x0003157E File Offset: 0x0002F77E
	public override List<GameObject> vmethod_0()
	{
		return this.objsToMesh;
	}

	// Token: 0x06004B9D RID: 19357 RVA: 0x00139C4C File Offset: 0x00137E4C
	public MB_AtlasesAndRects[] method_0(ProgressUpdateDelegate progressUpdateDelegate_0, bool bool_0 = false, MB_TextureCombiner.FileSaveFunction fileSaveFunction_0 = null)
	{
		if (this.doMultiMaterial)
		{
			for (int i = 0; i < this.resultMaterials.Length; i++)
			{
				MB_MultiMaterial mb_MultiMaterial = this.resultMaterials[i];
				if (mb_MultiMaterial.combinedMaterial == null)
				{
					DebugUtils.LogError(LogCategory.Default, "Combined Material is null please create and assign a result material.");
					return null;
				}
				Shader shader = mb_MultiMaterial.combinedMaterial.shader;
				for (int j = 0; j < mb_MultiMaterial.sourceMaterials.Count; j++)
				{
					if (mb_MultiMaterial.sourceMaterials[j] == null)
					{
						DebugUtils.LogError(LogCategory.Default, "There are null entries in the list of Source Materials");
						return null;
					}
					if (shader != mb_MultiMaterial.sourceMaterials[j].shader)
					{
						DebugUtils.LogWarning(LogCategory.Default, string.Concat(new object[]
						{
							"Source material ",
							mb_MultiMaterial.sourceMaterials[j],
							" does not use shader ",
							shader,
							" it may not have the required textures. If not empty textures will be generated."
						}));
					}
				}
			}
		}
		else
		{
			if (this.resultMaterial == null)
			{
				DebugUtils.LogError(LogCategory.Default, "Combined Material is null please create and assign a result material.");
				return null;
			}
			Shader shader2 = this.resultMaterial.shader;
			for (int k = 0; k < this.objsToMesh.Count; k++)
			{
				foreach (Material material in MB_Utility.GetGOMaterials(this.objsToMesh[k]))
				{
					if (material == null)
					{
						DebugUtils.LogError(LogCategory.Default, "Game object " + this.objsToMesh[k] + " has a null material. Can't build atlases");
						return null;
					}
					if (material.shader != shader2)
					{
						DebugUtils.LogWarning(LogCategory.Default, string.Concat(new object[]
						{
							"Game object ",
							this.objsToMesh[k],
							" does not use shader ",
							shader2,
							" it may not have the required textures. If not empty textures will be generated."
						}));
					}
				}
			}
		}
		int num = 1;
		if (this.doMultiMaterial)
		{
			num = this.resultMaterials.Length;
		}
		MB_AtlasesAndRects[] array = new MB_AtlasesAndRects[num];
		for (int m = 0; m < array.Length; m++)
		{
			array[m] = new MB_AtlasesAndRects();
		}
		MB_TextureCombiner mb_TextureCombiner = new MB_TextureCombiner();
		List<Material> list = null;
		for (int n = 0; n < array.Length; n++)
		{
			Material combinedMaterial;
			if (this.doMultiMaterial)
			{
				list = this.resultMaterials[n].sourceMaterials;
				combinedMaterial = this.resultMaterials[n].combinedMaterial;
			}
			else
			{
				combinedMaterial = this.resultMaterial;
			}
			DebugUtils.Log(LogCategory.Default, "Creating atlases for result material " + combinedMaterial);
			if (!mb_TextureCombiner.combineTexturesIntoAtlases(progressUpdateDelegate_0, array[n], combinedMaterial, this.objsToMesh, list, this.atlasPadding, this.customShaderPropNames, this.resizePowerOfTwoTextures, this.fixOutOfBoundsUVs, this.maxTilingBakeSize, bool_0, this.texturePackingAlgorithm, fileSaveFunction_0))
			{
				return null;
			}
		}
		if (array != null)
		{
			this.textureBakeResults.combinedMaterialInfo = array;
			this.textureBakeResults.doMultiMaterial = this.doMultiMaterial;
			this.textureBakeResults.resultMaterial = this.resultMaterial;
			this.textureBakeResults.resultMaterials = this.resultMaterials;
			this.textureBakeResults.fixOutOfBoundsUVs = this.fixOutOfBoundsUVs;
			this.method_2(this.textureBakeResults);
			if (Application.isPlaying)
			{
				if (this.doMultiMaterial)
				{
					for (int num2 = 0; num2 < this.resultMaterials.Length; num2++)
					{
						Material combinedMaterial2 = this.resultMaterials[num2].combinedMaterial;
						Texture2D[] atlases = array[num2].atlases;
						for (int num3 = 0; num3 < atlases.Length; num3++)
						{
							combinedMaterial2.SetTexture(array[num2].texPropertyNames[num3], atlases[num3]);
						}
					}
				}
				else
				{
					Material material2 = this.resultMaterial;
					Texture2D[] atlases2 = array[0].atlases;
					for (int num4 = 0; num4 < atlases2.Length; num4++)
					{
						material2.SetTexture(array[0].texPropertyNames[num4], atlases2[num4]);
					}
				}
			}
		}
		if (MB2_TextureBaker.VERBOSE)
		{
			DebugUtils.Log(LogCategory.Default, "Created Atlases");
		}
		return array;
	}

	// Token: 0x06004B9E RID: 19358 RVA: 0x00031586 File Offset: 0x0002F786
	public MB_AtlasesAndRects[] method_1()
	{
		return this.method_0(null, false, null);
	}

	// Token: 0x06004B9F RID: 19359 RVA: 0x0013A050 File Offset: 0x00138250
	private void method_2(MB2_TextureBakeResults mb2_TextureBakeResults_0)
	{
		List<Material> list = new List<Material>();
		List<Rect> list2 = new List<Rect>();
		for (int i = 0; i < mb2_TextureBakeResults_0.combinedMaterialInfo.Length; i++)
		{
			MB_AtlasesAndRects mb_AtlasesAndRects = mb2_TextureBakeResults_0.combinedMaterialInfo[i];
			Dictionary<Material, Rect> mat2rect_map = mb_AtlasesAndRects.mat2rect_map;
			foreach (Material material in mat2rect_map.Keys)
			{
				list.Add(material);
				list2.Add(mat2rect_map[material]);
			}
		}
		mb2_TextureBakeResults_0.materials = list.ToArray();
		mb2_TextureBakeResults_0.prefabUVRects = list2.ToArray();
	}

	// Token: 0x06004BA0 RID: 19360 RVA: 0x0013A100 File Offset: 0x00138300
	public void method_3(ProgressUpdateDelegate progressUpdateDelegate_0, MB_TextureCombiner.FileSaveFunction fileSaveFunction_0)
	{
		MB_AtlasesAndRects[] array = null;
		try
		{
			if (MB2_MeshBakerRoot.smethod_0(this, MB_ObjsToCombineTypes.dontCare))
			{
				array = this.method_0(progressUpdateDelegate_0, true, fileSaveFunction_0);
				if (array != null)
				{
					MB2_MeshBakerCommon component = base.GetComponent<MB2_MeshBakerCommon>();
					if (component != null)
					{
						component.textureBakeResults = this.textureBakeResults;
					}
				}
			}
		}
		catch (Exception ex)
		{
			global::UnityEngine.Debug.LogError(ex);
		}
		finally
		{
			if (array != null)
			{
				foreach (MB_AtlasesAndRects mb_AtlasesAndRects in array)
				{
					if (mb_AtlasesAndRects != null && mb_AtlasesAndRects.atlases != null)
					{
						for (int j = 0; j < mb_AtlasesAndRects.atlases.Length; j++)
						{
							if (mb_AtlasesAndRects.atlases[j] != null)
							{
								MB_Utility.Destroy(mb_AtlasesAndRects.atlases[j]);
							}
						}
					}
				}
			}
		}
	}

	// Token: 0x06004BA1 RID: 19361 RVA: 0x0013A1C8 File Offset: 0x001383C8
	public static void smethod_2(Material material_0, Material material_1)
	{
		material_0.shader = material_1.shader;
		material_0.CopyPropertiesFromMaterial(material_1);
		string[] shaderTexPropertyNames = MB_TextureCombiner.shaderTexPropertyNames;
		for (int i = 0; i < shaderTexPropertyNames.Length; i++)
		{
			Vector2 one = Vector2.one;
			Vector2 zero = Vector2.zero;
			if (material_0.HasProperty(shaderTexPropertyNames[i]))
			{
				material_0.SetTextureOffset(shaderTexPropertyNames[i], zero);
				material_0.SetTextureScale(shaderTexPropertyNames[i], one);
			}
		}
	}

	// Token: 0x04003704 RID: 14084
	private static bool VERBOSE;

	// Token: 0x04003705 RID: 14085
	[HideInInspector]
	public int maxTilingBakeSize = 1024;

	// Token: 0x04003706 RID: 14086
	[HideInInspector]
	public bool doMultiMaterial;

	// Token: 0x04003707 RID: 14087
	[HideInInspector]
	public bool fixOutOfBoundsUVs;

	// Token: 0x04003708 RID: 14088
	[HideInInspector]
	public Material resultMaterial;

	// Token: 0x04003709 RID: 14089
	public MB_MultiMaterial[] resultMaterials = new MB_MultiMaterial[0];

	// Token: 0x0400370A RID: 14090
	[HideInInspector]
	public int atlasPadding = 1;

	// Token: 0x0400370B RID: 14091
	[HideInInspector]
	public bool resizePowerOfTwoTextures = true;

	// Token: 0x0400370C RID: 14092
	[HideInInspector]
	public MB2_PackingAlgorithmEnum texturePackingAlgorithm;

	// Token: 0x0400370D RID: 14093
	public List<string> customShaderPropNames = new List<string>();

	// Token: 0x0400370E RID: 14094
	public List<GameObject> objsToMesh;
}
