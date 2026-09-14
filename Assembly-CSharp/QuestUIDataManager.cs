using System;
using System.Collections.Generic;
using System.Text;
using ns0;
using XsdSettings;

// Token: 0x02000749 RID: 1865
public class QuestUIDataManager : IQuestServiceNotificationListerner
{
	// Token: 0x06003136 RID: 12598 RVA: 0x000DFF18 File Offset: 0x000DE118
	private QuestUIDataManager()
	{
		this._titlePriority.Add(NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_DONE, 1);
		this._titlePriority.Add(NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_NEW, 2);
		this._titlePriority.Add(NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_SPECIAL_DONE, 3);
		this._titlePriority.Add(NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_SPECIAL_NEW, 4);
		this._titlePriority.Add(NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_PROGRESS, 5);
		this._titlePriority.Add(NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_DAILY_NEW, 6);
		this._titlePriority.Add(NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_DAILY_DONE, 1);
		this._titlePriority.Add(NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_NONE, 8);
	}

	// Token: 0x06003137 RID: 12599 RVA: 0x00020044 File Offset: 0x0001E244
	public static QuestUIDataManager smethod_0()
	{
		if (QuestUIDataManager._mgrRef == null)
		{
			QuestUIDataManager._mgrRef = new QuestUIDataManager();
		}
		return QuestUIDataManager._mgrRef;
	}

	// Token: 0x06003138 RID: 12600 RVA: 0x0002005C File Offset: 0x0001E25C
	public void method_0(IQuestUINotificationListerner iquestUINotificationListerner_0)
	{
		if (!this._notiListener.Contains(iquestUINotificationListerner_0))
		{
			this._notiListener.Add(iquestUINotificationListerner_0);
		}
	}

	// Token: 0x06003139 RID: 12601 RVA: 0x00020078 File Offset: 0x0001E278
	public void method_1(IQuestUINotificationListerner iquestUINotificationListerner_0)
	{
		if (this._notiListener.Contains(iquestUINotificationListerner_0))
		{
			this._notiListener.Remove(iquestUINotificationListerner_0);
		}
	}

	// Token: 0x0600313A RID: 12602 RVA: 0x00020095 File Offset: 0x0001E295
	public Quest method_2(int int_0)
	{
		return ServiceWrapperBase<QuestServiceWrapper>.Instance.method_18(int_0);
	}

	// Token: 0x0600313B RID: 12603 RVA: 0x000DFFE0 File Offset: 0x000DE1E0
	public string method_3(Quest quest_0, QuestProgress questProgress_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (quest_0.mTasks != null)
		{
			int num = ((questProgress_0.mCurrentTask >= quest_0.mTasks.Length) ? (quest_0.mTasks.Length - 1) : questProgress_0.mCurrentTask);
			stringBuilder.Append(LocalizedString.smethod_0(new LocalizedString(quest_0.mTasks[num].mDescription)));
			int num2 = 0;
			int num3 = 0;
			bool flag = false;
			QuestTaskType mType = quest_0.mTasks[num].mType;
			switch (mType)
			{
			case QuestTaskType.BringTo:
				flag = true;
				num3 = quest_0.mTasks[num].mMaterialCount;
				if (ServiceWrapperBase<InventoryServiceWrapper>.Instance.vmethod_2())
				{
					num2 = ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_33(quest_0.mTasks[num].mMaterialType);
					num2 = ((num2 <= num3) ? num2 : num3);
					goto IL_00FC;
				}
				goto IL_00FC;
			case QuestTaskType.Damage:
				goto IL_00CB;
			}
			if (mType != QuestTaskType.Kills)
			{
				goto IL_00FC;
			}
			IL_00CB:
			flag = true;
			if (questProgress_0.mStatus == QuestState.Completed)
			{
				num2 = quest_0.mTasks[num].mTarget;
			}
			else
			{
				num2 = questProgress_0.mTaskProgress;
			}
			num3 = quest_0.mTasks[num].mTarget;
			IL_00FC:
			if (flag)
			{
				stringBuilder.Append(" ").Append(num2).Append("/")
					.Append(num3);
			}
		}
		return stringBuilder.ToString();
	}

