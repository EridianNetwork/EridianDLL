using System;
using BHV;
using Core;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x020004B0 RID: 1200
public class PlayerBehavior : MonoBehaviour
{
	// Token: 0x06002014 RID: 8212 RVA: 0x0009D054 File Offset: 0x0009B254
	private void Start()
	{
		this.m_lastUpdateDeltaTime = Time.deltaTime;
		this.m_entity = base.GetComponent<EntityPlayer>();
		this.m_playerController = base.GetComponent<PlayerController>();
		this.m_taskManager = this.m_entity.vmethod_14();
		this.m_motor = (IBadAssCharacterMotor)base.GetComponent(typeof(IBadAssCharacterMotor));
		this.m_firstPersonSettings = this.m_taskManager.vmethod_0<BHVFirstPersonSettings>();
		if (this.m_entity != null && this.m_entity.vmethod_25() != null && this.m_entity.vmethod_25().IsMyActor() && MonoSingleton<GameSettingMgr>.Instance != null)
		{
			this.holdToCrouch = MonoSingleton<GameSettingMgr>.Instance.method_9(SettingFunctionType.HoldCrouching);
			this.method_38(MonoSingleton<GameSettingMgr>.Instance.method_10(SettingFunctionType.MouseSensitivity));
			this.SetAimSensitivity(MonoSingleton<GameSettingMgr>.Instance.method_10(SettingFunctionType.AimSensitivity));
			this.method_46(MonoSingleton<GameSettingMgr>.Instance.method_9(SettingFunctionType.InvertMouse));
			this.m_firstPersonSettings.m_FOVDefault = MonoSingleton<GameSettingMgr>.Instance.method_10(SettingFunctionType.FOV);
		}
	}

	// Token: 0x06002015 RID: 8213 RVA: 0x000163D1 File Offset: 0x000145D1
	public virtual void Update()
	{
		this.m_lastUpdateDeltaTime = Time.deltaTime;
		this.method_36();
	}

	// Token: 0x06002016 RID: 8214 RVA: 0x000163E4 File Offset: 0x000145E4
	public bool IsRunning()
	{
		return this.m_isRunning;
	}

	// Token: 0x06002017 RID: 8215 RVA: 0x000163EC File Offset: 0x000145EC
	public bool IsJumping()
	{
		return this.m_isJumping || (this.m_motor != null && this.m_motor.imethod_6());
	}

	// Token: 0x06002018 RID: 8216 RVA: 0x0001640D File Offset: 0x0001460D
	public bool IsAiming()
	{
		return this.m_isAiming;
	}

	// Token: 0x06002019 RID: 8217 RVA: 0x00016415 File Offset: 0x00014615
	public bool IsCrouching()
	{
		return this.m_isCrouching;
	}

	// Token: 0x0600201A RID: 8218 RVA: 0x0001641D File Offset: 0x0001461D
	public bool IsMovingForward()
	{
		return this.m_isMovingForward;
	}

	// Token: 0x0600201B RID: 8219 RVA: 0x00016425 File Offset: 0x00014625
	public bool IsMovingBackwards()
	{
		return this.m_isMovingBackward;
	}

	// Token: 0x0600201C RID: 8220 RVA: 0x0001642D File Offset: 0x0001462D
	public bool IsMovingLeft()
	{
		return this.m_isMovingLeft;
	}

	// Token: 0x0600201D RID: 8221 RVA: 0x00016435 File Offset: 0x00014635
	public bool IsMovingRight()
	{
		return this.m_isMovingRight;
	}

	// Token: 0x0600201E RID: 8222 RVA: 0x0001643D File Offset: 0x0001463D
	public bool IsFiring()
	{
		return this.m_isFiring || this.m_isAutoFiring;
	}

	// Token: 0x0600201F RID: 8223 RVA: 0x00016450 File Offset: 0x00014650
	public bool IsReloading()
	{
		return this.m_isReloading;
	}

	// Token: 0x06002020 RID: 8224 RVA: 0x00016458 File Offset: 0x00014658
	public bool IsUsingSkill()
	{
		return this.m_isUsingSkill;
	}

	// Token: 0x06002021 RID: 8225 RVA: 0x00016460 File Offset: 0x00014660
	public bool IsSwitchingWeapon()
	{
		return this.m_isSwitchingWeapon;
	}

	// Token: 0x06002022 RID: 8226 RVA: 0x00016468 File Offset: 0x00014668
	public bool IsInteracting()
	{
		return this.m_isInteracting;
	}

