using System;

// Token: 0x020000A5 RID: 165
public class AnimationPlayerCrouchIdleState : PlayerAnimationState
{
	// Token: 0x060003EA RID: 1002 RVA: 0x0000580D File Offset: 0x00003A0D
	public AnimationPlayerCrouchIdleState()
	{
		this.StateName = "PlayerCrouchIdle";
	}

	// Token: 0x1700001D RID: 29
	// (get) Token: 0x060003EB RID: 1003 RVA: 0x00005820 File Offset: 0x00003A20
	// (set) Token: 0x060003EC RID: 1004 RVA: 0x00005828 File Offset: 0x00003A28
	public float Single_0
	{
		get
		{
			return this.m_moveSpeed;
		}
		set
		{
			this.m_moveSpeed = value;
		}
	}

	// Token: 0x060003ED RID: 1005 RVA: 0x00005831 File Offset: 0x00003A31
	public override void vmethod_0()
	{
		base.vmethod_0();
		base.m_status = AnimationStatus.RUNNING;
	}

	// Token: 0x060003EE RID: 1006 RVA: 0x00049168 File Offset: 0x00047368
	public override void vmethod_1()
	{
		if (this.m_AnimationManagerFSM == null)
		{
			return;
		}
		if (this.m_AnimationManagerFSM.Animator_0 == null)
		{
			return;
		}
		base.method_16("bMove", false);
		base.method_16("bIdle", true);
		base.method_17("fSpeed", 0f);
		base.method_17("fDirection", 0f);
		base.method_16("bIsCrouch", true);
		base.method_17("fIsCrouch", 1f);
		if (base.Boolean_0)
		{
			base.method_7(MecanimAnimationID.ID_1st_CrouchIdle);
			base.method_11("fDirection", 0f);
		}
	}

	// Token: 0x060003EF RID: 1007 RVA: 0x00005840 File Offset: 0x00003A40
	public override void vmethod_2()
	{
		base.vmethod_2();
		if (!this.m_AnimationManagerFSM.Animator_0)
		{
		}
		base.m_status = AnimationStatus.SUCCESS;
	}

	// Token: 0x040003CD RID: 973
	private float m_moveSpeed;
}
