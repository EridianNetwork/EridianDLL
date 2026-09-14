using System;

namespace BHV
{
	// Token: 0x020001FA RID: 506
	public class BHVTaskPoisonSpit : BHVTask
	{
		// Token: 0x06000AAD RID: 2733 RVA: 0x0000A8B2 File Offset: 0x00008AB2
		public BHVTaskPoisonSpit()
		{
			base.m_Type = BHVTaskType.PoisonSpit;
		}

		// Token: 0x06000AAE RID: 2734 RVA: 0x0000A8CD File Offset: 0x00008ACD
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamPoisonSpit_0 = bhvtaskParam_0 as BHVTaskParamPoisonSpit;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000AAF RID: 2735 RVA: 0x0000A8E2 File Offset: 0x00008AE2
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamPoisonSpit_0;
		}

		// Token: 0x06000AB0 RID: 2736 RVA: 0x00063DF4 File Offset: 0x00061FF4
		public override void Start()
		{
			base.Start();
			this.float_0 = 3.333f * this.bhvtaskManager_0.m_animationManagerFSM.Animator_0.speed;
			this.bool_1 = false;
			this.bhvtaskManager_0.m_animationManagerFSM.vmethod_7(AnimationStateFSM.Idle);
			this.bhvtaskManager_0.m_animationManagerFSM.Animator_0.SetBool("bExitTurn", true);
			this.bhvtaskManager_0.m_animationManagerFSM.Animator_0.SetBool("bPoisonSpit", true);
			(this.bhvtaskManager_0.m_animationManagerFSM as SkagAnimationManagerFSM).OnStartPoisonSpit();
		}

		// Token: 0x06000AB1 RID: 2737 RVA: 0x00063E8C File Offset: 0x0006208C
		public override void Update(float deltaTime)
		{
			if (base.m_Status == BHVTaskStatus.SUCCESS)
			{
				return;
			}
			this.float_0 -= deltaTime;
			if (this.float_0 < 0f)
			{
				this.bhvtaskManager_0.m_animationManagerFSM.Animator_0.SetBool("bPoisonSpit", false);
				(this.bhvtaskManager_0.m_animationManagerFSM as SkagAnimationManagerFSM).OnStopPoisonSpit();
				base.m_Status = BHVTaskStatus.SUCCESS;
				return;
			}
			if (!this.bool_1 && (this.bhvtaskManager_0.m_animationManagerFSM as SkagAnimationManagerFSM).m_bSpitAttack)
			{
				this.bool_1 = true;
				(this.bhvtaskManager_0.m_animationManagerFSM as SkagAnimationManagerFSM).m_bSpitAttack = false;
			}
			base.Update(deltaTime);
		}

		// Token: 0x06000AB2 RID: 2738 RVA: 0x0000A8EA File Offset: 0x00008AEA
		public override void vmethod_3(bool bool_2)
		{
			base.vmethod_3(bool_2);
			this.bhvtaskManager_0.m_animationManagerFSM.Animator_0.SetBool("bPoisonSpit", false);
			(this.bhvtaskManager_0.m_animationManagerFSM as SkagAnimationManagerFSM).OnStopPoisonSpit();
		}

		// Token: 0x040009C2 RID: 2498
		private BHVTaskParamPoisonSpit bhvtaskParamPoisonSpit_0;

		// Token: 0x040009C3 RID: 2499
		private float float_0 = 3.333f;

		// Token: 0x040009C4 RID: 2500
		private bool bool_1;
	}
}
