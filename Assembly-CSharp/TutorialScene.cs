using System;

// Token: 0x02000536 RID: 1334
public class TutorialScene : Scene
{
	// Token: 0x06002255 RID: 8789 RVA: 0x000A3470 File Offset: 0x000A1670
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

	// Token: 0x06002256 RID: 8790 RVA: 0x000A34D8 File Offset: 0x000A16D8
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

	// Token: 0x040016DD RID: 5853
	private ClusterAction_TutorialLesson m_tutorialLesson;

	// Token: 0x040016DE RID: 5854
	private ClusterAction_ResetTutorTask m_resetTutorTask;
}
