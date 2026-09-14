using System;
using UnityEngine;

// Token: 0x020004F4 RID: 1268
public class ClusterAction_SwitchPlayerInvincible : ClusterAction
{
	// Token: 0x06002163 RID: 8547 RVA: 0x000A1004 File Offset: 0x0009F204
	public override object Clone()
	{
		ClusterAction_SwitchPlayerInvincible clusterAction_SwitchPlayerInvincible = ScriptableObject.CreateInstance(base.GetType()) as ClusterAction_SwitchPlayerInvincible;
		clusterAction_SwitchPlayerInvincible.m_isInvulnerable = this.m_isInvulnerable;
		clusterAction_SwitchPlayerInvincible.m_executionOrder = this.m_executionOrder;
		return clusterAction_SwitchPlayerInvincible;
	}

	// Token: 0x04001614 RID: 5652
	public bool m_isInvulnerable;
}
