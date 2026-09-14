using System;
using System.Collections.Generic;
using Core;
using ns0;
using XsdSettings;

// Token: 0x020003F5 RID: 1013
public class ClaptrapSoccerScoringRule : TeamDeathmatchScoringRule
{
	// Token: 0x0600197F RID: 6527 RVA: 0x00012FCF File Offset: 0x000111CF
	public override void imethod_0()
	{
		this.m_scoringSettings = "Settings/ScoringClaptrapSoccer";
		base.imethod_0();
	}

	// Token: 0x06001980 RID: 6528 RVA: 0x000848A4 File Offset: 0x00082AA4
	public override void OnEntityKillPostStat(KillContext context)
	{
		base.OnEntityKillPostStat(context);
		if (context.m_killer != null && context.m_victim != null)
		{
			EntityPlayer entityPlayer = context.m_victim as EntityPlayer;
			if (entityPlayer.m_claptrap != null)
			{
				this.m_lastKillActions.Add(ScoringActionType.BonusAssassination);
				this.vmethod_1(context.m_killer as EntityPlayer, context.m_killer, context.m_victim, context.m_subType);
			}
		}
	}

	// Token: 0x06001981 RID: 6529 RVA: 0x00012FE2 File Offset: 0x000111E2
	public override void OnPickedUp(EntityPlayer picker, EntityObject item)
	{
		if (picker != null && item != null && item.m_subType == EntityObject.EntitySubType.Claptrap)
		{
			this.m_inGameActions.Add(ScoringActionType.BonusDeliveryMan);
			this.vmethod_2(picker, this.m_inGameActions);
		}
	}

	// Token: 0x06001982 RID: 6530 RVA: 0x00084928 File Offset: 0x00082B28
	public override void OnEndMatch()
	{
		StatisticsManager.SessionStats currentSession = MonoSingleton<StatisticsManager>.Instance.GetCurrentSession();
		if (currentSession == null)
		{
			return;
		}
		int num = 1;
		if (1 == currentSession.m_claptrapTeamID)
		{
			num = 2;
		}
		StatisticsManager.StatSheet statSheet = currentSession.method_9(num);
		if (statSheet == null)
		{
			return;
		}
		statSheet.m_score += currentSession.m_claptrapScore;
		DebugUtils.Log(LogCategory.Gamelogic, "claptrapScore: " + currentSession.m_claptrapScore);
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
						if (personalStatSheet.m_teamId == num)
						{
							if (currentSession.m_claptrapScore == MonoSingleton<ClaptrapZone>.Instance.m_score)
							{
								this.m_inGameActions.Add(ScoringActionType.BonusWrongAddress);
							}
							else if (currentSession.m_claptrapScore == 3)
							{
								this.m_inGameActions.Add(ScoringActionType.BonusBigBang);
							}
						}
						this.vmethod_2(entity as EntityPlayer, this.m_inGameActions);
					}
				}
			}
		}
	}
}
