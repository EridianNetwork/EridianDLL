using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using ExitGames.Client.Photon;
using ns0;
using UnityEngine;

// Token: 0x02000B26 RID: 2854
internal class OnlineServerPeer : PhotonPeer, IPhotonPeerListener
{
	// Token: 0x06004D7D RID: 19837 RVA: 0x00149158 File Offset: 0x00147358
	public OnlineServerPeer(IPhotonPeerListener iphotonPeerListener_0, ConnectionProtocol connectionProtocol_0)
		: base(iphotonPeerListener_0, connectionProtocol_0)
	{
		base.Listener = this;
		this.externalListener = iphotonPeerListener_0;
		this.OnlineServerAddr = null;
		this.mIsAuthenticated = false;
		this.mOnlineCallQueue = new Queue<OnlineServerPeer.OnlineCallParameters>();
		this.mOperationResponseCallbacks = new Dictionary<byte, OperationResponseCallback>();
		this.mEventCallbacks = new Dictionary<byte, EventCallback>();
	}

	// Token: 0x06004D7E RID: 19838 RVA: 0x00032479 File Offset: 0x00030679
	private void Reset()
	{
		this.OnlineServerAddr = null;
		this.mIsAuthenticated = false;
	}

	// Token: 0x170007C7 RID: 1991
	// (get) Token: 0x06004D7F RID: 19839 RVA: 0x00032489 File Offset: 0x00030689
	// (set) Token: 0x06004D80 RID: 19840 RVA: 0x00032491 File Offset: 0x00030691
	public PeerState State { get; internal set; }

	// Token: 0x170007C8 RID: 1992
	// (get) Token: 0x06004D81 RID: 19841 RVA: 0x0003249A File Offset: 0x0003069A
	// (set) Token: 0x06004D82 RID: 19842 RVA: 0x000324A2 File Offset: 0x000306A2
	public bool mIsAuthenticated { get; private set; }

	// Token: 0x170007C9 RID: 1993
	// (get) Token: 0x06004D83 RID: 19843 RVA: 0x000324AB File Offset: 0x000306AB
	// (set) Token: 0x06004D84 RID: 19844 RVA: 0x000324B3 File Offset: 0x000306B3
	public string OnlineServerAddr { get; internal set; }

	// Token: 0x06004D85 RID: 19845 RVA: 0x000324BC File Offset: 0x000306BC
	public void DebugReturn(DebugLevel level, string message)
	{
		if (this.externalListener != null)
		{
			this.externalListener.DebugReturn(level, message);
		}
	}

	// Token: 0x06004D86 RID: 19846 RVA: 0x001491AC File Offset: 0x001473AC
	public void method_0(string string_0, string string_1, string string_2 = "", string string_3 = "")
	{
		if (this.OnlineServerAddr != null)
		{
			this.mAppVersion = string_1;
			this.mAppId = string_0;
			this.maccount = string_2;
			this.mpwd = string_3;
			DebugUtils.Log(LogCategory.Network, "Connect to online server: " + this.OnlineServerAddr.ToString());
			base.Connect(this.OnlineServerAddr, "Online");
			return;
		}
		DebugUtils.LogError(LogCategory.Network, "No online server available!");
	}

	// Token: 0x06004D87 RID: 19847 RVA: 0x0014921C File Offset: 0x0014741C
	public bool method_1(string string_0, string string_1, string string_2, string string_3)
	{
		if (base.DebugOut >= DebugLevel.INFO)
		{
			base.Listener.DebugReturn(DebugLevel.INFO, "OpAuthenticate()");
		}
		this.mOnlineCallQueue.Enqueue(new OnlineServerPeer.OnlineCallParameters
		{
			mOperationCode = 230
		});
		Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
		dictionary[220] = string_1;
		dictionary[224] = string_0;
		dictionary[105] = 2;
		dictionary[110] = OnlineService.s_accountId;
		dictionary[221] = this.mToken;
		dictionary[103] = this.method_2();
		return this.OpCustom(230, dictionary, true, 0, base.IsEncryptionAvailable);
	}

