using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using Core;
using ExitGames.Client.Photon;
using ExitGames.Client.Photon.Lite;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x02000B1C RID: 2844
internal class NetworkingPeer : LoadbalancingPeer, IPhotonPeerListener
{
	// Token: 0x06004CE0 RID: 19680 RVA: 0x001430D4 File Offset: 0x001412D4
	public NetworkingPeer(IPhotonPeerListener iphotonPeerListener_0, string string_0, ConnectionProtocol connectionProtocol_0)
		: base(iphotonPeerListener_0, connectionProtocol_0)
	{
		base.Listener = this;
		this.externalListener = iphotonPeerListener_0;
		this.playerName = string_0;
		this.mLocalActor = new PhotonPlayer(true, -1, this.playername);
		this.AddActor(this.mLocalActor.ActorId, this.mLocalActor);
		this.State = global::PeerState.PeerCreated;
		this.mFallbackSessions = new Queue<string>();
		base.LimitOfUnreliableCommands = 200;
		base.WarningSize = 200;
		base.ChannelCount = 3;
		this.MasterConnection = true;
		this.FirstConnectMaster = true;
	}

	// Token: 0x170007B8 RID: 1976
	// (get) Token: 0x06004CE3 RID: 19683 RVA: 0x00031F78 File Offset: 0x00030178
	// (set) Token: 0x06004CE2 RID: 19682 RVA: 0x00031F6F File Offset: 0x0003016F
	private bool MasterConnection { get; set; }

	// Token: 0x170007B9 RID: 1977
	// (get) Token: 0x06004CE5 RID: 19685 RVA: 0x00031F89 File Offset: 0x00030189
	// (set) Token: 0x06004CE4 RID: 19684 RVA: 0x00031F80 File Offset: 0x00030180
	private bool FirstConnectMaster { get; set; }

	// Token: 0x06004CE6 RID: 19686 RVA: 0x00031F91 File Offset: 0x00030191
	public void Reset()
	{
		this.FirstConnectMaster = true;
	}

	// Token: 0x170007BA RID: 1978
	// (get) Token: 0x06004CE7 RID: 19687 RVA: 0x00031F9A File Offset: 0x0003019A
	// (set) Token: 0x06004CE8 RID: 19688 RVA: 0x001432A4 File Offset: 0x001414A4
	public string playerName
	{
		get
		{
			return this.playername;
		}
		set
		{
			if (!string.IsNullOrEmpty(value) && !value.Equals(this.playername))
			{
				if (this.mLocalActor != null)
				{
					this.mLocalActor.String_0 = value;
				}
				this.playername = value;
				if (this.Room_0 != null)
				{
					this.UpdateLocalPlayerName();
				}
				return;
			}
		}
	}

	// Token: 0x170007BB RID: 1979
	// (get) Token: 0x06004CE9 RID: 19689 RVA: 0x00031FA2 File Offset: 0x000301A2
	// (set) Token: 0x06004CEA RID: 19690 RVA: 0x00031FAA File Offset: 0x000301AA
	public PeerState State { get; internal set; }

	// Token: 0x170007BC RID: 1980
	// (get) Token: 0x06004CEB RID: 19691 RVA: 0x00031FB3 File Offset: 0x000301B3
	public Room Room_0
	{
		get
		{
			if (this.mRoomToGetInto != null && this.mRoomToGetInto.isLocalClientInside)
			{
				return this.mRoomToGetInto;
			}
			return null;
		}
	}

	// Token: 0x170007BD RID: 1981
	// (get) Token: 0x06004CEC RID: 19692 RVA: 0x00031FD2 File Offset: 0x000301D2
	// (set) Token: 0x06004CED RID: 19693 RVA: 0x00031FDA File Offset: 0x000301DA
	internal Room mRoomToGetInto { get; set; }

	// Token: 0x170007BE RID: 1982
	// (get) Token: 0x06004CEE RID: 19694 RVA: 0x00031FE3 File Offset: 0x000301E3
	// (set) Token: 0x06004CEF RID: 19695 RVA: 0x00031FEB File Offset: 0x000301EB
	public PhotonPlayer mLocalActor { get; internal set; }

	// Token: 0x170007BF RID: 1983
	// (get) Token: 0x06004CF0 RID: 19696 RVA: 0x00031FF4 File Offset: 0x000301F4
	// (set) Token: 0x06004CF1 RID: 19697 RVA: 0x00031FFC File Offset: 0x000301FC
	public string mGameserver { get; internal set; }

	// Token: 0x170007C0 RID: 1984
	// (get) Token: 0x06004CF2 RID: 19698 RVA: 0x00032005 File Offset: 0x00030205
	// (set) Token: 0x06004CF3 RID: 19699 RVA: 0x0003200D File Offset: 0x0003020D
	public int mQueuePosition { get; internal set; }

	// Token: 0x170007C1 RID: 1985
	// (get) Token: 0x06004CF4 RID: 19700 RVA: 0x00032016 File Offset: 0x00030216
	// (set) Token: 0x06004CF5 RID: 19701 RVA: 0x0003201E File Offset: 0x0003021E
	public int mPlayersOnMasterCount { get; internal set; }

	// Token: 0x170007C2 RID: 1986
	// (get) Token: 0x06004CF6 RID: 19702 RVA: 0x00032027 File Offset: 0x00030227
	// (set) Token: 0x06004CF7 RID: 19703 RVA: 0x0003202F File Offset: 0x0003022F
	public int mGameCount { get; internal set; }

	// Token: 0x170007C3 RID: 1987
	// (get) Token: 0x06004CF8 RID: 19704 RVA: 0x00032038 File Offset: 0x00030238
	// (set) Token: 0x06004CF9 RID: 19705 RVA: 0x00032040 File Offset: 0x00030240
	public int mPlayersInRoomsCount { get; internal set; }

	// Token: 0x06004CFA RID: 19706 RVA: 0x00032049 File Offset: 0x00030249
	public ReadOnlyCollection<PhotonView> GetAllPhotonViews()
	{
		return this.photonViews.AsReadOnly();
	}

	// Token: 0x06004CFB RID: 19707 RVA: 0x00032056 File Offset: 0x00030256
	public ReadOnlyCollection<PhotonView> GetActivePhotonViews()
	{
		return this.photonActiveViews.AsReadOnly();
	}

	// Token: 0x06004CFC RID: 19708 RVA: 0x00032063 File Offset: 0x00030263
	public void GetActivePhotonViewsList(out List<PhotonView> list_0)
	{
		list_0 = this.photonActiveViews;
	}

	// Token: 0x06004CFD RID: 19709 RVA: 0x001432F4 File Offset: 0x001414F4
	public float GetPingById(int int_0)
	{
		float num = 0f;
		if (this.peerRoundTripTimes.TryGetValue(int_0, out num))
		{
			return num;
		}
		return 0f;
	}

	// Token: 0x06004CFE RID: 19710 RVA: 0x00143320 File Offset: 0x00141520
	public float GetLowestPing()
	{
		float num = 0f;
		if (peerRoundTripTimes.Count > 0)
		{
			num = float.MaxValue;
		}
		Dictionary<int, float>.Enumerator enumerator = peerRoundTripTimes.GetEnumerator();
		while (enumerator.MoveNext())
		{
			if (enumerator.Current.Value < num)
			{
				num = enumerator.Current.Value;
			}
		}
		return num;
	}
	// Token: 0x06004CFF RID: 19711 RVA: 0x00143384 File Offset: 0x00141584
	public override bool Connect(string serverAddress, string appID)
	{
		if (PhotonNetwork.connectionStateDetailed == global::PeerState.Disconnecting)
		{
			DebugUtils.LogError(LogCategory.Network, "ERROR: Cannot connect to Photon while Disconnecting. Connection failed.");
			return false;
		}
		if (string.IsNullOrEmpty(this.masterServerAddress))
		{
			this.masterServerAddress = serverAddress;
		}
		this.mAppId = appID.Trim();
		bool flag = base.Connect(serverAddress, string.Empty);
		this.State = ((!flag) ? global::PeerState.Disconnected : global::PeerState.Connecting);
		return flag;
	}

	// Token: 0x06004D00 RID: 19712 RVA: 0x001433E4 File Offset: 0x001415E4
	public override void Disconnect()
	{
		if (base.PeerState == PeerStateValue.Disconnected)
		{
			if (base.DebugOut >= DebugLevel.WARNING)
			{
				this.DebugReturn(DebugLevel.WARNING, string.Format("Can't execute Disconnect() while not connected. Nothing changed. State: {0}", this.State));
			}
			return;
		}
		MonoSingleton<DebugInfoManager>.Instance.method_3();
		base.Disconnect();
		this.State = global::PeerState.Disconnecting;
		this.ResetRoomState();
		this.LeaveLobbyIfInside();
	}

	// Token: 0x06004D01 RID: 19713 RVA: 0x0003206D File Offset: 0x0003026D
	private void DisconnectFromMasterServer()
	{
		base.Disconnect();
		this.State = global::PeerState.DisconnectingFromMasterserver;
		this.LeaveLobbyIfInside();
	}

	// Token: 0x06004D02 RID: 19714 RVA: 0x00032082 File Offset: 0x00030282
	private void DisconnectFromGameServer()
	{
		base.Disconnect();
		this.State = global::PeerState.DisconnectingFromGameserver;
		this.ResetRoomState();
	}

