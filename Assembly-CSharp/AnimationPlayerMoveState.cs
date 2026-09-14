using System;
using UnityEngine;

// Token: 0x020000B4 RID: 180
public class AnimationPlayerMoveState : PlayerAnimationState
{
	// Token: 0x06000433 RID: 1075 RVA: 0x00005CB9 File Offset: 0x00003EB9
	public AnimationPlayerMoveState()
	{
		this.StateName = "PlayerMove";
	}

	// Token: 0x17000022 RID: 34
	// (get) Token: 0x06000434 RID: 1076 RVA: 0x00005CCC File Offset: 0x00003ECC
	// (set) Token: 0x06000435 RID: 1077 RVA: 0x00005CD4 File Offset: 0x00003ED4
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

	// Token: 0x06000436 RID: 1078 RVA: 0x00005CDD File Offset: 0x00003EDD
	public void method_22(float float_2, float float_3)
	{
		this.m_moveSpeed = float_2;
		this.m_moveDirection = float_3;
	}

	// Token: 0x06000437 RID: 1079 RVA: 0x00005831 File Offset: 0x00003A31
	public override void vmethod_0()
	{
		base.vmethod_0();
		base.m_status = AnimationStatus.RUNNING;
	}

	// Token: 0x06000438 RID: 1080 RVA: 0x0004A3C4 File Offset: 0x000485C4
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
			num /= 180f;
			if ((this.m_moveSpeed > 0f && this.m_moveSpeed < 0.2f) || this.m_moveSpeed >= 0f || this.m_moveSpeed <= -0.2f)
			{
			}
			base.method_16("bMove", true);
			base.method_16("bIdle", false);
			base.method_17("fDirection", num);
			base.method_17("fSpeed", this.m_moveSpeed);
			base.method_16("bIsCrouch", false);
			base.method_17("fIsCrouch", 0f);
			if (base.Boolean_0)
			{
				if (this.m_moveSpeed > 0.5f)
				{
					base.method_7(MecanimAnimationID.ID_1st_Sprint);
				}
				else
				{
					base.method_7(MecanimAnimationID.ID_1st_StandMove);
				}
				float @float = base.Animator_0.GetFloat("fDirection");
				num = Mathf.Lerp(@float, num, 0.4f);
				base.method_11("fDirection", num);
			}
		}
	}

	// Token: 0x06000439 RID: 1081 RVA: 0x00003DB3 File Offset: 0x00001FB3
	public override void vmethod_2()
	{
		base.vmethod_2();
		base.m_status = AnimationStatus.SUCCESS;
	}

	// Token: 0x0400040F RID: 1039
	private float m_moveSpeed;

	// Token: 0x04000410 RID: 1040
	private float m_moveDirection;
}
