using System;

// Token: 0x0200004D RID: 77
public class AnimationCoverPeakInState : AnimationManagerState
{
	// Token: 0x060001C0 RID: 448 RVA: 0x0003DAB8 File Offset: 0x0003BCB8
	public override void vmethod_0()
	{
		this.ElapsedTime = 0f;
		base.vmethod_0();
		if (this.m_AnimationManagerFSM.Animator_0)
		{
			this.m_AnimationManagerFSM.Animator_0.SetBool("IsFiring", false);
			this.m_AnimationManagerFSM.Animator_0.SetBool("IsCasual", false);
			this.m_AnimationManagerFSM.Animator_0.SetInteger("CrouchStatus", 4);
			this.m_AnimationManagerFSM.Animator_0.SetBool("IsCrouching", false);
		}
		this.m_peakInStarted = false;
		base.m_status = AnimationStatus.RUNNING;
	}

	// Token: 0x060001C1 RID: 449 RVA: 0x0003DB50 File Offset: 0x0003BD50
	public override void vmethod_1()
	{
		if (this.m_AnimationManagerFSM.Animator_0.GetCurrentAnimatorStateInfo(0).IsTag("CoverPeakIn"))
		{
			this.m_peakInStarted = true;
		}
		if (this.m_peakInStarted)
		{
			if (this.m_AnimationManagerFSM.method_8("CoverPeakIn", 0.6f) == AnimationStatus.SUCCESS)
			{
				this.m_AnimationManagerFSM.Animator_0.SetBool("IsCrouching", true);
			}
			if (this.m_AnimationManagerFSM.method_8("CoverPeakIn", 0.98f) == AnimationStatus.SUCCESS || !this.m_AnimationManagerFSM.Animator_0.GetCurrentAnimatorStateInfo(0).IsTag("CoverPeakIn"))
			{
				base.m_status = AnimationStatus.SUCCESS;
			}
		}
	}

	// Token: 0x060001C2 RID: 450 RVA: 0x00003DB3 File Offset: 0x00001FB3
	public override void vmethod_2()
	{
		base.vmethod_2();
		base.m_status = AnimationStatus.SUCCESS;
	}

	// Token: 0x040001A7 RID: 423
	private const string PEAKIN_TAG = "CoverPeakIn";

	// Token: 0x040001A8 RID: 424
	public bool m_peakInStarted;
}
