using System;
using UnityEngine;

// Token: 0x0200007D RID: 125
public class AnimationWarningState : AnimationManagerState
{
	// Token: 0x06000296 RID: 662 RVA: 0x000047E2 File Offset: 0x000029E2
	public override void vmethod_0()
	{
		base.vmethod_0();
		this.m_warningStarted = false;
	}

	// Token: 0x06000297 RID: 663 RVA: 0x0004156C File Offset: 0x0003F76C
	public override void vmethod_1()
	{
		this.m_animatorInfo = this.m_AnimationManagerFSM.Animator_0.GetCurrentAnimatorStateInfo(0);
		if (this.m_warningStarted)
		{
			if (!this.m_animatorInfo.IsTag("Warning") || base.method_1(this.m_animatorInfo, this.m_startTime, 0.97f))
			{
				this.m_AnimationManagerFSM.Animator_0.SetBool("bWarning", false);
				base.m_status = AnimationStatus.SUCCESS;
			}
		}
		else
		{
			if (this.m_AnimationManagerFSM.Animator_0 != null)
			{
				this.m_AnimationManagerFSM.Animator_0.SetBool("bWarning", true);
			}
			if (this.m_animatorInfo.IsTag("Warning"))
			{
				this.m_warningStarted = true;
				this.m_startTime = this.m_animatorInfo.normalizedTime;
			}
		}
	}

	// Token: 0x06000298 RID: 664 RVA: 0x000047F1 File Offset: 0x000029F1
	public override void vmethod_2()
	{
		base.vmethod_2();
		this.m_AnimationManagerFSM.Animator_0.SetBool("bWarning", false);
		base.m_status = AnimationStatus.SUCCESS;
	}

	// Token: 0x04000267 RID: 615
	private const string WARNING_TAG = "Warning";

	// Token: 0x04000268 RID: 616
	public bool m_warningStarted;

	// Token: 0x04000269 RID: 617
	private AnimatorStateInfo m_animatorInfo;

	// Token: 0x0400026A RID: 618
	private float m_startTime;
}