	// Token: 0x06002023 RID: 8227 RVA: 0x00016470 File Offset: 0x00014670
	public bool IsThrowing()
	{
		return this.m_isThrowing;
	}

	// Token: 0x06002024 RID: 8228 RVA: 0x00016478 File Offset: 0x00014678
	public bool IsMeleeing()
	{
		return this.m_isMeleeing;
	}

	// Token: 0x06002025 RID: 8229 RVA: 0x00016480 File Offset: 0x00014680
	public byte method_15()
	{
		return this.m_nextWeaponIndex;
	}

	// Token: 0x06002026 RID: 8230 RVA: 0x00016488 File Offset: 0x00014688
	public void method_16(float float_0)
	{
		this.m_yaw = float_0;
	}

	// Token: 0x06002027 RID: 8231 RVA: 0x00016491 File Offset: 0x00014691
	public void method_17(float float_0)
	{
		this.m_pitch = float_0;
	}

	// Token: 0x06002028 RID: 8232 RVA: 0x0001649A File Offset: 0x0001469A
	public float method_18()
	{
		return this.NormalizeAngle(this.m_yaw + this.m_recoilOffsetYaw);
	}

	// Token: 0x06002029 RID: 8233 RVA: 0x000164AF File Offset: 0x000146AF
	public float method_19()
	{
		return this.NormalizeAngle(this.m_pitch - this.m_recoilOffsetPitch);
	}

	// Token: 0x0600202A RID: 8234 RVA: 0x000164C4 File Offset: 0x000146C4
	public float GetYawAngle()
	{
		return this.NormalizeAngle(this.m_yaw);
	}

	// Token: 0x0600202B RID: 8235 RVA: 0x000164D2 File Offset: 0x000146D2
	public float GetPitchAngle()
	{
		return this.NormalizeAngle(this.m_pitch);
	}

	// Token: 0x0600202C RID: 8236 RVA: 0x000164E0 File Offset: 0x000146E0
	public float method_22()
	{
		return this.m_angularVelocityYaw;
	}

	// Token: 0x0600202D RID: 8237 RVA: 0x000164E8 File Offset: 0x000146E8
	public float method_23()
	{
		return this.m_angularVelocityPitch;
	}

	// Token: 0x0600202E RID: 8238 RVA: 0x0009D14C File Offset: 0x0009B34C
	public float method_24()
	{
		EntityWeapon entityWeapon = this.m_entity.vmethod_16();
		if (entityWeapon)
		{
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			entityWeapon.method_89(ref num, ref num2, ref num3);
			return num3;
		}
		return 0f;
	}

	// Token: 0x0600202F RID: 8239 RVA: 0x0009D194 File Offset: 0x0009B394
	public Quaternion method_25()
	{
		EntityWeapon entityWeapon = this.m_entity.vmethod_16();
		if (entityWeapon)
		{
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			entityWeapon.method_89(ref num, ref num2, ref num3);
			return Quaternion.Euler(num2, 0f, num);
		}
		return Quaternion.identity;
	}

