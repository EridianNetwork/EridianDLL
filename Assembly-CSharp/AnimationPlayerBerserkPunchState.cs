using System;

// Token: 0x020000A3 RID: 163
public class AnimationPlayerBerserkPunchState : PlayerAnimationState
{
	// Token: 0x060003DF RID: 991 RVA: 0x000056FF File Offset: 0x000038FF
	public AnimationPlayerBerserkPunchState()
	{
		this.StateName = "PlayerBerserkPunch";
	}

	// Token: 0x060003E0 RID: 992 RVA: 0x00005712 File Offset: 0x00003912
	public override void vmethod_0()
	{
		base.vmethod_0();
		base.m_status = AnimationStatus.RUNNING;
		this.m_stateTag = "BerserkPunch";
		this.m_layer = 0;
		if (base.Boolean_0)
		{
			base.method_7(MecanimAnimationID.ID_1st_BerserkPunch);
		}
		base.method_16("bBerserkPunch", true);
	}

	// Token: 0x060003E1 RID: 993 RVA: 0x00005750 File Offset: 0x00003950
	public override void vmethod_4()
	{
		base.vmethod_4();
		this.m_networkCompensationPer = this.m_netLantency;
		base.method_21().PlayerSkillManage_0.Boolean_0 = false;
	}

	// Token: 0x060003E2 RID: 994 RVA: 0x00049098 File Offset: 0x00047298
	public override void vmethod_2()
	{
		base.vmethod_2();
		base.m_status = AnimationStatus.SUCCESS;
		base.method_16("bBerserkPunch", false);
		base.method_21().PlayerSkillManage_0.OnSkillEvent(SkillEvent.BerserkPunchEnd);
		base.method_21().PlayerSkillManage_0.OnSkillEvent(SkillEvent.SkillExit);
		base.method_8(MecanimAnimationID.ID_1st_BerserkPunch);
	}

	// Token: 0x060003E3 RID: 995 RVA: 0x00005775 File Offset: 0x00003975
	protected override void OnAnimationTimeElapsed(string state)
	{
		base.m_status = AnimationStatus.SUCCESS;
		base.method_16("bBerserkPunch", false);
	}

	// Token: 0x040003C7 RID: 967
	public float m_netLantency;
}
