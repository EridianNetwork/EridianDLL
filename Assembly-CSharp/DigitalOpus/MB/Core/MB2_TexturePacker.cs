using System;
using System.Collections.Generic;
using UnityEngine;

namespace DigitalOpus.MB.Core
{
	// Token: 0x02000AF1 RID: 2801
	public class MB2_TexturePacker
	{
		// Token: 0x06004C27 RID: 19495 RVA: 0x0013DF38 File Offset: 0x0013C138
		private static void printTree(MB2_TexturePacker.Node r, string spc)
		{
			if (r.child[0] != null)
			{
				MB2_TexturePacker.printTree(r.child[0], spc + "  ");
			}
			if (r.child[1] != null)
			{
				MB2_TexturePacker.printTree(r.child[1], spc + "  ");
			}
		}

		// Token: 0x06004C28 RID: 19496 RVA: 0x0013DF8C File Offset: 0x0013C18C
		private static void flattenTree(MB2_TexturePacker.Node r, List<MB2_TexturePacker.Image> putHere)
		{
			if (r.img != null)
			{
				r.img.x = r.r.x;
				r.img.y = r.r.y;
				putHere.Add(r.img);
			}
			if (r.child[0] != null)
			{
				MB2_TexturePacker.flattenTree(r.child[0], putHere);
			}
			if (r.child[1] != null)
			{
				MB2_TexturePacker.flattenTree(r.child[1], putHere);
			}
		}

		// Token: 0x06004C29 RID: 19497 RVA: 0x0013E00C File Offset: 0x0013C20C
		private static void drawGizmosNode(MB2_TexturePacker.Node r)
		{
			Vector3 vector = new Vector3((float)r.r.w, (float)r.r.h, 0f);
			Vector3 vector2 = new Vector3((float)r.r.x + vector.x / 2f, (float)(-(float)r.r.y) - vector.y / 2f, 0f);
			Gizmos.DrawWireCube(vector2, vector);
			if (r.img != null)
			{
				Gizmos.color = Color.blue;
				vector = new Vector3((float)r.img.w, (float)r.img.h, 0f);
				vector2 = new Vector3((float)r.img.x + vector.x / 2f, (float)(-(float)r.img.y) - vector.y / 2f, 0f);
				Gizmos.DrawCube(vector2, vector);
			}
			if (r.child[0] != null)
			{
				Gizmos.color = Color.red;
				MB2_TexturePacker.drawGizmosNode(r.child[0]);
			}
			if (r.child[1] != null)
			{
				Gizmos.color = Color.green;
				MB2_TexturePacker.drawGizmosNode(r.child[1]);
			}
		}

		// Token: 0x06004C2A RID: 19498 RVA: 0x0013E148 File Offset: 0x0013C348
		private static Texture2D createFilledTex(Color c, int w, int h)
		{
			Texture2D texture2D = new Texture2D(w, h);
			texture2D.name = "createFilledTex_t";
			for (int i = 0; i < w; i++)
			{
				for (int j = 0; j < h; j++)
				{
					texture2D.SetPixel(i, j, c);
				}
			}
			texture2D.Apply();
			return texture2D;
		}

		// Token: 0x06004C2B RID: 19499 RVA: 0x00031ACC File Offset: 0x0002FCCC
		public void DrawGizmos()
		{
			if (this.bestRoot != null)
			{
				MB2_TexturePacker.drawGizmosNode(this.bestRoot.root);
			}
		}