	// Token: 0x06002030 RID: 8240 RVA: 0x0009D1E8 File Offset: 0x0009B3E8
	private void method_26()
	{
		if (this.m_playerController == null)
		{
			return;
		}
		if (MonoSingleton<InputManager>.Instance == null)
		{
			return;
		}
		if (this.m_entity == null)
		{
			return;
		}
		if (this.m_entity.vmethod_25() == null)
		{
			return;
		}
		if (MonoSingleton<TargetingManager>.Instance == null)
		{
			return;
		}
		if (MonoSingleton<InputManager>.Instance.method_3())
		{
			this.m_isRunning = false;
			this.m_isMovingForward = false;
			this.m_isMovingBackward = false;
			this.m_isMovingLeft = false;
			this.m_isMovingRight = false;
			this.m_isJumping = false;
			this.m_isAiming = false;
			this.m_isFiring = false;
			this.m_isAutoFiring = false;
			this.m_isReloading = false;
			this.m_isAutoReload = false;
			this.m_isSwitchingWeapon = false;
			this.m_isUsingSkill = false;
			this.m_isInteracting = false;
			MonoSingleton<TargetingManager>.Instance.m_currentInteraction = null;
			this.m_isThrowing = false;
			this.m_isMeleeing = false;
			MonoSingleton<InputManager>.Instance.method_24();
			return;
		}
		if (this.m_lastInputTickCount == Time.frameCount)
		{
			return;
		}
		this.m_lastInputTickCount = Time.frameCount;
		if (this.m_playerController.method_31())
		{
			this.m_isMovingForward = MonoSingleton<InputManager>.Instance.method_4("Forward");
			this.m_isMovingBackward = MonoSingleton<InputManager>.Instance.method_4("Backward");
			this.m_isMovingLeft = MonoSingleton<InputManager>.Instance.method_4("Left");
			this.m_isMovingRight = MonoSingleton<InputManager>.Instance.method_4("Right");
		}
		else
		{
			this.m_isMovingForward = false;
			this.m_isMovingBackward = false;
			this.m_isMovingLeft = false;
			this.m_isMovingRight = false;
		}
		if (MonoSingleton<InputManager>.Instance.method_7("Run"))
		{
			if (this.m_isRunning)
			{
				this.m_isRunning = false;
			}
			else if (MonoSingleton<InputManager>.Instance.method_4("Forward") && this.m_playerController.method_32())
			{
				this.m_isRunning = true;
			}
		}
		if (!MonoSingleton<InputManager>.Instance.method_4("Forward"))
		{
			this.m_isRunning = false;
		}
		if (!this.clickToAim)
		{
			if (MonoSingleton<InputManager>.Instance.method_4("Fire2") && this.m_playerController.method_46())
			{
				this.m_isAiming = true;
				this.m_isAutoFiring = false;
			}
			else
			{
				this.m_isAiming = false;
			}
		}
		else if (MonoSingleton<InputManager>.Instance.method_7("Fire2"))
		{
			this.m_isAiming = !this.m_isAiming;
			if (this.m_isAiming)
			{
				this.m_isAutoFiring = false;
			}
		}
		if (this.m_isRunning && this.m_isAiming)
		{
			if (this.m_conflictFlag == PlayerBehavior.KeyConflictFlag.None)
			{
				if (MonoSingleton<InputManager>.Instance.method_7("Run"))
				{
					this.m_conflictFlag = PlayerBehavior.KeyConflictFlag.SprintWin;
				}
				else
				{
					this.m_conflictFlag = PlayerBehavior.KeyConflictFlag.AimWin;
				}
			}
			if (this.m_conflictFlag == PlayerBehavior.KeyConflictFlag.SprintWin)
			{
				this.m_isAiming = false;
				this.m_isRunning = true;
			}
			else
			{
				this.m_isAiming = true;
				this.m_isRunning = false;
			}
		}
		else
		{
			this.m_conflictFlag = PlayerBehavior.KeyConflictFlag.None;
		}
		if (MonoSingleton<InputManager>.Instance.method_7("Reload") && this.m_playerController.method_38())
		{
			this.m_isReloading = true;
			this.m_isFiring = false;
			this.m_isAutoFiring = false;
		}
		else
		{
			this.m_isReloading = false;
			EntityWeapon entityWeapon = this.m_entity.vmethod_16();
			if (entityWeapon != null && entityWeapon.method_39())
			{
				this.m_isAutoFiring = true;
			}
			else
			{
				this.m_isAutoFiring = false;
			}
			if (MonoSingleton<InputManager>.Instance.method_4("Fire1") && this.m_playerController.method_33())
			{
				if (this.m_playerController.method_36())
				{
					if (this.m_playerController.method_38())
					{
						this.m_isReloading = true;
					}
					this.m_isFiring = false;
					this.m_isAutoFiring = false;
				}
				else if (entityWeapon != null && entityWeapon.method_36())
				{
					this.m_isFiring = false;
					if (entityWeapon.method_37())
					{
						this.m_isAutoFiring = true;
					}
				}
				else
				{
					this.m_isFiring = true;
					this.m_isAutoFiring = false;
				}
			}
			else
			{
				this.m_isFiring = false;
				if (this.m_playerController.method_33() && this.m_playerController.method_36() && this.m_playerController.method_38() && !this.m_isAutoReload)
				{
					this.m_isAutoReload = true;
					this.m_isReloading = true;
				}
				if (!this.m_playerController.method_36() && this.m_isAutoReload)
				{
					this.m_isAutoReload = false;
				}
			}
		}
		bool flag = false;
		if (MonoSingleton<InputManager>.Instance.method_7("ChangeToPreviousWeapon"))
		{
			this.m_nextWeaponIndex = this.m_previousWeaponIndex;
			flag = true;
		}
		if (MonoSingleton<InputManager>.Instance.method_7("ChangeWeapon1"))
		{
			DebugUtils.Log(LogCategory.Default, "WPNSW_3 ChangeWeapon1 pressed");
			this.m_nextWeaponIndex = 0;
			flag = true;
		}
		if (MonoSingleton<InputManager>.Instance.method_7("ChangeWeapon2"))
		{
			this.m_nextWeaponIndex = 1;
			flag = true;
		}
		if (MonoSingleton<InputManager>.Instance.method_7("ChangeWeapon3"))
		{
			this.m_nextWeaponIndex = 2;
			flag = true;
		}
		if (MonoSingleton<InputManager>.Instance.method_7("ChangeWeapon4"))
		{
			this.m_nextWeaponIndex = 3;
			flag = true;
		}
		if (!this.m_isSwitchingWeapon && MonoSingleton<InputManager>.Instance.method_5("SwitchWeapon") != 0f)
		{
			EquipmentInventoryEntityPlayer equipmentInventoryEntityPlayer = this.m_entity.vmethod_19() as EquipmentInventoryEntityPlayer;
			if (equipmentInventoryEntityPlayer != null)
			{
				this.m_nextWeaponIndex = equipmentInventoryEntityPlayer.method_35();
				flag = true;
			}
		}
		byte b = 0;
		if (ServiceWrapperBase<InventoryServiceWrapper>.Instance != null)
		{
			b = ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_8();
		}
		if (flag)
		{
			DebugUtils.Log(LogCategory.Default, string.Format("WPNSW_4 flag=True current={0} next={1} canSwitch={2}", b, this.m_nextWeaponIndex, this.m_playerController.method_40(this.m_nextWeaponIndex)));
		}
		if (flag && b != this.m_nextWeaponIndex && this.m_playerController.method_40(this.m_nextWeaponIndex))
		{
			this.m_previousWeaponIndex = b;
			this.m_isSwitchingWeapon = true;
			this.m_isFiring = false;
			this.m_isAutoFiring = false;
			this.m_isReloading = false;
			this.m_isAiming = false;
		}
		else
		{
			this.m_isSwitchingWeapon = false;
		}
		if (this.holdToCrouch)
		{
			if (MonoSingleton<InputManager>.Instance.method_4("Crouch"))
			{
				if (this.m_playerController.method_42())
				{
					this.m_isCrouching = true;
				}
			}
			else if (this.m_playerController.method_43())
			{
				this.m_isCrouching = false;
			}
		}
		else if (MonoSingleton<InputManager>.Instance.method_7("Crouch"))
		{
			if (this.m_isCrouching)
			{
				if (this.m_playerController.method_43())
				{
					this.m_isCrouching = false;
				}
			}
			else if (this.m_playerController.method_42())
			{
				this.m_isCrouching = true;
			}
		}
		if (MonoSingleton<InputManager>.Instance.method_7("Jump") && this.m_playerController.method_44())
		{
			if (this.m_isCrouching)
			{
				if (this.m_playerController.method_43())
				{
					this.m_isJumping = false;
					this.m_isCrouching = false;
				}
			}
			else
			{
				this.m_isJumping = true;
			}
		}
		else
		{
			this.m_isJumping = false;
		}
		if (this.m_isFiring)
		{
			this.m_isRunning = false;
		}
		if (this.m_isRunning && MonoSingleton<InputManager>.Instance.method_7("Run"))
		{
			if (this.m_playerController.method_43())
			{
				this.m_isCrouching = false;
			}
		}
		else if (this.m_isCrouching)
		{
			this.m_isRunning = false;
		}
		if (this.m_isRunning && !this.m_playerController.method_32())
		{
			this.m_isRunning = false;
		}
		if (this.m_isReloading)
		{
			this.m_isAiming = false;
		}
		if (MonoSingleton<InputManager>.Instance.method_7("Skill") && this.m_playerController.method_48())
		{
			this.m_isRunning = false;
			this.m_isUsingSkill = true;
		}
		else
		{
			this.m_isUsingSkill = false;
		}
		if (MonoSingleton<InputManager>.Instance.method_7("Interaction") && this.m_playerController.method_50())
		{
			MonoSingleton<TargetingManager>.Instance.m_currentInteraction = MonoSingleton<TargetingManager>.Instance.m_availableInteraction;
			this.m_isInteracting = true;
		}
		else if (MonoSingleton<InputManager>.Instance.method_8("Interaction") || MonoSingleton<InputManager>.Instance.method_3())
		{
			MonoSingleton<TargetingManager>.Instance.m_currentInteraction = null;
			this.m_isInteracting = false;
		}
		if (MonoSingleton<InputManager>.Instance.method_7("Throw") && this.m_playerController.method_52())
		{
			this.m_isThrowing = true;
		}
		else
		{
			this.m_isThrowing = false;
		}
		this.method_27();
		MonoSingleton<InputManager>.Instance.method_24();
	}

