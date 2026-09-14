using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml.Serialization;
using Core;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x0200026C RID: 620
public class AppManager : MonoSingleton<AppManager>
{
	// Token: 0x1700007B RID: 123
	// (get) Token: 0x06000D07 RID: 3335 RVA: 0x0000C4B6 File Offset: 0x0000A6B6
	// (set) Token: 0x06000D08 RID: 3336 RVA: 0x0000C4BE File Offset: 0x0000A6BE
	public bool OnlineHostMinResMode { get; private set; }

	// Token: 0x1700007C RID: 124
	// (get) Token: 0x06000D09 RID: 3337 RVA: 0x0000C4C7 File Offset: 0x0000A6C7
	// (set) Token: 0x06000D0A RID: 3338 RVA: 0x0000C4CF File Offset: 0x0000A6CF
	public GlobalSettings m_globalSettings { get; private set; }

	// Token: 0x06000D0B RID: 3339 RVA: 0x0000C4D8 File Offset: 0x0000A6D8
	public GameUIManager method_0()
	{
		return this.m_gameUIMng;
	}

	// Token: 0x06000D0C RID: 3340 RVA: 0x0006DBDC File Offset: 0x0006BDDC
	protected override void Awake()
	{
		base.gameObject.AddComponent<ShandaWrapper>();
		this.m_enableSndaLogin = false;
		this.m_offlineMode = false;
		this.m_login = null;
		base.Awake();
		(global::UnityEngine.Object.Instantiate(ResourcesLoader.smethod_0("ProdUtils/FinalInfo")) as GameObject).transform.parent = base.gameObject.transform;
		Application.targetFrameRate = 60;
		string[] commandLineArgs = Environment.GetCommandLineArgs();
		foreach (string text in commandLineArgs)
		{
			if (text.Contains("-logfile:"))
			{
				string[] array2 = text.Split(new char[] { ':' });
				if (array2.Length > 1)
				{
					WebDebugManager.string_1 = array2[1];
				}
			}
		}
		base.gameObject.AddComponent<WebDebugManager>();
		TerminalLogger.InitIfRequested(commandLineArgs);
		this.method_4(commandLineArgs);
		base.gameObject.AddComponent<AssetBundleManager>();
		if (this.m_autoTestCase.Contains("stress"))
		{
			this.OnlineHostMinResMode = !this.m_offlineMode && SystemInfo.graphicsDeviceID == 0;
			BuildingKitManager.OnlineHostMinResMode = this.OnlineHostMinResMode;
		}
		else
		{
			this.OnlineHostMinResMode = false;
		}
		PhotonNetwork.offlineMode = this.m_offlineMode;
		global::UnityEngine.Object.DontDestroyOnLoad(base.transform.gameObject);
		this.method_2();
		base.StartCoroutine(this.method_3());
	}

	// Token: 0x06000D0D RID: 3341 RVA: 0x0000C4E0 File Offset: 0x0000A6E0
	private void OnDestroy()
	{
		DebugUtils.Log(LogCategory.Framework, "AppManager.OnDestroy");
		this.method_10();
		DiscordRpcHandler.Shutdown();
	}

	// Token: 0x06000D0E RID: 3342 RVA: 0x0000C4F8 File Offset: 0x0000A6F8
	public void method_1(bool bool_0)
	{
		if (this.m_defaultLoading == null)
		{
			return;
		}
		this.m_defaultLoading.SetActive(bool_0);
	}

