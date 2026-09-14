using System;
using System.Collections;
using System.Collections.Generic;
using XsdSettings;

// Token: 0x0200036F RID: 879
internal class FriendsListsService : OnAccessSingleton<IFriendsListsService, FriendsListsService, FriendsListsServiceOffline>, IFriendsListsService
{
	// Token: 0x06001615 RID: 5653 RVA: 0x0007B33C File Offset: 0x0007953C
	public FriendsListsService()
	{
		PhotonNetwork.onlinePeer.method_5(207, new OperationResponseCallback(this.OnRetrieveFriendsList));
		PhotonNetwork.onlinePeer.method_5(206, new OperationResponseCallback(this.OnIsUserAFriend));
		PhotonNetwork.onlinePeer.method_5(201, new OperationResponseCallback(this.OnIsUserIgnored));
		PhotonNetwork.onlinePeer.method_5(144, new OperationResponseCallback(this.OnGotFriendsCharacterInfo));
		PhotonNetwork.onlinePeer.method_7(208, new EventCallback(this.OnNewFriendEvent));
		PhotonNetwork.onlinePeer.method_7(207, new EventCallback(this.OnUnfriendedEvent));
		PhotonNetwork.onlinePeer.method_7(155, new EventCallback(this.OnRejectFriendEvent));
		OnAccessSingleton<IMessagingService, MessagingService, MessagingServiceOffline>.Prop_0.imethod_5("friend_request", new OnRecieveMessage(this.OnFriendRequestReceived));
	}

	// Token: 0x06001616 RID: 5654 RVA: 0x000102CC File Offset: 0x0000E4CC
	public void imethod_0(OnGetMyFriendsList onGetMyFriendsList_0)
	{
		this.mOnGetMyFriendsList = onGetMyFriendsList_0;
		PhotonNetwork.onlinePeer.method_3(207, new object[0]);
	}

	// Token: 0x06001617 RID: 5655 RVA: 0x0007B470 File Offset: 0x00079670
	private void OnRetrieveFriendsList(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (this.mOnGetMyFriendsList != null)
		{
			if (operationResponse == 0)
			{
				int[] array = new int[parameters.Count];
				int num = 0;
				foreach (object obj in parameters.Values)
				{
					array[num++] = (int)((Hashtable)obj)[0];
				}
				this.mOnGetMyFriendsList(array);
			}
			else
			{
				this.mOnGetMyFriendsList(null);
			}
			this.mOnGetMyFriendsList = null;
		}
	}

	// Token: 0x06001618 RID: 5656 RVA: 0x000102EB File Offset: 0x0000E4EB
	public void imethod_1(int int_0)
	{
		PhotonNetwork.onlinePeer.method_3(164, new object[] { int_0 });
	}

	// Token: 0x06001619 RID: 5657 RVA: 0x0001030C File Offset: 0x0000E50C
	public void imethod_2(int int_0)
	{
		PhotonNetwork.onlinePeer.method_3(205, new object[] { int_0 });
	}

	// Token: 0x0600161A RID: 5658 RVA: 0x0001032D File Offset: 0x0000E52D
	public void imethod_3(int int_0)
	{
		PhotonNetwork.onlinePeer.method_3(165, new object[] { int_0 });
	}

	// Token: 0x0600161B RID: 5659 RVA: 0x0001034E File Offset: 0x0000E54E
	public void imethod_4(int int_0)
	{
		PhotonNetwork.onlinePeer.method_3(204, new object[] { int_0 });
	}

	// Token: 0x0600161C RID: 5660 RVA: 0x0001036F File Offset: 0x0000E56F
	public void imethod_5(int int_0)
	{
		PhotonNetwork.onlinePeer.method_3(203, new object[] { int_0 });
	}

	// Token: 0x0600161D RID: 5661 RVA: 0x00010390 File Offset: 0x0000E590
	public void imethod_6(int int_0)
	{
		PhotonNetwork.onlinePeer.method_3(202, new object[] { int_0 });
	}

	// Token: 0x0600161E RID: 5662 RVA: 0x000103B1 File Offset: 0x0000E5B1
	public void imethod_7(OnIsUserAFriend onIsUserAFriend_0, int int_0)
	{
		this.mOnIsUserAFriend = onIsUserAFriend_0;
		PhotonNetwork.onlinePeer.method_3(206, new object[]
		{
			OnlineService.s_characterId,
			int_0
		});
	}

	// Token: 0x0600161F RID: 5663 RVA: 0x0007B518 File Offset: 0x00079718
	private void OnIsUserAFriend(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (this.mOnIsUserAFriend != null)
		{
			if (operationResponse == 0)
			{
				int num = (int)parameters[0];
				int num2 = (int)parameters[1];
				bool flag = (bool)parameters[2];
				this.mOnIsUserAFriend(num, num2, flag);
			}
			else
			{
				this.mOnIsUserAFriend(-1, -1, false);
			}
			this.mOnIsUserAFriend = null;
		}
	}

