using System;
using System.Collections.Generic;
using UnityEngine;

namespace DigitalOpus.MB.Core
{
	// Token: 0x02000B01 RID: 2817
	public class MB_Utility
	{
		// Token: 0x06004C6C RID: 19564 RVA: 0x00140D18 File Offset: 0x0013EF18
		public static Texture2D createTextureCopy(Texture2D source)
		{
			Texture2D texture2D = new Texture2D(source.width, source.height, TextureFormat.ARGB32, true);
			texture2D.name = "createTextureCopy_newTex";
			texture2D.SetPixels(source.GetPixels());
			return texture2D;
		}

		// Token: 0x06004C6D RID: 19565 RVA: 0x00140D54 File Offset: 0x0013EF54
		public static Material[] GetGOMaterials(GameObject go)
		{
			if (go == null)
			{
				return null;
			}
			Material[] array = null;
			Mesh mesh = null;
			MeshRenderer component = go.GetComponent<MeshRenderer>();
			if (component != null)
			{
				array = component.sharedMaterials;
				MeshFilter component2 = go.GetComponent<MeshFilter>();
				if (component2 == null)
				{
					throw new Exception("Object " + go + " has a MeshRenderer but no MeshFilter.");
				}
				mesh = component2.sharedMesh;
			}
			SkinnedMeshRenderer component3 = go.GetComponent<SkinnedMeshRenderer>();
			if (component3 != null)
			{
				array = component3.sharedMaterials;
				mesh = component3.sharedMesh;
			}
			if (array == null)
			{
				global::UnityEngine.Debug.LogError("Object " + go.name + " does not have a MeshRenderer or a SkinnedMeshRenderer component");
				return null;
			}
			if (mesh == null)
			{
				global::UnityEngine.Debug.LogError("Object " + go.name + " has a MeshRenderer or SkinnedMeshRenderer but no mesh.");
				return null;
			}
			if (mesh.subMeshCount < array.Length)
			{
				global::UnityEngine.Debug.LogWarning(string.Concat(new object[] { "Object ", go, " has only ", mesh.subMeshCount, " submeshes and has ", array.Length, " materials. Extra materials do nothing." }));
				Material[] array2 = new Material[mesh.subMeshCount];
				Array.Copy(array, array2, array2.Length);
				array = array2;
			}
			return array;
		}

		// Token: 0x06004C6E RID: 19566 RVA: 0x00140E90 File Offset: 0x0013F090
		public static Mesh GetMesh(GameObject go)
		{
			if (go == null)
			{
				return null;
			}
			MeshFilter component = go.GetComponent<MeshFilter>();
			if (component != null)
			{
				return component.sharedMesh;
			}
			SkinnedMeshRenderer component2 = go.GetComponent<SkinnedMeshRenderer>();
			if (component2 != null)
			{
				return component2.sharedMesh;
			}
			global::UnityEngine.Debug.LogError("Object " + go.name + " does not have a MeshFilter or a SkinnedMeshRenderer component");
			return null;
		}

		// Token: 0x06004C6F RID: 19567 RVA: 0x00140EF4 File Offset: 0x0013F0F4
		public static Renderer GetRenderer(GameObject go)
		{
			if (go == null)
			{
				return null;
			}
			MeshRenderer component = go.GetComponent<MeshRenderer>();
			if (component != null)
			{
				return component;
			}
			SkinnedMeshRenderer component2 = go.GetComponent<SkinnedMeshRenderer>();
			if (component2 != null)
			{
				return component2;
			}
			return null;
		}

		// Token: 0x06004C70 RID: 19568 RVA: 0x00140F34 File Offset: 0x0013F134
		public static void DisableRendererInSource(GameObject go)
		{
			if (go == null)
			{
				return;
			}
			MeshRenderer component = go.GetComponent<MeshRenderer>();
			if (component != null)
			{
				component.enabled = false;
				return;
			}
			SkinnedMeshRenderer component2 = go.GetComponent<SkinnedMeshRenderer>();
			if (component2 != null)
			{
				component2.enabled = false;
				return;
			}
		}

