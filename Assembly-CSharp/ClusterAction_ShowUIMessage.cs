using System;
using Core;
using UnityEngine;

// Token: 0x020004F2 RID: 1266
public class ClusterAction_ShowUIMessage : ClusterAction
{
	// Token: 0x0600215F RID: 8543 RVA: 0x000A0F94 File Offset: 0x0009F194
	public override object Clone()
	{
		ClusterAction_ShowUIMessage clusterAction_ShowUIMessage = ScriptableObject.CreateInstance(base.GetType()) as ClusterAction_ShowUIMessage;
		clusterAction_ShowUIMessage.m_message = this.m_message;
		clusterAction_ShowUIMessage.m_executionOrder = this.m_executionOrder;
		return clusterAction_ShowUIMessage;
	}

	// Token: 0x04001612 RID: 5650
	public UIMessage m_message = new UIMessage();
}
