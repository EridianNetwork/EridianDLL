using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using ns0;
using UnityEngine;

using Core;
// Token: 0x02000469 RID: 1129
public class EntityPlayerTown : EntityPlayer
{
	// Token: 0x06001CFD RID: 7421 RVA: 0x00014992 File Offset: 0x00012B92
	protected override void Awake()
	{
		base.Awake();
		if (InteractionManager.InteractionManager_0)
		{
			InteractionManager.InteractionManager_0.method_0(this);
		}
	}

	// Token: 0x06001CFE RID: 7422 RVA: 0x000149B1 File Offset: 0x00012BB1
	protected override void OnDestroy()
	{
		base.OnDestroy();
		if (InteractionManager.InteractionManager_0)
		{
			InteractionManager.InteractionManager_0.method_1(this);
		}
	}

	// Token: 0x06001CFF RID: 7423 RVA: 0x0008FA14 File Offset: 0x0008DC14
	public override void Start()
	{
		this.m_equipment = base.GetComponent<EquipmentInventoryEntityPlayerTown>();
		this.m_collisionManager = base.GetComponent<CollisionManager>();
		this.m_instanceInput = base.GetComponent<InstanceInput>();
		this.m_playerController = base.GetComponent<PlayerController>();
		this.m_playerBehavior = (PlayerBehavior)base.GetComponent(typeof(PlayerBehavior));
		this.m_vfxMgr = base.GetComponentInChildren<VFXManager>();
		PlayerInfoSync playerInfoSync = this.vmethod_25();
		if (playerInfoSync == null)
		{
			return;
		}
		playerInfoSync.method_6(this);
		if (playerInfoSync.PlayerState_0 > PlayerInfoSync.PlayerState.None)
		{
			base.method_23();
		}
		else
		{
			this.m_handler_statechanged = new PlayerInfoSync.OnPlayerStateChanged_Handler(base.method_23);
			playerInfoSync.Event_0 += this.m_handler_statechanged;
		}
		base.name = base.name + "(" + playerInfoSync.m_name + ")";
		this.m_name = playerInfoSync.m_name;
		int num = MonoSingleton<LevelingManager>.Instance.method_3(this.vmethod_25().m_avatarDna.method_5(), this.vmethod_25().m_exp);
		ItemDNA[] array = new ItemDNA[4];
		ItemDNA itemDNA = null;
		ItemDNA itemDNA2 = null;
		byte b = 0;
		if (this.vmethod_26())
		{
			for (int i = 0; i < 4; i++)
			{
				array[i] = ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_7((byte)i);
			}
			itemDNA = ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_26();
			itemDNA2 = ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_27();
			Inventory inventory = OnAccessSingleton<IInventoryService, InventoryService, InventoryServiceOffline>.Prop_0.imethod_0(OnlineService.s_characterId, null);
			if (inventory != null)
			{
				b = inventory.method_3();
			}
		}
		base.method_4();
		this.m_relatedPlayer = this;
		if (playerInfoSync != null && !playerInfoSync.IsMyActor() && GroupManager.smethod_0().method_17(playerInfoSync.m_characterId))
		{
			MapObjectMark mapObjectMark = base.gameObject.AddComponent<MapObjectMark>();
			mapObjectMark.ObjType = UIMapDataManager.MiniMapObjectType.TeamMate;
			mapObjectMark.bAlwaysOnMap = true;
			mapObjectMark.method_0();
		}
		this.m_isInBattle = false;
		this.m_skillManager = base.GetComponent<PlayerSkillManage>();
		if (this.m_skillManager != null)
		{
			this.m_skillManager.vmethod_0();
		}
		this.m_skillTreeStatus = base.GetComponent<SkillTreeStatus>();
		this.m_skillTreeStatus.method_0();
		this.m_effectMgr = new PlayerEffectManager(this);
		base.method_12();
		(this.m_equipment as EquipmentInventoryEntityPlayerTown).method_40((byte)num, array, itemDNA, itemDNA2, b);
		StatisticsManager.StatSheet personalStatSheet = MonoSingleton<StatisticsManager>.Instance.GetCurrentSession().GetPersonalStatSheet(this.m_playerInfo);
		if (personalStatSheet != null)
		{
			personalStatSheet.Reset(this.m_name);
		}
		base.method_126();
		this.m_ability.method_0(new SwitchWeapon());
		this.m_ability.method_0(new EquipWeapon());
		this.m_ability.method_0(new EquipShield());
		this.m_ability.method_0(new EquipClassMode());
		this.m_ability.method_0(new EquipOutfit());
		this.m_ability.method_0(new EntityInteraction());
	}

