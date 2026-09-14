using System;
using System.Reflection;

// Token: 0x0200063F RID: 1599
internal class AutoTestTable
{
	// Token: 0x06002889 RID: 10377 RVA: 0x000BF280 File Offset: 0x000BD480
	public string[] method_0(string string_0)
	{
		string[] array = this.m_empty;
		Type type = base.GetType();
		FieldInfo field = type.GetField("m_" + string_0);
		if (field != null)
		{
			array = (string[])field.GetValue(this);
		}
		return array;
	}

	// Token: 0x04001CB2 RID: 7346
	public string[] m_testCases = new string[] { "LoadAutoTestLevel1_WaitForOnePlayer", "  Test1|Test2", "Quit" };

	// Token: 0x04001CB3 RID: 7347
	public string[] m_loadLevel = new string[] { "LoadLevel" };

	// Token: 0x04001CB4 RID: 7348
	public string[] m_empty = new string[0];

	// Token: 0x04001CB5 RID: 7349
	public string[] m_oneInvulnerablePlayerStanding = new string[] { "LoadAutoTestLevel1_WaitForOnePlayer", "  InvulnerablePlayerStandStillForOneMinute", "Quit" };

	// Token: 0x04001CB6 RID: 7350
	public string[] m_twoInvulnerablePlayersStanding = new string[] { "LoadAutoTestLevel1_WaitForTwoPlayers", "  InvulnerablePlayerStandStillForOneMinute", "Quit" };

	// Token: 0x04001CB7 RID: 7351
	public string[] m_threeInvulnerablePlayersStanding = new string[] { "LoadAutoTestLevel1_WaitForThreePlayers", "  InvulnerablePlayerStandStillForOneMinute", "Quit" };

	// Token: 0x04001CB8 RID: 7352
	public string[] m_fourInvulnerablePlayersStanding = new string[] { "LoadAutoTestLevel1_WaitForFourPlayers", "  InvulnerablePlayerStandStillForOneMinute", "Quit" };

	// Token: 0x04001CB9 RID: 7353
	public string[] m_testAI = new string[] { "LoadAutoTestLevel1_WaitForOnePlayer", "  NpcMoveToDestination|NpcRangeAttackPlayer|NpcShootExplosiveBarrel|NpcChooseAttackTarget|NpcOnDamage|PlayerTeleport|NpcMeleeAttackPlayer|NpcChooseCover|NpcAttackPlayerInCover|NpcSuicideAttack |BadassBanditThrowGrenade|NpcBasicSpawn|NpcAdvanceSpawn|BadassPsychoThrowAxe|NpcReloadWeapon|NpcChargeAttack|NpcSpitAttack|NpcCombatSpawn|NpcIceMeteorAttack|NpcHeal|NpcSniperAttackPlayer|RakkFlyMeleeAttack|HurtZone|NpcFallBackFireAttackPlayer|KillDestroyableObject|TentacleMeleeAttack|ArchangleEnergyBlast|ArchangelEnergyMissile|TheInsaneTeleportPlayer", "Quit" };

	// Token: 0x04001CBA RID: 7354
	public string[] m_npcMovetoDestination = new string[] { "LoadAutoTestLevel1_WaitForOnePlayer", "  NpcMoveToDestination", "Quit" };

	// Token: 0x04001CBB RID: 7355
	public string[] m_archangleEnergyBlast = new string[] { "LoadAutoTestLevel1_WaitForOnePlayer", "  ArchangleEnergyBlast", "Quit" };

	// Token: 0x04001CBC RID: 7356
	public string[] m_archangelEnergyMissile = new string[] { "LoadAutoTestLevel1_WaitForOnePlayer", "  ArchangelEnergyMissile", "Quit" };

	// Token: 0x04001CBD RID: 7357
	public string[] m_theInsaneTeleportPlayer = new string[] { "LoadAutoTestLevel1_WaitForOnePlayer", "  TheInsaneTeleportPlayer", "Quit" };

	// Token: 0x04001CBE RID: 7358
	public string[] m_npcBasicSpawn = new string[] { "LoadAutoTestLevel1_WaitForOnePlayer", "  NpcBasicSpawn", "Quit" };

	// Token: 0x04001CBF RID: 7359
	public string[] m_npcAdvanceSpawn = new string[] { "LoadAutoTestLevel1_WaitForOnePlayer", "  NpcAdvanceSpawn", "Quit" };

	// Token: 0x04001CC0 RID: 7360
	public string[] m_npcCombatSpawn = new string[] { "LoadAutoTestLevel1_WaitForOnePlayer", "  NpcCombatSpawn", "Quit" };

