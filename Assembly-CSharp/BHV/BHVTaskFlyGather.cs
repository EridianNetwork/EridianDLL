using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x02000184 RID: 388
	public class BHVTaskFlyGather : BHVTask
	{
		// Token: 0x060008B5 RID: 2229 RVA: 0x00008BEE File Offset: 0x00006DEE
		public BHVTaskFlyGather()
		{
			base.m_Type = BHVTaskType.FlyGather;
		}

		// Token: 0x060008B6 RID: 2230 RVA: 0x00008BFE File Offset: 0x00006DFE
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamFlyGather_0 = bhvtaskParam_0 as BHVTaskParamFlyGather;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x060008B7 RID: 2231 RVA: 0x00008C13 File Offset: 0x00006E13
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamFlyGather_0;
		}

		// Token: 0x060008B8 RID: 2232 RVA: 0x0005C12C File Offset: 0x0005A32C
		public override void Start()
		{
			base.Start();
			this.animationFlyGatherState_0 = this.bhvtaskManager_0.m_animationManagerFSM.method_16("FlyGather") as AnimationFlyGatherState;
			this.bhvtaskManager_0.m_animationManagerFSM.vmethod_7(AnimationStateFSM.FlyGather);
			this.bhvflyingSettings_0 = this.bhvtaskManager_0.vmethod_0<BHVFlyingSettings>();
			this.vector3_0 = this.bhvtaskParamFlyGather_0.vector3_0;
			base.m_Status = BHVTaskStatus.RUNNING;
			this.bhvtaskManager_0.m_animationManagerFSM.m_validateNextMovePosition = false;
			this.float_0 = -1f;
			this.bool_1 = false;
		}

		// Token: 0x060008B9 RID: 2233 RVA: 0x00008C1B File Offset: 0x00006E1B
		public override void Update(float deltaTime)
		{
			if (base.m_Status == BHVTaskStatus.SUCCESS)
			{
				return;
			}
			base.Update(deltaTime);
		}

		// Token: 0x060008BA RID: 2234 RVA: 0x0005C1BC File Offset: 0x0005A3BC
		private void method_0(float float_1)
		{
			Vector3 vector = this.vector3_0 - this.bhvtaskManager_0.m_entity.method_1();
			Vector3 vector2 = vector.normalized;
			if (vector.sqrMagnitude < 0.02f)
			{
				base.m_Status = BHVTaskStatus.SUCCESS;
				return;
			}
			this.float_0 -= float_1;
			if (this.float_0 < 0f)
			{
				this.float_0 = 1f;
				int num = ~(1 << LayerMask.NameToLayer("Ignore Raycast"));
				Vector3 vector3 = this.bhvtaskManager_0.m_entity.transform.position + vector2 * 1f;
				float num2 = this.bhvflyingSettings_0.m_gatherFlyingSpeed * float_1;
				RaycastHit raycastHit;
				if (this.bool_1 = Physics.Raycast(vector3, vector2, out raycastHit, num2, num))
				{
					this.vector3_1 = this.bhvtaskManager_0.m_entity.transform.position;
					this.vector3_1.y = this.vector3_0.y;
				}
			}
			if (this.bool_1)
			{
				vector = this.vector3_1 - this.bhvtaskManager_0.m_entity.transform.position;
				vector2 = vector.normalized;
			}
			this.method_1(float_1, vector2, vector);
		}

		// Token: 0x060008BB RID: 2235 RVA: 0x0005C2F8 File Offset: 0x0005A4F8
		private void method_1(float float_1, Vector3 vector3_2, Vector3 vector3_3)
		{
			float num = Vector3.Angle(this.bhvtaskManager_0.m_entity.transform.forward, vector3_2);
			float num2 = Mathf.Lerp(1f, 0.1f, num / 180f);
			float num3 = this.bhvflyingSettings_0.m_gatherFlyingSpeed * float_1 * num2;
			float magnitude = vector3_3.magnitude;
			if (magnitude < num3)
			{
				num3 = magnitude;
			}
			this.bhvtaskManager_0.m_entity.transform.position += vector3_2 * num3;
			if (!this.bool_1)
			{
				this.bhvtaskManager_0.m_entity.transform.forward = Vector3.Slerp(this.bhvtaskManager_0.m_entity.transform.forward, vector3_2, 0.1f);
			}
			else
			{
				this.bhvtaskManager_0.m_entity.transform.forward = Vector3.Slerp(this.bhvtaskManager_0.m_entity.transform.forward, vector3_2, 0.8f);
			}
			Vector3 normalized = (this.bhvtaskManager_0.m_entity.transform.position - this.vector3_0).normalized;
			float num4 = Vector3.Dot(normalized, vector3_2);
			num4 = ((num4 <= 0f) ? (-1f * num) : num);
			if (num4 < -15f)
			{
				num4 = -90f;
			}
			else if (num4 > 15f)
			{
				num4 = 90f;
			}
			else
			{
				num4 = 0f;
			}
			this.animationFlyGatherState_0.m_turnAngle = Mathf.Lerp(this.animationFlyGatherState_0.m_turnAngle, num4, 0.1f);
		}

		// Token: 0x0400081B RID: 2075
		private BHVTaskParamFlyGather bhvtaskParamFlyGather_0;

		// Token: 0x0400081C RID: 2076
		private AnimationFlyGatherState animationFlyGatherState_0;

		// Token: 0x0400081D RID: 2077
		private BHVFlyingSettings bhvflyingSettings_0;

		// Token: 0x0400081E RID: 2078
		private Vector3 vector3_0;

		// Token: 0x0400081F RID: 2079
		private float float_0;

		// Token: 0x04000820 RID: 2080
		private bool bool_1;

		// Token: 0x04000821 RID: 2081
		private Vector3 vector3_1;
	}
}
