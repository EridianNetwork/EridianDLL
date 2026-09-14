using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using ExitGames.Client.Photon;
using UnityEngine;

// Token: 0x02000B32 RID: 2866
public static class PhotonNetwork
{
	// Token: 0x06004DCA RID: 19914 RVA: 0x0014A144 File Offset: 0x00148344
	static PhotonNetwork()
	{
		Application.runInBackground = true;
		GameObject gameObject = new GameObject();
		PhotonNetwork.photonMono = gameObject.AddComponent<PhotonHandler>();
		gameObject.name = "PhotonMono";
		gameObject.hideFlags = HideFlags.HideInHierarchy;
		GameObject gameObject2 = new GameObject();
		gameObject2.AddComponent<PhotonRecvHandler>();
		gameObject2.name = "PhotonRECV";
		gameObject2.hideFlags = HideFlags.HideInHierarchy;
		PhotonNetwork.networkingPeer = new NetworkingPeer(PhotonNetwork.photonMono, string.Empty, ConnectionProtocol.Udp);
		PhotonNetwork.networkingPeer.LimitOfUnreliableCommands = 100;
		GameObject gameObject3 = new GameObject();
		OnlinePeerHandler onlinePeerHandler = gameObject3.AddComponent<OnlinePeerHandler>();
		gameObject3.name = "PhotonOnline";
		gameObject3.hideFlags = HideFlags.HideInHierarchy;
		PhotonNetwork.onlinePeer = new OnlineServerPeer(onlinePeerHandler, ConnectionProtocol.Udp);
		CustomTypes.smethod_0();
	}

	// Token: 0x170007D1 RID: 2001
	// (get) Token: 0x06004DCB RID: 19915 RVA: 0x0003280E File Offset: 0x00030A0E
	public static bool connected
	{
		get
		{
			return PhotonNetwork.offlineMode || PhotonNetwork.connectionState == ConnectionState.Connected;
		}
	}

	// Token: 0x170007D2 RID: 2002
	// (get) Token: 0x06004DCC RID: 19916 RVA: 0x0014A298 File Offset: 0x00148498
	public static ConnectionState connectionState
	{
		get
		{
			if (PhotonNetwork.offlineMode)
			{
				return ConnectionState.Connected;
			}
			if (PhotonNetwork.networkingPeer == null)
			{
				return ConnectionState.Disconnected;
			}
			PeerStateValue peerState = PhotonNetwork.networkingPeer.PeerState;
			switch (peerState)
			{
			case PeerStateValue.Disconnected:
				return ConnectionState.Disconnected;
			case PeerStateValue.Connecting:
				return ConnectionState.Connecting;
			case PeerStateValue.Connected:
				return ConnectionState.Connected;
			case PeerStateValue.Disconnecting:
				return ConnectionState.Disconnecting;
			}
			if (peerState != PeerStateValue.InitializingApplication)
			{
				return ConnectionState.Disconnected;
			}
			return ConnectionState.InitializingApplication;
		}
	}

	// Token: 0x170007D3 RID: 2003
	// (get) Token: 0x06004DCD RID: 19917 RVA: 0x00032821 File Offset: 0x00030A21
	public static PeerState connectionStateDetailed
	{
		get
		{
			if (PhotonNetwork.offlineMode)
			{
				return PeerState.Connected;
			}
			if (PhotonNetwork.networkingPeer == null)
			{
				return PeerState.Disconnected;
			}
			return PhotonNetwork.networkingPeer.State;
		}
	}

	// Token: 0x170007D4 RID: 2004
	// (get) Token: 0x06004DCE RID: 19918 RVA: 0x00032840 File Offset: 0x00030A40
	public static Room room
	{
		get
		{
			if (!PhotonNetwork.isOfflineMode)
			{
				return PhotonNetwork.networkingPeer.Room_0;
			}
			if (PhotonNetwork.offlineMode_inRoom)
			{
				return new Room("OfflineRoom", new Hashtable());
			}
			return null;
		}
	}

	// Token: 0x170007D5 RID: 2005
	// (get) Token: 0x06004DCF RID: 19919 RVA: 0x0003286C File Offset: 0x00030A6C
	public static PhotonPlayer player
	{
		get
		{
			if (PhotonNetwork.networkingPeer == null)
			{
				return null;
			}
			return PhotonNetwork.networkingPeer.mLocalActor;
		}
	}

	// Token: 0x170007D6 RID: 2006
	// (get) Token: 0x06004DD0 RID: 19920 RVA: 0x00032881 File Offset: 0x00030A81
	public static PhotonPlayer masterClient
	{
		get
		{
			if (PhotonNetwork.networkingPeer == null)
			{
				return null;
			}
			return PhotonNetwork.networkingPeer.mMasterClient;
		}
	}

	// Token: 0x170007D7 RID: 2007
	// (get) Token: 0x06004DD1 RID: 19921 RVA: 0x00032896 File Offset: 0x00030A96
	// (set) Token: 0x06004DD2 RID: 19922 RVA: 0x000328A2 File Offset: 0x00030AA2
	public static string playerName
	{
		get
		{
			return PhotonNetwork.networkingPeer.playerName;
		}
		set
		{
			PhotonNetwork.networkingPeer.playerName = value;
		}
	}

	// Token: 0x170007D8 RID: 2008
	// (get) Token: 0x06004DD3 RID: 19923 RVA: 0x000328AF File Offset: 0x00030AAF
	public static PhotonPlayer[] playerList
	{
		get
		{
			if (PhotonNetwork.networkingPeer == null)
			{
				return new PhotonPlayer[0];
			}
			return PhotonNetwork.networkingPeer.mPlayerListCopy;
		}
	}

	// Token: 0x170007D9 RID: 2009
	// (get) Token: 0x06004DD4 RID: 19924 RVA: 0x000328C9 File Offset: 0x00030AC9
	public static PhotonPlayer[] otherPlayers
	{
		get
		{
			if (PhotonNetwork.networkingPeer == null)
			{
				return new PhotonPlayer[0];
			}
			return PhotonNetwork.networkingPeer.mOtherPlayerListCopy;
		}
	}