		// Token: 0x06004C2C RID: 19500 RVA: 0x0013E190 File Offset: 0x0013C390
		private bool Probe(MB2_TexturePacker.Image[] imgsToAdd, int idealAtlasW, int idealAtlasH, float imgArea, int maxAtlasDim, MB2_TexturePacker.ProbeResult pr)
		{
			MB2_TexturePacker.Node node = new MB2_TexturePacker.Node();
			node.r = new MB2_TexturePacker.PixRect(0, 0, idealAtlasW, idealAtlasH);
			for (int i = 0; i < imgsToAdd.Length; i++)
			{
				MB2_TexturePacker.Node node2 = node.Insert(imgsToAdd[i], false);
				if (node2 == null)
				{
					return false;
				}
				if (i == imgsToAdd.Length - 1)
				{
					int num = 0;
					int num2 = 0;
					this.GetExtent(node, ref num, ref num2);
					float num3 = 1f - ((float)(num * num2) - imgArea) / (float)(num * num2);
					float num4;
					if (num < num2)
					{
						num4 = (float)num / (float)num2;
					}
					else
					{
						num4 = (float)num2 / (float)num;
					}
					bool flag = num <= maxAtlasDim && num2 <= maxAtlasDim;
					pr.Set(num, num2, node, flag, num3, num4);
					if (this.LOG_LEVEL >= MB2_LogLevel.info)
					{
						global::UnityEngine.Debug.Log(string.Concat(new object[] { "Probe success efficiency w=", num, " h=", num2, " e=", num3, " sq=", num4, " fits=", flag }));
					}
					return true;
				}
			}
			if (this.LOG_LEVEL >= MB2_LogLevel.error)
			{
				global::UnityEngine.Debug.LogError("Should never get here.");
			}
			return false;
		}

		// Token: 0x06004C2D RID: 19501 RVA: 0x0013E2C8 File Offset: 0x0013C4C8
		private void GetExtent(MB2_TexturePacker.Node r, ref int x, ref int y)
		{
			if (r.img != null)
			{
				if (r.r.x + r.img.w > x)
				{
					x = r.r.x + r.img.w;
				}
				if (r.r.y + r.img.h > y)
				{
					y = r.r.y + r.img.h;
				}
			}
			if (r.child[0] != null)
			{
				this.GetExtent(r.child[0], ref x, ref y);
			}
			if (r.child[1] != null)
			{
				this.GetExtent(r.child[1], ref x, ref y);
			}
		}

