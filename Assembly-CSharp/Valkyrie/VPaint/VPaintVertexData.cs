using System;
using UnityEngine;

namespace Valkyrie.VPaint
{
	// Token: 0x02000B94 RID: 2964
	[Serializable]
	public class VPaintVertexData
	{
		// Token: 0x17000817 RID: 2071
		// (get) Token: 0x0600500B RID: 20491 RVA: 0x0003417D File Offset: 0x0003237D
		// (set) Token: 0x0600500C RID: 20492 RVA: 0x0003418A File Offset: 0x0003238A
		public IVPaintIdentifier identifier
		{
			get
			{
				return this.colorer as IVPaintIdentifier;
			}
			set
			{
				this.colorer = value as global::UnityEngine.Object;
			}
		}

		// Token: 0x17000818 RID: 2072
		// (get) Token: 0x0600500D RID: 20493 RVA: 0x00034198 File Offset: 0x00032398
		// (set) Token: 0x0600500E RID: 20494 RVA: 0x000341A5 File Offset: 0x000323A5
		public VPaintObject vpaintObject
		{
			get
			{
				return this.colorer as VPaintObject;
			}
			set
			{
				this.colorer = value;
			}
		}

		// Token: 0x0600500F RID: 20495 RVA: 0x00154B3C File Offset: 0x00152D3C
		public VPaintVertexData Clone()
		{
			VPaintVertexData vpaintVertexData = new VPaintVertexData();
			vpaintVertexData.colorer = this.colorer;
			vpaintVertexData.colors = new Color[this.colors.Length];
			vpaintVertexData.transparency = new float[this.colors.Length];
			for (int i = 0; i < this.colors.Length; i++)
			{
				vpaintVertexData.colors[i] = this.colors[i];
				vpaintVertexData.transparency[i] = this.transparency[i];
			}
			return vpaintVertexData;
		}

		// Token: 0x04003CB7 RID: 15543
		public global::UnityEngine.Object colorer;

		// Token: 0x04003CB8 RID: 15544
		public Color[] colors;

		// Token: 0x04003CB9 RID: 15545
		public float[] transparency;
	}
}