		// Token: 0x06004C71 RID: 19569 RVA: 0x00140F7C File Offset: 0x0013F17C
		public static bool hasOutOfBoundsUVs(Mesh m, ref Rect uvBounds, int submeshIndex = -1)
		{
			Vector2[] uv = m.uv;
			if (uv.Length == 0)
			{
				return false;
			}
			if (submeshIndex >= m.subMeshCount)
			{
				return false;
			}
			float num2;
			float num;
			float num4;
			float num3;
			if (submeshIndex >= 0)
			{
				int[] triangles = m.GetTriangles(submeshIndex);
				if (triangles.Length == 0)
				{
					return false;
				}
				num = (num2 = uv[triangles[0]].x);
				num3 = (num4 = uv[triangles[0]].y);
				foreach (int num5 in triangles)
				{
					if (uv[num5].x < num2)
					{
						num2 = uv[num5].x;
					}
					if (uv[num5].x > num)
					{
						num = uv[num5].x;
					}
					if (uv[num5].y < num4)
					{
						num4 = uv[num5].y;
					}
					if (uv[num5].y > num3)
					{
						num3 = uv[num5].y;
					}
				}
			}
			else
			{
				num = (num2 = uv[0].x);
				num3 = (num4 = uv[0].y);
				for (int j = 0; j < uv.Length; j++)
				{
					if (uv[j].x < num2)
					{
						num2 = uv[j].x;
					}
					if (uv[j].x > num)
					{
						num = uv[j].x;
					}
					if (uv[j].y < num4)
					{
						num4 = uv[j].y;
					}
					if (uv[j].y > num3)
					{
						num3 = uv[j].y;
					}
				}
			}
			uvBounds.x = num2;
			uvBounds.y = num4;
			uvBounds.width = num - num2;
			uvBounds.height = num3 - num4;
			if (num <= 1f && num2 >= 0f && num3 <= 1f && num4 >= 0f)
			{
				float num6 = 0f;
				uvBounds.y = num6;
				uvBounds.x = num6;
				num6 = 1f;
				uvBounds.height = num6;
				uvBounds.width = num6;
				return false;
			}
			return true;
		}

		// Token: 0x06004C72 RID: 19570 RVA: 0x001411A4 File Offset: 0x0013F3A4
		public static void setSolidColor(Texture2D t, Color c)
		{
			Color[] pixels = t.GetPixels();
			for (int i = 0; i < pixels.Length; i++)
			{
				pixels[i] = c;
			}
			t.SetPixels(pixels);
			t.Apply();
		}

		// Token: 0x06004C73 RID: 19571 RVA: 0x001411E0 File Offset: 0x0013F3E0
		public static Texture2D resampleTexture(Texture2D source, int newWidth, int newHeight)
		{
			TextureFormat format = source.format;
			if (format != TextureFormat.ARGB32 && format != TextureFormat.RGBA32 && format != TextureFormat.BGRA32 && format != TextureFormat.RGB24 && format != TextureFormat.Alpha8)
			{
				if (format != TextureFormat.DXT1)
				{
					global::UnityEngine.Debug.LogError("Can only resize textures in formats ARGB32, RGBA32, BGRA32, RGB24, Alpha8 or DXT");
					return null;
				}
			}
			Texture2D texture2D = new Texture2D(newWidth, newHeight, TextureFormat.ARGB32, true);
			texture2D.name = "resampleTexture_newTex";
			float num = (float)newWidth;
			float num2 = (float)newHeight;
			for (int i = 0; i < newWidth; i++)
			{
				for (int j = 0; j < newHeight; j++)
				{
					float num3 = (float)i / num;
					float num4 = (float)j / num2;
					texture2D.SetPixel(i, j, source.GetPixelBilinear(num3, num4));
				}
			}
			texture2D.Apply();
			return texture2D;
		}

