using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using BHV;
using BHV_Anim;
using ns0;
using UnityEngine;

// Token: 0x0200000B RID: 11
public class AIServiceSetting
{
	// Token: 0x0600003A RID: 58 RVA: 0x00035AC4 File Offset: 0x00033CC4
	private AIServiceSetting()
	{
	}

	// Token: 0x17000004 RID: 4
	// (get) Token: 0x0600003C RID: 60 RVA: 0x00003285 File Offset: 0x00001485
	public static AIServiceSetting AIServiceSetting_0
	{
		get
		{
			return AIServiceSetting.s_instance;
		}
	}

	// Token: 0x0600003D RID: 61 RVA: 0x00035B38 File Offset: 0x00033D38
	public void method_0()
	{
		uint num = 0U;
		XmlNodeList xmlNodeList = LevelLoadingManager.MapsDescXml.MapsDescXml_0.method_1().SelectNodes("NPCSetting/NPC/@value");
		for (int i = 0; i < xmlNodeList.Count; i++)
		{
			string text = xmlNodeList[i].Value.Replace("_L", string.Empty);
			text = text.Replace("_M", string.Empty);
			num = 0U;
			string text2 = string.Concat(new string[] { "Entities/Npc/", text, "/Config_", text, "_TaskManager" });
			TextAsset textAsset = Resources.Load<TextAsset>(text2);
			if (textAsset != null)
			{
				this.method_2(text, textAsset.text, ref num);
			}
			if (num != 0U)
			{
				text2 = string.Concat(new string[] { "Entities/Npc/", text, "/Config_", text, "_AnimationManager" });
				textAsset = Resources.Load<TextAsset>(text2);
				if (textAsset != null)
				{
					this.method_1(num, textAsset.text);
				}
			}
		}
		if (this.m_taskLUT.Count == 0)
		{
			this.m_taskLUT.Add(1, new BHVTaskIdle());
			this.m_taskLUT.Add(4, new BHVTaskMoveTo());
			this.m_taskLUT.Add(2, new BHVTaskDie());
			this.m_taskLUT.Add(3, new BHVTaskDead());
			this.m_taskLUT.Add(58, new BHVTaskDazeEffect());
			this.m_taskLUT.Add(29, new BHVTaskLightHurt());
			this.m_taskLUT.Add(42, new BHVTaskAlert());
			this.m_taskLUT.Add(5, new BHVTaskTurnTo());
			this.m_taskLUT.Add(31, new BHVTaskRespawn());
			this.m_taskLUT.Add(6, new BHVTaskMoveWithFacing());
			this.m_taskLUT.Add(10, new BHVTaskFire());
			this.m_taskLUT.Add(12, new BHVTaskCoverIdle());
			this.m_taskLUT.Add(13, new BHVTaskCoverFire());
			this.m_taskLUT.Add(14, new BHVTaskCoverFireIdle());
			this.m_taskLUT.Add(22, new BHVTaskMeleeAttack());
			this.m_taskLUT.Add(11, new BHVTaskReload());
			this.m_taskLUT.Add(15, new BHVTaskCoverReload());
			this.m_taskLUT.Add(16, new BHVTaskCoverPeakOut());
			this.m_taskLUT.Add(17, new BHVTaskCoverPeakIn());
			this.m_taskLUT.Add(18, new BHVTaskCoverLookAround());
			this.m_taskLUT.Add(28, new BHVTaskHurt());
			this.m_taskLUT.Add(32, new BHVTaskAdvanceSpawn());
			this.m_taskLUT.Add(45, new BHVTaskRoll());
			this.m_taskLUT.Add(46, new BHVTaskSideStep());
			this.m_taskLUT.Add(56, new BHVTaskWarning());
			this.m_taskLUT.Add(41, new BHVTaskSuicide());
			this.m_taskLUT.Add(23, new BHVTaskJumpAttack());
			this.m_taskLUT.Add(24, new BHVTaskJumpAttackLand());
			this.m_taskLUT.Add(26, new BHVTaskChargeAttack());
			this.m_taskLUT.Add(27, new BHVTaskChargeAttackHit());
			this.m_taskLUT.Add(33, new BHVTaskWarcry());
			this.m_taskLUT.Add(47, new BHVTaskSpit());
			this.m_taskLUT.Add(30, new BHVTaskSpawn());
			this.m_taskLUT.Add(34, new BHVTaskStunned());
		}
		if (this.m_animStateList.Count == 0)
		{
			this.m_animStateList.Add("Idle", new AnimationIdleState());
			this.m_animStateList.Add("Die", new AnimationDieState());
			this.m_animStateList.Add("Dead", new AnimationDeadState());
			this.m_animStateList.Add("Alert", new AnimationAlertState());
			this.m_animStateList.Add("TurnTo", new AnimationTurnToState());
			this.m_animStateList.Add("Move", new AnimationMoveState());
			this.m_animStateList.Add("Hurt", new AnimationHurtState());
			this.m_animStateList.Add("JumpAttack", new AnimationJumpAttackState());
			this.m_animStateList.Add("JumpAttackCrash", new AnimationJumpAttackCrashState());
			this.m_animStateList.Add("AdvanceSpawn", new AnimationAdvanceSpawnState());
			this.m_animStateList.Add("CombatSpawn", new AnimationCombatSpawnState());
			this.m_animStateList.Add("MeleeAttack", new AnimationMeleeAttackState());
			this.m_animStateList.Add("Warcry", new AnimationWarcryState());
			this.m_animStateList.Add("Charge", new AnimationChargeState());
			this.m_animStateList.Add("ChargeHit", new AnimationChargeHitState());
			this.m_animStateList.Add("MoveWithFacing", new AnimationMoveWithFacingState());
			this.m_animStateList.Add("CoverIdleBeforeFire", new AnimationCoverIdleBeforeFireState());
			this.m_animStateList.Add("CoverIdle", new AnimationCoverIdleState());
			this.m_animStateList.Add("CoverLookAround", new AnimationCoverLookAroundState());
			this.m_animStateList.Add("CoverPeakIn", new AnimationCoverPeakInState());
			this.m_animStateList.Add("CoverPeakOut", new AnimationCoverPeakOutState());
			this.m_animStateList.Add("Roll", new AnimationRollState());
			this.m_animStateList.Add("Warning", new AnimationWarningState());
			this.m_animStateList.Add("Fire", new AnimationFireState());
			this.m_animStateList.Add("Reload", new AnimationReloadState());
			this.m_animStateList.Add("CoverFire", new AnimationCoverFireState());
			this.m_animStateList.Add("CoverReload", new AnimationCoverReloadState());
			this.m_animStateList.Add("Empty", new AnimationEmptyState());
			this.m_animStateList.Add("Stun", new AnimationStunState());
			this.m_animStateList.Add("Spawn", new AnimationSpawnState());
		}
	}

	// Token: 0x0600003E RID: 62 RVA: 0x00036140 File Offset: 0x00034340
	public bool method_1(uint uint_0, string string_0)
	{
		if (AIServiceSetting.AIServiceSetting_0.m_npcAnimationMgrSetupList.ContainsKey(uint_0))
		{
			return true;
		}
		BHVAnimationManagerSetup bhvanimationManagerSetup = null;
		StringReader stringReader = new StringReader(string_0);
		if (this.m_animationSerializer != null)
		{
			bhvanimationManagerSetup = this.m_animationSerializer.Deserialize(stringReader) as BHVAnimationManagerSetup;
		}
		AIServiceSetting.AIServiceSetting_0.m_npcAnimationMgrSetupList.Add(uint_0, bhvanimationManagerSetup);
		return true;
	}

