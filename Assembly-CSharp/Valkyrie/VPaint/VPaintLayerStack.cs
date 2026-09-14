using System;
using System.Collections.Generic;
using UnityEngine;

namespace Valkyrie.VPaint
{
	// Token: 0x02000B8D RID: 2957
	[Serializable]
	public class VPaintLayerStack
	{
		// Token: 0x06004FE6 RID: 20454 RVA: 0x00034104 File Offset: 0x00032304
		public void Clear()
		{
			this.layers.Clear();
		}

		// Token: 0x06004FE7 RID: 20455 RVA: 0x0015362C File Offset: 0x0015182C
		public VPaintLayerStack Clone()
		{
			VPaintLayerStack vpaintLayerStack = new VPaintLayerStack();
			foreach (VPaintLayer vpaintLayer in this.layers)
			{
				vpaintLayerStack.layers.Add(vpaintLayer.Clone());
			}
			return vpaintLayerStack;
		}

		// Token: 0x06004FE8 RID: 20456 RVA: 0x00153690 File Offset: 0x00151890
		public VPaintLayer NewLayer()
		{
			VPaintLayer vpaintLayer = new VPaintLayer();
			this.layers.Add(vpaintLayer);
			return vpaintLayer;
		}

		// Token: 0x06004FE9 RID: 20457 RVA: 0x001536B0 File Offset: 0x001518B0
		public List<VPaintLayer> GetActiveLayers()
		{
			List<VPaintLayer> list = new List<VPaintLayer>();
			foreach (VPaintLayer vpaintLayer in this.layers)
			{
				if (vpaintLayer.enabled)
				{
					list.Add(vpaintLayer);
				}
			}
			return list;
		}

		// Token: 0x06004FEA RID: 20458 RVA: 0x00034111 File Offset: 0x00032311
		public VPaintLayer GetMergedLayer()
		{
			return this.GetMergedLayer(null);
		}

		// Token: 0x06004FEB RID: 20459 RVA: 0x00153714 File Offset: 0x00151914
		public VPaintLayer GetMergedLayer(VPaintLayer baseLayer)
		{
			VPaintLayer vpaintLayer;
			if (baseLayer == null)
			{
				vpaintLayer = new VPaintLayer();
			}
			else
			{
				vpaintLayer = baseLayer.Clone();
			}
			for (int i = 0; i < this.layers.Count; i++)
			{
				VPaintLayer vpaintLayer2 = this.layers[i];
				if (vpaintLayer2.enabled)
				{
					vpaintLayer.Merge(vpaintLayer2, default(Color));
				}
			}
			return vpaintLayer;
		}

		// Token: 0x06004FEC RID: 20460 RVA: 0x00153774 File Offset: 0x00151974
		public void Collapse()
		{
			this.layers = new List<VPaintLayer> { this.GetMergedLayer() };
		}

		// Token: 0x06004FED RID: 20461 RVA: 0x0015379C File Offset: 0x0015199C
		public void Sanitize()
		{
			foreach (VPaintLayer vpaintLayer in this.layers)
			{
				vpaintLayer.Sanitize();
			}
		}

		// Token: 0x06004FEE RID: 20462 RVA: 0x001537F0 File Offset: 0x001519F0
		public void Sanitize(List<IVPaintIdentifier> colorers)
		{
			foreach (VPaintLayer vpaintLayer in this.layers)
			{
				vpaintLayer.Sanitize(colorers);
			}
		}

		// Token: 0x04003C23 RID: 15395
		public List<VPaintLayer> layers = new List<VPaintLayer>();

		// Token: 0x04003C24 RID: 15396
		public int currentLayer;
	}
}
