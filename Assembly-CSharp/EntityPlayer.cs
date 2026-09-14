using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Xml.Serialization;
using BHV;
using BHV_FSM;
using Core;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x0200045C RID: 1116
public class EntityPlayer : Entity, MeleeAttacker, KnockBackInterface, InteractionClient, IDamageListener, InstantiateManager.InstanciationClient
{
	// Token: 0x1700016E RID: 366
	// (get) Token: 0x06001BDE RID: 7134 RVA: 0x000140A3 File Offset: 0x000122A3
	public VFXManager VFXManager_0
	{
		get
		{
			return this.m_vfxMgr;
		}
	}

	// Token: 0x1700016F RID: 367
	// (get) Token: 0x06001BDF RID: 7135 RVA: 0x000140AB File Offset: 0x000122AB
	public BaseEventTriggerCtl BaseEventTriggerCtl_0
	{
		get
		{
			return this.m_eventTriggerCtl;
		}
	}

	// Token: 0x17000170 RID: 368
	// (get) Token: 0x06001BE0 RID: 7136 RVA: 0x000140B3 File Offset: 0x000122B3
	public BHVSecondWindManager BHVSecondWindManager_0
	{
		get
		{
			return this.m_secondWindManager;
		}
	}

	// Token: 0x17000171 RID: 369
	// (get) Token: 0x06001BE1 RID: 7137 RVA: 0x000140BB File Offset: 0x000122BB
	public PlayerSkillManage PlayerSkillManage_0
	{
		get
		{
			return this.m_skillManager;
		}
	}

	// Token: 0x17000172 RID: 370
	// (get) Token: 0x06001BE2 RID: 7138 RVA: 0x000140C3 File Offset: 0x000122C3
	public SkillTreeStatus SkillTreeStatus_0
	{
		get
		{
			return this.m_skillTreeStatus;
		}
	}

	// Token: 0x17000173 RID: 371
	// (get) Token: 0x06001BE3 RID: 7139 RVA: 0x000140CB File Offset: 0x000122CB
	public PlayerEffectManager PlayerEffectManager_0
	{
		get
		{
			return this.m_effectMgr;
		}
	}

	// Token: 0x06001BE4 RID: 7140 RVA: 0x0008B2CC File Offset: 0x000894CC
	protected override void Awake()
	{
		this.m_playerId = (int)base.photonView.Object_0[0];
		base.Awake();
		this.m_session = MonoSingleton<Session>.Instance;
		this.sightTestCache = new Dictionary<Entity, int>();
		if (InteractionManager.InteractionManager_0)
		{
			InteractionManager.InteractionManager_0.method_0(this);
		}
		this.m_secondWindManager = new BHVSecondWindManager(this);
	}

	// Token: 0x06001BE5 RID: 7141 RVA: 0x0008B330 File Offset: 0x00089530
	protected override void OnDestroy()
	{
		if (this.m_playerInfo != null && this.m_playerInfo.IsMyActor())
		{
			ServiceWrapperBase<DeathCamManager>.Instance.method_4(this);
		}
		base.OnDestroy();
		if (this.m_fpHandMaterial != null)
		{
			global::UnityEngine.Object.Destroy(this.m_fpHandMaterial);
			this.m_fpHandMaterial = null;
		}
		if (InteractionManager.InteractionManager_0)
		{
			InteractionManager.InteractionManager_0.method_1(this);
		}
		if (this.m_playerFirstPersonInventoryManager != null)
		{
			global::UnityEngine.Object.Destroy(this.m_playerFirstPersonInventoryManager.gameObject);
		}
	}

	// Token: 0x06001BE6 RID: 7142 RVA: 0x0008B3C0 File Offset: 0x000895C0
	public override AnimationManager vmethod_12()
	{
		if (base.gameObject == null)
		{
			return null;
		}
		return base.GetComponent<PlayerAnimationManagerFSM>();
	}

	// Token: 0x06001BE7 RID: 7143 RVA: 0x0008B3E8 File Offset: 0x000895E8
	public override void Start()
	{
		this.m_equipment = base.GetComponent<EquipmentInventoryEntityPlayer>();
		this.m_collisionManager = base.GetComponent<CollisionManager>();
		this.m_instanceInput = base.GetComponent<InstanceInput>();
		this.m_playerController = base.GetComponent<PlayerController>();
		this.m_playerBehavior = (PlayerBehavior)base.GetComponent(typeof(PlayerBehavior));
		this.m_vfxMgr = base.GetComponentInChildren<VFXManager>();
		this.m_eventTriggerCtl = base.GetComponent<BaseEventTriggerCtl>();
		PlayerInfoSync playerInfoSync = this.vmethod_25();
		if (playerInfoSync != null)
		{
			playerInfoSync.method_6(this);
			if (playerInfoSync.PlayerState_0 > PlayerInfoSync.PlayerState.None)
			{
				this.method_23();
			}
			else
			{
				this.m_handler_statechanged = new PlayerInfoSync.OnPlayerStateChanged_Handler(this.method_23);
				playerInfoSync.Event_0 += this.m_handler_statechanged;
			}
		}
		base.name = base.name + "(" + playerInfoSync.m_name + ")";
		this.m_name = playerInfoSync.m_name;
		DamageManager.DamageManager_0.method_3(this);
		base.Start();
		this.m_ability.method_0(new Throw());
		this.m_ability.method_0(new SwitchWeapon());
		this.m_ability.method_0(new EquipWeapon());
		this.m_ability.method_0(new UnequipWeapon());
		this.m_ability.method_0(new EquipShield());
		this.m_ability.method_0(new UnequipShield());
		this.m_ability.method_0(new UnequipClassMode());
		this.m_ability.method_0(new EquipClassMode());
		this.m_ability.method_0(new EquipOutfit());
		this.m_ability.method_0(new Tidy());
		this.m_ability.method_0(new UnequipOutfit());
		this.m_ability.method_0(new DropItem());
		this.m_ability.method_0(new SwapItems());
		this.m_ability.method_0(new SwapWeapons());
		this.m_ability.method_0(new Melee());
		this.m_ability.method_0(new EntityInteraction());
		this.m_ability.method_0(new LevelTriggerInteraction());
		this.m_ability.method_0(new SecondWindRevive());
		this.m_ability.method_0(new SecondWindQuickEnd());
		this.m_ability.method_0(new KnockBack());
		this.m_ability.method_0(new BerserkDash());
		this.m_relatedPlayer = this;
		this.m_isInBattle = true;
		this.m_skillManager = base.GetComponent<PlayerSkillManage>();
		this.m_skillManager.vmethod_0();
		this.m_skillTreeStatus = base.GetComponent<SkillTreeStatus>();
		this.m_skillTreeStatus.method_0();
		this.m_effectMgr = new PlayerEffectManager(this);
		StatisticsManager.StatSheet personalStatSheet = MonoSingleton<StatisticsManager>.Instance.GetCurrentSession().GetPersonalStatSheet(this.m_playerInfo);
		if (personalStatSheet != null)
		{
			personalStatSheet.Reset(this.m_name);
		}
		this.method_126();
		this.method_12();
		this.method_11();
	}

	// Token: 0x06001BE8 RID: 7144 RVA: 0x0008B6AC File Offset: 0x000898AC
	public void method_10()
	{
		MapObjectMark component = base.gameObject.GetComponent<MapObjectMark>();
		if (component != null)
		{
			component.method_1();
		}
	}

	// Token: 0x06001BE9 RID: 7145 RVA: 0x0008B6D4 File Offset: 0x000898D4
	public void method_11()
	{
		MapObjectMark component = base.gameObject.GetComponent<MapObjectMark>();
		if (component != null)
		{
			global::UnityEngine.Object.Destroy(component);
		}
		PlayerInfoSync playerInfoSync = this.vmethod_25();
		PlayerInfoSync localPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer();
		if (playerInfoSync != null && localPlayer != null && !playerInfoSync.IsMyActor())
		{
			if (playerInfoSync.m_teamID == localPlayer.m_teamID)
			{
				MapObjectMark mapObjectMark = base.gameObject.AddComponent<MapObjectMark>();
				mapObjectMark.iCharacterID = playerInfoSync.m_characterId;
				mapObjectMark.bAlwaysOnMap = true;
				mapObjectMark.ObjType = UIMapDataManager.MiniMapObjectType.TeamMate;
				mapObjectMark.method_0();
			}
			else if (MonoSingleton<Session>.Instance.method_12())
			{
				MapObjectMark mapObjectMark2 = base.gameObject.AddComponent<MapObjectMark>();
				mapObjectMark2.bAlwaysOnMap = true;
				mapObjectMark2.ObjType = UIMapDataManager.MiniMapObjectType.EnemyPlayer;
				mapObjectMark2.iCharacterID = playerInfoSync.m_characterId;
				mapObjectMark2.method_0();
			}
		}
	}

	// Token: 0x06001BEA RID: 7146 RVA: 0x000140D3 File Offset: 0x000122D3
	protected void method_12()
	{
		this.m_guildEffectMgr = new PlayerGuildEffectManage(this);
	}

	// Token: 0x06001BEB RID: 7147 RVA: 0x0008B7A8 File Offset: 0x000899A8
	public override void Update()
	{
		base.Update();
		if (this.m_relatedPlayer == null && MonoSingleton<Session>.Instance.method_16())
		{
			this.Start();
		}
		if (this.m_playerIsSpawned)
		{
			if (MonoSingleton<Session>.Instance.method_15())
			{
				SessionInfo.SessionInfo_0.method_4();
			}
			this.m_playerIsSpawned = false;
		}
		EntityShield entityShield = this.vmethod_18();
		if (entityShield != null && this.vmethod_40() > 0)
		{
			entityShield.method_23();
		}
		if (!MonoSingleton<Session>.Instance.method_16())
		{
			this.method_22();
		}
		this.method_62();
		this.method_63();
		if (this.m_weaponReady.Update(this.vmethod_16() != null))
		{
			this.method_137();
		}
		if (this.m_shieldReady.Update(this.vmethod_18() != null))
		{
			this.method_137();
		}
		if (this.vmethod_16() == null)
		{
			this.method_99(Quaternion.Euler(0f, 0f, 0f), 0f);
		}
	}

	// Token: 0x06001BEC RID: 7148 RVA: 0x0008B8A8 File Offset: 0x00089AA8
	public float method_13(EffectType effectType_0, AffectType affectType_0)
	{
		float num = this.SkillTreeStatus_0.method_5(affectType_0);
		ItemDNA itemDNA = this.method_40();
		if (itemDNA != null)
		{
			ClassModeDNA classModeDNA = itemDNA.method_8();
			if (classModeDNA != null)
			{
				num = classModeDNA.m_attribute.method_1(effectType_0, affectType_0, classModeDNA.m_level);
			}
		}
		return num;
	}

	// Token: 0x06001BED RID: 7149 RVA: 0x0008B8EC File Offset: 0x00089AEC
	public int method_14()
	{
		ItemDNA itemDNA = this.method_40();
		if (itemDNA != null)
		{
			ClassModeDNA classModeDNA = itemDNA.method_8();
			if (classModeDNA != null)
			{
				return classModeDNA.m_level;
			}
		}
		return 0;
	}

	// Token: 0x06001BEE RID: 7150 RVA: 0x0008B918 File Offset: 0x00089B18
	public float method_15(EffectType effectType_0, AffectType affectType_0)
	{
		float num = this.SkillTreeStatus_0.method_5(affectType_0);
		ItemDNA itemDNA = this.method_42();
		if (itemDNA != null)
		{
			SkillAttributeConfig skillAttributeConfig = WeaponExtraAttributeStore.WeaponExtraAttributeStore_0.method_0(itemDNA.method_6().m_extraEffect, itemDNA.method_6().m_extraEffectIndex, itemDNA.ItemRarity_0, effectType_0, itemDNA.method_0());
			if (skillAttributeConfig != null)
			{
				if (skillAttributeConfig.m_affectType == affectType_0)
				{
					num = skillAttributeConfig.m_attrValue;
					if (affectType_0 == AffectType.Scale)
					{
						num += 1f;
					}
				}
				else
				{
					DebugUtils.LogError(LogCategory.Gamelogic, string.Format("{0} operation error, correct: {1}, current: {2}", effectType_0, affectType_0, skillAttributeConfig.m_affectType));
				}
			}
		}
		return num;
	}

	// Token: 0x06001BEF RID: 7151 RVA: 0x0008B9B4 File Offset: 0x00089BB4
	public float method_16(EffectType effectType_0, AffectType affectType_0)
	{
		float num = this.SkillTreeStatus_0.method_5(affectType_0);
		ItemDNA itemDNA = this.method_39();
		if (itemDNA != null)
		{
			SkillAttributeConfig skillAttributeConfig = ShieldExtraAttributeStore.ShieldExtraAttributeStore_0.method_0(itemDNA.method_7().m_extraEffect, itemDNA.method_7().m_extraEffectIndex, itemDNA.ItemRarity_0, effectType_0, itemDNA.method_0());
			if (skillAttributeConfig != null)
			{
				if (skillAttributeConfig.m_affectType == affectType_0)
				{
					num = skillAttributeConfig.m_attrValue;
					if (affectType_0 == AffectType.Scale)
					{
						num += 1f;
					}
				}
				else
				{
					DebugUtils.LogError(LogCategory.Gamelogic, string.Format("{0} operation error, correct: {1}, current: {2}", effectType_0, affectType_0, skillAttributeConfig.m_affectType));
				}
			}
		}
		return num;
	}

	// Token: 0x06001BF0 RID: 7152 RVA: 0x000140E1 File Offset: 0x000122E1
	public float method_17(EffectType effectType_0, AffectType affectType_0)
	{
		return this.m_guildEffectMgr.method_0(effectType_0, affectType_0);
	}

	// Token: 0x06001BF1 RID: 7153 RVA: 0x0008BA50 File Offset: 0x00089C50
	private Entity method_18()
	{
		Ray ray = new Ray(this.vmethod_23(), this.vmethod_27());
		Collider collider = null;
		float maxValue = float.MaxValue;
		return TargetingService.smethod_2(ray, this, out collider, ref maxValue, ColliderType.WeakPoint, true);
	}

	// Token: 0x06001BF2 RID: 7154 RVA: 0x0000311B File Offset: 0x0000131B
	private void method_19()
	{
	}

	// Token: 0x06001BF3 RID: 7155 RVA: 0x000140F0 File Offset: 0x000122F0
	public void LateUpdate()
	{
		if (this.m_badassFpsCamera != null)
		{
			this.m_badassFpsCamera.method_7(-1);
		}
	}

	// Token: 0x06001BF4 RID: 7156 RVA: 0x0001410C File Offset: 0x0001230C
	public override void vmethod_24()
	{
		if (this.m_playerBehavior == null)
		{
			base.vmethod_24();
		}
		else
		{
			this.m_playerBehavior.method_28();
		}
	}

	// Token: 0x06001BF5 RID: 7157 RVA: 0x0001412F File Offset: 0x0001232F
	public int method_20()
	{
		if (this.m_playerInfo)
		{
			return this.m_playerInfo.m_characterId;
		}
		return -1;
	}

	// Token: 0x06001BF6 RID: 7158 RVA: 0x0001414B File Offset: 0x0001234B
	public override string vmethod_4()
	{
		return this.m_name;
	}

	// Token: 0x06001BF7 RID: 7159 RVA: 0x0008BA88 File Offset: 0x00089C88
	public void method_21()
	{
		if (!MonoSingleton<Session>.Instance.method_16())
		{
			PlayerInfoSync localPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer();
			if (localPlayer == null)
			{
				return;
			}
			Entity entity = localPlayer.GetEntity();
			if (entity == null)
			{
				return;
			}
			if (entity.vmethod_9() == this.vmethod_9() && MonoSingleton<GraphicsMgr>.Instance != null && MonoSingleton<GraphicsMgr>.Instance.method_21() != null)
			{
				MonoSingleton<GraphicsMgr>.Instance.method_21().method_9(this.method_114(), new Vector3(0f, 0.3f, 0f), this.vmethod_4(), NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_DUMMY);
			}
		}
		else if (MonoSingleton<GraphicsMgr>.Instance != null && MonoSingleton<GraphicsMgr>.Instance.method_21() != null)
		{
			MonoSingleton<GraphicsMgr>.Instance.method_21().method_9(this.method_114(), new Vector3(0f, 0.3f, 0f), this.vmethod_4(), NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_NONE);
		}
		this.m_bTitleAdded = true;
	}

