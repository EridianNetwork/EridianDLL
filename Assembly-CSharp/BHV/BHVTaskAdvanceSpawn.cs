using System;

namespace BHV
{
	// Token: 0x02000171 RID: 369
	public class BHVTaskAdvanceSpawn : BHVTaskAnimationState
	{
		// Token: 0x0600086F RID: 2159 RVA: 0x00008753 File Offset: 0x00006953
		public BHVTaskAdvanceSpawn()
		{
			base.m_Type = BHVTaskType.AdvanceSpawn;
		}

		// Token: 0x06000870 RID: 2160 RVA: 0x00008763 File Offset: 0x00006963
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamAdvanceSpawn_0 = bhvtaskParam_0 as BHVTaskParamAdvanceSpawn;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000871 RID: 2161 RVA: 0x00008778 File Offset: 0x00006978
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamAdvanceSpawn_0;
		}

		// Token: 0x06000872 RID: 2162 RVA: 0x0005B90C File Offset: 0x00059B0C
		public override void Start()
		{
			base.Start();
			if (this.bhvtaskParamAdvanceSpawn_0.eadvanceSpawnType_0 == BHVTaskParamAdvanceSpawn.EAdvanceSpawnType.const_1)
			{
				AnimationCombatSpawnState animationCombatSpawnState = this.bhvtaskManager_0.m_animationManagerFSM.method_16(Utils.smethod_23(AnimationStateFSM.CombatSpawn)) as AnimationCombatSpawnState;
				if (animationCombatSpawnState != null)
				{
					animationCombatSpawnState.m_walkAfterSpawnTime = this.bhvtaskManager_0.vmethod_0<BHVNavAgentSettings>().m_combatSpawnDuration;
					animationCombatSpawnState.m_moveSpeed = this.bhvtaskManager_0.method_19(BHVMovementSpeed.RUN, BHVStressLevel.COMBAT);
					animationCombatSpawnState.m_destinationFacing = this.bhvtaskManager_0.transform.forward;
					this.bhvtaskManager_0.m_animationManagerFSM.Single_1 = 0f;
				}
				EquipmentInventoryEntityNpc component = this.bhvtaskManager_0.GetComponent<EquipmentInventoryEntityNpc>();
				if (component != null)
				{
					component.m_npcNameFromCluster = this.bhvtaskParamAdvanceSpawn_0.string_0;
				}
				BHVTaskUtils.smethod_15(this.bhvtaskManager_0.gameObject, false);
			}
		}

		// Token: 0x06000873 RID: 2163 RVA: 0x00008780 File Offset: 0x00006980
		public override void Update(float deltaTime)
		{
			if (this.bhvtaskParamAdvanceSpawn_0.eadvanceSpawnType_0 == BHVTaskParamAdvanceSpawn.EAdvanceSpawnType.const_0)
			{
				base.Update(deltaTime, AnimationStateFSM.AdvanceSpawn);
			}
			else
			{
				base.Update(deltaTime, AnimationStateFSM.CombatSpawn);
			}
			this.bhvtaskManager_0.m_entity.vmethod_49();
		}

		// Token: 0x06000874 RID: 2164 RVA: 0x0005B9DC File Offset: 0x00059BDC
		public override void vmethod_3(bool bool_1)
		{
			base.vmethod_3(bool_1);
			if (this.bhvtaskManager_0.m_animationManagerFSM != null)
			{
				NPCAnimationManagerFSM npcanimationManagerFSM = this.bhvtaskManager_0.m_animationManagerFSM as NPCAnimationManagerFSM;
				if (npcanimationManagerFSM != null)
				{
					npcanimationManagerFSM.method_23(false);
				}
			}
		}

		// Token: 0x040007FB RID: 2043
		private BHVTaskParamAdvanceSpawn bhvtaskParamAdvanceSpawn_0;
	}
}
