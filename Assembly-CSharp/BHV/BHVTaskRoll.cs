using System;

namespace BHV
{
	// Token: 0x02000204 RID: 516
	public class BHVTaskRoll : BHVTaskAnimationState
	{
		// Token: 0x06000AD9 RID: 2777 RVA: 0x0000AB34 File Offset: 0x00008D34
		public BHVTaskRoll()
		{
			base.m_Type = BHVTaskType.Roll;
		}

		// Token: 0x06000ADA RID: 2778 RVA: 0x0000AB44 File Offset: 0x00008D44
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamRoll_0 = bhvtaskParam_0 as BHVTaskParamRoll;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000ADB RID: 2779 RVA: 0x0000AB59 File Offset: 0x00008D59
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamRoll_0;
		}

		// Token: 0x06000ADC RID: 2780 RVA: 0x00064694 File Offset: 0x00062894
		public override void Start()
		{
			base.Start();
			if (this.animationRollState_0 == null)
			{
				this.animationRollState_0 = this.bhvtaskManager_0.m_animationManagerFSM.method_16(Utils.smethod_23(AnimationStateFSM.Roll)) as AnimationRollState;
			}
			if (this.animationRollState_0 != null)
			{
				this.animationRollState_0.m_isSideStep = false;
				this.animationRollState_0.m_isDodgeRight = this.bhvtaskParamRoll_0.bool_1;
			}
		}

		// Token: 0x06000ADD RID: 2781 RVA: 0x0000AB61 File Offset: 0x00008D61
		public override void Update(float deltaTime)
		{
			this.bhvtaskManager_0.m_entity.vmethod_49();
			base.Update(deltaTime, AnimationStateFSM.Roll);
		}

		// Token: 0x040009DE RID: 2526
		private BHVTaskParamRoll bhvtaskParamRoll_0;

		// Token: 0x040009DF RID: 2527
		private AnimationRollState animationRollState_0;
	}
}
