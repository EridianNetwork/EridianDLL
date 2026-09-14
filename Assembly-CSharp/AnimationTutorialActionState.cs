using System;

// Token: 0x0200007A RID: 122
public class AnimationTutorialActionState : AnimationManagerState
{
	// Token: 0x0600028C RID: 652 RVA: 0x00041314 File Offset: 0x0003F514
	public override void vmethod_0()
	{
		base.vmethod_0();
		if (this.m_AnimationManagerFSM.Animator_0)
		{
			this.m_AnimationManagerFSM.Animator_0.SetBool("bIdle", true);
			this.m_AnimationManagerFSM.Animator_0.SetFloat("fMoveSpeed", 0f);
			if (this.m_tutorAction == ClusterAction_ResetTutorTask.TutorAction.Nervous)
			{
				this.m_AnimationManagerFSM.Animator_0.SetBool("bNervous", true);
				this.m_AnimationManagerFSM.Animator_0.SetBool("bOperatingPanel", false);
			}
			else if (this.m_tutorAction == ClusterAction_ResetTutorTask.TutorAction.OperatingPanel)
			{
				this.m_AnimationManagerFSM.Animator_0.SetBool("bNervous", false);
				this.m_AnimationManagerFSM.Animator_0.SetBool("bOperatingPanel", true);
			}
		}
	}

	// Token: 0x0600028D RID: 653 RVA: 0x000413D8 File Offset: 0x0003F5D8
	public override void vmethod_2()
	{
		base.vmethod_2();
		if (this.m_AnimationManagerFSM.Animator_0)
		{
			this.m_AnimationManagerFSM.Animator_0.SetBool("bNervous", false);
			this.m_AnimationManagerFSM.Animator_0.SetBool("bOperatingPanel", false);
		}
	}

	// Token: 0x04000261 RID: 609
	public ClusterAction_ResetTutorTask.TutorAction m_tutorAction;
}
