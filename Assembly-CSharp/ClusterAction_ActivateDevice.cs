using System;
using UnityEngine;

// Token: 0x020004D5 RID: 1237
public class ClusterAction_ActivateDevice : ClusterAction
{
	// Token: 0x06002136 RID: 8502 RVA: 0x000A0A78 File Offset: 0x0009EC78
	public override object Clone()
	{
		ClusterAction_ActivateDevice clusterAction_ActivateDevice = ScriptableObject.CreateInstance(base.GetType()) as ClusterAction_ActivateDevice;
		clusterAction_ActivateDevice.m_device = this.m_device;
		clusterAction_ActivateDevice.m_executionOrder = this.m_executionOrder;
		return clusterAction_ActivateDevice;
	}

	// Token: 0x040015C8 RID: 5576
	public GameObject m_device;
}
