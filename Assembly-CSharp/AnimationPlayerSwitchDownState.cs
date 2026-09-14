using System;

// Token: 0x020000BD RID: 189
public class AnimationPlayerSwitchDownState : PlayerAnimationState
{
	// Token: 0x06000459 RID: 1113 RVA: 0x00005EC5 File Offset: 0x000040C5
	public AnimationPlayerSwitchDownState()
	{
		this.StateName = "PlayerSwitchDown";
		this.m_stateTag = "SwitchDown";
		this.m_layer = 1;
	}

	// Token: 0x0600045A RID: 1114 RVA: 0x00005EF5 File Offset: 0x000040F5
	public void method_22(EntityWeapon entityWeapon_0, EntityPlayer entityPlayer_0)
	{
		this.m_nextWeapon = entityWeapon_0;
		this.m_entityPlayer = entityPlayer_0;
	}

	// Token: 0x0600045B RID: 1115 RVA: 0x0004ABFC File Offset: 0x00048DFC
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
	}

	// Token: 0x0600045C RID: 1116 RVA: 0x00005F05 File Offset: 0x00004105
	protected override void OnAnimationTimeElapsed(string tag)
	{
		base.method_16("bSwitchDown", false);
		base.m_status = AnimationStatus.SUCCESS;
		this.m_playerAnimManager.OnSwitchDownFinished(this.m_nextWeapon);
	}

	// Token: 0x0600045D RID: 1117 RVA: 0x00005F2C File Offset: 0x0000412C
	public override void vmethod_2()
	{
		base.vmethod_2();
		base.method_16("bSwitchDown", false);
		if (!base.Boolean_0)
		{
		}
		base.m_status = AnimationStatus.SUCCESS;
	}

	// Token: 0x0600045E RID: 1118 RVA: 0x00005F50 File Offset: 0x00004150
	private void method_23()
	{
		if (base.Boolean_0)
		{
			base.method_11("fSwitchSpeed", this.m_switchSpeed);
		}
		base.method_17("fSwitchSpeed", this.m_switchSpeed);
	}

	// Token: 0x04000430 RID: 1072
	private const string SWITCHUP_TAG = "SwitchUp";

	// Token: 0x04000431 RID: 1073
	private const string SWITCHDOWN_TAG = "SwitchDown";

	// Token: 0x04000432 RID: 1074
	public bool m_SwitchStarted;

	// Token: 0x04000433 RID: 1075
	private float m_startTime;

	// Token: 0x04000434 RID: 1076
	private EntityWeapon m_nextWeapon;

	// Token: 0x04000435 RID: 1077
	private EntityPlayer m_entityPlayer;

	// Token: 0x04000436 RID: 1078
	private float m_switchSpeed = 1f;
}
