using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Valkyrie.VPaint
{
	[Serializable]
	public class VPaintLayer
	{
		public bool foldout;

		public string name = "Layer";

		public int tag;

		public List<VPaintVertexData> paintData = new List<VPaintVertexData>();

		public VPaintBlendMode blendMode;

		public bool enabled = true;

		public float opacity = 1f;

		public bool maskR = true;

		public bool maskG = true;

		public bool maskB = true;

		public bool maskA = true;

		public int selectedColor;

		public VPaintVertexData GetOrCreate(VPaintObject vc)
		{
			if (vc == null)
			{
				return null;
			}
			VPaintVertexData vPaintVertexData = Get(vc);
			if (vPaintVertexData != null)
			{
				return vPaintVertexData;
			}
			vPaintVertexData = new VPaintVertexData();
			vPaintVertexData.vpaintObject = vc;
			Color[] array = vc.method_1();
			vPaintVertexData.colors = new Color[array.Length];
			vPaintVertexData.transparency = new float[array.Length];
			paintData.Add(vPaintVertexData);
			return vPaintVertexData;
		}

		public VPaintVertexData Get(IVPaintIdentifier vc)
		{
			if (vc == null)
			{
				return null;
			}
			int num = 0;
			VPaintVertexData vPaintVertexData;
			while (true)
			{
				if (num < paintData.Count)
				{
					vPaintVertexData = paintData[num];
					if (vc.IsEqualTo(vPaintVertexData.identifier))
					{
						break;
					}
					num++;
					continue;
				}
				return null;
			}
			return vPaintVertexData;
		}

		public void Remove(IVPaintIdentifier vc)
		{
			for (int i = 0; i < paintData.Count; i++)
			{
				VPaintVertexData vPaintVertexData = paintData[i];
				if (vPaintVertexData.identifier.IsEqualTo(vc))
				{
					paintData.RemoveAt(i);
					i--;
				}
			}
		}

		public VPaintLayer Clone()
		{
			VPaintLayer vPaintLayer = new VPaintLayer();
			foreach (VPaintVertexData paintDatum in paintData)
			{
				vPaintLayer.paintData.Add(paintDatum.Clone());
			}
			vPaintLayer.blendMode = blendMode;
			vPaintLayer.name = name;
			vPaintLayer.tag = tag;
			vPaintLayer.opacity = opacity;
			vPaintLayer.enabled = enabled;
			vPaintLayer.maskR = maskR;
			vPaintLayer.maskG = maskG;
			vPaintLayer.maskB = maskB;
			vPaintLayer.maskA = maskA;
			return vPaintLayer;
		}

		public void Merge(VPaintLayer layer, [Optional] Color baseColor)
		{
			foreach (VPaintVertexData paintDatum in layer.paintData)
			{
				VPaintVertexData vPaintVertexData = Get(paintDatum.identifier);
				Color[] array = null;
				float[] array2 = null;
				if (vPaintVertexData != null)
				{
					array = vPaintVertexData.colors;
					array2 = vPaintVertexData.transparency;
				}
				else
				{
					array = new Color[paintDatum.colors.Length];
					for (int i = 0; i < array.Length; i++)
					{
						array[i] = baseColor;
					}
					array2 = new float[paintDatum.transparency.Length];
					vPaintVertexData = new VPaintVertexData();
					vPaintVertexData.colors = array;
					vPaintVertexData.transparency = array2;
					vPaintVertexData.colorer = paintDatum.colorer;
					paintData.Add(vPaintVertexData);
				}
				VPaintUtility.MergeColors(array, array2, paintDatum.colors, paintDatum.transparency, layer.blendMode, layer.opacity, layer.maskR, layer.maskG, layer.maskB, layer.maskA);
			}
		}

		public void Apply()
		{
			foreach (VPaintVertexData paintDatum in paintData)
			{
				if (!(paintDatum.vpaintObject == null))
				{
					paintDatum.vpaintObject.method_3(paintDatum.colors);
				}
			}
		}

		public void Sanitize()
		{
			for (int i = 0; i < paintData.Count; i++)
			{
				VPaintVertexData vPaintVertexData = paintData[i];
				if (vPaintVertexData.colorer == null)
				{
					paintData.RemoveAt(i--);
				}
			}
		}

		public void Sanitize(List<IVPaintIdentifier> colorers)
		{
			for (int i = 0; i < paintData.Count; i++)
			{
				VPaintVertexData vPaintVertexData = paintData[i];
				if (!vPaintVertexData.colorer)
				{
					paintData.RemoveAt(i--);
					continue;
				}
				bool flag = false;
				IVPaintIdentifier identifier = vPaintVertexData.identifier;
				for (int j = 0; j < colorers.Count; j++)
				{
					IVPaintIdentifier obj = colorers[j];
					if (identifier.IsEqualTo(obj))
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					paintData.RemoveAt(i--);
				}
			}
		}

		public void CleanZeroTransparency()
		{
			for (int i = 0; i < paintData.Count; i++)
			{
				VPaintVertexData vPaintVertexData = paintData[i];
				float[] transparency = vPaintVertexData.transparency;
				int num = 0;
				while (true)
				{
					if (num < transparency.Length)
					{
						float num2 = transparency[num];
						if (num2 != 0f)
						{
							break;
						}
						num++;
						continue;
					}
					paintData.RemoveAt(i--);
					break;
				}
			}
		}
	}
}