	// Token: 0x04001CC1 RID: 7361
	public string[] m_rakkFlyMeleeAttack = new string[] { "LoadAutoTestLevel1_WaitForOnePlayer", "  RakkFlyMeleeAttack", "Quit" };

	// Token: 0x04001CC2 RID: 7362
	public string[] m_hurtZone = new string[] { "LoadAutoTestLevel1_WaitForOnePlayer", "  HurtZone", "Quit" };

	// Token: 0x04001CC3 RID: 7363
	public string[] m_npcHeal = new string[] { "LoadAutoTestLevel1_WaitForOnePlayer", "  NpcHeal", "Quit" };

	// Token: 0x04001CC4 RID: 7364
	public string[] m_killDestroyableObject = new string[] { "LoadAutoTestLevel1_WaitForOnePlayer", "  KillDestroyableObject", "Quit" };

	// Token: 0x04001CC5 RID: 7365
	public string[] m_tentacleMeleeAttack = new string[] { "LoadAutoTestLevel1_WaitForOnePlayer", "  TentacleMeleeAttack", "Quit" };

	// Token: 0x04001CC6 RID: 7366
	public string[] m_npcRangeAttackPlayer = new string[] { "LoadAutoTestLevel1_WaitForOnePlayer", "  NpcRangeAttackPlayer", "Quit" };

	// Token: 0x04001CC7 RID: 7367
	public string[] m_npcSniperAttackPlayer = new string[] { "LoadAutoTestLevel1_WaitForOnePlayer", "  NpcSniperAttackPlayer", "Quit" };

	// Token: 0x04001CC8 RID: 7368
	public string[] m_npcFallBackFireAttackPlayer = new string[] { "LoadAutoTestLevel1_WaitForOnePlayer", "  NpcFallBackFireAttackPlayer", "Quit" };

	// Token: 0x04001CC9 RID: 7369
	public string[] m_badassBanditThrowGrenade = new string[] { "LoadAutoTestLevel1_WaitForOnePlayer", "  BadassBanditThrowGrenade", "Quit" };

	// Token: 0x04001CCA RID: 7370
	public string[] m_badassPsychoThrowAxe = new string[] { "LoadAutoTestLevel1_WaitForOnePlayer", "  BadassPsychoThrowAxe", "Quit" };

	// Token: 0x04001CCB RID: 7371
	public string[] m_npcSuicideAttack = new string[] { "LoadAutoTestLevel1_WaitForOnePlayer", "  NpcSuicideAttack", "Quit" };

	// Token: 0x04001CCC RID: 7372
	public string[] m_npcReloadWeapon = new string[] { "LoadAutoTestLevel1_WaitForOnePlayer", "  NpcReloadWeapon", "Quit" };

	// Token: 0x04001CCD RID: 7373
	public string[] m_npcSpitAttack = new string[] { "LoadAutoTestLevel1_WaitForOnePlayer", "  NpcSpitAttack", "Quit" };

	// Token: 0x04001CCE RID: 7374
	public string[] m_npcMeleeAttackPlayer = new string[] { "LoadAutoTestLevel1_WaitForOnePlayer", "  NpcMeleeAttackPlayer", "Quit" };

	// Token: 0x04001CCF RID: 7375
	public string[] m_npcIceMeteorAttack = new string[] { "LoadAutoTestLevel1_WaitForOnePlayer", "  NpcIceMeteorAttack", "Quit" };

	// Token: 0x04001CD0 RID: 7376
	public string[] m_npcAttackPlayerInCover = new string[] { "LoadAutoTestLevel1_WaitForOnePlayer", "  NpcAttackPlayerInCover", "Quit" };

	// Token: 0x04001CD1 RID: 7377
	public string[] m_npcShootExplosiveBarrel = new string[] { "LoadAutoTestLevel1_WaitForOnePlayer", "  NpcShootExplosiveBarrel", "Quit" };

	// Token: 0x04001CD2 RID: 7378
	public string[] m_npcOnDamage = new string[] { "LoadAutoTestLevel1_WaitForOnePlayer", "  NpcOnDamage", "Quit" };

	// Token: 0x04001CD3 RID: 7379
	public string[] m_playerTeleport = new string[] { "LoadAutoTestLevel1_WaitForOnePlayer", "  PlayerTeleport", "Quit" };

	// Token: 0x04001CD4 RID: 7380
	public string[] m_npcChooseCover = new string[] { "LoadAutoTestLevel1_WaitForOnePlayer", "  NpcChooseCover", "Quit" };

	// Token: 0x04001CD5 RID: 7381
	public string[] m_npcChargeAttack = new string[] { "LoadAutoTestLevel1_WaitForOnePlayer", "  NpcChargeAttack", "Quit" };

