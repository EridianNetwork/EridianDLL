using System;
using UnityEngine;

// Token: 0x02000062 RID: 98
public class AnimationLaserSweepState : AnimationManagerState
{
	// Token: 0x0600021A RID: 538 RVA: 0x0000417D File Offset: 0x0000237D
	public AnimationLaserSweepState()
	{
		this.StateName = "LaserSweep";
	}

	// Token: 0x17000014 RID: 20
	// (get) Token: 0x0600021B RID: 539 RVA: 0x0000419B File Offset: 0x0000239B
	// (set) Token: 0x0600021C RID: 540 RVA: 0x000041A3 File Offset: 0x000023A3
	public bool m_triggetHitEvent { get; set; }

	// Token: 0x0600021D RID: 541 RVA: 0x0003F674 File Offset: 0x0003D874
	public override void vmethod_0()
	{
		base.vmethod_0();
		this.m_AnimationManagerFSM.Animator_0.SetBool("bIdle", true);
		this.m_AnimationManagerFSM.Animator_0.SetBool("bLaserSweep", true);
		this.m_AnimationManagerFSM.Animator_0.SetFloat("fMoveSpeed", 0f);
		if (this.m_AnimationManagerFSM.m_isHumanoid)
		{
			this.m_AnimationManagerFSM.Animator_0.SetBool("IsCasual", false);
		}
		this.m_sweepStarted = false;
	}

	// Token: 0x0600021E RID: 542 RVA: 0x0003F6F8 File Offset: 0x0003D8F8
	public override void vmethod_1()
	{
		this.m_animatorInfo = this.m_AnimationManagerFSM.Animator_0.GetCurrentAnimatorStateInfo(0);
		if (this.m_sweepStarted)
		{
			if (!this.m_animatorInfo.IsTag(this.m_animationTag) || base.method_1(this.m_animatorInfo, this.m_startTime, 0.98f))
			{
				base.m_status = AnimationStatus.SUCCESS;
				this.m_AnimationManagerFSM.Animator_0.SetBool("bLaserSweep", false);
			}
		}
		else
		{
			this.m_AnimationManagerFSM.Animator_0.SetBool("bLaserSweep", true);
			if (this.m_animatorInfo.IsTag(this.m_animationTag))
			{
				this.m_sweepStarted = true;
				this.m_startTime = this.m_animatorInfo.normalizedTime;
			}
		}
	}

	// Token: 0x0600021F RID: 543 RVA: 0x000041AC File Offset: 0x000023AC
	public override void vmethod_2()
	{
		base.m_status = AnimationStatus.SUCCESS;
		this.m_AnimationManagerFSM.Animator_0.SetBool("bLaserSweep", false);
		base.vmethod_2();
	}

	// Token: 0x040001F1 RID: 497
	private string m_animationTag = "LaserSweep";

	// Token: 0x040001F2 RID: 498
	private bool m_sweepStarted;

	// Token: 0x040001F3 RID: 499
	private AnimatorStateInfo m_animatorInfo;

	// Token: 0x040001F4 RID: 500
	private float m_startTime;
}
