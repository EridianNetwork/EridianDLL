using System;

// Token: 0x020000A6 RID: 166
public class AnimationPlayerCrouchMoveState : PlayerAnimationState
{
	// Token: 0x060003F0 RID: 1008 RVA: 0x00005861 File Offset: 0x00003A61
	public AnimationPlayerCrouchMoveState()
	{
		this.StateName = "PlayerCrouchMove";
	}

	// Token: 0x1700001E RID: 30
	// (get) Token: 0x060003F1 RID: 1009 RVA: 0x00005874 File Offset: 0x00003A74
	// (set) Token: 0x060003F2 RID: 1010 RVA: 0x0000587C File Offset: 0x00003A7C
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

	// Token: 0x060003F3 RID: 1011 RVA: 0x00005885 File Offset: 0x00003A85
	public void method_22(float float_2, float float_3)
	{
		this.m_moveSpeed = float_2;
		this.m_moveDirection = float_3;
	}

	// Token: 0x060003F4 RID: 1012 RVA: 0x00005831 File Offset: 0x00003A31
	public override void vmethod_0()
	{
		base.vmethod_0();
		base.m_status = AnimationStatus.RUNNING;
	}

	// Token: 0x060003F5 RID: 1013 RVA: 0x00049214 File Offset: 0x00047414
	public override void vmethod_1()
	{
		if (this.m_AnimationManagerFSM.Animator_0)
		{
			float num = this.m_moveDirection;
			if (num >= 22.5f && (double)num <= 337.5)
			{
				if (num < 67.5f)
				{
					num = 45f;
				}
				else if (num < 112.5f)
				{
					num = 90f;
				}
				else if (num < 157.5f)
				{
					num = 45f;
					if (this.m_moveSpeed > 0f)
					{
						this.m_moveSpeed *= -1f;
					}
				}
				else if (num < 202.5f)
				{
					num = 0f;
					if (this.m_moveSpeed > 0f)
					{
						this.m_moveSpeed *= -1f;
					}
				}
				else if (num < 247.5f)
				{
					num = -45f;
					if (this.m_moveSpeed > 0f)
					{
						this.m_moveSpeed *= -1f;
					}
				}
				else if (num < 292.5f)
				{
					num = -90f;
				}
				else
				{
					num = -45f;
				}
			}
			else
			{
				num = 0f;
			}
			base.method_16("bMove", true);
			base.method_16("bIdle", false);
			base.method_17("fDirection", num / 180f);
			base.method_17("fSpeed", this.m_moveSpeed);
			base.method_16("bIsCrouch", true);
			base.method_17("fIsCrouch", 1f);
			if (base.Boolean_0)
			{
				base.method_7(MecanimAnimationID.ID_1st_CrouchMove);
				base.method_11("fDirection", num);
			}
		}
	}

	// Token: 0x060003F6 RID: 1014 RVA: 0x00003DB3 File Offset: 0x00001FB3
	public override void vmethod_2()
	{
		base.vmethod_2();
		base.m_status = AnimationStatus.SUCCESS;
	}

	// Token: 0x040003CE RID: 974
	private float m_moveSpeed;

	// Token: 0x040003CF RID: 975
	private float m_moveDirection;
}
