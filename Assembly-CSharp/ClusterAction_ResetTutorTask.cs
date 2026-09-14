using System;
using BHV;
using UnityEngine;

// Token: 0x020004E7 RID: 1255
public class ClusterAction_ResetTutorTask : ClusterAction
{
	// Token: 0x06002154 RID: 8532 RVA: 0x000A0DEC File Offset: 0x0009EFEC
	public override object Clone()
	{
		ClusterAction_ResetTutorTask clusterAction_ResetTutorTask = ScriptableObject.CreateInstance(base.GetType()) as ClusterAction_ResetTutorTask;
		clusterAction_ResetTutorTask.m_taskType = this.m_taskType;
		clusterAction_ResetTutorTask.m_message = this.m_message;
		clusterAction_ResetTutorTask.m_repeatMessageWaitTime = this.m_repeatMessageWaitTime;
		clusterAction_ResetTutorTask.m_idleWaitTime = this.m_idleWaitTime;
		clusterAction_ResetTutorTask.m_finished = this.m_finished;
		clusterAction_ResetTutorTask.m_moveSpeed = this.m_moveSpeed;
		clusterAction_ResetTutorTask.m_moveToDestination = this.m_moveToDestination;
		clusterAction_ResetTutorTask.m_facingObject = this.m_facingObject;
		clusterAction_ResetTutorTask.m_tutorAction = this.m_tutorAction;
		clusterAction_ResetTutorTask.m_moveStyle = this.m_moveStyle;
		clusterAction_ResetTutorTask.m_facingOption = this.m_facingOption;
		clusterAction_ResetTutorTask.m_moveSpeedIndex = this.m_moveSpeedIndex;
		clusterAction_ResetTutorTask.m_executionOrder = this.m_executionOrder;
		return clusterAction_ResetTutorTask;
	}

	// Token: 0x040015EE RID: 5614
	public ClusterAction_ResetTutorTask.TutorTaskType m_taskType = ClusterAction_ResetTutorTask.TutorTaskType.Wait;

	// Token: 0x040015EF RID: 5615
	public string m_message;

	// Token: 0x040015F0 RID: 5616
	public float m_repeatMessageWaitTime;

	// Token: 0x040015F1 RID: 5617
	public float m_idleWaitTime;

	// Token: 0x040015F2 RID: 5618
	public bool m_finished;

	// Token: 0x040015F3 RID: 5619
	public BHVMovementSpeed m_moveSpeed;

	// Token: 0x040015F4 RID: 5620
	public GameObject m_moveToDestination;

	// Token: 0x040015F5 RID: 5621
	public GameObject m_facingObject;

	// Token: 0x040015F6 RID: 5622
	public ClusterAction_ResetTutorTask.TutorAction m_tutorAction;

	// Token: 0x040015F7 RID: 5623
	public ClusterAction_ResetTutorTask.TutorMoveStyle m_moveStyle;

	// Token: 0x040015F8 RID: 5624
	public ClusterAction_ResetTutorTask.FacingOption m_facingOption = ClusterAction_ResetTutorTask.FacingOption.TargetObject;

	// Token: 0x040015F9 RID: 5625
	[SerializeField]
	private int m_moveSpeedIndex;

	// Token: 0x040015FA RID: 5626
	private string[] m_moveSpeedNames = new string[] { "WALK", "RUN", "SPRINT" };

	// Token: 0x020004E8 RID: 1256
	public enum TutorTaskType
	{
		// Token: 0x040015FC RID: 5628
		Move = 1,
		// Token: 0x040015FD RID: 5629
		Talk,
		// Token: 0x040015FE RID: 5630
		Wait,
		// Token: 0x040015FF RID: 5631
		DoAction
	}

	// Token: 0x020004E9 RID: 1257
	public enum TutorAction
	{
		// Token: 0x04001601 RID: 5633
		None,
		// Token: 0x04001602 RID: 5634
		Nervous,
		// Token: 0x04001603 RID: 5635
		OperatingPanel
	}

	// Token: 0x020004EA RID: 1258
	public enum TutorMoveStyle
	{
		// Token: 0x04001605 RID: 5637
		Normal,
		// Token: 0x04001606 RID: 5638
		Scared
	}

	// Token: 0x020004EB RID: 1259
	public enum FacingOption
	{
		// Token: 0x04001608 RID: 5640
		Player,
		// Token: 0x04001609 RID: 5641
		TargetObject
	}
}
