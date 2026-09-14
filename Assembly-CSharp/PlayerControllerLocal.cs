using System;
using ns0;

// Token: 0x020004B6 RID: 1206
public class PlayerControllerLocal : PlayerController
{
	// Token: 0x0600208C RID: 8332 RVA: 0x0009F0C4 File Offset: 0x0009D2C4
	public override void Start()
	{
		base.Start();
		this.m_playerBehavior = base.GetComponent<PlayerBehavior>();
		this.m_playerThirdPersonAnimationManagerFSM.m_isPlayerLocal = true;
		this.m_playerWeaponAnimationManagerFSM = base.GetComponent<PlayerWeaponAnimationManagerFSM>();
		this.m_playerWeaponAnimationManagerFSM.m_isPlayerLocal = true;
		this.m_shootingTestMenu = MonoSingleton<Session>.Instance.GetComponent<ShootingTestMenu>();
	}

	// Token: 0x0600208D RID: 8333 RVA: 0x0009F118 File Offset: 0x0009D318
	protected override void FixedUpdate()
	{
		if (this.m_shootingTestMenu != null && this.m_shootingTestMenu.enabled)
		{
			this.m_shootingTestMenu.method_0();
		}
		base.method_11();
		this.m_inInput.CaptureAndQueueInputFrame();
		this.method_59();
		this.m_playerThirdPersonAnimationManagerFSM.method_33(this.m_playerBehavior.method_22(), this.m_playerBehavior.method_23());
		base.FixedUpdate();
	}

	// Token: 0x0600208E RID: 8334 RVA: 0x0009F18C File Offset: 0x0009D38C
	private void method_59()
	{
		if (this.m_playerBehavior.IsFiring())
		{
			base.method_35();
		}
		if (this.m_playerBehavior.IsSwitchingWeapon())
		{
			base.method_41(this.m_playerBehavior.method_15());
		}
		if (this.m_playerBehavior.IsReloading())
		{
			base.method_39();
		}
		if (this.m_playerBehavior.IsUsingSkill())
		{
			base.method_49();
			MonoSingleton<GuidanceTipsManager>.Instance.method_2("guidance_use_skill");
			MonoSingleton<GuidanceTipsManager>.Instance.method_2("guidance_use_secondary");
		}
		if (this.m_playerBehavior.IsInteracting())
		{
			base.method_51();
		}
		if (this.m_playerBehavior.IsThrowing())
		{
			base.method_53();
		}
		if (this.m_playerBehavior.IsMeleeing())
		{
			base.method_55();
		}
		if (this.m_playerBehavior.IsAiming())
		{
			base.method_47(true);
		}
		else
		{
			base.method_47(false);
			if (!this.m_inInput.IsRunning() && !base.method_56())
			{
				if (this.m_inInput.IsJumping())
				{
					MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDAimTargetView>().vmethod_5(E_SCOPE_TYPE.E_NORMAL);
					EntityWeapon entityWeapon = this.m_entity.vmethod_16();
					if (entityWeapon != null)
					{
						entityWeapon.method_98();
					}
				}
				else
				{
					MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDAimTargetView>().vmethod_5(E_SCOPE_TYPE.E_NORMAL);
				}
			}
			else
			{
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDAimTargetView>().vmethod_5(E_SCOPE_TYPE.E_NONE);
				EntityWeapon entityWeapon2 = this.m_entity.vmethod_16();
				if (entityWeapon2 != null)
				{
					entityWeapon2.method_98();
				}
			}
		}
	}

	// Token: 0x0600208F RID: 8335 RVA: 0x0009F304 File Offset: 0x0009D504
	public void OnAnimationStart_Aim()
	{
		if (this.m_entity && this.m_entity.vmethod_16() && this.m_entity.vmethod_16().method_21())
		{
			this.m_entity.method_59(true);
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDAimTargetView>().vmethod_6(this.m_entity.vmethod_16().method_73());
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDAimTargetView>().vmethod_5(E_SCOPE_TYPE.E_SNIPER);
		}
		else
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDAimTargetView>().vmethod_5(E_SCOPE_TYPE.E_NONE);
		}
	}

	// Token: 0x0400151E RID: 5406
	private PlayerWeaponAnimationManagerFSM m_playerWeaponAnimationManagerFSM;

	// Token: 0x0400151F RID: 5407
	private ShootingTestMenu m_shootingTestMenu;
}
