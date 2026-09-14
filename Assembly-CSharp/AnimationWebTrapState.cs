using System;

// Token: 0x0200007E RID: 126
public class AnimationWebTrapState : AnimationManagerState
{
	// Token: 0x0600029A RID: 666 RVA: 0x00004829 File Offset: 0x00002A29
	public override void vmethod_0()
	{
		base.vmethod_0();
		this.m_bThrowWebTrap = false;
		this.m_AnimationManagerFSM.Animator_0.SetBool("bExitTurn", true);
		this.m_AnimationManagerFSM.Animator_0.SetBool("bThrowWebTrap", true);
	}

	// Token: 0x0600029B RID: 667 RVA: 0x00004864 File Offset: 0x00002A64
	public override void vmethod_1()
	{
		if (this.m_AnimationManagerFSM.method_8(this.m_animationTag, 0.98f) == AnimationStatus.SUCCESS)
		{
			base.m_status = AnimationStatus.SUCCESS;
			this.m_AnimationManagerFSM.Animator_0.SetBool("bThrowWebTrap", false);
		}
	}

	// Token: 0x0600029C RID: 668 RVA: 0x0000489C File Offset: 0x00002A9C
	public override void vmethod_2()
	{
		base.vmethod_2();
		this.m_AnimationManagerFSM.Animator_0.SetBool("bThrowWebTrap", false);
	}

	// Token: 0x0400026B RID: 619
	private string m_animationTag = "ThrowWebTrap";

	// Token: 0x0400026C RID: 620
	public bool m_bThrowWebTrap;
}
