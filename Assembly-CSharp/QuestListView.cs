using System;
using System.Collections.Generic;
using ns0;
using XsdSettings;

// Token: 0x020006B9 RID: 1721
public class QuestListView : BaseView, IQuestServiceNotificationListerner, IQuestUINotificationListerner
{
	// Token: 0x06002D4E RID: 11598 RVA: 0x000039EC File Offset: 0x00001BEC
	public override bool vmethod_0()
	{
		return true;
	}

	// Token: 0x06002D4F RID: 11599 RVA: 0x000D47D4 File Offset: 0x000D29D4
	public override void vmethod_2()
	{
		base.vmethod_2();
		this._questInfoByInstanceID = new Dictionary<int, List<QuestListView.QuestListSlotData>>();
		MonoSingleton<AppManager>.Instance.method_0().method_6(this);
		MonoSingleton<AppManager>.Instance.method_0().method_8(this);
		MonoSingleton<AppManager>.Instance.method_0().method_16(this, "UIQuest");
		QuestUIDataManager.smethod_0().method_0(this);
		this.OnQuestProgress(0, QuestUIDataManager.smethod_0().method_7());
	}

	// Token: 0x06002D50 RID: 11600 RVA: 0x000D4844 File Offset: 0x000D2A44
	public override void vmethod_3()
	{
		base.vmethod_3();
		this._questInfoByInstanceID.Clear();
		MonoSingleton<AppManager>.Instance.method_0().method_17(this, string.Empty);
		MonoSingleton<AppManager>.Instance.method_0().method_7(this);
		MonoSingleton<AppManager>.Instance.method_0().method_9(this);
		QuestUIDataManager.smethod_0().method_1(this);
	}

	// Token: 0x06002D51 RID: 11601 RVA: 0x0001E0F3 File Offset: 0x0001C2F3
	public override bool vmethod_4()
	{
		if (this.Boolean_1)
		{
			this.Boolean_1 = false;
			return true;
		}
		return base.vmethod_4();
	}

	// Token: 0x06002D52 RID: 11602 RVA: 0x0001E10C File Offset: 0x0001C30C
	protected virtual void vmethod_5()
	{
		if (this.currentFocusSlot != null && this.currentFocusSlot.questProgress.mStatus == QuestState.InProgress)
		{
			QuestUIDataManager.smethod_0().method_8(this.currentFocusSlot.quest.mId);
		}
	}

	// Token: 0x06002D53 RID: 11603 RVA: 0x0001E143 File Offset: 0x0001C343
	public void OnQuestAbandoned(int accountId, int questId)
	{
		this.OnQuestProgress(0, QuestUIDataManager.smethod_0().method_7());
	}

	// Token: 0x06002D54 RID: 11604 RVA: 0x0001E143 File Offset: 0x0001C343
	public void OnQuestUpdate(int characterId, int questId, QuestState questState)
	{
		this.OnQuestProgress(0, QuestUIDataManager.smethod_0().method_7());
	}

	// Token: 0x06002D55 RID: 11605 RVA: 0x0001E143 File Offset: 0x0001C343
	public void OnQuestAccepted(int characterId, int questId)
	{
		this.OnQuestProgress(0, QuestUIDataManager.smethod_0().method_7());
	}

	// Token: 0x06002D56 RID: 11606 RVA: 0x0001E143 File Offset: 0x0001C343
	public void OnQuestRewardClaimed(int characterId, int questId, QuestReward[] rewards)
	{
		this.OnQuestProgress(0, QuestUIDataManager.smethod_0().method_7());
	}

	// Token: 0x06002D57 RID: 11607 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnNewTask(int iCharacterID, int iQuestID, int iNewTaskID)
	{
	}

	// Token: 0x06002D58 RID: 11608 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnTaskProgressUpgrade(int questID, int taskID, int count)
	{
	}

	// Token: 0x06002D59 RID: 11609 RVA: 0x000D48A4 File Offset: 0x000D2AA4
	public void OnQuestProgress(int characterId, Dictionary<int, QuestProgress> playerQuestProgress)
	{
		this._questInfoByInstanceID.Clear();
		foreach (QuestProgress questProgress in playerQuestProgress.Values)
		{
			if (questProgress.mStatus != QuestState.Unavailable)
			{
				if (questProgress.mStatus != QuestState.Available)
				{
					Quest quest = QuestUIDataManager.smethod_0().method_2(questProgress.mQuestId);
					if (quest != null)
					{
						List<QuestListView.QuestListSlotData> list = null;
						int num = -1;
						if (questProgress.mStatus == QuestState.RewardClaimed)
						{
							num = -1;
						}
						else if (quest.mBoundInstanceList != null && quest.mBoundInstanceList.Length > 0)
						{
							num = quest.mBoundInstanceList[0];
						}
						if (!this._questInfoByInstanceID.TryGetValue(num, out list))
						{
							list = new List<QuestListView.QuestListSlotData>();
							this._questInfoByInstanceID.Add(num, list);
						}
						list.Add(new QuestListView.QuestListSlotData(quest, questProgress));
					}
				}
			}
		}
		this.vmethod_6();
	}

	// Token: 0x06002D5A RID: 11610 RVA: 0x000D4994 File Offset: 0x000D2B94
	protected virtual void vmethod_6()
	{
		foreach (List<QuestListView.QuestListSlotData> list in this._questInfoByInstanceID.Values)
		{
			list.Sort(new Comparison<QuestListView.QuestListSlotData>(this.method_3));
		}
	}

	// Token: 0x06002D5B RID: 11611 RVA: 0x000D49F8 File Offset: 0x000D2BF8
	private int method_3(QuestListView.QuestListSlotData questListSlotData_0, QuestListView.QuestListSlotData questListSlotData_1)
	{
		int num = 0;
		if (questListSlotData_0.quest != null && questListSlotData_1.quest != null)
		{
			num = questListSlotData_0.quest.mId - questListSlotData_1.quest.mId;
		}
		return num;
	}

	// Token: 0x04001FD5 RID: 8149
	protected Dictionary<int, List<QuestListView.QuestListSlotData>> _questInfoByInstanceID = new Dictionary<int, List<QuestListView.QuestListSlotData>>();

	// Token: 0x04001FD6 RID: 8150
	protected QuestListView.QuestListSlotData currentFocusSlot;

	// Token: 0x020006BA RID: 1722
	public class QuestListSlotData
	{
		// Token: 0x06002D5C RID: 11612 RVA: 0x0001E156 File Offset: 0x0001C356
		public QuestListSlotData(Quest quest_0, QuestProgress questProgress_0)
		{
			this.quest = quest_0;
			this.questProgress = questProgress_0;
		}

		// Token: 0x04001FD7 RID: 8151
		public Quest quest;

		// Token: 0x04001FD8 RID: 8152
		public QuestProgress questProgress;
	}
}
