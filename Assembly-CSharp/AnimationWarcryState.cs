using System;
using UnityEngine;

// Token: 0x0200007C RID: 124
public class AnimationWarcryState : AnimationManagerState
{
	// Token: 0x06000292 RID: 658 RVA: 0x000047B5 File Offset: 0x000029B5
	public override void vmethod_0()
	{
		base.vmethod_0();
		this.m_warcryStarted = false;
	}

	// Token: 0x06000293 RID: 659 RVA: 0x00041498 File Offset: 0x0003F698
	public override void vmethod_1()
	{
		this.m_animatorInfo = this.m_AnimationManagerFSM.Animator_0.GetCurrentAnimatorStateInfo(0);
		if (this.m_warcryStarted)
		{
			if (base.method_1(this.m_animatorInfo, this.m_startTime, 0.98f) || !this.m_animatorInfo.IsTag("Howl"))
			{
				this.m_AnimationManagerFSM.Animator_0.SetBool("bWarcry", false);
				base.m_status = AnimationStatus.SUCCESS;
			}
		}
		else
		{
			this.m_AnimationManagerFSM.Animator_0.SetBool("bWarcry", true);
			this.m_AnimationManagerFSM.Animator_0.SetFloat("fWarcryPhase", (float)this.m_WarcryPhase);
			if (this.m_animatorInfo.IsTag("Howl"))
			{
				this.m_warcryStarted = true;
				this.m_startTime = this.m_animatorInfo.normalizedTime;
			}
		}
	}

	// Token: 0x06000294 RID: 660 RVA: 0x000047C4 File Offset: 0x000029C4
	public override void vmethod_2()
	{
		base.vmethod_2();
		this.m_AnimationManagerFSM.Animator_0.SetBool("bWarcry", false);
	}

	// Token: 0x04000262 RID: 610
	private const string WARCRY_TAG = "Howl";

	// Token: 0x04000263 RID: 611
	public bool m_warcryStarted;

	// Token: 0x04000264 RID: 612
	public int m_WarcryPhase;

	// Token: 0x04000265 RID: 613
	private AnimatorStateInfo m_animatorInfo;

	// Token: 0x04000266 RID: 614
	private float m_startTime;
}