	// Token: 0x170007DA RID: 2010
	// (get) Token: 0x06004DD5 RID: 19925 RVA: 0x000328E3 File Offset: 0x00030AE3
	// (set) Token: 0x06004DD6 RID: 19926 RVA: 0x0014A2F0 File Offset: 0x001484F0
	public static bool offlineMode
	{
		get
		{
			return PhotonNetwork.isOfflineMode;
		}
		set
		{
			if (value == PhotonNetwork.isOfflineMode)
			{
				return;
			}
			if (value && PhotonNetwork.connected)
			{
				DebugUtils.LogError(LogCategory.Network, "Can't start OFFLINE mode while connected!");
			}
			else
			{
				PhotonNetwork.networkingPeer.Disconnect();
				PhotonNetwork.isOfflineMode = value;
				if (PhotonNetwork.isOfflineMode)
				{
					NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnConnectedToPhoton, new object[0]);
					PhotonNetwork.networkingPeer.SetLocalActorId(1);
					PhotonNetwork.networkingPeer.mMasterClient = PhotonNetwork.player;
				}
				else
				{
					PhotonNetwork.networkingPeer.SetLocalActorId(-1);
					PhotonNetwork.networkingPeer.mMasterClient = null;
				}
			}
		}
	}

	// Token: 0x170007DB RID: 2011
	// (get) Token: 0x06004DD7 RID: 19927 RVA: 0x000328EA File Offset: 0x00030AEA
	// (set) Token: 0x06004DD8 RID: 19928 RVA: 0x000328FF File Offset: 0x00030AFF
	[Obsolete("Used for compatibility with Unity networking only.")]
	public static int maxConnections
	{
		get
		{
			if (PhotonNetwork.room == null)
			{
				return 0;
			}
			return PhotonNetwork.room.maxPlayers;
		}
		set
		{
			PhotonNetwork.room.maxPlayers = value;
		}
	}

	// Token: 0x170007DC RID: 2012
	// (get) Token: 0x06004DD9 RID: 19929 RVA: 0x0003290C File Offset: 0x00030B0C
	// (set) Token: 0x06004DDA RID: 19930 RVA: 0x00032913 File Offset: 0x00030B13
	public static bool automaticallySyncScene
	{
		get
		{
			return PhotonNetwork._mAutomaticallySyncScene;
		}
		set
		{
			PhotonNetwork._mAutomaticallySyncScene = value;
			if (PhotonNetwork._mAutomaticallySyncScene && PhotonNetwork.room != null)
			{
				PhotonNetwork.networkingPeer.AutomaticallySyncScene();
			}
		}
	}

	// Token: 0x170007DD RID: 2013
	// (get) Token: 0x06004DDB RID: 19931 RVA: 0x00032933 File Offset: 0x00030B33
	// (set) Token: 0x06004DDC RID: 19932 RVA: 0x0003293A File Offset: 0x00030B3A
	public static bool autoCleanUpPlayerObjects
	{
		get
		{
			return PhotonNetwork.m_autoCleanUpPlayerObjects;
		}
		set
		{
			if (PhotonNetwork.room != null)
			{
				DebugUtils.LogError(LogCategory.Network, "Setting autoCleanUpPlayerObjects while in a room is not supported.");
			}
			PhotonNetwork.m_autoCleanUpPlayerObjects = value;
		}
	}

	// Token: 0x170007DE RID: 2014
	// (get) Token: 0x06004DDD RID: 19933 RVA: 0x00032955 File Offset: 0x00030B55
	// (set) Token: 0x06004DDE RID: 19934 RVA: 0x0003295C File Offset: 0x00030B5C
	public static bool autoJoinLobby
	{
		get
		{
			return PhotonNetwork.autoJoinLobbyField;
		}
		set
		{
			PhotonNetwork.autoJoinLobbyField = value;
		}
	}

	// Token: 0x170007DF RID: 2015
	// (get) Token: 0x06004DDF RID: 19935 RVA: 0x00032964 File Offset: 0x00030B64
	public static bool insideLobby
	{
		get
		{
			return PhotonNetwork.networkingPeer.insideLobby;
		}
	}

	// Token: 0x170007E0 RID: 2016
	// (get) Token: 0x06004DE0 RID: 19936 RVA: 0x00032970 File Offset: 0x00030B70
	// (set) Token: 0x06004DE1 RID: 19937 RVA: 0x0003297D File Offset: 0x00030B7D
	public static int sendRate
	{
		get
		{
			return 1000 / PhotonNetwork.sendInterval;
		}
		set
		{
			PhotonNetwork.sendInterval = 1000 / value;
			if (PhotonNetwork.photonMono != null)
			{
				PhotonNetwork.photonMono.updateInterval = PhotonNetwork.sendInterval;
			}
			if (value < PhotonNetwork.sendRateOnSerialize)
			{
				PhotonNetwork.sendRateOnSerialize = value;
			}
		}
	}

	// Token: 0x170007E1 RID: 2017
	// (get) Token: 0x06004DE2 RID: 19938 RVA: 0x000329B5 File Offset: 0x00030BB5
	// (set) Token: 0x06004DE3 RID: 19939 RVA: 0x0014A374 File Offset: 0x00148574
	public static int sendRateOnSerialize
	{
		get
		{
			return 1000 / PhotonNetwork.sendIntervalOnSerialize;
		}
		set
		{
			if (value > PhotonNetwork.sendRate)
			{
				DebugUtils.LogError(LogCategory.Network, "Error, can not set the OnSerialize SendRate more often then the overall SendRate");
				value = PhotonNetwork.sendRate;
			}
			PhotonNetwork.sendIntervalOnSerialize = 1000 / value;
			if (PhotonNetwork.photonMono != null)
			{
				PhotonNetwork.photonMono.updateIntervalOnSerialize = PhotonNetwork.sendIntervalOnSerialize;
			}
		}
	}

	// Token: 0x170007E2 RID: 2018
	// (get) Token: 0x06004DE4 RID: 19940 RVA: 0x000329C2 File Offset: 0x00030BC2
	// (set) Token: 0x06004DE5 RID: 19941 RVA: 0x000329C9 File Offset: 0x00030BC9
	public static bool isMessageQueueRunning
	{
		get
		{
			return PhotonNetwork.m_isMessageQueueRunning;
		}
		set
		{
			if (value == PhotonNetwork.m_isMessageQueueRunning)
			{
				return;
			}
			PhotonNetwork.networkingPeer.IsSendingOnlyAcks = !value;
			PhotonNetwork.m_isMessageQueueRunning = value;
			if (!value)
			{
				PhotonHandler.smethod_0();
			}
		}
	}

	// Token: 0x170007E3 RID: 2019
	// (get) Token: 0x06004DE6 RID: 19942 RVA: 0x000329F0 File Offset: 0x00030BF0
	// (set) Token: 0x06004DE7 RID: 19943 RVA: 0x000329FC File Offset: 0x00030BFC
	public static int unreliableCommandsLimit
	{
		get
		{
			return PhotonNetwork.networkingPeer.LimitOfUnreliableCommands;
		}
		set
		{
			PhotonNetwork.networkingPeer.LimitOfUnreliableCommands = value;
		}
	}

	// Token: 0x170007E4 RID: 2020
	// (get) Token: 0x06004DE8 RID: 19944 RVA: 0x00032A09 File Offset: 0x00030C09
	public static double time
	{
		get
		{
			if (PhotonNetwork.offlineMode)
			{
				return (double)Time.time;
			}
			return PhotonNetwork.networkingPeer.ServerTimeInMilliSeconds / 1000.0;
		}
	}

	// Token: 0x170007E5 RID: 2021
	// (get) Token: 0x06004DE9 RID: 19945 RVA: 0x00032A2F File Offset: 0x00030C2F
	public static bool isMasterClient
	{
		get
		{
			return PhotonNetwork.offlineMode || PhotonNetwork.networkingPeer.mMasterClient == PhotonNetwork.networkingPeer.mLocalActor;
		}
	}

	// Token: 0x170007E6 RID: 2022
	// (get) Token: 0x06004DEA RID: 19946 RVA: 0x00032A50 File Offset: 0x00030C50
	public static bool isNonMasterClientInRoom
	{
		get
		{
			return !PhotonNetwork.isMasterClient && PhotonNetwork.room != null;
		}
	}

	// Token: 0x170007E7 RID: 2023
	// (get) Token: 0x06004DEB RID: 19947 RVA: 0x00032A67 File Offset: 0x00030C67
	public static int countOfPlayersOnMaster
	{
		get
		{
			return PhotonNetwork.networkingPeer.mPlayersOnMasterCount;
		}
	}

	// Token: 0x170007E8 RID: 2024
	// (get) Token: 0x06004DEC RID: 19948 RVA: 0x00032A73 File Offset: 0x00030C73
	public static int countOfPlayersInRooms
	{
		get
		{
			return PhotonNetwork.networkingPeer.mPlayersInRoomsCount;
		}
	}

	// Token: 0x170007E9 RID: 2025
	// (get) Token: 0x06004DED RID: 19949 RVA: 0x00032A7F File Offset: 0x00030C7F
	public static int countOfPlayers
	{
		get
		{
			return PhotonNetwork.networkingPeer.mPlayersInRoomsCount + PhotonNetwork.networkingPeer.mPlayersOnMasterCount;
		}
	}

	// Token: 0x170007EA RID: 2026
	// (get) Token: 0x06004DEE RID: 19950 RVA: 0x00032A96 File Offset: 0x00030C96
	public static int countOfRooms
	{
		get
		{
			if (PhotonNetwork.insideLobby)
			{
				return PhotonNetwork.GetRoomList().Length;
			}
			return PhotonNetwork.networkingPeer.mGameCount;
		}
	}

	// Token: 0x170007EB RID: 2027
	// (get) Token: 0x06004DEF RID: 19951 RVA: 0x00032AB1 File Offset: 0x00030CB1
	// (set) Token: 0x06004DF0 RID: 19952 RVA: 0x00032ABD File Offset: 0x00030CBD
	public static bool NetworkStatisticsEnabled
	{
		get
		{
			return PhotonNetwork.networkingPeer.TrafficStatsEnabled;
		}
		set
		{
			PhotonNetwork.networkingPeer.TrafficStatsEnabled = value;
		}
	}

	// Token: 0x06004DF1 RID: 19953 RVA: 0x00032ACA File Offset: 0x00030CCA
	public static void NetworkStatisticsReset()
	{
		PhotonNetwork.networkingPeer.TrafficStatsReset();
		PhotonNetwork.networkingPeer.ResetNetworkStatistics();
	}

	// Token: 0x06004DF2 RID: 19954 RVA: 0x00032AE0 File Offset: 0x00030CE0
	public static string NetworkStatisticsToString()
	{
		if (PhotonNetwork.networkingPeer != null && !PhotonNetwork.offlineMode)
		{
			return PhotonNetwork.networkingPeer.VitalStatsToString(false);
		}
		return "Offline or in OfflineMode. No VitalStats available.";
	}

	// Token: 0x06004DF3 RID: 19955 RVA: 0x0014A3C8 File Offset: 0x001485C8
	public static void InternalCleanPhotonMonoFromSceneIfStuck()
	{
		PhotonHandler[] array = global::UnityEngine.Object.FindObjectsOfType(typeof(PhotonHandler)) as PhotonHandler[];
		if (array != null && array.Length > 0)
		{
			DebugUtils.Log(LogCategory.Network, "Cleaning up hidden PhotonHandler instances in scene. Please save it. This is not an issue.");
			foreach (PhotonHandler photonHandler in array)
			{
				photonHandler.gameObject.hideFlags = HideFlags.None;
				if (photonHandler.gameObject != null && photonHandler.gameObject.name == "PhotonMono")
				{
					global::UnityEngine.Object.DestroyImmediate(photonHandler.gameObject);
				}
				global::UnityEngine.Object.DestroyImmediate(photonHandler);
			}
		}
	}

	// Token: 0x06004DF4 RID: 19956 RVA: 0x0014A458 File Offset: 0x00148658
	public static void ConnectUsingSettings(string string_0)
	{
		if (PhotonNetwork.PhotonServerSettings == null)
		{
			DebugUtils.LogError(LogCategory.Network, "Can't connect: Loading settings failed. ServerSettings asset must be in any 'Resources' folder as: PhotonServerSettings");
			return;
		}
		if (PhotonNetwork.PhotonServerSettings.HostType == ServerSettings.HostingOption.OfflineMode)
		{
			PhotonNetwork.offlineMode = true;
			return;
		}
		PhotonNetwork.Connect(PhotonNetwork.PhotonServerSettings.ServerAddress, PhotonNetwork.PhotonServerSettings.ServerPort, PhotonNetwork.PhotonServerSettings.AppID, string_0, string.Empty, string.Empty);
	}

	// Token: 0x06004DF5 RID: 19957 RVA: 0x00032B01 File Offset: 0x00030D01
	[Obsolete("This method is obsolete; use ConnectUsingSettings with the gameVersion argument instead")]
	public static void ConnectUsingSettings()
	{
		PhotonNetwork.ConnectUsingSettings("1.0");
	}

	// Token: 0x06004DF6 RID: 19958 RVA: 0x00032B0D File Offset: 0x00030D0D
	[Obsolete("This method is obsolete; use Connect with the gameVersion argument instead")]
	public static void Connect(string string_0, int int_0, string string_1)
	{
		PhotonNetwork.Connect(string_0, int_0, string_1, "1.0", string.Empty, string.Empty);
	}

	// Token: 0x06004DF7 RID: 19959 RVA: 0x0014A4C4 File Offset: 0x001486C4
	public static void Connect(string string_0, int int_0, string string_1, string string_2, string string_3 = "", string string_4 = "")
	{
		if (int_0 <= 0)
		{
			DebugUtils.LogError(LogCategory.Network, "Aborted Connect: invalid port: " + int_0);
			return;
		}
		if (string_0.Length <= 2)
		{
			DebugUtils.LogError(LogCategory.Network, "Aborted Connect: invalid serverAddress: " + string_0);
			return;
		}
		if (PhotonNetwork.networkingPeer.PeerState != PeerStateValue.Disconnected)
		{
			DebugUtils.LogWarning(LogCategory.Network, "Connect() only works when disconnected. Current state: " + PhotonNetwork.networkingPeer.PeerState);
			return;
		}
		if (PhotonNetwork.offlineMode)
		{
			PhotonNetwork.offlineMode = false;
			DebugUtils.LogWarning(LogCategory.Network, "Shut down offline mode due to a connect attempt");
		}
		if (!PhotonNetwork.isMessageQueueRunning)
		{
			PhotonNetwork.isMessageQueueRunning = true;
			DebugUtils.LogWarning(LogCategory.Network, "Forced enabling of isMessageQueueRunning because of a Connect()");
		}
		string_0 = string_0 + ":" + int_0;
		PhotonNetwork.networkingPeer.mAppVersion = string_2;
		PhotonNetwork.networkingPeer.maccount = string_3;
		PhotonNetwork.networkingPeer.mpwd = string_4;
		PhotonNetwork.networkingPeer.Connect(string_0, string_1);
	}

	// Token: 0x06004DF8 RID: 19960 RVA: 0x0014A5B0 File Offset: 0x001487B0
	public static void Disconnect()
	{
		if (PhotonNetwork.offlineMode)
		{
			PhotonNetwork.offlineMode = false;
			PhotonNetwork.networkingPeer.State = PeerState.Disconnecting;
			PhotonNetwork.networkingPeer.OnStatusChanged(StatusCode.Disconnect);
			return;
		}
		if (PhotonNetwork.networkingPeer == null)
		{
			return;
		}
		PhotonNetwork.networkingPeer.Disconnect();
		if (PhotonNetwork.onlinePeer != null)
		{
			PhotonNetwork.onlinePeer.Disconnect();
		}
	}

	// Token: 0x06004DF9 RID: 19961 RVA: 0x0000311B File Offset: 0x0000131B
	[Obsolete("Used for compatibility with Unity networking only. Encryption is automatically initialized while connecting.")]
	public static void InitializeSecurity()
	{
	}

	// Token: 0x06004DFA RID: 19962 RVA: 0x0014A60C File Offset: 0x0014880C
	public static void CreateRoom(string string_0)
	{
		DebugUtils.Log(LogCategory.Network, "this custom props " + PhotonNetwork.player.customProperties.ToStringFull());
		if (PhotonNetwork.connectionStateDetailed != PeerState.ConnectedToGameserver && PhotonNetwork.connectionStateDetailed != PeerState.Joining)
		{
			if (PhotonNetwork.connectionStateDetailed != PeerState.Joined)
			{
				if (PhotonNetwork.room != null)
				{
					DebugUtils.LogError(LogCategory.Network, "CreateRoom aborted: You are already in a room!");
					return;
				}
				if (PhotonNetwork.offlineMode)
				{
					PhotonNetwork.offlineMode_inRoom = true;
					NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnCreatedRoom, new object[0]);
					NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnJoinedRoom, new object[0]);
					return;
				}
				PhotonNetwork.networkingPeer.OpCreateRoom(string_0, true, true, 0, PhotonNetwork.autoCleanUpPlayerObjects, null, null);
				return;
			}
		}
		DebugUtils.LogError(LogCategory.Network, "CreateRoom aborted: You are already connecting to a room!");
	}

	// Token: 0x06004DFB RID: 19963 RVA: 0x00032B26 File Offset: 0x00030D26
	public static void CreateRoom(string string_0, bool bool_0, bool bool_1, int int_0)
	{
		PhotonNetwork.CreateRoom(string_0, bool_0, bool_1, int_0, null, null);
	}

	// Token: 0x06004DFC RID: 19964 RVA: 0x0014A6B8 File Offset: 0x001488B8
	public static void CreateRoom(string string_0, bool bool_0, bool bool_1, int int_0, Hashtable hashtable_0, string[] string_1)
	{
		if (PhotonNetwork.connectionStateDetailed != PeerState.Joining && PhotonNetwork.connectionStateDetailed != PeerState.Joined)
		{
			if (PhotonNetwork.connectionStateDetailed != PeerState.ConnectedToGameserver)
			{
				if (PhotonNetwork.room != null)
				{
					DebugUtils.LogError(LogCategory.Network, "CreateRoom aborted: You are already in a room!");
					return;
				}
				if (PhotonNetwork.offlineMode)
				{
					PhotonNetwork.offlineMode_inRoom = true;
					NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnCreatedRoom, new object[0]);
					return;
				}
				if (int_0 > 255)
				{
					DebugUtils.LogError(LogCategory.Network, "Error: CreateRoom called with " + int_0 + " maxplayers. This has been reverted to the max of 255 players because internally a 'byte' is used.");
					int_0 = 255;
				}
				PhotonNetwork.networkingPeer.OpCreateRoom(string_0, bool_0, bool_1, (byte)int_0, PhotonNetwork.autoCleanUpPlayerObjects, hashtable_0, string_1);
				return;
			}
		}
		DebugUtils.LogError(LogCategory.Network, "CreateRoom aborted: You can only create a room while not currently connected/connecting to a room.");
	}

	// Token: 0x06004DFD RID: 19965 RVA: 0x00032B33 File Offset: 0x00030D33
	public static void JoinRoom(RoomInfo roomInfo_0)
	{
		if (roomInfo_0 == null)
		{
			DebugUtils.LogError(LogCategory.Network, "JoinRoom aborted: you passed a NULL room");
			return;
		}
		PhotonNetwork.JoinRoom(roomInfo_0.String_0);
	}

	// Token: 0x06004DFE RID: 19966 RVA: 0x0014A76C File Offset: 0x0014896C
	public static void JoinRoom(string string_0)
	{
		if (PhotonNetwork.connectionStateDetailed != PeerState.Joining && PhotonNetwork.connectionStateDetailed != PeerState.Joined)
		{
			if (PhotonNetwork.connectionStateDetailed != PeerState.ConnectedToGameserver)
			{
				if (PhotonNetwork.room != null)
				{
					DebugUtils.LogError(LogCategory.Network, "JoinRoom aborted: You are already in a room!");
					NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnPhotonJoinRoomFailed, new object[0]);
					return;
				}
				if (string_0 == string.Empty)
				{
					DebugUtils.LogError(LogCategory.Network, "JoinRoom aborted: You must specifiy a room name!");
					NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnPhotonJoinRoomFailed, new object[0]);
					return;
				}
				if (PhotonNetwork.offlineMode)
				{
					PhotonNetwork.offlineMode_inRoom = true;
					NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnJoinedRoom, new object[0]);
					return;
				}
				PhotonNetwork.networkingPeer.OpJoin(string_0, null);
				return;
			}
		}
		DebugUtils.LogError(LogCategory.Network, "JoinRoom aborted: You can only join a room while not currently connected/connecting to a room.");
		NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnPhotonJoinRoomFailed, new object[0]);
	}

	// Token: 0x06004DFF RID: 19967 RVA: 0x00032B50 File Offset: 0x00030D50
	public static void JoinRandomRoom()
	{
		PhotonNetwork.JoinRandomRoom(null, 0);
	}

	// Token: 0x06004E00 RID: 19968 RVA: 0x00032B59 File Offset: 0x00030D59
	public static void JoinRandomRoom(Hashtable hashtable_0, byte byte_0)
	{
		PhotonNetwork.JoinRandomRoom(hashtable_0, byte_0, MatchmakingMode.FillRoom);
	}

	// Token: 0x06004E01 RID: 19969 RVA: 0x0014A828 File Offset: 0x00148A28
	public static void JoinRandomRoom(Hashtable hashtable_0, byte byte_0, MatchmakingMode matchmakingMode_0)
	{
		if (PhotonNetwork.connectionStateDetailed != PeerState.Joining && PhotonNetwork.connectionStateDetailed != PeerState.Joined)
		{
			if (PhotonNetwork.connectionStateDetailed != PeerState.ConnectedToGameserver)
			{
				if (PhotonNetwork.room != null)
				{
					DebugUtils.LogError(LogCategory.Network, "JoinRandomRoom aborted: You are already in a room!");
					NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnPhotonRandomJoinFailed, new object[0]);
					return;
				}
				if (PhotonNetwork.offlineMode)
				{
					PhotonNetwork.offlineMode_inRoom = true;
					NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnJoinedRoom, new object[0]);
				}
				else
				{
					Hashtable hashtable = new Hashtable();
					hashtable.MergeStringKeys(hashtable_0);
					if (byte_0 > 0)
					{
						hashtable[byte.MaxValue] = byte_0;
					}
					PhotonNetwork.networkingPeer.OpJoinRandomRoom(hashtable, 0, null, matchmakingMode_0);
				}
				return;
			}
		}
		DebugUtils.LogError(LogCategory.Network, "JoinRandomRoom aborted: You can only join a room while not currently connected/connecting to a room. [" + PhotonNetwork.connectionStateDetailed + "]");
		NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnPhotonRandomJoinFailed, new object[0]);
	}

	// Token: 0x06004E02 RID: 19970 RVA: 0x00032B63 File Offset: 0x00030D63
	public static void smethod_17(Query query_0, int int_0 = 50)
	{
		PhotonNetwork.networkingPeer.OpExecuteQuery(query_0, int_0);
	}

	// Token: 0x06004E03 RID: 19971 RVA: 0x0014A8F8 File Offset: 0x00148AF8
	public static void CancelJoin()
	{
		if (!PhotonNetwork.offlineMode && PhotonNetwork.connectionStateDetailed != PeerState.Joining)
		{
			DebugUtils.LogError(LogCategory.Network, string.Format("PhotonNetwork: No join attempt in progress to cancel (State = {0})", PhotonNetwork.connectionStateDetailed));
			return;
		}
		if (PhotonNetwork.offlineMode)
		{
			PhotonNetwork.offlineMode_inRoom = false;
			NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnLeftRoom, new object[0]);
		}
		else
		{
			PhotonNetwork.networkingPeer.OpCancelJoin();
		}
	}

	// Token: 0x06004E04 RID: 19972 RVA: 0x0014A958 File Offset: 0x00148B58
	public static void LeaveRoom()
	{
		if (!PhotonNetwork.offlineMode && PhotonNetwork.connectionStateDetailed != PeerState.Joined)
		{
			DebugUtils.LogError(LogCategory.Network, "PhotonNetwork: Error, you cannot leave a room if you're not in a room!(1)");
			return;
		}
		if (PhotonNetwork.room == null)
		{
			DebugUtils.LogError(LogCategory.Network, "PhotonNetwork: Error, you cannot leave a room if you're not in a room!(2)");
			return;
		}
		if (PhotonNetwork.offlineMode)
		{
			PhotonNetwork.offlineMode_inRoom = false;
			NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnLeftRoom, new object[0]);
		}
		else
		{
			PhotonNetwork.networkingPeer.OpLeaveRoom();
		}
	}

	// Token: 0x06004E05 RID: 19973 RVA: 0x00032B72 File Offset: 0x00030D72
	public static RoomInfo[] GetRoomList()
	{
		if (PhotonNetwork.offlineMode)
		{
			return new RoomInfo[0];
		}
		if (PhotonNetwork.networkingPeer == null)
		{
			return new RoomInfo[0];
		}
		return PhotonNetwork.networkingPeer.mGameListCopy;
	}

	// Token: 0x06004E06 RID: 19974 RVA: 0x0014A9BC File Offset: 0x00148BBC
	public static void SetPlayerCustomProperties(Hashtable hashtable_0)
	{
		if (hashtable_0 == null)
		{
			hashtable_0 = new Hashtable();
			foreach (object obj in PhotonNetwork.player.customProperties.Keys)
			{
				hashtable_0[(string)obj] = null;
			}
		}
		if (PhotonNetwork.room != null && PhotonNetwork.room.isLocalClientInside)
		{
			PhotonNetwork.player.method_2(hashtable_0);
		}
		else
		{
			PhotonNetwork.player.method_0(hashtable_0);
		}
	}

	// Token: 0x06004E07 RID: 19975 RVA: 0x0014AA58 File Offset: 0x00148C58
	public static int AllocateViewID()
	{
		int num = PhotonNetwork.AllocateViewID(PhotonNetwork.player.ActorId);
		PhotonNetwork.manuallyAllocatedViewIds.Add(num);
		return num;
	}

	// Token: 0x06004E08 RID: 19976 RVA: 0x0014AA84 File Offset: 0x00148C84
	public static void UnAllocateViewID(int int_0)
	{
		PhotonNetwork.manuallyAllocatedViewIds.Remove(int_0);
		if (PhotonNetwork.networkingPeer.photonViewList.ContainsKey(int_0))
		{
			DebugUtils.LogWarning(LogCategory.Network, string.Format("Unallocated manually used viewID: {0} but found it used still in a PhotonView: {1}", int_0, PhotonNetwork.networkingPeer.photonViewList[int_0]));
		}
	}

	// Token: 0x06004E09 RID: 19977 RVA: 0x0014AAD8 File Offset: 0x00148CD8
	private static int AllocateViewID(int int_0)
	{
		if (int_0 == 0)
		{
			int num = PhotonNetwork.lastUsedViewSubIdStatic;
			int num2 = int_0 * PhotonNetwork.MAX_VIEW_IDS;
			for (int i = 1; i < PhotonNetwork.MAX_VIEW_IDS; i++)
			{
				num = (num + 1) % PhotonNetwork.MAX_VIEW_IDS;
				if (num != 0)
				{
					int num3 = num + num2;
					if (!PhotonNetwork.networkingPeer.photonViewList.ContainsKey(num3))
					{
						PhotonNetwork.lastUsedViewSubIdStatic = num;
						return num3;
					}
				}
			}
			throw new Exception(string.Format("AllocateViewID() failed. Room (user {0}) is out of subIds, as all room viewIDs are used.", int_0));
		}
		int num4 = PhotonNetwork.lastUsedViewSubId;
		int num5 = int_0 * PhotonNetwork.MAX_VIEW_IDS;
		for (int j = 1; j < PhotonNetwork.MAX_VIEW_IDS; j++)
		{
			num4 = (num4 + 1) % PhotonNetwork.MAX_VIEW_IDS;
			if (num4 != 0)
			{
				int num6 = num4 + num5;
				if (!PhotonNetwork.networkingPeer.photonViewList.ContainsKey(num6) && !PhotonNetwork.manuallyAllocatedViewIds.Contains(num6))
				{
					PhotonNetwork.lastUsedViewSubId = num4;
					return num6;
				}
			}
		}
		throw new Exception(string.Format("AllocateViewID() failed. User {0} is out of subIds, as all viewIDs are used.", int_0));
	}

	// Token: 0x06004E0A RID: 19978 RVA: 0x0014ABC4 File Offset: 0x00148DC4
	private static int[] AllocateSceneViewIDs(int int_0)
	{
		int[] array = new int[int_0];
		for (int i = 0; i < int_0; i++)
		{
			array[i] = PhotonNetwork.AllocateViewID(0);
		}
		return array;
	}

	// Token: 0x06004E0B RID: 19979 RVA: 0x00032B9A File Offset: 0x00030D9A
	public static GameObject Instantiate(string string_0, Vector3 vector3_0, Quaternion quaternion_0, int int_0)
	{
		return PhotonNetwork.Instantiate(string_0, vector3_0, quaternion_0, int_0, null);
	}

	// Token: 0x06004E0C RID: 19980 RVA: 0x0014ABF0 File Offset: 0x00148DF0
	public static GameObject Instantiate(string string_0, Vector3 vector3_0, Quaternion quaternion_0, int int_0, object[] object_0)
	{
		if (!PhotonNetwork.VerifyCanUseNetwork())
		{
			DebugUtils.LogError(LogCategory.Network, "PhotonNetwork error: Could not Instantiate the prefab [" + string_0 + "] as the game is not connected.");
			return null;
		}
		GameObject gameObject = ResourcesLoader.smethod_8(string_0);
		if (gameObject == null)
		{
			DebugUtils.LogError(LogCategory.Network, "PhotonNetwork error: Could not Instantiate the prefab [" + string_0 + "]. Please verify you have this gameobject in a Resources folder (and not in a subfolder)");
			return null;
		}
		if (gameObject.GetComponent<PhotonView>() == null)
		{
			DebugUtils.LogError(LogCategory.Network, "PhotonNetwork error: Could not Instantiate the prefab [" + string_0 + "] as it has no PhotonView attached to the root.");
			return null;
		}
		Component[] componentsInChildren = gameObject.GetComponentsInChildren<PhotonView>(true);
		int[] array = new int[componentsInChildren.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = PhotonNetwork.AllocateViewID(PhotonNetwork.player.ActorId);
		}
		Hashtable hashtable = PhotonNetwork.networkingPeer.SendInstantiate(string_0, vector3_0, quaternion_0, int_0, array, object_0, false);
		return PhotonNetwork.networkingPeer.DoInstantiate(hashtable, PhotonNetwork.networkingPeer.mLocalActor, gameObject, true);
	}

	// Token: 0x06004E0D RID: 19981 RVA: 0x0014ACCC File Offset: 0x00148ECC
	public static GameObject InstantiateSceneObject(string string_0, Vector3 vector3_0, Quaternion quaternion_0, int int_0, object[] object_0)
	{
		if (!PhotonNetwork.VerifyCanUseNetwork())
		{
			return null;
		}
		if (!PhotonNetwork.isMasterClient)
		{
			DebugUtils.LogError(LogCategory.Network, "PhotonNetwork error [InstantiateSceneObject]: Only the master client can Instantiate scene objects");
			return null;
		}
		GameObject gameObject = ResourcesLoader.smethod_8(string_0);
		if (gameObject == null)
		{
			DebugUtils.LogError(LogCategory.Network, "PhotonNetwork error [InstantiateSceneObject]: Could not Instantiate the prefab [" + string_0 + "]. Please verify you have this gameobject in a Resources folder (and not in a subfolder)");
			return null;
		}
		if (gameObject.GetComponent<PhotonView>() == null)
		{
			DebugUtils.LogError(LogCategory.Network, "PhotonNetwork error [InstantiateSceneObject]: Could not Instantiate the prefab [" + string_0 + "] as it has no PhotonView attached to the root.");
			return null;
		}
		Component[] photonViewsInChildren = gameObject.GetPhotonViewsInChildren();
		int[] array = PhotonNetwork.AllocateSceneViewIDs(photonViewsInChildren.Length);
		if (array == null)
		{
			DebugUtils.LogError(LogCategory.Network, string.Concat(new object[]
			{
				"PhotonNetwork error [InstantiateSceneObject]: Could not Instantiate the prefab [",
				string_0,
				"] as no ViewIDs are free to use. Max is: ",
				PhotonNetwork.MAX_VIEW_IDS
			}));
			return null;
		}
		Hashtable hashtable = PhotonNetwork.networkingPeer.SendInstantiate(string_0, vector3_0, quaternion_0, int_0, array, object_0, true);
		return PhotonNetwork.networkingPeer.DoInstantiate(hashtable, PhotonNetwork.networkingPeer.mLocalActor, gameObject, true);
	}

	// Token: 0x06004E0E RID: 19982 RVA: 0x00032BA6 File Offset: 0x00030DA6
	public static int GetPing()
	{
		return PhotonNetwork.networkingPeer.RoundTripTime;
	}

	// Token: 0x06004E0F RID: 19983 RVA: 0x00032BB2 File Offset: 0x00030DB2
	public static void SendOutgoingCommands()
	{
		if (!PhotonNetwork.VerifyCanUseNetwork())
		{
			return;
		}
		while (PhotonNetwork.networkingPeer.SendOutgoingCommands())
		{
		}
	}

	// Token: 0x06004E10 RID: 19984 RVA: 0x0014ADBC File Offset: 0x00148FBC
	public static void CloseConnection(PhotonPlayer photonPlayer_0)
	{
		if (!PhotonNetwork.VerifyCanUseNetwork())
		{
			return;
		}
		if (!PhotonNetwork.player.Boolean_0)
		{
			DebugUtils.LogError(LogCategory.Network, "CloseConnection: Only the masterclient can kick another player.");
		}
		if (photonPlayer_0 == null)
		{
			DebugUtils.LogError(LogCategory.Network, "CloseConnection: No such player connected!");
		}
		else
		{
			int[] array = new int[] { photonPlayer_0.ActorId };
			PhotonNetwork.networkingPeer.RaiseEventToActors(203, null, true, 0, array);
		}
	}

	// Token: 0x06004E11 RID: 19985 RVA: 0x0014AE20 File Offset: 0x00149020
	public static void Destroy(PhotonView photonView_0)
	{
		if (photonView_0 != null && photonView_0.Boolean_1)
		{
			if (photonView_0.instantiationId > 0)
			{
				PhotonNetwork.networkingPeer.DestroyPhotonView(photonView_0, false);
			}
			else
			{
				DebugUtils.LogError(LogCategory.Network, "Use PhotonNetwork.Destroy(view) only on PhotonViews created with PhotonNetwork.Instantiate(). GameObject not destroyed: " + photonView_0.gameObject);
			}
		}
		else
		{
			DebugUtils.LogError(LogCategory.Network, "Destroy: Could not destroy view ID [" + photonView_0 + "]. Does not exist, or is not ours!");
		}
	}

	// Token: 0x06004E12 RID: 19986 RVA: 0x0014AE88 File Offset: 0x00149088
	public static void Destroy(GameObject gameObject_0)
	{
		PhotonView component = gameObject_0.GetComponent<PhotonView>();
		if (component == null)
		{
			DebugUtils.LogError(LogCategory.Network, "Cannot call Destroy(GameObject go); on the gameobject \"" + gameObject_0.name + "\" as it has no PhotonView attached.");
		}
		else if (component.Boolean_1)
		{
			int num = PhotonNetwork.networkingPeer.GetInstantiatedObjectsId(gameObject_0);
			if (num <= 0)
			{
				DebugUtils.LogError(LogCategory.Network, "Use PhotonNetwork.Destroy() only on GameObjects created with PhotonNetwork.Instantiate(). GameObject not destroyed: " + gameObject_0);
			}
			else
			{
				PhotonNetwork.networkingPeer.RemoveInstantiatedObject(gameObject_0, false);
			}
		}
		else
		{
			DebugUtils.LogError(LogCategory.Network, string.Concat(new object[] { "Cannot call Destroy(GameObject go); on the gameobject \"", gameObject_0.name, "\" as we don't control it (Owner: ", component.PhotonPlayer_0, ")." }));
		}
	}

	// Token: 0x06004E13 RID: 19987 RVA: 0x0014AF3C File Offset: 0x0014913C
	public static void DestroyPlayerObjects(PhotonPlayer photonPlayer_0)
	{
		if (!PhotonNetwork.VerifyCanUseNetwork())
		{
			return;
		}
		if (!PhotonNetwork.player.Boolean_0)
		{
			if (photonPlayer_0 != PhotonNetwork.player)
			{
				DebugUtils.LogError(LogCategory.Network, "Couldn't destroy objects for player \"" + photonPlayer_0 + "\" as we are not the masterclient.");
				return;
			}
		}
		PhotonNetwork.networkingPeer.DestroyPlayerObjects(photonPlayer_0, false);
	}

	// Token: 0x06004E14 RID: 19988 RVA: 0x00032BC8 File Offset: 0x00030DC8
	public static void RemoveAllInstantiatedObjects()
	{
		if (PhotonNetwork.isMasterClient)
		{
			PhotonNetwork.networkingPeer.RemoveAllInstantiatedObjects();
		}
		else
		{
			DebugUtils.LogError(LogCategory.Network, "Couldn't call RemoveAllInstantiatedObjects as only the master client is allowed to call this.");
		}
	}

	// Token: 0x06004E15 RID: 19989 RVA: 0x0014AF8C File Offset: 0x0014918C
	public static void RemoveAllInstantiatedObjects(PhotonPlayer photonPlayer_0)
	{
		if (!PhotonNetwork.VerifyCanUseNetwork())
		{
			return;
		}
		if (!PhotonNetwork.player.Boolean_0)
		{
			if (photonPlayer_0 != PhotonNetwork.player)
			{
				DebugUtils.LogError(LogCategory.Network, "Couldn't RemoveAllInstantiatedObjects for player \"" + photonPlayer_0 + "\" as only the master client or the player itself is allowed to call this.");
				return;
			}
		}
		PhotonNetwork.networkingPeer.RemoveAllInstantiatedObjectsByPlayer(photonPlayer_0, false);
	}

	// Token: 0x06004E16 RID: 19990 RVA: 0x0014AFDC File Offset: 0x001491DC
	internal static void RPC(PhotonView photonView_0, string string_0, PhotonTargets photonTargets_0, bool bool_0, params object[] object_0)
	{
		if (!PhotonNetwork.VerifyCanUseNetwork())
		{
			return;
		}
		if (PhotonNetwork.room == null)
		{
			DebugUtils.LogWarning(LogCategory.Network, "Cannot send RPCs in Lobby! RPC dropped.");
			return;
		}
		if (PhotonNetwork.networkingPeer != null)
		{
			PhotonNetwork.networkingPeer.SendRPCToTargets(photonView_0, string_0, photonTargets_0, bool_0, object_0);
		}
		else
		{
			DebugUtils.LogWarning(LogCategory.Network, "Could not execute RPC " + string_0 + ". Possible scene loading in progress?");
		}
	}

	// Token: 0x06004E17 RID: 19991 RVA: 0x0014B038 File Offset: 0x00149238
	internal static void RPC(PhotonView photonView_0, string string_0, PhotonPlayer photonPlayer_0, bool bool_0, params object[] object_0)
	{
		if (!PhotonNetwork.VerifyCanUseNetwork())
		{
			return;
		}
		if (PhotonNetwork.room == null)
		{
			DebugUtils.LogWarning(LogCategory.Network, "Cannot send RPCs in Lobby, only processed locally");
			return;
		}
		if (PhotonNetwork.player == null)
		{
			DebugUtils.LogError(LogCategory.Network, "Error; Sending RPC to player null! Aborted \"" + string_0 + "\"");
		}
		if (PhotonNetwork.networkingPeer != null)
		{
			PhotonNetwork.networkingPeer.SendRPCToPlayer(photonView_0, string_0, photonPlayer_0, bool_0, object_0);
		}
		else
		{
			DebugUtils.LogWarning(LogCategory.Network, "Could not execute RPC " + string_0 + ". Possible scene loading in progress?");
		}
	}

	// Token: 0x06004E18 RID: 19992 RVA: 0x00032BE9 File Offset: 0x00030DE9
	public static void RemoveRPCs()
	{
		if (!PhotonNetwork.VerifyCanUseNetwork())
		{
			return;
		}
		PhotonNetwork.RemoveRPCs(PhotonNetwork.player);
	}

	// Token: 0x06004E19 RID: 19993 RVA: 0x00032BFD File Offset: 0x00030DFD
	public static void RemoveRPCs(PhotonPlayer photonPlayer_0)
	{
		if (!PhotonNetwork.VerifyCanUseNetwork())
		{
			return;
		}
		if (!photonPlayer_0.isLocal && !PhotonNetwork.isMasterClient)
		{
			DebugUtils.LogError(LogCategory.Network, "Error; Only the MasterClient can call RemoveRPCs for other players.");
			return;
		}
		PhotonNetwork.networkingPeer.RemoveRPCs(photonPlayer_0.ActorId);
	}

	// Token: 0x06004E1A RID: 19994 RVA: 0x00032C33 File Offset: 0x00030E33
	public static void RemoveAllBufferedMessages()
	{
		if (!PhotonNetwork.VerifyCanUseNetwork())
		{
			return;
		}
		PhotonNetwork.RemoveAllBufferedMessages(PhotonNetwork.player);
	}

	// Token: 0x06004E1B RID: 19995 RVA: 0x00032C47 File Offset: 0x00030E47
	public static void RemoveAllBufferedMessages(PhotonPlayer photonPlayer_0)
	{
		if (!PhotonNetwork.VerifyCanUseNetwork())
		{
			return;
		}
		if (!photonPlayer_0.isLocal && !PhotonNetwork.isMasterClient)
		{
			DebugUtils.LogError(LogCategory.Network, "Error; Only the MasterClient can call RemoveAllBufferedMessages for other players.");
			return;
		}
		PhotonNetwork.networkingPeer.RemoveCompleteCacheOfPlayer(photonPlayer_0.ActorId);
	}

	// Token: 0x06004E1C RID: 19996 RVA: 0x00032C7D File Offset: 0x00030E7D
	public static void RemoveRPCs(PhotonView photonView_0)
	{
		if (!PhotonNetwork.VerifyCanUseNetwork())
		{
			return;
		}
		PhotonNetwork.networkingPeer.RemoveRPCs(photonView_0);
	}

	// Token: 0x06004E1D RID: 19997 RVA: 0x00032C92 File Offset: 0x00030E92
	public static void RemoveRPCsInGroup(int int_0)
	{
		if (!PhotonNetwork.VerifyCanUseNetwork())
		{
			return;
		}
		PhotonNetwork.networkingPeer.RemoveRPCsInGroup(int_0);
	}

	// Token: 0x06004E1E RID: 19998 RVA: 0x00032CA7 File Offset: 0x00030EA7
	public static void SetReceivingEnabled(int int_0, bool bool_0)
	{
		if (!PhotonNetwork.VerifyCanUseNetwork())
		{
			return;
		}
		PhotonNetwork.networkingPeer.SetReceivingEnabled(int_0, bool_0);
	}

	// Token: 0x06004E1F RID: 19999 RVA: 0x00032CBD File Offset: 0x00030EBD
	public static void SetSendingEnabled(int int_0, bool bool_0)
	{
		if (!PhotonNetwork.VerifyCanUseNetwork())
		{
			return;
		}
		PhotonNetwork.networkingPeer.SetSendingEnabled(int_0, bool_0);
	}

	// Token: 0x06004E20 RID: 20000 RVA: 0x00032CD3 File Offset: 0x00030ED3
	public static void SetLevelPrefix(short short_0)
	{
		if (!PhotonNetwork.VerifyCanUseNetwork())
		{
			return;
		}
		PhotonNetwork.networkingPeer.SetLevelPrefix(short_0);
	}

	// Token: 0x06004E21 RID: 20001 RVA: 0x00032CE8 File Offset: 0x00030EE8
	private static bool VerifyCanUseNetwork()
	{
		if (PhotonNetwork.networkingPeer != null && (PhotonNetwork.offlineMode || PhotonNetwork.connected))
		{
			return true;
		}
		if (DebugUtils.s_debugInfoSync != null)
		{
			DebugUtils.s_debugInfoSync.m_enabled = false;
		}
		DebugUtils.LogError(LogCategory.Network, "Cannot send messages when not connected; Either connect to Photon OR use offline mode!");
		return false;
	}

	// Token: 0x06004E22 RID: 20002 RVA: 0x00032D26 File Offset: 0x00030F26
	public static void LoadLevel(int int_0)
	{
		PhotonNetwork.isMessageQueueRunning = false;
		PhotonNetwork.networkingPeer.loadingLevelAndPausedNetwork = true;
		Application.LoadLevel(int_0);
	}

	// Token: 0x06004E23 RID: 20003 RVA: 0x00032D3F File Offset: 0x00030F3F
	public static void LoadLevel(string string_0)
	{
		PhotonNetwork.isMessageQueueRunning = false;
		PhotonNetwork.networkingPeer.loadingLevelAndPausedNetwork = true;
		Application.LoadLevel(string_0);
	}

	// Token: 0x06004E24 RID: 20004 RVA: 0x00032D58 File Offset: 0x00030F58
	public static float GetPingById(int int_0)
	{
		return PhotonNetwork.networkingPeer.GetPingById(int_0);
	}

	// Token: 0x06004E25 RID: 20005 RVA: 0x00032D65 File Offset: 0x00030F65
	public static float smethod_52()
	{
		return PhotonNetwork.networkingPeer.GetLowestPing();
	}

	// Token: 0x04003A3C RID: 14908
	public const string versionPUN = "1.18";

	// Token: 0x04003A3D RID: 14909
	public const string serverSettingsAssetFile = "PhotonServerSettings";

	// Token: 0x04003A3E RID: 14910
	public const string serverSettingsAssetPath = "Assets/Tools/Photon Unity Networking/Resources/PhotonServerSettings.asset";

	// Token: 0x04003A3F RID: 14911
	internal static readonly PhotonHandler photonMono;

	// Token: 0x04003A40 RID: 14912
	internal static readonly NetworkingPeer networkingPeer;

	// Token: 0x04003A41 RID: 14913
	internal static readonly OnlineServerPeer onlinePeer;

	// Token: 0x04003A42 RID: 14914
	public static readonly int MAX_VIEW_IDS = 100000;

	// Token: 0x04003A43 RID: 14915
	internal static ServerSettings PhotonServerSettings = (ServerSettings)ResourcesLoader.smethod_1("PhotonServerSettings", typeof(ServerSettings));

	// Token: 0x04003A44 RID: 14916
	public static float precisionForVectorSynchronization = 9.9E-05f;

	// Token: 0x04003A45 RID: 14917
	public static float precisionForQuaternionSynchronization = 1f;

	// Token: 0x04003A46 RID: 14918
	public static float precisionForFloatSynchronization = 0.01f;

	// Token: 0x04003A47 RID: 14919
	public static int BandwidthCap = 100;

	// Token: 0x04003A48 RID: 14920
	public static PhotonLogLevel logLevel = PhotonLogLevel.ErrorsOnly;

	// Token: 0x04003A49 RID: 14921
	public static bool UsePrefabCache = false;

	// Token: 0x04003A4A RID: 14922
	public static Dictionary<string, GameObject> PrefabCache = new Dictionary<string, GameObject>();

	// Token: 0x04003A4B RID: 14923
	private static bool isOfflineMode = false;

	// Token: 0x04003A4C RID: 14924
	private static bool offlineMode_inRoom = false;

	// Token: 0x04003A4D RID: 14925
	private static bool _mAutomaticallySyncScene = false;

	// Token: 0x04003A4E RID: 14926
	private static bool m_autoCleanUpPlayerObjects = true;

	// Token: 0x04003A4F RID: 14927
	private static bool autoJoinLobbyField = true;

	// Token: 0x04003A50 RID: 14928
	private static int sendInterval = 10;

	// Token: 0x04003A51 RID: 14929
	private static int sendIntervalOnSerialize = 66;

	// Token: 0x04003A52 RID: 14930
	private static bool m_isMessageQueueRunning = true;

	// Token: 0x04003A53 RID: 14931
	internal static int lastUsedViewSubId = 0;

	// Token: 0x04003A54 RID: 14932
	internal static int lastUsedViewSubIdStatic = 0;

	// Token: 0x04003A55 RID: 14933
	internal static List<int> manuallyAllocatedViewIds = new List<int>();
}