	// Token: 0x0600313C RID: 12604 RVA: 0x000E0118 File Offset: 0x000DE318
	public QuestProgress method_4(int int_0)
	{
		QuestProgress questProgress = null;
		if (this._playerQuestProgress != null)
		{
			this._playerQuestProgress.TryGetValue(int_0, out questProgress);
		}
		return questProgress;
	}

	// Token: 0x0600313D RID: 12605 RVA: 0x000E0140 File Offset: 0x000DE340
	public void method_5()
	{
		ServiceWrapperBase<QuestServiceWrapper>.Instance.method_0(this);
		this.OnQuestProgress(0, ServiceWrapperBase<QuestServiceWrapper>.Instance.method_7(false));
		ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_0(new InventoryServiceWrapper.InventoryUpdateCallback(this.method_11));
		NPC_UIFlowController.smethod_0().method_10(new NPC_UIFlowController.onUIShowOff(this.method_21));
	}

	// Token: 0x0600313E RID: 12606 RVA: 0x000200A2 File Offset: 0x0001E2A2
	public void method_6()
	{
		ServiceWrapperBase<QuestServiceWrapper>.Instance.method_1(this);
		ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_1(new InventoryServiceWrapper.InventoryUpdateCallback(this.method_11));
		NPC_UIFlowController.smethod_0().method_11(new NPC_UIFlowController.onUIShowOff(this.method_21));
	}

	// Token: 0x0600313F RID: 12607 RVA: 0x000200DB File Offset: 0x0001E2DB
	public Dictionary<int, QuestProgress> method_7()
	{
		return this._playerQuestProgress;
	}

	// Token: 0x06003140 RID: 12608 RVA: 0x000200E3 File Offset: 0x0001E2E3
	public void method_8(int int_0)
	{
		ServiceWrapperBase<QuestServiceWrapper>.Instance.method_10(OnlineService.s_characterId, int_0);
	}

	// Token: 0x06003141 RID: 12609 RVA: 0x000200F5 File Offset: 0x0001E2F5
	public void method_9(int int_0)
	{
		ServiceWrapperBase<QuestServiceWrapper>.Instance.method_5(int_0);
	}

	// Token: 0x06003142 RID: 12610 RVA: 0x00020102 File Offset: 0x0001E302
	public void method_10(int int_0, byte[] byte_0)
	{
		ServiceWrapperBase<QuestServiceWrapper>.Instance.method_4(int_0, byte_0);
	}

	// Token: 0x06003143 RID: 12611 RVA: 0x00020110 File Offset: 0x0001E310
	public void method_11(InventoryServiceWrapper.InventoryUpdateType inventoryUpdateType_0)
	{
		this.OnQuestProgress(0, this._playerQuestProgress);
	}

	// Token: 0x06003144 RID: 12612 RVA: 0x000E0198 File Offset: 0x000DE398
	public void OnQuestUpdate(int accountId, int questId, QuestState questState)
	{
		this.method_12();
		foreach (IQuestUINotificationListerner questUINotificationListerner in this._notiListener)
		{
			questUINotificationListerner.OnQuestUpdate(accountId, questId, questState);
		}
		if (questState == QuestState.InProgress)
		{
			Quest quest = ServiceWrapperBase<QuestServiceWrapper>.Instance.method_18(questId);
			if (quest != null && quest.mTasks.Length > 0 && quest.mTasks[0].mTaskEchoIDList != null)
			{
				foreach (string text in quest.mTasks[0].mTaskEchoIDList)
				{
					this.method_20(text);
				}
			}
		}
	}

	// Token: 0x06003145 RID: 12613 RVA: 0x000E0250 File Offset: 0x000DE450
	public void OnNewTask(int iCharacterID, int iQuestID, int iNewTaskID)
	{
		this.method_12();
		Quest quest = ServiceWrapperBase<QuestServiceWrapper>.Instance.method_18(iQuestID);
		if (quest != null && quest.mTasks.Length > iNewTaskID && quest.mTasks[iNewTaskID].mTaskEchoIDList != null)
		{
			foreach (string text in quest.mTasks[iNewTaskID].mTaskEchoIDList)
			{
				this.method_20(text);
			}
		}
		foreach (IQuestUINotificationListerner questUINotificationListerner in this._notiListener)
		{
			questUINotificationListerner.OnNewTask(iCharacterID, iQuestID, iNewTaskID);
		}
	}

