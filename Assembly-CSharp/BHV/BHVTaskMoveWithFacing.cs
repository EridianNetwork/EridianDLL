using System;
using System.Text;
using UnityEngine;

namespace BHV
{
	// Token: 0x0200018D RID: 397
	public class BHVTaskMoveWithFacing : BHVTask
	{
		// Token: 0x060008DE RID: 2270 RVA: 0x00008DD1 File Offset: 0x00006FD1
		public BHVTaskMoveWithFacing()
		{
			base.m_Type = BHVTaskType.MoveWithFacing;
		}

		// Token: 0x060008DF RID: 2271 RVA: 0x00008DE0 File Offset: 0x00006FE0
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamMoveWithFacing_0 = bhvtaskParam_0 as BHVTaskParamMoveWithFacing;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x060008E0 RID: 2272 RVA: 0x00008DF5 File Offset: 0x00006FF5
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamMoveWithFacing_0;
		}

		// Token: 0x060008E1 RID: 2273 RVA: 0x0005CD00 File Offset: 0x0005AF00
		public override void Start()
		{
			base.Start();
			this.animationMoveWithFacingState_0 = this.bhvtaskManager_0.m_animationManagerFSM.m_animationStateMachine["MoveWithFacing"] as AnimationMoveWithFacingState;
			if (this.animationMoveWithFacingState_0 != null)
			{
				this.animationMoveWithFacingState_0.m_moveSpeed = this.bhvtaskManager_0.method_19(this.bhvtaskParamMoveWithFacing_0.bhvmovementSpeed_0, this.bhvtaskParamMoveWithFacing_0.bhvstressLevel_0);
				this.animationMoveWithFacingState_0.m_isSprint = this.bhvtaskParamMoveWithFacing_0.bhvmovementSpeed_0 == BHVMovementSpeed.SPRINT;
			}
			this.bhvtaskManager_0.m_animationManagerFSM.Boolean_1 = true;
			this.bhvtaskManager_0.m_animationManagerFSM.BHVStressLevel_0 = this.bhvtaskParamMoveWithFacing_0.bhvstressLevel_0;
			this.bhvtaskManager_0.m_animationManagerFSM.Boolean_0 = this.method_0();
			this.bhvtaskManager_0.m_animationManagerFSM.vmethod_7(AnimationStateFSM.MoveWithFacing);
		}

		// Token: 0x060008E2 RID: 2274 RVA: 0x00008DFD File Offset: 0x00006FFD
		private bool method_0()
		{
			return this.bhvtaskParamMoveWithFacing_0 != null && !(this.bhvtaskParamMoveWithFacing_0.gameObject_0 == null);
		}

		// Token: 0x060008E3 RID: 2275 RVA: 0x0005CDD8 File Offset: 0x0005AFD8
		public void method_1(float float_0)
		{
			if (this.animationMoveWithFacingState_0 != null)
			{
				Vector3 normalized = this.bhvtaskManager_0.m_animationManagerFSM.m_movementSync.Velocity.normalized;
				float num = this.method_2(this.bhvtaskManager_0.transform, normalized);
				this.animationMoveWithFacingState_0.method_4(num);
			}
		}

		// Token: 0x060008E4 RID: 2276 RVA: 0x0005CE2C File Offset: 0x0005B02C
		public float method_2(Transform transform_0, Vector3 vector3_0)
		{
			Vector3 forward = transform_0.forward;
			forward.y = 0f;
			vector3_0.y = 0f;
			float num = Vector3.Angle(forward, vector3_0);
			float num2 = Vector3.Dot(vector3_0, transform_0.right);
			return (num2 <= 0f) ? (360f - num) : num;
		}

		// Token: 0x060008E5 RID: 2277 RVA: 0x00008E1F File Offset: 0x0000701F
		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			this.method_1(deltaTime);
		}

		// Token: 0x060008E6 RID: 2278 RVA: 0x00008E2F File Offset: 0x0000702F
		public override void vmethod_3(bool bool_1)
		{
			base.vmethod_3(bool_1);
		}

		// Token: 0x060008E7 RID: 2279 RVA: 0x0005CE80 File Offset: 0x0005B080
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder(base.ToString());
			if (this.bhvtaskParamMoveWithFacing_0 != null)
			{
				float num = 0f;
				if (this.bhvtaskManager_0.m_animationManagerFSM != null)
				{
					num = this.bhvtaskManager_0.m_animationManagerFSM.Single_1;
				}
				stringBuilder.Append(string.Format("        StressLevel:{0} - MovementSpeed:{1} - FacingAngle:{2}\n", this.bhvtaskParamMoveWithFacing_0.bhvstressLevel_0, this.bhvtaskParamMoveWithFacing_0.bhvmovementSpeed_0, num));
			}
			return stringBuilder.ToString();
		}

		// Token: 0x04000842 RID: 2114
		private BHVTaskParamMoveWithFacing bhvtaskParamMoveWithFacing_0;

		// Token: 0x04000843 RID: 2115
		private AnimationMoveWithFacingState animationMoveWithFacingState_0;
	}
}
