using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020004E2 RID: 1250
public class ClusterAction_NextRound : ClusterAction
{
	// Token: 0x0600214B RID: 8523 RVA: 0x000A0CAC File Offset: 0x0009EEAC
	public override object Clone()
	{
		ClusterAction_NextRound clusterAction_NextRound = ScriptableObject.CreateInstance(base.GetType()) as ClusterAction_NextRound;
		clusterAction_NextRound.m_targetScore = this.m_targetScore;
		clusterAction_NextRound.m_timer = this.m_timer;
		clusterAction_NextRound.m_resetSceneList = this.m_resetSceneList;
		clusterAction_NextRound.m_executionOrder = this.m_executionOrder;
		return clusterAction_NextRound;
	}

	// Token: 0x040015DD RID: 5597
	public int m_targetScore = 10;

	// Token: 0x040015DE RID: 5598
	public ClaptrapTimerCluster m_timer;

	// Token: 0x040015DF RID: 5599
	public List<Scene> m_resetSceneList = new List<Scene>();
}
