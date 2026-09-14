using System;
using Core;
using UnityEngine;
using XsdSettings;

// Token: 0x020000A0 RID: 160
public class AnimationPlayerAimState : PlayerAnimationState
{
	// Token: 0x060003C5 RID: 965 RVA: 0x00005545 File Offset: 0x00003745
	public AnimationPlayerAimState()
	{
		this.StateName = "PlayerAim";
	}

	// Token: 0x1700001B RID: 27
	// (get) Token: 0x060003C6 RID: 966 RVA: 0x0000555F File Offset: 0x0000375F
	private PlayerBehavior PlayerBehavior_0
	{
		get
		{
			if (this.m_inner_playerBehavior == null)
			{
				this.m_inner_playerBehavior = base.method_21().GetComponent<PlayerBehavior>();
			}
			return this.m_inner_playerBehavior;
		}
	}

	// Token: 0x1700001C RID: 28
	// (get) Token: 0x060003C7 RID: 967 RVA: 0x00005586 File Offset: 0x00003786
	// (set) Token: 0x060003C8 RID: 968 RVA: 0x0000558E File Offset: 0x0000378E
	public bool Boolean_1
	{
		get
		{
			return this.m_isAiming;
		}
		set
		{
			this.m_isAiming = value;
		}
	}

	// Token: 0x060003C9 RID: 969 RVA: 0x00048A28 File Offset: 0x00046C28
	public override void vmethod_0()
	{
		base.vmethod_0();
		base.m_status = AnimationStatus.RUNNING;
		if (base.Boolean_0)
		{
			this.m_player = this.m_AnimationManagerFSM.m_entity as EntityPlayer;
			this.m_bTriggerOnce = true;
			base.method_7(MecanimAnimationID.ID_1st_Aim);
			if (base.Animator_0 != null && this.m_player != null && this.m_player.vmethod_16() != null)
			{
				if (this.m_player.vmethod_16().method_20())
				{
					base.method_11("fScopeType", 1f);
				}
				else
				{
					base.method_11("fScopeType", 0f);
				}
				base.method_9("Aim", 0, this.method_22("Aim", 0));
				if (this.m_player.vmethod_16().method_99() != WeaponType.SniperRifle)
				{
					base.method_9("Idle_Aim", 1, this.method_22("Idle_Aim", 1));
				}
			}
		}
		base.method_19(false);
		this.method_23();
	}

	// Token: 0x060003CA RID: 970 RVA: 0x00048B30 File Offset: 0x00046D30
	private float method_22(string string_1, int int_0)
	{
		float num = 0f;
		AnimatorStateInfo currentAnimatorStateInfo = base.Animator_0.GetCurrentAnimatorStateInfo(int_0);
		if (currentAnimatorStateInfo.length > 0f)
		{
			num = this.m_player.vmethod_16().method_76() / currentAnimatorStateInfo.length;
		}
		else
		{
			DebugUtils.LogError(LogCategory.Gamelogic, string.Concat(new object[] { "animation to aim length is below 0 , targetState ", string_1, "hand of weapon animation layer ", int_0 }));
		}
		return num;
	}

	// Token: 0x060003CB RID: 971 RVA: 0x00048BA8 File Offset: 0x00046DA8
	public override void vmethod_1()
	{
		base.method_16("bIsAiming", true);
		if (base.Boolean_0)
		{
			this.m_animatorInfo = base.method_15(base.Boolean_0, 0);
			if (this.m_bTriggerOnce && this.m_animatorInfo.IsTag("Aim"))
			{
				this.m_bTriggerOnce = false;
				if (this.m_player != null && this.m_player.GetComponent<PlayerControllerLocal>() != null)
				{
					this.m_player.GetComponent<PlayerControllerLocal>().OnAnimationStart_Aim();
					this.m_player.method_109(true);
				}
				if (base.Boolean_0)
				{
					base.method_10("bFromFire", false);
				}
			}
			this.m_animatorInfo = base.method_15(base.Boolean_0, 1);
			if (this.m_animatorInfo.IsTag("AimFire"))
			{
				base.method_10("bAimFire", false);
			}
		}
		if (this.PlayerBehavior_0.IsFiring())
		{
			this.m_fireHolding_duration += Time.deltaTime;
		}
		else
		{
			this.m_fireHolding_duration = 0f;
		}
	}

