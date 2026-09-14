using System;

// Token: 0x020000B2 RID: 178
public class AnimationPlayerMeleeState : PlayerAnimationState
{
	// Token: 0x0600042F RID: 1071 RVA: 0x00005C56 File Offset: 0x00003E56
	public AnimationPlayerMeleeState()
	{
		this.StateName = "PlayerMelee";
	}

	// Token: 0x06000430 RID: 1072 RVA: 0x00005C69 File Offset: 0x00003E69
	public override void vmethod_0()
	{
		base.vmethod_0();
		base.m_status = AnimationStatus.RUNNING;
		this.m_timing = AnimationPlayerMeleeState.MeleeTiming.FirstTick;
		this.m_layer = ((!base.Boolean_0) ? 1 : 0);
	}

	// Token: 0x06000431 RID: 1073 RVA: 0x0004A2D0 File Offset: 0x000484D0
	public override void vmethod_1()
	{
		this.m_animatorInfo = base.method_15(base.Boolean_0, this.m_layer);
		switch (this.m_timing)
		{
		case AnimationPlayerMeleeState.MeleeTiming.FirstTick:
			if (base.Boolean_0)
			{
				base.method_7(MecanimAnimationID.ID_1st_Melee);
			}
			base.method_16("bMelee", true);
			this.m_timing = AnimationPlayerMeleeState.MeleeTiming.WaitForTransitionFinish;
			break;
		case AnimationPlayerMeleeState.MeleeTiming.WaitForTransitionFinish:
			if (this.m_animatorInfo.IsTag("Melee"))
			{
				this.m_startTime = this.m_animatorInfo.normalizedTime;
				base.method_16("bMelee", false);
				this.m_timing = AnimationPlayerMeleeState.MeleeTiming.Playing;
			}
			break;
		case AnimationPlayerMeleeState.MeleeTiming.Playing:
			if (!this.m_animatorInfo.IsTag("Melee") || base.method_1(this.m_animatorInfo, this.m_startTime, 0.97f))
			{
				this.m_timing = AnimationPlayerMeleeState.MeleeTiming.Finish;
			}
			break;
		case AnimationPlayerMeleeState.MeleeTiming.Finish:
			base.m_status = AnimationStatus.SUCCESS;
			base.method_16("bMelee", false);
			break;
		}
	}

	// Token: 0x06000432 RID: 1074 RVA: 0x00005C91 File Offset: 0x00003E91
	public override void vmethod_2()
	{
		base.vmethod_2();
		base.m_status = AnimationStatus.SUCCESS;
		base.method_16("bMelee", false);
		base.method_21().m_pending_melee = false;
	}

	// Token: 0x04000408 RID: 1032
	private float m_startTime;

	// Token: 0x04000409 RID: 1033
	private AnimationPlayerMeleeState.MeleeTiming m_timing;

	// Token: 0x020000B3 RID: 179
	public enum MeleeTiming
	{
		// Token: 0x0400040B RID: 1035
		FirstTick,
		// Token: 0x0400040C RID: 1036
		WaitForTransitionFinish,
		// Token: 0x0400040D RID: 1037
		Playing,
		// Token: 0x0400040E RID: 1038
		Finish
	}
}
