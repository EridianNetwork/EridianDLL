using System;
using UnityEngine;

// Token: 0x0200005D RID: 93
public class AnimationIceMeteorAttackState : AnimationManagerState
{
	// Token: 0x06000204 RID: 516 RVA: 0x0000407E File Offset: 0x0000227E
	public AnimationIceMeteorAttackState()
	{
		this.StateName = "IceMeteorAttack";
	}

	// Token: 0x06000205 RID: 517 RVA: 0x0003EEF0 File Offset: 0x0003D0F0
	public override void vmethod_0()
	{
		base.vmethod_0();
		this.m_meteorPreStarted = false;
		this.m_meteorEndStarted = false;
		this.m_meteorStep = EAnimationMeteorStep.MeteorPre;
		this.m_AnimationManagerFSM.Animator_0.SetBool("bMeteorStart", true);
		this.m_AnimationManagerFSM.Animator_0.SetBool("bMeteorLoop", false);
		this.m_AnimationManagerFSM.Animator_0.SetBool("bMeteorEnd", false);
	}

	// Token: 0x06000206 RID: 518 RVA: 0x0003EF5C File Offset: 0x0003D15C
	public override void vmethod_1()
	{
		this.m_animatorInfo = this.m_AnimationManagerFSM.Animator_0.GetCurrentAnimatorStateInfo(0);
		if (this.m_meteorStep == EAnimationMeteorStep.MeteorPre)
		{
			if (this.m_meteorPreStarted)
			{
				if (!this.m_animatorInfo.IsTag("IceMeteorStart") || base.method_1(this.m_animatorInfo, this.m_startTime, 0.97f))
				{
					this.m_AnimationManagerFSM.Animator_0.SetBool("bMeteorStart", false);
					this.m_AnimationManagerFSM.Animator_0.SetBool("bMeteorLoop", true);
					this.m_meteorStep = EAnimationMeteorStep.MeteorLoop;
				}
			}
			else
			{
				this.m_AnimationManagerFSM.Animator_0.SetBool("bMeteorStart", true);
				if (this.m_animatorInfo.IsTag("IceMeteorStart") || this.m_animatorInfo.IsTag("IceMeteorLoop"))
				{
					this.m_meteorPreStarted = true;
					this.m_startTime = this.m_animatorInfo.normalizedTime;
				}
			}
		}
		else if (this.m_meteorStep == EAnimationMeteorStep.MeteorLoop)
		{
			if (this.m_animatorInfo.IsTag("IceMeteorEnd"))
			{
				this.m_meteorStep = EAnimationMeteorStep.MeteorFinish;
			}
		}
		else if (this.m_meteorStep == EAnimationMeteorStep.MeteorFinish)
		{
			if (this.m_meteorEndStarted)
			{
				if (!this.m_animatorInfo.IsTag("IceMeteorEnd") || base.method_1(this.m_animatorInfo, this.m_startTime, 0.97f))
				{
					this.m_AnimationManagerFSM.Animator_0.SetBool("bMeteorEnd", false);
					base.m_status = AnimationStatus.SUCCESS;
				}
			}
			else
			{
				this.m_AnimationManagerFSM.Animator_0.SetBool("bMeteorLoop", false);
				this.m_AnimationManagerFSM.Animator_0.SetBool("bMeteorEnd", true);
				if (this.m_animatorInfo.IsTag("IceMeteorEnd"))
				{
					this.m_meteorEndStarted = true;
					this.m_startTime = this.m_animatorInfo.normalizedTime;
				}
			}
		}
	}

	// Token: 0x06000207 RID: 519 RVA: 0x0003F134 File Offset: 0x0003D334
	public override void vmethod_2()
	{
		base.vmethod_2();
		this.m_AnimationManagerFSM.Animator_0.SetBool("bMeteorStart", false);
		this.m_AnimationManagerFSM.Animator_0.SetBool("bMeteorLoop", false);
		this.m_AnimationManagerFSM.Animator_0.SetBool("bMeteorEnd", true);
	}

	// Token: 0x040001DC RID: 476
	private const string METEORSTART_TAG = "IceMeteorStart";

	// Token: 0x040001DD RID: 477
	private const string METEORLOOP_TAG = "IceMeteorLoop";

	// Token: 0x040001DE RID: 478
	private const string METEOREND_TAG = "IceMeteorEnd";

	// Token: 0x040001DF RID: 479
	public EAnimationMeteorStep m_meteorStep;

	// Token: 0x040001E0 RID: 480
	private AnimatorStateInfo m_animatorInfo;

	// Token: 0x040001E1 RID: 481
	private float m_startTime;

	// Token: 0x040001E2 RID: 482
	private bool m_meteorPreStarted;

	// Token: 0x040001E3 RID: 483
	private bool m_meteorEndStarted;
}
