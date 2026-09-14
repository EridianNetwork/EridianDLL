using System;
using UnityEngine;

// Token: 0x020004D8 RID: 1240
public class ClusterAction_DisplayEchoMessage : ClusterAction
{
	// Token: 0x0600213B RID: 8507 RVA: 0x000A0AF4 File Offset: 0x0009ECF4
	public override object Clone()
	{
		ClusterAction_DisplayEchoMessage clusterAction_DisplayEchoMessage = ScriptableObject.CreateInstance(base.GetType()) as ClusterAction_DisplayEchoMessage;
		clusterAction_DisplayEchoMessage.m_echoId = this.m_echoId;
		clusterAction_DisplayEchoMessage.m_executionOrder = this.m_executionOrder;
		return clusterAction_DisplayEchoMessage;
	}

	// Token: 0x040015CB RID: 5579
	public string m_echoId;
}
