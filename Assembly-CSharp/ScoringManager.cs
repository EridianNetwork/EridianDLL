using System;
using System.Collections.Generic;
using ns0;
using XsdSettings;

// Token: 0x02000538 RID: 1336
public class ScoringManager : MonoSingleton<ScoringManager>, IDamageListener
{
	// Token: 0x06002266 RID: 8806 RVA: 0x00017A3F File Offset: 0x00015C3F
	public void method_0(StatisticsManager.SessionStats sessionStats_0)
	{
		this.m_scoringRule.imethod_6(sessionStats_0);
	}

	// Token: 0x06002267 RID: 8807 RVA: 0x000A3540 File Offset: 0x000A1740
	public void method_1()
	{
		if (MonoSingleton<Session>.Instance.method_6() == "GameModePvP")
		{
			this.m_scoringRule = new DeathmatchScoringRule();
		}
		else if (MonoSingleton<Session>.Instance.method_6() == "GamemodeTeamDeathmatch")
		{
			this.m_scoringRule = new TeamDeathmatchScoringRule();
		}
		else if (MonoSingleton<Session>.Instance.method_6() == "GamemodeClaptrapSoccer")
		{
			this.m_scoringRule = new ClaptrapSoccerScoringRule();
		}
		else
		{
			this.m_scoringRule = new DefaultScoringRule();
		}
		this.m_scoringRule.imethod_0();
	}

	// Token: 0x06002268 RID: 8808 RVA: 0x00017A4D File Offset: 0x00015C4D
	public void method_2()
	{
		this.m_scoringRule.OnUpdateMatch();
	}

	// Token: 0x06002269 RID: 8809 RVA: 0x000A35CC File Offset: 0x000A17CC
	public void method_3()
	{
		List<PlayerInfoSync> list;
		MonoSingleton<Session>.Instance.method_38(out list);
		for (int i = 0; i < list.Count; i++)
		{
			StatisticsManager.StatSheet personalStatSheet = MonoSingleton<StatisticsManager>.Instance.GetCurrentSession().GetPersonalStatSheet(list[i]);
			if (personalStatSheet != null)
			{
				personalStatSheet.method_5();
			}
		}
	}

	// Token: 0x0600226A RID: 8810 RVA: 0x000A3618 File Offset: 0x000A1818
	public void method_4()
	{
		List<PlayerInfoSync> list;
		MonoSingleton<Session>.Instance.method_38(out list);
		for (int i = 0; i < list.Count; i++)
		{
			StatisticsManager.StatSheet personalStatSheet = MonoSingleton<StatisticsManager>.Instance.GetCurrentSession().GetPersonalStatSheet(list[i]);
			if (personalStatSheet != null && personalStatSheet.m_attackDamage == 0 && personalStatSheet.m_goalPoint == 0)
			{
				personalStatSheet.method_5();
			}
		}
	}

	// Token: 0x0600226B RID: 8811 RVA: 0x00017A5A File Offset: 0x00015C5A
	public void method_5()
	{
		this.m_scoringRule.OnEndMatch();
	}

	// Token: 0x0600226C RID: 8812 RVA: 0x00017A67 File Offset: 0x00015C67
	public void method_6()
	{
		this.m_scoringRule.OnEndMatch();
		this.m_scoringRule = new DefaultScoringRule();
	}

	// Token: 0x0600226D RID: 8813 RVA: 0x00017A7F File Offset: 0x00015C7F
	public int method_7(ScoringActionType scoringActionType_0, Entity entity_0, Entity entity_1)
	{
		return this.m_scoringRule.imethod_1(scoringActionType_0, entity_0, entity_1);
	}

	// Token: 0x0600226E RID: 8814 RVA: 0x00017A8F File Offset: 0x00015C8F
	public int method_8()
	{
		return MonoSingleton<StatisticsManager>.Instance.GetCurrentSession().method_16();
	}

	// Token: 0x0600226F RID: 8815 RVA: 0x00017AA0 File Offset: 0x00015CA0
	public int method_9()
	{
		return MonoSingleton<StatisticsManager>.Instance.GetCurrentSession().method_24();
	}

	// Token: 0x06002270 RID: 8816 RVA: 0x00017AB1 File Offset: 0x00015CB1
	public int method_10(int int_0)
	{
		return MonoSingleton<StatisticsManager>.Instance.GetCurrentSession().method_25(int_0);
	}

