using System;

namespace BHV
{
	// Token: 0x0200022C RID: 556
	public class BHVTaskCoverPeakOut : BHVTaskAnimationState
	{
		// Token: 0x06000B76 RID: 2934 RVA: 0x0000B418 File Offset: 0x00009618
		public BHVTaskCoverPeakOut()
		{
			base.m_Type = BHVTaskType.CoverPeakOut;
		}

		// Token: 0x06000B77 RID: 2935 RVA: 0x0000B428 File Offset: 0x00009628
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamCoverPeakOut_0 = bhvtaskParam_0 as BHVTaskParamCoverPeakOut;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000B78 RID: 2936 RVA: 0x0000B43D File Offset: 0x0000963D
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamCoverPeakOut_0;
		}

		// Token: 0x06000B79 RID: 2937 RVA: 0x0000B445 File Offset: 0x00009645
		public override void Update(float deltaTime)
		{
			base.Update(deltaTime, AnimationStateFSM.CoverPeakOut);
		}

		// Token: 0x04000A5F RID: 2655
		private BHVTaskParamCoverPeakOut bhvtaskParamCoverPeakOut_0;
	}
}
