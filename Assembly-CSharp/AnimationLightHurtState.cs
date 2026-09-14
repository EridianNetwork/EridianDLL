using System;
using BHV;
using UnityEngine;

// Token: 0x02000064 RID: 100
public class AnimationLightHurtState : AnimationManagerState
{
	// Token: 0x06000226 RID: 550 RVA: 0x00004202 File Offset: 0x00002402
	public override void vmethod_0()
	{
		base.vmethod_0();
		this.m_hurtLightLayer = this.m_AnimationManagerFSM.vmethod_8("HurtLight");
		this.method_4();
	}

	// Token: 0x06000227 RID: 551 RVA: 0x0003F918 File Offset: 0x0003DB18
	public void method_4()
	{
		if (this.m_AnimationManagerFSM.Animator_0 != null)
		{
			if (this.m_damageType == EDamageType.DT_Light || this.m_damageType == EDamageType.DT_Light_Critical)
			{
				this.m_AnimationManagerFSM.Animator_0.SetBool("bHurtLight", true);
			}
			this.m_hurtStarted = false;
		}
		base.m_status = AnimationStatus.RUNNING;
		this.m_isHurtPending = true;
	}

	// Token: 0x06000228 RID: 552 RVA: 0x0003F978 File Offset: 0x0003DB78
	public override void vmethod_1()
	{
		if (this.m_AnimationManagerFSM.Animator_0 == null)
		{
			return;
		}
		if (this.m_isHurtPending)
		{
			this.m_AnimationManagerFSM.Animator_0.SetBool("bHurtLight", true);
			this.m_isHurtPending = false;
		}
		else if (this.m_damageType == EDamageType.DT_Light || this.m_damageType == EDamageType.DT_Light_Critical)
		{
			this.m_animatorInfo = this.m_AnimationManagerFSM.Animator_0.GetCurrentAnimatorStateInfo(this.m_hurtLightLayer);
			if (this.m_hurtStarted)
			{
				if (base.method_1(this.m_animatorInfo, this.m_startTime, 0.98f) || !this.m_animatorInfo.IsTag("HurtLight"))
				{
					base.m_status = AnimationStatus.SUCCESS;
				}
			}
			else if (this.m_animatorInfo.IsTag("HurtLight"))
			{
				this.m_AnimationManagerFSM.Animator_0.SetBool("bHurtLight", false);
				this.m_hurtStarted = true;
				this.m_startTime = this.m_animatorInfo.normalizedTime;
			}
		}
	}

	// Token: 0x06000229 RID: 553 RVA: 0x00004226 File Offset: 0x00002426
	public override void vmethod_2()
	{
		base.vmethod_2();
		if (this.m_AnimationManagerFSM.Animator_0 != null)
		{
			this.m_AnimationManagerFSM.Animator_0.SetBool("bHurtLight", false);
		}
		base.m_status = AnimationStatus.SUCCESS;
	}

	// Token: 0x040001FB RID: 507
	private const string HURTLIGHT_TAG = "HurtLight";

	// Token: 0x040001FC RID: 508
	private int m_hurtLightLayer;

	// Token: 0x040001FD RID: 509
	public bool m_hurtStarted;

	// Token: 0x040001FE RID: 510
	public EDamageType m_damageType;

	// Token: 0x040001FF RID: 511
	private AnimatorStateInfo m_animatorInfo;

	// Token: 0x04000200 RID: 512
	private float m_startTime;

	// Token: 0x04000201 RID: 513
	private bool m_isHurtPending;
}