	// Token: 0x06001BF8 RID: 7160 RVA: 0x0008BB80 File Offset: 0x00089D80
	protected void method_22()
	{
		if (this.m_playerInfo == null)
		{
			return;
		}
		if (this.method_114() != null && !this.m_playerInfo.IsMyActor())
		{
			if (MonoSingleton<TargetingManager>.Instance && MonoSingleton<TargetingManager>.Instance.m_aimedEntity == this)
			{
				if (this.m_bTitleAdded && MonoSingleton<GraphicsMgr>.Instance != null)
				{
					NpcTitleMgr npcTitleMgr = MonoSingleton<GraphicsMgr>.Instance.method_21();
					if (npcTitleMgr != null)
					{
						npcTitleMgr.method_6(this.method_114());
						this.m_bTitleAdded = false;
					}
				}
			}
			else if (!this.m_bTitleAdded)
			{
				this.method_21();
			}
		}
	}

	// Token: 0x06001BF9 RID: 7161 RVA: 0x0008BC1C File Offset: 0x00089E1C
	protected void method_23()
	{
		if (this.m_playerInfo.PlayerState_0 > PlayerInfoSync.PlayerState.None)
		{
			base.GetComponent<PlayerAssembly>().method_0(this.m_playerInfo.IsMyActor(), this.m_playerInfo.m_avatarDna.method_5());
			if (this.m_handler_statechanged != null)
			{
				this.m_playerInfo.Event_0 -= this.m_handler_statechanged;
			}
			this.m_playerIsSpawned = true;
		}
	}

	// Token: 0x06001BFA RID: 7162 RVA: 0x0008BC80 File Offset: 0x00089E80
	public IEnumerator method_24()
	{
		m_equipmentReadyTimer.Start(20f);
		yield return StartCoroutine(vmethod_63());
	}
	// Token: 0x06001BFB RID: 7163 RVA: 0x0008BC9C File Offset: 0x00089E9C
	protected virtual IEnumerator vmethod_62(byte byte_0)
	{
		if (vmethod_25() != null)
		{
			DebugUtils.Log(LogCategory.Gamelogic, "player " + vmethod_25().m_name + " add one weapon in instance :" + byte_0);
		}
		else
		{
			DebugUtils.Log(LogCategory.Gamelogic, "player info null. add one weapon in instance ");
		}
		EntityWeapon weapon2;
		while (true)
		{
			if (m_equipment.method_1())
			{
				if (vmethod_25() != null)
				{
					DebugUtils.Log(LogCategory.Gamelogic, "instance player " + vmethod_25().m_name + " m_equipment is ready, slot " + byte_0);
				}
				else
				{
					DebugUtils.Log(LogCategory.Gamelogic, "instance player info null. m_equipment is ready");
				}
				weapon2 = null;
				break;
			}
			if (m_equipmentReadyTimer.method_7())
			{
				DebugUtils.Log(LogCategory.Gamelogic, "m_equipmentReadyTimer Elapsed, must Equipment not Ready");
				yield break;
			}
			yield return 0;
		}
		do
		{
			weapon2 = m_equipment.vmethod_28(byte_0);
			yield return 0;
		}
		while (m_equipment.method_17(byte_0) && weapon2 == null);
		if (vmethod_25() != null)
		{
			DebugUtils.Log(LogCategory.Gamelogic, "instance player " + vmethod_25().m_name + " weapon is ready, slot " + byte_0);
		}
		else
		{
			DebugUtils.Log(LogCategory.Gamelogic, "instance player info null. weapon is ready");
		}
		if (weapon2 != null)
		{
			if (vmethod_25() != null)
			{
				DebugUtils.Log(LogCategory.Gamelogic, "instance player " + vmethod_25().m_name + " weapon not null, slot " + byte_0);
			}
			else
			{
				DebugUtils.Log(LogCategory.Gamelogic, "instance player info null. weapon not null");
			}
			while (!weapon2.m_isReady)
			{
				yield return 0;
			}
			if (vmethod_25() != null && weapon2.method_17() != null)
			{
				DebugUtils.Log(LogCategory.Gamelogic, "instance player " + vmethod_25().m_name + " EquipNewWeapon , slot " + byte_0);
			}
			else
			{
				DebugUtils.Log(LogCategory.Gamelogic, "instance player info null. EquipNewWeapon");
			}
			method_48(weapon2);
			weapon2.vmethod_64();
		}
	}
	// Token: 0x06001BFC RID: 7164 RVA: 0x0008BCC8 File Offset: 0x00089EC8
	protected virtual IEnumerator vmethod_63()
	{
		for (byte i = 0; i < m_equipment.Int32_0; i++)
		{
			yield return StartCoroutine(vmethod_62(i));
		}
		if ((bool)m_equipment.vmethod_27())
		{
			if (m_equipment.vmethod_27().method_17() != null && vmethod_25() != null)
			{
				DebugUtils.Log(LogCategory.Gamelogic, "instance player " + vmethod_25().m_name + " equip weapon " + m_equipment.vmethod_27().method_17().ToString());
			}
			DebugUtils.Log(LogCategory.Gamelogic, "instance player equip weapon ");
			m_equipment.vmethod_27().vmethod_63(this);
			m_equipedWeapon = m_equipment.vmethod_27();
		}
		else
		{
			if (m_equipment != null && vmethod_25() != null)
			{
				DebugUtils.Log(LogCategory.Gamelogic, "instance player " + vmethod_25().m_name + " this shouldn't happened, except tutorial, activeWeapon " + m_equipment.vmethod_55());
			}
			DebugUtils.Log(LogCategory.Gamelogic, "instance player can't equip weapon ");
		}
		method_28();
	}
	// Token: 0x06001BFD RID: 7165 RVA: 0x0008BCE4 File Offset: 0x00089EE4
	public EntityWeapon method_25()
	{
		if (this.m_equipment != null)
		{
			byte b = 0;
			while ((int)b < this.m_equipment.Int32_0)
			{
				EntityWeapon entityWeapon = this.m_equipment.vmethod_28(b);
				if (this.m_equipment.vmethod_55() != b && entityWeapon != null && entityWeapon.method_17() != null && !entityWeapon.method_17().method_3())
				{
					return entityWeapon;
				}
				b += 1;
			}
		}
		return null;
	}

	// Token: 0x06001BFE RID: 7166 RVA: 0x0008BD54 File Offset: 0x00089F54
	public EntityWeapon method_26()
	{
		if (this.m_equipment != null)
		{
			byte b = 0;
			while ((int)b < this.m_equipment.Int32_0)
			{
				EntityWeapon entityWeapon = this.m_equipment.vmethod_28(b);
				if (this.m_equipment.vmethod_55() != b && entityWeapon != null && entityWeapon.method_17() != null && entityWeapon.method_17().method_3())
				{
					return entityWeapon;
				}
				b += 1;
			}
		}
		return null;
	}

	// Token: 0x06001BFF RID: 7167 RVA: 0x00014153 File Offset: 0x00012353
	public EntityWeapon method_27()
	{
		if (this.m_equipment != null)
		{
			return this.m_equipment.vmethod_27();
		}
		return null;
	}

	// Token: 0x06001C00 RID: 7168 RVA: 0x0008BDC4 File Offset: 0x00089FC4
	public void method_28()
	{
		if (!this.vmethod_26())
		{
			this.m_backWeapon = this.method_25();
			if (this.m_backWeapon != null)
			{
				this.m_backWeapon.method_51(this);
			}
			this.m_thighWeapon = this.method_26();
			if (this.m_thighWeapon != null)
			{
				this.m_thighWeapon.method_51(this);
			}
		}
	}

	// Token: 0x06001C01 RID: 7169 RVA: 0x00014170 File Offset: 0x00012370
	public void method_29(byte byte_0)
	{
		base.StartCoroutine(this.vmethod_62(byte_0));
	}

	// Token: 0x06001C02 RID: 7170 RVA: 0x0008BE28 File Offset: 0x0008A028
	protected virtual IEnumerator vmethod_64()
	{
		EntityShield shield2 = null;
		do
		{
			shield2 = m_equipment.vmethod_26();
			yield return 0;
		}
		while (shield2 == null);
		while (!shield2.vmethod_62())
		{
			yield return 0;
		}
		shield2.vmethod_63(this);
	}
	// Token: 0x06001C03 RID: 7171 RVA: 0x0008BE44 File Offset: 0x0008A044
	private IEnumerator method_30()
	{
		int weaponId = 0;
		EntityWeapon weapon2 = null;
		while (m_equipment.vmethod_27() == null)
		{
			yield return 0;
		}
		weapon2 = m_equipment.vmethod_27();
		if (weapon2 != null)
		{
			weaponId = m_equipment.vmethod_27().vmethod_0();
		}
		BadAssNetworkView networkView2 = null;
		do
		{
			networkView2 = BadAssNetworkView.smethod_3(weaponId);
			yield return 0;
		}
		while (networkView2 == null);
		EntityWeapon wp = networkView2.GetComponent<EntityWeapon>();
		while (true)
		{
			if (!wp.vmethod_62())
			{
				if (!(vmethod_16() != wp))
				{
					yield return 0;
					continue;
				}
				break;
			}
			while (true)
			{
				if (!(wp.m_owner == null))
				{
					vmethod_12().OnSwitchWeapon(wp);
					break;
				}
				if (vmethod_16() != wp)
				{
					break;
				}
				yield return 0;
			}
			break;
		}
	}
	// Token: 0x06001C04 RID: 7172 RVA: 0x0008BE60 File Offset: 0x0008A060
	private IEnumerator method_31(int int_0)
	{
		DebugUtils.Log(LogCategory.Gamelogic, "PickUpWeaponWhenReady: Start");
		EntityWeapon weaponToPick2 = null;
		BadAssNetworkView networkView2 = null;
		do
		{
			networkView2 = BadAssNetworkView.smethod_3(int_0);
			yield return 0;
		}
		while (networkView2 == null);
		weaponToPick2 = networkView2.GetComponent<EntityWeapon>();
		weaponToPick2.method_49();
		while (!weaponToPick2.vmethod_62())
		{
			yield return 0;
		}
		method_49(weaponToPick2);
		DebugUtils.Log(LogCategory.Gamelogic, "PickUpWeaponWhenReady: Model instantiated");
	}
	// Token: 0x06001C05 RID: 7173 RVA: 0x0008BE8C File Offset: 0x0008A08C
	private IEnumerator method_32(int int_0, int int_1, bool bool_0)
	{
		DebugUtils.Log(LogCategory.Gamelogic, "PickUpAndSwitchWeaponWhenReady: Start");
		EntityWeapon weaponToPick = null;
		EntityWeapon weaponToDrop = null;
		BadAssNetworkView networkView = null;
		do
		{
			networkView = BadAssNetworkView.smethod_3(int_0);
			yield return 0;
		}
		while (networkView == null);
		weaponToPick = networkView.GetComponent<EntityWeapon>();
		if (int_1 != 0)
		{
			networkView = null;
			do
			{
				networkView = BadAssNetworkView.smethod_3(int_1);
				yield return 0;
			}
			while (networkView == null);
			weaponToDrop = networkView.GetComponent<EntityWeapon>();
		}
		weaponToPick.method_49();
		while (!weaponToPick.vmethod_62())
		{
			yield return 0;
		}
		DebugUtils.Log(LogCategory.Gamelogic, "PickUpAndSwitchWeaponWhenReady: Model instantiated");
		if (weaponToDrop != null)
		{
			weaponToDrop.method_57(this);
			if (bool_0)
			{
				DebugUtils.Log(LogCategory.Gamelogic, "PickUpAndSwitchWeaponWhenReady: Drop weaponToReplace - " + weaponToDrop.vmethod_0() + " - Owner = " + ((!(weaponToDrop.m_owner != null)) ? "None" : weaponToDrop.m_owner.vmethod_0().ToString()));
				weaponToDrop.vmethod_66(weaponToDrop.gameObject.transform.position, weaponToDrop.gameObject.transform.rotation, base.transform.forward);
			}
		}
		method_48(weaponToPick);
		DebugUtils.Log(LogCategory.Gamelogic, "PickUpAndSwitchWeaponWhenReady: Equip weaponToPickup - " + weaponToPick.vmethod_0() + " - Owner = " + ((!(weaponToPick.m_owner != null)) ? "None" : weaponToPick.m_owner.vmethod_0().ToString()));
		BaseEventTriggerCtl trigger = GetComponent<BaseEventTriggerCtl>();
		if (trigger != null)
		{
			trigger.vmethod_1(AudioEventName.UI_Inventory_Equip);
		}
		AnimationManager animMng = vmethod_12();
		if ((bool)animMng)
		{
			animMng.OnPickUpWeapon(weaponToPick);
		}
	}
	// Token: 0x06001C06 RID: 7174 RVA: 0x0008BED4 File Offset: 0x0008A0D4
	private IEnumerator method_33(int int_0)
	{
		BadAssNetworkView networkView2 = null;
		do
		{
			networkView2 = BadAssNetworkView.smethod_3(int_0);
			yield return 0;
		}
		while (networkView2 == null);
		EntityObject claptrap = networkView2.GetComponent<EntityObject>();
		Skeleton skeleton = vmethod_17();
		if (skeleton == null)
		{
			yield break;
		}
		if (!vmethod_26())
		{
			claptrap.transform.parent = vmethod_17().method_5(WeaponType.ShotGun);
			claptrap.transform.localPosition = new Vector3(-0.08f, -0.35f, 0.03f);
			claptrap.transform.localRotation = Quaternion.Euler(330f, 90f, 0f);
			claptrap.transform.localScale = Vector3.one * 0.8f;
			ns0.MonoSingleton<EchoMessageManager>.Instance.method_1();
		}
		else
		{
			claptrap.gameObject.SetActive(value: false);
			MapObjectMark markObjClaptrap = claptrap.gameObject.GetComponent<MapObjectMark>();
			MapObjectMark markObjPlayer = base.gameObject.AddComponent<MapObjectMark>();
			markObjPlayer.bAlwaysOnMap = markObjClaptrap.bAlwaysOnMap;
			markObjPlayer.ObjType = markObjClaptrap.ObjType;
			markObjPlayer.method_0();
			ns0.MonoSingleton<EchoMessageManager>.Instance.method_1();
			ns0.MonoSingleton<ns0.EchoMessageManager>.Instance.method_8("Echo_Soccer_PickClaptrap_01");
			ns0.MonoSingleton<ns0.EchoMessageManager>.Instance.method_8("Echo_Soccer_PickClaptrap_02");
			for (int i = 1; i <= 9; i++)
			{
				ns0.MonoSingleton<EchoMessageManager>.Instance.method_0("Echo_Soccer_CarryingClaptrap_0" + i);
			}
		}
		claptrap.vmethod_65();
		claptrap.method_15(this);
		m_claptrap = claptrap;
		Collider coll = claptrap.GetComponent<Collider>();
		if (coll != null)
		{
			coll.enabled = false;
		}
		Rigidbody body = claptrap.GetComponent<Rigidbody>();
		if (body != null)
		{
			UnityEngine.Object.Destroy(body);
		}
		ns0.MonoSingleton<ScoringManager>.Instance.OnPickedUp(this, claptrap);
		ns0.MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDPvPInfoView>().vmethod_13(vmethod_9());
		if (m_claptrap != null)
		{
			ns0.MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDPvPInfoView>().method_6(vmethod_9());
		}
	}
	// Token: 0x06001C07 RID: 7175 RVA: 0x0008BF00 File Offset: 0x0008A100
	public void imethod_1()
	{
		if (this.PlayerSkillManage_0.vmethod_14())
		{
			base.GetComponent<PlayerAnimationManagerFSM>().OnMeleeSkill();
		}
		else
		{
			this.vmethod_12().OnMelee();
			HunterManage hunterManage = this.PlayerSkillManage_0 as HunterManage;
			if (hunterManage && hunterManage.method_14())
			{
				hunterManage.method_17();
			}
		}
	}

