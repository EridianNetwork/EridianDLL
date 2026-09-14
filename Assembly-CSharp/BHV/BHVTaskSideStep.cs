using System;

namespace BHV
{
	// Token: 0x02000208 RID: 520
	public class BHVTaskSideStep : BHVTaskAnimationState
	{
		// Token: 0x06000AE6 RID: 2790 RVA: 0x0000AC2C File Offset: 0x00008E2C
		public BHVTaskSideStep()
		{
			base.m_Type = BHVTaskType.SideStep;
		}

		// Token: 0x06000AE7 RID: 2791 RVA: 0x0000AC3C File Offset: 0x00008E3C
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamSideStep_0 = bhvtaskParam_0 as BHVTaskParamSideStep;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000AE8 RID: 2792 RVA: 0x0000AC51 File Offset: 0x00008E51
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamSideStep_0;
		}

		// Token: 0x06000AE9 RID: 2793 RVA: 0x000646FC File Offset: 0x000628FC
		public override void Start()
		{
			base.Start();
			if (this.animationRollState_0 == null)
			{
				this.animationRollState_0 = this.bhvtaskManager_0.m_animationManagerFSM.method_16(Utils.smethod_23(AnimationStateFSM.Roll)) as AnimationRollState;
			}
			if (this.animationRollState_0 != null)
			{
				this.animationRollState_0.m_isSideStep = true;
				this.animationRollState_0.m_isDodgeRight = this.bhvtaskParamSideStep_0.bool_1;
			}
		}

		// Token: 0x06000AEA RID: 2794 RVA: 0x0000AB61 File Offset: 0x00008D61
		public override void Update(float deltaTime)
		{
			this.bhvtaskManager_0.m_entity.vmethod_49();
			base.Update(deltaTime, AnimationStateFSM.Roll);
		}

		// Token: 0x040009E2 RID: 2530
		private BHVTaskParamSideStep bhvtaskParamSideStep_0;

		// Token: 0x040009E3 RID: 2531
		private AnimationRollState animationRollState_0;
	}
}
