using System;
using UnityEngine;

// Token: 0x020004FD RID: 1277
public class ClusterCondition_LevelTrigger : ClusterCondition
{
	// Token: 0x06002178 RID: 8568 RVA: 0x000A11C8 File Offset: 0x0009F3C8
	public override object Clone()
	{
		ClusterCondition_LevelTrigger clusterCondition_LevelTrigger = ScriptableObject.CreateInstance(base.GetType()) as ClusterCondition_LevelTrigger;
		clusterCondition_LevelTrigger.m_trigger = this.m_trigger;
		clusterCondition_LevelTrigger.m_ownerCluster = this.m_ownerCluster;
		clusterCondition_LevelTrigger.m_isValid = this.m_isValid;
		return clusterCondition_LevelTrigger;
	}

	// Token: 0x04001623 RID: 5667
	public LevelTrigger m_trigger;
}
