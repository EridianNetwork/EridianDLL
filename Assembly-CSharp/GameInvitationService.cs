using System;
using System.Collections.Generic;
using Core;
using ns0;

// Token: 0x02000375 RID: 885
internal class GameInvitationService : OnAccessSingleton<IGameInvitationService, GameInvitationService, GameInvitationServiceOffline>, IGameInvitationService
{
	// Token: 0x0600163C RID: 5692 RVA: 0x0007B8B4 File Offset: 0x00079AB4
	public GameInvitationService()
	{
		this.mGameInvitationCallbacks = new List<GameInvitationCallback>();
		OnAccessSingleton<IMessagingService, MessagingService, MessagingServiceOffline>.Prop_0.imethod_5("game_invitation", new OnRecieveMessage(this.OnGameInvitationReceived));
		PhotonNetwork.networkingPeer.RegisterOperationResponseCallback(137, new OperationResponseCallback(this.OnAcceptGameInvitationResponse));
	}

	// Token: 0x0600163D RID: 5693 RVA: 0x0001056B File Offset: 0x0000E76B
	public void imethod_0(GameInvitationCallback gameInvitationCallback_0)
	{
		this.mGameInvitationCallbacks.Add(gameInvitationCallback_0);
	}

	// Token: 0x0600163E RID: 5694 RVA: 0x00010579 File Offset: 0x0000E779
	public void imethod_1(GameInvitationCallback gameInvitationCallback_0)
	{
		this.mGameInvitationCallbacks.Remove(gameInvitationCallback_0);
	}

	// Token: 0x0600163F RID: 5695 RVA: 0x00010588 File Offset: 0x0000E788
	public void imethod_2(string string_0)
	{
		PhotonNetwork.onlinePeer.method_3(200, new object[] { string_0 });
	}

	// Token: 0x06001640 RID: 5696 RVA: 0x0007B90C File Offset: 0x00079B0C
	private void OnGameInvitationReceived(Message message)
	{
		mGameInvitationCallbacks.ForEach(delegate(GameInvitationCallback gameInvitationCallback_0)
		{
			gameInvitationCallback_0(new GameInvitation
			{
				mId = message.mId,
				mSender = message.mSender
			});
		});
	}
	// Token: 0x06001641 RID: 5697 RVA: 0x000105A4 File Offset: 0x0000E7A4
	public void imethod_3(GameInvitation gameInvitation_0)
	{
		PhotonNetwork.networkingPeer.OpCustomWithArgs(137, new object[] { gameInvitation_0.mId });
	}

	// Token: 0x06001642 RID: 5698 RVA: 0x0007B940 File Offset: 0x00079B40
	private void OnAcceptGameInvitationResponse(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (operationResponse == 0 && parameters != null && parameters.ContainsKey(0))
		{
			MonoSingleton<AppManager>.Instance.m_playlistId = (int)parameters[1];
			DebugUtils.Log(LogCategory.Network, "GameInvitationService.OnAcceptGameInvitationResponse - playlistId: " + MonoSingleton<AppManager>.Instance.m_playlistId);
			MonoSingleton<GameFlowManager>.Instance.method_9((string)parameters[0]);
		}
	}

	// Token: 0x06001643 RID: 5699 RVA: 0x000105CB File Offset: 0x0000E7CB
	public void imethod_4(GameInvitation gameInvitation_0)
	{
		OnAccessSingleton<IMessagingService, MessagingService, MessagingServiceOffline>.Prop_0.imethod_4(gameInvitation_0.mId);
	}

	// Token: 0x06001644 RID: 5700 RVA: 0x000105DE File Offset: 0x0000E7DE
	public bool imethod_5(string string_0)
	{
		this.mWaitingOnIsFriendsGameJoinable = true;
		this.mIsFriendsGameJoinable = false;
		PhotonNetwork.networkingPeer.method_2(string_0);
		while (this.mWaitingOnIsFriendsGameJoinable)
		{
		}
		return this.mIsFriendsGameJoinable;
	}

	// Token: 0x06001645 RID: 5701 RVA: 0x00010608 File Offset: 0x0000E808
	public void OnIsFriendsGameJoinable(bool result)
	{
		this.mIsFriendsGameJoinable = result;
		this.mWaitingOnIsFriendsGameJoinable = false;
	}

	// Token: 0x06001646 RID: 5702 RVA: 0x00010618 File Offset: 0x0000E818
	public void imethod_6(string string_0)
	{
		PhotonNetwork.networkingPeer.method_1(string_0);
	}

	// Token: 0x04000F06 RID: 3846
	private List<GameInvitationCallback> mGameInvitationCallbacks;

	// Token: 0x04000F07 RID: 3847
	private bool mWaitingOnIsFriendsGameJoinable;

	// Token: 0x04000F08 RID: 3848
	private bool mIsFriendsGameJoinable;
}
