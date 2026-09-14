using System;
using UnityEngine;

// Token: 0x020004DB RID: 1243
public class ClusterAction_GiveXP : ClusterAction
{
	// Token: 0x06002140 RID: 8512 RVA: 0x000A0B70 File Offset: 0x0009ED70
	public override object Clone()
	{
		ClusterAction_GiveXP clusterAction_GiveXP = ScriptableObject.CreateInstance(base.GetType()) as ClusterAction_GiveXP;
		clusterAction_GiveXP.m_xpBonus = this.m_xpBonus;
		clusterAction_GiveXP.m_maxLevelRewarded = this.m_maxLevelRewarded;
		clusterAction_GiveXP.m_executionOrder = this.m_executionOrder;
		return clusterAction_GiveXP;
	}

	// Token: 0x040015CE RID: 5582
	public int m_xpBonus;

	// Token: 0x040015CF RID: 5583
	public int m_maxLevelRewarded;
}
