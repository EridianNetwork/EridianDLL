using System;
using UnityEngine;

// Token: 0x020004EE RID: 1262
public class ClusterAction_SetNavMeshLayer : ClusterAction
{
	// Token: 0x06002159 RID: 8537 RVA: 0x000A0EE0 File Offset: 0x0009F0E0
	public override object Clone()
	{
		ClusterAction_SetNavMeshLayer clusterAction_SetNavMeshLayer = ScriptableObject.CreateInstance(base.GetType()) as ClusterAction_SetNavMeshLayer;
		clusterAction_SetNavMeshLayer.m_navmeshLayer = this.m_navmeshLayer;
		clusterAction_SetNavMeshLayer.m_setAction = this.m_setAction;
		clusterAction_SetNavMeshLayer.m_executionOrder = this.m_executionOrder;
		return clusterAction_SetNavMeshLayer;
	}

	// Token: 0x0400160B RID: 5643
	public string m_navmeshLayer;

	// Token: 0x0400160C RID: 5644
	public ClusterAction_SetNavMeshLayer.ESetAction m_setAction;

	// Token: 0x020004EF RID: 1263
	public enum ESetAction
	{
		// Token: 0x0400160E RID: 5646
		Enable,
		// Token: 0x0400160F RID: 5647
		Disable
	}
}
