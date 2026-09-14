using System;

namespace BHV
{
	// Token: 0x020001F8 RID: 504
	public class BHVTaskPoisonDash : BHVTask
	{
		// Token: 0x06000AA3 RID: 2723 RVA: 0x0000A7FB File Offset: 0x000089FB
		public BHVTaskPoisonDash()
		{
			base.m_Type = BHVTaskType.PoisonDash;
		}

		// Token: 0x06000AA4 RID: 2724 RVA: 0x0000A816 File Offset: 0x00008A16
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamPoisonDash_0 = bhvtaskParam_0 as BHVTaskParamPoisonDash;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000AA5 RID: 2725 RVA: 0x0000A82B File Offset: 0x00008A2B
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamPoisonDash_0;
		}

		// Token: 0x06000AA6 RID: 2726 RVA: 0x00063C40 File Offset: 0x00061E40
		public override void Start()
		{
			base.Start();
			this.float_0 = 1.733f * this.bhvtaskManager_0.m_animationManagerFSM.Animator_0.speed;
			this.bool_1 = false;
			this.bhvtaskManager_0.m_animationManagerFSM.vmethod_7(AnimationStateFSM.Idle);
			this.bhvtaskManager_0.m_animationManagerFSM.Animator_0.SetBool("bExitTurn", true);
			this.bhvtaskManager_0.m_animationManagerFSM.Animator_0.SetBool("bPoisonDash", true);
		}

		// Token: 0x06000AA7 RID: 2727 RVA: 0x00063CC4 File Offset: 0x00061EC4
		public override void Update(float deltaTime)
		{
			if (base.m_Status == BHVTaskStatus.SUCCESS)
			{
				return;
			}
			this.float_0 -= deltaTime;
			if (this.float_0 < 0f)
			{
				this.bhvtaskManager_0.m_animationManagerFSM.Animator_0.SetBool("bPoisonDash", false);
				base.m_Status = BHVTaskStatus.SUCCESS;
				return;
			}
			if (!this.bool_1 && (this.bhvtaskManager_0.m_animationManagerFSM as SkagAnimationManagerFSM).m_bDashAttack)
			{
				this.bool_1 = true;
				(this.bhvtaskManager_0.m_animationManagerFSM as SkagAnimationManagerFSM).m_bDashAttack = false;
			}
			base.Update(deltaTime);
		}

		// Token: 0x06000AA8 RID: 2728 RVA: 0x0000A833 File Offset: 0x00008A33
		public override void vmethod_3(bool bool_2)
		{
			base.vmethod_3(bool_2);
			this.bhvtaskManager_0.m_animationManagerFSM.Animator_0.SetBool("bPoisonDash", false);
		}

		// Token: 0x040009BA RID: 2490
		private BHVTaskParamPoisonDash bhvtaskParamPoisonDash_0;

		// Token: 0x040009BB RID: 2491
		private float float_0 = 1.733f;

		// Token: 0x040009BC RID: 2492
		private bool bool_1;
	}
}
