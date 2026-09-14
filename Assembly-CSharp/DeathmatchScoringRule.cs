using System;
using System.Collections.Generic;
using Core;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x020003F6 RID: 1014
public class DeathmatchScoringRule : GeneralScoringRule
{
	// Token: 0x06001984 RID: 6532 RVA: 0x0001304E File Offset: 0x0001124E
	public override void imethod_0()
	{
		if (!MonoSingleton<Session>.Instance.method_14() && !MonoSingleton<Session>.Instance.method_15())
		{
			this.m_scoringSettings = "Settings/ScoringDeathmatch";
		}
		base.imethod_0();
	}

	// Token: 0x06001985 RID: 6533 RVA: 0x0000311B File Offset: 0x0000131B
	public override void OnDamagedPreStat(DamageContext context)
	{
	}

	// Token: 0x06001986 RID: 6534 RVA: 0x0000311B File Offset: 0x0000131B
	public override void OnDamagedPostStat(DamageContext context)
	{
	}

	// Token: 0x06001987 RID: 6535 RVA: 0x00084A54 File Offset: 0x00082C54
	public override void OnEntityKillPreStat(KillContext context)
	{
		this.m_lastKillUnderDominationDelay = false;
		ScoringActionType scoringActionType = this.method_4(context);
		if (scoringActionType == ScoringActionType.BasicSuicide)
		{
			this.m_lastKillActions.Add(scoringActionType);
		}
		else
		{
			this.method_3(context);
			this.m_lastKillActions.Clear();
			this.m_lastKillActions.Add(scoringActionType);
			if (context.m_killer != null && context.m_victim != null)
			{
				PlayerInfoSync playerInfoSync = context.m_killer.vmethod_25();
				if (playerInfoSync)
				{
					StatisticsManager.SessionStats currentSession = MonoSingleton<StatisticsManager>.Instance.GetCurrentSession();
					if (currentSession == null)
					{
						return;
					}
					StatisticsManager.StatSheet personalStatSheet = currentSession.GetPersonalStatSheet(playerInfoSync);
					if (personalStatSheet == null)
					{
						DebugUtils.LogWarning(LogCategory.Gamelogic, "DeathmatchScoringRule:CheckAssist - missing stats for player[" + personalStatSheet.m_name + "]");
						return;
					}
					if (Time.time - personalStatSheet.m_lastKillTime <= 3f)
					{
						this.m_lastKillUnderDominationDelay = true;
					}
					PlayerInfoSync playerInfoSync2 = context.m_victim.vmethod_25();
					if (playerInfoSync2)
					{
						StatisticsManager.StatSheet personalStatSheet2 = currentSession.GetPersonalStatSheet(playerInfoSync2);
						if (personalStatSheet2 != null)
						{
							if (personalStatSheet2.m_lastKillerForRevenge == context.m_killer.vmethod_0())
							{
								if (++personalStatSheet2.m_sameVictimCount == 3)
								{
									this.m_lastKillActions.Add(ScoringActionType.BonusArchNemesis);
									personalStatSheet2.m_sameVictimCount = 0;
								}
							}
							else
							{
								personalStatSheet2.m_sameVictimCount = 1;
							}
						}
					}
				}
			}
		}
	}

