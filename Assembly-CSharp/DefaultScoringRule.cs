using System;
using System.Collections.Generic;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x020003F8 RID: 1016
public class DefaultScoringRule : GeneralScoringRule
{
	// Token: 0x060019AE RID: 6574 RVA: 0x00013131 File Offset: 0x00011331
	public override void imethod_0()
	{
		this.m_scoringSettings = "Settings/ScoringPVE";
		base.imethod_0();
	}

	// Token: 0x060019AF RID: 6575 RVA: 0x00085DC4 File Offset: 0x00083FC4
	private void method_2(StatisticsManager.SessionStats sessionStats_0)
	{
		if (sessionStats_0 == null)
		{
			return;
		}
		List<PlayerInfoSync> list;
		MonoSingleton<Session>.Instance.method_38(out list);
		for (int i = 0; i < list.Count; i++)
		{
			StatisticsManager.StatSheet personalStatSheet = sessionStats_0.GetPersonalStatSheet(list[i]);
			Playlist playlist = MatchmakingService.MatchmakingService_0.method_1(sessionStats_0.m_playlistId);
			int num = 1;
			float num2 = 1f;
			switch (sessionStats_0.m_difficulty)
			{
			case ELevelDifficulty.Normal:
				num = playlist.m_normal_Exp;
				num2 = this.method_4(playlist.m_normal_LevelMin, personalStatSheet.m_level);
				break;
			case ELevelDifficulty.Hard:
				num = playlist.m_hard_Exp;
				num2 = this.method_4(playlist.m_hard_LevelMin, personalStatSheet.m_level);
				break;
			case ELevelDifficulty.Hell:
				num = playlist.m_hell_Exp;
				num2 = this.method_4(playlist.m_hell_LevelMin, personalStatSheet.m_level);
				break;
			}
			int num3 = (int)((float)num * num2 * this.vmethod_0(sessionStats_0, personalStatSheet, false));
			personalStatSheet.method_8(num3);
		}
	}

	// Token: 0x060019B0 RID: 6576 RVA: 0x00085EB4 File Offset: 0x000840B4
	private void method_3(StatisticsManager.SessionStats sessionStats_0)
	{
		if (sessionStats_0 == null)
		{
			return;
		}
		PvEGuildExpFactorDataList pvEGuildExpFactorDataList = ns0.MonoSingleton<GuildProgressionSetting>.Instance.method_1();
		ns0.MonoSingleton<Session>.Instance.method_38(out var list_);
		for (int i = 0; i < list_.Count; i++)
		{
			StatisticsManager.StatSheet personalStatSheet = sessionStats_0.GetPersonalStatSheet(list_[i]);
			InstanceGrade instanceGrade = personalStatSheet.method_0(sessionStats_0);
			if (instanceGrade == InstanceGrade.F)
			{
				personalStatSheet.m_guildExp = 0;
				continue;
			}
			int num = 0;
			for (int j = 0; j < pvEGuildExpFactorDataList.m_playtimeFactors.Length; j++)
			{
				if (sessionStats_0.m_duration > (float)(pvEGuildExpFactorDataList.m_playtimeFactors[j].m_minTime * 60) && !(sessionStats_0.m_duration > (float)(pvEGuildExpFactorDataList.m_playtimeFactors[j].m_maxTime * 60)))
				{
					num = pvEGuildExpFactorDataList.m_playtimeFactors[j].m_expValue;
					break;
				}
			}
			int num2 = 0;
			int num3 = (int)instanceGrade;
			if (num3 < pvEGuildExpFactorDataList.m_scoreFactors.Length)
			{
				num2 = pvEGuildExpFactorDataList.m_scoreFactors[num3].m_expValue;
			}
			int num4 = 0;
			int difficulty = (int)sessionStats_0.m_difficulty;
			if (difficulty - 1 >= 0 && difficulty - 1 < pvEGuildExpFactorDataList.m_difficultyFactors.Length)
			{
				num4 = pvEGuildExpFactorDataList.m_difficultyFactors[difficulty - 1].m_expValue;
			}
			float num5 = num + num2 + num4;
			num5 *= AntiAddiction.smethod_0(list_[i].m_antiAddictionLevel);
			personalStatSheet.m_guildExp += (int)num5;
		}
	}
	// Token: 0x060019B1 RID: 6577 RVA: 0x00086004 File Offset: 0x00084204
	protected override float vmethod_0(StatisticsManager.SessionStats sessionStats_0, StatisticsManager.StatSheet statSheet_0, bool bool_0)
	{
		ScoringSetupPVE scoringSetupPVE = this.m_scoreSetup.m_ScoringSetup as ScoringSetupPVE;
		if (scoringSetupPVE != null)
		{
			float num = 1f;
			int num2 = (int)statSheet_0.method_0(sessionStats_0);
			if (num2 < scoringSetupPVE.m_performanceRankBonus.Length)
			{
				ELevelDifficulty difficulty = sessionStats_0.m_difficulty;
				PerformanceRankPVE performanceRankPVE = null;
				switch (difficulty)
				{
				case ELevelDifficulty.Normal:
					performanceRankPVE = scoringSetupPVE.m_performanceRankBonus[num2].m_performanceRankNormal;
					break;
				case ELevelDifficulty.Hard:
					performanceRankPVE = scoringSetupPVE.m_performanceRankBonus[num2].m_performanceRankHard;
					break;
				case ELevelDifficulty.Hell:
					performanceRankPVE = scoringSetupPVE.m_performanceRankBonus[num2].m_performanceRankHell;
					break;
				}
				if (performanceRankPVE != null)
				{
					num = ((!bool_0) ? performanceRankPVE.m_EXPBonus : performanceRankPVE.m_softCurrencyBonus);
				}
			}
			return num;
		}
		return 1f;
	}

