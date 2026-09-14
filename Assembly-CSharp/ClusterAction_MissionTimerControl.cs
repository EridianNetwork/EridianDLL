using System;
using UnityEngine;
using XsdSettings;

// Token: 0x020004DF RID: 1247
public class ClusterAction_MissionTimerControl : ClusterAction
{
	// Token: 0x06002148 RID: 8520 RVA: 0x000A0C68 File Offset: 0x0009EE68
	public override object Clone()
	{
		ClusterAction_MissionTimerControl clusterAction_MissionTimerControl = ScriptableObject.CreateInstance(base.GetType()) as ClusterAction_MissionTimerControl;
		clusterAction_MissionTimerControl.m_action = this.m_action;
		clusterAction_MissionTimerControl.m_extendedDuration = this.m_extendedDuration;
		clusterAction_MissionTimerControl.m_executionOrder = this.m_executionOrder;
		return clusterAction_MissionTimerControl;
	}

	// Token: 0x040015D4 RID: 5588
	public ClusterAction_MissionTimerControl.MissionTimerAction m_action;

	// Token: 0x040015D5 RID: 5589
	public double m_extendedDuration;

	// Token: 0x040015D6 RID: 5590
	public ELevelDifficulty m_difficulty;

	// Token: 0x020004E0 RID: 1248
	public enum MissionTimerAction
	{
		// Token: 0x040015D8 RID: 5592
		Stop,
		// Token: 0x040015D9 RID: 5593
		Resume,
		// Token: 0x040015DA RID: 5594
		Reset,
		// Token: 0x040015DB RID: 5595
		Extend,
		// Token: 0x040015DC RID: 5596
		Start
	}
}