	// Token: 0x06002031 RID: 8241 RVA: 0x0009D9A8 File Offset: 0x0009BBA8
	private void method_27()
	{
		if (MonoSingleton<InputManager>.Instance.method_4("MeleeAttack") && this.m_playerController.method_54() && !this.m_isInteracting)
		{
			this.m_isMeleeing = true;
			this.m_isAiming = false;
			this.m_isAutoReload = false;
		}
		else
		{
			this.m_isMeleeing = false;
		}
	}

	// Token: 0x06002032 RID: 8242 RVA: 0x0009D9FC File Offset: 0x0009BBFC
	public void method_28()
	{
		EntityWeapon entityWeapon = this.m_entity.vmethod_16();
		if (entityWeapon == null)
		{
			return;
		}
		entityWeapon.method_93(ref this.m_recoilSettingsYaw);
		this.m_recoilOffsetYaw = Mathf.Clamp(this.m_recoilOffsetYaw, this.m_recoilSettingsYaw.m_offsetMin, this.m_recoilSettingsYaw.m_offsetMax);
		this.m_recoilOffsetYaw += this.m_recoilSettingsYaw.m_randomOffsetMin + (this.m_recoilSettingsYaw.m_randomOffsetMax - this.m_recoilSettingsYaw.m_randomOffsetMin) * Utils.StaticRandom.smethod_0(this.m_randomIndex++);
		entityWeapon.method_94(ref this.m_recoilSettingsPitch);
		float num = this.m_recoilSettingsPitch.m_randomOffsetMin + (this.m_recoilSettingsPitch.m_randomOffsetMax - this.m_recoilSettingsPitch.m_randomOffsetMin) * Utils.StaticRandom.smethod_0(this.m_randomIndex++);
		float num2 = Mathf.Clamp(this.m_recoilOffsetPitch / this.m_recoilSettingsPitch.m_randomOffsetMax, FloatAttributeValue.smethod_0(entityWeapon.m_attribute.method_1(AttributeType.RecoilPitchMulMin) as FloatAttributeValue), FloatAttributeValue.smethod_0(entityWeapon.m_attribute.method_1(AttributeType.RecoilPitchMulMax) as FloatAttributeValue));
		num *= num2;
		this.m_recoilOffsetPitch = Mathf.Clamp(this.m_recoilOffsetPitch, this.m_recoilSettingsPitch.m_offsetMin, this.m_recoilSettingsPitch.m_offsetMax);
		this.m_recoilOffsetPitch += num;
		entityWeapon.method_95(ref this.m_recoilSettingsKickBack);
		this.m_recoilOffsetKickBack = Mathf.Clamp(this.m_recoilOffsetKickBack, this.m_recoilSettingsKickBack.m_offsetMin, this.m_recoilSettingsKickBack.m_offsetMax);
		this.m_recoilOffsetKickBack += this.m_recoilSettingsKickBack.m_randomOffsetMin + (this.m_recoilSettingsKickBack.m_randomOffsetMax - this.m_recoilSettingsKickBack.m_randomOffsetMin) * Utils.StaticRandom.smethod_0(this.m_randomIndex++);
		if (this.IsAiming())
		{
			float num3 = this.m_entity.PlayerEffectManager_0.method_0(EffectType.WeaponRecoil);
			this.m_recoilOffsetYaw *= num3;
			this.m_recoilOffsetPitch *= num3;
			this.m_recoilOffsetKickBack *= num3;
		}
		if (entityWeapon.method_92() > 0f)
		{
			this.m_nextFireTime = entityWeapon.m_nextFireTime;
		}
		else
		{
			this.m_nextFireTime = Time.time;
		}
	}

