using System;
using System.Collections;
using Core;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x02000473 RID: 1139
public class EntityWeapon : EntityObject
{
	// Token: 0x06001D63 RID: 7523 RVA: 0x00090F64 File Offset: 0x0008F164
	public static AttackInfo.ElementalType smethod_1(WeaponAttribute weaponAttribute_0)
	{
		return (AttackInfo.ElementalType)IntAttributeValue.smethod_0(weaponAttribute_0.method_1(AttributeType.ElementalType) as IntAttributeValue);
	}

	// Token: 0x06001D64 RID: 7524 RVA: 0x00014BE4 File Offset: 0x00012DE4
	public override AttackInfo.ElementalType vmethod_1()
	{
		return EntityWeapon.smethod_1(this.m_attribute);
	}

	// Token: 0x17000192 RID: 402
	// (get) Token: 0x06001D65 RID: 7525 RVA: 0x00014BF1 File Offset: 0x00012DF1
	// (set) Token: 0x06001D66 RID: 7526 RVA: 0x00014BF9 File Offset: 0x00012DF9
	public WeaponAttribute m_attribute { get; private set; }

	// Token: 0x06001D67 RID: 7527 RVA: 0x00014C02 File Offset: 0x00012E02
	public void method_16(WeaponDNA weaponDNA_0)
	{
		this.m_dna = weaponDNA_0;
	}

	// Token: 0x06001D68 RID: 7528 RVA: 0x00014C0B File Offset: 0x00012E0B
	public WeaponDNA method_17()
	{
		return this.m_dna;
	}

	// Token: 0x06001D69 RID: 7529 RVA: 0x00014C13 File Offset: 0x00012E13
	public override int vmethod_3()
	{
		return this.m_level;
	}

	// Token: 0x06001D6A RID: 7530 RVA: 0x00014C1B File Offset: 0x00012E1B
	public byte method_18(WeaponSubPart weaponSubPart_0)
	{
		return this.m_dna.method_15(weaponSubPart_0);
	}

	// Token: 0x06001D6B RID: 7531 RVA: 0x00090F88 File Offset: 0x0008F188
	// seems to get the skel of the player, and attatches the weapon to the correct bone, so basically equip weapon. im making an edit here to make sure the rigidbody is disabled
	public override void vmethod_63(Entity entity_0)
	{
		if (entity_0 == null)
		{
			return;
		}
		DebugUtils.Log(LogCategory.Gamelogic, "owner not null");
		Skeleton skeleton = entity_0.vmethod_17();
		if (skeleton == null)
		{
			return;
		}
		DebugUtils.Log(LogCategory.Gamelogic, "owner skeleton not null");
		WeaponType weaponType = this.method_99();
		Transform transform = skeleton.method_4(weaponType);
		if (transform == null)
		{
			DebugUtils.LogError(LogCategory.Gamelogic, string.Concat(new object[] { "No weapon Node for Weapontype[", weaponType, "] on [", entity_0.name, "]" }));
			return;
		}
		base.transform.parent = transform;
		base.transform.localPosition = Vector3.zero;
		base.transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
		DebugUtils.Log(LogCategory.Gamelogic, string.Concat(new object[]
		{
			"transform.parent postion x ",
			base.transform.parent.position.x,
			" y ",
			base.transform.parent.position.y,
			" z ",
			base.transform.parent.position.z
		}));
		DebugUtils.Log(LogCategory.Gamelogic, string.Concat(new object[]
		{
			"transform postion x ",
			base.transform.position.x,
			" y ",
			base.transform.position.y,
			" z ",
			base.transform.position.z
		}));
		base.gameObject.SetActive(true);
		DebugUtils.Log(LogCategory.Gamelogic, "game object active state is " + base.gameObject.activeInHierarchy);
		this.method_55();
		this.method_53(entity_0);
		this.mWpnRenderer = base.gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
		// use the same method as above to find the wpn's rigidbody and disable it, this is to prevent the wpn from colliding with the player when holstered
		Rigidbody wpnRigidbody = base.gameObject.GetComponentInChildren<Rigidbody>();
		if (wpnRigidbody != null)
		{
			wpnRigidbody.isKinematic = true;
			wpnRigidbody.detectCollisions = false;
		}
		if (MonoSingleton<Session>.Instance.method_16() && NPC_UIFlowController.smethod_0() != null && NPC_UIFlowController.smethod_0().Boolean_0 && this.mWpnRenderer)
		{
			this.mWpnRenderer.enabled = false;
		}
		this.m_isReadyToFire = true;
	}

	// Token: 0x06001D6C RID: 7532 RVA: 0x00014C29 File Offset: 0x00012E29
	public override void vmethod_64()
	{
		if (MonoSingleton<Session>.Instance.method_16() && this.mWpnRenderer)
		{
			this.mWpnRenderer.enabled = true;
		}
		base.gameObject.SetActive(false);
	}

	// Token: 0x06001D6D RID: 7533 RVA: 0x00014C5C File Offset: 0x00012E5C
	public override bool vmethod_62()
	{
		return this.m_isReady;
	}

	// Token: 0x06001D6E RID: 7534 RVA: 0x000911E0 File Offset: 0x0008F3E0
	public void method_19(bool bool_0)
	{
		SkinnedMeshRenderer componentInChildren = base.gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
		if (componentInChildren != null)
		{
			componentInChildren.enabled = !bool_0;
		}
	}

	// Token: 0x06001D6F RID: 7535 RVA: 0x00014C64 File Offset: 0x00012E64
	public bool method_20()
	{
		return this.m_hasScope;
	}

	// Token: 0x06001D70 RID: 7536 RVA: 0x00014C6C File Offset: 0x00012E6C
	public bool method_21()
	{
		return this.m_hasMask;
	}

	// Token: 0x06001D71 RID: 7537 RVA: 0x00014C74 File Offset: 0x00012E74
	public void method_22(bool bool_0)
	{
		this.m_isAimActive = bool_0;
		if (this.m_isAimActive)
		{
			this.m_currentView = this.m_zoomView;
		}
		else
		{
			this.m_currentView = this.m_normalView;
		}
	}

