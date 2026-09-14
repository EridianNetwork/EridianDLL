using System;
using System.Collections.Generic;
using System.Text;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x0200074A RID: 1866
public class QuestTrackView : BaseView, IQuestServiceNotificationListerner, IQuestUINotificationListerner
{
	// Token: 0x06003157 RID: 12631 RVA: 0x000201B7 File Offset: 0x0001E3B7
	public override void vmethod_2()
	{
		base.vmethod_2();
		MonoSingleton<AppManager>.Instance.method_0().method_4(this);
		this._refIDCounter = 0;
		this._onTrackingDataDic = new Dictionary<string, QuestTrackView.TrackingSlotData>();
		this._onTrackingDataList = new List<QuestTrackView.TrackingSlotData>();
		QuestUIDataManager.smethod_0().method_0(this);
	}

	// Token: 0x06003158 RID: 12632 RVA: 0x000201F7 File Offset: 0x0001E3F7
	public override void vmethod_3()
	{
		base.vmethod_3();
		MonoSingleton<AppManager>.Instance.method_0().method_5(this);
		this._refIDCounter = 0;
		this._onTrackingDataDic.Clear();
		this._onTrackingDataList.Clear();
		QuestUIDataManager.smethod_0().method_1(this);
	}

	// Token: 0x06003159 RID: 12633 RVA: 0x000E0A3C File Offset: 0x000DEC3C
	protected virtual void vmethod_5(QuestTrackView.TrackingSlotData trackingSlotData_0)
	{
		QuestTrackView.eTrackerAnimation eTrackerAnimation = trackingSlotData_0.TrackerAnimaList[0];
		if (eTrackerAnimation == QuestTrackView.eTrackerAnimation.eRemove)
		{
			if (this._onTrackingDataDic.ContainsKey(trackingSlotData_0.StrID))
			{
				this._onTrackingDataDic.Remove(trackingSlotData_0.StrID);
			}
			if (this._onTrackingDataList.Contains(trackingSlotData_0))
			{
				this._onTrackingDataList.Remove(trackingSlotData_0);
			}
		}
		else
		{
			trackingSlotData_0.TrackerAnimaList.RemoveAt(0);
		}
		this.vmethod_6();
	}

	// Token: 0x0600315A RID: 12634 RVA: 0x000E0AB0 File Offset: 0x000DECB0
	public void OnQuestUpdate(int characterId, int iQuestID, QuestState questState)
	{
		QuestProgress questProgress = QuestUIDataManager.smethod_0().method_4(iQuestID);
		QuestTrackView.TrackingSlotData trackingSlotData = null;
		if (questState == QuestState.Completed)
		{
			trackingSlotData = this.method_3(iQuestID);
			if (!trackingSlotData.TrackerAnimaList.Contains(QuestTrackView.eTrackerAnimation.eQuestComplete) && trackingSlotData.iconState != QuestState.Completed)
			{
				trackingSlotData.TrackerAnimaList.Add(QuestTrackView.eTrackerAnimation.eQuestComplete);
				this.method_4(ref questProgress, ref trackingSlotData);
			}
		}
		this.vmethod_6();
	}

	// Token: 0x0600315B RID: 12635 RVA: 0x000E0B10 File Offset: 0x000DED10
	public void OnQuestAbandoned(int characterId, int questId)
	{
		QuestTrackView.TrackingSlotData trackingSlotData = this.method_3(questId);
		if (trackingSlotData != null)
		{
			trackingSlotData.TrackerAnimaList.Add(QuestTrackView.eTrackerAnimation.eRemove);
		}
		StringBuilder stringBuilder = new StringBuilder(this.PREFIX_QUEST);
		stringBuilder.Append(questId);
		if (this._onTrackingDataDic.ContainsKey(stringBuilder.ToString()))
		{
			this._onTrackingDataDic.Remove(stringBuilder.ToString());
		}
		this.vmethod_6();
	}

