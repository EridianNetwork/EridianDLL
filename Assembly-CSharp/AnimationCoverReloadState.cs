using System;
using UnityEngine;

// Token: 0x0200004F RID: 79
public class AnimationCoverReloadState : AnimationManagerState
{
	// Token: 0x060001C8 RID: 456 RVA: 0x0003DD40 File Offset: 0x0003BF40
	public override void vmethod_0()
	{
		base.vmethod_0();
		if (this.m_AnimationManagerFSM.Animator_0)
		{
			this.m_AnimationManagerFSM.Animator_0.SetBool("IsFiring", false);
			this.m_AnimationManagerFSM.Animator_0.SetBool("IsCasual", false);
			this.m_AnimationManagerFSM.Animator_0.SetInteger("CrouchStatus", 1);
			this.m_AnimationManagerFSM.Animator_0.SetBool("IsCrouching", true);
			this.m_AnimationManagerFSM.Animator_0.SetBool("IsReloading", true);
		}
		this.m_reloadStarted = false;
		base.m_status = AnimationStatus.RUNNING;
	}

	// Token: 0x060001C9 RID: 457 RVA: 0x0003DDE4 File Offset: 0x0003BFE4
	public override void vmethod_1()
	{
		if (!(this.m_AnimationManagerFSM == null) && !(this.m_AnimationManagerFSM.Animator_0 == null))
		{
			this.m_animatorInfo = this.m_AnimationManagerFSM.Animator_0.GetCurrentAnimatorStateInfo(1);
			if (this.m_reloadStarted)
			{
				if (base.method_1(this.m_animatorInfo, this.m_startTime, 0.98f) || !this.m_animatorInfo.IsTag("CoverReload"))
				{
					this.m_AnimationManagerFSM.Animator_0.SetBool("IsReloading", false);
					if (this.m_AnimationManagerFSM.m_entity != null && this.m_AnimationManagerFSM.m_entity.vmethod_16() != null)
					{
						this.m_AnimationManagerFSM.m_entity.vmethod_16().OnReloadAnimDone();
					}
					base.m_status = AnimationStatus.SUCCESS;
				}
			}
			else if (this.m_animatorInfo.IsTag("CoverReload"))
			{
				this.m_reloadStarted = true;
				this.m_startTime = this.m_animatorInfo.normalizedTime;
			}
			return;
		}
	}

	// Token: 0x060001CA RID: 458 RVA: 0x00003DEC File Offset: 0x00001FEC
	public override void vmethod_2()
	{
		base.vmethod_2();
		if (this.m_AnimationManagerFSM.Animator_0 != null)
		{
			this.m_AnimationManagerFSM.Animator_0.SetBool("IsReloading", false);
		}
		base.m_status = AnimationStatus.SUCCESS;
	}

	// Token: 0x040001AB RID: 427
	private const string COVERRELOAD_TAG = "CoverReload";

	// Token: 0x040001AC RID: 428
	private const int UPPERBODY_LAYER = 1;

	// Token: 0x040001AD RID: 429
	public bool m_reloadStarted;

	// Token: 0x040001AE RID: 430
	private AnimatorStateInfo m_animatorInfo;

	// Token: 0x040001AF RID: 431
	private float m_startTime;
}
