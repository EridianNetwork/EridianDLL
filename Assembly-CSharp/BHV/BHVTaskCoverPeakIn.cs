using System;

namespace BHV
{
	// Token: 0x0200022A RID: 554
	public class BHVTaskCoverPeakIn : BHVTaskAnimationState
	{
		// Token: 0x06000B70 RID: 2928 RVA: 0x0000B3A0 File Offset: 0x000095A0
		public BHVTaskCoverPeakIn()
		{
			base.m_Type = BHVTaskType.CoverPeakIn;
		}

		// Token: 0x06000B71 RID: 2929 RVA: 0x0000B3B0 File Offset: 0x000095B0
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamCoverPeakIn_0 = bhvtaskParam_0 as BHVTaskParamCoverPeakIn;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000B72 RID: 2930 RVA: 0x0000B3C5 File Offset: 0x000095C5
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamCoverPeakIn_0;
		}

		// Token: 0x06000B73 RID: 2931 RVA: 0x0000B3CD File Offset: 0x000095CD
		public override void Update(float deltaTime)
		{
			base.Update(deltaTime, AnimationStateFSM.CoverPeakIn);
		}

		// Token: 0x04000A5D RID: 2653
		private BHVTaskParamCoverPeakIn bhvtaskParamCoverPeakIn_0;
	}
}
