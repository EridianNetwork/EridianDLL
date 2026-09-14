using System;

// Token: 0x02000073 RID: 115
public class AnimationSpitState : AnimationManagerState
{
	// Token: 0x0600026C RID: 620 RVA: 0x00040AD0 File Offset: 0x0003ECD0
	public override void vmethod_0()
	{
		base.vmethod_0();
		this.m_bSpitAttackAnimFinished = false;
		this.m_AnimationManagerFSM.Animator_0.SetBool("bIdle", true);
		this.m_AnimationManagerFSM.Animator_0.SetBool("bSpitAttack", true);
		this.m_AnimationManagerFSM.Animator_0.SetInteger("SpitAttackIndex", this.m_spitAttackIndex);
	}

	// Token: 0x0600026D RID: 621 RVA: 0x0000462C File Offset: 0x0000282C
	public override void vmethod_1()
	{
		if (this.m_AnimationManagerFSM.method_8("spit", 0.98f) == AnimationStatus.SUCCESS)
		{
			this.m_AnimationManagerFSM.Animator_0.SetBool("bSpitAttack", false);
			this.m_bSpitAttackAnimFinished = true;
		}
	}

	// Token: 0x0600026E RID: 622 RVA: 0x00004663 File Offset: 0x00002863
	public override void vmethod_2()
	{
		base.vmethod_2();
		this.m_AnimationManagerFSM.Animator_0.SetBool("bSpitAttack", false);
	}

	// Token: 0x0600026F RID: 623 RVA: 0x00004681 File Offset: 0x00002881
	public void method_4(bool bool_1)
	{
		this.m_AnimationManagerFSM.Animator_0.SetBool("bSpitAttack", bool_1);
	}

	// Token: 0x04000249 RID: 585
	public int m_spitAttackIndex;

	// Token: 0x0400024A RID: 586
	public bool m_bSpitAttackAnimFinished;
}
