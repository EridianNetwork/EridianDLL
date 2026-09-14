using System;
using Core;
using UnityEngine;
using XsdSettings;

// Token: 0x02000099 RID: 153
public class PlayerWeaponAnimationManagerFSM : AnimationManagerFSM
{
	// Token: 0x06000399 RID: 921 RVA: 0x000478F8 File Offset: 0x00045AF8
	public void method_19()
	{
		string text = "Entities/Player_Mecanim/WPN_SMG_Controller";
		this.m_weaponControllerSMG = (RuntimeAnimatorController)Resources.Load(text);
		text = "Entities/Player_Mecanim/WPN_Shotgun_Controller";
		this.m_weaponControllerShotgun = (RuntimeAnimatorController)Resources.Load(text);
		text = "Entities/Player_Mecanim/WPN_Sniper_Controller";
		this.m_weaponControllerSniper = (RuntimeAnimatorController)Resources.Load(text);
		text = "Entities/Player_Mecanim/WPN_RepeaterPistol_Controller";
		this.m_weaponControllerPistol = (RuntimeAnimatorController)Resources.Load(text);
		text = "Entities/Player_Mecanim/WPN_CombatRifle_Controller";
		this.m_weaponControllerCombatRifle = (RuntimeAnimatorController)Resources.Load(text);
		this.method_20();
	}

	// Token: 0x0600039A RID: 922 RVA: 0x00047980 File Offset: 0x00045B80
	public void method_20()
	{
		if (this.m_entity == null)
		{
			this.m_entity = base.GetComponent<EntityPlayer>();
		}
		if (this.m_entity == null)
		{
			return;
		}
		this.m_entityWeapon = this.m_entity.vmethod_16();
		if (this.m_entityWeapon == null)
		{
			return;
		}
		this.m_entityWeapon.method_66();
		PlayerAnimationManagerFSM component = base.GetComponent<PlayerAnimationManagerFSM>();
		if (component != null)
		{
			component.vmethod_15(this.m_entityWeapon.method_17().m_type);
			this.m_weaponMode = component.method_29();
		}
		else
		{
			DebugUtils.LogError(LogCategory.Animation, "PlayerAnimationManager can't be null!");
		}
		this.m_weaponAnimator = this.m_entityWeapon.gameObject.GetComponentInChildren<Animator>();
		if (this.m_weaponAnimator != null)
		{
			switch (this.m_entityWeapon.method_17().m_type)
			{
			case WeaponType.SMG:
				this.m_weaponAnimator.runtimeAnimatorController = this.m_weaponControllerSMG;
				break;
			case WeaponType.SniperRifle:
				this.m_weaponAnimator.runtimeAnimatorController = this.m_weaponControllerSniper;
				break;
			case WeaponType.ShotGun:
				this.m_weaponAnimator.runtimeAnimatorController = this.m_weaponControllerShotgun;
				break;
			case WeaponType.RepeaterPistol:
				this.m_weaponAnimator.runtimeAnimatorController = this.m_weaponControllerPistol;
				break;
			case WeaponType.CombatRifle:
				this.m_weaponAnimator.runtimeAnimatorController = this.m_weaponControllerCombatRifle;
				break;
			}
			this.method_24();
			this.m_weaponAnimator.applyRootMotion = false;
			for (int i = 0; i < this.m_weaponAnimator.layerCount; i++)
			{
				this.m_weaponAnimator.SetLayerWeight(i, 1f);
			}
			this.m_clearPending = true;
			if (this.m_isPlayerLocal)
			{
				if (this.m_entityWeapon.method_99() == WeaponType.RepeaterPistol)
				{
					this.m_weaponAnimator.SetFloat("fSwitchSpeed", this.m_entityWeapon.method_74());
				}
				else if (this.m_entityWeapon.method_99() == WeaponType.ShotGun)
				{
					this.m_weaponAnimator.SetFloat("fSwitchSpeed", this.m_entityWeapon.method_75());
				}
			}
		}
	}

	// Token: 0x0600039B RID: 923 RVA: 0x00047B70 File Offset: 0x00045D70
	public void method_21(Animator animator_0)
	{
		this.m_weaponAnimator = animator_0;
		this.m_weaponAnimator.applyRootMotion = false;
		for (int i = 0; i < this.m_weaponAnimator.layerCount; i++)
		{
			this.m_weaponAnimator.SetLayerWeight(i, 1f);
		}
	}

	// Token: 0x0600039C RID: 924 RVA: 0x0000532C File Offset: 0x0000352C
	public override void Start()
	{
		this.method_19();
	}

	// Token: 0x0600039D RID: 925 RVA: 0x00047BB8 File Offset: 0x00045DB8
	public override void vmethod_7(AnimationStateFSM animationStateFSM_0)
	{
		string text = Utils.smethod_23(animationStateFSM_0);
		if (this.m_animationStateMachine.States.ContainsKey(text))
		{
			base.method_11(text, this.m_animationStateMachine);
		}
		else if (this.m_upperBodyStateMachine != null && this.m_upperBodyStateMachine.States.ContainsKey(text))
		{
			base.method_11(text, this.m_upperBodyStateMachine);
		}
	}

