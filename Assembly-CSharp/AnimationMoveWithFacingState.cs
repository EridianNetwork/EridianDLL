using System;
using BHV;
using UnityEngine;

// Token: 0x02000069 RID: 105
public class AnimationMoveWithFacingState : AnimationManagerState
{
	// Token: 0x06000244 RID: 580 RVA: 0x000043E6 File Offset: 0x000025E6
	public AnimationMoveWithFacingState()
	{
		this.StateName = "MoveWithFacing";
	}

	// Token: 0x06000245 RID: 581 RVA: 0x00040048 File Offset: 0x0003E248
	public void method_4(float float_2)
	{
		if (this.m_AnimationManagerFSM == null)
		{
			return;
		}
		if (float_2 >= 270f)
		{
			float_2 -= 360f;
		}
		if (float_2 > 90f)
		{
			float_2 = 180f - float_2;
			this.m_AnimationManagerFSM.Animator_0.SetBool("IsMoveBackward", true);
		}
		else
		{
			this.m_AnimationManagerFSM.Animator_0.SetBool("IsMoveBackward", false);
		}
		float @float = this.m_AnimationManagerFSM.Animator_0.GetFloat("FaceAngle");
		float_2 = Mathf.Lerp(@float, float_2, 0.3f);
		this.m_AnimationManagerFSM.Animator_0.SetFloat("FaceAngle", float_2);
	}

	// Token: 0x06000246 RID: 582 RVA: 0x000400F4 File Offset: 0x0003E2F4
	public override void vmethod_0()
	{
		base.vmethod_0();
		if (this.m_AnimationManagerFSM.Animator_0)
		{
			this.m_AnimationManagerFSM.m_disableMovementAnimation = false;
			this.m_AnimationManagerFSM.Animator_0.SetBool("bMove", true);
			if (this.m_AnimationManagerFSM.m_isHumanoid)
			{
				this.m_AnimationManagerFSM.Animator_0.SetInteger("CrouchStatus", 0);
				this.m_AnimationManagerFSM.Animator_0.SetBool("IsCrouching", false);
			}
		}
	}

	// Token: 0x06000247 RID: 583 RVA: 0x00040174 File Offset: 0x0003E374
	public override void vmethod_1()
	{
		if (!(this.m_AnimationManagerFSM == null) && !(this.m_AnimationManagerFSM.Animator_0 == null))
		{
			this.m_AnimationManagerFSM.Animator_0.SetFloat("fMoveSpeed", this.m_moveSpeed);
			this.m_AnimationManagerFSM.Animator_0.SetFloat("fSprintMode", (!this.m_isSprint) ? 0f : 1f);
			if (this.m_AnimationManagerFSM.BHVStressLevel_0 == BHVStressLevel.RELAX)
			{
				this.m_AnimationManagerFSM.Animator_0.SetBool("IsCasual", true);
				if (this.m_AnimationManagerFSM.m_upperBodyStateMachine != null)
				{
					this.m_AnimationManagerFSM.m_upperBodyStateMachine.method_1("Empty");
				}
			}
			else
			{
				this.m_AnimationManagerFSM.Animator_0.SetBool("IsCasual", false);
			}
			return;
		}
	}

	// Token: 0x06000248 RID: 584 RVA: 0x0004024C File Offset: 0x0003E44C
	public override void vmethod_2()
	{
		base.vmethod_2();
		if (this.m_AnimationManagerFSM.Animator_0 && this.m_AnimationManagerFSM.m_fullBodyNextState != AnimationStateFSM.MoveWithFacing)
		{
			this.m_AnimationManagerFSM.m_disableMovementAnimation = true;
			this.m_AnimationManagerFSM.Animator_0.SetBool("IsTurning", false);
			this.m_AnimationManagerFSM.Animator_0.SetFloat("fSprintMode", 0f);
		}
	}

	// Token: 0x0400021E RID: 542
	public float m_moveSpeed;

	// Token: 0x0400021F RID: 543
	public bool m_isSprint;

	// Token: 0x04000220 RID: 544
	private AnimatorStateInfo m_animatorStateInfo;
}