	// Token: 0x0600003F RID: 63 RVA: 0x00036198 File Offset: 0x00034398
	public bool method_2(string string_0, string string_1, ref uint uint_0)
	{
		if (this.m_npcTaskSettingLoadedList.Contains(string_0))
		{
			return true;
		}
		BHVTaskManagerSetup bhvtaskManagerSetup = null;
		StringReader stringReader = new StringReader(string_1);
		if (this.m_taskSerializer != null)
		{
			bhvtaskManagerSetup = this.m_taskSerializer.Deserialize(stringReader) as BHVTaskManagerSetup;
		}
		Dictionary<Type, BHVTaskSettings> dictionary = new Dictionary<Type, BHVTaskSettings>();
		int num = bhvtaskManagerSetup.m_settings.Length;
		for (int i = 0; i < num; i++)
		{
			dictionary.Add(bhvtaskManagerSetup.m_settings[i].GetType(), bhvtaskManagerSetup.m_settings[i]);
		}
		uint_0 = Utility.smethod_1(bhvtaskManagerSetup.m_entityType);
		this.m_settingList.Add(uint_0, dictionary);
		this.m_npcTaskSettingLoadedList.Add(string_0);
		return true;
	}

	// Token: 0x06000040 RID: 64 RVA: 0x0003623C File Offset: 0x0003443C
	public void method_3(EntityNpc.EntitySubType entitySubType_0, Dictionary<int, BHVTask> dictionary_0)
	{
		dictionary_0.Add(1, new BHVTaskIdle());
		dictionary_0.Add(4, new BHVTaskMoveTo());
		dictionary_0.Add(2, new BHVTaskDie());
		dictionary_0.Add(3, new BHVTaskDead());
		dictionary_0.Add(58, new BHVTaskDazeEffect());
		dictionary_0.Add(29, new BHVTaskLightHurt());
		dictionary_0.Add(42, new BHVTaskAlert());
		dictionary_0.Add(5, new BHVTaskTurnTo());
		dictionary_0.Add(31, new BHVTaskRespawn());
		switch (entitySubType_0)
		{
		case EntityNpc.EntitySubType.CHR_SkagAdult:
		case EntityNpc.EntitySubType.CHR_SkagAlpha:
		case EntityNpc.EntitySubType.CHR_SkagPup:
		case EntityNpc.EntitySubType.CHR_BadassVkag:
			this.method_16(dictionary_0);
			break;
		case EntityNpc.EntitySubType.CHR_SkagSpitter:
			this.method_17(dictionary_0);
			break;
		case EntityNpc.EntitySubType.CHR_SkagZilla:
		case EntityNpc.EntitySubType.CHR_ZillaKing:
			this.method_18(dictionary_0);
			break;
		case EntityNpc.EntitySubType.CHR_BanditKiller:
		case EntityNpc.EntitySubType.CHR_BanditRaider:
		case EntityNpc.EntitySubType.CHR_BadassBanditKiller:
		case EntityNpc.EntitySubType.CHR_CrimsonLanceInfantry:
		case EntityNpc.EntitySubType.CHR_DrBlofeld:
		case EntityNpc.EntitySubType.CHR_MajorVanCleef:
			this.method_6(dictionary_0);
			break;
		case EntityNpc.EntitySubType.CHR_BanditBruiser:
			this.method_21(dictionary_0);
			break;
		case EntityNpc.EntitySubType.CHR_BanditPsycho:
		case EntityNpc.EntitySubType.CHR_BadassBanditPsycho:
		case EntityNpc.EntitySubType.CHR_BatistaTheRocketLord:
		case EntityNpc.EntitySubType.CHR_InterstellarEraser:
			this.method_8(dictionary_0);
			break;
		case EntityNpc.EntitySubType.CHR_SpiderantWidowmaker:
			this.method_29(dictionary_0);
			break;
		case EntityNpc.EntitySubType.CHR_BanditSuicidePsycho:
			this.method_9(dictionary_0);
			break;
		case EntityNpc.EntitySubType.CHR_SpiderantWorker:
		case EntityNpc.EntitySubType.CHR_BadassSpiderantWorker:
			this.method_15(dictionary_0);
			break;
		case EntityNpc.EntitySubType.CHR_CrimsonLanceDefender:
		case EntityNpc.EntitySubType.CHR_BadassCrimsonLanceDefender:
			this.method_11(dictionary_0);
			break;
		case EntityNpc.EntitySubType.CHR_GuardianWraith:
			this.method_12(dictionary_0);
			break;
		case EntityNpc.EntitySubType.CHR_SpiderantTalos:
			this.method_28(dictionary_0);
			break;
		case EntityNpc.EntitySubType.CHR_CrimsonMechaKnoxx:
			this.method_23(dictionary_0);
			break;
		case EntityNpc.EntitySubType.CHR_BadassGuardianWraith:
			this.method_13(dictionary_0);
			break;
		case EntityNpc.EntitySubType.CHR_Rakk:
			this.method_26(dictionary_0);
			break;
		case EntityNpc.EntitySubType.CHR_MidgetShotgunner:
			this.method_25(dictionary_0);
			break;
		case EntityNpc.EntitySubType.CHR_BanditScout:
		case EntityNpc.EntitySubType.CHR_CrimsonLanceSniper:
			this.method_7(dictionary_0);
			break;
		case EntityNpc.EntitySubType.CHR_SoldierTurretBasic:
			this.method_27(dictionary_0);
			break;
		case EntityNpc.EntitySubType.CHR_CrimsonLanceMedic:
			this.method_22(dictionary_0);
			break;
		case EntityNpc.EntitySubType.CHR_MedicalStation:
			this.method_24(dictionary_0);
			break;
		case EntityNpc.EntitySubType.CHR_BanditApollyon:
			this.method_20(dictionary_0);
			break;
		case EntityNpc.EntitySubType.CHR_ArchAngel:
			this.method_14(dictionary_0);
			break;
		case EntityNpc.EntitySubType.CHR_ClapTrapTutor:
			this.method_30(dictionary_0);
			break;
		case EntityNpc.EntitySubType.CHR_TheInsane:
			this.method_31(dictionary_0);
			break;
		case EntityNpc.EntitySubType.CHR_TheInsaneTentacle:
		case EntityNpc.EntitySubType.CHR_TheInsaneTentacleLarge:
			this.method_32(dictionary_0);
			break;
		case EntityNpc.EntitySubType.CHR_Crabworm:
			this.method_5(dictionary_0);
			break;
		case EntityNpc.EntitySubType.CHR_TheInsaneCrystal:
			this.method_4(dictionary_0);
			break;
		case EntityNpc.EntitySubType.CHR_SpitterQueen:
			this.method_19(dictionary_0);
			break;
		case EntityNpc.EntitySubType.CHR_CrimsonLanceAssassin:
			this.method_10(dictionary_0);
			break;
		}
	}