		// Token: 0x06004C74 RID: 19572 RVA: 0x00141280 File Offset: 0x0013F480
		public static bool validateOBuvsMultiMaterial(Material[] sharedMaterials)
		{
			for (int i = 0; i < sharedMaterials.Length; i++)
			{
				for (int j = i + 1; j < sharedMaterials.Length; j++)
				{
					if (sharedMaterials[i] == sharedMaterials[j])
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x06004C75 RID: 19573 RVA: 0x001412BC File Offset: 0x0013F4BC
		public static int doSubmeshesShareVertsOrTris(Mesh m)
		{
			List<MB_Utility.MB_Triangle> list = new List<MB_Utility.MB_Triangle>();
			bool flag = false;
			bool flag2 = false;
			for (int i = 0; i < m.subMeshCount; i++)
			{
				int[] triangles = m.GetTriangles(i);
				for (int j = 0; j < triangles.Length; j += 3)
				{
					MB_Utility.MB_Triangle mb_Triangle = new MB_Utility.MB_Triangle(triangles, j, i);
					for (int k = 0; k < list.Count; k++)
					{
						if (mb_Triangle.isSame(list[k]))
						{
							flag2 = true;
						}
						if (mb_Triangle.sharesVerts(list[k]))
						{
							flag = true;
						}
					}
					list.Add(mb_Triangle);
				}
			}
			if (flag2)
			{
				return 2;
			}
			if (flag)
			{
				return 1;
			}
			return 0;
		}

		// Token: 0x06004C76 RID: 19574 RVA: 0x0014135C File Offset: 0x0013F55C
		private static bool validateMultipleMaterials(MB_MultiMaterial[] rs)
		{
			List<Material> list = new List<Material>();
			List<Material> list2 = new List<Material>();
			for (int i = 0; i < rs.Length; i++)
			{
				if (list2.Contains(rs[i].combinedMaterial))
				{
					global::UnityEngine.Debug.LogError("There are duplicate combined materials in the combined materials list");
					return false;
				}
				for (int j = 0; j < rs[i].sourceMaterials.Count; j++)
				{
					if (rs[i].sourceMaterials[j] == null)
					{
						global::UnityEngine.Debug.LogError("There are nulls in the list of source materials");
						return false;
					}
					if (list.Contains(rs[i].sourceMaterials[j]))
					{
						global::UnityEngine.Debug.LogError("There are duplicate source materials in the combined materials list");
						return false;
					}
					list.Add(rs[i].sourceMaterials[j]);
				}
				list2.Add(rs[i].combinedMaterial);
			}
			return true;
		}

		// Token: 0x06004C77 RID: 19575 RVA: 0x000077C7 File Offset: 0x000059C7
		public static void Destroy(global::UnityEngine.Object o)
		{
			global::UnityEngine.Object.Destroy(o);
		}

		// Token: 0x02000B02 RID: 2818
		private class MB_Triangle
		{
			// Token: 0x06004C78 RID: 19576 RVA: 0x00141424 File Offset: 0x0013F624
			public MB_Triangle(int[] ts, int idx, int sIdx)
			{
				this.vs[0] = ts[idx];
				this.vs[1] = ts[idx + 1];
				this.vs[2] = ts[idx + 2];
				this.submeshIdx = sIdx;
				Array.Sort<int>(this.vs);
			}

			// Token: 0x06004C79 RID: 19577 RVA: 0x0014147C File Offset: 0x0013F67C
			public bool isSame(object obj)
			{
				MB_Utility.MB_Triangle mb_Triangle = (MB_Utility.MB_Triangle)obj;
				return this.vs[0] == mb_Triangle.vs[0] && this.vs[1] == mb_Triangle.vs[1] && this.vs[2] == mb_Triangle.vs[2] && this.submeshIdx != mb_Triangle.submeshIdx;
			}

			// Token: 0x06004C7A RID: 19578 RVA: 0x001414D8 File Offset: 0x0013F6D8
			public bool sharesVerts(MB_Utility.MB_Triangle obj)
			{
				return ((this.vs[0] == obj.vs[0] || this.vs[0] == obj.vs[1] || this.vs[0] == obj.vs[2]) && this.submeshIdx != obj.submeshIdx) || ((this.vs[1] == obj.vs[0] || this.vs[1] == obj.vs[1] || this.vs[1] == obj.vs[2]) && this.submeshIdx != obj.submeshIdx) || ((this.vs[2] == obj.vs[0] || this.vs[2] == obj.vs[1] || this.vs[2] == obj.vs[2]) && this.submeshIdx != obj.submeshIdx);
			}

			// Token: 0x0400379D RID: 14237
			private int submeshIdx;

			// Token: 0x0400379E RID: 14238
			private int[] vs = new int[3];
		}
	}
}
