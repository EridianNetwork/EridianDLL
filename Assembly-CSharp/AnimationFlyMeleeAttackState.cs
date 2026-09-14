using System;

// Token: 0x0200005A RID: 90
public class AnimationFlyMeleeAttackState : AnimationManagerState
{
	// Token: 0x060001F7 RID: 503 RVA: 0x0003EB74 File Offset: 0x0003CD74
	public override void vmethod_0()
	{
		base.vmethod_0();
		if (this.m_AnimationManagerFSM != null)
		{
			this.m_AnimationManagerFSM.Animator_0.SetBool("bStartDive", true);
			this.m_AnimationManagerFSM.Animator_0.SetBool("bStartMeleeAttack", false);
			this.m_AnimationManagerFSM.Animator_0.SetBool("bMeleeAttackEnd", false);
		}
	}

	// Token: 0x060001F8 RID: 504 RVA: 0x0000311B File Offset: 0x0000131B
	public override void vmethod_1()
	{
	}

	// Token: 0x060001F9 RID: 505 RVA: 0x0003EBD8 File Offset: 0x0003CDD8
	public override void vmethod_2()
	{
		base.vmethod_2();
		if (this.m_AnimationManagerFSM != null)
		{
			this.m_AnimationManagerFSM.Animator_0.SetBool("bStartDive", false);
			this.m_AnimationManagerFSM.Animator_0.SetBool("bStartMeleeAttack", false);
			this.m_AnimationManagerFSM.Animator_0.SetBool("bMeleeAttackEnd", true);
			this.m_AnimationManagerFSM.Animator_0.SetBool("IsCasual", false);
		}
	}

	// Token: 0x060001FA RID: 506 RVA: 0x0000402A File Offset: 0x0000222A
	public void method_4(bool bool_1)
	{
		if (this.m_AnimationManagerFSM.Animator_0)
		{
			this.m_AnimationManagerFSM.Animator_0.SetBool("bStartMeleeAttack", bool_1);
		}
	}

	// Token: 0x060001FB RID: 507 RVA: 0x00004054 File Offset: 0x00002254
	public void method_5(bool bool_1)
	{
		if (this.m_AnimationManagerFSM.Animator_0)
		{
			this.m_AnimationManagerFSM.Animator_0.SetBool("bMeleeAttackEnd", bool_1);
		}
	}
}