	// Token: 0x06000041 RID: 65 RVA: 0x000364B0 File Offset: 0x000346B0
	public void method_4(Dictionary<int, BHVTask> dictionary_0)
	{
		dictionary_0.Add(93, new BHVTaskCrystalEnergyBlast());
		dictionary_0.Add(94, new BHVTaskCrystalDeathStruggle());
		dictionary_0.Remove(4);
		dictionary_0.Remove(58);
		dictionary_0.Remove(29);
		dictionary_0.Remove(42);
		dictionary_0.Remove(5);
	}

	// Token: 0x06000042 RID: 66 RVA: 0x0000328C File Offset: 0x0000148C
	public void method_5(Dictionary<int, BHVTask> dictionary_0)
	{
		dictionary_0.Add(22, new BHVTaskMeleeAttack());
		dictionary_0.Add(90, new BHVTaskDrillAttack());
		dictionary_0.Add(91, new BHVTaskUndergroundIdle());
	}

	// Token: 0x06000043 RID: 67 RVA: 0x00036504 File Offset: 0x00034704
	public void method_6(Dictionary<int, BHVTask> dictionary_0)
	{
		dictionary_0.Add(6, new BHVTaskMoveWithFacing());
		dictionary_0.Add(10, new BHVTaskFire());
		dictionary_0.Add(12, new BHVTaskCoverIdle());
		dictionary_0.Add(13, new BHVTaskCoverFire());
		dictionary_0.Add(14, new BHVTaskCoverFireIdle());
		dictionary_0.Add(22, new BHVTaskMeleeAttack());
		dictionary_0.Add(11, new BHVTaskReload());
		dictionary_0.Add(15, new BHVTaskCoverReload());
		dictionary_0.Add(16, new BHVTaskCoverPeakOut());
		dictionary_0.Add(17, new BHVTaskCoverPeakIn());
		dictionary_0.Add(18, new BHVTaskCoverLookAround());
		dictionary_0.Add(28, new BHVTaskHurt());
		dictionary_0.Add(32, new BHVTaskAdvanceSpawn());
		dictionary_0.Add(45, new BHVTaskRoll());
		dictionary_0.Add(46, new BHVTaskSideStep());
		dictionary_0.Add(56, new BHVTaskWarning());
		dictionary_0.Add(59, new BHVTaskThrowAttack());
	}

	// Token: 0x06000044 RID: 68 RVA: 0x000032B5 File Offset: 0x000014B5
	public void method_7(Dictionary<int, BHVTask> dictionary_0)
	{
		this.method_6(dictionary_0);
		dictionary_0.Add(75, new BHVTaskAimingTarget());
		dictionary_0.Remove(59);
	}

	// Token: 0x06000045 RID: 69 RVA: 0x000032D4 File Offset: 0x000014D4
	public void method_8(Dictionary<int, BHVTask> dictionary_0)
	{
		dictionary_0.Add(22, new BHVTaskMeleeAttack());
		dictionary_0.Add(28, new BHVTaskHurt());
		dictionary_0.Add(32, new BHVTaskAdvanceSpawn());
		dictionary_0.Add(59, new BHVTaskThrowAttack());
	}

	// Token: 0x06000046 RID: 70 RVA: 0x0000330A File Offset: 0x0000150A
	public void method_9(Dictionary<int, BHVTask> dictionary_0)
	{
		dictionary_0.Add(41, new BHVTaskSuicide());
		dictionary_0.Add(28, new BHVTaskHurt());
		dictionary_0.Add(32, new BHVTaskAdvanceSpawn());
	}

	// Token: 0x06000047 RID: 71 RVA: 0x000365F0 File Offset: 0x000347F0
	public void method_10(Dictionary<int, BHVTask> dictionary_0)
	{
		dictionary_0.Add(30, new BHVTaskSpawn());
		dictionary_0.Add(22, new BHVTaskMeleeAttack());
		dictionary_0.Add(28, new BHVTaskHurt());
		dictionary_0.Add(59, new BHVTaskThrowAttack());
		dictionary_0.Add(101, new BHVTaskRollBack());
		dictionary_0.Add(102, new BHVTaskInvisible());
		dictionary_0.Add(104, new BHVTaskSwordSlash());
		dictionary_0.Add(45, new BHVTaskRoll());
		dictionary_0.Add(105, new BHVTaskDefenseField());
	}

	// Token: 0x06000048 RID: 72 RVA: 0x00036674 File Offset: 0x00034874
	public void method_11(Dictionary<int, BHVTask> dictionary_0)
	{
		dictionary_0.Add(6, new BHVTaskMoveWithFacing());
		dictionary_0.Add(10, new BHVTaskFire());
		dictionary_0.Add(22, new BHVTaskMeleeAttack());
		dictionary_0.Add(11, new BHVTaskReload());
		dictionary_0.Add(28, new BHVTaskHurt());
		dictionary_0.Add(46, new BHVTaskSideStep());
		dictionary_0.Add(56, new BHVTaskWarning());
		dictionary_0.Add(32, new BHVTaskAdvanceSpawn());
		dictionary_0.Add(59, new BHVTaskThrowAttack());
	}

	// Token: 0x06000049 RID: 73 RVA: 0x000366F8 File Offset: 0x000348F8
	public void method_12(Dictionary<int, BHVTask> dictionary_0)
	{
		dictionary_0.Add(8, new BHVTaskSlideMoveTo());
		dictionary_0.Add(22, new BHVTaskMeleeAttack());
		dictionary_0.Add(28, new BHVTaskHurt());
		dictionary_0.Add(45, new BHVTaskRoll());
		dictionary_0.Add(46, new BHVTaskSideStep());
		dictionary_0.Add(55, new BHVTaskShowWeapon());
	}

	// Token: 0x0600004A RID: 74 RVA: 0x00003333 File Offset: 0x00001533
	public void method_13(Dictionary<int, BHVTask> dictionary_0)
	{
		this.method_12(dictionary_0);
		dictionary_0.Add(64, new BHVTaskTeleport());
	}

	// Token: 0x0600004B RID: 75 RVA: 0x00036754 File Offset: 0x00034954
	public void method_14(Dictionary<int, BHVTask> dictionary_0)
	{
		dictionary_0.Add(28, new BHVTaskHurt());
		dictionary_0.Add(81, new BHVTaskCircleMove());
		dictionary_0.Add(64, new BHVTaskTeleport());
		dictionary_0.Add(82, new BHVTaskEnergyBlast());
		dictionary_0.Add(83, new BHVTaskEnergyMissile());
		dictionary_0.Add(84, new BHVTaskDeathStruggle());
		dictionary_0.Add(51, new BHVTaskDisabled());
	}

	// Token: 0x0600004C RID: 76 RVA: 0x000367BC File Offset: 0x000349BC
	public void method_15(Dictionary<int, BHVTask> dictionary_0)
	{
		dictionary_0.Add(22, new BHVTaskMeleeAttack());
		dictionary_0.Add(23, new BHVTaskJumpAttack());
		dictionary_0.Add(24, new BHVTaskJumpAttackLand());
		dictionary_0.Add(26, new BHVTaskChargeAttack());
		dictionary_0.Add(27, new BHVTaskChargeAttackHit());
		dictionary_0.Add(30, new BHVTaskSpawn());
		dictionary_0.Add(34, new BHVTaskStunned());
	}

