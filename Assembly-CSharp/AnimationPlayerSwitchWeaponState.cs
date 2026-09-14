using System;

// Token: 0x020000BF RID: 191
public class AnimationPlayerSwitchWeaponState : PlayerAnimationState
{
	// Token: 0x06000465 RID: 1125 RVA: 0x00006011 File Offset: 0x00004211
	public AnimationPlayerSwitchWeaponState()
	{
		this.StateName = "PlayerSwitchWeapon";
	}

	// Token: 0x06000466 RID: 1126 RVA: 0x0000602F File Offset: 0x0000422F
	public void method_22(EntityWeapon entityWeapon_0, EntityPlayer entityPlayer_0)
	{
		this.m_nextWeapon = entityWeapon_0;
		this.m_entityPlayer = entityPlayer_0;
	}

	// Token: 0x06000467 RID: 1127 RVA: 0x0004AD28 File Offset: 0x00048F28
	public override void vmethod_0()
	{
		base.vmethod_0();
		if (this.m_entityPlayer.vmethod_16() != null)
		{
			this.m_switchSpeed = this.m_entityPlayer.vmethod_16().method_74();
		}
		this.method_23();
		if (base.Boolean_0)
		{
			base.method_7(MecanimAnimationID.ID_1st_SwitchDown);
			if (base.PlayerWeaponAnimationManagerFSM_0 != null)
			{
				base.PlayerWeaponAnimationManagerFSM_0.OnSwitchWeapon(true);
			}
		}
		base.method_16("bSwitchDown", true);
		base.m_status = AnimationStatus.RUNNING;
		if (base.PlayerWeaponAnimationManagerFSM_0 != null)
		{
			base.PlayerWeaponAnimationManagerFSM_0.method_20();
		}
		this.m_stateTag = "SwitchDown";
		this.m_layer = 1;
	}

	// Token: 0x06000468 RID: 1128 RVA: 0x0000603F File Offset: 0x0000423F
	protected override void OnAnimationTimeElapsed(string tag)
	{
		base.method_16("bSwitchDown", false);
		base.m_status = AnimationStatus.SUCCESS;
		this.m_playerAnimManager.OnPickUpWeapon(this.m_nextWeapon);
	}

	// Token: 0x06000469 RID: 1129 RVA: 0x00006066 File Offset: 0x00004266
	public override void vmethod_2()
	{
		base.vmethod_2();
		base.method_16("bSwitchDown", false);
		base.m_status = AnimationStatus.SUCCESS;
	}

	// Token: 0x0600046A RID: 1130 RVA: 0x00006082 File Offset: 0x00004282
	private void method_23()
	{
		if (base.Boolean_0)
		{
			base.method_11("fSwitchSpeed", this.m_switchSpeed);
		}
		base.method_17("fSwitchSpeed", this.m_switchSpeed);
	}

	// Token: 0x0400043C RID: 1084
	private const string SWITCHUP_TAG = "SwitchUp";

	// Token: 0x0400043D RID: 1085
	private const string SWITCHDOWN_TAG = "SwitchDown";

	// Token: 0x0400043E RID: 1086
	public bool m_SwitchStarted;

	// Token: 0x0400043F RID: 1087
	private float m_startTime;

	// Token: 0x04000440 RID: 1088
	private EntityWeapon m_nextWeapon;

	// Token: 0x04000441 RID: 1089
	private EntityPlayer m_entityPlayer;

	// Token: 0x04000442 RID: 1090
	private float m_switchSpeed = 1f;
}
