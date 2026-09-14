using System;
using UnityEngine;

namespace Valkyrie.VPaint
{
	// Token: 0x02000B93 RID: 2963
	[Serializable]
	public class VPaintVertexCache
	{
		// Token: 0x17000816 RID: 2070
		// (get) Token: 0x06005008 RID: 20488 RVA: 0x00034167 File Offset: 0x00032367
		// (set) Token: 0x06005009 RID: 20489 RVA: 0x00034174 File Offset: 0x00032374
		public VPaintObject vpaintObject
		{
			get
			{
				return this.obj as VPaintObject;
			}
			set
			{
				this.obj = value;
			}
		}

		// Token: 0x04003CB5 RID: 15541
		public global::UnityEngine.Object obj;

		// Token: 0x04003CB6 RID: 15542
		public Vector3[] vertices;
	}
}
