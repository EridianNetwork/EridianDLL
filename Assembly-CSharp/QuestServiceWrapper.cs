using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Core;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x02000342 RID: 834
public class QuestServiceWrapper : ServiceWrapper<IQuestServiceWrapper, QuestServiceWrapper>
{
	// Token: 0x0600150B RID: 5387 RVA: 0x0000F770 File Offset: 0x0000D970
	public void method_0(IQuestServiceNotificationListerner iquestServiceNotificationListerner_0)
	{
		this.m_listerner.Add(iquestServiceNotificationListerner_0);
	}

	// Token: 0x0600150C RID: 5388 RVA: 0x0000F77E File Offset: 0x0000D97E
	public void method_1(IQuestServiceNotificationListerner iquestServiceNotificationListerner_0)
	{
		this.m_listerner.Remove(iquestServiceNotificationListerner_0);
	}

	// Token: 0x0600150D RID: 5389 RVA: 0x00078BC0 File Offset: 0x00076DC0
	public void OnQuestUpdate(int characterId, int questId, QuestState questState)
	{
		if (this.m_playerQuestsProgess == null)
		{
			return;
		}
		if (questState == QuestState.Available)
		{
			QuestProgress questProgress = new QuestProgress();
			questProgress.mCurrentTask = 0;
			questProgress.mQuestId = questId;
			questProgress.mStatus = questState;
			questProgress.mTaskProgress = 0;
			if (!this.m_playerQuestsProgess.ContainsKey(questId))
			{
				this.m_playerQuestsProgess.Add(questId, questProgress);
				this.OnQuestProgress(OnlineService.s_characterId, this.m_playerQuestsProgess);
			}
			Quest quest = this.method_18(questId);
			if (quest != null && quest.mCategory == QuestCategory.Guidance && MonoSingleton<Session>.Instance != null && MonoSingleton<Session>.Instance.method_16())
			{
				this.method_5(questId);
			}
		}
		else
		{
			QuestProgress questProgress2 = null;
			if (this.m_playerQuestsProgess.TryGetValue(questId, out questProgress2) && questProgress2 != null)
			{
				questProgress2.mStatus = questState;
			}
		}
		for (int i = 0; i < this.m_listerner.Count; i++)
		{
			this.m_listerner[i].OnQuestUpdate(characterId, questId, questState);
		}
	}

	// Token: 0x0600150E RID: 5390 RVA: 0x00078CA8 File Offset: 0x00076EA8
	public void OnQuestAbandoned(short reason, int questId)
	{
		if (reason == 0)
		{
			QuestProgress questProgress = this.method_8(questId);
			questProgress.mStatus = QuestState.Available;
		}
		for (int i = 0; i < this.m_listerner.Count; i++)
		{
			this.m_listerner[i].OnQuestAbandoned(OnlineService.s_characterId, questId);
		}
	}

	// Token: 0x0600150F RID: 5391 RVA: 0x00078CF4 File Offset: 0x00076EF4
	public void OnQuestAccepted(int characterId, int questId)
	{
		for (int i = 0; i < this.m_listerner.Count; i++)
		{
			this.m_listerner[i].OnQuestAccepted(characterId, questId);
		}
	}

	// Token: 0x06001510 RID: 5392 RVA: 0x00078D2C File Offset: 0x00076F2C
	public void OnNewTask(int iCharacterID, int iQuestID, int iNewTaskID)
	{
		for (int i = 0; i < this.m_listerner.Count; i++)
		{
			this.m_listerner[i].OnNewTask(iCharacterID, iQuestID, iNewTaskID);
		}
	}

	// Token: 0x06001511 RID: 5393 RVA: 0x00078D64 File Offset: 0x00076F64
	public void OnQuestRewardClaimed(int characterId, int questId, QuestReward[] rewards)
	{
		for (int i = 0; i < this.m_listerner.Count; i++)
		{
			this.m_listerner[i].OnQuestRewardClaimed(characterId, questId, rewards);
		}
	}

	// Token: 0x06001512 RID: 5394 RVA: 0x00078D9C File Offset: 0x00076F9C
	public void OnTaskProgressUpgrade(int questId, int taskId, int count)
	{
		for (int i = 0; i < this.m_listerner.Count; i++)
		{
			this.m_listerner[i].OnTaskProgressUpgrade(questId, taskId, count);
		}
	}