	// Token: 0x06002033 RID: 8243 RVA: 0x0009DC4C File Offset: 0x0009BE4C
	private void method_29(EntityWeapon.RecoilSettings recoilSettings_0, ref float float_0)
	{
		if (float_0 > 0f)
		{
			if (this.m_nextFireTime > Time.fixedTime)
			{
				float_0 -= Time.fixedDeltaTime * recoilSettings_0.m_reducingRateActive;
			}
			else
			{
				float_0 -= Time.fixedDeltaTime * recoilSettings_0.m_reducingRateOnIdle;
			}
		}
		else
		{
			float_0 = 0f;
		}
	}

	// Token: 0x06002034 RID: 8244 RVA: 0x0009DC9C File Offset: 0x0009BE9C
	private void method_30(EntityWeapon.RecoilSettings recoilSettings_0, ref float float_0)
	{
		if (float_0 > 0f)
		{
			if (this.m_nextFireTime > Time.fixedTime)
			{
				float_0 -= Time.fixedDeltaTime * recoilSettings_0.m_reducingRateActive;
			}
			else
			{
				float_0 -= Time.fixedDeltaTime * recoilSettings_0.m_reducingRateOnIdle;
			}
			if (float_0 <= 0f)
			{
				float_0 = 0f;
			}
		}
		else if (float_0 < 0f)
		{
			if (this.m_nextFireTime > Time.fixedTime)
			{
				float_0 += Time.fixedDeltaTime * recoilSettings_0.m_reducingRateActive;
			}
			else
			{
				float_0 += Time.fixedDeltaTime * recoilSettings_0.m_reducingRateOnIdle;
			}
			if (float_0 >= 0f)
			{
				float_0 = 0f;
			}
		}
	}

