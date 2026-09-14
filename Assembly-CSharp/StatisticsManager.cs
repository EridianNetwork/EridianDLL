using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x0200055F RID: 1375
public class StatisticsManager : MonoSingleton<StatisticsManager>
{
	// Token: 0x0600233A RID: 9018 RVA: 0x00018320 File Offset: 0x00016520
	public StatisticsManager.SessionStats GetCurrentSession()
	{
		return this.m_currentSession;
	}

	// Token: 0x0600233B RID: 9019 RVA: 0x000A67B4 File Offset: 0x000A49B4
	public void method_1()
	{
		if (MonoSingleton<Session>.Instance != null && MonoSingleton<Session>.Instance.method_16())
		{
			return;
		}
		this.m_isRecording = true;
		this.GetCurrentSession().method_3(0);
		this.GetCurrentSession().m_instanceName = MonoSingleton<Session>.Instance.method_1();
		this.GetCurrentSession().m_difficulty = MonoSingleton<Session>.Instance.method_2();
		this.GetCurrentSession().m_sessionLevelRange = MonoSingleton<Session>.Instance.method_3();
		this.GetCurrentSession().m_playlistId = MatchmakingService.MatchmakingService_0.method_0().m_id;
		this.GetCurrentSession().m_mapName = MonoSingleton<Session>.Instance.method_5();
		this.GetCurrentSession().m_round = 1;
		this.GetCurrentSession().m_gameModeName = MonoSingleton<Session>.Instance.method_6();
	}

	// Token: 0x0600233C RID: 9020 RVA: 0x000A6880 File Offset: 0x000A4A80
	public void method_2()
	{
		if (!this.m_isRecording)
		{
			return;
		}
		if (MonoSingleton<Session>.Instance == null)
		{
			return;
		}
		PlayerInfoSync localPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer();
		if (localPlayer)
		{
			EntityWeapon entityWeapon = ((!(localPlayer.GetEntity() != null)) ? null : localPlayer.GetEntity().vmethod_16());
			if (MonoSingleton<StatisticsManager>.Instance == null)
			{
				return;
			}
			StatisticsManager.SessionStats currentSession = MonoSingleton<StatisticsManager>.Instance.GetCurrentSession();
			if (currentSession == null)
			{
				return;
			}
			if (entityWeapon && MonoSingleton<StatisticsManager>.Instance.GetCurrentSession() != null)
			{
				StatisticsManager.StatSheet personalStatSheet = currentSession.GetPersonalStatSheet(localPlayer);
				if (personalStatSheet == null)
				{
					return;
				}
				personalStatSheet.method_4(entityWeapon.method_99());
				DebugUtils.Log(LogCategory.Stats, "Weapon Usage for [" + localPlayer.m_name + "]");
				DebugUtils.Log(LogCategory.Stats, "SMG - " + personalStatSheet.m_SmgUsage);
				DebugUtils.Log(LogCategory.Stats, "SniperRifle - " + personalStatSheet.m_SniperUsage);
				DebugUtils.Log(LogCategory.Stats, "ShotGun - " + personalStatSheet.m_ShotgunUsage);
				DebugUtils.Log(LogCategory.Stats, "Pistol - " + personalStatSheet.m_PistolUsage);
				DebugUtils.Log(LogCategory.Stats, "CombatRifle - " + personalStatSheet.m_CombatRifleUsage);
			}
		}
		this.m_isRecording = false;
	}

	// Token: 0x0600233D RID: 9021 RVA: 0x000A69D8 File Offset: 0x000A4BD8
	public void method_3(object[] object_0)
	{
		this.m_currentSession = StatisticsManager.smethod_1(object_0);
		DebugUtils.LogError(LogCategory.Gamelogic, string.Concat(new string[]
		{
			"DIAG3: claptrapTeamID=",
			this.m_currentSession.m_claptrapTeamID.ToString(),
			" claptrapScore=",
			this.m_currentSession.m_claptrapScore.ToString(),
			" timeLimit=",
			this.m_currentSession.m_timeLimit.ToString(),
			" endScore=",
			this.m_currentSession.m_endScore.ToString(),
			" sheets=",
			this.m_currentSession.m_statsSheets.Count.ToString()
		}));
		for (int i = 0; i < this.m_currentSession.m_statsSheets.Count; i++)
		{
			StatisticsManager.StatSheet statSheet = this.m_currentSession.m_statsSheets[i];
			DebugUtils.LogError(LogCategory.Gamelogic, string.Concat(new string[]
			{
				"DIAG3 sheet[",
				i.ToString(),
				"] id=",
				statSheet.m_id.ToString(),
				" teamId=",
				statSheet.m_teamId.ToString(),
				" isTeam=",
				statSheet.m_isTeam.ToString(),
				" name=",
				statSheet.m_name,
				" score=",
				statSheet.m_score.ToString()
			}));
		}
	}

	// Token: 0x0600233E RID: 9022 RVA: 0x000A6B58 File Offset: 0x000A4D58
	public void method_4(object[] object_0)
	{
		if (!this.m_isRecording)
		{
			return;
		}
		PlayerInfoSync localPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer();
		if (localPlayer)
		{
			EntityWeapon entityWeapon = ((!(localPlayer.GetEntity() != null)) ? null : localPlayer.GetEntity().vmethod_16());
			if (entityWeapon)
			{
				StatisticsManager.StatSheet personalStatSheet = MonoSingleton<StatisticsManager>.Instance.GetCurrentSession().GetPersonalStatSheet(localPlayer);
				personalStatSheet.method_4(entityWeapon.method_99());
				DebugUtils.Log(LogCategory.Stats, "Weapon Usage for [" + localPlayer.m_name + "]");
				DebugUtils.Log(LogCategory.Stats, "SMG - " + personalStatSheet.m_SmgUsage);
				DebugUtils.Log(LogCategory.Stats, "SniperRifle - " + personalStatSheet.m_SniperUsage);
				DebugUtils.Log(LogCategory.Stats, "ShotGun - " + personalStatSheet.m_ShotgunUsage);
				DebugUtils.Log(LogCategory.Stats, "Pistol - " + personalStatSheet.m_PistolUsage);
				DebugUtils.Log(LogCategory.Stats, "CombatRifle - " + personalStatSheet.m_CombatRifleUsage);
			}
		}
		this.m_lastScoreBoard = StatisticsManager.smethod_1(object_0);
		StatisticsManager.StatSheet statSheet = this.m_lastScoreBoard.method_21();
		if (statSheet != null)
		{
			statSheet.m_rivalTable = this.m_currentSession.method_21().m_rivalTable;
			if (statSheet.m_isEnergyConsumed)
			{
				Character character = ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_5();
				if (character != null)
				{
					character.Energy--;
				}
			}
		}
		this.m_isRecording = false;
	}

