using System;
using UnityEngine;

// Token: 0x020000DE RID: 222
internal class QEMInput
{
	// Token: 0x040004C7 RID: 1223
	public float m_percentage = 0.5f;

	// Token: 0x040004C8 RID: 1224
	public float s_vertexCombineThreshold = 0.001f;

	// Token: 0x040004C9 RID: 1225
	public int s_boundaryPlaneWeight = 100;

	// Token: 0x040004CA RID: 1226
	public Vector2[] m_uv;

	// Token: 0x040004CB RID: 1227
	public float m_uvWeight;

	// Token: 0x040004CC RID: 1228
	public Vector2[] m_uv2;

	// Token: 0x040004CD RID: 1229
	public float m_uv2Weight;

	// Token: 0x040004CE RID: 1230
	public Vector3[] m_normal;

	// Token: 0x040004CF RID: 1231
	public float m_normalWeight;

	// Token: 0x040004D0 RID: 1232
	public Vector3[] m_vertex;

	// Token: 0x040004D1 RID: 1233
	public int[] m_triangle;
}
