using System;
using Core;

// Token: 0x020000B8 RID: 184
public class AnimationPlayerReloadState : PlayerAnimationState
{
	// Token: 0x06000447 RID: 1095 RVA: 0x00005DF7 File Offset: 0x00003FF7
	public AnimationPlayerReloadState()
	{
		this.StateName = "PlayerReload";
		this.m_stateTag = "Reload";
		this.m_layer = 1;
	}

	// Token: 0x06000448 RID: 1096 RVA: 0x0004A770 File Offset: 0x00048970
	public override void vmethod_0()
	{
		base.vmethod_0();
		this.m_thirdPersonReloadStarted = false;
		this.m_weaponMode = ((PlayerAnimationManagerFSM)this.m_AnimationManagerFSM).method_29();
		this.m_reloadSpeed = this.m_AnimationManagerFSM.m_entity.vmethod_16().method_77();
		this.m_reloadPercentage = base.method_21().vmethod_16().method_100();
		base.method_4(new PlayerAnimationState.AnimationStateEventCallBack(this.OnReloadTimeElapsed), this.m_reloadPercentage);
		if (this.m_reloadPercentage > this.m_maxReloadPercentage)
		{
			DebugUtils.LogWarning(LogCategory.Gamelogic, "weapon type reload percentage is bigger than max value, its reload animatin can't be finished, weapon type is " + base.method_21().vmethod_16().method_99()
				.ToString());
		}
		if (base.Boolean_0)
		{
			base.method_11("fWeaponMode", this.m_weaponMode);
			base.method_11("fReloadSpeed", this.m_reloadSpeed);
			base.method_10("bFire", false);
		}
		base.method_17("fWeaponMode", this.m_weaponMode);
		base.method_17("fReloadSpeed", this.m_reloadSpeed);
		base.method_16("bFire", false);
		base.method_16("bReload", true);
		base.m_status = AnimationStatus.RUNNING;
		base.method_7(MecanimAnimationID.ID_1st_Reload);
		if (base.PlayerWeaponAnimationManagerFSM_0 != null)
		{
			base.PlayerWeaponAnimationManagerFSM_0.OnWeaponReload(this.m_netLantency);
		}
	}

	// Token: 0x06000449 RID: 1097 RVA: 0x00005E32 File Offset: 0x00004032
	public override void vmethod_4()
	{
		this.m_networkCompensationPer = this.m_netLantency / this.m_animatorInfo.length;
	}

	// Token: 0x0600044A RID: 1098 RVA: 0x0004A8C8 File Offset: 0x00048AC8
	public override void vmethod_2()
	{
		base.vmethod_2();
		if (!base.Boolean_0)
		{
		}
		if (base.PlayerWeaponAnimationManagerFSM_0 != null && base.PlayerWeaponAnimationManagerFSM_0.m_weaponAnimator != null)
		{
			base.PlayerWeaponAnimationManagerFSM_0.m_weaponAnimator.SetBool("bClear", true);
		}
		base.method_16("bReload", false);
		base.method_5(new PlayerAnimationState.AnimationStateEventCallBack(this.OnReloadTimeElapsed), this.m_reloadPercentage);
	}

	// Token: 0x0600044B RID: 1099 RVA: 0x00005E4C File Offset: 0x0000404C
	protected override void OnAnimationTimeElapsed(string tag)
	{
		if (this.m_animatorInfo.IsTag("Reload"))
		{
			base.method_16("bReload", false);
		}
		base.m_status = AnimationStatus.SUCCESS;
	}

	// Token: 0x0600044C RID: 1100 RVA: 0x00005E74 File Offset: 0x00004074
	private void OnReloadTimeElapsed(string tag)
	{
		this.m_AnimationManagerFSM.m_entity.vmethod_16().OnReloadAnimDone();
	}

	// Token: 0x0400041C RID: 1052
	private const string RELOAD_TAG = "Reload";

	// Token: 0x0400041D RID: 1053
	public bool m_thirdPersonReloadStarted;

	// Token: 0x0400041E RID: 1054
	private float m_startTime;

	// Token: 0x0400041F RID: 1055
	private float m_weaponMode;

	// Token: 0x04000420 RID: 1056
	private float m_reloadSpeed = 1f;

	// Token: 0x04000421 RID: 1057
	public float m_netLantency;

	// Token: 0x04000422 RID: 1058
	private float m_reloadPercentage;

	// Token: 0x04000423 RID: 1059
	private float m_maxReloadPercentage = 0.97f;
}