	// Token: 0x0600004D RID: 77 RVA: 0x00036824 File Offset: 0x00034A24
	public void method_16(Dictionary<int, BHVTask> dictionary_0)
	{
		dictionary_0.Add(22, new BHVTaskMeleeAttack());
		dictionary_0.Add(23, new BHVTaskJumpAttack());
		dictionary_0.Add(24, new BHVTaskJumpAttackLand());
		dictionary_0.Add(26, new BHVTaskChargeAttack());
		dictionary_0.Add(27, new BHVTaskChargeAttackHit());
		dictionary_0.Add(28, new BHVTaskHurt());
		dictionary_0.Add(32, new BHVTaskAdvanceSpawn());
		dictionary_0.Add(33, new BHVTaskWarcry());
	}

	// Token: 0x0600004E RID: 78 RVA: 0x0003689C File Offset: 0x00034A9C
	public void method_17(Dictionary<int, BHVTask> dictionary_0)
	{
		dictionary_0.Add(22, new BHVTaskMeleeAttack());
		dictionary_0.Add(47, new BHVTaskSpit());
		dictionary_0.Add(33, new BHVTaskWarcry());
		dictionary_0.Add(28, new BHVTaskHurt());
		dictionary_0.Add(32, new BHVTaskAdvanceSpawn());
	}

	// Token: 0x0600004F RID: 79 RVA: 0x000368EC File Offset: 0x00034AEC
	public void method_18(Dictionary<int, BHVTask> dictionary_0)
	{
		dictionary_0.Add(22, new BHVTaskMeleeAttack());
		dictionary_0.Add(26, new BHVTaskChargeAttack());
		dictionary_0.Add(27, new BHVTaskChargeAttackHit());
		dictionary_0.Add(33, new BHVTaskWarcry());
		dictionary_0.Add(25, new BHVTaskJumpOnTheSpotAttack());
		dictionary_0.Add(32, new BHVTaskAdvanceSpawn());
	}

	// Token: 0x06000050 RID: 80 RVA: 0x00003349 File Offset: 0x00001549
	public void method_19(Dictionary<int, BHVTask> dictionary_0)
	{
		dictionary_0.Add(95, new BHVTaskPoisonDash());
		dictionary_0.Add(96, new BHVTaskPoisonSpit());
		dictionary_0.Add(97, new BHVTaskPoisonCrush());
	}

	// Token: 0x06000051 RID: 81 RVA: 0x00036948 File Offset: 0x00034B48
	public void method_20(Dictionary<int, BHVTask> dictionary_0)
	{
		dictionary_0.Add(10, new BHVTaskFire());
		dictionary_0.Add(77, new BHVTaskHammerAttack());
		dictionary_0.Add(11, new BHVTaskReload());
		dictionary_0.Add(28, new BHVTaskHurt());
		dictionary_0.Add(32, new BHVTaskAdvanceSpawn());
		dictionary_0.Add(6, new BHVTaskMoveWithFacing());
		dictionary_0.Add(56, new BHVTaskWarning());
		dictionary_0.Add(76, new BHVTaskHammerJumpAttack());
		dictionary_0.Add(78, new BHVTaskLavaStrike());
		dictionary_0.Add(51, new BHVTaskDisabled());
	}

	// Token: 0x06000052 RID: 82 RVA: 0x000369D8 File Offset: 0x00034BD8
	public void method_21(Dictionary<int, BHVTask> dictionary_0)
	{
		dictionary_0.Add(10, new BHVTaskFire());
		dictionary_0.Add(22, new BHVTaskMeleeAttack());
		dictionary_0.Add(11, new BHVTaskReload());
		dictionary_0.Add(28, new BHVTaskHurt());
		dictionary_0.Add(32, new BHVTaskAdvanceSpawn());
		dictionary_0.Add(6, new BHVTaskMoveWithFacing());
		dictionary_0.Add(56, new BHVTaskWarning());
		dictionary_0.Add(59, new BHVTaskThrowAttack());
	}

	// Token: 0x06000053 RID: 83 RVA: 0x00036A4C File Offset: 0x00034C4C
	public void method_22(Dictionary<int, BHVTask> dictionary_0)
	{
		dictionary_0.Add(10, new BHVTaskFire());
		dictionary_0.Add(22, new BHVTaskMeleeAttack());
		dictionary_0.Add(11, new BHVTaskReload());
		dictionary_0.Add(28, new BHVTaskHurt());
		dictionary_0.Add(46, new BHVTaskSideStep());
		dictionary_0.Add(56, new BHVTaskWarning());
		dictionary_0.Add(73, new BHVTaskDeployAidStation());
		dictionary_0.Add(6, new BHVTaskMoveWithFacing());
		dictionary_0.Add(32, new BHVTaskAdvanceSpawn());
		dictionary_0.Add(12, new BHVTaskCoverIdle());
		dictionary_0.Add(13, new BHVTaskCoverFire());
		dictionary_0.Add(14, new BHVTaskCoverFireIdle());
		dictionary_0.Add(15, new BHVTaskCoverReload());
		dictionary_0.Add(16, new BHVTaskCoverPeakOut());
		dictionary_0.Add(17, new BHVTaskCoverPeakIn());
		dictionary_0.Add(18, new BHVTaskCoverLookAround());
		dictionary_0.Add(59, new BHVTaskThrowAttack());
		dictionary_0.Add(45, new BHVTaskRoll());
	}

	// Token: 0x06000054 RID: 84 RVA: 0x00036B44 File Offset: 0x00034D44
	public void method_23(Dictionary<int, BHVTask> dictionary_0)
	{
		dictionary_0.Add(10, new BHVTaskFire());
		dictionary_0.Add(22, new BHVTaskMeleeAttack());
		dictionary_0.Add(11, new BHVTaskReload());
		dictionary_0.Add(56, new BHVTaskWarning());
		dictionary_0.Add(23, new BHVTaskJumpAttack());
		dictionary_0.Add(24, new BHVTaskJumpAttackLand());
		dictionary_0.Add(26, new BHVTaskChargeAttack());
		dictionary_0.Add(27, new BHVTaskChargeAttackHit());
		dictionary_0.Add(7, new BHVTaskTurnOnSpot());
		dictionary_0.Add(52, new BHVTaskSpacing());
		dictionary_0.Add(53, new BHVTaskCritical());
		dictionary_0.Add(61, new BHVTaskRailgunAttack());
		dictionary_0.Add(62, new BHVTaskMortarAttack());
		dictionary_0.Add(63, new BHVTaskJetAttack());
		dictionary_0.Add(28, new BHVTaskHurt());
		dictionary_0.Add(32, new BHVTaskAdvanceSpawn());
		dictionary_0.Add(70, new BHVTaskDestoryMissile());
		dictionary_0.Add(71, new BHVTaskLaserSweep());
		dictionary_0.Add(72, new BHVTaskRecharge());
		dictionary_0.Add(51, new BHVTaskDisabled());
	}

	// Token: 0x06000055 RID: 85 RVA: 0x00003372 File Offset: 0x00001572
	public void method_24(Dictionary<int, BHVTask> dictionary_0)
	{
		dictionary_0.Add(30, new BHVTaskSpawn());
		dictionary_0.Remove(4);
		dictionary_0.Remove(58);
		dictionary_0.Remove(29);
		dictionary_0.Remove(42);
		dictionary_0.Remove(5);
	}

