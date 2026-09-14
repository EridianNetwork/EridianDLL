using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace DigitalOpus.MB.Core
{
	// Token: 0x02000AFA RID: 2810
	public class MB_TextureCombiner
	{
		// Token: 0x06004C43 RID: 19523 RVA: 0x0013EDCC File Offset: 0x0013CFCC
		public bool combineTexturesIntoAtlases(ProgressUpdateDelegate progressInfo, MB_AtlasesAndRects results, Material resultMaterial, List<GameObject> objsToMesh, List<Material> sourceMaterials, int atlasPadding, List<string> customShaderPropNames, bool resizePowerOfTwoTextures, bool fixOutOfBoundsUVs, int maxTilingBakeSize, bool saveAtlasesAsAssets = false, MB2_PackingAlgorithmEnum packingAlgorithm = MB2_PackingAlgorithmEnum.UnitysPackTextures, MB_TextureCombiner.FileSaveFunction fileSaveFunction = null)
		{
			return this._combineTexturesIntoAtlases(progressInfo, results, resultMaterial, objsToMesh, sourceMaterials, atlasPadding, customShaderPropNames, resizePowerOfTwoTextures, fixOutOfBoundsUVs, maxTilingBakeSize, saveAtlasesAsAssets, fileSaveFunction, packingAlgorithm);
		}

		// Token: 0x06004C44 RID: 19524 RVA: 0x0013EDF8 File Offset: 0x0013CFF8
	private bool _collectPropertyNames(Material resultMaterial, List<string> customShaderPropNames, List<string> texPropertyNames)
	{
		for (int i = 0; i < texPropertyNames.Count; i++)
		{
			string text = customShaderPropNames.Find((string x) => x.Equals(texPropertyNames[i]));
			if (text != null)
			{
				customShaderPropNames.Remove(text);
			}
		}
		if (resultMaterial == null)
		{
			UnityEngine.Debug.LogError("Please assign a result material. The combined mesh will use this material.");
			return false;
		}
		string text2 = string.Empty;
		for (int j = 0; j < shaderTexPropertyNames.Length; j++)
		{
			if (resultMaterial.HasProperty(shaderTexPropertyNames[j]))
			{
				text2 = text2 + ", " + shaderTexPropertyNames[j];
				if (!texPropertyNames.Contains(shaderTexPropertyNames[j]))
				{
					texPropertyNames.Add(shaderTexPropertyNames[j]);
				}
				if (resultMaterial.GetTextureOffset(shaderTexPropertyNames[j]) != new Vector2(0f, 0f))
				{
					UnityEngine.Debug.LogWarning("Result material has non-zero offset. This is probably incorrect.");
				}
				if (resultMaterial.GetTextureScale(shaderTexPropertyNames[j]) != new Vector2(1f, 1f))
				{
					UnityEngine.Debug.LogWarning("Result material should probably have tiling of 1,1");
				}
			}
		}
		for (int k = 0; k < customShaderPropNames.Count; k++)
		{
			if (resultMaterial.HasProperty(customShaderPropNames[k]))
			{
				text2 = text2 + ", " + customShaderPropNames[k];
				texPropertyNames.Add(customShaderPropNames[k]);
				if (resultMaterial.GetTextureOffset(customShaderPropNames[k]) != new Vector2(0f, 0f))
				{
					UnityEngine.Debug.LogWarning("Result material has non-zero offset. This is probably incorrect.");
				}
				if (resultMaterial.GetTextureScale(customShaderPropNames[k]) != new Vector2(1f, 1f))
				{
					UnityEngine.Debug.LogWarning("Result material should probably have tiling of 1,1.");
				}
			}
			else
			{
				UnityEngine.Debug.LogWarning("Result material shader does not use property " + customShaderPropNames[k] + " in the list of custom shader property names");
			}
		}
		return true;
	}
		// Token: 0x06004C45 RID: 19525 RVA: 0x0013F020 File Offset: 0x0013D220
		private bool _combineTexturesIntoAtlases(ProgressUpdateDelegate progressInfo, MB_AtlasesAndRects results, Material resultMaterial, List<GameObject> objsToMesh, List<Material> sourceMaterials, int atlasPadding, List<string> customShaderPropNames, bool resizePowerOfTwoTextures, bool fixOutOfBoundsUVs, int maxTilingBakeSize, bool saveAtlasesAsAssets, MB_TextureCombiner.FileSaveFunction fileSaveFunction, MB2_PackingAlgorithmEnum packingAlgorithm)
		{
			bool flag = false;
			try
			{
				this._temporaryTextures.Clear();
				this._texturesWithReadWriteFlagSet.Clear();
				if (objsToMesh == null || objsToMesh.Count == 0)
				{
					global::UnityEngine.Debug.LogError("No meshes to combine. Please assign some meshes to combine.");
					return false;
				}
				if (atlasPadding < 0)
				{
					global::UnityEngine.Debug.LogError("Atlas padding must be zero or greater.");
					return false;
				}
				if (maxTilingBakeSize < 2 || maxTilingBakeSize > 4096)
				{
					global::UnityEngine.Debug.LogError("Invalid value for max tiling bake size.");
					return false;
				}
				if (progressInfo != null)
				{
					progressInfo("Collecting textures for " + objsToMesh.Count + " meshes.", 0.01f);
				}
				List<string> list = new List<string>();
				if (!this._collectPropertyNames(resultMaterial, customShaderPropNames, list))
				{
					return false;
				}
				flag = this.__combineTexturesIntoAtlases(progressInfo, results, resultMaterial, list, objsToMesh, sourceMaterials, atlasPadding, resizePowerOfTwoTextures, fixOutOfBoundsUVs, maxTilingBakeSize, saveAtlasesAsAssets, fileSaveFunction, packingAlgorithm);
			}
			catch (MissingReferenceException ex)
			{
				global::UnityEngine.Debug.LogError("Creating atlases failed a MissingReferenceException was thrown. This is normally only happens when trying to create very large atlases and Unity is running out of Memory. Try changing the 'Texture Packer' to a different option, it may work with an alternate packer. This error is sometimes intermittant. Try baking again.");
				global::UnityEngine.Debug.LogError(ex);
			}
			catch (Exception ex2)
			{
				global::UnityEngine.Debug.LogError(ex2);
			}
			finally
			{
				this._destroyTemporaryTextures();
				this._SetReadFlags(progressInfo);
			}
			return flag;
		}

		// Token: 0x06004C46 RID: 19526 RVA: 0x0013F154 File Offset: 0x0013D354
		private bool __combineTexturesIntoAtlases(ProgressUpdateDelegate progressInfo, MB_AtlasesAndRects results, Material resultMaterial, List<string> texPropertyNames, List<GameObject> objsToMesh, List<Material> sourceMaterials, int atlasPadding, bool resizePowerOfTwoTextures, bool fixOutOfBoundsUVs, int maxTilingBakeSize, bool saveAtlasesAsAssets, MB_TextureCombiner.FileSaveFunction fileSaveFunction, MB2_PackingAlgorithmEnum packingAlgorithm)
		{
			int count = texPropertyNames.Count;
			bool flag = false;
			List<MB_TextureCombiner.MB_TexSet> list = new List<MB_TextureCombiner.MB_TexSet>();
			if (MB_TextureCombiner.VERBOSE)
			{
				global::UnityEngine.Debug.Log(string.Concat(new object[] { "__combineTexturesIntoAtlases atlases:", texPropertyNames.Count, " objsToMesh:", objsToMesh.Count, " fixOutOfBoundsUVs:", fixOutOfBoundsUVs }));
			}
			for (int i = 0; i < objsToMesh.Count; i++)
			{
				GameObject gameObject = objsToMesh[i];
				if (MB_TextureCombiner.VERBOSE)
				{
					global::UnityEngine.Debug.Log("Collecting textures for object " + gameObject);
				}
				if (gameObject == null)
				{
					global::UnityEngine.Debug.LogError("The list of objects to mesh contained nulls.");
					return false;
				}
				Mesh mesh = MB_Utility.GetMesh(gameObject);
				if (mesh == null)
				{
					global::UnityEngine.Debug.LogError("Object " + gameObject.name + " in the list of objects to mesh has no mesh.");
					return false;
				}
				Material[] gomaterials = MB_Utility.GetGOMaterials(gameObject);
				if (gomaterials == null)
				{
					global::UnityEngine.Debug.LogError("Object " + gameObject.name + " in the list of objects has no materials.");
					return false;
				}
				for (int j = 0; j < gomaterials.Length; j++)
				{
					Material material = gomaterials[j];
					if (sourceMaterials == null || sourceMaterials.Contains(material))
					{
						Rect rect = default(Rect);
						bool flag2 = MB_Utility.hasOutOfBoundsUVs(mesh, ref rect, j);
						flag = flag || flag2;
						if (material.name.Contains("(Instance)"))
						{
							global::UnityEngine.Debug.LogError("The sharedMaterial on object " + gameObject.name + " has been 'Instanced'. This was probably caused by a script accessing the meshRender.material property in the editor.  The material to UV Rectangle mapping will be incorrect. To fix this recreate the object from its prefab or re-assign its material from the correct asset.");
							return false;
						}
						if (fixOutOfBoundsUVs && !MB_Utility.validateOBuvsMultiMaterial(gomaterials))
						{
							global::UnityEngine.Debug.LogWarning("Object " + gameObject.name + " uses the same material on multiple submeshes. This may generate strange results especially when used with fix out of bounds uvs. Try duplicating the material.");
						}
						if (progressInfo != null)
						{
							progressInfo("Collecting textures for " + material, 0.01f);
						}
						MB_TextureCombiner.MeshBakerMaterialTexture[] array = new MB_TextureCombiner.MeshBakerMaterialTexture[texPropertyNames.Count];
						for (int k = 0; k < texPropertyNames.Count; k++)
						{
							Texture2D texture2D = null;
							Vector2 vector = Vector2.one;
							Vector2 vector2 = Vector2.zero;
							Vector2 one = Vector2.one;
							Vector2 zero = Vector2.zero;
							if (material.HasProperty(texPropertyNames[k]))
							{
								Texture texture = material.GetTexture(texPropertyNames[k]);
								if (texture != null)
								{
									if (!(texture is Texture2D))
									{
										global::UnityEngine.Debug.LogError("Object " + gameObject.name + " in the list of objects to mesh uses a Texture that is not a Texture2D. Cannot build atlases.");
										return false;
									}
									texture2D = (Texture2D)texture;
									TextureFormat format = texture2D.format;
									if (format != TextureFormat.ARGB32 && format != TextureFormat.RGBA32 && format != TextureFormat.BGRA32 && format != TextureFormat.RGB24 && format != TextureFormat.Alpha8)
									{
										global::UnityEngine.Debug.LogError(string.Concat(new object[] { "Object ", gameObject.name, " in the list of objects to mesh uses Texture ", texture2D.name, " uses format ", format, " that is not in: ARGB32, RGBA32, BGRA32, RGB24, Alpha8 or DXT. These textures cannot be resized at runtime. Try changing texture format. If format says 'compressed' try changing it to 'truecolor'" }));
										return false;
									}
								}
								vector2 = material.GetTextureOffset(texPropertyNames[k]);
								vector = material.GetTextureScale(texPropertyNames[k]);
							}
							if (texture2D == null)
							{
								global::UnityEngine.Debug.LogWarning("No texture selected for " + texPropertyNames[k] + " in object " + objsToMesh[i].name);
							}
							if (fixOutOfBoundsUVs && flag2)
							{
								one = new Vector2(rect.width, rect.height);
								zero = new Vector2(rect.x, rect.y);
							}
							array[k] = new MB_TextureCombiner.MeshBakerMaterialTexture(texture2D, vector2, vector, zero, one);
						}
						MB_TextureCombiner.MB_TexSet setOfTexs = new MB_TextureCombiner.MB_TexSet(array);
						MB_TextureCombiner.MB_TexSet mb_TexSet = list.Find((MB_TextureCombiner.MB_TexSet x) => x.Equals(setOfTexs));
						if (mb_TexSet != null)
						{
							setOfTexs = mb_TexSet;
						}
						else
						{
							list.Add(setOfTexs);
						}
						if (!setOfTexs.mats.Contains(material))
						{
							setOfTexs.mats.Add(material);
						}
					}
				}
			}
			int num = atlasPadding;
			if (list.Count == 1)
			{
				global::UnityEngine.Debug.Log("All objects use the same textures.");
				num = 0;
			}
			for (int l = 0; l < list.Count; l++)
			{
				MB_TextureCombiner.MB_TexSet mb_TexSet2 = list[l];
				mb_TexSet2.idealWidth = 1;
				mb_TexSet2.idealHeight = 1;
				int num2 = 1;
				int num3 = 1;
				for (int m = 0; m < mb_TexSet2.ts.Length; m++)
				{
					MB_TextureCombiner.MeshBakerMaterialTexture meshBakerMaterialTexture = mb_TexSet2.ts[m];
					if (!meshBakerMaterialTexture.scale.Equals(Vector2.one))
					{
						global::UnityEngine.Debug.LogWarning(string.Concat(new object[] { "Texture ", meshBakerMaterialTexture.t, "is tiled by ", meshBakerMaterialTexture.scale, " tiling will be baked into a texture with maxSize:", maxTilingBakeSize }));
					}
					if (!meshBakerMaterialTexture.obUVscale.Equals(Vector2.one))
					{
						global::UnityEngine.Debug.LogWarning(string.Concat(new object[] { "Texture ", meshBakerMaterialTexture.t, "has out of bounds UVs that effectively tile by ", meshBakerMaterialTexture.obUVscale, " tiling will be baked into a texture with maxSize:", maxTilingBakeSize }));
					}
					if (meshBakerMaterialTexture.t != null)
					{
						Vector2 adjustedForScaleAndOffset2Dimensions = this.getAdjustedForScaleAndOffset2Dimensions(meshBakerMaterialTexture, fixOutOfBoundsUVs, maxTilingBakeSize);
						num2 = (int)adjustedForScaleAndOffset2Dimensions.x;
						num3 = (int)adjustedForScaleAndOffset2Dimensions.y;
						if (meshBakerMaterialTexture.t.width * meshBakerMaterialTexture.t.height > num2 * num3)
						{
							num2 = meshBakerMaterialTexture.t.width;
							num3 = meshBakerMaterialTexture.t.height;
						}
					}
				}
				if (resizePowerOfTwoTextures)
				{
					if (this.IsPowerOfTwo(num2))
					{
						num2 -= num * 2;
					}
					if (this.IsPowerOfTwo(num3))
					{
						num3 -= num * 2;
					}
					if (num2 < 1)
					{
						num2 = 1;
					}
					if (num3 < 1)
					{
						num3 = 1;
					}
				}
				mb_TexSet2.idealWidth = num2;
				mb_TexSet2.idealHeight = num3;
			}
			StringBuilder stringBuilder = new StringBuilder();
			if (count > 0)
			{
				stringBuilder = new StringBuilder();
				stringBuilder.AppendLine("Report");
				for (int n = 0; n < list.Count; n++)
				{
					MB_TextureCombiner.MB_TexSet mb_TexSet3 = list[n];
					stringBuilder.AppendLine("----------");
					stringBuilder.Append(string.Concat(new object[] { "This set of textures will be resized to:", mb_TexSet3.idealWidth, "x", mb_TexSet3.idealHeight, "\n" }));
					for (int num4 = 0; num4 < mb_TexSet3.ts.Length; num4++)
					{
						if (mb_TexSet3.ts[num4].t != null)
						{
							stringBuilder.Append(string.Concat(new object[]
							{
								"   [",
								texPropertyNames[num4],
								" ",
								mb_TexSet3.ts[num4].t.name,
								" ",
								mb_TexSet3.ts[num4].t.width,
								"x",
								mb_TexSet3.ts[num4].t.height,
								"]\n"
							}));
						}
						else
						{
							stringBuilder.Append("   [" + texPropertyNames[num4] + " null a blank texture will be created]\n");
						}
					}
					stringBuilder.AppendLine(string.Empty);
					stringBuilder.Append("Materials using:");
					for (int num5 = 0; num5 < mb_TexSet3.mats.Count; num5++)
					{
						stringBuilder.Append(mb_TexSet3.mats[num5].name + ", ");
					}
					stringBuilder.AppendLine(string.Empty);
				}
			}
			if (progressInfo != null)
			{
				progressInfo("Creating txture atlases.", 0.1f);
			}
			GC.Collect();
			Texture2D[] array2 = new Texture2D[count];
			Rect[] array3;
			if (packingAlgorithm == MB2_PackingAlgorithmEnum.UnitysPackTextures)
			{
				array3 = this.__CreateAtlasesUnityTexturePacker(progressInfo, count, list, fixOutOfBoundsUVs, maxTilingBakeSize, num, saveAtlasesAsAssets, texPropertyNames, resultMaterial, fileSaveFunction, array2);
			}
			else
			{
				array3 = this.__CreateAtlasesMBTexturePacker(progressInfo, count, list, fixOutOfBoundsUVs, maxTilingBakeSize, num, saveAtlasesAsAssets, texPropertyNames, resultMaterial, fileSaveFunction, array2);
			}
			if (progressInfo != null)
			{
				progressInfo("Building Report", 0.7f);
			}
			StringBuilder stringBuilder2 = new StringBuilder();
			stringBuilder2.AppendLine("---- Atlases ------");
			for (int num6 = 0; num6 < count; num6++)
			{
				if (array2[num6] != null)
				{
					stringBuilder2.AppendLine(string.Concat(new object[]
					{
						"Created Atlas For: ",
						texPropertyNames[num6],
						" h=",
						array2[num6].height,
						" w=",
						array2[num6].width
					}));
				}
			}
			stringBuilder.Append(stringBuilder2.ToString());
			Dictionary<Material, Rect> dictionary = new Dictionary<Material, Rect>();
			for (int num7 = 0; num7 < list.Count; num7++)
			{
				List<Material> mats = list[num7].mats;
				for (int num8 = 0; num8 < mats.Count; num8++)
				{
					if (!dictionary.ContainsKey(mats[num8]))
					{
						dictionary.Add(mats[num8], array3[num7]);
					}
				}
			}
			results.atlases = array2;
			results.texPropertyNames = texPropertyNames.ToArray();
			results.mat2rect_map = dictionary;
			if (progressInfo != null)
			{
				progressInfo("Restoring Texture Formats & Read Flags", 0.8f);
			}
			this._destroyTemporaryTextures();
			this._SetReadFlags(progressInfo);
			if (stringBuilder != null)
			{
				global::UnityEngine.Debug.Log(stringBuilder.ToString());
			}
			return true;
		}

		// Token: 0x06004C47 RID: 19527 RVA: 0x0013FB2C File Offset: 0x0013DD2C
		private Rect[] __CreateAtlasesMBTexturePacker(ProgressUpdateDelegate progressInfo, int numAtlases, List<MB_TextureCombiner.MB_TexSet> distinctMaterialTextures, bool fixOutOfBoundsUVs, int maxTilingBakeSize, int _padding, bool saveAtlasesAsAssets, List<string> texPropertyNames, Material resultMaterial, MB_TextureCombiner.FileSaveFunction fileSaveFunction, Texture2D[] atlases)
		{
			List<Vector2> list = new List<Vector2>();
			for (int i = 0; i < distinctMaterialTextures.Count; i++)
			{
				list.Add(new Vector2((float)distinctMaterialTextures[i].idealWidth, (float)distinctMaterialTextures[i].idealHeight));
			}
			MB2_TexturePacker mb2_TexturePacker = new MB2_TexturePacker();
			int num = 1;
			int num2 = 1;
			int num3 = 4096;
			if (Application.platform == RuntimePlatform.Android)
			{
				num3 = 2048;
			}
			if (Application.platform == RuntimePlatform.IPhonePlayer)
			{
				num3 = 2048;
			}
			if (Application.platform == RuntimePlatform.WindowsWebPlayer)
			{
				num3 = 2048;
			}
			if (Application.platform == RuntimePlatform.OSXWebPlayer)
			{
				num3 = 2048;
			}
			Rect[] rects = mb2_TexturePacker.GetRects(list, num3, _padding, out num, out num2);
			global::UnityEngine.Debug.Log(string.Concat(new object[] { "Generated atlas will be ", num, "x", num2, " (Max atlas size for platform: ", num3, ")" }));
			for (int j = 0; j < numAtlases; j++)
			{
				GC.Collect();
				if (progressInfo != null)
				{
					progressInfo("Creating Atlas '" + texPropertyNames[j] + "'", 0.01f);
				}
				Color[] array = new Color[num * num2];
				for (int k = 0; k < array.Length; k++)
				{
					array[k] = Color.clear;
				}
				for (int l = 0; l < distinctMaterialTextures.Count; l++)
				{
					Rect rect = rects[l];
					Texture2D t = distinctMaterialTextures[l].ts[j].t;
					int num4 = Mathf.RoundToInt(rect.x * (float)num);
					int num5 = Mathf.RoundToInt(rect.y * (float)num2);
					int num6 = Mathf.RoundToInt(rect.width * (float)num);
					int num7 = Mathf.RoundToInt(rect.height * (float)num2);
					if (num6 == 0 || num7 == 0)
					{
						global::UnityEngine.Debug.LogError("Image in atlas has no height or width");
					}
					this.setReadWriteFlag(t, true, true);
					if (progressInfo != null)
					{
						progressInfo("Copying to atlas: '" + distinctMaterialTextures[l].ts[j].t + "'", 0.02f);
					}
					this.CopyScaledAndTiledToAtlas(distinctMaterialTextures[l].ts[j], num4, num5, num6, num7, fixOutOfBoundsUVs, maxTilingBakeSize, array, num);
				}
				if (progressInfo != null)
				{
					progressInfo("Applying changes to atlas: '" + texPropertyNames[j] + "'", 0.03f);
				}
				Texture2D texture2D = new Texture2D(num, num2, TextureFormat.ARGB32, true);
				texture2D.name = "MB_TextureCombiner_atlas";
				texture2D.SetPixels(array);
				texture2D.Apply();
				if (MB_TextureCombiner.VERBOSE)
				{
					global::UnityEngine.Debug.Log(string.Concat(new object[]
					{
						"Saving atlas ",
						texPropertyNames[j],
						" w=",
						texture2D.width,
						" h=",
						texture2D.height
					}));
				}
				atlases[j] = texture2D;
				if (progressInfo != null)
				{
					progressInfo("Saving atlas: '" + texPropertyNames[j] + "'", 0.04f);
				}
				if (saveAtlasesAsAssets)
				{
					this._saveAtlasToAssetDatabase(atlases[j], texPropertyNames[j], j, resultMaterial, fileSaveFunction);
				}
				this._destroyTemporaryTextures();
			}
			return rects;
		}

		// Token: 0x06004C48 RID: 19528 RVA: 0x0013FE8C File Offset: 0x0013E08C
		private Rect[] __CreateAtlasesUnityTexturePacker(ProgressUpdateDelegate progressInfo, int numAtlases, List<MB_TextureCombiner.MB_TexSet> distinctMaterialTextures, bool fixOutOfBoundsUVs, int maxTilingBakeSize, int _padding, bool saveAtlasesAsAssets, List<string> texPropertyNames, Material resultMaterial, MB_TextureCombiner.FileSaveFunction fileSaveFunction, Texture2D[] atlases)
		{
			long num = 0L;
			int num2 = 1;
			int num3 = 1;
			Rect[] array = null;
			for (int i = 0; i < numAtlases; i++)
			{
				if (MB_TextureCombiner.VERBOSE)
				{
					global::UnityEngine.Debug.Log(string.Concat(new object[]
					{
						"Beginning loop ",
						i,
						" num temporary textures ",
						this._temporaryTextures.Count
					}));
				}
				for (int j = 0; j < distinctMaterialTextures.Count; j++)
				{
					MB_TextureCombiner.MB_TexSet mb_TexSet = distinctMaterialTextures[j];
					int idealWidth = mb_TexSet.idealWidth;
					int idealHeight = mb_TexSet.idealHeight;
					Texture2D texture2D = mb_TexSet.ts[i].t;
					if (texture2D == null)
					{
						texture2D = (mb_TexSet.ts[i].t = this._createTemporaryTexture(idealWidth, idealHeight, TextureFormat.ARGB32, true));
					}
					if (progressInfo != null)
					{
						progressInfo("Adjusting for scale and offset " + texture2D, 0.01f);
					}
					this.setReadWriteFlag(texture2D, true, true);
					texture2D = this.getAdjustedForScaleAndOffset2(mb_TexSet.ts[i], fixOutOfBoundsUVs, maxTilingBakeSize);
					if (texture2D.width != idealWidth || texture2D.height != idealHeight)
					{
						if (progressInfo != null)
						{
							progressInfo("Resizing texture '" + texture2D + "'", 0.01f);
						}
						if (MB_TextureCombiner.VERBOSE)
						{
							global::UnityEngine.Debug.Log(string.Concat(new object[]
							{
								"Copying and resizing texture ",
								texPropertyNames[i],
								" from ",
								texture2D.width,
								"x",
								texture2D.height,
								" to ",
								idealWidth,
								"x",
								idealHeight
							}));
						}
						this.setReadWriteFlag(texture2D, true, true);
						texture2D = this._resizeTexture(texture2D, idealWidth, idealHeight);
					}
					mb_TexSet.ts[i].t = texture2D;
				}
				Texture2D[] array2 = new Texture2D[distinctMaterialTextures.Count];
				for (int k = 0; k < distinctMaterialTextures.Count; k++)
				{
					Texture2D t = distinctMaterialTextures[k].ts[i].t;
					num += (long)(t.width * t.height);
					array2[k] = t;
				}
				if (Math.Sqrt((double)num) > 3500.0)
				{
					global::UnityEngine.Debug.LogWarning("The maximum possible atlas size is 4096. Textures may be shrunk");
				}
				atlases[i] = new Texture2D(1, 1, TextureFormat.ARGB32, true);
				atlases[i].name = "MB_TextureCombiner_atlases" + i;
				if (progressInfo != null)
				{
					progressInfo("Packing texture atlas " + texPropertyNames[i], 0.25f);
				}
				if (i == 0)
				{
					if (progressInfo != null)
					{
						progressInfo("Estimated min size of atlases: " + Math.Sqrt((double)num).ToString("F0"), 0.1f);
					}
					global::UnityEngine.Debug.Log("Estimated atlas minimum size:" + Math.Sqrt((double)num).ToString("F0"));
					this._addWatermark(array2);
					if (distinctMaterialTextures.Count == 1)
					{
						array = new Rect[]
						{
							new Rect(0f, 0f, 1f, 1f)
						};
						atlases[i] = this._copyTexturesIntoAtlas(array2, _padding, array, array2[0].width, array2[0].height);
					}
					else
					{
						array = atlases[i].PackTextures(array2, _padding, 4096, false);
					}
					global::UnityEngine.Debug.Log(string.Concat(new object[]
					{
						"After pack textures atlas size ",
						atlases[i].width,
						" ",
						atlases[i].height
					}));
					num2 = atlases[i].width;
					num3 = atlases[i].height;
					atlases[i].Apply();
				}
				else
				{
					if (progressInfo != null)
					{
						progressInfo("Copying Textures Into: " + texPropertyNames[i], 0.1f);
					}
					atlases[i] = this._copyTexturesIntoAtlas(array2, _padding, array, num2, num3);
				}
				if (saveAtlasesAsAssets)
				{
					this._saveAtlasToAssetDatabase(atlases[i], texPropertyNames[i], i, resultMaterial, fileSaveFunction);
				}
				this._destroyTemporaryTextures();
				GC.Collect();
			}
			return array;
		}

		// Token: 0x06004C49 RID: 19529 RVA: 0x0000311B File Offset: 0x0000131B
		private void _addWatermark(Texture2D[] texToPack)
		{
		}

		// Token: 0x06004C4A RID: 19530 RVA: 0x00013990 File Offset: 0x00011B90
		private Texture2D _addWatermark(Texture2D texToPack)
		{
			return texToPack;
		}

		// Token: 0x06004C4B RID: 19531 RVA: 0x001402DC File Offset: 0x0013E4DC
		private Texture2D _copyTexturesIntoAtlas(Texture2D[] texToPack, int padding, Rect[] rs, int w, int h)
		{
			Texture2D texture2D = new Texture2D(w, h, TextureFormat.ARGB32, true);
			texture2D.name = "MB_TextureCombiner_ta";
			MB_Utility.setSolidColor(texture2D, Color.clear);
			for (int i = 0; i < rs.Length; i++)
			{
				Rect rect = rs[i];
				Texture2D texture2D2 = texToPack[i];
				int num = Mathf.RoundToInt(rect.x * (float)w);
				int num2 = Mathf.RoundToInt(rect.y * (float)h);
				int num3 = Mathf.RoundToInt(rect.width * (float)w);
				int num4 = Mathf.RoundToInt(rect.height * (float)h);
				if (texture2D2.width != num3 && texture2D2.height != num4)
				{
					texture2D2 = MB_Utility.resampleTexture(texture2D2, num3, num4);
					this._temporaryTextures.Add(texture2D2);
				}
				texture2D.SetPixels(num, num2, num3, num4, texture2D2.GetPixels());
			}
			texture2D.Apply();
			return texture2D;
		}

		// Token: 0x06004C4C RID: 19532 RVA: 0x00031C15 File Offset: 0x0002FE15
		private bool IsPowerOfTwo(int x)
		{
			return (x & (x - 1)) == 0;
		}

		// Token: 0x06004C4D RID: 19533 RVA: 0x0000311B File Offset: 0x0000131B
		private void setReadWriteFlag(Texture2D tx, bool isReadable, bool addToList)
		{
		}

		// Token: 0x06004C4E RID: 19534 RVA: 0x0000311B File Offset: 0x0000131B
		private void setTextureSize(Texture2D tx)
		{
		}

		// Token: 0x06004C4F RID: 19535 RVA: 0x0000311D File Offset: 0x0000131D
		private bool _isCompressed(Texture2D tx)
		{
			return false;
		}

		// Token: 0x06004C50 RID: 19536 RVA: 0x001403C0 File Offset: 0x0013E5C0
		private Vector2 getAdjustedForScaleAndOffset2Dimensions(MB_TextureCombiner.MeshBakerMaterialTexture source, bool fixOutOfBoundsUVs, int maxSize)
		{
			if (source.offset.x == 0f && source.offset.y == 0f && source.scale.x == 1f && source.scale.y == 1f)
			{
				if (!fixOutOfBoundsUVs)
				{
					return new Vector2((float)source.t.width, (float)source.t.height);
				}
				if (source.obUVoffset.x == 0f && source.obUVoffset.y == 0f && source.obUVscale.x == 1f && source.obUVscale.y == 1f)
				{
					return new Vector2((float)source.t.width, (float)source.t.height);
				}
			}
			if (MB_TextureCombiner.VERBOSE)
			{
				global::UnityEngine.Debug.Log(string.Concat(new object[] { "getAdjustedForScaleAndOffset2Dimensions: ", source.t, " ", source.obUVoffset, " ", source.obUVscale }));
			}
			float num = (float)source.t.width * source.scale.x;
			float num2 = (float)source.t.height * source.scale.y;
			if (fixOutOfBoundsUVs)
			{
				num *= source.obUVscale.x;
				num2 *= source.obUVscale.y;
			}
			if (num > (float)maxSize)
			{
				num = (float)maxSize;
			}
			if (num2 > (float)maxSize)
			{
				num2 = (float)maxSize;
			}
			if (num < 1f)
			{
				num = 1f;
			}
			if (num2 < 1f)
			{
				num2 = 1f;
			}
			return new Vector2(num, num2);
		}

		// Token: 0x06004C51 RID: 19537 RVA: 0x00140580 File Offset: 0x0013E780
		private Texture2D getAdjustedForScaleAndOffset2(MB_TextureCombiner.MeshBakerMaterialTexture source, bool fixOutOfBoundsUVs, int maxSize)
		{
			if (source.offset.x == 0f && source.offset.y == 0f && source.scale.x == 1f && source.scale.y == 1f)
			{
				if (!fixOutOfBoundsUVs)
				{
					return source.t;
				}
				if (source.obUVoffset.x == 0f && source.obUVoffset.y == 0f && source.obUVscale.x == 1f && source.obUVscale.y == 1f)
				{
					return source.t;
				}
			}
			Vector2 adjustedForScaleAndOffset2Dimensions = this.getAdjustedForScaleAndOffset2Dimensions(source, fixOutOfBoundsUVs, maxSize);
			if (MB_TextureCombiner.VERBOSE)
			{
				global::UnityEngine.Debug.Log(string.Concat(new object[] { "getAdjustedForScaleAndOffset2: ", source.t, " ", source.obUVoffset, " ", source.obUVscale }));
			}
			float x = adjustedForScaleAndOffset2Dimensions.x;
			float y = adjustedForScaleAndOffset2Dimensions.y;
			float num = source.scale.x;
			float num2 = source.scale.y;
			float num3 = source.offset.x;
			float num4 = source.offset.y;
			if (fixOutOfBoundsUVs)
			{
				num *= source.obUVscale.x;
				num2 *= source.obUVscale.y;
				num3 += source.obUVoffset.x;
				num4 += source.obUVoffset.y;
			}
			Texture2D texture2D = this._createTemporaryTexture((int)x, (int)y, TextureFormat.ARGB32, true);
			for (int i = 0; i < texture2D.width; i++)
			{
				for (int j = 0; j < texture2D.height; j++)
				{
					float num5 = (float)i / x * num + num3;
					float num6 = (float)j / y * num2 + num4;
					texture2D.SetPixel(i, j, source.t.GetPixelBilinear(num5, num6));
				}
			}
			texture2D.Apply();
			return texture2D;
		}

		// Token: 0x06004C52 RID: 19538 RVA: 0x0014078C File Offset: 0x0013E98C
		private void CopyScaledAndTiledToAtlas(MB_TextureCombiner.MeshBakerMaterialTexture source, int targX, int targY, int targW, int targH, bool fixOutOfBoundsUVs, int maxSize, Color[] atlasPixels, int atlasWidth)
		{
			if (MB_TextureCombiner.VERBOSE)
			{
				global::UnityEngine.Debug.Log(string.Concat(new object[]
				{
					"CopyScaledAndTiledToAtlas: ",
					source.t,
					" sourceW=",
					source.t.width,
					" sourceH=",
					source.t.height,
					" inAtlasX=",
					targX,
					" inAtlasY=",
					targY,
					" inAtlasW=",
					targW,
					" inAtlasH=",
					targH
				}));
			}
			float num = (float)targW;
			float num2 = (float)targH;
			float num3 = source.scale.x;
			float num4 = source.scale.y;
			float num5 = source.offset.x;
			float num6 = source.offset.y;
			if (fixOutOfBoundsUVs)
			{
				num3 *= source.obUVscale.x;
				num4 *= source.obUVscale.y;
				num5 += source.obUVoffset.x;
				num6 += source.obUVoffset.y;
			}
			int num7 = (int)num;
			int num8 = (int)num2;
			Texture2D texture2D = source.t;
			if (texture2D == null)
			{
				texture2D = this._createTemporaryTexture(2, 2, TextureFormat.ARGB32, true);
				MB_Utility.setSolidColor(texture2D, Color.clear);
			}
			texture2D = this._addWatermark(texture2D);
			for (int i = 0; i < num7; i++)
			{
				for (int j = 0; j < num8; j++)
				{
					float num9 = (float)i / num * num3 + num5;
					float num10 = (float)j / num2 * num4 + num6;
					atlasPixels[(targY + j) * atlasWidth + targX + i] = texture2D.GetPixelBilinear(num9, num10);
				}
			}
		}

		// Token: 0x06004C53 RID: 19539 RVA: 0x0014095C File Offset: 0x0013EB5C
		private Texture2D _createTemporaryTexture(int w, int h, TextureFormat texFormat, bool mipMaps)
		{
			Texture2D texture2D = new Texture2D(w, h, texFormat, mipMaps);
			texture2D.name = "MB_TextureCombiner_t";
			MB_Utility.setSolidColor(texture2D, Color.clear);
			this._temporaryTextures.Add(texture2D);
			return texture2D;
		}

		// Token: 0x06004C54 RID: 19540 RVA: 0x00140998 File Offset: 0x0013EB98
		private Texture2D _createTextureCopy(Texture2D t)
		{
			Texture2D texture2D = MB_Utility.createTextureCopy(t);
			this._temporaryTextures.Add(texture2D);
			return texture2D;
		}

		// Token: 0x06004C55 RID: 19541 RVA: 0x001409BC File Offset: 0x0013EBBC
		private Texture2D _resizeTexture(Texture2D t, int w, int h)
		{
			Texture2D texture2D = MB_Utility.resampleTexture(t, w, h);
			this._temporaryTextures.Add(texture2D);
			return texture2D;
		}

		// Token: 0x06004C56 RID: 19542 RVA: 0x001409E0 File Offset: 0x0013EBE0
		private void _destroyTemporaryTextures()
		{
			if (MB_TextureCombiner.VERBOSE)
			{
				global::UnityEngine.Debug.Log("Destroying " + this._temporaryTextures.Count + " temporary textures");
			}
			for (int i = 0; i < this._temporaryTextures.Count; i++)
			{
				this._destroy(this._temporaryTextures[i]);
			}
			this._temporaryTextures.Clear();
		}

		// Token: 0x06004C57 RID: 19543 RVA: 0x00140A4C File Offset: 0x0013EC4C
		private void _SetReadFlags(ProgressUpdateDelegate progressInfo)
		{
			for (int i = 0; i < this._texturesWithReadWriteFlagSet.Count; i++)
			{
				if (progressInfo != null)
				{
					progressInfo("Restoring read flag for " + this._texturesWithReadWriteFlagSet[i], 0.9f);
				}
				this.setReadWriteFlag(this._texturesWithReadWriteFlagSet[i], false, false);
			}
			this._texturesWithReadWriteFlagSet.Clear();
		}

		// Token: 0x06004C58 RID: 19544 RVA: 0x00031C1F File Offset: 0x0002FE1F
		private void _destroy(global::UnityEngine.Object o)
		{
			global::UnityEngine.Object.Destroy(o);
		}

		// Token: 0x06004C59 RID: 19545 RVA: 0x0000311B File Offset: 0x0000131B
		private void _saveAtlasToAssetDatabase(Texture2D atlas, string texPropertyName, int atlasNum, Material resMat, MB_TextureCombiner.FileSaveFunction fileSaveFunction)
		{
		}

		// Token: 0x06004C5A RID: 19546 RVA: 0x0000311B File Offset: 0x0000131B
		private void _setMaterialTextureProperty(Material target, string texPropName, string texturePath)
		{
		}

		// Token: 0x06004C5B RID: 19547 RVA: 0x0000311B File Offset: 0x0000131B
		private void setNormalMap(Texture2D tx)
		{
		}

		// Token: 0x0400378C RID: 14220
		private static bool VERBOSE = false;

		// Token: 0x0400378D RID: 14221
		public static string[] shaderTexPropertyNames = new string[]
		{
			"_MainTex", "_BumpMap", "_Normal", "_BumpSpecMap", "_DecalTex", "_Detail", "_GlossMap", "_Illum", "_LightTextureB0", "_ParallaxMap",
			"_ShadowOffset", "_TranslucencyMap", "_SpecMap", "_TranspMap"
		};

		// Token: 0x0400378E RID: 14222
		private List<Texture2D> _temporaryTextures = new List<Texture2D>();

		// Token: 0x0400378F RID: 14223
		private List<Texture2D> _texturesWithReadWriteFlagSet = new List<Texture2D>();

		// Token: 0x02000AFB RID: 2811
		private class MeshBakerMaterialTexture
		{
			// Token: 0x06004C5C RID: 19548 RVA: 0x00140AB4 File Offset: 0x0013ECB4
			public MeshBakerMaterialTexture()
			{
			}

			// Token: 0x06004C5D RID: 19549 RVA: 0x00140B1C File Offset: 0x0013ED1C
			public MeshBakerMaterialTexture(Texture2D tx)
			{
				this.t = tx;
			}

			// Token: 0x06004C5E RID: 19550 RVA: 0x00140B8C File Offset: 0x0013ED8C
			public MeshBakerMaterialTexture(Texture2D tx, Vector2 o, Vector2 s, Vector2 oUV, Vector2 sUV)
			{
				this.t = tx;
				this.offset = o;
				this.scale = s;
				this.obUVoffset = oUV;
				this.obUVscale = sUV;
			}

			// Token: 0x04003790 RID: 14224
			public Vector2 offset = new Vector2(0f, 0f);

			// Token: 0x04003791 RID: 14225
			public Vector2 scale = new Vector2(1f, 1f);

			// Token: 0x04003792 RID: 14226
			public Vector2 obUVoffset = new Vector2(0f, 0f);

			// Token: 0x04003793 RID: 14227
			public Vector2 obUVscale = new Vector2(1f, 1f);

			// Token: 0x04003794 RID: 14228
			public Texture2D t;
		}

		// Token: 0x02000AFC RID: 2812
		private class MB_TexSet
		{
			// Token: 0x06004C5F RID: 19551 RVA: 0x00031C27 File Offset: 0x0002FE27
			public MB_TexSet(MB_TextureCombiner.MeshBakerMaterialTexture[] tss)
			{
				this.ts = tss;
				this.mats = new List<Material>();
			}

			// Token: 0x06004C60 RID: 19552 RVA: 0x00140C18 File Offset: 0x0013EE18
			public override bool Equals(object obj)
			{
				if (!(obj is MB_TextureCombiner.MB_TexSet))
				{
					return false;
				}
				MB_TextureCombiner.MB_TexSet mb_TexSet = (MB_TextureCombiner.MB_TexSet)obj;
				if (mb_TexSet.ts.Length != this.ts.Length)
				{
					return false;
				}
				for (int i = 0; i < this.ts.Length; i++)
				{
					if (this.ts[i].offset != mb_TexSet.ts[i].offset)
					{
						return false;
					}
					if (this.ts[i].scale != mb_TexSet.ts[i].scale)
					{
						return false;
					}
					if (this.ts[i].t != mb_TexSet.ts[i].t)
					{
						return false;
					}
					if (this.ts[i].obUVoffset != mb_TexSet.ts[i].obUVoffset)
					{
						return false;
					}
					if (this.ts[i].obUVscale != mb_TexSet.ts[i].obUVscale)
					{
						return false;
					}
				}
				return true;
			}

			// Token: 0x06004C61 RID: 19553 RVA: 0x0000311D File Offset: 0x0000131D
			public override int GetHashCode()
			{
				return 0;
			}

			// Token: 0x04003795 RID: 14229
			public MB_TextureCombiner.MeshBakerMaterialTexture[] ts;

			// Token: 0x04003796 RID: 14230
			public List<Material> mats;

			// Token: 0x04003797 RID: 14231
			public int idealWidth;

			// Token: 0x04003798 RID: 14232
			public int idealHeight;
		}

		// Token: 0x02000AFD RID: 2813
		// (Invoke) Token: 0x06004C63 RID: 19555
		public delegate void FileSaveFunction(string pth, byte[] bytes);
	}
}
