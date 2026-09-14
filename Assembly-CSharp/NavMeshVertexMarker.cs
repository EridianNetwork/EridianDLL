using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000551 RID: 1361
public class NavMeshVertexMarker : MonoBehaviour
{
	// Token: 0x06002311 RID: 8977 RVA: 0x000180AE File Offset: 0x000162AE
	private void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		Gizmos.DrawSphere(base.transform.position, this.m_markerSize);
	}

	// Token: 0x06002312 RID: 8978 RVA: 0x000180D0 File Offset: 0x000162D0
	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawCube(base.transform.position, 2f * this.m_markerSize * Vector3.one);
	}

	// Token: 0x06002313 RID: 8979 RVA: 0x00018102 File Offset: 0x00016302
	public void method_0(int int_0)
	{
		if (!this.m_samePositionVertices.Contains(int_0))
		{
			this.m_samePositionVertices.Add(int_0);
		}
	}

	// Token: 0x06002314 RID: 8980 RVA: 0x0001811E File Offset: 0x0001631E
	public void method_1(int int_0, int int_1)
	{
		if (!this.m_directNeighborVertices.Contains(int_0))
		{
			this.m_directNeighborVertices.Add(int_0);
		}
		if (!this.m_directNeighborVertices.Contains(int_1))
		{
			this.m_directNeighborVertices.Add(int_1);
		}
	}

	// Token: 0x040017B8 RID: 6072
	public float m_markerSize = 0.5f;

	// Token: 0x040017B9 RID: 6073
	public List<int> m_samePositionVertices = new List<int>();

	// Token: 0x040017BA RID: 6074
	public List<int> m_directNeighborVertices = new List<int>();
}