	// Token: 0x06001C08 RID: 7176 RVA: 0x00014180 File Offset: 0x00012380
	private void method_34()
	{
		if (this.m_count_dot > 0)
		{
			this.m_count_dot--;
		}
	}

	// Token: 0x06001C09 RID: 7177 RVA: 0x00014199 File Offset: 0x00012399
	public override bool vmethod_59()
	{
		return this.m_count_dot < DamageManager.DamageManager_0.method_15();
	}

	// Token: 0x06001C0A RID: 7178 RVA: 0x0008BF54 File Offset: 0x0008A154
	public void OnDamaged(DamageContext context)
	{
		if (context.m_victim == this)
		{
			try
			{
				AnimationManager animationManager = this.vmethod_12();
				if (animationManager != null)
				{
					animationManager.OnDamaged(context.m_damageInfo);
				}
			}
			catch (Exception ex)
			{
				DebugUtils.LogWarning(LogCategory.Framework, "EntityPlayer.OnDamaged[" + ex + "]");
				return;
			}
			bool isTriggeringDamageOverTime = context.m_damageInfo.m_isTriggeringDamageOverTime;
			bool flag = this.method_36(context);
			float num = DamageManager.DamageManager_0.method_5(context.m_damageInfo.m_elementalType, context.m_victim, context.m_killer);
			if (isTriggeringDamageOverTime || flag)
			{
				this.m_count_dot++;
				base.Invoke("DOTFinish", num);
			}
			if (this.method_35(context))
			{
				BadAssFPSCamera badAssFPSCamera = this.method_45();
				if (this.VFXManager_0 != null && badAssFPSCamera != null)
				{
					if (MonoSingleton<GraphicsMgr>.Instance != null)
					{
						MonoSingleton<GraphicsMgr>.Instance.method_24().method_3(this, ENPCParticleType.E_DamageShieldBroken, 0f);
					}
					BaseEventTriggerCtl component = base.GetComponent<BaseEventTriggerCtl>();
					if (component != null)
					{
						component.vmethod_1(AudioEventName.Chr_Shr_Shield_Power_Down);
					}
				}
			}
			if (this.m_playerInfo.IsMyActor() && MonoSingleton<GraphicsMgr>.Instance != null)
			{
				if (isTriggeringDamageOverTime)
				{
					switch (context.m_damageInfo.m_elementalType)
					{
					case AttackInfo.ElementalType.Fire:
						MonoSingleton<GraphicsMgr>.Instance.method_24().method_3(this, ENPCParticleType.E_DamageFire, num);
						break;
					case AttackInfo.ElementalType.Shock:
						MonoSingleton<GraphicsMgr>.Instance.method_24().method_3(this, ENPCParticleType.E_DamageElectricity, num);
						break;
					case AttackInfo.ElementalType.Corrosive:
						MonoSingleton<GraphicsMgr>.Instance.method_24().method_3(this, ENPCParticleType.E_DamageVenom, num);
						break;
					}
				}
				else if (flag)
				{
					num = 1f;
					switch (context.m_subType)
					{
					case AttackSubType.DamageOverTimeFire:
						MonoSingleton<GraphicsMgr>.Instance.method_24().method_3(this, ENPCParticleType.E_DamageFire, num);
						break;
					case AttackSubType.DamageOverTimeShock:
						MonoSingleton<GraphicsMgr>.Instance.method_24().method_3(this, ENPCParticleType.E_DamageElectricity, num);
						break;
					case AttackSubType.DamageOverTimeCorrosive:
						MonoSingleton<GraphicsMgr>.Instance.method_24().method_3(this, ENPCParticleType.E_DamageVenom, num);
						break;
					}
				}
			}
			if (MonoSingleton<Session>.Instance.method_15())
			{
				if (!this.m_playerDamageEchoTimer.method_6())
				{
					if (this.vmethod_26())
					{
						MonoSingleton<global::ns0.EchoMessageManager>.Instance.method_8("Echo_Soccer_CarryingClaptrap_Hurt_01");
						MonoSingleton<global::ns0.EchoMessageManager>.Instance.method_8("Echo_Soccer_CarryingClaptrap_Hurt_02");
						this.m_playerDamageEchoTimer.Start(8f);
					}
				}
				else if (!this.m_playerDamageEchoTimer.method_7())
				{
				}
			}
		}
		this.PlayerSkillManage_0.OnDamaged(context);
		if (this.BHVSecondWindManager_0 != null)
		{
			this.BHVSecondWindManager_0.OnReceiveDamage(context);
		}
	}

	// Token: 0x06001C0B RID: 7179 RVA: 0x000141AD File Offset: 0x000123AD
	public bool method_35(DamageContext damageContext_0)
	{
		return damageContext_0.m_victim == this && this.vmethod_44() > 0 && damageContext_0.m_damageInfo.m_shieldDamagePoints > this.vmethod_44();
	}

	// Token: 0x06001C0C RID: 7180 RVA: 0x000141DE File Offset: 0x000123DE
	private bool method_36(DamageContext damageContext_0)
	{
		return damageContext_0.m_subType == AttackSubType.DamageOverTimeFire || damageContext_0.m_subType == AttackSubType.DamageOverTimeShock || damageContext_0.m_subType == AttackSubType.DamageOverTimeCorrosive;
	}

	// Token: 0x06001C0D RID: 7181 RVA: 0x0008C208 File Offset: 0x0008A408
	private EntityPlayer.KillType method_37(KillContext killContext_0)
	{
		EntityPlayer.KillType killType = EntityPlayer.KillType.Others;
		if (killContext_0.m_killer == this)
		{
			if (killContext_0.m_victim == this)
			{
				killType = EntityPlayer.KillType.Suicide;
			}
			else if (killContext_0.m_victim is EntityNpc || killContext_0.m_victim is EntityPlayer)
			{
				killType = EntityPlayer.KillType.IKillEnemy;
			}
		}
		else if (killContext_0.m_victim == this)
		{
			killType = EntityPlayer.KillType.EnemyKillMe;
		}
		else
		{
			killType = EntityPlayer.KillType.Others;
		}
		return killType;
	}

	// Token: 0x06001C0E RID: 7182 RVA: 0x0008C270 File Offset: 0x0008A470
	public void OnEntityKill(KillContext context)
	{
		switch (this.method_37(context))
		{
		case EntityPlayer.KillType.Suicide:
			this.m_lastKiller = context.m_killer;
			this.PlayerSkillManage_0.OnPlayerSuicide();
			break;
		case EntityPlayer.KillType.IKillEnemy:
			this.method_111();
			this.method_112();
			break;
		case EntityPlayer.KillType.EnemyKillMe:
			this.m_lastKiller = context.m_killer;
			this.PlayerSkillManage_0.OnPlayerBeKilled();
			break;
		}
	}

	// Token: 0x06001C0F RID: 7183 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnInstanciate(GameObject instance, InstantiateManager.SpawnRequest request)
	{
	}

	// Token: 0x06001C10 RID: 7184 RVA: 0x000039EC File Offset: 0x00001BEC
	public override Entity.EntityType vmethod_8()
	{
		return Entity.EntityType.Player;
	}

	// Token: 0x06001C11 RID: 7185 RVA: 0x00014204 File Offset: 0x00012404
	public static string[] smethod_0()
	{
		return new string[0];
	}

	// Token: 0x06001C12 RID: 7186 RVA: 0x0008C2DC File Offset: 0x0008A4DC
	public override int vmethod_9()
	{
		PlayerInfoSync playerInfoSync = this.vmethod_25();
		if (playerInfoSync == null)
		{
			return -1;
		}
		return playerInfoSync.m_teamID;
	}

	// Token: 0x06001C13 RID: 7187 RVA: 0x0001420C File Offset: 0x0001240C
	public override EntityWeapon vmethod_16()
	{
		return this.m_equipedWeapon;
	}

	// Token: 0x06001C14 RID: 7188 RVA: 0x00014214 File Offset: 0x00012414
	public override EntityShield vmethod_18()
	{
		return this.vmethod_19().vmethod_26();
	}

	// Token: 0x06001C15 RID: 7189 RVA: 0x0008C304 File Offset: 0x0008A504
	public EntityClassMode method_38()
	{
		EquipmentInventoryEntityPlayer equipmentInventoryEntityPlayer = this.vmethod_19() as EquipmentInventoryEntityPlayer;
		if (equipmentInventoryEntityPlayer != null)
		{
			return equipmentInventoryEntityPlayer.method_19();
		}
		return null;
	}

	// Token: 0x06001C16 RID: 7190 RVA: 0x0008C330 File Offset: 0x0008A530
	public ItemDNA method_39()
	{
		EquipmentInventoryEntityPlayer equipmentInventoryEntityPlayer = this.vmethod_19() as EquipmentInventoryEntityPlayer;
		if (equipmentInventoryEntityPlayer != null)
		{
			return equipmentInventoryEntityPlayer.vmethod_39();
		}
		return null;
	}

	// Token: 0x06001C17 RID: 7191 RVA: 0x0008C35C File Offset: 0x0008A55C
	public ItemDNA method_40()
	{
		EquipmentInventoryEntityPlayer equipmentInventoryEntityPlayer = this.vmethod_19() as EquipmentInventoryEntityPlayer;
		if (equipmentInventoryEntityPlayer != null)
		{
			return equipmentInventoryEntityPlayer.method_13();
		}
		return null;
	}

	// Token: 0x06001C18 RID: 7192 RVA: 0x0008C388 File Offset: 0x0008A588
	public ItemDNA method_41(AvatarSubPart avatarSubPart_0)
	{
		EquipmentInventoryEntityPlayer equipmentInventoryEntityPlayer = this.vmethod_19() as EquipmentInventoryEntityPlayer;
		if (equipmentInventoryEntityPlayer != null)
		{
			return equipmentInventoryEntityPlayer.method_14(avatarSubPart_0);
		}
		return null;
	}

	// Token: 0x06001C19 RID: 7193 RVA: 0x0008C3B4 File Offset: 0x0008A5B4
	public ItemDNA method_42()
	{
		EquipmentInventoryEntityPlayer equipmentInventoryEntityPlayer = this.vmethod_19() as EquipmentInventoryEntityPlayer;
		if (equipmentInventoryEntityPlayer != null)
		{
			return equipmentInventoryEntityPlayer.method_15();
		}
		return null;
	}

	// Token: 0x06001C1A RID: 7194 RVA: 0x00014221 File Offset: 0x00012421
	public override EquipmentInventoryEntity vmethod_19()
	{
		return this.m_equipment;
	}

	// Token: 0x06001C1B RID: 7195 RVA: 0x00014229 File Offset: 0x00012429
	public override CollisionManager vmethod_21()
	{
		return this.m_collisionManager;
	}

	// Token: 0x06001C1C RID: 7196 RVA: 0x00014231 File Offset: 0x00012431
	public InstanceInput method_43()
	{
		return this.m_instanceInput;
	}

	// Token: 0x06001C1D RID: 7197 RVA: 0x0008C3E0 File Offset: 0x0008A5E0
	public override int vmethod_3()
	{
		PlayerInfoSync playerInfoSync = this.vmethod_25();
		return MonoSingleton<LevelingManager>.Instance.method_3(playerInfoSync.m_avatarDna.method_5(), playerInfoSync.m_exp);
	}

	// Token: 0x06001C1E RID: 7198 RVA: 0x00014239 File Offset: 0x00012439
	public void method_44(BadAssFPSCamera badAssFPSCamera_0)
	{
		this.m_badassFpsCamera = badAssFPSCamera_0;
	}

	// Token: 0x06001C1F RID: 7199 RVA: 0x00014242 File Offset: 0x00012442
	public BadAssFPSCamera method_45()
	{
		return this.m_badassFpsCamera;
	}

	// Token: 0x06001C20 RID: 7200 RVA: 0x0001424A File Offset: 0x0001244A
	public Vector3 method_46()
	{
		return this.m_badassFpsCamera.GetPosition();
	}

	// Token: 0x06001C21 RID: 7201 RVA: 0x00014257 File Offset: 0x00012457
	public PlayerBehavior method_47()
	{
		return this.m_playerBehavior;
	}

	// Token: 0x06001C22 RID: 7202 RVA: 0x0001425F File Offset: 0x0001245F
	public override PlayerInfoSync vmethod_25()
	{
		if (this.m_playerInfo == null)
		{
			this.m_playerInfo = this.m_session.TryGetPlayerInfoSyncById(this.m_playerId);
		}
		return this.m_playerInfo;
	}

	// Token: 0x06001C23 RID: 7203 RVA: 0x0001428C File Offset: 0x0001248C
	public override bool vmethod_26()
	{
		return this.m_playerId == NetworkManager.GetActorId();
	}

	// Token: 0x06001C24 RID: 7204 RVA: 0x0008C410 File Offset: 0x0008A610
	public void method_48(EntityWeapon entityWeapon_0)
	{
		DebugUtils.Log(LogCategory.Gamelogic, "EquipNewWeapon started");
		if (this.m_equipedWeapon != null)
		{
			DebugUtils.Log(LogCategory.Gamelogic, "m_equipedWeapon not null" + this.m_equipedWeapon.m_name.ToString());
			this.m_equipedWeapon.vmethod_64();
		}
		entityWeapon_0.method_54(this);
		this.m_equipedWeapon = entityWeapon_0;
		entityWeapon_0.vmethod_63(this);
		this.method_59(false);
		DebugUtils.Log(LogCategory.Gamelogic, "EquipNewWeapon end");
	}

	// Token: 0x06001C25 RID: 7205 RVA: 0x0001429B File Offset: 0x0001249B
	public void method_49(EntityWeapon entityWeapon_0)
	{
		entityWeapon_0.method_54(this);
	}

	// Token: 0x06001C26 RID: 7206 RVA: 0x0008C488 File Offset: 0x0008A688
	public void method_50(EntityWeapon entityWeapon_0)
	{
		if (this.vmethod_26())
		{
			if (this.m_equipedWeapon != null)
			{
				this.m_equipedWeapon.vmethod_64();
			}
		}
		else
		{
			this.method_51(entityWeapon_0);
		}
		this.m_equipedWeapon = entityWeapon_0;
		entityWeapon_0.vmethod_63(this);
		this.method_59(false);
	}

	// Token: 0x06001C27 RID: 7207 RVA: 0x0008C4D4 File Offset: 0x0008A6D4
	public void method_51(EntityWeapon entityWeapon_0)
	{
		if (entityWeapon_0 == this.m_thighWeapon)
		{
			this.m_thighWeapon = null;
		}
		if (entityWeapon_0 == this.m_backWeapon)
		{
			this.m_backWeapon = null;
		}
		if (this.m_equipedWeapon != null)
		{
			this.m_equipedWeapon.method_51(this);
			if (this.m_equipedWeapon.method_99() == WeaponType.RepeaterPistol)
			{
				if (this.m_thighWeapon != null)
				{
					this.m_thighWeapon.vmethod_64();
				}
				this.m_thighWeapon = this.m_equipedWeapon;
			}
			else
			{
				if (this.m_backWeapon != null)
				{
					this.m_backWeapon.vmethod_64();
				}
				this.m_backWeapon = this.m_equipedWeapon;
			}
		}
	}

	// Token: 0x06001C28 RID: 7208 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_65(EntityWeapon entityWeapon_0, byte byte_0)
	{
	}

	// Token: 0x06001C29 RID: 7209 RVA: 0x0000311B File Offset: 0x0000131B
	public void method_52(EntityWeapon entityWeapon_0, byte byte_0, bool bool_0)
	{
	}

	// Token: 0x06001C2A RID: 7210 RVA: 0x0000311B File Offset: 0x0000131B
	public void method_53(EntityWeapon entityWeapon_0, byte byte_0)
	{
	}