	// Token: 0x06002035 RID: 8245 RVA: 0x000164F0 File Offset: 0x000146F0
	protected void method_31()
	{
		this.method_30(this.m_recoilSettingsYaw, ref this.m_recoilOffsetYaw);
		this.method_29(this.m_recoilSettingsPitch, ref this.m_recoilOffsetPitch);
		this.method_29(this.m_recoilSettingsKickBack, ref this.m_recoilOffsetKickBack);
	}

	// Token: 0x06002036 RID: 8246 RVA: 0x00016528 File Offset: 0x00014728
	private void method_32(float float_0)
	{
		if (this.m_posToFollowByCamera == null)
		{
			this.method_34();
		}
		else
		{
			this.method_42(float_0);
		}
		this.method_33();
	}

	// Token: 0x06002037 RID: 8247 RVA: 0x0001654D File Offset: 0x0001474D
	protected virtual void FixedUpdate()
	{
		this.method_31();
		this.method_26();
		this.method_32(Time.fixedDeltaTime);
	}

	// Token: 0x06002038 RID: 8248 RVA: 0x0009DD40 File Offset: 0x0009BF40
	private void method_33()
	{
		EntityWeapon entityWeapon = this.m_entity.vmethod_16();
		if (!(entityWeapon == null) && this.m_isAiming)
		{
			entityWeapon.m_wander_manager.Update();
			this.m_yaw += entityWeapon.m_wander_manager.method_5();
			this.m_yaw = this.NormalizeAngle(this.m_yaw);
			this.m_pitch += entityWeapon.m_wander_manager.method_6();
			this.m_pitch = Mathf.Clamp(this.m_pitch, -this.m_firstPersonSettings.m_cameraAngleMaxPitch, -this.m_firstPersonSettings.m_cameraAngleMinPitch);
			return;
		}
	}

	// Token: 0x06002039 RID: 8249 RVA: 0x0009DDE4 File Offset: 0x0009BFE4
	private void method_34()
	{
		if (this.m_AccmulatedRotationTime > this.m_lastUpdateDeltaTime)
		{
			return;
		}
		float num = 0f;
		float num2 = 0f;
		this.method_37(ref num, ref num2);
		float num3 = 0f;
		float num4 = 0f;
		if (!MonoSingleton<InputManager>.Instance.method_3())
		{
			num3 = MonoSingleton<InputManager>.Instance.method_5("Mouse X");
			num3 *= Time.fixedDeltaTime / this.m_lastUpdateDeltaTime;
			num4 = MonoSingleton<InputManager>.Instance.method_5("Mouse Y");
			num4 *= Time.fixedDeltaTime / this.m_lastUpdateDeltaTime;
		}
		this.m_angularVelocityYaw = num3 * num;
		this.m_angularVelocityPitch = num4 * num2;
		if (this.m_inverseMouse)
		{
			this.m_angularVelocityPitch *= -1f;
		}
		if (this.m_entity != null && this.m_entity.PlayerSkillManage_0 != null)
		{
			this.m_angularVelocityYaw = this.m_entity.PlayerSkillManage_0.vmethod_4(this.m_angularVelocityYaw);
		}
		this.m_AccmulatedRotationTime += Time.fixedDeltaTime;
		this.m_yaw += this.m_angularVelocityYaw;
		this.m_yaw = this.NormalizeAngle(this.m_yaw);
		this.m_pitch -= this.m_angularVelocityPitch;
		this.m_pitch = Mathf.Clamp(this.m_pitch, -this.m_firstPersonSettings.m_cameraAngleMaxPitch, -this.m_firstPersonSettings.m_cameraAngleMinPitch);
	}