	// Token: 0x06001988 RID: 6536 RVA: 0x00084BA0 File Offset: 0x00082DA0
	public override void OnEntityKillPostStat(KillContext context)
	{
		StatisticsManager.SessionStats currentSession = MonoSingleton<StatisticsManager>.Instance.GetCurrentSession();
		PlayerInfoSync playerInfoSync = null;
		StatisticsManager.StatSheet statSheet = null;
		StatisticsManager.StatSheet.KillType killType = StatisticsManager.StatSheet.KillType.Normal;
		if (context.m_killer != null)
		{
			playerInfoSync = context.m_killer.vmethod_25();
		}
		if (playerInfoSync)
		{
			statSheet = MonoSingleton<StatisticsManager>.Instance.GetCurrentSession().GetPersonalStatSheet(playerInfoSync);
		}
		if (currentSession.m_killCount == 1)
		{
			this.m_lastKillActions.Add(ScoringActionType.BonusFirstBlood);
		}
		if (context.m_partInfo == WeakPoint.PartInfo.Head)
		{
			this.m_lastKillActions.Add(ScoringActionType.BonusHeadShot);
			killType = StatisticsManager.StatSheet.KillType.HeadShot;
			statSheet.m_headshotKillCount++;
			this.method_2(statSheet.m_headshotKillCount, ScoringActionType.BonusSharpShooter, ScoringActionType.BonusHeadHunter);
		}
		else if (context.m_strengthType == WeakPoint.StrengthType.VeryWeak)
		{
			this.m_lastKillActions.Add(ScoringActionType.BonusCritical);
			killType = StatisticsManager.StatSheet.KillType.Critical;
		}
		if (AttackInfo.smethod_0(context.m_subType) == AttackInfo.AttackType.Melee)
		{
			this.m_lastKillActions.Add(ScoringActionType.BonusMelee);
			statSheet.m_meleeKillCount++;
			this.method_2(statSheet.m_meleeKillCount, ScoringActionType.BonusBucher, ScoringActionType.BonusBushido);
		}
		if (context.m_subType == AttackSubType.AreaGrenade)
		{
			statSheet.m_grenadeKillCount++;
			this.method_2(statSheet.m_grenadeKillCount, ScoringActionType.BonusShotPutter, ScoringActionType.BonusCatapult);
		}
		if (AttackInfo.smethod_0(context.m_subType) == AttackInfo.AttackType.Projectile && playerInfoSync != null)
		{
			Entity entity = playerInfoSync.GetEntity();
			if (entity != null)
			{
				EquipmentInventoryEntityPlayer equipmentInventoryEntityPlayer = entity.vmethod_19() as EquipmentInventoryEntityPlayer;
				if (equipmentInventoryEntityPlayer != null)
				{
					EntityWeapon entityWeapon = equipmentInventoryEntityPlayer.vmethod_27();
					if (entityWeapon != null)
					{
						statSheet.method_14(entityWeapon.method_99(), killType);
					}
				}
			}
		}
		if (context.m_killer != null && context.m_victim != null && context.m_victim.vmethod_0() != context.m_killer.vmethod_0() && statSheet != null)
		{
			if (statSheet.m_killStreak > 1)
			{
				if (statSheet.m_killStreak == 2)
				{
					this.m_lastKillActions.Add(ScoringActionType.BonusKillStreak);
				}
				else if (statSheet.m_killStreak == 3)
				{
					this.m_lastKillActions.Add(ScoringActionType.BonusNaturalbornKiller);
				}
				else if (statSheet.m_killStreak == 5)
				{
					this.m_lastKillActions.Add(ScoringActionType.BonusOneManArmy);
				}
			}
			if (statSheet.method_12(3) < 5f)
			{
				this.m_lastKillActions.Add(ScoringActionType.BonusGenocide);
				statSheet.method_13();
			}
			else if (statSheet.method_12(2) < 5f)
			{
				this.m_lastKillActions.Add(ScoringActionType.BonusTripleKilling);
			}
			else if (statSheet.method_12(1) < 5f)
			{
				this.m_lastKillActions.Add(ScoringActionType.BonusOneStoneTwoBird);
			}
			if (context.m_victim.vmethod_0() == statSheet.m_lastDamager[1] && Time.time - statSheet.m_lastDamageTime < 3f)
			{
				this.m_lastKillActions.Add(ScoringActionType.BonusGiveAndTake);
			}
		}
		if (context.m_killer != null && context.m_victim != null)
		{
			if (statSheet != null && statSheet.m_lastKillerForRevenge == context.m_victim.vmethod_0() && context.m_victim.vmethod_0() != context.m_killer.vmethod_0())
			{
				this.m_lastKillActions.Add(ScoringActionType.BonusRevenge);
				statSheet.m_lastKillerForRevenge = 0;
				statSheet.m_nemesisCount++;
				this.method_2(statSheet.m_nemesisCount, ScoringActionType.BonusPayback, ScoringActionType.BonusAvenger);
			}
			if (MonoSingleton<StatisticsManager>.Instance.GetCurrentSession().m_endKillCount > 0 && MonoSingleton<ScoringManager>.Instance.method_9() >= MonoSingleton<StatisticsManager>.Instance.GetCurrentSession().m_endKillCount)
			{
				this.m_lastKillActions.Add(ScoringActionType.BonusLastKill);
			}
			if (context.m_subType == AttackSubType.SkillTurretProjectile)
			{
				this.m_lastKillActions.Add(ScoringActionType.BonusTurretKill);
			}
			else if (context.m_subType == AttackSubType.AreaFirebird)
			{
				this.m_lastKillActions.Add(ScoringActionType.BonusFirebirdKill);
			}
			else if (context.m_subType == AttackSubType.MeleeSkillBerserkPunch)
			{
				this.m_lastKillActions.Add(ScoringActionType.BonusPunchKill);
			}
			else if (context.m_subType == AttackSubType.AreaGrenade)
			{
				this.m_lastKillActions.Add(ScoringActionType.BonusGrenadesKill);
			}
			EntityPlayer entityPlayer = context.m_killer as EntityPlayer;
			if (entityPlayer != null && entityPlayer.PlayerSkillManage_0 is HunterManage && MarkManager.MarkManager_0.m_titleCrl.method_1(context.m_victim))
			{
				this.m_lastKillActions.Add(ScoringActionType.BonusMarkedKill);
			}
			if (MonoSingleton<Session>.Instance.method_14() && playerInfoSync != null)
			{
				StatisticsManager.StatSheet statSheet2 = currentSession.method_9(playerInfoSync.m_teamID);
				if (statSheet2 != null && statSheet2.m_killCount == 1)
				{
					this.m_lastKillActions.Add(ScoringActionType.BonusFirstBullet);
				}
			}
			PlayerController component = context.m_victim.GetComponent<PlayerController>();
			if (component != null && component.method_37())
			{
				this.m_lastKillActions.Add(ScoringActionType.BonusShameless);
			}
			PlayerInfoSync playerInfoSync2 = context.m_victim.vmethod_25();
			if (playerInfoSync2 != null)
			{
				StatisticsManager.StatSheet personalStatSheet = MonoSingleton<StatisticsManager>.Instance.GetCurrentSession().GetPersonalStatSheet(playerInfoSync2);
				if (personalStatSheet != null)
				{
					if (MonoSingleton<Session>.Instance.method_8() > (double)((float)currentSession.m_timeLimit * 0.5f) && currentSession.method_16() == personalStatSheet.m_score)
					{
						this.m_lastKillActions.Add(ScoringActionType.BonusAssassin);
					}
					if (personalStatSheet.m_killCount > 0 && Time.time - personalStatSheet.m_lastKillTime < 3f)
					{
						this.m_lastVictimActions.Add(ScoringActionType.BonusLoveShot);
					}
				}
			}
			if (Vector3.Distance(context.m_victim.transform.position, context.m_killer.transform.position) > 30f)
			{
				this.m_lastKillActions.Add(ScoringActionType.BonusEagleEye);
			}
			Vector3 vector = context.m_victim.transform.TransformDirection(Vector3.forward);
			Vector3 vector2 = context.m_killer.transform.position - context.m_victim.transform.position;
			if (Vector3.Dot(vector, vector2) < 0f)
			{
				this.m_lastKillActions.Add(ScoringActionType.BonusBackStabbing);
			}
			PlayerAnimationManagerFSM component2 = context.m_victim.GetComponent<PlayerAnimationManagerFSM>();
			if (component2 != null)
			{
				if (component2.method_13(AnimationStateFSM.PlayerReload))
				{
					this.m_lastKillActions.Add(ScoringActionType.BonusShameless);
				}
				if (component2.method_13(AnimationStateFSM.PlayerMove))
				{
					AnimationPlayerMoveState animationPlayerMoveState = component2.method_16(Utils.smethod_23(AnimationStateFSM.PlayerMove)) as AnimationPlayerMoveState;
					if (animationPlayerMoveState.Single_0 >= 0.6f)
					{
						this.m_lastKillActions.Add(ScoringActionType.BonusRoadtoHell);
					}
				}
			}
		}
		this.vmethod_1(context.m_killer as EntityPlayer, context.m_killer, context.m_victim, context.m_subType);
		this.vmethod_2(context.m_victim as EntityPlayer, this.m_lastVictimActions);
	}

