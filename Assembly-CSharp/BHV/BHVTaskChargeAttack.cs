using System;

namespace BHV
{
	// Token: 0x020001AC RID: 428
	public class BHVTaskChargeAttack : BHVTask
	{
		// Token: 0x06000956 RID: 2390 RVA: 0x000095A6 File Offset: 0x000077A6
		public BHVTaskChargeAttack()
		{
			base.m_Type = BHVTaskType.ChargeAttack;
			base.m_Layer = BHVTaskLayer.FULLBODY;
		}

		// Token: 0x06000957 RID: 2391 RVA: 0x000095C4 File Offset: 0x000077C4
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamChargeAttack_0 = bhvtaskParam_0 as BHVTaskParamChargeAttack;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000958 RID: 2392 RVA: 0x000095D9 File Offset: 0x000077D9
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamChargeAttack_0;
		}

		// Token: 0x06000959 RID: 2393 RVA: 0x000095E1 File Offset: 0x000077E1
		public override void Start()
		{
			base.Start();
			this.state_0 = BHVTaskChargeAttack.State.const_1;
			this.animationChargeState_0 = this.bhvtaskManager_0.m_animationManagerFSM.method_16("Charge") as AnimationChargeState;
			this.animationChargeState_0.EAnimationChargeStep_0 = EAnimationChargeStep.ChargeNull;
		}

		// Token: 0x0600095A RID: 2394 RVA: 0x0005DB80 File Offset: 0x0005BD80
		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			if (this.animationChargeState_0 == null)
			{
				this.state_0 = BHVTaskChargeAttack.State.const_0;
			}
			BHVTaskChargeAttack.State state = this.state_0;
			switch (state + 1)
			{
			case BHVTaskChargeAttack.State.const_1:
				base.m_Status = BHVTaskStatus.FAILED;
				return;
			case BHVTaskChargeAttack.State.const_2:
				switch (this.animationChargeState_0.EAnimationChargeStep_0)
				{
				case EAnimationChargeStep.ChargeNull:
					this.bhvtaskManager_0.m_animationManagerFSM.vmethod_7(AnimationStateFSM.Charge);
					this.bhvtaskManager_0.m_animationManagerFSM.Boolean_1 = true;
					base.m_Status = BHVTaskStatus.RUNNING;
					break;
				case EAnimationChargeStep.ChargePre:
				case EAnimationChargeStep.ChargeLoop:
					if (this.animationChargeState_0.EAnimationChargeStep_0 != EAnimationChargeStep.ChargeReach && this.animationChargeState_0 != null)
					{
						this.animationChargeState_0.m_destinationPosition = this.bhvtaskParamChargeAttack_0.vector3_0;
						this.animationChargeState_0.m_destinationDistanceFactor = BHVTaskUtils.smethod_2(this.bhvtaskManager_0.transform.position, this.animationChargeState_0.m_destinationPosition);
					}
					break;
				case EAnimationChargeStep.ChargeFinish:
					base.m_Status = BHVTaskStatus.FAILED;
					this.state_0 = BHVTaskChargeAttack.State.const_2;
					break;
				}
				break;
			case (BHVTaskChargeAttack.State)2:
				return;
			}
		}

		// Token: 0x0600095B RID: 2395 RVA: 0x0000961C File Offset: 0x0000781C
		public override void vmethod_3(bool bool_1)
		{
			base.vmethod_3(bool_1);
			this.animationChargeState_0.EAnimationChargeStep_0 = EAnimationChargeStep.ChargeReach;
		}

		// Token: 0x04000880 RID: 2176
		private AnimationChargeState animationChargeState_0;

		// Token: 0x04000881 RID: 2177
		private BHVTaskParamChargeAttack bhvtaskParamChargeAttack_0;

		// Token: 0x04000882 RID: 2178
		private BHVTaskChargeAttack.State state_0 = BHVTaskChargeAttack.State.const_0;

		// Token: 0x020001AD RID: 429
		private enum State
		{
			// Token: 0x04000884 RID: 2180
			const_0 = -1,
			// Token: 0x04000885 RID: 2181
			const_1,
			// Token: 0x04000886 RID: 2182
			const_2
		}
	}
}
