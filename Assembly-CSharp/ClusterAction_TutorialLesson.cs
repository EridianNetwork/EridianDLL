using System;
using Core;
using UnityEngine;

// Token: 0x020004F7 RID: 1271
public class ClusterAction_TutorialLesson : ClusterAction
{
	// Token: 0x06002167 RID: 8551 RVA: 0x000A1080 File Offset: 0x0009F280
	public override object Clone()
	{
		ClusterAction_TutorialLesson clusterAction_TutorialLesson = ScriptableObject.CreateInstance(base.GetType()) as ClusterAction_TutorialLesson;
		clusterAction_TutorialLesson.m_message = this.m_message;
		clusterAction_TutorialLesson.m_lessonTargetObject = this.m_lessonTargetObject;
		clusterAction_TutorialLesson.m_executionOrder = this.m_executionOrder;
		return clusterAction_TutorialLesson;
	}

	// Token: 0x0400161B RID: 5659
	public UIMessage m_message = new UIMessage();

	// Token: 0x0400161C RID: 5660
	public GameObject m_lessonTargetObject;
}
