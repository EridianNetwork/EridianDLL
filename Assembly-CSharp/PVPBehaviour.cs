using System;
using System.Collections.Generic;
using ns0;
using UnityEngine;

// Token: 0x02000698 RID: 1688
public class PVPBehaviour : StepBehaviour
{
	// Token: 0x06002BC8 RID: 11208 RVA: 0x000CCF2C File Offset: 0x000CB12C
	public override void OnShow(FrontEndStepManager.StepState lastStep, object data = null)
	{
		MonoSingleton<AppManager>.Instance.method_0().vmethod_12(true);
		QuestUIDataManager.smethod_0().method_5();
		UIMapDisplayManager.smethod_0().method_0();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<HUDAimTargetView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<HUDPlayerInfoView>().bPVPDisp = true;
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<HUDFeedbackView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<HUDWorldTipsView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<EchoMessageView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<HUDVictoryCondition>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<HUDPvPInfoView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<HUDSkillStatusView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<CharInfoView>().bPVPDisp = true;
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<HUDTeamMatePortraitView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<SkillTreeView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<CurrencyUpdateView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<PopupMenuView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<WeaponPreviewView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<LargeMapView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<InventoryView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<MiniMapView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<HUDPvPKillStampView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<HUDTreasureBoxView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<AchievementPopUpView>();
		ChatView chatView = MonoSingleton<AppManager>.Instance.method_0().vmethod_6<ChatView>();
		if (MonoSingleton<Session>.Instance.method_14())
		{
			chatView.method_11(new ChatParameter[]
			{
				ChatParameter.Town,
				ChatParameter.Team,
				ChatParameter.Guild,
				ChatParameter.Private,
				ChatParameter.System
			});
			chatView.method_4(ChatParameter.Team, string.Empty);
		}
		else
		{
			chatView.method_11(new ChatParameter[]
			{
				ChatParameter.Town,
				ChatParameter.Group,
				ChatParameter.Guild,
				ChatParameter.Private,
				ChatParameter.System
			});
			chatView.method_4(ChatParameter.Group, string.Empty);
		}
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<PauseMenuView>();
		ItemTips.smethod_0();
	}

	// Token: 0x06002BC9 RID: 11209 RVA: 0x000CD134 File Offset: 0x000CB334
	public override void vmethod_0(FrontEndStepManager.StepState stepState_0)
	{
		this._gameCamera = null;
		MonoSingleton<AppManager>.Instance.method_0().Camera_0 = null;
		ItemTips.smethod_1();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_3();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<ChatView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<PopupMenuView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<InventoryView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<CharInfoView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<HUDWorldTipsView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<HUDFeedbackView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<HUDAimTargetView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<HUDPlayerInfoView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<EchoMessageView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<HUDVictoryCondition>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<HUDPvPInfoView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<HUDSkillStatusView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<HUDTeamMatePortraitView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<SkillTreeView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<CurrencyUpdateView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<LargeMapView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<WeaponPreviewView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<MiniMapView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<HUDPvPKillStampView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<HUDTreasureBoxView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<AchievementPopUpView>();
		QuestUIDataManager.smethod_0().method_6();
		UIMapDataManager.smethod_0().method_1();
		UIMapDisplayManager.smethod_0().method_1();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<PauseMenuView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_12(false);
	}