	// Token: 0x06003146 RID: 12614 RVA: 0x000E0300 File Offset: 0x000DE500
	public void OnQuestProgress(int characterID, Dictionary<int, QuestProgress> questProgress)
	{
		this._playerQuestProgress = questProgress;
		this.method_12();
		foreach (IQuestUINotificationListerner questUINotificationListerner in this._notiListener)
		{
			questUINotificationListerner.OnQuestProgress(characterID, questProgress);
		}
	}

	// Token: 0x06003147 RID: 12615 RVA: 0x000E0360 File Offset: 0x000DE560
	public void OnQuestRewardClaimed(int accountId, int questId, QuestReward[] rewards)
	{
		this.method_12();
		foreach (IQuestUINotificationListerner questUINotificationListerner in this._notiListener)
		{
			questUINotificationListerner.OnQuestRewardClaimed(accountId, questId, rewards);
		}
	}

	// Token: 0x06003148 RID: 12616 RVA: 0x000E03BC File Offset: 0x000DE5BC
	public void OnQuestAbandoned(int accountId, int questId)
	{
		this.method_12();
		foreach (IQuestUINotificationListerner questUINotificationListerner in this._notiListener)
		{
			questUINotificationListerner.OnQuestAbandoned(accountId, questId);
		}
	}

	// Token: 0x06003149 RID: 12617 RVA: 0x000E0418 File Offset: 0x000DE618
	public void OnQuestAccepted(int accountId, int questId)
	{
		this.method_12();
		foreach (IQuestUINotificationListerner questUINotificationListerner in this._notiListener)
		{
			questUINotificationListerner.OnQuestAccepted(accountId, questId);
		}
	}

	// Token: 0x0600314A RID: 12618 RVA: 0x000E0474 File Offset: 0x000DE674
	public void OnTaskProgressUpgrade(int questID, int taskID, int count)
	{
		this.method_12();
		foreach (IQuestUINotificationListerner questUINotificationListerner in this._notiListener)
		{
			questUINotificationListerner.OnTaskProgressUpgrade(questID, taskID, count);
		}
	}

	// Token: 0x0600314B RID: 12619 RVA: 0x000E04D0 File Offset: 0x000DE6D0
	protected void method_12()
	{
		this._npcClaimerQuests.Clear();
		this._npcGiverQuests.Clear();
		this._npcQuestTitleCollection.Clear();
		foreach (KeyValuePair<int, QuestProgress> keyValuePair in this._playerQuestProgress)
		{
			Quest quest = ServiceWrapperBase<QuestServiceWrapper>.Instance.method_18(keyValuePair.Value.mQuestId);
			if (quest != null)
			{
				foreach (int num in quest.mGiverIdList)
				{
					List<int> list = null;
					if (!this._npcGiverQuests.TryGetValue(num, out list))
					{
						list = new List<int>();
						this._npcGiverQuests.Add(num, list);
					}
					list.Add(quest.mId);
				}
				foreach (int num2 in quest.mReclaimerIdList)
				{
					List<int> list2 = null;
					if (!this._npcClaimerQuests.TryGetValue(num2, out list2))
					{
						list2 = new List<int>();
						this._npcClaimerQuests.Add(num2, list2);
					}
					list2.Add(quest.mId);
				}
			}
		}
		this.method_13();
	}