	// Token: 0x0600233F RID: 9023 RVA: 0x00018328 File Offset: 0x00016528
	public StatisticsManager.SessionStats method_5()
	{
		return this.m_lastScoreBoard;
	}

	// Token: 0x06002340 RID: 9024 RVA: 0x00018330 File Offset: 0x00016530
	public StatisticsManager.StatSheet[] method_6()
	{
		return this.m_currentSession.m_statsSheets.ToArray();
	}

	// Token: 0x06002341 RID: 9025 RVA: 0x000A6CD4 File Offset: 0x000A4ED4
	public static object[] smethod_0(StatisticsManager.SessionStats sessionStats_0)
	{
		List<object> list = new List<object>();
		list.Add(sessionStats_0.m_instanceName);
		list.Add(sessionStats_0.m_playlistId);
		list.Add((byte)sessionStats_0.m_difficulty);
		list.Add(sessionStats_0.m_duration);
		list.Add(sessionStats_0.m_timeLimit);
		list.Add(sessionStats_0.m_endScore);
		list.Add((short)sessionStats_0.m_killCount);
		list.Add((byte)sessionStats_0.m_round);
		list.Add((byte)sessionStats_0.m_claptrapTeamID);
		list.Add((byte)sessionStats_0.m_claptrapScore);
		list.Add(sessionStats_0.m_gameModeName);
		list.Add((byte)sessionStats_0.m_statsSheets.Count);
		for (int i = 0; i < sessionStats_0.m_statsSheets.Count; i++)
		{
			list.Add(sessionStats_0.m_statsSheets[i].m_id);
			list.Add(sessionStats_0.m_statsSheets[i].m_teamId);
			list.Add(sessionStats_0.m_statsSheets[i].m_isTeam);
			list.Add(sessionStats_0.m_statsSheets[i].m_name);
			list.Add(sessionStats_0.m_statsSheets[i].m_level);
			list.Add((short)sessionStats_0.m_statsSheets[i].m_lastKillerForRevenge);
			list.Add((short)sessionStats_0.m_statsSheets[i].m_lastDamager[0]);
			list.Add((short)sessionStats_0.m_statsSheets[i].m_lastDamager[1]);
			list.Add(sessionStats_0.m_statsSheets[i].m_isEnergyConsumed);
			list.Add(sessionStats_0.m_statsSheets[i].m_isFail);
			list.Add((short)sessionStats_0.m_statsSheets[i].m_score);
			list.Add((short)sessionStats_0.m_statsSheets[i].m_goalPoint);
			list.Add((byte)sessionStats_0.m_statsSheets[i].m_killCount);
			list.Add((byte)sessionStats_0.m_statsSheets[i].m_criticalKillCount);
			list.Add((byte)sessionStats_0.m_statsSheets[i].m_deathcount);
			list.Add(sessionStats_0.m_statsSheets[i].m_totalDamage);
			list.Add(sessionStats_0.m_statsSheets[i].m_criticalDamage);
			list.Add(sessionStats_0.m_statsSheets[i].m_attackDamage);
			list.Add((byte)sessionStats_0.m_statsSheets[i].m_badassKill);
			list.Add((byte)sessionStats_0.m_statsSheets[i].m_bossKill);
			list.Add((short)sessionStats_0.m_statsSheets[i].m_hitNumber);
			list.Add((short)sessionStats_0.m_statsSheets[i].m_criticalHitNumber);
			list.Add((short)sessionStats_0.m_statsSheets[i].m_sameVictimCount);
			list.Add((short)sessionStats_0.m_statsSheets[i].m_meleeKillCount);
			list.Add((short)sessionStats_0.m_statsSheets[i].m_nemesisCount);
			list.Add((short)sessionStats_0.m_statsSheets[i].m_grenadeKillCount);
			list.Add((short)sessionStats_0.m_statsSheets[i].m_headshotKillCount);
			list.Add((short)sessionStats_0.m_statsSheets[i].m_skillCount);
			list.Add(sessionStats_0.m_statsSheets[i].m_extraExp);
			list.Add(sessionStats_0.m_statsSheets[i].m_extraMoney);
			list.Add(sessionStats_0.m_statsSheets[i].m_honorValue);
			list.Add(sessionStats_0.m_statsSheets[i].m_guildExp);
			list.Add((byte)sessionStats_0.m_statsSheets[i].m_killStreak);
			list.Add((byte)sessionStats_0.m_statsSheets[i].m_criticalKillStreak);
			list.Add((byte)sessionStats_0.m_statsSheets[i].m_deathStreak);
			list.Add((byte)sessionStats_0.m_statsSheets[i].m_ping);
			list.Add(sessionStats_0.m_statsSheets[i].m_lastDamageTime);
			list.Add(sessionStats_0.m_statsSheets[i].m_livingInterval);
			list.Add(sessionStats_0.m_statsSheets[i].m_flyingInterval);
			list.Add(sessionStats_0.m_statsSheets[i].m_lastKillTime);
			list.Add((byte)sessionStats_0.m_statsSheets[i].m_last4KillTimes.Length);
			for (int j = 0; j < sessionStats_0.m_statsSheets[i].m_last4KillTimes.Length; j++)
			{
				list.Add(sessionStats_0.m_statsSheets[i].m_last4KillTimes[j]);
			}
			list.Add((byte)sessionStats_0.m_statsSheets[i].m_lastKillTimeIndex);
		}
		return list.ToArray();
	}

