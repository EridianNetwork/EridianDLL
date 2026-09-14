using System;
using System.Collections;
using Core;
using ns0;
using UnityEngine;
using XsdSettings;

namespace AutoTest
{
	// Token: 0x02000633 RID: 1587
	internal class AutoTestCase_Stress : AutoTestCase
	{
		// Token: 0x06002845 RID: 10309 RVA: 0x000BD898 File Offset: 0x000BBA98
		public int GetPlayerNum()
		{
			if (this.m_maxPlayer < 0)
			{
				string environmentVariable = Environment.GetEnvironmentVariable("maxplayer");
				this.m_maxPlayer = int.Parse(environmentVariable);
			}
			return this.m_maxPlayer;
		}

		// Token: 0x06002846 RID: 10310 RVA: 0x000BD8CC File Offset: 0x000BBACC
		protected override void OpenAutoTestCase()
		{
			MonoSingleton<InputManager>.Instance.method_0(this.m_inputReader);
			Application.targetFrameRate = 30;
			this.m_timeToClose = 7200f + (float)global::UnityEngine.Random.Range(0, 180);
			AvatarType avatarType = (AvatarType)global::UnityEngine.Random.Range(0, 4);
			MonoSingleton<AutoTestManager>.Instance.StartCoroutine(this.CreateAndEnterTownCorountine(avatarType));
		}

		// Token: 0x06002847 RID: 10311 RVA: 0x000BD924 File Offset: 0x000BBB24
	public IEnumerator CreateAndEnterTownCorountine(AvatarType avatarType)
	{
		yield return ns0.MonoSingleton<AutoTestManager>.Instance.StartCoroutine(AutoTestUtility.smethod_7(avatarType));
		m_minTimeInLevel = 180 + UnityEngine.Random.Range(0, 120);
		Lobby pveLobby = LobbyManager.smethod_0().Lobby_1;
		Lobby pvpLobby = LobbyManager.smethod_0().Lobby_0;
		if (pveLobby != null || pvpLobby != null)
		{
			LobbyManager.smethod_0().method_24();
			LobbyManager.smethod_0().method_26();
		}
		if (AutoTestUtility.s_isANewlyCreatedCharacter)
		{
			GoToTutorial();
		}
		else
		{
			GoIntoTown();
		}
	}
		// Token: 0x06002848 RID: 10312 RVA: 0x000BD950 File Offset: 0x000BBB50
		private void GoToTutorial()
		{
			AvatarType avatarType = (AvatarType)global::UnityEngine.Random.Range(0, 4);
			int num = -1;
			if (string.IsNullOrEmpty(MonoSingleton<AppManager>.Instance.m_privateSessionName))
			{
				num = MatchmakingService.MatchmakingService_0.method_3("lvl_Tutorial_Part1_4x").m_id;
				DebugUtils.Log(LogCategory.Autotest, "GoToTutorial:" + num);
				AutoTestUtility.smethod_8(num);
			}
			else
			{
				DebugUtils.Log(LogCategory.Autotest, "GoToTutorial:" + num);
				MonoSingleton<AutoTestManager>.Instance.StartCoroutine(AutoTestUtility.smethod_9(avatarType, num));
			}
			this.m_timeToChangeLevel = 0f;
			AutoTestUtility.s_isANewlyCreatedCharacter = false;
		}

		// Token: 0x06002849 RID: 10313 RVA: 0x000BD9E8 File Offset: 0x000BBBE8
		private void GoIntoRV()
		{
			AvatarType avatarType = (AvatarType)global::UnityEngine.Random.Range(0, 4);
			int num = -1;
			if (string.IsNullOrEmpty(MonoSingleton<AppManager>.Instance.m_privateSessionName))
			{
				num = MatchmakingService.MatchmakingService_0.method_3("lvl_RV_4x").m_id;
				DebugUtils.Log(LogCategory.Autotest, "GoIntoRV:" + num);
				AutoTestUtility.smethod_8(num);
			}
			else
			{
				DebugUtils.Log(LogCategory.Autotest, "GoIntoRV:" + num);
				MonoSingleton<AutoTestManager>.Instance.StartCoroutine(AutoTestUtility.smethod_9(avatarType, num));
			}
			this.m_timeToChangeLevel = 0f;
		}

