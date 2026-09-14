using System;
using UnityEngine;

// Token: 0x0200050E RID: 1294
public class LessonCluster : Scene
{
	// Token: 0x0600219C RID: 8604 RVA: 0x0000311D File Offset: 0x0000131D
	protected override bool vmethod_3()
	{
		return false;
	}

	// Token: 0x0600219D RID: 8605 RVA: 0x000A16B8 File Offset: 0x0009F8B8
	public ClusterAction_TutorialLesson method_10()
	{
		if (this.m_tutorialLesson != null)
		{
			return this.m_tutorialLesson;
		}
		if (this.m_completionActions != null)
		{
			for (int i = 0; i < this.m_completionActions.Length; i++)
			{
				this.m_tutorialLesson = this.m_completionActions[i] as ClusterAction_TutorialLesson;
				if (this.m_tutorialLesson != null)
				{
					return this.m_tutorialLesson;
				}
			}
		}
		return null;
	}

	// Token: 0x0600219E RID: 8606 RVA: 0x000A1720 File Offset: 0x0009F920
	public ClusterAction_ResetTutorTask method_11()
	{
		if (this.m_resetTutorTask != null)
		{
			return this.m_resetTutorTask;
		}
		if (this.m_completionActions != null)
		{
			for (int i = 0; i < this.m_completionActions.Length; i++)
			{
				this.m_resetTutorTask = this.m_completionActions[i] as ClusterAction_ResetTutorTask;
				if (this.m_resetTutorTask != null)
				{
					return this.m_resetTutorTask;
				}
			}
		}
		return null;
	}

	// Token: 0x0400164E RID: 5710
	private ClusterAction_TutorialLesson m_tutorialLesson;

	// Token: 0x0400164F RID: 5711
	private ClusterAction_ResetTutorTask m_resetTutorTask;

	// Token: 0x04001650 RID: 5712
	private bool m_forceComplete;

	// Token: 0x04001651 RID: 5713
	public ClusterAction[] m_npcTasks = new ClusterAction[0];

	// Token: 0x04001652 RID: 5714
	[HideInInspector]
	public bool m_showNpcTasks;

	// Token: 0x04001653 RID: 5715
	[HideInInspector]
	public bool m_CompleteAfterNpcTasksDone = true;

	// Token: 0x04001654 RID: 5716
	[HideInInspector]
	public bool m_closePreviousLessonCluster = true;

	// Token: 0x04001655 RID: 5717
	[HideInInspector]
	public LessonCluster m_previousLessonCluster;
}
