using System;

namespace BHV
{
	// Token: 0x020001E5 RID: 485
	public class BHVTaskJumpAttackLand : BHVTask
	{
		// Token: 0x06000A59 RID: 2649 RVA: 0x0000A3C2 File Offset: 0x000085C2
		public BHVTaskJumpAttackLand()
		{
			base.m_Type = BHVTaskType.JumpAttackLand;
			base.m_Layer = BHVTaskLayer.FULLBODY;
		}

		// Token: 0x06000A5A RID: 2650 RVA: 0x0000A3D9 File Offset: 0x000085D9
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamJumpAttackLand_0 = bhvtaskParam_0 as BHVTaskParamJumpAttackLand;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000A5B RID: 2651 RVA: 0x0000A3EE File Offset: 0x000085EE
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamJumpAttackLand_0;
		}

		// Token: 0x06000A5C RID: 2652 RVA: 0x0000A3F6 File Offset: 0x000085F6
		public override void Start()
		{
			base.Start();
			this.bhvtaskManager_0.m_animationManagerFSM.vmethod_7(AnimationStateFSM.JumpAttackCrash);
		}

		// Token: 0x06000A5D RID: 2653 RVA: 0x00062E04 File Offset: 0x00061004
		public override void Update(float deltaTime)
		{
			this.bhvtaskManager_0.m_entity.vmethod_49();
			base.Update(deltaTime);
			AnimationStatus animationStatus = this.bhvtaskManager_0.m_animationManagerFSM.method_0(AnimationStateFSM.JumpAttackCrash);
			switch (animationStatus + 1)
			{
			case AnimationStatus.FAILED:
			case AnimationStatus.RUNNING:
				base.m_Status = BHVTaskStatus.FAILED;
				break;
			case AnimationStatus.SUCCESS:
				base.m_Status = BHVTaskStatus.RUNNING;
				break;
			case AnimationStatus.PREPARE:
				this.bhvtaskManager_0.m_animationManagerFSM.vmethod_7(AnimationStateFSM.Idle);
				base.m_Status = BHVTaskStatus.SUCCESS;
				break;
			}
		}

		// Token: 0x04000985 RID: 2437
		private BHVTaskParamJumpAttackLand bhvtaskParamJumpAttackLand_0;
	}
}