	// Token: 0x06002271 RID: 8817 RVA: 0x00017AC3 File Offset: 0x00015CC3
	public int method_11(PlayerInfoSync playerInfoSync_0)
	{
		return MonoSingleton<StatisticsManager>.Instance.GetCurrentSession().method_26(playerInfoSync_0);
	}

	// Token: 0x06002272 RID: 8818 RVA: 0x00017AD5 File Offset: 0x00015CD5
	public void method_12(int int_0)
	{
		this.m_scoringRule.imethod_2(int_0);
	}

	// Token: 0x06002273 RID: 8819 RVA: 0x00017AE3 File Offset: 0x00015CE3
	public void method_13(Entity entity_0)
	{
		this.m_scoringRule.imethod_3(entity_0);
	}

	// Token: 0x06002274 RID: 8820 RVA: 0x000A3674 File Offset: 0x000A1874
	public void OnDamaged(DamageContext context)
	{
		this.m_scoringRule.OnDamagedPreStat(context);
		if (context.m_killer != null)
		{
			PlayerInfoSync playerInfoSync = context.m_killer.vmethod_25();
			if (playerInfoSync)
			{
				StatisticsManager.StatSheet personalStatSheet = MonoSingleton<StatisticsManager>.Instance.GetCurrentSession().GetPersonalStatSheet(playerInfoSync);
				if (personalStatSheet != null)
				{
					personalStatSheet.method_9(context);
					personalStatSheet.method_11(context);
				}
			}
		}
		if (context.m_victim != null)
		{
			PlayerInfoSync playerInfoSync2 = context.m_victim.vmethod_25();
			if (playerInfoSync2)
			{
				StatisticsManager.StatSheet personalStatSheet2 = MonoSingleton<StatisticsManager>.Instance.GetCurrentSession().GetPersonalStatSheet(playerInfoSync2);
				if (personalStatSheet2 != null)
				{
					personalStatSheet2.method_10(context);
					personalStatSheet2.method_9(context);
				}
			}
		}
		this.m_scoringRule.OnDamagedPostStat(context);
	}

	// Token: 0x06002275 RID: 8821 RVA: 0x000A3728 File Offset: 0x000A1928
	public void OnEntityKill(KillContext context)
	{
		if (this.m_scoringRule == null)
		{
			return;
		}
		EntityPlayer entityPlayer = context.m_victim as EntityPlayer;
		if (entityPlayer != null && !entityPlayer.method_152())
		{
			return;
		}
		if (context.m_victim.vmethod_8() == Entity.EntityType.Npc)
		{
			EntityNpc entityNpc = context.m_victim as EntityNpc;
			if (entityNpc.m_subType == EntityNpc.EntitySubType.CHR_SoldierTurretBasic)
			{
				return;
			}
		}
		this.m_scoringRule.OnEntityKillPreStat(context);
		StatisticsManager.SessionStats currentSession = MonoSingleton<StatisticsManager>.Instance.GetCurrentSession();
		if (currentSession == null)
		{
			return;
		}
		if (context.m_killer != context.m_victim)
		{
			currentSession.method_2();
		}
		if (context.m_killer != null)
		{
			PlayerInfoSync playerInfoSync = context.m_killer.vmethod_25();
			if (playerInfoSync)
			{
				StatisticsManager.StatSheet personalStatSheet = currentSession.GetPersonalStatSheet(playerInfoSync);
				if (personalStatSheet != null)
				{
					personalStatSheet.method_17(context);
					if (MonoSingleton<Session>.Instance.method_14())
					{
						StatisticsManager.StatSheet statSheet = currentSession.method_9(playerInfoSync.m_teamID);
						if (statSheet != null)
						{
							statSheet.method_17(context);
						}
					}
				}
			}
		}
		if (context.m_victim != null && context.m_killer != null)
		{
			PlayerInfoSync playerInfoSync2 = context.m_victim.vmethod_25();
			if (playerInfoSync2)
			{
				StatisticsManager.StatSheet personalStatSheet2 = currentSession.GetPersonalStatSheet(playerInfoSync2);
				if (personalStatSheet2 != null)
				{
					personalStatSheet2.method_7(context);
				}
				if (MonoSingleton<Session>.Instance.method_14())
				{
					StatisticsManager.StatSheet statSheet2 = currentSession.method_9(playerInfoSync2.m_teamID);
					if (statSheet2 != null)
					{
						statSheet2.method_7(context);
					}
				}
			}
		}
		this.m_scoringRule.OnEntityKillPostStat(context);
	}

