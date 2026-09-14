using System;

// Token: 0x0200032B RID: 811
internal class PresenceServiceOffline : IPresenceService
{
	// Token: 0x06001427 RID: 5159 RVA: 0x0000F2D2 File Offset: 0x0000D4D2
	public void imethod_0(int int_0, OnGetPresence onGetPresence_0)
	{
		if (onGetPresence_0 != null)
		{
			onGetPresence_0(null);
		}
	}

	// Token: 0x06001428 RID: 5160 RVA: 0x0000F2DE File Offset: 0x0000D4DE
	public void imethod_1(OnGetPresence onGetPresence_0)
	{
		if (onGetPresence_0 != null)
		{
			onGetPresence_0(null);
		}
	}

	// Token: 0x06001429 RID: 5161 RVA: 0x0000F2EA File Offset: 0x0000D4EA
	public void imethod_2(OnGetFriendsPresence onGetFriendsPresence_0)
	{
		if (onGetFriendsPresence_0 != null)
		{
			onGetFriendsPresence_0(null);
		}
	}

	// Token: 0x0600142A RID: 5162 RVA: 0x0000F2F6 File Offset: 0x0000D4F6
	public void imethod_3(OnSearchForCharacter onSearchForCharacter_0, string string_0)
	{
		if (onSearchForCharacter_0 != null)
		{
			onSearchForCharacter_0(null);
		}
	}

	// Token: 0x0600142B RID: 5163 RVA: 0x0000311B File Offset: 0x0000131B
	public void method_0(int int_0, OnGetAntiAddictionLevel onGetAntiAddictionLevel_0)
	{
	}

	// Token: 0x0600142C RID: 5164 RVA: 0x0000311B File Offset: 0x0000131B
	public void method_1(int int_0, int int_1)
	{
	}

	// Token: 0x0600142D RID: 5165 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_4(OnPresenceUpdated onPresenceUpdated_0)
	{
	}

	// Token: 0x0600142E RID: 5166 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_5(OnPresenceUpdated onPresenceUpdated_0)
	{
	}

	// Token: 0x0600142F RID: 5167 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_6(OnNotifyAntiAddictionLevelEvent onNotifyAntiAddictionLevelEvent_0)
	{
	}

	// Token: 0x06001430 RID: 5168 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_7(OnNotifyAntiAddictionLevelEvent onNotifyAntiAddictionLevelEvent_0)
	{
	}
}