		// Token: 0x06004C2E RID: 19502 RVA: 0x0013E37C File Offset: 0x0013C57C
		public Rect[] GetRects(List<Vector2> imgWidthHeights, int maxDimension, int padding, out int outW, out int outH)
		{
			float num = 0f;
			int num2 = 0;
			int num3 = 0;
			MB2_TexturePacker.Image[] array = new MB2_TexturePacker.Image[imgWidthHeights.Count];
			for (int i = 0; i < array.Length; i++)
			{
				MB2_TexturePacker.Image image = (array[i] = new MB2_TexturePacker.Image(i, (int)imgWidthHeights[i].x, (int)imgWidthHeights[i].y, padding));
				num += (float)(image.w * image.h);
				num2 = Mathf.Max(num2, image.w);
				num3 = Mathf.Max(num3, image.h);
			}
			if ((float)num3 / (float)num2 > 2f)
			{
				if (this.LOG_LEVEL >= MB2_LogLevel.info)
				{
					global::UnityEngine.Debug.Log("Using height Comparer");
				}
				Array.Sort<MB2_TexturePacker.Image>(array, new MB2_TexturePacker.ImageHeightComparer());
			}
			else if ((double)((float)num3 / (float)num2) < 0.5)
			{
				if (this.LOG_LEVEL >= MB2_LogLevel.info)
				{
					global::UnityEngine.Debug.Log("Using width Comparer");
				}
				Array.Sort<MB2_TexturePacker.Image>(array, new MB2_TexturePacker.ImageWidthComparer());
			}
			else
			{
				if (this.LOG_LEVEL >= MB2_LogLevel.info)
				{
					global::UnityEngine.Debug.Log("Using area Comparer");
				}
				Array.Sort<MB2_TexturePacker.Image>(array, new MB2_TexturePacker.ImageAreaComparer());
			}
			int num4 = (int)Mathf.Sqrt(num);
			int num5 = num4;
			int num6 = num4;
			if (num2 > num4)
			{
				num5 = num2;
				num6 = Mathf.Max(Mathf.CeilToInt(num / (float)num2), num3);
			}
			if (num3 > num4)
			{
				num5 = Mathf.Max(Mathf.CeilToInt(num / (float)num3), num2);
				num6 = num3;
			}
			if (num5 == 0)
			{
				num5 = 1;
			}
			if (num6 == 0)
			{
				num6 = 1;
			}
			int num7 = (int)((float)num5 * 0.15f);
			int num8 = (int)((float)num6 * 0.15f);
			if (num7 == 0)
			{
				num7 = 1;
			}
			if (num8 == 0)
			{
				num8 = 1;
			}
			int num9 = 2;
			int num10 = num6;
			while (num9 > 1 && num10 < num4 * 1000)
			{
				bool flag = false;
				num9 = 0;
				int num11 = num5;
				while (!flag && num11 < num4 * 1000)
				{
					MB2_TexturePacker.ProbeResult probeResult = new MB2_TexturePacker.ProbeResult();
					if (this.Probe(array, num11, num10, num, maxDimension, probeResult))
					{
						flag = true;
						if (this.bestRoot == null)
						{
							this.bestRoot = probeResult;
						}
						else if (probeResult.GetScore() > this.bestRoot.GetScore())
						{
							this.bestRoot = probeResult;
						}
					}
					else
					{
						num9++;
						num11 += num7;
						if (this.LOG_LEVEL >= MB2_LogLevel.info)
						{
							global::UnityEngine.Debug.Log(string.Concat(new object[] { "increasing Width h=", num10, " w=", num11 }));
						}
					}
				}
				num10 += num8;
				if (this.LOG_LEVEL >= MB2_LogLevel.info)
				{
					global::UnityEngine.Debug.Log(string.Concat(new object[] { "increasing Height h=", num10, " w=", num11 }));
				}
			}
			outW = 0;
			outH = 0;
			if (this.bestRoot == null)
			{
				return null;
			}
			if (this.LOG_LEVEL >= MB2_LogLevel.info)
			{
				global::UnityEngine.Debug.Log(string.Concat(new object[]
				{
					"Best fit found: w=",
					this.bestRoot.w,
					" h=",
					this.bestRoot.h,
					" efficiency=",
					this.bestRoot.efficiency,
					" squareness=",
					this.bestRoot.squareness,
					" fits in max dimension=",
					this.bestRoot.fitsInMaxSize
				}));
			}
			outW = this.bestRoot.w;
			outH = this.bestRoot.h;
			List<MB2_TexturePacker.Image> list = new List<MB2_TexturePacker.Image>();
			MB2_TexturePacker.flattenTree(this.bestRoot.root, list);
			list.Sort(new MB2_TexturePacker.ImgIDComparer());
			if (list.Count != array.Length)
			{
				global::UnityEngine.Debug.LogError("Result images not the same lentgh as source");
			}
			float num12 = (float)padding / (float)this.bestRoot.w;
			if (this.bestRoot.w > maxDimension)
			{
				num12 = (float)padding / (float)maxDimension;
				float num13 = (float)maxDimension / (float)this.bestRoot.w;
				if (this.LOG_LEVEL >= MB2_LogLevel.warn)
				{
					global::UnityEngine.Debug.LogWarning("Packing exceeded atlas width shrinking to " + num13);
				}
				for (int j = 0; j < list.Count; j++)
				{
					MB2_TexturePacker.Image image2 = list[j];
					int num14 = (int)((float)(image2.x + image2.w) * num13);
					image2.x = (int)(num13 * (float)image2.x);
					image2.w = num14 - image2.x;
					if (image2.w == 0)
					{
						global::UnityEngine.Debug.LogError("rounding scaled image w to zero");
					}
				}
				outW = maxDimension;
			}
			float num15 = (float)padding / (float)this.bestRoot.h;
			if (this.bestRoot.h > maxDimension)
			{
				num15 = (float)padding / (float)maxDimension;
				float num16 = (float)maxDimension / (float)this.bestRoot.h;
				if (this.LOG_LEVEL >= MB2_LogLevel.warn)
				{
					global::UnityEngine.Debug.LogWarning("Packing exceeded atlas height shrinking to " + num16);
				}
				for (int k = 0; k < list.Count; k++)
				{
					MB2_TexturePacker.Image image3 = list[k];
					int num17 = (int)((float)(image3.y + image3.h) * num16);
					image3.y = (int)(num16 * (float)image3.y);
					image3.h = num17 - image3.y;
					if (image3.h == 0)
					{
						global::UnityEngine.Debug.LogError("rounding scaled image h to zero");
					}
				}
				outH = maxDimension;
			}
			Rect[] array2 = new Rect[list.Count];
			for (int l = 0; l < list.Count; l++)
			{
				MB2_TexturePacker.Image image4 = list[l];
				Rect rect = (array2[l] = new Rect((float)image4.x / (float)outW + num12, (float)image4.y / (float)outH + num15, (float)image4.w / (float)outW - num12 * 2f, (float)image4.h / (float)outH - num15 * 2f));
				if (this.LOG_LEVEL >= MB2_LogLevel.info)
				{
					global::UnityEngine.Debug.Log(string.Concat(new object[]
					{
						"Image: ",
						l,
						" imgID=",
						image4.imgId,
						" x=",
						rect.x * (float)outW,
						" y=",
						rect.y * (float)outH,
						" w=",
						rect.width * (float)outW,
						" h=",
						rect.height * (float)outH,
						" padding=",
						padding
					}));
				}
			}
			if (this.LOG_LEVEL >= MB2_LogLevel.info)
			{
				global::UnityEngine.Debug.Log("Done GetRects");
			}
			return array2;
		}

