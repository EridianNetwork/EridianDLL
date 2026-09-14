using System;
using System.Text;

namespace BHV
{
	// Token: 0x02000175 RID: 373
	public class BHVTaskAnimationState : BHVTask
	{
		// Token: 0x06000880 RID: 2176 RVA: 0x000088A0 File Offset: 0x00006AA0
		public BHVTaskAnimationState()
		{
			base.m_Type = BHVTaskType.INVALID;
		}

		// Token: 0x06000881 RID: 2177 RVA: 0x000088B6 File Offset: 0x00006AB6
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamAnimationState_0 = bhvtaskParam_0 as BHVTaskParamAnimationState;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000882 RID: 2178 RVA: 0x000088CB File Offset: 0x00006ACB
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamAnimationState_0;
		}

		// Token: 0x06000883 RID: 2179 RVA: 0x000088D3 File Offset: 0x00006AD3
		public override void Start()
		{
			base.Start();
			this.state_0 = BHVTaskAnimationState.State.const_1;
		}

		// Token: 0x06000884 RID: 2180 RVA: 0x000088E2 File Offset: 0x00006AE2
		public override void Update(float deltaTime)
		{
			if (base.m_Type == BHVTaskType.PlayAnimation)
			{
				this.Update(deltaTime, this.bhvtaskParamAnimationState_0.animationStateFSM_0);
			}
		}

		// Token: 0x06000885 RID: 2181 RVA: 0x0005BABC File Offset: 0x00059CBC
		public virtual void Update(float deltaTime, AnimationStateFSM animationState = AnimationStateFSM.Invalid)
		{
			base.Update(deltaTime);
			BHVTaskAnimationState.State state = this.state_0;
			switch (state + 1)
			{
			case BHVTaskAnimationState.State.const_1:
				base.m_Status = BHVTaskStatus.FAILED;
				return;
			case BHVTaskAnimationState.State.const_2:
				this.bhvtaskManager_0.m_animationManagerFSM.vmethod_7(animationState);
				base.m_Status = BHVTaskStatus.RUNNING;
				this.state_0 = BHVTaskAnimationState.State.const_2;
				return;
			case BHVTaskAnimationState.State.const_3:
			{
				AnimationStatus animationStatus = this.bhvtaskManager_0.m_animationManagerFSM.method_0(animationState);
				switch (animationStatus + 1)
				{
				case AnimationStatus.FAILED:
				case AnimationStatus.RUNNING:
					base.m_Status = BHVTaskStatus.FAILED;
					this.state_0 = BHVTaskAnimationState.State.const_3;
					break;
				case AnimationStatus.SUCCESS:
					base.m_Status = BHVTaskStatus.RUNNING;
					break;
				case AnimationStatus.PREPARE:
					this.state_0 = BHVTaskAnimationState.State.const_3;
					base.m_Status = BHVTaskStatus.SUCCESS;
					break;
				}
				return;
			}
			case (BHVTaskAnimationState.State)3:
				return;
			default:
				base.m_Status = BHVTaskStatus.SUCCESS;
				return;
			}
		}

		// Token: 0x06000886 RID: 2182 RVA: 0x00008900 File Offset: 0x00006B00
		protected void method_0()
		{
			this.state_0 = BHVTaskAnimationState.State.const_3;
			base.m_Status = BHVTaskStatus.SUCCESS;
		}

		// Token: 0x06000887 RID: 2183 RVA: 0x0005BB74 File Offset: 0x00059D74
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder(base.ToString());
			stringBuilder.Append(string.Format("        State:{0}\n", this.state_0));
			return stringBuilder.ToString();
		}

		// Token: 0x04000800 RID: 2048
		private BHVTaskParamAnimationState bhvtaskParamAnimationState_0;

		// Token: 0x04000801 RID: 2049
		protected BHVTaskAnimationState.State state_0 = BHVTaskAnimationState.State.const_0;

		// Token: 0x02000176 RID: 374
		protected enum State
		{
			// Token: 0x04000803 RID: 2051
			const_0 = -1,
			// Token: 0x04000804 RID: 2052
			const_1,
			// Token: 0x04000805 RID: 2053
			const_2,
			// Token: 0x04000806 RID: 2054
			const_3
		}
	}
}