	// Token: 0x06001513 RID: 5395 RVA: 0x00078DD4 File Offset: 0x00076FD4
	public void OnQuestProgress(int characterId, Dictionary<int, QuestProgress> quests)
	{
		this.m_playerQuestsProgess = quests;
		int num = 0;
		foreach (KeyValuePair<int, DailyQuestInfo> keyValuePair in this.m_dailyQuestInfos)
		{
			QuestProgress questProgress = null;
			if (this.m_playerQuestsProgess.TryGetValue(keyValuePair.Key, out questProgress) && (questProgress.mStatus == QuestState.Completed || questProgress.mStatus == QuestState.InProgress || questProgress.mStatus == QuestState.RewardClaimed))
			{
				num++;
			}
		}
		if (num < 5)
		{
			foreach (KeyValuePair<int, DailyQuestInfo> keyValuePair2 in this.m_dailyQuestInfos)
			{
				QuestProgress questProgress2 = null;
				if (!this.m_playerQuestsProgess.TryGetValue(keyValuePair2.Key, out questProgress2))
				{
					questProgress2 = new QuestProgress();
					questProgress2.mQuestId = keyValuePair2.Key;
					questProgress2.mStatus = QuestState.Available;
					this.m_playerQuestsProgess.Add(keyValuePair2.Key, questProgress2);
				}
				else if (questProgress2.mStatus == QuestState.Unavailable)
				{
					questProgress2.mStatus = QuestState.Available;
				}
			}
		}
		List<int> list = new List<int>(this.m_playerQuestsProgess.Keys);
		foreach (int num2 in list)
		{
			Quest quest = null;
			if (this.m_playerQuestsInfo.TryGetValue(num2, out quest))
			{
				QuestProgress questProgress3 = this.m_playerQuestsProgess[num2];
				if (num >= 5 && quest.mCategory == QuestCategory.Daily && questProgress3.mStatus == QuestState.Available)
				{
					this.m_playerQuestsProgess.Remove(num2);
				}
				else
				{
					int num3 = ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_8();
					if (((int)quest.mRequiredLevel > num3 || ((int)quest.mHighestLevel > 0 && num3 > (int)quest.mHighestLevel)) && questProgress3.mStatus == QuestState.Available)
					{
						this.m_playerQuestsProgess[num2].mStatus = QuestState.Unavailable;
					}
				}
			}
		}
		for (int i = 0; i < this.m_listerner.Count; i++)
		{
			this.m_listerner[i].OnQuestProgress(characterId, this.m_playerQuestsProgess);
		}
	}

	// Token: 0x06001514 RID: 5396 RVA: 0x00079020 File Offset: 0x00077220
	protected override IQuestServiceWrapper vmethod_0()
	{
		if (MonoSingleton<Session>.Instance != null && !MonoSingleton<Session>.Instance.method_16() && MonoSingleton<Session>.Instance.GetLocalPlayer() && MonoSingleton<Session>.Instance.GetLocalPlayer().GetEntity())
		{
			return this.m_wrapperSession;
		}
		return this.m_wrapperOnline;
	}

	// Token: 0x06001515 RID: 5397 RVA: 0x0000F78D File Offset: 0x0000D98D
	public override void Reset()
	{
		this.m_bInited = false;
	}

	// Token: 0x06001516 RID: 5398 RVA: 0x0007907C File Offset: 0x0007727C
	public override void vmethod_1()
	{
		if (!this.m_bInited)
		{
			this.m_wrapperOnline = new QuestServiceWrapperOnline();
			this.m_wrapperSession = new QuestServiceWrapperSession();
			this.m_playerQuestsInfo = new Dictionary<int, Quest>();
			this.m_playerDailyQuests = new Dictionary<int, Quest>();
			this.method_3("Settings/Quests", ref this.m_playerQuestsInfo);
			this.method_3("Settings/DailyQuests", ref this.m_playerDailyQuests);
			this.method_3("Settings/GuidanceQuests", ref this.m_playerQuestsInfo);
			base.vmethod_1();
			this.m_bInited = true;
		}
	}

	// Token: 0x06001517 RID: 5399 RVA: 0x00079100 File Offset: 0x00077300
	public void method_2()
	{
		foreach (QuestProgress questProgress in this.m_playerQuestsProgess.Values)
		{
			if (questProgress.mStatus == QuestState.Available)
			{
				Quest quest = this.method_18(questProgress.mQuestId);
				if (quest != null && quest.mCategory == QuestCategory.Guidance)
				{
					this.method_5(quest.mId);
				}
			}
		}
	}

