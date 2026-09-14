using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x020006D2 RID: 1746
public class LevelLockingManager : IQuestServiceNotificationListerner
{
	// Token: 0x06002E11 RID: 11793 RVA: 0x000D6BE0 File Offset: 0x000D4DE0
	private LevelLockingManager()
	{
		OnAccessSingleton<IProgressionService, ProgressionService, ProgressionServiceOffline>.Prop_0.imethod_3(new InstanceUnlockedCallback(this.method_6));
	}

	// Token: 0x06002E12 RID: 11794 RVA: 0x0001E7BB File Offset: 0x0001C9BB
	public void method_0()
	{
		this.m_unlockAll = true;
	}

	// Token: 0x06002E13 RID: 11795 RVA: 0x0001E7C4 File Offset: 0x0001C9C4
	public static LevelLockingManager smethod_0()
	{
		if (LevelLockingManager.mInstance == null)
		{
			LevelLockingManager.mInstance = new LevelLockingManager();
		}
		return LevelLockingManager.mInstance;
	}

	// Token: 0x06002E14 RID: 11796 RVA: 0x0001E7DC File Offset: 0x0001C9DC
	public bool method_1()
	{
		return this.m_bFirstEnterFlag;
	}

	// Token: 0x06002E15 RID: 11797 RVA: 0x0001E7E4 File Offset: 0x0001C9E4
	public bool method_2(int int_0)
	{
		return this.m_unlockAll || (!MonoSingleton<AppManager>.Instance.m_offlineMode && this.mUnlockedLevels.ContainsKey(int_0));
	}