	// Token: 0x0600203A RID: 8250 RVA: 0x0009DF48 File Offset: 0x0009C148
	private float NormalizeAngle(float float_0)
	{
		float num = float_0 % 360f;
		if (num < 0f)
		{
			num += 360f;
		}
		return num;
	}

	// Token: 0x0600203B RID: 8251 RVA: 0x00016566 File Offset: 0x00014766
	private void method_36()
	{
		this.m_AccmulatedRotationTime = 0f;
	}

	// Token: 0x0600203C RID: 8252 RVA: 0x0009DF70 File Offset: 0x0009C170
	private void method_37(ref float float_0, ref float float_1)
	{
		if (this.m_isAiming)
		{
			EntityWeapon entityWeapon = this.m_entity.vmethod_16();
			if (entityWeapon != null)
			{
				entityWeapon.method_85(ref float_0, ref float_1, this.m_aimSensitivity);
				return;
			}
		}
		float_0 = this.m_firstPersonSettings.m_cameraAngularSpeedYaw;
		float_1 = this.m_firstPersonSettings.m_cameraAngularSpeedPitch;
	}

	// Token: 0x0600203D RID: 8253 RVA: 0x00016573 File Offset: 0x00014773
	public void method_38(float float_0)
	{
		this.m_firstPersonSettings.m_cameraAngularSpeedYaw = float_0;
		this.m_firstPersonSettings.m_cameraAngularSpeedPitch = float_0;
	}

	// Token: 0x0600203E RID: 8254 RVA: 0x0001658D File Offset: 0x0001478D
	public float method_39()
	{
		return this.m_firstPersonSettings.m_cameraAngularSpeedYaw;
	}

	public void SetAimSensitivity(float sensitivity)
	{
		this.m_aimSensitivity = sensitivity;
	}

	// Token: 0x0600203F RID: 8255 RVA: 0x0001659A File Offset: 0x0001479A
	public void method_40(Transform transform_0)
	{
		this.m_posToFollowByCamera = transform_0;
		this.m_lastTargetPos = this.m_posToFollowByCamera.position;
		this.m_lastMinePos = this.m_playerController.method_12().position;
	}

	// Token: 0x06002040 RID: 8256 RVA: 0x000165CA File Offset: 0x000147CA
	public void method_41()
	{
		this.m_posToFollowByCamera = null;
	}

	// Token: 0x06002041 RID: 8257 RVA: 0x0009DFC0 File Offset: 0x0009C1C0
	private void method_42(float float_0)
	{
		this.m_velocityOfCameraTarget = (this.m_posToFollowByCamera.position - this.m_lastTargetPos) / float_0;
		this.m_lastTargetPos = this.m_posToFollowByCamera.position;
		this.m_velocityOfMine = (this.m_playerController.method_12().position - this.m_lastMinePos) / float_0;
		this.m_lastMinePos = this.m_playerController.method_12().position;
		Vector3 vector = this.m_posToFollowByCamera.position + this.m_velocityOfCameraTarget * float_0 - (this.m_playerController.method_12().position + this.m_velocityOfMine * float_0);
		Quaternion identity = Quaternion.identity;
		identity.SetLookRotation(vector);
		this.m_yaw = identity.eulerAngles.y;
		this.m_pitch = identity.eulerAngles.x;
	}

	// Token: 0x06002042 RID: 8258 RVA: 0x000165D3 File Offset: 0x000147D3
	public void method_43(bool bool_0)
	{
		this.m_isCrouching = bool_0;
	}

	// Token: 0x06002043 RID: 8259 RVA: 0x000165DC File Offset: 0x000147DC
	public Vector3 method_44()
	{
		return this.m_motor.imethod_8().velocity;
	}

	// Token: 0x06002044 RID: 8260 RVA: 0x000165EE File Offset: 0x000147EE
	public BHVFirstPersonSettings method_45()
	{
		return this.m_firstPersonSettings;
	}

	// Token: 0x06002045 RID: 8261 RVA: 0x000165F6 File Offset: 0x000147F6
	public void method_46(bool bool_0)
	{
		this.m_inverseMouse = bool_0;
	}

	// Token: 0x040014C0 RID: 5312
	private EntityPlayer m_entity;

	// Token: 0x040014C1 RID: 5313
	private PlayerController m_playerController;

	// Token: 0x040014C2 RID: 5314
	private BHVTaskManager m_taskManager;

	// Token: 0x040014C3 RID: 5315
	private IBadAssCharacterMotor m_motor;