	// Token: 0x0600314C RID: 12620 RVA: 0x000E0614 File Offset: 0x000DE814
	protected void method_13()
	{
		foreach (KeyValuePair<int, List<int>> keyValuePair in this._npcGiverQuests)
		{
			List<NpcTitleMgr.NPC_ICON_TYPE> list = null;
			if (!this._npcQuestTitleCollection.TryGetValue(keyValuePair.Key, out list))
			{
				list = new List<NpcTitleMgr.NPC_ICON_TYPE>();
				this._npcQuestTitleCollection.Add(keyValuePair.Key, list);
			}
			foreach (int num in keyValuePair.Value)
			{
				NpcTitleMgr.NPC_ICON_TYPE npc_ICON_TYPE = this.method_15(num, keyValuePair.Key);
				if (!list.Contains(npc_ICON_TYPE))
				{
					list.Add(npc_ICON_TYPE);
				}
			}
		}
		foreach (KeyValuePair<int, List<int>> keyValuePair2 in this._npcClaimerQuests)
		{
			List<NpcTitleMgr.NPC_ICON_TYPE> list2 = null;
			if (!this._npcQuestTitleCollection.TryGetValue(keyValuePair2.Key, out list2))
			{
				list2 = new List<NpcTitleMgr.NPC_ICON_TYPE>();
				this._npcQuestTitleCollection.Add(keyValuePair2.Key, list2);
			}
			foreach (int num2 in keyValuePair2.Value)
			{
				NpcTitleMgr.NPC_ICON_TYPE npc_ICON_TYPE2 = this.method_15(num2, keyValuePair2.Key);
				if (!list2.Contains(npc_ICON_TYPE2))
				{
					list2.Add(npc_ICON_TYPE2);
				}
			}
		}
		foreach (List<NpcTitleMgr.NPC_ICON_TYPE> list3 in this._npcQuestTitleCollection.Values)
		{
			list3.Sort(new Comparison<NpcTitleMgr.NPC_ICON_TYPE>(this.method_14));
		}
	}

	// Token: 0x0600314D RID: 12621 RVA: 0x000E0824 File Offset: 0x000DEA24
	protected int method_14(NpcTitleMgr.NPC_ICON_TYPE npc_ICON_TYPE_0, NpcTitleMgr.NPC_ICON_TYPE npc_ICON_TYPE_1)
	{
		int num = 0;
		int num2 = 0;
		this._titlePriority.TryGetValue(npc_ICON_TYPE_0, out num);
		this._titlePriority.TryGetValue(npc_ICON_TYPE_1, out num2);
		return num - num2;
	}

	// Token: 0x0600314E RID: 12622 RVA: 0x000E0858 File Offset: 0x000DEA58
	protected NpcTitleMgr.NPC_ICON_TYPE method_15(int int_0, int int_1)
	{
		NpcTitleMgr.NPC_ICON_TYPE npc_ICON_TYPE = NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_NONE;
		Quest quest = this.method_2(int_0);
		QuestProgress questProgress = this.method_4(int_0);
		if (quest != null && questProgress != null)
		{
			switch (questProgress.mStatus)
			{
			case QuestState.Available:
				if (quest.mGiverIdList.Contains(int_1))
				{
					if (quest.mCategory == QuestCategory.Daily)
					{
						npc_ICON_TYPE = NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_DAILY_NEW;
					}
					else if (quest.mCategory == QuestCategory.Special)
					{
						npc_ICON_TYPE = NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_SPECIAL_NEW;
					}
					else
					{
						npc_ICON_TYPE = NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_NEW;
					}
				}
				break;
			case QuestState.InProgress:
				if (quest.mReclaimerIdList.Contains(int_1))
				{
					npc_ICON_TYPE = NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_PROGRESS;
				}
				break;
			case QuestState.Completed:
				if (quest.mReclaimerIdList.Contains(int_1))
				{
					if (quest.mCategory == QuestCategory.Daily)
					{
						npc_ICON_TYPE = NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_DAILY_DONE;
					}
					else if (quest.mCategory == QuestCategory.Special)
					{
						npc_ICON_TYPE = NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_SPECIAL_DONE;
					}
					else
					{
						npc_ICON_TYPE = NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_DONE;
					}
				}
				break;
			}
		}
		return npc_ICON_TYPE;
	}

	// Token: 0x0600314F RID: 12623 RVA: 0x000E090C File Offset: 0x000DEB0C
	public NpcTitleMgr.NPC_ICON_TYPE method_16(int int_0)
	{
		NpcTitleMgr.NPC_ICON_TYPE npc_ICON_TYPE = NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_NONE;
		List<NpcTitleMgr.NPC_ICON_TYPE> list = null;
		if (this._npcQuestTitleCollection.TryGetValue(int_0, out list) && list.Count > 0)
		{
			npc_ICON_TYPE = list[0];
		}
		return npc_ICON_TYPE;
	}

