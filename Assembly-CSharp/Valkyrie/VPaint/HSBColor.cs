using System;
using UnityEngine;

namespace Valkyrie.VPaint
{
	// Token: 0x02000B87 RID: 2951
	[Serializable]
	public struct HSBColor
	{
		// Token: 0x06004FCF RID: 20431 RVA: 0x000340A3 File Offset: 0x000322A3
		public HSBColor(float h, float s, float b, float a)
		{
			this.h = h;
			this.s = s;
			this.b = b;
			this.a = a;
		}

		// Token: 0x06004FD0 RID: 20432 RVA: 0x000340C2 File Offset: 0x000322C2
		public HSBColor(float h, float s, float b)
		{
			this.h = h;
			this.s = s;
			this.b = b;
			this.a = 1f;
		}

		// Token: 0x06004FD1 RID: 20433 RVA: 0x001529CC File Offset: 0x00150BCC
		public HSBColor(Color col)
		{
			HSBColor hsbcolor = HSBColor.FromColor(col);
			this.h = hsbcolor.h;
			this.s = hsbcolor.s;
			this.b = hsbcolor.b;
			this.a = hsbcolor.a;
		}

		// Token: 0x06004FD2 RID: 20434 RVA: 0x00152A14 File Offset: 0x00150C14
		public static HSBColor FromColor(Color color)
		{
			HSBColor hsbcolor = new HSBColor(0f, 0f, 0f, color.a);
			float r = color.r;
			float g = color.g;
			float num = color.b;
			float num2 = Mathf.Max(r, Mathf.Max(g, num));
			if (num2 <= 0f)
			{
				return hsbcolor;
			}
			float num3 = Mathf.Min(r, Mathf.Min(g, num));
			float num4 = num2 - num3;
			if (num2 > num3)
			{
				if (g == num2)
				{
					hsbcolor.h = (num - r) / num4 * 60f + 120f;
				}
				else if (num == num2)
				{
					hsbcolor.h = (r - g) / num4 * 60f + 240f;
				}
				else if (num > g)
				{
					hsbcolor.h = (g - num) / num4 * 60f + 360f;
				}
				else
				{
					hsbcolor.h = (g - num) / num4 * 60f;
				}
				if (hsbcolor.h < 0f)
				{
					hsbcolor.h += 360f;
				}
			}
			else
			{
				hsbcolor.h = 0f;
			}
			hsbcolor.h *= 0.0027777778f;
			hsbcolor.s = num4 / num2 * 1f;
			hsbcolor.b = num2;
			return hsbcolor;
		}

		// Token: 0x06004FD3 RID: 20435 RVA: 0x00152B60 File Offset: 0x00150D60
		public static Color ToColor(HSBColor hsbColor)
		{
			float num = hsbColor.b;
			float num2 = hsbColor.b;
			float num3 = hsbColor.b;
			if (hsbColor.s != 0f)
			{
				float num4 = hsbColor.b;
				float num5 = hsbColor.b * hsbColor.s;
				float num6 = hsbColor.b - num5;
				float num7 = hsbColor.h * 360f;
				if (num7 < 60f)
				{
					num = num4;
					num2 = num7 * num5 / 60f + num6;
					num3 = num6;
				}
				else if (num7 < 120f)
				{
					num = -(num7 - 120f) * num5 / 60f + num6;
					num2 = num4;
					num3 = num6;
				}
				else if (num7 < 180f)
				{
					num = num6;
					num2 = num4;
					num3 = (num7 - 120f) * num5 / 60f + num6;
				}
				else if (num7 < 240f)
				{
					num = num6;
					num2 = -(num7 - 240f) * num5 / 60f + num6;
					num3 = num4;
				}
				else if (num7 < 300f)
				{
					num = (num7 - 240f) * num5 / 60f + num6;
					num2 = num6;
					num3 = num4;
				}
				else if (num7 <= 360f)
				{
					num = num4;
					num2 = num6;
					num3 = -(num7 - 360f) * num5 / 60f + num6;
				}
				else
				{
					num = 0f;
					num2 = 0f;
					num3 = 0f;
				}
			}
			return new Color(Mathf.Clamp01(num), Mathf.Clamp01(num2), Mathf.Clamp01(num3), hsbColor.a);
		}

		// Token: 0x06004FD4 RID: 20436 RVA: 0x000340E4 File Offset: 0x000322E4
		public Color ToColor()
		{
			return HSBColor.ToColor(this);
		}

		// Token: 0x06004FD5 RID: 20437 RVA: 0x00152CE0 File Offset: 0x00150EE0
		public override string ToString()
		{
			return string.Concat(new object[] { "H:", this.h, " S:", this.s, " B:", this.b });
		}

		// Token: 0x06004FD6 RID: 20438 RVA: 0x00152D3C File Offset: 0x00150F3C
		public static HSBColor Lerp(HSBColor a, HSBColor b, float t)
		{
			float num;
			for (num = Mathf.LerpAngle(a.h * 360f, b.h * 360f, t); num < 0f; num += 360f)
			{
			}
			while (num > 360f)
			{
				num -= 360f;
			}
			return new HSBColor(num / 360f, Mathf.Lerp(a.s, b.s, t), Mathf.Lerp(a.b, b.b, t), Mathf.Lerp(a.a, b.a, t));
		}

		// Token: 0x04003BFD RID: 15357
		public float h;

		// Token: 0x04003BFE RID: 15358
		public float s;

		// Token: 0x04003BFF RID: 15359
		public float b;

		// Token: 0x04003C00 RID: 15360
		public float a;
	}
}
