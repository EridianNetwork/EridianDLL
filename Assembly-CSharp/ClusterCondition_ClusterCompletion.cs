using System;
using UnityEngine;

// Token: 0x020004FB RID: 1275
public class ClusterCondition_ClusterCompletion : ClusterCondition
{
	// Token: 0x06002174 RID: 8564 RVA: 0x000A1140 File Offset: 0x0009F340
	public override object Clone()
	{
		ClusterCondition_ClusterCompletion clusterCondition_ClusterCompletion = ScriptableObject.CreateInstance(base.GetType()) as ClusterCondition_ClusterCompletion;
		clusterCondition_ClusterCompletion.m_cluster = this.m_cluster;
		clusterCondition_ClusterCompletion.m_ownerCluster = this.m_ownerCluster;
		clusterCondition_ClusterCompletion.m_isValid = this.m_isValid;
		return clusterCondition_ClusterCompletion;
	}

	// Token: 0x04001621 RID: 5665
	public Scene m_cluster;
}
