using System;

// Token: 0x020002F9 RID: 761
internal interface IPresenceService
{
	// Token: 0x060011B4 RID: 4532
	void imethod_0(int int_0, OnGetPresence onGetPresence_0);

	// Token: 0x060011B5 RID: 4533
	void imethod_1(OnGetPresence onGetPresence_0);

	// Token: 0x060011B6 RID: 4534
	void imethod_2(OnGetFriendsPresence onGetFriendsPresence_0);

	// Token: 0x060011B7 RID: 4535
	void imethod_3(OnSearchForCharacter onSearchForCharacter_0, string string_0);

	// Token: 0x060011B8 RID: 4536
	void imethod_4(OnPresenceUpdated onPresenceUpdated_0);

	// Token: 0x060011B9 RID: 4537
	void imethod_5(OnPresenceUpdated onPresenceUpdated_0);

	// Token: 0x060011BA RID: 4538
	void imethod_6(OnNotifyAntiAddictionLevelEvent onNotifyAntiAddictionLevelEvent_0);

	// Token: 0x060011BB RID: 4539
	void imethod_7(OnNotifyAntiAddictionLevelEvent onNotifyAntiAddictionLevelEvent_0);
}