	// Token: 0x06001989 RID: 6537 RVA: 0x00013079 File Offset: 0x00011279
	private void method_2(int int_0, ScoringActionType scoringActionType_0, ScoringActionType scoringActionType_1)
	{
		if (int_0 == 5)
		{
			this.m_lastKillActions.Add(scoringActionType_0);
		}
		else if (int_0 == 10)
		{
			this.m_lastKillActions.Add(scoringActionType_1);
		}
	}

	// Token: 0x0600198A RID: 6538 RVA: 0x000851F4 File Offset: 0x000833F4
	private void method_3(KillContext killContext_0)
	{
		ScoringActionType scoringActionType = this.method_4(killContext_0);
		if (scoringActionType != ScoringActionType.BasicSuicide)
		{
			this.m_inGameActions.Clear();
			if (killContext_0.m_victim == null)
			{
				return;
			}
			if (killContext_0.m_killer == null)
			{
				return;
			}
			PlayerInfoSync playerInfoSync = killContext_0.m_victim.vmethod_25();
			if (playerInfoSync == null)
			{
				return;
			}
			StatisticsManager.SessionStats currentSession = MonoSingleton<StatisticsManager>.Instance.GetCurrentSession();
			if (currentSession == null)
			{
				return;
			}
			StatisticsManager.StatSheet personalStatSheet = currentSession.GetPersonalStatSheet(playerInfoSync);
			if (personalStatSheet == null)
			{
				DebugUtils.LogWarning(LogCategory.Gamelogic, "DeathmatchScoringRule:CheckAssist - missing stats for player[" + playerInfoSync.m_name + "]");
				return;
			}
			int num = personalStatSheet.m_lastDamager[1];
			if (num == killContext_0.m_killer.vmethod_0())
			{
				num = personalStatSheet.m_lastDamager[0];
			}
			Entity entity = BadAssNetworkView.smethod_4(num);
			if (entity == null)
			{
				return;
			}
			if (killContext_0.m_killer.vmethod_9() == entity.vmethod_9() && killContext_0.m_killer.vmethod_0() != num)
			{
				this.m_inGameActions.Add(ScoringActionType.BasicAssist);
			}
			if (this.m_inGameActions.Count == 0)
			{
				return;
			}
			this.vmethod_2(entity as EntityPlayer, this.m_inGameActions);
		}
	}