	// Token: 0x06004D88 RID: 19848 RVA: 0x0000311D File Offset: 0x0000131D
	public int method_2()
	{
		return 0;
	}

	// Token: 0x06004D89 RID: 19849 RVA: 0x001492DC File Offset: 0x001474DC
	public bool method_3(byte byte_0, params object[] object_0)
	{
		bool flag = true;
		if (this.State == global::PeerState.Connected)
		{
			if (this.mOnlineCallQueue.Count == 0)
			{
				flag = this.OpCustom(byte_0, new Dictionary<byte, object> { { 112, object_0 } }, true);
			}
			if (flag)
			{
				this.mOnlineCallQueue.Enqueue(new OnlineServerPeer.OnlineCallParameters
				{
					mOperationCode = byte_0,
					mParameters = object_0
				});
			}
		}
		return flag;
	}

	// Token: 0x06004D8A RID: 19850 RVA: 0x000324D3 File Offset: 0x000306D3
	public void method_4(string string_0)
	{
		this.OnlineServerAddr = string_0;
	}

	// Token: 0x06004D8B RID: 19851 RVA: 0x00149340 File Offset: 0x00147540
	public void OnOperationResponse(OperationResponse operationResponse)
	{
		DebugUtils.Log(LogCategory.Network, "[DIAG] OnOperationResponse ENTRY code=" + operationResponse.OperationCode.ToString() + " returnCode=" + operationResponse.ReturnCode.ToString());
		OnlineServerPeer.OnlineCallParameters onlineCallParameters = this.mOnlineCallQueue.Dequeue();
		if (onlineCallParameters.mOperationCode != operationResponse.OperationCode && base.DebugOut >= DebugLevel.ERROR)
		{
			this.DebugReturn(DebugLevel.ERROR, string.Format("Unexpected operation response from server: {0}  Was expecting: {1}", operationResponse.ToString(), onlineCallParameters.mOperationCode));
		}
		if (this.mOnlineCallQueue.Count >= 1)
		{
			OnlineServerPeer.OnlineCallParameters onlineCallParameters2 = this.mOnlineCallQueue.Peek();
			this.OpCustom(onlineCallParameters2.mOperationCode, new Dictionary<byte, object> { { 112, onlineCallParameters2.mParameters } }, true);
		}
		if (operationResponse.ReturnCode != 0 && operationResponse.OperationCode != 82)
		{
			this.DebugReturn(DebugLevel.ERROR, string.Format("Operation {0} returned error code {1}: {2}", operationResponse.OperationCode, operationResponse.ReturnCode, operationResponse.DebugMessage));
		}
		if (operationResponse.OperationCode == 230)
		{
			this.mIsAuthenticated = true;
			if (operationResponse.ReturnCode != 0)
			{
				if (base.DebugOut >= DebugLevel.ERROR)
				{
					this.DebugReturn(DebugLevel.ERROR, string.Format("Authentication failed: '{0}' Code: {1}", operationResponse.DebugMessage, operationResponse.ReturnCode));
				}
				if (operationResponse.ReturnCode == -2)
				{
					this.DebugReturn(DebugLevel.ERROR, string.Format("If you host Photon yourself, make sure to start the 'Instance LoadBalancing'", new object[0]));
				}
				if (operationResponse.ReturnCode == 32767)
				{
					this.DebugReturn(DebugLevel.ERROR, string.Format("The appId this client sent is unknown on the server (Cloud). Check settings. If using the Cloud, check account.", new object[0]));
				}
				this.mAuthFailurePending = true;
				this.SuppressNextDisconnectPopup();
				this.Disconnect();
				this.State = global::PeerState.Disconnecting;
				if (operationResponse.ReturnCode == 32757)
				{
					this.DebugReturn(DebugLevel.ERROR, string.Format("Currently, the limit of users is reached for Disconnecting", new object[0]));
				}
				else if (operationResponse.ReturnCode == 32756)
				{
					this.DebugReturn(DebugLevel.ERROR, string.Format("The used master server address is not available with the subscription currently used. Got to Photon Cloud Dashboard or change URL. Disconnecting", new object[0]));
				}
			}
			if (operationResponse.Parameters != null && operationResponse.Parameters.ContainsKey(0))
			{
				OnlineService.s_accountId = (int)operationResponse.Parameters[0];
				PhotonNetwork.player.method_2(new Hashtable { 
				{
					"AccountId",
					OnlineService.s_accountId
				} });
			}
		}
		if (this.mOperationResponseCallbacks.ContainsKey(operationResponse.OperationCode))
		{
			this.mOperationResponseCallbacks[operationResponse.OperationCode](operationResponse.ReturnCode, operationResponse.Parameters);
		}
	}

