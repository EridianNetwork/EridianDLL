using System;
using System.Collections.Generic;
using XsdSettings;

// Token: 0x02000341 RID: 833
public interface IQuestServiceNotificationListerner
{
	// Token: 0x06001503 RID: 5379
	void OnTaskProgressUpgrade(int questID, int taskID, int count);

	// Token: 0x06001504 RID: 5380
	void OnQuestUpdate(int characterId, int questId, QuestState questState);

	// Token: 0x06001505 RID: 5381
	void OnQuestAccepted(int characterId, int questId);

	// Token: 0x06001506 RID: 5382
	void OnQuestAbandoned(int characterId, int questId);

	// Token: 0x06001507 RID: 5383
	void OnQuestRewardClaimed(int characterId, int questId, QuestReward[] rewards);

	// Token: 0x06001508 RID: 5384
	void OnQuestProgress(int characterId, Dictionary<int, QuestProgress> quests);

	// Token: 0x06001509 RID: 5385
	void OnNewTask(int iCharacterID, int iQuestID, int iNewTaskID);
}
