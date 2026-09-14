using System;
using UnityEngine;

// Token: 0x020004DD RID: 1245
public class ClusterAction_KillAllNpcs : ClusterAction
{
	// Token: 0x06002144 RID: 8516 RVA: 0x000A0BEC File Offset: 0x0009EDEC
	public override object Clone()
	{
		ClusterAction_KillAllNpcs clusterAction_KillAllNpcs = ScriptableObject.CreateInstance(base.GetType()) as ClusterAction_KillAllNpcs;
		clusterAction_KillAllNpcs.m_cluster = this.m_cluster;
		clusterAction_KillAllNpcs.m_executionOrder = this.m_executionOrder;
		return clusterAction_KillAllNpcs;
	}

	// Token: 0x040015D1 RID: 5585
	public Cluster m_cluster;
}
