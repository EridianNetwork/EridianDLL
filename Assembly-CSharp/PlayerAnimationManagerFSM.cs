using System;
using System.Collections.Generic;
using System.Text;
using BHV;
using Core;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x02000097 RID: 151
public class PlayerAnimationManagerFSM : AnimationManagerFSM
{
	// Token: 0x06000345 RID: 837 RVA: 0x00004F9C File Offset: 0x0000319C
	public EAnimationJumpStep method_19()
	{
		return this.m_jumpStep;
	}

	// Token: 0x06000346 RID: 838 RVA: 0x00045760 File Offset: 0x00043960
	public bool method_20()
	{
		EAnimationJumpStep eanimationJumpStep = this.method_19();
		return eanimationJumpStep != EAnimationJumpStep.JumpFinish && eanimationJumpStep > EAnimationJumpStep.JumpNull;
	}

	// Token: 0x06000347 RID: 839 RVA: 0x00004FA4 File Offset: 0x000031A4
	public void OnJumpStartFinish()
	{
		if (this.m_jumpStep == EAnimationJumpStep.JumpPre)
		{
			this.vmethod_7(AnimationStateFSM.PlayerJumpIdle);
			this.m_jumpStep = EAnimationJumpStep.JumpLoop;
		}
	}

	// Token: 0x06000348 RID: 840 RVA: 0x00045780 File Offset: 0x00043980
	public void OnJumpLandFinish()
	{
		AnimationPlayerJumpLandState animationPlayerJumpLandState = base.method_16(Utils.smethod_23(AnimationStateFSM.PlayerJumpLand)) as AnimationPlayerJumpLandState;
		if (animationPlayerJumpLandState != null)
		{
			animationPlayerJumpLandState.vmethod_2();
		}
		this.m_jumpStep = EAnimationJumpStep.JumpFinish;
	}

	// Token: 0x06000349 RID: 841 RVA: 0x000457B0 File Offset: 0x000439B0
	public void method_21()
	{
		if (base.method_13(AnimationStateFSM.PlayerJumpStart))
		{
			AnimationPlayerJumpStartState animationPlayerJumpStartState = base.method_16(Utils.smethod_23(AnimationStateFSM.PlayerJumpStart)) as AnimationPlayerJumpStartState;
			if (animationPlayerJumpStartState != null)
			{
				animationPlayerJumpStartState.vmethod_2();
			}
		}
		if (base.method_13(AnimationStateFSM.PlayerJumpIdle))
		{
			AnimationPlayerJumpIdleState animationPlayerJumpIdleState = base.method_16(Utils.smethod_23(AnimationStateFSM.PlayerJumpIdle)) as AnimationPlayerJumpIdleState;
			if (animationPlayerJumpIdleState != null)
			{
				animationPlayerJumpIdleState.vmethod_2();
			}
		}
		if (base.method_13(AnimationStateFSM.PlayerJumpLand))
		{
			AnimationPlayerJumpLandState animationPlayerJumpLandState = base.method_16(Utils.smethod_23(AnimationStateFSM.PlayerJumpLand)) as AnimationPlayerJumpLandState;
			if (animationPlayerJumpLandState != null)
			{
				animationPlayerJumpLandState.vmethod_2();
			}
		}
		this.m_jumpStep = EAnimationJumpStep.JumpFinish;
	}

	// Token: 0x0600034A RID: 842 RVA: 0x00045838 File Offset: 0x00043A38
	public void OnLand()
	{
		EAnimationJumpStep eanimationJumpStep = this.method_19();
		if (eanimationJumpStep == EAnimationJumpStep.JumpPre || eanimationJumpStep == EAnimationJumpStep.JumpLoop)
		{
			this.vmethod_7(AnimationStateFSM.PlayerJumpLand);
			this.m_jumpStep = EAnimationJumpStep.JumpLand;
		}
	}

	// Token: 0x0600034B RID: 843 RVA: 0x00004FBE File Offset: 0x000031BE
	public void method_22(PlayerAnimationManagerFSM.ESecondWindMode esecondWindMode_0)
	{
		if (base.Animator_0 == null)
		{
			return;
		}
		base.Animator_0.SetInteger("iSecondWind", (int)esecondWindMode_0);
	}

	// Token: 0x0600034C RID: 844 RVA: 0x00045864 File Offset: 0x00043A64
	public virtual void vmethod_13()
	{
		string text = "Entities/Player_Mecanim/Siren_1st_Controller_SMG";
		this.m_firstPersonControllerSMG = (RuntimeAnimatorController)Resources.Load(text);
		text = "Entities/Player_Mecanim/Siren_1st_Controller_Shotgun";
		this.m_firstPersonControllerShotgun = (RuntimeAnimatorController)Resources.Load(text);
		text = "Entities/Player_Mecanim/Siren_1st_Controller_Sniper";
		this.m_firstPersonControllerSniper = (RuntimeAnimatorController)Resources.Load(text);
		text = "Entities/Player_Mecanim/Siren_1st_Controller_RepeaterPistol";
		this.m_firstPersonControllerPistol = (RuntimeAnimatorController)Resources.Load(text);
		text = "Entities/Player_Mecanim/Siren_1st_Controller_CombatRifle";
		this.m_firstPersonControllerCombatRifle = (RuntimeAnimatorController)Resources.Load(text);
		text = "Entities/Player_Mecanim/Siren_3rd_Controller_runtime";
		this.m_thirdPersonControllerGame = (RuntimeAnimatorController)Resources.Load(text);
		text = "Entities/Player_Mecanim/Siren_3rd_Controller_Town";
		this.m_thirdPersonControllerTown = (RuntimeAnimatorController)Resources.Load(text);
	}

	// Token: 0x0600034D RID: 845 RVA: 0x00045914 File Offset: 0x00043B14
	public bool method_23()
	{
		EntityWeapon entityWeapon = base.GetComponent<EntityPlayer>().vmethod_16();
		if (entityWeapon != null)
		{
			this.vmethod_15(entityWeapon.method_17().m_type);
			int num = (int)entityWeapon.method_99();
			this.vmethod_14(num);
			return true;
		}
		return false;
	}

	// Token: 0x0600034E RID: 846 RVA: 0x00004FE0 File Offset: 0x000031E0
	public virtual void vmethod_14(int int_0)
	{
		if (base.Animator_0 != null)
		{
			base.Animator_0.SetInteger("iWeaponType", int_0);
			if (!MonoSingleton<Session>.Instance.method_16())
			{
				base.Animator_0.SetFloat("fDefaultPose", (float)int_0);
			}
		}
	}

	// Token: 0x0600034F RID: 847 RVA: 0x00045958 File Offset: 0x00043B58
	protected void method_24()
	{
		for (int i = 0; i < this.m_firstPersonAnimator.layerCount; i++)
		{
			this.m_firstPersonAnimator.SetLayerWeight(i, 1f);
		}
	}

	// Token: 0x06000350 RID: 848 RVA: 0x0000501F File Offset: 0x0000321F
	public void method_25(Animator animator_0)
	{
		this.m_firstPersonAnimator = animator_0;
		this.method_24();
	}

	// Token: 0x06000351 RID: 849 RVA: 0x0004598C File Offset: 0x00043B8C
	public virtual void vmethod_15(WeaponType weaponType_0)
	{
		if (this.m_firstPersonAnimator == null)
		{
			return;
		}
		switch (weaponType_0)
		{
		case WeaponType.SMG:
			this.m_firstPersonAnimator.runtimeAnimatorController = this.m_firstPersonControllerSMG;
			break;
		case WeaponType.SniperRifle:
			this.m_firstPersonAnimator.runtimeAnimatorController = this.m_firstPersonControllerSniper;
			break;
		case WeaponType.ShotGun:
			this.m_firstPersonAnimator.runtimeAnimatorController = this.m_firstPersonControllerShotgun;
			break;
		case WeaponType.RepeaterPistol:
			this.m_firstPersonAnimator.runtimeAnimatorController = this.m_firstPersonControllerPistol;
			break;
		case WeaponType.CombatRifle:
			this.m_firstPersonAnimator.runtimeAnimatorController = this.m_firstPersonControllerCombatRifle;
			break;
		}
		this.method_54();
		this.method_24();
	}

