using System;
using UnityEngine;

// Token: 0x020004F0 RID: 1264
public class ClusterAction_SetPlayerActions : ClusterAction
{
	// Token: 0x0600215B RID: 8539 RVA: 0x000A0F24 File Offset: 0x0009F124
	public override object Clone()
	{
		ClusterAction_SetPlayerActions clusterAction_SetPlayerActions = ScriptableObject.CreateInstance(base.GetType()) as ClusterAction_SetPlayerActions;
		clusterAction_SetPlayerActions.m_actions = this.m_actions;
		clusterAction_SetPlayerActions.m_executionOrder = this.m_executionOrder;
		return clusterAction_SetPlayerActions;
	}

	// Token: 0x04001610 RID: 5648
	public int m_actions;
}
