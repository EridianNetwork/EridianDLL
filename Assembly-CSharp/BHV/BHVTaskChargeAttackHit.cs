using System;

namespace BHV
{
	// Token: 0x020001AF RID: 431
	public class BHVTaskChargeAttackHit : BHVTaskAnimationState
	{
		// Token: 0x0600095E RID: 2398 RVA: 0x00009641 File Offset: 0x00007841
		public BHVTaskChargeAttackHit()
		{
			base.m_Type = BHVTaskType.ChargeAttackHit;
		}

		// Token: 0x0600095F RID: 2399 RVA: 0x00009651 File Offset: 0x00007851
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamChargeAttackHit_0 = bhvtaskParam_0 as BHVTaskParamChargeAttackHit;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000960 RID: 2400 RVA: 0x00009666 File Offset: 0x00007866
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamChargeAttackHit_0;
		}

		// Token: 0x06000961 RID: 2401 RVA: 0x0000966E File Offset: 0x0000786E
		public override void Update(float deltaTime)
		{
			base.Update(deltaTime, AnimationStateFSM.ChargeHit);
		}

		// Token: 0x04000887 RID: 2183
		private BHVTaskParamChargeAttackHit bhvtaskParamChargeAttackHit_0;
	}
}
