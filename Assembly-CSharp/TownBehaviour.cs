using System;
using System.Collections.Generic;
using Core;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x0200069B RID: 1691
public class TownBehaviour : StepBehaviour
{
	// Token: 0x06002BDD RID: 11229 RVA: 0x000CE448 File Offset: 0x000CC648
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
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<InstanceSelectView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InstanceSelectView>()._enterLevelFunc = null;
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<TownHUDView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<CurrencyUpdateView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<PopupMenuView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<PlayerListView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<GroupView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<FriendView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<WeaponPreviewView>();
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
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<AchievementBoardView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<AchievementPopUpView>();
		ItemTips.smethod_0();
		this.method_1();
		if (MonoSingleton<GameSettingMgr>.Instance != null && MonoSingleton<GameSettingMgr>.Instance.method_15(GameSettingMgr.UserData.PlayedTutorial.ToString()) == 0)
		{
			MonoSingleton<GameSettingMgr>.Instance.method_14(GameSettingMgr.UserData.PlayedTutorial.ToString(), 1);
		}
		LobbyManager.smethod_0().m_bCanShowLobbyECHO = true;
	}

	// Token: 0x06002BDE RID: 11230 RVA: 0x000CE76C File Offset: 0x000CC96C
	public override void vmethod_0(FrontEndStepManager.StepState stepState_0)
	{
		this._gameCamera = null;
		MonoSingleton<AppManager>.Instance.method_0().Camera_0 = null;
		ItemTips.smethod_1();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<ChatView>();
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
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<WeaponCraftView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<WeaponMeltView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<WeaponUpgradeView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<WeaponPreviewView>();
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
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<AchievementBoardView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<AchievementPopUpView>();
		QuestUIDataManager.smethod_0().method_6();
		UIMapDataManager.smethod_0().method_1();
		UIMapDisplayManager.smethod_0().method_1();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_3();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<PauseMenuView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_12(true);
	}

	// Token: 0x06002BDF RID: 11231 RVA: 0x000CEA34 File Offset: 0x000CCC34
	public override void OnLevelLoadingFinish()
	{
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InventoryView>().vmethod_6(InventoryServiceWrapper.InventoryUpdateType.FullUpdate);
		MonoSingleton<AppManager>.Instance.method_0().Boolean_2 = true;
		MonoSingleton<AppManager>.Instance.method_0().Boolean_1 = true;
		ServiceWrapperBase<QuestServiceWrapper>.Instance.method_2();
		UIMapDataManager.smethod_0().method_0();
		this.method_3();
	}

	// Token: 0x06002BE0 RID: 11232 RVA: 0x000CEA90 File Offset: 0x000CCC90
	private void Update()
	{
		this.method_5();
		this.method_6();
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

	// Token: 0x06002BE1 RID: 11233 RVA: 0x0001CE14 File Offset: 0x0001B014
	private int method_0(PlayerInfoSync playerInfoSync_0, PlayerInfoSync playerInfoSync_1)
	{
		if (playerInfoSync_1.m_characterId == GroupManager.smethod_0().m_nLeaderId)
		{
			return 1;
		}
		return -1;
	}

	// Token: 0x06002BE2 RID: 11234 RVA: 0x000CE190 File Offset: 0x000CC390
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
				case NpcOccupation.OutfitShop: // without this, npcs in town will have empty pages for outfits
					num = townNpc.m_OutfitShopID;
					break;
				case NpcOccupation.MaterialShop: // for the jingle material shop
					num = townNpc.m_MaterialShopID;
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

	// Token: 0x06002BE3 RID: 11235 RVA: 0x0001CE2B File Offset: 0x0001B02B
	private void method_2()
	{
		ServiceWrapperBase<ShopServiceWrapper>.Instance.method_9();
	}

	// Token: 0x06002BE4 RID: 11236 RVA: 0x000CE288 File Offset: 0x000CC488
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

	// Token: 0x06002BE5 RID: 11237 RVA: 0x000CEBBC File Offset: 0x000CCDBC
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

	// Token: 0x06002BE6 RID: 11238 RVA: 0x000CEC14 File Offset: 0x000CCE14
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

	// Token: 0x06002BE7 RID: 11239 RVA: 0x0001CE66 File Offset: 0x0001B066
	public static void smethod_0()
	{
		TownBehaviour.m_MatchMakingTime.method_4();
		TownBehaviour.m_MatchMakingTime.Start(20f);
	}

	// Token: 0x06002BE8 RID: 11240 RVA: 0x0001CE81 File Offset: 0x0001B081
	public static void smethod_1()
	{
		TownBehaviour.m_MatchMakingTime.method_4();
	}

	// Token: 0x06002BE9 RID: 11241 RVA: 0x000CECF0 File Offset: 0x000CCEF0
	private void method_5()
	{
		if (TownBehaviour.m_MatchMakingTime.method_6())
		{
			Lobby lobby_ = LobbyManager.smethod_0().Lobby_0;
			if (LobbyManager.smethod_0().method_1())
			{
				if (TownBehaviour.m_MatchMakingTime.method_7())
				{
					LobbyManager.smethod_0().m_bCanShowLobbyECHO = true;
					if (lobby_.Boolean_2)
					{
						if (LobbyManager.smethod_0().method_1())
						{
							MonoSingleton<GameFlowManager>.Instance.method_12(lobby_.Playlist, lobby_.GameMode);
						}
					}
					else
					{
						LobbyManager.smethod_0().method_26();
						LobbyManager.smethod_0().method_24();
					}
				}
				else if (LobbyManager.smethod_0().method_4())
				{
					TownBehaviour.smethod_1();
					LobbyManager.smethod_0().m_bCanShowLobbyECHO = true;
					if (LobbyManager.smethod_0().method_1())
					{
						MonoSingleton<GameFlowManager>.Instance.method_12(lobby_.Playlist, lobby_.GameMode);
					}
				}
			}
			else if (TownBehaviour.m_MatchMakingTime.method_7())
			{
				LobbyManager.smethod_0().m_bCanShowLobbyECHO = true;
				if (lobby_ != null && !lobby_.Boolean_2)
				{
					LobbyManager.smethod_0().method_24();
				}
			}
		}
	}

	// Token: 0x06002BEA RID: 11242 RVA: 0x0001CE8D File Offset: 0x0001B08D
	public static void smethod_2()
	{
		DebugUtils.Log(LogCategory.GUI, "TownBehaviour.smethod_2 starting PvE matchmaking timer");
		TownBehaviour.m_PvEMatchMakingTime.method_4();
		TownBehaviour.m_PvEMatchMakingTime.Start(20f);
	}

	// Token: 0x06002BEB RID: 11243 RVA: 0x0001CEB3 File Offset: 0x0001B0B3
	public static void smethod_3()
	{
		TownBehaviour.m_PvEMatchMakingTime.method_4();
	}

	// Token: 0x06002BEC RID: 11244 RVA: 0x000CEDF4 File Offset: 0x000CCFF4
	private void method_6()
	{
		if (TownBehaviour.m_PvEMatchMakingTime.method_6())
		{
			Lobby lobby_ = LobbyManager.smethod_0().Lobby_1;
			if (TownBehaviour.m_PvEMatchMakingTime.method_7())
			{
				if (LobbyManager.smethod_0().method_11())
				{
					MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InstanceInfoView>().Boolean_1 = false;
					MonoSingleton<AppManager>.Instance.method_0().vmethod_5<NewInstanceSelectView>().Boolean_1 = false;
					MonoSingleton<GameFlowManager>.Instance.method_12(lobby_.Playlist, lobby_.GameMode);
				}
				else
				{
					DebugUtils.Log(LogCategory.GUI, "~~~~~~~Time Over!!" + ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_9() + "not PvE room Owner");
				}
			}
			else if (LobbyManager.smethod_0().method_13())
			{
				if (LobbyManager.smethod_0().method_11())
				{
					MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InstanceInfoView>().Boolean_1 = false;
					MonoSingleton<AppManager>.Instance.method_0().vmethod_5<NewInstanceSelectView>().Boolean_1 = false;
					MonoSingleton<GameFlowManager>.Instance.method_12(lobby_.Playlist, lobby_.GameMode);
				}
				else
				{
					DebugUtils.Log(LogCategory.GUI, "~~~~~~~PvE room Full!!" + ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_9() + "not PvE room Owner");
				}
				TownBehaviour.smethod_3();
			}
		}
	}

	// Token: 0x04001ED1 RID: 7889
	private Camera _gameCamera;

	// Token: 0x04001ED2 RID: 7890
	public static bool m_bCheckWorldMap = false;

	// Token: 0x04001ED3 RID: 7891
	private static Utils.Timer m_MatchMakingTime = new Utils.Timer();

	// Token: 0x04001ED4 RID: 7892
	private static Utils.Timer m_PvEMatchMakingTime = new Utils.Timer();

	// Token: 0x04001ED5 RID: 7893
	private PlayerProperties m_playerInfo = new PlayerProperties();
}
