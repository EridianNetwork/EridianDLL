using System;
using UnityEngine;

// Token: 0x02000500 RID: 1280
public class ClusterCondition_ObjectsDestroyed : ClusterCondition
{
	// Token: 0x0600217E RID: 8574 RVA: 0x000A12D0 File Offset: 0x0009F4D0
	public override object Clone()
	{
		ClusterCondition_ObjectsDestroyed clusterCondition_ObjectsDestroyed = ScriptableObject.CreateInstance(base.GetType()) as ClusterCondition_ObjectsDestroyed;
		clusterCondition_ObjectsDestroyed.m_object = this.m_object;
		clusterCondition_ObjectsDestroyed.m_ownerCluster = this.m_ownerCluster;
		clusterCondition_ObjectsDestroyed.m_isValid = this.m_isValid;
		return clusterCondition_ObjectsDestroyed;
	}

	// Token: 0x0400162B RID: 5675
	public GameObject m_object;
}
