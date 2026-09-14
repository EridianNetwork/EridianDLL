using System;

// Token: 0x02000059 RID: 89
public class AnimationFlyGatherState : AnimationManagerState
{
	// Token: 0x060001F3 RID: 499 RVA: 0x0003EB1C File Offset: 0x0003CD1C
	public override void vmethod_0()
	{
		base.vmethod_0();
		if (this.m_AnimationManagerFSM.Animator_0)
		{
			this.m_AnimationManagerFSM.Animator_0.SetBool("IsCasual", false);
			this.m_AnimationManagerFSM.Animator_0.SetFloat("fFlyingSpeed", 10f);
		}
	}

	// Token: 0x060001F4 RID: 500 RVA: 0x0000400D File Offset: 0x0000220D
	public override void vmethod_1()
	{
		this.m_AnimationManagerFSM.Animator_0.SetFloat("TurnAngle", this.m_turnAngle);
	}

	// Token: 0x060001F5 RID: 501 RVA: 0x00003ED0 File Offset: 0x000020D0
	public override void vmethod_2()
	{
		base.vmethod_2();
	}
}