	// Token: 0x060003CC RID: 972 RVA: 0x00048CB4 File Offset: 0x00046EB4
	public override void vmethod_2()
	{
		base.vmethod_2();
		if (this.m_player)
		{
			this.m_player.method_109(false);
		}
		if (base.Boolean_0)
		{
			base.method_8(MecanimAnimationID.ID_1st_Aim);
			base.method_10("bFromAimFire", true);
		}
		base.method_16("bIsAiming", false);
		base.m_status = AnimationStatus.SUCCESS;
		if (base.Boolean_0 && this.m_player != null)
		{
			this.m_player.method_59(false);
		}
		base.method_19(true);
		this.method_27();
		this.method_24();
		this.m_fireHolding_duration = 0f;
	}

	// Token: 0x060003CD RID: 973 RVA: 0x00048D54 File Offset: 0x00046F54
	private void method_23()
	{
		if (this.m_AnimManager == null)
		{
			this.m_AnimManager = this.m_AnimationManagerFSM as PlayerAnimationManagerFSM;
		}
		this.m_AnimManager.m_fireTiming.Event_0 += this.method_26;
		this.m_AnimManager.m_fireTiming.Event_1 += this.method_25;
		this.m_AnimManager.m_fireTiming.Event_2 += this.method_27;
	}

	// Token: 0x060003CE RID: 974 RVA: 0x00048DD4 File Offset: 0x00046FD4
	private void method_24()
	{
		this.m_AnimManager.m_fireTiming.Event_0 -= this.method_26;
		this.m_AnimManager.m_fireTiming.Event_1 -= this.method_25;
		this.m_AnimManager.m_fireTiming.Event_2 -= this.method_27;
	}

	// Token: 0x060003CF RID: 975 RVA: 0x00005597 File Offset: 0x00003797
	private void method_25(float float_2)
	{
		if (base.Boolean_0 && !this.method_28())
		{
			base.method_10("bAimFire", true);
		}
	}

	// Token: 0x060003D0 RID: 976 RVA: 0x000055B6 File Offset: 0x000037B6
	private void method_26()
	{
		if (base.Boolean_0 && this.method_29() && !this.method_28())
		{
			base.method_10("bAimFire", true);
		}
	}

	// Token: 0x060003D1 RID: 977 RVA: 0x000055DD File Offset: 0x000037DD
	private void method_27()
	{
		if (base.Boolean_0 && !this.method_28())
		{
			base.method_10("bAimFire", false);
		}
	}

	// Token: 0x060003D2 RID: 978 RVA: 0x000055FC File Offset: 0x000037FC
	private bool method_28()
	{
		return this.m_player != null && this.m_player.vmethod_16() != null && this.m_player.vmethod_16().method_21();
	}

	// Token: 0x060003D3 RID: 979 RVA: 0x00048E38 File Offset: 0x00047038
	private bool method_29()
	{
		if (this.m_player != null)
		{
			EntityWeapon entityWeapon = this.m_player.vmethod_16();
			if (entityWeapon != null)
			{
				WeaponDNA weaponDNA = entityWeapon.method_17();
				if (weaponDNA != null)
				{
					switch (weaponDNA.m_type)
					{
					case WeaponType.SMG:
						return true;
					case WeaponType.RepeaterPistol:
						return true;
					case WeaponType.CombatRifle:
						return true;
					}
				}
			}
		}
		return false;
	}

	// Token: 0x060003D4 RID: 980 RVA: 0x00005631 File Offset: 0x00003831
	public float method_30()
	{
		return this.m_fireHolding_duration;
	}

	// Token: 0x040003BA RID: 954
	private const int m_firstPeronAimLayer = 0;

	// Token: 0x040003BB RID: 955
	private const int m_firstPersonAimShootLayer = 1;

	// Token: 0x040003BC RID: 956
	private const string m_stateNameInLayer = "Aim";

	// Token: 0x040003BD RID: 957
	private const string m_stateNameInShootLayer = "Idle_Aim";

	// Token: 0x040003BE RID: 958
	private bool m_bTriggerOnce = true;

	// Token: 0x040003BF RID: 959
	private EntityPlayer m_player;

	// Token: 0x040003C0 RID: 960
	private PlayerAnimationManagerFSM m_AnimManager;

	// Token: 0x040003C1 RID: 961
	private bool m_isAiming;

	// Token: 0x040003C2 RID: 962
	private float m_fireHolding_duration;

	// Token: 0x040003C3 RID: 963
	private PlayerBehavior m_inner_playerBehavior;
}
