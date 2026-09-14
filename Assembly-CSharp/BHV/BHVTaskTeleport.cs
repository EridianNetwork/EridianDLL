using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x02000216 RID: 534
	public class BHVTaskTeleport : BHVTask
	{
		// Token: 0x06000B1E RID: 2846 RVA: 0x0000AF41 File Offset: 0x00009141
		public BHVTaskTeleport()
		{
			base.m_Type = BHVTaskType.Teleport;
		}

		// Token: 0x06000B1F RID: 2847 RVA: 0x0000AF51 File Offset: 0x00009151
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamTeleport_0 = bhvtaskParam_0 as BHVTaskParamTeleport;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000B20 RID: 2848 RVA: 0x0000AF66 File Offset: 0x00009166
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamTeleport_0;
		}

		// Token: 0x06000B21 RID: 2849 RVA: 0x00065248 File Offset: 0x00063448
		public override void Start()
		{
			base.Start();
			this.float_0 = 0f;
			this.vector3_0.x = 0f;
			this.vector3_0.y = 1f;
			this.vector3_0.z = 0f;
			this.bool_1 = false;
			this.float_1 = global::UnityEngine.Random.Range(this.bhvtaskParamTeleport_0.float_1, this.bhvtaskParamTeleport_0.float_2);
			if (this.bhvtaskManager_0.m_animationManagerFSM.m_VFXManager != null)
			{
				(this.bhvtaskManager_0.m_animationManagerFSM as NPCAnimationManagerFSM).vmethod_14();
			}
		}

		// Token: 0x06000B22 RID: 2850 RVA: 0x000652EC File Offset: 0x000634EC
		public override void Update(float deltaTime)
		{
			if (base.m_Status == BHVTaskStatus.SUCCESS)
			{
				return;
			}
			this.float_0 += deltaTime;
			if (!this.bool_1)
			{
				if (this.float_0 > this.bhvtaskParamTeleport_0.float_0)
				{
					this.bhvtaskManager_0.m_animationManagerFSM.vmethod_11(true);
					this.method_0(true);
					this.float_0 = 0f;
					this.RPC_TeleportMe();
				}
			}
			else if (this.float_0 > this.float_1)
			{
				if (this.bhvtaskManager_0.m_animationManagerFSM.m_VFXManager != null)
				{
					(this.bhvtaskManager_0.m_animationManagerFSM as NPCAnimationManagerFSM).vmethod_15();
				}
				this.method_0(false);
				this.bhvtaskManager_0.m_animationManagerFSM.vmethod_11(false);
				base.m_Status = BHVTaskStatus.SUCCESS;
			}
		}

		// Token: 0x06000B23 RID: 2851 RVA: 0x000653B4 File Offset: 0x000635B4
		public override void vmethod_3(bool bool_2)
		{
			base.vmethod_3(bool_2);
			if (this.bool_1)
			{
				if (this.bhvtaskManager_0.m_animationManagerFSM.m_VFXManager != null)
				{
					(this.bhvtaskManager_0.m_animationManagerFSM as NPCAnimationManagerFSM).vmethod_15();
				}
				this.method_0(false);
				this.bhvtaskManager_0.m_animationManagerFSM.vmethod_11(false);
			}
		}

		// Token: 0x06000B24 RID: 2852 RVA: 0x00065418 File Offset: 0x00063618
		private void method_0(bool bool_2)
		{
			Renderer[] componentsInChildren = this.bhvtaskManager_0.m_entity.gameObject.GetComponentsInChildren<Renderer>();
			foreach (Renderer renderer in componentsInChildren)
			{
				renderer.enabled = !bool_2;
			}
			this.bool_1 = bool_2;
		}

		// Token: 0x06000B25 RID: 2853 RVA: 0x0000311B File Offset: 0x0000131B
		private void RPC_TeleportMe()
		{
		}

		// Token: 0x04000A13 RID: 2579
		private BHVTaskParamTeleport bhvtaskParamTeleport_0;

		// Token: 0x04000A14 RID: 2580
		private float float_0;

		// Token: 0x04000A15 RID: 2581
		private float float_1;

		// Token: 0x04000A16 RID: 2582
		private Vector3 vector3_0;

		// Token: 0x04000A17 RID: 2583
		private bool bool_1;
	}
}
