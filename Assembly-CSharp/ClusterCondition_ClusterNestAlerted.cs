using System;
using UnityEngine;

// Token: 0x020004FC RID: 1276
public class ClusterCondition_ClusterNestAlerted : ClusterCondition
{
	// Token: 0x06002176 RID: 8566 RVA: 0x000A1184 File Offset: 0x0009F384
	public override object Clone()
	{
		ClusterCondition_ClusterNestAlerted clusterCondition_ClusterNestAlerted = ScriptableObject.CreateInstance(base.GetType()) as ClusterCondition_ClusterNestAlerted;
		clusterCondition_ClusterNestAlerted.m_nest = this.m_nest;
		clusterCondition_ClusterNestAlerted.m_ownerCluster = this.m_ownerCluster;
		clusterCondition_ClusterNestAlerted.m_isValid = this.m_isValid;
		return clusterCondition_ClusterNestAlerted;
	}

	// Token: 0x04001622 RID: 5666
	public Cluster m_nest;
}
