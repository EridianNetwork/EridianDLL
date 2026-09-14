using System;
using System.Collections.Generic;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x0200068E RID: 1678
public class GamingBehaviour : StepBehaviour
{
	// Token: 0x06002B71 RID: 11121 RVA: 0x000CA924 File Offset: 0x000C8B24
	public override void OnShow(FrontEndStepManager.StepState lastStep, object data = null)
	{
		MonoSingleton<AppManager>.Instance.method_0().Boolean_2 = true;
		MonoSingleton<AppManager>.Instance.method_0().vmethod_18(false);
		MonoSingleton<AppManager>.Instance.method_0().vmethod_12(true);
		QuestUIDataManager.smethod_0().method_5();
		UIMapDisplayManager.smethod_0().method_0();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<QuestTrackView>().Boolean_1 = true;
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<HUDAimTargetView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<HUDPlayerInfoView>().bPVPDisp = false;
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<HUDFeedbackView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<HUDWorldTipsView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<EchoMessageView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<HUDSkillStatusView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<CharInfoView>().bPVPDisp = false;
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<HUDTeamMatePortraitView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<QuestDetailView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<HUDWrapupView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<SkillTreeView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<CurrencyUpdateView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<QuestListView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<PopupMenuView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<WeaponPreviewView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<InventoryView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<MiniMapView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<LargeMapView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<HUDTreasureBoxView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<HUDCountDownView>().Boolean_1 = false;
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<SecondWindView>();
		ChatView chatView = MonoSingleton<AppManager>.Instance.method_0().vmethod_6<ChatView>();
		chatView.method_11(new ChatParameter[]
		{
			ChatParameter.Town,
			ChatParameter.Group,
			ChatParameter.Guild,
			ChatParameter.Private,
			ChatParameter.System
		});
		chatView.method_4(ChatParameter.Group, string.Empty);
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<PauseMenuView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_6<AchievementPopUpView>();
		ItemTips.smethod_0();
	}

	// Token: 0x06002B72 RID: 11122 RVA: 0x000CAB4C File Offset: 0x000C8D4C
	public override void vmethod_0(FrontEndStepManager.StepState stepState_0)
	{
		this._gameCamera = null;
		ItemTips.smethod_1();
		MonoSingleton<AppManager>.Instance.method_0().Camera_0 = null;
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
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<HUDSkillStatusView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<HUDTeamMatePortraitView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<QuestDetailView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<SkillTreeView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<CurrencyUpdateView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<QuestListView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<QuestTrackView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<HUDWrapupView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<WeaponPreviewView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<MiniMapView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<LargeMapView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<HUDTreasureBoxView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<HUDCountDownView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<SecondWindView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<AchievementPopUpView>();
		QuestUIDataManager.smethod_0().method_6();
		UIMapDataManager.smethod_0().method_1();
		UIMapDisplayManager.smethod_0().method_1();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_7<PauseMenuView>();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_12(false);
	}

	// Token: 0x06002B73 RID: 11123 RVA: 0x0001CC50 File Offset: 0x0001AE50
	public override void OnLevelLoadingFinish()
	{
		MonoSingleton<AppManager>.Instance.method_0().Boolean_2 = true;
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InventoryView>().vmethod_6(InventoryServiceWrapper.InventoryUpdateType.FullUpdate);
		UIMapDataManager.smethod_0().method_0();
	}