	// Token: 0x06001C2B RID: 7211 RVA: 0x000142A4 File Offset: 0x000124A4
	[RPC]
	public void RPC_RequestPickUpWeapon(int weaponToPickId)
	{
		base.StartCoroutine(this.method_31(weaponToPickId));
	}

	// Token: 0x06001C2C RID: 7212 RVA: 0x000142B4 File Offset: 0x000124B4
	[RPC]
	public void RPC_RequestPickUpAndSwitchWeapon(int weaponToPickId, int weaponToDropId, bool throwIt)
	{
		base.StartCoroutine(this.method_32(weaponToPickId, weaponToDropId, throwIt));
	}

	// Token: 0x06001C2D RID: 7213 RVA: 0x0000311B File Offset: 0x0000131B
	public void method_54(EntityObject entityObject_0)
	{
	}

	// Token: 0x06001C2E RID: 7214 RVA: 0x000142C6 File Offset: 0x000124C6
	[RPC]
	public void RPC_RequestPickUpClaptrap(int clapTrapId)
	{
		base.StartCoroutine(this.method_33(clapTrapId));
	}

	// Token: 0x06001C2F RID: 7215 RVA: 0x0000311B File Offset: 0x0000131B
	public void method_55()
	{
	}

	// Token: 0x06001C30 RID: 7216 RVA: 0x0008C580 File Offset: 0x0008A780
	[RPC]
	public void RPC_RequestDropClaptrap(Vector3 pos, Quaternion rot, Vector3 dir)
	{
		if (this.m_claptrap != null)
		{
			this.m_claptrap.gameObject.SetActive(true);
			this.m_claptrap.transform.position = pos;
			this.m_claptrap.transform.rotation = rot;
			this.m_claptrap.method_15(null);
			this.m_claptrap.transform.parent = MonoSingleton<EntityManager>.Instance.m_entityDirectory.transform;
			this.m_claptrap.transform.localScale = Vector3.one;
			if (this.m_claptrap.m_pickable)
			{
				this.m_claptrap.m_pickable.OnDrop();
			}
			this.m_claptrap = null;
			MapObjectMark component = base.gameObject.GetComponent<MapObjectMark>();
			if (component)
			{
				global::UnityEngine.Object.Destroy(component);
			}
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDPvPInfoView>().vmethod_14();
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDPvPInfoView>().method_6(-1);
			if (this.vmethod_26())
			{
				MonoSingleton<global::EchoMessageManager>.Instance.method_1();
				MonoSingleton<global::ns0.EchoMessageManager>.Instance.method_8("Echo_Soccer_CarryingClaptrap_Dying_01");
				MonoSingleton<global::ns0.EchoMessageManager>.Instance.method_8("Echo_Soccer_CarryingClaptrap_Dying_02");
			}
		}
	}

	// Token: 0x06001C31 RID: 7217 RVA: 0x0000311B File Offset: 0x0000131B
	public void method_56()
	{
	}

	// Token: 0x06001C32 RID: 7218 RVA: 0x000142D6 File Offset: 0x000124D6
	public void OnDestroyClaptrap()
	{
		if (this.VFXManager_0 != null)
		{
			this.VFXManager_0.method_4(ENPCParticleType.E_Explode, 0f, true);
		}
		MonoSingleton<global::EchoMessageManager>.Instance.method_1();
	}

	// Token: 0x06001C33 RID: 7219 RVA: 0x00014304 File Offset: 0x00012504
	public int method_57(int int_0)
	{
		return (int)((float)int_0 * this.PlayerEffectManager_0.method_0(EffectType.ClipSize));
	}

	// Token: 0x06001C34 RID: 7220 RVA: 0x0008C6B0 File Offset: 0x0008A8B0
	public IEnumerator method_58(int int_0)
	{
		BadAssNetworkView view2 = null;
		do
		{
			view2 = BadAssNetworkView.smethod_3(int_0);
			yield return 0;
		}
		while (view2 == null);
		EntityObject item = null;
		if (view2 != null)
		{
			item = view2.GetComponent<EntityObject>();
		}
		while (!item.vmethod_62())
		{
			yield return 0;
		}
		item.vmethod_66(base.transform.position, base.transform.rotation, base.transform.forward);
	}
	// Token: 0x06001C35 RID: 7221 RVA: 0x0008C6DC File Offset: 0x0008A8DC
	public void method_59(bool bool_0)
	{
		if (this.m_HandModel == null)
		{
			this.method_60();
		}
		if (this.m_HandModel == null)
		{
			return;
		}
		this.m_HandModel.GetComponent<SkinnedMeshRenderer>().enabled = !bool_0;
		if (this.m_equipedWeapon != null)
		{
			foreach (SkinnedMeshRenderer renderer in this.m_equipedWeapon.GetComponentsInChildren<SkinnedMeshRenderer>())
			{
				renderer.enabled = !bool_0;
			}
		}
		if (MonoSingleton<GraphicsMgr>.Instance != null)
		{
			MonoSingleton<GraphicsMgr>.Instance.mIsHideFpMesh = bool_0;
		}
	}

	// Token: 0x06001C36 RID: 7222 RVA: 0x0008C770 File Offset: 0x0008A970
	public Transform method_60()
	{
		if (this.m_HandModel == null)
		{
			string text = string.Empty;
			switch (this.vmethod_25().m_avatarDna.method_5())
			{
			case AvatarType.SIREN:
				text = "HipsAdjuster/CHR_Siren_Hand_L1_01";
				break;
			case AvatarType.SOLDIER:
				text = "HipsAdjuster/CHR_Soldier_Hand_L1_01";
				break;
			case AvatarType.BERSERKER:
				text = "HipsAdjuster/CHR_Berserker_Hand_L1_01";
				break;
			case AvatarType.HUNTER:
				text = "HipsAdjuster/CHR_Hunter_Hand_L1_01";
				break;
			}
			Skeleton skeleton = this.vmethod_17();
			if (skeleton == null)
			{
				return null;
			}
			Transform transform = skeleton.transform;
			if (transform == null)
			{
				return null;
			}
			this.m_HandModel = transform.Find(text);
		}
		return this.m_HandModel;
	}

	// Token: 0x06001C37 RID: 7223 RVA: 0x0008C818 File Offset: 0x0008AA18
	public Transform method_61(Transform transform_0, string string_0)
	{
		if (transform_0.name.Equals(string_0))
		{
			return transform_0;
		}
		foreach (object obj in transform_0)
		{
			Transform transform = (Transform)obj;
			Transform transform2 = this.method_61(transform, string_0);
			if (transform2 != null)
			{
				return transform2;
			}
		}
		return null;
	}

	// Token: 0x06001C38 RID: 7224 RVA: 0x0000311B File Offset: 0x0000131B
	private void method_62()
	{
	}

	// Token: 0x06001C39 RID: 7225 RVA: 0x0008C894 File Offset: 0x0008AA94
	private void method_63()
	{
		EquipmentInventoryEntity.PropertyFlags propertyFlags = this.vmethod_19().vmethod_24();
		if ((propertyFlags & EquipmentInventoryEntity.PropertyFlags.InBattle) != EquipmentInventoryEntity.PropertyFlags.None)
		{
			this.method_64(true);
		}
		else
		{
			this.method_64(false);
		}
	}

	// Token: 0x06001C3A RID: 7226 RVA: 0x0008C8C4 File Offset: 0x0008AAC4
	private void method_64(bool bool_0)
	{
		this.m_isInBattle = bool_0;
		if (ComponentMonoSingleton<AudioSystem>.Boolean_0 && null != ComponentMonoSingleton<AudioSystem>.Instance.Tensity)
		{
			if (this.m_isInBattle)
			{
				ComponentMonoSingleton<AudioSystem>.Instance.Tensity.method_3(TensityState.Battle, true);
			}
			else
			{
				ComponentMonoSingleton<AudioSystem>.Instance.Tensity.method_3(TensityState.Normal, true);
			}
		}
	}

	// Token: 0x06001C3B RID: 7227 RVA: 0x0008C920 File Offset: 0x0008AB20
	public override bool vmethod_53()
	{
		BHVTaskManager bhvtaskManager = this.vmethod_14();
		if (bhvtaskManager)
		{
			BHVTask bhvtask = bhvtaskManager.method_12();
			if (bhvtask != null)
			{
				return bhvtask.m_Type == BHVTaskType.PlayerDead;
			}
		}
		return false;
	}

	// Token: 0x06001C3C RID: 7228 RVA: 0x0008C954 File Offset: 0x0008AB54
	public bool method_65()
	{
		BHVTaskManager bhvtaskManager = this.vmethod_14();
		if (bhvtaskManager)
		{
			BHVTask bhvtask = bhvtaskManager.method_12();
			if (bhvtask != null)
			{
				return bhvtask.m_Type == BHVTaskType.PlayerDown;
			}
		}
		return false;
	}

	// Token: 0x06001C3D RID: 7229 RVA: 0x0008C988 File Offset: 0x0008AB88
	public float method_66()
	{
		BHVTaskManager bhvtaskManager = this.vmethod_14();
		if (bhvtaskManager != null)
		{
			BHVTaskPlayerDown bhvtaskPlayerDown = bhvtaskManager.method_12() as BHVTaskPlayerDown;
			if (bhvtaskPlayerDown != null)
			{
				return bhvtaskPlayerDown.float_0 / bhvtaskPlayerDown.float_1;
			}
		}
		return 0f;
	}

	// Token: 0x06001C3E RID: 7230 RVA: 0x0008C9C8 File Offset: 0x0008ABC8
	public bool method_67()
	{
		BHVTaskManager bhvtaskManager = this.vmethod_14();
		if (bhvtaskManager)
		{
			BHVTask bhvtask = bhvtaskManager.method_12();
			if (bhvtask != null)
			{
				return bhvtask.m_Type == BHVTaskType.PlayerCripple;
			}
		}
		return false;
	}

	// Token: 0x06001C3F RID: 7231 RVA: 0x0008C9FC File Offset: 0x0008ABFC
	public bool method_68()
	{
		BHVTaskManager bhvtaskManager = this.vmethod_14();
		if (bhvtaskManager)
		{
			BHVTask bhvtask = bhvtaskManager.method_12();
			if (bhvtask != null)
			{
				return bhvtask.m_Type == BHVTaskType.PlayerRevive;
			}
		}
		return false;
	}

	// Token: 0x06001C40 RID: 7232 RVA: 0x0008CA30 File Offset: 0x0008AC30
	public bool method_69()
	{
		BHVTaskManager bhvtaskManager = this.vmethod_14();
		if (bhvtaskManager)
		{
			BHVTask bhvtask = bhvtaskManager.method_12();
			if (bhvtask != null)
			{
				return bhvtask.m_Type == BHVTaskType.PlayerStun;
			}
		}
		return false;
	}

	// Token: 0x06001C41 RID: 7233 RVA: 0x00014317 File Offset: 0x00012517
	public AvatarType method_70()
	{
		if (this.vmethod_25() != null && this.vmethod_25().m_avatarDna != null)
		{
			return this.vmethod_25().m_avatarDna.method_5();
		}
		return AvatarType.TOTAL;
	}

	// Token: 0x06001C42 RID: 7234 RVA: 0x00014346 File Offset: 0x00012546
	public int method_71(int int_0)
	{
		return MonoSingleton<LevelingManager>.Instance.method_5(this.vmethod_25().m_avatarDna.method_5(), int_0);
	}

	// Token: 0x06001C43 RID: 7235 RVA: 0x0008CA64 File Offset: 0x0008AC64
	public float method_72()
	{
		float num = 1f;
		if (MonoSingleton<Session>.Instance.method_12())
		{
			float num2 = MonoSingleton<LevelingManager>.Instance.method_6(this.vmethod_3());
			float num3 = MonoSingleton<LevelingManager>.Instance.method_7();
			num = num3 / num2;
		}
		return num;
	}

	// Token: 0x06001C44 RID: 7236 RVA: 0x0008CAA4 File Offset: 0x0008ACA4
	public float method_73()
	{
		float num3;
		if (MonoSingleton<Session>.Instance.method_12())
		{
			float num = MonoSingleton<LevelingManager>.Instance.method_6(this.vmethod_3());
			float num2 = MonoSingleton<LevelingManager>.Instance.method_7();
			num3 = num2 / num;
		}
		else
		{
			num3 = MonoSingleton<LevelingManager>.Instance.method_6(this.vmethod_3());
		}
		return num3;
	}

	// Token: 0x06001C45 RID: 7237 RVA: 0x0008CAF8 File Offset: 0x0008ACF8
	protected override void OnDrawGizmos()
	{
		base.OnDrawGizmos();
		global::Debug.smethod_7(this.vmethod_28(), this.vmethod_27() * 1000f);
		if (this.m_badassFpsCamera != null)
		{
			global::Debug.smethod_8(this.m_badassFpsCamera.transform.position, this.vmethod_27() * 500f, Color.green);
			RaycastHit raycastHit;
			if (Physics.Raycast(this.vmethod_28(), this.vmethod_27(), out raycastHit, 400f))
			{
				Gizmos.color = Color.red;
				Gizmos.DrawSphere(raycastHit.point, 0.05f);
				global::Debug.smethod_8(raycastHit.point, raycastHit.normal, Color.red * 0.5f);
			}
		}
	}

	// Token: 0x06001C46 RID: 7238 RVA: 0x00014363 File Offset: 0x00012563
	public void OnPlayerRespawnFinish()
	{
		this.method_11();
	}

	// Token: 0x06001C47 RID: 7239 RVA: 0x0008CBB8 File Offset: 0x0008ADB8
	public void OnPlayerRespawn()
	{
		if (this.m_playerController != null)
		{
			this.m_playerController.method_9();
		}
		if (this.m_equipment == null)
		{
			return;
		}
		byte b = 0;
		while ((int)b < this.m_equipment.Int32_0)
		{
			EntityWeapon entityWeapon = this.m_equipment.vmethod_28(b);
			if (entityWeapon != null)
			{
				entityWeapon.OnPlayerRespawn();
			}
			b += 1;
		}
		if (this.m_playerInfo.IsMyActor())
		{
			ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_2(InventoryServiceWrapper.InventoryUpdateType.FullUpdate);
		}
	}

	// Token: 0x06001C48 RID: 7240 RVA: 0x0001436B File Offset: 0x0001256B
	public override Vector3 vmethod_27()
	{
		if (this.m_playerController != null)
		{
			return this.m_playerController.method_22();
		}
		return base.vmethod_27();
	}

	// Token: 0x06001C49 RID: 7241 RVA: 0x0001438D File Offset: 0x0001258D
	public Vector3 method_74()
	{
		if (this.m_playerController != null)
		{
			return this.m_playerController.method_23();
		}
		return Vector3.zero;
	}

	// Token: 0x06001C4A RID: 7242 RVA: 0x000143AE File Offset: 0x000125AE
	public override Vector3 vmethod_28()
	{
		if (this.m_playerController != null)
		{
			return this.m_playerController.method_24();
		}
		return base.vmethod_28();
	}

	// Token: 0x06001C4B RID: 7243 RVA: 0x000143D0 File Offset: 0x000125D0
	public Entity method_75()
	{
		return this.m_lastKiller;
	}

	// Token: 0x06001C4C RID: 7244 RVA: 0x000143D8 File Offset: 0x000125D8
	public void method_76()
	{
		this.m_ability.method_5("Throw", false, 0);
	}

	// Token: 0x06001C4D RID: 7245 RVA: 0x0008CC38 File Offset: 0x0008AE38
	public virtual void vmethod_66(byte byte_0)
	{
		if (MonoSingleton<Session>.Instance != null && !MonoSingleton<Session>.Instance.method_16())
		{
			EntityWeapon entityWeapon = this.vmethod_16();
			if (entityWeapon)
			{
				MonoSingleton<StatisticsManager>.Instance.GetCurrentSession().GetPersonalStatSheet(this.vmethod_25()).method_4(entityWeapon.method_99());
			}
		}
		this.m_ability.method_5("SwitchWeapon", true, (int)byte_0);
	}

