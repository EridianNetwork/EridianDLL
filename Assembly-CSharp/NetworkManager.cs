using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Core;
using ns0;
using Photon;
using UnityEngine;
using XsdSettings;

// Token: 0x02000AC1 RID: 2753
public class NetworkManager : global::Photon.MonoBehaviour
{
	// Token: 0x06004AB9 RID: 19129 RVA: 0x00030D33 File Offset: 0x0002EF33
	public void method_0(INetworkManagerListener inetworkManagerListener_0)
	{
		this.m_notificationListeners.Add(inetworkManagerListener_0);
	}

	// Token: 0x06004ABA RID: 19130 RVA: 0x00030D41 File Offset: 0x0002EF41
	public void method_1(INetworkManagerListener inetworkManagerListener_0)
	{
		if (this.m_notificationListeners.Contains(inetworkManagerListener_0))
		{
			this.m_notificationListeners.Remove(inetworkManagerListener_0);
		}
	}

	// Token: 0x06004ABB RID: 19131 RVA: 0x00030D5E File Offset: 0x0002EF5E
	public void method_2(NetworkManager.NetworkObserver networkObserver_0)
	{
		this.m_observers.Add(networkObserver_0);
	}

	// Token: 0x06004ABC RID: 19132 RVA: 0x00030D6C File Offset: 0x0002EF6C
	public void method_3(NetworkManager.NetworkObserver networkObserver_0)
	{
		this.m_observers.Remove(networkObserver_0);
	}

	// Token: 0x17000789 RID: 1929
	// (get) Token: 0x06004ABD RID: 19133 RVA: 0x00030D7B File Offset: 0x0002EF7B
	public List<BadAssNetworkView> List_0
	{
		get
		{
			return this.m_networkViews;
		}
	}

	// Token: 0x1700078A RID: 1930
	// (get) Token: 0x06004ABE RID: 19134 RVA: 0x00030D83 File Offset: 0x0002EF83
	public static NetworkManager NetworkManager_0
	{
		get
		{
			return NetworkManager.s_instance;
		}
	}

	// Token: 0x06004ABF RID: 19135 RVA: 0x00030D8A File Offset: 0x0002EF8A
	private void Awake()
	{
		BolCustomType.smethod_1();
		this.m_networkViews = new List<BadAssNetworkView>();
		if (NetworkManager.s_instance != null)
		{
			DebugUtils.LogError(LogCategory.Network, "NetworkManager is already initialized");
		}
		NetworkManager.s_instance = this;
	}

	// Token: 0x06004AC0 RID: 19136 RVA: 0x00030DBB File Offset: 0x0002EFBB
	private void Start()
	{
		OnAccessSingleton<IChatService, ChatService, ChatServiceOffline>.Prop_0.imethod_0();
		OnAccessSingleton<IMailService, MailService, MailServiceOffline>.Prop_0.imethod_0();
	}

	// Token: 0x06004AC1 RID: 19137 RVA: 0x001370A0 File Offset: 0x001352A0
	private void Update()
	{
		if (MonoSingleton<AppManager>.Instance.m_logNetworkProfile && PhotonNetwork.NetworkStatisticsEnabled && Time.frameCount % 100 == 0)
		{
			DebugUtils.Log(LogCategory.Profile, "TrafficStatsOutgoing.TotalCommandBytes:" + (float)PhotonNetwork.networkingPeer.TrafficStatsOutgoing.TotalCommandBytes / (float)(PhotonNetwork.networkingPeer.TrafficStatsElapsedMs / 1000L));
			DebugUtils.Log(LogCategory.Profile, "TrafficStatsIncoming.TotalCommandBytes:" + (float)PhotonNetwork.networkingPeer.TrafficStatsIncoming.TotalCommandBytes / (float)(PhotonNetwork.networkingPeer.TrafficStatsElapsedMs / 1000L));
		}
		if (this.m_PriorityInspectorPlayerIndex < PhotonNetwork.playerList.Length)
		{
			NetworkingPriority.NetworkingPriority_0.priorityInspector = PhotonNetwork.playerList[this.m_PriorityInspectorPlayerIndex];
		}
		PhotonNetwork.BandwidthCap = MonoSingleton<AppManager>.Instance.BandwidthCap;
		this.m_PriorityInspectorPlayerIndex = MonoSingleton<AppManager>.Instance.PriorityInspector;
	}