	// Token: 0x06003150 RID: 12624 RVA: 0x000E0940 File Offset: 0x000DEB40
	public List<int> method_17(int int_0)
	{
		List<int> list = null;
		this._npcGiverQuests.TryGetValue(int_0, out list);
		return list;
	}

	// Token: 0x06003151 RID: 12625 RVA: 0x000E0960 File Offset: 0x000DEB60
	public List<int> method_18(int int_0)
	{
		List<int> list = null;
		this._npcClaimerQuests.TryGetValue(int_0, out list);
		return list;
	}

	// Token: 0x06003152 RID: 12626 RVA: 0x000E0980 File Offset: 0x000DEB80
	public NpcTitleMgr.NPC_ICON_TYPE method_19(int int_0, int int_1 = -1)
	{
		NpcTitleMgr.NPC_ICON_TYPE npc_ICON_TYPE = NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_NONE;
		if (this._playerQuestProgress != null)
		{
			foreach (QuestProgress questProgress in this._playerQuestProgress.Values)
			{
				if (questProgress.mStatus == QuestState.InProgress)
				{
					Quest quest = ServiceWrapperBase<QuestServiceWrapper>.Instance.method_18(questProgress.mQuestId);
					if (quest != null && quest.mIsBoundInstance && quest.mBoundInstanceList.Contains(int_0) && (quest.mRequiredDifficulty == int_1 || (quest.mRequiredDifficulty == -1 && int_1 == 0)))
					{
						if (quest.mCategory != QuestCategory.Daily)
						{
							npc_ICON_TYPE = NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_DONE;
						}
						else if (npc_ICON_TYPE != NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_DONE)
						{
							npc_ICON_TYPE = NpcTitleMgr.NPC_ICON_TYPE.NPC_ICON_DAILY_DONE;
						}
					}
				}
			}
		}
		return npc_ICON_TYPE;
	}

	// Token: 0x06003153 RID: 12627 RVA: 0x0002011F File Offset: 0x0001E31F
	protected void method_20(string string_0)
	{
		if (NPC_UIFlowController.smethod_0().Boolean_0)
		{
			this._pendingEchoIDQueue.Enqueue(string_0);
		}
		else
		{
			MonoSingleton<global::ns0.EchoMessageManager>.Instance.method_8(string_0);
		}
	}

	// Token: 0x06003154 RID: 12628 RVA: 0x00020146 File Offset: 0x0001E346
	protected void method_21(bool bool_0)
	{
		if (!bool_0)
		{
			while (this._pendingEchoIDQueue.Count > 0)
			{
				MonoSingleton<global::ns0.EchoMessageManager>.Instance.method_8(this._pendingEchoIDQueue.Dequeue());
			}
		}
	}

	// Token: 0x0400220D RID: 8717
	protected List<IQuestUINotificationListerner> _notiListener = new List<IQuestUINotificationListerner>();

	// Token: 0x0400220E RID: 8718
	protected Dictionary<int, List<int>> _npcGiverQuests = new Dictionary<int, List<int>>();

	// Token: 0x0400220F RID: 8719
	protected Dictionary<int, List<int>> _npcClaimerQuests = new Dictionary<int, List<int>>();

	// Token: 0x04002210 RID: 8720
	protected Dictionary<int, QuestProgress> _playerQuestProgress = new Dictionary<int, QuestProgress>();

	// Token: 0x04002211 RID: 8721
	protected Dictionary<int, List<NpcTitleMgr.NPC_ICON_TYPE>> _npcQuestTitleCollection = new Dictionary<int, List<NpcTitleMgr.NPC_ICON_TYPE>>();

	// Token: 0x04002212 RID: 8722
	protected static QuestUIDataManager _mgrRef;

	// Token: 0x04002213 RID: 8723
	protected Queue<string> _pendingEchoIDQueue = new Queue<string>();

	// Token: 0x04002214 RID: 8724
	protected Dictionary<NpcTitleMgr.NPC_ICON_TYPE, int> _titlePriority = new Dictionary<NpcTitleMgr.NPC_ICON_TYPE, int>();
}
