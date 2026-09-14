using System;

// Token: 0x02000320 RID: 800
internal class FriendsListsServiceOffline : IFriendsListsService
{
	// Token: 0x06001375 RID: 4981 RVA: 0x0000EFAA File Offset: 0x0000D1AA
	public void imethod_0(OnGetMyFriendsList onGetMyFriendsList_0)
	{
		if (onGetMyFriendsList_0 != null)
		{
			onGetMyFriendsList_0(null);
		}
	}

	// Token: 0x06001376 RID: 4982 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_1(int int_0)
	{
	}

	// Token: 0x06001377 RID: 4983 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_2(int int_0)
	{
	}

	// Token: 0x06001378 RID: 4984 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_3(int int_0)
	{
	}

	// Token: 0x06001379 RID: 4985 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_4(int int_0)
	{
	}

	// Token: 0x0600137A RID: 4986 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_5(int int_0)
	{
	}

	// Token: 0x0600137B RID: 4987 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_6(int int_0)
	{
	}

	// Token: 0x0600137C RID: 4988 RVA: 0x0000EFB6 File Offset: 0x0000D1B6
	public void imethod_7(OnIsUserAFriend onIsUserAFriend_0, int int_0)
	{
		if (onIsUserAFriend_0 != null)
		{
			onIsUserAFriend_0(-1, -1, false);
		}
	}

	// Token: 0x0600137D RID: 4989 RVA: 0x0000EFC4 File Offset: 0x0000D1C4
	public void imethod_8(OnIsUserIgnored onIsUserIgnored_0, int int_0)
	{
		if (onIsUserIgnored_0 != null)
		{
			onIsUserIgnored_0(-1, -1, false);
		}
	}

	// Token: 0x0600137E RID: 4990 RVA: 0x0000EFD2 File Offset: 0x0000D1D2
	public void imethod_10(OnGetMyPendingFriendRequests onGetMyPendingFriendRequests_0)
	{
		if (onGetMyPendingFriendRequests_0 != null)
		{
			onGetMyPendingFriendRequests_0(null);
		}
	}

	// Token: 0x0600137F RID: 4991 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_11(OnFriendRequestReceived onFriendRequestReceived_0)
	{
	}

	// Token: 0x06001380 RID: 4992 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_12(OnFriendRequestReceived onFriendRequestReceived_0)
	{
	}

	// Token: 0x06001381 RID: 4993 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_13(OnNewFriend onNewFriend_0)
	{
	}

	// Token: 0x06001382 RID: 4994 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_14(OnNewFriend onNewFriend_0)
	{
	}

	// Token: 0x06001383 RID: 4995 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_15(OnUnfriended onUnfriended_0)
	{
	}

	// Token: 0x06001384 RID: 4996 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_16(OnUnfriended onUnfriended_0)
	{
	}

	// Token: 0x06001385 RID: 4997 RVA: 0x0000EFB6 File Offset: 0x0000D1B6
	public void method_0(OnIsUserAFriend onIsUserAFriend_0, int int_0, int int_1)
	{
		if (onIsUserAFriend_0 != null)
		{
			onIsUserAFriend_0(-1, -1, false);
		}
	}

	// Token: 0x06001386 RID: 4998 RVA: 0x0000EFC4 File Offset: 0x0000D1C4
	public void method_1(OnIsUserIgnored onIsUserIgnored_0, int int_0, int int_1)
	{
		if (onIsUserIgnored_0 != null)
		{
			onIsUserIgnored_0(-1, -1, false);
		}
	}

	// Token: 0x06001387 RID: 4999 RVA: 0x0000EFDE File Offset: 0x0000D1DE
	public void imethod_9(OnGetFriendsCharacterInfo onGetFriendsCharacterInfo_0)
	{
		if (onGetFriendsCharacterInfo_0 != null)
		{
			onGetFriendsCharacterInfo_0(null);
		}
	}

	// Token: 0x06001388 RID: 5000 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_17(OnRejectFriend onRejectFriend_0)
	{
	}

	// Token: 0x06001389 RID: 5001 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_18(OnRejectFriend onRejectFriend_0)
	{
	}
}
