using System;

// Token: 0x020000AE RID: 174
public class AnimationPlayerJumpStartState : PlayerAnimationState
{
	// Token: 0x0600041C RID: 1052 RVA: 0x00005B02 File Offset: 0x00003D02
	public AnimationPlayerJumpStartState()
	{
		this.StateName = "PlayerJumpStart";
		this.m_stateTag = "JumpStart";
		this.m_layer = 0;
	}

	// Token: 0x0600041D RID: 1053 RVA: 0x00005B27 File Offset: 0x00003D27
	public override void vmethod_0()
	{
		base.vmethod_0();
		if (base.Boolean_0)
		{
			base.method_7(MecanimAnimationID.ID_1st_JumpStart);
		}
		base.method_16("bJumpStart", true);
	}

	// Token: 0x0600041E RID: 1054 RVA: 0x00005B4B File Offset: 0x00003D4B
	protected override void OnAnimationTimeElapsed(string tag)
	{
		base.m_status = AnimationStatus.SUCCESS;
		this.m_playerAnimManager.OnJumpStartFinish();
	}

	// Token: 0x0600041F RID: 1055 RVA: 0x00005B5F File Offset: 0x00003D5F
	public override void vmethod_2()
	{
		base.vmethod_2();
		base.m_status = AnimationStatus.SUCCESS;
		if (base.Boolean_0)
		{
			base.method_8(MecanimAnimationID.ID_1st_JumpStart);
		}
		base.method_16("bJumpStart", false);
	}

	// Token: 0x040003F2 RID: 1010
	private const string JUMPSTART_TAG = "JumpStart";

	// Token: 0x040003F3 RID: 1011
	private const string JUMPIDLE_TAG = "JumpIdle";

	// Token: 0x040003F4 RID: 1012
	private const string JUMPLAND_TAG = "JumpLand";
}
