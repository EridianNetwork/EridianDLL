using System;

// Token: 0x0200007B RID: 123
public class AnimationTutorialLessonState : AnimationManagerState
{
	// Token: 0x0600028F RID: 655 RVA: 0x0004142C File Offset: 0x0003F62C
	public override void vmethod_0()
	{
		base.vmethod_0();
		if (this.m_AnimationManagerFSM.Animator_0)
		{
			this.m_AnimationManagerFSM.Animator_0.SetBool("bIdle", true);
			this.m_AnimationManagerFSM.Animator_0.SetFloat("fMoveSpeed", 0f);
			this.m_AnimationManagerFSM.Animator_0.SetBool("bShowLesson", true);
		}
	}

	// Token: 0x06000290 RID: 656 RVA: 0x00004785 File Offset: 0x00002985
	public override void vmethod_2()
	{
		base.vmethod_2();
		if (this.m_AnimationManagerFSM.Animator_0)
		{
			this.m_AnimationManagerFSM.Animator_0.SetBool("bShowLesson", false);
		}
	}
}
