using System;
using Core;
using ExitGames.Client.Photon;
using Photon;
using UnityEngine;

// Token: 0x02000B34 RID: 2868
internal class PhotonRecvHandler : global::Photon.MonoBehaviour, IPhotonPeerListener
{
	// Token: 0x06004E37 RID: 20023 RVA: 0x0014B1F4 File Offset: 0x001493F4
	private void Awake()
	{
		if (PhotonRecvHandler.SP != null && PhotonRecvHandler.SP != this && PhotonRecvHandler.SP.gameObject != null)
		{
			global::UnityEngine.Object.DestroyImmediate(PhotonRecvHandler.SP.gameObject);
		}
		PhotonRecvHandler.SP = this;
		global::UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
	}

	// Token: 0x06004E38 RID: 20024 RVA: 0x0014B250 File Offset: 0x00149450
	private void FixedUpdate()
	{
		if (PhotonNetwork.networkingPeer == null)
		{
			DebugUtils.LogError(LogCategory.Network, "NetworkPeer broke!");
			return;
		}
		if (PhotonNetwork.connectionStateDetailed != PeerState.PeerCreated)
		{
			if (PhotonNetwork.connectionStateDetailed != PeerState.Disconnected)
			{
				if (!PhotonNetwork.isMessageQueueRunning)
				{
					return;
				}
				bool flag = true;
				while (PhotonNetwork.isMessageQueueRunning && flag)
				{
					flag = PhotonNetwork.networkingPeer.DispatchIncomingCommands();
				}
				return;
			}
		}
	}

	// Token: 0x06004E39 RID: 20025 RVA: 0x00149104 File Offset: 0x00147304
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

	// Token: 0x06004E3A RID: 20026 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnOperationResponse(OperationResponse operationResponse)
	{
	}

	// Token: 0x06004E3B RID: 20027 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnStatusChanged(StatusCode statusCode)
	{
	}

	// Token: 0x06004E3C RID: 20028 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnEvent(EventData photonEvent)
	{
	}

	// Token: 0x04003A5A RID: 14938
	public static PhotonRecvHandler SP;
}
