using System;
using UnityEngine;

// Token: 0x020004EC RID: 1260
public class ClusterAction_RespawnPlayers : ClusterAction
{
	// Token: 0x06002156 RID: 8534 RVA: 0x000A0EA8 File Offset: 0x0009F0A8
	public override object Clone()
	{
		ClusterAction_RespawnPlayers clusterAction_RespawnPlayers = ScriptableObject.CreateInstance(base.GetType()) as ClusterAction_RespawnPlayers;
		clusterAction_RespawnPlayers.m_onlyRespawnDeadPlayer = this.m_onlyRespawnDeadPlayer;
		clusterAction_RespawnPlayers.m_executionOrder = this.m_executionOrder;
		return clusterAction_RespawnPlayers;
	}

	// Token: 0x0400160A RID: 5642
	public bool m_onlyRespawnDeadPlayer = true;
}
