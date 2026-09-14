using System;

namespace BHV
{
	// Token: 0x02000191 RID: 401
	public class BHVTaskRespawn : BHVTask
	{
		// Token: 0x060008F4 RID: 2292 RVA: 0x00008F2E File Offset: 0x0000712E
		public BHVTaskRespawn()
		{
			base.m_Type = BHVTaskType.Respawn;
		}

		// Token: 0x060008F5 RID: 2293 RVA: 0x00008F3E File Offset: 0x0000713E
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamRespawn_0 = bhvtaskParam_0 as BHVTaskParamRespawn;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x060008F6 RID: 2294 RVA: 0x00008F53 File Offset: 0x00007153
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamRespawn_0;
		}

		// Token: 0x060008F7 RID: 2295 RVA: 0x0005D0EC File Offset: 0x0005B2EC
		public override void Start()
		{
			base.Start();
			this.float_0 = 0f;
			if (this.bhvtaskManager_0.m_entity != null && this.bhvtaskManager_0.m_entity as EntityNpc != null)
			{
				(this.bhvtaskManager_0.m_entity as EntityNpc).m_bClusterNameSetuped = false;
				(this.bhvtaskManager_0.m_entity as EntityNpc).method_10();
			}
			base.m_Status = BHVTaskStatus.RUNNING;
		}

		// Token: 0x060008F8 RID: 2296 RVA: 0x0005D168 File Offset: 0x0005B368
		public override void Update(float deltaTime)
		{
			if (base.m_Status == BHVTaskStatus.SUCCESS)
			{
				return;
			}
			base.Update(deltaTime);
			if ((this.bhvtaskManager_0.m_animationManagerFSM as NPCAnimationManagerFSM).m_bTeleportEnd)
			{
				this.float_0 += deltaTime;
				if (this.float_0 < 0.5f)
				{
					return;
				}
				base.m_Status = BHVTaskStatus.SUCCESS;
			}
		}

		// Token: 0x060008F9 RID: 2297 RVA: 0x0005D1C0 File Offset: 0x0005B3C0
		public override void vmethod_3(bool bool_1)
		{
			base.vmethod_3(bool_1);
			(this.bhvtaskManager_0.m_animationManagerFSM as NPCAnimationManagerFSM).method_30();
			BHVTaskUtils.smethod_15(this.bhvtaskManager_0.gameObject, false);
			(this.bhvtaskManager_0.m_animationManagerFSM as NPCAnimationManagerFSM).m_bTeleportEnd = false;
			if (this.bhvtaskManager_0.m_navAgent != null)
			{
				this.bhvtaskManager_0.m_navAgent.Warp(this.bhvtaskParamRespawn_0.vector3_0);
			}
		}

		// Token: 0x04000849 RID: 2121
		private BHVTaskParamRespawn bhvtaskParamRespawn_0;

		// Token: 0x0400084A RID: 2122
		private float float_0;
	}
}
