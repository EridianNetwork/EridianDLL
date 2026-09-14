using System;
using UnityEngine;

// Token: 0x0200004C RID: 76
public class AnimationCoverLookAroundState : AnimationManagerState
{
	// Token: 0x060001BC RID: 444 RVA: 0x0003DA00 File Offset: 0x0003BC00
	public override void vmethod_0()
	{
		this.ElapsedTime = 0f;
		base.vmethod_0();
		if (this.m_AnimationManagerFSM.Animator_0)
		{
			this.m_AnimationManagerFSM.Animator_0.SetBool("IsFiring", false);
			this.m_AnimationManagerFSM.Animator_0.SetBool("IsCasual", false);
			this.m_AnimationManagerFSM.Animator_0.SetInteger("CrouchStatus", 3);
			this.m_AnimationManagerFSM.Animator_0.SetBool("IsCrouching", false);
		}
		this.m_lookDuration = this.m_AnimationManagerFSM.Single_0;
		if (this.m_lookDuration <= 0f)
		{
			this.m_lookDuration = 1f;
		}
		base.m_status = AnimationStatus.RUNNING;
	}

	// Token: 0x060001BD RID: 445 RVA: 0x00003DC2 File Offset: 0x00001FC2
	public override void vmethod_1()
	{
		if (this.m_lookDuration <= 0f)
		{
			base.m_status = AnimationStatus.SUCCESS;
		}
		else
		{
			this.m_lookDuration -= Time.deltaTime;
		}
	}

	// Token: 0x060001BE RID: 446 RVA: 0x00003DB3 File Offset: 0x00001FB3
	public override void vmethod_2()
	{
		base.vmethod_2();
		base.m_status = AnimationStatus.SUCCESS;
	}

	// Token: 0x040001A6 RID: 422
	public float m_lookDuration;
}
