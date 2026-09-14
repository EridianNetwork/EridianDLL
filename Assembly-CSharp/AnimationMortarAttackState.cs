using System;
using UnityEngine;

// Token: 0x02000067 RID: 103
public class AnimationMortarAttackState : AnimationManagerState
{
	// Token: 0x0600023C RID: 572 RVA: 0x00004344 File Offset: 0x00002544
	public override void vmethod_0()
	{
		base.vmethod_0();
		this.m_attackStarted = false;
		this.m_startTime = Time.time;
	}

	// Token: 0x0600023D RID: 573 RVA: 0x0003FCA4 File Offset: 0x0003DEA4
	public override void vmethod_1()
	{
		this.m_animatorInfo = this.m_AnimationManagerFSM.Animator_0.GetCurrentAnimatorStateInfo(0);
		if (this.m_attackStarted)
		{
			if (Time.time - this.m_startTime >= this.m_attackDuration)
			{
				this.m_AnimationManagerFSM.Animator_0.SetBool("bMortarAttack", false);
				base.m_status = AnimationStatus.SUCCESS;
			}
		}
		else
		{
			this.m_AnimationManagerFSM.Animator_0.SetBool("bMortarAttack", true);
			if (this.m_animatorInfo.IsTag("MortarAttack"))
			{
				this.m_attackStarted = true;
			}
		}
	}

	// Token: 0x0600023E RID: 574 RVA: 0x0000435E File Offset: 0x0000255E
	public override void vmethod_2()
	{
		base.vmethod_2();
		this.m_AnimationManagerFSM.Animator_0.SetBool("bMortarAttack", false);
	}

	// Token: 0x04000210 RID: 528
	private const string MORTARATTACK_TAG = "MortarAttack";

	// Token: 0x04000211 RID: 529
	public bool m_attackStarted;

	// Token: 0x04000212 RID: 530
	private AnimatorStateInfo m_animatorInfo;

	// Token: 0x04000213 RID: 531
	public float m_attackDuration;

	// Token: 0x04000214 RID: 532
	private float m_startTime;
}
