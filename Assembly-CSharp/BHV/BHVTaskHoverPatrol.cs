using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x02000186 RID: 390
	public class BHVTaskHoverPatrol : BHVTask
	{
		// Token: 0x060008BE RID: 2238 RVA: 0x00008C67 File Offset: 0x00006E67
		public BHVTaskHoverPatrol()
		{
			base.m_Type = BHVTaskType.HoverPatrol;
		}

		// Token: 0x060008BF RID: 2239 RVA: 0x00008C77 File Offset: 0x00006E77
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamHoverPatrol_0 = bhvtaskParam_0 as BHVTaskParamHoverPatrol;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x060008C0 RID: 2240 RVA: 0x00008C8C File Offset: 0x00006E8C
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamHoverPatrol_0;
		}

		// Token: 0x060008C1 RID: 2241 RVA: 0x0005C488 File Offset: 0x0005A688
		public override void Start()
		{
			base.Start();
			this.animationHoverPatrolState_0 = this.bhvtaskManager_0.m_animationManagerFSM.method_16("HoverPatrol") as AnimationHoverPatrolState;
			this.bhvtaskManager_0.m_animationManagerFSM.vmethod_7(AnimationStateFSM.HoverPatrol);
			this.bhvflyingSettings_0 = this.bhvtaskManager_0.vmethod_0<BHVFlyingSettings>();
			this.bool_1 = false;
			this.method_0();
			this.bhvtaskManager_0.m_animationManagerFSM.m_validateNextMovePosition = false;
		}

		// Token: 0x060008C2 RID: 2242 RVA: 0x00008C94 File Offset: 0x00006E94
		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			if (!this.bool_1)
			{
				return;
			}
		}

		// Token: 0x060008C3 RID: 2243 RVA: 0x0005C4FC File Offset: 0x0005A6FC
		private void method_0()
		{
			Vector3 normalized = (this.bhvtaskParamHoverPatrol_0.vector3_0 - this.bhvtaskManager_0.m_entity.transform.position).normalized;
			normalized.y = 0f;
			this.vector3_0 = this.bhvtaskParamHoverPatrol_0.vector3_0 + Vector3.Cross(normalized, Vector3.up) * this.bhvflyingSettings_0.m_hoverPatrolRadius;
		}

		// Token: 0x060008C4 RID: 2244 RVA: 0x0005C574 File Offset: 0x0005A774
		private void method_1(float float_0)
		{
			Vector3 vector = this.vector3_0 - this.bhvtaskManager_0.m_entity.method_1();
			Vector3 normalized = vector.normalized;
			if (vector.sqrMagnitude < 2.25f)
			{
				this.bool_1 = true;
				return;
			}
			this.method_3(float_0, normalized);
		}

		// Token: 0x060008C5 RID: 2245 RVA: 0x0005C5C4 File Offset: 0x0005A7C4
		private void method_2(float float_0)
		{
			Vector3 vector = (this.bhvtaskManager_0.m_entity.transform.position - this.bhvtaskParamHoverPatrol_0.vector3_0).normalized;
			vector.y = 0f;
			vector = Quaternion.Euler(0f, 3f, 0f) * vector;
			Vector3 vector2 = this.bhvtaskParamHoverPatrol_0.vector3_0 + vector * this.bhvflyingSettings_0.m_hoverPatrolRadius;
			Vector3 normalized = (vector2 - this.bhvtaskManager_0.m_entity.transform.position).normalized;
			this.method_3(float_0, normalized);
		}

		// Token: 0x060008C6 RID: 2246 RVA: 0x0005C678 File Offset: 0x0005A878
		private void method_3(float float_0, Vector3 vector3_1)
		{
			float num = Vector3.Angle(this.bhvtaskManager_0.m_entity.transform.forward, vector3_1);
			float num2 = Mathf.Lerp(1f, 0.1f, num / 180f);
			float num3 = this.bhvflyingSettings_0.m_patrolFlyingSpeed * float_0 * num2;
			this.bhvtaskManager_0.m_entity.transform.position += vector3_1 * num3;
			this.bhvtaskManager_0.m_entity.transform.forward = Vector3.Slerp(this.bhvtaskManager_0.m_entity.transform.forward, vector3_1, 0.2f);
			Vector3 normalized = (this.bhvtaskManager_0.m_entity.transform.position - this.bhvtaskParamHoverPatrol_0.vector3_0).normalized;
			float num4 = Vector3.Dot(normalized, vector3_1);
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
			this.animationHoverPatrolState_0.m_turnAngle = Mathf.Lerp(this.animationHoverPatrolState_0.m_turnAngle, num4, 0.1f);
		}

		// Token: 0x04000823 RID: 2083
		private BHVTaskParamHoverPatrol bhvtaskParamHoverPatrol_0;

		// Token: 0x04000824 RID: 2084
		private AnimationHoverPatrolState animationHoverPatrolState_0;

		// Token: 0x04000825 RID: 2085
		private BHVFlyingSettings bhvflyingSettings_0;

		// Token: 0x04000826 RID: 2086
		private bool bool_1;

		// Token: 0x04000827 RID: 2087
		private Vector3 vector3_0;
	}
}
