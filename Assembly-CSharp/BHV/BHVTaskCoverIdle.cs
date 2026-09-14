using System;
using System.Text;

namespace BHV
{
	// Token: 0x02000225 RID: 549
	public class BHVTaskCoverIdle : BHVTask
	{
		// Token: 0x06000B61 RID: 2913 RVA: 0x0000B289 File Offset: 0x00009489
		public BHVTaskCoverIdle()
		{
			base.m_Type = BHVTaskType.CoverIdle;
		}

		// Token: 0x06000B62 RID: 2914 RVA: 0x0000B2A0 File Offset: 0x000094A0
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamCoverIdle_0 = bhvtaskParam_0 as BHVTaskParamCoverIdle;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000B63 RID: 2915 RVA: 0x0000B2B5 File Offset: 0x000094B5
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamCoverIdle_0;
		}

		// Token: 0x06000B64 RID: 2916 RVA: 0x0000B2BD File Offset: 0x000094BD
		public override void Start()
		{
			base.Start();
			this.coverIdleState_0 = BHVTaskCoverIdle.CoverIdleState.const_1;
		}

		// Token: 0x06000B65 RID: 2917 RVA: 0x00066550 File Offset: 0x00064750
		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			BHVTaskCoverIdle.CoverIdleState coverIdleState = this.coverIdleState_0;
			switch (coverIdleState + 1)
			{
			case BHVTaskCoverIdle.CoverIdleState.const_1:
				base.m_Status = BHVTaskStatus.FAILED;
				return;
			case BHVTaskCoverIdle.CoverIdleState.const_2:
				this.bhvtaskManager_0.m_animationManagerFSM.vmethod_7(AnimationStateFSM.CoverIdle);
				base.m_Status = BHVTaskStatus.RUNNING;
				this.coverIdleState_0 = BHVTaskCoverIdle.CoverIdleState.const_2;
				return;
			case BHVTaskCoverIdle.CoverIdleState.const_3:
			{
				AnimationStatus animationStatus = this.bhvtaskManager_0.m_animationManagerFSM.method_0(AnimationStateFSM.CoverIdle);
				switch (animationStatus + 1)
				{
				case AnimationStatus.FAILED:
				case AnimationStatus.RUNNING:
					base.m_Status = BHVTaskStatus.FAILED;
					this.coverIdleState_0 = BHVTaskCoverIdle.CoverIdleState.const_3;
					break;
				case AnimationStatus.SUCCESS:
					base.m_Status = BHVTaskStatus.RUNNING;
					break;
				case AnimationStatus.PREPARE:
					this.coverIdleState_0 = BHVTaskCoverIdle.CoverIdleState.const_3;
					base.m_Status = BHVTaskStatus.SUCCESS;
					break;
				}
				return;
			}
			case (BHVTaskCoverIdle.CoverIdleState)3:
				return;
			default:
				base.m_Status = BHVTaskStatus.SUCCESS;
				return;
			}
		}

		// Token: 0x06000B66 RID: 2918 RVA: 0x0006660C File Offset: 0x0006480C
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder(base.ToString());
			stringBuilder.Append(string.Format("        State:{0}\n", this.coverIdleState_0));
			return stringBuilder.ToString();
		}

		// Token: 0x04000A51 RID: 2641
		private BHVTaskParamCoverIdle bhvtaskParamCoverIdle_0;

		// Token: 0x04000A52 RID: 2642
		private BHVTaskCoverIdle.CoverIdleState coverIdleState_0 = BHVTaskCoverIdle.CoverIdleState.const_0;

		// Token: 0x02000226 RID: 550
		private enum CoverIdleState
		{
			// Token: 0x04000A54 RID: 2644
			const_0 = -1,
			// Token: 0x04000A55 RID: 2645
			const_1,
			// Token: 0x04000A56 RID: 2646
			const_2,
			// Token: 0x04000A57 RID: 2647
			const_3
		}
	}
}
