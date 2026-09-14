using System;
using UnityEngine;

// Token: 0x02000504 RID: 1284
public class ClusterCondition_RemainingNpc : ClusterCondition
{
	// Token: 0x06002187 RID: 8583 RVA: 0x000A13EC File Offset: 0x0009F5EC
	public override object Clone()
	{
		ClusterCondition_RemainingNpc clusterCondition_RemainingNpc = ScriptableObject.CreateInstance(base.GetType()) as ClusterCondition_RemainingNpc;
		clusterCondition_RemainingNpc.m_cluster = this.m_cluster;
		clusterCondition_RemainingNpc.m_remainingNpc = this.m_remainingNpc;
		clusterCondition_RemainingNpc.m_ownerCluster = this.m_ownerCluster;
		clusterCondition_RemainingNpc.m_isValid = this.m_isValid;
		return clusterCondition_RemainingNpc;
	}

	// Token: 0x04001630 RID: 5680
	public Cluster m_cluster;

	// Token: 0x04001631 RID: 5681
	public int m_remainingNpc;
}
