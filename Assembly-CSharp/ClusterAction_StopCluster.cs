using System;
using UnityEngine;

// Token: 0x020004F3 RID: 1267
public class ClusterAction_StopCluster : ClusterAction
{
	// Token: 0x06002161 RID: 8545 RVA: 0x000A0FCC File Offset: 0x0009F1CC
	public override object Clone()
	{
		ClusterAction_StopCluster clusterAction_StopCluster = ScriptableObject.CreateInstance(base.GetType()) as ClusterAction_StopCluster;
		clusterAction_StopCluster.m_stopCluster = this.m_stopCluster;
		clusterAction_StopCluster.m_executionOrder = this.m_executionOrder;
		return clusterAction_StopCluster;
	}

	// Token: 0x04001613 RID: 5651
	public Cluster m_stopCluster;
}
