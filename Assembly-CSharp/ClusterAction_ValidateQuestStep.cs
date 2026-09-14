using System;
using UnityEngine;

// Token: 0x020004F8 RID: 1272
public class ClusterAction_ValidateQuestStep : ClusterAction
{
	// Token: 0x06002169 RID: 8553 RVA: 0x000A10C4 File Offset: 0x0009F2C4
	public override object Clone()
	{
		ClusterAction_ValidateQuestStep clusterAction_ValidateQuestStep = ScriptableObject.CreateInstance(base.GetType()) as ClusterAction_ValidateQuestStep;
		clusterAction_ValidateQuestStep.m_questId = this.m_questId;
		clusterAction_ValidateQuestStep.m_stepId = this.m_stepId;
		clusterAction_ValidateQuestStep.m_executionOrder = this.m_executionOrder;
		return clusterAction_ValidateQuestStep;
	}

	// Token: 0x0400161D RID: 5661
	public int m_questId;

	// Token: 0x0400161E RID: 5662
	public int m_stepId;
}
