using System;
using UnityEngine;

// Token: 0x02000052 RID: 82
public class AnimationDeployAidStationState : AnimationManagerState
{
	// Token: 0x060001D5 RID: 469 RVA: 0x00003ED8 File Offset: 0x000020D8
	public AnimationDeployAidStationState()
	{
		this.StateName = "DeployAidStation";
	}

	// Token: 0x060001D6 RID: 470 RVA: 0x00003EEB File Offset: 0x000020EB
	public override void vmethod_0()
	{
		base.vmethod_0();
		this.m_deployStarted = false;
	}

	// Token: 0x060001D7 RID: 471 RVA: 0x0003DF50 File Offset: 0x0003C150
	public override void vmethod_1()
	{
		if (!(this.m_AnimationManagerFSM == null) && !(this.m_AnimationManagerFSM.Animator_0 == null))
		{
			this.m_animatorInfo = this.m_AnimationManagerFSM.Animator_0.GetCurrentAnimatorStateInfo(0);
			if (this.m_deployStarted)
			{
				if (base.method_1(this.m_animatorInfo, this.m_startTime, 0.98f) || !this.m_animatorInfo.IsTag("DeployStation"))
				{
					this.m_AnimationManagerFSM.Animator_0.SetBool("bDeployStation", false);
					base.m_status = AnimationStatus.SUCCESS;
				}
			}
			else
			{
				this.m_AnimationManagerFSM.Animator_0.SetBool("bDeployStation", true);
				if (this.m_animatorInfo.IsTag("DeployStation"))
				{
					this.m_deployStarted = true;
					this.m_startTime = this.m_animatorInfo.normalizedTime;
				}
			}
			return;
		}
	}

	// Token: 0x060001D8 RID: 472 RVA: 0x00003EFA File Offset: 0x000020FA
	public override void vmethod_2()
	{
		base.vmethod_2();
		if (this.m_AnimationManagerFSM.Animator_0 != null)
		{
			this.m_AnimationManagerFSM.Animator_0.SetBool("bDeployStation", false);
		}
		base.m_status = AnimationStatus.SUCCESS;
	}

	// Token: 0x040001B1 RID: 433
	private const string DEPLOY_TAG = "DeployStation";

	// Token: 0x040001B2 RID: 434
	public bool m_deployStarted;

	// Token: 0x040001B3 RID: 435
	private AnimatorStateInfo m_animatorInfo;

	// Token: 0x040001B4 RID: 436
	private float m_startTime;
}
