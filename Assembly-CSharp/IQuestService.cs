using System;
using System.Collections.Generic;

// Token: 0x020002FB RID: 763
internal interface IQuestService
{
	// Token: 0x060011C1 RID: 4545
	Dictionary<int, QuestProgress> imethod_0(int int_0, GetPlayerQuestsCallback getPlayerQuestsCallback_0 = null);

	// Token: 0x060011C2 RID: 4546
	void imethod_1(int int_0, int int_1, byte[] byte_0);

	// Token: 0x060011C3 RID: 4547
	void imethod_2(int int_0, int int_1);

	// Token: 0x060011C4 RID: 4548
	void imethod_3();

	// Token: 0x060011C5 RID: 4549
	void imethod_4(int int_0, int int_1);

	// Token: 0x060011C6 RID: 4550
	void imethod_5(TalkToNPCCallback talkToNPCCallback_0, int int_0, int int_1);

	// Token: 0x060011C7 RID: 4551
	void imethod_6(BringToNPCCallback bringToNPCCallback_0, int int_0, int int_1);

	// Token: 0x060011C8 RID: 4552
	void imethod_7(QuestAcceptedCallback questAcceptedCallback_0);

	// Token: 0x060011C9 RID: 4553
	void imethod_8(QuestAcceptedCallback questAcceptedCallback_0);

	// Token: 0x060011CA RID: 4554
	void imethod_9(RejectQuestCallback rejectQuestCallback_0);

	// Token: 0x060011CB RID: 4555
	void imethod_10(RejectQuestCallback rejectQuestCallback_0);

	// Token: 0x060011CC RID: 4556
	void imethod_11(QuestRewardClaimedCallback questRewardClaimedCallback_0);

	// Token: 0x060011CD RID: 4557
	void imethod_12(QuestRewardClaimedCallback questRewardClaimedCallback_0);

	// Token: 0x060011CE RID: 4558
	void imethod_13(QuestStatusCallback questStatusCallback_0);

	// Token: 0x060011CF RID: 4559
	void imethod_14(QuestStatusCallback questStatusCallback_0);

	// Token: 0x060011D0 RID: 4560
	void imethod_15(QuestTaskUpdatedCallback questTaskUpdatedCallback_0);

	// Token: 0x060011D1 RID: 4561
	void imethod_16(QuestTaskUpdatedCallback questTaskUpdatedCallback_0);

	// Token: 0x060011D2 RID: 4562
	void imethod_17(GetPlayerDailyQuestsContentCallback getPlayerDailyQuestsContentCallback_0);

	// Token: 0x060011D3 RID: 4563
	void imethod_18(GetPlayerDailyQuestsContentCallback getPlayerDailyQuestsContentCallback_0);

	// Token: 0x060011D4 RID: 4564
	void imethod_19(ClearPlayerDailyQuestCallback clearPlayerDailyQuestCallback_0);

	// Token: 0x060011D5 RID: 4565
	void imethod_20(ClearPlayerDailyQuestCallback clearPlayerDailyQuestCallback_0);

	// Token: 0x060011D6 RID: 4566
	void imethod_21(int int_0, int int_1);
}