	// Token: 0x06002BCA RID: 11210 RVA: 0x000CD2FC File Offset: 0x000CB4FC
	private void Update()
	{
		if (this._gameCamera == null)
		{
			GameObject gameObject = GameObject.Find("FpsCamera(Clone)");
			if (gameObject != null)
			{
				this._gameCamera = gameObject.GetComponent<Camera>();
				MonoSingleton<AppManager>.Instance.method_0().Camera_0 = this._gameCamera;
			}
		}
		else
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDWorldTipsView>().vmethod_6();
		}
		Session prop_ = MonoSingleton<Session>.Instance;
		if (prop_ == null)
		{
			return;
		}
		PlayerInfoSync localPlayer = prop_.GetLocalPlayer();
		if (localPlayer == null)
		{
			return;
		}
		if (!MonoSingleton<Session>.Instance.method_16() && MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDTeamMatePortraitView>() != null)
		{
			List<PlayerInfoSync> list = new List<PlayerInfoSync>();
			List<PlayerInfoSync> list2;
			MonoSingleton<Session>.Instance.method_38(out list2);
			for (int i = 0; i < list2.Count; i++)
			{
				if (!list2[i].IsMyActor() && localPlayer.m_teamID == list2[i].m_teamID)
				{
					list.Add(list2[i]);
				}
			}
			if (list.Count == 0)
			{
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDTeamMatePortraitView>().vmethod_8();
			}
			else
			{
				for (int j = 0; j < list.Count; j++)
				{
					MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDTeamMatePortraitView>().vmethod_6(list[j], j, list.Count);
				}
			}
		}
		E_USE_TYPE e_USE_TYPE = E_USE_TYPE.E_NONE;
		Entity entity = localPlayer.GetEntity();
		EntityWeapon entityWeapon = null;
		if (entity)
		{
			GroupManager.smethod_0().method_16();
			EquipmentInventoryEntity equipmentInventoryEntity = entity.vmethod_19();
			if (equipmentInventoryEntity != null)
			{
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDPlayerInfoView>().vmethod_6(equipmentInventoryEntity.vmethod_4(), equipmentInventoryEntity.vmethod_0());
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDPlayerInfoView>().vmethod_5(equipmentInventoryEntity.vmethod_6(), equipmentInventoryEntity.vmethod_7());
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDPlayerInfoView>().vmethod_7(0, 0);
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDPlayerInfoView>().vmethod_11(MonoSingleton<LevelingManager>.Instance.method_2());
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDPlayerInfoView>().vmethod_10(localPlayer.m_name);
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDPlayerInfoView>().vmethod_13(localPlayer.m_avatarDna.method_5());
			}
			entityWeapon = entity.vmethod_16();
			if (entityWeapon != null)
			{
				if (equipmentInventoryEntity != null)
				{
					MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDPlayerInfoView>().vmethod_8(entityWeapon.m_ammoCount, entityWeapon.method_101(), equipmentInventoryEntity.vmethod_15(entityWeapon.m_attribute.m_weaponType), entityWeapon.m_attribute.m_weaponType);
				}
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDAimTargetView>().vmethod_9(entityWeapon.method_99());
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDAimTargetView>().vmethod_10(entityWeapon.vmethod_1());
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDAimTargetView>().vmethod_11(entityWeapon.method_72());
				if (entityWeapon.m_ammoCount * 100 / entityWeapon.method_101() < 25)
				{
					e_USE_TYPE = E_USE_TYPE.R_RELOAD;
				}
			}
			if (equipmentInventoryEntity != null)
			{
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDPlayerInfoView>().vmethod_9(equipmentInventoryEntity.vmethod_19(), equipmentInventoryEntity.vmethod_18());
			}
		}
		if (MonoSingleton<TargetingManager>.Instance != null)
		{
			bool flag = false;
			if (MonoSingleton<TargetingManager>.Instance.method_4())
			{
				Pickable pickable = MonoSingleton<TargetingManager>.Instance.m_availableInteraction as Pickable;
				if (pickable != null && pickable.m_entity.vmethod_67())
				{
					EntityObject entity2 = pickable.m_entity;
					ItemDNA itemDNA = null;
					if (entity2 is EntityWeapon)
					{
						flag = true;
						itemDNA = entityWeapon.method_13();
					}
					else if (entity2 is EntityShield)
					{
						itemDNA = ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_26();
					}
					MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDAimTargetView>().vmethod_13(entity2, false, !InteractionManager.InteractionManager_0.method_5(entity, entity2.method_13()), itemDNA);
				}
				e_USE_TYPE = MonoSingleton<TargetingManager>.Instance.m_availableInteraction.imethod_6();
			}
			else if (MonoSingleton<TargetingManager>.Instance.method_5())
			{
				Pickable pickable2 = MonoSingleton<TargetingManager>.Instance.m_seeableInteraction as Pickable;
				if (pickable2 != null && pickable2.m_entity.vmethod_67())
				{
					EntityObject entity3 = pickable2.m_entity;
					MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDAimTargetView>().vmethod_13(entity3, true, !InteractionManager.InteractionManager_0.method_5(entity, entity3.method_13()), null);
				}
			}
			else
			{
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDAimTargetView>().vmethod_13(null, true, false, null);
			}
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDPlayerInfoView>().vmethod_17(flag);
			Entity aimedEntity = MonoSingleton<TargetingManager>.Instance.m_aimedEntity;
			if (aimedEntity != null)
			{
				bool flag2 = aimedEntity.vmethod_9() == entity.vmethod_9();
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDAimTargetView>().vmethod_12(aimedEntity, flag2);
			}
			else
			{
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDAimTargetView>().vmethod_12(null, false);
			}
		}
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDAimTargetView>().vmethod_8(e_USE_TYPE);
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDPvPInfoView>().Boolean_1 = true;
		PlayerInfoSync localPlayer2 = MonoSingleton<Session>.Instance.GetLocalPlayer();
		StatisticsManager.SessionStats currentSession = MonoSingleton<StatisticsManager>.Instance.GetCurrentSession();
		if (localPlayer2 && currentSession != null && (currentSession.m_endScore != 0 || currentSession.method_1() != 0))
		{
			StatisticsManager.StatSheet personalStatSheet = MonoSingleton<StatisticsManager>.Instance.GetCurrentSession().GetPersonalStatSheet(localPlayer2);
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDVictoryCondition>().vmethod_6(currentSession.method_1(), personalStatSheet);
		}
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDPvPInfoView>().Update(Time.deltaTime);
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDPvPKillStampView>().Update(Time.deltaTime);
		if (entity as EntityPlayer != null)
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDSkillStatusView>().Update((entity as EntityPlayer).PlayerSkillManage_0.method_4());
		}
		if (ServiceWrapperBase<CharacterServiceWrapper>.Instance.vmethod_2())
		{
			PlayerProperties playerProperties = new PlayerProperties();
			playerProperties.m_name = ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_9();
			playerProperties.m_exp = 0;
			playerProperties.m_avatarDna = ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_13();
			playerProperties.m_level = 36;
			if (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<CharInfoView>() != null)
			{
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<CharInfoView>().vmethod_6(playerProperties);
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InventoryView>().vmethod_7();
			}
		}
		UIMapDataManager.smethod_0().Update();
		UIMapDisplayManager.smethod_0().Update();
	}

	// Token: 0x06002BCB RID: 11211 RVA: 0x0001CC50 File Offset: 0x0001AE50
	public override void OnLevelLoadingFinish()
	{
		MonoSingleton<AppManager>.Instance.method_0().Boolean_2 = true;
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InventoryView>().vmethod_6(InventoryServiceWrapper.InventoryUpdateType.FullUpdate);
		UIMapDataManager.smethod_0().method_0();
	}

	// Token: 0x04001ECD RID: 7885
	private Camera _gameCamera;
}
