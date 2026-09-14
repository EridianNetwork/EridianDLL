using System;
using BHV;

// Token: 0x0200005E RID: 94
public class AnimationIdleState : AnimationManagerState
{
	// Token: 0x06000208 RID: 520 RVA: 0x00004091 File Offset: 0x00002291
	public AnimationIdleState()
	{
		this.StateName = "Idle";
	}

	// Token: 0x06000209 RID: 521 RVA: 0x0003F18C File Offset: 0x0003D38C
	public override void vmethod_0()
	{
		this.ElapsedTime = 0f;
		base.vmethod_0();
		if (this.m_AnimationManagerFSM.Animator_0)
		{
			this.m_AnimationManagerFSM.Animator_0.SetBool("bIdle", true);
			this.m_AnimationManagerFSM.Animator_0.SetFloat("fMoveSpeed", 0f);
			if (this.m_AnimationManagerFSM.m_isHumanoid)
			{
				this.m_AnimationManagerFSM.Animator_0.SetInteger("CrouchStatus", 0);
				this.m_AnimationManagerFSM.Animator_0.SetBool("IsCrouching", false);
			}
		}
	}

	// Token: 0x0600020A RID: 522 RVA: 0x000040A4 File Offset: 0x000022A4
	public override void vmethod_1()
	{
		if (this.m_AnimationManagerFSM.Animator_0)
		{
			this.m_AnimationManagerFSM.Animator_0.SetBool("IsCasual", this.m_stressLevel == BHVStressLevel.RELAX);
		}
	}

	// Token: 0x0600020B RID: 523 RVA: 0x00003ED0 File Offset: 0x000020D0
	public override void vmethod_2()
	{
		base.vmethod_2();
	}

	// Token: 0x040001E4 RID: 484
	public BHVStressLevel m_stressLevel;
}