	// Token: 0x06001D00 RID: 7424 RVA: 0x000149D0 File Offset: 0x00012BD0
	public override void vmethod_69(byte byte_0)
	{
		base.method_91(byte_0);
	}

	// Token: 0x06001D01 RID: 7425 RVA: 0x000149D9 File Offset: 0x00012BD9
	public override void vmethod_71(byte byte_0)
	{
		base.method_94(byte_0);
	}

	// Token: 0x06001D02 RID: 7426 RVA: 0x000149E2 File Offset: 0x00012BE2
	public override void vmethod_72(byte byte_0)
	{
		base.method_95(byte_0);
	}

	// Token: 0x06001D03 RID: 7427 RVA: 0x000149EB File Offset: 0x00012BEB
	public override void vmethod_75(byte byte_0)
	{
		base.method_97(byte_0);
	}

	// Token: 0x06001D04 RID: 7428 RVA: 0x000149F4 File Offset: 0x00012BF4
	public override void vmethod_73()
	{
		base.method_92();
	}

	// Token: 0x06001D05 RID: 7429 RVA: 0x000149FC File Offset: 0x00012BFC
	public override void vmethod_74()
	{
		base.method_93();
	}

	// Token: 0x06001D06 RID: 7430 RVA: 0x00014A04 File Offset: 0x00012C04
	public override void vmethod_68(byte byte_0)
	{
		base.method_90(byte_0);
	}

	// Token: 0x06001D07 RID: 7431 RVA: 0x00014A0D File Offset: 0x00012C0D
	public override void vmethod_76(byte byte_0)
	{
		base.method_98(byte_0);
	}

	// Token: 0x06001D08 RID: 7432 RVA: 0x00014A16 File Offset: 0x00012C16
	public override void vmethod_77(byte byte_0, byte byte_1)
	{
		(this.vmethod_19() as EquipmentInventoryEntityPlayer).vmethod_41(byte_0, byte_1);
	}

	// Token: 0x06001D09 RID: 7433 RVA: 0x00014A2A File Offset: 0x00012C2A
	public override void vmethod_78(byte byte_0, byte byte_1)
	{
		(this.vmethod_19() as EquipmentInventoryEntityPlayer).vmethod_42(byte_0, byte_1);
	}

	// Token: 0x06001D0A RID: 7434 RVA: 0x00014A3E File Offset: 0x00012C3E
	public override void vmethod_65(EntityWeapon entityWeapon_0, byte byte_0)
	{
		base.StartCoroutine(this.method_155(entityWeapon_0, byte_0));
	}