	// Token: 0x040014C4 RID: 5316
	private BHVFirstPersonSettings m_firstPersonSettings;

	// Token: 0x040014C5 RID: 5317
	private bool m_isRunning;

	// Token: 0x040014C6 RID: 5318
	private bool m_isMovingForward;

	// Token: 0x040014C7 RID: 5319
	private bool m_isMovingBackward;

	// Token: 0x040014C8 RID: 5320
	private bool m_isMovingLeft;

	// Token: 0x040014C9 RID: 5321
	private bool m_isMovingRight;

	// Token: 0x040014CA RID: 5322
	private bool m_isJumping;

	// Token: 0x040014CB RID: 5323
	private bool m_isAiming;

	// Token: 0x040014CC RID: 5324
	private bool m_isCrouching;

	// Token: 0x040014CD RID: 5325
	private bool m_isFiring;

	// Token: 0x040014CE RID: 5326
	private bool m_isAutoFiring;

	// Token: 0x040014CF RID: 5327
	private bool m_isReloading;

	// Token: 0x040014D0 RID: 5328
	private bool m_isAutoReload;

	// Token: 0x040014D1 RID: 5329
	private bool m_isSwitchingWeapon;

	// Token: 0x040014D2 RID: 5330
	private bool m_isUsingSkill;

	// Token: 0x040014D3 RID: 5331
	private bool m_isInteracting;

	// Token: 0x040014D4 RID: 5332
	private bool m_isThrowing;

	// Token: 0x040014D5 RID: 5333
	private bool m_isMeleeing;

	// Token: 0x040014D6 RID: 5334
	private byte m_nextWeaponIndex;

	// Token: 0x040014D7 RID: 5335
	private byte m_previousWeaponIndex;

	// Token: 0x040014D8 RID: 5336
	private bool m_inverseMouse;

	// Token: 0x040014D9 RID: 5337
	private float m_yaw;

	// Token: 0x040014DA RID: 5338
	private float m_pitch;

	// Token: 0x040014DB RID: 5339
	private float m_angularVelocityYaw;

	// Token: 0x040014DC RID: 5340
	private float m_angularVelocityPitch;

	private float m_aimSensitivity;

	// Token: 0x040014DD RID: 5341
	private float m_recoilOffsetYaw;

	// Token: 0x040014DE RID: 5342
	private float m_recoilOffsetPitch;

	// Token: 0x040014DF RID: 5343
	private float m_recoilOffsetKickBack;

	// Token: 0x040014E0 RID: 5344
	private int m_randomIndex;

	// Token: 0x040014E1 RID: 5345
	private float m_nextFireTime;

	// Token: 0x040014E2 RID: 5346
	private EntityWeapon.RecoilSettings m_recoilSettingsYaw = new EntityWeapon.RecoilSettings();

	// Token: 0x040014E3 RID: 5347
	private EntityWeapon.RecoilSettings m_recoilSettingsPitch = new EntityWeapon.RecoilSettings();

	// Token: 0x040014E4 RID: 5348
	private EntityWeapon.RecoilSettings m_recoilSettingsKickBack = new EntityWeapon.RecoilSettings();

	// Token: 0x040014E5 RID: 5349
	private int m_lastInputTickCount;

	// Token: 0x040014E6 RID: 5350
	private float m_lastUpdateDeltaTime;

	// Token: 0x040014E7 RID: 5351
	private float m_AccmulatedRotationTime;

	// Token: 0x040014E8 RID: 5352
	public bool holdToCrouch;

	// Token: 0x040014E9 RID: 5353
	public bool clickToAim;

	// Token: 0x040014EA RID: 5354
	private Transform m_posToFollowByCamera;

	// Token: 0x040014EB RID: 5355
	private Vector3 m_velocityOfCameraTarget = Vector3.zero;

	// Token: 0x040014EC RID: 5356
	private Vector3 m_lastTargetPos;

	// Token: 0x040014ED RID: 5357
	private Vector3 m_velocityOfMine = Vector3.zero;

	// Token: 0x040014EE RID: 5358
	private Vector3 m_lastMinePos;

	// Token: 0x040014EF RID: 5359
	private PlayerBehavior.KeyConflictFlag m_conflictFlag;

	// Token: 0x020004B1 RID: 1201
	public enum KeyConflictFlag
	{
		// Token: 0x040014F1 RID: 5361
		None,
		// Token: 0x040014F2 RID: 5362
		AimWin,
		// Token: 0x040014F3 RID: 5363
		SprintWin
	}
}