	// Token: 0x06002B74 RID: 11124 RVA: 0x000CAD44 File Offset: 0x000C8F44
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
		if (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDTeamMatePortraitView>() != null)
		{
			List<PlayerInfoSync> list = new List<PlayerInfoSync>();
			List<PlayerInfoSync> list2;
			prop_.method_38(out list2);
			for (int i = 0; i < list2.Count; i++)
			{
				if (!list2[i].IsMyActor() && localPlayer.m_teamID == list2[i].m_teamID)
				{
					list.Add(list2[i]);
				}
				UIMapDataManager.smethod_0().OnPlayerPvEStatusUpdate(list2[i].GetEntity() as EntityPlayer);
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
					MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDTeamMatePortraitView>().vmethod_5(list[j], j, list.Count);
				}
			}
		}
		if (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDCountDownView>() != null)
		{
			StatisticsManager.SessionStats currentSession = MonoSingleton<StatisticsManager>.Instance.GetCurrentSession();
			if (currentSession != null && !MonoSingleton<Session>.Instance.method_13())
			{
				if (MonoSingleton<Session>.Instance.method_7().method_3())
				{
					MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDCountDownView>().Boolean_1 = true;
					int num = (int)MonoSingleton<Session>.Instance.method_7().method_2();
					MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDCountDownView>().vmethod_5(num);
				}
			}
			else
			{
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDCountDownView>().Boolean_1 = false;
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
				AvatarType avatarType = localPlayer.m_avatarDna.method_5();
				int num2 = MonoSingleton<LevelingManager>.Instance.method_3(avatarType, localPlayer.m_exp);
				int num3 = MonoSingleton<LevelingManager>.Instance.method_4(avatarType, num2);
				int num4 = MonoSingleton<LevelingManager>.Instance.method_4(avatarType, num2 + 1);
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDPlayerInfoView>().vmethod_7(localPlayer.m_exp - num3, num4 - num3);
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDPlayerInfoView>().vmethod_11(MonoSingleton<LevelingManager>.Instance.method_3(avatarType, localPlayer.m_exp));
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDPlayerInfoView>().vmethod_10(localPlayer.m_name);
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDPlayerInfoView>().vmethod_13(localPlayer.m_avatarDna.method_5());
			}
			entityWeapon = entity.vmethod_16();
			if (entityWeapon != null)
			{
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDPlayerInfoView>().vmethod_8(entityWeapon.m_ammoCount, entityWeapon.method_101(), equipmentInventoryEntity.vmethod_15(entityWeapon.m_attribute.m_weaponType), entityWeapon.m_attribute.m_weaponType);
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDAimTargetView>().vmethod_9(entityWeapon.method_99());
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDAimTargetView>().vmethod_10(entityWeapon.vmethod_1());
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDAimTargetView>().vmethod_11(entityWeapon.method_72());
				if (entityWeapon.m_ammoCount * 100 / entityWeapon.method_101() < 25)
				{
					e_USE_TYPE = E_USE_TYPE.R_RELOAD;
					if (equipmentInventoryEntity.vmethod_15(entityWeapon.m_attribute.m_weaponType) <= 0)
					{
						e_USE_TYPE = E_USE_TYPE.W_OUTAMMO;
					}
				}
			}
			else
			{
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDAimTargetView>().vmethod_9(WeaponType.TOTAL);
			}
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDPlayerInfoView>().vmethod_9(equipmentInventoryEntity.vmethod_19(), equipmentInventoryEntity.vmethod_18());
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
						if (entityWeapon != null)
						{
							itemDNA = entityWeapon.method_13();
						}
						flag = true;
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
				EntityNpc entityNpc = aimedEntity as EntityNpc;
				if (entityNpc != null && entityNpc.m_npcFamilly == EntityNpc.EntityNpcFamilly.Tutor)
				{
					flag2 = true;
				}
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDAimTargetView>().vmethod_12(aimedEntity, flag2);
			}
			else
			{
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDAimTargetView>().vmethod_12(null, false);
			}
		}
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDAimTargetView>().vmethod_8(e_USE_TYPE);
		if (entity as EntityPlayer != null)
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDSkillStatusView>().Update((entity as EntityPlayer).PlayerSkillManage_0.method_4());
		}
		if (ServiceWrapperBase<CharacterServiceWrapper>.Instance != null && ServiceWrapperBase<CharacterServiceWrapper>.Instance.vmethod_2())
		{
			this.m_playerInfo.m_name = ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_9();
			this.m_playerInfo.m_exp = ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_7();
			this.m_playerInfo.m_avatarDna = ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_13();
			this.m_playerInfo.m_level = ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_8();
			if (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<CharInfoView>() != null)
			{
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<CharInfoView>().vmethod_6(this.m_playerInfo);
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InventoryView>().vmethod_7();
			}
		}
		UIMapDataManager.smethod_0().Update();
		UIMapDisplayManager.smethod_0().Update();
	}

	// Token: 0x04001E9A RID: 7834
	private Camera _gameCamera;

	// Token: 0x04001E9B RID: 7835
	private PlayerProperties m_playerInfo = new PlayerProperties();
}
