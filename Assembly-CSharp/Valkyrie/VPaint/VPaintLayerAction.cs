using System;
using UnityEngine;

namespace Valkyrie.VPaint
{
	// Token: 0x02000B8C RID: 2956
	[Serializable]
	public class VPaintLayerAction
	{
		// Token: 0x06004FE3 RID: 20451 RVA: 0x0015333C File Offset: 0x0015153C
		public void Apply(ref Color c, ref float t, VPaintActionType type)
		{
			HSBColor hsbcolor = new HSBColor(c);
			switch (type)
			{
			case VPaintActionType.HueShift:
				hsbcolor.h += this.hueAdjustment / 360f;
				if (1f < hsbcolor.h)
				{
					hsbcolor.h -= 1f;
				}
				c = hsbcolor.ToColor();
				break;
			case VPaintActionType.Saturation:
				hsbcolor.s *= this.saturationAdjustment;
				c = hsbcolor.ToColor();
				break;
			case VPaintActionType.Brightness:
				if (this.brightnessAdjustment < 1f)
				{
					hsbcolor.b = Mathf.Lerp(0f, hsbcolor.b, this.brightnessAdjustment);
				}
				else if (1f < this.brightnessAdjustment)
				{
					hsbcolor.b = Mathf.Lerp(hsbcolor.b, 1f, this.brightnessAdjustment - 1f);
				}
				c = hsbcolor.ToColor();
				break;
			case VPaintActionType.OpacityAdjustment:
				t = Mathf.Clamp01(t * this.opacityAdjustment);
				break;
			case VPaintActionType.Contrast:
				if (1f < this.contrastAdjustment)
				{
					c.a = Mathf.Pow(c.a + this.contrastThreshhold, this.contrastAdjustment) - this.contrastThreshhold;
					c.r = Mathf.Pow(c.r + this.contrastThreshhold, this.contrastAdjustment) - this.contrastThreshhold;
					c.g = Mathf.Pow(c.g + this.contrastThreshhold, this.contrastAdjustment) - this.contrastThreshhold;
					c.b = Mathf.Pow(c.b + this.contrastThreshhold, this.contrastAdjustment) - this.contrastThreshhold;
				}
				else
				{
					c = Color.Lerp(Color.grey, c, this.contrastAdjustment);
				}
				break;
			case VPaintActionType.TintColor:
			{
				float num = this.tintColorOpacity;
				if (this.tintUseValue)
				{
					if (this.tintInvertUseValue)
					{
						num *= hsbcolor.b;
					}
					else
					{
						num *= 1f - hsbcolor.b;
					}
				}
				c = Color.Lerp(c, this.tintColor, num);
				break;
			}
			}
		}

		// Token: 0x06004FE4 RID: 20452 RVA: 0x00153584 File Offset: 0x00151784
		public void ApplyTo(VPaintLayer layer, params VPaintActionType[] types)
		{
			foreach (VPaintVertexData vpaintVertexData in layer.paintData)
			{
				Color[] colors = vpaintVertexData.colors;
				float[] transparency = vpaintVertexData.transparency;
				for (int i = 0; i < colors.Length; i++)
				{
					foreach (VPaintActionType vpaintActionType in types)
					{
						this.Apply(ref colors[i], ref transparency[i], vpaintActionType);
					}
				}
				vpaintVertexData.colors = colors;
			}
		}

		// Token: 0x04003C19 RID: 15385
		public float hueAdjustment;

		// Token: 0x04003C1A RID: 15386
		public float saturationAdjustment = 1f;

		// Token: 0x04003C1B RID: 15387
		public float brightnessAdjustment = 1f;

		// Token: 0x04003C1C RID: 15388
		public float opacityAdjustment = 1f;

		// Token: 0x04003C1D RID: 15389
		public float contrastAdjustment = 1f;

		// Token: 0x04003C1E RID: 15390
		public float contrastThreshhold = 0.5f;

		// Token: 0x04003C1F RID: 15391
		public Color tintColor = Color.yellow;

		// Token: 0x04003C20 RID: 15392
		public float tintColorOpacity = 1f;

		// Token: 0x04003C21 RID: 15393
		public bool tintUseValue;

		// Token: 0x04003C22 RID: 15394
		public bool tintInvertUseValue;
	}
}