	// Token: 0x06002342 RID: 9026 RVA: 0x000A72CC File Offset: 0x000A54CC
	private static StatisticsManager.SessionStats smethod_1(object[] object_0)
	{
		StatisticsManager.SessionStats sessionStats = new StatisticsManager.SessionStats();
		sessionStats.m_instanceName = (string)object_0[0];
		sessionStats.m_playlistId = (int)object_0[1];
		sessionStats.m_difficulty = (ELevelDifficulty)((byte)object_0[2]);
		sessionStats.m_duration = (float)object_0[3];
		sessionStats.m_timeLimit = (int)object_0[4];
		sessionStats.m_endScore = (int)object_0[5];
		sessionStats.method_3((int)((short)object_0[6]));
		sessionStats.m_round = (int)((byte)object_0[7]);
		sessionStats.m_claptrapTeamID = (int)((byte)object_0[8]);
		sessionStats.m_claptrapScore = (int)((byte)object_0[9]);
		sessionStats.m_gameModeName = (string)object_0[10];
		int num = 11;
		int num2 = 12;
		byte b = (byte)object_0[num];
		sessionStats.m_statsSheets = new List<StatisticsManager.StatSheet>();
		for (int i = 0; i < (int)b; i++)
		{
			StatisticsManager.StatSheet statSheet = new StatisticsManager.StatSheet();
			statSheet = new StatisticsManager.StatSheet();
			statSheet.m_id = (int)object_0[num2++];
			statSheet.m_teamId = (int)object_0[num2++];
			statSheet.m_isTeam = (bool)object_0[num2++];
			statSheet.m_name = (string)object_0[num2++];
			statSheet.m_level = (int)object_0[num2++];
			statSheet.m_lastKillerForRevenge = (int)((short)object_0[num2++]);
			statSheet.m_lastDamager[0] = (int)((short)object_0[num2++]);
			statSheet.m_lastDamager[1] = (int)((short)object_0[num2++]);
			statSheet.m_isEnergyConsumed = (bool)object_0[num2++];
			statSheet.m_isFail = (bool)object_0[num2++];
			statSheet.m_score = (int)((short)object_0[num2++]);
			statSheet.m_goalPoint = (int)((short)object_0[num2++]);
			statSheet.m_killCount = (int)((byte)object_0[num2++]);
			statSheet.m_criticalKillCount = (int)((byte)object_0[num2++]);
			statSheet.m_deathcount = (int)((byte)object_0[num2++]);
			statSheet.m_totalDamage = (int)object_0[num2++];
			statSheet.m_criticalDamage = (int)object_0[num2++];
			statSheet.m_attackDamage = (int)object_0[num2++];
			statSheet.m_badassKill = (int)((byte)object_0[num2++]);
			statSheet.m_bossKill = (int)((byte)object_0[num2++]);
			statSheet.m_hitNumber = (int)((short)object_0[num2++]);
			statSheet.m_criticalHitNumber = (int)((short)object_0[num2++]);
			statSheet.m_sameVictimCount = (int)((short)object_0[num2++]);
			statSheet.m_meleeKillCount = (int)((short)object_0[num2++]);
			statSheet.m_nemesisCount = (int)((short)object_0[num2++]);
			statSheet.m_grenadeKillCount = (int)((short)object_0[num2++]);
			statSheet.m_headshotKillCount = (int)((short)object_0[num2++]);
			statSheet.m_skillCount = (int)((short)object_0[num2++]);
			statSheet.m_extraExp = (int)object_0[num2++];
			statSheet.m_extraMoney = (int)object_0[num2++];
			statSheet.m_honorValue = (int)object_0[num2++];
			statSheet.m_guildExp = (int)object_0[num2++];
			statSheet.m_killStreak = (int)((byte)object_0[num2++]);
			statSheet.m_criticalKillStreak = (int)((byte)object_0[num2++]);
			statSheet.m_deathStreak = (int)((byte)object_0[num2++]);
			statSheet.m_ping = (StatisticsManager.PingQuality)((byte)object_0[num2++]);
			statSheet.m_lastDamageTime = (float)object_0[num2++];
			statSheet.m_livingInterval = (float)object_0[num2++];
			statSheet.m_flyingInterval = (float)object_0[num2++];
			statSheet.m_lastKillTime = (float)object_0[num2++];
			int num3 = (int)((byte)object_0[num2++]);
			statSheet.m_last4KillTimes = new float[num3];
			for (int j = 0; j < num3; j++)
			{
				statSheet.m_last4KillTimes[j] = (float)object_0[num2++];
			}
			statSheet.m_lastKillTimeIndex = (int)((byte)object_0[num2++]);
			sessionStats.m_statsSheets.Add(statSheet);
		}
		return sessionStats;
	}

	// Token: 0x040017D6 RID: 6102
	private bool m_isRecording;

	// Token: 0x040017D7 RID: 6103
	private StatisticsManager.SessionStats m_currentSession = new StatisticsManager.SessionStats();

	// Token: 0x040017D8 RID: 6104
	private StatisticsManager.SessionStats m_lastScoreBoard = new StatisticsManager.SessionStats();

	// Token: 0x02000560 RID: 1376
	public enum PingQuality
	{
		// Token: 0x040017DA RID: 6106
		Low,
		// Token: 0x040017DB RID: 6107
		Medium,
		// Token: 0x040017DC RID: 6108
		High
	}

	// Token: 0x02000561 RID: 1377
	public class SessionStats
	{
		// Token: 0x170001C6 RID: 454
		// (get) Token: 0x06002344 RID: 9028 RVA: 0x00018355 File Offset: 0x00016555
		// (set) Token: 0x06002345 RID: 9029 RVA: 0x0001835D File Offset: 0x0001655D
		public int m_killCount { get; private set; }

