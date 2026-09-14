using System;
using UnityEngine;

// Token: 0x020004FF RID: 1279
public class ClusterCondition_ObjectsDamaged : ClusterCondition
{
	// Token: 0x0600217C RID: 8572 RVA: 0x000A1280 File Offset: 0x0009F480
	public override object Clone()
	{
		ClusterCondition_ObjectsDamaged clusterCondition_ObjectsDamaged = ScriptableObject.CreateInstance(base.GetType()) as ClusterCondition_ObjectsDamaged;
		clusterCondition_ObjectsDamaged.m_object = this.m_object;
		clusterCondition_ObjectsDamaged.m_damagePercent = this.m_damagePercent;
		clusterCondition_ObjectsDamaged.m_ownerCluster = this.m_ownerCluster;
		clusterCondition_ObjectsDamaged.m_isValid = this.m_isValid;
		return clusterCondition_ObjectsDamaged;
	}

	// Token: 0x04001629 RID: 5673
	public GameObject m_object;

	// Token: 0x0400162A RID: 5674
	public float m_damagePercent = 1f;
}
