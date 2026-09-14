using System;
using UnityEngine;

// Token: 0x020004F1 RID: 1265
public class ClusterAction_ShakeCamera : ClusterAction
{
	// Token: 0x0600215D RID: 8541 RVA: 0x000A0F5C File Offset: 0x0009F15C
	public override object Clone()
	{
		ClusterAction_ShakeCamera clusterAction_ShakeCamera = ScriptableObject.CreateInstance(base.GetType()) as ClusterAction_ShakeCamera;
		clusterAction_ShakeCamera.m_intensity = this.m_intensity;
		clusterAction_ShakeCamera.m_executionOrder = this.m_executionOrder;
		return clusterAction_ShakeCamera;
	}

	// Token: 0x04001611 RID: 5649
	public BadAssFPSCamera.ShakeType m_intensity;
}
