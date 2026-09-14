using System;

namespace BHV
{
	// Token: 0x0200022E RID: 558
	public class BHVTaskCoverReload : BHVTaskAnimationState
	{
		// Token: 0x06000B7C RID: 2940 RVA: 0x0000B490 File Offset: 0x00009690
		public BHVTaskCoverReload()
		{
			base.m_Type = BHVTaskType.CoverReload;
		}

		// Token: 0x06000B7D RID: 2941 RVA: 0x0000B4A0 File Offset: 0x000096A0
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamCoverReload_0 = bhvtaskParam_0 as BHVTaskParamCoverReload;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000B7E RID: 2942 RVA: 0x0000B4B5 File Offset: 0x000096B5
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamCoverReload_0;
		}

		// Token: 0x06000B7F RID: 2943 RVA: 0x00066698 File Offset: 0x00064898
		public override void Update(float deltaTime)
		{
			BHVTaskAnimationState.State state_ = this.state_0;
			base.Update(deltaTime, AnimationStateFSM.CoverReload);
			if (state_ != BHVTaskAnimationState.State.const_1 || this.state_0 == BHVTaskAnimationState.State.const_2)
			{
			}
		}

		// Token: 0x04000A61 RID: 2657
		private BHVTaskParamCoverReload bhvtaskParamCoverReload_0;
	}
}
