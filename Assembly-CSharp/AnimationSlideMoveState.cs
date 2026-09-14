using System;

// Token: 0x02000070 RID: 112
public class AnimationSlideMoveState : AnimationManagerState
{
	// Token: 0x0600025E RID: 606 RVA: 0x00040804 File Offset: 0x0003EA04
	public override void vmethod_0()
	{
		base.vmethod_0();
		if (this.m_AnimationManagerFSM.Animator_0)
		{
			this.m_AnimationManagerFSM.m_disableMovementAnimation = false;
			this.m_AnimationManagerFSM.Animator_0.SetBool("bMove", true);
			this.m_AnimationManagerFSM.Animator_0.SetFloat("fMoveSpeed", 1f);
		}
	}

	// Token: 0x0600025F RID: 607 RVA: 0x00004526 File Offset: 0x00002726
	public override void vmethod_1()
	{
		if (this.m_AnimationManagerFSM.m_VFXManager != null)
		{
			this.m_VFXManager.method_4(ENPCParticleType.E_MoveDust, 3f, false);
		}
	}

	// Token: 0x06000260 RID: 608 RVA: 0x00040868 File Offset: 0x0003EA68
	public override void vmethod_2()
	{
		base.vmethod_2();
		if (this.m_AnimationManagerFSM.Animator_0)
		{
			this.m_AnimationManagerFSM.m_disableMovementAnimation = true;
			this.m_AnimationManagerFSM.Animator_0.SetBool("bMove", false);
			this.m_AnimationManagerFSM.Animator_0.SetFloat("fMoveSpeed", 0f);
		}
		if (this.m_AnimationManagerFSM.m_VFXManager != null)
		{
			this.m_VFXManager.method_14(ENPCParticleType.E_MoveDust);
		}
	}
}
