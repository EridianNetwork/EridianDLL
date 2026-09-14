using System;
using UnityEngine;

// Token: 0x02000502 RID: 1282
public class ClusterCondition_PlayerAction : ClusterCondition
{
	// Token: 0x06002183 RID: 8579 RVA: 0x000A1358 File Offset: 0x0009F558
	public override object Clone()
	{
		ClusterCondition_PlayerAction clusterCondition_PlayerAction = ScriptableObject.CreateInstance(base.GetType()) as ClusterCondition_PlayerAction;
		clusterCondition_PlayerAction.m_action = this.m_action;
		clusterCondition_PlayerAction.m_ownerCluster = this.m_ownerCluster;
		clusterCondition_PlayerAction.m_isValid = this.m_isValid;
		return clusterCondition_PlayerAction;
	}

	// Token: 0x0400162D RID: 5677
	private PlayerAction m_action = PlayerAction.Aim;
}
