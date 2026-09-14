using System;
using System.Collections.Generic;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x0200040D RID: 1037
public class TeamDeathmatchScoringRule : DeathmatchScoringRule
{
	// Token: 0x060019EA RID: 6634 RVA: 0x000865D0 File Offset: 0x000847D0
	public override void imethod_0()
	{
		if (!MonoSingleton<Session>.Instance.method_15())
		{
			this.m_scoringSettings = "Settings/ScoringTeamDeathmatch";
		}
		base.imethod_0();
		MonoSingleton<StatisticsManager>.Instance.GetCurrentSession().method_10(1);
		MonoSingleton<StatisticsManager>.Instance.GetCurrentSession().method_10(2);
	}

	// Token: 0x060019EB RID: 6635 RVA: 0x0008661C File Offset: 0x0008481C
	protected override void vmethod_1(EntityPlayer entityPlayer_0, Entity entity_0, Entity entity_1, AttackSubType attackSubType_0)
	{
		if (entityPlayer_0 == null)
		{
			return;
		}
		if (entity_0 != null && entity_1 != null)
		{
			PlayerInfoSync playerInfoSync = entityPlayer_0.vmethod_25();
			PlayerInfoSync playerInfoSync2 = entity_0.vmethod_25();
			PlayerInfoSync playerInfoSync3 = entity_1.vmethod_25();
			if (playerInfoSync != null && playerInfoSync2 != null && playerInfoSync3 != null)
			{
				EntityPlayer entityPlayer = entity_0 as EntityPlayer;
				EntityPlayer entityPlayer2 = entity_1 as EntityPlayer;
				if (entityPlayer != null && entityPlayer2 != null && entityPlayer.PlayerSkillManage_0 is HunterManage && MarkManager.MarkManager_0.m_titleCrl.method_1(entityPlayer2))
				{
					attackSubType_0 = EntityPlayer.smethod_1(attackSubType_0);
				}
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDPvPInfoView>().method_5(playerInfoSync2, playerInfoSync3, attackSubType_0, this.m_lastKillActions, playerInfoSync.IsMyActor());
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDPvPKillStampView>().method_3(playerInfoSync2.m_name, this.m_lastKillActions);
			}
		}
		int num = 0;
		for (int i = 0; i < this.m_lastKillActions.Count; i++)
		{
			int num2 = this.imethod_1(this.m_lastKillActions[i], entity_0, entity_1);
			num += num2;
		}
		if (!MonoSingleton<Session>.Instance.method_15())
		{
			MonoSingleton<ScoringManager>.Instance.method_14(entityPlayer_0.vmethod_25().m_teamID, true, num);
		}
		MonoSingleton<ScoringManager>.Instance.method_14(entityPlayer_0.vmethod_25().m_characterId, false, num);
		this.m_lastKillActions.Clear();
	}

	// Token: 0x060019EC RID: 6636 RVA: 0x00086798 File Offset: 0x00084998
	protected override void vmethod_3(StatisticsManager.SessionStats sessionStats_0)
	{
		if (sessionStats_0 == null)
		{
			return;
		}
		ScoringSetupPVP scoringSetupPVP = this.m_scoreSetup.m_ScoringSetup as ScoringSetupPVP;
		if (scoringSetupPVP != null)
		{
			List<PlayerInfoSync> list;
			MonoSingleton<Session>.Instance.method_38(out list);
			for (int i = 0; i < list.Count; i++)
			{
				StatisticsManager.StatSheet personalStatSheet = sessionStats_0.GetPersonalStatSheet(list[i]);
				int num = sessionStats_0.method_26(list[i]);
				num = Mathf.Max(num, 1);
				personalStatSheet.m_honorValue = scoringSetupPVP.m_honorStandardReward / num * (list.Count / 8) + ((!MonoSingleton<ScoringManager>.Instance.method_17(list[i])) ? 0 : scoringSetupPVP.m_honorWinBonus);
			}
		}
	}

	// Token: 0x060019ED RID: 6637 RVA: 0x00086838 File Offset: 0x00084A38
	public override void OnEndMatch()
	{
		base.OnEndMatch();
		StatisticsManager.SessionStats currentSession = MonoSingleton<StatisticsManager>.Instance.GetCurrentSession();
		if (currentSession == null)
		{
			return;
		}
		List<PlayerInfoSync> list;
		MonoSingleton<Session>.Instance.method_38(out list);
		if (list != null)
		{
			foreach (PlayerInfoSync playerInfoSync in list)
			{
				Entity entity = playerInfoSync.GetEntity();
				if (entity != null)
				{
					StatisticsManager.StatSheet personalStatSheet = currentSession.GetPersonalStatSheet(playerInfoSync);
					if (personalStatSheet != null)
					{
						if (personalStatSheet.m_killCount == 0 && MonoSingleton<ScoringManager>.Instance.method_17(playerInfoSync))
						{
							this.m_inGameActions.Add(ScoringActionType.BonusBloodlessVictory);
						}
						this.vmethod_2(entity as EntityPlayer, this.m_inGameActions);
					}
				}
			}
		}
	}
}
