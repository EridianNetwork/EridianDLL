using System;

// Token: 0x02000043 RID: 67
public class AnimationBurrowState : AnimationManagerState
{
	// Token: 0x1700000D RID: 13
	// (get) Token: 0x06000195 RID: 405 RVA: 0x00003CB6 File Offset: 0x00001EB6
	// (set) Token: 0x06000196 RID: 406 RVA: 0x00003CBE File Offset: 0x00001EBE
	public EAnimationBurrowStep EAnimationBurrowStep_0
	{
		get
		{
			return this.m_animationBurrowStep;
		}
		set
		{
			this.m_animationBurrowStep = value;
		}
	}

	// Token: 0x06000197 RID: 407 RVA: 0x0003CF7C File Offset: 0x0003B17C
	public override void vmethod_0()
	{
		base.vmethod_0();
		this.m_bPlayBurrowOutDust = true;
		this.EAnimationBurrowStep_0 = EAnimationBurrowStep.BurrowEnter;
		this.m_AnimationManagerFSM.Animator_0.SetBool("bBurrowEnter", true);
		this.m_AnimationManagerFSM.Animator_0.SetBool("bBurrowExit", false);
	}

	// Token: 0x06000198 RID: 408 RVA: 0x0003CFCC File Offset: 0x0003B1CC
	public override void vmethod_1()
	{
		if (this.EAnimationBurrowStep_0 == EAnimationBurrowStep.BurrowEnter)
		{
			if (this.m_AnimationManagerFSM.method_8("BurrowEnter", 0.98f) == AnimationStatus.SUCCESS)
			{
				this.EAnimationBurrowStep_0 = EAnimationBurrowStep.BurrowWait;
				this.m_AnimationManagerFSM.Animator_0.SetBool("bBurrowEnter", false);
				this.m_AnimationManagerFSM.Animator_0.SetBool("bBurrowExit", false);
				if (this.m_VFXManager)
				{
					this.m_VFXManager.method_4(ENPCParticleType.E_Burrow, 0f, true);
				}
			}
		}
		else if (this.EAnimationBurrowStep_0 != EAnimationBurrowStep.BurrowWait)
		{
			if (this.EAnimationBurrowStep_0 == EAnimationBurrowStep.BurrowExit)
			{
				this.m_AnimationManagerFSM.Animator_0.SetBool("bBurrowExit", true);
				if (this.m_VFXManager && this.m_bPlayBurrowOutDust && this.m_AnimationManagerFSM.method_8("BurrowExit", 0.2f) == AnimationStatus.SUCCESS)
				{
					this.m_bPlayBurrowOutDust = false;
					this.m_VFXManager.method_4(ENPCParticleType.E_Burrow, 0f, true);
				}
				if (this.m_AnimationManagerFSM.method_8("BurrowExit", 0.98f) == AnimationStatus.SUCCESS)
				{
					this.EAnimationBurrowStep_0 = EAnimationBurrowStep.BurrowFinish;
					this.m_AnimationManagerFSM.Animator_0.SetBool("bBurrowExit", false);
				}
			}
		}
	}

	// Token: 0x06000199 RID: 409 RVA: 0x00003CC7 File Offset: 0x00001EC7
	public override void vmethod_2()
	{
		base.vmethod_2();
		this.EAnimationBurrowStep_0 = EAnimationBurrowStep.BurrowNull;
		this.m_AnimationManagerFSM.Animator_0.SetBool("bBurrowEnter", false);
		this.m_AnimationManagerFSM.Animator_0.SetBool("bBurrowExit", true);
	}

	// Token: 0x04000182 RID: 386
	private const string ANIM_BURROW_ENTER = "BurrowEnter";

	// Token: 0x04000183 RID: 387
	private const string ANIM_BURROW_EXIT = "BurrowExit";

	// Token: 0x04000184 RID: 388
	private const string PARAM_ENTER = "bBurrowEnter";

	// Token: 0x04000185 RID: 389
	private const string PARAM_EXIT = "bBurrowExit";

	// Token: 0x04000186 RID: 390
	private bool m_bPlayBurrowOutDust;

	// Token: 0x04000187 RID: 391
	private EAnimationBurrowStep m_animationBurrowStep;
}
