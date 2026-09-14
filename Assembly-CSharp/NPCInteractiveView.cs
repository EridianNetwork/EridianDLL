using System;
using System.Collections.Generic;
using ns0;
using XsdSettings;

// Token: 0x0200071F RID: 1823
public class NPCInteractiveView : BaseView, IQuestServiceNotificationListerner, IQuestUINotificationListerner
{
	// Token: 0x06003070 RID: 12400 RVA: 0x0001FA30 File Offset: 0x0001DC30
	public override void vmethod_2()
	{
		base.vmethod_2();
		MonoSingleton<AppManager>.Instance.method_0().method_6(this);
		QuestUIDataManager.smethod_0().method_0(this);
	}

	// Token: 0x06003071 RID: 12401 RVA: 0x0001FA53 File Offset: 0x0001DC53
	public override void vmethod_3()
	{
		base.vmethod_3();
		MonoSingleton<AppManager>.Instance.method_0().method_7(this);
		QuestUIDataManager.smethod_0().method_1(this);
	}

	// Token: 0x06003072 RID: 12402 RVA: 0x0001FA76 File Offset: 0x0001DC76
	public override bool vmethod_4()
	{
		if (this._bVisible)
		{
			NPC_UIFlowController.smethod_0().method_3(NPC_UIFlowController.NPC_UIFlowState.None);
			return true;
		}
		return base.vmethod_4();
	}

