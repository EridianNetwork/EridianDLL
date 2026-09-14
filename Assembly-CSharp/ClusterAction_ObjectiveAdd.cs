using System;
using UnityEngine;

// Token: 0x020004E3 RID: 1251
public class ClusterAction_ObjectiveAdd : ClusterAction
{
	// Token: 0x0600214D RID: 8525 RVA: 0x000A0CFC File Offset: 0x0009EEFC
	public override object Clone()
	{
		ClusterAction_ObjectiveAdd clusterAction_ObjectiveAdd = ScriptableObject.CreateInstance(base.GetType()) as ClusterAction_ObjectiveAdd;
		clusterAction_ObjectiveAdd.m_objectiveId = this.m_objectiveId;
		clusterAction_ObjectiveAdd.m_titleId = this.m_titleId;
		clusterAction_ObjectiveAdd.m_detailId = this.m_detailId;
		clusterAction_ObjectiveAdd.m_executionOrder = this.m_executionOrder;
		return clusterAction_ObjectiveAdd;
	}

	// Token: 0x040015E0 RID: 5600
	public string m_objectiveId;

	// Token: 0x040015E1 RID: 5601
	public string m_titleId;

	// Token: 0x040015E2 RID: 5602
	public string m_detailId;
}
