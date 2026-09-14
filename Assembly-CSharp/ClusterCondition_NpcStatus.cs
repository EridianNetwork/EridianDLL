using System;
using UnityEngine;

// Token: 0x020004FE RID: 1278
public class ClusterCondition_NpcStatus : ClusterCondition
{
	// Token: 0x0600217A RID: 8570 RVA: 0x000A120C File Offset: 0x0009F40C
	public override object Clone()
	{
		ClusterCondition_NpcStatus clusterCondition_NpcStatus = ScriptableObject.CreateInstance(base.GetType()) as ClusterCondition_NpcStatus;
		clusterCondition_NpcStatus.m_npcType = this.m_npcType;
		clusterCondition_NpcStatus.m_aiState = this.m_aiState;
		clusterCondition_NpcStatus.m_checkPhase = this.m_checkPhase;
		clusterCondition_NpcStatus.m_checkState = this.m_checkState;
		clusterCondition_NpcStatus.m_phase = this.m_phase;
		clusterCondition_NpcStatus.m_ownerCluster = this.m_ownerCluster;
		clusterCondition_NpcStatus.m_isValid = this.m_isValid;
		return clusterCondition_NpcStatus;
	}

	// Token: 0x04001624 RID: 5668
	public EntityNpc.EntitySubType m_npcType;

	// Token: 0x04001625 RID: 5669
	public string m_aiState = string.Empty;

	// Token: 0x04001626 RID: 5670
	public bool m_checkPhase;

	// Token: 0x04001627 RID: 5671
	public bool m_checkState = true;

	// Token: 0x04001628 RID: 5672
	public int m_phase;
}