	// Token: 0x06000352 RID: 850 RVA: 0x00045A30 File Offset: 0x00043C30
	protected void method_26()
	{
		string text = "Entities/Player_Mecanim/Siren_3rd_Controller_Inventory";
		PlayerInfoSync playerInfoSync = base.GetComponent<EntityPlayer>().vmethod_25();
		if (playerInfoSync != null)
		{
			AvatarType avatarType = playerInfoSync.m_avatarDna.method_5();
			if (avatarType == AvatarType.BERSERKER)
			{
				text = "Entities/Player_Mecanim/Berserker_3rd_Controller_Inventory";
			}
			else if (avatarType == AvatarType.SOLDIER)
			{
				text = "Entities/Player_Mecanim/Soldier_3rd_Controller_Inventory";
			}
		}
		this.m_inventoryAnimator.runtimeAnimatorController = (RuntimeAnimatorController)Resources.Load(text);
		for (int i = 0; i < this.m_inventoryAnimator.layerCount; i++)
		{
			this.m_inventoryAnimator.SetLayerWeight(i, 1f);
		}
		this.m_inventoryAnimator.applyRootMotion = false;
		this.m_inventoryAnimator.updateMode = AnimatorUpdateMode.Normal;
		this.m_inventoryAnimator.cullingMode = AnimatorCullingMode.BasedOnRenderers;
		this.m_inventoryAnimator.logWarnings = false;
	}

	// Token: 0x06000353 RID: 851 RVA: 0x0000502E File Offset: 0x0000322E
	public void method_27(GameObject gameObject_0)
	{
		this.m_inventoryAnimator = gameObject_0.GetComponent<Animator>();
		this.method_26();
	}

	// Token: 0x06000354 RID: 852 RVA: 0x00045AE8 File Offset: 0x00043CE8
	public GameObject method_28(bool bool_0)
	{
		if (this.m_inventoryAnimator != null)
		{
			this.m_inventoryAnimator.gameObject.SetActive(bool_0);
			if (bool_0)
			{
				PlayerFirstPersonInventoryManager component = this.m_inventoryAnimator.gameObject.GetComponent<PlayerFirstPersonInventoryManager>();
				if (component != null)
				{
					component.OnShowInventoryView();
				}
				foreach (SkinnedMeshRenderer skinnedMeshRenderer in this.m_inventoryAnimator.gameObject.GetComponentsInChildren<SkinnedMeshRenderer>())
				{
					skinnedMeshRenderer.useLightProbes = false;
					skinnedMeshRenderer.castShadows = false;
					skinnedMeshRenderer.receiveShadows = false;
				}
			}
			return this.m_inventoryAnimator.gameObject;
		}
		return null;
	}

	// Token: 0x06000355 RID: 853 RVA: 0x00045B7C File Offset: 0x00043D7C
	public override void vmethod_4(GameObject gameObject_0)
	{
		this.m_animationHost = gameObject_0;
		base.Animator_0 = this.m_animationHost.GetComponent<Animator>();
		base.Animator_0.runtimeAnimatorController = this.m_thirdPersonControllerGame;
		for (int i = 0; i < base.Animator_0.layerCount; i++)
		{
			base.Animator_0.SetLayerWeight(i, 1f);
		}
		this.m_modelScale = this.m_animationHost.transform.localScale.x;
		this.m_VFXManager = this.m_animationHost.GetComponent<VFXManager>();
		this.vmethod_3();
	}

	// Token: 0x06000356 RID: 854 RVA: 0x00045C0C File Offset: 0x00043E0C
	public float method_29()
	{
		if (this.m_entity == null)
		{
			DebugUtils.LogError(LogCategory.Animation, "EntityPlayer can't be null!");
			return 0f;
		}
		EntityWeapon entityWeapon = this.m_entity.vmethod_16();
		if (entityWeapon == null)
		{
			DebugUtils.LogError(LogCategory.Animation, "EntityWeapon can't be null!");
			return 0f;
		}
		switch (entityWeapon.method_71() + 1)
		{
		case EntityWeapon.ReloadType.Standard:
			DebugUtils.LogError(LogCategory.Animation, "Invalid Reload Type");
			return 0f;
		case EntityWeapon.ReloadType.CustomA:
			return 0f;
		case EntityWeapon.ReloadType.CustomB:
			return 1f;
		case EntityWeapon.ReloadType.Max:
			return 2f;
		default:
			return 0f;
		}
	}

	// Token: 0x06000357 RID: 855 RVA: 0x00045CA8 File Offset: 0x00043EA8
	public override void Start()
	{
		DebugUtils.Log(LogCategory.Animation, "PlayerTHirdPersonAnimationManager isPlayerLocal: " + this.m_isPlayerLocal.ToString());
		if (this.m_additiveStateMachine != null)
		{
			base.method_15("LightHurt", this.m_additiveStateMachine);
			this.m_lightHurtState = base.method_16("LightHurt") as AnimationLightHurtState;
		}
		this.m_entity = base.GetComponent<EntityPlayer>();
		this.m_AudioCtl = base.GetComponent<BaseEventTriggerCtl>();
		base.vmethod_3();
		this.m_canUseFacingLogic = true;
		this.m_movementSync = base.GetComponent<MovementSync>();
		this.vmethod_13();
		this.m_isSetDefaultWeaponPending = true;
		this.m_taskManager = base.GetComponent<BHVTaskManager>();
		this.m_fireTiming = new FireTiming(this);
		this.m_AnimatorGraph = new MecanimAnimatorGraph(this);
		this.m_priorityMgr = new StatePriorityManage(this);
		this.m_transitionHistoryMgr = new TransitionHistoryManage(this);
		(base.method_16(Utils.smethod_23(AnimationStateFSM.PlayerFire)) as AnimationPlayerFireState).method_22();
	}

	// Token: 0x06000358 RID: 856 RVA: 0x00045D94 File Offset: 0x00043F94
	public void method_30()
	{
		if (this.m_upperBodyStateMachine == null)
		{
			return;
		}
		if (this.m_upperBodyStateMachine.m_curState == null)
		{
			this.m_upperBodyStateMachine.method_1("Empty");
			return;
		}
		if (((AnimationManagerState)this.m_upperBodyStateMachine.m_curState).m_status == AnimationStatus.SUCCESS && !this.m_upperBodyStateMachine.method_3("Empty"))
		{
			this.m_upperBodyStateMachine.method_1("Empty");
		}
	}

	// Token: 0x06000359 RID: 857 RVA: 0x00045E04 File Offset: 0x00044004
	public void method_31(AnimationStateFSM animationStateFSM_0)
	{
		if (this.m_upperBodyStateMachine == null)
		{
			return;
		}
		string text = Utils.smethod_23(animationStateFSM_0);
		if (this.m_upperBodyStateMachine.States.ContainsKey(text) && !this.m_upperBodyStateMachine.method_3(text))
		{
			base.method_11(text, this.m_upperBodyStateMachine);
		}
	}

	// Token: 0x0600035A RID: 858 RVA: 0x00005042 File Offset: 0x00003242
	public void method_32(bool bool_0)
	{
		this.m_isAngularVelocityActive = bool_0;
	}

	// Token: 0x0600035B RID: 859 RVA: 0x00045E50 File Offset: 0x00044050
	public void method_33(float float_0, float float_1)
	{
		if (!this.m_isAngularVelocityActive)
		{
			return;
		}
		this.m_angularVelocityMaxYaw += float_0 * this.m_taskManager.vmethod_0<BHVFirstPersonSettings>().m_handsAngularSpeedMultiplierYaw;
		this.m_angularVelocityMaxYaw = Mathf.Clamp(this.m_angularVelocityMaxYaw, -1f, 1f);
		this.m_angularVelocityMaxPitch += float_1 * this.m_taskManager.vmethod_0<BHVFirstPersonSettings>().m_handsAngularSpeedMultiplierPitch;
		this.m_angularVelocityMaxPitch = Mathf.Clamp(this.m_angularVelocityMaxPitch, -1f, 1f);
	}