	// Token: 0x06000056 RID: 86 RVA: 0x00036C54 File Offset: 0x00034E54
	public void method_25(Dictionary<int, BHVTask> dictionary_0)
	{
		dictionary_0.Add(10, new BHVTaskFire());
		dictionary_0.Add(22, new BHVTaskMeleeAttack());
		dictionary_0.Add(11, new BHVTaskReload());
		dictionary_0.Add(28, new BHVTaskHurt());
		dictionary_0.Add(32, new BHVTaskAdvanceSpawn());
		dictionary_0.Add(74, new BHVTaskFireFullBody());
	}

	// Token: 0x06000057 RID: 87 RVA: 0x00036CB0 File Offset: 0x00034EB0
	public void method_26(Dictionary<int, BHVTask> dictionary_0)
	{
		dictionary_0.Add(28, new BHVTaskHurt());
		dictionary_0.Add(65, new BHVTaskHoverPatrol());
		dictionary_0.Add(67, new BHVTaskFlyMeleeAttack());
		dictionary_0.Add(66, new BHVTaskFlyGather());
		dictionary_0.Remove(4);
		dictionary_0.Remove(42);
		dictionary_0.Remove(5);
	}

	// Token: 0x06000058 RID: 88 RVA: 0x00036D0C File Offset: 0x00034F0C
	public void method_27(Dictionary<int, BHVTask> dictionary_0)
	{
		dictionary_0.Add(68, new BHVTaskRocketAttack());
		dictionary_0.Add(74, new BHVTaskFireFullBody());
		dictionary_0.Add(30, new BHVTaskSpawn());
		dictionary_0.Remove(4);
		dictionary_0.Remove(58);
		dictionary_0.Remove(29);
		dictionary_0.Remove(42);
		dictionary_0.Remove(5);
	}

	// Token: 0x06000059 RID: 89 RVA: 0x00036D6C File Offset: 0x00034F6C
	public void method_28(Dictionary<int, BHVTask> dictionary_0)
	{
		dictionary_0.Add(22, new BHVTaskMeleeAttack());
		dictionary_0.Add(26, new BHVTaskChargeAttack());
		dictionary_0.Add(27, new BHVTaskChargeAttackHit());
		dictionary_0.Add(52, new BHVTaskSpacing());
		dictionary_0.Add(48, new BHVTaskIceEarthquakeAttack());
		dictionary_0.Add(49, new BHVTaskIceMeteorAttack());
		dictionary_0.Add(60, new BHVTaskEarthPikeAttack());
		dictionary_0.Add(30, new BHVTaskSpawn());
		dictionary_0.Add(33, new BHVTaskWarcry());
		dictionary_0.Add(34, new BHVTaskStunned());
		dictionary_0.Add(54, new BHVTaskSummonExtraNPC());
		dictionary_0.Add(70, new BHVTaskDestoryMissile());
		dictionary_0.Add(51, new BHVTaskDisabled());
	}

	// Token: 0x0600005A RID: 90 RVA: 0x00036E24 File Offset: 0x00035024
	public void method_29(Dictionary<int, BHVTask> dictionary_0)
	{
		dictionary_0.Add(22, new BHVTaskMeleeAttack());
		dictionary_0.Add(23, new BHVTaskJumpAttack());
		dictionary_0.Add(24, new BHVTaskJumpAttackLand());
		dictionary_0.Add(26, new BHVTaskChargeAttack());
		dictionary_0.Add(27, new BHVTaskChargeAttackHit());
		dictionary_0.Add(52, new BHVTaskSpacing());
		dictionary_0.Add(44, new BHVTaskBurrowAttack());
		dictionary_0.Add(53, new BHVTaskCritical());
		dictionary_0.Add(30, new BHVTaskSpawn());
		dictionary_0.Add(33, new BHVTaskWarcry());
		dictionary_0.Add(34, new BHVTaskStunned());
		dictionary_0.Add(43, new BHVTaskRadiusAttack());
		dictionary_0.Add(79, new BHVTaskWebTrap());
		dictionary_0.Add(51, new BHVTaskDisabled());
	}

	// Token: 0x0600005B RID: 91 RVA: 0x000033AC File Offset: 0x000015AC
	public void method_30(Dictionary<int, BHVTask> dictionary_0)
	{
		dictionary_0.Add(80, new BHVTaskTutorialLesson());
		dictionary_0.Add(92, new BHVTaskTutorialAction());
	}

	// Token: 0x0600005C RID: 92 RVA: 0x00036EE8 File Offset: 0x000350E8
	public void method_31(Dictionary<int, BHVTask> dictionary_0)
	{
		dictionary_0.Add(85, new BHVTaskEyeLaser());
		dictionary_0.Add(86, new BHVTaskEyeLaserPlus());
		dictionary_0.Add(87, new BHVTaskPlayerTeleport());
		dictionary_0.Add(28, new BHVTaskHurt());
		dictionary_0.Add(51, new BHVTaskDisabled());
	}

	// Token: 0x0600005D RID: 93 RVA: 0x000033C8 File Offset: 0x000015C8
	public void method_32(Dictionary<int, BHVTask> dictionary_0)
	{
		dictionary_0.Add(22, new BHVTaskMeleeAttack());
		dictionary_0.Add(30, new BHVTaskSpawn());
	}

