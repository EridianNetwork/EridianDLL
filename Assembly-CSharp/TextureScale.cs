using System;
using UnityEngine;

// Token: 0x020005E6 RID: 1510
public class TextureScale
{
	// Token: 0x06002625 RID: 9765 RVA: 0x00019D49 File Offset: 0x00017F49
	public static void smethod_0(Texture2D texture2D_0, int int_0, int int_1)
	{
		TextureScale.smethod_4(texture2D_0, int_0, int_1, false);
	}

	// Token: 0x06002626 RID: 9766 RVA: 0x00019D54 File Offset: 0x00017F54
	public static void smethod_1(Texture2D texture2D_0, int int_0, int int_1, Rect rect_0)
	{
		TextureScale.smethod_4(texture2D_0, int_0, int_1, true);
	}

	// Token: 0x06002627 RID: 9767 RVA: 0x000B8248 File Offset: 0x000B6448
	public static void smethod_2(Texture2D texture2D_0, Texture2D texture2D_1, bool bool_0, Rect rect_0)
	{
		Rect rect = new Rect(0f, 0f, (float)texture2D_1.width, (float)texture2D_1.height);
		TextureScale.smethod_3(texture2D_0, texture2D_1, bool_0, rect_0, rect);
	}

	// Token: 0x06002628 RID: 9768 RVA: 0x000B8280 File Offset: 0x000B6480
	public static void smethod_3(Texture2D texture2D_0, Texture2D texture2D_1, bool bool_0, Rect rect_0, Rect rect_1)
	{
		TextureScale.srcRect = rect_0;
		int width = texture2D_1.width;
		int height = texture2D_1.height;
		int num = (int)TextureScale.srcRect.width;
		int num2 = (int)TextureScale.srcRect.height;
		TextureScale.texColors = texture2D_0.GetPixels();
		TextureScale.newColors = new Color[width * height];
		if (bool_0)
		{
			TextureScale.ratioX = 1f / (rect_1.width / (float)(num - 1));
			TextureScale.ratioY = 1f / (rect_1.height / (float)(num2 - 1));
		}
		else
		{
			TextureScale.ratioX = (float)num / (float)width;
			TextureScale.ratioY = (float)num2 / (float)height;
		}
		TextureScale.w = texture2D_0.width;
		TextureScale.w2 = width;
		TextureScale.ThreadData threadData = new TextureScale.ThreadData(0, height);
		if (bool_0)
		{
			TextureScale.smethod_5(threadData, rect_1);
		}
		else
		{
			TextureScale.smethod_6(threadData);
		}
		texture2D_1.Resize(width, height);
		texture2D_1.SetPixels(TextureScale.newColors);
		texture2D_1.Apply();
	}

	// Token: 0x06002629 RID: 9769 RVA: 0x000B8364 File Offset: 0x000B6564
	private static void smethod_4(Texture2D texture2D_0, int int_0, int int_1, bool bool_0)
	{
		Rect rect = new Rect(0f, 0f, (float)texture2D_0.width, (float)texture2D_0.height);
		TextureScale.smethod_2(texture2D_0, texture2D_0, bool_0, rect);
	}

	// Token: 0x0600262A RID: 9770 RVA: 0x000B839C File Offset: 0x000B659C
	public static void smethod_5(object object_0, Rect rect_0)
	{
		TextureScale.ThreadData threadData = (TextureScale.ThreadData)object_0;
		for (int i = threadData.start; i < threadData.end; i++)
		{
			int num = i * TextureScale.w2;
			for (int j = 0; j < TextureScale.w2; j++)
			{
				if ((float)j >= rect_0.x && (float)j <= rect_0.x + rect_0.width && (float)i >= rect_0.y && (float)i <= rect_0.y + rect_0.height)
				{
					int num2 = (int)Mathf.Floor(((float)i - rect_0.y) * TextureScale.ratioY);
					int num3 = num2 * TextureScale.w + (int)TextureScale.srcRect.y * TextureScale.w;
					int num4 = (num2 + 1) * TextureScale.w + (int)TextureScale.srcRect.y * TextureScale.w;
					int num5 = (int)Mathf.Floor(((float)j - rect_0.x) * TextureScale.ratioX) + (int)TextureScale.srcRect.x;
					float num6 = ((float)j - rect_0.x) * TextureScale.ratioX - (float)num5 + (float)((int)TextureScale.srcRect.x);
					float num7 = ((float)i - rect_0.y) * TextureScale.ratioY - (float)num2;
					TextureScale.newColors[num + j] = TextureScale.smethod_7(TextureScale.smethod_7(TextureScale.texColors[num3 + num5], TextureScale.texColors[num3 + num5 + 1], num6), TextureScale.smethod_7(TextureScale.texColors[num4 + num5], TextureScale.texColors[num4 + num5 + 1], num6), num7);
				}
				else
				{
					TextureScale.newColors[num + j] = new Color(0f, 0f, 0f, 0f);
				}
			}
		}
	}

	// Token: 0x0600262B RID: 9771 RVA: 0x000B858C File Offset: 0x000B678C
	public static void smethod_6(object object_0)
	{
		TextureScale.ThreadData threadData = (TextureScale.ThreadData)object_0;
		for (int i = threadData.start; i < threadData.end; i++)
		{
			int num = (int)(TextureScale.ratioY * (float)i) * TextureScale.w;
			int num2 = i * TextureScale.w2;
			for (int j = 0; j < TextureScale.w2; j++)
			{
				TextureScale.newColors[num2 + j] = TextureScale.texColors[(int)((float)num + TextureScale.ratioX * (float)j)];
			}
		}
	}

	// Token: 0x0600262C RID: 9772 RVA: 0x000B8614 File Offset: 0x000B6814
	private static Color smethod_7(Color color_0, Color color_1, float float_0)
	{
		return new Color(color_0.r + (color_1.r - color_0.r) * float_0, color_0.g + (color_1.g - color_0.g) * float_0, color_0.b + (color_1.b - color_0.b) * float_0, color_0.a + (color_1.a - color_0.a) * float_0);
	}

	// Token: 0x04001BCF RID: 7119
	private static Color[] texColors;

	// Token: 0x04001BD0 RID: 7120
	private static Color[] newColors;

	// Token: 0x04001BD1 RID: 7121
	private static int w;

	// Token: 0x04001BD2 RID: 7122
	private static float ratioX;

	// Token: 0x04001BD3 RID: 7123
	private static float ratioY;

	// Token: 0x04001BD4 RID: 7124
	private static int w2;

	// Token: 0x04001BD5 RID: 7125
	private static int finishCount;

	// Token: 0x04001BD6 RID: 7126
	private static Rect srcRect;

	// Token: 0x020005E7 RID: 1511
	public class ThreadData
	{
		// Token: 0x0600262D RID: 9773 RVA: 0x00019D5F File Offset: 0x00017F5F
		public ThreadData(int int_0, int int_1)
		{
			this.start = int_0;
			this.end = int_1;
		}

		// Token: 0x04001BD7 RID: 7127
		public int start;

		// Token: 0x04001BD8 RID: 7128
		public int end;
	}
}