		// Token: 0x0600284A RID: 10314 RVA: 0x000BDA78 File Offset: 0x000BBC78
		private void GoIntoTown()
		{
			int num = -1;
			AvatarType avatarType = (AvatarType)global::UnityEngine.Random.Range(0, 4);
			if (string.IsNullOrEmpty(MonoSingleton<AppManager>.Instance.m_privateSessionName))
			{
				if (MonoSingleton<AppManager>.Instance.m_stressTown && MonoSingleton<AppManager>.Instance.m_stressPlaylistId != -1)
				{
					num = MonoSingleton<AppManager>.Instance.m_stressPlaylistId;
				}
				else
				{
					num = MatchmakingService.MatchmakingService_0.method_8(GamemodeType.GamemodeTown);
				}
				DebugUtils.Log(LogCategory.Autotest, "GoIntoTown:" + num);
				AutoTestUtility.smethod_8(num);
			}
			else
			{
				DebugUtils.Log(LogCategory.Autotest, "GoIntoTown:" + num);
				MonoSingleton<AutoTestManager>.Instance.StartCoroutine(AutoTestUtility.smethod_9(avatarType, num));
			}
			this.m_timeToChangeLevel = 0f;
		}

		// Token: 0x0600284B RID: 10315 RVA: 0x000BDB28 File Offset: 0x000BBD28
		private void StressTestGetIntoLevel()
		{
			if (LobbyManager.smethod_0().method_0())
			{
				return;
			}
			AvatarType avatarType = (AvatarType)global::UnityEngine.Random.Range(0, 4);
			int num = -1;
			if (string.IsNullOrEmpty(MonoSingleton<AppManager>.Instance.m_privateSessionName))
			{
				DebugUtils.Log(LogCategory.Autotest, "CreateAutoTestPvELobby:");
				LobbyManager.smethod_0().method_52();
			}
			else
			{
				DebugUtils.Log(LogCategory.Autotest, "StressTestGetIntoLevel:" + num);
				MonoSingleton<AutoTestManager>.Instance.StartCoroutine(AutoTestUtility.smethod_9(avatarType, num));
			}
			this.m_timeToChangeLevel = 0f;
		}

		// Token: 0x0600284C RID: 10316 RVA: 0x000BDBAC File Offset: 0x000BBDAC
		private void GoToPvPLevel()
		{
			if (LobbyManager.smethod_0().method_0())
			{
				return;
			}
			AvatarType avatarType = (AvatarType)global::UnityEngine.Random.Range(0, 4);
			int num = -1;
			if (string.IsNullOrEmpty(MonoSingleton<AppManager>.Instance.m_privateSessionName))
			{
				DebugUtils.Log(LogCategory.Autotest, "CreateAutoTestPvELobby:");
				LobbyManager.smethod_0().method_50();
			}
			else
			{
				DebugUtils.Log(LogCategory.Autotest, "GoToPvPLevel:" + num);
				MonoSingleton<AutoTestManager>.Instance.StartCoroutine(AutoTestUtility.smethod_9(avatarType, num));
			}
			this.m_timeToChangeLevel = 0f;
		}

		// Token: 0x0600284D RID: 10317 RVA: 0x000BDC30 File Offset: 0x000BBE30
		protected override void UpdateAutoTestCase()
		{
			this.m_timeToChangeLevel += Time.deltaTime;
			if (base.m_timeElapsed >= this.m_timeToClose)
			{
				base.Close(true, string.Empty);
			}
			if (MonoSingleton<AppManager>.Instance == null)
			{
				return;
			}
			if (this.m_inputReader != null)
			{
				this.m_inputReader.Update(base.m_timeElapsed);
			}
			if (MonoSingleton<Session>.Instance != null && ServiceWrapperBase<ChatServiceWarpper>.Instance != null)
			{
				if (this.m_chatTimer.method_7())
				{
					byte[] array = new byte[1];
					ChatParameter chatParameter = ChatParameter.Group;
					if (MonoSingleton<Session>.Instance.method_16())
					{
						chatParameter = ChatParameter.Town;
					}
					ServiceWrapperBase<ChatServiceWarpper>.Instance.method_0(new OnChat(this.onNetSendResult), (byte)chatParameter, 0, ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_9(), AutoTestCase_Stress.m_chatText, array);
					this.m_chatTimer.Start(20f);
				}
				if (!this.m_chatTimer.method_6())
				{
					this.m_chatTimer.Start(20f);
				}
			}
			if (this.IsTimeToChange())
			{
				this.ChangeMap();
			}
		}

