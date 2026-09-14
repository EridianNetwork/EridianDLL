using System;
using UnityEngine;

// Token: 0x02000057 RID: 87
public class AnimationFireFullBodyState : AnimationFireState
{
	// Token: 0x060001E6 RID: 486 RVA: 0x0003E69C File Offset: 0x0003C89C
	public override void vmethod_0()
	{
		base.vmethod_0();
		this.m_shotPending = false;
		if (this.method_4())
		{
			int num = ((!this.m_fallBackAfterShot) ? 1 : 0);
			this.m_AnimationManagerFSM.Animator_0.SetInteger("StanceMode", num);
		}
	}

	// Token: 0x060001E7 RID: 487 RVA: 0x00003F95 File Offset: 0x00002195
	public bool method_4()
	{
		return this.m_entityNPC.m_subType == EntityNpc.EntitySubType.CHR_MidgetShotgunner;
	}

	// Token: 0x060001E8 RID: 488 RVA: 0x0003E6E4 File Offset: 0x0003C8E4
	public override void vmethod_1()
	{
		if (this.m_fireStep == EAnimationFireStep.FireShooting)
		{
			base.m_status = AnimationStatus.RUNNING;
			if (this.m_fireTime <= 0f)
			{
				this.m_fireStep = EAnimationFireStep.FireIdle;
				this.m_firstShotPending = false;
				this.m_lastShotPending = true;
				this.m_AnimationManagerFSM.Animator_0.SetBool("IsFiring", false);
			}
			else
			{
				this.m_fireTime -= Time.deltaTime;
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
			if (this.m_AnimationManagerFSM.Animator_0.GetCurrentAnimatorStateInfo(0).IsTag("Fire"))
			{
				return;
			}
			base.m_status = AnimationStatus.SUCCESS;
		}
	}

	// Token: 0x060001E9 RID: 489 RVA: 0x00003FA9 File Offset: 0x000021A9
	public override void vmethod_2()
	{
		base.m_status = AnimationStatus.SUCCESS;
		this.m_firstShotPending = false;
		this.m_lastShotPending = false;
		base.vmethod_2();
		this.m_AnimationManagerFSM.Animator_0.SetBool("IsFiring", false);
	}

	// Token: 0x040001C6 RID: 454
	public bool m_fallBackAfterShot;

	// Token: 0x040001C7 RID: 455
	public bool m_shotPending;
}
