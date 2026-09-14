using System;
using UnityEngine;

// Token: 0x0200006B RID: 107
public class AnimationRailgunAttackState : AnimationManagerState
{
	// Token: 0x0600024E RID: 590 RVA: 0x0000447B File Offset: 0x0000267B
	public override void vmethod_0()
	{
		base.vmethod_0();
		this.m_attackStarted = false;
	}

	// Token: 0x0600024F RID: 591 RVA: 0x00040340 File Offset: 0x0003E540
	public override void vmethod_1()
	{
		this.m_animatorInfo = this.m_AnimationManagerFSM.Animator_0.GetCurrentAnimatorStateInfo(0);
		if (this.m_attackStarted)
		{
			if (base.method_1(this.m_animatorInfo, this.m_startTime, 0.98f) || !this.m_animatorInfo.IsTag("Railgun"))
			{
				this.m_AnimationManagerFSM.Animator_0.SetBool("bRailgunAttack", false);
				base.m_status = AnimationStatus.SUCCESS;
			}
		}
		else
		{
			this.m_AnimationManagerFSM.Animator_0.SetBool("bRailgunAttack", true);
			this.m_AnimationManagerFSM.Animator_0.SetInteger("iRailgunAttackIndex", this.m_railgunAttackIndex);
			if (this.m_animatorInfo.IsTag("Railgun"))
			{
				this.m_attackStarted = true;
				this.m_startTime = this.m_animatorInfo.normalizedTime;
			}
		}
	}

	// Token: 0x06000250 RID: 592 RVA: 0x0000448A File Offset: 0x0000268A
	public override void vmethod_2()
	{
		base.vmethod_2();
		this.m_AnimationManagerFSM.Animator_0.SetBool("bRailgunAttack", false);
		base.m_status = AnimationStatus.SUCCESS;
	}

	// Token: 0x04000225 RID: 549
	private const string RAILGUN_TAG = "Railgun";

	// Token: 0x04000226 RID: 550
	public int m_railgunAttackIndex;

	// Token: 0x04000227 RID: 551
	public bool m_attackStarted;

	// Token: 0x04000228 RID: 552
	private AnimatorStateInfo m_animatorInfo;

	// Token: 0x04000229 RID: 553
	private float m_startTime;
}
