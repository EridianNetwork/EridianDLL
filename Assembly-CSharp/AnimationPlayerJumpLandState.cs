using System;

// Token: 0x020000AD RID: 173
public class AnimationPlayerJumpLandState : PlayerAnimationState
{
	// Token: 0x06000418 RID: 1048 RVA: 0x00005A9E File Offset: 0x00003C9E
	public AnimationPlayerJumpLandState()
	{
		this.StateName = "PlayerJumpLand";
		this.m_stateTag = "JumpLand";
		this.m_layer = 0;
	}

	// Token: 0x06000419 RID: 1049 RVA: 0x00049C64 File Offset: 0x00047E64
	public override void vmethod_0()
	{
		base.vmethod_0();
		if (base.Boolean_0)
		{
			base.method_8(MecanimAnimationID.ID_1st_JumpStart);
			base.method_8(MecanimAnimationID.ID_1st_JumpIdle);
			base.method_7(MecanimAnimationID.ID_1st_JumpLand);
		}
		base.method_16("bJumpStart", false);
		base.method_16("bJumpLand", true);
		BaseEventTriggerCtl componentInChildren = this.m_AnimationManagerFSM.m_animationHost.GetComponentInChildren<BaseEventTriggerCtl>();
		if (componentInChildren != null)
		{
			if (base.Boolean_0)
			{
				componentInChildren.vmethod_1(AudioEventName.Chr_Land_Rnd);
			}
			componentInChildren.vmethod_1(AudioEventName.Chr_Shr_Foley_Run_Rnd);
			componentInChildren.vmethod_1(AudioEventName.Chr_Shr_FootStep_Run);
		}
	}

	// Token: 0x0600041A RID: 1050 RVA: 0x00005AC3 File Offset: 0x00003CC3
	protected override void OnAnimationTimeElapsed(string tag)
	{
		base.m_status = AnimationStatus.SUCCESS;
		this.m_playerAnimManager.OnJumpLandFinish();
	}

	// Token: 0x0600041B RID: 1051 RVA: 0x00005AD7 File Offset: 0x00003CD7
	public override void vmethod_2()
	{
		base.vmethod_2();
		base.m_status = AnimationStatus.SUCCESS;
		if (base.Boolean_0)
		{
			base.method_8(MecanimAnimationID.ID_1st_JumpLand);
		}
		base.method_16("bJumpLand", false);
	}

	// Token: 0x040003EF RID: 1007
	private const string JUMPSTART_TAG = "JumpStart";

	// Token: 0x040003F0 RID: 1008
	private const string JUMPIDLE_TAG = "JumpIdle";

	// Token: 0x040003F1 RID: 1009
	private const string JUMPLAND_TAG = "JumpLand";
}