	// Token: 0x06001D72 RID: 7538 RVA: 0x00014C9F File Offset: 0x00012E9F
	public bool method_23()
	{
		if (this.method_99() != WeaponType.ShotGun)
		{
			if (this.method_99() != WeaponType.SniperRifle)
			{
				return (double)FloatAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.FireRate) as FloatAttributeValue) > 5.0;
			}
		}
		return false;
	}

	// Token: 0x06001D73 RID: 7539 RVA: 0x0009120C File Offset: 0x0008F40C
	private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.IsWriting)
		{
			this.m_ammoCountToSend = -1;
			if (this.m_isDataDirty)
			{
				this.m_ammoCountToSend = this.m_ammoCount;
				this.m_isDataDirty = false;
			}
			stream.SendNext(this.m_ammoCountToSend);
			stream.SendNext(this.m_random_index);
		}
		else
		{
			int num = (int)stream.ReceiveNext();
			if (num != -1)
			{
				this.m_ammoCount = num;
			}
			this.m_random_index = (int)stream.ReceiveNext();
		}
	}

	// Token: 0x06001D74 RID: 7540 RVA: 0x00091290 File Offset: 0x0008F490
	public override void Start()
	{
		base.Start();
		if (this.m_dna == null)
		{
			ItemDNA itemDNA = this.vmethod_7()[0] as ItemDNA;
			this.m_dna = itemDNA.method_6();
		}
		this.m_wander_manager = new EntityWeapon.WanderManage(this);
		this.m_level = this.m_dna.m_level;
		this.method_24(this.m_dna);
		if (this.vmethod_7() != null)
		{
			int num = (int)this.vmethod_7()[2];
			if (num == -1 || num == PhotonNetwork.player.ActorId)
			{
				this.method_49();
			}
		}
		else
		{
			this.method_49();
		}
		if (AuthoritativeActionManager.AuthoritativeActionManager_0)
		{
			this.m_ability.method_0(new Fire());
			this.m_ability.method_0(new Reload());
		}
		this.m_random_index = 0;
	}

	// Token: 0x06001D75 RID: 7541 RVA: 0x00091358 File Offset: 0x0008F558
	public void method_24(WeaponDNA weaponDNA_0)
	{
		m_attribute = weaponDNA_0.m_attribute;
		DebugUtils.Log(LogCategory.Gamelogic, " m_attribute is " + (m_attribute != null));
		m_reloadPercentage = FloatAttributeValue.smethod_0(m_attribute.method_1(AttributeType.ReloadPercentage) as FloatAttributeValue);
		m_manufacturer = (ItemManufacturer)IntAttributeValue.smethod_0(m_attribute.method_1(AttributeType.ManufactureType) as IntAttributeValue);
		m_dynamicBulletBurst = IntAttributeValue.smethod_0(m_attribute.method_1(AttributeType.ZoomFiringBurst) as IntAttributeValue);
		m_fixedBulletBurst = IntAttributeValue.smethod_0(m_attribute.method_1(AttributeType.ZoomFiringBurst) as IntAttributeValue);
		m_delayTimeAfterBurst = FloatAttributeValue.smethod_0(m_attribute.method_1(AttributeType.DelayTimeAfterBurst) as FloatAttributeValue);
		for (int i = 0; i < weaponDNA_0.m_subPartsCode.Length; i++)
		{
			SubPartWpn subPartWpn = SubPartWeaponStore.SubPartWeaponStore_0.method_1(weaponDNA_0.m_subPartsCode[i]);
			if (i == 6)
			{
				if (subPartWpn == null)
				{
					DebugUtils.Log(LogCategory.Gamelogic, "SIGHT part is null, dna subpart code is " + weaponDNA_0.m_subPartsCode[i]);
				}
				BuildingPart buildingPart = subPartWpn.m_BuildingPart;
				BuildingKit buildingKit = BuildingKitManager.smethod_0(buildingPart.bkID);
				m_hasScope = buildingKit.method_8(buildingPart.mPart, buildingPart.mFBX) != BuildingKit.emptyPart;
				break;
			}
		}
		if (method_72() != 0)
		{
			m_hasMask = true;
		}
		m_normalView = new PerViewWeaponParam();
		m_normalView.m_AccuracyMax = Mathf.Clamp(FloatAttributeValue.smethod_0(m_attribute.method_1(AttributeType.AccuracyMax) as FloatAttributeValue), 0f, 100f);
		m_normalView.m_AccuracyMin = Mathf.Clamp(FloatAttributeValue.smethod_0(m_attribute.method_1(AttributeType.AccuracyMin) as FloatAttributeValue), 0f, 100f);
		m_normalView.m_AccuracyDecrease = FloatAttributeValue.smethod_0(m_attribute.method_1(AttributeType.AccuracyDecrease) as FloatAttributeValue);
		m_normalView.m_AccuracyRegenerationRateActive = FloatAttributeValue.smethod_0(m_attribute.method_1(AttributeType.AccuracyRegenerationRateActive) as FloatAttributeValue);
		m_normalView.m_AccuracyRegenerationRateOnIdle = FloatAttributeValue.smethod_0(m_attribute.method_1(AttributeType.AccuracyRegenerationRateOnIdle) as FloatAttributeValue);
		m_normalView.m_InnerAccuracyMax = Mathf.Clamp(FloatAttributeValue.smethod_0(m_attribute.method_1(AttributeType.InnerAccuracyMax) as FloatAttributeValue), 0f, 100f);
		m_normalView.m_InnerAccuracyMin = Mathf.Clamp(FloatAttributeValue.smethod_0(m_attribute.method_1(AttributeType.InnerAccuracyMin) as FloatAttributeValue), 0f, 100f);
		m_normalView.m_InnerAccuracyDecrease = FloatAttributeValue.smethod_0(m_attribute.method_1(AttributeType.InnerAccuracyDecrease) as FloatAttributeValue);
		m_normalView.m_InnerAccuracyRegenerationRateActive = FloatAttributeValue.smethod_0(m_attribute.method_1(AttributeType.InnerAccuracyRegenerationRateActive) as FloatAttributeValue);
		m_normalView.m_recoverTime = FloatAttributeValue.smethod_0(m_attribute.method_1(AttributeType.RecoverTime) as FloatAttributeValue);
		m_zoomView = new PerViewWeaponParam();
		m_zoomView.m_AccuracyMax = Mathf.Clamp(FloatAttributeValue.smethod_0(m_attribute.method_1(AttributeType.AccuracyMaxZoom) as FloatAttributeValue), 0f, 100f);
		m_zoomView.m_AccuracyMin = Mathf.Clamp(FloatAttributeValue.smethod_0(m_attribute.method_1(AttributeType.AccuracyMinZoom) as FloatAttributeValue), 0f, 100f);
		m_zoomView.m_AccuracyDecrease = FloatAttributeValue.smethod_0(m_attribute.method_1(AttributeType.AccuracyDecreaseZoom) as FloatAttributeValue);
		m_zoomView.m_AccuracyRegenerationRateActive = FloatAttributeValue.smethod_0(m_attribute.method_1(AttributeType.AccuracyRegenerationRateActiveZoom) as FloatAttributeValue);
		m_zoomView.m_AccuracyRegenerationRateOnIdle = FloatAttributeValue.smethod_0(m_attribute.method_1(AttributeType.AccuracyRegenerationRateOnIdleZoom) as FloatAttributeValue);
		m_zoomView.m_InnerAccuracyMax = Mathf.Clamp(FloatAttributeValue.smethod_0(m_attribute.method_1(AttributeType.InnerAccuracyMax) as FloatAttributeValue), 0f, 100f);
		m_zoomView.m_InnerAccuracyMin = Mathf.Clamp(FloatAttributeValue.smethod_0(m_attribute.method_1(AttributeType.InnerAccuracyMin) as FloatAttributeValue), 0f, 100f);
		m_zoomView.m_InnerAccuracyDecrease = FloatAttributeValue.smethod_0(m_attribute.method_1(AttributeType.InnerAccuracyDecrease) as FloatAttributeValue);
		m_zoomView.m_InnerAccuracyRegenerationRateActive = FloatAttributeValue.smethod_0(m_attribute.method_1(AttributeType.InnerAccuracyRegenerationRateActive) as FloatAttributeValue);
		m_zoomView.m_recoverTime = FloatAttributeValue.smethod_0(m_attribute.method_1(AttributeType.ZoomRecoverTime) as FloatAttributeValue);
		m_wander_manager.m_k_Radius = FloatAttributeValue.smethod_0(m_attribute.method_1(AttributeType.ZoomWanderRadius) as FloatAttributeValue);
		m_wander_manager.m_k_Speed = FloatAttributeValue.smethod_0(m_attribute.method_1(AttributeType.ZoomWanderSpeed) as FloatAttributeValue);
		m_wander_manager.m_k_Accel = FloatAttributeValue.smethod_0(m_attribute.method_1(AttributeType.ZoomWanderAccel) as FloatAttributeValue);
		m_wander_manager.m_k_Decel = FloatAttributeValue.smethod_0(m_attribute.method_1(AttributeType.ZoomWanderDecel) as FloatAttributeValue);
		m_wander_manager.m_k_Accel_Distance = FloatAttributeValue.smethod_0(m_attribute.method_1(AttributeType.ZoomWanderAccelDistance) as FloatAttributeValue);
		m_wander_manager.m_k_Decel_Distance = FloatAttributeValue.smethod_0(m_attribute.method_1(AttributeType.ZoomWanderDecelDistance) as FloatAttributeValue);
		m_normalView.m_InnerAccuracy = FloatAttributeValue.smethod_0(m_attribute.method_1(AttributeType.InnerAccuracyNormal) as FloatAttributeValue);
		m_normalView.m_InnerAccuracyRatio = FloatAttributeValue.smethod_0(m_attribute.method_1(AttributeType.InnerAccuracyRatioNormal) as FloatAttributeValue);
		m_zoomView.m_InnerAccuracy = FloatAttributeValue.smethod_0(m_attribute.method_1(AttributeType.InnerAccuracyZoom) as FloatAttributeValue);
		m_zoomView.m_InnerAccuracyRatio = FloatAttributeValue.smethod_0(m_attribute.method_1(AttributeType.InnerAccuracyRatioZoom) as FloatAttributeValue);
		m_currentView = m_normalView;
		m_currentSpread = m_currentView.m_AccuracyMax;
		m_innerSpread = m_currentSpread * m_currentView.m_InnerAccuracy;
	}
	// Token: 0x06001D76 RID: 7542 RVA: 0x00014CDA File Offset: 0x00012EDA
	public void method_25(int int_0)
	{
		this.m_ammoCount -= int_0;
	}

	// Token: 0x06001D77 RID: 7543 RVA: 0x00014CEA File Offset: 0x00012EEA
	public bool method_26()
	{
		return this.m_ammoCount <= 0;
	}

	// Token: 0x06001D78 RID: 7544 RVA: 0x00014CF8 File Offset: 0x00012EF8
	public bool method_27()
	{
		return this.m_ammoCount == this.method_101();
	}

	// Token: 0x06001D79 RID: 7545 RVA: 0x00091974 File Offset: 0x0008FB74
	public void method_28(int int_0)
	{
		int num = this.method_101();
		this.m_ammoCount = Mathf.Clamp(this.m_ammoCount + int_0, 0, num);
	}

	// Token: 0x06001D7A RID: 7546 RVA: 0x000919A0 File Offset: 0x0008FBA0
	public void method_29()
	{
		bool flag = false;
		if (this.m_ammoCount <= 0)
		{
			EntityPlayer entityPlayer = base.m_owner as EntityPlayer;
			if (entityPlayer != null && entityPlayer.PlayerSkillManage_0.vmethod_13())
			{
				flag = true;
			}
		}
		if (flag)
		{
			this.method_41();
		}
		else
		{
			this.m_ability.method_5("Reload", true, 0);
		}
	}

	// Token: 0x06001D7B RID: 7547 RVA: 0x000919FC File Offset: 0x0008FBFC
	public void method_30()
	{
		if (!this.m_isReadyToFire)
		{
			return;
		}
		TargetingManager prop_ = MonoSingleton<TargetingManager>.Instance;
		Entity aimedEntity = prop_.m_aimedEntity;
		EntityNpc entityNpc = prop_.m_aimedEntity as EntityNpc;
		int num = ((aimedEntity != null) ? aimedEntity.vmethod_0() : 0);
		Vector3 vector = ((aimedEntity != null) ? (prop_.m_lastAimingRay.origin + prop_.m_lastAimingRay.direction * prop_.m_distanceToAimed) : Vector3.zero);
		int num2 = -1;
		int num3 = 0;
		if (prop_.m_aimedCollider != null)
		{
			WeakPoint component = prop_.m_aimedCollider.GetComponent<WeakPoint>();
			if (component != null)
			{
				num2 = (int)component.method_3();
				if (entityNpc != null && entityNpc.vmethod_21() != null)
				{
					num3 = (int)entityNpc.vmethod_21().method_11(component);
				}
			}
		}
		object[] array = new object[] { num, vector, num2, num3 };
		if (this.m_dna.m_type == WeaponType.ShotGun)
		{
			if (this.method_33())
			{
				base.photonView.method_4("RPC_ReportRaycastHit", PhotonTargets.MasterClient, array);
				this.actionBeforeResolve = true;
				this.m_ability.method_5("Fire", true, this.m_randomRecoilIndex);
				return;
			}
		}
		else if (this.m_dna.m_type == WeaponType.SniperRifle)
		{
			if (this.method_33())
			{
				EntityPlayer entityPlayer = base.m_owner as EntityPlayer;
				if (entityPlayer != null && entityPlayer.method_153())
				{
					entityPlayer.method_154();
				}
				base.photonView.method_4("RPC_ReportRaycastHit", PhotonTargets.MasterClient, array);
				this.actionBeforeResolve = true;
				this.m_ability.method_5("Fire", true, this.m_randomRecoilIndex);
				return;
			}
		}
		else
		{
			base.photonView.method_4("RPC_ReportRaycastHit", PhotonTargets.MasterClient, array);
			this.m_ability.method_5("Fire", false, this.m_randomRecoilIndex);
		}
	}

	// Token: 0x06001D7C RID: 7548 RVA: 0x00091BE8 File Offset: 0x0008FDE8
	public void method_31(global::Action.ActionMessage actionMessage_0)
	{
		this.m_randomRecoilIndex = (int)actionMessage_0.m_param;
		this.m_firstFireFrame = actionMessage_0.m_frameNum;
		this.m_firstFireAmmo = this.m_ammoCount;
		this.m_bulletOffsetStart = 0f;
		if (this.m_nextFireTime < Time.fixedTime && Time.fixedTime - this.m_nextFireTime < Time.fixedDeltaTime)
		{
			this.m_bulletOffsetStart = this.m_nextFireTime - (Time.fixedTime - Time.fixedDeltaTime);
		}
		if (this.m_nextFireTime > Time.fixedTime)
		{
			this.m_bulletOffsetStart = this.m_nextFireTime - (Time.fixedTime - Time.fixedDeltaTime);
		}
	}

	// Token: 0x06001D7D RID: 7549 RVA: 0x00091C88 File Offset: 0x0008FE88
	public void method_32(global::Action.ActionMessage actionMessage_0, float float_0)
	{
		this.actionBeforeResolve = false;
		if (this.m_firstFireAmmo <= 0)
		{
			return;
		}
		int num = 0;
		float num2 = 1f / this.method_92();
		float num3 = this.m_bulletOffsetStart;
		float num4 = (float)(actionMessage_0.m_frameNum - this.m_firstFireFrame) * Time.fixedDeltaTime;
		if (actionMessage_0.m_frameNum - this.m_firstFireFrame == 0)
		{
			num3 += num2;
			num++;
		}
		else
		{
			while ((double)num3 < (double)num4 - 0.0001)
			{
				num3 += num2;
				num++;
			}
		}
		float num5 = Time.fixedTime + num3 - num4;
		int num6 = this.m_firstFireAmmo - num;
		if (this.m_ammoCount < num6)
		{
			this.m_ammoCount = num6;
			this.m_nextFireTime = num5;
			return;
		}
		if (this.m_ammoCount > num6)
		{
			if (this.m_ammoCount - num6 > 1000)
			{
				DebugUtils.LogError(LogCategory.Gamelogic, string.Concat(new object[] { "Ammo difference too big: RightAmmo ", num6, " m_ammoCount:", this.m_ammoCount }));
				if (base.m_owner != null)
				{
					DebugUtils.LogError(LogCategory.Gamelogic, "Ammo couting logic is wrong on " + base.m_owner.m_name + " weapon:" + this.m_name);
				}
			}
			int num7 = 0;
			while (num7 < this.m_ammoCount - num6 && num7 < 1000)
			{
				int num8 = IntAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.WeaponProjectilesPerShot) as IntAttributeValue);
				this.method_25(1);
				this.method_35(num8, float_0, num2);
				num7++;
			}
		}
	}

	// Token: 0x06001D7E RID: 7550 RVA: 0x00014D08 File Offset: 0x00012F08
	public bool method_33()
	{
		return this.m_nextFireTime < Time.fixedTime && this.m_ammoCount > 0 && !this.actionBeforeResolve;
	}

	// Token: 0x06001D7F RID: 7551 RVA: 0x00091E08 File Offset: 0x00090008
	public void method_34(float float_0)
	{
		if (Time.fixedTime <= this.m_lastResolveTime)
		{
			return;
		}
		this.m_lastResolveTime = Time.fixedTime;
		float num = this.method_92();
		float num2 = 1f / num;
		int i = 0;
		num2 = 1f / num;
		if (Time.fixedTime - this.m_nextFireTime > Time.fixedDeltaTime || this.m_nextFireTime == 0f)
		{
			this.m_nextFireTime = Time.fixedTime - Time.fixedDeltaTime;
		}
		if (this.m_nextFireTime < Time.fixedTime)
		{
			i = (int)((Time.fixedTime - this.m_nextFireTime) / num2) + 1;
		}
		i = Mathf.Min(i, this.m_ammoCount);
		int num3 = i;
		int num4 = IntAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.WeaponProjectilesPerShot) as IntAttributeValue);
		EntityPlayer entityPlayer = base.m_owner as EntityPlayer;
		if (entityPlayer != null && entityPlayer.PlayerSkillManage_0.vmethod_9(this))
		{
			int random_index = this.m_random_index;
			this.m_random_index = random_index + 1;
			float num5 = Utils.StaticRandom.smethod_0(random_index);
			num3 = entityPlayer.PlayerSkillManage_0.vmethod_10(i, num5);
			num4 = entityPlayer.PlayerSkillManage_0.vmethod_11(num4);
		}
		this.method_25(num3);
		if (this.m_burstFireStage == EntityWeapon.BurstFireStage.Bursting)
		{
			this.m_dynamicBulletBurst -= num3;
			this.m_BurstFinishTime = Time.fixedTime;
			if (this.m_dynamicBulletBurst <= 0 || this.m_ammoCount <= 0)
			{
				this.m_burstFireStage = EntityWeapon.BurstFireStage.NoneBurst;
			}
		}
		while (i > 0)
		{
			this.method_35(num4, float_0, num2);
			i--;
		}
	}

	// Token: 0x06001D80 RID: 7552 RVA: 0x00091F78 File Offset: 0x00090178
	private void method_35(int int_0, float float_0, float float_1)
	{
		this.method_84(this.m_nextFireTime);
		if (base.m_owner == null)
		{
			return;
		}
		if (this.m_dna == null)
		{
			return;
		}
		EntityPlayer entityPlayer = base.m_owner as EntityPlayer;
		if (int_0 > 1)
		{
			for (int i = 0; i < int_0; i++)
			{
				AttackInfo attackInfo = new AttackInfo(AttackSubType.ProjectileGeneric);
				if (this.m_dna != null)
				{
					if (this.m_dna.method_1() == WeaponType.ShotGun)
					{
						attackInfo.m_subType = AttackSubType.ProjectileShotgun;
					}
					if (this.m_dna.method_1() == WeaponType.SniperRifle)
					{
						attackInfo.m_subType = AttackSubType.ProjectileSniper;
					}
					if (this.m_dna.method_1() == WeaponType.RepeaterPistol)
					{
						attackInfo.m_subType = AttackSubType.ProjectilePistol;
					}
					if (this.m_dna.method_1() == WeaponType.CombatRifle)
					{
						attackInfo.m_subType = AttackSubType.ProjectileCombatRifle;
					}
				}
				attackInfo.m_attacker = this.vmethod_0();
				if (base.m_owner is EntityNpcSoldierTurret)
				{
					attackInfo.m_owner = (base.m_owner as EntityNpcSoldierTurret).m_relatedPlayer.vmethod_0();
					attackInfo.m_subType = AttackSubType.SkillTurretProjectile;
				}
				else
				{
					attackInfo.m_owner = base.m_owner.vmethod_0();
				}
				attackInfo.m_timeStamp = (double)(Time.time - float_0);
				attackInfo.m_origin = this.vmethod_28();
				attackInfo.m_direction = this.method_81(1f, 1f);
				int num = (int)FloatAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.WeaponDamage) as FloatAttributeValue);
				if (base.m_owner is EntityNpcSoldierTurret)
				{
					EntityPlayer relatedPlayer = (base.m_owner as EntityNpcSoldierTurret).m_relatedPlayer;
					if (relatedPlayer != null)
					{
						num = PlayerSkillManage.smethod_0(relatedPlayer.vmethod_3(), (float)num) * (int)relatedPlayer.method_72();
					}
				}
				if (entityPlayer != null)
				{
					num = entityPlayer.method_139(num);
				}
				int num2 = num / int_0;
				attackInfo.m_damagePoint = num2;
				MonoSingleton<AttackManager>.Instance.method_1(attackInfo);
				this.OnAttackToAt(attackInfo);
			}
		}
		else if (int_0 == 1)
		{
			AttackInfo attackInfo2 = new AttackInfo(AttackSubType.ProjectileGeneric);
			if (this.m_dna != null)
			{
				if (this.m_dna.method_1() == WeaponType.ShotGun)
				{
					attackInfo2.m_subType = AttackSubType.ProjectileShotgun;
				}
				if (this.m_dna.method_1() == WeaponType.SniperRifle)
				{
					attackInfo2.m_subType = AttackSubType.ProjectileSniper;
				}
				if (this.m_dna.method_1() == WeaponType.RepeaterPistol)
				{
					attackInfo2.m_subType = AttackSubType.ProjectilePistol;
				}
				if (this.m_dna.method_1() == WeaponType.CombatRifle)
				{
					attackInfo2.m_subType = AttackSubType.ProjectileCombatRifle;
				}
			}
			attackInfo2.m_attacker = this.vmethod_0();
			if (base.m_owner is EntityNpcSoldierTurret)
			{
				attackInfo2.m_owner = (base.m_owner as EntityNpcSoldierTurret).m_relatedPlayer.vmethod_0();
				attackInfo2.m_subType = AttackSubType.SkillTurretProjectile;
			}
			else
			{
				attackInfo2.m_owner = base.m_owner.vmethod_0();
			}
			attackInfo2.m_timeStamp = (double)(Time.time - float_0);
			attackInfo2.m_origin = this.vmethod_28();
			attackInfo2.m_direction = this.method_81(1f, 1f);
			attackInfo2.m_damagePoint = (int)FloatAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.WeaponDamage) as FloatAttributeValue);
			if (base.m_owner is EntityNpcSoldierTurret)
			{
				EntityPlayer relatedPlayer2 = (base.m_owner as EntityNpcSoldierTurret).m_relatedPlayer;
				if (relatedPlayer2 != null)
				{
					int num3 = (base.m_owner as EntityNpcSoldierTurret).m_relatedPlayer.vmethod_3();
					attackInfo2.m_damagePoint = PlayerSkillManage.smethod_0(num3, (float)attackInfo2.m_damagePoint) * (int)relatedPlayer2.method_72();
				}
			}
			else if (entityPlayer != null)
			{
				attackInfo2.m_damagePoint = entityPlayer.method_139(attackInfo2.m_damagePoint);
			}
			MonoSingleton<AttackManager>.Instance.method_1(attackInfo2);
			this.OnAttackToAt(attackInfo2);
		}
		else
		{
			DebugUtils.LogError(LogCategory.Gamelogic, this.m_dna.method_4() + "'s m_pellet < 0 !!!!");
		}
		this.m_currentSpread = Mathf.Clamp(this.m_currentSpread + this.m_currentView.m_AccuracyDecrease, this.m_currentView.m_AccuracyMax, this.m_currentView.m_AccuracyMin);
		this.m_innerSpread = this.m_currentSpread * this.m_currentView.m_InnerAccuracy;
		this.m_lastFireTime = this.m_nextFireTime;
		this.m_nextFireTime += float_1;
		if (this.method_80())
		{
			this.method_86();
		}
	}

	// Token: 0x06001D81 RID: 7553 RVA: 0x00014D2B File Offset: 0x00012F2B
	public bool method_36()
	{
		return this.m_manufacturer == ItemManufacturer.Dahl && this.m_isAimActive && this.m_fixedBulletBurst > 0;
	}

	// Token: 0x06001D82 RID: 7554 RVA: 0x00092378 File Offset: 0x00090578
	public bool method_37()
	{
		if (this.m_manufacturer == ItemManufacturer.Dahl && this.m_isAimActive && this.m_fixedBulletBurst > 0 && this.m_burstFireStage != EntityWeapon.BurstFireStage.Bursting && this.m_BurstFinishTime + this.m_delayTimeAfterBurst < Time.fixedTime)
		{
			this.method_38();
			return true;
		}
		return false;
	}

	// Token: 0x06001D83 RID: 7555 RVA: 0x00014D4A File Offset: 0x00012F4A
	public void method_38()
	{
		this.m_burstFireStage = EntityWeapon.BurstFireStage.Bursting;
		this.m_dynamicBulletBurst = IntAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.ZoomFiringBurst) as IntAttributeValue);
	}

	// Token: 0x06001D84 RID: 7556 RVA: 0x00014D70 File Offset: 0x00012F70
	public bool method_39()
	{
		return this.m_burstFireStage == EntityWeapon.BurstFireStage.Bursting;
	}

	// Token: 0x06001D85 RID: 7557 RVA: 0x000923C8 File Offset: 0x000905C8
	private void OnAttackToAt(AttackInfo at)
	{
		PlayerInfoSync localPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer();
		if (localPlayer != null)
		{
			EntityPlayer entityPlayer = localPlayer.GetEntity() as EntityPlayer;
			if (entityPlayer != null && entityPlayer.method_45() != null && !MonoSingleton<AppManager>.Instance.m_noimpact && MonoSingleton<ImpactManager>.Instance != null)
			{
				MonoSingleton<ImpactManager>.Instance.method_5(at.m_origin, at.m_direction, this.vmethod_1());
			}
			if (this.m_shotTrace != null)
			{
				if (base.m_owner is EntityPlayer)
				{
					Transform transform = this.method_46();
					if (transform != null && this.m_shotTraceGameObject != null)
					{
						this.m_shotTraceGameObject.transform.position = transform.position;
						RaycastHit raycastHit;
						if (Physics.Raycast(at.m_origin, at.m_direction, out raycastHit, 3000f, TargetingService.Int32_0))
						{
							this.m_shotTraceGameObject.transform.rotation = Quaternion.LookRotation(raycastHit.point - this.m_shotTraceGameObject.transform.position, Vector3.up);
						}
						else
						{
							this.m_shotTraceGameObject.transform.rotation = Quaternion.LookRotation(at.m_origin + at.m_direction * 3000f - this.m_shotTraceGameObject.transform.position, Vector3.up);
						}
					}
				}
				this.m_shotTrace.Play();
			}
		}
		if (base.m_owner == null)
		{
			return;
		}
		if (!base.m_owner.vmethod_26())
		{
			AnimationManager animationManager = base.m_owner.vmethod_12();
			if (animationManager != null)
			{
				animationManager.OnAttack();
			}
		}
		else
		{
			if (base.m_owner.vmethod_8() == Entity.EntityType.Player)
			{
			}
			base.m_owner.BroadcastMessage("OnAttack", SendMessageOptions.DontRequireReceiver);
			base.m_owner.BroadcastMessage("TriggerEffectByName", "OnAttack", SendMessageOptions.DontRequireReceiver);
		}
	}

	// Token: 0x06001D86 RID: 7558 RVA: 0x000925BC File Offset: 0x000907BC
	public void method_40(float float_0, global::Action.ActionMessage actionMessage_0)
	{
		if (base.m_owner)
		{
			if (!base.m_owner.vmethod_26())
			{
				AnimationManager animationManager = base.m_owner.vmethod_12();
				if (animationManager)
				{
					base.m_owner.vmethod_12().OnReload(float_0);
				}
			}
			else
			{
				base.m_owner.BroadcastMessage("OnReload", float_0, SendMessageOptions.DontRequireReceiver);
			}
		}
	}

	// Token: 0x06001D87 RID: 7559 RVA: 0x00014D7B File Offset: 0x00012F7B
	public void OnReloadAnimDone()
	{
		this.method_41();
	}

	// Token: 0x06001D88 RID: 7560 RVA: 0x00092624 File Offset: 0x00090824
	public void method_41()
	{
		if (base.m_owner && base.m_owner.vmethod_19())
		{
			EquipmentInventoryEntity equipmentInventoryEntity = base.m_owner.vmethod_19();
			int num = Mathf.Min(this.method_101() - this.m_ammoCount, equipmentInventoryEntity.vmethod_15(this.m_attribute.m_weaponType));
			equipmentInventoryEntity.vmethod_16(equipmentInventoryEntity.vmethod_15(this.m_attribute.m_weaponType) - num, this.m_attribute.m_weaponType);
			this.m_ammoCount += num;
		}
	}

	// Token: 0x06001D89 RID: 7561 RVA: 0x000926B4 File Offset: 0x000908B4
	public void method_42()
	{
		if (base.m_owner && base.m_owner.vmethod_19())
		{
			EquipmentInventoryEntity equipmentInventoryEntity = base.m_owner.vmethod_19();
			int num = this.m_ammoCount + equipmentInventoryEntity.vmethod_15(this.m_attribute.m_weaponType);
			int num2 = Mathf.Min(this.method_101(), num);
			int num3 = num - num2;
			equipmentInventoryEntity.vmethod_16(num3, this.m_attribute.m_weaponType);
			this.m_ammoCount = num2;
		}
	}

	// Token: 0x06001D8A RID: 7562 RVA: 0x00014D83 File Offset: 0x00012F83
	public Transform method_43()
	{
		if (base.gameObject.transform.childCount > 0)
		{
			return base.gameObject.transform.GetChild(0).Find("b_body");
		}
		return null;
	}

	// Token: 0x06001D8B RID: 7563 RVA: 0x00092730 File Offset: 0x00090930
	public Transform method_44(string string_0)
	{
		Transform transform = this.method_43();
		return (!(transform == null)) ? transform.Find(string_0) : null;
	}

	// Token: 0x06001D8C RID: 7564 RVA: 0x00092758 File Offset: 0x00090958
	public Transform method_45()
	{
		if (this.method_99() == WeaponType.ShotGun)
		{
			int num = (int)this.m_dna.method_15(WeaponSubPart.ACC);
			num++;
			foreach (Transform transform in base.gameObject.transform.GetComponentsInChildren<Transform>(true))
			{
				if (transform.gameObject.name == "b_element_" + num && num == 5)
				{
					return transform;
				}
			}
		}
		return null;
	}

	// Token: 0x06001D8D RID: 7565 RVA: 0x000927D0 File Offset: 0x000909D0
	public Transform method_46()
	{
		int num = (int)this.m_dna.method_15(WeaponSubPart.BARREL);
		num++;
		foreach (Transform transform in base.gameObject.transform.GetComponentsInChildren<Transform>(true))
		{
			if (transform.gameObject.name == "b_muzzle_flash_" + num)
			{
				return transform;
			}
		}
		string text = "b_muzzle_flash_" + num;
		return this.method_44(text);
	}

	// Token: 0x06001D8E RID: 7566 RVA: 0x00092850 File Offset: 0x00090A50
	public Transform method_47()
	{
		foreach (Transform transform in base.gameObject.transform.GetComponentsInChildren<Transform>(true))
		{
			if (transform.gameObject.name == "b_bullet_ejection")
			{
				return transform;
			}
		}
		string text = "b_bullet_ejection";
		return this.method_44(text);
	}

	// Token: 0x06001D8F RID: 7567 RVA: 0x0000311B File Offset: 0x0000131B
	public void method_48()
	{
	}

	// Token: 0x06001D90 RID: 7568 RVA: 0x000928A8 File Offset: 0x00090AA8
	public void method_49()
	{
		if (!this.startedInstanciatingModel)
		{
			this.startedInstanciatingModel = true;
			DebugUtils.Log(LogCategory.Gamelogic, "weapon InstanciateModel start " + this.m_dna);
			base.StartCoroutine(this.method_50());
			DebugUtils.Log(LogCategory.Gamelogic, "weapon InstanciateModel finish " + this.m_dna);
		}
	}

	// Token: 0x06001D91 RID: 7569 RVA: 0x00092900 File Offset: 0x00090B00
	// method 50 here builds the gun, but im unsure exactly when, seemingly just when a gun is built in general.
	private IEnumerator method_50()
	{
		yield return StartCoroutine(ns0.MonoSingleton<WeaponFactory>.Instance.method_4(m_dna, base.gameObject));
		BoxCollider boxColl = base.gameObject.GetComponent<BoxCollider>();
		if (boxColl == null)
		{
			boxColl = base.gameObject.AddComponent<BoxCollider>();
		}
		if (boxColl != null)
		{
			boxColl.size = new Vector3(0.1f, 0.1f, 0.1f);
			boxColl.center = new Vector3(0f, 0f, 0.3f);
			SkinnedMeshRenderer render = base.gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
			// above we find the skinned renderer which is a child of the gun, so maybe this can assist in a lter fix with the invis gun stuff. as of now it only fixes on swap
			if (render != null)
			{
				boxColl.size = new Vector3(Mathf.Max(0.1f, render.localBounds.extents.x * 2f), Mathf.Max(0.1f, render.localBounds.extents.y * 2f), Mathf.Max(0.1f, render.localBounds.extents.z * 2f));
				boxColl.center = render.localBounds.center;
				smethod_2(base.gameObject, vmethod_1());
			}
		}
		if (m_collisionManager != null)
		{
			m_collisionManager.method_0(bool_0: false);
		}
		m_isReady = true;
		DebugUtils.Log(LogCategory.Gamelogic, "InstanciateModel weapon is ready, weapon " + m_dna);
	}
	// Token: 0x06001D92 RID: 7570 RVA: 0x0009291C File Offset: 0x00090B1C
	// this method appears to be the holstering featrue, hence why it disables the collider and rigidbody of the weap
	public void method_51(Entity entity_0)
	{
		if (entity_0 == null)
		{
			return;
		}
		base.method_15(entity_0);
		Skeleton skeleton = entity_0.vmethod_17();
		if (skeleton == null)
		{
			return;
		}
		base.transform.parent = skeleton.method_5(this.method_99());
		base.transform.localPosition = Vector3.zero;
		base.transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
		Collider component = base.GetComponent<Collider>();
		if (component != null)
		{
			component.enabled = false;
		}
		Rigidbody component2 = base.GetComponent<Rigidbody>();
		if (component2 != null)
		{
			global::UnityEngine.Object.Destroy(component2);
		}
		base.gameObject.SetActive(true);
	}

	// Token: 0x06001D93 RID: 7571 RVA: 0x000929CC File Offset: 0x00090BCC
	private void method_52()
	{
		SkinnedMeshRenderer componentInChildren = base.GetComponentInChildren<SkinnedMeshRenderer>();
		if (componentInChildren)
		{
			Material material = componentInChildren.material;
			if (material)
			{
				material.SetTexture("_Cube", MonoSingleton<LevelLoadingManager>.Instance.m_levelCubemap);
			}
		}
	}

	// Token: 0x06001D94 RID: 7572 RVA: 0x00092A0C File Offset: 0x00090C0C
	private void method_53(Entity entity_0)
	{
		if (this.m_magazineInitialized)
		{
			return;
		}
		if (entity_0.vmethod_8() == Entity.EntityType.Player && entity_0 as EntityPlayer != null && entity_0.vmethod_19() as EquipmentInventoryEntityPlayer != null)
		{
			if (!entity_0.vmethod_26())
			{
				return;
			}
			EquipmentInventoryEntityPlayer equipmentInventoryEntityPlayer = entity_0.vmethod_19() as EquipmentInventoryEntityPlayer;
			int reserve = equipmentInventoryEntityPlayer.vmethod_15(this.method_99());
			int clip = (entity_0 as EntityPlayer).method_57(IntAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.ClipSize) as IntAttributeValue));
			int loaded = Mathf.Min(reserve, clip);
			this.m_ammoCount = loaded;
			equipmentInventoryEntityPlayer.vmethod_16(reserve - loaded, this.method_99());
		}
		else
		{
			this.m_ammoCount = this.method_101();
		}
		this.m_magazineInitialized = true;
		this.m_isDataDirty = true;
	}

	// Token: 0x06001D95 RID: 7573 RVA: 0x00092AE4 File Offset: 0x00090CE4
	public void method_54(Entity entity_0)
	{
		if (entity_0 == null)
		{
			return;
		}
		DebugUtils.Log(LogCategory.Gamelogic, "character not null");
		base.method_15(entity_0);
		this.method_53(entity_0);
		if (entity_0.vmethod_8() != Entity.EntityType.Player)
		{
			AnimationManagerFSM component = entity_0.GetComponent<AnimationManagerFSM>();
			if (component != null)
			{
				component.m_animationEventController = entity_0.GetComponentInChildren<AnimationEventController>();
			}
		}
		if (!MonoSingleton<AppManager>.Instance.OnlineHostMinResMode)
		{
			if (entity_0.vmethod_8() == Entity.EntityType.Player)
			{
				this.method_65();
				if (base.m_owner != null && base.m_owner.vmethod_26())
				{
					this.method_55();
				}
			}
			else
			{
				this.method_58(entity_0);
			}
		}
		if (entity_0.vmethod_8() == Entity.EntityType.Player)
		{
			this.m_relatedPlayer = (EntityPlayer)entity_0;
			DebugUtils.Log(LogCategory.Gamelogic, "set relatedplayer");
			if (base.m_owner != null && !base.m_owner.vmethod_26())
			{
				this.method_52();
			}
		}
		else if (entity_0.vmethod_8() == Entity.EntityType.Npc)
		{
			this.method_52();
		}
		Skeleton skeleton = entity_0.vmethod_17();
		if (skeleton == null)
		{
			return;
		}
		DebugUtils.Log(LogCategory.Gamelogic, "character skeleton not null");
		base.transform.parent = skeleton.method_4(this.method_99());
		base.transform.localPosition = Vector3.zero;
		base.transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
		base.transform.localScale = Vector3.one;
		DebugUtils.Log(LogCategory.Gamelogic, string.Concat(new object[]
		{
			"transform.parent postion x ",
			base.transform.parent.position.x,
			" y ",
			base.transform.parent.position.y,
			" z ",
			base.transform.parent.position.z
		}));
		DebugUtils.Log(LogCategory.Gamelogic, string.Concat(new object[]
		{
			"transform postion x ",
			base.transform.position.x,
			" y ",
			base.transform.position.y,
			" z ",
			base.transform.position.z
		}));
		Collider component2 = base.GetComponent<Collider>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		Rigidbody component3 = base.GetComponent<Rigidbody>();
		if (component3 != null)
		{
			global::UnityEngine.Object.Destroy(component3);
		}
		base.gameObject.SetActive(false);
		DebugUtils.Log(LogCategory.Gamelogic, "game object active state is " + base.gameObject.activeInHierarchy);
		base.transform.localRotation = this.originalRotation;
		this.vmethod_65();
		this.m_isReadyToFire = true;
	}

	// Token: 0x06001D96 RID: 7574 RVA: 0x00092DBC File Offset: 0x00090FBC
	public void method_55()
	{
		float num = FloatAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.FirstPersonMeshFOV) as FloatAttributeValue);
		this.method_56(num);
	}

	// Token: 0x06001D97 RID: 7575 RVA: 0x00092DE8 File Offset: 0x00090FE8
	public void method_56(float float_0)
	{
		EntityPlayer entityPlayer = base.m_owner as EntityPlayer;
		if (entityPlayer)
		{
			WeaponCameraControl componentInChildren = entityPlayer.GetComponentInChildren<WeaponCameraControl>();
			if (componentInChildren)
			{
				componentInChildren.method_2(float_0);
				SkinnedMeshRenderer componentInChildren2 = base.GetComponentInChildren<SkinnedMeshRenderer>();
				if (componentInChildren2)
				{
					if (this.m_fpWpnClearZMat == null)
					{
						this.m_fpWpnClearZMat = new Material(Shader.Find("Custom/BOL_ClearZFov"));
					}
					if (this.m_thrWpnMat == null)
					{
						this.m_thrWpnMat = global::UnityEngine.Object.Instantiate(componentInChildren2.material) as Material;
					}
					Material material = componentInChildren2.material;
					material.shader = Shader.Find("Custom/BOL_Wpn_MaskReflectFov");
					material.CopyPropertiesFromMaterial(this.m_thrWpnMat);
					material.SetMatrix("_ProjMat", componentInChildren.method_0());
					material.SetTexture("_Cube", MonoSingleton<LevelLoadingManager>.Instance.m_levelCubemap);
					componentInChildren2.materials = new Material[] { material, this.m_fpWpnClearZMat };
					this.m_fpWpnClearZMat.SetMatrix("_ProjMat", componentInChildren.method_0());
					componentInChildren2.castShadows = false;
				}
			}
		}
	}

	// Token: 0x06001D98 RID: 7576 RVA: 0x00092F00 File Offset: 0x00091100
	public void method_57(Entity entity_0)
	{
		if (base.m_owner != null && base.m_owner.vmethod_26())
		{
			SkinnedMeshRenderer[] componentsInChildren = base.GetComponentsInChildren<SkinnedMeshRenderer>(true);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				Material material = componentsInChildren[i].material;
				material.shader = Shader.Find("Custom/BOL_Wpn_MaskReflect");
				material.CopyPropertiesFromMaterial(this.m_thrWpnMat);
				material.SetTexture("_Cube", MonoSingleton<LevelLoadingManager>.Instance.m_levelCubemap);
				componentsInChildren[i].materials = new Material[] { material };
			}
			global::UnityEngine.Object.Destroy(this.m_thrWpnMat);
			this.m_thrWpnMat = null;
		}
		(entity_0 as EntityPlayer).m_equipedWeapon = null;
		this.m_relatedPlayer = null;
		base.gameObject.SetActive(true);
		base.method_15(null);
		base.transform.parent = MonoSingleton<EntityManager>.Instance.m_entityDirectory.transform;
		this.method_66();
	}

	// Token: 0x06001D99 RID: 7577 RVA: 0x00092FE8 File Offset: 0x000911E8
	private void OnCollisionStay(Collision collision)
	{
		if (collision.contacts.Length >= 4 && (collision.collider is TerrainCollider || collision.gameObject.layer == LayerMask.NameToLayer("Walkable")) && this.m_rigidBody != null)
		{
			this.m_rigidBody.Sleep();
		}
	}

	// Token: 0x06001D9A RID: 7578 RVA: 0x00093040 File Offset: 0x00091240
	private void method_58(Entity entity_0)
	{
		if (MonoSingleton<AppManager>.Instance.OnlineHostMinResMode)
		{
			return;
		}
		AnimationEventController componentInChildren = entity_0.GetComponentInChildren<AnimationEventController>();
		if (componentInChildren == null)
		{
			return;
		}
		Transform transform = this.method_46();
		if (transform == null)
		{
			DebugUtils.LogError(LogCategory.Gamelogic, "can't find muzzle flash");
			return;
		}
		WeaponType weaponType = this.method_99();
		string text = EntityWeapon.smethod_5(this.method_99(), this.vmethod_1());
		string text2;
		string text3;
		if (weaponType != WeaponType.SMG)
		{
			if (weaponType != WeaponType.RepeaterPistol)
			{
				if (weaponType == WeaponType.ShotGun)
				{
					text2 = "Particles/PTL_Shotgun_Muzzle Flash_NPC";
					text3 = null;
					goto IL_0098;
				}
				if (weaponType == WeaponType.SniperRifle)
				{
					text2 = "Particles/PTL_Sniper_Muzzle_Flash_NPC";
					text3 = null;
					goto IL_0098;
				}
				text2 = "Particles/PTL_Smg_Muzzle Flash NPC";
				text3 = null;
				goto IL_0098;
			}
		}
		text2 = "Particles/PTL_Smg_Muzzle Flash NPC";
		text3 = "Particles/PTL_Shooting Track_Continuous";
		IL_0098:
		GameObject gameObject = (GameObject)global::UnityEngine.Object.Instantiate(ResourcesLoader.smethod_0(text2));
		if (gameObject != null)
		{
			gameObject.transform.parent = transform;
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.transform.localRotation = Quaternion.identity;
			if (weaponType == WeaponType.ShotGun)
			{
				gameObject.transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
			}
			if (weaponType == WeaponType.SniperRifle)
			{
				gameObject.transform.localRotation = Quaternion.Euler(0f, 0f, 180f);
			}
			componentInChildren.m_muzzleFlash = gameObject.GetComponent<ParticleSystem>();
			componentInChildren.m_muzzleFlash.loop = true;
			this.m_flashMuzzle = gameObject.particleSystem;
			this.m_flashMuzzle.loop = false;
			this.m_flashMuzzle.gameObject.SetActive(false);
		}
		if (weaponType == WeaponType.SniperRifle)
		{
			GameObject gameObject2 = (GameObject)global::UnityEngine.Object.Instantiate(ResourcesLoader.smethod_0("Particles/PTL_Sniper_Muzzle_Resources"));
			if (gameObject2 != null)
			{
				gameObject2.transform.parent = transform;
				gameObject2.transform.localPosition = Vector3.zero;
				componentInChildren.m_sniperLight = gameObject2.particleSystem;
				componentInChildren.m_sniperLight.loop = true;
			}
			GameObject gameObject3 = (GameObject)global::UnityEngine.Object.Instantiate(ResourcesLoader.smethod_0("Particles/PTL_Sniper_Camera_Glow"));
			if (gameObject3 != null)
			{
				gameObject3.transform.parent = transform;
				gameObject3.transform.localPosition = Vector3.zero;
				gameObject3.transform.localRotation = Quaternion.identity;
				componentInChildren.m_cameraGlow = gameObject3;
				componentInChildren.m_cameraGlow.SetActive(false);
			}
		}
		if (text3 != null)
		{
			this.m_shotTraceGameObject = (GameObject)global::UnityEngine.Object.Instantiate(ResourcesLoader.smethod_0(text3));
			if (this.m_shotTraceGameObject != null)
			{
				this.m_shotTraceGameObject.transform.parent = transform;
				this.m_shotTraceGameObject.transform.localPosition = Vector3.zero;
				this.m_shotTraceGameObject.transform.localRotation = Quaternion.AngleAxis(90f, Vector3.right);
				componentInChildren.m_coneFlash = this.m_shotTraceGameObject.GetComponent<ParticleSystem>();
				componentInChildren.m_coneFlash.loop = true;
				this.m_shotTrace = this.m_shotTraceGameObject.particleSystem;
				this.m_shotTrace.loop = false;
			}
		}
		GameObject gameObject4 = (GameObject)global::UnityEngine.Object.Instantiate(ResourcesLoader.smethod_0(text));
		if (gameObject4 != null)
		{
			gameObject4.transform.parent = transform;
			gameObject4.transform.localPosition = Vector3.zero;
			gameObject4.transform.localRotation = Quaternion.identity;
			componentInChildren.m_muzzleLight = gameObject4.GetComponent<Animation>();
			componentInChildren.m_muzzleLight.wrapMode = WrapMode.Loop;
			this.m_muzzleFlashLight = gameObject4.animation;
			this.m_muzzleFlashLight.wrapMode = WrapMode.Once;
		}
		if (weaponType == WeaponType.SMG)
		{
			this.method_62(transform);
		}
	}

	// Token: 0x06001D9B RID: 7579 RVA: 0x000933B4 File Offset: 0x000915B4
	private void method_59(GameObject gameObject_0, Transform transform_0)
	{
		if (MonoSingleton<AppManager>.Instance.OnlineHostMinResMode)
		{
			return;
		}
		if (gameObject_0 == null)
		{
			DebugUtils.LogError(LogCategory.Gamelogic, "*****No flashMuzzle for the weapon*****");
			return;
		}
		gameObject_0.name = "flashMuzzle";
		gameObject_0.transform.parent = transform_0;
		gameObject_0.transform.localPosition = Vector3.zero;
		gameObject_0.transform.localEulerAngles = new Vector3(0f, 180f, 180f);
		ParticleSystem component = gameObject_0.GetComponent<ParticleSystem>();
		Renderer renderer = component.renderer;
		if (renderer != null)
		{
			if (base.m_owner.vmethod_26())
			{
				WeaponCameraControl componentInChildren = base.m_owner.GetComponentInChildren<WeaponCameraControl>();
				Material material = renderer.material;
				if (componentInChildren && material)
				{
					material.SetMatrix("_ProjMat", componentInChildren.method_0());
				}
			}
			else
			{
				Shader shader = Shader.Find("Particles/Additive");
				ParticleSystem[] componentsInChildren = base.GetComponentsInChildren<ParticleSystem>();
				foreach (ParticleSystem particleSystem in componentsInChildren)
				{
					foreach (Material material2 in particleSystem.renderer.materials)
					{
						material2.shader = shader;
					}
					particleSystem.renderer.material.shader = shader;
				}
			}
		}
	}

	// Token: 0x06001D9C RID: 7580 RVA: 0x00093508 File Offset: 0x00091708
	private void method_60(GameObject gameObject_0, Transform transform_0)
	{
		if (MonoSingleton<AppManager>.Instance.OnlineHostMinResMode)
		{
			return;
		}
		if (gameObject_0 == null)
		{
			DebugUtils.LogError(LogCategory.Gamelogic, "*****No flashMuzzle for the weapon*****");
			return;
		}
		gameObject_0.name = "flashMuzzleLight";
		gameObject_0.transform.parent = transform_0;
		gameObject_0.transform.localPosition = Vector3.zero;
		gameObject_0.transform.localEulerAngles = new Vector3(90f, 0f, 0f);
	}

	// Token: 0x06001D9D RID: 7581 RVA: 0x00093580 File Offset: 0x00091780
	private void method_61()
	{
		if (MonoSingleton<AppManager>.Instance.OnlineHostMinResMode)
		{
			return;
		}
		Transform transform = this.method_46();
		if (transform == null)
		{
			return;
		}
		Transform child;
		while (transform.childCount > 0 && (child = transform.GetChild(0)))
		{
			global::UnityEngine.Object.DestroyImmediate(child.gameObject);
		}
		EntityWeapon.smethod_2(base.gameObject, this.vmethod_1());
		GameObject gameObject = EntityWeapon.smethod_3(this.method_99(), this.vmethod_1());
		GameObject gameObject2 = EntityWeapon.smethod_4(this.method_99(), this.vmethod_1());
		this.method_59(gameObject, transform);
		this.method_60(gameObject2, transform);
		if (!base.m_owner.vmethod_26())
		{
			this.method_62(transform);
		}
	}

	// Token: 0x06001D9E RID: 7582 RVA: 0x00093628 File Offset: 0x00091828
	public static void smethod_2(GameObject gameObject_0, AttackInfo.ElementalType elementalType_0)
	{
		SkinnedMeshRenderer componentInChildren = gameObject_0.GetComponentInChildren<SkinnedMeshRenderer>();
		if (!(componentInChildren == null) && !(componentInChildren.material == null))
		{
			switch (elementalType_0)
			{
			case AttackInfo.ElementalType.None:
				componentInChildren.material.SetColor("_EmissiveColor", GraphicsDataMgr.NoneElementalEmissiveColor);
				break;
			case AttackInfo.ElementalType.Fire:
				componentInChildren.material.SetColor("_EmissiveColor", GraphicsDataMgr.FireElementalEmissiveColor);
				break;
			case AttackInfo.ElementalType.Shock:
				componentInChildren.material.SetColor("_EmissiveColor", GraphicsDataMgr.ShockElementalEmissiveColor);
				break;
			case AttackInfo.ElementalType.Corrosive:
				componentInChildren.material.SetColor("_EmissiveColor", GraphicsDataMgr.CorrosiveElementalEmissiveColor);
				break;
			}
			return;
		}
	}

	// Token: 0x06001D9F RID: 7583 RVA: 0x000936CC File Offset: 0x000918CC
	private static GameObject smethod_3(WeaponType weaponType_0, AttackInfo.ElementalType elementalType_0)
	{
		WeaponElementalManager component = ns0.MonoSingleton<WeaponFactory>.Instance.method_0().GetComponent<WeaponElementalManager>();
		string string_ = null;
		for (int i = 0; i < component.elementalConfigs.Length; i++)
		{
			if (component.elementalConfigs[i].weapontype == weaponType_0 && component.elementalConfigs[i].elementaltype == elementalType_0)
			{
				string_ = "Particles/" + component.elementalConfigs[i].muzzleRescource;
				break;
			}
		}
		return (GameObject)UnityEngine.Object.Instantiate(ResourcesLoader.smethod_0(string_));
	}
	// Token: 0x06001DA0 RID: 7584 RVA: 0x0009374C File Offset: 0x0009194C
	private static GameObject smethod_4(WeaponType weaponType_0, AttackInfo.ElementalType elementalType_0)
	{
		string text = EntityWeapon.smethod_5(weaponType_0, elementalType_0);
		return (GameObject)global::UnityEngine.Object.Instantiate(ResourcesLoader.smethod_0(text));
	}

	// Token: 0x06001DA1 RID: 7585 RVA: 0x00093774 File Offset: 0x00091974
	private static string smethod_5(WeaponType weaponType_0, AttackInfo.ElementalType elementalType_0)
	{
		WeaponElementalManager component = MonoSingleton<WeaponFactory>.Instance.method_0().GetComponent<WeaponElementalManager>();
		string text = null;
		for (int i = 0; i < component.elementalConfigs.Length; i++)
		{
			if (component.elementalConfigs[i].weapontype == weaponType_0 && component.elementalConfigs[i].elementaltype == elementalType_0)
			{
				text = "Particles/" + component.elementalConfigs[i].lightRescource;
				return text;
			}
		}
		return text;
	}

	// Token: 0x06001DA2 RID: 7586 RVA: 0x000937E4 File Offset: 0x000919E4
	private void method_62(Transform transform_0)
	{
		if (MonoSingleton<AppManager>.Instance.OnlineHostMinResMode)
		{
			return;
		}
		GameObject gameObject = (GameObject)global::UnityEngine.Object.Instantiate(ResourcesLoader.smethod_0("Entities/Object/Weapon/WPN_ShootEffect_NPC"));
		if (gameObject != null)
		{
			gameObject.transform.parent = transform_0;
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.transform.localRotation = Quaternion.identity;
		}
	}

	// Token: 0x06001DA3 RID: 7587 RVA: 0x00093848 File Offset: 0x00091A48
	private void method_63()
	{
		if (MonoSingleton<AppManager>.Instance.OnlineHostMinResMode)
		{
			return;
		}
		if (MonoSingleton<Session>.Instance != null && MonoSingleton<Session>.Instance.method_16())
		{
			return;
		}
		if (this.m_shotTrace != null && this.m_shotTraceGameObject != null)
		{
			return;
		}
		string text = null;
		string text2 = null;
		WeaponType weaponType = this.method_99();
		if (weaponType != WeaponType.SMG && weaponType != WeaponType.RepeaterPistol)
		{
			if (weaponType != WeaponType.CombatRifle)
			{
				if (weaponType == WeaponType.ShotGun)
				{
					text = "Particles/PTL_Shooting_Track_FirstPerson_Shotgun";
					text2 = "PTL_Shooting_Track_FirstPerson_Shotgun_Particle";
					goto IL_008C;
				}
				if (weaponType == WeaponType.SniperRifle)
				{
					text = "Particles/PTL_Shooting_Track_FirstPerson_Sniper";
					text2 = "PTL_Shooting_Track_FirstPerson_Sniper_Particle";
					goto IL_008C;
				}
				goto IL_008C;
			}
		}
		text = "Particles/PTL_Shooting_Track_FirstPerson";
		text2 = "PTL_Shooting_Track_FirstPerson_Particle";
		IL_008C:
		if (!string.IsNullOrEmpty(text))
		{
			this.m_shotTraceGameObject = (GameObject)global::UnityEngine.Object.Instantiate(ResourcesLoader.smethod_0(text));
			if (this.m_shotTraceGameObject != null && !string.IsNullOrEmpty(text2))
			{
				Transform transform = this.m_shotTraceGameObject.transform.FindChild(text2);
				if (transform != null && transform.gameObject.particleSystem)
				{
					this.m_shotTrace = transform.gameObject.particleSystem;
				}
			}
		}
	}

	// Token: 0x06001DA4 RID: 7588 RVA: 0x00093954 File Offset: 0x00091B54
	private void method_64()
	{
		if (MonoSingleton<AppManager>.Instance.OnlineHostMinResMode)
		{
			return;
		}
		Transform transform = this.method_47();
		if (transform == null)
		{
			DebugUtils.LogWarning(LogCategory.Gamelogic, string.Concat(new object[]
			{
				"*****No bulletEjectionNode found for [",
				base.name,
				"] of type [",
				this.method_99(),
				"]*****"
			}));
			return;
		}
		Transform child;
		while (transform.childCount > 0 && (child = transform.GetChild(0)))
		{
			global::UnityEngine.Object.DestroyImmediate(child.gameObject);
		}
		GameObject gameObject = null;
		switch (this.method_99())
		{
		case WeaponType.SMG:
			gameObject = (GameObject)global::UnityEngine.Object.Instantiate(ResourcesLoader.smethod_0("Particles/PTL_Bullet_Ejection_Smg"));
			break;
		case WeaponType.SniperRifle:
			gameObject = (GameObject)global::UnityEngine.Object.Instantiate(ResourcesLoader.smethod_0("Particles/PTL_Bullet_Ejection_Sniper"));
			break;
		case WeaponType.ShotGun:
			gameObject = (GameObject)global::UnityEngine.Object.Instantiate(ResourcesLoader.smethod_0("Particles/PTL_Bullet_Ejection_Shotgun"));
			break;
		case WeaponType.RepeaterPistol:
			gameObject = (GameObject)global::UnityEngine.Object.Instantiate(ResourcesLoader.smethod_0("Particles/PTL_Bullet_Ejection_Smg"));
			break;
		case WeaponType.CombatRifle:
			gameObject = (GameObject)global::UnityEngine.Object.Instantiate(ResourcesLoader.smethod_0("Particles/PTL_Bullet_Ejection_Smg"));
			break;
		}
		if (gameObject == null)
		{
			DebugUtils.LogWarning(LogCategory.Gamelogic, "*****No bulletEjection for the weapon*****");
			return;
		}
		gameObject.transform.parent = transform;
		gameObject.transform.localPosition = Vector3.zero;
		gameObject.transform.localEulerAngles = new Vector3(90f, 0f, 0f);
		ParticleSystem component = gameObject.GetComponent<ParticleSystem>();
		Renderer renderer = component.renderer;
		if (renderer != null)
		{
			Material material = renderer.material;
			if (material)
			{
				WeaponCameraControl componentInChildren = base.m_owner.GetComponentInChildren<WeaponCameraControl>();
				if (componentInChildren)
				{
					material.SetMatrix("_ProjMat", componentInChildren.method_0());
				}
			}
		}
	}

	// Token: 0x06001DA5 RID: 7589 RVA: 0x00014DB5 File Offset: 0x00012FB5
	private void method_65()
	{
		if (MonoSingleton<AppManager>.Instance.OnlineHostMinResMode)
		{
			return;
		}
		this.method_61();
		this.method_63();
		this.method_64();
	}

	// Token: 0x06001DA6 RID: 7590 RVA: 0x00014DD6 File Offset: 0x00012FD6
	public void OnPlayerRespawn()
	{
		if (MonoSingleton<AppManager>.Instance.OnlineHostMinResMode)
		{
			return;
		}
		this.method_63();
	}

	// Token: 0x06001DA7 RID: 7591 RVA: 0x00093B20 File Offset: 0x00091D20
	public void method_66()
	{
		if (!MonoSingleton<AppManager>.Instance.OnlineHostMinResMode)
		{
			this.m_flashMuzzle = null;
			this.m_bulletEjection = null;
			this.m_muzzleFlashLight = null;
			Transform transform = this.method_46();
			if (transform)
			{
				Transform transform2 = transform.FindChild("flashMuzzle");
				if (transform2 != null)
				{
					this.m_flashMuzzle = transform2.GetComponent<ParticleSystem>();
				}
				if (transform.FindChild("flashMuzzleLight"))
				{
					this.m_muzzleFlashLight = transform.FindChild("flashMuzzleLight").animation;
				}
			}
			else
			{
				DebugUtils.LogWarning(LogCategory.Gamelogic, string.Concat(new object[]
				{
					"*****flashMuzzleNode missing for [",
					base.name,
					"] of type [",
					this.method_99(),
					"]*****"
				}));
			}
			Transform transform3 = this.method_47();
			if (transform3)
			{
				this.m_bulletEjection = transform3.GetComponentInChildren<ParticleSystem>();
			}
			else
			{
				DebugUtils.LogWarning(LogCategory.Gamelogic, string.Concat(new object[]
				{
					"*****bulletEjectionNode missing for [",
					base.name,
					"] of type [",
					this.method_99(),
					"]*****"
				}));
			}
		}
	}

	// Token: 0x06001DA8 RID: 7592 RVA: 0x00014DEB File Offset: 0x00012FEB
	private bool method_67()
	{
		return IntAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.CanEjectBulletShells) as IntAttributeValue) > 0;
	}

	// Token: 0x06001DA9 RID: 7593 RVA: 0x00093C48 File Offset: 0x00091E48
	public float method_68()
	{
		float num = FloatAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.FireRange) as FloatAttributeValue);
		if (num <= 0f)
		{
			num = float.MaxValue;
		}
		return num;
	}

	// Token: 0x06001DAA RID: 7594 RVA: 0x00014E07 File Offset: 0x00013007
	public float method_69()
	{
		return FloatAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.FireMaxRange) as FloatAttributeValue);
	}

	// Token: 0x06001DAB RID: 7595 RVA: 0x00014E23 File Offset: 0x00013023
	public float method_70()
	{
		return FloatAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.MinDamageScale) as FloatAttributeValue);
	}

	// Token: 0x06001DAC RID: 7596 RVA: 0x00014E3C File Offset: 0x0001303C
	public EntityWeapon.ReloadType method_71()
	{
		return (EntityWeapon.ReloadType)IntAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.ReloadType) as IntAttributeValue);
	}

	// Token: 0x06001DAD RID: 7597 RVA: 0x00014E55 File Offset: 0x00013055
	public EntityWeapon.ScopeMaskType method_72()
	{
		return (EntityWeapon.ScopeMaskType)IntAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.ScopeMaskType) as IntAttributeValue);
	}

	// Token: 0x06001DAE RID: 7598 RVA: 0x00014E6E File Offset: 0x0001306E
	public EntityWeapon.ScopeHudType method_73()
	{
		return (EntityWeapon.ScopeHudType)IntAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.ScopeHudType) as IntAttributeValue);
	}

	// Token: 0x06001DAF RID: 7599 RVA: 0x00093C7C File Offset: 0x00091E7C
	public float method_74()
	{
		float num = FloatAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.PutDownTime) as FloatAttributeValue);
		if (!(base.m_owner == null))
		{
			if (base.m_owner.vmethod_8() == Entity.EntityType.Player)
			{
				return num * (base.m_owner as EntityPlayer).PlayerSkillManage_0.vmethod_8();
			}
		}
		return num;
	}

	// Token: 0x06001DB0 RID: 7600 RVA: 0x00093CE4 File Offset: 0x00091EE4
	public float method_75()
	{
		float num = FloatAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.EquipTime) as FloatAttributeValue);
		if (!(base.m_owner == null))
		{
			if (base.m_owner.vmethod_8() == Entity.EntityType.Player)
			{
				return num * (base.m_owner as EntityPlayer).PlayerSkillManage_0.vmethod_8();
			}
		}
		return num;
	}

	// Token: 0x06001DB1 RID: 7601 RVA: 0x00093D4C File Offset: 0x00091F4C
	public float method_76()
	{
		float num = FloatAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.ZoomTranslation) as FloatAttributeValue);
		if (!(base.m_owner == null))
		{
			if (base.m_owner.vmethod_8() == Entity.EntityType.Player)
			{
				float num2 = 1f - (base.m_owner as EntityPlayer).PlayerEffectManager_0.method_0(EffectType.ZoomTransitionSpeed);
				return num * num2;
			}
		}
		return num;
	}

	// Token: 0x06001DB2 RID: 7602 RVA: 0x00093DBC File Offset: 0x00091FBC
	public float method_77()
	{
		float num = FloatAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.ReloadTime) as FloatAttributeValue);
		if (!(base.m_owner == null))
		{
			if (base.m_owner.vmethod_8() == Entity.EntityType.Player)
			{
				return num * (base.m_owner as EntityPlayer).PlayerSkillManage_0.vmethod_7();
			}
		}
		return num;
	}

	// Token: 0x06001DB3 RID: 7603 RVA: 0x00093E24 File Offset: 0x00092024
	public float method_78(InstanceInput instanceInput_0)
	{
		if (instanceInput_0.IsRunning())
		{
			return FloatAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.SprintSpeedModifier) as FloatAttributeValue);
		}
		if (instanceInput_0.IsMoving())
		{
			if (instanceInput_0.IsAiming())
			{
				return FloatAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.StandWalkSpeedModifier) as FloatAttributeValue);
			}
			return FloatAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.RunSpeedModifier) as FloatAttributeValue);
		}
		else
		{
			if (instanceInput_0.IsCrouching())
			{
				return FloatAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.CrouchWalkSpeedModifier) as FloatAttributeValue);
			}
			return 1f;
		}
	}

	// Token: 0x06001DB4 RID: 7604 RVA: 0x00093EC4 File Offset: 0x000920C4
	public void method_79()
	{
		if (!MonoSingleton<AppManager>.Instance.OnlineHostMinResMode)
		{
			if (this.m_flashMuzzle == null)
			{
				this.method_66();
			}
			if (this.m_flashMuzzle != null)
			{
				this.m_flashMuzzle.transform.localPosition = Vector3.zero;
				this.m_flashMuzzle.gameObject.SetActive(true);
				this.m_flashMuzzle.Play();
				if (this.m_shotTrace != null)
				{
					this.m_shotTrace.Play();
				}
			}
			if (this.m_muzzleFlashLight != null && this.m_muzzleFlashLight.clip != null && this.m_muzzleFlashLight.clip.name != null)
			{
				this.m_muzzleFlashLight.CrossFade(this.m_muzzleFlashLight.clip.name, 0f);
			}
			if (base.m_owner is EntityPlayer && this.method_67() && this.m_bulletEjection != null)
			{
				this.m_bulletEjection.Emit(1);
			}
		}
	}

	// Token: 0x06001DB5 RID: 7605 RVA: 0x00014E87 File Offset: 0x00013087
	private bool method_80()
	{
		return !this.m_noBulletSpray;
	}

	// Token: 0x06001DB6 RID: 7606 RVA: 0x00094128 File Offset: 0x00092328
	private Vector3 method_81(float float_0, float float_1)
	{
		if (!this.method_80())
		{
			return this.vmethod_27();
		}
		float num = Utils.StaticRandom.smethod_0(this.m_randomRecoilIndex++);
		float num2 = Utils.StaticRandom.smethod_0(this.m_randomRecoilIndex++);
		float num3 = Utils.StaticRandom.smethod_0(this.m_randomRecoilIndex++);
		float num4 = ((num >= this.m_currentView.m_InnerAccuracyRatio) ? this.method_82() : this.method_83());
		if (base.m_owner.vmethod_8() == Entity.EntityType.Player)
		{
			float num5;
			if (this.m_isAimActive)
			{
				num5 = 1f / ((EntityPlayer)base.m_owner).PlayerEffectManager_0.method_0(EffectType.ZoomAccuracy);
			}
			else
			{
				num5 = 1f / ((EntityPlayer)base.m_owner).PlayerEffectManager_0.method_0(EffectType.WeaponAccuracy);
			}
			num4 *= num5;
		}
		float num6 = num2 - 0.5f;
		float num7 = Mathf.Sqrt(1f - Mathf.Pow(2f * num6, 2f));
		Quaternion quaternion = Quaternion.Euler((num3 - 0.5f) * num7 * num4, num6 * num4, 0f);
		Vector3 vector = this.vmethod_27();
		Vector3 vector2 = base.m_owner.transform.InverseTransformDirection(vector);
		vector2 = quaternion * vector2;
		return base.m_owner.transform.TransformDirection(vector2);
	}

	// Token: 0x06001DB7 RID: 7607 RVA: 0x00014E94 File Offset: 0x00013094
	public override Vector3 vmethod_27()
	{
		if (base.m_owner != null)
		{
			return base.m_owner.vmethod_27();
		}
		return base.vmethod_27();
	}

	// Token: 0x06001DB8 RID: 7608 RVA: 0x00014EB6 File Offset: 0x000130B6
	protected override void OnDrawGizmos()
	{
		base.OnDrawGizmos();
		global::Debug.smethod_7(this.vmethod_28(), this.vmethod_27() * 1000f);
	}

	// Token: 0x06001DB9 RID: 7609 RVA: 0x00014ED9 File Offset: 0x000130D9
	public override Vector3 vmethod_28()
	{
		if (base.m_owner != null)
		{
			return base.m_owner.vmethod_28();
		}
		return base.transform.position;
	}

	// Token: 0x06001DBA RID: 7610 RVA: 0x00014F00 File Offset: 0x00013100
	private float method_82()
	{
		return this.m_currentSpread * 0.12f;
	}

	// Token: 0x06001DBB RID: 7611 RVA: 0x00014F0E File Offset: 0x0001310E
	private float method_83()
	{
		return this.m_innerSpread * 0.12f;
	}

	// Token: 0x06001DBC RID: 7612 RVA: 0x00094294 File Offset: 0x00092494
	private void method_84(float float_0)
	{
		if (float_0 - this.m_lastFireTime > this.m_currentView.m_recoverTime)
		{
			if (this.m_lastUpdateSpreadTime < this.m_lastFireTime + this.m_currentView.m_recoverTime)
			{
				float num = this.m_lastFireTime + this.m_currentView.m_recoverTime - this.m_lastUpdateSpreadTime;
				this.method_87(this.m_recoilSettingsPitch, ref this.m_recoilOffsetPitch, num, false);
				this.method_87(this.m_recoilSettingsYaw, ref this.m_recoilOffsetYaw, num, false);
				this.method_87(this.m_recoilSettingsKickBack, ref this.m_recoilOffsetKickBack, num, false);
				this.m_currentSpread = Mathf.Clamp(this.m_currentSpread - this.m_currentView.m_AccuracyRegenerationRateActive * (1000f * num), this.m_currentView.m_AccuracyMax, this.m_currentView.m_AccuracyMin);
				this.m_innerSpread = this.m_currentSpread * this.m_currentView.m_InnerAccuracy;
				num = float_0 - this.m_lastFireTime - this.m_currentView.m_recoverTime;
				this.method_87(this.m_recoilSettingsPitch, ref this.m_recoilOffsetPitch, num, true);
				this.method_87(this.m_recoilSettingsYaw, ref this.m_recoilOffsetYaw, num, true);
				this.method_87(this.m_recoilSettingsKickBack, ref this.m_recoilOffsetKickBack, num, true);
				this.m_currentSpread = Mathf.Clamp(this.m_currentSpread - this.m_currentView.m_AccuracyRegenerationRateOnIdle * (1000f * num), this.m_currentView.m_AccuracyMax, this.m_currentView.m_AccuracyMin);
				this.m_innerSpread = this.m_currentSpread * this.m_currentView.m_InnerAccuracy;
			}
			else
			{
				float num = float_0 - this.m_lastUpdateSpreadTime;
				this.method_87(this.m_recoilSettingsPitch, ref this.m_recoilOffsetPitch, num, true);
				this.method_87(this.m_recoilSettingsYaw, ref this.m_recoilOffsetYaw, num, true);
				this.method_87(this.m_recoilSettingsKickBack, ref this.m_recoilOffsetKickBack, num, true);
				this.m_currentSpread = Mathf.Clamp(this.m_currentSpread - this.m_currentView.m_AccuracyRegenerationRateOnIdle * (1000f * num), this.m_currentView.m_AccuracyMax, this.m_currentView.m_AccuracyMin);
				this.m_innerSpread = this.m_currentSpread * this.m_currentView.m_InnerAccuracy;
				if (this.m_manufacturer == ItemManufacturer.Vladof)
				{
					this.method_90(true);
				}
			}
		}
		else
		{
			float num = float_0 - this.m_lastUpdateSpreadTime;
			this.method_87(this.m_recoilSettingsPitch, ref this.m_recoilOffsetPitch, num, false);
			this.method_87(this.m_recoilSettingsYaw, ref this.m_recoilOffsetYaw, num, false);
			this.method_87(this.m_recoilSettingsKickBack, ref this.m_recoilOffsetKickBack, num, false);
			this.m_currentSpread = Mathf.Clamp(this.m_currentSpread - this.m_currentView.m_AccuracyRegenerationRateActive * (1000f * num), this.m_currentView.m_AccuracyMax, this.m_currentView.m_AccuracyMin);
			this.m_innerSpread = this.m_currentSpread * this.m_currentView.m_InnerAccuracy;
			if (this.m_manufacturer == ItemManufacturer.Vladof)
			{
				this.method_90(false);
			}
		}
		this.method_88();
		this.m_lastUpdateSpreadTime = float_0;
	}

	// Token: 0x06001DBD RID: 7613 RVA: 0x00094594 File Offset: 0x00092794
	public override void Update()
	{
		base.Update();
		if (base.m_owner != null && base.m_owner is EntityNpc && (base.m_pickable == null || !base.m_pickable.m_spinningToOwner))
		{
			base.transform.localPosition = Vector3.zero;
			base.transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
		}
		if (this.vmethod_62())
		{
			if (base.m_owner != null && base.m_owner.vmethod_26())
			{
				if (!this.m_isAimActive)
				{
					MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDAimTargetView>().vmethod_7(this.method_82() / 2f, float.MaxValue);
					this.m_burstFireStage = EntityWeapon.BurstFireStage.NoneBurst;
				}
				else
				{
					MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDAimTargetView>().vmethod_7(FloatAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.AccuracyMaxZoom) as FloatAttributeValue) * 0.06f, FloatAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.AccuracyMinZoom) as FloatAttributeValue) * 0.01f);
				}
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDAimTargetView>().vmethod_6(this.method_73());
			}
			this.method_84(Time.fixedTime);
		}
	}

	// Token: 0x06001DBE RID: 7614 RVA: 0x000946E0 File Offset: 0x000928E0
	protected override void OnDestroy()
	{
		base.OnDestroy();
		if (this.m_fpWpnClearZMat)
		{
			global::UnityEngine.Object.Destroy(this.m_fpWpnClearZMat);
			this.m_fpWpnClearZMat = null;
		}
		if (this.m_thrWpnMat)
		{
			global::UnityEngine.Object.Destroy(this.m_thrWpnMat);
			this.m_thrWpnMat = null;
		}
		if (this.m_shotTrace != null)
		{
			global::UnityEngine.Object.Destroy(this.m_shotTrace);
		}
		if (this.m_shotTraceGameObject != null)
		{
			global::UnityEngine.Object.Destroy(this.m_shotTraceGameObject);
		}
	}

	// Token: 0x06001DBF RID: 7615 RVA: 0x00014F1C File Offset: 0x0001311C
	public void method_85(ref float float_0, ref float float_1, float aimSensitivity)
	{
		// old code, used weapon parts to define it which is fucking insane because weapon parts are mega broken right now as idi pointed out. in the future uncomment below and remove the new code. this is just until we fix parts
		//float_0 = FloatAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.ZoomCameraAngularSpeedYaw) as FloatAttributeValue);
		//float_1 = FloatAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.ZoomCameraAngularSpeedPitch) as FloatAttributeValue);

		float_0 = aimSensitivity;
		float_1 = aimSensitivity;
	}

	// Token: 0x06001DC0 RID: 7616 RVA: 0x00094764 File Offset: 0x00092964
	public void method_86()
	{
		this.method_93(ref this.m_recoilSettingsYaw);
		this.m_recoilOffsetYaw += this.m_recoilSettingsYaw.m_randomOffsetMin + (this.m_recoilSettingsYaw.m_randomOffsetMax - this.m_recoilSettingsYaw.m_randomOffsetMin) * Utils.StaticRandom.smethod_0(this.m_randomRecoilIndex++);
		this.m_recoilOffsetYaw = Mathf.Clamp(this.m_recoilOffsetYaw, this.m_recoilSettingsYaw.m_offsetMin, this.m_recoilSettingsYaw.m_offsetMax);
		this.method_94(ref this.m_recoilSettingsPitch);
		float num = this.m_recoilSettingsPitch.m_randomOffsetMin + (this.m_recoilSettingsPitch.m_randomOffsetMax - this.m_recoilSettingsPitch.m_randomOffsetMin) * Utils.StaticRandom.smethod_0(this.m_randomRecoilIndex++);
		float num2 = Mathf.Clamp(this.m_recoilOffsetPitch / this.m_recoilSettingsPitch.m_randomOffsetMax, FloatAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.RecoilPitchMulMin) as FloatAttributeValue), FloatAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.RecoilPitchMulMax) as FloatAttributeValue));
		num *= num2;
		this.m_recoilOffsetPitch += num;
		this.m_recoilOffsetPitch = Mathf.Clamp(this.m_recoilOffsetPitch, this.m_recoilSettingsPitch.m_offsetMin, this.m_recoilSettingsPitch.m_offsetMax);
		this.method_95(ref this.m_recoilSettingsKickBack);
		this.m_recoilOffsetKickBack += this.m_recoilSettingsKickBack.m_randomOffsetMin + (this.m_recoilSettingsKickBack.m_randomOffsetMax - this.m_recoilSettingsKickBack.m_randomOffsetMin) * Utils.StaticRandom.smethod_0(this.m_randomRecoilIndex++);
		this.m_recoilOffsetKickBack = Mathf.Clamp(this.m_recoilOffsetKickBack, this.m_recoilSettingsKickBack.m_offsetMin, this.m_recoilSettingsKickBack.m_offsetMax);
		if (this.m_isAimActive)
		{
			float num3 = (base.m_owner as EntityPlayer).PlayerEffectManager_0.method_0(EffectType.WeaponRecoil);
			this.m_recoilOffsetYaw *= num3;
			this.m_recoilOffsetPitch *= num3;
			this.m_recoilOffsetKickBack *= num3;
		}
	}

	// Token: 0x06001DC1 RID: 7617 RVA: 0x00094978 File Offset: 0x00092B78
	private void method_87(EntityWeapon.RecoilSettings recoilSettings_0, ref float float_0, float float_1, bool bool_0)
	{
		if (bool_0)
		{
			if (float_0.AlmostEquals(0f, 0.0001f))
			{
				float_0 = 0f;
			}
			else if (float_0 > 0f)
			{
				float_0 -= recoilSettings_0.m_reducingRateOnIdle * float_1;
				if (float_0 < 0f)
				{
					float_0 = 0f;
				}
			}
			else if (float_0 < 0f)
			{
				float_0 += recoilSettings_0.m_reducingRateOnIdle * float_1;
				if (float_0 > 0f)
				{
					float_0 = 0f;
				}
			}
		}
		else if (float_0.AlmostEquals(0f, 0.0001f))
		{
			float_0 = 0f;
		}
		else if (float_0 > 0f)
		{
			float_0 -= recoilSettings_0.m_reducingRateActive * float_1;
			if (float_0 < 0f)
			{
				float_0 = 0f;
			}
		}
		else if (float_0 < 0f)
		{
			float_0 += recoilSettings_0.m_reducingRateActive * float_1;
			if (float_0 > 0f)
			{
				float_0 = 0f;
			}
		}
	}

	// Token: 0x06001DC2 RID: 7618 RVA: 0x00094A6C File Offset: 0x00092C6C
	private void method_88()
	{
		EntityPlayer entityPlayer = base.m_owner as EntityPlayer;
		if (entityPlayer)
		{
			entityPlayer.method_99(Quaternion.Euler(this.m_recoilOffsetYaw, 0f, this.m_recoilOffsetPitch), this.m_recoilOffsetKickBack);
		}
	}

	// Token: 0x06001DC3 RID: 7619 RVA: 0x00014F50 File Offset: 0x00013150
	public void method_89(ref float float_0, ref float float_1, ref float float_2)
	{
		float_0 = this.m_recoilOffsetPitch;
		float_1 = this.m_recoilOffsetYaw;
		float_2 = this.m_recoilOffsetKickBack;
	}

	// Token: 0x06001DC4 RID: 7620 RVA: 0x00014F6A File Offset: 0x0001316A
	public void method_90(bool bool_0 = false)
	{
		if (bool_0)
		{
			this.m_dynamicFireRate = 0f;
		}
		else
		{
			this.m_dynamicFireRate += FloatAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.FireRateIncrease) as FloatAttributeValue);
		}
	}

	// Token: 0x06001DC5 RID: 7621 RVA: 0x00094AB0 File Offset: 0x00092CB0
	public float method_91(float float_0)
	{
		ItemManufacturer manufacturer = this.m_manufacturer;
		if (manufacturer != ItemManufacturer.Vladof)
		{
			if (manufacturer == ItemManufacturer.Dahl)
			{
				if (this.m_isAimActive && this.m_fixedBulletBurst > 0)
				{
					float_0 = FloatAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.BurstFireRate) as FloatAttributeValue);
				}
			}
		}
		else
		{
			float_0 += this.m_dynamicFireRate;
			float num = FloatAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.FireRateMax) as FloatAttributeValue);
			if (num > 0f)
			{
				float_0 = Mathf.Clamp(float_0, 0f, num);
			}
			else
			{
				DebugUtils.LogWarning(LogCategory.Gamelogic, "Vladof weapon should have a fireRateMax bigger than 0, please check with desiger of weapon subpart setting");
			}
		}
		return float_0;
	}

	// Token: 0x06001DC6 RID: 7622 RVA: 0x00094B48 File Offset: 0x00092D48
	public float method_92()
	{
		if (this.m_attribute == null)
		{
			return 0f;
		}
		float num = FloatAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.FireRate) as FloatAttributeValue);
		EntityPlayer entityPlayer = base.m_owner as EntityPlayer;
		if (entityPlayer != null)
		{
			num *= entityPlayer.PlayerSkillManage_0.vmethod_2();
			num = this.method_91(num);
		}
		return num;
	}

	// Token: 0x06001DC7 RID: 7623 RVA: 0x00094BA8 File Offset: 0x00092DA8
	public void method_93(ref EntityWeapon.RecoilSettings recoilSettings_0)
	{
		if (this.m_attribute == null)
		{
			return;
		}
		if (this.m_isAimActive)
		{
			recoilSettings_0.m_randomOffsetMin = FloatAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.RecoilZoomYawRandomOffsetMin) as FloatAttributeValue);
			recoilSettings_0.m_randomOffsetMax = FloatAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.RecoilZoomYawRandomOffsetMax) as FloatAttributeValue);
			recoilSettings_0.m_offsetMin = FloatAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.RecoilZoomYawOffsetMin) as FloatAttributeValue);
			recoilSettings_0.m_offsetMax = FloatAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.RecoilZoomYawOffsetMax) as FloatAttributeValue);
			recoilSettings_0.m_reducingRateActive = FloatAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.RecoilZoomYawReducingRateActive) as FloatAttributeValue);
			recoilSettings_0.m_reducingRateOnIdle = FloatAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.RecoilZoomYawReducingRateOnIdle) as FloatAttributeValue);
			return;
		}
		recoilSettings_0.m_randomOffsetMin = FloatAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.RecoilYawRandomOffsetMin) as FloatAttributeValue);
		recoilSettings_0.m_randomOffsetMax = FloatAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.RecoilYawRandomOffsetMax) as FloatAttributeValue);
		recoilSettings_0.m_offsetMin = FloatAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.RecoilYawOffsetMin) as FloatAttributeValue);
		recoilSettings_0.m_offsetMax = FloatAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.RecoilYawOffsetMax) as FloatAttributeValue);
		recoilSettings_0.m_reducingRateActive = FloatAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.RecoilYawReducingRateActive) as FloatAttributeValue);
		recoilSettings_0.m_reducingRateOnIdle = FloatAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.RecoilYawReducingRateOnIdle) as FloatAttributeValue);
		recoilSettings_0.method_0();
	}

	// Token: 0x06001DC8 RID: 7624 RVA: 0x00094D3C File Offset: 0x00092F3C
	public void method_94(ref EntityWeapon.RecoilSettings recoilSettings_0)
	{
		if (this.m_isAimActive)
		{
			recoilSettings_0.m_randomOffsetMin = FloatAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.RecoilZoomPitchRandomOffsetMin) as FloatAttributeValue);
			recoilSettings_0.m_randomOffsetMax = FloatAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.RecoilZoomPitchRandomOffsetMax) as FloatAttributeValue);
			recoilSettings_0.m_offsetMin = FloatAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.RecoilZoomPitchOffsetMin) as FloatAttributeValue);
			recoilSettings_0.m_offsetMax = FloatAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.RecoilZoomPitchOffsetMax) as FloatAttributeValue);
			recoilSettings_0.m_reducingRateActive = FloatAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.RecoilZoomPitchReducingRateActive) as FloatAttributeValue);
			recoilSettings_0.m_reducingRateOnIdle = FloatAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.RecoilZoomPitchReducingRateOnIdle) as FloatAttributeValue);
			recoilSettings_0.method_0();
			return;
		}
		recoilSettings_0.m_randomOffsetMin = FloatAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.RecoilPitchRandomOffsetMin) as FloatAttributeValue);
		recoilSettings_0.m_randomOffsetMax = FloatAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.RecoilPitchRandomOffsetMax) as FloatAttributeValue);
		recoilSettings_0.m_offsetMin = FloatAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.RecoilPitchOffsetMin) as FloatAttributeValue);
		recoilSettings_0.m_offsetMax = FloatAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.RecoilPitchOffsetMax) as FloatAttributeValue);
		recoilSettings_0.m_reducingRateActive = FloatAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.RecoilPitchReducingRateActive) as FloatAttributeValue);
		recoilSettings_0.m_reducingRateOnIdle = FloatAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.RecoilPitchReducingRateOnIdle) as FloatAttributeValue);
		recoilSettings_0.method_0();
	}

	// Token: 0x06001DC9 RID: 7625 RVA: 0x00094ECC File Offset: 0x000930CC
	public void method_95(ref EntityWeapon.RecoilSettings recoilSettings_0)
	{
		if (this.m_isAimActive)
		{
			recoilSettings_0.m_randomOffsetMin = FloatAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.RecoilZoomKickBackRandomOffsetMin) as FloatAttributeValue);
			recoilSettings_0.m_randomOffsetMax = FloatAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.RecoilZoomKickBackRandomOffsetMax) as FloatAttributeValue);
			recoilSettings_0.m_offsetMin = FloatAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.RecoilZoomKickBackOffsetMin) as FloatAttributeValue);
			recoilSettings_0.m_offsetMax = FloatAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.RecoilZoomKickBackOffsetMax) as FloatAttributeValue);
			recoilSettings_0.m_reducingRateActive = FloatAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.RecoilZoomKickBackReducingRateActive) as FloatAttributeValue);
			recoilSettings_0.m_reducingRateOnIdle = FloatAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.RecoilZoomKickBackReducingRateOnIdle) as FloatAttributeValue);
			recoilSettings_0.method_0();
			return;
		}
		recoilSettings_0.m_randomOffsetMin = FloatAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.RecoilKickBackRandomOffsetMin) as FloatAttributeValue);
		recoilSettings_0.m_randomOffsetMax = FloatAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.RecoilKickBackRandomOffsetMax) as FloatAttributeValue);
		recoilSettings_0.m_offsetMin = FloatAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.RecoilKickBackOffsetMin) as FloatAttributeValue);
		recoilSettings_0.m_offsetMax = FloatAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.RecoilKickBackOffsetMax) as FloatAttributeValue);
		recoilSettings_0.m_reducingRateActive = FloatAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.RecoilKickBackReducingRateActive) as FloatAttributeValue);
		recoilSettings_0.m_reducingRateOnIdle = FloatAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.RecoilKickBackReducingRateOnIdle) as FloatAttributeValue);
		recoilSettings_0.method_0();
	}

	// Token: 0x06001DCA RID: 7626 RVA: 0x0000311B File Offset: 0x0000131B
	public void method_96()
	{
	}

	// Token: 0x06001DCB RID: 7627 RVA: 0x0000311B File Offset: 0x0000131B
	public void method_97()
	{
	}

	// Token: 0x06001DCC RID: 7628 RVA: 0x00014FA0 File Offset: 0x000131A0
	public void method_98()
	{
		this.m_currentSpread = Mathf.Max(this.m_currentView.m_AccuracyMax, this.m_currentView.m_AccuracyMin);
		this.m_innerSpread = this.m_currentSpread * this.m_currentView.m_InnerAccuracy;
	}

	// Token: 0x06001DCD RID: 7629 RVA: 0x00014FDB File Offset: 0x000131DB
	public WeaponType method_99()
	{
		return this.m_dna.method_1();
	}

	// Token: 0x06001DCE RID: 7630 RVA: 0x00014FE8 File Offset: 0x000131E8
	public float method_100()
	{
		return this.m_reloadPercentage;
	}

	// Token: 0x06001DCF RID: 7631 RVA: 0x0009505C File Offset: 0x0009325C
	public int method_101()
	{
		int num = IntAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.ClipSize) as IntAttributeValue);
		if (base.m_owner == null)
		{
			return num;
		}
		if (base.m_owner.vmethod_8() == Entity.EntityType.Player)
		{
			return (int)((float)num * ((EntityPlayer)base.m_owner).PlayerEffectManager_0.method_0(EffectType.ClipSize));
		}
		return num;
	}

	// Token: 0x06001DD0 RID: 7632 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnCombatReload()
	{
	}

	// Token: 0x06001DD1 RID: 7633 RVA: 0x000950BC File Offset: 0x000932BC
	public float method_102()
	{
		float num = FloatAttributeValue.smethod_0(this.m_attribute.method_1(AttributeType.ElementalProcCoef) as FloatAttributeValue);
		EntityPlayer entityPlayer = base.m_owner as EntityPlayer;
		if (entityPlayer != null && entityPlayer.PlayerSkillManage_0 is FirebirdManage)
		{
			float num2 = entityPlayer.PlayerEffectManager_0.method_0(EffectType.WpnElementalProc);
			num *= num2;
		}
		return num;
	}

	// Token: 0x06001DD2 RID: 7634 RVA: 0x00014FF0 File Offset: 0x000131F0
	public float method_103()
	{
		return Utils.StaticRandom.smethod_0(this.m_randomRecoilIndex);
	}

	// Token: 0x04001346 RID: 4934
	public EntityWeapon.WanderManage m_wander_manager;

	// Token: 0x04001347 RID: 4935
	public readonly Quaternion originalRotation = Quaternion.Euler(new Vector3(90f, 0f, 0f));

	// Token: 0x04001348 RID: 4936
	private WeaponDNA m_dna;

	// Token: 0x04001349 RID: 4937
	private bool startedInstanciatingModel;

	// Token: 0x0400134A RID: 4938
	public float m_nextFireTime;

	// Token: 0x0400134B RID: 4939
	private float m_lastFireTime;

	// Token: 0x0400134C RID: 4940
	private float m_lastUpdateSpreadTime;

	// Token: 0x0400134D RID: 4941
	public Vector3 m_fireDirection;

	// Token: 0x0400134E RID: 4942
	public Vector3 m_fireOrigin;

	// Token: 0x0400134F RID: 4943
	public int m_ammoCount;

	private bool m_magazineInitialized;

	// Token: 0x04001350 RID: 4944
	[HideInInspector]
	public bool m_isReady;

	// Token: 0x04001351 RID: 4945
	private float m_currentSpread;

	// Token: 0x04001352 RID: 4946
	private float m_innerSpread;

	// Token: 0x04001353 RID: 4947
	private PerViewWeaponParam m_currentView;

	// Token: 0x04001354 RID: 4948
	private PerViewWeaponParam m_normalView;

	// Token: 0x04001355 RID: 4949
	private PerViewWeaponParam m_zoomView;

	// Token: 0x04001356 RID: 4950
	public bool m_isAimActive;

	// Token: 0x04001357 RID: 4951
	private ParticleSystem m_flashMuzzle;

	// Token: 0x04001358 RID: 4952
	private GameObject m_shotTraceGameObject;

	// Token: 0x04001359 RID: 4953
	private ParticleSystem m_shotTrace;

	// Token: 0x0400135A RID: 4954
	private Animation m_muzzleFlashLight;

	// Token: 0x0400135B RID: 4955
	private ParticleSystem m_bulletEjection;

	// Token: 0x0400135C RID: 4956
	private bool m_hasScope;

	// Token: 0x0400135D RID: 4957
	private bool m_hasMask;

	// Token: 0x0400135E RID: 4958
	public bool m_noBulletSpray;

	// Token: 0x0400135F RID: 4959
	private bool m_isDataDirty;

	// Token: 0x04001360 RID: 4960
	private int m_ammoCountToSend;

	// Token: 0x04001361 RID: 4961
	public Material m_thrWpnMat;

	// Token: 0x04001362 RID: 4962
	private Material m_fpWpnClearZMat;

	// Token: 0x04001363 RID: 4963
	private float m_reloadPercentage;

	// Token: 0x04001364 RID: 4964
	public SkinnedMeshRenderer mWpnRenderer;

	// Token: 0x04001365 RID: 4965
	private int m_random_index;

	// Token: 0x04001366 RID: 4966
	private float m_recoilOffsetYaw;

	// Token: 0x04001367 RID: 4967
	private float m_recoilOffsetPitch;

	// Token: 0x04001368 RID: 4968
	private float m_recoilOffsetKickBack;

	// Token: 0x04001369 RID: 4969
	private int m_randomRecoilIndex;

	// Token: 0x0400136A RID: 4970
	private EntityWeapon.RecoilSettings m_recoilSettingsYaw = new EntityWeapon.RecoilSettings();

	// Token: 0x0400136B RID: 4971
	private EntityWeapon.RecoilSettings m_recoilSettingsPitch = new EntityWeapon.RecoilSettings();

	// Token: 0x0400136C RID: 4972
	private EntityWeapon.RecoilSettings m_recoilSettingsKickBack = new EntityWeapon.RecoilSettings();

	// Token: 0x0400136D RID: 4973
	private ItemManufacturer m_manufacturer;

	// Token: 0x0400136E RID: 4974
	private float m_dynamicFireRate;

	// Token: 0x0400136F RID: 4975
	private int m_dynamicBulletBurst;

	// Token: 0x04001370 RID: 4976
	private int m_fixedBulletBurst;

	// Token: 0x04001371 RID: 4977
	private float m_delayTimeAfterBurst = 0.5f;

	// Token: 0x04001372 RID: 4978
	public float m_BurstFinishTime;

	// Token: 0x04001373 RID: 4979
	private EntityWeapon.BurstFireStage m_burstFireStage;

	// Token: 0x04001374 RID: 4980
	public bool m_isReadyToFire;

	// Token: 0x04001375 RID: 4981
	private int m_level;

	// Token: 0x04001376 RID: 4982
	private bool actionBeforeResolve;

	// Token: 0x04001377 RID: 4983
	private int m_firstFireFrame;

	// Token: 0x04001378 RID: 4984
	private int m_firstFireAmmo;

	// Token: 0x04001379 RID: 4985
	private float m_bulletOffsetStart;

	// Token: 0x0400137A RID: 4986
	private float m_lastResolveTime;

	// Token: 0x02000474 RID: 1140
	public class RecoilSettings
	{
		// Token: 0x06001DD4 RID: 7636 RVA: 0x00014FFD File Offset: 0x000131FD
		public void method_0()
		{
			if (this.m_reducingRateActive <= 1E-45f)
			{
				this.m_reducingRateActive = 0.1f;
			}
			if (this.m_reducingRateOnIdle <= 1E-45f)
			{
				this.m_reducingRateOnIdle = 0.1f;
			}
		}

		// Token: 0x0400137C RID: 4988
		public float m_randomOffsetMin;

		// Token: 0x0400137D RID: 4989
		public float m_randomOffsetMax;

		// Token: 0x0400137E RID: 4990
		public float m_offsetMin;

		// Token: 0x0400137F RID: 4991
		public float m_offsetMax;

		// Token: 0x04001380 RID: 4992
		public float m_reducingRateActive;

		// Token: 0x04001381 RID: 4993
		public float m_reducingRateOnIdle;
	}

	// Token: 0x02000475 RID: 1141
	public class WanderManage
	{
		// Token: 0x06001DD5 RID: 7637 RVA: 0x00095118 File Offset: 0x00093318
		public WanderManage(EntityWeapon entityWeapon_0)
		{
			this.m_owner = entityWeapon_0;
		}

		// Token: 0x06001DD6 RID: 7638 RVA: 0x0009516C File Offset: 0x0009336C
		private float method_0()
		{
			if (this.m_progress <= this.m_k_Accel_Distance)
			{
				this.m_current_speed += this.m_k_Accel * Time.deltaTime;
			}
			else if (this.m_progress >= 1f - this.m_k_Decel_Distance)
			{
				this.m_current_speed -= this.m_k_Decel * Time.deltaTime;
			}
			else
			{
				this.m_current_speed = this.m_k_Speed;
			}
			this.m_current_speed = Mathf.Clamp(this.m_current_speed, 0.1f, this.m_k_Speed);
			this.m_current_speed *= this.m_modifier;
			return this.m_current_speed;
		}

		// Token: 0x06001DD7 RID: 7639 RVA: 0x00095214 File Offset: 0x00093414
		public void Update()
		{
			if (!this.m_owner)
			{
				return;
			}
			if (this.m_totaldist <= 0f)
			{
				this.method_1();
			}
			this.m_dist += this.method_0() * Time.deltaTime;
			this.m_progress = Mathf.Clamp(this.m_dist / this.m_totaldist, 0f, 1f);
			Vector2 vector = Vector2.Lerp(this.m_start, this.m_end, this.m_progress);
			this.m_delta = vector - this.m_pos;
			this.m_pos = vector;
			if (this.m_dist >= this.m_totaldist)
			{
				this.method_1();
			}
		}

		// Token: 0x06001DD8 RID: 7640 RVA: 0x000952C4 File Offset: 0x000934C4
		private void method_1()
		{
			this.method_2();
			this.m_start = this.m_end;
			this.m_end = this.method_3();
			this.m_totaldist = Vector2.Distance(this.m_start, this.m_end);
			this.m_progress = 0f;
			this.m_dist = 0f;
			this.m_delta = Vector2.zero;
		}

		// Token: 0x06001DD9 RID: 7641 RVA: 0x00095328 File Offset: 0x00093528
		private void method_2()
		{
			this.m_modifier = 1f;
			if (this.m_owner != null && this.m_owner.m_owner != null && this.m_owner.m_owner.vmethod_8() == Entity.EntityType.Player)
			{
				EntityPlayer entityPlayer = (EntityPlayer)this.m_owner.m_owner;
				if (entityPlayer != null && entityPlayer.PlayerEffectManager_0 != null)
				{
					this.m_modifier = entityPlayer.PlayerEffectManager_0.method_0(EffectType.WeaponSway);
				}
			}
		}

		// Token: 0x06001DDA RID: 7642 RVA: 0x000953AC File Offset: 0x000935AC
		private Vector2 method_3()
		{
			Vector2 zero = Vector2.zero;
			float num = global::UnityEngine.Random.Range(0f, 1f) * 360f * 0.017453292f;
			zero.x = Mathf.Cos(num) * this.m_k_Radius * this.m_modifier;
			zero.y = Mathf.Sin(num) * this.m_k_Radius * this.m_modifier;
			return zero;
		}

		// Token: 0x06001DDB RID: 7643 RVA: 0x0001502F File Offset: 0x0001322F
		public Quaternion method_4()
		{
			return Quaternion.Euler(this.m_pos.x, 0f, this.m_pos.y);
		}

		// Token: 0x06001DDC RID: 7644 RVA: 0x00015051 File Offset: 0x00013251
		public float method_5()
		{
			return this.m_delta.x;
		}

		// Token: 0x06001DDD RID: 7645 RVA: 0x0001505E File Offset: 0x0001325E
		public float method_6()
		{
			return this.m_delta.y;
		}

		// Token: 0x04001382 RID: 4994
		public float m_k_Radius;

		// Token: 0x04001383 RID: 4995
		public float m_k_Speed;

		// Token: 0x04001384 RID: 4996
		public float m_k_Accel;

		// Token: 0x04001385 RID: 4997
		public float m_k_Decel;

		// Token: 0x04001386 RID: 4998
		public float m_k_Accel_Distance;

		// Token: 0x04001387 RID: 4999
		public float m_k_Decel_Distance;

		// Token: 0x04001388 RID: 5000
		private Vector2 m_pos = Vector2.zero;

		// Token: 0x04001389 RID: 5001
		private Vector2 m_start = Vector2.zero;

		// Token: 0x0400138A RID: 5002
		private Vector2 m_end = Vector2.zero;

		// Token: 0x0400138B RID: 5003
		private Vector2 m_delta = Vector2.zero;

		// Token: 0x0400138C RID: 5004
		private float m_totaldist;

		// Token: 0x0400138D RID: 5005
		private float m_progress;

		// Token: 0x0400138E RID: 5006
		private float m_dist;

		// Token: 0x0400138F RID: 5007
		private float m_current_speed;

		// Token: 0x04001390 RID: 5008
		private EntityWeapon m_owner;

		// Token: 0x04001391 RID: 5009
		private float m_modifier = 1f;
	}

	// Token: 0x02000476 RID: 1142
	public enum ReloadType
	{
		// Token: 0x04001393 RID: 5011
		Invalid = -1,
		// Token: 0x04001394 RID: 5012
		Standard,
		// Token: 0x04001395 RID: 5013
		CustomA,
		// Token: 0x04001396 RID: 5014
		CustomB,
		// Token: 0x04001397 RID: 5015
		Max
	}

	// Token: 0x02000477 RID: 1143
	public enum ScopeMaskType
	{
		// Token: 0x04001399 RID: 5017
		NoScope,
		// Token: 0x0400139A RID: 5018
		Scope01,
		// Token: 0x0400139B RID: 5019
		Scope02,
		// Token: 0x0400139C RID: 5020
		Scope03,
		// Token: 0x0400139D RID: 5021
		Scope04,
		// Token: 0x0400139E RID: 5022
		Scope05,
		// Token: 0x0400139F RID: 5023
		Scope06,
		// Token: 0x040013A0 RID: 5024
		Max
	}

	// Token: 0x02000478 RID: 1144
	public enum ScopeHudType
	{
		// Token: 0x040013A2 RID: 5026
		NoScopeHud,
		// Token: 0x040013A3 RID: 5027
		Primary,
		// Token: 0x040013A4 RID: 5028
		Intermediate,
		// Token: 0x040013A5 RID: 5029
		Advanced,
		// Token: 0x040013A6 RID: 5030
		Max
	}

	// Token: 0x02000479 RID: 1145
	public enum BurstFireStage
	{
		// Token: 0x040013A8 RID: 5032
		NoneBurst,
		// Token: 0x040013A9 RID: 5033
		Bursting
	}
}