	// Token: 0x06001C4E RID: 7246 RVA: 0x000143EC File Offset: 0x000125EC
	public virtual void vmethod_67(byte byte_0, byte byte_1)
	{
		this.m_ability.method_5("EquipWeapon", true, ((int)byte_1 << 8) | (int)byte_0);
	}

	// Token: 0x06001C4F RID: 7247 RVA: 0x00014404 File Offset: 0x00012604
	public virtual void vmethod_68(byte byte_0)
	{
		this.m_ability.method_5("UnequipWeapon", true, (int)byte_0);
	}

	// Token: 0x06001C50 RID: 7248 RVA: 0x00014418 File Offset: 0x00012618
	public virtual void vmethod_69(byte byte_0)
	{
		this.m_ability.method_5("EquipShield", true, (int)byte_0);
	}

	// Token: 0x06001C51 RID: 7249 RVA: 0x0001442C File Offset: 0x0001262C
	public virtual void vmethod_70()
	{
		this.m_ability.method_5("Tidy", true, 0);
	}

	// Token: 0x06001C52 RID: 7250 RVA: 0x00014440 File Offset: 0x00012640
	public virtual void vmethod_71(byte byte_0)
	{
		this.m_ability.method_5("EquipClassMode", true, (int)byte_0);
	}

	// Token: 0x06001C53 RID: 7251 RVA: 0x00014454 File Offset: 0x00012654
	public virtual void vmethod_72(byte byte_0)
	{
		this.m_ability.method_5("EquipOutfit", true, (int)byte_0);
	}

	// Token: 0x06001C54 RID: 7252 RVA: 0x00014468 File Offset: 0x00012668
	public virtual void vmethod_73()
	{
		this.m_ability.method_5("UnequipShield", true, 0);
	}

	// Token: 0x06001C55 RID: 7253 RVA: 0x0001447C File Offset: 0x0001267C
	public virtual void vmethod_74()
	{
		this.m_ability.method_5("UnequipClassMode", true, 0);
	}

	// Token: 0x06001C56 RID: 7254 RVA: 0x00014490 File Offset: 0x00012690
	public virtual void vmethod_75(byte byte_0)
	{
		this.m_ability.method_5("UnequipOutfit", true, (int)byte_0);
	}

	// Token: 0x06001C57 RID: 7255 RVA: 0x000144A4 File Offset: 0x000126A4
	public virtual void vmethod_76(byte byte_0)
	{
		this.m_ability.method_5("DropItem", true, (int)byte_0);
	}

	// Token: 0x06001C58 RID: 7256 RVA: 0x000144B8 File Offset: 0x000126B8
	public virtual void vmethod_77(byte byte_0, byte byte_1)
	{
		this.m_ability.method_5("SwapItems", true, ((int)byte_0 << 8) | (int)byte_1);
	}

	// Token: 0x06001C59 RID: 7257 RVA: 0x000144D0 File Offset: 0x000126D0
	public virtual void vmethod_78(byte byte_0, byte byte_1)
	{
		this.m_ability.method_5("SwapWeapons", true, ((int)byte_0 << 8) | (int)byte_1);
	}

	// Token: 0x06001C5A RID: 7258 RVA: 0x000144E8 File Offset: 0x000126E8
	public void method_77()
	{
		this.m_ability.method_5("Melee", true, 0);
		this.m_pending_melee = true;
	}

	// Token: 0x06001C5B RID: 7259 RVA: 0x00014503 File Offset: 0x00012703
	public void method_78()
	{
		this.m_skillManager.vmethod_1();
	}

	// Token: 0x06001C5C RID: 7260 RVA: 0x0008CCA0 File Offset: 0x0008AEA0
	public void method_79()
	{
		if (MonoSingleton<Session>.Instance.method_16())
		{
			InteractionClient interactionClient = null;
			InteractionClient interactionClient2 = null;
			float num = 0f;
			if (InteractionManager.InteractionManager_0.method_3(this, ref interactionClient, ref interactionClient2, ref num))
			{
				if (interactionClient is Pickable)
				{
					EntityObject entity = (interactionClient as Pickable).m_entity;
					ItemDNA itemDNA = entity.method_13();
					if (itemDNA != null && InteractionManager.InteractionManager_0.method_5(this, itemDNA))
					{
						this.m_ability.method_5("EntityInteraction", false, entity.vmethod_0());
						return;
					}
				}
				else if (!(interactionClient is EntityWeapon))
				{
					interactionClient.imethod_5(this, false);
					return;
				}
			}
		}
		else if (MonoSingleton<TargetingManager>.Instance.m_currentInteraction != null)
		{
			if (MonoSingleton<TargetingManager>.Instance.m_currentInteraction is Pickable)
			{
				EntityObject entity2 = (MonoSingleton<TargetingManager>.Instance.m_currentInteraction as Pickable).m_entity;
				ItemDNA itemDNA2 = entity2.method_13();
				if (itemDNA2 != null && InteractionManager.InteractionManager_0.method_5(this, itemDNA2))
				{
					this.m_ability.method_5("EntityInteraction", false, entity2.vmethod_0());
					return;
				}
			}
			else
			{
				if (MonoSingleton<TargetingManager>.Instance.m_currentInteraction is LevelTrigger)
				{
					LevelTrigger levelTrigger = MonoSingleton<TargetingManager>.Instance.m_currentInteraction as LevelTrigger;
					this.m_ability.method_5("LevelTriggerInteraction", true, levelTrigger.method_0());
					return;
				}
				if (MonoSingleton<TargetingManager>.Instance.m_currentInteraction is EntityPlayer)
				{
					InteractionClient interactionClient3 = null;
					InteractionClient interactionClient4 = null;
					float num2 = 0f;
					if (InteractionManager.InteractionManager_0.method_3(this, ref interactionClient3, ref interactionClient4, ref num2))
					{
						EntityPlayer entityPlayer = interactionClient3 as EntityPlayer;
						if (entityPlayer != null)
						{
							if (entityPlayer == this)
							{
								this.m_ability.method_5("SecondWindQuickEnd", false, entityPlayer.vmethod_0());
								return;
							}
							this.OnSendRevive(entityPlayer);
							this.m_ability.method_5("SecondWindRevive", false, entityPlayer.vmethod_0());
							return;
						}
					}
				}
				else
				{
					InteractionClient interactionClient5 = null;
					InteractionClient interactionClient6 = null;
					float num3 = 0f;
					if (InteractionManager.InteractionManager_0.method_3(this, ref interactionClient5, ref interactionClient6, ref num3) && interactionClient5 is TeleportToTownTrigger)
					{
						interactionClient5.imethod_5(this, false);
					}
				}
			}
		}
	}

	// Token: 0x06001C5D RID: 7261 RVA: 0x0008CEA8 File Offset: 0x0008B0A8
	public void method_80(float float_0)
	{
		PlayerAnimationManagerFSM component = base.GetComponent<PlayerAnimationManagerFSM>();
		component.OnBerserkCharge(float_0);
	}

	// Token: 0x06001C5E RID: 7262 RVA: 0x0008CEC4 File Offset: 0x0008B0C4
	public void method_81(float float_0)
	{
		PlayerAnimationManagerFSM component = base.GetComponent<PlayerAnimationManagerFSM>();
		component.OnBerserkDash(float_0);
	}

	// Token: 0x06001C5F RID: 7263 RVA: 0x0008CEE0 File Offset: 0x0008B0E0
	public void method_82(float float_0)
	{
		PlayerAnimationManagerFSM component = base.GetComponent<PlayerAnimationManagerFSM>();
		component.OnBerserkPunch(float_0);
	}

	// Token: 0x06001C60 RID: 7264 RVA: 0x0008CEFC File Offset: 0x0008B0FC
	public void method_83(float float_0)
	{
		PlayerAnimationManagerFSM component = base.GetComponent<PlayerAnimationManagerFSM>();
		component.OnFireBird(float_0);
	}

	// Token: 0x06001C61 RID: 7265 RVA: 0x0008CF18 File Offset: 0x0008B118
	public void method_84(float float_0)
	{
		PlayerAnimationManagerFSM component = base.GetComponent<PlayerAnimationManagerFSM>();
		component.OnCallback(float_0);
	}

	// Token: 0x06001C62 RID: 7266 RVA: 0x00014510 File Offset: 0x00012710
	public void method_85(float float_0)
	{
		this.vmethod_12().OnThrow(float_0, new AnimationPlayerThrowGrenadeState.SpawnGrenadeDelegate(this.method_86));
	}

	// Token: 0x06001C63 RID: 7267 RVA: 0x0008CF34 File Offset: 0x0008B134
	public void method_86()
	{
		Throw @throw = this.m_ability.method_4("Throw") as Throw;
		if (@throw != null)
		{
			@throw.method_6();
		}
	}

	// Token: 0x06001C64 RID: 7268 RVA: 0x0008CF60 File Offset: 0x0008B160
	public void method_87(bool bool_0)
	{
		PlayerAnimationManagerFSM playerAnimationManagerFSM = this.vmethod_12() as PlayerAnimationManagerFSM;
		if (playerAnimationManagerFSM != null)
		{
			if (bool_0)
			{
				playerAnimationManagerFSM.method_37(0f);
			}
			else
			{
				playerAnimationManagerFSM.method_37(1f);
			}
		}
	}

	// Token: 0x06001C65 RID: 7269 RVA: 0x0001452A File Offset: 0x0001272A
	public bool method_88(byte byte_0)
	{
		return this.m_playerController != null && this.m_playerController.method_40(byte_0);
	}

	// Token: 0x06001C66 RID: 7270 RVA: 0x00014548 File Offset: 0x00012748
	public virtual void vmethod_79(byte byte_0)
	{
		DebugUtils.Log(LogCategory.Default, string.Format("WPNSW_2 vmethod_79 called slot={0}", byte_0));
		if (this.m_equipment != null)
		{
			this.m_equipment.vmethod_54(byte_0);
			base.StartCoroutine(this.method_30());
		}
	}

	// Token: 0x06001C67 RID: 7271 RVA: 0x00014587 File Offset: 0x00012787
	public void method_89(byte byte_0, byte byte_1)
	{
		this.m_equipment.vmethod_43(byte_0, byte_1);
	}

	// Token: 0x06001C68 RID: 7272 RVA: 0x00014596 File Offset: 0x00012796
	public void method_90(byte byte_0)
	{
		this.m_equipment.vmethod_44(byte_0);
	}

	// Token: 0x06001C69 RID: 7273 RVA: 0x000145A4 File Offset: 0x000127A4
	public void method_91(byte byte_0)
	{
		this.m_equipment.vmethod_46(byte_0);
	}

	// Token: 0x06001C6A RID: 7274 RVA: 0x000145B2 File Offset: 0x000127B2
	public void method_92()
	{
		this.m_equipment.vmethod_48();
	}

	// Token: 0x06001C6B RID: 7275 RVA: 0x000145BF File Offset: 0x000127BF
	public void method_93()
	{
		this.m_equipment.vmethod_47();
	}

	// Token: 0x06001C6C RID: 7276 RVA: 0x000145CC File Offset: 0x000127CC
	public void method_94(byte byte_0)
	{
		this.m_equipment.vmethod_50(byte_0);
	}

	// Token: 0x06001C6D RID: 7277 RVA: 0x000145DA File Offset: 0x000127DA
	public void method_95(byte byte_0)
	{
		this.m_equipment.vmethod_51(byte_0);
	}

	// Token: 0x06001C6E RID: 7278 RVA: 0x000145E8 File Offset: 0x000127E8
	public void method_96()
	{
		this.m_equipment.method_32();
	}

	// Token: 0x06001C6F RID: 7279 RVA: 0x000145F5 File Offset: 0x000127F5
	public void method_97(byte byte_0)
	{
		this.m_equipment.vmethod_52(byte_0);
	}

	// Token: 0x06001C70 RID: 7280 RVA: 0x00014603 File Offset: 0x00012803
	public void method_98(byte byte_0)
	{
		this.m_equipment.vmethod_53(byte_0);
	}

	// Token: 0x06001C71 RID: 7281 RVA: 0x0008CFA0 File Offset: 0x0008B1A0
	public override Vector3 vmethod_23()
	{
		Skeleton skeleton = this.vmethod_17();
		if (skeleton)
		{
			Transform transform = skeleton.method_7();
			if (transform)
			{
				Vector3 position = transform.position;
				position.y += global::UnityEngine.Random.Range(-0.1f, 0.1f);
				return position;
			}
		}
		return base.method_1();
	}

	// Token: 0x06001C72 RID: 7282 RVA: 0x00014611 File Offset: 0x00012811
	public void method_99(Quaternion quaternion_0, float float_0)
	{
		this.m_playerController.method_20(quaternion_0, float_0);
	}

	// Token: 0x06001C73 RID: 7283 RVA: 0x0008CFF8 File Offset: 0x0008B1F8
	public void method_100(Quaternion quaternion_0)
	{
		if (this.m_playerBehavior != null)
		{
			this.m_playerBehavior.method_16(quaternion_0.eulerAngles.y);
			this.m_playerBehavior.method_17(quaternion_0.eulerAngles.x);
		}
	}

	// Token: 0x06001C74 RID: 7284 RVA: 0x00014620 File Offset: 0x00012820
	public void method_101(Transform transform_0)
	{
		if (this.m_playerBehavior != null)
		{
			this.m_playerBehavior.method_40(transform_0);
		}
	}

	// Token: 0x06001C75 RID: 7285 RVA: 0x0001463C File Offset: 0x0001283C
	public void method_102()
	{
		if (this.m_playerBehavior != null)
		{
			this.m_playerBehavior.method_41();
		}
	}

	// Token: 0x06001C76 RID: 7286 RVA: 0x00014657 File Offset: 0x00012857
	private Vector3 method_103()
	{
		return this.vmethod_28() + this.m_playerBehavior.method_44() * Time.fixedDeltaTime * 15f;
	}

	// Token: 0x06001C77 RID: 7287 RVA: 0x0008D048 File Offset: 0x0008B248
	private Vector3 method_104()
	{
		if (Vector3.Angle(this.method_74() * 15f, Vector3.zero) < 20f)
		{
			return this.vmethod_27() + this.method_74() * 15f;
		}
		return this.vmethod_27();
	}