	// Token: 0x06000D0F RID: 3343 RVA: 0x0006DD1C File Offset: 0x0006BF1C
	private void method_2()
	{
		this.m_defaultLoading = global::UnityEngine.Object.Instantiate(Resources.Load("PRO_DefaultLoading")) as GameObject;
		if (this.m_defaultLoading != null)
		{
			this.m_defaultLoading.transform.parent = base.transform;
			this.method_1(false);
		}
		TextAsset textAsset = (TextAsset)ResourcesLoader.smethod_0("Settings/GlobalSettings");
		using (StringReader stringReader = new StringReader(textAsset.text))
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(GlobalSettings));
			this.m_globalSettings = xmlSerializer.Deserialize(stringReader) as GlobalSettings;
		}
		Resources.UnloadAsset(textAsset);
		this.m_debugInfoManager = base.gameObject.AddComponent<DebugInfoManager>();
		base.gameObject.AddComponent<MecanimEventSetupHelper>();
		this.m_gameFlowMng = base.gameObject.AddComponent<GameFlowManager>();
		base.gameObject.AddComponent<MessageRelayManager>();
		base.gameObject.AddComponent<AsyncTaskManager>();
		base.gameObject.AddComponent<PlayerManager>();
		base.gameObject.AddComponent<InstantiateManager>();
		base.gameObject.AddComponent<EntityManager>();
		base.gameObject.AddComponent<LevelingManager>();
		base.gameObject.AddComponent<ScoringManager>();
		base.gameObject.AddComponent<StatisticsManager>();
		base.gameObject.AddComponent<GuildProgressionSetting>();
		base.gameObject.AddComponent<LadderProgressionSetting>();
		base.gameObject.AddComponent<AchievementSetting>();
		base.gameObject.AddComponent<InputManager>();
		if (!this.OnlineHostMinResMode)
		{
			base.gameObject.AddComponent<DebugCamera>();
			bool flag = false;
			string[] commandLineArgs = Environment.GetCommandLineArgs();
			for (int i = 0; i < commandLineArgs.Length; i++)
			{
				if (commandLineArgs[i].Contains("-debug"))
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				base.gameObject.AddComponent<PhotonStatsGui>();
				base.gameObject.AddComponent<PhotonLagSimulationGui>();
			}
			AudioManager.smethod_0();
			base.gameObject.AddComponent<BadAssLocalizion>();
			this.m_gameUIMng = base.gameObject.AddComponent<UniUIManager>();
			this.m_frontEndMgr = base.gameObject.AddComponent<FrontEndStepManager>();
			base.gameObject.AddComponent<global::ns0.EchoMessageManager>();
			base.gameObject.AddComponent<global::EchoMessageManager>();
			base.gameObject.AddComponent<GuidanceTipsManager>();
			this.m_gameUIMng.vmethod_0();
			base.gameObject.AddComponent<QualityManager>();
			base.gameObject.AddComponent<GraphicsMgr>().method_4();
			base.gameObject.AddComponent<GameSettingMgr>();
		}
		else
		{
			this.m_gameUIMng = base.gameObject.AddComponent<GameUIManager>();
			this.m_frontEndMgr = base.gameObject.AddComponent<FrontEndStepManager>();
			base.gameObject.AddComponent<global::ns0.EchoMessageManager>();
			this.m_gameUIMng.vmethod_0();
		}
		base.gameObject.AddComponent<AvatarGeneratorService>();
		base.gameObject.AddComponent<OnlineService>();
		base.gameObject.AddComponent<MatchmakingService>();
		base.gameObject.AddComponent<ItemGeneratorService>();
		base.gameObject.AddComponent<WeaponFactory>();
		base.gameObject.AddComponent<LevelLoadingManager>();
		if (!string.IsNullOrEmpty(this.m_autoTestCase))
		{
			base.gameObject.AddComponent<AutoTestManager>();
		}
		if (this.m_logGameProfile)
		{
			if (!global::UnityEngine.Debug.isDebugBuild)
			{
				DebugUtils.LogWarning(LogCategory.Framework, "ProfilerManager only work under development build");
			}
			this.m_profilerManager = new ProfilerManager();
			this.m_profilerManager.Start();
		}
		this.method_11();
		Application.backgroundLoadingPriority = ThreadPriority.Normal;
		if (this.m_useWrapperWindow)
		{
			this.method_20(1032);
		}
	}

	// Token: 0x06000D10 RID: 3344 RVA: 0x0006E064 File Offset: 0x0006C264
	private void Update()
	{
		if (this.m_logGameProfile)
		{
			this.m_profilerManager.Update();
		}
		if (!string.IsNullOrEmpty(this.m_autoTestCase))
		{
			this.m_isLoadingPageLoaded = true;
		}
		if (!this.m_isLoadingPageLoaded && Application.CanStreamedLevelBeLoaded("LoadingPage"))
		{
			MonoSingleton<GameFlowManager>.Instance.method_2();
			this.m_isLoadingPageLoaded = true;
		}
		if (!this.m_isReadyToLoadResources)
		{
			this.m_isReadyToLoadResources = Application.CanStreamedLevelBeLoaded("ResourcesLoading");
			if (MonoSingleton<AssetBundleManager>.Instance.Boolean_2 && !MonoSingleton<AssetBundleManager>.Instance.Boolean_1)
			{
				this.m_isReadyToLoadResources = false;
			}
			if (this.m_isReadyToLoadResources)
			{
				base.gameObject.AddComponent<WeaponGeneratorService>();
				if (!string.IsNullOrEmpty(this.m_autoTestCase))
				{
					AppManager.s_allowQuit = true;
					this.m_playlistId = AutoTestUtility.smethod_1(this.m_autoTestCase);
					AutoTestUtility.smethod_5();
					base.GetComponent<AutoTestManager>().method_1(this.m_autoTestCase);
				}
			}
		}
		if (this.m_shutdownTimer.method_7())
		{
			this.method_10();
		}
		this.accum += Time.timeScale / Time.deltaTime;
		this.frames++;
		WindowsDLLHandler.smethod_1(out this.m_memCur, out this.m_memPeak);
		if (PhotonNetwork.isMasterClient && DebugUtils.s_debugInfoSync != null)
		{
			bool enabled = DebugUtils.s_debugInfoSync.m_enabled;
		}
		bool flag = false;
		string[] commandLineArgs = Environment.GetCommandLineArgs();
		for (int i = 0; i < commandLineArgs.Length; i++)
		{
			if (commandLineArgs[i].Contains("-debug"))
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			if (Input.GetKeyDown(KeyCode.F6))
			{
				AIServiceUtility.AIServiceUtility_0.m_bShowNpcHP = !AIServiceUtility.AIServiceUtility_0.m_bShowNpcHP;
			}
			if (Input.GetKeyDown(KeyCode.F8))
			{
				GameObject gameObject = GameObject.Find("DebugNpcCollisionMarkers");
				EntityNpc[] array = global::UnityEngine.Object.FindObjectsOfType<EntityNpc>();
				if (gameObject != null)
				{
					global::UnityEngine.Object.Destroy(gameObject);
					EntityNpc[] array2 = array;
					for (int j = 0; j < array2.Length; j++)
					{
						Transform transform = array2[j].transform.Find("NpcCollisionMarker");
						if (transform != null)
						{
							global::UnityEngine.Object.Destroy(transform.gameObject);
						}
					}
				}
				else
				{
					new GameObject("DebugNpcCollisionMarkers");
					EntityNpc[] array3 = array;
					for (int k = 0; k < array3.Length; k++)
					{
						CapsuleCollider componentInChildren = array3[k].GetComponentInChildren<CapsuleCollider>();
						if (!(componentInChildren == null))
						{
							GameObject gameObject2 = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
							gameObject2.name = "NpcCollisionMarker";
							gameObject2.transform.parent = componentInChildren.transform;
							gameObject2.transform.localPosition = componentInChildren.center;
							if (componentInChildren.direction == 0)
							{
								gameObject2.transform.localRotation = Quaternion.Euler(0f, 0f, 90f);
							}
							else if (componentInChildren.direction == 2)
							{
								gameObject2.transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
							}
							else
							{
								gameObject2.transform.localRotation = Quaternion.identity;
							}
							gameObject2.transform.localScale = new Vector3(componentInChildren.radius * 2f, componentInChildren.height * 0.5f, componentInChildren.radius * 2f);
							EntityNpc[] array4 = array;
							for (int l = 0; l < array4.Length; l++)
							{
								CapsuleCollider componentInChildren2 = array4[l].GetComponentInChildren<CapsuleCollider>();
								if (!(componentInChildren2 == null))
								{
									Transform transform2 = componentInChildren2.transform.Find("NpcCollisionMarker");
									if (transform2 != null)
									{
										global::UnityEngine.Object.Destroy(transform2.gameObject);
									}
								}
							}
						}
					}
				}
			}
			if (Input.GetKeyDown(KeyCode.F7))
			{
				GameObject gameObject3 = GameObject.Find("DebugPlayerPosMarker");
				if (gameObject3 != null)
				{
					global::UnityEngine.Object.Destroy(gameObject3);
				}
				else
				{
					GameObject gameObject4 = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
					gameObject4.name = "DebugPlayerPosMarker";
					gameObject4.transform.localScale = new Vector3(0.3f, 50f, 0.3f);
					Collider component = gameObject4.GetComponent<Collider>();
					if (component != null)
					{
						global::UnityEngine.Object.Destroy(component);
					}
					Renderer component2 = gameObject4.GetComponent<Renderer>();
					if (component2 != null)
					{
						Shader shader = Shader.Find("Unlit/Color");
						if (shader != null)
						{
							component2.material.shader = shader;
						}
						component2.material.color = Color.magenta;
					}
				}
			}
			GameObject gameObject5 = GameObject.Find("DebugPlayerPosMarker");
			if (gameObject5 != null && MonoSingleton<Session>.Instance != null && MonoSingleton<Session>.Instance.GetLocalPlayer() != null)
			{
				EntityPlayer entityPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer().GetEntity() as EntityPlayer;
				if (entityPlayer != null)
				{
					MovementSync component3 = entityPlayer.GetComponent<MovementSync>();
					if (component3 != null)
					{
						FieldInfo field = typeof(MovementSync).GetField("correctPlayerPos", BindingFlags.Instance | BindingFlags.NonPublic);
						if (field != null)
						{
							Vector3 vector = (Vector3)field.GetValue(component3);
							gameObject5.transform.position = vector + Vector3.up * 50f;
						}
					}
				}
			}
			GameObject gameObject6 = GameObject.Find("DebugPlayerPosMarker");
			if (gameObject6 != null && MonoSingleton<Session>.Instance != null && MonoSingleton<Session>.Instance.GetLocalPlayer() != null)
			{
				EntityPlayer entityPlayer2 = MonoSingleton<Session>.Instance.GetLocalPlayer().GetEntity() as EntityPlayer;
				if (entityPlayer2 != null)
				{
					gameObject6.transform.position = entityPlayer2.transform.position + Vector3.up * 50f;
				}
			}
		}
		string text = "in the menu";
		if (ServiceWrapperBase<CharacterServiceWrapper>.Instance != null)
		{
			try
			{
				text = "Level " + ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_8().ToString();
			}
			catch (Exception)
			{
			}
		}
		string text2;
		try
		{
			text2 = LocalizedString.smethod_0(new LocalizedString((this.m_playlistId != -1) ? ("Instance_" + this.m_playlistId.ToString()) : "Instance_28"));
		}
		catch (Exception)
		{
			text2 = Application.loadedLevelName;
		}
		DiscordRpcHandler.RunCallbacks();
		DiscordRpcHandler.UpdatePresence(text, text2, "logo", "Borderlands Online");
	}

	// Token: 0x06000D11 RID: 3345 RVA: 0x0006E68C File Offset: 0x0006C88C
	private IEnumerator method_3()
	{
		while (true)
		{
			m_fps = accum / (float)frames;
			accum = 0f;
			frames = 0;
			yield return new WaitForSeconds(frequency);
		}
	}
	// Token: 0x06000D12 RID: 3346 RVA: 0x0006E6A8 File Offset: 0x0006C8A8
	private void method_4(string[] string_0)
	{
		this.m_language = "INT";
		this.m_offlineMode = false;
		this.m_usePlaylistId = false;
		if (string_0 != null)
		{
			foreach (string text in string_0)
			{
				DebugUtils.Log(LogCategory.Framework, "Load Parameters: " + text);
				if (text.Contains("-server:"))
				{
					string[] array = text.Split(new char[] { ':' });
					if (array.Length > 1)
					{
						DebugUtils.Log(LogCategory.Framework, "-server:" + array[1]);
						this.m_serverEnvironment = OnlineService.ServerFrameWorkEnv.Custom;
						this.m_serverIP = array[1];
					}
				}
				else if (text.Contains("-playlist:"))
				{
					string[] array2 = text.Split(new char[] { ':' });
					if (array2.Length > 1)
					{
						DebugUtils.Log(LogCategory.Framework, "-playlist:" + array2[1]);
						this.m_playlistId = Convert.ToInt32(array2[1]);
						this.m_usePlaylistId = true;
					}
				}
				else if (text.Contains("-privatecode:"))
				{
					string[] array3 = text.Split(new char[] { ':' });
					if (array3.Length > 1)
					{
						DebugUtils.Log(LogCategory.Framework, "-privatecode:" + array3[1]);
						this.m_privateSessionName = array3[1];
					}
				}
				else if (text.Contains("-usecache"))
				{
					DebugUtils.Log(LogCategory.Framework, "-usecache");
				}
				else if (text.Contains("-profilelog"))
				{
					DebugUtils.Log(LogCategory.Framework, "-profilelog");
					this.m_logGameProfile = true;
				}
				else if (text.Contains("-autotest:"))
				{
					string[] array4 = text.Split(new char[] { ':' });
					if (array4.Length > 1)
					{
						DebugUtils.Log(LogCategory.Framework, "-autotest:" + array4[1]);
						this.m_autoTestCase = array4[1];
						this.m_usePlaylistId = true;
					}
				}
				else if (text.Contains("-levelledmatchmaking:"))
				{
					string[] array5 = text.Split(new char[] { ':' });
					if (array5.Length > 1)
					{
						DebugUtils.Log(LogCategory.Framework, "-levelledmatchmaking:" + array5[1]);
						this.m_disableLevelledMatchmaking = !Convert.ToBoolean(array5[1]);
					}
				}
				else if (text.Contains("-language:"))
				{
					string[] array6 = text.Split(new char[] { ':' });
					if (array6.Length > 1)
					{
						DebugUtils.Log(LogCategory.Framework, "-language:" + array6[1]);
						this.m_language = array6[1];
					}
				}
				else if (text.Contains("-difficulty:"))
				{
					string[] array7 = text.Split(new char[] { ':' });
					if (array7.Length > 1)
					{
						DebugUtils.Log(LogCategory.Framework, "-difficulty:" + array7[1]);
						int num;
						if (int.TryParse(array7[1], out num))
						{
							this.m_difficulty = (ELevelDifficulty)num;
						}
						else
						{
							this.m_difficulty = (ELevelDifficulty)((int)Enum.Parse(typeof(ELevelDifficulty), array7[1]));
						}
					}
				}
				else if (text.Contains("-gameservername:"))
				{
					string[] array8 = text.Split(new char[] { ':' });
					if (array8.Length > 1)
					{
						DebugUtils.Log(LogCategory.Framework, text);
						this.m_gameServerName = array8[1];
					}
				}
				else if (text.Contains("-statdb"))
				{
					string[] array9 = text.Split(new char[] { ':' });
					if (array9.Length > 1)
					{
						DebugUtils.Log(LogCategory.Framework, text);
						this.m_statsDBAddress = array9[1];
					}
				}
				else if (text.Contains("-skiptutorial"))
				{
					DebugUtils.Log(LogCategory.Framework, "-skiptutorial");
					this.m_skipTutorial = true;
				}
				else if (text.Contains("-sndalogin"))
				{
					DebugUtils.Log(LogCategory.Framework, text);
					this.m_enableSndaLogin = true;
				}
				else if (text.Contains("-login:"))
				{
					string[] array10 = text.Split(new char[] { ':' });
					if (array10.Length > 1)
					{
						DebugUtils.Log(LogCategory.Framework, "-login:" + array10[1]);
						this.m_login = array10[1];
					}
				}
				else if (text.Contains("-version:"))
				{
					string[] array11 = text.Split(new char[] { ':' });
					if (array11.Length > 1)
					{
						DebugUtils.Log(LogCategory.Framework, "-version:" + array11[1]);
						this.m_debugInfo_Version = array11[1];
					}
				}
				else if (text.Contains("-areaid:"))
				{
					string[] array12 = text.Split(new char[] { ':' });
					if (array12.Length > 1)
					{
						DebugUtils.Log(LogCategory.Framework, "-areaid:" + array12[1]);
						int num2;
						if (int.TryParse(array12[1], out num2))
						{
							ShandaWrapper.AreaID = num2;
						}
					}
				}
				else if (text.Contains("-groupid:"))
				{
					string[] array13 = text.Split(new char[] { ':' });
					if (array13.Length > 1)
					{
						DebugUtils.Log(LogCategory.Framework, "-groupid:" + array13[1]);
						int num3;
						if (int.TryParse(array13[1], out num3))
						{
							ShandaWrapper.GroupId = num3;
						}
					}
				}
				else if (text.Contains("-usereboot"))
				{
					DebugUtils.Log(LogCategory.Framework, "-usereboot");
					this.m_useReboot = true;
				}
				else if (text.Contains("-rebooted:"))
				{
					string[] array14 = text.Split(new char[] { ':' });
					if (array14.Length > 1)
					{
						DebugUtils.Log(LogCategory.Framework, "-rebooted:" + array14[1]);
						int num4;
						if (int.TryParse(array14[1], out num4))
						{
							this.m_isRebooted = true;
							this.m_rebootedCharacterId = num4;
						}
					}
				}
				else if (text.Contains("-parentHandle"))
				{
					string[] array15 = text.Split(new char[] { ':' });
					if (array15.Length > 1)
					{
						this.m_parentHWND = (IntPtr)Convert.ToInt32(array15[1]);
						if (this.m_parentHWND != IntPtr.Zero)
						{
							this.m_useWrapperWindow = true;
						}
					}
				}
				else if (text.Contains("-nosound"))
				{
					this.m_nosound = true;
				}
				else if (text.Contains("-noimpact"))
				{
					this.m_noimpact = true;
				}
			}
		}
	}

	// Token: 0x06000D13 RID: 3347 RVA: 0x0006ECC0 File Offset: 0x0006CEC0
	private void OnApplicationQuit()
	{
		if (!AppManager.s_allowQuit)
		{
			Application.CancelQuit();
			this.method_0().vmethod_5<HUDWarningView>().vmethod_7(LocalizedString.smethod_0(new LocalizedString("LeaveConfirmation")), new Delegate_EventProc(this.method_5), new Delegate_EventProc(this.method_6));
		}
		else
		{
			NetworkManager.DisconnectAsyncTask disconnectAsyncTask = new NetworkManager.DisconnectAsyncTask();
			disconnectAsyncTask.method_5();
			MonoSingleton<AsyncTaskManager>.Instance.method_1(disconnectAsyncTask, null);
		}
	}

	// Token: 0x06000D14 RID: 3348 RVA: 0x0000C515 File Offset: 0x0000A715
	private void method_5()
	{
		AppManager.s_allowQuit = true;
		Application.Quit();
	}

	// Token: 0x06000D15 RID: 3349 RVA: 0x0000311B File Offset: 0x0000131B
	private void method_6()
	{
	}

	// Token: 0x06000D16 RID: 3350 RVA: 0x0006ED2C File Offset: 0x0006CF2C
	public void method_7()
	{
		NetworkManager.DisconnectAsyncTask disconnectAsyncTask = new NetworkManager.DisconnectAsyncTask();
		disconnectAsyncTask.method_5();
		MonoSingleton<AsyncTaskManager>.Instance.method_1(disconnectAsyncTask, null);
		string text = Environment.GetCommandLineArgs()[0];
		string text2 = Environment.CommandLine + " ";
		if (text2.IndexOf("-usereboot") < 0)
		{
			text2 += " -usereboot";
		}
		if (text2.IndexOf("-rebooted:") >= 0)
		{
			int num = text2.IndexOf("-rebooted:");
			int num2 = text2.IndexOf(" ", num + 1);
			text2 = (text2.Substring(0, num).Trim() + text2.Substring(num2, text2.Length - num2)).Trim();
		}
		text2 = text2 + " -rebooted:" + OnlineService.s_characterId;
		if (text2.IndexOf("-login:") >= 0)
		{
			int num3 = text2.IndexOf("-login:");
			int num4 = text2.IndexOf(" ", num3 + 1);
			text2 = (text2.Substring(0, num3).Trim() + text2.Substring(num4, text2.Length - num4)).Trim();
		}
		text2 = text2 + " -login:" + this.m_login;
		if (text2.Contains("-parameterstart"))
		{
			text2 = text2.Substring(text2.IndexOf("-parameterstart"));
		}
		else
		{
			text2 = "-parameterstart " + text2;
		}
		DebugUtils.Log(LogCategory.System, string.Concat(new string[] { "Reboot [", text, "][", text2, "]" }));
		if (!this.m_useWrapperWindow)
		{
			Process.Start(text, text2);
		}
		else
		{
			this.method_24(5, text2);
			this.method_21(1030);
		}
		Process.GetCurrentProcess().Kill();
	}

	// Token: 0x06000D17 RID: 3351 RVA: 0x0006EEE4 File Offset: 0x0006D0E4
	public void method_8()
	{
		DebugUtils.Log(LogCategory.Framework, "AppManager.QuitApp");
		NetworkManager.DisconnectAsyncTask disconnectAsyncTask = new NetworkManager.DisconnectAsyncTask();
		disconnectAsyncTask.method_5();
		MonoSingleton<AsyncTaskManager>.Instance.method_1(disconnectAsyncTask, null);
		if (!this.m_shutdownTimer.method_6())
		{
			this.m_shutdownTimer.Start(2f);
		}
	}

	// Token: 0x06000D18 RID: 3352 RVA: 0x0000C522 File Offset: 0x0000A722
	public bool method_9()
	{
		return this.m_shutdownTimer.method_6();
	}

	// Token: 0x06000D19 RID: 3353 RVA: 0x0006EF34 File Offset: 0x0006D134
	private void method_10()
	{
		DebugUtils.Log(LogCategory.Framework, "AppManager.Shutdown");
		if (this.m_useWrapperWindow)
		{
			this.method_21(1031);
		}
		if (this.m_autoTestCase.Contains("stress"))
		{
			DebugUtils.Log(LogCategory.Framework, "AppManager.System.Diagnostics.Process.GetCurrentProcess().Kill()");
			Process.GetCurrentProcess().Kill();
		}
		else
		{
			AppManager.s_allowQuit = true;
			Application.Quit();
		}
		DebugUtils.Log(LogCategory.Framework, "Application.Quit()");
		if (this.m_profilerManager != null)
		{
			this.m_profilerManager.OnDestroy();
		}
	}

	// Token: 0x06000D1A RID: 3354 RVA: 0x0006EFB4 File Offset: 0x0006D1B4
	private void OnGUI()
	{
		if (this.m_style == null)
		{
			this.m_style = new GUIStyle(GUI.skin.label);
		}
		GUILayout.BeginArea(new Rect(0f, 2f, (float)(Screen.width - 10), (float)(Screen.width - 100)));
		this.m_style.normal.textColor = Color.white;
		this.m_style.alignment = TextAnchor.LowerRight;
		if (!string.IsNullOrEmpty(this.m_debugInfo_Version))
		{
			GUILayout.Label(this.m_displayedVersionId.ToString(), this.m_style, new GUILayoutOption[0]);
		}
		if (!string.IsNullOrEmpty(OnlineService.s_serverVersionId))
		{
			GUILayout.Label(OnlineService.s_serverVersionId, this.m_style, new GUILayoutOption[0]);
		}
		GUILayout.EndArea();
		bool flag = false;
		string[] commandLineArgs = Environment.GetCommandLineArgs();
		for (int i = 0; i < commandLineArgs.Length; i++)
		{
			if (commandLineArgs[i].Contains("-debug"))
			{
				flag = true;
				break;
			}
		}
		if (flag && Input.GetKey(KeyCode.F5))
		{
			if (MonoSingleton<GraphicsMgr>.Instance != null)
			{
				MonoSingleton<GraphicsMgr>.Instance.method_14();
			}
			if (MonoSingleton<DebugCamera>.Instance != null)
			{
				MonoSingleton<DebugCamera>.Instance.method_8();
			}
		}
	}

	// Token: 0x06000D1B RID: 3355 RVA: 0x0006F0DC File Offset: 0x0006D2DC
	private void method_11()
	{
		this.m_displayedVersionId.Append(AppManager.CONFIGURATION_PREFIX);
		TextAsset textAsset = (TextAsset)ResourcesLoader.smethod_1("VersionInfo", typeof(TextAsset));
		if (null == textAsset)
		{
			DebugUtils.LogWarning(LogCategory.Framework, "Couldn't find VersionInfo.txt resource");
		}
		else
		{
			using (StringReader stringReader = new StringReader(textAsset.text))
			{
				string text = stringReader.ReadLine();
				if (string.IsNullOrEmpty(text))
				{
					DebugUtils.LogWarning(LogCategory.Framework, "Couldn't find valid version info - this is OK for local builds");
				}
				else
				{
					this.m_debugInfo_Version = text;
				}
			}
		}
		if (!string.IsNullOrEmpty(this.m_debugInfo_Version))
		{
			this.m_displayedVersionId.Append(this.m_debugInfo_Version);
		}
		MethodInfo method = base.GetType().GetMethod("ReadVersionInfo", BindingFlags.Instance | BindingFlags.NonPublic);
		if (method != null)
		{
			DebugUtils.Log(LogCategory.Framework, "This version appears to not be obfuscated");
		}
		else
		{
			DebugUtils.Log(LogCategory.Framework, "This version appears to be obfuscated");
			this.m_displayedVersionId.Append(AppManager.OBFUSCATION_SUFFIX);
		}
		this.m_debugInfoManager.String_0 = this.m_debugInfo_Version;
		DebugUtils.Log(LogCategory.Framework, "Read version info: " + this.m_debugInfo_Version);
	}

	// Token: 0x06000D1C RID: 3356 RVA: 0x0006F1FC File Offset: 0x0006D3FC
	public void method_12(bool bool_0)
	{
		float time = Time.time;
		if (time - this.m_lastTimeRleaseMemory > 3f)
		{
			this.m_lastTimeRleaseMemory = time;
			DebugUtils.Log(LogCategory.Framework, "AppManager ReleaseMemory - " + Time.time);
			Pickable.LightPillarManager.LightPillarManager_0.method_0();
			MonoSingleton<AssetBundleManager>.Instance.method_15(false);
			if (!bool_0)
			{
				BuildingKitGenerator.smethod_0();
				BuildingKitLoader.smethod_2();
			}
			if (ComponentMonoSingleton<AudioSystem>.Boolean_0)
			{
				ComponentMonoSingleton<AudioSystem>.Instance.imethod_4();
			}
			Resources.UnloadUnusedAssets();
			DebugUtils.Log(LogCategory.Framework, "System.GC.Collect");
			GC.Collect();
		}
		DebugUtils.Log(LogCategory.Framework, "AppManager ReleaseMemory Done- " + Time.time);
	}

	// Token: 0x06000D1D RID: 3357 RVA: 0x0006F2A4 File Offset: 0x0006D4A4
	public void method_13(bool bool_0 = false)
	{
		if (MonoSingleton<DNAPortrait>.Instance != null)
		{
			MonoSingleton<DNAPortrait>.Instance.method_0();
		}
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, BaseAssetBundle> keyValuePair in MonoSingleton<AssetBundleManager>.Instance.Dictionary_0)
		{
			if (keyValuePair.Key.StartsWith("uniswf_"))
			{
				list.Add(keyValuePair.Key);
			}
		}
		for (int i = 0; i < list.Count; i++)
		{
			MonoSingleton<AssetBundleManager>.Instance.method_14(list[i], bool_0);
		}
		MonoSingleton<UniResourceManager>.Instance.method_10();
		foreach (Material material in global::UnityEngine.Object.FindObjectsOfType(typeof(Material)))
		{
			if ((material.name == "Transparent/DiffuseDoubeSided" || material.name.ToLower().Contains(".swf_")) && material.mainTexture == null)
			{
				global::UnityEngine.Object.Destroy(material);
			}
		}
	}

	// Token: 0x06000D1E RID: 3358 RVA: 0x0000C52F File Offset: 0x0000A72F
	public FrontEndStepManager.StepState method_14()
	{
		return this.m_frontEndMgr.StepState_0;
	}

	// Token: 0x06000D1F RID: 3359 RVA: 0x0000C53C File Offset: 0x0000A73C
	public DNACreateBehaviour method_15()
	{
		return this.m_dnaCreateBehaviour;
	}

	// Token: 0x06000D20 RID: 3360 RVA: 0x0000C544 File Offset: 0x0000A744
	public void method_16(DNACreateBehaviour dnacreateBehaviour_0)
	{
		this.m_dnaCreateBehaviour = dnacreateBehaviour_0;
	}

	// Token: 0x06000D21 RID: 3361 RVA: 0x0000C54D File Offset: 0x0000A74D
	public void method_17()
	{
		this.m_dnaCreateBehaviour = null;
	}

	// Token: 0x06000D22 RID: 3362 RVA: 0x0006F3D0 File Offset: 0x0006D5D0
	private static bool smethod_0()
	{
		OperatingSystem osversion = Environment.OSVersion;
		return osversion.Platform == PlatformID.Win32NT && osversion.Version.Major == 5 && osversion.Version.Minor == 1;
	}

	// Token: 0x06000D23 RID: 3363 RVA: 0x0006F410 File Offset: 0x0006D610
	public bool method_18()
	{
		if (!this.m_useReboot)
		{
			return false;
		}
		ulong num = WindowsDLLHandler.smethod_0();
		return num < 209715200UL || (AppManager.smethod_0() && (ulong)this.m_memCur > 1288490189UL);
	}

	// Token: 0x06000D24 RID: 3364
	[DllImport("user32.dll")]
	private static extern int SendMessage(IntPtr intptr_0, int int_0, int int_1, ref AppManager.COPYDATASTRUCT copydatastruct_0);

	// Token: 0x06000D25 RID: 3365
	[DllImport("user32.dll", EntryPoint = "SendMessage")]
	private static extern int SendMessage_1(IntPtr intptr_0, int int_0, IntPtr intptr_1, IntPtr intptr_2);

	// Token: 0x06000D26 RID: 3366
	[DllImport("user32.dll")]
	private static extern IntPtr FindWindow(string string_0, string string_1);

	// Token: 0x06000D27 RID: 3367
	[DllImport("user32.dll")]
	internal static extern bool EnumChildWindows(IntPtr intptr_0, AppManager.WindowEnumProc windowEnumProc_0, IntPtr intptr_1);

	// Token: 0x06000D28 RID: 3368
	[DllImport("user32.dll")]
	private static extern bool PostMessage(IntPtr intptr_0, int int_0, IntPtr intptr_1, IntPtr intptr_2);

	// Token: 0x06000D29 RID: 3369
	[DllImport("user32.dll")]
	private static extern IntPtr SetFocus(IntPtr intptr_0);

	// Token: 0x06000D2A RID: 3370 RVA: 0x0000C556 File Offset: 0x0000A756
	public IntPtr method_19()
	{
		if (this.m_HWND == IntPtr.Zero)
		{
			this.m_HWND = AppManager.FindWindow(null, "Borderlands Online");
		}
		return this.m_HWND;
	}

	// Token: 0x06000D2B RID: 3371 RVA: 0x0000C581 File Offset: 0x0000A781
	public void method_20(int int_0)
	{
		this.method_22(int_0, IntPtr.Zero, IntPtr.Zero);
	}

	// Token: 0x06000D2C RID: 3372 RVA: 0x0000C594 File Offset: 0x0000A794
	public void method_21(int int_0)
	{
		this.method_23(int_0, IntPtr.Zero, IntPtr.Zero);
	}

	// Token: 0x06000D2D RID: 3373 RVA: 0x0000C5A7 File Offset: 0x0000A7A7
	public void method_22(int int_0, IntPtr intptr_0, IntPtr intptr_1)
	{
		AppManager.SendMessage_1(this.m_parentHWND, int_0, intptr_0, intptr_1);
	}

	// Token: 0x06000D2E RID: 3374 RVA: 0x0000C5B8 File Offset: 0x0000A7B8
	public void method_23(int int_0, IntPtr intptr_0, IntPtr intptr_1)
	{
		AppManager.PostMessage(this.m_parentHWND, int_0, intptr_0, intptr_1);
	}

	// Token: 0x06000D2F RID: 3375 RVA: 0x0006F458 File Offset: 0x0006D658
	public void method_24(int int_0, string string_0)
	{
		byte[] bytes = Encoding.Default.GetBytes(string_0);
		int num = bytes.Length;
		AppManager.COPYDATASTRUCT copydatastruct;
		copydatastruct.dwData = (IntPtr)100;
		copydatastruct.lpData = string_0;
		copydatastruct.cData = num + 1;
		AppManager.SendMessage(this.m_parentHWND, 74, int_0, ref copydatastruct);
	}

	// Token: 0x04000BBB RID: 3003
	public const string APP_NAME = "Borderlands Online";

	// Token: 0x04000BBC RID: 3004
	public const int WM_COPYDATA = 74;

	// Token: 0x04000BBD RID: 3005
	public const int WM_ACTIVATE = 6;

	// Token: 0x04000BBE RID: 3006
	public const int WA_ACTIVE = 1;

	// Token: 0x04000BBF RID: 3007
	public const int WM_USER = 1024;

	// Token: 0x04000BC0 RID: 3008
	public const int WM_RESOLUTION = 1029;

	// Token: 0x04000BC1 RID: 3009
	public const int WM_REBOOT = 1030;

	// Token: 0x04000BC2 RID: 3010
	public const int WM_CLOSE = 1031;

	// Token: 0x04000BC3 RID: 3011
	public const int WM_OPENIME = 1032;

	// Token: 0x04000BC4 RID: 3012
	public const int WA_REBOOTPARAMETERS = 5;

	// Token: 0x04000BC5 RID: 3013
	public const int WA_FULLSCREEN = 1;

	// Token: 0x04000BC6 RID: 3014
	public const int WA_NOTFULLSCREEN = 0;

	// Token: 0x04000BC7 RID: 3015
	private const string PARAMETERSTART = "-parameterstart";

	// Token: 0x04000BC8 RID: 3016
	private const ulong MAX_MEMLIMIT_FORCLIENT = 1288490189UL;

	// Token: 0x04000BC9 RID: 3017
	private const ulong MIN_FREEMEM_FORCLIENT = 209715200UL;

	// Token: 0x04000BCA RID: 3018
	public IntPtr m_parentHWND = IntPtr.Zero;

	// Token: 0x04000BCB RID: 3019
	public bool m_useWrapperWindow;

	// Token: 0x04000BCC RID: 3020
	public IntPtr m_HWND = IntPtr.Zero;

	// Token: 0x04000BCD RID: 3021
	public string m_autoTestCase = string.Empty;

	// Token: 0x04000BCE RID: 3022
	[HideInInspector]
	public bool m_offlineMode;

	// Token: 0x04000BCF RID: 3023
	public string m_level;

	// Token: 0x04000BD0 RID: 3024
	[HideInInspector]
	public global::UnityEngine.Object m_levelObject;

	// Token: 0x04000BD1 RID: 3025
	public string m_gameType = "GamemodePvE";

	// Token: 0x04000BD2 RID: 3026
	public string m_privateSessionName;

	// Token: 0x04000BD3 RID: 3027
	public ELevelDifficulty m_difficulty;

	// Token: 0x04000BD4 RID: 3028
	public OnlineService.ServerFrameWorkEnv m_serverEnvironment = OnlineService.ServerFrameWorkEnv.Dev;

	// Token: 0x04000BD5 RID: 3029
	public bool m_logNetworkProfile;

	// Token: 0x04000BD6 RID: 3030
	public bool m_logGameProfile;

	// Token: 0x04000BD7 RID: 3031
	public bool m_disableLevelledMatchmaking;

	// Token: 0x04000BD8 RID: 3032
	public bool m_enableSndaLogin;

	// Token: 0x04000BD9 RID: 3033
	public float m_serviceProcessingTime;

	// Token: 0x04000BDA RID: 3034
	public string[] m_sceneToPlay = new string[0];

	// Token: 0x04000BDB RID: 3035
	public bool m_usePlaylistId;

	// Token: 0x04000BDC RID: 3036
	public bool m_skipTutorial;

	// Token: 0x04000BDD RID: 3037
	public int m_playlistId = -1;

	// Token: 0x04000BDE RID: 3038
	public string m_serverIP = "127.0.0.1";

	// Token: 0x04000BDF RID: 3039
	public string m_language = "INT";

	// Token: 0x04000BE0 RID: 3040
	public string m_gameServerName;

	// Token: 0x04000BE1 RID: 3041
	public string m_statsDBAddress = "127.0.0.1";

	// Token: 0x04000BE2 RID: 3042
	public string m_login;

	// Token: 0x04000BE3 RID: 3043
	public bool m_emptyHostShutdown = true;

	// Token: 0x04000BE4 RID: 3044
	public bool m_nosound;

	// Token: 0x04000BE5 RID: 3045
	public bool m_noimpact;

	// Token: 0x04000BE6 RID: 3046
	public bool m_useReboot;

	// Token: 0x04000BE7 RID: 3047
	public bool m_isRebooted;

	// Token: 0x04000BE8 RID: 3048
	public int m_rebootedCharacterId;

	// Token: 0x04000BE9 RID: 3049
	public bool m_stressTown;

	// Token: 0x04000BEA RID: 3050
	public int m_stressPlaylistId = -1;

	// Token: 0x04000BEB RID: 3051
	public bool m_isReadyToLoadResources;

	// Token: 0x04000BEC RID: 3052
	public static readonly DateTime EPOCH = new DateTime(1970, 1, 1, 0, 0, 0, 0);

	// Token: 0x04000BED RID: 3053
	private GameObject m_defaultLoading;

	// Token: 0x04000BEE RID: 3054
	public string m_debugInfo_Version = "undefined";

	// Token: 0x04000BEF RID: 3055
	public StringBuilder m_displayedVersionId = new StringBuilder();

	// Token: 0x04000BF0 RID: 3056
	private GameFlowManager m_gameFlowMng;

	// Token: 0x04000BF1 RID: 3057
	private GameUIManager m_gameUIMng;

	// Token: 0x04000BF2 RID: 3058
	private FrontEndStepManager m_frontEndMgr;

	// Token: 0x04000BF3 RID: 3059
	public int BandwidthCap;

	// Token: 0x04000BF4 RID: 3060
	public int PriorityInspector;

	// Token: 0x04000BF5 RID: 3061
	protected float accum;

	// Token: 0x04000BF6 RID: 3062
	protected int frames;

	// Token: 0x04000BF7 RID: 3063
	[HideInInspector]
	public uint m_memCur;

	// Token: 0x04000BF8 RID: 3064
	[HideInInspector]
	public uint m_memPeak;

	// Token: 0x04000BF9 RID: 3065
	[HideInInspector]
	public float m_fps;

	// Token: 0x04000BFA RID: 3066
	[HideInInspector]
	public float frequency = 0.5f;

	// Token: 0x04000BFB RID: 3067
	public bool m_gameServerInstance;

	// Token: 0x04000BFC RID: 3068
	public int m_pvpRoomId;

	// Token: 0x04000BFD RID: 3069
	private Utils.Timer m_shutdownTimer = new Utils.Timer();

	// Token: 0x04000BFE RID: 3070
	public ProfilerManager m_profilerManager;

	// Token: 0x04000BFF RID: 3071
	private DebugInfoManager m_debugInfoManager;

	// Token: 0x04000C00 RID: 3072
	public GameObject m_manager;

	// Token: 0x04000C01 RID: 3073
	private bool m_isLoadingPageLoaded;

	// Token: 0x04000C02 RID: 3074
	public static bool s_allowQuit = false;

	// Token: 0x04000C03 RID: 3075
	private GUIStyle m_style;

	// Token: 0x04000C04 RID: 3076
	private static readonly string CONFIGURATION_PREFIX = "f";

	// Token: 0x04000C05 RID: 3077
	private static readonly string OBFUSCATION_SUFFIX = "_CO";

	// Token: 0x04000C06 RID: 3078
	private float m_lastTimeRleaseMemory;

	// Token: 0x04000C07 RID: 3079
	private DNACreateBehaviour m_dnaCreateBehaviour;

	// Token: 0x0200026D RID: 621
	public struct COPYDATASTRUCT
	{
		// Token: 0x04000C0A RID: 3082
		public IntPtr dwData;

		// Token: 0x04000C0B RID: 3083
		public int cData;

		// Token: 0x04000C0C RID: 3084
		[MarshalAs(UnmanagedType.LPStr)]
		public string lpData;
	}

	// Token: 0x0200026E RID: 622
	// (Invoke) Token: 0x06000D31 RID: 3377
	internal delegate int WindowEnumProc(IntPtr hwnd, IntPtr lparam);
}