	// Token: 0x0600039E RID: 926 RVA: 0x00005334 File Offset: 0x00003534
	public override void Update()
	{
		if (this.m_weaponAnimator == null)
		{
			this.method_20();
			base.Boolean_1 = false;
		}
		base.Update();
		this.method_22();
	}

	// Token: 0x0600039F RID: 927 RVA: 0x00047C18 File Offset: 0x00045E18
	public void method_22()
	{
		if (this.m_entityWeapon == null)
		{
			return;
		}
		if (this.m_weaponAnimator == null)
		{
			return;
		}
		if (!this.m_isPlayerLocal)
		{
			return;
		}
		this.m_weaponAnimator.SetFloat("fWeaponMode", this.m_weaponMode);
		if (this.m_clearPending)
		{
			this.m_weaponAnimator.SetBool("bClear", true);
			this.m_clearPending = false;
			return;
		}
		this.m_weaponAnimator.SetBool("bClear", false);
		if (this.m_firePending && this.method_23() && !this.m_reloadPending)
		{
			this.m_firePending = false;
		}
		else
		{
			this.m_weaponAnimator.SetBool("bFire", false);
		}
		if (this.m_reloadPending)
		{
			this.m_weaponAnimator.SetFloat("fReloadSpeed", this.m_entityWeapon.method_77());
			this.m_weaponAnimator.SetBool("bReload", true);
			this.m_weaponAnimator.SetBool("bFire", false);
			this.m_reloadPending = false;
		}
		else
		{
			this.m_weaponAnimator.SetBool("bReload", false);
		}
	}

	// Token: 0x060003A0 RID: 928 RVA: 0x0000535D File Offset: 0x0000355D
	private bool method_23()
	{
		if (this.m_playerAnimationManager == null)
		{
			this.m_playerAnimationManager = base.gameObject.GetComponent<PlayerAnimationManagerFSM>();
		}
		return this.m_playerAnimationManager != null && this.m_playerAnimationManager.method_48();
	}

	// Token: 0x060003A1 RID: 929 RVA: 0x00047D28 File Offset: 0x00045F28
	public override void OnAttack()
	{
		if (this.m_entityWeapon == null)
		{
			return;
		}
		if (this.m_weaponAnimator == null)
		{
			return;
		}
		if (this.m_isPlayerLocal)
		{
			this.m_entityWeapon.method_79();
			this.m_weaponAnimator.SetBool("bFire", true);
		}
	}

	// Token: 0x060003A2 RID: 930 RVA: 0x00005399 File Offset: 0x00003599
	public void OnWeaponReload(float compasation)
	{
		if (this.m_isPlayerLocal)
		{
			this.m_reloadPending = true;
			return;
		}
	}

	// Token: 0x060003A3 RID: 931 RVA: 0x00047D78 File Offset: 0x00045F78
	public void OnSwitchWeapon(bool down)
	{
		if (this.m_entityWeapon == null)
		{
			return;
		}
		if (this.m_weaponAnimator == null)
		{
			return;
		}
		if (this.m_isPlayerLocal && this.m_entityWeapon.method_99() == WeaponType.RepeaterPistol)
		{
			if (down)
			{
				this.m_weaponAnimator.SetBool("bSwitchWeapon", true);
			}
			else
			{
				this.m_weaponAnimator.SetBool("bSwitchWeapon", false);
			}
		}
	}

	// Token: 0x060003A4 RID: 932 RVA: 0x000053AB File Offset: 0x000035AB
	private void method_24()
	{
		if (this.m_weaponAnimator == null)
		{
			return;
		}
		if (this.m_weaponAnimator.GetComponent<MecanimEventEmitter>())
		{
			this.m_weaponAnimator.GetComponent<MecanimEventEmitter>().animatorController = this.m_weaponAnimator.runtimeAnimatorController;
		}
	}

	// Token: 0x04000396 RID: 918
	public Animator m_weaponAnimator;

	// Token: 0x04000397 RID: 919
	public bool m_isPlayerLocal;

	// Token: 0x04000398 RID: 920
	public EntityWeapon m_entityWeapon;

	// Token: 0x04000399 RID: 921
	private bool m_firePending;

	// Token: 0x0400039A RID: 922
	private bool m_reloadPending;

	// Token: 0x0400039B RID: 923
	private bool m_clearPending;

	// Token: 0x0400039C RID: 924
	private RuntimeAnimatorController m_weaponControllerSMG;

	// Token: 0x0400039D RID: 925
	private RuntimeAnimatorController m_weaponControllerShotgun;

	// Token: 0x0400039E RID: 926
	private RuntimeAnimatorController m_weaponControllerSniper;

	// Token: 0x0400039F RID: 927
	private RuntimeAnimatorController m_weaponControllerPistol;

	// Token: 0x040003A0 RID: 928
	private RuntimeAnimatorController m_weaponControllerCombatRifle;

	// Token: 0x040003A1 RID: 929
	private float m_weaponMode;

	// Token: 0x040003A2 RID: 930
	private PlayerAnimationManagerFSM m_playerAnimationManager;

	// Token: 0x0200009A RID: 154
	public enum E_WeaponAnimation
	{
		// Token: 0x040003A4 RID: 932
		Idle,
		// Token: 0x040003A5 RID: 933
		Draw,
		// Token: 0x040003A6 RID: 934
		Fire,
		// Token: 0x040003A7 RID: 935
		Reload
	}
}
