using System;
using Core;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x02000ACC RID: 2764
public class SessionInfo : MonoBehaviour, IPhotonView, IPhotonSerializeView
{
	// Token: 0x17000790 RID: 1936
	// (get) Token: 0x06004B1D RID: 19229 RVA: 0x000310A6 File Offset: 0x0002F2A6
	// (set) Token: 0x06004B1E RID: 19230 RVA: 0x000310AE File Offset: 0x0002F2AE
	public PhotonView photonView { get; set; }

	// Token: 0x17000791 RID: 1937
	// (get) Token: 0x06004B1F RID: 19231 RVA: 0x000310B7 File Offset: 0x0002F2B7
	public static SessionInfo SessionInfo_0
	{
		get
		{
			return SessionInfo.s_instance;
		}
	}

	// Token: 0x06004B20 RID: 19232 RVA: 0x000310BE File Offset: 0x0002F2BE
	private void Awake()
	{
		base.gameObject.transform.parent = MonoSingleton<AppManager>.Instance.transform;
		if (SessionInfo.s_instance != null)
		{
			DebugUtils.LogError(LogCategory.Gamelogic, "SessionInfo is already initialized");
		}
		SessionInfo.s_instance = this;
	}

	// Token: 0x06004B21 RID: 19233 RVA: 0x00137DB0 File Offset: 0x00135FB0
	public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.IsWriting)
		{
			stream.SendNext(MonoSingleton<Session>.Instance.method_1());
			stream.SendNext((byte)MonoSingleton<Session>.Instance.method_2());
			stream.SendNext(MonoSingleton<Session>.Instance.method_9());
			stream.SendNext(MonoSingleton<Session>.Instance.m_showTimerOnScreen);
			stream.SendNext(MonoSingleton<Session>.Instance.method_4());
			stream.SendNext(MonoSingleton<Session>.Instance.method_5());
			stream.SendNext(MonoSingleton<Session>.Instance.method_6());
			MonoSingleton<StatisticsManager>.Instance.GetCurrentSession().method_0(stream);
		}
		else
		{
			string text = (string)stream.ReceiveNext();
			ELevelDifficulty elevelDifficulty = (ELevelDifficulty)((byte)stream.ReceiveNext());
			MonoSingleton<Session>.Instance.method_10((double)stream.ReceiveNext());
			MonoSingleton<Session>.Instance.m_showTimerOnScreen = (bool)stream.ReceiveNext();
			byte b = (byte)stream.ReceiveNext();
			string text2 = (string)stream.ReceiveNext();
			string text3 = (string)stream.ReceiveNext();
			MonoSingleton<StatisticsManager>.Instance.GetCurrentSession().method_0(stream);
			MonoSingleton<Session>.Instance.method_22(text, elevelDifficulty);
			if (MonoSingleton<Session>.Instance.method_4() != b)
			{
				MonoSingleton<Session>.Instance.method_21(text2, text3);
			}
		}
	}

	// Token: 0x06004B22 RID: 19234 RVA: 0x000310F8 File Offset: 0x0002F2F8
	public void method_0()
	{
		this.photonView.method_4("RPC_RequestMapReady", PhotonTargets.MasterClient, new object[0]);
	}

	// Token: 0x06004B23 RID: 19235 RVA: 0x00031111 File Offset: 0x0002F311
	public void method_1()
	{
		this.photonView.method_4("RPC_RequestRespawnPlayer", PhotonTargets.MasterClient, new object[0]);
	}

	// Token: 0x06004B24 RID: 19236 RVA: 0x00137F00 File Offset: 0x00136100
	public void method_2(int int_0)
	{
		DebugUtils.Log(LogCategory.Gamelogic, "IamReadyForSession [" + int_0 + "]");
		object[] array = new object[] { int_0 };
		this.photonView.method_4("RPC_RequestPlayerReady", PhotonTargets.MasterClient, array);
	}

	// Token: 0x06004B25 RID: 19237 RVA: 0x00137F4C File Offset: 0x0013614C
	public void method_3(int int_0)
	{
		DebugUtils.Log(LogCategory.Gamelogic, "IamReadyForWrapup [" + int_0 + "]");
		object[] array = new object[] { int_0 };
		this.photonView.method_4("RPC_RequestPlayerWrapup", PhotonTargets.MasterClient, array);
	}

	// Token: 0x06004B26 RID: 19238 RVA: 0x0003112A File Offset: 0x0002F32A
	public void method_4()
	{
		this.photonView.method_4("RPC_RequestPlayerForGame", PhotonTargets.MasterClient, new object[0]);
	}

	// Token: 0x06004B27 RID: 19239 RVA: 0x00137F98 File Offset: 0x00136198
	[RPC]
	private void RPC_RequestPlayerReady(int characterId, PhotonMessageInfo info)
	{
		DebugUtils.Log(LogCategory.Gamelogic, "RPC_RequestPlayerReady [" + characterId + "]");
		PlayerInfoSync playerInfoSync = MonoSingleton<Session>.Instance.TryGetPlayerInfoSyncById(info.sender.ActorId);
		if (playerInfoSync != null)
		{
			playerInfoSync.m_characterId = characterId;
			MonoSingleton<Session>.Instance.method_24().imethod_5(playerInfoSync);
		}
	}

	// Token: 0x06004B28 RID: 19240 RVA: 0x00137FF8 File Offset: 0x001361F8
	[RPC]
	private void RPC_RequestPlayerWrapup(int characterId, PhotonMessageInfo info)
	{
		DebugUtils.Log(LogCategory.Gamelogic, "RPC_RequestPlayerWrapup [" + characterId + "]");
		PlayerInfoSync playerInfoSync = MonoSingleton<Session>.Instance.TryGetPlayerInfoSyncById(info.sender.ActorId);
		playerInfoSync.m_characterId = characterId;
		MonoSingleton<Session>.Instance.method_24().imethod_6(playerInfoSync);
	}

	// Token: 0x06004B29 RID: 19241 RVA: 0x00138050 File Offset: 0x00136250
	[RPC]
	private void RPC_RequestMapReady(PhotonMessageInfo info)
	{
		DebugUtils.Log(LogCategory.Gamelogic, "RPC_RequestMapReady " + info.sender + Time.realtimeSinceStartup);
		PlayerInfoSync playerInfoSync = MonoSingleton<Session>.Instance.TryGetPlayerInfoSyncById(info.sender.ActorId);
		MonoSingleton<Session>.Instance.method_24().imethod_7(playerInfoSync);
	}

	// Token: 0x06004B2A RID: 19242 RVA: 0x001380A4 File Offset: 0x001362A4
	[RPC]
	private void RPC_RequestPlayerForGame(PhotonMessageInfo info)
	{
		PlayerInfoSync playerInfoSync = MonoSingleton<Session>.Instance.TryGetPlayerInfoSyncById(info.sender.ActorId);
		MonoSingleton<Session>.Instance.method_24().imethod_8(playerInfoSync);
	}

	// Token: 0x06004B2B RID: 19243 RVA: 0x00031143 File Offset: 0x0002F343
	[RPC]
	private void RPC_SendSyncMissionTimer(bool isRunning, double start, double duration, double pause, PhotonMessageInfo info)
	{
		MonoSingleton<Session>.Instance.method_7().method_5(isRunning, start, duration, pause);
	}

	// Token: 0x06004B2C RID: 19244 RVA: 0x001380D8 File Offset: 0x001362D8
	[RPC]
	private void RPC_SendMissionTimerEvent(int eventType, double duration, PhotonMessageInfo info)
	{
		DebugUtils.Log(LogCategory.Gamelogic, string.Concat(new object[] { "RPC_SendMissionTimerEvent [", eventType, "][", duration, "]" }));
		HUDCountDownView hudcountDownView = MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDCountDownView>();
		if (hudcountDownView == null)
		{
			return;
		}
		switch (eventType)
		{
		case 0:
			hudcountDownView.vmethod_8((int)duration);
			break;
		case 1:
			hudcountDownView.vmethod_6();
			break;
		case 2:
			hudcountDownView.vmethod_7();
			break;
		}
	}

	// Token: 0x06004B2D RID: 19245 RVA: 0x00138164 File Offset: 0x00136364
	[RPC]
	private void RPC_RequestDisplayCountDown(float countdown, PhotonMessageInfo info)
	{
		DebugUtils.Log(LogCategory.Gamelogic, "RPC_RequestDisplayCountDown");
		PlayerInfoSync localPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer();
		if (localPlayer)
		{
			UIMessage uimessage = new UIMessage();
			uimessage.m_type = UIMessage.GEnum1.const_1;
			uimessage.m_text = string.Empty;
			uimessage.m_duration = countdown;
			uimessage.m_displayCountDown = true;
			MonoSingleton<global::ns0.EchoMessageManager>.Instance.method_2(uimessage);
		}
	}

	// Token: 0x06004B2E RID: 19246 RVA: 0x001381C0 File Offset: 0x001363C0
	[RPC]
	private void RPC_RequestDisplayUIMessage(bool displayCountDown, float decayDate, float duration, string text, byte type, PhotonMessageInfo info)
	{
		UIMessage uimessage = new UIMessage();
		uimessage.m_decayDate = decayDate;
		uimessage.m_displayCountDown = displayCountDown;
		uimessage.m_duration = duration;
		uimessage.m_type = (UIMessage.GEnum1)type;
		uimessage.m_text = text;
		DebugUtils.Log(LogCategory.Gamelogic, "RPC_RequestDisplayUIMessage - " + uimessage.m_text);
		PlayerInfoSync localPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer();
		if (localPlayer)
		{
			MonoSingleton<global::ns0.EchoMessageManager>.Instance.method_2(uimessage);
		}
	}

	// Token: 0x06004B2F RID: 19247 RVA: 0x0013822C File Offset: 0x0013642C
	[RPC]
	private void RPC_RequestDisplayEchoMessage(string echoMsgId, PhotonMessageInfo info)
	{
		PlayerInfoSync localPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer();
		if (localPlayer)
		{
			MonoSingleton<global::ns0.EchoMessageManager>.Instance.method_8(echoMsgId);
		}
	}

	// Token: 0x06004B30 RID: 19248 RVA: 0x00138258 File Offset: 0x00136458
	[RPC]
	private void RPC_RequestDisplayRandomEchoMessages(string[] echoMsgsId, PhotonMessageInfo info)
	{
		PlayerInfoSync localPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer();
		if (localPlayer && MonoSingleton<global::EchoMessageManager>.Instance != null)
		{
			MonoSingleton<global::EchoMessageManager>.Instance.method_1();
			for (int i = 0; i < echoMsgsId.Length; i++)
			{
				MonoSingleton<global::EchoMessageManager>.Instance.method_0(echoMsgsId[i]);
			}
		}
	}

	// Token: 0x06004B31 RID: 19249 RVA: 0x001382AC File Offset: 0x001364AC
	[RPC]
	private void RPC_RequestActivateDevice(string deviceName, PhotonMessageInfo info)
	{
		DebugUtils.Log(LogCategory.System, "SessionInfo.RPC_RequestActivateDevice");
		GameObject gameObject = GameObject.Find(deviceName);
		int childCount = gameObject.transform.childCount;
		for (int i = 0; i < childCount; i++)
		{
			gameObject.transform.GetChild(i).gameObject.SetActive(true);
		}
	}

	// Token: 0x06004B32 RID: 19250 RVA: 0x001382FC File Offset: 0x001364FC
	[RPC]
	private void RPC_RequestActivateCutscene(int cutsceneID, bool activate, PhotonMessageInfo info)
	{
		DebugUtils.Log(LogCategory.Gamelogic, string.Concat(new object[] { "SessionInfo.RPC_RequestActivateCutscene [", cutsceneID, "][", activate, "]" }));
		global::UnityEngine.Object[] array = global::UnityEngine.Object.FindObjectsOfType(typeof(CutsceneCluster));
		for (int i = 0; i < array.Length; i++)
		{
			CutsceneCluster cutsceneCluster = array[i] as CutsceneCluster;
			if (cutsceneCluster != null && cutsceneCluster.m_cutsceneId == cutsceneID && cutsceneCluster.m_cutscene != null)
			{
				if (activate)
				{
					MonoSingleton<Session>.Instance.method_41(cutsceneCluster.m_cutscene);
				}
				else
				{
					MonoSingleton<Session>.Instance.method_42(cutsceneCluster.m_cutscene);
				}
			}
		}
	}

	// Token: 0x06004B33 RID: 19251 RVA: 0x001383B0 File Offset: 0x001365B0
	[RPC]
	private void RPC_RequestSyncSessionStats(object[] sessionData, PhotonMessageInfo info)
	{
		DebugUtils.LogError(LogCategory.Gamelogic, "DIAG: RPC_RequestSyncSessionStats called, count=" + sessionData.Length.ToString());
		MonoSingleton<StatisticsManager>.Instance.method_3(sessionData);
	}

	// Token: 0x06004B34 RID: 19252 RVA: 0x00031159 File Offset: 0x0002F359
	[RPC]
	private void RPC_RequestSendSessionStats(object[] sessionData, PhotonMessageInfo info)
	{
		MonoSingleton<StatisticsManager>.Instance.method_4(sessionData);
		MonoSingleton<Session>.Instance.method_20();
	}

	// Token: 0x06004B35 RID: 19253 RVA: 0x001383E4 File Offset: 0x001365E4
	[RPC]
	private void RPC_RequestShakeCamera(int intensity)
	{
		PlayerInfoSync localPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer();
		if (localPlayer == null)
		{
			return;
		}
		EntityPlayer entityPlayer = localPlayer.GetEntity() as EntityPlayer;
		if (entityPlayer == null)
		{
			return;
		}
		BadAssFPSCamera badAssFPSCamera = entityPlayer.method_45();
		if (badAssFPSCamera == null)
		{
			return;
		}
		badAssFPSCamera.method_6((BadAssFPSCamera.ShakeType)intensity);
	}

	// Token: 0x06004B36 RID: 19254 RVA: 0x00138434 File Offset: 0x00136634
	[RPC]
	private void RPC_RequestSetPlayerActions(int actions)
	{
		PlayerInfoSync localPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer();
		if (localPlayer == null)
		{
			return;
		}
		Entity entity = localPlayer.GetEntity();
		if (entity == null)
		{
			return;
		}
		PlayerController component = entity.GetComponent<PlayerController>();
		if (component == null)
		{
			return;
		}
		component.method_2((PlayerAction)actions);
	}

	// Token: 0x06004B37 RID: 19255 RVA: 0x00138480 File Offset: 0x00136680
	[RPC]
	private void RPC_SendPlayerToTown()
	{
		PlayerInfoSync localPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer();
		if (localPlayer == null)
		{
			return;
		}
		MonoSingleton<GameFlowManager>.Instance.method_7();
	}

	// Token: 0x06004B38 RID: 19256 RVA: 0x001384AC File Offset: 0x001366AC
	[RPC]
	private void RPC_AddObjectiveToClient(string objectiveId, string titleId, string detailId)
	{
		PlayerInfoSync localPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer();
		if (localPlayer == null)
		{
			return;
		}
		ServiceWrapperBase<ObjectiveManager>.Instance.method_0(objectiveId, titleId, detailId);
	}

	// Token: 0x06004B39 RID: 19257 RVA: 0x001384DC File Offset: 0x001366DC
	[RPC]
	private void RPC_RemoveObjectiveFromClient(string objectiveId, bool isSuccess)
	{
		PlayerInfoSync localPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer();
		if (localPlayer == null)
		{
			return;
		}
		ServiceWrapperBase<ObjectiveManager>.Instance.method_1(objectiveId, isSuccess);
	}

	// Token: 0x06004B3A RID: 19258 RVA: 0x0000311B File Offset: 0x0000131B
	[RPC]
	private void RPC_RequestRespawnPlayer(PhotonMessageInfo info)
	{
	}

	// Token: 0x06004B3B RID: 19259 RVA: 0x00031170 File Offset: 0x0002F370
	[RPC]
	private void RPC_SendAllPlayersAreReady()
	{
		DebugUtils.Log(LogCategory.Gamelogic, "All Players are ready");
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDPvPInfoView>().vmethod_10(false);
	}

	// Token: 0x06004B3C RID: 19260 RVA: 0x0013850C File Offset: 0x0013670C
	[RPC]
	private void RPC_ShowRoundResultToClient(bool isFinalRound)
	{
		DebugUtils.LogError(LogCategory.Gamelogic, "DIAG: RPC_ShowRoundResultToClient called isFinalRound=" + isFinalRound.ToString());
		DebugUtils.Log(LogCategory.Gamelogic, "ShowRoundResult");
		MonoSingleton<ScoringManager>.Instance.method_5();
		MonoSingleton<InputManager>.Instance.method_1(false);
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDPvPInfoView>().vmethod_11();
	}

	// Token: 0x06004B3D RID: 19261 RVA: 0x00138564 File Offset: 0x00136764
	[RPC]
	private void RPC_CloseRoundResultToClient()
	{
		DebugUtils.LogError(LogCategory.Gamelogic, "DIAG: RPC_CloseRoundResultToClient called");
		DebugUtils.Log(LogCategory.Gamelogic, "CloseRoundResult");
		MonoSingleton<InputManager>.Instance.method_2(false);
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDPvPInfoView>().vmethod_12();
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDPvPInfoView>().method_6(-1);
	}

	// Token: 0x06004B3E RID: 19262 RVA: 0x001385BC File Offset: 0x001367BC
	[RPC]
	private void RPC_PlayCutscene(string cutsceneName)
	{
		DebugUtils.Log(LogCategory.Gamelogic, "RPC_PlayCutscene received: " + cutsceneName);
		global::UnityEngine.Object[] array = Resources.FindObjectsOfTypeAll(typeof(CutScene));
		DebugUtils.Log(LogCategory.Gamelogic, "RPC_PlayCutscene found " + array.Length.ToString() + " CutScene object(s)");
		for (int i = 0; i < array.Length; i++)
		{
			CutScene cutScene = array[i] as CutScene;
			if (cutScene != null)
			{
				DebugUtils.Log(LogCategory.Gamelogic, "RPC_PlayCutscene candidate: '" + cutScene.gameObject.name + "' active=" + cutScene.gameObject.activeSelf.ToString());
			}
			if (cutScene != null && cutScene.gameObject.name == cutsceneName && !cutScene.gameObject.activeSelf)
			{
				DebugUtils.Log(LogCategory.Gamelogic, "RPC_PlayCutscene MATCH (currently inactive = the real scene instance), activating");
				cutScene.gameObject.SetActive(true);
				cutScene.gameObject.name = cutsceneName + "_LIVE";
				Transform transform = cutScene.gameObject.transform.parent;
				while (transform != null)
				{
					if (!transform.gameObject.activeSelf)
					{
						DebugUtils.Log(LogCategory.Gamelogic, "RPC_PlayCutscene forcing ancestor active: " + transform.gameObject.name);
						transform.gameObject.SetActive(true);
					}
					transform = transform.parent;
				}
				DebugUtils.Log(LogCategory.Gamelogic, "RPC_PlayCutscene after SetActive(true): activeSelf=" + cutScene.gameObject.activeSelf.ToString() + " activeInHierarchy=" + cutScene.gameObject.activeInHierarchy.ToString());
				Camera camera_ = MonoSingleton<AppManager>.Instance.method_0().Camera_0;
				if (camera_ != null)
				{
					DebugUtils.Log(LogCategory.Gamelogic, "RPC_PlayCutscene disabling Camera_0: " + camera_.gameObject.name);
					camera_.gameObject.SetActive(false);
				}
				else
				{
					DebugUtils.Log(LogCategory.Gamelogic, "RPC_PlayCutscene Camera_0 is null");
				}
				MonoSingleton<AppManager>.Instance.method_0().vmethod_10(false);
				DebugUtils.Log(LogCategory.Gamelogic, "RPC_PlayCutscene vmethod_10(false) called (hide HUD)");
				return;
			}
		}
		DebugUtils.Log(LogCategory.Gamelogic, "RPC_PlayCutscene NO MATCH (inactive instance) for '" + cutsceneName + "'");
	}

	// Token: 0x06004B3F RID: 19263 RVA: 0x001387E4 File Offset: 0x001369E4
	[RPC]
	private void RPC_StopCutscene(string cutsceneName)
	{
		DebugUtils.Log(LogCategory.Gamelogic, "RPC_StopCutscene received: " + cutsceneName);
		global::UnityEngine.Object[] array = Resources.FindObjectsOfTypeAll(typeof(CutScene));
		string text = cutsceneName + "_LIVE";
		for (int i = 0; i < array.Length; i++)
		{
			CutScene cutScene = array[i] as CutScene;
			if (cutScene != null && cutScene.gameObject.name == text)
			{
				DebugUtils.Log(LogCategory.Gamelogic, "RPC_StopCutscene MATCH (marked live instance), deactivating");
				cutScene.gameObject.SetActive(false);
				cutScene.gameObject.name = cutsceneName;
				break;
			}
		}
		Camera camera_ = MonoSingleton<AppManager>.Instance.method_0().Camera_0;
		if (camera_ != null)
		{
			DebugUtils.Log(LogCategory.Gamelogic, "RPC_StopCutscene re-enabling Camera_0: " + camera_.gameObject.name);
			camera_.gameObject.SetActive(true);
		}
		else
		{
			DebugUtils.Log(LogCategory.Gamelogic, "RPC_StopCutscene Camera_0 is null");
		}
		MonoSingleton<AppManager>.Instance.method_0().vmethod_10(true);
		DebugUtils.Log(LogCategory.Gamelogic, "RPC_StopCutscene vmethod_10(true) called (show HUD)");
	}

	// Token: 0x0400369C RID: 13980
	private static SessionInfo s_instance;
}