	// Token: 0x04001CD6 RID: 7382
	public string[] m_npcChooseAttackTarget = new string[] { "LoadAutoTestLevel1_WaitForTwoPlayers", "  NpcChooseAttackTarget", "Quit" };

	// Token: 0x04001CD7 RID: 7383
	public string[] m_playerShootingTest = new string[] { "LoadAutoTestLevel1_SpawnPlayerAndWait(Siren,1)", "  PlayerShootingTest", "Quit" };

	// Token: 0x04001CD8 RID: 7384
	public string[] m_playerShootingTestWithPlayerNotMoving = new string[] { "LoadAutoTestLevel1_SpawnPlayerAndWait(Siren,1)", "  PlayerShootingTestWithPlayerNotMoving", "Quit" };

	// Token: 0x04001CD9 RID: 7385
	public string[] m_playerShootingTestPvP = new string[] { "LoadAutoTestLevel1_SpawnPlayerAndWait(Siren,2)", "  PlayerShootingTestPvP", "Quit" };

	// Token: 0x04001CDA RID: 7386
	public string[] m_memoryTest = new string[] { "LoadAutoTestLevel1_WaitForOnePlayer", "  Memory", "Quit" };

	// Token: 0x04001CDB RID: 7387
	public string[] m_memoryLeakTest = new string[] { "LoadAutoTestLevel1_WaitForOnePlayer", "  MemLeak", "Quit" };

	// Token: 0x04001CDC RID: 7388
	public string[] m_fpsTest = new string[] { "LoadAutoTestLevel1_WaitForOnePlayer", "  Fps", "Quit" };

	// Token: 0x04001CDD RID: 7389
	public string[] m_stressTest = new string[] { "Stress", "Quit" };

	// Token: 0x04001CDE RID: 7390
	public string[] m_stressTest3x5 = new string[] { "Stress3x5", "Quit" };

	// Token: 0x04001CDF RID: 7391
	public string[] m_stressTest3x6 = new string[] { "Stress3x6", "Quit" };

	// Token: 0x04001CE0 RID: 7392
	public string[] m_stressTest3x7 = new string[] { "Stress3x7", "Quit" };

	// Token: 0x04001CE1 RID: 7393
	public string[] m_stressTest3x9 = new string[] { "Stress3x9", "Quit" };

	// Token: 0x04001CE2 RID: 7394
	public string[] m_stressTest3x10 = new string[] { "Stress3x10", "Quit" };

	// Token: 0x04001CE3 RID: 7395
	public string[] m_stressTest3x11 = new string[] { "Stress3x11", "Quit" };

	// Token: 0x04001CE4 RID: 7396
	public string[] m_stressTest3x13 = new string[] { "Stress3x13", "Quit" };

	// Token: 0x04001CE5 RID: 7397
	public string[] m_stressTest3x14 = new string[] { "Stress3x14", "Quit" };

	// Token: 0x04001CE6 RID: 7398
	public string[] m_stressTest3x15 = new string[] { "Stress3x15", "Quit" };

	// Token: 0x04001CE7 RID: 7399
	public string[] m_skillSiren = new string[] { "LoadAutoTestLevel1_SpawnPlayerAndWait(Siren,1)", "  SkillSirenTest", "Quit" };

	// Token: 0x04001CE8 RID: 7400
	public string[] m_skillBerserker = new string[] { "LoadAutoTestLevel1_SpawnPlayerAndWait(BERSERKER,1)", "  SkillBerserkerTest", "Quit" };

	// Token: 0x04001CE9 RID: 7401
	public string[] m_skillSoldier = new string[] { "LoadAutoTestLevel1_SpawnPlayerAndWait(SOLDIER,1)", "  SkillSoldierTest", "Quit" };

	// Token: 0x04001CEA RID: 7402
	public string[] m_skillHunter = new string[] { "LoadAutoTestLevel1_SpawnPlayerAndWait(HUNTER,1)", "  SkillHunterTest", "Quit" };

	// Token: 0x04001CEB RID: 7403
	public string[] m_itemWeapon = new string[] { "LoadAutoTestLevel1_WaitForOnePlayer", "  ItemWeaponTest", "Quit" };

	// Token: 0x04001CEC RID: 7404
	public string[] m_itemShield = new string[] { "LoadAutoTestLevel1_WaitForOnePlayer", "  ItemShieldTest", "Quit" };

	// Token: 0x04001CED RID: 7405
	public string[] m_itemClassMode = new string[] { "LoadAutoTestLevel1_SpawnPlayerAndWait(Siren,1)", "  ItemClassModeTest", "Quit" };
}