	// Token: 0x0600035C RID: 860 RVA: 0x00045EDC File Offset: 0x000440DC
	protected void method_34()
	{
		if (this.m_firstPersonAnimator == null)
		{
			return;
		}
		this.m_angularVelocityYaw = Mathf.Lerp(this.m_angularVelocityYaw, this.m_angularVelocityMaxYaw, this.m_taskManager.vmethod_0<BHVFirstPersonSettings>().m_handsAngularSpeedEnterSpeedFactorYaw);
		this.m_angularVelocityMaxYaw = Mathf.Lerp(0f, this.m_angularVelocityMaxYaw, this.m_taskManager.vmethod_0<BHVFirstPersonSettings>().m_handsAngularSpeedExitSpeedFactorYaw);
		this.m_angularVelocityPitch = Mathf.Lerp(this.m_angularVelocityPitch, this.m_angularVelocityMaxPitch, this.m_taskManager.vmethod_0<BHVFirstPersonSettings>().m_handsAngularSpeedEnterSpeedFactorPitch);
		this.m_angularVelocityMaxPitch = Mathf.Lerp(0f, this.m_angularVelocityMaxPitch, this.m_taskManager.vmethod_0<BHVFirstPersonSettings>().m_handsAngularSpeedExitSpeedFactorPitch);
		this.m_firstPersonAnimator.SetFloat("AngularVelocityYaw", this.m_angularVelocityYaw);
		this.m_firstPersonAnimator.SetFloat("AngularVelocityPitch", this.m_angularVelocityPitch);
	}

	// Token: 0x0600035D RID: 861 RVA: 0x00045FC0 File Offset: 0x000441C0
	public override void Update()
	{
		if (base.Animator_0 == null)
		{
			base.vmethod_3();
			base.Boolean_1 = true;
		}
		else
		{
			base.Animator_0.feetPivotActive = 0f;
		}
		if (this.m_movementSync == null)
		{
			this.m_movementSync = base.GetComponent<MovementSync>();
		}
		if (this.m_isSetDefaultWeaponPending)
		{
			this.m_isSetDefaultWeaponPending = !this.method_23();
		}
		base.Update();
		this.method_34();
		if (!MonoSingleton<Session>.Instance.method_16())
		{
			this.method_35();
		}
		this.method_30();
		this.m_AnimatorGraph.Update();
		this.method_43();
		if (!this.m_isPlayerLocal)
		{
			this.vmethod_16();
			if (this.m_beginDeathFading && base.Transform_0 != null)
			{
				this.m_currentTime += Time.deltaTime;
				SkinnedMeshRenderer component = base.Transform_0.GetComponent<SkinnedMeshRenderer>();
				if (component != null)
				{
					for (int i = 0; i < component.materials.Length; i++)
					{
						component.materials[i].SetFloat("_CurrentTime", this.m_currentTime);
					}
				}
			}
		}
	}

	// Token: 0x0600035E RID: 862 RVA: 0x000460D8 File Offset: 0x000442D8
	public void method_35()
	{
		if (this.m_fireTiming == null)
		{
			return;
		}
		this.m_fireTiming.Update();
		if (!this.m_isPlayerLocal || !(this.m_firstPersonAnimator != null))
		{
			if (this.m_animationEventController != null && base.Animator_0 != null)
			{
				bool flag = (this.vmethod_23() || this.vmethod_24()) && base.Animator_0.GetFloat("fSpeed") < 0.5f;
				EntityPlayer entityPlayer = this.m_entity as EntityPlayer;
				if (entityPlayer != null && (entityPlayer.method_65() || entityPlayer.method_67() || entityPlayer.method_68()))
				{
					flag = false;
				}
				if (this.m_lightHurtState != null)
				{
					flag = flag && this.m_lightHurtState.m_status != AnimationStatus.RUNNING;
				}
				if (flag)
				{
					this.m_animationEventController.m_enableAimIK = true;
					if (this.m_entity != null)
					{
						EntityWeapon entityWeapon = this.m_entity.vmethod_16();
						if (entityWeapon != null)
						{
							this.m_animationEventController.m_currentWeaponType = entityWeapon.method_99();
							this.m_animationEventController.m_enableLeftHandIK = true;
							return;
						}
					}
				}
				else
				{
					this.m_animationEventController.m_enableAimIK = false;
					this.m_animationEventController.m_enableLeftHandIK = false;
				}
			}
			return;
		}
		if (this.m_firstPersonAnimator.GetCurrentAnimatorStateInfo(1).IsTag("Idle"))
		{
			this.m_firstPersonAnimator.SetLayerWeight(1, 0f);
			return;
		}
		this.m_firstPersonAnimator.SetLayerWeight(1, 1f);
	}

	// Token: 0x0600035F RID: 863 RVA: 0x00046258 File Offset: 0x00044458
	public override void OnAttack()
	{
		if (this.m_blockShootingThisFrame)
		{
			return;
		}
		if (this.m_entity == null)
		{
			this.m_entity = base.GetComponent<EntityPlayer>();
		}
		if (this.m_entity == null)
		{
			return;
		}
		EntityWeapon entityWeapon = this.m_entity.vmethod_16();
		if (entityWeapon != null)
		{
			float num = entityWeapon.method_92();
			this.method_51(num);
			if (this.m_isPlayerLocal)
			{
				if (!base.method_13(AnimationStateFSM.PlayerAim))
				{
					this.method_31(AnimationStateFSM.PlayerFire);
					return;
				}
			}
			else
			{
				this.method_31(AnimationStateFSM.PlayerFire);
				entityWeapon.method_79();
				this.method_36(entityWeapon);
			}
		}
	}

	// Token: 0x06000360 RID: 864 RVA: 0x0000504B File Offset: 0x0000324B
	private void method_36(EntityWeapon entityWeapon_0)
	{
		if (entityWeapon_0.method_99() == WeaponType.SniperRifle)
		{
			this.m_AudioCtl.vmethod_1(AudioEventName.Wep_Sniper_1stShoot_Rnd);
			return;
		}
		if (entityWeapon_0.method_99() == WeaponType.ShotGun)
		{
			this.m_AudioCtl.vmethod_1(AudioEventName.Wep_Shotgun_1stShoot_Rnd);
		}
	}

	// Token: 0x06000361 RID: 865 RVA: 0x000462EC File Offset: 0x000444EC
	public void method_37(float float_0)
	{
		if (float_0 >= 0f && float_0 <= 1000f)
		{
			if (this.m_firstPersonAnimator != null)
			{
				this.m_firstPersonAnimator.speed = float_0;
			}
			if (base.Animator_0 != null)
			{
				base.Animator_0.speed = float_0;
			}
			return;
		}
		DebugUtils.LogError(LogCategory.Gamelogic, "invalid playback speed");
	}

	// Token: 0x06000362 RID: 866 RVA: 0x0004634C File Offset: 0x0004454C
	public override void OnThrow(float networkLatency, AnimationPlayerThrowGrenadeState.SpawnGrenadeDelegate spawnGrenadeDelegate)
	{
		AnimationPlayerThrowGrenadeState animationPlayerThrowGrenadeState = base.method_16(Utils.smethod_23(AnimationStateFSM.PlayerThrowGrenade)) as AnimationPlayerThrowGrenadeState;
		if (animationPlayerThrowGrenadeState != null)
		{
			animationPlayerThrowGrenadeState.NetworkLatency = networkLatency;
			animationPlayerThrowGrenadeState.m_spawnGrenadeDelegate = spawnGrenadeDelegate;
		}
		this.method_31(AnimationStateFSM.PlayerThrowGrenade);
	}

	// Token: 0x06000363 RID: 867 RVA: 0x0000507A File Offset: 0x0000327A
	public void OnThrowGrenade()
	{
		this.method_31(AnimationStateFSM.PlayerThrowGrenade);
	}

	// Token: 0x06000364 RID: 868 RVA: 0x00005084 File Offset: 0x00003284
	public void OnFireBird(float _netLatency)
	{
		(base.method_16(Utils.smethod_23(AnimationStateFSM.PlayerFireBird)) as AnimationPlayerFireBirdState).m_netLantency = _netLatency;
		this.method_31(AnimationStateFSM.PlayerFireBird);
	}

	// Token: 0x06000365 RID: 869 RVA: 0x000050A6 File Offset: 0x000032A6
	public void OnCallback(float _netLatency)
	{
		(base.method_16(Utils.smethod_23(AnimationStateFSM.PlayerCallback)) as AnimationPlayerCallbackState).m_netLantency = _netLatency;
		this.method_31(AnimationStateFSM.PlayerCallback);
	}

