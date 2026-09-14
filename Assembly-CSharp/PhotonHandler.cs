using System;
using System.Collections;
using System.Threading;
using Core;
using ExitGames.Client.Photon;
using ns0;
using Photon;
using UnityEngine;

// Token: 0x02000B30 RID: 2864
internal class PhotonHandler : global::Photon.MonoBehaviour, IPhotonPeerListener
{
	// Token: 0x06004DB3 RID: 19891 RVA: 0x00149CD4 File Offset: 0x00147ED4
	private void Awake()
	{
		if (PhotonHandler.SP != null && PhotonHandler.SP != this && PhotonHandler.SP.gameObject != null)
		{
			global::UnityEngine.Object.DestroyImmediate(PhotonHandler.SP.gameObject);
		}
		PhotonHandler.SP = this;
		global::UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		this.updateInterval = 1000 / PhotonNetwork.sendRate;
		this.updateIntervalOnSerialize = 1000 / PhotonNetwork.sendRateOnSerialize;
		this.startTimeStamp = DateTime.Now;
	}

	// Token: 0x06004DB4 RID: 19892 RVA: 0x00149D5C File Offset: 0x00147F5C
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
				int num = (int)(DateTime.Now - this.startTimeStamp).TotalMilliseconds;
				if (num > this.nextSendTickCountOnSerialize)
				{
					this.nextSendTickCountOnSerialize = num / this.updateIntervalOnSerialize * this.updateIntervalOnSerialize + this.updateIntervalOnSerialize;
					PhotonNetwork.networkingPeer.method_64();
					this.nextSendTickCount = 0;
				}
				if (num > this.nextSendTickCount)
				{
					this.nextSendTickCount = num / this.updateInterval * this.updateInterval + this.updateInterval;
					bool flag = true;
					double num2 = (double)Time.realtimeSinceStartup;
					while (flag && (double)Time.realtimeSinceStartup - num2 <= 0.003)
					{
						flag = PhotonNetwork.networkingPeer.SendOutgoingCommands();
					}
				}
				return;
			}
		}
	}

	// Token: 0x06004DB5 RID: 19893 RVA: 0x00149E38 File Offset: 0x00148038
	private void Update()
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
				if (MonoSingleton<Session>.Instance != null && !MonoSingleton<Session>.Instance.method_16())
				{
					PhotonNetwork.networkingPeer.method_70();
				}
				PhotonNetwork.networkingPeer.method_63();
				return;
			}
		}
	}

	// Token: 0x06004DB6 RID: 19894 RVA: 0x00149EA4 File Offset: 0x001480A4
	private void LateUpdate()
	{
		bool flag = true;
		while (flag)
		{
			flag = PhotonNetwork.networkingPeer.SendOutgoingCommands();
		}
	}

	// Token: 0x06004DB7 RID: 19895 RVA: 0x00032714 File Offset: 0x00030914
	protected void OnApplicationQuit()
	{
		if (!AppManager.s_allowQuit)
		{
			return;
		}
		PhotonNetwork.Disconnect();
	}

	// Token: 0x06004DB8 RID: 19896 RVA: 0x00032723 File Offset: 0x00030923
	protected void OnLevelWasLoaded(int level)
	{
		PhotonNetwork.networkingPeer.method_62();
		if (PhotonNetwork.automaticallySyncScene)
		{
			this.method_0();
		}
	}

	// Token: 0x06004DB9 RID: 19897 RVA: 0x0003273C File Offset: 0x0003093C
	protected void OnJoinedRoom()
	{
		PhotonNetwork.networkingPeer.AutomaticallySyncScene();
	}

	// Token: 0x06004DBA RID: 19898 RVA: 0x00032748 File Offset: 0x00030948
	protected void OnCreatedRoom()
	{
		if (PhotonNetwork.automaticallySyncScene)
		{
			this.method_0();
		}
	}

	// Token: 0x06004DBB RID: 19899 RVA: 0x00149EC4 File Offset: 0x001480C4
	protected internal void method_0()
	{
		if (PhotonNetwork.isMasterClient)
		{
			Hashtable hashtable = new Hashtable();
			hashtable["curScn"] = Application.loadedLevelName;
			PhotonNetwork.room.method_1(hashtable);
		}
	}

	// Token: 0x06004DBC RID: 19900 RVA: 0x0000311B File Offset: 0x0000131B
	public static void smethod_0()
	{
	}

	// Token: 0x06004DBD RID: 19901 RVA: 0x00032757 File Offset: 0x00030957
	public static void smethod_1()
	{
		while (PhotonNetwork.networkingPeer != null && PhotonNetwork.networkingPeer.IsSendingOnlyAcks)
		{
			while (PhotonNetwork.networkingPeer.SendAcksOnly())
			{
			}
			Thread.Sleep(50);
		}
	}

	// Token: 0x06004DBE RID: 19902 RVA: 0x00149104 File Offset: 0x00147304
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

	// Token: 0x06004DBF RID: 19903 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnOperationResponse(OperationResponse operationResponse)
	{
	}

	// Token: 0x06004DC0 RID: 19904 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnStatusChanged(StatusCode statusCode)
	{
	}

	// Token: 0x06004DC1 RID: 19905 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnEvent(EventData photonEvent)
	{
	}

	// Token: 0x04003A32 RID: 14898
	public static PhotonHandler SP;

	// Token: 0x04003A33 RID: 14899
	public int updateInterval;

	// Token: 0x04003A34 RID: 14900
	public int updateIntervalOnSerialize;

	// Token: 0x04003A35 RID: 14901
	private int nextSendTickCount;

	// Token: 0x04003A36 RID: 14902
	private int nextSendTickCountOnSerialize;

	// Token: 0x04003A37 RID: 14903
	private DateTime startTimeStamp;
}