	// Token: 0x0600315C RID: 12636 RVA: 0x000E0B74 File Offset: 0x000DED74
	public void OnQuestAccepted(int characterId, int iQuestID)
	{
		Quest quest = QuestUIDataManager.smethod_0().method_2(iQuestID);
		QuestTrackView.TrackingSlotData trackingSlotData = this.method_3(iQuestID);
		QuestProgress questProgress = QuestUIDataManager.smethod_0().method_4(iQuestID);
		if (quest != null && quest.mTasks != null && quest.mTasks[0].mType != QuestTaskType.TalkTo && !trackingSlotData.TrackerAnimaList.Contains(QuestTrackView.eTrackerAnimation.eQuestComplete))
		{
			trackingSlotData.TrackerAnimaList.Add(QuestTrackView.eTrackerAnimation.eNewQuest);
		}
		this.method_4(ref questProgress, ref trackingSlotData);
		this.vmethod_6();
	}

	// Token: 0x0600315D RID: 12637 RVA: 0x000E0B10 File Offset: 0x000DED10
	public void OnQuestRewardClaimed(int characterId, int iQuestID, QuestReward[] rewards)
	{
		QuestTrackView.TrackingSlotData trackingSlotData = this.method_3(iQuestID);
		if (trackingSlotData != null)
		{
			trackingSlotData.TrackerAnimaList.Add(QuestTrackView.eTrackerAnimation.eRemove);
		}
		StringBuilder stringBuilder = new StringBuilder(this.PREFIX_QUEST);
		stringBuilder.Append(iQuestID);
		if (this._onTrackingDataDic.ContainsKey(stringBuilder.ToString()))
		{
			this._onTrackingDataDic.Remove(stringBuilder.ToString());
		}
		this.vmethod_6();
	}

	// Token: 0x0600315E RID: 12638 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnNewTask(int iCharacterID, int iQuestID, int iNewTaskID)
	{
	}

	// Token: 0x0600315F RID: 12639 RVA: 0x000E0BE8 File Offset: 0x000DEDE8
	public void OnTaskProgressUpgrade(int iQuestID, int taskID, int count)
	{
		QuestTrackView.TrackingSlotData trackingSlotData = this.method_3(iQuestID);
		Quest quest = QuestUIDataManager.smethod_0().method_2(iQuestID);
		QuestProgress questProgress = QuestUIDataManager.smethod_0().method_4(iQuestID);
		if (questProgress != null && questProgress.mCurrentTask >= taskID)
		{
			if (trackingSlotData != null && quest != null && quest.mTasks != null && quest.mTasks.Length > taskID)
			{
				if (count >= quest.mTasks[taskID].mTarget)
				{
					if (!trackingSlotData.TrackerAnimaList.Contains(QuestTrackView.eTrackerAnimation.eQuestComplete))
					{
						if (taskID + 1 == quest.mTasks.Length)
						{
							trackingSlotData.TrackerAnimaList.Add(QuestTrackView.eTrackerAnimation.eQuestComplete);
						}
						else
						{
							trackingSlotData.TrackerAnimaList.Add(QuestTrackView.eTrackerAnimation.eTaskComplete);
						}
					}
				}
				else if (!trackingSlotData.TrackerAnimaList.Contains(QuestTrackView.eTrackerAnimation.eQuestComplete))
				{
					trackingSlotData.TrackerAnimaList.Add(QuestTrackView.eTrackerAnimation.eTaskProgressUpdate);
				}
				this.method_4(ref questProgress, ref trackingSlotData);
			}
			this.vmethod_6();
			return;
		}
	}

	// Token: 0x06003160 RID: 12640 RVA: 0x000E0CB8 File Offset: 0x000DEEB8
	public void OnQuestProgress(int characterId, Dictionary<int, QuestProgress> dicQuestProgress)
	{
		if (dicQuestProgress == null)
		{
			return;
		}
		List<QuestProgress> list = this.method_5(dicQuestProgress);
		for (int i = 0; i < list.Count; i++)
		{
			QuestProgress questProgress = list[i];
			QuestTrackView.TrackingSlotData trackingSlotData = this.method_3(questProgress.mQuestId);
			this.method_4(ref questProgress, ref trackingSlotData);
		}
		this.vmethod_6();
	}

