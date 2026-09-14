using System;
using UnityEngine;

// Token: 0x0200006C RID: 108
public class AnimationReloadState : AnimationManagerState
{
	// Token: 0x06000252 RID: 594 RVA: 0x000044AF File Offset: 0x000026AF
	public override void vmethod_0()
	{
		base.vmethod_0();
		this.m_reloadStarted = false;
		base.m_status = AnimationStatus.PREPARE;
	}

	// Token: 0x06000253 RID: 595 RVA: 0x00040414 File Offset: 0x0003E614
	public override void vmethod_1()
	{
		if (!(this.m_AnimationManagerFSM == null) && !(this.m_AnimationManagerFSM.Animator_0 == null))
		{
			if (base.m_status == AnimationStatus.PREPARE)
			{
				this.m_animatorInfo = this.m_AnimationManagerFSM.Animator_0.GetCurrentAnimatorStateInfo(0);
				if (!this.m_animatorInfo.IsTag("Fire"))
				{
					base.m_status = AnimationStatus.RUNNING;
				}
			}
			else if (base.m_status == AnimationStatus.RUNNING)
			{
				this.m_animatorInfo = this.m_AnimationManagerFSM.Animator_0.GetCurrentAnimatorStateInfo(1);
				if (this.m_reloadStarted)
				{
					if (base.method_1(this.m_animatorInfo, this.m_startTime, 0.98f) || !this.m_animatorInfo.IsTag("StandReload"))
					{
						this.m_AnimationManagerFSM.Animator_0.SetBool("IsReloading", false);
						if (this.m_AnimationManagerFSM.m_entity != null && this.m_AnimationManagerFSM.m_entity.vmethod_16() != null)
						{
							this.m_AnimationManagerFSM.m_entity.vmethod_16().OnReloadAnimDone();
						}
						base.m_status = AnimationStatus.SUCCESS;
					}
				}
				else
				{
					this.m_AnimationManagerFSM.Animator_0.SetBool("IsReloading", true);
					if (this.m_animatorInfo.IsTag("StandReload"))
					{
						this.m_reloadStarted = true;
						this.m_startTime = this.m_animatorInfo.normalizedTime;
					}
				}
			}
			return;
		}
	}

	// Token: 0x06000254 RID: 596 RVA: 0x00003DEC File Offset: 0x00001FEC
	public override void vmethod_2()
	{
		base.vmethod_2();
		if (this.m_AnimationManagerFSM.Animator_0 != null)
		{
			this.m_AnimationManagerFSM.Animator_0.SetBool("IsReloading", false);
		}
		base.m_status = AnimationStatus.SUCCESS;
	}

	// Token: 0x0400022A RID: 554
	private const string RELOAD_TAG = "StandReload";

	// Token: 0x0400022B RID: 555
	private const int UPPERBODY_LAYER = 1;

	// Token: 0x0400022C RID: 556
	public bool m_reloadStarted;

	// Token: 0x0400022D RID: 557
	private AnimatorStateInfo m_animatorInfo;

	// Token: 0x0400022E RID: 558
	private float m_startTime;
}
