using System;
using Core;
using ExitGames.Client.Photon;
using Photon;
using UnityEngine;

// Token: 0x02000B25 RID: 2853
internal class OnlinePeerHandler : global::Photon.MonoBehaviour, IPhotonPeerListener
{
	// Token: 0x06004D76 RID: 19830 RVA: 0x00149004 File Offset: 0x00147204
	private void Awake()
	{
		if (OnlinePeerHandler.SP != null && OnlinePeerHandler.SP != this && OnlinePeerHandler.SP.gameObject != null)
		{
			global::UnityEngine.Object.DestroyImmediate(OnlinePeerHandler.SP.gameObject);
		}
		OnlinePeerHandler.SP = this;
		global::UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
	}

	// Token: 0x06004D77 RID: 19831 RVA: 0x0003245E File Offset: 0x0003065E
	private void Update()
	{
		if (PhotonNetwork.onlinePeer.State == PeerState.Disconnected)
		{
			return;
		}
		PhotonNetwork.onlinePeer.Service();
	}

	// Token: 0x06004D78 RID: 19832 RVA: 0x00149060 File Offset: 0x00147260
	public void OnConnectedToMaster(string serveraddr)
	{
		if (serveraddr != string.Empty)
		{
			DebugUtils.Log(LogCategory.Network, serveraddr);
			DebugUtils.Log(LogCategory.Network, PhotonNetwork.onlinePeer.State.ToString());
			if (PhotonNetwork.onlinePeer.State == PeerState.Disconnected || PhotonNetwork.onlinePeer.State == PeerState.PeerCreated || PhotonNetwork.onlinePeer.State == PeerState.Uninitialized)
			{
				PhotonNetwork.onlinePeer.method_4(serveraddr);
				PhotonNetwork.onlinePeer.method_0(PhotonNetwork.networkingPeer.mAppId, PhotonNetwork.networkingPeer.mAppVersion, PhotonNetwork.networkingPeer.maccount, PhotonNetwork.networkingPeer.mpwd);
			}
		}
	}

	// Token: 0x06004D79 RID: 19833 RVA: 0x00149104 File Offset: 0x00147304
	public void DebugReturn(DebugLevel level, string message)
	{
		if (level == DebugLevel.ERROR)
		{
			DebugUtils.LogError(LogCategory.Network, message);
		}
		else if (level == DebugLevel.WARNING)
		{
			DebugUtils.LogWarning(LogCategory.Network, message);
		}
		else if (level == DebugLevel.INFO && PhotonNetwork.logLevel >= PhotonLogLevel.Informational)
		{
			DebugUtils.Log(LogCategory.Network, message);
		}
		else if (level == DebugLevel.ALL && PhotonNetwork.logLevel == PhotonLogLevel.Full)
		{
			DebugUtils.Log(LogCategory.Network, message);
		}
	}

	// Token: 0x06004D7A RID: 19834 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnOperationResponse(OperationResponse operationResponse)
	{
	}

	// Token: 0x06004D7B RID: 19835 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnStatusChanged(StatusCode statusCode)
	{
	}

	// Token: 0x06004D7C RID: 19836 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnEvent(EventData photonEvent)
	{
	}

	// Token: 0x04003A05 RID: 14853
	private static OnlinePeerHandler SP;
}
