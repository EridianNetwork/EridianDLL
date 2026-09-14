using System;

// Token: 0x0200005B RID: 91
public class AnimationHoverPatrolState : AnimationManagerState
{
	// Token: 0x060001FD RID: 509 RVA: 0x0003EC54 File Offset: 0x0003CE54
	public override void vmethod_0()
	{
		base.vmethod_0();
		if (this.m_AnimationManagerFSM.Animator_0)
		{
			this.m_AnimationManagerFSM.Animator_0.SetBool("IsCasual", true);
			this.m_AnimationManagerFSM.Animator_0.SetFloat("fFlyingSpeed", 10f);
		}
	}

	// Token: 0x060001FE RID: 510 RVA: 0x0000400D File Offset: 0x0000220D
	public override void vmethod_1()
	{
		this.m_AnimationManagerFSM.Animator_0.SetFloat("TurnAngle", this.m_turnAngle);
	}

	// Token: 0x060001FF RID: 511 RVA: 0x00003ED0 File Offset: 0x000020D0
	public override void vmethod_2()
	{
		base.vmethod_2();
	}
}