	// Token: 0x0600005E RID: 94 RVA: 0x00036F38 File Offset: 0x00035138
	public void method_33(EntityNpc.EntitySubType entitySubType_0, NPCAnimationManagerFSM npcanimationManagerFSM_0)
	{
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Idle", new AnimationIdleState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Die", new AnimationDieState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Dead", new AnimationDeadState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Alert", new AnimationAlertState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("TurnTo", new AnimationTurnToState());
		switch (entitySubType_0)
		{
		case EntityNpc.EntitySubType.CHR_SkagAdult:
		case EntityNpc.EntitySubType.CHR_SkagAlpha:
		case EntityNpc.EntitySubType.CHR_SkagPup:
		case EntityNpc.EntitySubType.CHR_BadassVkag:
			this.method_34(npcanimationManagerFSM_0);
			break;
		case EntityNpc.EntitySubType.CHR_SkagSpitter:
			this.method_35(npcanimationManagerFSM_0);
			break;
		case EntityNpc.EntitySubType.CHR_SkagZilla:
		case EntityNpc.EntitySubType.CHR_ZillaKing:
			this.method_36(npcanimationManagerFSM_0);
			break;
		case EntityNpc.EntitySubType.CHR_BanditKiller:
		case EntityNpc.EntitySubType.CHR_BanditRaider:
		case EntityNpc.EntitySubType.CHR_BadassBanditKiller:
		case EntityNpc.EntitySubType.CHR_BanditScout:
		case EntityNpc.EntitySubType.CHR_CrimsonLanceInfantry:
		case EntityNpc.EntitySubType.CHR_CrimsonLanceSniper:
		case EntityNpc.EntitySubType.CHR_DrBlofeld:
		case EntityNpc.EntitySubType.CHR_MajorVanCleef:
			this.method_43(npcanimationManagerFSM_0);
			break;
		case EntityNpc.EntitySubType.CHR_BanditBruiser:
			this.method_45(npcanimationManagerFSM_0);
			break;
		case EntityNpc.EntitySubType.CHR_BanditPsycho:
		case EntityNpc.EntitySubType.CHR_BadassBanditPsycho:
		case EntityNpc.EntitySubType.CHR_BatistaTheRocketLord:
		case EntityNpc.EntitySubType.CHR_InterstellarEraser:
			this.method_39(npcanimationManagerFSM_0);
			break;
		case EntityNpc.EntitySubType.CHR_SpiderantWidowmaker:
			this.method_55(npcanimationManagerFSM_0);
			break;
		case EntityNpc.EntitySubType.CHR_BanditSuicidePsycho:
			this.method_40(npcanimationManagerFSM_0);
			break;
		case EntityNpc.EntitySubType.CHR_SpiderantWorker:
		case EntityNpc.EntitySubType.CHR_BadassSpiderantWorker:
			this.method_38(npcanimationManagerFSM_0);
			break;
		case EntityNpc.EntitySubType.CHR_CrimsonLanceDefender:
		case EntityNpc.EntitySubType.CHR_BadassCrimsonLanceDefender:
			this.method_42(npcanimationManagerFSM_0);
			break;
		case EntityNpc.EntitySubType.CHR_GuardianWraith:
		case EntityNpc.EntitySubType.CHR_BadassGuardianWraith:
			this.method_46(npcanimationManagerFSM_0);
			break;
		case EntityNpc.EntitySubType.CHR_SpiderantTalos:
			this.method_54(npcanimationManagerFSM_0);
			break;
		case EntityNpc.EntitySubType.CHR_CrimsonMechaKnoxx:
			this.method_53(npcanimationManagerFSM_0);
			break;
		case EntityNpc.EntitySubType.CHR_Rakk:
			this.method_50(npcanimationManagerFSM_0);
			break;
		case EntityNpc.EntitySubType.CHR_MidgetShotgunner:
			this.method_49(npcanimationManagerFSM_0);
			break;
		case EntityNpc.EntitySubType.CHR_SoldierTurretBasic:
			this.method_51(npcanimationManagerFSM_0);
			break;
		case EntityNpc.EntitySubType.CHR_CrimsonLanceMedic:
			this.method_44(npcanimationManagerFSM_0);
			break;
		case EntityNpc.EntitySubType.CHR_MedicalStation:
			this.method_48(npcanimationManagerFSM_0);
			break;
		case EntityNpc.EntitySubType.CHR_BanditApollyon:
			this.method_52(npcanimationManagerFSM_0);
			break;
		case EntityNpc.EntitySubType.CHR_ArchAngel:
			this.method_47(npcanimationManagerFSM_0);
			break;
		case EntityNpc.EntitySubType.CHR_ClapTrapTutor:
			this.method_56(npcanimationManagerFSM_0);
			break;
		case EntityNpc.EntitySubType.CHR_TheInsane:
			this.method_57(npcanimationManagerFSM_0);
			break;
		case EntityNpc.EntitySubType.CHR_TheInsaneTentacle:
		case EntityNpc.EntitySubType.CHR_TheInsaneTentacleLarge:
			this.method_58(npcanimationManagerFSM_0);
			break;
		case EntityNpc.EntitySubType.CHR_Crabworm:
			this.method_59(npcanimationManagerFSM_0);
			break;
		case EntityNpc.EntitySubType.CHR_TheInsaneCrystal:
			this.method_60(npcanimationManagerFSM_0);
			break;
		case EntityNpc.EntitySubType.CHR_SpitterQueen:
			this.method_37(npcanimationManagerFSM_0);
			break;
		case EntityNpc.EntitySubType.CHR_CrimsonLanceAssassin:
			this.method_41(npcanimationManagerFSM_0);
			break;
		}
	}

