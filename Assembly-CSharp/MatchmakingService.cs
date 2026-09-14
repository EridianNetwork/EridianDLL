using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using Core;
using ns0;
using Photon;
using UnityEngine;
using XsdSettings;

// Token: 0x020003B9 RID: 953
public class MatchmakingService : global::Photon.MonoBehaviour
{
	// Token: 0x17000146 RID: 326
	// (get) Token: 0x0600181A RID: 6170 RVA: 0x00011E6D File Offset: 0x0001006D
	public static MatchmakingService MatchmakingService_0
	{
		get
		{
			return MatchmakingService.s_instance;
		}
	}

	// Token: 0x0600181B RID: 6171 RVA: 0x00011E74 File Offset: 0x00010074
	private void Awake()
	{
		if (MatchmakingService.s_instance != null)
		{
			DebugUtils.LogError(LogCategory.Network, "MatchmakingService is already initialized");
		}
		MatchmakingService.s_instance = this;
	}

	// Token: 0x0600181C RID: 6172 RVA: 0x0008092C File Offset: 0x0007EB2C
	private void Start()
	{
		this.mGameOwnerChangedListeners = new List<GameOwnerChangedListener>();
		this.mKickedFromGameListeners = new List<KickedFromGameListener>();
		if (!string.IsNullOrEmpty(MonoSingleton<AppManager>.Instance.m_autoTestCase))
		{
			MonoSingleton<AppManager>.Instance.m_playlistId = 0;
		}
		TextAsset textAsset = (TextAsset)ResourcesLoader.smethod_0("Settings/Playlist");
		string text = textAsset.text;
		try
		{
			string text2 = Path.Combine(Application.dataPath, "../overrides/playlist_override.xml");
			if (File.Exists(text2))
			{
				text = File.ReadAllText(text2);
				DebugUtils.Log(LogCategory.Network, "MatchmakingService: using external playlist override " + text2);
			}
		}
		catch (Exception ex)
		{
			DebugUtils.LogError(LogCategory.Network, "MatchmakingService: playlist override load failed: " + ex.Message);
			text = textAsset.text;
		}
		using (StringReader stringReader = new StringReader(text))
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(PlayListSetup));
			this.m_playlistSetup = xmlSerializer.Deserialize(stringReader) as PlayListSetup;
		}
		Resources.UnloadAsset(textAsset);
		PhotonNetwork.networkingPeer.RegisterOperationResponseCallback(136, new OperationResponseCallback(this.OnKickPlayerFromGameResponse));
		PhotonNetwork.networkingPeer.RegisterEventCallback(197, new EventCallback(this.OnGameOwnerChangedEvent));
		PhotonNetwork.networkingPeer.RegisterEventCallback(196, new EventCallback(this.OnKickedFromGameEvent));
		OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.Prop_0.imethod_10(new OnPlayerJoinLobby(this.OnPlayerJoinPvPRoom));
		OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.Prop_0.imethod_12(new OnPlayerLeaveLobby(this.OnPlayerLeavePvPRoom));
		OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.Prop_0.imethod_22(new OnLobbyOwnerChange(this.OnPvPRoomOwnerChange));
		OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.Prop_0.imethod_18(new OnLobbyClose(this.OnPvPRoomClose));
		OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.Prop_0.imethod_20(new OnLobbyDelete(this.OnPvPRoomDelete));
		OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.Prop_0.imethod_26(new OnGroupJoinLobby(this.OnGroupJoinPvPRoom));
		OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.Prop_0.imethod_28(new OnGroupLeaveLobby(this.OnGroupLeavePvPRoom));
	}

	// Token: 0x0600181D RID: 6173 RVA: 0x00011E95 File Offset: 0x00010095
	public Playlist method_0()
	{
		return this.method_1(MonoSingleton<AppManager>.Instance.m_playlistId);
	}

	// Token: 0x0600181E RID: 6174 RVA: 0x00080B20 File Offset: 0x0007ED20
	public Playlist method_1(int int_0)
	{
		for (int i = 0; i < this.m_playlistSetup.m_playlists.Length; i++)
		{
			if (this.m_playlistSetup.m_playlists[i].m_id == int_0)
			{
				return this.m_playlistSetup.m_playlists[i];
			}
		}
		return null;
	}

	// Token: 0x0600181F RID: 6175 RVA: 0x00080B6C File Offset: 0x0007ED6C
	public Playlist method_2(string string_0)
	{
		for (int i = 0; i < this.m_playlistSetup.m_playlists.Length; i++)
		{
			Playlist playlist = this.m_playlistSetup.m_playlists[i];
			for (int j = 0; j < playlist.m_sceneToPlay.Length; j++)
			{
				if (playlist.m_sceneToPlay[j] == string_0)
				{
					return playlist;
				}
			}
		}
		return null;
	}

	// Token: 0x06001820 RID: 6176 RVA: 0x00080BC8 File Offset: 0x0007EDC8
	public Playlist method_3(string string_0)
	{
		for (int i = 0; i < this.m_playlistSetup.m_playlists.Length; i++)
		{
			if (this.m_playlistSetup.m_playlists[i].m_name == string_0)
			{
				return this.m_playlistSetup.m_playlists[i];
			}
		}
		return null;
	}

	// Token: 0x06001821 RID: 6177 RVA: 0x00011EA7 File Offset: 0x000100A7
	public int method_4(int int_0)
	{
		if (this.m_playlistprogressionmapping.ContainsKey(int_0))
		{
			return this.m_playlistprogressionmapping[int_0];
		}
		return -1;
	}

	// Token: 0x06001822 RID: 6178 RVA: 0x00011EC5 File Offset: 0x000100C5
	private void OnFindPvPRoom(Lobby room)
	{
		DebugUtils.Log(LogCategory.Network, "MatchmakingService.OnFindPvPRoom - " + Time.time);
		this.m_myPvpRoom = room;
		this.method_14();
	}

	// Token: 0x06001823 RID: 6179 RVA: 0x00011EEF File Offset: 0x000100EF
	public void method_5()
	{
		DebugUtils.Log(LogCategory.Network, "MatchmakingService.ReMatch");
		this.m_isRematching = true;
		if (this.m_myPvpRoom != null)
		{
			OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.Prop_0.imethod_6(new OnLeaveLobby(this.OnLeavePvPRoom));
		}
		else
		{
			this.OnLeavePvPRoom(true);
		}
	}

	// Token: 0x06001824 RID: 6180 RVA: 0x00080C18 File Offset: 0x0007EE18
	private void OnLeavePvPRoom(bool success)
	{
		DebugUtils.Log(LogCategory.Network, "MatchmakingService.OnLeavePvPRoom - " + Time.time);
		this.m_myPvpRoom = null;
		if (this.m_isRematching)
		{
			OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.Prop_0.imethod_0(new OnCreateLobby(this.OnCreateRematchLobby), true);
			this.m_isRematching = false;
		}
		this.m_isRematching = false;
	}

	// Token: 0x06001825 RID: 6181 RVA: 0x00080C74 File Offset: 0x0007EE74
	private void OnCreateRematchLobby(Lobby newLobby)
	{
		this.m_myPvpRoom = newLobby;
		Playlist playlist = MatchmakingService.MatchmakingService_0.method_0();
		OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.Prop_0.imethod_1(new OnOpenLobby(this.OnFindPvPRoom), MatchmakingService.smethod_0(playlist.m_gameMode), playlist.m_id, ELevelDifficulty.Normal);
	}

	// Token: 0x06001826 RID: 6182 RVA: 0x00011F2B File Offset: 0x0001012B
	public void method_6()
	{
		DebugUtils.Log(LogCategory.Network, "MatchmakingService.CancelPvP - " + Time.time);
		OnAccessSingleton<ILobbyService, LobbyService, LobbyServiceOffline>.Prop_0.imethod_6(new OnLeaveLobby(this.OnLeavePvPRoom));
	}

	// Token: 0x06001827 RID: 6183 RVA: 0x00011F5E File Offset: 0x0001015E
	public void method_7()
	{
		DebugUtils.Log(LogCategory.Network, "MatchmakingService.CancelInstance - " + Time.time);
		PhotonNetwork.CancelJoin();
	}

	// Token: 0x06001828 RID: 6184 RVA: 0x00011F80 File Offset: 0x00010180
	public int method_8(GamemodeType gamemodeType_0)
	{
		return -1;
	}

	// Token: 0x06001829 RID: 6185 RVA: 0x00080CBC File Offset: 0x0007EEBC
	public static GamemodeType smethod_0(string string_0)
	{
		if (string.IsNullOrEmpty(string_0))
		{
			return GamemodeType.None;
		}
		if (string_0.Equals("GameModeTown", StringComparison.OrdinalIgnoreCase))
		{
			return GamemodeType.GamemodeTown;
		}
		if (string_0.Equals("GameModePvE", StringComparison.OrdinalIgnoreCase))
		{
			return GamemodeType.GamemodePvE;
		}
		if (string_0.Equals("GameModeSurvival", StringComparison.OrdinalIgnoreCase))
		{
			return GamemodeType.GamemodeSurvival;
		}
		if (string_0.Equals("GameModePvP", StringComparison.OrdinalIgnoreCase))
		{
			return GamemodeType.GamemodeDeathmatch;
		}
		if (string_0.Equals("GameModeTeamDeathmatch", StringComparison.OrdinalIgnoreCase))
		{
			return GamemodeType.GamemodeTeamDeathmatch;
		}
		if (string_0.Equals("GamemodeTutorial", StringComparison.OrdinalIgnoreCase))
		{
			return GamemodeType.GamemodeTutorial;
		}
		if (string_0.Equals("GamemodeClaptrapSoccer", StringComparison.OrdinalIgnoreCase))
		{
			return GamemodeType.GamemodeClaptrapSoccer;
		}
		if (string_0.Equals("GamemodeRV", StringComparison.OrdinalIgnoreCase))
		{
			return GamemodeType.GamemodeRV;
		}
		return GamemodeType.None;
	}

	// Token: 0x0600182A RID: 6186 RVA: 0x00080D54 File Offset: 0x0007EF54
	public static bool smethod_1(GamemodeType gamemodeType_0)
	{
		switch (gamemodeType_0)
		{
		case GamemodeType.GamemodeDeathmatch:
		case GamemodeType.GamemodeTeamDeathmatch:
		case GamemodeType.GamemodeClaptrapSoccer:
			return true;
		default:
			return false;
		}
	}

	// Token: 0x0600182B RID: 6187 RVA: 0x00011F83 File Offset: 0x00010183
	public void method_9(int int_0)
	{
		PhotonNetwork.networkingPeer.OpCustomWithArgs(136, new object[] { int_0 });
	}

	// Token: 0x0600182C RID: 6188 RVA: 0x0000311B File Offset: 0x0000131B
	private void OnKickPlayerFromGameResponse(short OperationResponse, Dictionary<byte, object> parameters)
	{
	}

	// Token: 0x0600182D RID: 6189 RVA: 0x00011FA4 File Offset: 0x000101A4
	public void method_10(KickedFromGameListener kickedFromGameListener_0)
	{
		this.mKickedFromGameListeners.Add(kickedFromGameListener_0);
	}

	// Token: 0x0600182E RID: 6190 RVA: 0x00011FB2 File Offset: 0x000101B2
	public void method_11(KickedFromGameListener kickedFromGameListener_0)
	{
		this.mKickedFromGameListeners.Remove(kickedFromGameListener_0);
	}

	// Token: 0x0600182F RID: 6191 RVA: 0x00011FC1 File Offset: 0x000101C1
	private void OnKickedFromGameEvent(Dictionary<byte, object> parameters)
	{
		this.mKickedFromGameListeners.ForEach(new Action<KickedFromGameListener>(MatchmakingService.smethod_2));
	}

	// Token: 0x06001830 RID: 6192 RVA: 0x00011FEB File Offset: 0x000101EB
	public void method_12(GameOwnerChangedListener gameOwnerChangedListener_0)
	{
		this.mGameOwnerChangedListeners.Add(gameOwnerChangedListener_0);
	}

	// Token: 0x06001831 RID: 6193 RVA: 0x00011FF9 File Offset: 0x000101F9
	public void method_13(GameOwnerChangedListener gameOwnerChangedListener_0)
	{
		this.mGameOwnerChangedListeners.Remove(gameOwnerChangedListener_0);
	}

	// Token: 0x06001832 RID: 6194 RVA: 0x00080D80 File Offset: 0x0007EF80
	private void OnGameOwnerChangedEvent(Dictionary<byte, object> parameters)
	{
		mGameOwnerChangedListeners.ForEach(delegate(GameOwnerChangedListener gameOwnerChangedListener_0)
		{
			gameOwnerChangedListener_0((int)parameters[0]);
		});
	}
	// Token: 0x06001833 RID: 6195 RVA: 0x00080DB4 File Offset: 0x0007EFB4
	private void method_14()
	{
		if (this.m_myPvpRoom == null)
		{
			return;
		}
		if (this.m_myPvpRoom.Owner != OnlineService.s_characterId)
		{
			return;
		}
		if (!this.m_myPvpRoom.HasGameStarted)
		{
			Playlist playlist = this.method_1(this.m_myPvpRoom.Playlist);
			if (this.m_myPvpRoom.Int32_0 < playlist.m_minPlayerCountToStart)
			{
				return;
			}
			if (this.m_myPvpRoom.IsGroupGame && this.m_myPvpRoom.GameMode == GamemodeType.GamemodeTeamDeathmatch && (this.m_myPvpRoom.IsGroupGame || this.m_myPvpRoom.Int32_0 <= 1))
			{
				return;
			}
			this.m_myPvpRoom.HasGameStarted = true;
			MonoSingleton<AppManager>.Instance.m_playlistId = playlist.m_id;
			DebugUtils.Log(LogCategory.Network, "MatchmakingService.CheckPvPStartCondition - " + this.m_myPvpRoom.Playlist);
			MonoSingleton<GameFlowManager>.Instance.method_12(this.m_myPvpRoom.Playlist, this.m_myPvpRoom.GameMode);
		}
	}

	// Token: 0x06001834 RID: 6196 RVA: 0x00012008 File Offset: 0x00010208
	private void OnPlayerJoinPvPRoom(Presence newPlayer)
	{
		DebugUtils.Log(LogCategory.Network, "MatchmakingService.OnPlayerJoinPvPRoom - " + newPlayer.mCharacterId);
		if (this.m_myPvpRoom == null)
		{
			return;
		}
		this.m_myPvpRoom.method_0(newPlayer);
		this.method_14();
	}

	// Token: 0x06001835 RID: 6197 RVA: 0x00012041 File Offset: 0x00010241
	private void OnGroupJoinPvPRoom(int newGroupId)
	{
		DebugUtils.Log(LogCategory.Network, "MatchmakingService.OnGroupJoinPvPRoom - " + newGroupId);
		this.method_14();
	}

	// Token: 0x06001836 RID: 6198 RVA: 0x00012060 File Offset: 0x00010260
	private void OnPlayerLeavePvPRoom(int characterId)
	{
		DebugUtils.Log(LogCategory.Network, "MatchmakingService.OnPlayerLeavePvPRoom - " + characterId);
		if (this.m_myPvpRoom == null)
		{
			return;
		}
		if (characterId == OnlineService.s_characterId)
		{
			this.m_myPvpRoom = null;
			return;
		}
		this.m_myPvpRoom.method_1(characterId);
	}

	// Token: 0x06001837 RID: 6199 RVA: 0x0001209F File Offset: 0x0001029F
	private void OnGroupLeavePvPRoom(int groupId)
	{
		DebugUtils.Log(LogCategory.Network, "MatchmakingService.OnGroupLeavePvPRoom - " + groupId);
		if (this.m_myPvpRoom == null)
		{
			return;
		}
		if (groupId == GroupManager.smethod_0().m_nGroupId)
		{
			this.m_myPvpRoom = null;
			return;
		}
	}

	// Token: 0x06001838 RID: 6200 RVA: 0x00080EA8 File Offset: 0x0007F0A8
	private void OnPvPRoomOwnerChange(int newOwnerCharacterId)
	{
		DebugUtils.Log(LogCategory.Network, string.Concat(new object[]
		{
			"MatchmakingService.OnPvPRoomOwnerChange[",
			newOwnerCharacterId,
			"] - ",
			Time.time
		}));
		if (this.m_myPvpRoom == null)
		{
			return;
		}
		this.m_myPvpRoom.Owner = newOwnerCharacterId;
	}

	// Token: 0x06001839 RID: 6201 RVA: 0x000120D6 File Offset: 0x000102D6
	private void OnPvPRoomClose()
	{
		DebugUtils.Log(LogCategory.Network, "MatchmakingService.OnPvPRoomClose - " + Time.time);
	}

	// Token: 0x0600183A RID: 6202 RVA: 0x000120F3 File Offset: 0x000102F3
	private void OnPvPRoomDelete()
	{
		DebugUtils.Log(LogCategory.Network, "MatchmakingService.OnPvPRoomDelete - " + Time.time);
		this.m_myPvpRoom = null;
		LobbyManager.smethod_0().OnLobbyClose();
	}

	// Token: 0x0600183B RID: 6203 RVA: 0x00012121 File Offset: 0x00010321
	[CompilerGenerated]
	private static void smethod_2(KickedFromGameListener kickedFromGameListener_0)
	{
		kickedFromGameListener_0();
	}

	// Token: 0x0400105A RID: 4186
	private static MatchmakingService s_instance;

	// Token: 0x0400105B RID: 4187
	private PlayListSetup m_playlistSetup;

	// Token: 0x0400105C RID: 4188
	public Dictionary<int, int> m_playlistprogressionmapping = new Dictionary<int, int>
	{
		{ 2, 1 },
		{ 5, 2 },
		{ 4, 3 },
		{ 3, 4 },
		{ 1, 5 }
	};

	// Token: 0x0400105D RID: 4189
	private Lobby m_myPvpRoom;

	// Token: 0x0400105E RID: 4190
	private bool m_isRematching;

	// Token: 0x0400105F RID: 4191
	private List<GameOwnerChangedListener> mGameOwnerChangedListeners;

	// Token: 0x04001060 RID: 4192
	private List<KickedFromGameListener> mKickedFromGameListeners;

	// Token: 0x020003BA RID: 954
	public class FindMeAPlaylistAsyncTask : PhotonNetworkTask
	{
		// Token: 0x0600183D RID: 6205 RVA: 0x00012129 File Offset: 0x00010329
		public void method_4(int int_1, int int_2)
		{
			this.m_characterId = int_1;
			this.m_playlistId = int_2;
			this.float_1 = 30f;
		}

		// Token: 0x0600183E RID: 6206 RVA: 0x00080F04 File Offset: 0x0007F104
		public override void Start()
		{
			base.Start();
			NetworkManager.WaitServerSwitchAsyncTask waitServerSwitchAsyncTask = new NetworkManager.WaitServerSwitchAsyncTask();
			waitServerSwitchAsyncTask.method_4();
			MonoSingleton<AsyncTaskManager>.Instance.method_1(waitServerSwitchAsyncTask, new TaskCompletedDelegate(this.OnServerSwitchCompleted));
		}

		// Token: 0x0600183F RID: 6207 RVA: 0x00080F3C File Offset: 0x0007F13C
		private void OnServerSwitchCompleted(AsyncTaskBase task, AsyncTaskStatus result)
		{
			if (result != AsyncTaskStatus.Success)
			{
				base.SetStatus(result);
				return;
			}
			if (PhotonNetwork.room != null)
			{
				PhotonNetwork.LeaveRoom();
			}
			PhotonNetwork.SetReceivingEnabled(1, false);
			PhotonNetwork.SetReceivingEnabled(2, false);
			PhotonNetwork.SetReceivingEnabled(3, false);
			this.m_playList = MatchmakingService.MatchmakingService_0.method_1(this.m_playlistId);
			DebugUtils.Log(LogCategory.Network, string.Concat(new object[]
			{
				"FindMeAPlaylistAsyncTask.Start for Playlist [",
				this.m_playlistId,
				"][",
				this.m_playList.m_name,
				"][",
				MonoSingleton<AppManager>.Instance.m_debugInfo_Version,
				"]"
			}));
			if (MonoSingleton<AppManager>.Instance.m_privateSessionName != string.Empty)
			{
				DebugUtils.Log(LogCategory.Network, "JoinRoom [" + MonoSingleton<AppManager>.Instance.m_privateSessionName + "]");
				PhotonNetwork.JoinRoom(MonoSingleton<AppManager>.Instance.m_privateSessionName);
				return;
			}
			RoomInfo[] roomList = PhotonNetwork.GetRoomList();
			if (roomList.Length > 0)
			{
				foreach (RoomInfo roomInfo in roomList)
				{
					DebugUtils.Log(LogCategory.Network, string.Concat(new object[] { "Room [", roomInfo.String_0, " ", roomInfo.playerCount, "/", roomInfo.Byte_0, "]" }));
					if (roomInfo.String_0.Contains(MonoSingleton<AppManager>.Instance.m_debugInfo_Version) && roomInfo.String_0.Contains(this.m_playList.m_name) && roomInfo.playerCount < (int)roomInfo.Byte_0)
					{
						DebugUtils.Log(LogCategory.Network, "JoinRoom [" + roomInfo.String_0 + "]");
						try
						{
							PhotonNetwork.JoinRoom(roomInfo.String_0);
						}
						catch (Exception ex)
						{
							DebugUtils.LogError(LogCategory.Network, "JoinRoom Exception[" + ex + "]");
							base.SetStatus(AsyncTaskStatus.Error_JoinRoomFail);
						}
						return;
					}
				}
			}
			Hashtable hashtable = new Hashtable();
			GamemodeType gamemodeType = MatchmakingService.smethod_0(this.m_playList.m_gameMode);
			hashtable["PlaylistId"] = this.m_playlistId;
			hashtable["VersionId"] = string.Empty;
			hashtable["GameMode"] = (int)gamemodeType;
			hashtable["ForceStartGameTime"] = 0;
			hashtable["Difficulty"] = (int)MonoSingleton<AppManager>.Instance.m_difficulty;
			PlayerProperties playerProperties = MonoSingleton<PlayerManager>.Instance.method_2();
			if (playerProperties == null)
			{
				hashtable["LevelledMatchmaking"] = false;
			}
			else
			{
				hashtable["PlayerLevel"] = playerProperties.m_level;
			}
			switch (gamemodeType)
			{
			case GamemodeType.GamemodePvE:
			case GamemodeType.GamemodeSurvival:
				hashtable["JoinInProgress"] = true;
				hashtable["GroupMatchmakingEnabled"] = true;
				break;
			case GamemodeType.GamemodeDeathmatch:
			case GamemodeType.GamemodeTeamDeathmatch:
			case GamemodeType.GamemodeClaptrapSoccer:
				hashtable["JoinInProgress"] = true;
				hashtable["GroupMatchmakingEnabled"] = true;
				if (GroupManager.smethod_0().method_18())
				{
					hashtable["GroupGame"] = true;
				}
				break;
			case GamemodeType.GamemodeTutorial:
				hashtable["JoinInProgress"] = this.m_playList.m_maxPlayerCount > 1;
				hashtable["IsOpen"] = this.m_playList.m_maxPlayerCount > 1;
				break;
			default:
				hashtable["JoinInProgress"] = true;
				hashtable["GroupMatchmakingEnabled"] = false;
				hashtable["LevelledMatchmaking"] = false;
				break;
			}
			try
			{
				PhotonNetwork.JoinRandomRoom(hashtable, 0);
			}
			catch (Exception ex2)
			{
				DebugUtils.LogError(LogCategory.Network, "JoinRandomRoom Exception[" + ex2 + "]");
				base.SetStatus(AsyncTaskStatus.Error_JoinRoomFail);
			}
		}

		// Token: 0x06001840 RID: 6208 RVA: 0x00012144 File Offset: 0x00010344
		public override void OnJoinedRoom()
		{
			if (base.IsStatus())
			{
				return;
			}
			base.SetStatus(AsyncTaskStatus.Success);
		}

		// Token: 0x06001841 RID: 6209 RVA: 0x00012156 File Offset: 0x00010356
		public override void OnPhotonJoinRoomFailed()
		{
			if (base.IsStatus())
			{
				return;
			}
			base.SetStatus(AsyncTaskStatus.Error_JoinRoomFail);
		}

		// Token: 0x06001842 RID: 6210 RVA: 0x00012156 File Offset: 0x00010356
		public override void OnPhotonRandomJoinFailed()
		{
			if (base.IsStatus())
			{
				return;
			}
			base.SetStatus(AsyncTaskStatus.Error_JoinRoomFail);
		}

		// Token: 0x06001843 RID: 6211 RVA: 0x00012169 File Offset: 0x00010369
		public override void vmethod_0()
		{
			if (base.GetStatus() == AsyncTaskStatus.Error_Timeout)
			{
				PhotonNetwork.CancelJoin();
			}
			base.vmethod_0();
		}

		// Token: 0x04001062 RID: 4194
		public int m_characterId;

		// Token: 0x04001063 RID: 4195
		public int m_playlistId;

		// Token: 0x04001064 RID: 4196
		public Playlist m_playList;
	}

	// Token: 0x020003BB RID: 955
	public class JoinRoomAsyncTask : PhotonNetworkTask
	{
		// Token: 0x06001845 RID: 6213 RVA: 0x0001217F File Offset: 0x0001037F
		public void method_4(string string_0)
		{
			this.m_roomName = string_0;
			this.float_1 = 30f;
		}

		// Token: 0x06001846 RID: 6214 RVA: 0x00081350 File Offset: 0x0007F550
		public override void Start()
		{
			base.Start();
			NetworkManager.WaitServerSwitchAsyncTask waitServerSwitchAsyncTask = new NetworkManager.WaitServerSwitchAsyncTask();
			waitServerSwitchAsyncTask.method_4();
			MonoSingleton<AsyncTaskManager>.Instance.method_1(waitServerSwitchAsyncTask, new TaskCompletedDelegate(this.OnServerSwitchCompleted));
		}

		// Token: 0x06001847 RID: 6215 RVA: 0x00081388 File Offset: 0x0007F588
		private void OnServerSwitchCompleted(AsyncTaskBase task, AsyncTaskStatus result)
		{
			if (result != AsyncTaskStatus.Success)
			{
				base.SetStatus(result);
				return;
			}
			if (PhotonNetwork.room != null)
			{
				PhotonNetwork.LeaveRoom();
			}
			PhotonNetwork.SetReceivingEnabled(1, false);
			PhotonNetwork.SetReceivingEnabled(2, false);
			PhotonNetwork.SetReceivingEnabled(3, false);
			try
			{
				DebugUtils.Log(LogCategory.Network, "JoinRoomAsyncTask.OnServerSwitchCompleted try to join room  [" + this.m_roomName + "]");
				PhotonNetwork.JoinRoom(this.m_roomName);
			}
			catch (Exception ex)
			{
				DebugUtils.LogError(LogCategory.Network, "JoinRoom Exception[" + ex + "]");
				base.SetStatus(AsyncTaskStatus.Error_JoinRoomFail);
			}
		}

		// Token: 0x06001848 RID: 6216 RVA: 0x00012144 File Offset: 0x00010344
		public override void OnJoinedRoom()
		{
			if (base.IsStatus())
			{
				return;
			}
			base.SetStatus(AsyncTaskStatus.Success);
		}

		// Token: 0x06001849 RID: 6217 RVA: 0x00012156 File Offset: 0x00010356
		public override void OnPhotonJoinRoomFailed()
		{
			if (base.IsStatus())
			{
				return;
			}
			base.SetStatus(AsyncTaskStatus.Error_JoinRoomFail);
		}

		// Token: 0x0600184A RID: 6218 RVA: 0x00012156 File Offset: 0x00010356
		public override void OnPhotonRandomJoinFailed()
		{
			if (base.IsStatus())
			{
				return;
			}
			base.SetStatus(AsyncTaskStatus.Error_JoinRoomFail);
		}

		// Token: 0x0600184B RID: 6219 RVA: 0x00012169 File Offset: 0x00010369
		public override void vmethod_0()
		{
			if (base.GetStatus() == AsyncTaskStatus.Error_Timeout)
			{
				PhotonNetwork.CancelJoin();
			}
			base.vmethod_0();
		}

		// Token: 0x04001065 RID: 4197
		public string m_roomName;
	}

	// Token: 0x020003BC RID: 956
	public class StartPvPMatchAsyncTask : PhotonNetworkTask
	{
		// Token: 0x0600184D RID: 6221 RVA: 0x00012193 File Offset: 0x00010393
		public void method_4(int int_1, GamemodeType gamemodeType_0)
		{
			this.m_instanceId = int_1;
			this.m_gamemode = gamemodeType_0;
			this.float_1 = 60f;
		}

		// Token: 0x0600184E RID: 6222 RVA: 0x00081420 File Offset: 0x0007F620
		public override void Start()
		{
			base.Start();
			NetworkManager.WaitServerSwitchAsyncTask waitServerSwitchAsyncTask = new NetworkManager.WaitServerSwitchAsyncTask();
			waitServerSwitchAsyncTask.method_4();
			MonoSingleton<AsyncTaskManager>.Instance.method_1(waitServerSwitchAsyncTask, new TaskCompletedDelegate(this.OnServerSwitchCompleted));
		}

		// Token: 0x0600184F RID: 6223 RVA: 0x00081458 File Offset: 0x0007F658
		private void OnServerSwitchCompleted(AsyncTaskBase task, AsyncTaskStatus result)
		{
			if (result != AsyncTaskStatus.Success)
			{
				base.SetStatus(result);
				return;
			}
			if (PhotonNetwork.room != null)
			{
				PhotonNetwork.LeaveRoom();
			}
			PhotonNetwork.SetReceivingEnabled(1, false);
			PhotonNetwork.SetReceivingEnabled(2, false);
			PhotonNetwork.SetReceivingEnabled(3, false);
			Dictionary<byte, object> dictionary = new Dictionary<byte, object>
			{
				{
					0,
					(int)this.m_gamemode
				},
				{ 1, this.m_instanceId }
			};
			PhotonNetwork.networkingPeer.OpCustom(127, dictionary, true);
		}

		// Token: 0x06001850 RID: 6224 RVA: 0x00012144 File Offset: 0x00010344
		public override void OnJoinedRoom()
		{
			if (base.IsStatus())
			{
				return;
			}
			base.SetStatus(AsyncTaskStatus.Success);
		}

		// Token: 0x06001851 RID: 6225 RVA: 0x00012156 File Offset: 0x00010356
		public override void OnPhotonJoinRoomFailed()
		{
			if (base.IsStatus())
			{
				return;
			}
			base.SetStatus(AsyncTaskStatus.Error_JoinRoomFail);
		}

		// Token: 0x06001852 RID: 6226 RVA: 0x00012156 File Offset: 0x00010356
		public override void OnPhotonRandomJoinFailed()
		{
			if (base.IsStatus())
			{
				return;
			}
			base.SetStatus(AsyncTaskStatus.Error_JoinRoomFail);
		}

		// Token: 0x04001066 RID: 4198
		public int m_instanceId;

		// Token: 0x04001067 RID: 4199
		private GamemodeType m_gamemode;
	}

	// Token: 0x020003BD RID: 957
	public class LeaveRoomAsyncTask : PhotonNetworkTask
	{
		// Token: 0x06001854 RID: 6228 RVA: 0x0000D358 File Offset: 0x0000B558
		public void method_4()
		{
			this.float_1 = 30f;
		}

		// Token: 0x06001855 RID: 6229 RVA: 0x000121AE File Offset: 0x000103AE
		public override void Start()
		{
			base.Start();
			if (PhotonNetwork.offlineMode)
			{
				base.SetStatus(AsyncTaskStatus.Success);
				return;
			}
			if (NetworkManager.smethod_4())
			{
				base.SetStatus(AsyncTaskStatus.Success);
				return;
			}
			if (PhotonNetwork.room == null)
			{
				base.SetStatus(AsyncTaskStatus.Success);
				return;
			}
			PhotonNetwork.LeaveRoom();
		}

		// Token: 0x06001856 RID: 6230 RVA: 0x00012144 File Offset: 0x00010344
		public override void OnLeftRoom()
		{
			if (base.IsStatus())
			{
				return;
			}
			base.SetStatus(AsyncTaskStatus.Success);
		}
	}

	// Token: 0x020003BE RID: 958
	public enum RequestStatus
	{
		// Token: 0x04001069 RID: 4201
		None,
		// Token: 0x0400106A RID: 4202
		Pending,
		// Token: 0x0400106B RID: 4203
		Succeed,
		// Token: 0x0400106C RID: 4204
		Failure
	}
}