	// Token: 0x06004D8C RID: 19852 RVA: 0x000324DC File Offset: 0x000306DC
	public override void Disconnect()
	{
		if (base.PeerState == PeerStateValue.Disconnected)
		{
			if (base.DebugOut >= DebugLevel.WARNING)
			{
				this.DebugReturn(DebugLevel.WARNING, string.Format("Can't execute Online Disconnect() while not connected. Nothing changed. State: {0}", this.State));
			}
			return;
		}
		base.Disconnect();
		this.State = global::PeerState.Disconnecting;
	}

	// Token: 0x06004D8D RID: 19853 RVA: 0x001495B4 File Offset: 0x001477B4
	public void OnStatusChanged(StatusCode statusCode)
	{
		DebugLevel debugOut = base.DebugOut;
		switch (statusCode)
		{
		case StatusCode.Connect:
			this.State = global::PeerState.Connected;
			base.EstablishEncryption();
			return;
		case StatusCode.Disconnect:
			this.Reset();
			this.State = global::PeerState.PeerCreated;
			this.DebugReturn(DebugLevel.WARNING, string.Format("OnStatusChanged: {0}", statusCode.ToString()));
			global::UnityEngine.Debug.LogError(Time.time.ToString() + " Disconnected from server:" + statusCode.ToString());
			MonoSingleton<DebugInfoManager>.Instance.method_3();
			if (this.mAuthFailurePending)
			{
				this.mAuthFailurePending = false;
				this.SuppressNextDisconnectPopup();
			}
			PhotonNetwork.networkingPeer.Disconnect();
			return;
		case StatusCode.QueueOutgoingReliableWarning:
		case StatusCode.QueueOutgoingUnreliableWarning:
		case StatusCode.SendError:
		case StatusCode.QueueOutgoingAcksWarning:
		case StatusCode.QueueSentWarning:
			return;
		case StatusCode.InternalReceiveException:
		case StatusCode.TimeoutDisconnect:
		case StatusCode.DisconnectByServer:
		case StatusCode.DisconnectByServerUserLimit:
		case StatusCode.DisconnectByServerLogic:
			if (this.State == global::PeerState.Connecting)
			{
				this.DebugReturn(DebugLevel.WARNING, string.Concat(new object[] { statusCode, " while connecting to: ", base.ServerAddress, ". Check if the server is available." }));
				this.State = global::PeerState.PeerCreated;
			}
			else
			{
				this.State = global::PeerState.PeerCreated;
			}
			global::UnityEngine.Debug.LogError(Time.time.ToString() + " Disconnected from server:" + statusCode.ToString());
			MonoSingleton<DebugInfoManager>.Instance.method_3();
			this.Disconnect();
			return;
		case StatusCode.EncryptionEstablished:
			if (!this.method_1(this.mAppId, this.mAppVersion, this.maccount, this.mpwd))
			{
				this.externalListener.DebugReturn(DebugLevel.ERROR, "Error Authenticating! Did not work.");
				return;
			}
			return;
		case StatusCode.EncryptionFailedToEstablish:
			this.externalListener.DebugReturn(DebugLevel.ERROR, "Encryption wasn't established: " + statusCode.ToString() + ". Going to authenticate anyways.");
			if (!this.method_1(this.mAppId, this.mAppVersion, this.maccount, this.mpwd))
			{
				this.externalListener.DebugReturn(DebugLevel.ERROR, "Error Authenticating! Did not work.");
				return;
			}
			return;
		}
		DebugUtils.Log(LogCategory.Network, "CommandBufferSize is " + base.CommandBufferSize.ToString());
	}

