using System;
using UnityEngine;

// Token: 0x02000505 RID: 1285
public class ClusterCondition_ScoreReached : ClusterCondition
{
	// Token: 0x06002189 RID: 8585 RVA: 0x000A143C File Offset: 0x0009F63C
	public override object Clone()
	{
		ClusterCondition_ScoreReached clusterCondition_ScoreReached = ScriptableObject.CreateInstance(base.GetType()) as ClusterCondition_ScoreReached;
		clusterCondition_ScoreReached.m_thresholdType = this.m_thresholdType;
		clusterCondition_ScoreReached.m_countToReach = this.m_countToReach;
		clusterCondition_ScoreReached.m_ownerCluster = this.m_ownerCluster;
		clusterCondition_ScoreReached.m_isValid = this.m_isValid;
		return clusterCondition_ScoreReached;
	}

	// Token: 0x04001632 RID: 5682
	public ClusterCondition_ScoreReached.ThresholdType m_thresholdType;

	// Token: 0x04001633 RID: 5683
	public int m_countToReach = 1000;

	// Token: 0x02000506 RID: 1286
	public enum ThresholdType
	{
		// Token: 0x04001635 RID: 5685
		Score,
		// Token: 0x04001636 RID: 5686
		Kill
	}
}
