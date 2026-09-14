using System;
using UnityEngine;

// Token: 0x020000A9 RID: 169
public class AnimationPlayerFireBirdState : PlayerAnimationState
{
	// Token: 0x060003FC RID: 1020 RVA: 0x000058B6 File Offset: 0x00003AB6
	public AnimationPlayerFireBirdState()
	{
		this.StateName = "PlayerFireBird";
	}

	// Token: 0x060003FD RID: 1021 RVA: 0x000058C9 File Offset: 0x00003AC9
	public override void vmethod_0()
	{
		base.vmethod_0();
		base.m_status = AnimationStatus.RUNNING;
		this.m_bFirstTickInTag = false;
		if (base.Boolean_0)
		{
			base.method_7(MecanimAnimationID.ID_1st_FireBird);
		}
		base.method_16("bFireBird", true);
	}

	// Token: 0x060003FE RID: 1022 RVA: 0x000058FC File Offset: 0x00003AFC
	public override void vmethod_1()
	{
		this.method_22();
	}

	// Token: 0x060003FF RID: 1023 RVA: 0x00049868 File Offset: 0x00047A68
	private void method_22()
	{
		this.m_animatorInfo = base.method_15(false, 1);
		if (!this.m_animatorInfo.IsTag("FireBird"))
		{
			return;
		}
		if (!this.m_bFirstTickInTag)
		{
			this.m_bFirstTickInTag = true;
			this.m_startTime = Time.time;
			this.m_length_anim = this.m_animatorInfo.length;
			base.method_20().method_3(ENPCParticleType.E_Player_HandFire, base.method_21().vmethod_17().transform, true, this.m_length_anim, true);
		}
		if (this.method_23(0.97f))
		{
			base.m_status = AnimationStatus.SUCCESS;
			base.method_16("bFireBird", false);
		}
	}

	// Token: 0x06000400 RID: 1024 RVA: 0x00005904 File Offset: 0x00003B04
	public override void vmethod_2()
	{
		base.vmethod_2();
		base.m_status = AnimationStatus.SUCCESS;
		base.method_16("bFireBird", false);
		base.method_20().method_14(ENPCParticleType.E_Player_HandFire);
	}

	// Token: 0x06000401 RID: 1025 RVA: 0x0000592D File Offset: 0x00003B2D
	private bool method_23(float float_2)
	{
		return Time.time + this.m_netLantency - this.m_startTime > this.m_length_anim * float_2;
	}

	// Token: 0x040003E0 RID: 992
	private const string m_tag = "FireBird";

	// Token: 0x040003E1 RID: 993
	public float m_netLantency;

	// Token: 0x040003E2 RID: 994
	private bool m_bFirstTickInTag;

	// Token: 0x040003E3 RID: 995
	private float m_startTime;

	// Token: 0x040003E4 RID: 996
	private float m_length_anim;
}
