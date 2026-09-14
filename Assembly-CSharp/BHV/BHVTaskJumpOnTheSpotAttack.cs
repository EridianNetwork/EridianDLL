using System;

namespace BHV
{
	// Token: 0x020001E7 RID: 487
	public class BHVTaskJumpOnTheSpotAttack : BHVTaskAnimationState
	{
		// Token: 0x06000A60 RID: 2656 RVA: 0x0000A420 File Offset: 0x00008620
		public BHVTaskJumpOnTheSpotAttack()
		{
			base.m_Type = BHVTaskType.JumpOnTheSpotAttack;
		}

		// Token: 0x06000A61 RID: 2657 RVA: 0x0000A430 File Offset: 0x00008630
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamJumpOnTheSpotAttack_0 = bhvtaskParam_0 as BHVTaskParamJumpOnTheSpotAttack;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000A62 RID: 2658 RVA: 0x0000A445 File Offset: 0x00008645
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamJumpOnTheSpotAttack_0;
		}

		// Token: 0x06000A63 RID: 2659 RVA: 0x0000A44D File Offset: 0x0000864D
		public override void Update(float deltaTime)
		{
			base.Update(deltaTime, AnimationStateFSM.JumpOnSpot);
		}

		// Token: 0x04000986 RID: 2438
		private BHVTaskParamJumpOnTheSpotAttack bhvtaskParamJumpOnTheSpotAttack_0;
	}
}
