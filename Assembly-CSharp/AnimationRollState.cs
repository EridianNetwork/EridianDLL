using System;
using UnityEngine;

// Token: 0x0200006E RID: 110
public class AnimationRollState : AnimationManagerState
{
	// Token: 0x06000256 RID: 598 RVA: 0x00040588 File Offset: 0x0003E788
	public override void vmethod_0()
	{
		base.vmethod_0();
		this.m_animatorInfo = this.m_AnimationManagerFSM.Animator_0.GetCurrentAnimatorStateInfo(0);
		if (!this.m_AnimationManagerFSM.Animator_0.GetBool("IsCrouching"))
		{
			if (this.m_isSideStep)
			{
				if (this.m_isDodgeRight)
				{
					this.m_AnimationManagerFSM.Animator_0.SetInteger("RollStatus", 4);
				}
				else
				{
					this.m_AnimationManagerFSM.Animator_0.SetInteger("RollStatus", 3);
				}
			}
			else if (this.m_isDodgeRight)
			{
				this.m_AnimationManagerFSM.Animator_0.SetInteger("RollStatus", 2);
			}
			else
			{
				this.m_AnimationManagerFSM.Animator_0.SetInteger("RollStatus", 1);
			}
		}
		else if (this.m_isDodgeRight)
		{
			this.m_AnimationManagerFSM.Animator_0.SetInteger("RollStatus", 2);
		}
		else
		{
			this.m_AnimationManagerFSM.Animator_0.SetInteger("RollStatus", 1);
		}
		this.m_rollStarted = false;
		base.m_status = AnimationStatus.RUNNING;
	}

	// Token: 0x06000257 RID: 599 RVA: 0x00040688 File Offset: 0x0003E888
	public override void vmethod_1()
	{
		this.m_animatorInfo = this.m_AnimationManagerFSM.Animator_0.GetCurrentAnimatorStateInfo(0);
		if (this.m_rollStarted)
		{
			if (base.method_1(this.m_animatorInfo, this.m_startTime, 0.98f) || !this.m_animatorInfo.IsTag("Roll"))
			{
				this.m_AnimationManagerFSM.Animator_0.SetInteger("RollStatus", 0);
				base.m_status = AnimationStatus.SUCCESS;
			}
		}
		else if (this.m_animatorInfo.IsTag("Roll"))
		{
			this.m_rollStarted = true;
			this.m_startTime = this.m_animatorInfo.normalizedTime;
		}
	}

	// Token: 0x06000258 RID: 600 RVA: 0x000044D4 File Offset: 0x000026D4
	public override void vmethod_2()
	{
		base.vmethod_2();
		this.m_AnimationManagerFSM.Animator_0.SetInteger("RollStatus", 0);
		base.m_status = AnimationStatus.SUCCESS;
	}

	// Token: 0x04000235 RID: 565
	private const string DODGE_TAG = "Roll";

	// Token: 0x04000236 RID: 566
	private bool m_rollStarted;

	// Token: 0x04000237 RID: 567
	private AnimatorStateInfo m_animatorInfo;

	// Token: 0x04000238 RID: 568
	private float m_startTime;

	// Token: 0x04000239 RID: 569
	public bool m_isDodgeRight = true;

	// Token: 0x0400023A RID: 570
	public bool m_isSideStep;
}