		// Token: 0x06004C2F RID: 19503 RVA: 0x0013EA4C File Offset: 0x0013CC4C
		public void RunTestHarness()
		{
			int num;
			int num2;
			this.GetRects(new List<Vector2>
			{
				new Vector2(128f, 128f),
				new Vector2(256f, 256f),
				new Vector2(512f, 512f)
			}, 2048, 1, out num, out num2);
		}

		// Token: 0x04003778 RID: 14200
		public MB2_LogLevel LOG_LEVEL = MB2_LogLevel.warn;

		// Token: 0x04003779 RID: 14201
		private MB2_TexturePacker.ProbeResult bestRoot;

		// Token: 0x02000AF2 RID: 2802
		private class PixRect
		{
			// Token: 0x06004C30 RID: 19504 RVA: 0x00003197 File Offset: 0x00001397
			public PixRect()
			{
			}

			// Token: 0x06004C31 RID: 19505 RVA: 0x00031AE6 File Offset: 0x0002FCE6
			public PixRect(int xx, int yy, int ww, int hh)
			{
				this.x = xx;
				this.y = yy;
				this.w = ww;
				this.h = hh;
			}

			// Token: 0x0400377A RID: 14202
			public int x;

			// Token: 0x0400377B RID: 14203
			public int y;

			// Token: 0x0400377C RID: 14204
			public int w;

			// Token: 0x0400377D RID: 14205
			public int h;
		}

		// Token: 0x02000AF3 RID: 2803
		private class Image
		{
			// Token: 0x06004C32 RID: 19506 RVA: 0x00031B0B File Offset: 0x0002FD0B
			public Image(int id, int tw, int th, int padding)
			{
				this.imgId = id;
				this.w = tw + padding * 2;
				this.h = th + padding * 2;
			}

			// Token: 0x0400377E RID: 14206
			public int imgId;

			// Token: 0x0400377F RID: 14207
			public int w;

			// Token: 0x04003780 RID: 14208
			public int h;

			// Token: 0x04003781 RID: 14209
			public int x;

			// Token: 0x04003782 RID: 14210
			public int y;
		}

		// Token: 0x02000AF4 RID: 2804
		private class ImgIDComparer : IComparer<MB2_TexturePacker.Image>
		{
			// Token: 0x06004C34 RID: 19508 RVA: 0x00031B32 File Offset: 0x0002FD32
			public int Compare(MB2_TexturePacker.Image x, MB2_TexturePacker.Image y)
			{
				if (x.imgId > y.imgId)
				{
					return 1;
				}
				if (x.imgId == y.imgId)
				{
					return 0;
				}
				return -1;
			}
		}

		// Token: 0x02000AF5 RID: 2805
		private class ImageHeightComparer : IComparer<MB2_TexturePacker.Image>
		{
			// Token: 0x06004C36 RID: 19510 RVA: 0x00031B55 File Offset: 0x0002FD55
			public int Compare(MB2_TexturePacker.Image x, MB2_TexturePacker.Image y)
			{
				if (x.h > y.h)
				{
					return -1;
				}
				if (x.h == y.h)
				{
					return 0;
				}
				return 1;
			}
		}

		// Token: 0x02000AF6 RID: 2806
		private class ImageWidthComparer : IComparer<MB2_TexturePacker.Image>
		{
			// Token: 0x06004C38 RID: 19512 RVA: 0x00031B78 File Offset: 0x0002FD78
			public int Compare(MB2_TexturePacker.Image x, MB2_TexturePacker.Image y)
			{
				if (x.w > y.w)
				{
					return -1;
				}
				if (x.w == y.w)
				{
					return 0;
				}
				return 1;
			}
		}