	// Token: 0x060019B2 RID: 6578 RVA: 0x000860B4 File Offset: 0x000842B4
	private float method_4(int int_0, int int_1)
	{
		ScoringSetupPVE scoringSetupPVE = this.m_scoreSetup.m_ScoringSetup as ScoringSetupPVE;
		if (scoringSetupPVE != null)
		{
			int num = Mathf.Abs(int_0 - int_1);
			for (int i = 0; i < scoringSetupPVE.m_levelAdjustments.Length - 1; i++)
			{
				if (num <= scoringSetupPVE.m_levelAdjustments[i].m_instanceCharacterLevelDiff)
				{
					return scoringSetupPVE.m_levelAdjustments[i].m_modifier;
				}
			}
			return scoringSetupPVE.m_levelAdjustments[scoringSetupPVE.m_levelAdjustments.Length - 1].m_modifier;
		}
		return 1f;
	}

	// Token: 0x060019B3 RID: 6579 RVA: 0x00086130 File Offset: 0x00084330
	public override int imethod_5(EntityNpc.EntityNpcRank entityNpcRank_0)
	{
		int num = 0;
		if (this.m_scoreSetup != null && this.m_scoreSetup.m_ScoringSetup != null)
		{
			ScoringSetupPVE scoringSetupPVE = this.m_scoreSetup.m_ScoringSetup as ScoringSetupPVE;
			if (scoringSetupPVE != null)
			{
				int num2 = Convert.ToInt32(entityNpcRank_0);
				if (num2 < scoringSetupPVE.m_killScores.Length)
				{
					num = scoringSetupPVE.m_killScores[num2].m_score;
				}
			}
		}
		return num;
	}

	// Token: 0x060019B4 RID: 6580 RVA: 0x00086190 File Offset: 0x00084390
	private float method_5()
	{
		ScoringSetupPVE scoringSetupPVE = this.m_scoreSetup.m_ScoringSetup as ScoringSetupPVE;
		if (scoringSetupPVE != null)
		{
			return scoringSetupPVE.m_timeScoreConversionRate;
		}
		return 1f;
	}

	// Token: 0x060019B5 RID: 6581 RVA: 0x000861C0 File Offset: 0x000843C0
	public override void imethod_6(StatisticsManager.SessionStats sessionStats_0)
	{
		double num = MonoSingleton<Session>.Instance.method_7().method_2();
		if (num < 0.0)
		{
			num = 0.0;
		}
		double num2 = num * (double)this.method_5();
		int num3 = 0;
		int num4 = 1;
		for (int i = 0; i < sessionStats_0.m_statsSheets.Count; i++)
		{
			StatisticsManager.StatSheet statSheet = sessionStats_0.m_statsSheets[i];
			num3 += statSheet.m_score;
			if (statSheet.m_totalDamage > num4)
			{
				num4 = statSheet.m_totalDamage;
			}
		}
		for (int j = 0; j < sessionStats_0.m_statsSheets.Count; j++)
		{
			StatisticsManager.StatSheet statSheet2 = sessionStats_0.m_statsSheets[j];
			float num5 = (float)(statSheet2.m_totalDamage / num4);
			statSheet2.m_score = (int)((num2 + (double)num3) * (double)num5);
		}
		base.method_0(sessionStats_0);
		this.method_2(sessionStats_0);
		this.method_3(sessionStats_0);
	}

	// Token: 0x060019B6 RID: 6582 RVA: 0x000862A0 File Offset: 0x000844A0
	public override InstanceGrade imethod_4(StatisticsManager.SessionStats sessionStats_0, StatisticsManager.StatSheet statSheet_0)
	{
		Playlist playlist = MatchmakingService.MatchmakingService_0.method_1(sessionStats_0.m_playlistId);
		TargetScoreGrade[] array = null;
		switch (sessionStats_0.m_difficulty)
		{
		case ELevelDifficulty.Normal:
			array = playlist.m_normal_targetScore;
			break;
		case ELevelDifficulty.Hard:
			array = playlist.m_hard_targetScore;
			break;
		case ELevelDifficulty.Hell:
			array = playlist.m_hell_targetScore;
			break;
		}
		if (array != null)
		{
			for (int i = 0; i < array.Length; i++)
			{
				if (statSheet_0.m_score >= array[i].m_score)
				{
					return (InstanceGrade)i;
				}
			}
		}
		return InstanceGrade.F;
	}
}