	// Token: 0x06004AC2 RID: 19138 RVA: 0x00030DD1 File Offset: 0x0002EFD1
	public void method_4(BadAssNetworkView badAssNetworkView_0)
	{
		this.m_networkViews.Add(badAssNetworkView_0);
	}

	// Token: 0x06004AC3 RID: 19139 RVA: 0x00030DDF File Offset: 0x0002EFDF
	public void method_5(BadAssNetworkView badAssNetworkView_0)
	{
		this.m_networkViews.Remove(badAssNetworkView_0);
	}

	// Token: 0x06004AC4 RID: 19140 RVA: 0x00030DEE File Offset: 0x0002EFEE
	public static int GetActorId()
	{
		return PhotonNetwork.player.ActorId;
	}

	// Token: 0x06004AC5 RID: 19141 RVA: 0x0013718C File Offset: 0x0013538C
	private static void smethod_1()
	{
		PhotonNetwork.onlinePeer.method_7(158, new EventCallback(NetworkManager.NetworkManager_0.OnGPKDynCodeEvent));
		PhotonNetwork.onlinePeer.method_7(157, new EventCallback(NetworkManager.NetworkManager_0.OnGPKAuthDataEvent));
		PhotonNetwork.onlinePeer.method_5(62, new OperationResponseCallback(NetworkManager.NetworkManager_0.OnGPKAuthReplyResponse));
	}

	// Token: 0x06004AC6 RID: 19142 RVA: 0x00030DFA File Offset: 0x0002EFFA
	private static void smethod_2()
	{
		PhotonNetwork.onlinePeer.method_6(62);
		PhotonNetwork.onlinePeer.method_8(157);
		PhotonNetwork.onlinePeer.method_8(158);
	}

	// Token: 0x06004AC7 RID: 19143 RVA: 0x001371F4 File Offset: 0x001353F4
	private void OnDisconnectedFromPhoton()
	{
		NetworkManager.smethod_2();
		OnAccessSingleton<IAnnouncementService, AnnouncementService, AnnouncementServiceOffline>.Prop_0.imethod_1(new OnAnnouncements(this.OnAnnouncements));
		NetworkManager.m_isDisconnected = true;
		DebugUtils.Log(LogCategory.Network, "OnDisconnectedFromPhoton from Photon." + Time.realtimeSinceStartup.ToString());
		for (int i = 0; i < this.m_notificationListeners.Count; i++)
		{
			this.m_notificationListeners[i].OnDisconnectedFromPhoton();
		}
		if (this.m_suppressDisconnectPopup)
		{
			this.m_suppressDisconnectPopup = false;
			DebugUtils.Log(LogCategory.Network, "[DIAG] OnDisconnectedFromPhoton: popup suppressed");
			return;
		}
		if (MonoSingleton<AppManager>.Instance.m_autoTestCase.Contains("stress"))
		{
			MonoSingleton<AppManager>.Instance.method_8();
			return;
		}
		if (!MonoSingleton<AppManager>.Instance.method_9())
		{
			GameUIManager gameUIManager = MonoSingleton<AppManager>.Instance.method_0();
			MonoSingleton<GameFlowManager>.Instance.method_18();
			MonoSingleton<AppManager>.Instance.method_1(true);
			gameUIManager.vmethod_10(true);
			MonoSingleton<InputManager>.Instance.method_2(false);
			LocalizedString localizedString = new LocalizedString("Disconnected_Confirmation");
			gameUIManager.vmethod_5<HUDWarningView>().vmethod_7(LocalizedString.smethod_0(localizedString), new Delegate_EventProc(this.method_6), null);
		}
	}

