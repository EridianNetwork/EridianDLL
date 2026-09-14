using System;
using UnityEngine;

// Token: 0x02000066 RID: 102
public class AnimationMeleeAttackState : AnimationManagerState
{
	// Token: 0x06000235 RID: 565 RVA: 0x000042F0 File Offset: 0x000024F0
	public AnimationMeleeAttackState()
	{
		this.StateName = "MeleeAttack";
	}

	// Token: 0x17000016 RID: 22
	// (get) Token: 0x06000236 RID: 566 RVA: 0x0000430E File Offset: 0x0000250E
	// (set) Token: 0x06000237 RID: 567 RVA: 0x00004316 File Offset: 0x00002516
	public bool m_triggetHitEvent { get; set; }

	// Token: 0x06000238 RID: 568 RVA: 0x0003FB5C File Offset: 0x0003DD5C
	public override void vmethod_0()
	{
		base.vmethod_0();
		this.m_AnimationManagerFSM.Animator_0.SetBool("bAttack", true);
		this.m_AnimationManagerFSM.Animator_0.SetFloat("fAttackID", (float)this.m_meleeAttackID);
		this.m_AnimationManagerFSM.Animator_0.SetFloat("fMoveSpeed", 0f);
		if (this.m_AnimationManagerFSM.m_isHumanoid)
		{
			this.m_AnimationManagerFSM.Animator_0.SetBool("IsCasual", false);
		}
		this.m_triggetHitEvent = false;
		this.m_meleeStarted = false;
	}

	// Token: 0x06000239 RID: 569 RVA: 0x0003FBEC File Offset: 0x0003DDEC
	public override void vmethod_1()
	{
		this.m_animatorInfo = this.m_AnimationManagerFSM.Animator_0.GetCurrentAnimatorStateInfo(0);
		if (this.m_meleeStarted)
		{
			if (!this.m_animatorInfo.IsTag(this.m_animationTag) || base.method_1(this.m_animatorInfo, this.m_startTime, 0.98f))
			{
				base.m_status = AnimationStatus.SUCCESS;
				this.m_AnimationManagerFSM.Animator_0.SetBool("bAttack", false);
			}
		}
		else
		{
			this.m_AnimationManagerFSM.Animator_0.SetBool("bAttack", true);
			if (this.m_animatorInfo.IsTag(this.m_animationTag))
			{
				this.m_meleeStarted = true;
				this.m_startTime = this.m_animatorInfo.normalizedTime;
			}
		}
	}

	// Token: 0x0600023A RID: 570 RVA: 0x0000431F File Offset: 0x0000251F
	public override void vmethod_2()
	{
		base.m_status = AnimationStatus.SUCCESS;
		this.m_AnimationManagerFSM.Animator_0.SetBool("bAttack", false);
		base.vmethod_2();
	}

	// Token: 0x04000209 RID: 521
	private const float HIT_THRESHOLD = 0.09f;

	// Token: 0x0400020A RID: 522
	private string m_animationTag = "TagMeleeAttack";

	// Token: 0x0400020B RID: 523
	public int m_meleeAttackID;

	// Token: 0x0400020C RID: 524
	private bool m_meleeStarted;

	// Token: 0x0400020D RID: 525
	private AnimatorStateInfo m_animatorInfo;

	// Token: 0x0400020E RID: 526
	private float m_startTime;
}