	// Token: 0x06003161 RID: 12641 RVA: 0x000E0D08 File Offset: 0x000DEF08
	protected QuestTrackView.TrackingSlotData method_3(int int_0)
	{
		StringBuilder stringBuilder = new StringBuilder(this.PREFIX_QUEST);
		stringBuilder.Append(int_0);
		QuestTrackView.TrackingSlotData trackingSlotData = null;
		if (!this._onTrackingDataDic.TryGetValue(stringBuilder.ToString(), out trackingSlotData))
		{
			trackingSlotData = new QuestTrackView.TrackingSlotData();
			trackingSlotData.iQuestID = int_0;
			trackingSlotData.StrID = stringBuilder.ToString();
			trackingSlotData.TaskCategory = QuestTrackView.eTrackingCategory.eQuest;
			this._onTrackingDataDic.Add(stringBuilder.ToString(), trackingSlotData);
		}
		return trackingSlotData;
	}

	// Token: 0x06003162 RID: 12642 RVA: 0x000E0D74 File Offset: 0x000DEF74
	protected void method_4(ref QuestProgress questProgress_0, ref QuestTrackView.TrackingSlotData trackingSlotData_0)
	{
		if (questProgress_0 == null || trackingSlotData_0 == null)
		{
			return;
		}
		Quest quest = QuestUIDataManager.smethod_0().method_2(questProgress_0.mQuestId);
		if (quest == null)
		{
			return;
		}
		trackingSlotData_0.strTitleText = LocalizedString.smethod_0(new LocalizedString(quest.mTitle));
		QuestState mStatus = questProgress_0.mStatus;
		if (mStatus != QuestState.InProgress)
		{
			if (mStatus == QuestState.Completed)
			{
				trackingSlotData_0.textColor = Color.yellow;
			}
		}
		else
		{
			trackingSlotData_0.textColor = Color.white;
		}
		trackingSlotData_0.iconState = questProgress_0.mStatus;
		trackingSlotData_0.strDesText = QuestUIDataManager.smethod_0().method_3(quest, questProgress_0);
	}

	// Token: 0x06003163 RID: 12643 RVA: 0x000E0E08 File Offset: 0x000DF008
	protected List<QuestProgress> method_5(Dictionary<int, QuestProgress> dictionary_0)
	{
		List<QuestProgress> list = new List<QuestProgress>();
		Dictionary<QuestCategory, List<QuestProgress>> dictionary = new Dictionary<QuestCategory, List<QuestProgress>>();
		List<QuestProgress> list2 = null;
		foreach (QuestProgress questProgress in dictionary_0.Values)
		{
			if (questProgress.mStatus == QuestState.InProgress || questProgress.mStatus == QuestState.Completed || questProgress.mStatus == QuestState.Failed)
			{
				Quest quest = ServiceWrapperBase<QuestServiceWrapper>.Instance.method_18(questProgress.mQuestId);
				if (quest != null)
				{
					if (!dictionary.TryGetValue(quest.mCategory, out list2))
					{
						list2 = new List<QuestProgress>();
						dictionary.Add(quest.mCategory, list2);
					}
					if (MonoSingleton<Session>.Instance.method_16())
					{
						list2.Add(questProgress);
					}
					else if (quest != null)
					{
						bool flag = !quest.mIsBoundInstance || quest.mBoundInstanceList.Contains(MonoSingleton<AppManager>.Instance.m_playlistId);
						bool flag2 = quest.mRequiredDifficulty == -1 || quest.mRequiredDifficulty == (int)MonoSingleton<Session>.Instance.method_2();
						if (flag && flag2)
						{
							list2.Add(questProgress);
						}
					}
				}
			}
		}
		foreach (List<QuestProgress> list3 in dictionary.Values)
		{
			list3.Sort(new Comparison<QuestProgress>(this.method_6));
		}
		QuestCategory[] array = new QuestCategory[]
		{
			QuestCategory.Objective,
			QuestCategory.Story,
			QuestCategory.Sidequest,
			QuestCategory.Daily,
			QuestCategory.Guidance
		};
		foreach (QuestCategory questCategory in array)
		{
			if (dictionary.TryGetValue(questCategory, out list2))
			{
				list.AddRange(list2);
			}
		}
		return list;
	}

