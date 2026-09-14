using System;
using System.Collections.Generic;
using ns0;
using XsdSettings;

// Token: 0x02000343 RID: 835
public class QuestServiceWrapperOnline : IQuestServiceWrapper, IServiceWrapper
{
	// Token: 0x06001533 RID: 5427 RVA: 0x0000F82F File Offset: 0x0000DA2F
	private void method_0(int int_0, Dictionary<int, QuestProgress> dictionary_0)
	{
		ServiceWrapperBase<QuestServiceWrapper>.Instance.OnQuestProgress(int_0, dictionary_0);
		this.m_initialized = true;
	}

	// Token: 0x06001534 RID: 5428 RVA: 0x0000F844 File Offset: 0x0000DA44
	public void method_1(int int_0, int int_1, QuestState questState_0)
	{
		ServiceWrapperBase<QuestServiceWrapper>.Instance.OnQuestUpdate(int_0, int_1, questState_0);
	}

	// Token: 0x06001535 RID: 5429 RVA: 0x0000F853 File Offset: 0x0000DA53
	public void method_2(int int_0, int int_1)
	{
		ServiceWrapperBase<QuestServiceWrapper>.Instance.OnQuestAccepted(int_0, int_1);
	}

	// Token: 0x06001536 RID: 5430 RVA: 0x0000F861 File Offset: 0x0000DA61
	public void method_3(int int_0, int int_1, QuestReward[] questReward_0)
	{
		ServiceWrapperBase<QuestServiceWrapper>.Instance.OnQuestRewardClaimed(int_0, int_1, questReward_0);
	}

	// Token: 0x06001537 RID: 5431 RVA: 0x0000F870 File Offset: 0x0000DA70
	public void method_4(Dictionary<int, DailyQuestInfo> dictionary_0)
	{
		ServiceWrapperBase<QuestServiceWrapper>.Instance.OnGetPlayerDailyQuestsContent(dictionary_0);
	}

	// Token: 0x06001538 RID: 5432 RVA: 0x0000F87D File Offset: 0x0000DA7D
	public void method_5()
	{
		ServiceWrapperBase<QuestServiceWrapper>.Instance.OnClearPlayerDailyQuest();
	}

	// Token: 0x06001539 RID: 5433 RVA: 0x0000F889 File Offset: 0x0000DA89
	public void method_6(short short_0, int int_0)
	{
		ServiceWrapperBase<QuestServiceWrapper>.Instance.OnQuestAbandoned(short_0, int_0);
	}

	// Token: 0x0600153A RID: 5434 RVA: 0x00079994 File Offset: 0x00077B94
	public void imethod_0()
	{
		if (!this.m_isInitializing && !this.m_initialized)
		{
			this.m_isInitializing = true;
			OnAccessSingleton<IQuestService, QuestService, QuestServiceOffline>.Prop_0.imethod_7(new QuestAcceptedCallback(this.method_2));
			OnAccessSingleton<IQuestService, QuestService, QuestServiceOffline>.Prop_0.imethod_11(new QuestRewardClaimedCallback(this.method_3));
			OnAccessSingleton<IQuestService, QuestService, QuestServiceOffline>.Prop_0.imethod_13(new QuestStatusCallback(this.method_1));
			OnAccessSingleton<IQuestService, QuestService, QuestServiceOffline>.Prop_0.imethod_17(new GetPlayerDailyQuestsContentCallback(this.method_4));
			OnAccessSingleton<IQuestService, QuestService, QuestServiceOffline>.Prop_0.imethod_19(new ClearPlayerDailyQuestCallback(this.method_5));
			OnAccessSingleton<IQuestService, QuestService, QuestServiceOffline>.Prop_0.imethod_9(new RejectQuestCallback(this.method_6));
			OnAccessSingleton<IQuestService, QuestService, QuestServiceOffline>.Prop_0.imethod_3();
			OnAccessSingleton<IQuestService, QuestService, QuestServiceOffline>.Prop_0.imethod_0(OnlineService.s_characterId, new GetPlayerQuestsCallback(this.method_0));
		}
	}

	// Token: 0x0600153B RID: 5435 RVA: 0x0000F897 File Offset: 0x0000DA97
	public bool imethod_1()
	{
		return this.m_initialized;
	}

	// Token: 0x0600153C RID: 5436 RVA: 0x0000F89F File Offset: 0x0000DA9F
	public void imethod_2(int int_0, byte[] byte_0)
	{
		OnAccessSingleton<IQuestService, QuestService, QuestServiceOffline>.Prop_0.imethod_1(OnlineService.s_characterId, int_0, byte_0);
	}

	// Token: 0x0600153D RID: 5437 RVA: 0x0000F8B2 File Offset: 0x0000DAB2
	public void imethod_3(int int_0)
	{
		OnAccessSingleton<IQuestService, QuestService, QuestServiceOffline>.Prop_0.imethod_2(OnlineService.s_characterId, int_0);
	}

	// Token: 0x0600153E RID: 5438 RVA: 0x0000F8C4 File Offset: 0x0000DAC4
	public void imethod_5()
	{
		OnAccessSingleton<IQuestService, QuestService, QuestServiceOffline>.Prop_0.imethod_3();
	}

	// Token: 0x0600153F RID: 5439 RVA: 0x0000F8D0 File Offset: 0x0000DAD0
	public Dictionary<int, QuestProgress> imethod_4()
	{
		return OnAccessSingleton<IQuestService, QuestService, QuestServiceOffline>.Prop_0.imethod_0(OnlineService.s_characterId, new GetPlayerQuestsCallback(this.method_0));
	}

	// Token: 0x06001540 RID: 5440 RVA: 0x0000F8ED File Offset: 0x0000DAED
	public void imethod_6(int int_0, int int_1)
	{
		OnAccessSingleton<IQuestService, QuestService, QuestServiceOffline>.Prop_0.imethod_4(int_0, int_1);
	}

	// Token: 0x06001541 RID: 5441 RVA: 0x0000F8FB File Offset: 0x0000DAFB
	public void imethod_7(TalkToNPCCallback talkToNPCCallback_0, int int_0, int int_1)
	{
		OnAccessSingleton<IQuestService, QuestService, QuestServiceOffline>.Prop_0.imethod_5(talkToNPCCallback_0, int_0, int_1);
	}

	// Token: 0x06001542 RID: 5442 RVA: 0x0000F90A File Offset: 0x0000DB0A
	public void imethod_8(BringToNPCCallback bringToNPCCallback_0, int int_0, int int_1)
	{
		OnAccessSingleton<IQuestService, QuestService, QuestServiceOffline>.Prop_0.imethod_6(bringToNPCCallback_0, int_0, int_1);
	}

	// Token: 0x06001543 RID: 5443 RVA: 0x0000F919 File Offset: 0x0000DB19
	public void imethod_9(int int_0, int int_1)
	{
		OnAccessSingleton<IQuestService, QuestService, QuestServiceOffline>.Prop_0.imethod_21(int_0, int_1);
	}

	// Token: 0x04000E87 RID: 3719
	private bool m_isInitializing;

	// Token: 0x04000E88 RID: 3720
	private bool m_initialized;
}
