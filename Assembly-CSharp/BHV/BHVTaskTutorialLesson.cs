using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x02000246 RID: 582
	public class BHVTaskTutorialLesson : BHVTaskAnimationState
	{
		// Token: 0x06000BD5 RID: 3029 RVA: 0x0000B912 File Offset: 0x00009B12
		public BHVTaskTutorialLesson()
		{
			base.m_Type = BHVTaskType.TutorialLesson;
			base.m_Layer = BHVTaskLayer.FULLBODY;
		}

		// Token: 0x06000BD6 RID: 3030 RVA: 0x0000B929 File Offset: 0x00009B29
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamTutorialLesson_0 = bhvtaskParam_0 as BHVTaskParamTutorialLesson;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000BD7 RID: 3031 RVA: 0x0000B93E File Offset: 0x00009B3E
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamTutorialLesson_0;
		}

		// Token: 0x06000BD8 RID: 3032 RVA: 0x0000B946 File Offset: 0x00009B46
		public override void Start()
		{
			base.Start();
			this.clapTrapTutorAnimationManagerFSM_0 = this.bhvtaskManager_0.m_animationManagerFSM as ClapTrapTutorAnimationManagerFSM;
			this.clapTrapTutorAnimationManagerFSM_0.m_lessonMessage = this.bhvtaskParamTutorialLesson_0.string_0;
			this.float_0 = 0f;
		}

		// Token: 0x06000BD9 RID: 3033 RVA: 0x00067A5C File Offset: 0x00065C5C
		public override void Update(float deltaTime)
		{
			base.Update(deltaTime, AnimationStateFSM.TutorialLesson);
			this.float_0 += deltaTime;
			if (this.float_0 > this.bhvtaskParamTutorialLesson_0.float_0)
			{
				this.float_0 = 0f;
				this.clapTrapTutorAnimationManagerFSM_0.m_showMessage = !this.clapTrapTutorAnimationManagerFSM_0.m_showMessage;
			}
		}

		// Token: 0x06000BDA RID: 3034 RVA: 0x00067AB8 File Offset: 0x00065CB8
		private void method_1()
		{
			if (this.entityPlayer_0 == null)
			{
				return;
			}
			Vector3 vector = this.entityPlayer_0.transform.position - this.bhvtaskManager_0.transform.position;
			vector.y = 0f;
			if (vector.sqrMagnitude < 1E-45f)
			{
				return;
			}
			Vector3 vector2 = Vector3.Lerp(this.bhvtaskManager_0.transform.forward, vector, 0.03f);
			this.bhvtaskManager_0.transform.forward = vector2;
		}

		// Token: 0x06000BDB RID: 3035 RVA: 0x0000B985 File Offset: 0x00009B85
		public override void vmethod_3(bool bool_1)
		{
			base.vmethod_3(bool_1);
			this.clapTrapTutorAnimationManagerFSM_0.m_showMessage = false;
		}

		// Token: 0x04000A98 RID: 2712
		private BHVTaskParamTutorialLesson bhvtaskParamTutorialLesson_0;

		// Token: 0x04000A99 RID: 2713
		private ClapTrapTutorAnimationManagerFSM clapTrapTutorAnimationManagerFSM_0;

		// Token: 0x04000A9A RID: 2714
		private float float_0;

		// Token: 0x04000A9B RID: 2715
		private EntityPlayer entityPlayer_0;
	}
}
