using System;

namespace BHV
{
	// Token: 0x0200020F RID: 527
	public class BHVTaskStunned : BHVTaskAnimationState
	{
		// Token: 0x06000B04 RID: 2820 RVA: 0x0000ADA4 File Offset: 0x00008FA4
		public BHVTaskStunned()
		{
			base.m_Type = BHVTaskType.Stunned;
		}

		// Token: 0x06000B05 RID: 2821 RVA: 0x0000ADB4 File Offset: 0x00008FB4
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamStunned_0 = bhvtaskParam_0 as BHVTaskParamStunned;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000B06 RID: 2822 RVA: 0x0000ADC9 File Offset: 0x00008FC9
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamStunned_0;
		}

		// Token: 0x06000B07 RID: 2823 RVA: 0x0000ADD1 File Offset: 0x00008FD1
		public override void Update(float deltaTime)
		{
			base.Update(deltaTime, AnimationStateFSM.Stun);
		}

		// Token: 0x040009FB RID: 2555
		private BHVTaskParamStunned bhvtaskParamStunned_0;
	}
}