	// Token: 0x06004AC8 RID: 19144 RVA: 0x0000C515 File Offset: 0x0000A715
	private void method_6()
	{
		AppManager.s_allowQuit = true;
		Application.Quit();
	}

	// Token: 0x06004AC9 RID: 19145 RVA: 0x0013730C File Offset: 0x0013550C
	private void OnConnectionFail(object parameters)
	{
		DebugUtils.LogError(LogCategory.Network, string.Concat(new object[]
		{
			"OnConnectionFail from Photon. StatusCode: ",
			parameters,
			"-",
			Time.realtimeSinceStartup
		}));
		if (MonoSingleton<AppManager>.Instance.m_autoTestCase.Contains("stress"))
		{
			MonoSingleton<AppManager>.Instance.method_8();
			return;
		}
	}

	// Token: 0x06004ACA RID: 19146 RVA: 0x00137370 File Offset: 0x00135570
	private void OnFailedToConnectToPhoton(object parameters)
	{
		DebugUtils.LogError(LogCategory.Network, string.Concat(new object[]
		{
			"OnFailedToConnectToPhoton from photon. StatusCode: ",
			parameters,
			"-",
			Time.realtimeSinceStartup
		}));
		if (MonoSingleton<AppManager>.Instance.m_enableSndaLogin)
		{
			MonoSingleton<AppManager>.Instance.method_8();
		}
		else
		{
			if (MonoSingleton<AppManager>.Instance.m_autoTestCase.Contains("stress"))
			{
				MonoSingleton<AppManager>.Instance.method_8();
				return;
			}
			MonoSingleton<AppManager>.Instance.method_8();
		}
	}

	// Token: 0x06004ACB RID: 19147 RVA: 0x00030E26 File Offset: 0x0002F026
	private void OnConnectedToPhoton()
	{
		OnAccessSingleton<IAnnouncementService, AnnouncementService, AnnouncementServiceOffline>.Prop_0.imethod_0(new OnAnnouncements(this.OnAnnouncements));
		NetworkManager.m_isDisconnected = false;
	}

	// Token: 0x06004ACC RID: 19148 RVA: 0x00030E44 File Offset: 0x0002F044
	private void OnReceivedRoomListUpdate()
	{
		DebugUtils.Log(LogCategory.Network, "OnReceivedRoomListUpdate" + Time.realtimeSinceStartup);
	}

	// Token: 0x06004ACD RID: 19149 RVA: 0x001373F4 File Offset: 0x001355F4
	private void OnJoinedRoom()
	{
		DebugUtils.Log(LogCategory.Network, "OnJoinedRoom" + Time.realtimeSinceStartup);
		PhotonNetwork.NetworkStatisticsReset();
		for (int i = 0; i < this.m_notificationListeners.Count; i++)
		{
			this.m_notificationListeners[i].OnJoinedRoom();
		}
	}

	// Token: 0x06004ACE RID: 19150 RVA: 0x00137448 File Offset: 0x00135648
	private void OnPhotonJoinRoomFailed()
	{
		for (int i = 0; i < this.m_notificationListeners.Count; i++)
		{
			this.m_notificationListeners[i].OnPhotonJoinRoomFailed();
		}
	}

	// Token: 0x06004ACF RID: 19151 RVA: 0x0013747C File Offset: 0x0013567C
	private void OnPhotonRandomJoinFailed()
	{
		for (int i = 0; i < this.m_notificationListeners.Count; i++)
		{
			this.m_notificationListeners[i].OnPhotonRandomJoinFailed();
		}
	}

