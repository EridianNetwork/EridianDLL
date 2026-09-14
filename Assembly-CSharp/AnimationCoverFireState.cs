using System;
using UnityEngine;

// Token: 0x02000049 RID: 73
public class AnimationCoverFireState : AnimationManagerState
{
	// Token: 0x1700000F RID: 15
	// (get) Token: 0x060001AC RID: 428 RVA: 0x00003D53 File Offset: 0x00001F53
	// (set) Token: 0x060001AD RID: 429 RVA: 0x00003D5B File Offset: 0x00001F5B
	public float Single_0
	{
		get
		{
			return this.m_fireDuration;
		}
		set
		{
			this.m_fireDuration = value;
		}
	}

	// Token: 0x17000010 RID: 16
	// (get) Token: 0x060001AE RID: 430 RVA: 0x00003D64 File Offset: 0x00001F64
	// (set) Token: 0x060001AF RID: 431 RVA: 0x00003D6C File Offset: 0x00001F6C
	public float Single_1
	{
		get
		{
			return this.m_fireIdleDuration;
		}
		set
		{
			this.m_fireIdleDuration = value;
		}
	}

	// Token: 0x060001B0 RID: 432 RVA: 0x0003D7DC File Offset: 0x0003B9DC
	public override void vmethod_0()
	{
		base.vmethod_0();
		this.m_fireTime = this.m_fireDuration;
		this.m_fireIdleTime = this.m_fireIdleDuration;
		if (this.m_fireTime < 0f)
		{
			this.m_fireTime = 1f;
		}
		if (this.m_fireIdleTime < 0f)
		{
			this.m_fireIdleTime = 1f;
		}
		base.m_status = AnimationStatus.RUNNING;
		this.m_animationEventController = this.m_AnimationManagerFSM.m_animationEventController;
		this.m_AnimationManagerFSM.Animator_0.SetBool("IsFiring", true);
		this.m_AnimationManagerFSM.Animator_0.SetBool("IsCasual", false);
		this.m_AnimationManagerFSM.Animator_0.SetInteger("CrouchStatus", 5);
		this.m_AnimationManagerFSM.Animator_0.SetBool("IsCrouching", false);
		this.m_fireStep = EAnimationFireStep.FireShooting;
	}

	// Token: 0x060001B1 RID: 433 RVA: 0x0003D8B0 File Offset: 0x0003BAB0
	public override void vmethod_1()
	{
		if (this.m_fireStep == EAnimationFireStep.FireShooting)
		{
			if (this.m_fireTime <= 0f)
			{
				this.m_fireStep = EAnimationFireStep.FireIdle;
				if (this.m_animationEventController != null)
				{
					this.m_animationEventController.OnBanditShootStop();
				}
				this.m_AnimationManagerFSM.Animator_0.SetBool("IsFiring", false);
			}
			else
			{
				this.m_fireTime -= Time.deltaTime;
				if (this.m_animationEventController != null)
				{
				}
			}
		}
		else if (this.m_fireStep == EAnimationFireStep.FireIdle)
		{
			if (this.m_fireIdleTime <= 0f)
			{
				this.m_fireStep = EAnimationFireStep.FireFinish;
			}
			else
			{
				this.m_fireIdleTime -= Time.deltaTime;
			}
		}
		else if (this.m_fireStep == EAnimationFireStep.FireFinish)
		{
			base.m_status = AnimationStatus.SUCCESS;
		}
	}

	// Token: 0x060001B2 RID: 434 RVA: 0x00003D75 File Offset: 0x00001F75
	public override void vmethod_2()
	{
		base.m_status = AnimationStatus.SUCCESS;
		base.vmethod_2();
		if (this.m_animationEventController != null)
		{
			this.m_animationEventController.OnBanditShootStop();
		}
		this.m_AnimationManagerFSM.Animator_0.SetBool("IsFiring", false);
	}

	// Token: 0x0400019F RID: 415
	private const string FIRE_TAG = "Fire";

	// Token: 0x040001A0 RID: 416
	public AnimationEventController m_animationEventController;

	// Token: 0x040001A1 RID: 417
	public EAnimationFireStep m_fireStep;

	// Token: 0x040001A2 RID: 418
	private float m_fireDuration;

	// Token: 0x040001A3 RID: 419
	private float m_fireTime;

	// Token: 0x040001A4 RID: 420
	private float m_fireIdleDuration;

	// Token: 0x040001A5 RID: 421
	private float m_fireIdleTime;
}
