using System;

// Token: 0x02000079 RID: 121
public class AnimationTurnToState : AnimationManagerState
{
	// Token: 0x0600028A RID: 650 RVA: 0x00041270 File Offset: 0x0003F470
	public override void vmethod_0()
	{
		base.vmethod_0();
		if (this.m_AnimationManagerFSM.Animator_0)
		{
			this.m_AnimationManagerFSM.Animator_0.SetBool("bIdle", true);
			this.m_AnimationManagerFSM.Animator_0.SetFloat("fMoveSpeed", 0f);
			this.m_AnimationManagerFSM.Animator_0.SetBool("IsCasual", false);
			if (this.m_AnimationManagerFSM.m_isHumanoid)
			{
				this.m_AnimationManagerFSM.Animator_0.SetInteger("CrouchStatus", 0);
				this.m_AnimationManagerFSM.Animator_0.SetBool("IsCrouching", false);
			}
		}
	}
}
