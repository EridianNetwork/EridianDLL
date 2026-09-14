using System;
using UnityEngine;

// Token: 0x02000076 RID: 118
public class AnimationSummonExtraNPCState : AnimationManagerState
{
	// Token: 0x0600027C RID: 636 RVA: 0x000046AA File Offset: 0x000028AA
	public AnimationSummonExtraNPCState()
	{
		this.StateName = "SummonExtraNPC";
	}

	// Token: 0x0600027D RID: 637 RVA: 0x000046BD File Offset: 0x000028BD
	public override void vmethod_0()
	{
		base.vmethod_0();
		this.m_summonStarted = false;
	}

	// Token: 0x0600027E RID: 638 RVA: 0x00040F04 File Offset: 0x0003F104
	public override void vmethod_1()
	{
		this.m_animatorInfo = this.m_AnimationManagerFSM.Animator_0.GetCurrentAnimatorStateInfo(0);
		if (this.m_summonStarted)
		{
			if (!this.m_animatorInfo.IsTag("SummonNPC") || base.method_1(this.m_animatorInfo, this.m_startTime, 0.97f))
			{
				base.m_status = AnimationStatus.SUCCESS;
				this.m_AnimationManagerFSM.Animator_0.SetBool("bSummonNPC", false);
			}
		}
		else
		{
			this.m_AnimationManagerFSM.Animator_0.SetBool("bSummonNPC", true);
			if (this.m_animatorInfo.IsTag("SummonNPC"))
			{
				this.m_summonStarted = true;
				this.m_startTime = this.m_animatorInfo.normalizedTime;
			}
		}
	}

	// Token: 0x0600027F RID: 639 RVA: 0x000046CC File Offset: 0x000028CC
	public override void vmethod_2()
	{
		base.vmethod_2();
		this.m_AnimationManagerFSM.Animator_0.SetBool("bSummonNPC", false);
		base.m_status = AnimationStatus.SUCCESS;
	}

	// Token: 0x04000255 RID: 597
	private const string SUMMON_TAG = "SummonNPC";

	// Token: 0x04000256 RID: 598
	public bool m_summonStarted;

	// Token: 0x04000257 RID: 599
	private AnimatorStateInfo m_animatorInfo;

	// Token: 0x04000258 RID: 600
	private float m_startTime;
}