	// Token: 0x06004AD0 RID: 19152 RVA: 0x001374B0 File Offset: 0x001356B0
	public IEnumerator method_7()
	{
		PhotonNetwork.Disconnect();
		while (!m_isDisconnected)
		{
			yield return 0;
		}
		while (PhotonNetwork.connectionState != 0)
		{
			yield return 0;
		}
	}
	// Token: 0x06004AD1 RID: 19153 RVA: 0x001374C4 File Offset: 0x001356C4
	public IEnumerator method_8(byte byte_0, params object[] object_0)
	{
		DebugUtils.Log(LogCategory.Network, "OpOnlineCall..." + byte_0 + " - " + Time.time);
		while (!PhotonNetwork.onlinePeer.mIsAuthenticated)
		{
			yield return 0;
		}
		while (mCallInProgress)
		{
			yield return 0;
		}
		while (!PhotonNetwork.onlinePeer.method_5(byte_0, OnOperationResponse))
		{
			yield return 0;
		}
		mCallInProgress = true;
		mCallResultDictionary = null;
		PhotonNetwork.onlinePeer.method_3(byte_0, object_0);
		while (mCallInProgress)
		{
			yield return 0;
		}
		PhotonNetwork.onlinePeer.method_6(byte_0);
		DebugUtils.Log(LogCategory.Network, "...Done (OpOnlineCall)" + Time.realtimeSinceStartup);
	}
	// Token: 0x06004AD2 RID: 19154 RVA: 0x00030E61 File Offset: 0x0002F061
	private void OnOperationResponse(short OperationResponse, Dictionary<byte, object> parameters)
	{
		this.mCallInProgress = false;
		this.mCallResultDictionary = parameters;
	}

	// Token: 0x06004AD3 RID: 19155 RVA: 0x00030E71 File Offset: 0x0002F071
	public Dictionary<byte, object> method_9()
	{
		return this.mCallResultDictionary;
	}

	// Token: 0x06004AD4 RID: 19156 RVA: 0x0000311B File Offset: 0x0000131B
	private void OnLeftLobby()
	{
	}

	// Token: 0x06004AD5 RID: 19157 RVA: 0x00030E79 File Offset: 0x0002F079
	private void OnPhotonCreateRoomFailed()
	{
		MonoSingleton<AppManager>.Instance.method_8();
	}

	// Token: 0x06004AD6 RID: 19158 RVA: 0x001374FC File Offset: 0x001356FC
	private void OnLeftRoom()
	{
		for (int i = 0; i < this.m_notificationListeners.Count; i++)
		{
			this.m_notificationListeners[i].OnLeftRoom();
		}
		Session prop_ = MonoSingleton<Session>.Instance;
		if (prop_)
		{
			if (NetworkManager.smethod_3())
			{
				PhotonNetwork.Destroy(prop_.gameObject);
			}
			else
			{
				global::UnityEngine.Object.Destroy(prop_.gameObject);
			}
		}
		PhotonNetwork.NetworkStatisticsReset();
	}

	// Token: 0x06004AD7 RID: 19159 RVA: 0x0000311B File Offset: 0x0000131B
	public void method_10(GameObject gameObject_0)
	{
	}

	// Token: 0x06004AD8 RID: 19160 RVA: 0x00137564 File Offset: 0x00135764
	private void OnPhotonPlayerDisconnected(PhotonPlayer player)
	{
		DebugUtils.Log(LogCategory.Network, "OnPhotonPlayerDisconnected [" + player.ActorId + "]");
		if (player.String_0.Contains("Host") && !PhotonNetwork.offlineMode)
		{
			PhotonNetwork.LeaveRoom();
		}
	}

	// Token: 0x06004AD9 RID: 19161 RVA: 0x00030E85 File Offset: 0x0002F085
	private void OnActionLoaded()
	{
		DebugUtils.Log(LogCategory.Network, "Loading complete" + Time.realtimeSinceStartup);
	}

	// Token: 0x06004ADA RID: 19162 RVA: 0x00030EA2 File Offset: 0x0002F0A2
	public static bool smethod_3()
	{
		return PhotonNetwork.isMasterClient;
	}

