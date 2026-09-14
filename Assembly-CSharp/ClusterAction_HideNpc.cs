using System;
using UnityEngine;

// Token: 0x020004DC RID: 1244
public class ClusterAction_HideNpc : ClusterAction
{
	// Token: 0x06002142 RID: 8514 RVA: 0x000A0BB4 File Offset: 0x0009EDB4
	public override object Clone()
	{
		ClusterAction_HideNpc clusterAction_HideNpc = ScriptableObject.CreateInstance(base.GetType()) as ClusterAction_HideNpc;
		clusterAction_HideNpc.m_bHide = this.m_bHide;
		clusterAction_HideNpc.m_executionOrder = this.m_executionOrder;
		return clusterAction_HideNpc;
	}

	// Token: 0x040015D0 RID: 5584
	public bool m_bHide = true;
}
