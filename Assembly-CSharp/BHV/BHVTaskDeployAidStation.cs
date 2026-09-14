using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x0200017E RID: 382
	public class BHVTaskDeployAidStation : BHVTask, InstantiateManager.InstanciationClient
	{
		// Token: 0x0600089D RID: 2205 RVA: 0x00008A7C File Offset: 0x00006C7C
		public BHVTaskDeployAidStation()
		{
			base.m_Type = BHVTaskType.DeployAidStation;
		}

		// Token: 0x0600089E RID: 2206 RVA: 0x00008A8C File Offset: 0x00006C8C
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamDeployAidStation_0 = bhvtaskParam_0 as BHVTaskParamDeployAidStation;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x0600089F RID: 2207 RVA: 0x00008AA1 File Offset: 0x00006CA1
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamDeployAidStation_0;
		}

		// Token: 0x060008A0 RID: 2208 RVA: 0x00008AA9 File Offset: 0x00006CA9
		public override void Start()
		{
			base.Start();
			this.animationDeployAidStationState_0 = this.bhvtaskManager_0.m_animationManagerFSM.method_16(Utils.smethod_23(AnimationStateFSM.DeployAidStation)) as AnimationDeployAidStationState;
			this.bhvtaskManager_0.m_animationManagerFSM.vmethod_7(AnimationStateFSM.DeployAidStation);
		}

		// Token: 0x060008A1 RID: 2209 RVA: 0x00008AE5 File Offset: 0x00006CE5
		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			if (this.animationDeployAidStationState_0 != null && this.animationDeployAidStationState_0.m_status == AnimationStatus.SUCCESS)
			{
				base.m_Status = BHVTaskStatus.SUCCESS;
			}
		}

		// Token: 0x060008A2 RID: 2210 RVA: 0x0000311B File Offset: 0x0000131B
		public override void vmethod_3(bool bool_1)
		{
		}

		// Token: 0x060008A3 RID: 2211 RVA: 0x0000311B File Offset: 0x0000131B
		public void OnInstanciate(GameObject instance, InstantiateManager.SpawnRequest request)
		{
		}

		// Token: 0x0400080F RID: 2063
		private BHVTaskParamDeployAidStation bhvtaskParamDeployAidStation_0;

		// Token: 0x04000810 RID: 2064
		private AnimationDeployAidStationState animationDeployAidStationState_0;
	}
}
