using System;

// Token: 0x0200006A RID: 106
public class AnimationRadiusAttackState : AnimationManagerState
{
	// Token: 0x06000249 RID: 585 RVA: 0x000043F9 File Offset: 0x000025F9
	public AnimationRadiusAttackState()
	{
		this.StateName = "RadiusAttack";
	}

	// Token: 0x0600024A RID: 586 RVA: 0x00004417 File Offset: 0x00002617
	public override void vmethod_0()
	{
		base.vmethod_0();
		this.m_AnimationManagerFSM.Animator_0.SetBool("bAttackRadius", true);
		this.m_radiusAttackHit = false;
		this.m_bDoDamage = false;
	}

	// Token: 0x0600024B RID: 587 RVA: 0x000402BC File Offset: 0x0003E4BC
	public override void vmethod_1()
	{
		if (this.m_AnimationManagerFSM.method_8(this.m_animationTag, 0.98f) == AnimationStatus.SUCCESS)
		{
			base.m_status = AnimationStatus.SUCCESS;
			this.m_AnimationManagerFSM.Animator_0.SetBool("bAttackRadius", false);
		}
		if (this.m_radiusAttackHit && !this.m_bDoDamage)
		{
			if (this.m_VFXManager != null)
			{
				this.m_VFXManager.method_4(ENPCParticleType.E_RadiusAttack, 0f, false);
			}
			this.m_bDoDamage = true;
			this.m_radiusAttackHit = false;
		}
	}

	// Token: 0x0600024C RID: 588 RVA: 0x00004443 File Offset: 0x00002643
	public override void vmethod_2()
	{
		if (this.m_VFXManager)
		{
			this.m_VFXManager.method_13(ENPCParticleType.E_RadiusAttack);
		}
		this.m_AnimationManagerFSM.Animator_0.SetBool("bAttackRadius", false);
		base.vmethod_2();
	}

	// Token: 0x04000221 RID: 545
	private const float THRESHOLD = 0.9f;

	// Token: 0x04000222 RID: 546
	private string m_animationTag = "AttackRadius";

	// Token: 0x04000223 RID: 547
	public bool m_radiusAttackHit;

	// Token: 0x04000224 RID: 548
	public bool m_bDoDamage;
}