	// Token: 0x0600198B RID: 6539 RVA: 0x00085314 File Offset: 0x00083514
	protected virtual void vmethod_1(EntityPlayer entityPlayer_0, Entity entity_0, Entity entity_1, AttackSubType attackSubType_0)
	{
		if (this.m_lastKillActions.Count == 0)
		{
			return;
		}
		if (entityPlayer_0 == null)
		{
			return;
		}
		PlayerInfoSync playerInfoSync = entityPlayer_0.vmethod_25();
		if (playerInfoSync == null)
		{
			return;
		}
		if (entity_0 != null && entity_1 != null)
		{
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
		MonoSingleton<ScoringManager>.Instance.method_14(entityPlayer_0.vmethod_25().m_characterId, false, num);
		this.m_lastKillActions.Clear();
	}

	// Token: 0x0600198C RID: 6540 RVA: 0x00085484 File Offset: 0x00083684
	protected virtual void vmethod_2(EntityPlayer entityPlayer_0, List<ScoringActionType> list_0)
	{
		if (list_0.Count == 0)
		{
			return;
		}
		if (entityPlayer_0 == null)
		{
			return;
		}
		PlayerInfoSync playerInfoSync = entityPlayer_0.vmethod_25();
		if (playerInfoSync == null)
		{
			return;
		}
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDPvPKillStampView>().method_3(playerInfoSync.m_name, list_0);
		int num = 0;
		for (int i = 0; i < list_0.Count; i++)
		{
			int num2 = this.imethod_1(list_0[i], null, null);
			num += num2;
		}
		MonoSingleton<ScoringManager>.Instance.method_14(entityPlayer_0.vmethod_25().m_characterId, false, num);
		list_0.Clear();
	}

	// Token: 0x0600198D RID: 6541 RVA: 0x0001309E File Offset: 0x0001129E
	public ScoringActionType method_4(KillContext killContext_0)
	{
		if (killContext_0.m_victim != null && killContext_0.m_killer != null && killContext_0.m_victim.vmethod_0() == killContext_0.m_killer.vmethod_0())
		{
			return ScoringActionType.BasicSuicide;
		}
		return ScoringActionType.BasicKill;
	}

	// Token: 0x0600198E RID: 6542 RVA: 0x000130DB File Offset: 0x000112DB
	public override void imethod_2(int int_0)
	{
		this.m_multiKillWinner.Add(int_0);
	}

	// Token: 0x0600198F RID: 6543 RVA: 0x00085514 File Offset: 0x00083714
	public override void imethod_3(Entity entity_0)
	{
		EquipmentInventoryEntity equipmentInventoryEntity = entity_0.vmethod_19();
		if (equipmentInventoryEntity != null && equipmentInventoryEntity.vmethod_6() == equipmentInventoryEntity.vmethod_7() && (float)equipmentInventoryEntity.vmethod_4() < (float)equipmentInventoryEntity.vmethod_0() * 0.1f)
		{
			this.m_inGameActions.Add(ScoringActionType.BonusResuscitation);
			this.vmethod_2(entity_0 as EntityPlayer, this.m_inGameActions);
		}
	}

	// Token: 0x06001990 RID: 6544 RVA: 0x00085574 File Offset: 0x00083774
	public override int imethod_1(ScoringActionType scoringActionType_0, Entity entity_0, Entity entity_1)
	{
		ScoringSetupPVP scoringSetupPVP = this.m_scoreSetup.m_ScoringSetup as ScoringSetupPVP;
		if (scoringSetupPVP != null)
		{
			for (int i = 0; i < scoringSetupPVP.m_scoringActions.Length; i++)
			{
				if (scoringSetupPVP.m_scoringActions[i].m_scoringActionType == scoringActionType_0)
				{
					return (int)((float)scoringSetupPVP.m_scoringActions[i].m_value * this.method_5(scoringActionType_0, entity_0, entity_1));
				}
			}
		}
		return 0;
	}

	// Token: 0x06001991 RID: 6545 RVA: 0x000855D8 File Offset: 0x000837D8
	protected float method_5(ScoringActionType scoringActionType_0, Entity entity_0, Entity entity_1)
	{
		if (!(entity_0 == null) && !(entity_1 == null))
		{
			if (scoringActionType_0 == ScoringActionType.BasicKill)
			{
				PlayerInfoSync playerInfoSync = entity_0.vmethod_25();
				PlayerInfoSync playerInfoSync2 = entity_1.vmethod_25();
				if (playerInfoSync != null && playerInfoSync2 != null)
				{
					int num = (int)((float)(MonoSingleton<LevelingManager>.Instance.method_3(playerInfoSync2.m_avatarDna.method_5(), playerInfoSync2.m_exp) - MonoSingleton<LevelingManager>.Instance.method_3(playerInfoSync.m_avatarDna.method_5(), playerInfoSync.m_exp)) / 2f);
					num = Mathf.Max(num, 0);
					return (float)num / 4f;
				}
			}
			return 1f;
		}
		return 1f;
	}

	// Token: 0x06001992 RID: 6546 RVA: 0x00085680 File Offset: 0x00083880
	public override void OnUpdateMatch()
	{
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
				EntityPlayer entityPlayer = playerInfoSync.GetEntity() as EntityPlayer;
				if (entityPlayer != null)
				{
					StatisticsManager.StatSheet personalStatSheet = currentSession.GetPersonalStatSheet(playerInfoSync);
					if (personalStatSheet != null)
					{
						personalStatSheet.m_livingInterval += Time.deltaTime;
						if (personalStatSheet.m_livingInterval > 300f)
						{
							this.m_inGameActions.Add(ScoringActionType.BonusLongevity);
							personalStatSheet.m_livingInterval = 0f;
						}
						BadAssCharacterMotorLite component = entityPlayer.GetComponent<BadAssCharacterMotorLite>();
						if (component != null)
						{
							if (component.jumping.jumping)
							{
								personalStatSheet.m_flyingInterval += Time.deltaTime;
								if (personalStatSheet.m_flyingInterval > 3f)
								{
									this.m_inGameActions.Add(ScoringActionType.BonusAirBourne);
									personalStatSheet.m_flyingInterval = 0f;
								}
							}
							else
							{
								personalStatSheet.m_flyingInterval = 0f;
							}
						}
						personalStatSheet.m_lastPos = entityPlayer.transform.position;
					}
					this.vmethod_2(entityPlayer, this.m_inGameActions);
				}
			}
		}
	}

	// Token: 0x06001993 RID: 6547 RVA: 0x000857E8 File Offset: 0x000839E8
	public override void OnEndMatch()
	{
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
						if (personalStatSheet.m_killCount == 0 && personalStatSheet.m_deathcount == 0)
						{
							this.m_inGameActions.Add(ScoringActionType.BonusAFK);
						}
						this.vmethod_2(entity as EntityPlayer, this.m_inGameActions);
					}
				}
			}
		}
	}

	// Token: 0x06001994 RID: 6548 RVA: 0x000858A0 File Offset: 0x00083AA0
	protected override float vmethod_0(StatisticsManager.SessionStats sessionStats_0, StatisticsManager.StatSheet statSheet_0, bool bool_0)
	{
		ScoringSetupPVP scoringSetupPVP = this.m_scoreSetup.m_ScoringSetup as ScoringSetupPVP;
		if (scoringSetupPVP != null)
		{
			InstanceGrade instanceGrade = this.imethod_4(sessionStats_0, statSheet_0);
			int num = (int)instanceGrade;
			if (num < scoringSetupPVP.m_performanceRankBonus.Length)
			{
				return (!bool_0) ? scoringSetupPVP.m_performanceRankBonus[num].m_EXPBonus : scoringSetupPVP.m_performanceRankBonus[num].m_softCurrencyBonus;
			}
		}
		return 1f;
	}

	// Token: 0x06001995 RID: 6549 RVA: 0x000858FC File Offset: 0x00083AFC
	protected virtual void vmethod_3(StatisticsManager.SessionStats sessionStats_0)
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
				personalStatSheet.m_honorValue = scoringSetupPVP.m_honorStandardReward / num * (list.Count / 8) + scoringSetupPVP.m_honorWinBonus / num;
			}
		}
	}

	// Token: 0x06001996 RID: 6550 RVA: 0x00085988 File Offset: 0x00083B88
	protected void method_6(StatisticsManager.SessionStats sessionStats_0)
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
				if (!personalStatSheet.m_isFail)
				{
					int num = (int)(sessionStats_0.m_duration * scoringSetupPVP.m_expStandardReward * base.method_1(personalStatSheet.m_level, false) * scoringSetupPVP.m_modeModifierEXP * scoringSetupPVP.m_winBonusEXP * this.vmethod_0(sessionStats_0, personalStatSheet, false));
					personalStatSheet.method_8(num);
				}
			}
		}
	}

	// Token: 0x06001997 RID: 6551 RVA: 0x00085A20 File Offset: 0x00083C20
	protected float method_7(PlayerInfoSync playerInfoSync_0)
	{
		EntityPlayer entityPlayer = playerInfoSync_0.GetEntity() as EntityPlayer;
		if (entityPlayer)
		{
			return entityPlayer.PlayerEffectManager_0.method_0(EffectType.XPBonus);
		}
		return 1f;
	}

	// Token: 0x06001998 RID: 6552 RVA: 0x00085A54 File Offset: 0x00083C54
	protected void method_8(StatisticsManager.SessionStats sessionStats_0)
	{
		if (sessionStats_0 == null)
		{
			return;
		}
		PvPGuildExpFactorDataList pvPGuildExpFactorDataList = MonoSingleton<GuildProgressionSetting>.Instance.method_2();
		List<PlayerInfoSync> list;
		MonoSingleton<Session>.Instance.method_38(out list);
		for (int i = 0; i < list.Count; i++)
		{
			StatisticsManager.StatSheet personalStatSheet = sessionStats_0.GetPersonalStatSheet(list[i]);
			if (!personalStatSheet.m_isFail)
			{
				float num;
				if (MonoSingleton<ScoringManager>.Instance.method_17(list[i]))
				{
					num = (float)pvPGuildExpFactorDataList.m_expWinFactor.m_basicExpValue;
					int num2 = sessionStats_0.method_26(list[i]);
					if (num2 > 0 && num2 <= pvPGuildExpFactorDataList.m_expWinFactor.m_rankFactors.Length && list.Count > pvPGuildExpFactorDataList.m_expWinFactor.m_rankFactors[num2 - 1].m_minPlayer)
					{
						num += (float)pvPGuildExpFactorDataList.m_expWinFactor.m_rankFactors[num2 - 1].m_expValue;
					}
				}
				else
				{
					num = (float)pvPGuildExpFactorDataList.m_expLoseFactor.m_basicExpValue;
				}
				num *= AntiAddiction.smethod_0(list[i].m_antiAddictionLevel);
				personalStatSheet.m_guildExp += (int)num;
			}
		}
	}

	// Token: 0x06001999 RID: 6553 RVA: 0x000130EA File Offset: 0x000112EA
	public override void imethod_6(StatisticsManager.SessionStats sessionStats_0)
	{
		if (sessionStats_0 == null)
		{
			return;
		}
		base.method_0(sessionStats_0);
		this.vmethod_3(sessionStats_0);
		this.method_6(sessionStats_0);
		this.method_8(sessionStats_0);
	}

	// Token: 0x0600199A RID: 6554 RVA: 0x00085B68 File Offset: 0x00083D68
	public override InstanceGrade imethod_4(StatisticsManager.SessionStats sessionStats_0, StatisticsManager.StatSheet statSheet_0)
	{
		ScoringSetupPVP scoringSetupPVP = this.m_scoreSetup.m_ScoringSetup as ScoringSetupPVP;
		if (scoringSetupPVP != null && !statSheet_0.m_isFail)
		{
			int num = sessionStats_0.method_16();
			for (int i = 0; i < scoringSetupPVP.m_performanceRankBonus.Length - 1; i++)
			{
				if ((float)statSheet_0.m_score >= scoringSetupPVP.m_performanceRankBonus[i].m_condition * (float)num)
				{
					return (InstanceGrade)i;
				}
			}
			return InstanceGrade.D;
		}
		return InstanceGrade.F;
	}

	// Token: 0x04001137 RID: 4407
	protected const float dominationBonusDelay = 3f;

	// Token: 0x04001138 RID: 4408
	protected const float multiKillingBonusDelay = 5f;

	// Token: 0x04001139 RID: 4409
	protected List<ScoringActionType> m_lastKillActions = new List<ScoringActionType>();

	// Token: 0x0400113A RID: 4410
	protected List<ScoringActionType> m_lastVictimActions = new List<ScoringActionType>();

	// Token: 0x0400113B RID: 4411
	protected List<ScoringActionType> m_inGameActions = new List<ScoringActionType>();

	// Token: 0x0400113C RID: 4412
	protected HashSet<int> m_multiKillWinner = new HashSet<int>();

	// Token: 0x0400113D RID: 4413
	protected bool m_lastKillUnderDominationDelay;

	// Token: 0x0400113E RID: 4414
	protected bool m_lastKillmultiKillingDelay;
}