	// Token: 0x06004ADB RID: 19163 RVA: 0x00030EA9 File Offset: 0x0002F0A9
	public static bool smethod_4()
	{
		return NetworkManager.m_isDisconnected;
	}

	// Token: 0x06004ADC RID: 19164 RVA: 0x00030EB0 File Offset: 0x0002F0B0
	public static bool smethod_5()
	{
		return PhotonNetwork.offlineMode;
	}

	// Token: 0x06004ADD RID: 19165 RVA: 0x00030EB7 File Offset: 0x0002F0B7
	public static double smethod_6()
	{
		return PhotonNetwork.time;
	}

	// Token: 0x06004ADE RID: 19166 RVA: 0x00030EBE File Offset: 0x0002F0BE
	public static int smethod_7()
	{
		return PhotonNetwork.GetPing();
	}

	// Token: 0x06004ADF RID: 19167 RVA: 0x00030EC5 File Offset: 0x0002F0C5
	public static float GetPingById(int int_0)
	{
		return PhotonNetwork.GetPingById(int_0);
	}

	// Token: 0x06004AE0 RID: 19168 RVA: 0x00030ECD File Offset: 0x0002F0CD
	public static float smethod_9()
	{
		return PhotonNetwork.smethod_52();
	}

	// Token: 0x06004AE1 RID: 19169 RVA: 0x00030ED4 File Offset: 0x0002F0D4
	public static float smethod_10()
	{
		return 1f / (float)PhotonNetwork.sendRateOnSerialize;
	}

	// Token: 0x06004AE2 RID: 19170 RVA: 0x00030EE2 File Offset: 0x0002F0E2
	public static void smethod_11(GameObject gameObject_0)
	{
		PhotonNetwork.Destroy(gameObject_0);
	}

	// Token: 0x06004AE3 RID: 19171 RVA: 0x00030EEA File Offset: 0x0002F0EA
	public static void smethod_12(Entity entity_0)
	{
		if (entity_0 == null)
		{
			return;
		}
		PhotonNetwork.Destroy(entity_0.gameObject);
	}

	// Token: 0x06004AE4 RID: 19172 RVA: 0x001375B0 File Offset: 0x001357B0
	public void OnAnnouncements(Announcement[] announcement)
	{
		foreach (Announcement announcement2 in announcement)
		{
			string content = announcement2.Content;
			AnnouncementType type = announcement2.Type;
			if (type != AnnouncementType.Event)
			{
				if (type == AnnouncementType.Broadcast)
				{
					MonoSingleton<global::ns0.EchoMessageManager>.Instance.method_3(content, DisplayTarget.Broadcast);
				}
			}
			else
			{
				MonoSingleton<global::ns0.EchoMessageManager>.Instance.method_3(content, DisplayTarget.Event);
			}
			if (!string.IsNullOrEmpty(announcement2.Content))
			{
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<ChatView>().method_8(ChatParameter.System, string.Empty, content, 0, string.Empty);
			}
		}
	}

	// Token: 0x06004AE5 RID: 19173 RVA: 0x00030F01 File Offset: 0x0002F101
	private void OnGPKDynCodeEvent(Dictionary<byte, object> parameters)
	{
		DebugUtils.Log(LogCategory.Network, "NetworkManager.OnGPKDynCodeEvent");
		NetworkManager.s_dynCode = (byte[])parameters[0];
		ShandaWrapper.smethod_0(NetworkManager.s_dynCode);
	}

	// Token: 0x06004AE6 RID: 19174 RVA: 0x00137630 File Offset: 0x00135830
	private void OnGPKAuthDataEvent(Dictionary<byte, object> parameters)
	{
		DebugUtils.Log(LogCategory.Network, "NetworkManager.OnGPKAuthDataEvent");
		byte[] array = (byte[])parameters[0];
		ShandaWrapper.smethod_1(ref array);
		PhotonNetwork.onlinePeer.method_3(62, new object[] { array });
	}

