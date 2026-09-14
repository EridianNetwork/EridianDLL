using System;

// Token: 0x02000050 RID: 80
public class AnimationCriticalState : AnimationManagerState
{
	// Token: 0x060001CB RID: 459 RVA: 0x00003E24 File Offset: 0x00002024
	public AnimationCriticalState()
	{
		this.StateName = "Critical";
		this.m_bStruggleEnd = false;
	}

	// Token: 0x060001CC RID: 460 RVA: 0x00003E3E File Offset: 0x0000203E
	public override void vmethod_0()
	{
		this.m_AnimationManagerFSM.Animator_0.SetBool("IsCritical", true);
		this.m_AnimationManagerFSM.Animator_0.SetBool("IsStruggleLoopEnd", false);
	}

	// Token: 0x060001CD RID: 461 RVA: 0x00003E6C File Offset: 0x0000206C
	public override void vmethod_1()
	{
		if (this.m_AnimationManagerFSM.method_8("struggle_end", 0.98f) == AnimationStatus.SUCCESS)
		{
			this.m_bStruggleEnd = true;
		}
	}

	// Token: 0x060001CE RID: 462 RVA: 0x00003E8D File Offset: 0x0000208D
	public void method_4(bool bool_1)
	{
		this.m_AnimationManagerFSM.Animator_0.SetBool("IsStruggleLoopEnd", bool_1);
	}

	// Token: 0x060001CF RID: 463 RVA: 0x00003EA5 File Offset: 0x000020A5
	public void method_5(bool bool_1)
	{
		this.m_AnimationManagerFSM.Animator_0.SetBool("IsCritical", bool_1);
	}

	// Token: 0x060001D0 RID: 464 RVA: 0x0003DEF4 File Offset: 0x0003C0F4
	public override void vmethod_2()
	{
		base.vmethod_2();
		if (this.m_AnimationManagerFSM.Animator_0 != null)
		{
			this.m_AnimationManagerFSM.Animator_0.SetBool("IsCritical", false);
			this.m_AnimationManagerFSM.Animator_0.SetBool("IsStruggleLoopEnd", true);
		}
		base.m_status = AnimationStatus.SUCCESS;
	}

	// Token: 0x040001B0 RID: 432
	public bool m_bStruggleEnd;
}
