using System;

// Token: 0x02000041 RID: 65
public class AnimationAttachBombState : AnimationManagerState
{
	// Token: 0x06000193 RID: 403 RVA: 0x00003C78 File Offset: 0x00001E78
	public override void vmethod_0()
	{
		base.vmethod_0();
		if (this.m_AnimationManagerFSM != null && this.m_AnimationManagerFSM.Animator_0 != null)
		{
			this.m_AnimationManagerFSM.Animator_0.SetTrigger("tAttachBomb");
		}
	}
}