	// Token: 0x06000366 RID: 870 RVA: 0x000050C8 File Offset: 0x000032C8
	public void OnBerserkCharge(float _netLatency)
	{
		(base.method_16(Utils.smethod_23(AnimationStateFSM.PlayerBerserkCharge)) as AnimationPlayerBerserkChargeState).m_netLantency = _netLatency;
		this.method_31(AnimationStateFSM.PlayerBerserkCharge);
	}

	// Token: 0x06000367 RID: 871 RVA: 0x000050EA File Offset: 0x000032EA
	public void OnBerserkDash(float _netLatency)
	{
		(base.method_16(Utils.smethod_23(AnimationStateFSM.PlayerBerserkDash)) as AnimationPlayerBerserkDashState).m_netLantency = _netLatency;
		this.method_31(AnimationStateFSM.PlayerBerserkDash);
	}

	// Token: 0x06000368 RID: 872 RVA: 0x0000510C File Offset: 0x0000330C
	public void OnBerserkPunch(float _netLatency)
	{
		(base.method_16(Utils.smethod_23(AnimationStateFSM.PlayerBerserkPunch)) as AnimationPlayerBerserkPunchState).m_netLantency = _netLatency;
		this.method_31(AnimationStateFSM.PlayerBerserkPunch);
	}

	// Token: 0x06000369 RID: 873 RVA: 0x0000512E File Offset: 0x0000332E
	public override void OnReload(float _netLatency)
	{
		this.m_blockShootingThisFrame = true;
		(base.method_16(Utils.smethod_23(AnimationStateFSM.PlayerReload)) as AnimationPlayerReloadState).m_netLantency = _netLatency;
		this.method_31(AnimationStateFSM.PlayerReload);
	}

	// Token: 0x0600036A RID: 874 RVA: 0x00046388 File Offset: 0x00044588
	public override void OnSwitchWeapon(EntityWeapon weapon)
	{
		if (weapon == null)
		{
			return;
		}
		int num = (int)weapon.method_99();
		this.vmethod_14(num);
		AnimationPlayerSwitchDownState animationPlayerSwitchDownState = base.method_16(Utils.smethod_23(AnimationStateFSM.PlayerSwitchDown)) as AnimationPlayerSwitchDownState;
		if (animationPlayerSwitchDownState != null)
		{
			animationPlayerSwitchDownState.method_22(weapon, this.m_entity as EntityPlayer);
		}
		this.method_31(AnimationStateFSM.PlayerSwitchDown);
	}

	// Token: 0x0600036B RID: 875 RVA: 0x000463E0 File Offset: 0x000445E0
	public void OnSwitchDownFinished(EntityWeapon nextWeapon)
	{
		if (nextWeapon == null)
		{
			return;
		}
		EntityPlayer entityPlayer = this.m_entity as EntityPlayer;
		if (entityPlayer == null)
		{
			return;
		}
		int num = (int)nextWeapon.method_99();
		this.vmethod_14(num);
		AnimationPlayerSwitchUpState animationPlayerSwitchUpState = base.method_16(Utils.smethod_23(AnimationStateFSM.PlayerSwitchUp)) as AnimationPlayerSwitchUpState;
		if (animationPlayerSwitchUpState != null)
		{
			animationPlayerSwitchUpState.method_22(nextWeapon, entityPlayer);
		}
		this.method_31(AnimationStateFSM.PlayerSwitchUp);
		this.method_38(nextWeapon);
	}

	// Token: 0x0600036C RID: 876 RVA: 0x00046448 File Offset: 0x00044648
	private void method_38(EntityWeapon entityWeapon_0)
	{
		if (!(entityWeapon_0 == null) && !(entityWeapon_0.m_owner == null))
		{
			PlayerInfoSync playerInfoSync = entityWeapon_0.m_owner.vmethod_25();
			if (playerInfoSync != null && playerInfoSync.IsMyActor() && MonoSingleton<AppManager>.Instance.method_0() != null && entityWeapon_0.method_17() != null && entityWeapon_0.method_17().m_name != null)
			{
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDPlayerInfoView>().vmethod_16(null, entityWeapon_0.method_17());
			}
			return;
		}
	}

	// Token: 0x0600036D RID: 877 RVA: 0x000464CC File Offset: 0x000446CC
	public override void OnPickUpWeapon(EntityWeapon weapon)
	{
		int num = (int)weapon.method_99();
		this.vmethod_14(num);
		AnimationPlayerPickupWeaponState animationPlayerPickupWeaponState = base.method_16(Utils.smethod_23(AnimationStateFSM.PlayerPickupWeapon)) as AnimationPlayerPickupWeaponState;
		if (animationPlayerPickupWeaponState != null)
		{
			animationPlayerPickupWeaponState.method_22(weapon, this.m_entity as EntityPlayer);
		}
		this.method_31(AnimationStateFSM.PlayerPickupWeapon);
		this.method_38(weapon);
	}

	// Token: 0x0600036E RID: 878 RVA: 0x00005157 File Offset: 0x00003357
	public override void OnMelee()
	{
		this.m_blockShootingThisFrame = true;
		this.vmethod_7(AnimationStateFSM.PlayerMelee);
	}

	// Token: 0x0600036F RID: 879 RVA: 0x00005168 File Offset: 0x00003368
	public void OnMeleeSkill()
	{
		this.m_blockShootingThisFrame = true;
		this.vmethod_7(AnimationStateFSM.PlayerMeleeSkill);
	}

	// Token: 0x06000370 RID: 880 RVA: 0x00046520 File Offset: 0x00044720
	public override void OnDamaged(DamageInfo damageInfo)
	{
		if (!this.m_isPlayerLocal && Time.time - this.m_previousLightHurtTime > 0.2f && this.m_lightHurtState != null)
		{
			this.m_lightHurtState.m_damageType = EDamageType.DT_Light;
			if (this.m_lightHurtState.m_status == AnimationStatus.RUNNING)
			{
				this.m_lightHurtState.method_4();
			}
			else
			{
				this.vmethod_7(AnimationStateFSM.LightHurt);
			}
			this.m_previousLightHurtTime = Time.time;
		}
	}

	// Token: 0x06000371 RID: 881 RVA: 0x00005179 File Offset: 0x00003379
	public override int vmethod_8(string string_0)
	{
		if (string_0.ToLower() == "hurtlight")
		{
			return 3;
		}
		return 0;
	}

	// Token: 0x06000372 RID: 882 RVA: 0x0004658C File Offset: 0x0004478C
	public float method_39()
	{
		float num = (float)((ushort)this.m_shootPitch) / 100f;
		if (base.Animator_0 != null && base.Animator_0.GetBool("bIsCrouch"))
		{
			if (num >= 320f)
			{
				num -= 320f;
			}
			else
			{
				num += 40f;
			}
		}
		return num;
	}

	// Token: 0x06000373 RID: 883 RVA: 0x000465E4 File Offset: 0x000447E4
	public void method_40(byte byte_0, short short_0)
	{
		if (!(base.Animator_0 == null) && !base.method_13(AnimationStateFSM.PlayerDie))
		{
			if (this.m_movementSync == null)
			{
				this.m_movementSync = base.GetComponent<MovementSync>();
			}
			this.m_shootPitch = short_0;
			this.m_inputFrameFlag = byte_0;
			return;
		}
	}

	// Token: 0x06000374 RID: 884 RVA: 0x00046634 File Offset: 0x00044834
	protected virtual void vmethod_16()
	{
		if (base.Animator_0 == null || base.method_13(AnimationStateFSM.PlayerDie))
		{
			return;
		}
		if (this.m_movementSync == null)
		{
			this.m_movementSync = base.GetComponent<MovementSync>();
		}
		this.method_41(this.m_inputFrameFlag);
		if (this.vmethod_17(this.m_inputFrameFlag))
		{
			return;
		}
		if (this.method_42(this.m_inputFrameFlag))
		{
			return;
		}
		this.vmethod_18(this.m_inputFrameFlag);
	}

	// Token: 0x06000375 RID: 885 RVA: 0x00005190 File Offset: 0x00003390
	private bool method_41(byte byte_0)
	{
		bool flag = (byte_0 & 128) > 0;
		if (flag)
		{
			this.method_31(AnimationStateFSM.PlayerAim);
			return flag;
		}
		if (base.method_13(AnimationStateFSM.PlayerAim))
		{
			base.method_16("PlayerAim").vmethod_2();
		}
		return flag;
	}