	// Token: 0x06004AE7 RID: 19175 RVA: 0x00030F2A File Offset: 0x0002F12A
	private void OnGPKAuthReplyResponse(short result, Dictionary<byte, object> parameters)
	{
		DebugUtils.Log(LogCategory.Network, "NetworkManager.OnGPKAuthReplyResponse");
	}

	// Token: 0x06004AE8 RID: 19176 RVA: 0x00030F38 File Offset: 0x0002F138
	public void SuppressNextDisconnectPopup(bool suppress)
	{
		this.m_suppressDisconnectPopup = suppress;
	}

	// Token: 0x04003675 RID: 13941
	private static NetworkManager s_instance;

	// Token: 0x04003676 RID: 13942
	private static byte[] s_dynCode;

	// Token: 0x04003677 RID: 13943
	private static bool m_isDisconnected = true;

	// Token: 0x04003678 RID: 13944
	private int m_PriorityInspectorPlayerIndex = 1;

	// Token: 0x04003679 RID: 13945
	private Dictionary<byte, object> mCallResultDictionary;

	// Token: 0x0400367A RID: 13946
	private bool mCallInProgress;

	// Token: 0x0400367B RID: 13947
	private List<INetworkManagerListener> m_notificationListeners = new List<INetworkManagerListener>();

	// Token: 0x0400367C RID: 13948
	private List<NetworkManager.NetworkObserver> m_observers = new List<NetworkManager.NetworkObserver>();

	// Token: 0x0400367D RID: 13949
	private List<BadAssNetworkView> m_networkViews;

	// Token: 0x0400367E RID: 13950
	private bool m_suppressDisconnectPopup;

	// Token: 0x02000AC2 RID: 2754
	public class AuthenticateAsyncTask : PhotonNetworkTask
	{
		// Token: 0x06004AEA RID: 19178 RVA: 0x00030F41 File Offset: 0x0002F141
		public void method_4(string string_0)
		{
			this.float_1 = 30f;
			this.m_login = string_0;
		}

		// Token: 0x06004AEB RID: 19179 RVA: 0x00030F55 File Offset: 0x0002F155
		public void method_5()
		{
			this.float_1 = 30f;
			this.m_login = ShandaWrapper.ShandaTicket;
		}

		// Token: 0x06004AEC RID: 19180 RVA: 0x00137674 File Offset: 0x00135874
		public override void Start()
		{
			DebugUtils.Log(LogCategory.Network, "[DIAG] AuthenticateAsyncTask.Start, PhotonNetwork.connected=" + PhotonNetwork.connected.ToString());
			base.Start();
			if (!PhotonNetwork.connected)
			{
				NetworkManager.smethod_1();
				PhotonNetwork.onlinePeer.method_5(230, new OperationResponseCallback(this.OnAuthenticate));
				PhotonNetwork.Connect(MonoSingleton<OnlineService>.Instance.method_0(), 5055, ShandaWrapper.ApplicationName, MonoSingleton<AppManager>.Instance.m_debugInfo_Version, this.m_login, (this.m_pwd != string.Empty) ? this.m_pwd : "*");
				return;
			}
			DebugUtils.Log(LogCategory.Network, "[DIAG] AuthenticateAsyncTask.Start: already connected, resending OpAuthenticate on the live connection.");
			PhotonNetwork.onlinePeer.method_5(230, new OperationResponseCallback(this.OnAuthenticate));
			PhotonNetwork.networkingPeer.maccount = this.m_login;
			PhotonNetwork.networkingPeer.mpwd = ((this.m_pwd != string.Empty) ? this.m_pwd : "*");
			PhotonNetwork.networkingPeer.vmethod_7(PhotonNetwork.networkingPeer.mAppId, PhotonNetwork.networkingPeer.mAppVersion, PhotonNetwork.networkingPeer.maccount, PhotonNetwork.networkingPeer.mpwd);
		}

