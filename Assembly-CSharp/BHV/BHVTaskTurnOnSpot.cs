using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x0200019C RID: 412
	public class BHVTaskTurnOnSpot : BHVTask
	{
		// Token: 0x0600091E RID: 2334 RVA: 0x00009255 File Offset: 0x00007455
		public BHVTaskTurnOnSpot()
		{
			base.m_Type = BHVTaskType.TurnOnSpot;
		}

		// Token: 0x0600091F RID: 2335 RVA: 0x00009264 File Offset: 0x00007464
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamTurnOnSpot_0 = bhvtaskParam_0 as BHVTaskParamTurnOnSpot;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000920 RID: 2336 RVA: 0x00009279 File Offset: 0x00007479
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamTurnOnSpot_0;
		}

		// Token: 0x06000921 RID: 2337 RVA: 0x0005D384 File Offset: 0x0005B584
		public override void Start()
		{
			base.Start();
			this.animationTurnOnSpotState_0 = this.bhvtaskManager_0.m_animationManagerFSM.method_16("TurnOnSpot") as AnimationTurnOnSpotState;
			this.animationTurnOnSpotState_0.m_finalFacing = (this.bhvtaskParamTurnOnSpot_0.gameObject_0.transform.position - this.bhvtaskManager_0.m_entity.method_1()).normalized;
			this.bhvtaskManager_0.m_animationManagerFSM.Boolean_1 = true;
			this.bhvtaskManager_0.m_animationManagerFSM.vmethod_7(AnimationStateFSM.TurnOnSpot);
			base.m_Status = BHVTaskStatus.RUNNING;
		}

		// Token: 0x06000922 RID: 2338 RVA: 0x0005D420 File Offset: 0x0005B620
		public override void Update(float deltaTime)
		{
			if (base.m_Status == BHVTaskStatus.SUCCESS)
			{
				return;
			}
			if (this.animationTurnOnSpotState_0 == null)
			{
				return;
			}
			if (this.animationTurnOnSpotState_0.m_status == AnimationStatus.SUCCESS)
			{
				base.m_Status = BHVTaskStatus.SUCCESS;
			}
			else
			{
				if (this.bhvtaskParamTurnOnSpot_0 == null)
				{
					return;
				}
				if (this.bhvtaskParamTurnOnSpot_0.gameObject_0 == null)
				{
					return;
				}
				if (this.bhvtaskManager_0.m_entity == null)
				{
					return;
				}
				Vector3 vector = this.bhvtaskParamTurnOnSpot_0.gameObject_0.transform.position - this.bhvtaskManager_0.m_entity.method_1();
				vector.y = 0f;
				if (vector.sqrMagnitude < 0.09f)
				{
					base.m_Status = BHVTaskStatus.SUCCESS;
				}
				else
				{
					this.animationTurnOnSpotState_0.m_finalFacing = vector.normalized;
					this.animationTurnOnSpotState_0.m_finalFacing.y = 0f;
				}
			}
		}

		// Token: 0x06000923 RID: 2339 RVA: 0x00009281 File Offset: 0x00007481
		public override void vmethod_3(bool bool_1)
		{
			base.vmethod_3(bool_1);
			this.bhvtaskManager_0.m_animationManagerFSM.Boolean_1 = false;
		}

		// Token: 0x04000860 RID: 2144
		private BHVTaskParamTurnOnSpot bhvtaskParamTurnOnSpot_0;

		// Token: 0x04000861 RID: 2145
		private AnimationTurnOnSpotState animationTurnOnSpotState_0;
	}
}