	// Token: 0x06000376 RID: 886 RVA: 0x000051C2 File Offset: 0x000033C2
	protected virtual bool vmethod_17(byte byte_0)
	{
		if ((byte_0 & 2) != 0)
		{
			if (!this.method_20())
			{
				this.vmethod_7(AnimationStateFSM.PlayerJumpStart);
				this.m_jumpStep = EAnimationJumpStep.JumpPre;
			}
			return true;
		}
		if (this.method_20())
		{
			// Network says the jump bit is clear, but the jump FSM is still mid-flight (JumpPre/JumpLoop).
			// Normally OnLand() (driven by BadAssCharacterMotorLite's local ground-physics check) closes this
			// out, but that never fires for a remotely-rendered avatar (its position comes from MovementSync,
			// not local physics), leaving it stuck floating in JumpLoop forever. Force it closed here instead.
			this.method_21();
			return false;
		}
		this.m_jumpStep = EAnimationJumpStep.JumpNull;
		return false;
	}

	// Token: 0x06000377 RID: 887 RVA: 0x000466AC File Offset: 0x000448AC
	private bool method_42(byte byte_0)
	{
		if ((byte_0 & 64) != 0)
		{
			float num = 0f;
			float num2 = 0f;
			this.vmethod_19(ref num, ref num2);
			if ((byte_0 & 4) == 0 && num <= 0.1f)
			{
				if (!base.method_13(AnimationStateFSM.PlayerCrouchIdle))
				{
					this.vmethod_7(AnimationStateFSM.PlayerCrouchIdle);
				}
			}
			else
			{
				(base.method_16(Utils.smethod_23(AnimationStateFSM.PlayerCrouchMove)) as AnimationPlayerCrouchMoveState).method_22(0.2f, num2);
				if (!base.method_13(AnimationStateFSM.PlayerCrouchMove))
				{
					this.vmethod_7(AnimationStateFSM.PlayerCrouchMove);
				}
			}
			return true;
		}
		return false;
	}

	// Token: 0x06000378 RID: 888 RVA: 0x00046728 File Offset: 0x00044928
	protected void method_43()
	{
		if (Time.deltaTime != 0f)
		{
			this.m_localVelocity = (base.transform.position - this.m_previousPosition) / Time.deltaTime;
			this.m_localVelocity.y = 0f;
			this.m_previousVelocity.Add(this.m_localVelocity.magnitude);
			this.m_previousPosition = base.transform.position;
			this.m_positionHistory.Add(new Pair<Vector3, float>(base.transform.position, Time.time));
		}
	}

	// Token: 0x06000379 RID: 889 RVA: 0x000467C0 File Offset: 0x000449C0
	protected virtual bool vmethod_18(byte byte_0)
	{
		float num = 0f;
		float num2 = 0f;
		float num3 = 0.0002f;
		this.vmethod_19(ref num, ref num2);
		bool flag = (byte_0 & 1) > 0;
		float num4 = num;
		if (this.m_movementSync != null)
		{
			Vector3 vector = this.m_movementSync.method_1();
			vector.y = 0f;
			num4 = vector.magnitude;
		}
		if (num2 > 150f)
		{
		}
		if (num <= num3 && num4 <= num3)
		{
			if (!base.method_13(AnimationStateFSM.PlayerIdle))
			{
				this.method_44();
			}
		}
		else if (num > num3 && num4 > num3)
		{
			AnimationPlayerMoveState animationPlayerMoveState = base.method_16(Utils.smethod_23(AnimationStateFSM.PlayerMove)) as AnimationPlayerMoveState;
			float num5 = this.vmethod_20(flag, num);
			if (base.method_13(AnimationStateFSM.PlayerMove))
			{
				this.method_45(num5, num2);
			}
			else
			{
				this.vmethod_7(AnimationStateFSM.PlayerMove);
				animationPlayerMoveState.method_22(num5, num2);
			}
		}
		else if (num > num3 && num4 <= num3)
		{
			if (!base.method_13(AnimationStateFSM.PlayerIdle))
			{
				this.method_44();
			}
		}
		else
		{
			AnimationPlayerMoveState animationPlayerMoveState2 = base.method_16(Utils.smethod_23(AnimationStateFSM.PlayerMove)) as AnimationPlayerMoveState;
			float num6 = this.vmethod_20(flag, (num + num4) * 0.5f);
			if (base.method_13(AnimationStateFSM.PlayerMove))
			{
				this.method_45(num6, num2);
			}
			else
			{
				this.vmethod_7(AnimationStateFSM.PlayerMove);
				animationPlayerMoveState2.method_22(num6, num2);
			}
		}
		return true;
	}

	// Token: 0x0600037A RID: 890 RVA: 0x00046910 File Offset: 0x00044B10
	protected void method_44()
	{
		if (base.method_13(AnimationStateFSM.PlayerIdle))
		{
			return;
		}
		if (!base.method_13(AnimationStateFSM.PlayerMove))
		{
			this.vmethod_7(AnimationStateFSM.PlayerIdle);
			return;
		}
		float num = Mathf.Abs(base.Animator_0.GetFloat("fSpeed"));
		if (num < 0.1f)
		{
			this.vmethod_7(AnimationStateFSM.PlayerIdle);
			return;
		}
		float num2 = Mathf.Lerp(num, 0f, 0.5f);
		float @float = base.Animator_0.GetFloat("fDirection");
		(base.method_16(Utils.smethod_23(AnimationStateFSM.PlayerMove)) as AnimationPlayerMoveState).method_22(num2, @float);
	}

	// Token: 0x0600037B RID: 891 RVA: 0x000469A0 File Offset: 0x00044BA0
	protected void method_45(float float_0, float float_1 = 0f)
	{
		if (!base.method_13(AnimationStateFSM.PlayerMove))
		{
			this.vmethod_7(AnimationStateFSM.PlayerMove);
		}
		float num = Mathf.Abs(base.Animator_0.GetFloat("fSpeed"));
		float num2 = float_0;
		if (Mathf.Abs(float_0 - num) > 0.05f)
		{
			num2 = Mathf.Lerp(num, float_0, 0.3f);
		}
		(base.method_16(Utils.smethod_23(AnimationStateFSM.PlayerMove)) as AnimationPlayerMoveState).method_22(num2, float_1);
	}

	// Token: 0x0600037C RID: 892 RVA: 0x00046A0C File Offset: 0x00044C0C
	private float method_46(CircularBuffer<float> gclass2_0)
	{
		if (gclass2_0.Count <= 0)
		{
			return 0f;
		}
		float num = 0f;
		for (int i = 0; i < gclass2_0.Count; i++)
		{
			num += gclass2_0[i];
		}
		float num2 = num / (float)gclass2_0.Count;
		float num3 = 0f;
		for (int j = 0; j < gclass2_0.Count; j++)
		{
			num3 += (gclass2_0[j] - num2) * (gclass2_0[j] - num2);
		}
		return (float)Math.Sqrt((double)(num3 / (float)(gclass2_0.Count - 1)));
	}

	// Token: 0x0600037D RID: 893 RVA: 0x00046A98 File Offset: 0x00044C98
	protected virtual void vmethod_19(ref float float_0, ref float float_1)
	{
		Vector3 vector = this.m_movementSync.Velocity;
		if (this.m_positionHistory != null && this.m_positionHistory.Count > 1)
		{
			Pair<Vector3, float> pair = this.m_positionHistory[this.m_positionHistory.Count - 1];
			int i = 0;
			while (i < this.m_positionHistory.Count - 1)
			{
				if (pair.Right - this.m_positionHistory[i].Right <= 0.1f || pair.Right - this.m_positionHistory[i + 1].Right > 0.1f)
				{
					i++;
				}
				else
				{
					float num = pair.Right - this.m_positionHistory[i].Right;
					if (num > 1E-45f)
					{
						vector = (pair.Left - this.m_positionHistory[i].Left) / num;
						this.m_localVelocity = vector;
						break;
					}
					break;
				}
			}
		}
		vector.y = 0f;
		float_0 = vector.magnitude;
		Vector3 forward = base.transform.forward;
		forward.y = 0f;
		float_1 = BHVTaskUtils.smethod_8(forward.normalized, vector.normalized);
	}