	// Token: 0x06002E16 RID: 11798 RVA: 0x000D6C3C File Offset: 0x000D4E3C
	public bool method_3()
	{
		this.method_9(false);
		GameObject gameObject = GameObject.Find("LD");
		LobbyBehaviour[] componentsInChildren = gameObject.GetComponentsInChildren<LobbyBehaviour>(true);
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].method_0();
		}
		return this.m_bWithNewlyUnlockedInstance;
	}

	// Token: 0x06002E17 RID: 11799 RVA: 0x000D6C80 File Offset: 0x000D4E80
	public void method_4()
	{
		GameObject gameObject = GameObject.Find("LD");
		LobbyBehaviour[] componentsInChildren = gameObject.GetComponentsInChildren<LobbyBehaviour>(true);
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].method_1();
		}
	}

	// Token: 0x06002E18 RID: 11800 RVA: 0x0001E80A File Offset: 0x0001CA0A
	public void method_5()
	{
		ServiceWrapperBase<QuestServiceWrapper>.Instance.method_0(this);
	}

	// Token: 0x06002E19 RID: 11801 RVA: 0x000D6CB8 File Offset: 0x000D4EB8
	protected void method_6(int int_0)
	{
		MonoSingleton<GuidanceTipsManager>.Instance.OnUnlockNewInstance();
		if (GroupManager.smethod_0().method_18() && !this.mGroupUnlockedLevels.ContainsKey(int_0))
		{
			this.mGroupUnlockedLevels.Add(int_0, 0);
		}
		if (!this.mUnlockedLevels.ContainsKey(int_0))
		{
			this.mUnlockedLevels.Add(int_0, 0);
			this.m_bWithNewlyUnlockedInstance = true;
		}
		if (!this.mAccessableLevels.ContainsKey(int_0))
		{
			this.mAccessableLevels.Add(int_0, 0);
		}
	}

	// Token: 0x06002E1A RID: 11802 RVA: 0x0001E817 File Offset: 0x0001CA17
	protected void method_7(Dictionary<int, int> dictionary_0)
	{
		this.method_9(false);
	}

	// Token: 0x06002E1B RID: 11803 RVA: 0x0001E817 File Offset: 0x0001CA17
	public void OnQuestUpdate(int accountId, int questId, QuestState questState)
	{
		this.method_9(false);
	}

	// Token: 0x06002E1C RID: 11804 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnQuestAccepted(int accountId, int questId)
	{
	}

	// Token: 0x06002E1D RID: 11805 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnQuestAbandoned(int characterId, int questId)
	{
	}

	// Token: 0x06002E1E RID: 11806 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnNewTask(int iCharacterID, int iQuestID, int iNewTaskID)
	{
	}

	// Token: 0x06002E1F RID: 11807 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnTaskProgressUpgrade(int questID, int taskID, int count)
	{
	}

	// Token: 0x06002E20 RID: 11808 RVA: 0x0001E817 File Offset: 0x0001CA17
	public void OnQuestRewardClaimed(int accountId, int questId, QuestReward[] rewards)
	{
		this.method_9(false);
	}

	// Token: 0x06002E21 RID: 11809 RVA: 0x000D6D34 File Offset: 0x000D4F34
	public void OnQuestProgress(int accountId, Dictionary<int, QuestProgress> questProgress)
	{
		this.mProcessingQuests.Clear();
		Dictionary<int, Quest> dictionary = ServiceWrapperBase<QuestServiceWrapper>.Instance.method_17();
		for (int i = 0; i < questProgress.Count; i++)
		{
			QuestProgress value = questProgress.ElementAt<KeyValuePair<int, QuestProgress>>(i).Value;
			if (value.mStatus == QuestState.InProgress)
			{
				Quest quest = null;
				dictionary.TryGetValue(value.mQuestId, out quest);
				if (quest != null)
				{
					foreach (int num in quest.mBoundInstanceList)
					{
						if (!this.mProcessingQuests.Contains(num) && quest.mIsBoundInstance)
						{
							this.mProcessingQuests.Add(num);
						}
					}
				}
			}
		}
		if (GroupManager.smethod_0().method_18())
		{
			this.method_10();
		}
		this.m_bQuestInited = true;
	}

	// Token: 0x06002E22 RID: 11810 RVA: 0x0001E820 File Offset: 0x0001CA20
	public bool method_8(int int_0)
	{
		return this.mProcessingQuests.Contains(int_0);
	}

	// Token: 0x06002E23 RID: 11811 RVA: 0x000D6DF8 File Offset: 0x000D4FF8
	public void method_9(bool bool_0 = true)
	{
		if (MonoSingleton<AppManager>.Instance.m_offlineMode)
		{
			this.m_bWithNewlyUnlockedInstance = false;
			return;
		}
		Dictionary<int, int> dictionary = OnAccessSingleton<IProgressionService, ProgressionService, ProgressionServiceOffline>.Prop_0.imethod_1();
		if (this.m_bFirstEnterFlag)
		{
			for (int i = 0; i < dictionary.Count; i++)
			{
				this.mAccessableLevels.Add(dictionary.ElementAt<KeyValuePair<int, int>>(i).Key, dictionary.ElementAt<KeyValuePair<int, int>>(i).Value);
			}
			this.m_bFirstEnterFlag = false;
			this.method_5();
		}
		else
		{
			if (GroupManager.smethod_0().method_18())
			{
				this.method_10();
			}
			this.m_bWithNewlyUnlockedInstance = false;
			this.mUnlockedLevels.Clear();
			for (int j = 0; j < dictionary.Count; j++)
			{
				if (!this.mAccessableLevels.ContainsKey(dictionary.ElementAt<KeyValuePair<int, int>>(j).Key))
				{
					this.mUnlockedLevels.Add(dictionary.ElementAt<KeyValuePair<int, int>>(j).Key, dictionary.ElementAt<KeyValuePair<int, int>>(j).Value);
					this.m_bWithNewlyUnlockedInstance = true;
				}
			}
			this.mAccessableLevels.Clear();
			for (int k = 0; k < dictionary.Count; k++)
			{
				this.mAccessableLevels.Add(dictionary.ElementAt<KeyValuePair<int, int>>(k).Key, dictionary.ElementAt<KeyValuePair<int, int>>(k).Value);
			}
		}
	}

	// Token: 0x06002E24 RID: 11812 RVA: 0x0001E82E File Offset: 0x0001CA2E
	public void method_10()
	{
		DebugUtils.Log(LogCategory.GUI, "UpdateGroupUnlockedInstances call GetMyUnlockedInstances");
		OnAccessSingleton<IProgressionService, ProgressionService, ProgressionServiceOffline>.Prop_0.imethod_0(new GetUnlockedInstancesCallback(this.method_11));
	}

	// Token: 0x06002E25 RID: 11813 RVA: 0x000D6F48 File Offset: 0x000D5148
	private void method_11(Dictionary<int, int> dictionary_0)
	{
		this.mGroupUnlockedLevels.Clear();
		this.mAccessableLevels.Clear();
		for (int i = 0; i < dictionary_0.Count; i++)
		{
			this.mGroupUnlockedLevels.Add(dictionary_0.ElementAt<KeyValuePair<int, int>>(i).Key, dictionary_0.ElementAt<KeyValuePair<int, int>>(i).Value);
			this.mAccessableLevels.Add(dictionary_0.ElementAt<KeyValuePair<int, int>>(i).Key, dictionary_0.ElementAt<KeyValuePair<int, int>>(i).Value);
		}
	}

	// Token: 0x06002E26 RID: 11814 RVA: 0x000D6FD0 File Offset: 0x000D51D0
	public bool method_12(int int_0)
	{
		if (this.m_unlockAll)
		{
			return false;
		}
		if (MonoSingleton<AppManager>.Instance.m_offlineMode)
		{
			return false;
		}
		if (GroupManager.smethod_0().method_18())
		{
			if (this.mGroupUnlockedLevels.ContainsKey(int_0))
			{
				return false;
			}
		}
		else if (this.mAccessableLevels.ContainsKey(int_0))
		{
			return false;
		}
		return true;
	}

	// Token: 0x06002E27 RID: 11815 RVA: 0x000D7024 File Offset: 0x000D5224
	public int method_13(int int_0)
	{
		if (this.m_unlockAll)
		{
			return 2;
		}
		if (MonoSingleton<AppManager>.Instance.m_offlineMode)
		{
			return 2;
		}
		if (GroupManager.smethod_0().method_18())
		{
			if (this.mGroupUnlockedLevels.ContainsKey(int_0))
			{
				return this.mGroupUnlockedLevels[int_0];
			}
		}
		else if (this.mAccessableLevels.ContainsKey(int_0))
		{
			return this.mAccessableLevels[int_0];
		}
		return -1;
	}

	// Token: 0x04002047 RID: 8263
	private Dictionary<int, int> mAccessableLevels = new Dictionary<int, int>();

	// Token: 0x04002048 RID: 8264
	private Dictionary<int, int> mUnlockedLevels = new Dictionary<int, int>();

	// Token: 0x04002049 RID: 8265
	private Dictionary<int, int> mGroupUnlockedLevels = new Dictionary<int, int>();

	// Token: 0x0400204A RID: 8266
	private List<int> mProcessingQuests = new List<int>();

	// Token: 0x0400204B RID: 8267
	private bool m_bFirstEnterFlag = true;

	// Token: 0x0400204C RID: 8268
	private static LevelLockingManager mInstance;

	// Token: 0x0400204D RID: 8269
	private bool m_unlockAll;

	// Token: 0x0400204E RID: 8270
	public bool m_bQuestInited;

	// Token: 0x0400204F RID: 8271
	private bool m_bWithNewlyUnlockedInstance;
}