	// Token: 0x06004D03 RID: 19715 RVA: 0x00032098 File Offset: 0x00030298
	private void LeaveLobbyIfInside()
	{
		if (!this.insideLobby)
		{
			return;
		}
		NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnLeftLobby, new object[0]);
		this.insideLobby = false;
	}

	// Token: 0x06004D04 RID: 19716 RVA: 0x00143444 File Offset: 0x00141644
	private void ResetRoomState()
	{
		bool flag = this.mRoomToGetInto != null;
		bool flag2 = ((this.mRoomToGetInto == null) ? PhotonNetwork.autoCleanUpPlayerObjects : this.mRoomToGetInto.Boolean_4);
		this.mRoomToGetInto = null;
		this.mActors = new Dictionary<int, PhotonPlayer>();
		this.mPlayerListCopy = new PhotonPlayer[0];
		this.mOtherPlayerListCopy = new PhotonPlayer[0];
		this.mMasterClient = null;
		this.allowedReceivingGroups = new HashSet<int>();
		this.blockSendingGroups = new HashSet<int>();
		this.mGameList = new Dictionary<string, RoomInfo>();
		this.mGameListCopy = new RoomInfo[0];
		this.networkingPriority.method_4();
		this.instantiatingPhotonViews = new List<NetworkingPeer.InstantiatingPhotonViews>();
		this.removingInstantiatingPhotonViews = new List<NetworkingPeer.InstantiatingPhotonViews>();
		this.SetLocalActorId(-1);
		if (flag2)
		{
			List<GameObject> list = new List<GameObject>(this.instantiatedObjects.Values);
			foreach (PhotonView photonView in this.photonViewList.Values)
			{
				if (photonView != null && !photonView.Boolean_0 && photonView.gameObject != null)
				{
					list.Add(photonView.gameObject);
				}
			}
			for (int i = list.Count - 1; i >= 0; i--)
			{
				GameObject gameObject = list[i];
				if (gameObject != null)
				{
					if (base.DebugOut >= DebugLevel.ALL)
					{
						this.DebugReturn(DebugLevel.ALL, "Network destroy Instantiated GO: " + gameObject.name);
					}
					this.DestroyInstantiatedObject(gameObject);
				}
			}
			this.instantiatedObjects = new Dictionary<int, GameObject>();
			PhotonNetwork.manuallyAllocatedViewIds = new List<int>();
			PhotonNetwork.lastUsedViewSubId = 0;
			PhotonNetwork.lastUsedViewSubIdStatic = 0;
		}
		if (flag)
		{
			NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnLeftRoom, new object[0]);
		}
	}

	// Token: 0x06004D05 RID: 19717 RVA: 0x0014360C File Offset: 0x0014180C
	private void DestroyInstantiatedObject(GameObject gameObject_0)
	{
		PhotonView[] componentsInChildren = gameObject_0.GetComponentsInChildren<PhotonView>(true);
		foreach (PhotonView photonView in componentsInChildren)
		{
			if (photonView != null)
			{
				photonView.destroyedByPhotonNetworkOrQuit = true;
				this.UnregisterPhotonView(photonView);
			}
		}
		global::UnityEngine.Object.Destroy(gameObject_0);
	}

	// Token: 0x06004D06 RID: 19718 RVA: 0x00143654 File Offset: 0x00141854
	private void ApplyRoomAndActorProperties(Hashtable hashtable_0, Hashtable hashtable_1, int int_0)
	{
		if (this.Room_0 != null && hashtable_0 != null)
		{
			this.Room_0.ApplyPropertiesUpdate(hashtable_0);
			if (PhotonNetwork.automaticallySyncScene)
			{
				this.AutomaticallySyncScene();
			}
		}
		if (hashtable_1 != null && hashtable_1.Count > 0)
		{
			if (int_0 > 0)
			{
				PhotonPlayer photonPlayer = this.GetActorById(int_0);
				if (photonPlayer != null)
				{
					photonPlayer.method_0(this.UnwrapActorProperties(hashtable_1, int_0));
				}
			}
			else
			{
				foreach (object obj in hashtable_1.Keys)
				{
					int num = (int)obj;
					Hashtable hashtable = (Hashtable)hashtable_1[obj];
					string text = (string)hashtable[byte.MaxValue];
					PhotonPlayer photonPlayer2 = this.GetActorById(num);
					if (photonPlayer2 == null)
					{
						photonPlayer2 = new PhotonPlayer(false, num, text);
						this.AddActor(num, photonPlayer2);
					}
					photonPlayer2.method_0(hashtable);
				}
			}
		}
	}

	// Token: 0x06004D07 RID: 19719 RVA: 0x000320B6 File Offset: 0x000302B6
	private void AddActor(int int_0, PhotonPlayer photonPlayer_0)
	{
		if (!this.mActors.ContainsKey(int_0))
		{
			this.mActors[int_0] = photonPlayer_0;
			this.RebuildPlayerListCopies();
		}
		else
		{
			DebugUtils.LogError(LogCategory.Network, "Adding player twice: " + int_0);
		}
	}

	// Token: 0x06004D08 RID: 19720 RVA: 0x000320F2 File Offset: 0x000302F2
	private void RemoveActor(int int_0, PhotonPlayer photonPlayer_0)
	{
		this.mActors.Remove(int_0);
		this.networkingPriority.method_5(photonPlayer_0);
		this.peerRoundTripTimes.Remove(int_0);
		if (!photonPlayer_0.isLocal)
		{
			this.RebuildPlayerListCopies();
		}
	}

	// Token: 0x06004D09 RID: 19721 RVA: 0x0014375C File Offset: 0x0014195C
	private void RebuildPlayerListCopies()
	{
		this.mPlayerListCopy = new PhotonPlayer[this.mActors.Count];
		this.mActors.Values.CopyTo(this.mPlayerListCopy, 0);
		List<PhotonPlayer> list = new List<PhotonPlayer>();
		foreach (PhotonPlayer photonPlayer in this.mPlayerListCopy)
		{
			if (!photonPlayer.isLocal)
			{
				list.Add(photonPlayer);
			}
		}
		this.mOtherPlayerListCopy = list.ToArray();
	}

	// Token: 0x06004D0A RID: 19722 RVA: 0x001437D0 File Offset: 0x001419D0
	private void ResetSerializeCaches()
	{
		foreach (PhotonView photonView in this.photonViewList.Values)
		{
			photonView.lastOnSerializeDataSentPerPlayer.Clear();
			photonView.firstSent = true;
		}
	}

	// Token: 0x06004D0B RID: 19723 RVA: 0x00143834 File Offset: 0x00141A34
	private void HandleActorLeft(int int_0)
	{
		if (base.DebugOut >= DebugLevel.INFO)
		{
			this.DebugReturn(DebugLevel.INFO, "HandleEventLeave actorNr: " + int_0);
		}
		if (int_0 >= 0 && this.mActors.ContainsKey(int_0))
		{
			PhotonPlayer photonPlayer = this.GetActorById(int_0);
			if (photonPlayer == null)
			{
				DebugUtils.LogError(LogCategory.Network, "Error: HandleEventLeave for actorID=" + int_0 + " has no PhotonPlayer!");
			}
			if (this.mMasterClient != null && this.mMasterClient.ActorId == int_0)
			{
				this.mMasterClient = null;
			}
			this.ElectMasterClient(int_0);
			if (this.Room_0 != null && this.Room_0.Boolean_4)
			{
				this.DestroyPlayerObjects(photonPlayer, true);
			}
			this.RemoveActor(int_0, photonPlayer);
			NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnPhotonPlayerDisconnected, new object[] { photonPlayer });
			return;
		}
		if (base.DebugOut >= DebugLevel.ERROR)
		{
			this.DebugReturn(DebugLevel.ERROR, string.Format("Received event Leave for unknown actorNumber: {0}", int_0));
		}
	}

	// Token: 0x06004D0C RID: 19724 RVA: 0x0014391C File Offset: 0x00141B1C
	private void ElectMasterClient(int int_0)
	{
		int num = int.MaxValue;
		if (this.mMasterClient != null && this.mActors.ContainsKey(this.mMasterClient.ActorId))
		{
			return;
		}
		foreach (int num2 in this.mActors.Keys)
		{
			if (int_0 == -1 || int_0 != num2)
			{
				if (num2 < num)
				{
					num = num2;
				}
			}
		}
		if (this.mMasterClient == null || this.mMasterClient.ActorId != num)
		{
			bool flag = this.mMasterClient != null;
			this.mMasterClient = this.mActors[num];
			if (flag)
			{
				NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnMasterClientSwitched, new object[] { this.mMasterClient });
			}
		}
	}

	// Token: 0x06004D0D RID: 19725 RVA: 0x00032128 File Offset: 0x00030328
	private Hashtable UnwrapActorProperties(Hashtable hashtable_0, int int_0)
	{
		if (hashtable_0.ContainsKey(int_0))
		{
			return (Hashtable)hashtable_0[int_0];
		}
		return hashtable_0;
	}

	// Token: 0x06004D0E RID: 19726 RVA: 0x0003214B File Offset: 0x0003034B
	private PhotonPlayer GetActorById(int int_0)
	{
		if (this.mActors != null && this.mActors.ContainsKey(int_0))
		{
			return this.mActors[int_0];
		}
		return null;
	}

	// Token: 0x06004D0F RID: 19727 RVA: 0x001439F0 File Offset: 0x00141BF0
	private void UpdateLocalPlayerName()
	{
		if (this.State == global::PeerState.Joining)
		{
			this.mPlayernameHasToBeUpdated = true;
			return;
		}
		if (this.mLocalActor != null)
		{
			this.mLocalActor.String_0 = this.playerName;
			Hashtable hashtable = new Hashtable();
			hashtable[byte.MaxValue] = this.playerName;
			this.OpSetActorProperties(this.mLocalActor.ActorId, hashtable, true, 0);
			this.mPlayernameHasToBeUpdated = false;
		}
	}

	// Token: 0x06004D10 RID: 19728 RVA: 0x00143A60 File Offset: 0x00141C60
	private void HandleJoinRoomResponse(OperationResponse operationResponse_0)
	{
		if (operationResponse_0.ReturnCode != 0)
		{
			byte operationCode = operationResponse_0.OperationCode;
			switch (operationCode)
			{
			case 225:
				DebugUtils.LogWarning(LogCategory.Network, string.Concat(new object[] { "JoinRandomGame failed on GameServer. Changing back to MasterServer. Msg:", operationResponse_0.DebugMessage, "[", operationResponse_0.ReturnCode, "]" }));
				if (operationResponse_0.ReturnCode == 32758)
				{
					DebugUtils.Log(LogCategory.Network, "Most likely the game became empty during the switch to GameServer.");
				}
				NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnPhotonRandomJoinFailed, new object[0]);
				goto IL_016B;
			case 226:
				break;
			case 227:
				this.DebugReturn(DebugLevel.ERROR, "Create failed on GameServer. Changing back to MasterServer. Msg: " + operationResponse_0.DebugMessage);
				NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnPhotonCreateRoomFailed, new object[0]);
				goto IL_016B;
			default:
				if (operationCode != 127 && operationCode != 198)
				{
					goto IL_016B;
				}
				break;
			}
			if (this.mFallbackSessions.Count > 0)
			{
				this.DebugReturn(DebugLevel.WARNING, "Join failed on GameServer. Retrying. Msg: " + operationResponse_0.DebugMessage);
				string text = this.mFallbackSessions.Dequeue();
				Room room = new Room(text, this.mRoomToGetInto.Hashtable_0);
				this.mRoomToGetInto = room;
				this.OpJoin(text, this.mRoomToGetInto.Hashtable_0);
				return;
			}
			this.DebugReturn(DebugLevel.WARNING, "Join failed on GameServer. Changing back to MasterServer. Msg: " + operationResponse_0.DebugMessage);
			if (operationResponse_0.ReturnCode == 32758)
			{
				DebugUtils.Log(LogCategory.Network, "Most likely the game became empty during the switch to GameServer.");
			}
			NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnPhotonJoinRoomFailed, new object[0]);
			IL_016B:
			this.DisconnectFromGameServer();
			return;
		}
		this.State = global::PeerState.Joined;
		this.mRoomToGetInto.isLocalClientInside = true;
		Hashtable hashtable = (Hashtable)operationResponse_0[249];
		Hashtable hashtable2 = (Hashtable)operationResponse_0[248];
		this.ApplyRoomAndActorProperties(hashtable2, hashtable, 0);
		int num = (int)operationResponse_0[254];
		this.SetLocalActorId(num);
		this.ElectMasterClient(-1);
		if (this.mPlayernameHasToBeUpdated)
		{
			this.UpdateLocalPlayerName();
		}
		switch (operationResponse_0.OperationCode)
		{
		case 227:
			NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnCreatedRoom, new object[0]);
			break;
		}
	}

	// Token: 0x06004D11 RID: 19729 RVA: 0x00143C7C File Offset: 0x00141E7C
	private Hashtable BuildLocalPlayerProperties()
	{
		if (PhotonNetwork.player != null)
		{
			return PhotonNetwork.player.Hashtable_0;
		}
		Hashtable hashtable = new Hashtable();
		hashtable[byte.MaxValue] = this.playerName;
		return hashtable;
	}

	// Token: 0x06004D12 RID: 19730 RVA: 0x00143CB8 File Offset: 0x00141EB8
	public void SetLocalActorId(int int_0)
	{
		if (this.mLocalActor == null)
		{
			DebugUtils.LogWarning(LogCategory.Network, string.Format("Local actor is null or not in mActors! mLocalActor: {0} mActors==null: {1} newID: {2}", this.mLocalActor, this.mActors == null, int_0));
		}
		if (this.mActors.ContainsKey(this.mLocalActor.ActorId))
		{
			this.mActors.Remove(this.mLocalActor.ActorId);
		}
		this.mLocalActor.method_1(int_0);
		this.mActors[this.mLocalActor.ActorId] = this.mLocalActor;
		this.RebuildPlayerListCopies();
	}

	// Token: 0x06004D13 RID: 19731 RVA: 0x00143D58 File Offset: 0x00141F58
	public bool OpCreateRoom(string string_0, bool bool_0, bool bool_1, byte byte_0, bool bool_2, Hashtable hashtable_0, string[] string_1)
	{
		this.mRoomToGetInto = new Room(string_0, hashtable_0, bool_0, bool_1, (int)byte_0, bool_2, string_1);
		return base.vmethod_2(string_0, bool_0, bool_1, byte_0, bool_2, hashtable_0, this.BuildLocalPlayerProperties(), string_1);
	}

	// Token: 0x06004D14 RID: 19732 RVA: 0x00032171 File Offset: 0x00030371
	public bool OpExecuteQuery(Query query_0, int int_0 = 50)
	{
		return base.method_0(query_0.Parameters, query_0.Operations, int_0);
	}

	// Token: 0x06004D15 RID: 19733 RVA: 0x00143D94 File Offset: 0x00141F94
	public bool OpJoin(string string_0, Hashtable hashtable_0 = null)
	{
		DebugUtils.Log(LogCategory.Network, "OpJoin");
		Hashtable hashtable = new Hashtable();
		hashtable[246] = this.maccount;
		hashtable[253] = true;
		hashtable[249] = true;
		if (hashtable_0 != null)
		{
			hashtable[247] = ((!hashtable_0.ContainsKey("PlaylistId")) ? MonoSingleton<AppManager>.Instance.m_playlistId : ((int)hashtable_0["PlaylistId"]));
			hashtable[245] = ((!hashtable_0.ContainsKey("GameMode")) ? (-1) : ((int)hashtable_0["GameMode"]));
			hashtable[244] = ((!hashtable_0.ContainsKey("PlayerLevel")) ? (-1) : ((int)hashtable_0["PlayerLevel"]));
			hashtable[243] = ((!hashtable_0.ContainsKey("ForceStartGameTime")) ? 0 : ((int)hashtable_0["ForceStartGameTime"]));
			hashtable[242] = !hashtable_0.ContainsKey("JoinInProgress") || (bool)hashtable_0["JoinInProgress"];
			hashtable[241] = hashtable_0.ContainsKey("GroupMatchmakingEnabled") && (bool)hashtable_0["GroupMatchmakingEnabled"];
			hashtable[240] = hashtable_0.ContainsKey("LevelledMatchmaking") && (bool)hashtable_0["LevelledMatchmaking"];
			hashtable[239] = ((!hashtable_0.ContainsKey("Difficulty")) ? 0 : ((int)hashtable_0["Difficulty"]));
			hashtable[253] = !hashtable_0.ContainsKey("IsOpen") || (bool)hashtable_0["IsOpen"];
		}
		else
		{
			hashtable[247] = MonoSingleton<AppManager>.Instance.m_playlistId;
		}
		Playlist playlist = MatchmakingService.MatchmakingService_0.method_1(MonoSingleton<AppManager>.Instance.m_playlistId);
		hashtable[248] = (byte)playlist.m_minPlayerCountToStart;
		hashtable[byte.MaxValue] = (byte)playlist.m_maxPlayerCount;
		if (!hashtable.ContainsKey(245))
		{
			hashtable[245] = (int)MatchmakingService.smethod_0(playlist.m_gameMode);
		}
		if (this.mFallbackSessions != null && this.mFallbackSessions.Count > 0)
		{
			hashtable[238] = this.mFallbackSessions.ToArray();
		}
		return this.vmethod_3(string_0, this.BuildLocalPlayerProperties(), hashtable);
	}

	// Token: 0x06004D16 RID: 19734 RVA: 0x00032186 File Offset: 0x00030386
	public override bool OpJoinRandomRoom(Hashtable hashtable_0, byte byte_0, Hashtable hashtable_1, MatchmakingMode matchmakingMode_0)
	{
		DebugUtils.Log(LogCategory.Network, "OpJoinRandomRoom");
		this.mRoomToGetInto = new Room(null, null);
		return base.OpJoinRandomRoom(hashtable_0, byte_0, hashtable_1, matchmakingMode_0);
	}

	// Token: 0x06004D17 RID: 19735 RVA: 0x001440C0 File Offset: 0x001422C0
	public override bool OpAuthenticate(string string_0, string string_1, string string_2, string string_3)
	{
		Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
		dictionary[220] = string_1;
		dictionary[224] = string_0;
		if (base.DebugOut >= DebugLevel.INFO)
		{
			base.Listener.DebugReturn(DebugLevel.INFO, "OpAuthenticate()");
		}
		if (this.MasterConnection && this.FirstConnectMaster)
		{
			if (!MonoSingleton<AppManager>.Instance.m_enableSndaLogin)
			{
				dictionary[104] = string_2;
				dictionary[109] = string_3;
				dictionary[105] = 1;
			}
			else
			{
				dictionary[221] = string_2;
				dictionary[105] = 0;
			}
		}
		else
		{
			dictionary[110] = OnlineService.s_accountId;
			dictionary[221] = this.mToken;
			dictionary[105] = 2;
		}
		dictionary[0] = OnlineService.s_characterId;
		return this.OpCustom(230, dictionary, true, 0, base.IsEncryptionAvailable);
	}

	// Token: 0x06004D18 RID: 19736 RVA: 0x000321AC File Offset: 0x000303AC
	public virtual bool OpCancelJoin()
	{
		if (this.State != global::PeerState.Joining)
		{
			this.DebugReturn(DebugLevel.ERROR, string.Format("NetworkingPeer.OpCancelJoin() - ERROR: We are not currently joining a game (Current state = {0}).", this.State));
			return false;
		}
		return this.OpCustom(167, null, true, 0);
	}

	// Token: 0x06004D19 RID: 19737 RVA: 0x000321E4 File Offset: 0x000303E4
	public virtual bool OpLeaveRoom()
	{
		if (this.State != global::PeerState.Joined)
		{
			this.DebugReturn(DebugLevel.ERROR, "NetworkingPeer::leaveGame() - ERROR: no game is currently joined");
			return false;
		}
		return this.OpCustom(254, null, true, 0);
	}

	// Token: 0x06004D1A RID: 19738 RVA: 0x0003220C File Offset: 0x0003040C
	public override bool RaiseEventForGroup(byte byte_0, byte byte_1, Hashtable hashtable_0, bool bool_0, byte byte_2)
	{
		return !PhotonNetwork.offlineMode && base.RaiseEventForGroup(byte_0, byte_1, hashtable_0, bool_0, byte_2);
	}

	// Token: 0x06004D1B RID: 19739 RVA: 0x00032224 File Offset: 0x00030424
	public override bool RaiseEventToActorsCached(byte byte_0, Hashtable hashtable_0, bool bool_0, byte byte_1, int[] int_0, EventCaching eventCaching_0)
	{
		return !PhotonNetwork.offlineMode && base.RaiseEventToActorsCached(byte_0, hashtable_0, bool_0, byte_1, int_0, eventCaching_0);
	}

	// Token: 0x06004D1C RID: 19740 RVA: 0x0003223E File Offset: 0x0003043E
	public override bool RaiseEvent(byte byte_0, Hashtable hashtable_0, bool bool_0, byte byte_1, EventCaching eventCaching_0, ReceiverGroup receiverGroup_0)
	{
		return !PhotonNetwork.offlineMode && base.RaiseEvent(byte_0, hashtable_0, bool_0, byte_1, eventCaching_0, receiverGroup_0);
	}

	// Token: 0x06004D1D RID: 19741 RVA: 0x00032258 File Offset: 0x00030458
	public override bool OpChangeGroups(byte[] byte_0, byte[] byte_1)
	{
		return !PhotonNetwork.offlineMode && base.OpChangeGroups(byte_0, byte_1);
	}

	// Token: 0x06004D1E RID: 19742 RVA: 0x0003226B File Offset: 0x0003046B
	public void DebugReturn(DebugLevel level, string message)
	{
		this.externalListener.DebugReturn(level, message);
	}

	// Token: 0x06004D1F RID: 19743 RVA: 0x001441B8 File Offset: 0x001423B8
	public void OnOperationResponse(OperationResponse operationResponse)
	{
		try
		{
			if (PhotonNetwork.networkingPeer.State == global::PeerState.Disconnecting)
			{
				if (base.DebugOut >= DebugLevel.INFO)
				{
					this.DebugReturn(DebugLevel.INFO, "OperationResponse ignored while disconnecting: " + operationResponse.OperationCode.ToString());
				}
				return;
			}
			if (operationResponse == null)
			{
				return;
			}
			if (operationResponse.ReturnCode == 0)
			{
				if (base.DebugOut >= DebugLevel.INFO)
				{
					this.DebugReturn(DebugLevel.INFO, operationResponse.ToString());
				}
			}
			else if (base.DebugOut >= DebugLevel.WARNING)
			{
				if (operationResponse.ReturnCode == -3)
				{
					this.DebugReturn(DebugLevel.WARNING, "Operation could not be executed yet. Wait for state JoinedLobby or ConnectedToMaster and their respective callbacks before calling OPs. Client must be authorized.");
				}
				this.DebugReturn(DebugLevel.WARNING, operationResponse.ToStringFull());
			}
			byte operationCode = operationResponse.OperationCode;
			switch (operationCode)
			{
			case 221:
				foreach (object obj in ((Hashtable)operationResponse.Parameters[222]))
				{
					DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
					string text = (string)dictionaryEntry.Key;
					Room room = new Room(text, (Hashtable)dictionaryEntry.Value);
					if (room.removedFromList)
					{
						this.mGameList.Remove(text);
					}
					else
					{
						this.mGameList[text] = room;
					}
				}
				this.mGameListCopy = new RoomInfo[this.mGameList.Count];
				this.mGameList.Values.CopyTo(this.mGameListCopy, 0);
				NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnReceivedRoomListUpdate, new object[0]);
				goto IL_0A25;
			case 225:
			case 226:
				goto IL_0806;
			case 227:
			{
				if (this.State == global::PeerState.Joining)
				{
					this.HandleJoinRoomResponse(operationResponse);
					goto IL_0A25;
				}
				if (operationResponse.ReturnCode != 0)
				{
					DebugUtils.LogError(LogCategory.Network, "OperationCode.CreateGame fail[" + operationResponse.ToStringFull() + "]");
					NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnPhotonCreateRoomFailed, new object[0]);
					goto IL_0A25;
				}
				string text2 = (string)operationResponse[byte.MaxValue];
				if (!string.IsNullOrEmpty(text2))
				{
					this.mRoomToGetInto.String_1 = text2;
				}
				this.mGameserver = (string)operationResponse[230];
				string[] array = this.mGameserver.Split(new char[] { ':' });
				if (array[0].Equals("127.0.0.1"))
				{
					string text3 = base.ServerAddress.Split(new char[] { ':' })[0];
					this.mGameserver = text3 + ":" + array[1];
				}
				DebugUtils.Log(LogCategory.Network, "New GameServer: " + this.mGameserver);
				this.DisconnectFromMasterServer();
				this.mLastJoinType = JoinType.CreateGame;
				goto IL_0A25;
			}
			case 228:
				this.State = global::PeerState.Authenticated;
				this.LeaveLobbyIfInside();
				goto IL_0A25;
			case 229:
				this.State = global::PeerState.JoinedLobby;
				this.insideLobby = true;
				NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnJoinedLobby, new object[0]);
				goto IL_0A25;
			case 230:
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
					try
					{
						string text4 = null;
						if (operationResponse.Parameters != null && operationResponse.Parameters.ContainsKey(250))
						{
							text4 = operationResponse.Parameters[250] as string;
						}
						if (!string.IsNullOrEmpty(text4))
						{
							NetworkManager component = MonoSingleton<AppManager>.Instance.GetComponent<NetworkManager>();
							if (component != null)
							{
								component.SuppressNextDisconnectPopup(true);
							}
							MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDWarningView>().vmethod_7(text4, delegate
							{
							}, null);
						}
					}
					catch (Exception ex)
					{
						DebugUtils.LogError(LogCategory.Network, "[DIAG] auth fail message display EXCEPTION: " + ex.ToString());
					}
					this.Disconnect();
					this.State = global::PeerState.Disconnecting;
					if (operationResponse.ReturnCode == 32757)
					{
						this.DebugReturn(DebugLevel.ERROR, string.Format("Currently, the limit of users is reached for this title. Try again later. Disconnecting", new object[0]));
						NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnPhotonMaxCccuReached, new object[0]);
						NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnConnectionFail, new object[] { DisconnectCause.MaxCcuReached });
						goto IL_0A25;
					}
					if (operationResponse.ReturnCode == 32756)
					{
						this.DebugReturn(DebugLevel.ERROR, string.Format("The used master server address is not available with the subscription currently used. Got to Photon Cloud Dashboard or change URL. Disconnecting", new object[0]));
						NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnConnectionFail, new object[] { DisconnectCause.InvalidRegion });
						goto IL_0A25;
					}
					goto IL_0A25;
				}
				else
				{
					if (this.MasterConnection && this.FirstConnectMaster)
					{
						if (operationResponse.Parameters.ContainsKey(221))
						{
							this.mToken = (string)operationResponse[221];
							PhotonNetwork.onlinePeer.mToken = this.mToken;
							OnlineService.s_accountId = (int)operationResponse[110];
						}
						if (operationResponse.Parameters.ContainsKey(220))
						{
							OnlineService.s_serverVersionId = (string)operationResponse[220];
						}
						this.FirstConnectMaster = false;
					}
					if (this.State != global::PeerState.Connected && this.State != global::PeerState.ConnectedComingFromGameserver)
					{
						if (this.State != global::PeerState.ConnectedToGameserver)
						{
							goto IL_0A25;
						}
						this.State = global::PeerState.Joining;
						if (this.mLastJoinType == JoinType.JoinGame || this.mLastJoinType == JoinType.JoinRandomGame)
						{
							this.OpJoin(this.mRoomToGetInto.String_1, this.mRoomToGetInto.Hashtable_0);
							goto IL_0A25;
						}
						if (this.mLastJoinType == JoinType.CreateGame)
						{
							this.OpCreateRoom(this.mRoomToGetInto.String_1, this.mRoomToGetInto.Boolean_3, this.mRoomToGetInto.Boolean_2, (byte)this.mRoomToGetInto.maxPlayers, this.mRoomToGetInto.Boolean_4, this.mRoomToGetInto.Hashtable_0, this.mRoomToGetInto.propertiesListedInLobby);
							goto IL_0A25;
						}
						goto IL_0A25;
					}
					else
					{
						if (operationResponse.Parameters.ContainsKey(223))
						{
							this.mQueuePosition = (int)operationResponse[223];
							if (this.mQueuePosition > 0)
							{
								if (this.State == global::PeerState.ConnectedComingFromGameserver)
								{
									this.State = global::PeerState.QueuedComingFromGameserver;
									goto IL_0A25;
								}
								this.State = global::PeerState.Queued;
								goto IL_0A25;
							}
						}
						if (PhotonNetwork.autoJoinLobby)
						{
							this.vmethod_0();
							this.State = global::PeerState.Authenticated;
							if (operationResponse.Parameters.ContainsKey(108))
							{
								NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnConnectedToMaster, new object[] { (string)operationResponse.Parameters[108] });
								goto IL_0A25;
							}
							NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnConnectedToMaster, new object[] { string.Empty });
							goto IL_0A25;
						}
						else
						{
							this.State = global::PeerState.ConnectedToMaster;
							if (operationResponse.Parameters.ContainsKey(108))
							{
								NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnConnectedToMaster, new object[] { (string)operationResponse.Parameters[108] });
								goto IL_0A25;
							}
							NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnConnectedToMaster, new object[] { string.Empty });
							goto IL_0A25;
						}
					}
				}
				break;
			}
			switch (operationCode)
			{
			case 251:
			{
				Hashtable hashtable = (Hashtable)operationResponse[249];
				Hashtable hashtable2 = (Hashtable)operationResponse[248];
				this.ApplyRoomAndActorProperties(hashtable2, hashtable, 0);
				goto IL_0A25;
			}
			case 252:
			case 253:
				goto IL_0A25;
			case 254:
				break;
			default:
				if (operationCode == 197)
				{
					bool flag = (bool)operationResponse.Parameters[0];
					OnAccessSingleton<IGameInvitationService, GameInvitationService, GameInvitationServiceOffline>.Prop_0.OnIsFriendsGameJoinable(flag);
					goto IL_0A25;
				}
				if (operationCode == 198 || operationCode == 127)
				{
					goto IL_0806;
				}
				if (operationCode != 167)
				{
					if (this.mOperationResponseCallbacks.ContainsKey(operationResponse.OperationCode))
					{
						this.mOperationResponseCallbacks[operationResponse.OperationCode](operationResponse.ReturnCode, operationResponse.Parameters);
						goto IL_0A25;
					}
					if (base.DebugOut >= DebugLevel.ERROR)
					{
						this.DebugReturn(DebugLevel.ERROR, string.Format("operationResponse unhandled: {0}", operationResponse.ToString()));
						goto IL_0A25;
					}
					goto IL_0A25;
				}
				break;
			}
			this.DisconnectFromGameServer();
			goto IL_0A25;
			IL_0806:
			if (this.State != global::PeerState.Joining)
			{
				if (operationResponse.ReturnCode != 0)
				{
					NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnPhotonJoinRoomFailed, new object[0]);
					DebugUtils.LogError(LogCategory.Network, string.Concat(new object[]
					{
						"[",
						operationResponse.OperationCode,
						"] failed (no open game). Client stays on masterserver: ",
						operationResponse.ToStringFull(),
						" / ",
						operationResponse.ReturnCode
					}));
				}
				else
				{
					string text5 = (string)operationResponse[byte.MaxValue];
					Hashtable hashtable3 = (Hashtable)operationResponse[248];
					Hashtable hashtable4 = (Hashtable)operationResponse[234];
					this.mFallbackSessions.Clear();
					if (hashtable4 != null)
					{
						foreach (object obj2 in hashtable4)
						{
							DictionaryEntry dictionaryEntry2 = (DictionaryEntry)obj2;
							this.mFallbackSessions.Enqueue((string)dictionaryEntry2.Value);
						}
					}
					this.mRoomToGetInto = new Room(text5, hashtable3);
					this.mGameserver = (string)operationResponse[230];
					if (this.mGameserver == null)
					{
						DebugUtils.LogError(LogCategory.Network, string.Concat(new object[]
						{
							"[",
							operationResponse.OperationCode,
							"] mGameserver==null [",
							operationResponse.ToStringFull(),
							"][",
							text5,
							"][",
							hashtable3,
							"][",
							hashtable4
						}));
					}
					else
					{
						string[] array2 = this.mGameserver.Split(new char[] { ':' });
						if (array2[0].Equals("127.0.0.1"))
						{
							string text6 = base.ServerAddress.Split(new char[] { ':' })[0];
							this.mGameserver = text6 + ":" + array2[1];
						}
						DebugUtils.Log(LogCategory.Network, "New GameServer: " + this.mGameserver);
						this.DisconnectFromMasterServer();
						this.mLastJoinType = JoinType.JoinGame;
					}
				}
			}
			else
			{
				this.HandleJoinRoomResponse(operationResponse);
			}
			IL_0A25:;
		}
		catch (Exception ex2)
		{
			DebugUtils.LogError(LogCategory.Network, string.Concat(new object[] { "Exception [", ex2, "] on Operation [", operationResponse, "]" }));
		}
		this.externalListener.OnOperationResponse(operationResponse);
	}

	// Token: 0x06004D20 RID: 19744 RVA: 0x00144C94 File Offset: 0x00142E94
	public void OnStatusChanged(StatusCode statusCode)
	{
		if (base.DebugOut >= DebugLevel.INFO)
		{
			this.DebugReturn(DebugLevel.INFO, string.Format("OnStatusChanged: {0}", statusCode.ToString()));
		}
		switch (statusCode)
		{
		case StatusCode.SecurityExceptionOnConnect:
		case StatusCode.ExceptionOnConnect:
			this.State = global::PeerState.PeerCreated;
			NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnFailedToConnectToPhoton, new object[] { (DisconnectCause)statusCode });
			goto IL_04DD;
		case StatusCode.Connect:
			if (this.State == global::PeerState.ConnectingToGameserver)
			{
				if (base.DebugOut >= DebugLevel.ALL)
				{
					this.DebugReturn(DebugLevel.ALL, "Connected to gameserver.");
				}
				this.State = global::PeerState.ConnectedToGameserver;
				this.MasterConnection = false;
			}
			else
			{
				if (base.DebugOut >= DebugLevel.ALL)
				{
					this.DebugReturn(DebugLevel.ALL, "Connected to masterserver.");
				}
				if (this.State == global::PeerState.Connecting)
				{
					NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnConnectedToPhoton, new object[0]);
					this.State = global::PeerState.Connected;
				}
				else
				{
					this.State = global::PeerState.ConnectedComingFromGameserver;
				}
				this.MasterConnection = true;
			}
			if (this.requestSecurity)
			{
				base.EstablishEncryption();
				goto IL_04DD;
			}
			if (!this.OpAuthenticate(this.mAppId, this.mAppVersion, this.maccount, this.mpwd))
			{
				this.externalListener.DebugReturn(DebugLevel.ERROR, "Error Authenticating! Did not work.");
				goto IL_04DD;
			}
			goto IL_04DD;
		case StatusCode.Disconnect:
			if (this.State == global::PeerState.DisconnectingFromMasterserver)
			{
				if (this.Connect(this.mGameserver, this.mAppId))
				{
					this.State = global::PeerState.ConnectingToGameserver;
					goto IL_04DD;
				}
				goto IL_04DD;
			}
			else
			{
				if (this.State != global::PeerState.DisconnectingFromGameserver)
				{
					this.ResetRoomState();
					this.State = global::PeerState.PeerCreated;
					this.Reset();
					NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnDisconnectedFromPhoton, new object[0]);
					goto IL_04DD;
				}
				if (this.Connect(this.masterServerAddress, this.mAppId))
				{
					this.State = global::PeerState.ConnectingToMasterserver;
					goto IL_04DD;
				}
				goto IL_04DD;
			}
			break;
		case StatusCode.Exception:
			if (this.State == global::PeerState.Connecting)
			{
				DebugUtils.LogError(LogCategory.Network, "Exception while connecting to[" + base.ServerAddress + "]. Check if the server is available.");
				if (base.ServerAddress == null || base.ServerAddress.StartsWith("127.0.0.1"))
				{
					this.DebugReturn(DebugLevel.WARNING, "The server address is 127.0.0.1 (localhost): Make sure the server is running on this machine. Android and iOS emulators have their own localhost.");
					if (base.ServerAddress == this.mGameserver)
					{
						this.DebugReturn(DebugLevel.WARNING, "This might be a misconfiguration in the game server config. You need to edit it to a (public) address.");
					}
				}
				this.State = global::PeerState.PeerCreated;
				NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnFailedToConnectToPhoton, new object[] { (DisconnectCause)statusCode });
			}
			else
			{
				DebugUtils.LogError(LogCategory.Network, string.Concat(new object[] { "Exception while [", this.State, "]  to [", base.ServerAddress, "]. Check if the server is available." }));
				this.State = global::PeerState.PeerCreated;
				NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnConnectionFail, new object[] { (DisconnectCause)statusCode });
			}
			DebugUtils.Log(LogCategory.Network, "Disconnect because of: " + Enum.GetName(typeof(StatusCode), statusCode));
			this.Disconnect();
			goto IL_04DD;
		case StatusCode.QueueOutgoingReliableWarning:
		case StatusCode.QueueOutgoingUnreliableWarning:
		case StatusCode.SendError:
		case StatusCode.QueueOutgoingAcksWarning:
		case StatusCode.QueueSentWarning:
			goto IL_04DD;
		case StatusCode.InternalReceiveException:
		case StatusCode.TimeoutDisconnect:
		case StatusCode.DisconnectByServer:
		case StatusCode.DisconnectByServerUserLimit:
		case StatusCode.DisconnectByServerLogic:
			if (this.State == global::PeerState.Connecting)
			{
				this.DebugReturn(DebugLevel.WARNING, string.Concat(new object[] { statusCode, " while connecting to: ", base.ServerAddress, ". Check if the server is available." }));
				this.State = global::PeerState.PeerCreated;
				NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnFailedToConnectToPhoton, new object[] { (DisconnectCause)statusCode });
			}
			else
			{
				this.State = global::PeerState.PeerCreated;
				NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnConnectionFail, new object[] { (DisconnectCause)statusCode });
				DebugUtils.LogError(LogCategory.Network, string.Concat(new string[]
				{
					"OnConnectionFail [",
					Enum.GetName(typeof(StatusCode), statusCode),
					"] trying to connect [",
					base.ServerAddress,
					"]"
				}));
			}
			DebugUtils.Log(LogCategory.Network, "Disconnect because of: " + Enum.GetName(typeof(StatusCode), statusCode));
			this.Disconnect();
			goto IL_04DD;
		case StatusCode.EncryptionEstablished:
			if (!this.OpAuthenticate(this.mAppId, this.mAppVersion, this.maccount, this.mpwd))
			{
				this.externalListener.DebugReturn(DebugLevel.ERROR, "Error Authenticating! Did not work.");
				goto IL_04DD;
			}
			goto IL_04DD;
		case StatusCode.EncryptionFailedToEstablish:
			this.externalListener.DebugReturn(DebugLevel.ERROR, "Encryption wasn't established: " + statusCode + ". Going to authenticate anyways.");
			if (!this.OpAuthenticate(this.mAppId, this.mAppVersion, this.maccount, this.mpwd))
			{
				this.externalListener.DebugReturn(DebugLevel.ERROR, "Error Authenticating! Did not work.");
				goto IL_04DD;
			}
			goto IL_04DD;
		}
		DebugUtils.Log(LogCategory.Network, "CommandBufferSize is " + base.CommandBufferSize);
		this.DebugReturn(DebugLevel.ERROR, "Received unknown status code: " + statusCode);
		IL_04DD:
		this.externalListener.OnStatusChanged(statusCode);
	}

	// Token: 0x06004D21 RID: 19745 RVA: 0x0014518C File Offset: 0x0014338C
	public void OnEvent(EventData photonEvent)
	{
		if (base.DebugOut >= DebugLevel.INFO)
		{
			this.DebugReturn(DebugLevel.INFO, string.Format("OnEvent: {0}", photonEvent.ToString()));
		}
		int num = -1;
		PhotonPlayer photonPlayer = null;
		if (photonEvent.Parameters.ContainsKey(254))
		{
			num = (int)photonEvent[254];
			if (this.mActors.ContainsKey(num))
			{
				photonPlayer = this.mActors[num];
			}
		}
		byte code = photonEvent.Code;
		switch (code)
		{
		case 200:
			this.ProcessIncomingRPC(photonEvent[245] as Hashtable, photonPlayer);
			goto IL_07D3;
		case 201:
		case 206:
		{
			Hashtable hashtable = (Hashtable)photonEvent[245];
			if (hashtable == null)
			{
				DebugUtils.LogError(LogCategory.Network, "OnEvent: missing sync data (code " + code + "), ignoring event.");
				goto IL_07D3;
			}
			int num2 = (hashtable[(byte)0] != null) ? ((int)hashtable[(byte)0]) : 0;
			short num3 = -1;
			short num4 = 1;
			while ((int)num4 < hashtable.Count)
			{
				Hashtable hashtable2 = hashtable[num4] as Hashtable;
				if (hashtable2 == null || hashtable2[(byte)0] == null)
				{
					num4 += 1;
					continue;
				}
				int num5 = (int)hashtable2[(byte)0];
				PhotonView photonView = this.GetPhotonViewByID(num5);
				if (photonView != null)
				{
					photonView.OnSerializeRead(hashtable2, photonPlayer, num2, num3);
				}
				else if (photonEvent.Code == 206)
				{
					this.StoreDataForMissingView(num5, hashtable2, photonPlayer, num2, num3);
				}
				num4 += 1;
			}
			goto IL_07D3;
		}
		case 202:
			this.DoInstantiate((Hashtable)photonEvent[245], photonPlayer, null, false);
			goto IL_07D3;
		case 203:
			if (photonPlayer != null && photonPlayer.Boolean_0)
			{
				PhotonNetwork.LeaveRoom();
				goto IL_07D3;
			}
			DebugUtils.LogError(LogCategory.Network, "Error: Someone else(" + photonPlayer + ") then the masterserver requests a disconnect!");
			goto IL_07D3;
		case 204:
		{
			Hashtable hashtable3 = (Hashtable)photonEvent[245];
			if (hashtable3 == null)
			{
				DebugUtils.LogError(LogCategory.Network, "OnEvent: missing destroy data, ignoring event.");
				goto IL_07D3;
			}
			int num6 = (int)hashtable3[(byte)0];
			PhotonView photonView2 = this.GetPhotonViewByID(num6);
			if (photonView2 == null)
			{
				DebugUtils.Log(LogCategory.Network, "INFO: This view has already been destroyed. view ID=" + num6);
				goto IL_07D3;
			}
			if (photonPlayer == null)
			{
				DebugUtils.LogError(LogCategory.Network, string.Concat(new object[] { "ERROR: Illegal destroy request on view ID=", num6, " from player/actorNr: ", num, " view=", photonView2, "  orgPlayer=", photonPlayer }));
				goto IL_07D3;
			}
			this.DestroyPhotonView(photonView2, true);
			goto IL_07D3;
		}
		case 207:
		{
			Hashtable hashtable4 = (Hashtable)photonEvent[245];
			if (hashtable4 == null)
			{
				DebugUtils.LogError(LogCategory.Network, "OnEvent: missing ping data, ignoring event.");
				goto IL_07D3;
			}
			float num7 = (float)hashtable4[0];
			int num8 = (int)((byte)hashtable4[1]);
			if (num8 != this.mLocalActor.ActorId)
			{
				hashtable4[2] = (byte)this.mLocalActor.ActorId;
				this.RaiseEventToActors(207, hashtable4, true, 0, new int[] { num8 });
				goto IL_07D3;
			}
			if (!hashtable4.ContainsKey(2))
			{
				goto IL_07D3;
			}
			float num9 = Time.realtimeSinceStartup - num7;
			if (!this.peerRoundTripTimes.ContainsKey((int)((byte)hashtable4[2])))
			{
				this.peerRoundTripTimes[(int)((byte)hashtable4[2])] = num9;
				goto IL_07D3;
			}
			float num10 = this.peerRoundTripTimes[(int)((byte)hashtable4[2])];
			this.peerRoundTripTimes[(int)((byte)hashtable4[2])] = Mathf.Lerp(num10, num9, 0.1f);
			goto IL_07D3;
		}
		}
		switch (code)
		{
		case 226:
			if (photonEvent[229] == null || photonEvent[227] == null || photonEvent[228] == null)
			{
				DebugUtils.LogError(LogCategory.Network, "OnEvent: missing data for event 226, ignoring event.");
				goto IL_07D3;
			}
			this.mPlayersInRoomsCount = (int)photonEvent[229];
			this.mPlayersOnMasterCount = (int)photonEvent[227];
			this.mGameCount = (int)photonEvent[228];
			goto IL_07D3;
		case 228:
			if (photonEvent.Parameters.ContainsKey(223))
			{
				this.mQueuePosition = (int)photonEvent[223];
			}
			else
			{
				this.DebugReturn(DebugLevel.ERROR, "Event QueueState must contain position!");
			}
			if (this.mQueuePosition != 0)
			{
				goto IL_07D3;
			}
			if (PhotonNetwork.autoJoinLobby)
			{
				this.vmethod_0();
				this.State = global::PeerState.Authenticated;
				goto IL_07D3;
			}
			this.State = global::PeerState.ConnectedToMaster;
			NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnConnectedToMaster, new object[0]);
			goto IL_07D3;
		case 229:
		{
			Hashtable hashtable5 = (Hashtable)photonEvent[222];
			foreach (object obj in hashtable5)
			{
				DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
				string text = (string)dictionaryEntry.Key;
				Room room = new Room(text, (Hashtable)dictionaryEntry.Value);
				if (room.removedFromList)
				{
					this.mGameList.Remove(text);
				}
				else
				{
					this.mGameList[text] = room;
				}
			}
			this.mGameListCopy = new RoomInfo[this.mGameList.Count];
			this.mGameList.Values.CopyTo(this.mGameListCopy, 0);
			NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnReceivedRoomListUpdate, new object[0]);
			goto IL_07D3;
		}
		case 230:
		{
			this.mGameList = new Dictionary<string, RoomInfo>();
			Hashtable hashtable6 = (Hashtable)photonEvent[222];
			foreach (object obj2 in hashtable6)
			{
				DictionaryEntry dictionaryEntry2 = (DictionaryEntry)obj2;
				string text2 = (string)dictionaryEntry2.Key;
				this.mGameList[text2] = new RoomInfo(text2, (Hashtable)dictionaryEntry2.Value);
			}
			this.mGameListCopy = new RoomInfo[this.mGameList.Count];
			this.mGameList.Values.CopyTo(this.mGameListCopy, 0);
			NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnReceivedRoomListUpdate, new object[0]);
			goto IL_07D3;
		}
		}
		switch (code)
		{
		case 253:
		{
			if (photonEvent[253] == null)
			{
				DebugUtils.LogError(LogCategory.Network, "OnEvent: missing data for event 253, ignoring event.");
				break;
			}
			int num11 = (int)photonEvent[253];
			Hashtable hashtable7 = null;
			Hashtable hashtable8 = null;
			if (num11 == 0)
			{
				hashtable7 = (Hashtable)photonEvent[251];
			}
			else
			{
				hashtable8 = (Hashtable)photonEvent[251];
			}
			this.ApplyRoomAndActorProperties(hashtable7, hashtable8, num11);
			break;
		}
		case 254:
			this.HandleActorLeft(num);
			break;
		case 255:
		{
			Hashtable hashtable9 = (Hashtable)photonEvent[249];
			if (photonPlayer == null)
			{
				bool flag = this.mLocalActor.ActorId == num;
				this.AddActor(num, new PhotonPlayer(flag, num, hashtable9));
				this.ResetSerializeCaches();
			}
			if (this.mActors[num] == this.mLocalActor)
			{
				int[] array = (int[])photonEvent[252];
				if (array == null)
				{
					array = new int[0];
				}
				foreach (int num12 in array)
				{
					if (this.mLocalActor.ActorId != num12 && !this.mActors.ContainsKey(num12))
					{
						DebugUtils.Log(LogCategory.Network, "creating player");
						this.AddActor(num12, new PhotonPlayer(false, num12, string.Empty));
					}
				}
				NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnJoinedRoom, new object[0]);
			}
			else
			{
				NetworkingPeer.SendMonoMessage(PhotonNetworkingMessage.OnPhotonPlayerConnected, new object[] { this.mActors[num] });
			}
			break;
		}
		default:
			if (this.mEventCallbacks.ContainsKey(photonEvent.Code))
			{
				this.mEventCallbacks[photonEvent.Code](photonEvent.Parameters);
			}
			else
			{
				DebugUtils.LogError(LogCategory.Network, "Error. Unhandled event: " + photonEvent);
			}
			break;
		}
		IL_07D3:
		this.externalListener.OnEvent(photonEvent);
	}

	// Token: 0x06004D22 RID: 19746 RVA: 0x00145994 File Offset: 0x00143B94
	private void StoreDataForMissingView(int int_0, Hashtable hashtable_0, PhotonPlayer photonPlayer_0, int int_1, short short_0)
	{
		NetworkingPeer.StoredDataForNoView storedDataForNoView = default(NetworkingPeer.StoredDataForNoView);
		storedDataForNoView.data = hashtable_0;
		storedDataForNoView.originatingPlayer = photonPlayer_0;
		storedDataForNoView.remoteLevelPrefix = short_0;
		storedDataForNoView.remoteUpdateServerTimestamp = int_1;
		this.m_StoredDataForNoView[int_0] = storedDataForNoView;
	}

	// Token: 0x06004D23 RID: 19747 RVA: 0x001459D8 File Offset: 0x00143BD8
	public static void SendMonoMessage(PhotonNetworkingMessage photonNetworkingMessage_0, params object[] object_0)
	{
		HashSet<GameObject> hashSet = new HashSet<GameObject>();
		foreach (MonoBehaviour monoBehaviour in (MonoBehaviour[])global::UnityEngine.Object.FindObjectsOfType(typeof(MonoBehaviour)))
		{
			if (!hashSet.Contains(monoBehaviour.gameObject))
			{
				hashSet.Add(monoBehaviour.gameObject);
				if (object_0 != null && object_0.Length == 1)
				{
					monoBehaviour.SendMessage(photonNetworkingMessage_0.ToString(), object_0[0], SendMessageOptions.DontRequireReceiver);
				}
				else
				{
					monoBehaviour.SendMessage(photonNetworkingMessage_0.ToString(), object_0, SendMessageOptions.DontRequireReceiver);
				}
			}
		}
	}

	// Token: 0x06004D24 RID: 19748 RVA: 0x00145A60 File Offset: 0x00143C60
	public void ProcessIncomingRPC(Hashtable hashtable_0, PhotonPlayer photonPlayer_0)
	{
		if (hashtable_0 == null || !hashtable_0.ContainsKey((byte)0))
		{
			this.DebugReturn(DebugLevel.ERROR, "Malformed RPC; this should never occur.");
			return;
		}
		int num = (int)hashtable_0[(byte)0];
		int num2 = 0;
		if (hashtable_0.ContainsKey((byte)1))
		{
			num2 = (int)((short)hashtable_0[(byte)1]);
		}
		string text = (string)hashtable_0[(byte)3];
		object[] array = (object[])hashtable_0[(byte)4];
		if (array == null)
		{
			array = new object[0];
		}
		PhotonView photonView = this.GetPhotonViewByID(num);
		if (photonView == null)
		{
			DebugUtils.LogError(LogCategory.Network, string.Concat(new object[] { "Received RPC \"", text, "\" for viewID ", num, " but this PhotonView does not exist!" }));
			return;
		}
		if (photonView.Int32_0 != num2)
		{
			DebugUtils.LogError(LogCategory.Network, string.Concat(new object[] { "Received RPC \"", text, "\" on viewID ", num, " with a prefix of ", num2, ", our prefix is ", photonView.Int32_0, ". The RPC has been ignored." }));
			return;
		}
		if (photonView.preInstantiate)
		{
			photonView.bufferedRPC.Add(new Pair<Hashtable, PhotonPlayer>(hashtable_0, photonPlayer_0));
			return;
		}
		if (text == string.Empty)
		{
			this.DebugReturn(DebugLevel.ERROR, "Malformed RPC; this should never occur.");
			return;
		}
		if (PhotonNetwork.NetworkStatisticsEnabled)
		{
			photonView.method_16(text, Utils.smethod_8(hashtable_0));
		}
		if (base.DebugOut >= DebugLevel.ALL)
		{
			this.DebugReturn(DebugLevel.ALL, "Received RPC; " + text);
		}
		if (photonView.group != 0 && !this.allowedReceivingGroups.Contains(photonView.group))
		{
			return;
		}
		Type[] array2 = Type.EmptyTypes;
		if (array.Length > 0)
		{
			array2 = new Type[array.Length];
			int num3 = 0;
			foreach (object obj in array)
			{
				if (obj == null)
				{
					array2[num3] = null;
				}
				else
				{
					array2[num3] = obj.GetType();
				}
				num3++;
			}
		}
		int num4 = 0;
		int num5 = 0;
		foreach (MonoBehaviour monoBehaviour in photonView.GetComponents<MonoBehaviour>())
		{
			if (monoBehaviour == null)
			{
				DebugUtils.LogError(LogCategory.Network, "ERROR You have missing MonoBehaviours on your gameobjects!");
			}
			else
			{
				Type type = monoBehaviour.GetType();
				List<MethodInfo> list = null;
				if (this.monoRPCMethodsCache.ContainsKey(type))
				{
					list = this.monoRPCMethodsCache[type];
				}
				if (list == null)
				{
					List<MethodInfo> list2 = new List<MethodInfo>();
					MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
					for (int k = 0; k < methods.Length; k++)
					{
						if (methods[k].IsDefined(typeof(RPC), false))
						{
							list2.Add(methods[k]);
						}
					}
					this.monoRPCMethodsCache[type] = list2;
					list = list2;
				}
				if (list != null)
				{
					for (int l = 0; l < list.Count; l++)
					{
						MethodInfo methodInfo = list[l];
						if (methodInfo.Name == text)
						{
							num5++;
							ParameterInfo[] parameters = methodInfo.GetParameters();
							if (parameters.Length == array2.Length)
							{
								if (this.ParameterTypesMatch(parameters, array2))
								{
									num4++;
									object obj2 = methodInfo.Invoke(monoBehaviour, array);
									if (methodInfo.ReturnType == typeof(IEnumerator))
									{
										monoBehaviour.StartCoroutine((IEnumerator)obj2);
									}
								}
							}
							else if (parameters.Length - 1 == array2.Length)
							{
								if (this.ParameterTypesMatch(parameters, array2) && parameters[parameters.Length - 1].ParameterType == typeof(PhotonMessageInfo))
								{
									num4++;
									int num6 = (int)hashtable_0[(byte)2];
									object[] array3 = new object[array.Length + 1];
									array.CopyTo(array3, 0);
									array3[array3.Length - 1] = new PhotonMessageInfo(photonPlayer_0, num6, photonView);
									object obj3 = methodInfo.Invoke(monoBehaviour, array3);
									if (methodInfo.ReturnType == typeof(IEnumerator))
									{
										monoBehaviour.StartCoroutine((IEnumerator)obj3);
									}
								}
							}
							else if (parameters.Length == 1 && parameters[0].ParameterType.IsArray)
							{
								num4++;
								object obj4 = methodInfo.Invoke(monoBehaviour, new object[] { array });
								if (methodInfo.ReturnType == typeof(IEnumerator))
								{
									monoBehaviour.StartCoroutine((IEnumerator)obj4);
								}
							}
						}
					}
				}
			}
		}
		if (num4 != 1)
		{
			string text2 = string.Empty;
			foreach (Type type2 in array2)
			{
				if (text2 != string.Empty)
				{
					text2 += ", ";
				}
				if (type2 == null)
				{
					text2 += "null";
				}
				else
				{
					text2 += type2.Name;
				}
			}
			if (num4 == 0)
			{
				if (num5 == 0)
				{
					this.DebugReturn(DebugLevel.ERROR, string.Concat(new object[] { "PhotonView with ID ", num, " has no method \"", text, "\" marked with the [RPC](C#) or @RPC(JS) property!" }));
				}
				else
				{
					this.DebugReturn(DebugLevel.ERROR, string.Concat(new object[] { "PhotonView with ID ", num, " has no method \"", text, "\" that takes ", array2.Length, " argument(s): ", text2 }));
				}
			}
			else
			{
				this.DebugReturn(DebugLevel.ERROR, string.Concat(new object[]
				{
					"PhotonView with ID ", num, " has ", num4, " methods \"", text, "\" that takes ", array2.Length, " argument(s): ", text2,
					". Should be just one?"
				}));
			}
		}
	}

	// Token: 0x06004D25 RID: 19749 RVA: 0x00146068 File Offset: 0x00144268
	private bool ParameterTypesMatch(ParameterInfo[] parameterInfo_0, Type[] type_0)
	{
		if (parameterInfo_0.Length < type_0.Length)
		{
			return false;
		}
		int num = 0;
		foreach (Type type in type_0)
		{
			if (type != null && parameterInfo_0[num].ParameterType != type)
			{
				return false;
			}
			num++;
		}
		return true;
	}

	// Token: 0x06004D26 RID: 19750 RVA: 0x001460AC File Offset: 0x001442AC
	internal Hashtable SendInstantiate(string string_0, Vector3 vector3_0, Quaternion quaternion_0, int int_0, int[] int_1, object[] object_0, bool bool_0)
	{
		int num = int_1[0];
		Hashtable hashtable = new Hashtable();
		int num2 = ns0.MonoSingleton<InstantiateManager>.Instance.m_itstantiateObjectDic.FindIndex((string s) => s.Equals(string_0));
		if (num2 >= 0)
		{
			hashtable[(byte)0] = num2;
		}
		else
		{
			hashtable[(byte)0] = string_0;
		}
		if (vector3_0 != Vector3.zero)
		{
			hashtable[(byte)1] = vector3_0;
		}
		if (quaternion_0 != Quaternion.identity)
		{
			hashtable[(byte)2] = quaternion_0;
		}
		if (int_0 != 0)
		{
			hashtable[(byte)3] = int_0;
		}
		if (int_1.Length > 1)
		{
			hashtable[(byte)4] = int_1;
		}
		if (object_0 != null)
		{
			hashtable[(byte)5] = object_0;
		}
		if (currentLevelPrefix > 0)
		{
			hashtable[(byte)8] = currentLevelPrefix;
		}
		hashtable[(byte)6] = base.ServerTimeInMilliSeconds;
		hashtable[(byte)7] = num;
		EventCaching eventCaching_ = ((!bool_0) ? EventCaching.AddToRoomCache : EventCaching.AddToRoomCacheGlobal);
		grossInstantiateData += Utils.smethod_8(hashtable);
		RaiseEvent(202, hashtable, bool_0: true, 0, eventCaching_, ReceiverGroup.Others);
		return hashtable;
	}
	// Token: 0x06004D27 RID: 19751 RVA: 0x00146210 File Offset: 0x00144410
	internal GameObject DoInstantiate(Hashtable hashtable_0, PhotonPlayer photonPlayer_0, GameObject gameObject_0, bool bool_0)
	{
		this.grossInstantiateDataRCV += Utils.smethod_8(hashtable_0);
		string text = string.Empty;
		object object_1 = hashtable_0[(byte)0];
		if (object_1 is string)
		{
			text = (string)object_1;
		}
		else if (object_1 is int)
		{
			int num = (int)object_1;
			InstantiateManager instantiateManager = MonoSingleton<InstantiateManager>.Instance;
			if (instantiateManager == null || num < 0 || num >= instantiateManager.m_itstantiateObjectDic.Count)
			{
				DebugUtils.LogError(LogCategory.Network, "DoInstantiate: InstantiateManager not ready or invalid prefab index [" + num + "], skipping instantiate.");
				return null;
			}
			text = instantiateManager.m_itstantiateObjectDic[num];
		}
		else
		{
			DebugUtils.LogError(LogCategory.Network, "DoInstantiate: missing or invalid prefab id in instantiate data (hashtable[0] is " + ((object_1 == null) ? "null" : object_1.GetType().ToString()) + "), skipping instantiate.");
			return null;
		}
		if (hashtable_0[(byte)6] == null || hashtable_0[(byte)7] == null)
		{
			DebugUtils.LogError(LogCategory.Network, "DoInstantiate: missing serverTime/instantiationId in instantiate data for [" + text + "], skipping instantiate.");
			return null;
		}
		int num2 = (int)hashtable_0[(byte)6];
		int num3 = (int)hashtable_0[(byte)7];
		Vector3 vector;
		if (hashtable_0.ContainsKey((byte)1))
		{
			vector = (Vector3)hashtable_0[(byte)1];
		}
		else
		{
			vector = Vector3.zero;
		}
		Quaternion quaternion = Quaternion.identity;
		if (hashtable_0.ContainsKey((byte)2))
		{
			quaternion = (Quaternion)hashtable_0[(byte)2];
		}
		int num4 = 0;
		if (hashtable_0.ContainsKey((byte)3))
		{
			num4 = (int)hashtable_0[(byte)3];
		}
		short num5 = 0;
		if (hashtable_0.ContainsKey((byte)8))
		{
			num5 = (short)hashtable_0[(byte)8];
		}
		int[] array;
		if (hashtable_0.ContainsKey((byte)4))
		{
			array = (int[])hashtable_0[(byte)4];
		}
		else
		{
			array = new int[] { num3 };
		}
		object[] array2;
		if (hashtable_0.ContainsKey((byte)5))
		{
			array2 = (object[])hashtable_0[(byte)5];
		}
		else
		{
			array2 = null;
		}
		if (!bool_0)
		{
			GameObject gameObject = new GameObject("InstantiateHelper_" + num3);
			if (MonoSingleton<AppManager>.Instance != null)
			{
				gameObject.transform.parent = MonoSingleton<AppManager>.Instance.transform;
			}
			NetworkingPeer.InstantiatingPhotonViews instantiatingPhotonViews = new NetworkingPeer.InstantiatingPhotonViews();
			instantiatingPhotonViews.instantiateHelper = gameObject;
			for (int i = 0; i < array.Length; i++)
			{
				gameObject.AddComponent<PhotonView>();
			}
			PhotonView[] components = gameObject.GetComponents<PhotonView>();
			string text2 = string.Empty;
			for (int j = 0; j < array.Length; j++)
			{
				text2 += array[j];
				components[j].Int32_1 = array[j];
				components[j].group = num4;
				components[j].Object_0 = array2;
				components[j].preInstantiate = true;
			}
			instantiatingPhotonViews.instantiationId = num3;
			instantiatingPhotonViews.photonPlayer = photonPlayer_0;
			instantiatingPhotonViews.position = vector;
			instantiatingPhotonViews.rotation = quaternion;
			instantiatingPhotonViews.resourceGameObject = gameObject_0;
			instantiatingPhotonViews.prefabName = text;
			instantiatingPhotonViews.serverTime = num2;
			instantiatingPhotonViews.group = num4;
			instantiatingPhotonViews.objLevelPrefix = (int)num5;
			instantiatingPhotonViews.incomingInstantiationData = array2;
			this.instantiatingPhotonViews.Add(instantiatingPhotonViews);
			return null;
		}
		if (gameObject_0 == null)
		{
			gameObject_0 = ResourcesLoader.smethod_8(text);
			if (gameObject_0 == null)
			{
				DebugUtils.LogError(LogCategory.Network, "PhotonNetwork error: Could not Instantiate the prefab [" + text + "]. Please verify you have this gameobject in a Resources folder.");
				return null;
			}
		}
		PhotonView[] photonViewsInChildren = gameObject_0.GetPhotonViewsInChildren();
		if (photonViewsInChildren.Length != array.Length)
		{
			throw new Exception("Error in Instantiation! The resource's PhotonView count is not the same as in incoming data.");
		}
		for (int k = 0; k < array.Length; k++)
		{
			photonViewsInChildren[k].Int32_1 = array[k];
			photonViewsInChildren[k].Int32_0 = (int)num5;
			photonViewsInChildren[k].instantiationId = num3;
		}
		this.StoreTempInstantiationData(num3, array2);
		GameObject gameObject2 = ResourcesLoader.smethod_7(text, vector, quaternion);
		for (int l = 0; l < array.Length; l++)
		{
			photonViewsInChildren[l].Int32_1 = 0;
			photonViewsInChildren[l].Int32_0 = -1;
			photonViewsInChildren[l].prefixBackup = -1;
			photonViewsInChildren[l].instantiationId = -1;
		}
		this.ClearTempInstantiationData(num3);
		if (this.instantiatedObjects.ContainsKey(num3))
		{
			GameObject gameObject3 = this.instantiatedObjects[num3];
			string text3 = string.Empty;
			if (gameObject3 != null)
			{
				PhotonView[] photonViewsInChildren2 = gameObject3.GetPhotonViewsInChildren();
				foreach (PhotonView photonView in photonViewsInChildren2)
				{
					if (!(photonView == null))
					{
						text3 = text3 + photonView.ToString() + ", ";
					}
				}
			}
			DebugUtils.LogError(LogCategory.Network, string.Format("Adding GO \"{0}\" (instantiationID: {1}) to instantiatedObjects failed. instantiatedObjects.Count: {2}. Object taking the same place: {3}. Views on it: {4}. PhotonNetwork.lastUsedViewSubId: {5} PhotonNetwork.lastUsedViewSubIdStatic: {6} this.photonViewList.Count {7}.)", new object[]
			{
				gameObject2,
				num3,
				this.instantiatedObjects.Count,
				gameObject3,
				text3,
				PhotonNetwork.lastUsedViewSubId,
				PhotonNetwork.lastUsedViewSubIdStatic,
				this.photonViewList.Count
			}));
		}
		this.instantiatedObjects.Add(num3, gameObject2);
		object[] array4 = new object[]
		{
			new PhotonMessageInfo(photonPlayer_0, num2, null)
		};
		foreach (MonoBehaviour monoBehaviour in gameObject2.GetComponentsInChildren<MonoBehaviour>())
		{
			MethodInfo methodInfo = this.FindPhotonCallbackMethod(monoBehaviour, PhotonNetworkingMessage.OnPhotonInstantiate);
			if (methodInfo != null)
			{
				object obj = methodInfo.Invoke(monoBehaviour, array4);
				if (methodInfo.ReturnType == typeof(IEnumerator))
				{
					monoBehaviour.StartCoroutine((IEnumerator)obj);
				}
			}
		}
		return gameObject2;
	}

	// Token: 0x06004D28 RID: 19752 RVA: 0x0014671C File Offset: 0x0014491C
	private NetworkingPeer.InstantiateState CompleteDeferredInstantiate(NetworkingPeer.InstantiatingPhotonViews instantiatingPhotonViews_0)
	{
		if ((instantiatingPhotonViews_0.group != 0 && !this.allowedReceivingGroups.Contains(instantiatingPhotonViews_0.group)) || this.m_instantiatePending)
		{
			return NetworkingPeer.InstantiateState.Pending;
		}
		if (instantiatingPhotonViews_0.resourceGameObject == null)
		{
			instantiatingPhotonViews_0.resourceGameObject = ResourcesLoader.smethod_8(instantiatingPhotonViews_0.prefabName);
			if (instantiatingPhotonViews_0.resourceGameObject == null)
			{
				DebugUtils.LogError(LogCategory.Network, "PhotonNetwork error: Could not Instantiate the prefab [" + instantiatingPhotonViews_0.prefabName + "]. Please verify you have this gameobject in a Resources folder.");
				return NetworkingPeer.InstantiateState.Fail;
			}
		}
		PhotonView[] components = instantiatingPhotonViews_0.instantiateHelper.GetComponents<PhotonView>();
		foreach (PhotonView photonView in components)
		{
			this.UnregisterPhotonView(photonView);
		}
		PhotonView[] photonViewsInChildren = instantiatingPhotonViews_0.resourceGameObject.GetPhotonViewsInChildren();
		if (photonViewsInChildren.Length != components.Length)
		{
			throw new Exception("Error in Instantiation! The resource's PhotonView count is not the same as in incoming data. [" + instantiatingPhotonViews_0.prefabName + "].");
		}
		for (int j = 0; j < components.Length; j++)
		{
			photonViewsInChildren[j].Int32_1 = components[j].Int32_1;
			photonViewsInChildren[j].Int32_0 = instantiatingPhotonViews_0.objLevelPrefix;
			photonViewsInChildren[j].instantiationId = instantiatingPhotonViews_0.instantiationId;
		}
		this.StoreTempInstantiationData(instantiatingPhotonViews_0.instantiationId, instantiatingPhotonViews_0.incomingInstantiationData);
		this.m_instantiatePending = true;
		GameObject gameObject = ResourcesLoader.smethod_7(instantiatingPhotonViews_0.prefabName, instantiatingPhotonViews_0.position, instantiatingPhotonViews_0.rotation);
		for (int k = 0; k < components.Length; k++)
		{
			photonViewsInChildren[k].Int32_1 = 0;
			photonViewsInChildren[k].Int32_0 = -1;
			photonViewsInChildren[k].prefixBackup = -1;
			photonViewsInChildren[k].instantiationId = -1;
		}
		this.ClearTempInstantiationData(instantiatingPhotonViews_0.instantiationId);
		foreach (PhotonView photonView2 in components)
		{
			NetworkingPeer.StoredDataForNoView storedDataForNoView;
			if (this.m_StoredDataForNoView.TryGetValue(photonView2.Int32_1, out storedDataForNoView))
			{
				this.GetPhotonViewByID(photonView2.Int32_1).lastOnSerializeDataReceived = storedDataForNoView.data;
				this.GetPhotonViewByID(photonView2.Int32_1).OnSerializeRead(storedDataForNoView.data, storedDataForNoView.originatingPlayer, storedDataForNoView.remoteUpdateServerTimestamp, storedDataForNoView.remoteLevelPrefix);
				this.m_StoredDataForNoView.Remove(photonView2.Int32_1);
			}
			if (photonView2.lastOnSerializeDataReceived != null)
			{
				this.GetPhotonViewByID(photonView2.Int32_1).lastOnSerializeDataReceived = photonView2.lastOnSerializeDataReceived;
				this.GetPhotonViewByID(photonView2.Int32_1).OnSerializeRead(photonView2.lastOnSerializeDataReceived, instantiatingPhotonViews_0.photonPlayer, instantiatingPhotonViews_0.serverTime, 0);
			}
			if (photonView2.bufferedRPC.Count != 0)
			{
				foreach (Pair<Hashtable, PhotonPlayer> pair in photonView2.bufferedRPC)
				{
					this.ProcessIncomingRPC(pair.Left, pair.Right);
				}
			}
		}
		global::UnityEngine.Object.Destroy(instantiatingPhotonViews_0.instantiateHelper);
		object[] array3 = new object[]
		{
			new PhotonMessageInfo(instantiatingPhotonViews_0.photonPlayer, instantiatingPhotonViews_0.serverTime, null)
		};
		foreach (MonoBehaviour monoBehaviour in gameObject.GetComponentsInChildren<MonoBehaviour>())
		{
			MethodInfo methodInfo = this.FindPhotonCallbackMethod(monoBehaviour, PhotonNetworkingMessage.OnPhotonInstantiate);
			if (methodInfo != null)
			{
				object obj = methodInfo.Invoke(monoBehaviour, array3);
				if (methodInfo.ReturnType == typeof(IEnumerator))
				{
					PhotonHandler.SP.StartCoroutine((IEnumerator)obj);
				}
			}
		}
		if (gameObject != null)
		{
			return NetworkingPeer.InstantiateState.Success;
		}
		return NetworkingPeer.InstantiateState.Fail;
	}

	// Token: 0x06004D29 RID: 19753 RVA: 0x0003227A File Offset: 0x0003047A
	private void StoreTempInstantiationData(int int_0, object[] object_0)
	{
		this.tempInstantiationData[int_0] = object_0;
	}

	// Token: 0x06004D2A RID: 19754 RVA: 0x00146A8C File Offset: 0x00144C8C
	public object[] GetTempInstantiationData(int int_0)
	{
		object[] array = null;
		if (int_0 == 0)
		{
			return null;
		}
		this.tempInstantiationData.TryGetValue(int_0, out array);
		return array;
	}

	// Token: 0x06004D2B RID: 19755 RVA: 0x00032289 File Offset: 0x00030489
	private void ClearTempInstantiationData(int int_0)
	{
		this.tempInstantiationData.Remove(int_0);
	}

	// Token: 0x06004D2C RID: 19756 RVA: 0x00146AB0 File Offset: 0x00144CB0
	public void RemoveAllInstantiatedObjects()
	{
		GameObject[] array = new GameObject[this.instantiatedObjects.Count];
		this.instantiatedObjects.Values.CopyTo(array, 0);
		foreach (GameObject gameObject in array)
		{
			if (!(gameObject == null))
			{
				this.RemoveInstantiatedObject(gameObject, false);
			}
		}
		if (this.instantiatedObjects.Count > 0)
		{
			DebugUtils.LogError(LogCategory.Network, "RemoveAllInstantiatedObjects() this.instantiatedObjects.Count should be 0 by now.");
		}
		this.instantiatedObjects = new Dictionary<int, GameObject>();
	}

	// Token: 0x06004D2D RID: 19757 RVA: 0x00146B28 File Offset: 0x00144D28
	public void RemoveAllInstantiatedObjectsByPlayer(PhotonPlayer photonPlayer_0, bool bool_0)
	{
		GameObject[] array = new GameObject[this.instantiatedObjects.Count];
		this.instantiatedObjects.Values.CopyTo(array, 0);
		foreach (GameObject gameObject in array)
		{
			if (!(gameObject == null))
			{
				PhotonView[] componentsInChildren = gameObject.GetComponentsInChildren<PhotonView>();
				for (int j = componentsInChildren.Length - 1; j >= 0; j--)
				{
					PhotonView photonView = componentsInChildren[j];
					if (photonView.Int32_2 == photonPlayer_0.ActorId)
					{
						this.RemoveInstantiatedObject(gameObject, bool_0);
						break;
					}
				}
			}
		}
	}

	// Token: 0x06004D2E RID: 19758 RVA: 0x00146BB0 File Offset: 0x00144DB0
	public void RemoveInstantiatedObject(GameObject gameObject_0, bool bool_0)
	{
		if (gameObject_0 == null)
		{
			if (base.DebugOut == DebugLevel.ERROR)
			{
				this.DebugReturn(DebugLevel.ERROR, "Can't remove instantiated GO if it's null.");
			}
			return;
		}
		int num = this.GetInstantiatedObjectsId(gameObject_0);
		if (num == -1)
		{
			if (base.DebugOut == DebugLevel.ERROR)
			{
				this.DebugReturn(DebugLevel.ERROR, "Can't find GO in instantiation list. Object: " + gameObject_0);
			}
			return;
		}
		this.instantiatedObjects.Remove(num);
		PhotonView[] componentsInChildren = gameObject_0.GetComponentsInChildren<PhotonView>(true);
		for (int i = componentsInChildren.Length - 1; i >= 0; i--)
		{
			PhotonView photonView = componentsInChildren[i];
			if (!(photonView == null))
			{
				this.DestroyPhotonView(photonView, bool_0);
			}
		}
		if (base.DebugOut >= DebugLevel.ALL)
		{
			this.DebugReturn(DebugLevel.ALL, "Network destroy Instantiated GO: " + gameObject_0.name);
		}
		this.DestroyInstantiatedObject(gameObject_0);
	}

	// Token: 0x06004D2F RID: 19759 RVA: 0x00146C68 File Offset: 0x00144E68
	public int GetInstantiatedObjectsId(GameObject gameObject_0)
	{
		int num = -1;
		if (gameObject_0 == null)
		{
			this.DebugReturn(DebugLevel.ERROR, "GetInstantiatedObjectsId() for GO == null.");
			return num;
		}
		PhotonView[] photonViewsInChildren = gameObject_0.GetPhotonViewsInChildren();
		if (photonViewsInChildren != null && photonViewsInChildren.Length > 0 && photonViewsInChildren[0] != null)
		{
			return photonViewsInChildren[0].instantiationId;
		}
		if (base.DebugOut == DebugLevel.ALL)
		{
			this.DebugReturn(DebugLevel.ALL, "GetInstantiatedObjectsId failed for GO: " + gameObject_0);
		}
		return num;
	}

	// Token: 0x06004D30 RID: 19760 RVA: 0x00146CD0 File Offset: 0x00144ED0
	private void RemoveCachedInstantiate(int int_0, int int_1)
	{
		Hashtable hashtable = new Hashtable();
		hashtable[(byte)7] = int_0;
		this.RaiseEventToActorsCached(202, hashtable, true, 0, new int[] { int_1 }, EventCaching.RemoveFromRoomCache);
	}

	// Token: 0x06004D31 RID: 19761 RVA: 0x00146D10 File Offset: 0x00144F10
	private void RemoveAllCachedInstantiatesForActor(int int_0)
	{
		this.RaiseEventToActorsCached(202, null, true, 0, new int[] { int_0 }, EventCaching.RemoveFromRoomCache);
	}

	// Token: 0x06004D32 RID: 19762 RVA: 0x00146D38 File Offset: 0x00144F38
	public void DestroyPlayerObjects(PhotonPlayer photonPlayer_0, bool bool_0)
	{
		this.RemoveAllInstantiatedObjectsByPlayer(photonPlayer_0, bool_0);
		PhotonView[] array = (PhotonView[])global::UnityEngine.Object.FindObjectsOfType(typeof(PhotonView));
		for (int i = array.Length - 1; i >= 0; i--)
		{
			PhotonView photonView = array[i];
			photonView.method_18(photonPlayer_0);
			if (photonView.PhotonPlayer_0 == photonPlayer_0)
			{
				this.DestroyPhotonView(photonView, bool_0);
			}
		}
	}

	// Token: 0x06004D33 RID: 19763 RVA: 0x00146D90 File Offset: 0x00144F90
	public void DestroyPhotonView(PhotonView photonView_0, bool bool_0)
	{
		if (!bool_0 && (photonView_0.Boolean_1 || this.mMasterClient == this.mLocalActor))
		{
			Hashtable hashtable = new Hashtable();
			hashtable[(byte)0] = photonView_0.Int32_1;
			this.RaiseEvent(204, hashtable, true, 0, EventCaching.DoNotCache, ReceiverGroup.Others);
		}
		if (photonView_0.Boolean_1 || this.mMasterClient == this.mLocalActor)
		{
			this.RemoveRPCs(photonView_0);
		}
		if (photonView_0.instantiationId == photonView_0.Int32_1)
		{
			int int32_ = photonView_0.Int32_2;
			this.RemoveCachedInstantiate(photonView_0.instantiationId, int32_);
		}
		if (base.DebugOut >= DebugLevel.ALL)
		{
			this.DebugReturn(DebugLevel.ALL, "Network destroy PhotonView GO: " + photonView_0.gameObject.name);
		}
		this.DestroyInstantiatedObject(photonView_0.gameObject);
	}

	// Token: 0x06004D34 RID: 19764 RVA: 0x00146E54 File Offset: 0x00145054
	public PhotonView GetPhotonViewByID(int int_0)
	{
		PhotonView photonView = null;
		this.photonViewList.TryGetValue(int_0, out photonView);
		if (photonView == null)
		{
			PhotonView[] array = global::UnityEngine.Object.FindObjectsOfType(typeof(PhotonView)) as PhotonView[];
			foreach (PhotonView photonView2 in array)
			{
				if (photonView2.Int32_1 == int_0)
				{
					return photonView2;
				}
			}
		}
		return photonView;
	}

	// Token: 0x06004D35 RID: 19765 RVA: 0x00146EBC File Offset: 0x001450BC
	public void RegisterPhotonView(PhotonView photonView_0)
	{
		if (!Application.isPlaying)
		{
			this.photonViewList = new Dictionary<int, PhotonView>();
			return;
		}
		if (photonView_0.subId == 0)
		{
			return;
		}
		if (!this.photonViewList.ContainsKey(photonView_0.Int32_1))
		{
			this.photonViewList.Add(photonView_0.Int32_1, photonView_0);
			this.photonViews.Add(photonView_0);
			if (photonView_0.method_17())
			{
				this.photonActiveViews.Add(photonView_0);
				if (photonView_0.synchronizationDir == SynchronizationDir.Broadcast)
				{
					this.BroadcastViews.Add(photonView_0);
				}
				if (photonView_0.synchronizationDir == SynchronizationDir.Collect)
				{
					this.CollectViews.Add(photonView_0);
				}
			}
			if (base.DebugOut >= DebugLevel.ALL)
			{
				this.DebugReturn(DebugLevel.ALL, "Registered PhotonView: " + photonView_0.Int32_1.ToString());
				return;
			}
		}
		else if (photonView_0 != this.photonViewList[photonView_0.Int32_1])
		{
			if (photonView_0.PhotonPlayer_0 == null)
			{
				DebugUtils.LogError(LogCategory.Network, string.Format("No owner for  {0}.", photonView_0.Int32_1));
			}
			if (this.photonViewList[photonView_0.Int32_1].PhotonPlayer_0 == null)
			{
				DebugUtils.LogError(LogCategory.Network, string.Format("No owner for  {0}.", this.photonViewList[photonView_0.Int32_1]));
			}
			DebugUtils.LogError(LogCategory.Network, string.Format("PhotonView ID duplicate found: {0}. On objects: [{1}] and [{2}]. Maybe one wasn't destroyed on scene load?! Check for 'DontDestroyOnLoad'. Owner: [{3}[{4}]", new object[]
			{
				photonView_0.Int32_1,
				photonView_0,
				this.photonViewList[photonView_0.Int32_1],
				(photonView_0.PhotonPlayer_0 != null) ? photonView_0.PhotonPlayer_0.ActorId.ToString() : "none",
				(this.photonViewList[photonView_0.Int32_1].PhotonPlayer_0 != null) ? this.photonViewList[photonView_0.Int32_1].PhotonPlayer_0.ActorId.ToString() : "none"
			}));
			string text = string.Empty;
			for (int i = 0; i < PhotonNetwork.playerList.Length; i++)
			{
				text = "-" + PhotonNetwork.playerList[i].String_0;
			}
			DebugUtils.LogError(LogCategory.Network, string.Format("Duplicate in Room [{0}] [{1}]. ", PhotonNetwork.room.String_1, text));
		}
	}

	// Token: 0x06004D36 RID: 19766 RVA: 0x001470F0 File Offset: 0x001452F0
	public void UnregisterPhotonView(PhotonView photonView_0)
	{
		if (!Application.isPlaying)
		{
			this.photonViewList = new Dictionary<int, PhotonView>();
			return;
		}
		PhotonView photonView = null;
		this.photonViewList.TryGetValue(photonView_0.Int32_1, out photonView);
		if (photonView == photonView_0)
		{
			this.photonViewList.Remove(photonView_0.Int32_1);
		}
		this.photonViews.Remove(photonView_0);
		this.photonActiveViews.Remove(photonView_0);
		this.BroadcastViews.Remove(photonView_0);
		this.CollectViews.Remove(photonView_0);
		this.networkingPriority.OnRemovePhotonView(photonView_0);
	}

	// Token: 0x06004D37 RID: 19767 RVA: 0x00147184 File Offset: 0x00145384
	public void RemoveRPCs(int int_0)
	{
		this.RaiseEventToActorsCached(200, null, true, 0, new int[] { int_0 }, EventCaching.RemoveFromRoomCache);
	}

	// Token: 0x06004D38 RID: 19768 RVA: 0x001471AC File Offset: 0x001453AC
	public void RemoveCompleteCacheOfPlayer(int int_0)
	{
		this.RaiseEventToActorsCached(0, null, true, 0, new int[] { int_0 }, EventCaching.RemoveFromRoomCache);
	}

	// Token: 0x06004D39 RID: 19769 RVA: 0x001471D0 File Offset: 0x001453D0
	private void method_54()
	{
		Dictionary<byte, object> dictionary = new Dictionary<byte, object>();
		dictionary[244] = 0;
		dictionary[247] = 7;
		this.OpCustom(253, dictionary, true, 0);
	}

	// Token: 0x06004D3A RID: 19770 RVA: 0x00147214 File Offset: 0x00145414
	public void RemoveRPCs(PhotonView photonView_0)
	{
		if (!this.mLocalActor.Boolean_0 && photonView_0.PhotonPlayer_0 != this.mLocalActor)
		{
			DebugUtils.LogError(LogCategory.Network, string.Concat(new object[] { "Error, cannot remove cached RPCs on a PhotonView thats not ours! ", photonView_0.PhotonPlayer_0, " scene: ", photonView_0.Boolean_0 }));
			return;
		}
		Hashtable hashtable = new Hashtable();
		hashtable[(byte)0] = photonView_0.Int32_1;
		this.RaiseEvent(200, hashtable, true, 0, EventCaching.RemoveFromRoomCache, ReceiverGroup.Others);
	}

	// Token: 0x06004D3B RID: 19771 RVA: 0x001472A4 File Offset: 0x001454A4
	public void RemoveRPCsInGroup(int int_0)
	{
		foreach (KeyValuePair<int, PhotonView> keyValuePair in this.photonViewList)
		{
			PhotonView value = keyValuePair.Value;
			if (value.group == int_0)
			{
				this.RemoveRPCs(value);
			}
		}
	}

	// Token: 0x06004D3C RID: 19772 RVA: 0x00032298 File Offset: 0x00030498
	public void SetLevelPrefix(short short_0)
	{
		this.currentLevelPrefix = short_0;
	}

	// Token: 0x06004D3D RID: 19773 RVA: 0x00147308 File Offset: 0x00145508
	public void SendRPCToPlayer(PhotonView photonView_0, string string_0, PhotonPlayer photonPlayer_0, bool bool_0, params object[] object_0)
	{
		if (this.blockSendingGroups.Contains(photonView_0.group))
		{
			return;
		}
		if (photonView_0.Int32_1 < 1)
		{
			DebugUtils.LogError(LogCategory.Network, string.Concat(new object[]
			{
				"Illegal view ID:",
				photonView_0.Int32_1,
				" method: ",
				string_0,
				" GO:",
				photonView_0.gameObject.name
			}));
		}
		if (base.DebugOut >= DebugLevel.INFO)
		{
			this.DebugReturn(DebugLevel.INFO, string.Concat(new object[] { "Sending RPC \"", string_0, "\" to player[", photonPlayer_0, "]" }));
		}
		Hashtable hashtable = new Hashtable();
		hashtable[(byte)0] = photonView_0.Int32_1;
		if (photonView_0.Int32_0 > 0)
		{
			hashtable[(byte)1] = (short)photonView_0.Int32_0;
		}
		hashtable[(byte)2] = base.ServerTimeInMilliSeconds;
		hashtable[(byte)3] = string_0;
		hashtable[(byte)4] = object_0;
		if (this.mLocalActor == photonPlayer_0)
		{
			this.ProcessIncomingRPC(hashtable, photonPlayer_0);
		}
		else
		{
			if (PhotonNetwork.NetworkStatisticsEnabled)
			{
				photonView_0.method_15(string_0, Utils.smethod_8(hashtable));
			}
			int[] array = new int[] { photonPlayer_0.ActorId };
			this.RaiseEventToActors(200, hashtable, bool_0, 0, array);
		}
	}

	// Token: 0x06004D3E RID: 19774 RVA: 0x00147470 File Offset: 0x00145670
	public void SendRPCToTargets(PhotonView photonView_0, string string_0, PhotonTargets photonTargets_0, bool bool_0, params object[] object_0)
	{
		if (this.blockSendingGroups.Contains(photonView_0.group))
		{
			return;
		}
		if (photonView_0.Int32_1 < 1)
		{
			DebugUtils.LogError(LogCategory.Network, string.Concat(new object[]
			{
				"Illegal view ID:",
				photonView_0.Int32_1,
				" method: ",
				string_0,
				" GO:",
				photonView_0.gameObject.name
			}));
		}
		if (base.DebugOut >= DebugLevel.INFO)
		{
			this.DebugReturn(DebugLevel.INFO, string.Concat(new object[] { "Sending RPC \"", string_0, "\" to ", photonTargets_0 }));
		}
		Hashtable hashtable = new Hashtable();
		hashtable[(byte)0] = photonView_0.Int32_1;
		if (photonView_0.Int32_0 > 0)
		{
			hashtable[(byte)1] = (short)photonView_0.Int32_0;
		}
		hashtable[(byte)2] = base.ServerTimeInMilliSeconds;
		hashtable[(byte)3] = string_0;
		hashtable[(byte)4] = object_0;
		if (photonTargets_0 == PhotonTargets.All)
		{
			if (PhotonNetwork.NetworkStatisticsEnabled)
			{
				photonView_0.method_15(string_0, Utils.smethod_8(hashtable));
			}
			this.RaiseEventForGroup(200, (byte)photonView_0.group, hashtable, bool_0, 0);
			this.ProcessIncomingRPC(hashtable, this.mLocalActor);
		}
		else if (photonTargets_0 == PhotonTargets.Others)
		{
			if (PhotonNetwork.NetworkStatisticsEnabled)
			{
				photonView_0.method_15(string_0, Utils.smethod_8(hashtable));
			}
			this.RaiseEventForGroup(200, (byte)photonView_0.group, hashtable, bool_0, 0);
		}
		else if (photonTargets_0 == PhotonTargets.AllBuffered)
		{
			if (PhotonNetwork.NetworkStatisticsEnabled)
			{
				photonView_0.method_15(string_0, Utils.smethod_8(hashtable));
			}
			this.RaiseEvent(200, hashtable, bool_0, 0, EventCaching.AddToRoomCache, ReceiverGroup.Others);
			this.ProcessIncomingRPC(hashtable, this.mLocalActor);
		}
		else if (photonTargets_0 == PhotonTargets.OthersBuffered)
		{
			if (PhotonNetwork.NetworkStatisticsEnabled)
			{
				photonView_0.method_15(string_0, Utils.smethod_8(hashtable));
			}
			this.RaiseEvent(200, hashtable, bool_0, 0, EventCaching.AddToRoomCache, ReceiverGroup.Others);
		}
		else if (photonTargets_0 == PhotonTargets.MasterClient)
		{
			if (this.mMasterClient == this.mLocalActor)
			{
				this.ProcessIncomingRPC(hashtable, this.mLocalActor);
			}
			else
			{
				if (PhotonNetwork.NetworkStatisticsEnabled)
				{
					photonView_0.method_15(string_0, Utils.smethod_8(hashtable));
				}
				this.RaiseEvent(200, hashtable, bool_0, 0, EventCaching.DoNotCache, ReceiverGroup.MasterClient);
			}
		}
		else
		{
			DebugUtils.LogError(LogCategory.Network, "Unsupported target enum: " + photonTargets_0);
		}
	}

	// Token: 0x06004D3F RID: 19775 RVA: 0x001476C8 File Offset: 0x001458C8
	public void SetReceivingEnabled(int int_0, bool bool_0)
	{
		if (int_0 <= 0)
		{
			DebugUtils.LogError(LogCategory.Network, "Error: PhotonNetwork.SetReceivingEnabled was called with an illegal group number: " + int_0 + ". The group number should be at least 1.");
			return;
		}
		if (bool_0)
		{
			if (!this.allowedReceivingGroups.Contains(int_0))
			{
				this.allowedReceivingGroups.Add(int_0);
				byte[] array = new byte[] { (byte)int_0 };
				this.OpChangeGroups(null, array);
			}
		}
		else if (this.allowedReceivingGroups.Contains(int_0))
		{
			this.allowedReceivingGroups.Remove(int_0);
			byte[] array2 = new byte[] { (byte)int_0 };
			this.OpChangeGroups(array2, null);
		}
	}

	// Token: 0x06004D40 RID: 19776 RVA: 0x000322A1 File Offset: 0x000304A1
	public void SetSendingEnabled(int int_0, bool bool_0)
	{
		if (!bool_0)
		{
			this.blockSendingGroups.Add(int_0);
		}
		else
		{
			this.blockSendingGroups.Remove(int_0);
		}
	}

	// Token: 0x06004D41 RID: 19777 RVA: 0x0014775C File Offset: 0x0014595C
	public void PurgeDestroyedSceneViews()
	{
		if (this.loadingLevelAndPausedNetwork && !PhotonNetwork.isMessageQueueRunning)
		{
			this.loadingLevelAndPausedNetwork = false;
			PhotonNetwork.isMessageQueueRunning = true;
		}
		List<int> list = new List<int>();
		foreach (KeyValuePair<int, PhotonView> keyValuePair in this.photonViewList)
		{
			PhotonView value = keyValuePair.Value;
			if (value == null)
			{
				list.Add(keyValuePair.Key);
			}
		}
		for (int i = 0; i < list.Count; i++)
		{
			int num = list[i];
			this.UnregisterPhotonView(this.GetPhotonViewByID(num));
		}
		if (list.Count > 0 && base.DebugOut >= DebugLevel.INFO)
		{
			this.DebugReturn(DebugLevel.INFO, "Removed " + list.Count + " scene view IDs from last scene.");
		}
	}

	// Token: 0x06004D42 RID: 19778 RVA: 0x00147848 File Offset: 0x00145A48
	public void ProcessPendingInstantiates()
	{
		for (int i = 0; i < this.instantiatingPhotonViews.Count; i++)
		{
			InstantiatingPhotonViews instantiatingPhotonViews = this.instantiatingPhotonViews[i];
			bool flag = true;
			if (instantiatingPhotonViews.instantiateHelper != null)
			{
				PhotonView[] components = instantiatingPhotonViews.instantiateHelper.GetComponents<PhotonView>();
				PhotonView[] array = components;
				foreach (PhotonView photonView in array)
				{
					if (photonView.synchronization != 0 && photonView.lastOnSerializeDataReceived == null)
					{
						flag = false;
						break;
					}
				}
				if (!flag)
				{
					continue;
				}
				m_instantiatePending = false;
				try
				{
					InstantiateState instantiateState = CompleteDeferredInstantiate(instantiatingPhotonViews);
					if (instantiateState != InstantiateState.Pending)
					{
						removingInstantiatingPhotonViews.Add(instantiatingPhotonViews);
						if (instantiateState == InstantiateState.Fail)
						{
							DebugUtils.LogError(LogCategory.Network, "Fail to instantiate " + instantiatingPhotonViews.instantiationId + "->:" + instantiatingPhotonViews.prefabName);
						}
					}
				}
				catch (Exception ex)
				{
					removingInstantiatingPhotonViews.Add(instantiatingPhotonViews);
					DebugUtils.LogError(LogCategory.Network, "Exception in Instantiation " + ex);
				}
			}
			else
			{
				DebugUtils.Log(LogCategory.Network, instantiatingPhotonViews.instantiationId + " have no instantiateHelper");
				removingInstantiatingPhotonViews.Add(instantiatingPhotonViews);
			}
		}
		if (removingInstantiatingPhotonViews.Count <= 0)
		{
			return;
		}
		foreach (InstantiatingPhotonViews removingInstantiatingPhotonView in removingInstantiatingPhotonViews)
		{
			this.instantiatingPhotonViews.Remove(removingInstantiatingPhotonView);
		}
		removingInstantiatingPhotonViews.Clear();
	}
	// Token: 0x06004D43 RID: 19779 RVA: 0x001479F8 File Offset: 0x00145BF8
	public void RunViewUpdateTick()
	{
		this.m_viewUpdateCount++;
		if (!PhotonNetwork.connected || PhotonNetwork.offlineMode)
		{
			return;
		}
		if (this.mActors != null && this.mActors.Count > 1)
		{
			if (this.m_viewUpdateCount % this.m_pingChannel.m_sendingInterval == 0)
			{
				this.SendPingUpdate();
			}
			int count = this.photonActiveViews.Count;
			for (int i = 0; i < count; i++)
			{
				PhotonView photonView = this.photonActiveViews[i];
				photonView.ClearOutStream();
				if (photonView.observed != null && photonView.synchronization != ViewSynchronization.Off && photonView.gameObject.activeInHierarchy && ((photonView.PhotonPlayer_0 == this.mLocalActor && photonView.synchronizationDir == SynchronizationDir.Broadcast) || (photonView.PhotonPlayer_0 != this.mLocalActor && photonView.synchronizationDir == SynchronizationDir.Collect) || (photonView.Boolean_0 && this.mMasterClient == this.mLocalActor)) && !this.blockSendingGroups.Contains(photonView.group))
				{
					photonView.OnSerializeToStream();
					photonView.OnSerializeWrite();
				}
			}
			if (MonoSingleton<Session>.Instance != null && MonoSingleton<Session>.Instance.method_16())
			{
				this.BroadcastGridViewUpdates();
			}
			else
			{
				this.BroadcastViewUpdatesToPlayers(false);
			}
			return;
		}
	}

	// Token: 0x06004D44 RID: 19780 RVA: 0x00147B40 File Offset: 0x00145D40
	private void BroadcastGridViewUpdates()
	{
		Dictionary<int, Hashtable> dictionary = new Dictionary<int, Hashtable>();
		Dictionary<int, Hashtable> dictionary2 = new Dictionary<int, Hashtable>();
		if (MonoSingleton<GridManager>.Instance != null)
		{
			for (int i = 0; i < MonoSingleton<GridManager>.Instance.m_grids.Count; i++)
			{
				Grid grid = MonoSingleton<GridManager>.Instance.m_grids[i];
				List<PhotonView> list = grid.m_views;
				int num = list.Count;
				if (list == null)
				{
					return;
				}
				if (grid.m_newcomersID.Count != 0)
				{
					dictionary.Clear();
					dictionary2.Clear();
					list = grid.method_0();
					num = list.Count;
					for (int j = 0; j < num; j++)
					{
						PhotonView photonView = list[j];
						if (photonView.HasPendingSerializeData() && photonView.synchronizationDir == SynchronizationDir.Broadcast)
						{
							Hashtable hashtable = photonView.BuildFullSyncData();
							if (hashtable.Count != 0)
							{
								if (photonView.synchronization != ViewSynchronization.ReliableDeltaCompressed)
								{
									if (photonView.synchronization != ViewSynchronization.Reliable)
									{
										if (!dictionary2.ContainsKey(photonView.group))
										{
											dictionary2[photonView.group] = new Hashtable();
											dictionary2[photonView.group][(byte)0] = base.ServerTimeInMilliSeconds;
										}
										Hashtable hashtable2 = dictionary2[photonView.group];
										hashtable2.Add((short)hashtable2.Count, hashtable);
										goto IL_01C4;
									}
								}
								if (hashtable.ContainsKey((byte)1) || hashtable.ContainsKey((byte)2))
								{
									if (!dictionary.ContainsKey(photonView.group))
									{
										dictionary[photonView.group] = new Hashtable();
										dictionary[photonView.group][(byte)0] = base.ServerTimeInMilliSeconds;
									}
									Hashtable hashtable3 = dictionary[photonView.group];
									hashtable3.Add((short)hashtable3.Count, hashtable);
								}
							}
						}
						IL_01C4:;
					}
					foreach (KeyValuePair<int, Hashtable> keyValuePair in dictionary)
					{
						this.RaiseEventForGroup(206, grid.m_id, keyValuePair.Value, true, 0);
					}
					foreach (KeyValuePair<int, Hashtable> keyValuePair2 in dictionary2)
					{
						this.RaiseEventForGroup(206, grid.m_id, keyValuePair2.Value, false, 0);
					}
					list = grid.m_views;
					num = list.Count;
					dictionary.Clear();
					dictionary2.Clear();
					for (int k = 0; k < num; k++)
					{
						PhotonView photonView2 = list[k];
						if (photonView2.HasPendingSerializeData() && photonView2.synchronizationDir == SynchronizationDir.Broadcast)
						{
							Hashtable hashtable4 = photonView2.BuildFullSyncData();
							if (hashtable4.Count != 0)
							{
								if (photonView2.synchronization != ViewSynchronization.ReliableDeltaCompressed)
								{
									if (photonView2.synchronization != ViewSynchronization.Reliable)
									{
										if (!dictionary2.ContainsKey(photonView2.group))
										{
											dictionary2[photonView2.group] = new Hashtable();
											dictionary2[photonView2.group][(byte)0] = base.ServerTimeInMilliSeconds;
										}
										Hashtable hashtable5 = dictionary2[photonView2.group];
										hashtable5.Add((short)hashtable5.Count, hashtable4);
										goto IL_03C9;
									}
								}
								if (hashtable4.ContainsKey((byte)1) || hashtable4.ContainsKey((byte)2))
								{
									if (!dictionary.ContainsKey(photonView2.group))
									{
										dictionary[photonView2.group] = new Hashtable();
										dictionary[photonView2.group][(byte)0] = base.ServerTimeInMilliSeconds;
									}
									Hashtable hashtable6 = dictionary[photonView2.group];
									hashtable6.Add((short)hashtable6.Count, hashtable4);
								}
							}
						}
						IL_03C9:;
					}
					foreach (KeyValuePair<int, Hashtable> keyValuePair3 in dictionary)
					{
						this.RaiseEventToActors(206, keyValuePair3.Value, true, 0, grid.m_newcomersID.ToArray());
					}
					foreach (KeyValuePair<int, Hashtable> keyValuePair4 in dictionary2)
					{
						this.RaiseEventToActors(201, keyValuePair4.Value, false, 1, grid.m_newcomersID.ToArray());
					}
				}
				if (grid.m_settlersID.Count != 0)
				{
					dictionary.Clear();
					dictionary2.Clear();
					int num2 = 0;
					for (int l = 0; l < num; l++)
					{
						PhotonView photonView3 = list[l];
						if (photonView3.HasPendingSerializeData() && photonView3.synchronizationDir == SynchronizationDir.Broadcast)
						{
							Hashtable hashtable7 = photonView3.BuildDeltaSyncData();
							if (hashtable7.Count != 0)
							{
								if (num2 >= grid.m_maxUpdateViews)
								{
									break;
								}
								num2++;
								if (photonView3.synchronization != ViewSynchronization.ReliableDeltaCompressed)
								{
									if (photonView3.synchronization != ViewSynchronization.Reliable)
									{
										if (!dictionary2.ContainsKey(photonView3.group))
										{
											dictionary2[photonView3.group] = new Hashtable();
											dictionary2[photonView3.group][(byte)0] = base.ServerTimeInMilliSeconds;
										}
										Hashtable hashtable8 = dictionary2[photonView3.group];
										hashtable8.Add((short)hashtable8.Count, hashtable7);
										goto IL_05ED;
									}
								}
								if (hashtable7.ContainsKey((byte)1) || hashtable7.ContainsKey((byte)2))
								{
									if (!dictionary.ContainsKey(photonView3.group))
									{
										dictionary[photonView3.group] = new Hashtable();
										dictionary[photonView3.group][(byte)0] = base.ServerTimeInMilliSeconds;
									}
									Hashtable hashtable9 = dictionary[photonView3.group];
									hashtable9.Add((short)hashtable9.Count, hashtable7);
								}
							}
						}
						IL_05ED:;
					}
					Dictionary<int, Hashtable>.Enumerator enumerator5 = dictionary.GetEnumerator();
					while (enumerator5.MoveNext())
					{
						byte b = 206;
						byte id = grid.m_id;
						KeyValuePair<int, Hashtable> keyValuePair5 = enumerator5.Current;
						this.RaiseEventForGroup(b, id, keyValuePair5.Value, true, 0);
					}
					Dictionary<int, Hashtable>.Enumerator enumerator6 = dictionary2.GetEnumerator();
					while (enumerator6.MoveNext())
					{
						byte b2 = 201;
						byte id2 = grid.m_id;
						KeyValuePair<int, Hashtable> keyValuePair6 = enumerator6.Current;
						this.RaiseEventForGroup(b2, id2, keyValuePair6.Value, false, 1);
					}
				}
				grid.OnNetworkingUpdated();
			}
		}
		dictionary.Clear();
		dictionary2.Clear();
		for (int m = 0; m < this.CollectViews.Count; m++)
		{
			PhotonView photonView4 = this.CollectViews[m];
			if (photonView4.HasPendingSerializeData())
			{
				Hashtable hashtable10 = photonView4.BuildDeltaSyncData();
				if (hashtable10.Count != 0)
				{
					int[] array = new int[] { photonView4.PhotonPlayer_0.ActorId };
					if (photonView4.synchronization != ViewSynchronization.ReliableDeltaCompressed)
					{
						if (photonView4.synchronization != ViewSynchronization.Reliable)
						{
							Hashtable hashtable11 = new Hashtable();
							hashtable11[(byte)0] = base.ServerTimeInMilliSeconds;
							hashtable11[(short)1] = hashtable10;
							this.RaiseEventToActors(201, hashtable11, false, 1, array);
							goto IL_0780;
						}
					}
					Hashtable hashtable12 = new Hashtable();
					hashtable12[(byte)0] = base.ServerTimeInMilliSeconds;
					hashtable12[(short)1] = hashtable10;
					this.RaiseEventToActors(206, hashtable12, true, 0, array);
				}
			}
			IL_0780:;
		}
	}

	// Token: 0x06004D45 RID: 19781 RVA: 0x0014831C File Offset: 0x0014651C
	public void BroadcastViewUpdatesToPlayers(bool bool_0 = false)
	{
		Dictionary<int, Hashtable> dictionary = new Dictionary<int, Hashtable>();
		Dictionary<int, Hashtable> dictionary2 = new Dictionary<int, Hashtable>();
		int num = this.mOtherPlayerListCopy.Length;
		if (bool_0)
		{
			num /= 2;
		}
		int num2 = this.m_lastUpdatedPlayerIndex;
		while (num2 < num && num2 < this.mOtherPlayerListCopy.Length)
		{
			this.m_lastUpdatedPlayerIndex = num2;
			int num3 = 0;
			dictionary.Clear();
			dictionary2.Clear();
			int[] array = new int[] { this.mOtherPlayerListCopy[num2].ActorId };
			PhotonPlayer photonPlayer = this.mOtherPlayerListCopy[num2];
			List<PhotonView> list = this.photonViews;
			int count = list.Count;
			if (list == null)
			{
				return;
			}
			for (int i = 0; i < count; i++)
			{
				PhotonView photonView = list[i];
				if (photonView.HasPendingSerializeData())
				{
					if (photonView.synchronizationDir != SynchronizationDir.Collect || photonView.PhotonPlayer_0 == photonPlayer)
					{
						photonView.method_8(photonPlayer);
						float num4 = (float)this.networkingPriority.method_9(photonView, photonPlayer);
						if (num4 > 66f)
						{
							this.networkingPriority.method_2(photonView, photonPlayer);
						}
						else
						{
							bool flag = false;
							double num5;
							if (photonView.m_lastUpdateTimePerPlayer.TryGetValue(photonPlayer, out num5))
							{
								if (photonView.lastTimeDataSend > num5 && (double)Time.time > num5 + 5.0)
								{
									flag = true;
								}
							}
							else
							{
								flag = true;
							}
							if (num3 >= PhotonNetwork.BandwidthCap && !flag && num4 > 0f)
							{
								this.networkingPriority.method_2(photonView, photonPlayer);
							}
							else
							{
								Hashtable hashtable = photonView.BuildSyncDataForPlayer(photonPlayer, flag);
								if (hashtable.Count != 0)
								{
									double num6;
									if (photonView.m_lastUpdateTimePerPlayer.TryGetValue(photonPlayer, out num6))
									{
										photonView.m_updateIntervalPerPlayer[photonPlayer] = (double)Time.time - num6;
									}
									photonView.m_lastUpdateTimePerPlayer[photonPlayer] = (double)Time.time;
									this.networkingPriority.method_3(photonView, photonPlayer);
									num3 += Utils.smethod_8(hashtable);
									if (photonView.synchronization != ViewSynchronization.ReliableDeltaCompressed && photonView.synchronization != ViewSynchronization.Reliable && !flag)
									{
										if (!dictionary2.ContainsKey(photonView.group))
										{
											dictionary2[photonView.group] = new Hashtable();
											dictionary2[photonView.group][(byte)0] = base.ServerTimeInMilliSeconds;
										}
										Hashtable hashtable2 = dictionary2[photonView.group];
										hashtable2.Add((short)hashtable2.Count, hashtable);
									}
									else if (hashtable.ContainsKey((byte)1) || hashtable.ContainsKey((byte)2))
									{
										if (!dictionary.ContainsKey(photonView.group))
										{
											dictionary[photonView.group] = new Hashtable();
											dictionary[photonView.group][(byte)0] = base.ServerTimeInMilliSeconds;
										}
										Hashtable hashtable3 = dictionary[photonView.group];
										hashtable3.Add((short)hashtable3.Count, hashtable);
									}
								}
							}
						}
					}
				}
			}
			Dictionary<int, Hashtable>.Enumerator enumerator = dictionary.GetEnumerator();
			while (enumerator.MoveNext())
			{
				byte b = 206;
				KeyValuePair<int, Hashtable> keyValuePair = enumerator.Current;
				this.RaiseEventToActors(b, keyValuePair.Value, true, 1, array);
			}
			Dictionary<int, Hashtable>.Enumerator enumerator2 = dictionary2.GetEnumerator();
			while (enumerator2.MoveNext())
			{
				byte b2 = 201;
				KeyValuePair<int, Hashtable> keyValuePair2 = enumerator2.Current;
				this.RaiseEventToActors(b2, keyValuePair2.Value, false, 2, array);
			}
			num2++;
		}
		this.m_lastUpdatedPlayerIndex = num2;
		if (this.m_lastUpdatedPlayerIndex >= this.mOtherPlayerListCopy.Length)
		{
			this.m_lastUpdatedPlayerIndex = 0;
		}
	}

	// Token: 0x06004D46 RID: 19782 RVA: 0x001486B0 File Offset: 0x001468B0
	public void SendPingUpdate()
	{
		if (this.mLocalActor == null)
		{
			return;
		}
		if (this.mMasterClient == null)
		{
			return;
		}
		int i = 0;
		if (this.mLocalActor.ActorId == this.mMasterClient.ActorId)
		{
			while (i < this.mOtherPlayerListCopy.Length)
			{
				this.m_roundTripEvent.Clear();
				this.m_roundTripEvent[0] = Time.realtimeSinceStartup;
				this.m_roundTripEvent[1] = (byte)this.mLocalActor.ActorId;
				int[] array = new int[] { this.mOtherPlayerListCopy[i].ActorId };
				this.RaiseEventToActors(207, this.m_roundTripEvent, true, 0, array);
				i++;
			}
		}
	}

	// Token: 0x06004D47 RID: 19783 RVA: 0x00148774 File Offset: 0x00146974
	public void InvokeSerializeViewCallback(MonoBehaviour monoBehaviour_0, PhotonStream photonStream_0, PhotonMessageInfo photonMessageInfo_0)
	{
		object[] array = new object[] { photonStream_0, photonMessageInfo_0 };
		MethodInfo methodInfo = this.FindPhotonCallbackMethod(monoBehaviour_0, PhotonNetworkingMessage.OnPhotonSerializeView);
		if (methodInfo != null)
		{
			object obj = methodInfo.Invoke(monoBehaviour_0, array);
			if (methodInfo.ReturnType == typeof(IEnumerator))
			{
				PhotonHandler.SP.StartCoroutine((IEnumerator)obj);
			}
		}
		else
		{
			DebugUtils.LogError(LogCategory.Network, string.Concat(new object[]
			{
				"Tried to run ",
				PhotonNetworkingMessage.OnPhotonSerializeView,
				", but this method was missing on: ",
				monoBehaviour_0
			}));
		}
	}

	// Token: 0x06004D48 RID: 19784 RVA: 0x001487FC File Offset: 0x001469FC
	public MethodInfo FindPhotonCallbackMethod(MonoBehaviour monoBehaviour_0, PhotonNetworkingMessage photonNetworkingMessage_0)
	{
		Type type = monoBehaviour_0.GetType();
		if (!this.cachedMethods.ContainsKey(type))
		{
			Dictionary<PhotonNetworkingMessage, MethodInfo> dictionary = new Dictionary<PhotonNetworkingMessage, MethodInfo>();
			this.cachedMethods.Add(type, dictionary);
		}
		Dictionary<PhotonNetworkingMessage, MethodInfo> dictionary2 = this.cachedMethods[type];
		if (!dictionary2.ContainsKey(photonNetworkingMessage_0))
		{
			Type[] array;
			if (photonNetworkingMessage_0 == PhotonNetworkingMessage.OnPhotonSerializeView)
			{
				array = new Type[]
				{
					typeof(PhotonStream),
					typeof(PhotonMessageInfo)
				};
			}
			else if (photonNetworkingMessage_0 == PhotonNetworkingMessage.OnPhotonInstantiate)
			{
				array = new Type[] { typeof(PhotonMessageInfo) };
			}
			else
			{
				if (photonNetworkingMessage_0 != PhotonNetworkingMessage.OnPhotonEvaluate)
				{
					DebugUtils.LogError(LogCategory.Network, "Invalid PhotonNetworkingMessage!");
					return null;
				}
				array = new Type[]
				{
					typeof(PhotonPlayer),
					typeof(PhotonPriority)
				};
			}
			MethodInfo method = monoBehaviour_0.GetType().GetMethod(photonNetworkingMessage_0 + string.Empty, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, array, null);
			if (method != null)
			{
				dictionary2.Add(photonNetworkingMessage_0, method);
			}
		}
		if (dictionary2.ContainsKey(photonNetworkingMessage_0))
		{
			return dictionary2[photonNetworkingMessage_0];
		}
		return null;
	}

	// Token: 0x06004D49 RID: 19785 RVA: 0x000322C2 File Offset: 0x000304C2
	public void ResetViewPriorities()
	{
		this.networkingPriority.method_0();
	}

	// Token: 0x06004D4A RID: 19786 RVA: 0x00148904 File Offset: 0x00146B04
	protected internal void AutomaticallySyncScene()
	{
		if (PhotonNetwork.room != null && PhotonNetwork.automaticallySyncScene && !PhotonNetwork.isMasterClient)
		{
			string text = (string)PhotonNetwork.room.Hashtable_0["curScn"];
			if (!string.IsNullOrEmpty(text) && text != Application.loadedLevelName)
			{
				PhotonNetwork.LoadLevel(text);
			}
		}
	}

	// Token: 0x06004D4B RID: 19787 RVA: 0x0014895C File Offset: 0x00146B5C
	public void ResetNetworkStatistics()
	{
		for (int i = 0; i < this.photonViews.Count; i++)
		{
			this.photonViews[i].grossRPCSize = 0;
			this.photonViews[i].grossSerializeSize = 0;
			this.photonViews[i].sizePerMethod.Clear();
			this.photonViews[i].grossRPCSizeRCV = 0;
			this.photonViews[i].grossSerializeSizeRCV = 0;
			this.photonViews[i].sizePerMethodRCV.Clear();
		}
		this.networkStat.Clear();
		this.grossInstantiateData = 0;
	}

	// Token: 0x06004D4C RID: 19788 RVA: 0x00148A08 File Offset: 0x00146C08
	public List<PhotonView> GetSortedPhotonViewsBySent()
	{
		List<PhotonView> list = new List<PhotonView>();
		list.AddRange(this.photonViews);
		list.Sort(new Comparison<PhotonView>(NetworkingPeer.smethod_1));
		return list;
	}

	// Token: 0x06004D4D RID: 19789 RVA: 0x00148A4C File Offset: 0x00146C4C
	public List<PhotonView> GetSortedPhotonViewsByReceived()
	{
		List<PhotonView> list = new List<PhotonView>();
		list.AddRange(this.photonViews);
		list.Sort(new Comparison<PhotonView>(NetworkingPeer.smethod_2));
		return list;
	}

	// Token: 0x06004D4E RID: 19790 RVA: 0x00148A90 File Offset: 0x00146C90
	public int GetTotalSentBytes()
	{
		int num = this.grossInstantiateData;
		for (int i = 0; i < this.photonViews.Count; i++)
		{
			this.networkStat[this.photonViews[i].Int32_1] = this.photonViews[i].Int32_3;
		}
		foreach (int num2 in this.networkStat.Values)
		{
			num += num2;
		}
		return num;
	}

	// Token: 0x170007C4 RID: 1988
	// (get) Token: 0x06004D4F RID: 19791 RVA: 0x000322CF File Offset: 0x000304CF
	// (set) Token: 0x06004D50 RID: 19792 RVA: 0x000322D7 File Offset: 0x000304D7
	public int grossInstantiateData { get; private set; }

	// Token: 0x06004D51 RID: 19793 RVA: 0x00148B30 File Offset: 0x00146D30
	public int GetTotalReceivedBytes()
	{
		int num = this.grossInstantiateDataRCV;
		for (int i = 0; i < this.photonViews.Count; i++)
		{
			this.networkStatRCV[this.photonViews[i].Int32_1] = this.photonViews[i].Int32_4;
		}
		foreach (int num2 in this.networkStatRCV.Values)
		{
			num += num2;
		}
		return num;
	}

	// Token: 0x170007C5 RID: 1989
	// (get) Token: 0x06004D52 RID: 19794 RVA: 0x000322E0 File Offset: 0x000304E0
	// (set) Token: 0x06004D53 RID: 19795 RVA: 0x000322E8 File Offset: 0x000304E8
	public int grossInstantiateDataRCV { get; private set; }

	// Token: 0x06004D54 RID: 19796 RVA: 0x000322F1 File Offset: 0x000304F1
	public void RegisterEventCallback(byte byte_0, EventCallback eventCallback_0)
	{
		if (this.mEventCallbacks.ContainsKey(byte_0))
		{
			throw new ArgumentException(string.Format("RegisterEventCallback: Already registered a callback for event code {0}", byte_0), "eventCode");
		}
		this.mEventCallbacks[byte_0] = eventCallback_0;
	}

	// Token: 0x06004D55 RID: 19797 RVA: 0x00032329 File Offset: 0x00030529
	public void UnregisterEventCallback(byte byte_0)
	{
		this.mEventCallbacks.Remove(byte_0);
	}

	// Token: 0x06004D56 RID: 19798 RVA: 0x00032338 File Offset: 0x00030538
	public bool RegisterOperationResponseCallback(byte byte_0, OperationResponseCallback operationResponseCallback_0)
	{
		if (this.mOperationResponseCallbacks.ContainsKey(byte_0))
		{
			return false;
		}
		this.mOperationResponseCallbacks[byte_0] = operationResponseCallback_0;
		return true;
	}

	// Token: 0x06004D57 RID: 19799 RVA: 0x00032358 File Offset: 0x00030558
	public void UnregisterOperationResponseCallback(byte byte_0)
	{
		this.mOperationResponseCallbacks.Remove(byte_0);
	}

	// Token: 0x06004D58 RID: 19800 RVA: 0x00148BD0 File Offset: 0x00146DD0
	public bool OpCustomWithArgs(byte byte_0, params object[] object_0)
	{
		Dictionary<byte, object> customOpParameters = Enumerable.Range(0, object_0.Length).ToDictionary((int int_0) => (byte)int_0, (int int_0) => object_0[int_0]);
		return OpCustom(byte_0, customOpParameters, sendReliable: true);
	}
	// Token: 0x06004D59 RID: 19801 RVA: 0x00032367 File Offset: 0x00030567
	public override bool OpSetRoomProperties(Hashtable hashtable_0, bool bool_0, byte byte_0)
	{
		return !this.MasterConnection && base.OpSetRoomProperties(hashtable_0, bool_0, byte_0);
	}

	// Token: 0x06004D5A RID: 19802 RVA: 0x0003237C File Offset: 0x0003057C
	protected override bool OpSetActorProperties(int int_0, Hashtable hashtable_0, bool bool_0, byte byte_0)
	{
		return !this.MasterConnection && base.OpSetActorProperties(int_0, hashtable_0, bool_0, byte_0);
	}

	// Token: 0x06004D5B RID: 19803 RVA: 0x00032393 File Offset: 0x00030593
	[CompilerGenerated]
	private static int smethod_1(PhotonView photonView_0, PhotonView photonView_1)
	{
		return photonView_1.Int32_3 - photonView_0.Int32_3;
	}

	// Token: 0x06004D5C RID: 19804 RVA: 0x000323A2 File Offset: 0x000305A2
	[CompilerGenerated]
	private static int smethod_2(PhotonView photonView_0, PhotonView photonView_1)
	{
		return photonView_1.Int32_4 - photonView_0.Int32_4;
	}

	// Token: 0x06004D5D RID: 19805 RVA: 0x000323B1 File Offset: 0x000305B1
	[CompilerGenerated]
	private static byte smethod_3(int int_0)
	{
		return (byte)int_0;
	}

	// Token: 0x040039A5 RID: 14757
	protected internal const string CurrentSceneProperty = "curScn";

	// Token: 0x040039A6 RID: 14758
	public string mAppVersion;

	// Token: 0x040039A7 RID: 14759
	public string mAppId;

	// Token: 0x040039A8 RID: 14760
	private string masterServerAddress;

	// Token: 0x040039A9 RID: 14761
	private string playername = string.Empty;

	// Token: 0x040039AA RID: 14762
	private IPhotonPeerListener externalListener;

	// Token: 0x040039AB RID: 14763
	public JoinType mLastJoinType;

	// Token: 0x040039AC RID: 14764
	private bool mPlayernameHasToBeUpdated;

	// Token: 0x040039AD RID: 14765
	private Queue<string> mFallbackSessions;

	// Token: 0x040039AE RID: 14766
	public Dictionary<int, PhotonPlayer> mActors = new Dictionary<int, PhotonPlayer>();

	// Token: 0x040039AF RID: 14767
	public PhotonPlayer[] mOtherPlayerListCopy = new PhotonPlayer[0];

	// Token: 0x040039B0 RID: 14768
	public PhotonPlayer[] mPlayerListCopy = new PhotonPlayer[0];

	// Token: 0x040039B1 RID: 14769
	public PhotonPlayer mMasterClient;

	// Token: 0x040039B2 RID: 14770
	public bool requestSecurity = true;

	// Token: 0x040039B3 RID: 14771
	private Dictionary<Type, List<MethodInfo>> monoRPCMethodsCache = new Dictionary<Type, List<MethodInfo>>();

	// Token: 0x040039B4 RID: 14772
	public static bool UsePrefabCache = false;

	// Token: 0x040039B5 RID: 14773
	public static Dictionary<string, GameObject> PrefabCache = new Dictionary<string, GameObject>();

	// Token: 0x040039B6 RID: 14774
	public Dictionary<string, RoomInfo> mGameList = new Dictionary<string, RoomInfo>();

	// Token: 0x040039B7 RID: 14775
	public RoomInfo[] mGameListCopy = new RoomInfo[0];

	// Token: 0x040039B8 RID: 14776
	public bool insideLobby;

	// Token: 0x040039B9 RID: 14777
	public Dictionary<int, GameObject> instantiatedObjects = new Dictionary<int, GameObject>();

	// Token: 0x040039BA RID: 14778
	public HashSet<int> allowedReceivingGroups = new HashSet<int>();

	// Token: 0x040039BB RID: 14779
	private HashSet<int> blockSendingGroups = new HashSet<int>();

	// Token: 0x040039BC RID: 14780
	protected internal Dictionary<int, PhotonView> photonViewList = new Dictionary<int, PhotonView>();

	// Token: 0x040039BD RID: 14781
	protected internal short currentLevelPrefix;

	// Token: 0x040039BE RID: 14782
	private Dictionary<Type, Dictionary<PhotonNetworkingMessage, MethodInfo>> cachedMethods = new Dictionary<Type, Dictionary<PhotonNetworkingMessage, MethodInfo>>();

	// Token: 0x040039BF RID: 14783
	private List<PhotonView> photonViews = new List<PhotonView>();

	// Token: 0x040039C0 RID: 14784
	private List<PhotonView> photonActiveViews = new List<PhotonView>();

	// Token: 0x040039C1 RID: 14785
	private List<PhotonView> CollectViews = new List<PhotonView>();

	// Token: 0x040039C2 RID: 14786
	private List<PhotonView> BroadcastViews = new List<PhotonView>();

	// Token: 0x040039C3 RID: 14787
	private Dictionary<int, float> peerRoundTripTimes = new Dictionary<int, float>();

	// Token: 0x040039C4 RID: 14788
	private PhotonChannel m_pingChannel = new PhotonChannel(5);

	// Token: 0x040039C5 RID: 14789
	private int m_viewUpdateCount;

	// Token: 0x040039C6 RID: 14790
	private int m_lastUpdatedPlayerIndex;

	// Token: 0x040039C7 RID: 14791
	public NetworkingPriority networkingPriority = NetworkingPriority.NetworkingPriority_0;

	// Token: 0x040039C8 RID: 14792
	private bool m_instantiatePending;

	// Token: 0x040039C9 RID: 14793
	public string maccount;

	// Token: 0x040039CA RID: 14794
	public string mpwd;

	// Token: 0x040039CB RID: 14795
	public string mToken;

	// Token: 0x040039CC RID: 14796
	private Dictionary<int, NetworkingPeer.StoredDataForNoView> m_StoredDataForNoView = new Dictionary<int, NetworkingPeer.StoredDataForNoView>();

	// Token: 0x040039CD RID: 14797
	private List<NetworkingPeer.InstantiatingPhotonViews> instantiatingPhotonViews = new List<NetworkingPeer.InstantiatingPhotonViews>();

	// Token: 0x040039CE RID: 14798
	private List<NetworkingPeer.InstantiatingPhotonViews> removingInstantiatingPhotonViews = new List<NetworkingPeer.InstantiatingPhotonViews>();

	// Token: 0x040039CF RID: 14799
	private Dictionary<int, object[]> tempInstantiationData = new Dictionary<int, object[]>();

	// Token: 0x040039D0 RID: 14800
	private Hashtable m_roundTripEvent = new Hashtable();

	// Token: 0x040039D1 RID: 14801
	protected internal bool loadingLevelAndPausedNetwork;

	// Token: 0x040039D2 RID: 14802
	private Dictionary<int, int> networkStat = new Dictionary<int, int>();

	// Token: 0x040039D3 RID: 14803
	private Dictionary<int, int> networkStatRCV = new Dictionary<int, int>();

	// Token: 0x040039D4 RID: 14804
	private Dictionary<byte, OperationResponseCallback> mOperationResponseCallbacks = new Dictionary<byte, OperationResponseCallback>();

	// Token: 0x040039D5 RID: 14805
	private Dictionary<byte, EventCallback> mEventCallbacks = new Dictionary<byte, EventCallback>();

	// Token: 0x02000B1D RID: 2845
	private struct StoredDataForNoView
	{
		// Token: 0x040039E5 RID: 14821
		public Hashtable data;

		// Token: 0x040039E6 RID: 14822
		public PhotonPlayer originatingPlayer;

		// Token: 0x040039E7 RID: 14823
		public int remoteUpdateServerTimestamp;

		// Token: 0x040039E8 RID: 14824
		public short remoteLevelPrefix;
	}

	// Token: 0x02000B1E RID: 2846
	private enum InstantiateState
	{
		// Token: 0x040039EA RID: 14826
		Success,
		// Token: 0x040039EB RID: 14827
		Fail,
		// Token: 0x040039EC RID: 14828
		Pending
	}

	// Token: 0x02000B1F RID: 2847
	private class InstantiatingPhotonViews
	{
		// Token: 0x040039ED RID: 14829
		public GameObject instantiateHelper;

		// Token: 0x040039EE RID: 14830
		public int instantiationId;

		// Token: 0x040039EF RID: 14831
		public GameObject resourceGameObject;

		// Token: 0x040039F0 RID: 14832
		public string prefabName;

		// Token: 0x040039F1 RID: 14833
		public Vector3 position;

		// Token: 0x040039F2 RID: 14834
		public Quaternion rotation;

		// Token: 0x040039F3 RID: 14835
		public PhotonPlayer photonPlayer;

		// Token: 0x040039F4 RID: 14836
		public int serverTime;

		// Token: 0x040039F5 RID: 14837
		public int group;

		// Token: 0x040039F6 RID: 14838
		public int objLevelPrefix;

		// Token: 0x040039F7 RID: 14839
		public object[] incomingInstantiationData;
	}
}
