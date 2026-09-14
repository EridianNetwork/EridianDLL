using System;
using UnityEngine;
using XsdSettings;

// Token: 0x02000503 RID: 1283
public class ClusterCondition_RemainingAmmo : ClusterCondition
{
	// Token: 0x06002185 RID: 8581 RVA: 0x000A139C File Offset: 0x0009F59C
	public override object Clone()
	{
		ClusterCondition_RemainingAmmo clusterCondition_RemainingAmmo = ScriptableObject.CreateInstance(base.GetType()) as ClusterCondition_RemainingAmmo;
		clusterCondition_RemainingAmmo.m_ammoType = this.m_ammoType;
		clusterCondition_RemainingAmmo.m_count = this.m_count;
		clusterCondition_RemainingAmmo.m_ownerCluster = this.m_ownerCluster;
		clusterCondition_RemainingAmmo.m_isValid = this.m_isValid;
		return clusterCondition_RemainingAmmo;
	}

	// Token: 0x0400162E RID: 5678
	public AmmoType m_ammoType;

	// Token: 0x0400162F RID: 5679
	public int m_count = 10;
}