		// Token: 0x06004AED RID: 19181 RVA: 0x001377AC File Offset: 0x001359AC
		private void OnAuthenticate(short OperationResponse, Dictionary<byte, object> parameters)
		{
			DebugUtils.Log(LogCategory.Network, "[DIAG] OnAuthenticate FIRED code=" + OperationResponse.ToString());
			PhotonNetwork.onlinePeer.method_6(230);
			if (parameters != null && parameters.ContainsKey(250))
			{
				this.m_failureReason = parameters[250] as string;
			}
			if (OperationResponse == 0)
			{
				base.SetStatus(AsyncTaskStatus.Success);
				return;
			}
			if (OperationResponse == -2)
			{
				base.SetStatus(AsyncTaskStatus.Error_WrongPassword);
				return;
			}
			NetworkManager.smethod_2();
			base.SetStatus(AsyncTaskStatus.Error_AuthenticationFail);
		}

		// Token: 0x06004AEE RID: 19182 RVA: 0x00030F6D File Offset: 0x0002F16D
		public void SetAuth(string username, string password)
		{
			this.m_login = username;
			this.m_pwd = password;
			this.float_1 = 30f;
		}

		// Token: 0x06004AEF RID: 19183 RVA: 0x00030F88 File Offset: 0x0002F188
		public override void vmethod_0()
		{
			PhotonNetwork.onlinePeer.method_6(230);
			base.vmethod_0();
		}

		// Token: 0x0400367F RID: 13951
		private const int m_serverPort = 5055;

		// Token: 0x04003680 RID: 13952
		public string m_login;

		// Token: 0x04003681 RID: 13953
		private string m_pwd;

		// Token: 0x04003682 RID: 13954
		public string m_failureReason;
	}

	// Token: 0x02000AC3 RID: 2755
	public class StressTestAuthenticateAsyncTask : PhotonNetworkTask
	{
		// Token: 0x06004AF1 RID: 19185 RVA: 0x00030FB2 File Offset: 0x0002F1B2
		public void method_4(string string_0)
		{
			this.float_1 = 30f;
			this.m_login = string_0;
		}

		// Token: 0x06004AF2 RID: 19186 RVA: 0x0013782C File Offset: 0x00135A2C
		public override void Start()
		{
			base.Start();
			DebugUtils.Log(LogCategory.Network, "StressTestAuthenticateAsyncTask Start[" + this.m_login + "]");
			string text = string.Concat(new string[] { "https://cas.sdo.com/authen/staticLogin.jsonp?callback=staticLogin_JSONPMethod&inputUserId=", this.m_login, "&password=", this.m_password, "&appId=991002125&areaId=899&serviceUrl=http%3A%2F%2Fwww.sdo.com%2F&productVersion=v5&frameType=3&locale=zh_CN&version=21&tag=20&authenSource=1&productId=2&autoLoginFlag=0&_=1430893783331" });
			DebugUtils.Log(LogCategory.Network, "StressTestAuthenticateAsyncTask Start[" + text + "]");
			this.m_query = new WWW(text);
		}

		// Token: 0x06004AF3 RID: 19187 RVA: 0x001378B4 File Offset: 0x00135AB4
		public override void Update(float time)
		{
			base.Update(time);
			if (this.m_authenticating)
			{
				return;
			}
			if (this.m_ticket == null && this.m_query != null && this.m_query.isDone)
			{
				string text = this.m_query.text;
				DebugUtils.Log(LogCategory.Network, "StressTestAuthenticateAsyncTask response[" + text + "]");
				if (string.IsNullOrEmpty(text))
				{
					base.SetStatus(AsyncTaskStatus.Error);
					return;
				}
				int num = text.IndexOf("\"ticket\":");
				int num2 = text.LastIndexOf("\"");
				if (num < 0 || num2 < 0)
				{
					base.SetStatus(AsyncTaskStatus.Error);
					return;
				}
				this.m_ticket = text.Substring(num + 11, num2 - num - 11);
				DebugUtils.Log(LogCategory.Network, "StressTestAuthenticateAsyncTask Ticket[" + this.m_ticket + "]");
				NetworkManager.AuthenticateAsyncTask authenticateAsyncTask = new NetworkManager.AuthenticateAsyncTask();
				authenticateAsyncTask.method_4(this.m_ticket);
				MonoSingleton<AsyncTaskManager>.Instance.method_1(authenticateAsyncTask, new TaskCompletedDelegate(this.OnAuthenticate));
				this.m_authenticating = true;
			}
		}

