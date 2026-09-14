using System;

namespace BHV
{
	// Token: 0x020001A9 RID: 425
	public class BHVTaskBurrowAttack : BHVTask
	{
		// Token: 0x0600094E RID: 2382 RVA: 0x000094D8 File Offset: 0x000076D8
		public BHVTaskBurrowAttack()
		{
			base.m_Type = BHVTaskType.BurrowAttack;
		}

		// Token: 0x0600094F RID: 2383 RVA: 0x000094EF File Offset: 0x000076EF
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamBurrowAttack_0 = bhvtaskParam_0 as BHVTaskParamBurrowAttack;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000950 RID: 2384 RVA: 0x00009504 File Offset: 0x00007704
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamBurrowAttack_0;
		}

		// Token: 0x06000951 RID: 2385 RVA: 0x0000950C File Offset: 0x0000770C
		public override void Start()
		{
			base.Start();
			this.state_0 = BHVTaskBurrowAttack.State.const_1;
			this.animationBurrowState_0 = this.bhvtaskManager_0.m_animationManagerFSM.method_16("Burrow") as AnimationBurrowState;
			this.float_0 = 0f;
		}

		// Token: 0x06000952 RID: 2386 RVA: 0x0005DA84 File Offset: 0x0005BC84
		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			if (this.animationBurrowState_0 == null)
			{
				this.state_0 = BHVTaskBurrowAttack.State.const_0;
			}
			BHVTaskBurrowAttack.State state = this.state_0;
			switch (state + 1)
			{
			case BHVTaskBurrowAttack.State.const_1:
				base.m_Status = BHVTaskStatus.FAILED;
				return;
			case BHVTaskBurrowAttack.State.const_2:
				switch (this.animationBurrowState_0.EAnimationBurrowStep_0)
				{
				case EAnimationBurrowStep.BurrowNull:
					this.bhvtaskManager_0.m_animationManagerFSM.vmethod_7(AnimationStateFSM.Burrow);
					base.m_Status = BHVTaskStatus.RUNNING;
					break;
				case EAnimationBurrowStep.BurrowWait:
					this.float_0 += deltaTime;
					if (this.float_0 >= this.bhvtaskParamBurrowAttack_0.float_0)
					{
						this.animationBurrowState_0.EAnimationBurrowStep_0 = EAnimationBurrowStep.BurrowExit;
						this.bhvtaskManager_0.gameObject.transform.position = this.bhvtaskParamBurrowAttack_0.vector3_0;
					}
					break;
				case EAnimationBurrowStep.BurrowFinish:
					base.m_Status = BHVTaskStatus.SUCCESS;
					this.state_0 = BHVTaskBurrowAttack.State.const_2;
					this.animationBurrowState_0.EAnimationBurrowStep_0 = EAnimationBurrowStep.BurrowNull;
					break;
				}
				break;
			case (BHVTaskBurrowAttack.State)2:
				return;
			}
		}

		// Token: 0x06000953 RID: 2387 RVA: 0x00009546 File Offset: 0x00007746
		public override void vmethod_3(bool bool_1)
		{
			base.vmethod_3(bool_1);
			this.animationBurrowState_0.EAnimationBurrowStep_0 = EAnimationBurrowStep.BurrowFinish;
		}

		// Token: 0x04000877 RID: 2167
		private BHVTaskParamBurrowAttack bhvtaskParamBurrowAttack_0;

		// Token: 0x04000878 RID: 2168
		private AnimationBurrowState animationBurrowState_0;

		// Token: 0x04000879 RID: 2169
		private BHVTaskBurrowAttack.State state_0 = BHVTaskBurrowAttack.State.const_0;

		// Token: 0x0400087A RID: 2170
		private float float_0;

		// Token: 0x020001AA RID: 426
		private enum State
		{
			// Token: 0x0400087C RID: 2172
			const_0 = -1,
			// Token: 0x0400087D RID: 2173
			const_1,
			// Token: 0x0400087E RID: 2174
			const_2
		}
	}
}
