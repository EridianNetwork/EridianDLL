using System;
using System.Collections.Generic;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x02000699 RID: 1689
public class RVBehaviour : StepBehaviour
{
	// Token: 0x06002BCD RID: 11213 RVA: 0x000CD984 File Offset: 0x000CBB84
	public override void OnShow(FrontEndStepManager.StepState lastStep, object data = null)
	{
		MonoSingleton<AppManager>.Instance.method_0().Boolean_2 = true;
		MonoSingleton<AppManager>.Instance.method_0().vmethod_12(true);
		MonoSingleton<AppManager>.Instance.method_0().vmethod_18(false);
		LevelLockingManager.smethod_0().method_9(true);
		QuestUIDataManager.smethod_0().method_5();
		UIMapDisplayManager.smethod_0().method_0();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<NewInstanceSelectView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<InstanceInfoView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<WareHouseView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<QuestTrackView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<CharInfoView>().bPVPDisp = false;
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<HUDTeamMatePortraitView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<NPCDialogView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<NPCInteractiveView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<QuestDetailView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<SkillTreeView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<QuestListView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<EchoMessageView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<WeaponMeltView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<InstanceSelectView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InstanceSelectView>()._enterLevelFunc = null;
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<TownHUDView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<CurrencyUpdateView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<PopupMenuView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<PlayerListView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<GroupView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<FriendView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<WeaponPreviewView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<WeaponCraftView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<InventoryView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<MiniMapView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<MatchMakingView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<LargeMapView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<MailView>();
		ChatView chatView = MonoSingleton<AppManager>.Instance.method_0().vmethod_6<ChatView>();
		chatView.method_11(new ChatParameter[]
		{
			ChatParameter.Town,
			ChatParameter.Group,
			ChatParameter.Guild,
			ChatParameter.Private,
			ChatParameter.System
		});
		chatView.method_4(ChatParameter.Town, string.Empty);
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<PauseMenuView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<GuildCreateView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<GuildSearchView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<GuildOptionView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<PvPFlowView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<PvPTipsView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<ShopView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<WeaponUpgradeView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<AchievementBoardView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<AchievementPopUpView>();
		ItemTips.smethod_0();
		this.method_1();
		if (MonoSingleton<GameSettingMgr>.Instance != null && MonoSingleton<GameSettingMgr>.Instance.method_15(GameSettingMgr.UserData.PlayedTutorial.ToString()) == 0)
		{
			MonoSingleton<GameSettingMgr>.Instance.method_14(GameSettingMgr.UserData.PlayedTutorial.ToString(), 1);
		}
		LobbyManager.smethod_0().m_bCanShowLobbyECHO = true;
		if (GameObject.Find("__WeaponStationPump") == null)
		{
			new GameObject("__WeaponStationPump").AddComponent<WeaponStationPump>();
		}
	}

	// Token: 0x06002BCE RID: 11214 RVA: 0x000CDD00 File Offset: 0x000CBF00
	public override void vmethod_0(FrontEndStepManager.StepState stepState_0)
	{
		this._gameCamera = null;
		MonoSingleton<AppManager>.Instance.method_0().Camera_0 = null;
		ItemTips.smethod_1();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<ChatView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<WeaponMeltView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<PopupMenuView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<PlayerListView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<WareHouseView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<QuestTrackView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<CharInfoView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<HUDTeamMatePortraitView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<NPCDialogView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<NPCInteractiveView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<QuestDetailView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<EchoMessageView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<SkillTreeView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<InstanceSelectView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<CurrencyUpdateView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<NewInstanceSelectView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<InstanceInfoView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<TownHUDView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<QuestListView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<GroupView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<FriendView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<WeaponPreviewView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<WeaponCraftView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<InventoryView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<ShopView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<MiniMapView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<LargeMapView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<MatchMakingView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<GuildCreateView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<GuildSearchView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<GuildOptionView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<PvPFlowView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<PvPTipsView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<MailView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<WeaponUpgradeView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<AchievementBoardView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<AchievementPopUpView>();
		QuestUIDataManager.smethod_0().method_6();
		UIMapDataManager.smethod_0().method_1();
		UIMapDisplayManager.smethod_0().method_1();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_3();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<PauseMenuView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_12(true);
	}

	// Token: 0x06002BCF RID: 11215 RVA: 0x000CDFC8 File Offset: 0x000CC1C8
	public override void OnLevelLoadingFinish()
	{
		GameObject gameObject = new GameObject("WeaponCraftObject");
		ParticleManager particleManager = gameObject.AddComponent<ParticleManager>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<WeaponCraftView>().ParticleManager_0 = particleManager;
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<WeaponMeltView>().ParticleManager_0 = particleManager;
		MonoSingleton<AppManager>.Instance.method_0().vmethod_4(gameObject);
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InventoryView>().vmethod_6(InventoryServiceWrapper.InventoryUpdateType.FullUpdate);
		MonoSingleton<AppManager>.Instance.method_0().Boolean_2 = true;
		MonoSingleton<AppManager>.Instance.method_0().Boolean_1 = true;
		ServiceWrapperBase<QuestServiceWrapper>.Instance.method_2();
		UIMapDataManager.smethod_0().method_0();
		this.method_3();
	}

