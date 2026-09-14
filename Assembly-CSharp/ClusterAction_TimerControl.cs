using System;
using UnityEngine;

// Token: 0x020004F5 RID: 1269
public class ClusterAction_TimerControl : ClusterAction
{
	// Token: 0x06002165 RID: 8549 RVA: 0x000A103C File Offset: 0x0009F23C
	public override object Clone()
	{
		ClusterAction_TimerControl clusterAction_TimerControl = ScriptableObject.CreateInstance(base.GetType()) as ClusterAction_TimerControl;
		clusterAction_TimerControl.m_timer = this.m_timer;
		clusterAction_TimerControl.m_action = this.m_action;
		clusterAction_TimerControl.m_executionOrder = this.m_executionOrder;
		return clusterAction_TimerControl;
	}

	// Token: 0x04001615 RID: 5653
	public TimerCluster m_timer;

	// Token: 0x04001616 RID: 5654
	public ClusterAction_TimerControl.TimerAction m_action;

	// Token: 0x020004F6 RID: 1270
	public enum TimerAction
	{
		// Token: 0x04001618 RID: 5656
		Stop,
		// Token: 0x04001619 RID: 5657
		Resume,
		// Token: 0x0400161A RID: 5658
		Reset
	}
}
