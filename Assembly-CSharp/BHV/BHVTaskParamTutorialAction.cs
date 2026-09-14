using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x02000243 RID: 579
	public sealed class BHVTaskParamTutorialAction : BHVTaskParamAnimationState
	{
		// Token: 0x06000BC8 RID: 3016 RVA: 0x0000B813 File Offset: 0x00009A13
		public BHVTaskParamTutorialAction()
		{
			base.m_Type = BHVTaskType.TutorialAction;
			base.m_Layer = BHVTaskLayer.FULLBODY;
			this.gameObject_0 = null;
			this.tutorAction_0 = ClusterAction_ResetTutorTask.TutorAction.None;
			this.float_0 = 1f;
		}

		// Token: 0x06000BC9 RID: 3017 RVA: 0x00067938 File Offset: 0x00065B38
		public override void vmethod_2(ref BHVTaskParamSync.Data data_0, bool bool_1)
		{
			base.vmethod_2(ref data_0, bool_1);
			if (bool_1)
			{
				data_0.int_4 = (int)this.tutorAction_0;
			}
			else
			{
				int int_ = data_0.int_4;
				if (Enum.IsDefined(typeof(ClusterAction_ResetTutorTask.TutorAction), int_))
				{
					this.tutorAction_0 = (ClusterAction_ResetTutorTask.TutorAction)int_;
				}
				else
				{
					this.tutorAction_0 = ClusterAction_ResetTutorTask.TutorAction.None;
				}
			}
		}

		// Token: 0x04000A8E RID: 2702
		public GameObject gameObject_0;

		// Token: 0x04000A8F RID: 2703
		public ClusterAction_ResetTutorTask.TutorAction tutorAction_0;

		// Token: 0x04000A90 RID: 2704
		public float float_0;
	}
}
