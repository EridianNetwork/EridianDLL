using System;
using UnityEngine;

// Token: 0x020004D6 RID: 1238
public class ClusterAction_ActivateNpcCharge : ClusterAction
{
	// Token: 0x06002138 RID: 8504 RVA: 0x000A0AB0 File Offset: 0x0009ECB0
	public override object Clone()
	{
		ClusterAction_ActivateNpcCharge clusterAction_ActivateNpcCharge = ScriptableObject.CreateInstance(base.GetType()) as ClusterAction_ActivateNpcCharge;
		clusterAction_ActivateNpcCharge.m_bActiveCharge = this.m_bActiveCharge;
		clusterAction_ActivateNpcCharge.m_teleportPoint = this.m_teleportPoint;
		clusterAction_ActivateNpcCharge.m_executionOrder = this.m_executionOrder;
		return clusterAction_ActivateNpcCharge;
	}

	// Token: 0x040015C9 RID: 5577
	public bool m_bActiveCharge = true;

	// Token: 0x040015CA RID: 5578
	public GameObject m_teleportPoint;
}