	// Token: 0x06001D0B RID: 7435 RVA: 0x0008FCCC File Offset: 0x0008DECC
	private IEnumerator method_155(EntityWeapon entityWeapon_0, byte byte_0)
	{
		entityWeapon_0.method_49();
		while (!entityWeapon_0.vmethod_62())
		{
			yield return 0;
		}
		DebugUtils.Log(LogCategory.Gamelogic, "EquipWeaponWhenReadyInTown: Model instantiated");
		method_48(entityWeapon_0);
		AnimationManager animMng = vmethod_12();
		if ((bool)animMng)
		{
			animMng.OnPickUpWeapon(entityWeapon_0);
		}
	}
	// Token: 0x06001D0C RID: 7436 RVA: 0x0008FCF8 File Offset: 0x0008DEF8
	public override bool imethod_2(Ray ray_0, ref float float_0)
	{
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

	// Token: 0x06001D0D RID: 7437 RVA: 0x00014A4F File Offset: 0x00012C4F
	public override bool imethod_3(Entity entity_0)
	{
		return MonoSingleton<Session>.Instance.GetLocalPlayer() && (this.m_playerInfo && !this.m_playerInfo.IsMyActor());
	}

	// Token: 0x06001D0E RID: 7438 RVA: 0x0008FD68 File Offset: 0x0008DF68
	private MenuItemDef[] method_156()
	{
		this.m_currentAimedPlayerInfo = this.method_159(this.m_currentAimedPlayerID);
		MenuItemDef[] array = new MenuItemDef[4];
		if (this.m_currentAimedPlayerInfo != null)
		{
			array[0].itemTitle = LocalizedString.smethod_0(new LocalizedString("Group_Invitation"));
			array[0].itemData = this.m_currentAimedPlayerInfo.m_characterId;
			if (GroupManager.smethod_0().method_18() && (!GroupManager.smethod_0().method_19() || GroupManager.smethod_0().method_17(this.m_currentAimedPlayerInfo.m_characterId)))
			{
				array[0].itemFunc = null;
			}
			else
			{
				array[0].itemFunc = new MenuItemProcessFunc(GroupManager.smethod_0().method_14);
			}
			array[1].itemTitle = LocalizedString.smethod_0(new LocalizedString("Friend_Invitation"));
			array[1].itemData = this.m_currentAimedPlayerInfo.m_characterId;
			if (!FriendManager.smethod_0().method_26(this.m_currentAimedPlayerInfo.m_characterId) && FriendManager.smethod_0().method_13())
			{
				array[1].itemFunc = new MenuItemProcessFunc(FriendManager.smethod_0().method_14);
			}
			else
			{
				array[1].itemFunc = null;
			}
			array[2].itemTitle = LocalizedString.smethod_0(new LocalizedString("Chat_Send"));
			array[2].itemData = this.m_currentAimedPlayerInfo.m_name;
			array[2].itemFunc = new MenuItemProcessFunc(MonoSingleton<AppManager>.Instance.method_0().vmethod_5<ChatView>().method_3);
			array[3].itemTitle = LocalizedString.smethod_0(new LocalizedString("GUILD_INVITATION"));
			array[3].itemData = this.m_currentAimedPlayerInfo.m_characterId;
			if (!GuildManager.smethod_0().method_8() && !GuildManager.smethod_0().method_82())
			{
				array[3].itemFunc = null;
			}
			else
			{
				array[3].itemFunc = new MenuItemProcessFunc(GuildManager.smethod_0().method_31);
			}
		}
		return array;
	}

	// Token: 0x06001D0F RID: 7439 RVA: 0x0008FF88 File Offset: 0x0008E188
	private List<EntityPlayer> method_157()
	{
		InteractionClient[] array = MonoSingleton<TargetingManager>.Instance.m_mutilpleInteractions.ToArray();
		this.m_aimedPlayers.Clear();
		for (int i = 0; i < array.Length; i++)
		{
			EntityPlayer entityPlayer = array[i] as EntityPlayer;
			if (entityPlayer != null)
			{
				this.m_aimedPlayers.Add(entityPlayer);
			}
		}
		return this.m_aimedPlayers;
	}

	// Token: 0x06001D10 RID: 7440 RVA: 0x0008FFE4 File Offset: 0x0008E1E4
	private MenuItemDef[] method_158()
	{
		this.m_aimedPlayers = this.method_157();
		MenuItemDef[] array = new MenuItemDef[this.m_aimedPlayers.Count];
		for (int i = 0; i < array.Length; i++)
		{
			PlayerInfoSync playerInfoSync = this.m_aimedPlayers[i].vmethod_25();
			if (i == 0)
			{
				this.m_currentAimedPlayerID = playerInfoSync.m_characterId;
			}
			array[i].itemData = playerInfoSync.m_characterId;
			array[i].itemTitle = playerInfoSync.m_name;
		}
		return array;
	}

	// Token: 0x06001D11 RID: 7441 RVA: 0x00090068 File Offset: 0x0008E268
	private PlayerInfoSync method_159(int int_0)
	{
		for (int i = 0; i < this.m_aimedPlayers.Count; i++)
		{
			PlayerInfoSync playerInfoSync = this.m_aimedPlayers[i].vmethod_25();
			if (playerInfoSync.m_characterId == int_0)
			{
				return playerInfoSync;
			}
		}
		return null;
	}

	// Token: 0x06001D12 RID: 7442 RVA: 0x000900AC File Offset: 0x0008E2AC
	private void method_160(int int_0)
	{
		for (int i = 0; i < this.m_aimedPlayers.Count; i++)
		{
			PlayerInfoSync playerInfoSync = this.m_aimedPlayers[i].vmethod_25();
			EntityPlayerTown entityPlayerTown = this.m_aimedPlayers[i] as EntityPlayerTown;
			if (playerInfoSync.m_characterId == int_0)
			{
				if (entityPlayerTown != null)
				{
					entityPlayerTown.method_163(E_HighlightType.Golden, false);
				}
			}
			else if (entityPlayerTown != null)
			{
				entityPlayerTown.method_163(E_HighlightType.None, false);
			}
		}
	}

	// Token: 0x06001D13 RID: 7443 RVA: 0x00090120 File Offset: 0x0008E320
	private void method_161()
	{
		this.m_currentAimedPlayerInfo = this.method_159(this.m_currentAimedPlayerID);
		if (this.m_currentAimedPlayerInfo)
		{
			GroupManager.smethod_0().method_0(this.m_currentAimedPlayerInfo.m_characterId);
			FriendManager.smethod_0().method_1(this.m_currentAimedPlayerInfo.m_characterId);
		}
	}

	// Token: 0x06001D14 RID: 7444 RVA: 0x00014A81 File Offset: 0x00012C81
	public void OnPlayerSelected(int id)
	{
		if (this.m_currentAimedPlayerID != id)
		{
			this.m_currentAimedPlayerID = id;
			this.method_161();
			this.method_160(this.m_currentAimedPlayerID);
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<PlayerListView>().method_3(this.method_156());
		}
	}

	// Token: 0x06001D15 RID: 7445 RVA: 0x00090178 File Offset: 0x0008E378
	private void OnPlayerListClosed(BaseView view, bool bVisible, bool bInner)
	{
		if (!bVisible)
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<PopupMenuView>().method_2(new ViewVisbleChangeFunc(this.OnPlayerListClosed));
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<PlayerListView>().method_2(new ViewVisbleChangeFunc(this.OnPlayerListClosed));
			this.method_160(-1);
			this.m_currentAimedPlayerID = -1;
			this.m_aimedPlayers.Clear();
		}
	}

