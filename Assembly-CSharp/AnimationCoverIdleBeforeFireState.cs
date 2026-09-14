using System;

// Token: 0x0200004A RID: 74
public class AnimationCoverIdleBeforeFireState : AnimationManagerState
{
	// Token: 0x060001B4 RID: 436 RVA: 0x0003D970 File Offset: 0x0003BB70
	public override void vmethod_0()
	{
		this.ElapsedTime = 0f;
		base.vmethod_0();
		if (this.m_AnimationManagerFSM.Animator_0)
		{
			this.m_AnimationManagerFSM.Animator_0.SetBool("IsFiring", false);
			this.m_AnimationManagerFSM.Animator_0.SetBool("IsCasual", false);
			this.m_AnimationManagerFSM.Animator_0.SetInteger("CrouchStatus", 5);
			this.m_AnimationManagerFSM.Animator_0.SetBool("IsCrouching", false);
		}
		base.m_status = AnimationStatus.RUNNING;
	}

	// Token: 0x060001B5 RID: 437 RVA: 0x0000311B File Offset: 0x0000131B
	public override void vmethod_1()
	{
	}

	// Token: 0x060001B6 RID: 438 RVA: 0x00003DB3 File Offset: 0x00001FB3
	public override void vmethod_2()
	{
		base.vmethod_2();
		base.m_status = AnimationStatus.SUCCESS;
	}
}