	// Token: 0x06003073 RID: 12403 RVA: 0x0001E1F6 File Offset: 0x0001C3F6
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		base.vmethod_1(bool_0, bool_1);
	}

	// Token: 0x06003074 RID: 12404 RVA: 0x0001FA93 File Offset: 0x0001DC93
	public virtual void vmethod_5(global::XsdSettings.TownNpc townNpc_0)
	{
		this._NPCInfo = townNpc_0;
		this.method_4();
		this.vmethod_6();
	}

	// Token: 0x06003075 RID: 12405 RVA: 0x0001FAA8 File Offset: 0x0001DCA8
	public void method_3()
	{
		this.vmethod_6();
	}

	// Token: 0x06003076 RID: 12406 RVA: 0x000DD1A0 File Offset: 0x000DB3A0
	protected void method_4()
	{
		this._onShowQuestItemList.Clear();
		Dictionary<int, QuestProgress> dictionary = QuestUIDataManager.smethod_0().method_7();
		if (this._NPCInfo != null && dictionary != null)
		{
			List<int> list = QuestUIDataManager.smethod_0().method_17(this._NPCInfo.m_id);
			List<int> list2 = QuestUIDataManager.smethod_0().method_18(this._NPCInfo.m_id);
			foreach (QuestProgress questProgress in dictionary.Values)
			{
				if (questProgress.mStatus == QuestState.Available)
				{
					if (list != null && list.Count != 0)
					{
						Quest quest = QuestUIDataManager.smethod_0().method_2(questProgress.mQuestId);
						if (quest != null && list.Contains(questProgress.mQuestId))
						{
							NPCInteractiveView.FunctionListItemData functionListItemData = new NPCInteractiveView.FunctionListItemData();
							functionListItemData.functionType = NPC_UIFlowController.NPC_UIFlowState.Quest;
							functionListItemData.bAlwaysInBoard = false;
							functionListItemData.quest = quest;
							functionListItemData.questProgress = questProgress;
							this._onShowQuestItemList.Add(functionListItemData);
						}
					}
				}
				else if ((questProgress.mStatus == QuestState.InProgress || questProgress.mStatus == QuestState.Completed) && list2 != null && list2.Count != 0)
				{
					Quest quest2 = QuestUIDataManager.smethod_0().method_2(questProgress.mQuestId);
					if (quest2 != null && list2.Contains(questProgress.mQuestId))
					{
						NPCInteractiveView.FunctionListItemData functionListItemData2 = new NPCInteractiveView.FunctionListItemData();
						functionListItemData2.functionType = NPC_UIFlowController.NPC_UIFlowState.Quest;
						functionListItemData2.bAlwaysInBoard = false;
						functionListItemData2.quest = quest2;
						functionListItemData2.questProgress = questProgress;
						this._onShowQuestItemList.Add(functionListItemData2);
					}
				}
			}
		}
		this._onShowQuestItemList.Sort(new Comparison<NPCInteractiveView.FunctionListItemData>(this.method_5));
	}

	// Token: 0x06003077 RID: 12407 RVA: 0x0001FAB0 File Offset: 0x0001DCB0
	public void OnQuestAbandoned(int characterId, int questId)
	{
		this.method_4();
		this.vmethod_6();
	}

	// Token: 0x06003078 RID: 12408 RVA: 0x0001FAB0 File Offset: 0x0001DCB0
	public void OnQuestUpdate(int characterId, int questId, QuestState questState)
	{
		this.method_4();
		this.vmethod_6();
	}

	// Token: 0x06003079 RID: 12409 RVA: 0x0001FAB0 File Offset: 0x0001DCB0
	public void OnQuestAccepted(int characterId, int questId)
	{
		this.method_4();
		this.vmethod_6();
	}

	// Token: 0x0600307A RID: 12410 RVA: 0x0001FAB0 File Offset: 0x0001DCB0
	public void OnQuestRewardClaimed(int characterId, int questId, QuestReward[] rewards)
	{
		this.method_4();
		this.vmethod_6();
	}

	// Token: 0x0600307B RID: 12411 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnNewTask(int iCharacterID, int iQuestID, int iNewTaskID)
	{
	}

	// Token: 0x0600307C RID: 12412 RVA: 0x0001FAB0 File Offset: 0x0001DCB0
	public void OnQuestProgress(int characterId, Dictionary<int, QuestProgress> playerQuestProgress)
	{
		this.method_4();
		this.vmethod_6();
	}

	// Token: 0x0600307D RID: 12413 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnTaskProgressUpgrade(int questID, int taskID, int count)
	{
	}

	// Token: 0x0600307E RID: 12414 RVA: 0x000DD35C File Offset: 0x000DB55C
	protected int method_5(NPCInteractiveView.FunctionListItemData functionListItemData_0, NPCInteractiveView.FunctionListItemData functionListItemData_1)
	{
		int num = 0;
		if (functionListItemData_0.quest != null && functionListItemData_1.quest != null)
		{
			num = functionListItemData_0.quest.mId - functionListItemData_1.quest.mId;
		}
		return num;
	}

	// Token: 0x0600307F RID: 12415 RVA: 0x000DD394 File Offset: 0x000DB594
	protected virtual void vmethod_6()
	{
		this._totalList.Clear();
		if (this._NPCInfo != null && this._NPCInfo.m_occupations != null)
		{
			int num = ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_8();
			foreach (NpcOccupation npcOccupation in this._NPCInfo.m_occupations)
			{
				NPCInteractiveView.FunctionListItemData functionListItemData = new NPCInteractiveView.FunctionListItemData();
				functionListItemData.bAlwaysInBoard = true;
				switch (npcOccupation)
				{
				case NpcOccupation.Crafting:
					if (num >= LevelingManager.CRAFTING_UNLOCK_LEVEL)
					{
						functionListItemData.functionType = NPC_UIFlowController.NPC_UIFlowState.Crafting;
						this._totalList.Add(functionListItemData);
					}
					break;
				case NpcOccupation.Melting:
					if (num >= LevelingManager.MELTING_UNLOCK_LEVEL)
					{
						functionListItemData.functionType = NPC_UIFlowController.NPC_UIFlowState.Melting;
						this._totalList.Add(functionListItemData);
					}
					break;
				case NpcOccupation.CoinShieldShop:
					if (num >= LevelingManager.SELLING_UNLOCK_LEVEL)
					{
						functionListItemData.functionType = NPC_UIFlowController.NPC_UIFlowState.CoinShieldShop;
						this._totalList.Add(functionListItemData);
					}
					break;
				case NpcOccupation.ClassModeShop:
					if (num >= LevelingManager.CLASSMODESHOP_UNLOCK_LEVEL)
					{
						functionListItemData.functionType = NPC_UIFlowController.NPC_UIFlowState.ClassModeShop;
						this._totalList.Add(functionListItemData);
					}
					break;
				case NpcOccupation.WeaponShop:
					if (num >= LevelingManager.SELLING_UNLOCK_LEVEL)
					{
						functionListItemData.functionType = NPC_UIFlowController.NPC_UIFlowState.WeaponShop;
						this._totalList.Add(functionListItemData);
					}
					break;
				case NpcOccupation.Mail:
					if (num >= LevelingManager.MAIL_UNLOCK_LEVEL)
					{
						functionListItemData.functionType = NPC_UIFlowController.NPC_UIFlowState.Mail;
						this._totalList.Add(functionListItemData);
					}
					break;
				case NpcOccupation.Guild:
					if (num >= LevelingManager.CREATEGUILD_UNLOCK_LEVEL)
					{
						if (GuildManager.smethod_0().method_5())
						{
							functionListItemData.functionType = NPC_UIFlowController.NPC_UIFlowState.CreateGuild;
							this._totalList.Add(functionListItemData);
						}
						if (GuildManager.smethod_0().method_8())
						{
							NPCInteractiveView.FunctionListItemData functionListItemData2 = new NPCInteractiveView.FunctionListItemData();
							functionListItemData2.bAlwaysInBoard = true;
							functionListItemData2.functionType = NPC_UIFlowController.NPC_UIFlowState.DismissGuild;
							this._totalList.Add(functionListItemData2);
						}
						else if (GuildManager.smethod_0().method_7())
						{
							NPCInteractiveView.FunctionListItemData functionListItemData3 = new NPCInteractiveView.FunctionListItemData();
							functionListItemData3.bAlwaysInBoard = true;
							functionListItemData3.functionType = NPC_UIFlowController.NPC_UIFlowState.QuitGuild;
							this._totalList.Add(functionListItemData3);
						}
					}
					break;
				case NpcOccupation.Warehouse:
					if (num >= LevelingManager.WAREHOUSE_UNLOCK_LEVEL)
					{
						functionListItemData.functionType = NPC_UIFlowController.NPC_UIFlowState.Warehouse;
						this._totalList.Add(functionListItemData);
					}
					break;
				case NpcOccupation.WeaponUpgrade:
					if (num >= LevelingManager.UPGRADE_UNLOCK_LEVEL)
					{
						functionListItemData.functionType = NPC_UIFlowController.NPC_UIFlowState.WeaponUpgrade;
						this._totalList.Add(functionListItemData);
					}
					break;
				case NpcOccupation.PvP:
					if (num >= LevelingManager.PVP_UNLOCK_LEVEL)
					{
						functionListItemData.functionType = NPC_UIFlowController.NPC_UIFlowState.PvP;
						this._totalList.Add(functionListItemData);
					}
					break;
				case NpcOccupation.OutfitShop:
					if (num >= LevelingManager.SELLING_UNLOCK_LEVEL)
					{
						functionListItemData.functionType = NPC_UIFlowController.NPC_UIFlowState.OutfitShop;
						this._totalList.Add(functionListItemData);
					}
					break;
				}
			}
		}
		this._totalList.AddRange(this._onShowQuestItemList);
		NPCInteractiveView.FunctionListItemData functionListItemData4 = new NPCInteractiveView.FunctionListItemData();
		functionListItemData4.functionType = NPC_UIFlowController.NPC_UIFlowState.None;
		functionListItemData4.bAlwaysInBoard = true;
		this._totalList.Add(functionListItemData4);
	}

	// Token: 0x06003080 RID: 12416 RVA: 0x000DD668 File Offset: 0x000DB868
	public virtual void vmethod_7(NPCInteractiveView.FunctionListItemData functionListItemData_0)
	{
		if (functionListItemData_0.functionType == NPC_UIFlowController.NPC_UIFlowState.Quest)
		{
			if (functionListItemData_0.questProgress != null && functionListItemData_0.quest != null)
			{
				NPC_UIFlowController.smethod_0().method_0().onShowQuest = functionListItemData_0.quest;
				NPC_UIFlowController.smethod_0().method_0().onShowQuestProgress = functionListItemData_0.questProgress;
				switch (functionListItemData_0.questProgress.mStatus)
				{
				case QuestState.Available:
				case QuestState.Completed:
					NPC_UIFlowController.smethod_0().method_3(NPC_UIFlowController.NPC_UIFlowState.NpcDialog);
					break;
				case QuestState.InProgress:
					NPC_UIFlowController.smethod_0().method_3(NPC_UIFlowController.NPC_UIFlowState.Quest);
					break;
				}
			}
		}
		else if (functionListItemData_0.functionType == NPC_UIFlowController.NPC_UIFlowState.DismissGuild)
		{
			GuildManager.smethod_0().method_17();
			this.vmethod_6();
		}
		else if (functionListItemData_0.functionType == NPC_UIFlowController.NPC_UIFlowState.QuitGuild)
		{
			if (GuildManager.smethod_0().method_7())
			{
				GuildManager.smethod_0().method_34();
			}
			NPC_UIFlowController.smethod_0().method_3(NPC_UIFlowController.NPC_UIFlowState.None);
			this.vmethod_6();
		}
		else
		{
			NPC_UIFlowController.smethod_0().method_3(functionListItemData_0.functionType);
		}
	}

	// Token: 0x040021AF RID: 8623
	protected global::XsdSettings.TownNpc _NPCInfo;

	// Token: 0x040021B0 RID: 8624
	protected List<NPCInteractiveView.FunctionListItemData> _totalList = new List<NPCInteractiveView.FunctionListItemData>();

	// Token: 0x040021B1 RID: 8625
	protected List<NPCInteractiveView.FunctionListItemData> _onShowQuestItemList = new List<NPCInteractiveView.FunctionListItemData>();

	// Token: 0x040021B2 RID: 8626
	public static int MAX_FUNCTION_ITEM_COUNT = 6;

	// Token: 0x02000720 RID: 1824
	public class FunctionListItemData
	{
		// Token: 0x040021B3 RID: 8627
		public NPC_UIFlowController.NPC_UIFlowState functionType;

		// Token: 0x040021B4 RID: 8628
		public bool bAlwaysInBoard;

		// Token: 0x040021B5 RID: 8629
		public Quest quest;

		// Token: 0x040021B6 RID: 8630
		public QuestProgress questProgress;
	}
}