	// Token: 0x0600005F RID: 95 RVA: 0x000371A4 File Offset: 0x000353A4
	public void method_34(NPCAnimationManagerFSM npcanimationManagerFSM_0)
	{
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Move", new AnimationMoveState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Hurt", new AnimationHurtState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("JumpAttack", new AnimationJumpAttackState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("JumpAttackCrash", new AnimationJumpAttackCrashState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("AdvanceSpawn", new AnimationAdvanceSpawnState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("CombatSpawn", new AnimationCombatSpawnState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("MeleeAttack", new AnimationMeleeAttackState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Warcry", new AnimationWarcryState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Charge", new AnimationChargeState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("ChargeHit", new AnimationChargeHitState());
	}

	// Token: 0x06000060 RID: 96 RVA: 0x000372B8 File Offset: 0x000354B8
	public void method_35(NPCAnimationManagerFSM npcanimationManagerFSM_0)
	{
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Move", new AnimationMoveState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Hurt", new AnimationHurtState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("CombatSpawn", new AnimationCombatSpawnState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("MeleeAttack", new AnimationMeleeAttackState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Warcry", new AnimationWarcryState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Spit", new AnimationSpitState());
	}

	// Token: 0x06000061 RID: 97 RVA: 0x00037364 File Offset: 0x00035564
	public void method_36(NPCAnimationManagerFSM npcanimationManagerFSM_0)
	{
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Move", new AnimationMoveState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("MeleeAttack", new AnimationMeleeAttackState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Warcry", new AnimationWarcryState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("JumpOnSpot", new AnimationJumpOnSpotState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Charge", new AnimationChargeState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("ChargeHit", new AnimationChargeHitState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("AdvanceSpawn", new AnimationAdvanceSpawnState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("CombatSpawn", new AnimationCombatSpawnState());
	}

	// Token: 0x06000062 RID: 98 RVA: 0x000033E4 File Offset: 0x000015E4
	public void method_37(NPCAnimationManagerFSM npcanimationManagerFSM_0)
	{
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Move", new AnimationMoveState());
	}

	// Token: 0x06000063 RID: 99 RVA: 0x00037444 File Offset: 0x00035644
	public void method_38(NPCAnimationManagerFSM npcanimationManagerFSM_0)
	{
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Move", new AnimationMoveState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Stun", new AnimationStunState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("JumpAttack", new AnimationJumpAttackState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("JumpAttackCrash", new AnimationJumpAttackCrashState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Spawn", new AnimationSpawnState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("CombatSpawn", new AnimationCombatSpawnState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("MeleeAttack", new AnimationMeleeAttackState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Charge", new AnimationChargeState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("ChargeHit", new AnimationChargeHitState());
	}

	// Token: 0x06000064 RID: 100 RVA: 0x0003753C File Offset: 0x0003573C
	public void method_39(NPCAnimationManagerFSM npcanimationManagerFSM_0)
	{
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Move", new AnimationMoveState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Hurt", new AnimationHurtState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("AdvanceSpawn", new AnimationAdvanceSpawnState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("CombatSpawn", new AnimationCombatSpawnState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("MeleeAttack", new AnimationMeleeAttackState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("SuicideBomb", new AnimationSuicideBombState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("ThrowWeapon", new AnimationThrowWeaponState());
	}

	// Token: 0x06000065 RID: 101 RVA: 0x00037600 File Offset: 0x00035800
	public void method_40(NPCAnimationManagerFSM npcanimationManagerFSM_0)
	{
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Move", new AnimationMoveState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Hurt", new AnimationHurtState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("AdvanceSpawn", new AnimationAdvanceSpawnState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("CombatSpawn", new AnimationCombatSpawnState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("SuicideBomb", new AnimationSuicideBombState());
	}

	// Token: 0x06000066 RID: 102 RVA: 0x00037690 File Offset: 0x00035890
	public void method_41(NPCAnimationManagerFSM npcanimationManagerFSM_0)
	{
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Move", new AnimationMoveState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Hurt", new AnimationHurtState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("MeleeAttack", new AnimationMeleeAttackState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("ThrowWeapon", new AnimationThrowWeaponState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Spawn", new AnimationSpawnState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Roll", new AnimationRollState());
	}

	// Token: 0x06000067 RID: 103 RVA: 0x0003773C File Offset: 0x0003593C
	public void method_42(NPCAnimationManagerFSM npcanimationManagerFSM_0)
	{
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Move", new AnimationMoveState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("MoveWithFacing", new AnimationMoveWithFacingState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Hurt", new AnimationHurtState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Roll", new AnimationRollState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Warning", new AnimationWarningState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("CombatSpawn", new AnimationCombatSpawnState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("MeleeAttack", new AnimationMeleeAttackState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("ThrowWeapon", new AnimationThrowWeaponState());
		npcanimationManagerFSM_0.m_upperBodyStateMachine = new AnimationStateMachine();
		npcanimationManagerFSM_0.m_upperBodyStateMachine.States.Add("Fire", new AnimationFireState());
		npcanimationManagerFSM_0.m_upperBodyStateMachine.States.Add("Reload", new AnimationReloadState());
		npcanimationManagerFSM_0.m_upperBodyStateMachine.States.Add("Empty", new AnimationEmptyState());
	}

	// Token: 0x06000068 RID: 104 RVA: 0x00037874 File Offset: 0x00035A74
	public void method_43(NPCAnimationManagerFSM npcanimationManagerFSM_0)
	{
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Move", new AnimationMoveState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("MoveWithFacing", new AnimationMoveWithFacingState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("CoverIdleBeforeFire", new AnimationCoverIdleBeforeFireState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("CoverIdle", new AnimationCoverIdleState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("CoverLookAround", new AnimationCoverLookAroundState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("CoverPeakIn", new AnimationCoverPeakInState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("CoverPeakOut", new AnimationCoverPeakOutState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Hurt", new AnimationHurtState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Roll", new AnimationRollState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Warning", new AnimationWarningState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("AdvanceSpawn", new AnimationAdvanceSpawnState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("CombatSpawn", new AnimationCombatSpawnState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("MeleeAttack", new AnimationMeleeAttackState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("ThrowWeapon", new AnimationThrowWeaponState());
		npcanimationManagerFSM_0.m_upperBodyStateMachine = new AnimationStateMachine();
		npcanimationManagerFSM_0.m_upperBodyStateMachine.States.Add("Fire", new AnimationFireState());
		npcanimationManagerFSM_0.m_upperBodyStateMachine.States.Add("Reload", new AnimationReloadState());
		npcanimationManagerFSM_0.m_upperBodyStateMachine.States.Add("CoverFire", new AnimationCoverFireState());
		npcanimationManagerFSM_0.m_upperBodyStateMachine.States.Add("CoverReload", new AnimationCoverReloadState());
		npcanimationManagerFSM_0.m_upperBodyStateMachine.States.Add("Empty", new AnimationEmptyState());
	}

	// Token: 0x06000069 RID: 105 RVA: 0x00003400 File Offset: 0x00001600
	public void method_44(NPCAnimationManagerFSM npcanimationManagerFSM_0)
	{
		this.method_43(npcanimationManagerFSM_0);
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("DeployAidStation", new AnimationDeployAidStationState());
	}

	// Token: 0x0600006A RID: 106 RVA: 0x00037A7C File Offset: 0x00035C7C
	public void method_45(NPCAnimationManagerFSM npcanimationManagerFSM_0)
	{
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Move", new AnimationMoveState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("MoveWithFacing", new AnimationMoveWithFacingState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Hurt", new AnimationHurtState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Warning", new AnimationWarningState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("AdvanceSpawn", new AnimationAdvanceSpawnState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("CombatSpawn", new AnimationCombatSpawnState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("MeleeAttack", new AnimationMeleeAttackState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("ThrowWeapon", new AnimationThrowWeaponState());
		npcanimationManagerFSM_0.m_upperBodyStateMachine = new AnimationStateMachine();
		npcanimationManagerFSM_0.m_upperBodyStateMachine.States.Add("Fire", new AnimationFireState());
		npcanimationManagerFSM_0.m_upperBodyStateMachine.States.Add("Reload", new AnimationReloadState());
		npcanimationManagerFSM_0.m_upperBodyStateMachine.States.Add("Empty", new AnimationEmptyState());
	}

	// Token: 0x0600006B RID: 107 RVA: 0x00037BB4 File Offset: 0x00035DB4
	public void method_46(NPCAnimationManagerFSM npcanimationManagerFSM_0)
	{
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("SlideMove", new AnimationSlideMoveState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Hurt", new AnimationHurtState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("CombatSpawn", new AnimationCombatSpawnState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("MeleeAttack", new AnimationMeleeAttackState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("ShowWeapon", new AnimationShowWeaponState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("ThrowWeapon", new AnimationThrowWeaponState());
	}

	// Token: 0x0600006C RID: 108 RVA: 0x00003423 File Offset: 0x00001623
	public void method_47(NPCAnimationManagerFSM npcanimationManagerFSM_0)
	{
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Hurt", new AnimationHurtState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("CircleMove", new AnimationCircleMoveState());
	}

	// Token: 0x0600006D RID: 109 RVA: 0x00037C60 File Offset: 0x00035E60
	public void method_48(NPCAnimationManagerFSM npcanimationManagerFSM_0)
	{
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Spawn", new AnimationSpawnState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Remove("Alert");
		npcanimationManagerFSM_0.m_animationStateMachine.States.Remove("TurnTo");
	}

	// Token: 0x0600006E RID: 110 RVA: 0x00037CB4 File Offset: 0x00035EB4
	public void method_49(NPCAnimationManagerFSM npcanimationManagerFSM_0)
	{
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Move", new AnimationMoveState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Hurt", new AnimationHurtState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("FireFullBody", new AnimationFireFullBodyState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("AdvanceSpawn", new AnimationAdvanceSpawnState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("CombatSpawn", new AnimationCombatSpawnState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("MeleeAttack", new AnimationMeleeAttackState());
		npcanimationManagerFSM_0.m_upperBodyStateMachine = new AnimationStateMachine();
		npcanimationManagerFSM_0.m_upperBodyStateMachine.States.Add("Reload", new AnimationReloadState());
		npcanimationManagerFSM_0.m_upperBodyStateMachine.States.Add("Empty", new AnimationEmptyState());
	}

	// Token: 0x0600006F RID: 111 RVA: 0x00037D9C File Offset: 0x00035F9C
	public void method_50(NPCAnimationManagerFSM npcanimationManagerFSM_0)
	{
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("HoverPatrol", new AnimationHoverPatrolState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Hurt", new AnimationHurtState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("FlyGather", new AnimationFlyGatherState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("FlyMeleeAttack", new AnimationFlyMeleeAttackState());
	}

	// Token: 0x06000070 RID: 112 RVA: 0x00037E14 File Offset: 0x00036014
	public void method_51(NPCAnimationManagerFSM npcanimationManagerFSM_0)
	{
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("FireFullBody", new AnimationFireFullBodyState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Spawn", new AnimationSpawnState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Remove("Alert");
		npcanimationManagerFSM_0.m_animationStateMachine.States.Remove("TurnTo");
	}

	// Token: 0x06000071 RID: 113 RVA: 0x00037E84 File Offset: 0x00036084
	public void method_52(NPCAnimationManagerFSM npcanimationManagerFSM_0)
	{
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Move", new AnimationMoveState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("MoveWithFacing", new AnimationMoveWithFacingState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Warning", new AnimationWarningState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Hurt", new AnimationHurtState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("AdvanceSpawn", new AnimationAdvanceSpawnState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("CombatSpawn", new AnimationCombatSpawnState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("JumpAttack", new AnimationJumpAttackState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("MeleeAttack", new AnimationMeleeAttackState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("LavaStrike", new AnimationLavaStrikeState());
		npcanimationManagerFSM_0.m_upperBodyStateMachine = new AnimationStateMachine();
		npcanimationManagerFSM_0.m_upperBodyStateMachine.States.Add("Fire", new AnimationFireState());
		npcanimationManagerFSM_0.m_upperBodyStateMachine.States.Add("Reload", new AnimationReloadState());
		npcanimationManagerFSM_0.m_upperBodyStateMachine.States.Add("Empty", new AnimationEmptyState());
	}

	// Token: 0x06000072 RID: 114 RVA: 0x00037FD4 File Offset: 0x000361D4
	public void method_53(NPCAnimationManagerFSM npcanimationManagerFSM_0)
	{
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Move", new AnimationMoveState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Hurt", new AnimationHurtState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Warning", new AnimationWarningState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("AdvanceSpawn", new AnimationAdvanceSpawnState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("CombatSpawn", new AnimationCombatSpawnState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("MeleeAttack", new AnimationMeleeAttackState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("JumpAttack", new AnimationJumpAttackState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("JumpAttackCrash", new AnimationJumpAttackCrashState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Charge", new AnimationChargeState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("ChargeHit", new AnimationChargeHitState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Spacing", new AnimationSpacingState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("RailgunAttack", new AnimationRailgunAttackState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("MortarAttack", new AnimationMortarAttackState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("TurnOnSpot", new AnimationTurnOnSpotState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("LaserSweep", new AnimationLaserSweepState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Critical", new AnimationCriticalState());
	}

	// Token: 0x06000073 RID: 115 RVA: 0x00038184 File Offset: 0x00036384
	public void method_54(NPCAnimationManagerFSM npcanimationManagerFSM_0)
	{
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Move", new AnimationMoveState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Spawn", new AnimationSpawnState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Stun", new AnimationStunState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Spacing", new AnimationSpacingState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("MeleeAttack", new AnimationMeleeAttackState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("RadiusAttack", new AnimationRadiusAttackState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("IceMeteorAttack", new AnimationIceMeteorAttackState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Charge", new AnimationChargeState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("ChargeHit", new AnimationChargeHitState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("SummonExtraNPC", new AnimationSummonExtraNPCState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Warcry", new AnimationWarcryState());
	}

	// Token: 0x06000074 RID: 116 RVA: 0x000382B0 File Offset: 0x000364B0
	public void method_55(NPCAnimationManagerFSM npcanimationManagerFSM_0)
	{
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Move", new AnimationMoveState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Spawn", new AnimationSpawnState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("CombatSpawn", new AnimationCombatSpawnState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Stun", new AnimationStunState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Spacing", new AnimationSpacingState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("JumpAttack", new AnimationJumpAttackState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("JumpAttackCrash", new AnimationJumpAttackCrashState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("MeleeAttack", new AnimationMeleeAttackState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("RadiusAttack", new AnimationRadiusAttackState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Burrow", new AnimationBurrowState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Charge", new AnimationChargeState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("ChargeHit", new AnimationChargeHitState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Critical", new AnimationCriticalState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Warcry", new AnimationWarcryState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("WebTrap", new AnimationWebTrapState());
	}

	// Token: 0x06000075 RID: 117 RVA: 0x00038444 File Offset: 0x00036644
	public void method_56(NPCAnimationManagerFSM npcanimationManagerFSM_0)
	{
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Move", new AnimationMoveState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("TutorialLesson", new AnimationTutorialLessonState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("TutorialAction", new AnimationTutorialActionState());
	}

	// Token: 0x06000076 RID: 118 RVA: 0x00003459 File Offset: 0x00001659
	public void method_57(NPCAnimationManagerFSM npcanimationManagerFSM_0)
	{
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Hurt", new AnimationHurtState());
	}

	// Token: 0x06000077 RID: 119 RVA: 0x00003475 File Offset: 0x00001675
	public void method_58(NPCAnimationManagerFSM npcanimationManagerFSM_0)
	{
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("MeleeAttack", new AnimationMeleeAttackState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Spawn", new AnimationSpawnState());
	}

	// Token: 0x06000078 RID: 120 RVA: 0x000384A0 File Offset: 0x000366A0
	public void method_59(NPCAnimationManagerFSM npcanimationManagerFSM_0)
	{
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Move", new AnimationMoveState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("MeleeAttack", new AnimationMeleeAttackState());
		npcanimationManagerFSM_0.m_animationStateMachine.States.Add("Spawn", new AnimationSpawnState());
	}

	// Token: 0x06000079 RID: 121 RVA: 0x000034AB File Offset: 0x000016AB
	public void method_60(NPCAnimationManagerFSM npcanimationManagerFSM_0)
	{
		npcanimationManagerFSM_0.m_animationStateMachine.States.Remove("Alert");
		npcanimationManagerFSM_0.m_animationStateMachine.States.Remove("TurnTo");
	}

	// Token: 0x04000028 RID: 40
	private static readonly AIServiceSetting s_instance = new AIServiceSetting();

	// Token: 0x04000029 RID: 41
	public Dictionary<uint, Dictionary<Type, BHVTaskSettings>> m_settingList = new Dictionary<uint, Dictionary<Type, BHVTaskSettings>>();

	// Token: 0x0400002A RID: 42
	public List<string> m_npcTaskSettingLoadedList = new List<string>();

	// Token: 0x0400002B RID: 43
	public Dictionary<uint, BHVAnimationManagerSetup> m_npcAnimationMgrSetupList = new Dictionary<uint, BHVAnimationManagerSetup>();

	// Token: 0x0400002C RID: 44
	private Dictionary<int, BHVTask> m_taskLUT = new Dictionary<int, BHVTask>();

	// Token: 0x0400002D RID: 45
	private Dictionary<string, AnimationStateBase> m_animStateList = new Dictionary<string, AnimationStateBase>();

	// Token: 0x0400002E RID: 46
	public XmlSerializer m_taskSerializer = new XmlSerializer(typeof(BHVTaskManagerSetup));

	// Token: 0x0400002F RID: 47
	public XmlSerializer m_animationSerializer = new XmlSerializer(typeof(BHVAnimationManagerSetup));
}
