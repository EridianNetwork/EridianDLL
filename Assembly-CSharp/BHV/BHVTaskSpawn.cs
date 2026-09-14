using System;

namespace BHV
{
	// Token: 0x02000198 RID: 408
	public class BHVTaskSpawn : BHVTaskAnimationState
	{
		// Token: 0x0600090E RID: 2318 RVA: 0x0000913C File Offset: 0x0000733C
		public BHVTaskSpawn()
		{
			base.m_Type = BHVTaskType.Spawn;
		}

		// Token: 0x0600090F RID: 2319 RVA: 0x0000914C File Offset: 0x0000734C
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamSpawn_0 = bhvtaskParam_0 as BHVTaskParamSpawn;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000910 RID: 2320 RVA: 0x00009161 File Offset: 0x00007361
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamSpawn_0;
		}

		// Token: 0x06000911 RID: 2321 RVA: 0x0005D32C File Offset: 0x0005B52C
		public override void Start()
		{
			base.Start();
			if (this.bhvtaskParamSpawn_0.float_0 > 0f)
			{
				AnimationSpawnState animationSpawnState = this.bhvtaskManager_0.m_animationManagerFSM.method_16(Utils.smethod_23(AnimationStateFSM.Spawn)) as AnimationSpawnState;
				if (animationSpawnState != null)
				{
					animationSpawnState.m_spawnDuration = this.bhvtaskParamSpawn_0.float_0;
				}
			}
		}

		// Token: 0x06000912 RID: 2322 RVA: 0x00009169 File Offset: 0x00007369
		public override void Update(float deltaTime)
		{
			base.Update(deltaTime, AnimationStateFSM.Spawn);
			this.bhvtaskManager_0.m_animationManagerFSM.Animator_0.SetBool("IsSpawn", true);
		}

		// Token: 0x0400085C RID: 2140
		private BHVTaskParamSpawn bhvtaskParamSpawn_0;
	}
}
