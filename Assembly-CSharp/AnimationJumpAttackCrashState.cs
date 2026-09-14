using System;

// Token: 0x0200005F RID: 95
public class AnimationJumpAttackCrashState : AnimationManagerState
{
	// Token: 0x0600020D RID: 525 RVA: 0x000040D6 File Offset: 0x000022D6
	public override void vmethod_0()
	{
		base.vmethod_0();
		this.m_AnimationManagerFSM.Animator_0.SetBool("bJumpAttackCrash", true);
	}

	// Token: 0x0600020E RID: 526 RVA: 0x000040F4 File Offset: 0x000022F4
	public override void vmethod_1()
	{
		if (this.m_AnimationManagerFSM.method_8("JumpAttackCrash", 0.98f) == AnimationStatus.SUCCESS)
		{
			base.m_status = this.m_AnimationManagerFSM.method_8("JumpAttackCrash", 0.98f);
		}
	}

	// Token: 0x0600020F RID: 527 RVA: 0x0003F228 File Offset: 0x0003D428
	public override void vmethod_2()
	{
		base.vmethod_2();
		if (this.m_AnimationManagerFSM.Animator_0 != null)
		{
			this.m_AnimationManagerFSM.Animator_0.SetBool("bJumpAttackCrash", false);
			this.m_AnimationManagerFSM.Animator_0.SetBool("bForceIdle", true);
		}
	}

	// Token: 0x040001E5 RID: 485
	private const string JUMP_ATTACK_CRASH_TAG = "JumpAttackCrash";
}