	// Token: 0x06003164 RID: 12644 RVA: 0x00020237 File Offset: 0x0001E437
	protected int method_6(QuestProgress questProgress_0, QuestProgress questProgress_1)
	{
		return questProgress_0.mQuestId - questProgress_1.mQuestId;
	}

	// Token: 0x06003165 RID: 12645 RVA: 0x000E0FD0 File Offset: 0x000DF1D0
	public string method_7(string string_0, string string_1)
	{
		UniUIManager uniUIManager = MonoSingleton<AppManager>.Instance.method_0() as UniUIManager;
		if (uniUIManager != null)
		{
			uniUIManager.imethod_0("UI_HUD_New_Objective");
		}
		string text = this.PREFIX_OBJECTIVE + this._refIDCounter;
		this._refIDCounter++;
		while (this._onTrackingDataDic.ContainsKey(text))
		{
			this._refIDCounter++;
			this._refIDCounter %= this.REFERENCEID_UPPERBOUND;
			text = this.PREFIX_OBJECTIVE + this._refIDCounter;
		}
		QuestTrackView.TrackingSlotData trackingSlotData = new QuestTrackView.TrackingSlotData();
		trackingSlotData.TaskCategory = QuestTrackView.eTrackingCategory.eObjective;
		trackingSlotData.StrID = text;
		trackingSlotData.strTitleText = string_0;
		trackingSlotData.strDesText = string_1;
		trackingSlotData.textColor = Color.white;
		trackingSlotData.iconState = QuestState.InProgress;
		trackingSlotData.TrackerAnimaList.Add(QuestTrackView.eTrackerAnimation.eNewQuest);
		this._onTrackingDataDic.Add(text, trackingSlotData);
		this.vmethod_6();
		return text;
	}

	// Token: 0x06003166 RID: 12646 RVA: 0x000E10C4 File Offset: 0x000DF2C4
	public void method_8(string string_0)
	{
		QuestTrackView.TrackingSlotData trackingSlotData = null;
		if (this._onTrackingDataDic.TryGetValue(string_0, out trackingSlotData))
		{
			trackingSlotData.TrackerAnimaList.Add(QuestTrackView.eTrackerAnimation.eRemove);
			trackingSlotData.textColor = Color.yellow;
			trackingSlotData.iconState = QuestState.Completed;
		}
		if (this._onTrackingDataDic.ContainsKey(string_0))
		{
			this._onTrackingDataDic.Remove(string_0);
		}
		this.vmethod_6();
	}

	// Token: 0x06003167 RID: 12647 RVA: 0x000E1124 File Offset: 0x000DF324
	protected virtual void vmethod_6()
	{
		this._onTrackingDataList = new List<QuestTrackView.TrackingSlotData>(this._onTrackingDataDic.Values);
		this._onTrackingDataList.Sort(new Comparison<QuestTrackView.TrackingSlotData>(this.method_9));
		if (this._onTrackingDataList.Count > QuestTrackView.MAX_TRACKING_NUM)
		{
			this._onTrackingDataList.RemoveRange(QuestTrackView.MAX_TRACKING_NUM, this._onTrackingDataList.Count - QuestTrackView.MAX_TRACKING_NUM);
		}
	}

