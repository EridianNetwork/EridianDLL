using System;
using UnityEngine;

// Token: 0x02000077 RID: 119
public class AnimationThrowWeaponState : AnimationManagerState
{
	// Token: 0x06000281 RID: 641 RVA: 0x000046F1 File Offset: 0x000028F1
	public override void vmethod_0()
	{
		base.vmethod_0();
		this.m_throwStarted = false;
		this.m_throwLayerIndex = 0;
		this.m_readyToLaunch = false;
		this.m_spawnNewWeapon = false;
		this.m_AnimationManagerFSM.Animator_0.SetFloat("fMoveSpeed", 0f);
	}

	// Token: 0x06000282 RID: 642 RVA: 0x00040FBC File Offset: 0x0003F1BC
	public override void vmethod_1()
	{
		this.m_animatorInfo = this.m_AnimationManagerFSM.Animator_0.GetCurrentAnimatorStateInfo(this.m_throwLayerIndex);
		if (this.m_throwStarted)
		{
			if (base.method_1(this.m_animatorInfo, this.m_startTime, 0.98f) || !this.m_animatorInfo.IsTag("ThrowWeapon"))
			{
				this.m_AnimationManagerFSM.Animator_0.SetBool("bThrowWeapon", false);
				base.m_status = AnimationStatus.SUCCESS;
			}
		}
		else
		{
			this.m_AnimationManagerFSM.Animator_0.SetBool("bThrowWeapon", true);
			if (this.m_animatorInfo.IsTag("ThrowWeapon"))
			{
				this.m_throwStarted = true;
				this.m_startTime = this.m_animatorInfo.normalizedTime;
			}
		}
	}

	// Token: 0x06000283 RID: 643 RVA: 0x0000472F File Offset: 0x0000292F
	public override void vmethod_2()
	{
		base.vmethod_2();
		this.m_AnimationManagerFSM.Animator_0.SetBool("bThrowWeapon", false);
	}

	// Token: 0x04000259 RID: 601
	private const string THROW_TAG = "ThrowWeapon";

	// Token: 0x0400025A RID: 602
	public bool m_throwStarted;

	// Token: 0x0400025B RID: 603
	private AnimatorStateInfo m_animatorInfo;

	// Token: 0x0400025C RID: 604
	private float m_startTime;

	// Token: 0x0400025D RID: 605
	private int m_throwLayerIndex;

	// Token: 0x0400025E RID: 606
	public bool m_readyToLaunch;

	// Token: 0x0400025F RID: 607
	public bool m_spawnNewWeapon;
}
