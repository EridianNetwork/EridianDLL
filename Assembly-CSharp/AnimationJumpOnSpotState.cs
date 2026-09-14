using System;

// Token: 0x02000061 RID: 97
public class AnimationJumpOnSpotState : AnimationManagerState
{
	// Token: 0x06000217 RID: 535 RVA: 0x0000413A File Offset: 0x0000233A
	public override void vmethod_0()
	{
		base.vmethod_0();
		this.m_AnimationManagerFSM.Animator_0.SetBool("bJumpOnSpot", true);
		this.m_jumpOnSpotHit = false;
	}

	// Token: 0x06000218 RID: 536 RVA: 0x0003F618 File Offset: 0x0003D818
	public override void vmethod_1()
	{
		if (this.m_AnimationManagerFSM.method_8("JumpOnSpot", 0.98f) == AnimationStatus.SUCCESS)
		{
			base.m_status = AnimationStatus.SUCCESS;
		}
		if (this.m_jumpOnSpotHit && this.m_VFXManager != null)
		{
			this.m_VFXManager.method_4(ENPCParticleType.E_JumpOnSpot, 0f, false);
			this.m_jumpOnSpotHit = false;
		}
	}

	// Token: 0x06000219 RID: 537 RVA: 0x0000415F File Offset: 0x0000235F
	public override void vmethod_2()
	{
		base.vmethod_2();
		this.m_AnimationManagerFSM.Animator_0.SetBool("bJumpOnSpot", false);
	}

	// Token: 0x040001EE RID: 494
	private const string JUMPONSPOT_TAG = "JumpOnSpot";

	// Token: 0x040001EF RID: 495
	private const float THRESHOLD = 0.9f;

	// Token: 0x040001F0 RID: 496
	public bool m_jumpOnSpotHit;
}
