using System;
using UnityEngine;

// Token: 0x02000055 RID: 85
public class AnimationDropBombState : AnimationManagerState
{
	// Token: 0x060001DF RID: 479 RVA: 0x0003E5E4 File Offset: 0x0003C7E4
	public override void vmethod_0()
	{
		base.vmethod_0();
		if (this.m_AnimationManagerFSM != null && this.m_AnimationManagerFSM.Animator_0 != null)
		{
			this.m_AnimationManagerFSM.Animator_0.SetTrigger("tDropBomb");
		}
		this.m_dropBombStarted = false;
		base.m_status = AnimationStatus.RUNNING;
	}

	// Token: 0x060001E0 RID: 480 RVA: 0x0003E63C File Offset: 0x0003C83C
	public override void vmethod_1()
	{
		this.m_animatorInfo = this.m_AnimationManagerFSM.Animator_0.GetCurrentAnimatorStateInfo(0);
		if (this.m_dropBombStarted)
		{
			if (this.m_animatorInfo.IsTag("Idle"))
			{
				base.m_status = AnimationStatus.SUCCESS;
			}
		}
		else if (this.m_animatorInfo.IsTag("DropBomb"))
		{
			this.m_dropBombStarted = true;
		}
	}

	// Token: 0x040001C3 RID: 451
	private const string DROPBOMB_TAG = "DropBomb";

	// Token: 0x040001C4 RID: 452
	public bool m_dropBombStarted;

	// Token: 0x040001C5 RID: 453
	private AnimatorStateInfo m_animatorInfo;
}