	// Token: 0x0600037E RID: 894 RVA: 0x000051F4 File Offset: 0x000033F4
	protected virtual float vmethod_20(bool bool_0, float float_0)
	{
		if (bool_0)
		{
			return 0.6f;
		}
		if (float_0 > 2.8f)
		{
			return 0.4f;
		}
		return 0.2f;
	}

	// Token: 0x0600037F RID: 895 RVA: 0x00046BD8 File Offset: 0x00044DD8
	public virtual void vmethod_21(BHVMovementSpeed bhvmovementSpeed_0, Vector3 vector3_0, bool bool_0, bool bool_1, bool bool_2)
	{
		if (base.method_13(AnimationStateFSM.PlayerDie) && base.method_0(AnimationStateFSM.PlayerDie) == AnimationStatus.RUNNING)
		{
			return;
		}
		float num;
		switch (bhvmovementSpeed_0)
		{
		case BHVMovementSpeed.WALK:
			num = 0.2f;
			goto IL_004C;
		case BHVMovementSpeed.RUN:
			num = 0.4f;
			goto IL_004C;
		case BHVMovementSpeed.SPRINT:
			num = 0.6f;
			goto IL_004C;
		}
		num = 0f;
		IL_004C:
		EntityWeapon entityWeapon = this.m_entity.vmethod_16();
		if (entityWeapon)
		{
			entityWeapon.method_22(bool_2);
		}
		if (bool_2 && !base.method_13(AnimationStateFSM.PlayerBerserkDash))
		{
			this.method_31(AnimationStateFSM.PlayerAim);
		}
		else if (base.method_13(AnimationStateFSM.PlayerAim))
		{
			base.method_16("PlayerAim").vmethod_2();
		}
		if (!bool_0)
		{
			if (bool_1)
			{
				if (!this.method_20())
				{
					this.vmethod_7(AnimationStateFSM.PlayerJumpStart);
					this.m_jumpStep = EAnimationJumpStep.JumpPre;
					return;
				}
			}
			else if (!this.method_20())
			{
				if (this.m_AnimatorGraph.method_3(MecanimAnimationID.ID_1st_JumpLand))
				{
					this.m_AnimatorGraph.method_4(MecanimAnimationID.ID_1st_JumpLand);
				}
				if (num > 0.1f)
				{
					AnimationPlayerMoveState animationPlayerMoveState = base.method_16(Utils.smethod_23(AnimationStateFSM.PlayerMove)) as AnimationPlayerMoveState;
					float num2 = BHVTaskUtils.smethod_8(Vector3.forward, vector3_0);
					animationPlayerMoveState.method_22(num, num2);
					if (!base.method_13(AnimationStateFSM.PlayerMove))
					{
						this.vmethod_7(AnimationStateFSM.PlayerMove);
						return;
					}
				}
				else if (!base.method_13(AnimationStateFSM.PlayerIdle) || !this.m_AnimatorGraph.method_3(MecanimAnimationID.ID_1st_StandIdle))
				{
					this.vmethod_7(AnimationStateFSM.PlayerIdle);
				}
			}
			return;
		}
		if (num > 0.1f)
		{
			AnimationPlayerCrouchMoveState animationPlayerCrouchMoveState = base.method_16(Utils.smethod_23(AnimationStateFSM.PlayerCrouchMove)) as AnimationPlayerCrouchMoveState;
			float num3 = BHVTaskUtils.smethod_8(Vector3.forward, vector3_0);
			num = 0.2f;
			animationPlayerCrouchMoveState.method_22(num, num3);
			this.vmethod_7(AnimationStateFSM.PlayerCrouchMove);
			return;
		}
		this.vmethod_7(AnimationStateFSM.PlayerCrouchIdle);
	}

	// Token: 0x06000380 RID: 896 RVA: 0x00046D68 File Offset: 0x00044F68
	public virtual bool vmethod_22()
	{
		EAnimationJumpStep eanimationJumpStep = this.method_19();
		return eanimationJumpStep != EAnimationJumpStep.JumpLand && eanimationJumpStep != EAnimationJumpStep.JumpPre && eanimationJumpStep != EAnimationJumpStep.JumpLoop;
	}

	// Token: 0x06000381 RID: 897 RVA: 0x00046D8C File Offset: 0x00044F8C
	public bool method_47()
	{
		EAnimationJumpStep eanimationJumpStep = this.method_19();
		return eanimationJumpStep == EAnimationJumpStep.JumpFinish || eanimationJumpStep == EAnimationJumpStep.JumpNull;
	}

	// Token: 0x06000382 RID: 898 RVA: 0x00005212 File Offset: 0x00003412
	public virtual bool vmethod_23()
	{
		return this.method_50("PlayerAim");
	}

	// Token: 0x06000383 RID: 899 RVA: 0x0000521F File Offset: 0x0000341F
	public virtual bool vmethod_24()
	{
		return !this.m_blockShootingThisFrame && this.method_50("PlayerFire");
	}

	// Token: 0x06000384 RID: 900 RVA: 0x00005236 File Offset: 0x00003436
	public void LateUpdate()
	{
		this.m_blockShootingThisFrame = false;
	}

	// Token: 0x06000385 RID: 901 RVA: 0x00046DAC File Offset: 0x00044FAC
	public bool method_48()
	{
		if (this.m_isPlayerLocal && this.m_firstPersonAnimator != null)
		{
			foreach (AnimationInfo animationInfo in this.m_firstPersonAnimator.GetCurrentAnimationClipState(0))
			{
				if (animationInfo.clip.name == "Sprint" && animationInfo.weight > 0.1f)
				{
					return false;
				}
			}
		}
		return true;
	}

	// Token: 0x06000386 RID: 902 RVA: 0x0000523F File Offset: 0x0000343F
	public virtual bool vmethod_25()
	{
		return this.method_50("PlayerReload");
	}

	// Token: 0x06000387 RID: 903 RVA: 0x0000524C File Offset: 0x0000344C
	public virtual bool vmethod_26()
	{
		return this.method_50("PlayerMelee");
	}

	// Token: 0x06000388 RID: 904 RVA: 0x00046E1C File Offset: 0x0004501C
	public bool method_49()
	{
		bool flag = this.method_50("PlayerSwitchDown");
		bool flag2 = !base.method_13(AnimationStateFSM.PlayerSwitchDown) || base.method_16("PlayerSwitchDown").m_status != AnimationStatus.RUNNING;
		bool flag3 = !base.method_13(AnimationStateFSM.PlayerSwitchUp) || base.method_16("PlayerSwitchUp").m_status != AnimationStatus.RUNNING;
		DebugUtils.Log(LogCategory.Default, string.Format("WPNSW_1 canSwitch={0} downOK={1} upOK={2}", flag, flag2, flag3));
		return flag && flag2 && flag3;
	}

	// Token: 0x06000389 RID: 905 RVA: 0x00005259 File Offset: 0x00003459
	public virtual bool vmethod_27()
	{
		return this.method_50("PlayerThrowGrenade");
	}

	// Token: 0x0600038A RID: 906 RVA: 0x00005266 File Offset: 0x00003466
	public virtual bool vmethod_28()
	{
		return (this.m_entity as EntityPlayer).PlayerSkillManage_0.vmethod_3();
	}

	// Token: 0x0600038B RID: 907 RVA: 0x0000527D File Offset: 0x0000347D
	public bool method_50(string string_0)
	{
		return this.m_priorityMgr.method_0(string_0);
	}

	// Token: 0x0600038C RID: 908 RVA: 0x0000528B File Offset: 0x0000348B
	public void method_51(float float_0)
	{
		this.m_fireTiming.OnTriggerFire(float_0);
	}

	// Token: 0x0600038D RID: 909 RVA: 0x00005299 File Offset: 0x00003499
	public override void vmethod_6(bool bool_0)
	{
		this.m_isSetDefaultWeaponPending = true;
		if (base.Animator_0 != null)
		{
			base.Animator_0.applyRootMotion = bool_0;
		}
		if (this.m_firstPersonAnimator != null)
		{
			this.m_firstPersonAnimator.applyRootMotion = false;
		}
	}

