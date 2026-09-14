using System;
using UnityEngine;

// Token: 0x02000045 RID: 69
public class AnimationChargeState : AnimationManagerState
{
	// Token: 0x1700000E RID: 14
	// (get) Token: 0x0600019F RID: 415 RVA: 0x00003D02 File Offset: 0x00001F02
	// (set) Token: 0x060001A0 RID: 416 RVA: 0x00003D0A File Offset: 0x00001F0A
	public EAnimationChargeStep EAnimationChargeStep_0
	{
		get
		{
			return this.m_animationChargeStep;
		}
		set
		{
			this.m_animationChargeStep = value;
		}
	}

	// Token: 0x060001A1 RID: 417 RVA: 0x0003D26C File Offset: 0x0003B46C
	public override void vmethod_0()
	{
		base.vmethod_0();
		this.EAnimationChargeStep_0 = EAnimationChargeStep.ChargePre;
		this.m_chargePreStarted = false;
		this.m_chargeEndStarted = false;
		this.m_AnimationManagerFSM.Animator_0.SetBool("bChargeStart", true);
		this.m_AnimationManagerFSM.Animator_0.SetBool("bChargeLoop", false);
		this.m_AnimationManagerFSM.Animator_0.SetBool("bChargeEnd", false);
	}

	// Token: 0x060001A2 RID: 418 RVA: 0x0003D2D8 File Offset: 0x0003B4D8
	public override void vmethod_1()
	{
		this.m_animatorInfo = this.m_AnimationManagerFSM.Animator_0.GetCurrentAnimatorStateInfo(0);
		if (this.EAnimationChargeStep_0 == EAnimationChargeStep.ChargePre)
		{
			if (this.m_chargePreStarted)
			{
				if (!this.m_animatorInfo.IsTag("ChargeStart") || base.method_1(this.m_animatorInfo, this.m_startTime, 0.97f))
				{
					this.EAnimationChargeStep_0 = EAnimationChargeStep.ChargeLoop;
					this.m_AnimationManagerFSM.Animator_0.SetBool("bChargeStart", false);
					this.m_AnimationManagerFSM.Animator_0.SetBool("bChargeLoop", true);
				}
			}
			else
			{
				this.m_AnimationManagerFSM.Animator_0.SetBool("bChargeStart", true);
				if (this.m_animatorInfo.IsTag("ChargeStart") || this.m_animatorInfo.IsTag("ChargeLoop"))
				{
					this.m_chargePreStarted = true;
					this.m_startTime = this.m_animatorInfo.normalizedTime;
				}
			}
		}
		else if (this.EAnimationChargeStep_0 == EAnimationChargeStep.ChargeLoop)
		{
			this.method_4();
			this.method_5();
			if (this.m_animatorInfo.IsTag("ChargeEnd"))
			{
				this.EAnimationChargeStep_0 = EAnimationChargeStep.ChargeReach;
			}
		}
		else if (this.EAnimationChargeStep_0 == EAnimationChargeStep.ChargeReach)
		{
			if (this.m_chargeEndStarted)
			{
				if (!this.m_animatorInfo.IsTag("ChargeEnd") || base.method_1(this.m_animatorInfo, this.m_startTime, 0.97f))
				{
					this.EAnimationChargeStep_0 = EAnimationChargeStep.ChargeFinish;
					this.m_AnimationManagerFSM.Animator_0.SetBool("bChargeEnd", false);
					base.m_status = AnimationStatus.SUCCESS;
				}
			}
			else
			{
				this.m_AnimationManagerFSM.Animator_0.SetBool("bChargeLoop", false);
				this.m_AnimationManagerFSM.Animator_0.SetBool("bChargeEnd", true);
				if (this.m_animatorInfo.IsTag("ChargeEnd"))
				{
					this.m_chargeEndStarted = true;
					this.m_startTime = this.m_animatorInfo.normalizedTime;
				}
			}
		}
	}

	// Token: 0x060001A3 RID: 419 RVA: 0x0003D4C4 File Offset: 0x0003B6C4
	public override void vmethod_2()
	{
		base.vmethod_2();
		this.EAnimationChargeStep_0 = EAnimationChargeStep.ChargeNull;
		this.m_AnimationManagerFSM.Animator_0.SetBool("bChargeStart", false);
		this.m_AnimationManagerFSM.Animator_0.SetBool("bChargeLoop", false);
		this.m_AnimationManagerFSM.Animator_0.SetBool("bChargeEnd", true);
	}

	// Token: 0x060001A4 RID: 420 RVA: 0x0003D520 File Offset: 0x0003B720
	private void method_4()
	{
		if (this.m_AnimationManagerFSM == null)
		{
			return;
		}
		float num = Mathf.Lerp(0.2f, 1f, 1f - this.m_destinationDistanceFactor);
		this.m_AnimationManagerFSM.transform.forward = Vector3.Slerp(this.m_AnimationManagerFSM.transform.forward, this.m_destinationFacing, num).normalized;
		this.m_turnAngle = 0f;
		this.m_AnimationManagerFSM.Animator_0.SetFloat("TurnAngle", this.m_turnAngle);
		this.m_AnimationManagerFSM.Animator_0.SetBool("IsTurning", false);
	}

	// Token: 0x060001A5 RID: 421 RVA: 0x0003D5C8 File Offset: 0x0003B7C8
	private void method_5()
	{
		if (this.m_AnimationManagerFSM == null)
		{
			return;
		}
		float num = Mathf.Lerp(0f, 0.8f, 1f - this.m_destinationDistanceFactor);
		this.m_AnimationManagerFSM.transform.position = Vector3.Lerp(this.m_AnimationManagerFSM.transform.position, this.m_destinationPosition, num);
		this.m_AnimationManagerFSM.GetComponent<EntityNpc>().vmethod_49();
	}

	// Token: 0x0400018C RID: 396
	private const string CHARGE_START_TAG = "ChargeStart";

	// Token: 0x0400018D RID: 397
	private const string CHARGE_END_TAG = "ChargeEnd";

	// Token: 0x0400018E RID: 398
	private const string CHARGE_LOOP_TAG = "ChargeLoop";

	// Token: 0x0400018F RID: 399
	private AnimatorStateInfo m_animatorInfo;

	// Token: 0x04000190 RID: 400
	private float m_startTime;

	// Token: 0x04000191 RID: 401
	private bool m_chargePreStarted;

	// Token: 0x04000192 RID: 402
	private bool m_chargeEndStarted;

	// Token: 0x04000193 RID: 403
	private EAnimationChargeStep m_animationChargeStep;
}