	// Token: 0x06001620 RID: 5664 RVA: 0x000103E6 File Offset: 0x0000E5E6
	public void imethod_8(OnIsUserIgnored onIsUserIgnored_0, int int_0)
	{
		this.mOnIsUserIgnored = onIsUserIgnored_0;
		PhotonNetwork.onlinePeer.method_3(201, new object[]
		{
			OnlineService.s_characterId,
			int_0
		});
	}

	// Token: 0x06001621 RID: 5665 RVA: 0x0007B57C File Offset: 0x0007977C
	private void OnIsUserIgnored(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (this.mOnIsUserIgnored != null)
		{
			if (operationResponse == 0)
			{
				int num = (int)parameters[0];
				int num2 = (int)parameters[1];
				bool flag = (bool)parameters[2];
				this.mOnIsUserIgnored(num, num2, flag);
			}
			else
			{
				this.mOnIsUserIgnored(-1, -1, false);
			}
			this.mOnIsUserIgnored = null;
		}
	}

	// Token: 0x06001622 RID: 5666 RVA: 0x0001041B File Offset: 0x0000E61B
	public void imethod_11(OnFriendRequestReceived onFriendRequestReceived_0)
	{
		this.mOnFriendRequestReceived.Add(onFriendRequestReceived_0);
	}

	// Token: 0x06001623 RID: 5667 RVA: 0x00010429 File Offset: 0x0000E629
	public void imethod_12(OnFriendRequestReceived onFriendRequestReceived_0)
	{
		this.mOnFriendRequestReceived.Remove(onFriendRequestReceived_0);
	}

	// Token: 0x06001624 RID: 5668 RVA: 0x0007B5E0 File Offset: 0x000797E0
	private void OnFriendRequestReceived(Message message)
	{
		mOnFriendRequestReceived.ForEach(delegate(OnFriendRequestReceived onFriendRequestReceived_0)
		{
			onFriendRequestReceived_0(new FriendRequest
			{
				mMessageId = message.mId,
				mSender = message.mSender
			});
		});
	}
	// Token: 0x06001625 RID: 5669 RVA: 0x00010438 File Offset: 0x0000E638
	public void method_0(OnIsUserAFriend onIsUserAFriend_0, int int_0, int int_1)
	{
		this.mOnIsUserAFriend = onIsUserAFriend_0;
		PhotonNetwork.onlinePeer.method_3(206, new object[] { int_0, int_1 });
	}

	// Token: 0x06001626 RID: 5670 RVA: 0x00010469 File Offset: 0x0000E669
	public void method_1(OnIsUserIgnored onIsUserIgnored_0, int int_0, int int_1)
	{
		this.mOnIsUserIgnored = onIsUserIgnored_0;
		PhotonNetwork.onlinePeer.method_3(201, new object[] { int_0, int_1 });
	}

	// Token: 0x06001627 RID: 5671 RVA: 0x0001049A File Offset: 0x0000E69A
	public void imethod_9(OnGetFriendsCharacterInfo onGetFriendsCharacterInfo_0)
	{
		this.mOnGetFriendsCharacterInfo = onGetFriendsCharacterInfo_0;
		PhotonNetwork.onlinePeer.method_3(144, new object[0]);
	}

	// Token: 0x06001628 RID: 5672 RVA: 0x0007B614 File Offset: 0x00079814
	private void OnGotFriendsCharacterInfo(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (this.mOnGetFriendsCharacterInfo != null)
		{
			if (operationResponse == 0)
			{
				List<PlayerProperties> list = new List<PlayerProperties>();
				Hashtable hashtable = (Hashtable)parameters[0];
				foreach (object obj in hashtable)
				{
					Dictionary<byte, object> dictionary = (Dictionary<byte, object>)((DictionaryEntry)obj).Value;
					PlayerProperties playerProperties = new PlayerProperties
					{
						m_id = (int)dictionary[0],
						m_name = (string)dictionary[1],
						m_level = (int)dictionary[2],
						m_avatarDna = new AvatarDNA()
					};
					playerProperties.m_avatarDna.method_6((AvatarType)((int)dictionary[3]));
					list.Add(playerProperties);
				}
				this.mOnGetFriendsCharacterInfo(list);
			}
			else
			{
				this.mOnGetFriendsCharacterInfo(null);
			}
			this.mOnGetFriendsCharacterInfo = null;
		}
	}

	// Token: 0x06001629 RID: 5673 RVA: 0x000104B9 File Offset: 0x0000E6B9
	public void imethod_10(OnGetMyPendingFriendRequests onGetMyPendingFriendRequests_0)
	{
		if (onGetMyPendingFriendRequests_0 != null)
		{
			this.mOnGetMyPendingFriendRequests = onGetMyPendingFriendRequests_0;
		}
		OnAccessSingleton<IMessagingService, MessagingService, MessagingServiceOffline>.Prop_0.imethod_2(new OnRetrieveMessages(this.OnRetrieveMessagesResponse), "friend_request", false, 1, 50);
	}

