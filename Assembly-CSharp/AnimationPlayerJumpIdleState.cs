using System;

// Token: 0x020000AC RID: 172
public class AnimationPlayerJumpIdleState : PlayerAnimationState
{
	// Token: 0x06000415 RID: 1045 RVA: 0x00005A02 File Offset: 0x00003C02
	public AnimationPlayerJumpIdleState()
	{
		this.StateName = "PlayerJumpIdle";
		this.m_stateTag = "JumpIdle";
		this.m_layer = 0;
	}

	// Token: 0x06000416 RID: 1046 RVA: 0x00005A27 File Offset: 0x00003C27
	public override void vmethod_0()
	{
		base.vmethod_0();
		if (base.Boolean_0)
		{
			base.method_8(MecanimAnimationID.ID_1st_JumpStart);
			base.method_7(MecanimAnimationID.ID_1st_JumpIdle);
		}
		base.method_16("bJumpStart", false);
		base.method_16("bJumpIdle", true);
	}

	// Token: 0x06000417 RID: 1047 RVA: 0x00005A5F File Offset: 0x00003C5F
	public override void vmethod_2()
	{
		base.vmethod_2();
		base.m_status = AnimationStatus.SUCCESS;
		if (base.Boolean_0)
		{
			base.method_8(MecanimAnimationID.ID_1st_JumpStart);
			base.method_8(MecanimAnimationID.ID_1st_JumpIdle);
		}
		base.method_16("bJumpStart", false);
		base.method_16("bJumpIdle", false);
	}

	// Token: 0x040003EC RID: 1004
	private const string JUMPSTART_TAG = "JumpStart";

	// Token: 0x040003ED RID: 1005
	private const string JUMPIDLE_TAG = "JumpIdle";

	// Token: 0x040003EE RID: 1006
	private const string JUMPLAND_TAG = "JumpLand";
}
