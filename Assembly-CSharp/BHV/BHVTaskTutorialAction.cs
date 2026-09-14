using System;

namespace BHV
{
	// Token: 0x02000244 RID: 580
	public class BHVTaskTutorialAction : BHVTaskAnimationState
	{
		// Token: 0x06000BCA RID: 3018 RVA: 0x0000B843 File Offset: 0x00009A43
		public BHVTaskTutorialAction()
		{
			base.m_Type = BHVTaskType.TutorialAction;
			base.m_Layer = BHVTaskLayer.FULLBODY;
		}

		// Token: 0x06000BCB RID: 3019 RVA: 0x0000B85A File Offset: 0x00009A5A
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamTutorialAction_0 = bhvtaskParam_0 as BHVTaskParamTutorialAction;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000BCC RID: 3020 RVA: 0x0000B86F File Offset: 0x00009A6F
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamTutorialAction_0;
		}

		// Token: 0x06000BCD RID: 3021 RVA: 0x00067990 File Offset: 0x00065B90
		public override void Start()
		{
			base.Start();
			this.clapTrapTutorAnimationManagerFSM_0 = this.bhvtaskManager_0.m_animationManagerFSM as ClapTrapTutorAnimationManagerFSM;
			this.float_0 = 0f;
			AnimationTutorialActionState animationTutorialActionState = this.bhvtaskManager_0.m_animationManagerFSM.method_16(Utils.smethod_23(AnimationStateFSM.TutorialAction)) as AnimationTutorialActionState;
			if (animationTutorialActionState != null)
			{
				animationTutorialActionState.m_tutorAction = this.bhvtaskParamTutorialAction_0.tutorAction_0;
			}
		}

		// Token: 0x06000BCE RID: 3022 RVA: 0x000679F8 File Offset: 0x00065BF8
		public override void Update(float deltaTime)
		{
			base.Update(deltaTime, AnimationStateFSM.TutorialAction);
			this.float_0 += deltaTime;
			if (this.float_0 > this.bhvtaskParamTutorialAction_0.float_0)
			{
				this.float_0 = 0f;
				this.clapTrapTutorAnimationManagerFSM_0.m_showMessage = !this.clapTrapTutorAnimationManagerFSM_0.m_showMessage;
				base.m_Status = BHVTaskStatus.SUCCESS;
			}
		}

		// Token: 0x06000BCF RID: 3023 RVA: 0x0000311B File Offset: 0x0000131B
		private void method_1()
		{
		}

		// Token: 0x06000BD0 RID: 3024 RVA: 0x0000B877 File Offset: 0x00009A77
		public override void vmethod_3(bool bool_1)
		{
			base.vmethod_3(bool_1);
			this.clapTrapTutorAnimationManagerFSM_0.m_showMessage = false;
		}

		// Token: 0x04000A91 RID: 2705
		private BHVTaskParamTutorialAction bhvtaskParamTutorialAction_0;

		// Token: 0x04000A92 RID: 2706
		private ClapTrapTutorAnimationManagerFSM clapTrapTutorAnimationManagerFSM_0;

		// Token: 0x04000A93 RID: 2707
		private float float_0;
	}
}
