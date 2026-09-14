using System;

// Token: 0x020000BE RID: 190
public class AnimationPlayerSwitchUpState : PlayerAnimationState
{
	// Token: 0x0600045F RID: 1119 RVA: 0x00005F7E File Offset: 0x0000417E
	public AnimationPlayerSwitchUpState()
	{
		this.StateName = "PlayerSwitchUp";
		this.m_stateTag = "SwitchUp";
		this.m_layer = 1;
	}

	// Token: 0x06000460 RID: 1120 RVA: 0x00005FA3 File Offset: 0x000041A3
	public void method_22(EntityWeapon entityWeapon_0, EntityPlayer entityPlayer_0)
	{
		this.m_nextWeapon = entityWeapon_0;
		this.m_entityPlayer = entityPlayer_0;
	}

	// Token: 0x06000461 RID: 1121 RVA: 0x0004AC98 File Offset: 0x00048E98
	public override void vmethod_0()
	{
		base.vmethod_0();
		this.m_pickupStarted = false;
		if (base.Boolean_0)
		{
			base.method_7(MecanimAnimationID.ID_1st_SwitchUp);
		}
		base.method_16("bSwitchUp", true);
		base.m_status = AnimationStatus.RUNNING;
		if (this.m_entityPlayer != null && this.m_nextWeapon != null)
		{
			this.m_entityPlayer.method_50(this.m_nextWeapon);
			if (base.PlayerWeaponAnimationManagerFSM_0 != null)
			{
				base.PlayerWeaponAnimationManagerFSM_0.method_20();
			}
			this.method_23(this.m_nextWeapon);
		}
	}

	// Token: 0x06000462 RID: 1122 RVA: 0x00005FB3 File Offset: 0x000041B3
	protected override void OnAnimationTimeElapsed(string tag)
	{
		if (this.m_animatorInfo.IsTag("SwitchUp"))
		{
			base.method_16("bSwitchUp", false);
		}
		base.m_status = AnimationStatus.SUCCESS;
	}

	// Token: 0x06000463 RID: 1123 RVA: 0x00005FDB File Offset: 0x000041DB
	public override void vmethod_2()
	{
		base.vmethod_2();
		if (base.Boolean_0)
		{
			base.method_8(MecanimAnimationID.ID_1st_SwitchUp);
		}
		base.method_16("bSwitchUp", false);
		base.m_status = AnimationStatus.SUCCESS;
		this.m_entityPlayer.OnSwitchWeaponDone();
	}

	// Token: 0x06000464 RID: 1124 RVA: 0x00005DAC File Offset: 0x00003FAC
	private void method_23(EntityWeapon entityWeapon_0)
	{
		if (base.Boolean_0)
		{
			base.method_11("fSwitchSpeed", entityWeapon_0.method_75());
		}
		base.method_17("fSwitchSpeed", entityWeapon_0.method_75());
	}

	// Token: 0x04000437 RID: 1079
	private const string SWITCHUP_TAG = "SwitchUp";

	// Token: 0x04000438 RID: 1080
	public bool m_pickupStarted;

	// Token: 0x04000439 RID: 1081
	private float m_startTime;

	// Token: 0x0400043A RID: 1082
	private EntityWeapon m_nextWeapon;

	// Token: 0x0400043B RID: 1083
	private EntityPlayer m_entityPlayer;
}
