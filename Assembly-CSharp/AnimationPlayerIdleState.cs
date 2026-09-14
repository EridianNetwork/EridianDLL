using System;

// Token: 0x020000AB RID: 171
public class AnimationPlayerIdleState : PlayerAnimationState
{
	// Token: 0x0600040F RID: 1039 RVA: 0x000059DE File Offset: 0x00003BDE
	public AnimationPlayerIdleState()
	{
		this.StateName = "PlayerIdle";
	}

	// Token: 0x17000020 RID: 32
	// (get) Token: 0x06000410 RID: 1040 RVA: 0x000059F1 File Offset: 0x00003BF1
	// (set) Token: 0x06000411 RID: 1041 RVA: 0x000059F9 File Offset: 0x00003BF9
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

	// Token: 0x06000412 RID: 1042 RVA: 0x00005831 File Offset: 0x00003A31
	public override void vmethod_0()
	{
		base.vmethod_0();
		base.m_status = AnimationStatus.RUNNING;
	}

	// Token: 0x06000413 RID: 1043 RVA: 0x00049BB8 File Offset: 0x00047DB8
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
		base.method_16("bIsCrouch", false);
		base.method_17("fIsCrouch", 0f);
		if (base.Boolean_0)
		{
			base.method_7(MecanimAnimationID.ID_1st_StandIdle);
			base.method_11("fDirection", 0f);
		}
	}

	// Token: 0x06000414 RID: 1044 RVA: 0x00005840 File Offset: 0x00003A40
	public override void vmethod_2()
	{
		base.vmethod_2();
		if (!this.m_AnimationManagerFSM.Animator_0)
		{
		}
		base.m_status = AnimationStatus.SUCCESS;
	}

	// Token: 0x040003EB RID: 1003
	private float m_moveSpeed;
}