	// Token: 0x0600038E RID: 910 RVA: 0x00046EA4 File Offset: 0x000450A4
	public void method_52(bool bool_0)
	{
		switch (this.m_entity.vmethod_16().method_99())
		{
		case WeaponType.SMG:
			if (bool_0)
			{
				this.m_AudioCtl.vmethod_1(AudioEventName.Wep_SMG_1stShoot_LS_Rnd);
				return;
			}
			this.m_AudioCtl.vmethod_1(AudioEventName.Wep_SMG_1stShoot_LL_Rnd);
			return;
		case WeaponType.SniperRifle:
			this.m_AudioCtl.vmethod_1(AudioEventName.Wep_Sniper_1stShoot_Rnd);
			return;
		case WeaponType.ShotGun:
			this.m_AudioCtl.vmethod_1(AudioEventName.Wep_Shotgun_1stShoot_Rnd);
			return;
		case WeaponType.RepeaterPistol:
			this.m_AudioCtl.vmethod_1(AudioEventName.Wep_Repeater_1stShoot_High_Rnd);
			return;
		case WeaponType.CombatRifle:
			if (bool_0)
			{
				this.m_AudioCtl.vmethod_1(AudioEventName.Wep_CombatRifle_Low_Short_Rnd);
				return;
			}
			this.m_AudioCtl.vmethod_1(AudioEventName.Wep_CombatRifle_Low_Rnd);
			return;
		default:
			return;
		}
	}

	// Token: 0x0600038F RID: 911 RVA: 0x00046F44 File Offset: 0x00045144
	public void method_53()
	{
		WeaponType weaponType = this.m_entity.vmethod_16().method_99();
		if (weaponType != WeaponType.SMG)
		{
			if (weaponType == WeaponType.CombatRifle)
			{
				this.m_AudioCtl.vmethod_1(AudioEventName.Wep_CombatRifle_Low_Tail_Rnd);
				return;
			}
		}
		else
		{
			this.m_AudioCtl.vmethod_1(AudioEventName.Wep_SMG_Tail_L_Rnd);
		}
	}

	// Token: 0x06000390 RID: 912 RVA: 0x000052D6 File Offset: 0x000034D6
	protected void method_54()
	{
		if (this.m_firstPersonAnimator.GetComponent<MecanimEventEmitter>())
		{
			this.m_firstPersonAnimator.GetComponent<MecanimEventEmitter>().animatorController = this.m_firstPersonAnimator.runtimeAnimatorController;
		}
	}

