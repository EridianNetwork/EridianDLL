using System;

// Token: 0x02000063 RID: 99
public class AnimationLavaStrikeState : AnimationManagerState
{
	// Token: 0x06000221 RID: 545 RVA: 0x0003F7B0 File Offset: 0x0003D9B0
	public override void vmethod_0()
	{
		base.vmethod_0();
		this.m_bLavaStrikeEnd = false;
		this.m_bLanded = false;
		this.m_bJumpLoop = false;
		if (this.m_AnimationManagerFSM.Animator_0)
		{
			this.m_AnimationManagerFSM.Animator_0.SetBool("bStartLavaStrikeJump", true);
			this.m_AnimationManagerFSM.Animator_0.SetBool("bLavaStrikeJumpLand", false);
			this.m_AnimationManagerFSM.Animator_0.SetBool("bLavaStrikeEnd", false);
		}
	}

	// Token: 0x06000222 RID: 546 RVA: 0x0003F82C File Offset: 0x0003DA2C
	public override void vmethod_1()
	{
		if (this.m_bLavaStrikeEnd)
		{
			return;
		}
		if (!this.m_bJumpLoop && this.m_AnimationManagerFSM.Animator_0.GetCurrentAnimatorStateInfo(0).IsTag("JumpLoop"))
		{
			this.m_bJumpLoop = true;
		}
		if (this.m_bLanded && this.m_AnimationManagerFSM.method_8("LavaStrike", 0.98f) == AnimationStatus.SUCCESS)
		{
			this.m_bLavaStrikeEnd = true;
			this.m_AnimationManagerFSM.Animator_0.SetBool("bLavaStrikeEnd", true);
		}
	}

	// Token: 0x06000223 RID: 547 RVA: 0x0003F8B0 File Offset: 0x0003DAB0
	public override void vmethod_2()
	{
		base.vmethod_2();
		if (this.m_AnimationManagerFSM.Animator_0)
		{
			this.m_AnimationManagerFSM.Animator_0.SetBool("bStartLavaStrikeJump", false);
			this.m_AnimationManagerFSM.Animator_0.SetBool("bLavaStrikeJumpLand", true);
			this.m_AnimationManagerFSM.Animator_0.SetBool("bLavaStrikeEnd", true);
		}
	}

	// Token: 0x06000224 RID: 548 RVA: 0x000041D1 File Offset: 0x000023D1
	public void OnLanded()
	{
		if (this.m_AnimationManagerFSM.Animator_0)
		{
			this.m_AnimationManagerFSM.Animator_0.SetBool("bLavaStrikeJumpLand", true);
			this.m_bLanded = true;
		}
	}

	// Token: 0x040001F6 RID: 502
	private const string LavaStrike_TAG = "LavaStrike";

	// Token: 0x040001F7 RID: 503
	private const string LavaStrike_JumpLoop_TAG = "JumpLoop";

	// Token: 0x040001F8 RID: 504
	public bool m_bLavaStrikeEnd;

	// Token: 0x040001F9 RID: 505
	public bool m_bJumpLoop;

	// Token: 0x040001FA RID: 506
	private bool m_bLanded;
}
