using System;

// Token: 0x0200004B RID: 75
public class AnimationCoverIdleState : AnimationManagerState
{
	// Token: 0x060001B8 RID: 440 RVA: 0x0003D970 File Offset: 0x0003BB70
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

	// Token: 0x060001B9 RID: 441 RVA: 0x0000311B File Offset: 0x0000131B
	public override void vmethod_1()
	{
	}

	// Token: 0x060001BA RID: 442 RVA: 0x00003DB3 File Offset: 0x00001FB3
	public override void vmethod_2()
	{
		base.vmethod_2();
		base.m_status = AnimationStatus.SUCCESS;
	}
}