		// Token: 0x06002346 RID: 9030 RVA: 0x000A7730 File Offset: 0x000A5930
		public void method_0(PhotonStream photonStream_0)
		{
			if (photonStream_0.IsWriting)
			{
				photonStream_0.SendNext((short)this.m_sessionLevelRange);
				photonStream_0.SendNext((short)this.m_timeLimit);
				photonStream_0.SendNext((short)this.m_endScore);
				photonStream_0.SendNext((short)this.m_endKillCount);
				photonStream_0.SendNext(this.m_claptrap2TeamADis);
				photonStream_0.SendNext(this.m_claptrap2TeamBDis);
			}
			else
			{
				this.m_sessionLevelRange = (int)((short)photonStream_0.ReceiveNext());
				this.m_timeLimit = (int)((short)photonStream_0.ReceiveNext());
				this.m_endScore = (int)((short)photonStream_0.ReceiveNext());
				this.m_endKillCount = (int)((short)photonStream_0.ReceiveNext());
				this.m_claptrap2TeamADis = (float)photonStream_0.ReceiveNext();
				this.m_claptrap2TeamBDis = (float)photonStream_0.ReceiveNext();
			}
		}

		// Token: 0x06002347 RID: 9031 RVA: 0x000A781C File Offset: 0x000A5A1C
		public int method_1()
		{
			int num = (int)MonoSingleton<Session>.Instance.method_8();
			int num2 = Mathf.Max(0, this.m_timeLimit - num);
			DebugUtils.LogError(LogCategory.Gamelogic, string.Concat(new string[]
			{
				"DIAG1: timeLimit=",
				this.m_timeLimit.ToString(),
				" elapsed=",
				num.ToString(),
				" result=",
				num2.ToString(),
				" endScore=",
				this.m_endScore.ToString()
			}));
			return num2;
		}

		// Token: 0x06002348 RID: 9032 RVA: 0x00018366 File Offset: 0x00016566
		public void method_2()
		{
			this.m_killCount++;
		}

		// Token: 0x06002349 RID: 9033 RVA: 0x00018376 File Offset: 0x00016576
		public void method_3(int int_0)
		{
			this.m_killCount = int_0;
		}

		// Token: 0x0600234A RID: 9034 RVA: 0x0001837F File Offset: 0x0001657F
		public bool method_4()
		{
			return this.m_claptrapTeamID > 0;
		}

		// Token: 0x0600234B RID: 9035 RVA: 0x0001838A File Offset: 0x0001658A
		public string method_5()
		{
			return this.m_gameModeName;
		}

		// Token: 0x0600234C RID: 9036 RVA: 0x000A78A8 File Offset: 0x000A5AA8
		public StatisticsManager.StatSheet method_6(PlayerInfoSync playerInfoSync_0)
		{
			if (MonoSingleton<Session>.Instance != null && MonoSingleton<Session>.Instance.method_16())
			{
				return null;
			}
			return this.method_14(playerInfoSync_0.m_characterId, playerInfoSync_0.m_teamID, playerInfoSync_0.m_name, MonoSingleton<LevelingManager>.Instance.method_3(playerInfoSync_0.m_avatarDna.method_5(), playerInfoSync_0.m_exp), false);
		}

		// Token: 0x0600234D RID: 9037 RVA: 0x00018392 File Offset: 0x00016592
		public void method_7(PlayerInfoSync playerInfoSync_0)
		{
			if (MonoSingleton<Session>.Instance != null && MonoSingleton<Session>.Instance.method_16())
			{
				return;
			}
			this.method_13(playerInfoSync_0.m_characterId, false);
		}

		// Token: 0x0600234E RID: 9038 RVA: 0x000183BB File Offset: 0x000165BB
		public StatisticsManager.StatSheet GetPersonalStatSheet(PlayerInfoSync playerInfoSync_0)
		{
			return this.GetStatSheetById(playerInfoSync_0.m_characterId, false);
		}

		// Token: 0x0600234F RID: 9039 RVA: 0x000183CA File Offset: 0x000165CA
		public StatisticsManager.StatSheet method_9(int int_0)
		{
			return this.GetStatSheetById(int_0, true);
		}

		// Token: 0x06002350 RID: 9040 RVA: 0x000183D4 File Offset: 0x000165D4
		public StatisticsManager.StatSheet method_10(int int_0)
		{
			if (MonoSingleton<Session>.Instance != null && MonoSingleton<Session>.Instance.method_16())
			{
				return null;
			}
			return this.method_14(int_0, int_0, int_0.ToString(), 0, true);
		}

		// Token: 0x06002351 RID: 9041 RVA: 0x00018402 File Offset: 0x00016602
		public void method_11(int int_0)
		{
			if (MonoSingleton<Session>.Instance != null && MonoSingleton<Session>.Instance.method_16())
			{
				return;
			}
			this.method_13(int_0, true);
		}

		// Token: 0x06002352 RID: 9042 RVA: 0x000A7904 File Offset: 0x000A5B04
		public StatisticsManager.StatSheet GetStatSheetById(int int_0, bool bool_0)
		{
			for (int i = 0; i < this.m_statsSheets.Count; i++)
			{
				if (this.m_statsSheets[i].m_id == int_0 && this.m_statsSheets[i].m_isTeam == bool_0)
				{
					return this.m_statsSheets[i];
				}
			}
			return null;
		}

		// Token: 0x06002353 RID: 9043 RVA: 0x000A7960 File Offset: 0x000A5B60
		public void method_13(int int_0, bool bool_0)
		{
			if (MonoSingleton<Session>.Instance != null && MonoSingleton<Session>.Instance.method_16())
			{
				return;
			}
			for (int i = 0; i < this.m_statsSheets.Count; i++)
			{
				if (this.m_statsSheets[i].m_id == int_0 && this.m_statsSheets[i].m_isTeam == bool_0)
				{
					this.m_statsSheets.RemoveAt(i);
				}
			}
		}