		// Token: 0x0600284E RID: 10318 RVA: 0x000BDD30 File Offset: 0x000BBF30
		private bool IsTimeToChange()
		{
			if (MonoSingleton<Session>.Instance != null && MonoSingleton<Session>.Instance.method_13())
			{
				if ((float)((int)this.m_timeToChangeLevel) > this.m_minTimeInLevel + 300f)
				{
					return true;
				}
			}
			else if (MonoSingleton<Session>.Instance != null && MonoSingleton<Session>.Instance.method_11())
			{
				if ((float)((int)this.m_timeToChangeLevel) > this.m_minTimeInLevel + 900f)
				{
					return true;
				}
			}
			else if (MonoSingleton<Session>.Instance != null && MonoSingleton<Session>.Instance.method_12())
			{
				if ((float)((int)this.m_timeToChangeLevel) > this.m_minTimeInLevel + 360f)
				{
					return true;
				}
			}
			else if ((float)((int)this.m_timeToChangeLevel) > this.m_minTimeInLevel)
			{
				return true;
			}
			return false;
		}

		// Token: 0x0600284F RID: 10319 RVA: 0x000BDDE4 File Offset: 0x000BBFE4
		protected void ChangeMap()
		{
			Lobby lobby_ = LobbyManager.smethod_0().Lobby_1;
			Lobby lobby_2 = LobbyManager.smethod_0().Lobby_0;
			if (lobby_ != null || lobby_2 != null)
			{
				LobbyManager.smethod_0().method_24();
				LobbyManager.smethod_0().method_26();
			}
			if (MonoSingleton<Session>.Instance != null && MonoSingleton<Session>.Instance.method_13())
			{
				this.GoIntoTown();
			}
			else if (MonoSingleton<Session>.Instance != null && MonoSingleton<Session>.Instance.method_17())
			{
				this.GoIntoTown();
			}
			else if (MonoSingleton<Session>.Instance != null && MonoSingleton<Session>.Instance.method_16())
			{
				int num = global::UnityEngine.Random.Range(0, 5);
				if (num != 0 && !MonoSingleton<AppManager>.Instance.m_stressTown)
				{
					if (num == 1)
					{
						this.GoToPvPLevel();
					}
					else
					{
						this.StressTestGetIntoLevel();
					}
				}
				else
				{
					this.GoIntoRV();
				}
			}
			else
			{
				this.GoIntoTown();
			}
		}

		// Token: 0x06002850 RID: 10320 RVA: 0x0000311B File Offset: 0x0000131B
		protected void onNetSendResult(int result)
		{
		}

		// Token: 0x06002851 RID: 10321 RVA: 0x0001A8C1 File Offset: 0x00018AC1
		protected override void RequestResource()
		{
			this.m_IHaveGotResource = true;
		}

		// Token: 0x06002852 RID: 10322 RVA: 0x000BDEB8 File Offset: 0x000BC0B8
		protected override void CloseAutoTestCase()
		{
			NetworkManager.DisconnectAsyncTask disconnectAsyncTask = new NetworkManager.DisconnectAsyncTask();
			disconnectAsyncTask.method_5();
			MonoSingleton<AsyncTaskManager>.Instance.method_1(disconnectAsyncTask, null);
			MonoSingleton<AppManager>.Instance.method_8();
		}

		// Token: 0x04001C8B RID: 7307
		private int m_maxPlayer = -1;

		// Token: 0x04001C8C RID: 7308
		private AutoTestStressInputReader m_inputReader = new AutoTestStressInputReader();

		// Token: 0x04001C8D RID: 7309
		private float m_timeToClose;

		// Token: 0x04001C8E RID: 7310
		private float m_timeToChangeLevel;

		// Token: 0x04001C8F RID: 7311
		private float m_minTimeInLevel;

		// Token: 0x04001C90 RID: 7312
		private Utils.Timer m_chatTimer = new Utils.Timer();

		// Token: 0x04001C91 RID: 7313
		private static string m_chatText = "Que dites-vous ?... C'est inutile ?... Je le sais  Mais on ne se bat pas dans l'espoir du succes! Non! non, c'est bien plus beau lorsque c'est inutile!";
	}
}