	// Token: 0x06001518 RID: 5400 RVA: 0x00079180 File Offset: 0x00077380
	protected void method_3(string string_0, ref Dictionary<int, Quest> dictionary_0)
	{
		TextAsset textAsset = (TextAsset)ResourcesLoader.smethod_0(string_0);
		QuestSetup questSetup = null;
		using (StringReader stringReader = new StringReader(textAsset.text))
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(QuestSetup));
			questSetup = xmlSerializer.Deserialize(stringReader) as QuestSetup;
		}
		if (questSetup != null && questSetup.mQuests != null)
		{
			foreach (Quest quest in questSetup.mQuests)
			{
				if (!dictionary_0.ContainsKey(quest.mId))
				{
					dictionary_0.Add(quest.mId, quest);
				}
				else
				{
					DebugUtils.LogError(LogCategory.Gamelogic, "Get duplicate quest ID of " + quest.mId);
				}
			}
		}
		Resources.UnloadAsset(textAsset);
	}

	// Token: 0x06001519 RID: 5401 RVA: 0x0000F796 File Offset: 0x0000D996
	public void method_4(int int_0, byte[] byte_0)
	{
		this.vmethod_0().imethod_2(int_0, byte_0);
	}

	// Token: 0x0600151A RID: 5402 RVA: 0x0000F7A5 File Offset: 0x0000D9A5
	public void method_5(int int_0)
	{
		this.vmethod_0().imethod_3(int_0);
	}

	// Token: 0x0600151B RID: 5403 RVA: 0x0000F7B3 File Offset: 0x0000D9B3
	public void method_6()
	{
		this.vmethod_0().imethod_5();
	}

	// Token: 0x0600151C RID: 5404 RVA: 0x0000F7C0 File Offset: 0x0000D9C0
	public Dictionary<int, QuestProgress> method_7(bool bool_1 = true)
	{
		if (bool_1)
		{
			this.OnQuestProgress(OnlineService.s_characterId, this.m_playerQuestsProgess);
		}
		return this.m_playerQuestsProgess;
	}

	// Token: 0x0600151D RID: 5405 RVA: 0x00079254 File Offset: 0x00077454
	public QuestProgress method_8(int int_0)
	{
		QuestProgress questProgress = null;
		if (this.m_playerQuestsProgess.TryGetValue(int_0, out questProgress))
		{
			return questProgress;
		}
		return null;
	}

	// Token: 0x0600151E RID: 5406 RVA: 0x00079278 File Offset: 0x00077478
	public void OnGetPlayerDailyQuestsContent(Dictionary<int, DailyQuestInfo> dailyQuestInfos)
	{
		this.m_dailyQuestInfos = dailyQuestInfos;
		foreach (KeyValuePair<int, DailyQuestInfo> keyValuePair in this.m_dailyQuestInfos)
		{
			Quest quest = null;
			if (this.m_playerDailyQuests.TryGetValue(keyValuePair.Value.mQuestId, out quest))
			{
				if (!this.m_playerQuestsInfo.ContainsKey(keyValuePair.Key))
				{
					quest.mId = keyValuePair.Key;
					this.m_playerQuestsInfo.Add(keyValuePair.Key, quest);
				}
			}
			else
			{
				DebugUtils.LogWarning(LogCategory.Gamelogic, string.Concat(new object[]
				{
					"Can not find daily quest ! Server Daily Quest ID : ",
					keyValuePair.Key,
					" quest ID ",
					keyValuePair.Value.mQuestId
				}));
			}
		}
		this.OnQuestProgress(OnlineService.s_characterId, this.m_playerQuestsProgess);
	}

	// Token: 0x0600151F RID: 5407 RVA: 0x00079378 File Offset: 0x00077578
	public void OnClearPlayerDailyQuest()
	{
		foreach (int num in this.m_dailyQuestInfos.Keys)
		{
			if (this.m_playerQuestsProgess.ContainsKey(num))
			{
				this.m_playerQuestsProgess.Remove(num);
			}
		}
		this.m_dailyQuestInfos.Clear();
		this.OnQuestProgress(OnlineService.s_characterId, this.m_playerQuestsProgess);
		this.method_6();
	}

	// Token: 0x06001520 RID: 5408 RVA: 0x0000311B File Offset: 0x0000131B
	public void method_9(int int_0, int int_1)
	{
	}

	// Token: 0x06001521 RID: 5409 RVA: 0x0000F7DC File Offset: 0x0000D9DC
	public void method_10(int int_0, int int_1)
	{
		this.vmethod_0().imethod_6(int_0, int_1);
	}

	// Token: 0x06001522 RID: 5410 RVA: 0x00079408 File Offset: 0x00077608
	public void method_11(int int_0)
	{
		foreach (QuestProgress questProgress in this.m_playerQuestsProgess.Values)
		{
			if (questProgress.mStatus == QuestState.InProgress)
			{
				Quest quest = this.method_18(questProgress.mQuestId);
				if (quest != null)
				{
					QuestTask questTask = quest.mTasks[questProgress.mCurrentTask];
					if (questTask != null)
					{
						if (questTask.mType == QuestTaskType.TalkTo)
						{
							if (questTask.mTarget == int_0)
							{
								this.vmethod_0().imethod_7(new TalkToNPCCallback(this.OnTalkToNPC), questProgress.mQuestId, questTask.mTaskId);
								break;
							}
						}
					}
				}
			}
		}
	}

	// Token: 0x06001523 RID: 5411 RVA: 0x0000F7EB File Offset: 0x0000D9EB
	private void OnTalkToNPC(bool success, Dictionary<int, QuestProgress> questProgress)
	{
		if (success)
		{
			this.OnQuestProgress(OnlineService.s_characterId, questProgress);
		}
	}

	// Token: 0x06001524 RID: 5412 RVA: 0x000794C0 File Offset: 0x000776C0
	public void method_12(int int_0)
	{
		foreach (QuestProgress questProgress in this.m_playerQuestsProgess.Values)
		{
			if (questProgress.mStatus == QuestState.InProgress)
			{
				Quest quest = this.method_18(questProgress.mQuestId);
				if (quest != null)
				{
					QuestTask questTask = quest.mTasks[questProgress.mCurrentTask];
					if (questTask != null)
					{
						if (questTask.mType == QuestTaskType.BringTo)
						{
							if (questTask.mTarget == int_0 && ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_33(questTask.mMaterialType) >= questTask.mMaterialCount)
							{
								this.vmethod_0().imethod_8(new BringToNPCCallback(this.OnBringToNPC), questProgress.mQuestId, questTask.mTaskId);
								break;
							}
						}
					}
				}
			}
		}
	}

	// Token: 0x06001525 RID: 5413 RVA: 0x0000F7EB File Offset: 0x0000D9EB
	private void OnBringToNPC(bool success, Dictionary<int, QuestProgress> questProgress)
	{
		if (success)
		{
			this.OnQuestProgress(OnlineService.s_characterId, questProgress);
		}
	}

	// Token: 0x06001526 RID: 5414 RVA: 0x0000F7FC File Offset: 0x0000D9FC
	public void method_13()
	{
		this.method_16(QuestTaskType.UseSkill);
	}

	// Token: 0x06001527 RID: 5415 RVA: 0x0000F806 File Offset: 0x0000DA06
	public void method_14()
	{
		this.method_16(QuestTaskType.SkillPoint);
	}

	// Token: 0x06001528 RID: 5416 RVA: 0x0000F810 File Offset: 0x0000DA10
	public void method_15()
	{
		this.method_16(QuestTaskType.ShowItem);
	}

	// Token: 0x06001529 RID: 5417 RVA: 0x00079590 File Offset: 0x00077790
	protected void method_16(QuestTaskType questTaskType_0)
	{
		foreach (QuestProgress questProgress in this.m_playerQuestsProgess.Values)
		{
			if (questProgress.mStatus == QuestState.InProgress)
			{
				Quest quest = this.method_18(questProgress.mQuestId);
				if (quest != null)
				{
					QuestTask questTask = quest.mTasks[questProgress.mCurrentTask];
					if (questTask != null)
					{
						if (questTask.mType == questTaskType_0)
						{
							this.vmethod_0().imethod_9(OnlineService.s_characterId, questProgress.mQuestId);
						}
					}
				}
			}
		}
	}

	// Token: 0x0600152A RID: 5418 RVA: 0x0000F81A File Offset: 0x0000DA1A
	public Dictionary<int, Quest> method_17()
	{
		return this.m_playerQuestsInfo;
	}

	// Token: 0x0600152B RID: 5419 RVA: 0x00079630 File Offset: 0x00077830
	public Quest method_18(int int_0)
	{
		Quest quest = null;
		this.m_playerQuestsInfo.TryGetValue(int_0, out quest);
		return quest;
	}

	// Token: 0x0600152C RID: 5420 RVA: 0x00079650 File Offset: 0x00077850
	public Quest method_19(int int_0)
	{
		Quest quest = null;
		foreach (Quest quest2 in this.m_playerQuestsInfo.Values)
		{
			if (quest2.mCategory == QuestCategory.Objective && quest2.mBoundInstanceList.Contains(int_0))
			{
				quest = quest2;
				break;
			}
		}
		return quest;
	}

	// Token: 0x0600152D RID: 5421 RVA: 0x000796C0 File Offset: 0x000778C0
	public List<Quest> method_20()
	{
		List<Quest> list = new List<Quest>();
		foreach (Quest quest in this.m_playerQuestsInfo.Values)
		{
			QuestProgress questProgress = this.method_8(quest.mId);
			if (questProgress != null && questProgress.mStatus == QuestState.InProgress)
			{
				foreach (int num in quest.mBoundInstanceList)
				{
					Playlist playlist = MatchmakingService.MatchmakingService_0.method_1(num);
					if (playlist != null && MatchmakingService.smethod_1(MatchmakingService.smethod_0(playlist.m_gameMode)))
					{
						list.Add(quest);
					}
				}
			}
		}
		return list;
	}

	// Token: 0x0600152E RID: 5422 RVA: 0x00079780 File Offset: 0x00077980
	public bool method_21()
	{
		bool flag = false;
		foreach (Quest quest in this.m_playerQuestsInfo.Values)
		{
			QuestProgress questProgress = this.method_8(quest.mId);
			if (questProgress != null && questProgress.mStatus == QuestState.InProgress)
			{
				foreach (int num in quest.mBoundInstanceList)
				{
					Playlist playlist = MatchmakingService.MatchmakingService_0.method_1(num);
					if (playlist != null && MatchmakingService.smethod_1(MatchmakingService.smethod_0(playlist.m_gameMode)))
					{
						flag = true;
						break;
					}
				}
			}
		}
		return flag;
	}

	// Token: 0x0600152F RID: 5423 RVA: 0x00079838 File Offset: 0x00077A38
	public List<Quest> method_22(int int_0)
	{
		List<Quest> list = new List<Quest>();
		foreach (Quest quest in this.m_playerQuestsInfo.Values)
		{
			if (quest.mIsBoundInstance && quest.mCategory != QuestCategory.Objective && quest.mBoundInstanceList.Contains(int_0))
			{
				QuestProgress questProgress = this.method_8(quest.mId);
				if (questProgress != null && questProgress.mStatus == QuestState.InProgress)
				{
					list.Add(quest);
				}
			}
		}
		return list;
	}

	// Token: 0x06001530 RID: 5424 RVA: 0x000798D0 File Offset: 0x00077AD0
	public void method_23()
	{
		List<int> list = new List<int>();
		foreach (QuestProgress questProgress in this.m_playerQuestsProgess.Values)
		{
			Quest quest = this.method_18(questProgress.mQuestId);
			if (quest != null && quest.mCategory == QuestCategory.Objective)
			{
				list.Add(quest.mId);
			}
		}
		foreach (int num in list)
		{
			this.m_playerQuestsProgess.Remove(num);
		}
	}

	// Token: 0x06001531 RID: 5425 RVA: 0x0000F822 File Offset: 0x0000DA22
	public Dictionary<int, QuestProgress> RefreshPlayerQuests()
	{
		return this.vmethod_0().imethod_4();
	}

	// Token: 0x04000E81 RID: 3713
	protected bool m_bInited;

	// Token: 0x04000E82 RID: 3714
	protected Dictionary<int, QuestProgress> m_playerQuestsProgess = new Dictionary<int, QuestProgress>();

	// Token: 0x04000E83 RID: 3715
	protected Dictionary<int, Quest> m_playerQuestsInfo = new Dictionary<int, Quest>();

	// Token: 0x04000E84 RID: 3716
	protected Dictionary<int, Quest> m_playerDailyQuests = new Dictionary<int, Quest>();

	// Token: 0x04000E85 RID: 3717
	protected Dictionary<int, DailyQuestInfo> m_dailyQuestInfos = new Dictionary<int, DailyQuestInfo>();

	// Token: 0x04000E86 RID: 3718
	private List<IQuestServiceNotificationListerner> m_listerner = new List<IQuestServiceNotificationListerner>();
}