		// Token: 0x06002354 RID: 9044 RVA: 0x000A79D4 File Offset: 0x000A5BD4
		public StatisticsManager.StatSheet method_14(int int_0, int int_1, string string_0, int int_2, bool bool_0)
		{
			if (MonoSingleton<Session>.Instance != null && MonoSingleton<Session>.Instance.method_16())
			{
				return null;
			}
			for (int i = 0; i < this.m_statsSheets.Count; i++)
			{
				if (this.m_statsSheets[i].m_id == int_0 && this.m_statsSheets[i].m_isTeam == bool_0)
				{
					this.m_statsSheets[i].m_teamId = int_1;
					this.m_statsSheets[i].m_level = int_2;
					return this.m_statsSheets[i];
				}
			}
			StatisticsManager.StatSheet statSheet = new StatisticsManager.StatSheet();
			statSheet.m_id = int_0;
			statSheet.m_teamId = int_1;
			statSheet.m_name = string_0;
			statSheet.m_level = int_2;
			statSheet.m_isTeam = bool_0;
			this.m_statsSheets.Add(statSheet);
			return statSheet;
		}

		// Token: 0x06002355 RID: 9045 RVA: 0x00018426 File Offset: 0x00016626
		public object[] method_15()
		{
			return StatisticsManager.smethod_0(this);
		}

		// Token: 0x06002356 RID: 9046 RVA: 0x000A7AA8 File Offset: 0x000A5CA8
		public int method_16()
		{
			int num = 0;
			for (int i = 0; i < this.m_statsSheets.Count; i++)
			{
				if (!this.m_statsSheets[i].m_isTeam)
				{
					num = Mathf.Max(num, this.m_statsSheets[i].m_score);
				}
			}
			return num;
		}

		// Token: 0x06002357 RID: 9047 RVA: 0x000A7AFC File Offset: 0x000A5CFC
		public StatisticsManager.StatSheet method_17()
		{
			if (this.m_statsSheets.Count == 0)
			{
				return null;
			}
			StatisticsManager.StatSheet statSheet = this.m_statsSheets[0];
			for (int i = 0; i < this.m_statsSheets.Count; i++)
			{
				if (!this.m_statsSheets[i].m_isTeam && this.m_statsSheets[i].m_score > statSheet.m_score)
				{
					statSheet = this.m_statsSheets[i];
				}
			}
			return statSheet;
		}

		// Token: 0x06002358 RID: 9048 RVA: 0x000A7B78 File Offset: 0x000A5D78
		public string method_18()
		{
			StatisticsManager.StatSheet statSheet = this.m_statsSheets[0];
			for (int i = 0; i < this.m_statsSheets.Count; i++)
			{
				if (!this.m_statsSheets[i].m_isTeam && this.m_statsSheets[i].m_skillCount > statSheet.m_skillCount)
				{
					statSheet = this.m_statsSheets[i];
				}
			}
			return statSheet.m_name;
		}

		// Token: 0x06002359 RID: 9049 RVA: 0x000A7BE8 File Offset: 0x000A5DE8
		public string method_19()
		{
			StatisticsManager.StatSheet statSheet = this.m_statsSheets[0];
			for (int i = 0; i < this.m_statsSheets.Count; i++)
			{
				if (!this.m_statsSheets[i].m_isTeam && this.m_statsSheets[i].m_grenadeKillCount > statSheet.m_grenadeKillCount)
				{
					statSheet = this.m_statsSheets[i];
				}
			}
			return statSheet.m_name;
		}

		// Token: 0x0600235A RID: 9050 RVA: 0x000A7C58 File Offset: 0x000A5E58
		public string method_20()
		{
			StatisticsManager.StatSheet statSheet = this.m_statsSheets[0];
			for (int i = 0; i < this.m_statsSheets.Count; i++)
			{
				if (!this.m_statsSheets[i].m_isTeam && this.m_statsSheets[i].m_headshotKillCount > statSheet.m_headshotKillCount)
				{
					statSheet = this.m_statsSheets[i];
				}
			}
			return statSheet.m_name;
		}

		// Token: 0x0600235B RID: 9051 RVA: 0x000A7CC8 File Offset: 0x000A5EC8
		public StatisticsManager.StatSheet method_21()
		{
			if (this.m_statsSheets.Count == 0)
			{
				return null;
			}
			StatisticsManager.StatSheet statSheet = this.m_statsSheets[0];
			for (int i = 0; i < this.m_statsSheets.Count; i++)
			{
				if (this.m_statsSheets[i].m_name == ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_9())
				{
					statSheet = this.m_statsSheets[i];
					return statSheet;
				}
			}
			return statSheet;
		}

		// Token: 0x0600235C RID: 9052 RVA: 0x000A7D3C File Offset: 0x000A5F3C
		public int method_22(bool bool_0)
		{
			int num = 0;
			int teamId = this.method_21().m_teamId;
			for (int i = 0; i < this.m_statsSheets.Count; i++)
			{
				if (this.m_statsSheets[i].m_isTeam && this.m_statsSheets[i].m_teamId == teamId == bool_0)
				{
					num = this.m_statsSheets[i].m_score;
					return num;
				}
			}
			return num;
		}

		// Token: 0x0600235D RID: 9053 RVA: 0x000A7DB0 File Offset: 0x000A5FB0
		public StatisticsManager.StatSheet method_23(int int_0)
		{
			if (this.m_statsSheets == null)
			{
				return null;
			}
			if (this.m_statsSheets.Count < 1)
			{
				return null;
			}
			if (int_0 > this.m_statsSheets.Count || int_0 < 1)
			{
				return null;
			}
			LinkedList<StatisticsManager.StatSheet> linkedList = new LinkedList<StatisticsManager.StatSheet>();
			linkedList.AddFirst(this.m_statsSheets[0]);
			for (int i = 1; i < this.m_statsSheets.Count; i++)
			{
				LinkedListNode<StatisticsManager.StatSheet> linkedListNode = linkedList.First;
				while (linkedListNode.Value.m_score > this.m_statsSheets[i].m_score)
				{
					if (linkedListNode == linkedList.Last)
					{
						linkedList.AddAfter(linkedListNode, this.m_statsSheets[i]);
					}
					else
					{
						linkedListNode = linkedListNode.Next;
					}
				}
				if (linkedListNode.Value.m_score < this.m_statsSheets[i].m_score)
				{
					linkedList.AddBefore(linkedListNode, this.m_statsSheets[i]);
				}
			}
			LinkedListNode<StatisticsManager.StatSheet> linkedListNode2 = linkedList.First;
			for (int j = 1; j < int_0; j++)
			{
				if (linkedListNode2 == null)
				{
					return null;
				}
				linkedListNode2 = linkedListNode2.Next;
			}
			if (linkedListNode2 == null)
			{
				return null;
			}
			return linkedListNode2.Value;
		}