	// Token: 0x06002276 RID: 8822 RVA: 0x000A3898 File Offset: 0x000A1A98
	public void method_14(int int_0, bool bool_0, int int_1)
	{
		StatisticsManager.SessionStats currentSession = MonoSingleton<StatisticsManager>.Instance.GetCurrentSession();
		if (currentSession == null)
		{
			return;
		}
		StatisticsManager.StatSheet statSheetById = currentSession.GetStatSheetById(int_0, bool_0);
		if (statSheetById == null)
		{
			return;
		}
		statSheetById.m_score += int_1;
	}

	// Token: 0x06002277 RID: 8823 RVA: 0x000A38D0 File Offset: 0x000A1AD0
	public void method_15(int int_0, int int_1)
	{
		StatisticsManager.SessionStats currentSession = MonoSingleton<StatisticsManager>.Instance.GetCurrentSession();
		if (currentSession == null)
		{
			return;
		}
		StatisticsManager.StatSheet statSheetById = currentSession.GetStatSheetById(int_0, false);
		if (statSheetById == null)
		{
			return;
		}
		statSheetById.m_goalPoint += int_1;
	}

	// Token: 0x06002278 RID: 8824 RVA: 0x00017AF1 File Offset: 0x00015CF1
	public int method_16(EntityNpc.EntityNpcRank entityNpcRank_0)
	{
		return this.m_scoringRule.imethod_5(entityNpcRank_0);
	}

	// Token: 0x06002279 RID: 8825 RVA: 0x000A3908 File Offset: 0x000A1B08
	public bool method_17(PlayerInfoSync playerInfoSync_0)
	{
		if (MonoSingleton<StatisticsManager>.Instance == null)
		{
			return false;
		}
		if (playerInfoSync_0 == null)
		{
			return false;
		}
		StatisticsManager.SessionStats sessionStats = MonoSingleton<StatisticsManager>.Instance.method_5();
		if (sessionStats == null)
		{
			return false;
		}
		if (sessionStats.method_29() < 2)
		{
			return true;
		}
		GamemodeType gamemodeType = MatchmakingService.smethod_0(MatchmakingService.MatchmakingService_0.method_1(sessionStats.m_playlistId).m_gameMode);
		if (gamemodeType != GamemodeType.GamemodeClaptrapSoccer)
		{
			if (gamemodeType != GamemodeType.GamemodeTeamDeathmatch)
			{
				StatisticsManager.StatSheet personalStatSheet = sessionStats.GetPersonalStatSheet(playerInfoSync_0);
				if (personalStatSheet != null && personalStatSheet.m_killCount != 0)
				{
					int num = sessionStats.method_26(playerInfoSync_0);
					return num == 1;
				}
				return false;
			}
		}
		int teamID = playerInfoSync_0.m_teamID;
		int num2 = ((teamID != 1) ? 1 : 2);
		StatisticsManager.StatSheet statSheet = sessionStats.method_9(teamID);
		StatisticsManager.StatSheet statSheet2 = sessionStats.method_9(num2);
		if (gamemodeType == GamemodeType.GamemodeClaptrapSoccer)
		{
			return statSheet.m_score > statSheet2.m_score;
		}
		if (statSheet.m_killCount == 0 && statSheet2.m_killCount == 0)
		{
			return false;
		}
		if (statSheet.m_killCount != statSheet2.m_killCount)
		{
			return statSheet.m_killCount > statSheet2.m_killCount;
		}
		if (statSheet.m_deathcount != statSheet2.m_deathcount)
		{
			return statSheet.m_deathcount < statSheet2.m_deathcount;
		}
		if (statSheet.m_score != statSheet2.m_score)
		{
			return statSheet.m_score > statSheet2.m_score;
		}
		return statSheet.m_lastKillTime > statSheet2.m_lastKillTime;
	}

	// Token: 0x0600227A RID: 8826 RVA: 0x00017AFF File Offset: 0x00015CFF
	public void OnPickedUp(EntityPlayer picker, EntityObject item)
	{
		if (this.m_scoringRule != null)
		{
			this.m_scoringRule.OnPickedUp(picker, item);
		}
	}

	// Token: 0x0600227B RID: 8827 RVA: 0x00017B16 File Offset: 0x00015D16
	public InstanceGrade method_18(StatisticsManager.SessionStats sessionStats_0, StatisticsManager.StatSheet statSheet_0)
	{
		if (this.m_scoringRule != null)
		{
			return this.m_scoringRule.imethod_4(sessionStats_0, statSheet_0);
		}
		return InstanceGrade.F;
	}

	// Token: 0x040016DF RID: 5855
	private ScoringRule m_scoringRule = new DefaultScoringRule();
}
