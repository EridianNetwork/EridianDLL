using System;

// Token: 0x020000A1 RID: 161
public class AnimationPlayerBerserkChargeState : PlayerAnimationState
{
	// Token: 0x060003D5 RID: 981 RVA: 0x00005639 File Offset: 0x00003839
	public AnimationPlayerBerserkChargeState()
	{
		this.StateName = "PlayerBerserkCharge";
	}

	// Token: 0x060003D6 RID: 982 RVA: 0x00048E9C File Offset: 0x0004709C
	public override void vmethod_0()
	{
		base.vmethod_0();
		base.method_21().method_110();
		base.m_status = AnimationStatus.RUNNING;
		this.m_stateTag = "BerserkCharge";
		this.m_layer = 1;
		if (base.Boolean_0)
		{
			base.method_7(MecanimAnimationID.ID_1st_BerserkCharge);
		}
		base.method_16("bUpperBerserkCharge", true);
		if ((this.m_AnimationManagerFSM as PlayerAnimationManagerFSM).method_55())
		{
			base.method_16("bFullBerserkCharge", true);
		}
	}

	// Token: 0x060003D7 RID: 983 RVA: 0x0000564C File Offset: 0x0000384C
	public override void vmethod_4()
	{
		base.vmethod_4();
		this.m_networkCompensationPer = this.m_netLantency;
	}

	// Token: 0x060003D8 RID: 984 RVA: 0x00005660 File Offset: 0x00003860
	public override void vmethod_2()
	{
		base.vmethod_2();
		base.m_status = AnimationStatus.SUCCESS;
		base.method_16("bUpperBerserkCharge", false);
		base.method_16("bFullBerserkCharge", false);
	}

	// Token: 0x060003D9 RID: 985 RVA: 0x00005689 File Offset: 0x00003889
	protected override void OnAnimationTimeElapsed(string state)
	{
		base.m_status = AnimationStatus.SUCCESS;
		base.method_16("bUpperBerserkCharge", false);
		base.method_16("bFullBerserkCharge", false);
	}

	// Token: 0x040003C4 RID: 964
	public float m_netLantency;
}
