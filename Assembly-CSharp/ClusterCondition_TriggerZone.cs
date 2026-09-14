using System;
using UnityEngine;

// Token: 0x02000507 RID: 1287
public class ClusterCondition_TriggerZone : ClusterCondition
{
	// Token: 0x0600218B RID: 8587 RVA: 0x000A148C File Offset: 0x0009F68C
	public override object Clone()
	{
		ClusterCondition_TriggerZone clusterCondition_TriggerZone = ScriptableObject.CreateInstance(base.GetType()) as ClusterCondition_TriggerZone;
		clusterCondition_TriggerZone.m_linkPlayersToThisClusterFlow = this.m_linkPlayersToThisClusterFlow;
		clusterCondition_TriggerZone.m_triggeringCondition = this.m_triggeringCondition;
		clusterCondition_TriggerZone.claptrapCheck = this.claptrapCheck;
		clusterCondition_TriggerZone.teamID = this.teamID;
		clusterCondition_TriggerZone.score = this.score;
		clusterCondition_TriggerZone.m_ownerCluster = this.m_ownerCluster;
		clusterCondition_TriggerZone.m_isValid = this.m_isValid;
		return clusterCondition_TriggerZone;
	}

	// Token: 0x04001637 RID: 5687
	public bool m_linkPlayersToThisClusterFlow;

	// Token: 0x04001638 RID: 5688
	public ClusterCondition_TriggerZone.TriggerCondition m_triggeringCondition;

	// Token: 0x04001639 RID: 5689
	public bool claptrapCheck;

	// Token: 0x0400163A RID: 5690
	public ClusterCondition_TriggerZone.TeamID teamID = ClusterCondition_TriggerZone.TeamID.TeamA;

	// Token: 0x0400163B RID: 5691
	public int score = 1;

	// Token: 0x02000508 RID: 1288
	public enum TriggerCondition
	{
		// Token: 0x0400163D RID: 5693
		OnePlayer,
		// Token: 0x0400163E RID: 5694
		AtLeastHalfPlayers,
		// Token: 0x0400163F RID: 5695
		AllPlayers
	}

	// Token: 0x02000509 RID: 1289
	public enum TeamID
	{
		// Token: 0x04001641 RID: 5697
		TeamA = 1,
		// Token: 0x04001642 RID: 5698
		TeamB
	}
}
