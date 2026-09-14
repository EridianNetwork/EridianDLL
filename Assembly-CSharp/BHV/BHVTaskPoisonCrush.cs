using System;

namespace BHV
{
	// Token: 0x020001F6 RID: 502
	public class BHVTaskPoisonCrush : BHVTask
	{
		// Token: 0x06000A9B RID: 2715 RVA: 0x0000A78D File Offset: 0x0000898D
		public BHVTaskPoisonCrush()
		{
			base.m_Type = BHVTaskType.PoisonCrush;
		}

		// Token: 0x06000A9C RID: 2716 RVA: 0x0000A79D File Offset: 0x0000899D
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamPoisonCrush_0 = bhvtaskParam_0 as BHVTaskParamPoisonCrush;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000A9D RID: 2717 RVA: 0x0000A7B2 File Offset: 0x000089B2
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamPoisonCrush_0;
		}

		// Token: 0x06000A9E RID: 2718 RVA: 0x00063A98 File Offset: 0x00061C98
		public override void Start()
		{
			base.Start();
			this.float_0 = 1.667f * this.bhvtaskManager_0.m_animationManagerFSM.Animator_0.speed;
			this.bool_1 = false;
			this.bhvtaskManager_0.m_animationManagerFSM.vmethod_7(AnimationStateFSM.Idle);
			this.bhvtaskManager_0.m_animationManagerFSM.Animator_0.SetBool("bExitTurn", true);
			this.bhvtaskManager_0.m_animationManagerFSM.Animator_0.SetBool("bPoisonCrush", true);
			if ((this.bhvtaskManager_0.m_entity as EntityNpc).method_18())
			{
				AIServiceUtility.AIServiceUtility_0.method_5(this.bhvtaskManager_0.transform.position, this.bhvtaskParamPoisonCrush_0.float_0);
			}
		}

		// Token: 0x06000A9F RID: 2719 RVA: 0x00063B58 File Offset: 0x00061D58
		public override void Update(float deltaTime)
		{
			if (base.m_Status == BHVTaskStatus.SUCCESS)
			{
				return;
			}
			this.float_0 -= deltaTime;
			if (this.float_0 < 0f)
			{
				this.bhvtaskManager_0.m_animationManagerFSM.Animator_0.SetBool("bPoisonCrush", false);
				base.m_Status = BHVTaskStatus.SUCCESS;
				return;
			}
			if (!this.bool_1 && (this.bhvtaskManager_0.m_animationManagerFSM as SkagAnimationManagerFSM).m_bCrushAttack)
			{
				this.bool_1 = true;
				(this.bhvtaskManager_0.m_animationManagerFSM as SkagAnimationManagerFSM).m_bCrushAttack = false;
			}
			base.Update(deltaTime);
		}

		// Token: 0x06000AA0 RID: 2720 RVA: 0x00063BF0 File Offset: 0x00061DF0
		public override void vmethod_3(bool bool_2)
		{
			base.vmethod_3(bool_2);
			this.bhvtaskManager_0.m_animationManagerFSM.Animator_0.SetBool("bPoisonCrush", false);
			if ((this.bhvtaskManager_0.m_entity as EntityNpc).method_18())
			{
				AIServiceUtility.AIServiceUtility_0.method_6();
			}
		}

		// Token: 0x040009B6 RID: 2486
		private BHVTaskParamPoisonCrush bhvtaskParamPoisonCrush_0;

		// Token: 0x040009B7 RID: 2487
		private float float_0;

		// Token: 0x040009B8 RID: 2488
		private bool bool_1;
	}
}
