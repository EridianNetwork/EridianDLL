using System;

// Token: 0x020000B0 RID: 176
public class AnimationPlayerMeleeSkillState : PlayerAnimationState
{
	// Token: 0x0600042B RID: 1067 RVA: 0x00005C1B File Offset: 0x00003E1B
	public AnimationPlayerMeleeSkillState()
	{
		this.StateName = "PlayerMeleeSkill";
	}

	// Token: 0x0600042C RID: 1068 RVA: 0x0004A0F4 File Offset: 0x000482F4
	public override void vmethod_0()
	{
		base.vmethod_0();
		BerserkManage berserkManage = base.method_21().PlayerSkillManage_0 as BerserkManage;
		if (berserkManage != null)
		{
			berserkManage.Int32_0++;
		}
		base.m_status = AnimationStatus.RUNNING;
		this.m_timing = AnimationPlayerMeleeSkillState.MeleeTiming.FirstTick;
		this.m_layer = ((!base.Boolean_0) ? 1 : 0);
	}

	// Token: 0x0600042D RID: 1069 RVA: 0x0004A150 File Offset: 0x00048350
	public override void vmethod_1()
	{
		this.m_animatorInfo = base.method_15(base.Boolean_0, this.m_layer);
		switch (this.m_timing)
		{
		case AnimationPlayerMeleeSkillState.MeleeTiming.FirstTick:
			if (base.Boolean_0)
			{
				base.method_7(MecanimAnimationID.ID_1st_MeleeSkill);
			}
			base.method_16("bMeleeSkill", true);
			this.m_timing = AnimationPlayerMeleeSkillState.MeleeTiming.WaitForTransitionFinish;
			base.method_20().method_3(ENPCParticleType.E_Player_BerserkPunch, base.method_21().vmethod_17().transform, true, this.m_animatorInfo.length * 0.5f, true);
			if (base.method_21().vmethod_26())
			{
				base.method_20().method_3(ENPCParticleType.E_Berserk_MeteorFist_1st, base.method_21().vmethod_17().transform, false, 0f, true);
			}
			break;
		case AnimationPlayerMeleeSkillState.MeleeTiming.WaitForTransitionFinish:
			if (this.m_animatorInfo.IsTag("MeleeSkill"))
			{
				this.m_startTime = this.m_animatorInfo.normalizedTime;
				base.method_16("bMeleeSkill", false);
				this.m_timing = AnimationPlayerMeleeSkillState.MeleeTiming.Playing;
			}
			break;
		case AnimationPlayerMeleeSkillState.MeleeTiming.Playing:
			if (!this.m_animatorInfo.IsTag("MeleeSkill") || base.method_1(this.m_animatorInfo, this.m_startTime, 0.97f))
			{
				this.m_timing = AnimationPlayerMeleeSkillState.MeleeTiming.Finish;
			}
			break;
		case AnimationPlayerMeleeSkillState.MeleeTiming.Finish:
		{
			base.m_status = AnimationStatus.SUCCESS;
			base.method_16("bMeleeSkill", false);
			BerserkManage berserkManage = base.method_21().PlayerSkillManage_0 as BerserkManage;
			if (berserkManage != null)
			{
				berserkManage.method_26();
				berserkManage.method_23();
			}
			break;
		}
		}
	}

	// Token: 0x0600042E RID: 1070 RVA: 0x00005C2E File Offset: 0x00003E2E
	public override void vmethod_2()
	{
		base.vmethod_2();
		base.m_status = AnimationStatus.SUCCESS;
		base.method_16("bMeleeSkill", false);
		base.method_21().m_pending_melee = false;
	}

	// Token: 0x04000401 RID: 1025
	private float m_startTime;

	// Token: 0x04000402 RID: 1026
	private AnimationPlayerMeleeSkillState.MeleeTiming m_timing;

	// Token: 0x020000B1 RID: 177
	public enum MeleeTiming
	{
		// Token: 0x04000404 RID: 1028
		FirstTick,
		// Token: 0x04000405 RID: 1029
		WaitForTransitionFinish,
		// Token: 0x04000406 RID: 1030
		Playing,
		// Token: 0x04000407 RID: 1031
		Finish
	}
}
