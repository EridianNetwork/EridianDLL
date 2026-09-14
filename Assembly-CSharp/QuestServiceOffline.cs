using System;
using System.Collections.Generic;

// Token: 0x0200032D RID: 813
internal class QuestServiceOffline : IQuestService
{
	// Token: 0x0600143A RID: 5178 RVA: 0x000774E8 File Offset: 0x000756E8
	public Dictionary<int, QuestProgress> imethod_0(int int_0, GetPlayerQuestsCallback getPlayerQuestsCallback_0 = null)
	{
		Dictionary<int, QuestProgress> dictionary = new Dictionary<int, QuestProgress>();
		if (getPlayerQuestsCallback_0 != null)
		{
			getPlayerQuestsCallback_0(int_0, dictionary);
		}
		return dictionary;
	}

	// Token: 0x0600143B RID: 5179 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_2(int int_0, int int_1)
	{
	}

	// Token: 0x0600143C RID: 5180 RVA: 0x0000311B File Offset: 0x0000131B
	public void method_0(int int_0, int int_1, int int_2, int int_3)
	{
	}

	// Token: 0x0600143D RID: 5181 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_21(int int_0, int int_1)
	{
	}

	// Token: 0x0600143E RID: 5182 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_1(int int_0, int int_1, byte[] byte_0)
	{
	}

	// Token: 0x0600143F RID: 5183 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_4(int int_0, int int_1)
	{
	}

	// Token: 0x06001440 RID: 5184 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_3()
	{
	}

	// Token: 0x06001441 RID: 5185 RVA: 0x0000F319 File Offset: 0x0000D519
	public void imethod_5(TalkToNPCCallback talkToNPCCallback_0, int int_0, int int_1)
	{
		if (talkToNPCCallback_0 != null)
		{
			talkToNPCCallback_0(false, null);
		}
	}

	// Token: 0x06001442 RID: 5186 RVA: 0x0000F326 File Offset: 0x0000D526
	public void imethod_6(BringToNPCCallback bringToNPCCallback_0, int int_0, int int_1)
	{
		if (bringToNPCCallback_0 != null)
		{
			bringToNPCCallback_0(false, null);
		}
	}

	// Token: 0x06001443 RID: 5187 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_7(QuestAcceptedCallback questAcceptedCallback_0)
	{
	}

	// Token: 0x06001444 RID: 5188 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_8(QuestAcceptedCallback questAcceptedCallback_0)
	{
	}

	// Token: 0x06001445 RID: 5189 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_9(RejectQuestCallback rejectQuestCallback_0)
	{
	}

	// Token: 0x06001446 RID: 5190 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_10(RejectQuestCallback rejectQuestCallback_0)
	{
	}

	// Token: 0x06001447 RID: 5191 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_13(QuestStatusCallback questStatusCallback_0)
	{
	}

	// Token: 0x06001448 RID: 5192 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_14(QuestStatusCallback questStatusCallback_0)
	{
	}

	// Token: 0x06001449 RID: 5193 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_11(QuestRewardClaimedCallback questRewardClaimedCallback_0)
	{
	}

	// Token: 0x0600144A RID: 5194 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_12(QuestRewardClaimedCallback questRewardClaimedCallback_0)
	{
	}

	// Token: 0x0600144B RID: 5195 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_17(GetPlayerDailyQuestsContentCallback getPlayerDailyQuestsContentCallback_0)
	{
	}

	// Token: 0x0600144C RID: 5196 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_18(GetPlayerDailyQuestsContentCallback getPlayerDailyQuestsContentCallback_0)
	{
	}

	// Token: 0x0600144D RID: 5197 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_19(ClearPlayerDailyQuestCallback clearPlayerDailyQuestCallback_0)
	{
	}

	// Token: 0x0600144E RID: 5198 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_20(ClearPlayerDailyQuestCallback clearPlayerDailyQuestCallback_0)
	{
	}

	// Token: 0x0600144F RID: 5199 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_15(QuestTaskUpdatedCallback questTaskUpdatedCallback_0)
	{
	}

	// Token: 0x06001450 RID: 5200 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_16(QuestTaskUpdatedCallback questTaskUpdatedCallback_0)
	{
	}
}