	// Token: 0x06004D8E RID: 19854 RVA: 0x0003251A File Offset: 0x0003071A
	public bool method_5(byte byte_0, OperationResponseCallback operationResponseCallback_0)
	{
		if (this.mOperationResponseCallbacks.ContainsKey(byte_0))
		{
			return false;
		}
		this.mOperationResponseCallbacks[byte_0] = operationResponseCallback_0;
		return true;
	}

	// Token: 0x06004D8F RID: 19855 RVA: 0x0003253A File Offset: 0x0003073A
	public void method_6(byte byte_0)
	{
		this.mOperationResponseCallbacks.Remove(byte_0);
	}

	// Token: 0x06004D90 RID: 19856 RVA: 0x00032549 File Offset: 0x00030749
	public void method_7(byte byte_0, EventCallback eventCallback_0)
	{
		if (this.mEventCallbacks.ContainsKey(byte_0))
		{
			throw new ArgumentException(string.Format("RegisterEventCallback: Already registered a callback for event code {0}", byte_0), "eventCode");
		}
		this.mEventCallbacks[byte_0] = eventCallback_0;
	}

	// Token: 0x06004D91 RID: 19857 RVA: 0x00032581 File Offset: 0x00030781
	public void method_8(byte byte_0)
	{
		this.mEventCallbacks.Remove(byte_0);
	}

	// Token: 0x06004D92 RID: 19858 RVA: 0x00032590 File Offset: 0x00030790
	public void OnEvent(EventData eventData)
	{
		if (this.mEventCallbacks.ContainsKey(eventData.Code))
		{
			this.mEventCallbacks[eventData.Code](eventData.Parameters);
		}
	}

	// Token: 0x06004D93 RID: 19859 RVA: 0x00149808 File Offset: 0x00147A08
	private void SuppressNextDisconnectPopup()
	{
		try
		{
			NetworkManager component = MonoSingleton<AppManager>.Instance.GetComponent<NetworkManager>();
			if (component != null)
			{
				component.SuppressNextDisconnectPopup(true);
			}
		}
		catch (Exception ex)
		{
			DebugUtils.LogError(LogCategory.Network, "[DIAG] SuppressNextDisconnectPopup EXCEPTION: " + ex.ToString());
		}
	}

	// Token: 0x04003A06 RID: 14854
	public IPhotonPeerListener externalListener;

	// Token: 0x04003A07 RID: 14855
	public string mAppVersion;

	// Token: 0x04003A08 RID: 14856
	private string mAppId;

	// Token: 0x04003A09 RID: 14857
	public string maccount;

	// Token: 0x04003A0A RID: 14858
	public string mpwd;

	// Token: 0x04003A0B RID: 14859
	public string mToken;

	// Token: 0x04003A0C RID: 14860
	private Queue<OnlineServerPeer.OnlineCallParameters> mOnlineCallQueue;

	// Token: 0x04003A0D RID: 14861
	private Dictionary<byte, OperationResponseCallback> mOperationResponseCallbacks;

	// Token: 0x04003A0E RID: 14862
	private Dictionary<byte, EventCallback> mEventCallbacks;

	// Token: 0x04003A12 RID: 14866
	private bool mAuthFailurePending;

	// Token: 0x02000B27 RID: 2855
	private struct OnlineCallParameters
	{
		// Token: 0x04003A13 RID: 14867
		public byte mOperationCode;

		// Token: 0x04003A14 RID: 14868
		public object[] mParameters;
	}
}