		// Token: 0x06004AF4 RID: 19188 RVA: 0x00030FC6 File Offset: 0x0002F1C6
		private void OnAuthenticate(AsyncTaskBase task, AsyncTaskStatus result)
		{
			base.SetStatus(result);
		}

		// Token: 0x04003683 RID: 13955
		public string m_login;

		// Token: 0x04003684 RID: 13956
		private WWW m_query;

		// Token: 0x04003685 RID: 13957
		private string m_ticket;

		// Token: 0x04003686 RID: 13958
		private string m_password = "100test";

		// Token: 0x04003687 RID: 13959
		private bool m_authenticating;
	}

	// Token: 0x02000AC4 RID: 2756
	public class DisconnectAsyncTask : PhotonNetworkTask
	{
		// Token: 0x06004AF6 RID: 19190 RVA: 0x0000D358 File Offset: 0x0000B558
		public void method_4(string string_0)
		{
			this.float_1 = 30f;
		}

		// Token: 0x06004AF7 RID: 19191 RVA: 0x0000D358 File Offset: 0x0000B558
		public void method_5()
		{
			this.float_1 = 30f;
		}

		// Token: 0x06004AF8 RID: 19192 RVA: 0x00030FCF File Offset: 0x0002F1CF
		public override void Start()
		{
			base.Start();
			if (NetworkManager.smethod_4())
			{
				base.SetStatus(AsyncTaskStatus.Success);
				return;
			}
			PhotonNetwork.Disconnect();
		}

		// Token: 0x06004AF9 RID: 19193 RVA: 0x00030FEB File Offset: 0x0002F1EB
		public override void OnDisconnectedFromPhoton()
		{
			base.SetStatus(AsyncTaskStatus.Success);
		}

		// Token: 0x06004AFA RID: 19194 RVA: 0x00030FF4 File Offset: 0x0002F1F4
		public override void Update(float time)
		{
			base.Update(time);
			if (PhotonNetwork.connectionState == ConnectionState.Disconnected)
			{
				base.SetStatus(AsyncTaskStatus.Success);
			}
		}
	}

	// Token: 0x02000AC5 RID: 2757
	public class WaitServerSwitchAsyncTask : PhotonNetworkTask
	{
		// Token: 0x06004AFC RID: 19196 RVA: 0x0003100B File Offset: 0x0002F20B
		public void method_4()
		{
			this.float_1 = 15f;
		}

		// Token: 0x06004AFD RID: 19197 RVA: 0x00031018 File Offset: 0x0002F218
		public override void Start()
		{
			base.Start();
		}

		// Token: 0x06004AFE RID: 19198 RVA: 0x00031020 File Offset: 0x0002F220
		public override void Update(float time)
		{
			base.Update(time);
			if (PhotonNetwork.connectionState == ConnectionState.Disconnected || PhotonNetwork.connectionState == ConnectionState.Connected)
			{
				base.SetStatus(AsyncTaskStatus.Success);
			}
		}
	}

	// Token: 0x02000AC6 RID: 2758
	public interface NetworkObserver
	{
		// Token: 0x06004AFF RID: 19199
		void OnPlayerLeaveSession(int playerId);
	}
}
