using System;
using UnityEngine;

// Token: 0x020004DE RID: 1246
public class ClusterAction_LevelObjectActivation : ClusterAction
{
	// Token: 0x06002146 RID: 8518 RVA: 0x000A0C24 File Offset: 0x0009EE24
	public override object Clone()
	{
		ClusterAction_LevelObjectActivation clusterAction_LevelObjectActivation = ScriptableObject.CreateInstance(base.GetType()) as ClusterAction_LevelObjectActivation;
		clusterAction_LevelObjectActivation.m_levelObject = this.m_levelObject;
		clusterAction_LevelObjectActivation.m_activate = this.m_activate;
		clusterAction_LevelObjectActivation.m_executionOrder = this.m_executionOrder;
		return clusterAction_LevelObjectActivation;
	}

	// Token: 0x040015D2 RID: 5586
	public LevelObjectSync m_levelObject;

	// Token: 0x040015D3 RID: 5587
	public LevelObjectSync.LevelObjectSyncState m_activate = LevelObjectSync.LevelObjectSyncState.Activated;
}