	// Token: 0x06001D16 RID: 7446 RVA: 0x000901E4 File Offset: 0x0008E3E4
	public override void imethod_5(Entity entity_0, bool bool_0 = false)
	{
		if (!MonoSingleton<Session>.Instance.GetLocalPlayer())
		{
			return;
		}
		MenuItemDef[] array = this.method_158();
		this.method_161();
		this.method_160(this.m_currentAimedPlayerID);
		if (this.m_aimedPlayers.Count == 1)
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<PopupMenuView>().method_1(new ViewVisbleChangeFunc(this.OnPlayerListClosed));
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<PopupMenuView>().method_4(this.method_156(), new Vector2((float)Screen.width * 0.5f, (float)Screen.height * 0.5f), null);
		}
		else
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<PlayerListView>().method_1(new ViewVisbleChangeFunc(this.OnPlayerListClosed));
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<PlayerListView>().method_4(array, this.method_156(), new PlayerListView.SelectChangeDelegate(this.OnPlayerSelected), null);
		}
	}

	// Token: 0x06001D17 RID: 7447 RVA: 0x0000311D File Offset: 0x0000131D
	public override bool imethod_4()
	{
		return false;
	}

	// Token: 0x06001D18 RID: 7448 RVA: 0x00014ABF File Offset: 0x00012CBF
	public override E_USE_TYPE imethod_6()
	{
		return E_USE_TYPE.E_TALK;
	}

	// Token: 0x06001D19 RID: 7449 RVA: 0x0000311B File Offset: 0x0000131B
	public override void Update()
	{
	}

	// Token: 0x06001D1A RID: 7450 RVA: 0x000902CC File Offset: 0x0008E4CC
	protected override IEnumerator vmethod_63()
	{
		for (byte i = 0; i < EntityPlayer.m_WeapnSlotNums; i++)
		{
			yield return StartCoroutine(vmethod_62(i));
		}
		if ((bool)m_equipment.vmethod_27())
		{
			if (m_equipment.vmethod_27().method_17() != null && vmethod_25() != null)
			{
				DebugUtils.Log(LogCategory.Gamelogic, "town player " + vmethod_25().m_name + " equip weapon " + m_equipment.vmethod_27().method_17().ToString());
			}
			DebugUtils.Log(LogCategory.Gamelogic, "town player equip weapon ");
			m_equipment.vmethod_27().vmethod_63(this);
			m_equipedWeapon = m_equipment.vmethod_27();
		}
		else
		{
			if (m_equipment != null && vmethod_25() != null)
			{
				DebugUtils.Log(LogCategory.Gamelogic, "town player " + vmethod_25().m_name + "this shouldn't happened, except tutorial, activeWeapon " + m_equipment.vmethod_55());
			}
			DebugUtils.Log(LogCategory.Gamelogic, "town player can't equip weapon ");
		}
		method_28();
	}
	// Token: 0x06001D1B RID: 7451 RVA: 0x000902E8 File Offset: 0x0008E4E8
	protected override IEnumerator vmethod_62(byte byte_0)
	{
		if (vmethod_25() != null)
		{
			DebugUtils.Log(LogCategory.Gamelogic, "player " + vmethod_25().m_name + " add one weapon in town :" + byte_0);
		}
		else
		{
			DebugUtils.Log(LogCategory.Gamelogic, "player info null. add one weapon in town ");
		}
		while (!(m_equipment as EquipmentInventoryEntityPlayerTown).method_39())
		{
			yield return 0;
		}
		EntityWeapon weapon2 = null;
		weapon2 = m_equipment.vmethod_28(byte_0);
		if (vmethod_25() != null)
		{
			DebugUtils.Log(LogCategory.Gamelogic, "town player " + vmethod_25().m_name + " m_equipment is ready, slot " + byte_0);
		}
		else
		{
			DebugUtils.Log(LogCategory.Gamelogic, "town player info null. m_equipment is ready");
		}
		if (weapon2 != null)
		{
			if (vmethod_25() != null)
			{
				DebugUtils.Log(LogCategory.Gamelogic, "town player " + vmethod_25().m_name + "weapon not null");
			}
			else
			{
				DebugUtils.Log(LogCategory.Gamelogic, "town player info null. weapon not null");
			}
			while (!weapon2.m_isReady)
			{
				yield return 0;
			}
			if (vmethod_25() != null && weapon2.method_17() != null)
			{
				DebugUtils.Log(LogCategory.Gamelogic, "town player " + vmethod_25().m_name + " EquipNewWeapon EquipNewWeapon:" + weapon2.method_17().ToString());
			}
			else
			{
				DebugUtils.Log(LogCategory.Gamelogic, "town player info null. EquipNewWeapon EquipNewWeapon");
			}
			weapon2.method_54(this);
			method_59(bool_0: false);
		}
	}
	// Token: 0x06001D1C RID: 7452 RVA: 0x00090314 File Offset: 0x0008E514
	protected override IEnumerator vmethod_64()
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
	// Token: 0x06001D1D RID: 7453 RVA: 0x00014AC2 File Offset: 0x00012CC2
	public override void vmethod_79(byte byte_0)
	{
		if (this.m_equipment != null)
		{
			this.m_equipment.vmethod_54(byte_0);
			base.StartCoroutine(this.method_162());
		}
	}

	// Token: 0x06001D1E RID: 7454 RVA: 0x00090330 File Offset: 0x0008E530
	private IEnumerator method_162()
	{
		EntityWeapon weapon2 = null;
		while (m_equipment.vmethod_27() == null)
		{
			yield return 0;
		}
		weapon2 = m_equipment.vmethod_27();
		while (true)
		{
			if (!weapon2.vmethod_62())
			{
				if (!(vmethod_16() != weapon2))
				{
					yield return 0;
					continue;
				}
				break;
			}
			while (true)
			{
				if (!(weapon2.m_owner == null))
				{
					AnimationManager animMng = vmethod_12();
					if (!(animMng == null))
					{
						animMng.OnSwitchWeapon(weapon2);
					}
					break;
				}
				if (vmethod_16() != weapon2)
				{
					break;
				}
				yield return 0;
			}
			break;
		}
	}
	// Token: 0x06001D1F RID: 7455 RVA: 0x00014AEB File Offset: 0x00012CEB
	public void method_163(E_HighlightType e_HighlightType_0, bool bool_0 = false)
	{
		this.m_highlight_wrapper.method_0(base.gameObject, e_HighlightType_0, bool_0);
	}

	// Token: 0x06001D20 RID: 7456 RVA: 0x0000311B File Offset: 0x0000131B
	public override void vmethod_80()
	{
	}

	// Token: 0x04001320 RID: 4896
	protected int m_currentAimedPlayerID;

	// Token: 0x04001321 RID: 4897
	protected PlayerInfoSync m_currentAimedPlayerInfo;

	// Token: 0x04001322 RID: 4898
	protected List<EntityPlayer> m_aimedPlayers = new List<EntityPlayer>();

	// Token: 0x04001323 RID: 4899
	private HighlightWrapper m_highlight_wrapper = new HighlightWrapper();
}
