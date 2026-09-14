using System;
using BHV;
using UnityEngine;

// Token: 0x0200005C RID: 92
public class AnimationHurtState : AnimationManagerState
{
	// Token: 0x06000201 RID: 513 RVA: 0x0003ECAC File Offset: 0x0003CEAC
	public override void vmethod_0()
	{
		base.vmethod_0();
		if (this.m_AnimationManagerFSM.Animator_0 != null)
		{
			this.m_AnimationManagerFSM.Animator_0.SetBool("bIdle", true);
			if (this.m_damageType == EDamageType.DT_Critical)
			{
				this.m_AnimationManagerFSM.Animator_0.SetBool("IsInjured", true);
			}
			else if (this.m_damageType == EDamageType.DT_Heavy)
			{
				this.m_AnimationManagerFSM.Animator_0.SetInteger("iHeavyHitType", this.m_heavyHurtAnimIndex);
				this.m_AnimationManagerFSM.Animator_0.SetBool("bHeavyHit", true);
			}
			this.m_hurtStarted = false;
		}
		base.m_status = AnimationStatus.RUNNING;
	}

	// Token: 0x06000202 RID: 514 RVA: 0x0003ED54 File Offset: 0x0003CF54
	public override void vmethod_1()
	{
		this.m_animatorInfo = this.m_AnimationManagerFSM.Animator_0.GetCurrentAnimatorStateInfo(0);
		if (this.m_damageType == EDamageType.DT_Critical)
		{
			if (this.m_hurtStarted)
			{
				if (base.method_1(this.m_animatorInfo, this.m_startTime, 0.98f) || !this.m_animatorInfo.IsTag("InjuryReaction"))
				{
					this.m_AnimationManagerFSM.Animator_0.SetBool("IsInjured", false);
					base.m_status = AnimationStatus.SUCCESS;
				}
			}
			else if (this.m_animatorInfo.IsTag("InjuryReaction"))
			{
				this.m_startTime = this.m_animatorInfo.normalizedTime;
				this.m_hurtStarted = true;
			}
		}
		else if (this.m_damageType == EDamageType.DT_Heavy)
		{
			if (this.m_hurtStarted)
			{
				if (base.method_1(this.m_animatorInfo, this.m_startTime, 0.98f) || !this.m_animatorInfo.IsTag("InjuryReaction"))
				{
					this.m_AnimationManagerFSM.Animator_0.SetBool("bHeavyHit", false);
					base.m_status = AnimationStatus.SUCCESS;
				}
			}
			else if (this.m_animatorInfo.IsTag("InjuryReaction"))
			{
				this.m_startTime = this.m_animatorInfo.normalizedTime;
				this.m_hurtStarted = true;
			}
		}
	}

	// Token: 0x06000203 RID: 515 RVA: 0x0003EE94 File Offset: 0x0003D094
	public override void vmethod_2()
	{
		base.vmethod_2();
		this.m_AnimationManagerFSM.Animator_0.SetBool("IsInjured", false);
		this.m_AnimationManagerFSM.Animator_0.SetBool("bHurtLight", false);
		this.m_AnimationManagerFSM.Animator_0.SetBool("bHeavyHit", false);
		base.m_status = AnimationStatus.SUCCESS;
	}

	// Token: 0x040001D5 RID: 469
	private const string HURT_TAG = "InjuryReaction";

	// Token: 0x040001D6 RID: 470
	private const string HURTLIGHT_TAG = "HurtLight";

	// Token: 0x040001D7 RID: 471
	public bool m_hurtStarted;

	// Token: 0x040001D8 RID: 472
	public EDamageType m_damageType;

	// Token: 0x040001D9 RID: 473
	public int m_heavyHurtAnimIndex;

	// Token: 0x040001DA RID: 474
	private AnimatorStateInfo m_animatorInfo;

	// Token: 0x040001DB RID: 475
	private float m_startTime;
}