	// Token: 0x06003168 RID: 12648 RVA: 0x000E1194 File Offset: 0x000DF394
	protected int method_9(QuestTrackView.TrackingSlotData trackingSlotData_0, QuestTrackView.TrackingSlotData trackingSlotData_1)
	{
		int num = 0;
		if (trackingSlotData_0.TaskCategory != trackingSlotData_1.TaskCategory)
		{
			num = trackingSlotData_0.TaskCategory - trackingSlotData_1.TaskCategory;
		}
		else
		{
			QuestTrackView.eTrackingCategory taskCategory = trackingSlotData_0.TaskCategory;
			if (taskCategory == QuestTrackView.eTrackingCategory.eQuest)
			{
				num = trackingSlotData_0.iQuestID - trackingSlotData_1.iQuestID;
			}
		}
		return num;
	}

	// Token: 0x04002215 RID: 8725
	protected Dictionary<string, QuestTrackView.TrackingSlotData> _onTrackingDataDic = new Dictionary<string, QuestTrackView.TrackingSlotData>();

	// Token: 0x04002216 RID: 8726
	protected List<QuestTrackView.TrackingSlotData> _onTrackingDataList = new List<QuestTrackView.TrackingSlotData>();

	// Token: 0x04002217 RID: 8727
	protected int _refIDCounter;

	// Token: 0x04002218 RID: 8728
	protected readonly int REFERENCEID_UPPERBOUND = 9999;

	// Token: 0x04002219 RID: 8729
	protected readonly string PREFIX_OBJECTIVE = "Objective_";

	// Token: 0x0400221A RID: 8730
	protected readonly string PREFIX_QUEST = "Quest_";

	// Token: 0x0400221B RID: 8731
	protected static int MAX_TRACKING_NUM = 6;

	// Token: 0x0400221C RID: 8732
	protected bool _bOnAnima;

	// Token: 0x0200074B RID: 1867
	public enum eTrackingCategory
	{
		// Token: 0x0400221E RID: 8734
		eNone,
		// Token: 0x0400221F RID: 8735
		eObjective,
		// Token: 0x04002220 RID: 8736
		eQuest
	}

	// Token: 0x0200074C RID: 1868
	public enum eTrackerAnimation
	{
		// Token: 0x04002222 RID: 8738
		eNone,
		// Token: 0x04002223 RID: 8739
		eNewQuest,
		// Token: 0x04002224 RID: 8740
		eTaskProgressUpdate,
		// Token: 0x04002225 RID: 8741
		eTaskComplete,
		// Token: 0x04002226 RID: 8742
		eQuestComplete,
		// Token: 0x04002227 RID: 8743
		eTaskFail,
		// Token: 0x04002228 RID: 8744
		eQuestFail,
		// Token: 0x04002229 RID: 8745
		eRemove
	}

	// Token: 0x0200074D RID: 1869
	public class TrackingSlotData
	{
		// Token: 0x0600316A RID: 12650 RVA: 0x000E1234 File Offset: 0x000DF434
		public void method_0()
		{
			this.TaskCategory = QuestTrackView.eTrackingCategory.eNone;
			this.TrackerAnimaList.Clear();
			this.StrID = string.Empty;
			this.strTitleText = string.Empty;
			this.strDesText = string.Empty;
			this.iQuestID = 0;
			this.bOnAnimation = false;
			this.textColor = Color.white;
			this.iconState = QuestState.InProgress;
		}

		// Token: 0x0400222A RID: 8746
		public string StrID = string.Empty;

		// Token: 0x0400222B RID: 8747
		public int iQuestID;

		// Token: 0x0400222C RID: 8748
		public QuestTrackView.eTrackingCategory TaskCategory;

		// Token: 0x0400222D RID: 8749
		public List<QuestTrackView.eTrackerAnimation> TrackerAnimaList = new List<QuestTrackView.eTrackerAnimation>();

		// Token: 0x0400222E RID: 8750
		public string strTitleText = string.Empty;

		// Token: 0x0400222F RID: 8751
		public string strDesText = string.Empty;

		// Token: 0x04002230 RID: 8752
		public bool bOnAnimation;

		// Token: 0x04002231 RID: 8753
		public Color textColor = Color.white;

		// Token: 0x04002232 RID: 8754
		public QuestState iconState = QuestState.InProgress;
	}
}
