using System;
using UnityEngine;

// Token: 0x02000040 RID: 64
public class AnimationAlertState : AnimationManagerState
{
	// Token: 0x0600018F RID: 399 RVA: 0x0003CE3C File Offset: 0x0003B03C
	public override void vmethod_0()
	{
		base.vmethod_0();
		if (this.m_AnimationManagerFSM.Animator_0 != null)
		{
			if (this.m_isWarning)
			{
				this.m_AnimationManagerFSM.Animator_0.SetBool("IsWarning", true);
				this.m_AnimationManagerFSM.Animator_0.SetBool("IsAlert", false);
			}
			else
			{
				this.m_AnimationManagerFSM.Animator_0.SetBool("IsWarning", false);
				this.m_AnimationManagerFSM.Animator_0.SetBool("IsAlert", true);
			}
		}
		this.m_alertStarted = false;
		base.m_status = AnimationStatus.RUNNING;
	}

	// Token: 0x06000190 RID: 400 RVA: 0x0003CED4 File Offset: 0x0003B0D4
	public override void vmethod_1()
	{
		this.m_animatorInfo = this.m_AnimationManagerFSM.Animator_0.GetCurrentAnimatorStateInfo(0);
		if (this.m_alertStarted)
		{
			if (this.m_isWarning && (!this.m_animatorInfo.IsTag("Alert") || base.method_1(this.m_animatorInfo, this.m_startTime, 0.97f)))
			{
				this.m_AnimationManagerFSM.Animator_0.SetBool("IsWarning", false);
				base.m_status = AnimationStatus.SUCCESS;
			}
		}
		else if (this.m_animatorInfo.IsTag("Alert"))
		{
			this.m_alertStarted = true;
			this.m_startTime = this.m_animatorInfo.normalizedTime;
		}
	}

	// Token: 0x06000191 RID: 401 RVA: 0x00003C3D File Offset: 0x00001E3D
	public override void vmethod_2()
	{
		base.vmethod_2();
		this.m_AnimationManagerFSM.Animator_0.SetBool("IsAlert", false);
		this.m_AnimationManagerFSM.Animator_0.SetBool("IsWarning", false);
		base.m_status = AnimationStatus.SUCCESS;
	}

	// Token: 0x04000177 RID: 375
	private const string ALERT_TAG = "Alert";

	// Token: 0x04000178 RID: 376
	public bool m_alertStarted;

	// Token: 0x04000179 RID: 377
	public bool m_isWarning;

	// Token: 0x0400017A RID: 378
	private AnimatorStateInfo m_animatorInfo;

	// Token: 0x0400017B RID: 379
	private float m_startTime;
}