		// Token: 0x0600235E RID: 9054 RVA: 0x000A7ED4 File Offset: 0x000A60D4
		public int method_24()
		{
			int num = 0;
			for (int i = 0; i < this.m_statsSheets.Count; i++)
			{
				num = Mathf.Max(num, this.m_statsSheets[i].m_killCount);
			}
			return num;
		}

		// Token: 0x0600235F RID: 9055 RVA: 0x000A7F14 File Offset: 0x000A6114
		public int method_25(int int_0)
		{
			List<StatisticsManager.StatSheet> list = this.method_27();
			StatisticsManager.StatSheet[] array = list.ToArray();
			Array.Sort<StatisticsManager.StatSheet>(array, new Comparison<StatisticsManager.StatSheet>(this.method_31));
			if (int_0 > 0 && int_0 <= array.Length)
			{
				StatisticsManager.StatSheet statSheet = array[int_0 - 1];
				if (statSheet != null)
				{
					return statSheet.m_score;
				}
			}
			return 0;
		}

		// Token: 0x06002360 RID: 9056 RVA: 0x000A7F5C File Offset: 0x000A615C
		public int method_26(PlayerInfoSync playerInfoSync_0)
		{
			List<StatisticsManager.StatSheet> list = this.method_27();
			StatisticsManager.StatSheet[] array = list.ToArray();
			Array.Sort<StatisticsManager.StatSheet>(array, new Comparison<StatisticsManager.StatSheet>(this.method_31));
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].m_id == playerInfoSync_0.m_characterId)
				{
					return i + 1;
				}
			}
			return 0;
		}

		// Token: 0x06002361 RID: 9057 RVA: 0x000A7FB0 File Offset: 0x000A61B0
		public List<StatisticsManager.StatSheet> method_27()
		{
			List<StatisticsManager.StatSheet> list = new List<StatisticsManager.StatSheet>();
			for (int i = 0; i < this.m_statsSheets.Count; i++)
			{
				if (!this.m_statsSheets[i].m_isTeam)
				{
					list.Add(this.m_statsSheets[i]);
				}
			}
			return list;
		}

		// Token: 0x06002362 RID: 9058 RVA: 0x000A8000 File Offset: 0x000A6200
		public int method_28()
		{
			int num = 0;
			for (int i = 0; i < this.m_statsSheets.Count; i++)
			{
				if (!this.m_statsSheets[i].m_isTeam)
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x06002363 RID: 9059 RVA: 0x000A8040 File Offset: 0x000A6240
		public int method_29()
		{
			HashSet<int> hashSet = new HashSet<int>();
			for (int i = 0; i < this.m_statsSheets.Count; i++)
			{
				if (!this.m_statsSheets[i].m_isTeam)
				{
					hashSet.Add(this.m_statsSheets[i].m_teamId);
				}
			}
			return hashSet.Count;
		}

		// Token: 0x06002364 RID: 9060 RVA: 0x000A809C File Offset: 0x000A629C
		public int method_30(PlayerInfoSync playerInfoSync_0, PlayerInfoSync playerInfoSync_1)
		{
			StatisticsManager.StatSheet personalStatSheet = this.GetPersonalStatSheet(playerInfoSync_0);
			StatisticsManager.StatSheet personalStatSheet2 = this.GetPersonalStatSheet(playerInfoSync_1);
			return this.method_31(personalStatSheet, personalStatSheet2);
		}

		// Token: 0x06002365 RID: 9061 RVA: 0x000A80C4 File Offset: 0x000A62C4
		public int method_31(StatisticsManager.StatSheet statSheet_0, StatisticsManager.StatSheet statSheet_1)
		{
			if (statSheet_0 == null || statSheet_1 == null)
			{
				return 0;
			}
			if (statSheet_0.m_killCount != statSheet_1.m_killCount)
			{
				return statSheet_1.m_killCount - statSheet_0.m_killCount;
			}
			if (statSheet_0.m_deathcount != statSheet_1.m_deathcount)
			{
				return statSheet_0.m_deathcount - statSheet_1.m_deathcount;
			}
			if (statSheet_0.m_score != statSheet_1.m_score)
			{
				return statSheet_1.m_score - statSheet_0.m_score;
			}
			return -statSheet_0.m_lastKillTime.CompareTo(statSheet_1.m_lastKillTime);
		}

		// Token: 0x06002366 RID: 9062 RVA: 0x000A8140 File Offset: 0x000A6340
		public float method_32(int int_0)
		{
			if (!this.method_4())
			{
				return 0.5f;
			}
			float num = 0f;
			if (int_0 == 1)
			{
				num = this.m_claptrap2TeamADis;
			}
			else if (int_0 == 2)
			{
				num = this.m_claptrap2TeamBDis;
			}
			if (this.m_claptrap2TeamADis <= 0f && this.m_claptrap2TeamBDis <= 0f)
			{
				return 0.5f;
			}
			return num / (this.m_claptrap2TeamADis + this.m_claptrap2TeamBDis);
		}

		// Token: 0x040017DD RID: 6109
		public string m_instanceName;

		// Token: 0x040017DE RID: 6110
		public string m_mapName;

		// Token: 0x040017DF RID: 6111
		public int m_playlistId;

		// Token: 0x040017E0 RID: 6112
		public ELevelDifficulty m_difficulty;

		// Token: 0x040017E1 RID: 6113
		public List<StatisticsManager.StatSheet> m_statsSheets = new List<StatisticsManager.StatSheet>();

		// Token: 0x040017E2 RID: 6114
		public int m_sessionLevelRange;

		// Token: 0x040017E3 RID: 6115
		public int m_timeLimit;

		// Token: 0x040017E4 RID: 6116
		public int m_endScore;

		// Token: 0x040017E5 RID: 6117
		public int m_endKillCount;

		// Token: 0x040017E6 RID: 6118
		public float m_duration;

		// Token: 0x040017E7 RID: 6119
		public int m_round;

		// Token: 0x040017E8 RID: 6120
		public int m_claptrapTeamID;

		// Token: 0x040017E9 RID: 6121
		public int m_claptrapScore;

		// Token: 0x040017EA RID: 6122
		public float m_claptrap2TeamADis;

		// Token: 0x040017EB RID: 6123
		public float m_claptrap2TeamBDis;

		// Token: 0x040017EC RID: 6124
		public string m_gameModeName;
	}

	// Token: 0x02000562 RID: 1378
	public class StatSheet
	{
		public enum KillType
		{
			Normal,
			Critical,
			HeadShot
		}

		public bool m_isTeam;

		public int m_id;

		public int m_teamId;

		public string m_name;

		public int m_level;

		public int m_lastKillerForRevenge;

		public int[] m_lastDamager;

		public bool m_isEnergyConsumed;

		public bool m_isFail;

		public int m_score;

		public int m_goalPoint;

		public int m_killCount;

		public int m_criticalKillCount;

		public int m_deathcount;

		public int m_totalDamage;

		public int m_criticalDamage;

		public int m_attackDamage;

		public int m_badassKill;

		public int m_bossKill;

		public int m_hitNumber;

		public int m_criticalHitNumber;

		public int m_sameVictimCount;

		public int m_meleeKillCount;

		public int m_grenadeKillCount;

		public int m_headshotKillCount;

		public int m_skillCount;

		public int m_nemesisCount;

		public Dictionary<AvatarType, Hashtable> m_skillKills;

		public Dictionary<WeaponType, Hashtable> m_weaponKills;

		public Dictionary<string, int> m_rivalTable;

		public int m_extraExp;

		public int m_extraMoney;

		public int m_honorValue;

		public int m_guildExp;

		public int m_killStreak;

		public int m_criticalKillStreak;

		public int m_deathStreak;

		public PingQuality m_ping;

		public float m_lastDamageTime;

		public float m_livingInterval;

		public float m_flyingInterval;

		public Vector3 m_lastPos;

		public float m_lastKillTime;

		public float[] m_last4KillTimes;

		public int m_lastKillTimeIndex;

		public float m_SmgUsage;

		public float m_SniperUsage;

		public float m_ShotgunUsage;

		public float m_PistolUsage;

		public float m_CombatRifleUsage;

		private float m_lastSwitchTime;

		public StatSheet()
		{
			Reset(string.Empty);
		}

		public InstanceGrade method_0(SessionStats sessionStats_0)
		{
			if (m_isFail)
			{
				return InstanceGrade.F;
			}
			return ns0.MonoSingleton<ScoringManager>.Instance.method_18(sessionStats_0, this);
		}

		public void Reset(string name)
		{
			DebugUtils.Log(LogCategory.Stats, "StatSheet Reset [" + name + "]");
			m_name = name;
			m_lastKillerForRevenge = 0;
			m_lastDamager = new int[2];
			int[] lastDamager = m_lastDamager;
			m_lastDamager[1] = 0;
			lastDamager[0] = 0;
			m_isEnergyConsumed = false;
			m_isFail = false;
			m_score = 0;
			m_goalPoint = 0;
			m_killCount = 0;
			m_criticalKillCount = 0;
			m_meleeKillCount = 0;
			m_nemesisCount = 0;
			m_grenadeKillCount = 0;
			m_headshotKillCount = 0;
			m_skillCount = 0;
			m_skillKills = new Dictionary<AvatarType, Hashtable>();
			for (int i = 0; i < Enum.GetValues(typeof(AvatarType)).Length; i++)
			{
				m_skillKills.Add((AvatarType)i, new Hashtable());
				m_skillKills[(AvatarType)i].Add(0, 0);
				m_skillKills[(AvatarType)i].Add(1, 0);
			}
			m_weaponKills = new Dictionary<WeaponType, Hashtable>();
			for (int j = 0; j < Enum.GetValues(typeof(WeaponType)).Length; j++)
			{
				m_weaponKills.Add((WeaponType)j, new Hashtable());
				m_weaponKills[(WeaponType)j].Add(0, 0);
				m_weaponKills[(WeaponType)j].Add(1, 0);
				m_weaponKills[(WeaponType)j].Add(2, 0);
			}
			m_rivalTable = new Dictionary<string, int>();
			m_deathcount = 0;
			m_totalDamage = 0;
			m_criticalDamage = 0;
			m_attackDamage = 0;
			m_badassKill = 0;
			m_bossKill = 0;
			m_hitNumber = 0;
			m_criticalHitNumber = 0;
			m_sameVictimCount = 0;
			m_extraExp = 0;
			m_extraMoney = 0;
			m_honorValue = 0;
			m_guildExp = 0;
			m_killStreak = 0;
			m_criticalKillStreak = 0;
			m_deathStreak = 0;
			m_livingInterval = 0f;
			m_flyingInterval = 0f;
			m_lastPos = Vector3.zero;
			m_lastKillTime = 0f;
			m_last4KillTimes = new float[4];
			m_lastKillTimeIndex = -1;
			m_SmgUsage = 0f;
			m_SniperUsage = 0f;
			m_ShotgunUsage = 0f;
			m_PistolUsage = 0f;
			m_CombatRifleUsage = 0f;
			m_lastSwitchTime = Time.time;
		}

		public string method_1()
		{
			string result = string.Empty;
			int num = 0;
			Dictionary<string, int>.Enumerator enumerator = m_rivalTable.GetEnumerator();
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.Value >= num)
				{
					result = enumerator.Current.Key;
					num = enumerator.Current.Value;
				}
			}
			return result;
		}

		public void SetPingQuality(float float_0)
		{
			if (float_0 <= 100f)
			{
				m_ping = PingQuality.High;
			}
			else if (float_0 <= 300f)
			{
				m_ping = PingQuality.Medium;
			}
			else
			{
				m_ping = PingQuality.Low;
			}
		}

		public void method_3(bool bool_0)
		{
			if (bool_0)
			{
				EntityWeapon entityWeapon = ((!(ns0.MonoSingleton<Session>.Instance.GetLocalPlayer().GetEntity() != null)) ? null : ns0.MonoSingleton<Session>.Instance.GetLocalPlayer().GetEntity().vmethod_16());
				if ((bool)entityWeapon)
				{
					method_4(entityWeapon.method_99());
				}
			}
			else
			{
				m_lastSwitchTime = Time.time;
			}
		}

		public void method_4(WeaponType weaponType_0)
		{
			float time = Time.time;
			switch (weaponType_0)
			{
			case WeaponType.SMG:
				m_SmgUsage += time - m_lastSwitchTime;
				break;
			case WeaponType.SniperRifle:
				m_SniperUsage += time - m_lastSwitchTime;
				break;
			case WeaponType.ShotGun:
				m_ShotgunUsage += time - m_lastSwitchTime;
				break;
			case WeaponType.RepeaterPistol:
				m_PistolUsage += time - m_lastSwitchTime;
				break;
			case WeaponType.CombatRifle:
				m_CombatRifleUsage += time - m_lastSwitchTime;
				break;
			}
			m_lastSwitchTime = time;
		}

		public void method_5()
		{
			m_isFail = true;
		}

		public void method_6()
		{
			m_isEnergyConsumed = true;
		}

		public void method_7(KillContext killContext_0)
		{
			if (killContext_0.m_killer != null)
			{
				m_lastKillerForRevenge = killContext_0.m_killer.vmethod_0();
			}
			m_deathcount++;
			m_deathStreak++;
			m_killStreak = 0;
			m_criticalKillStreak = 0;
			m_livingInterval = 0f;
			int value = 0;
			if (!m_rivalTable.TryGetValue(killContext_0.m_killer.m_name, out value))
			{
				m_rivalTable.Add(killContext_0.m_killer.m_name, 0);
			}
			Dictionary<string, int> rivalTable;
			Dictionary<string, int> dictionary = (rivalTable = m_rivalTable);
			string name;
			string key = (name = killContext_0.m_killer.m_name);
			int num = rivalTable[name];
			dictionary[key] = num + 1;
		}

		public void method_8(int int_0)
		{
			m_extraExp += int_0;
		}

		public void method_9(DamageContext damageContext_0)
		{
			bool flag = damageContext_0.m_strengthType == WeakPoint.StrengthType.VeryWeak;
			if (AttackInfo.smethod_0(damageContext_0.m_subType) == AttackInfo.AttackType.Projectile)
			{
				m_hitNumber++;
				if (flag)
				{
					m_criticalHitNumber++;
				}
			}
			m_totalDamage += damageContext_0.m_damageInfo.m_healthDamagePoints;
			if (flag)
			{
				m_criticalDamage += damageContext_0.m_damageInfo.m_healthDamagePoints;
			}
		}

		public void method_10(DamageContext damageContext_0)
		{
			if (damageContext_0.m_killer != null)
			{
				int num = damageContext_0.m_killer.vmethod_0();
				if (num != m_lastDamager[1])
				{
					m_lastDamager[0] = m_lastDamager[1];
					m_lastDamager[1] = num;
					m_lastDamageTime = Time.time;
				}
			}
			else
			{
				int[] lastDamager = m_lastDamager;
				m_lastDamager[1] = 0;
				lastDamager[0] = 0;
			}
		}

		public void method_11(DamageContext damageContext_0)
		{
			m_attackDamage += damageContext_0.m_damageInfo.m_healthDamagePoints;
		}

		public float method_12(int int_0)
		{
			if (m_last4KillTimes == null)
			{
				return 0f;
			}
			if (int_0 > m_last4KillTimes.Length - 1)
			{
				return 0f;
			}
			if (m_lastKillTimeIndex >= 0 && m_lastKillTimeIndex < m_last4KillTimes.Length)
			{
				int num = (m_lastKillTimeIndex - int_0 + m_last4KillTimes.Length) % m_last4KillTimes.Length;
				if (num >= 0 && num < m_last4KillTimes.Length)
				{
					return m_last4KillTimes[m_lastKillTimeIndex] - m_last4KillTimes[num];
				}
				return 0f;
			}
			return 0f;
		}

		public void method_13()
		{
			m_lastKillTimeIndex = -1;
		}

		public void method_14(WeaponType weaponType_0, KillType killType_0)
		{
			DebugUtils.Log(LogCategory.Gamelogic, string.Concat("StatSheet.AddWeaponKill[", weaponType_0, "][", killType_0, "]"));
			int num = (int)m_weaponKills[weaponType_0][(int)killType_0];
			m_weaponKills[weaponType_0][(int)killType_0] = num + 1;
		}

		public void method_15(AvatarType avatarType_0)
		{
			int num = (int)m_skillKills[avatarType_0][1];
			m_skillKills[avatarType_0][1] = num + 1;
			m_skillCount++;
		}

		public void method_16(AvatarType avatarType_0)
		{
			int num = (int)m_skillKills[avatarType_0][0];
			m_skillKills[avatarType_0][0] = num + 1;
		}

		public void method_17(KillContext killContext_0)
		{
			if (killContext_0.m_killer == killContext_0.m_victim)
			{
				return;
			}
			m_lastKillTime = Time.time;
			m_lastKillTimeIndex = (m_lastKillTimeIndex + 1) % m_last4KillTimes.Length;
			m_last4KillTimes[m_lastKillTimeIndex] = Time.time;
			int num = ((killContext_0.m_strengthType == WeakPoint.StrengthType.VeryWeak) ? 1 : 0);
			m_killCount++;
			m_criticalKillCount += num;
			m_deathStreak = 0;
			m_killStreak++;
			m_criticalKillStreak += num;
			EntityNpc entityNpc = killContext_0.m_victim as EntityNpc;
			if (entityNpc != null)
			{
				if (entityNpc.method_18())
				{
					m_bossKill++;
				}
				else if (entityNpc.method_17())
				{
					m_badassKill++;
				}
			}
		}
	}
}
