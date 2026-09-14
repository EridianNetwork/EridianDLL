using System;
using UnityEngine;

// Token: 0x02000060 RID: 96
public class AnimationJumpAttackState : AnimationManagerState
{
	// Token: 0x17000013 RID: 19
	// (get) Token: 0x06000211 RID: 529 RVA: 0x00004129 File Offset: 0x00002329
	// (set) Token: 0x06000212 RID: 530 RVA: 0x00004131 File Offset: 0x00002331
	public EAnimationJumpStep EAnimationJumpStep_0
	{
		get
		{
			return this.m_animationJumpStep;
		}
		set
		{
			this.m_animationJumpStep = value;
		}
	}

	// Token: 0x06000213 RID: 531 RVA: 0x0003F27C File Offset: 0x0003D47C
	public override void vmethod_0()
	{
		base.vmethod_0();
		this.EAnimationJumpStep_0 = EAnimationJumpStep.JumpPre;
		this.m_takeoffStarted = false;
		this.m_landStarted = false;
		if (this.m_AnimationManagerFSM.Animator_0)
		{
			this.m_AnimationManagerFSM.Animator_0.SetBool("bJumpAttackTakeOff", true);
			this.m_AnimationManagerFSM.Animator_0.SetBool("bJumpAttackLoop", false);
			this.m_AnimationManagerFSM.Animator_0.SetBool("bJumpAttackLand", false);
			this.m_AnimationManagerFSM.Animator_0.SetBool("bForceIdle", false);
		}
	}

	// Token: 0x06000214 RID: 532 RVA: 0x0003F310 File Offset: 0x0003D510
	public override void vmethod_1()
	{
		if (this.m_AnimationManagerFSM.Animator_0 == null)
		{
			return;
		}
		this.m_animatorInfo = this.m_AnimationManagerFSM.Animator_0.GetCurrentAnimatorStateInfo(0);
		if (this.EAnimationJumpStep_0 == EAnimationJumpStep.JumpNull)
		{
			return;
		}
		if (this.EAnimationJumpStep_0 == EAnimationJumpStep.JumpPre)
		{
			if (this.m_takeoffStarted)
			{
				if (!this.m_animatorInfo.IsTag("JumpAttackTakeOff") || base.method_1(this.m_animatorInfo, this.m_startTime, 0.97f))
				{
					this.EAnimationJumpStep_0 = EAnimationJumpStep.JumpLoop;
					this.m_AnimationManagerFSM.Animator_0.SetBool("bJumpAttackLoop", true);
					this.m_AnimationManagerFSM.Animator_0.SetBool("bJumpAttackTakeOff", false);
					this.m_AnimationManagerFSM.Animator_0.SetBool("bJumpAttackLand", false);
				}
			}
			else
			{
				this.m_AnimationManagerFSM.Animator_0.SetBool("bJumpAttackTakeOff", true);
				if (this.m_animatorInfo.IsTag("JumpAttackTakeOff") || this.m_animatorInfo.IsTag("JumpAttackLoop"))
				{
					this.m_takeoffStarted = true;
					this.m_startTime = this.m_animatorInfo.normalizedTime;
				}
			}
		}
		else if (this.EAnimationJumpStep_0 == EAnimationJumpStep.JumpLoop)
		{
			if (this.m_animatorInfo.IsTag("JumpAttackLand"))
			{
				this.EAnimationJumpStep_0 = EAnimationJumpStep.JumpLand;
			}
		}
		else if (this.EAnimationJumpStep_0 == EAnimationJumpStep.JumpLand)
		{
			if (this.m_landStarted)
			{
				if (!this.m_animatorInfo.IsTag("JumpAttackLand") || base.method_1(this.m_animatorInfo, this.m_startTime, 0.97f))
				{
					this.EAnimationJumpStep_0 = EAnimationJumpStep.JumpFinish;
					this.m_AnimationManagerFSM.Animator_0.SetBool("bJumpAttackTakeOff", false);
					this.m_AnimationManagerFSM.Animator_0.SetBool("bJumpAttackLoop", false);
					this.m_AnimationManagerFSM.Animator_0.SetBool("bJumpAttackLand", true);
					base.m_status = AnimationStatus.SUCCESS;
				}
			}
			else
			{
				this.m_AnimationManagerFSM.Animator_0.SetBool("bJumpAttackLand", true);
				if (this.m_animatorInfo.IsTag("JumpAttackLand"))
				{
					this.m_landStarted = true;
					this.m_startTime = this.m_animatorInfo.normalizedTime;
				}
			}
		}
	}

	// Token: 0x06000215 RID: 533 RVA: 0x0003F53C File Offset: 0x0003D73C
	public override void vmethod_2()
	{
		base.vmethod_2();
		if (this.m_AnimationManagerFSM.Animator_0)
		{
			if (this.m_AnimationManagerFSM.m_fullBodyNextState == AnimationStateFSM.JumpAttackCrash)
			{
				this.m_AnimationManagerFSM.Animator_0.SetBool("bJumpAttackTakeOff", false);
				this.m_AnimationManagerFSM.Animator_0.SetBool("bJumpAttackLoop", false);
				this.m_AnimationManagerFSM.Animator_0.SetBool("bJumpAttackLand", false);
			}
			else
			{
				this.m_AnimationManagerFSM.Animator_0.SetBool("bJumpAttackTakeOff", false);
				this.m_AnimationManagerFSM.Animator_0.SetBool("bJumpAttackLoop", false);
				this.m_AnimationManagerFSM.Animator_0.SetBool("bJumpAttackLand", true);
				this.m_AnimationManagerFSM.Animator_0.SetBool("bForceIdle", true);
			}
			this.EAnimationJumpStep_0 = EAnimationJumpStep.JumpNull;
		}
	}

	// Token: 0x040001E6 RID: 486
	private const string JUMP_ATTACK_TAKEOFF_TAG = "JumpAttackTakeOff";

	// Token: 0x040001E7 RID: 487
	private const string JUMP_ATTACK_LAND_TAG = "JumpAttackLand";

	// Token: 0x040001E8 RID: 488
	private const string JUMP_ATTACK_LOOP_TAG = "JumpAttackLoop";

	// Token: 0x040001E9 RID: 489
	private AnimatorStateInfo m_animatorInfo;

	// Token: 0x040001EA RID: 490
	private float m_startTime;

	// Token: 0x040001EB RID: 491
	private bool m_takeoffStarted;

	// Token: 0x040001EC RID: 492
	private bool m_landStarted;

	// Token: 0x040001ED RID: 493
	private EAnimationJumpStep m_animationJumpStep;
}
