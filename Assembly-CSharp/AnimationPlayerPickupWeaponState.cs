using System;

// Token: 0x020000B5 RID: 181
public class AnimationPlayerPickupWeaponState : PlayerAnimationState
{
	// Token: 0x0600043A RID: 1082 RVA: 0x00005CED File Offset: 0x00003EED
	public AnimationPlayerPickupWeaponState()
	{
		this.StateName = "PlayerPickupWeapon";
		this.m_stateTag = "SwitchUp";
		this.m_layer = 1;
	}

	// Token: 0x0600043B RID: 1083 RVA: 0x00005D12 File Offset: 0x00003F12
	public void method_22(EntityWeapon entityWeapon_0, EntityPlayer entityPlayer_0)
	{
		this.m_nextWeapon = entityWeapon_0;
		this.m_entityPlayer = entityPlayer_0;
	}

	// Token: 0x0600043C RID: 1084 RVA: 0x00005D22 File Offset: 0x00003F22
	public override void vmethod_0()
	{
		base.vmethod_0();
		this.m_pickupStarted = false;
		if (base.Boolean_0)
		{
			base.method_7(MecanimAnimationID.ID_1st_PickUp);
		}
		base.method_16("bPickUp", true);
		base.m_status = AnimationStatus.RUNNING;
	}

	// Token: 0x0600043D RID: 1085 RVA: 0x0004A5C0 File Offset: 0x000487C0
	public override void vmethod_4()
	{
		base.vmethod_4();
		if (this.m_entityPlayer != null && this.m_nextWeapon != null)
		{
			if (base.PlayerWeaponAnimationManagerFSM_0 != null)
			{
				base.PlayerWeaponAnimationManagerFSM_0.method_20();
			}
			this.method_23(this.m_nextWeapon);
		}
	}

	// Token: 0x0600043E RID: 1086 RVA: 0x00005D55 File Offset: 0x00003F55
	protected override void OnAnimationTimeElapsed(string tag)
	{
		if (this.m_animatorInfo.IsTag("SwitchUp"))
		{
			base.method_16("bPickUp", false);
		}
		base.m_status = AnimationStatus.SUCCESS;
	}

	// Token: 0x0600043F RID: 1087 RVA: 0x00005D7D File Offset: 0x00003F7D
	public override void vmethod_2()
	{
		base.vmethod_2();
		if (!base.Boolean_0)
		{
		}
		base.method_16("bPickUp", false);
		base.m_status = AnimationStatus.SUCCESS;
		this.m_entityPlayer.OnSwitchWeaponDone();
	}

	// Token: 0x06000440 RID: 1088 RVA: 0x00005DAC File Offset: 0x00003FAC
	private void method_23(EntityWeapon entityWeapon_0)
	{
		if (base.Boolean_0)
		{
			base.method_11("fSwitchSpeed", entityWeapon_0.method_75());
		}
		base.method_17("fSwitchSpeed", entityWeapon_0.method_75());
	}

	// Token: 0x04000411 RID: 1041
	private const string SWITCHUP_TAG = "SwitchUp";

	// Token: 0x04000412 RID: 1042
	public bool m_pickupStarted;

	// Token: 0x04000413 RID: 1043
	private float m_startTime;

	// Token: 0x04000414 RID: 1044
	private EntityWeapon m_nextWeapon;

	// Token: 0x04000415 RID: 1045
	private EntityPlayer m_entityPlayer;
}