	// Token: 0x06002BD0 RID: 11216 RVA: 0x000CE070 File Offset: 0x000CC270
	private void Update()
	{
		Session prop_ = MonoSingleton<Session>.Instance;
		if (prop_ == null)
		{
			return;
		}
		if (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDTeamMatePortraitView>() != null)
		{
			Presence[] array = GroupManager.smethod_0().method_34();
			if (array.Length == 0)
			{
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDTeamMatePortraitView>().vmethod_8();
			}
			else
			{
				for (int i = 0; i < array.Length; i++)
				{
					MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDTeamMatePortraitView>().vmethod_7(array[i], i, array.Length);
				}
			}
		}
		if (this._gameCamera == null)
		{
			GameObject gameObject = GameObject.Find("FpsCamera(Clone)");
			if (gameObject != null)
			{
				this._gameCamera = gameObject.GetComponent<Camera>();
				MonoSingleton<AppManager>.Instance.method_0().Camera_0 = this._gameCamera;
			}
		}
		E_USE_TYPE e_USE_TYPE = E_USE_TYPE.E_NONE;
		if (MonoSingleton<TargetingManager>.Instance != null && MonoSingleton<TargetingManager>.Instance.method_4())
		{
			e_USE_TYPE = MonoSingleton<TargetingManager>.Instance.m_availableInteraction.imethod_6();
		}
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<TownHUDView>().vmethod_5(e_USE_TYPE);
		UIMapDataManager.smethod_0().Update();
		UIMapDisplayManager.smethod_0().Update();
		this.method_4();
	}

	// Token: 0x06002BD1 RID: 11217 RVA: 0x0001CE14 File Offset: 0x0001B014
	private int method_0(PlayerInfoSync playerInfoSync_0, PlayerInfoSync playerInfoSync_1)
	{
		if (playerInfoSync_1.m_characterId == GroupManager.smethod_0().m_nLeaderId)
		{
			return 1;
		}
		return -1;
	}

	// Token: 0x06002BD2 RID: 11218 RVA: 0x000CE190 File Offset: 0x000CC390
	private void method_1()
	{
		HashSet<int> hashSet = new HashSet<int>();
		if (MonoSingleton<TownNpcManager>.Instance == null)
		{
			return;
		}
		foreach (global::XsdSettings.TownNpc townNpc in MonoSingleton<TownNpcManager>.Instance.m_npcsSetup.m_npcs)
		{
			foreach (NpcOccupation npcOccupation in townNpc.m_occupations)
			{
				int num = -1;
				switch (npcOccupation)
				{
				case NpcOccupation.CoinShieldShop:
					num = townNpc.m_CoinShieldShopID;
					break;
				case NpcOccupation.ClassModeShop:
					num = townNpc.m_ClassModeShopID;
					break;
				case NpcOccupation.WeaponShop:
					num = townNpc.m_WeaponShopID;
					break;
				}
				hashSet.Add(num);
			}
		}
		foreach (int num2 in hashSet)
		{
			if (num2 != -1)
			{
				ServiceWrapperBase<ShopServiceWrapper>.Instance.method_5(num2, true);
			}
		}
	}

	// Token: 0x06002BD3 RID: 11219 RVA: 0x0001CE2B File Offset: 0x0001B02B
	private void method_2()
	{
		ServiceWrapperBase<ShopServiceWrapper>.Instance.method_9();
	}

	// Token: 0x06002BD4 RID: 11220 RVA: 0x000CE288 File Offset: 0x000CC488
	private void method_3()
	{
		bool flag = false;
		foreach (MailInfo mailInfo in ServiceWrapperBase<MailServiceWrapper>.Instance.method_0())
		{
			if (mailInfo.Mailtype == MailType.System && mailInfo.Mailstate == MailState.Unread && mailInfo.Item != null && mailInfo.Item.mItem != null)
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			MonoSingleton<global::ns0.EchoMessageManager>.Instance.method_8("81013");
		}
	}

	// Token: 0x06002BD5 RID: 11221 RVA: 0x000CE314 File Offset: 0x000CC514
	private void OnLevelUp(PlayerInfoSync player)
	{
		if (player.IsMyActor())
		{
			this.method_1();
		}
		AvatarType avatarType = player.m_avatarDna.method_5();
		NPC_UIFlowController.smethod_0().method_3(NPC_UIFlowController.NPC_UIFlowState.None);
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InstanceSelectView>().vmethod_6(MonoSingleton<LevelingManager>.Instance.method_3(avatarType, player.m_exp));
	}

	// Token: 0x06002BD6 RID: 11222 RVA: 0x000CE36C File Offset: 0x000CC56C
	private void method_4()
	{
		if (ServiceWrapperBase<CharacterServiceWrapper>.Instance == null)
		{
			return;
		}
		if (!ServiceWrapperBase<CharacterServiceWrapper>.Instance.vmethod_2())
		{
			return;
		}
		this.m_playerInfo.m_name = ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_9();
		this.m_playerInfo.m_exp = ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_7();
		this.m_playerInfo.m_avatarDna = ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_13();
		this.m_playerInfo.m_level = ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_8();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InstanceSelectView>().vmethod_7(this.m_playerInfo);
		if (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<CharInfoView>() != null)
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<CharInfoView>().vmethod_6(this.m_playerInfo);
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InventoryView>().vmethod_7();
		}
		GroupManager.smethod_0().method_16();
	}

	// Token: 0x04001ECE RID: 7886
	private Camera _gameCamera;

	// Token: 0x04001ECF RID: 7887
	public static bool m_bCheckWorldMap;

	// Token: 0x04001ED0 RID: 7888
	private PlayerProperties m_playerInfo = new PlayerProperties();
}
