using System;
using UnityEngine;

// Token: 0x02000044 RID: 68
public class AnimationChargeHitState : AnimationManagerState
{
	// Token: 0x0600019B RID: 411 RVA: 0x0003D104 File Offset: 0x0003B304
	public override void vmethod_0()
	{
		base.vmethod_0();
		this.m_AnimationManagerFSM.Animator_0.SetBool("bChargeStart", false);
		this.m_AnimationManagerFSM.Animator_0.SetBool("bChargeLoop", false);
		this.m_AnimationManagerFSM.Animator_0.SetBool("bChargeEnd", true);
	}

	// Token: 0x0600019C RID: 412 RVA: 0x0003D15C File Offset: 0x0003B35C
	public override void vmethod_1()
	{
		this.m_animatorInfo = this.m_AnimationManagerFSM.Animator_0.GetCurrentAnimatorStateInfo(0);
		if (this.m_chargeStarted)
		{
			if (!this.m_animatorInfo.IsTag("ChargeEnd") || base.method_1(this.m_animatorInfo, this.m_startTime, 0.97f))
			{
				base.m_status = AnimationStatus.SUCCESS;
				this.m_AnimationManagerFSM.Animator_0.SetBool("bChargeEnd", false);
			}
		}
		else
		{
			this.m_AnimationManagerFSM.Animator_0.SetBool("bChargeEnd", true);
			if (this.m_animatorInfo.IsTag("ChargeEnd"))
			{
				this.m_chargeStarted = true;
				this.m_startTime = this.m_animatorInfo.normalizedTime;
			}
		}
	}

	// Token: 0x0600019D RID: 413 RVA: 0x0003D214 File Offset: 0x0003B414
	public override void vmethod_2()
	{
		base.vmethod_2();
		this.m_AnimationManagerFSM.Animator_0.SetBool("bChargeStart", false);
		this.m_AnimationManagerFSM.Animator_0.SetBool("bChargeLoop", false);
		this.m_AnimationManagerFSM.Animator_0.SetBool("bChargeEnd", false);
	}

	// Token: 0x04000188 RID: 392
	private const string CHARGE_END_TAG = "ChargeEnd";

	// Token: 0x04000189 RID: 393
	public bool m_chargeStarted;

	// Token: 0x0400018A RID: 394
	private AnimatorStateInfo m_animatorInfo;

	// Token: 0x0400018B RID: 395
	private float m_startTime;
}