	// Token: 0x06001C78 RID: 7288 RVA: 0x0008D098 File Offset: 0x0008B298
	public bool method_105(Entity entity_0)
	{
		Skeleton skeleton = entity_0.vmethod_17();
		if (skeleton)
		{
			Transform transform = skeleton.method_7();
			if (transform != null)
			{
				if (Vector3.Dot(transform.position - this.method_103(), this.method_104()) > 0f)
				{
					Bounds bounds = entity_0.method_6();
					Vector3[] array = new Vector3[]
					{
						bounds.center + new Vector3(-bounds.extents.x, bounds.extents.y, -bounds.extents.z) * 0.9f,
						bounds.center + new Vector3(bounds.extents.x, -bounds.extents.y, -bounds.extents.z) * 0.9f,
						bounds.center + new Vector3(bounds.extents.x, bounds.extents.y, -bounds.extents.z) * 0.9f,
						bounds.center + new Vector3(-bounds.extents.x, -bounds.extents.y, -bounds.extents.z) * 0.9f,
						bounds.center + new Vector3(-bounds.extents.x, bounds.extents.y, bounds.extents.z) * 0.9f,
						bounds.center + new Vector3(bounds.extents.x, -bounds.extents.y, bounds.extents.z) * 0.9f,
						bounds.center + new Vector3(bounds.extents.x, bounds.extents.y, bounds.extents.z) * 0.9f,
						bounds.center + new Vector3(-bounds.extents.x, -bounds.extents.y, bounds.extents.z) * 0.9f
					};
					float num = 0f;
					Vector3 vector = Vector3.zero;
					Ray ray = new Ray(this.method_103(), entity_0.transform.position + bounds.center - this.method_103());
					for (int i = 0; i < array.Length; i++)
					{
						array[i] = entity_0.transform.position + entity_0.transform.TransformDirection(array[i]);
						float num2 = Utils.smethod_15(ray, array[i]);
						if (num2 > num)
						{
							num = num2;
							vector = array[i];
						}
					}
					Vector3 vector2 = 2f * (entity_0.transform.position + bounds.center) - vector;
					Vector3 vector3 = new Vector3(vector.x, vector.y - 2f * (vector.y - (entity_0.transform.position + bounds.center).y), vector.z);
					Vector3 vector4 = new Vector3(vector2.x, vector2.y - 2f * (vector2.y - (entity_0.transform.position + bounds.center).y), vector2.z);
					array[0] = vector;
					array[1] = vector2;
					array[2] = vector3;
					array[3] = vector4;
					array[4] = transform.position;
					array[5] = entity_0.transform.position;
					Collider collider = null;
					int num3 = 6;
					if (this.sightTestCache.ContainsKey(entity_0))
					{
						num3 = this.sightTestCache[entity_0];
						float num4 = 300f;
						ray.direction = array[num3] - this.method_103();
						global::Debug.smethod_8(ray.origin, ray.direction * 1000f, Color.black);
						if (num3 < 4)
						{
							if (TargetingService.smethod_3(ray, this, entity_0, out collider, ref num4, ColliderType.MovementBounding))
							{
								return true;
							}
						}
						else if (TargetingService.smethod_3(ray, this, entity_0, out collider, ref num4, ColliderType.WeakPoint))
						{
							return true;
						}
					}
					for (int j = 0; j < 6; j++)
					{
						if (j != num3)
						{
							float num5 = 300f;
							ray.direction = array[j] - this.method_103();
							global::Debug.smethod_8(ray.origin, ray.direction * 1000f, Color.black);
							if (j < 4)
							{
								if (TargetingService.smethod_3(ray, this, entity_0, out collider, ref num5, ColliderType.MovementBounding))
								{
									this.sightTestCache[entity_0] = j;
									return true;
								}
							}
							else if (TargetingService.smethod_3(ray, this, entity_0, out collider, ref num5, ColliderType.WeakPoint))
							{
								this.sightTestCache[entity_0] = j;
								return true;
							}
						}
					}
				}
				else if (Vector3.Distance(entity_0.transform.position, base.transform.position) < 5f)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x06001C79 RID: 7289 RVA: 0x0008D6FC File Offset: 0x0008B8FC
	public bool method_106(Entity entity_0)
	{
		Skeleton skeleton = entity_0.vmethod_17();
		if (skeleton)
		{
			Transform transform = skeleton.method_7();
			if (transform)
			{
				if (Vector3.Angle(this.method_104(), transform.position - this.method_103()) < 20f)
				{
					return true;
				}
			}
			else if (Vector3.Angle(this.method_104(), base.transform.position - this.method_103()) < 20f)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06001C7A RID: 7290 RVA: 0x0008D778 File Offset: 0x0008B978
	public bool method_107(Entity entity_0)
	{
		Skeleton skeleton = entity_0.vmethod_17();
		if (skeleton)
		{
			Transform transform = skeleton.method_7();
			if (transform)
			{
				if (Vector3.Angle(this.method_104(), transform.position - this.method_103()) < 40f)
				{
					return true;
				}
				if (Vector3.Angle(this.method_104(), base.transform.position - this.method_103()) < 40f)
				{
					return true;
				}
			}
			else if (Vector3.Angle(this.method_104(), base.transform.position - this.method_103()) < 40f)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06001C7B RID: 7291 RVA: 0x00014683 File Offset: 0x00012883
	public bool method_108()
	{
		return this.m_bAimFOVChanging;
	}

	// Token: 0x06001C7C RID: 7292 RVA: 0x0001468B File Offset: 0x0001288B
	public void method_109(bool bool_0)
	{
		this.m_bAimFOVChanging = bool_0;
	}

	// Token: 0x06001C7D RID: 7293 RVA: 0x0008D820 File Offset: 0x0008BA20
	public override bool vmethod_51()
	{
		PlayerInfoSync playerInfoSync = this.vmethod_25();
		if (playerInfoSync == null)
		{
			return base.vmethod_51();
		}
		return playerInfoSync.m_isInvulnerable;
	}

	// Token: 0x06001C7E RID: 7294 RVA: 0x0008D84C File Offset: 0x0008BA4C
	public override void vmethod_52(bool bool_0)
	{
		PlayerInfoSync playerInfoSync = this.vmethod_25();
		if (playerInfoSync == null)
		{
			base.vmethod_52(bool_0);
			return;
		}
		playerInfoSync.m_isInvulnerable = bool_0;
	}

	// Token: 0x06001C7F RID: 7295 RVA: 0x00014694 File Offset: 0x00012894
	public void method_110()
	{
		this.m_playerBehavior.method_43(false);
	}

	// Token: 0x06001C80 RID: 7296 RVA: 0x0008D878 File Offset: 0x0008BA78
	private void method_111()
	{
		float num = this.PlayerEffectManager_0.method_0(EffectType.FixedTimeRegenHealthSpeed);
		if (num <= 0f)
		{
			return;
		}
		float num2 = this.SkillTreeStatus_0.method_7(ESkillType.Bloodlust, 0);
		if (num2 <= 0f)
		{
			return;
		}
		this.PlayerSkillManage_0.RegenHealthManage_0.method_0(num, num2);
	}

	// Token: 0x06001C81 RID: 7297 RVA: 0x0008D8C8 File Offset: 0x0008BAC8
	private void method_112()
	{
		BerserkManage berserkManage = this.PlayerSkillManage_0 as BerserkManage;
		if (berserkManage != null)
		{
			berserkManage.method_31();
		}
	}

	// Token: 0x06001C82 RID: 7298 RVA: 0x0008D8F0 File Offset: 0x0008BAF0
	public void method_113(GameObject gameObject_0)
	{
		this.m_titleObj = gameObject_0;
		Transform transform = this.m_titleObj.transform.parent.Find("Export_Root/Export_Hips");
		if (this.m_titleObj.transform.parent.parent != null)
		{
			this.m_markerParentObj = this.m_titleObj.transform.parent.parent.gameObject;
		}
		if (transform != null)
		{
			this.m_titleObj.transform.parent = transform;
			Vector3 vector = ((!MonoSingleton<Session>.Instance.method_16()) ? new Vector3(this.CharacterSetting_0.m_titleOffsetX, this.CharacterSetting_0.m_titleOffsetY, this.CharacterSetting_0.m_titleOffsetZ) : new Vector3(this.CharacterSetting_0.m_titleOffsetX_Town, this.CharacterSetting_0.m_titleOffsetY_Town, this.CharacterSetting_0.m_titleOffsetZ_Town));
			this.m_titleObj.transform.localPosition = vector;
		}
	}

	// Token: 0x06001C83 RID: 7299 RVA: 0x000146A2 File Offset: 0x000128A2
	public GameObject method_114()
	{
		return this.m_titleObj;
	}

	// Token: 0x06001C84 RID: 7300 RVA: 0x000146AA File Offset: 0x000128AA
	public GameObject method_115()
	{
		return this.m_markerParentObj;
	}

	// Token: 0x06001C85 RID: 7301 RVA: 0x000146B2 File Offset: 0x000128B2
	public void method_116(Transform transform_0)
	{
		this.m_3rdPersonRenderTransform = transform_0;
	}

	// Token: 0x06001C86 RID: 7302 RVA: 0x0008D9E4 File Offset: 0x0008BBE4
	public void method_117(bool bool_0)
	{
		if (this.m_3rdPersonRenderTransform != null)
		{
			foreach (SkinnedMeshRenderer skinnedMeshRenderer in this.m_3rdPersonRenderTransform.GetComponentsInChildren<SkinnedMeshRenderer>())
			{
				if (skinnedMeshRenderer != null)
				{
					skinnedMeshRenderer.enabled = !bool_0;
				}
			}
		}
		if (this.m_equipedWeapon != null)
		{
			this.m_equipedWeapon.method_19(bool_0);
		}
		if (this.m_backWeapon != null)
		{
			this.m_backWeapon.method_19(bool_0);
		}
		if (this.m_thighWeapon != null)
		{
			this.m_thighWeapon.method_19(bool_0);
		}
	}

	// Token: 0x06001C87 RID: 7303 RVA: 0x000146BB File Offset: 0x000128BB
	public void method_118()
	{
		if (this.m_equipment != null)
		{
			this.m_equipment.method_36();
		}
	}

	// Token: 0x06001C88 RID: 7304 RVA: 0x0008DA80 File Offset: 0x0008BC80
	public void method_119(int int_0)
	{
		PlayerAssembly component = base.GetComponent<PlayerAssembly>();
		if (component != null && component.method_12() != null)
		{
			for (int i = 0; i < int_0; i++)
			{
				ItemDNA itemDNA = this.m_equipment.method_23(i);
				if (itemDNA != null && itemDNA.method_9() != null)
				{
					component.method_12().method_11((int)itemDNA.method_9().m_avatarSubpart, itemDNA.method_9().method_1());
					component.method_12().method_13((int)itemDNA.method_9().m_avatarSubpart, itemDNA.method_9().method_2());
					component.method_12().method_7();
				}
			}
		}
	}

	// Token: 0x06001C89 RID: 7305 RVA: 0x0008DB1C File Offset: 0x0008BD1C
	public void method_120(ItemDNA itemDNA_0)
	{
		PlayerAssembly component = base.GetComponent<PlayerAssembly>();
		if (component != null && component.method_11() != null && this.m_playerInfo.IsMyActor() && itemDNA_0.method_9() != null)
		{
			Character character = ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_5();
			int num = this.m_playerInfo.m_avatarDna.method_9(character.AvatarParts, itemDNA_0.method_9().m_avatarSubpart);
			int num2 = this.m_playerInfo.m_avatarDna.method_10(character.AvatarMaterials, itemDNA_0.method_9().m_avatarSubpart);
			component.method_11().method_11((int)itemDNA_0.method_9().m_avatarSubpart, num);
			component.method_11().method_13((int)itemDNA_0.method_9().m_avatarSubpart, num2);
			component.method_11().method_7();
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<CharInfoView>().vmethod_8(true);
		}
	}

	// Token: 0x06001C8A RID: 7306 RVA: 0x0008DC04 File Offset: 0x0008BE04
	public void method_121(ItemDNA itemDNA_0)
	{
		PlayerAssembly component = base.GetComponent<PlayerAssembly>();
		if (component != null && component.method_11() != null && this.m_playerInfo.IsMyActor() && itemDNA_0.method_9() != null)
		{
			component.method_11().method_11((int)itemDNA_0.method_9().m_avatarSubpart, itemDNA_0.method_9().method_1());
			component.method_11().method_13((int)itemDNA_0.method_9().m_avatarSubpart, itemDNA_0.method_9().method_2());
			component.method_11().method_7();
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<CharInfoView>().vmethod_8(true);
		}
	}

	// Token: 0x06001C8B RID: 7307 RVA: 0x0008DCA8 File Offset: 0x0008BEA8
	public void method_122()
	{
		PlayerAssembly component = base.GetComponent<PlayerAssembly>();
		if (component != null && component.method_11() != null && this.m_playerInfo.IsMyActor() && this.m_equipment != null)
		{
			for (int i = 0; i < this.m_equipment.Int32_1; i++)
			{
				ItemDNA itemDNA = this.m_equipment.method_23(i);
				if (itemDNA != null)
				{
					component.method_11().method_11((int)itemDNA.method_9().m_avatarSubpart, itemDNA.method_9().method_1());
					component.method_11().method_13((int)itemDNA.method_9().m_avatarSubpart, itemDNA.method_9().method_2());
				}
			}
			component.method_11().method_7();
		}
	}

	// Token: 0x06001C8C RID: 7308 RVA: 0x0008DD68 File Offset: 0x0008BF68
	public void method_123(int int_0, int int_1, int int_2)
	{
		PlayerAssembly component = base.GetComponent<PlayerAssembly>();
		if (component != null && component.method_11() != null && this.m_playerInfo.IsMyActor())
		{
			component.method_11().method_11(int_0, int_1);
			component.method_11().method_13(int_0, int_2);
			component.method_11().method_7();
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<CharInfoView>().vmethod_8(true);
		}
	}

	// Token: 0x06001C8D RID: 7309 RVA: 0x0008DDD8 File Offset: 0x0008BFD8
	public void method_124(BuildingKitRender buildingKitRender_0)
	{
		PlayerFirstPersonInventoryManager[] componentsInChildren = MonoSingleton<AppManager>.Instance.GetComponentsInChildren<PlayerFirstPersonInventoryManager>(true);
		GameObject gameObject;
		if (componentsInChildren != null && componentsInChildren.Length > 0)
		{
			gameObject = componentsInChildren[0].gameObject;
			buildingKitRender_0.method_5(gameObject);
		}
		else
		{
			gameObject = buildingKitRender_0.method_6();
			Component component = gameObject.GetComponent<MecanimEventEmitter>();
			if (component != null)
			{
				global::UnityEngine.Object.Destroy(component);
			}
			component = gameObject.GetComponent<AudioEventTriggerCtl>();
			if (component != null)
			{
				global::UnityEngine.Object.Destroy(component);
			}
			this.m_playerFirstPersonInventoryManager = gameObject.AddComponent<PlayerFirstPersonInventoryManager>();
			this.m_playerFirstPersonInventoryManager.Skeleton_0 = gameObject.AddComponent<Skeleton>();
			string text = gameObject.name.Replace("(Clone)", string.Empty) + "_InventoryView";
			gameObject.name = text;
			PlayerAnimationIkController playerAnimationIkController = gameObject.AddComponent<PlayerAnimationIkController>();
			playerAnimationIkController.m_enableLeftHandIK = true;
			playerAnimationIkController.m_enableAimIK = false;
			playerAnimationIkController.m_enableLookIK = false;
			gameObject.transform.position = new Vector3(-1000f, -1000f, -1000f);
		}
		PlayerAnimationManagerFSM component2 = base.GetComponent<PlayerAnimationManagerFSM>();
		component2.method_27(gameObject);
	}

	// Token: 0x06001C8E RID: 7310 RVA: 0x000146D6 File Offset: 0x000128D6
	public PlayerFirstPersonInventoryManager method_125()
	{
		return this.m_playerFirstPersonInventoryManager;
	}

	// Token: 0x17000174 RID: 372
	// (get) Token: 0x06001C8F RID: 7311 RVA: 0x000146DE File Offset: 0x000128DE
	public EntityPlayer.CharacterSetting CharacterSetting_0
	{
		get
		{
			return this.m_character_setting;
		}
	}

	// Token: 0x06001C90 RID: 7312 RVA: 0x000146E6 File Offset: 0x000128E6
	protected void method_126()
	{
		this.method_127();
	}

	// Token: 0x06001C91 RID: 7313 RVA: 0x0008DED8 File Offset: 0x0008C0D8
	private void method_127()
	{
		using (MemoryStream memoryStream = new MemoryStream(this.m_config_character.bytes))
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(EntityPlayer.CharacterSetting));
			this.m_character_setting = xmlSerializer.Deserialize(memoryStream) as EntityPlayer.CharacterSetting;
		}
	}

	// Token: 0x06001C92 RID: 7314 RVA: 0x000146EE File Offset: 0x000128EE
	public override float vmethod_33(Entity entity_0, HitInfo hitInfo_0)
	{
		this.PlayerSkillManage_0.vmethod_12(entity_0, hitInfo_0);
		return this.m_victimDamageModifier_skill;
	}

	// Token: 0x06001C93 RID: 7315 RVA: 0x00014703 File Offset: 0x00012903
	public void method_128(float float_0)
	{
		this.m_victimDamageModifier_skill = float_0;
	}

	// Token: 0x06001C94 RID: 7316 RVA: 0x0001470C File Offset: 0x0001290C
	public float method_129()
	{
		return this.m_elementalDamageModifier_skill;
	}

	// Token: 0x06001C95 RID: 7317 RVA: 0x00014714 File Offset: 0x00012914
	public void method_130(float float_0)
	{
		this.m_elementalDamageModifier_skill = float_0;
	}

	// Token: 0x06001C96 RID: 7318 RVA: 0x0008DF34 File Offset: 0x0008C134
	public override void vmethod_55(Dictionary<int, BHVTask> dictionary_0)
	{
		if (dictionary_0 == null)
		{
			return;
		}
		dictionary_0.Add(69, new BHVTaskPlayerSkill());
		dictionary_0.Add(35, new BHVTaskDefault());
		dictionary_0.Add(40, new BHVTaskPlayerDead());
		dictionary_0.Add(50, new BHVTaskPlayerSpawn());
		dictionary_0.Add(57, new BHVTaskPlayerTransfer());
		dictionary_0.Add(98, new BHVTaskPlayerCripple());
		dictionary_0.Add(99, new BHVTaskPlayerDown());
		dictionary_0.Add(100, new BHVTaskPlayerRevive());
		dictionary_0.Add(103, new BHVTaskPlayerStun());
	}

	// Token: 0x06001C97 RID: 7319 RVA: 0x0008DFBC File Offset: 0x0008C1BC
	[RPC]
	private void RPC_RequestAllLifeAndShield(Hashtable data, PhotonMessageInfo info)
	{
		int num = 0;
		int num2 = 1;
		int num3 = (int)data[num];
		for (int i = 0; i < num3; i++)
		{
			int num4 = (int)data[num2++];
			Hashtable hashtable = (Hashtable)data[num2++];
			Entity entity = BadAssNetworkView.smethod_4(num4);
			if (entity)
			{
				EquipmentInventoryEntity equipmentInventoryEntity = entity.vmethod_19();
				equipmentInventoryEntity.vmethod_38(hashtable);
			}
		}
	}

	// Token: 0x06001C98 RID: 7320 RVA: 0x0008E03C File Offset: 0x0008C23C
	public override float vmethod_54(EntityWeapon entityWeapon_0, int int_0)
	{
		if (entityWeapon_0 == null)
		{
			return 0f;
		}
		float num;
		if (entityWeapon_0.m_owner != this)
		{
			num = entityWeapon_0.m_owner.vmethod_54(entityWeapon_0, int_0);
		}
		else
		{
			num = base.vmethod_54(entityWeapon_0, int_0);
			if (this.PlayerSkillManage_0 is FirebirdManage)
			{
				float num2 = this.PlayerEffectManager_0.method_0(EffectType.ElementDamage);
				num *= num2;
			}
			Entity entity = BadAssNetworkView.smethod_4(int_0);
			if (entity != null && entity is EntityPlayer && (entity as EntityPlayer).PlayerSkillManage_0 is FirebirdManage)
			{
				float num3 = (entity as EntityPlayer).PlayerEffectManager_0.method_0(EffectType.ResistElemental);
				num *= num3;
			}
		}
		return num * this.method_72();
	}

	// Token: 0x06001C99 RID: 7321 RVA: 0x0001471D File Offset: 0x0001291D
	public void method_131(Entity entity_0, [Optional] Vector3 vector3_0)
	{
		if (!(entity_0 == null) && vector3_0.magnitude > 0f)
		{
			this.m_ability.method_6("KnockBack", true, vector3_0);
			return;
		}
	}

	// Token: 0x06001C9A RID: 7322 RVA: 0x00014749 File Offset: 0x00012949
	public void imethod_0(Vector3 vector3_0)
	{
		this.m_playerController.method_30(vector3_0);
	}

	// Token: 0x06001C9B RID: 7323 RVA: 0x0000311B File Offset: 0x0000131B
	public void method_132(bool bool_0)
	{
	}

	// Token: 0x06001C9C RID: 7324 RVA: 0x0008E0F0 File Offset: 0x0008C2F0
	public void method_133()
	{
		float num = 7f;
		if (this.m_playerInfo.IsMyActor())
		{
			if (MonoSingleton<GraphicsMgr>.Instance)
			{
				FpEffectMgr fpEffectMgr = MonoSingleton<GraphicsMgr>.Instance.method_20();
				if (fpEffectMgr != null)
				{
					fpEffectMgr.method_4(num, CharacterFxMgr.FX_TYPE.FX_REVIVE);
				}
			}
		}
		else if (MonoSingleton<GraphicsMgr>.Instance)
		{
			CharacterFxMgr characterFxMgr = MonoSingleton<GraphicsMgr>.Instance.method_16();
			if (characterFxMgr != null)
			{
				characterFxMgr.method_4(this, num, CharacterFxMgr.FX_TYPE.FX_REVIVE);
				if (this.m_equipedWeapon)
				{
					characterFxMgr.method_4(this.m_equipedWeapon, num, CharacterFxMgr.FX_TYPE.FX_REVIVE);
				}
				if (this.m_backWeapon)
				{
					characterFxMgr.method_4(this.m_backWeapon, num, CharacterFxMgr.FX_TYPE.FX_REVIVE);
				}
				if (this.m_thighWeapon)
				{
					characterFxMgr.method_4(this.m_thighWeapon, num, CharacterFxMgr.FX_TYPE.FX_REVIVE);
				}
			}
		}
	}

	// Token: 0x06001C9D RID: 7325 RVA: 0x00014757 File Offset: 0x00012957
	public override void vmethod_57(float float_0)
	{
		if (float_0 >= 1f)
		{
			this.m_playerController.method_9();
		}
		else
		{
			this.m_playerController.method_7(float_0);
		}
	}

	// Token: 0x06001C9E RID: 7326 RVA: 0x0008E1AC File Offset: 0x0008C3AC
	public override void vmethod_58(bool bool_0)
	{
		float num = ((!bool_0) ? (1f / this.m_slowdown_marked_move) : this.m_slowdown_marked_move);
		this.m_playerController.method_6(num);
	}

	// Token: 0x06001C9F RID: 7327 RVA: 0x0008E1E0 File Offset: 0x0008C3E0
	public void method_134()
	{
		StatisticsManager.SessionStats currentSession = MonoSingleton<StatisticsManager>.Instance.GetCurrentSession();
		PlayerInfoSync playerInfoSync = this.vmethod_25();
		if (currentSession == null || playerInfoSync == null)
		{
			return;
		}
		StatisticsManager.StatSheet personalStatSheet = currentSession.GetPersonalStatSheet(playerInfoSync);
		if (personalStatSheet == null)
		{
			return;
		}
		personalStatSheet.method_15(playerInfoSync.m_avatarDna.method_5());
	}

	// Token: 0x06001CA0 RID: 7328 RVA: 0x0008E22C File Offset: 0x0008C42C
	public static AttackSubType smethod_1(AttackSubType attackSubType_0)
	{
		AttackSubType attackSubType = attackSubType_0;
		switch (AttackInfo.smethod_0(attackSubType_0))
		{
		case AttackInfo.AttackType.Projectile:
			attackSubType = AttackSubType.ProjectileHunter;
			break;
		case AttackInfo.AttackType.Area:
			attackSubType = AttackSubType.AreaHunter;
			break;
		case AttackInfo.AttackType.Melee:
			attackSubType = AttackSubType.MeleeHunter;
			break;
		}
		return attackSubType;
	}

	// Token: 0x06001CA1 RID: 7329 RVA: 0x0008E268 File Offset: 0x0008C468
	public bool method_135(Entity entity_0, Vector3 vector3_0, float float_0)
	{
		if (entity_0 == null)
		{
			return false;
		}
		if (entity_0.vmethod_19() == null)
		{
			return false;
		}
		if (entity_0.vmethod_19().vmethod_4() <= 0)
		{
			return false;
		}
		if (this.method_136(entity_0))
		{
			return false;
		}
		float num = Vector3.Distance(vector3_0, entity_0.transform.position);
		return num <= float_0;
	}

	// Token: 0x06001CA2 RID: 7330 RVA: 0x0001477A File Offset: 0x0001297A
	private bool method_136(Entity entity_0)
	{
		return this == entity_0 || (entity_0.vmethod_9() == this.vmethod_9() && !this.vmethod_47());
	}

	// Token: 0x06001CA3 RID: 7331 RVA: 0x0008E2C4 File Offset: 0x0008C4C4
	public void OnSwitchWeaponDone()
	{
		this.PlayerSkillManage_0.OnSwitchWeaponDone();
		EntityWeapon entityWeapon = this.vmethod_16();
		if (entityWeapon)
		{
			this.method_137();
		}
	}

	// Token: 0x06001CA4 RID: 7332 RVA: 0x0000311B File Offset: 0x0000131B
	public void method_137()
	{
	}

	// Token: 0x06001CA5 RID: 7333 RVA: 0x0000311B File Offset: 0x0000131B
	public void method_138()
	{
	}

	// Token: 0x06001CA6 RID: 7334 RVA: 0x000147A0 File Offset: 0x000129A0
	public virtual void vmethod_80()
	{
		this.method_137();
	}

	// Token: 0x06001CA7 RID: 7335 RVA: 0x0008E2F4 File Offset: 0x0008C4F4
	public int method_139(int int_0)
	{
		float num = this.PlayerEffectManager_0.method_0(EffectType.BulletDamageScale);
		float num2 = this.PlayerEffectManager_0.method_0(EffectType.BulletDamagePostAdd);
		int num3 = (int)((float)int_0 * num) + PlayerSkillManage.smethod_0(this.vmethod_3(), num2);
		return this.method_140(num3);
	}

	// Token: 0x06001CA8 RID: 7336 RVA: 0x0008E33C File Offset: 0x0008C53C
	public int method_140(int int_0)
	{
		int num = int_0;
		if (MonoSingleton<Session>.Instance.method_12())
		{
			float num2 = MonoSingleton<LevelingManager>.Instance.method_6(this.vmethod_3());
			float num3 = MonoSingleton<LevelingManager>.Instance.method_7();
			float num4 = num3 / num2;
			num = (int)((float)int_0 * num4);
		}
		return num;
	}

	// Token: 0x06001CA9 RID: 7337 RVA: 0x000147A8 File Offset: 0x000129A8
	public int method_141(int int_0)
	{
		if (MonoSingleton<Session>.Instance.method_12())
		{
			return MonoSingleton<LevelingManager>.Instance.method_2();
		}
		return int_0;
	}

	// Token: 0x06001CAA RID: 7338 RVA: 0x0008E380 File Offset: 0x0008C580
	public void method_142(bool bool_0)
	{
		MovementSync component = base.GetComponent<MovementSync>();
		if (component)
		{
			component.method_5(bool_0);
		}
	}

	// Token: 0x06001CAB RID: 7339 RVA: 0x0008E3A4 File Offset: 0x0008C5A4
	public float method_143()
	{
		MovementSync component = base.GetComponent<MovementSync>();
		if (component)
		{
			return component.m_LastCorrectDis;
		}
		return 0f;
	}

	// Token: 0x06001CAC RID: 7340 RVA: 0x000147C2 File Offset: 0x000129C2
	public void method_144(GameObject gameObject_0)
	{
		gameObject_0.rigidbody.AddForce(this.method_145());
	}

	// Token: 0x06001CAD RID: 7341 RVA: 0x0008E3CC File Offset: 0x0008C5CC
	private Vector3 method_145()
	{
		float num = -10f;
		float num2 = 650f;
		Vector3 vector = this.vmethod_27();
		Vector3 vector2 = base.transform.InverseTransformDirection(vector);
		vector = base.transform.TransformDirection(Quaternion.Euler(num, 0f, 0f) * vector2);
		return vector * num2;
	}

	// Token: 0x06001CAE RID: 7342 RVA: 0x0008E428 File Offset: 0x0008C628
	public void method_146(BadAssFPSCamera.ShakeType shakeType_0)
	{
		BadAssFPSCamera badAssFPSCamera = this.method_45();
		if (badAssFPSCamera != null)
		{
			badAssFPSCamera.method_6(shakeType_0);
		}
	}

	// Token: 0x06001CAF RID: 7343 RVA: 0x0008E44C File Offset: 0x0008C64C
	public float method_147()
	{
		EntityWeapon entityWeapon = this.vmethod_16();
		if (entityWeapon != null)
		{
			return entityWeapon.method_103();
		}
		return 0.5f;
	}

	// Token: 0x06001CB0 RID: 7344 RVA: 0x0008E478 File Offset: 0x0008C678
	public virtual bool imethod_2(Ray ray_0, ref float float_0)
	{
		if (MonoSingleton<Session>.Instance == null)
		{
			return false;
		}
		if (!MonoSingleton<Session>.Instance.GetLocalPlayer())
		{
			return false;
		}
		CollisionManager collisionManager = this.vmethod_21();
		RaycastHit raycastHit;
		if (collisionManager != null && collisionManager.method_2(ray_0, out raycastHit, ref float_0))
		{
			if (this.m_playerInfo && !this.m_playerInfo.IsMyActor() && MonoSingleton<GuidanceTipsManager>.Instance != null)
			{
				MonoSingleton<GuidanceTipsManager>.Instance.OnCanInteractWithPlayer();
			}
			return true;
		}
		return false;
	}

	// Token: 0x06001CB1 RID: 7345 RVA: 0x0008E4F8 File Offset: 0x0008C6F8
	public virtual bool imethod_3(Entity entity_0)
	{
		if (!MonoSingleton<Session>.Instance.GetLocalPlayer())
		{
			return false;
		}
		EntityPlayer entityPlayer = entity_0 as EntityPlayer;
		if (entityPlayer == null)
		{
			return false;
		}
		if (entityPlayer == this)
		{
			if (this.method_67() || this.method_65())
			{
				this.m_secondwindInteractionType = E_USE_TYPE.E_SUCIDE;
				return true;
			}
		}
		else
		{
			if (entityPlayer.vmethod_53() || entityPlayer.method_65() || entityPlayer.method_67())
			{
				return false;
			}
			if (entityPlayer.vmethod_9() != this.vmethod_9())
			{
				return false;
			}
			if (this.method_67() || this.method_65())
			{
				this.m_secondwindInteractionType = E_USE_TYPE.E_REVIVE;
				return true;
			}
		}
		return false;
	}

	// Token: 0x06001CB2 RID: 7346 RVA: 0x0008E594 File Offset: 0x0008C794
	public virtual void imethod_5(Entity entity_0, bool bool_0 = false)
	{
		if (entity_0 == null)
		{
			return;
		}
		EntityPlayer entityPlayer = entity_0 as EntityPlayer;
		if (entityPlayer == null)
		{
			return;
		}
		if (!MonoSingleton<Session>.Instance.GetLocalPlayer())
		{
			return;
		}
	}

	// Token: 0x06001CB3 RID: 7347 RVA: 0x000147D5 File Offset: 0x000129D5
	public void method_148(EntityPlayer entityPlayer_0)
	{
		if (this.BHVSecondWindManager_0 == null)
		{
			return;
		}
		this.BHVSecondWindManager_0.method_1(entityPlayer_0);
	}

	// Token: 0x06001CB4 RID: 7348 RVA: 0x0000311D File Offset: 0x0000131D
	public virtual bool imethod_4()
	{
		return false;
	}

	// Token: 0x06001CB5 RID: 7349 RVA: 0x000147EC File Offset: 0x000129EC
	public virtual E_USE_TYPE imethod_6()
	{
		if (this.m_secondwindInteractionType != E_USE_TYPE.E_REVIVE && this.m_secondwindInteractionType != E_USE_TYPE.E_SUCIDE)
		{
			this.m_secondwindInteractionType = E_USE_TYPE.E_REVIVE;
		}
		return this.m_secondwindInteractionType;
	}

	// Token: 0x06001CB6 RID: 7350 RVA: 0x0008E5D0 File Offset: 0x0008C7D0
	public override float vmethod_61()
	{
		return this.PlayerEffectManager_0.method_0(EffectType.CriticalHitDamage);
	}

	// Token: 0x06001CB7 RID: 7351 RVA: 0x0008E5EC File Offset: 0x0008C7EC
	public void OnEnterPlayerCripple()
	{
		if (!this.vmethod_26() && MonoSingleton<GraphicsMgr>.Instance != null)
		{
			MonoSingleton<GraphicsMgr>.Instance.method_21().method_20(this.m_markerParentObj, new Vector3(0f, 1.5f, 0f), this.vmethod_4(), NpcTitleMgr.TPC_VFX_MARKER_GROUP.GROUP_SECOND_WIND, NpcTitleMgr.TPC_VFX_MARKER_TYPE.TPC_VFX_MARKER_CRIPPLE, true, this.method_114());
			MonoSingleton<GraphicsMgr>.Instance.method_21().method_29(this.m_markerParentObj, new Vector3(0f, 1.2f, 0f), this.vmethod_4(), NpcTitleMgr.TPC_PROGRESSBAR_TYPE.TPC_PROGRESSBAR_CRIPPLE);
		}
		this.PlayerSkillManage_0.OnEnterPlayerCripple();
	}

	// Token: 0x06001CB8 RID: 7352 RVA: 0x0008E684 File Offset: 0x0008C884
	public void OnEnterPlayerDead()
	{
		if (!this.vmethod_26())
		{
			if (MonoSingleton<GraphicsMgr>.Instance != null)
			{
				MonoSingleton<GraphicsMgr>.Instance.method_21().method_21(this.m_markerParentObj, NpcTitleMgr.TPC_VFX_MARKER_GROUP.GROUP_SECOND_WIND, this.method_114());
				MonoSingleton<GraphicsMgr>.Instance.method_21().method_31(this.m_markerParentObj);
			}
			this.method_10();
		}
	}

	// Token: 0x06001CB9 RID: 7353 RVA: 0x0008E6E0 File Offset: 0x0008C8E0
	public void OnEnterPlayerDown()
	{
		if (!this.vmethod_26() && MonoSingleton<GraphicsMgr>.Instance != null)
		{
			MonoSingleton<GraphicsMgr>.Instance.method_21().method_20(this.m_markerParentObj, new Vector3(0f, 1f, 0f), this.vmethod_4(), NpcTitleMgr.TPC_VFX_MARKER_GROUP.GROUP_SECOND_WIND, NpcTitleMgr.TPC_VFX_MARKER_TYPE.TPC_VFX_MARKER_DOWN, true, this.method_114());
			MonoSingleton<GraphicsMgr>.Instance.method_21().method_29(this.m_markerParentObj, new Vector3(0f, 1f, 0f), this.vmethod_4(), NpcTitleMgr.TPC_PROGRESSBAR_TYPE.TPC_PROGRESSBAR_DOWN);
		}
	}

	// Token: 0x06001CBA RID: 7354 RVA: 0x0008E76C File Offset: 0x0008C96C
	public void OnSecondWindRevive(bool hasKilledNPC)
	{
		if (this.vmethod_26())
		{
			if (hasKilledNPC)
			{
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<SecondWindView>().OnRevivedSelf();
			}
			else
			{
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<SecondWindView>().OnRevivedTeamMate();
			}
		}
		else if (MonoSingleton<GraphicsMgr>.Instance != null)
		{
			MonoSingleton<GraphicsMgr>.Instance.method_21().method_21(this.m_markerParentObj, NpcTitleMgr.TPC_VFX_MARKER_GROUP.GROUP_SECOND_WIND, this.method_114());
			MonoSingleton<GraphicsMgr>.Instance.method_21().method_31(this.m_markerParentObj);
		}
	}

	// Token: 0x06001CBB RID: 7355 RVA: 0x0001480F File Offset: 0x00012A0F
	public bool method_149()
	{
		return (this.method_67() || this.method_65()) && !(this.m_equipment == null) && this.m_equipment.method_7() > 0;
	}

	// Token: 0x06001CBC RID: 7356 RVA: 0x0008E7F0 File Offset: 0x0008C9F0
	public void OnSendRevive(EntityPlayer downTeammate)
	{
		EquipmentInventoryEntityPlayer equipmentInventoryEntityPlayer = downTeammate.vmethod_19() as EquipmentInventoryEntityPlayer;
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<SecondWindView>().Boolean_1 = true;
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<SecondWindView>().vmethod_6(true, (float)equipmentInventoryEntityPlayer.method_3() / (float)equipmentInventoryEntityPlayer.method_4(), (float)equipmentInventoryEntityPlayer.method_7() / (float)equipmentInventoryEntityPlayer.method_8(), downTeammate.m_name);
	}

	// Token: 0x06001CBD RID: 7357 RVA: 0x0008E858 File Offset: 0x0008CA58
	public List<Entity> method_150(float float_0 = 0f)
	{
		this.m_temp_enemyList.Clear();
		List<Entity> list = DamageManager.DamageManager_0.method_0();
		for (int i = 0; i < list.Count; i++)
		{
			Entity entity = list[i];
			if (!(entity == null) && !(entity.gameObject == null))
			{
				EquipmentInventoryEntity equipmentInventoryEntity = entity.vmethod_19();
				if (!(equipmentInventoryEntity == null) && equipmentInventoryEntity.vmethod_4() > 0 && !this.method_136(entity))
				{
					if (float_0 > 0f)
					{
						float num = Vector3.Distance(base.transform.position, entity.transform.position);
						if (num > float_0)
						{
							goto IL_0094;
						}
					}
					this.m_temp_enemyList.Add(entity);
				}
			}
			IL_0094:;
		}
		return this.m_temp_enemyList;
	}

	// Token: 0x06001CBE RID: 7358 RVA: 0x00014841 File Offset: 0x00012A41
	public float method_151()
	{
		if (this.m_playerController != null)
		{
			return this.m_playerController.method_25();
		}
		return 1.5f;
	}

	// Token: 0x06001CBF RID: 7359 RVA: 0x00014862 File Offset: 0x00012A62
	public bool method_152()
	{
		if (Time.time - this.m_lastKilledTime > 1f)
		{
			this.m_lastKilledTime = Time.time;
			return true;
		}
		return false;
	}

	// Token: 0x06001CC0 RID: 7360 RVA: 0x0008E910 File Offset: 0x0008CB10
	public bool method_153()
	{
		float num = 1f;
		if (this.m_animMgr == null)
		{
			this.m_animMgr = base.GetComponent<PlayerAnimationManagerFSM>();
		}
		if (this.m_animMgr.method_13(AnimationStateFSM.PlayerFire))
		{
			AnimationPlayerFireState animationPlayerFireState = this.m_animMgr.method_16(Utils.smethod_23(AnimationStateFSM.PlayerFire)) as AnimationPlayerFireState;
			return animationPlayerFireState.method_23() > num;
		}
		if (this.m_animMgr.method_13(AnimationStateFSM.PlayerAim))
		{
			AnimationPlayerAimState animationPlayerAimState = this.m_animMgr.method_16(Utils.smethod_23(AnimationStateFSM.PlayerAim)) as AnimationPlayerAimState;
			return animationPlayerAimState.method_30() > num;
		}
		return false;
	}

	// Token: 0x06001CC1 RID: 7361 RVA: 0x00014885 File Offset: 0x00012A85
	public void method_154()
	{
		base.photonView.method_4("RPC_SetChargeShot", PhotonTargets.MasterClient, new object[0]);
	}

	// Token: 0x06001CC2 RID: 7362 RVA: 0x0001489E File Offset: 0x00012A9E
	Vector3 InteractionClient.imethod_0()
	{
		return base.method_1();
	}

	// Token: 0x0400128A RID: 4746
	private const float m_minKilledTime = 1f;

	// Token: 0x0400128B RID: 4747
	protected Session m_session;

	// Token: 0x0400128C RID: 4748
	protected int m_playerId;

	// Token: 0x0400128D RID: 4749
	protected PlayerInfoSync m_playerInfo;

	// Token: 0x0400128E RID: 4750
	protected EquipmentInventoryEntityPlayer m_equipment;

	// Token: 0x0400128F RID: 4751
	protected CollisionManager m_collisionManager;

	// Token: 0x04001290 RID: 4752
	protected BadAssFPSCamera m_badassFpsCamera;

	// Token: 0x04001291 RID: 4753
	protected InstanceInput m_instanceInput;

	// Token: 0x04001292 RID: 4754
	protected PlayerController m_playerController;

	// Token: 0x04001293 RID: 4755
	protected PlayerBehavior m_playerBehavior;

	// Token: 0x04001294 RID: 4756
	protected CharacterController m_characterController;

	// Token: 0x04001295 RID: 4757
	protected bool m_bTitleAdded;

	// Token: 0x04001296 RID: 4758
	protected Entity m_lastKiller;

	// Token: 0x04001297 RID: 4759
	protected static int m_WeapnSlotNums = 4;

	// Token: 0x04001298 RID: 4760
	private PlayerFirstPersonInventoryManager m_playerFirstPersonInventoryManager;

	// Token: 0x04001299 RID: 4761
	private Dictionary<Entity, int> sightTestCache;

	// Token: 0x0400129A RID: 4762
	protected bool m_isInBattle;

	// Token: 0x0400129B RID: 4763
	public EntityWeapon m_equipedWeapon;

	// Token: 0x0400129C RID: 4764
	public EntityWeapon m_backWeapon;

	// Token: 0x0400129D RID: 4765
	public EntityWeapon m_thighWeapon;

	// Token: 0x0400129E RID: 4766
	public TextAsset m_AssemblyConfig;

	// Token: 0x0400129F RID: 4767
	public EntityObject m_claptrap;

	// Token: 0x040012A0 RID: 4768
	private bool m_playerIsSpawned;

	// Token: 0x040012A1 RID: 4769
	private Utils.Timer m_playerDamageEchoTimer = new Utils.Timer();

	// Token: 0x040012A2 RID: 4770
	private Utils.Timer m_equipmentReadyTimer = new Utils.Timer();

	// Token: 0x040012A3 RID: 4771
	public Material m_fpHandMaterial;

	// Token: 0x040012A4 RID: 4772
	public int m_awesomeLevel = 1;

	// Token: 0x040012A5 RID: 4773
	protected PlayerInfoSync.OnPlayerStateChanged_Handler m_handler_statechanged;

	// Token: 0x040012A6 RID: 4774
	protected VFXManager m_vfxMgr;

	// Token: 0x040012A7 RID: 4775
	protected BaseEventTriggerCtl m_eventTriggerCtl;

	// Token: 0x040012A8 RID: 4776
	private BHVSecondWindManager m_secondWindManager;

	// Token: 0x040012A9 RID: 4777
	protected PlayerSkillManage m_skillManager;

	// Token: 0x040012AA RID: 4778
	private bool m_bAimFOVChanging;

	// Token: 0x040012AB RID: 4779
	protected SkillTreeStatus m_skillTreeStatus;

	// Token: 0x040012AC RID: 4780
	protected PlayerEffectManager m_effectMgr;

	// Token: 0x040012AD RID: 4781
	private PlayerGuildEffectManage m_guildEffectMgr;

	// Token: 0x040012AE RID: 4782
	protected EntityPlayer.TriggerAtFirstTime m_weaponReady = new EntityPlayer.TriggerAtFirstTime();

	// Token: 0x040012AF RID: 4783
	protected EntityPlayer.TriggerAtFirstTime m_shieldReady = new EntityPlayer.TriggerAtFirstTime();

	// Token: 0x040012B0 RID: 4784
	private int m_count_dot;

	// Token: 0x040012B1 RID: 4785
	private Transform m_HandModel;

	// Token: 0x040012B2 RID: 4786
	public bool m_pending_melee;

	// Token: 0x040012B3 RID: 4787
	private GameObject m_titleObj;

	// Token: 0x040012B4 RID: 4788
	private GameObject m_markerParentObj;

	// Token: 0x040012B5 RID: 4789
	private Transform m_3rdPersonRenderTransform;

	// Token: 0x040012B6 RID: 4790
	public TextAsset m_config_character;

	// Token: 0x040012B7 RID: 4791
	[SerializeField]
	private EntityPlayer.CharacterSetting m_character_setting;

	// Token: 0x040012B8 RID: 4792
	private float m_victimDamageModifier_skill = 1f;

	// Token: 0x040012B9 RID: 4793
	private float m_elementalDamageModifier_skill = 1f;

	// Token: 0x040012BA RID: 4794
	private float m_slowdown_marked_move = 0.5f;

	// Token: 0x040012BB RID: 4795
	protected E_USE_TYPE m_secondwindInteractionType = E_USE_TYPE.E_REVIVE;

	// Token: 0x040012BC RID: 4796
	private List<Entity> m_temp_enemyList = new List<Entity>();

	// Token: 0x040012BD RID: 4797
	private float m_lastKilledTime;

	// Token: 0x040012BE RID: 4798
	private PlayerAnimationManagerFSM m_animMgr;

	// Token: 0x0200045D RID: 1117
	public class TriggerAtFirstTime
	{
		// Token: 0x06001CC4 RID: 7364 RVA: 0x000148B5 File Offset: 0x00012AB5
		public bool Update(bool _new)
		{
			if (this.m_active && !this.m_lasttick_condition && _new)
			{
				this.m_active = false;
				return true;
			}
			this.m_lasttick_condition = _new;
			return false;
		}

		// Token: 0x040012BF RID: 4799
		private bool m_active = true;

		// Token: 0x040012C0 RID: 4800
		private bool m_lasttick_condition;
	}

	// Token: 0x0200045E RID: 1118
	public enum KillType
	{
		// Token: 0x040012C2 RID: 4802
		Suicide,
		// Token: 0x040012C3 RID: 4803
		IKillEnemy,
		// Token: 0x040012C4 RID: 4804
		EnemyKillMe,
		// Token: 0x040012C5 RID: 4805
		Others
	}

	// Token: 0x0200045F RID: 1119
	[Serializable]
	public class CharacterSetting
	{
		// Token: 0x040012C6 RID: 4806
		public float m_standHeight;

		// Token: 0x040012C7 RID: 4807
		public float m_crouchHeight;

		// Token: 0x040012C8 RID: 4808
		public float m_titleOffsetX;

		// Token: 0x040012C9 RID: 4809
		public float m_titleOffsetY;

		// Token: 0x040012CA RID: 4810
		public float m_titleOffsetZ;

		// Token: 0x040012CB RID: 4811
		public float m_titleOffsetX_Town;

		// Token: 0x040012CC RID: 4812
		public float m_titleOffsetY_Town;

		// Token: 0x040012CD RID: 4813
		public float m_titleOffsetZ_Town;

		// Token: 0x040012CE RID: 4814
		public int m_maxSecondWindBlood = 10000;

		// Token: 0x040012CF RID: 4815
		public int m_secondWindBleedRate = 1000;

		// Token: 0x040012D0 RID: 4816
		public int m_maxBleedRate = 2000;

		// Token: 0x040012D1 RID: 4817
		public float m_damageBleedConversionRate = 0.5f;

		// Token: 0x040012D2 RID: 4818
		public float m_healBleedConversionRate = 1f;

		// Token: 0x040012D3 RID: 4819
		public float m_reviveBleedConversionRate = 1f;

		// Token: 0x040012D4 RID: 4820
		public int m_maxRevivePoint = 1000;

		// Token: 0x040012D5 RID: 4821
		public int m_revivePower = 200;

		// Token: 0x040012D6 RID: 4822
		public float m_reviveResetDelay = 2f;

		// Token: 0x040012D7 RID: 4823
		public int m_HPAfterSecondWind = 20;

		// Token: 0x040012D8 RID: 4824
		public int m_shieldAfterSecondWind = 75;

		// Token: 0x040012D9 RID: 4825
		public int m_HPAfterRevive = 50;

		// Token: 0x040012DA RID: 4826
		public int m_shieldAfterRevive = 75;

		// Token: 0x040012DB RID: 4827
		public float m_playerDownDuration = 10f;

		// Token: 0x040012DC RID: 4828
		public float m_stunDuration = 3f;

		// Token: 0x040012DD RID: 4829
		public float m_walkSpeed_stun = 0.3f;

		// Token: 0x040012DE RID: 4830
		public float m_rotation_stun = 0.1f;
	}
}
