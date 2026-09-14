using System;
using BHV;
using UnityEngine;

// Token: 0x02000068 RID: 104
public class AnimationMoveState : AnimationManagerState
{
	// Token: 0x0600023F RID: 575 RVA: 0x0000437C File Offset: 0x0000257C
	public AnimationMoveState()
	{
		this.StateName = "Move";
	}

	// Token: 0x06000240 RID: 576 RVA: 0x0003FD34 File Offset: 0x0003DF34
	public override void vmethod_0()
	{
		base.vmethod_0();
		this.ElapsedTime = 0f;
		this.m_startTurnThreshold = 10f;
		if (this.m_AnimationManagerFSM.Animator_0)
		{
			this.m_AnimationManagerFSM.m_disableMovementAnimation = false;
			this.m_AnimationManagerFSM.Animator_0.SetBool("bMove", true);
			this.m_AnimationManagerFSM.Animator_0.SetFloat("fSprintMode", (!this.m_isSprint) ? 0f : 1f);
			this.m_AnimationManagerFSM.Animator_0.SetFloat("fMoveSpeed", this.m_moveSpeed);
			if (this.m_AnimationManagerFSM.m_isHumanoid)
			{
				this.m_AnimationManagerFSM.Animator_0.SetInteger("CrouchStatus", 0);
				this.m_AnimationManagerFSM.Animator_0.SetBool("IsCrouching", false);
				this.m_AnimationManagerFSM.Animator_0.SetBool("IsMoveBackward", false);
				this.m_AnimationManagerFSM.Animator_0.SetFloat("FaceAngle", 0f);
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
			}
		}
	}

	// Token: 0x06000241 RID: 577 RVA: 0x000043BB File Offset: 0x000025BB
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
		this.method_4();
	}

	// Token: 0x06000242 RID: 578 RVA: 0x0003FEA4 File Offset: 0x0003E0A4
	private void method_4()
	{
		if (this.m_AnimationManagerFSM != null && this.m_AnimationManagerFSM.m_movementSync != null)
		{
			this.m_turnAngle = this.m_AnimationManagerFSM.m_movementSync.m_turnAngle;
		}
		while (this.m_turnAngle > 180f)
		{
			this.m_turnAngle -= 360f;
		}
		if (((NPCAnimationManagerFSM)this.m_AnimationManagerFSM).m_bCanMoveTurn)
		{
			if (Mathf.Abs(this.m_turnAngle) > 1E-45f)
			{
				if (!this.m_AnimationManagerFSM.Animator_0.GetBool("IsTurning"))
				{
					this.m_AnimationManagerFSM.Animator_0.SetFloat("TurnAngle", this.m_turnAngle);
					this.m_AnimationManagerFSM.Animator_0.SetBool("IsTurning", true);
				}
			}
			else
			{
				this.m_AnimationManagerFSM.Animator_0.SetFloat("TurnAngle", 0f);
				this.m_AnimationManagerFSM.Animator_0.SetBool("IsTurning", false);
			}
		}
	}

	// Token: 0x06000243 RID: 579 RVA: 0x0003FFAC File Offset: 0x0003E1AC
	public override void vmethod_2()
	{
		base.vmethod_2();
		if (this.m_AnimationManagerFSM.Animator_0 && this.m_AnimationManagerFSM.m_fullBodyNextState != AnimationStateFSM.Move)
		{
			this.m_AnimationManagerFSM.m_disableMovementAnimation = true;
			if (((NPCAnimationManagerFSM)this.m_AnimationManagerFSM).m_bCanMoveTurn)
			{
				this.m_AnimationManagerFSM.Animator_0.SetFloat("TurnAngle", 0f);
				this.m_AnimationManagerFSM.Animator_0.SetBool("IsTurning", false);
			}
			this.m_AnimationManagerFSM.Animator_0.SetFloat("fSprintMode", 0f);
		}
	}

	// Token: 0x04000215 RID: 533
	public float m_moveSpeed;

	// Token: 0x04000216 RID: 534
	public float m_startTurnThreshold;

	// Token: 0x04000217 RID: 535
	private float m_minimumWalkSpeed = 0.5f;

	// Token: 0x04000218 RID: 536
	private float m_minimumRunSpeed = 2.5f;

	// Token: 0x04000219 RID: 537
	private float m_sprintTurnThreshold = 60f;

	// Token: 0x0400021A RID: 538
	private AnimatorStateInfo m_animatorStateInfo;

	// Token: 0x0400021B RID: 539
	public bool m_isSprint;

	// Token: 0x0400021C RID: 540
	private bool m_isTurning;

	// Token: 0x0400021D RID: 541
	private string m_moveTurnTag = "MoveTurn";
}
