using System;
using UnityEngine;

// Token: 0x02000074 RID: 116
public class AnimationStunState : AnimationManagerState
{
	// Token: 0x06000271 RID: 625 RVA: 0x00040B34 File Offset: 0x0003ED34
	public override void vmethod_0()
	{
		base.vmethod_0();
		this.m_AnimationManagerFSM.Animator_0.SetBool("bExitTurn", true);
		this.m_AnimationManagerFSM.Animator_0.SetBool("IsStun", true);
		this.m_stunStarted = false;
		if (this.m_VFXManager)
		{
			this.m_VFXManager.method_4(ENPCParticleType.E_Stun, 0f, true);
		}
		base.m_status = AnimationStatus.RUNNING;
	}

	// Token: 0x06000272 RID: 626 RVA: 0x00040BA4 File Offset: 0x0003EDA4
	public override void vmethod_1()
	{
		if (!(this.m_AnimationManagerFSM == null) && !(this.m_AnimationManagerFSM.Animator_0 == null))
		{
			this.m_animatorInfo = this.m_AnimationManagerFSM.Animator_0.GetCurrentAnimatorStateInfo(0);
			if (this.m_stunStarted)
			{
				if (base.method_1(this.m_animatorInfo, this.m_startTime, 0.98f) || !this.m_animatorInfo.IsTag("Stun"))
				{
					this.m_AnimationManagerFSM.Animator_0.SetBool("IsStun", false);
					base.m_status = AnimationStatus.SUCCESS;
				}
			}
			else
			{
				this.m_AnimationManagerFSM.Animator_0.SetBool("IsStun", true);
				if (this.m_animatorInfo.IsTag("Stun"))
				{
					this.m_stunStarted = true;
					this.m_startTime = this.m_animatorInfo.normalizedTime;
				}
			}
			return;
		}
	}

	// Token: 0x06000273 RID: 627 RVA: 0x00040C84 File Offset: 0x0003EE84
	public override void vmethod_2()
	{
		base.vmethod_2();
		if (this.m_AnimationManagerFSM.Animator_0 != null)
		{
			this.m_AnimationManagerFSM.Animator_0.SetBool("IsStun", false);
		}
		if (this.m_VFXManager)
		{
			this.m_VFXManager.method_13(ENPCParticleType.E_Stun);
		}
	}

	// Token: 0x0400024B RID: 587
	private const string STUN_TAG = "Stun";

	// Token: 0x0400024C RID: 588
	private const int STUN_LAYER = 0;

	// Token: 0x0400024D RID: 589
	public bool m_stunStarted;

	// Token: 0x0400024E RID: 590
	private AnimatorStateInfo m_animatorInfo;

	// Token: 0x0400024F RID: 591
	private float m_startTime;
}
