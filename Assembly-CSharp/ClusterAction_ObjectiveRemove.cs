using System;
using UnityEngine;

// Token: 0x020004E4 RID: 1252
public class ClusterAction_ObjectiveRemove : ClusterAction
{
	// Token: 0x0600214F RID: 8527 RVA: 0x000A0D4C File Offset: 0x0009EF4C
	public override object Clone()
	{
		ClusterAction_ObjectiveRemove clusterAction_ObjectiveRemove = ScriptableObject.CreateInstance(base.GetType()) as ClusterAction_ObjectiveRemove;
		clusterAction_ObjectiveRemove.m_objectiveId = this.m_objectiveId;
		clusterAction_ObjectiveRemove.m_executionOrder = this.m_executionOrder;
		return clusterAction_ObjectiveRemove;
	}

	// Token: 0x040015E3 RID: 5603
	public string m_objectiveId;

	// Token: 0x040015E4 RID: 5604
	public bool m_isSuccess;
}