	// Token: 0x06000391 RID: 913 RVA: 0x00046F84 File Offset: 0x00045184
	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder("AnimationManagerFSM State:\n");
		foreach (KeyValuePair<string, AnimationStateBase> keyValuePair in this.m_animationStateMachine.States)
		{
			AnimationManagerState animationManagerState = (AnimationManagerState)keyValuePair.Value;
			AnimationStatus status = animationManagerState.m_status;
			if (status == AnimationStatus.FAILED || status == AnimationStatus.PREPARE || status == AnimationStatus.RUNNING)
			{
				stringBuilder.Append("\t").Append(animationManagerState.StateName).Append("\t : ")
					.Append(status.ToString())
					.Append("\n");
			}
		}
		if (this.m_upperBodyStateMachine != null)
		{
			stringBuilder.Append("Upper body state:\n");
			foreach (KeyValuePair<string, AnimationStateBase> keyValuePair2 in this.m_upperBodyStateMachine.States)
			{
				AnimationManagerState animationManagerState2 = (AnimationManagerState)keyValuePair2.Value;
				AnimationStatus status2 = animationManagerState2.m_status;
				if (status2 == AnimationStatus.FAILED || status2 == AnimationStatus.PREPARE || status2 == AnimationStatus.RUNNING)
				{
					stringBuilder.Append("\t").Append(animationManagerState2.StateName).Append("\t : ")
						.Append(status2.ToString())
						.Append("\n");
				}
			}
		}
		if (base.Animator_0 != null)
		{
			stringBuilder.Append("Third Person Animator:\n");
			for (int i = 0; i < base.Animator_0.layerCount; i++)
			{
				if (base.Animator_0.IsInTransition(i))
				{
					stringBuilder.Append("Transition:").Append(base.Animator_0.GetAnimatorTransitionInfo(i).normalizedTime).Append("\n");
					foreach (AnimationInfo animationInfo in base.Animator_0.GetNextAnimationClipState(i))
					{
						stringBuilder.Append("\t").Append(animationInfo.clip.name).Append("\t weight:")
							.Append(animationInfo.weight.ToString("F2"))
							.Append("\n");
					}
				}
				else
				{
					foreach (AnimationInfo animationInfo2 in base.Animator_0.GetCurrentAnimationClipState(i))
					{
						stringBuilder.Append("\t").Append(animationInfo2.clip.name).Append("\t weight:")
							.Append(animationInfo2.weight.ToString("F2"))
							.Append("\n");
					}
					AnimatorStateInfo currentAnimatorStateInfo = base.Animator_0.GetCurrentAnimatorStateInfo(i);
					if (currentAnimatorStateInfo.length > 1E-45f)
					{
						stringBuilder.Append("---Length:").Append(currentAnimatorStateInfo.length.ToString("F2")).Append("\t normalizedTime:")
							.Append(currentAnimatorStateInfo.normalizedTime.ToString("F2"))
							.Append("\n");
					}
				}
			}
		}
		if (this.m_firstPersonAnimator != null)
		{
			stringBuilder.Append("First Person Animator:\n");
			for (int k = 0; k < 2; k++)
			{
				if (this.m_firstPersonAnimator.IsInTransition(k))
				{
					stringBuilder.Append("Transition:").Append(this.m_firstPersonAnimator.GetAnimatorTransitionInfo(k).normalizedTime).Append("\n");
					foreach (AnimationInfo animationInfo3 in this.m_firstPersonAnimator.GetNextAnimationClipState(k))
					{
						stringBuilder.Append("\t").Append(animationInfo3.clip.name).Append("\t weight:")
							.Append(animationInfo3.weight.ToString("F2"))
							.Append("\n");
					}
				}
				else
				{
					foreach (AnimationInfo animationInfo4 in this.m_firstPersonAnimator.GetCurrentAnimationClipState(k))
					{
						stringBuilder.Append("\t").Append(animationInfo4.clip.name).Append("\t weight:")
							.Append(animationInfo4.weight.ToString("F2"))
							.Append("\n");
					}
					AnimatorStateInfo currentAnimatorStateInfo2 = this.m_firstPersonAnimator.GetCurrentAnimatorStateInfo(k);
					if (currentAnimatorStateInfo2.length > 1E-45f)
					{
						stringBuilder.Append("---Length:").Append(currentAnimatorStateInfo2.length.ToString("F2")).Append("\t normalizedTime:")
							.Append(currentAnimatorStateInfo2.normalizedTime.ToString("F2"))
							.Append("\n");
					}
				}
			}
		}
		if (this.m_AnimatorGraph != null)
		{
			if (this.m_firstPersonAnimator != null)
			{
				stringBuilder.Append("Animator Graph:\n---Parameters : ");
				foreach (string text in this.m_AnimatorGraph.method_13())
				{
					if (this.m_firstPersonAnimator.GetBool(text))
					{
						stringBuilder.Append(text).Append(",");
					}
				}
				stringBuilder.Append("\n");
			}
			if (this.m_transitionHistoryMgr != null)
			{
				this.m_transitionHistoryMgr.Update();
				stringBuilder.Append("---Transition History: \n\t");
				stringBuilder.Append(this.m_transitionHistoryMgr.ToString());
			}
			stringBuilder.Append("\n");
			AnimationPlayerFireState animationPlayerFireState = base.method_16(Utils.smethod_23(AnimationStateFSM.PlayerFire)) as AnimationPlayerFireState;
			stringBuilder.Append("FireHolding:  ").Append(animationPlayerFireState.method_23());
		}
		EquipmentInventoryEntityPlayer component = base.gameObject.GetComponent<EquipmentInventoryEntityPlayer>();
		if (component != null)
		{
			stringBuilder.AppendLine();
			stringBuilder.AppendFormat("Active Weapon {0}th Slot;", component.vmethod_55());
			for (int l = 0; l < component.Int32_0; l++)
			{
				byte b = (byte)l;
				if (component.method_17(b))
				{
					stringBuilder.AppendFormat(" <{0}> {1};", l, component.method_27(b).method_6().method_1());
				}
			}
		}
		return stringBuilder.ToString();
	}

	// Token: 0x06000392 RID: 914 RVA: 0x00005305 File Offset: 0x00003505
	public bool method_55()
	{
		return !base.Animator_0.GetBool("bMove") && !this.method_20();
	}

	// Token: 0x06000393 RID: 915 RVA: 0x00047648 File Offset: 0x00045848
	public bool method_56()
	{
		return base.method_13(AnimationStateFSM.PlayerBerserkCharge) || base.method_13(AnimationStateFSM.PlayerBerserkDash) || base.method_13(AnimationStateFSM.PlayerCrouchMove) || base.method_13(AnimationStateFSM.PlayerJumpIdle) || base.method_13(AnimationStateFSM.PlayerJumpLand) || base.method_13(AnimationStateFSM.PlayerJumpStart) || base.method_13(AnimationStateFSM.PlayerMove);
	}

	// Token: 0x06000394 RID: 916 RVA: 0x0004769C File Offset: 0x0004589C
	public virtual void vmethod_29()
	{
		PlayerInfoSync playerInfoSync = base.GetComponent<EntityPlayer>().vmethod_25();
		AvatarType avatarType = playerInfoSync.m_avatarDna.method_5();
		base.Animator_0.SetInteger("iAvatarType", (int)avatarType);
		base.Animator_0.SetBool("bLocalPlayer", playerInfoSync.IsMyActor());
	}

	// Token: 0x06000395 RID: 917 RVA: 0x000476E8 File Offset: 0x000458E8
	protected void method_57()
	{
		if (this.m_deathMaterials != null)
		{
			for (int i = 0; i < this.m_deathMaterials.Length; i++)
			{
				global::UnityEngine.Object.Destroy(this.m_deathMaterials[i]);
			}
			this.m_deathMaterials = null;
		}
	}

	// Token: 0x06000396 RID: 918 RVA: 0x00047724 File Offset: 0x00045924
	public void method_58()
	{
		if (base.Transform_0 == null)
		{
			return;
		}
		SkinnedMeshRenderer component = base.Transform_0.GetComponent<SkinnedMeshRenderer>();
		if (component == null)
		{
			return;
		}
		component.receiveShadows = false;
		component.castShadows = false;
		if (this.m_deathMaterials == null || component.materials.Length != this.m_deathMaterials.Length)
		{
			this.method_57();
			CharacterDeathEffectData component2 = (Resources.Load("Graphics/GraphicsData") as GameObject).GetComponent<CharacterDeathEffectData>();
			if (component2 != null)
			{
				this.m_fadingTime = component2.FadingTime;
			}
			this.m_deathMaterials = new Material[component.materials.Length];
			for (int i = 0; i < component.materials.Length; i++)
			{
				this.m_deathMaterials[i] = new Material(Shader.Find("Custom/BOL_Charactor_BRDF_DeathFading"));
				this.m_deathMaterials[i].CopyPropertiesFromMaterial(component.materials[i]);
				if (component2 != null)
				{
					this.m_deathMaterials[i].SetTexture("_FadingMap", component2.FadingTexture);
				}
			}
		}
		for (int j = 0; j < this.m_deathMaterials.Length; j++)
		{
			this.m_deathMaterials[j].SetFloat("_Fading_Time", this.m_fadingTime);
		}
		this.m_originalMaterials = component.renderer.materials;
		component.renderer.materials = this.m_deathMaterials;
		this.m_currentTime = 0f;
		this.m_beginDeathFading = true;
	}

	// Token: 0x06000397 RID: 919 RVA: 0x00047884 File Offset: 0x00045A84
	public void method_59()
	{
		if (base.Transform_0 == null || this.m_originalMaterials == null)
		{
			return;
		}
		SkinnedMeshRenderer component = base.Transform_0.GetComponent<SkinnedMeshRenderer>();
		if (!(component == null) && !(component.renderer == null))
		{
			component.renderer.materials = this.m_originalMaterials;
			this.m_originalMaterials = null;
			this.m_currentTime = 0f;
			this.m_beginDeathFading = false;
			return;
		}
	}

	// Token: 0x0400036B RID: 875
	public Animator m_firstPersonAnimator;

	// Token: 0x0400036C RID: 876
	public Animator m_inventoryAnimator;

	// Token: 0x0400036D RID: 877
	public float m_movementSyncVelocity;

	// Token: 0x0400036E RID: 878
	public bool m_isPlayerLocal;

	// Token: 0x0400036F RID: 879
	public FireTiming m_fireTiming;

	// Token: 0x04000370 RID: 880
	protected BHVTaskManager m_taskManager;

	// Token: 0x04000371 RID: 881
	private bool m_isAngularVelocityActive = true;

	// Token: 0x04000372 RID: 882
	private float m_angularVelocityYaw;

	// Token: 0x04000373 RID: 883
	private float m_angularVelocityMaxYaw;

	// Token: 0x04000374 RID: 884
	private float m_angularVelocityPitch;

	// Token: 0x04000375 RID: 885
	private float m_angularVelocityMaxPitch;

	// Token: 0x04000376 RID: 886
	private RuntimeAnimatorController m_firstPersonControllerSMG;

	// Token: 0x04000377 RID: 887
	private RuntimeAnimatorController m_firstPersonControllerShotgun;

	// Token: 0x04000378 RID: 888
	private RuntimeAnimatorController m_firstPersonControllerSniper;

	// Token: 0x04000379 RID: 889
	private RuntimeAnimatorController m_firstPersonControllerPistol;

	// Token: 0x0400037A RID: 890
	private RuntimeAnimatorController m_firstPersonControllerCombatRifle;

	// Token: 0x0400037B RID: 891
	private RuntimeAnimatorController m_thirdPersonControllerGame;

	// Token: 0x0400037C RID: 892
	protected RuntimeAnimatorController m_thirdPersonControllerTown;

	// Token: 0x0400037D RID: 893
	private short m_shootPitch;

	// Token: 0x0400037E RID: 894
	protected byte m_inputFrameFlag;

	// Token: 0x0400037F RID: 895
	public MecanimAnimatorGraph m_AnimatorGraph;

	// Token: 0x04000380 RID: 896
	protected StatePriorityManage m_priorityMgr;

	// Token: 0x04000381 RID: 897
	protected TransitionHistoryManage m_transitionHistoryMgr;

	// Token: 0x04000382 RID: 898
	protected bool m_isSetDefaultWeaponPending;

	// Token: 0x04000383 RID: 899
	private AnimationLightHurtState m_lightHurtState;

	// Token: 0x04000384 RID: 900
	protected List<float> m_jumpTimeQueue;

	// Token: 0x04000385 RID: 901
	public GameObject m_InventoryViewWeaponClone;

	// Token: 0x04000386 RID: 902
	public bool m_blockShootingThisFrame;

	// Token: 0x04000387 RID: 903
	public EAnimationJumpStep m_jumpStep;

	// Token: 0x04000388 RID: 904
	private float m_previousLightHurtTime = -1f;

	// Token: 0x04000389 RID: 905
	protected Vector3 m_previousPosition = Vector3.zero;

	// Token: 0x0400038A RID: 906
	protected Vector3 m_localVelocity = Vector3.zero;

	// Token: 0x0400038B RID: 907
	protected CircularBuffer<float> m_previousVelocity = new CircularBuffer<float>(5);

	// Token: 0x0400038C RID: 908
	protected CircularBuffer<Pair<Vector3, float>> m_positionHistory = new CircularBuffer<Pair<Vector3, float>>(7);

	// Token: 0x0400038D RID: 909
	private Material[] m_originalMaterials;

	// Token: 0x0400038E RID: 910
	private Material[] m_deathMaterials;

	// Token: 0x0400038F RID: 911
	private float m_fadingTime = 30f;

	// Token: 0x04000390 RID: 912
	private bool m_beginDeathFading;

	// Token: 0x04000391 RID: 913
	private float m_currentTime;

	// Token: 0x02000098 RID: 152
	public enum ESecondWindMode
	{
		// Token: 0x04000393 RID: 915
		Disabled,
		// Token: 0x04000394 RID: 916
		Crippled,
		// Token: 0x04000395 RID: 917
		Down
	}
}