		// Token: 0x02000AF7 RID: 2807
		private class ImageAreaComparer : IComparer<MB2_TexturePacker.Image>
		{
			// Token: 0x06004C3A RID: 19514 RVA: 0x0013EAB0 File Offset: 0x0013CCB0
			public int Compare(MB2_TexturePacker.Image x, MB2_TexturePacker.Image y)
			{
				int num = x.w * x.h;
				int num2 = y.w * y.h;
				if (num > num2)
				{
					return -1;
				}
				if (num == num2)
				{
					return 0;
				}
				return 1;
			}
		}

		// Token: 0x02000AF8 RID: 2808
		private class ProbeResult
		{
			// Token: 0x06004C3C RID: 19516 RVA: 0x00031B9B File Offset: 0x0002FD9B
			public void Set(int ww, int hh, MB2_TexturePacker.Node r, bool fits, float e, float sq)
			{
				this.w = ww;
				this.h = hh;
				this.root = r;
				this.fitsInMaxSize = fits;
				this.efficiency = e;
				this.squareness = sq;
			}

			// Token: 0x06004C3D RID: 19517 RVA: 0x0013EAE8 File Offset: 0x0013CCE8
			public float GetScore()
			{
				float num = ((!this.fitsInMaxSize) ? 0f : 1f);
				return this.squareness + 2f * this.efficiency + num;
			}

			// Token: 0x04003783 RID: 14211
			public int w;

			// Token: 0x04003784 RID: 14212
			public int h;

			// Token: 0x04003785 RID: 14213
			public MB2_TexturePacker.Node root;

			// Token: 0x04003786 RID: 14214
			public bool fitsInMaxSize;

			// Token: 0x04003787 RID: 14215
			public float efficiency;

			// Token: 0x04003788 RID: 14216
			public float squareness;
		}

		// Token: 0x02000AF9 RID: 2809
		private class Node
		{
			// Token: 0x06004C3F RID: 19519 RVA: 0x00031BDE File Offset: 0x0002FDDE
			private bool isLeaf()
			{
				return this.child[0] == null || this.child[1] == null;
			}

			// Token: 0x06004C40 RID: 19520 RVA: 0x0013EB20 File Offset: 0x0013CD20
			public MB2_TexturePacker.Node Insert(MB2_TexturePacker.Image im, bool handed)
			{
				int num;
				int num2;
				if (handed)
				{
					num = 0;
					num2 = 1;
				}
				else
				{
					num = 1;
					num2 = 0;
				}
				if (!this.isLeaf())
				{
					MB2_TexturePacker.Node node = this.child[num].Insert(im, handed);
					if (node != null)
					{
						return node;
					}
					return this.child[num2].Insert(im, handed);
				}
				else
				{
					if (this.img != null)
					{
						return null;
					}
					if (this.r.w < im.w || this.r.h < im.h)
					{
						return null;
					}
					if (this.r.w == im.w && this.r.h == im.h)
					{
						this.img = im;
						return this;
					}
					this.child[num] = new MB2_TexturePacker.Node();
					this.child[num2] = new MB2_TexturePacker.Node();
					int num3 = this.r.w - im.w;
					int num4 = this.r.h - im.h;
					if (num3 > num4)
					{
						this.child[num].r = new MB2_TexturePacker.PixRect(this.r.x, this.r.y, im.w, this.r.h);
						this.child[num2].r = new MB2_TexturePacker.PixRect(this.r.x + im.w, this.r.y, this.r.w - im.w, this.r.h);
					}
					else
					{
						this.child[num].r = new MB2_TexturePacker.PixRect(this.r.x, this.r.y, this.r.w, im.h);
						this.child[num2].r = new MB2_TexturePacker.PixRect(this.r.x, this.r.y + im.h, this.r.w, this.r.h - im.h);
					}
					return this.child[num].Insert(im, handed);
				}
			}

			// Token: 0x04003789 RID: 14217
			public MB2_TexturePacker.Node[] child = new MB2_TexturePacker.Node[2];

			// Token: 0x0400378A RID: 14218
			public MB2_TexturePacker.PixRect r;

			// Token: 0x0400378B RID: 14219
			public MB2_TexturePacker.Image img;
		}
	}
}
