using System;
using UnityEngine;

// Token: 0x020000A2 RID: 162
public class AnimationPlayerBerserkDashState : PlayerAnimationState
{
	// Token: 0x060003DA RID: 986 RVA: 0x000056AC File Offset: 0x000038AC
	public AnimationPlayerBerserkDashState()
	{
		this.StateName = "PlayerBerserkDash";
	}

	// Token: 0x060003DB RID: 987 RVA: 0x00048F10 File Offset: 0x00047110
	public override void vmethod_0()
	{
		base.vmethod_0();
		base.method_21().method_110();
		base.m_status = AnimationStatus.RUNNING;
		this.m_stateTag = "BerserkDash";
		this.m_layer = 0;
		if (base.Boolean_0)
		{
			base.method_7(MecanimAnimationID.ID_1st_BerserkDash);
		}
		base.method_16("bBerserkDash", true);
		base.method_21().GetComponent<PlayerController>().method_57(true);
		this.m_leftTime = (base.method_21().PlayerSkillManage_0 as BerserkManage).method_32();
	}

	// Token: 0x060003DC RID: 988 RVA: 0x00048F90 File Offset: 0x00047190
	public override void vmethod_4()
	{
		base.vmethod_4();
		this.m_networkCompensationPer = this.m_netLantency;
		base.method_20().method_4(ENPCParticleType.E_Player_BerserkDust, 0f, true);
		base.method_20().method_4(ENPCParticleType.E_Player_BerserkAirflow, 0f, true);
		base.method_20().method_2(ENPCParticleType.E_DashBeam, base.method_21().vmethod_17().transform, new Vector3(0f, -0.1f, -0f), Quaternion.Euler(new Vector3(270f, 0f, 0f)), 0f);
	}

	// Token: 0x060003DD RID: 989 RVA: 0x000056BF File Offset: 0x000038BF
	public override void vmethod_1()
	{
		base.vmethod_1();
		this.m_leftTime -= Time.deltaTime;
		if (this.m_leftTime < 0f)
		{
			base.m_status = AnimationStatus.SUCCESS;
			base.method_21().PlayerSkillManage_0.OnSkillEvent(SkillEvent.BerserkDashEndHitNone);
		}
	}

	// Token: 0x060003DE RID: 990 RVA: 0x00049028 File Offset: 0x00047228
	public override void vmethod_2()
	{
		base.vmethod_2();
		base.m_status = AnimationStatus.SUCCESS;
		base.method_21().GetComponent<PlayerController>().method_57(false);
		base.method_16("bBerserkDash", false);
		base.method_20().method_13(ENPCParticleType.E_Player_BerserkDust);
		base.method_20().method_13(ENPCParticleType.E_DashBeam);
		base.method_8(MecanimAnimationID.ID_1st_BerserkDash);
		base.method_21().PlayerSkillManage_0.OnSkillEvent(SkillEvent.BerserkDashStateExit);
	}

	// Token: 0x040003C5 RID: 965
	public float m_netLantency;

	// Token: 0x040003C6 RID: 966
	private float m_leftTime;
}