	// Token: 0x0600162A RID: 5674 RVA: 0x0007B734 File Offset: 0x00079934
	private void OnRetrieveMessagesResponse(Message[] messages)
	{
		if (this.mOnGetMyPendingFriendRequests != null)
		{
			FriendRequest[] array = new FriendRequest[messages.Length];
			for (int i = 0; i < messages.Length; i++)
			{
				array[i].mMessageId = messages[i].mId;
				array[i].mSender = messages[i].mSender;
			}
			this.mOnGetMyPendingFriendRequests(array);
			this.mOnGetMyPendingFriendRequests = null;
		}
	}

	// Token: 0x0600162B RID: 5675 RVA: 0x000104E4 File Offset: 0x0000E6E4
	public void imethod_13(OnNewFriend onNewFriend_0)
	{
		this.mOnNewFriend.Add(onNewFriend_0);
	}

	// Token: 0x0600162C RID: 5676 RVA: 0x000104F2 File Offset: 0x0000E6F2
	public void imethod_14(OnNewFriend onNewFriend_0)
	{
		this.mOnNewFriend.Remove(onNewFriend_0);
	}

	// Token: 0x0600162D RID: 5677 RVA: 0x0007B7A4 File Offset: 0x000799A4
	private void OnNewFriendEvent(Dictionary<byte, object> parameters)
	{
		Presence presence = new Presence((Hashtable)parameters[0]);
		mOnNewFriend.ForEach(delegate(OnNewFriend onNewFriend_0)
		{
			onNewFriend_0(presence);
		});
	}
	// Token: 0x0600162E RID: 5678 RVA: 0x00010501 File Offset: 0x0000E701
	public void imethod_15(OnUnfriended onUnfriended_0)
	{
		this.mOnUnfriended.Add(onUnfriended_0);
	}

	// Token: 0x0600162F RID: 5679 RVA: 0x0001050F File Offset: 0x0000E70F
	public void imethod_16(OnUnfriended onUnfriended_0)
	{
		this.mOnUnfriended.Remove(onUnfriended_0);
	}

	// Token: 0x06001630 RID: 5680 RVA: 0x0007B7E8 File Offset: 0x000799E8
	private void OnUnfriendedEvent(Dictionary<byte, object> parameters)
	{
		int characterId = (int)parameters[0];
		mOnUnfriended.ForEach(delegate(OnUnfriended onUnfriended_0)
		{
			onUnfriended_0(characterId);
		});
	}
	// Token: 0x06001631 RID: 5681 RVA: 0x0001051E File Offset: 0x0000E71E
	public void imethod_17(OnRejectFriend onRejectFriend_0)
	{
		this.mOnRejectFriend.Add(onRejectFriend_0);
	}

	// Token: 0x06001632 RID: 5682 RVA: 0x0001052C File Offset: 0x0000E72C
	public void imethod_18(OnRejectFriend onRejectFriend_0)
	{
		this.mOnRejectFriend.Remove(onRejectFriend_0);
	}

	// Token: 0x06001633 RID: 5683 RVA: 0x0007B824 File Offset: 0x00079A24
	private void OnRejectFriendEvent(Dictionary<byte, object> parameters)
	{
		int characterId = (int)parameters[0];
		string characterName = (string)parameters[1];
		mOnRejectFriend.ForEach(delegate(OnRejectFriend onRejectFriend_0)
		{
			onRejectFriend_0(characterId, characterName);
		});
	}
	// Token: 0x04000EF5 RID: 3829
	public readonly DateTime EPOCH = new DateTime(1970, 1, 1, 0, 0, 0, 0);

	// Token: 0x04000EF6 RID: 3830
	private List<OnNewFriend> mOnNewFriend = new List<OnNewFriend>();

	// Token: 0x04000EF7 RID: 3831
	private List<OnUnfriended> mOnUnfriended = new List<OnUnfriended>();

	// Token: 0x04000EF8 RID: 3832
	private List<OnRejectFriend> mOnRejectFriend = new List<OnRejectFriend>();

	// Token: 0x04000EF9 RID: 3833
	private List<OnFriendRequestReceived> mOnFriendRequestReceived = new List<OnFriendRequestReceived>();

	// Token: 0x04000EFA RID: 3834
	private OnGetMyFriendsList mOnGetMyFriendsList;

	// Token: 0x04000EFB RID: 3835
	private OnIsUserAFriend mOnIsUserAFriend;

	// Token: 0x04000EFC RID: 3836
	private OnIsUserIgnored mOnIsUserIgnored;

	// Token: 0x04000EFD RID: 3837
	private OnGetFriendsCharacterInfo mOnGetFriendsCharacterInfo;

	// Token: 0x04000EFE RID: 3838
	private OnGetMyPendingFriendRequests mOnGetMyPendingFriendRequests;
}
