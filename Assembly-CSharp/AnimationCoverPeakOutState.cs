using System;

// Token: 0x0200004E RID: 78
public class AnimationCoverPeakOutState : AnimationManagerState
{
	// Token: 0x060001C4 RID: 452 RVA: 0x0003DBFC File Offset: 0x0003BDFC
	public override void vmethod_0()
	{
		this.ElapsedTime = 0f;
		base.vmethod_0();
		if (this.m_AnimationManagerFSM.Animator_0)
		{
			this.m_AnimationManagerFSM.Animator_0.SetBool("IsFiring", false);
			this.m_AnimationManagerFSM.Animator_0.SetBool("IsCasual", false);
			this.m_AnimationManagerFSM.Animator_0.SetInteger("CrouchStatus", 2);
			this.m_AnimationManagerFSM.Animator_0.SetBool("IsCrouching", true);
		}
		this.m_peakOutStarted = false;
		base.m_status = AnimationStatus.RUNNING;
	}

	// Token: 0x060001C5 RID: 453 RVA: 0x0003DC94 File Offset: 0x0003BE94
	public override void vmethod_1()
	{
		if (this.m_AnimationManagerFSM.Animator_0.GetCurrentAnimatorStateInfo(0).IsTag("CoverPeakOut"))
		{
			this.m_peakOutStarted = true;
		}
		if (this.m_peakOutStarted)
		{
			if (this.m_AnimationManagerFSM.method_8("CoverPeakOut", 0.6f) == AnimationStatus.SUCCESS)
			{
				this.m_AnimationManagerFSM.Animator_0.SetBool("IsCrouching", false);
			}
			if (this.m_AnimationManagerFSM.method_8("CoverPeakOut", 0.98f) == AnimationStatus.SUCCESS || !this.m_AnimationManagerFSM.Animator_0.GetCurrentAnimatorStateInfo(0).IsTag("CoverPeakOut"))
			{
				base.m_status = AnimationStatus.SUCCESS;
			}
		}
	}

	// Token: 0x060001C6 RID: 454 RVA: 0x00003DB3 File Offset: 0x00001FB3
	public override void vmethod_2()
	{
		base.vmethod_2();
		base.m_status = AnimationStatus.SUCCESS;
	}

	// Token: 0x040001A9 RID: 425
	private const string PEAKOUT_TAG = "CoverPeakOut";

	// Token: 0x040001AA RID: 426
	public bool m_peakOutStarted;
}
