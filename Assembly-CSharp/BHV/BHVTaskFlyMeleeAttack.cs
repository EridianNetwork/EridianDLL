using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x020001D1 RID: 465
	public class BHVTaskFlyMeleeAttack : BHVTask
	{
		// Token: 0x060009F8 RID: 2552 RVA: 0x00009ECE File Offset: 0x000080CE
		public BHVTaskFlyMeleeAttack()
		{
			base.m_Type = BHVTaskType.FlyMeleeAttack;
		}

		// Token: 0x060009F9 RID: 2553 RVA: 0x00009EE9 File Offset: 0x000080E9
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamFlyMeleeAttack_0 = bhvtaskParam_0 as BHVTaskParamFlyMeleeAttack;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x060009FA RID: 2554 RVA: 0x00009EFE File Offset: 0x000080FE
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamFlyMeleeAttack_0;
		}

		// Token: 0x060009FB RID: 2555 RVA: 0x00060FBC File Offset: 0x0005F1BC
		public override void Start()
		{
			base.Start();
			this.animationFlyMeleeAttackState_0 = this.bhvtaskManager_0.m_animationManagerFSM.method_16("FlyMeleeAttack") as AnimationFlyMeleeAttackState;
			this.bhvflyingSettings_0 = this.bhvtaskManager_0.vmethod_0<BHVFlyingSettings>();
			this.bhvflyMeleeAttackSettings_0 = this.bhvtaskManager_0.vmethod_0<BHVFlyMeleeAttackSettings>();
			this.bool_1 = false;
			this.bool_2 = false;
			this.float_0 = 0f;
			this.float_3 = 0f;
			this.float_1 = global::UnityEngine.Random.Range(this.bhvflyMeleeAttackSettings_0.m_meleeAttackIdleTimeMin, this.bhvflyMeleeAttackSettings_0.m_meleeAttackIdleTimeMax);
			this.float_4 = -1f;
			this.bool_3 = false;
			if (this.bhvtaskParamFlyMeleeAttack_0.bool_1)
			{
				this.bool_1 = true;
			}
			if (this.bhvtaskParamFlyMeleeAttack_0.gameObject_0 != null)
			{
				float magnitude = (this.bhvtaskManager_0.m_entity.method_1() - this.bhvtaskParamFlyMeleeAttack_0.gameObject_0.transform.position).magnitude;
				float num = magnitude / this.bhvflyingSettings_0.m_meleeFlyingSpeed;
				this.float_5 = num / (num - 0.1f);
			}
			base.m_Status = BHVTaskStatus.RUNNING;
		}

		// Token: 0x060009FC RID: 2556 RVA: 0x000610E8 File Offset: 0x0005F2E8
		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			if (base.m_Status == BHVTaskStatus.SUCCESS)
			{
				return;
			}
			if (this.bhvtaskParamFlyMeleeAttack_0.gameObject_0 == null)
			{
				base.m_Status = BHVTaskStatus.SUCCESS;
				return;
			}
			if (!this.bool_1)
			{
				this.float_1 -= deltaTime;
				if (this.float_1 < 0f)
				{
					this.bool_1 = true;
					this.bhvtaskManager_0.m_animationManagerFSM.vmethod_7(AnimationStateFSM.FlyMeleeAttack);
				}
				this.method_0();
				return;
			}
			if (!this.bool_2)
			{
				float sqrMagnitude = (this.bhvtaskParamFlyMeleeAttack_0.gameObject_0.transform.position - this.bhvtaskManager_0.transform.position).sqrMagnitude;
				float num = this.bhvflyMeleeAttackSettings_0.m_meleeAttackDistanceMax * this.bhvflyMeleeAttackSettings_0.m_meleeAttackDistanceMax;
				if (sqrMagnitude < num)
				{
					this.method_3();
				}
				else
				{
					this.method_1(deltaTime);
				}
				return;
			}
			this.float_2 += deltaTime;
			if (this.float_2 > 2.5f)
			{
				this.animationFlyMeleeAttackState_0.method_5(true);
				base.m_Status = BHVTaskStatus.SUCCESS;
			}
		}

		// Token: 0x060009FD RID: 2557 RVA: 0x00009F06 File Offset: 0x00008106
		public override void vmethod_3(bool bool_4)
		{
			base.vmethod_3(bool_4);
			this.bhvtaskManager_0.m_animationManagerFSM.Boolean_1 = false;
			this.bhvtaskManager_0.m_animationManagerFSM.vmethod_6(false);
		}

		// Token: 0x060009FE RID: 2558 RVA: 0x000611F8 File Offset: 0x0005F3F8
		private void method_0()
		{
			if (this.bhvtaskParamFlyMeleeAttack_0.gameObject_0 == null)
			{
				return;
			}
			Vector3 normalized = (this.bhvtaskParamFlyMeleeAttack_0.gameObject_0.transform.position - this.bhvtaskManager_0.transform.position).normalized;
			normalized.y = 0f;
			this.bhvtaskManager_0.m_entity.transform.forward = Vector3.Slerp(this.bhvtaskManager_0.m_entity.transform.forward, normalized, Time.deltaTime * 2f);
		}

		// Token: 0x060009FF RID: 2559 RVA: 0x00061294 File Offset: 0x0005F494
		private void method_1(float float_6)
		{
			this.float_0 -= float_6;
			if (this.float_0 > 2f)
			{
				this.float_0 = 0f;
			}
			Vector3 vector = this.bhvtaskParamFlyMeleeAttack_0.gameObject_0.transform.position + Vector3.up * 1.6f;
			Vector3 vector2 = vector - this.bhvtaskManager_0.m_entity.transform.position;
			this.float_4 -= float_6;
			if (this.float_4 < 0f)
			{
				this.float_4 = 1f;
				int num = ~(1 << LayerMask.NameToLayer("Ignore Raycast"));
				Vector3 vector3 = this.bhvtaskManager_0.m_entity.transform.position + vector2.normalized * 1f;
				float num2 = (vector - vector3).magnitude - 1f;
				RaycastHit raycastHit;
				if (this.bool_3 = Physics.Raycast(vector3, vector2.normalized, out raycastHit, num2, num))
				{
					this.vector3_0 = this.bhvtaskParamFlyMeleeAttack_0.gameObject_0.transform.position;
					this.vector3_0.y = this.bhvtaskManager_0.m_entity.transform.position.y;
					this.vector3_0 += (this.vector3_0 - vector3).normalized * 5f;
				}
			}
			if (this.bool_3)
			{
				vector2 = this.vector3_0 - this.bhvtaskManager_0.m_entity.transform.position;
			}
			this.method_2(float_6, vector2, 0.1f);
		}

		// Token: 0x06000A00 RID: 2560 RVA: 0x00061458 File Offset: 0x0005F658
		private void method_2(float float_6, Vector3 vector3_1, float float_7)
		{
			Vector3 normalized = vector3_1.normalized;
			float sqrMagnitude = vector3_1.sqrMagnitude;
			this.float_3 += Time.deltaTime * 5f;
			this.float_3 = Mathf.Clamp(this.float_3, 0.1f, this.bhvflyingSettings_0.m_meleeFlyingSpeed);
			float num = Vector3.Angle(this.bhvtaskManager_0.m_entity.transform.forward, normalized);
			float num2 = Mathf.Lerp(1f, 0.1f, num / 180f);
			float num3 = this.float_3 * float_6 * num2;
			num3 *= this.float_5;
			float num4 = this.bhvflyMeleeAttackSettings_0.m_meleeAttackDistanceMax + 6f;
			if (sqrMagnitude < num4 * num4)
			{
				normalized.y = 0f;
				float_7 *= 2f;
			}
			this.bhvtaskManager_0.m_entity.transform.forward = Vector3.Slerp(this.bhvtaskManager_0.m_entity.transform.forward, normalized, float_7);
		}

		// Token: 0x06000A01 RID: 2561 RVA: 0x0006155C File Offset: 0x0005F75C
		private void method_3()
		{
			this.bool_2 = true;
			this.float_2 = 0f;
			this.bhvtaskManager_0.m_animationManagerFSM.Boolean_1 = true;
			this.bhvtaskManager_0.m_animationManagerFSM.vmethod_6(true);
			this.animationFlyMeleeAttackState_0.method_4(true);
			this.method_4();
		}

		// Token: 0x06000A02 RID: 2562 RVA: 0x0000311B File Offset: 0x0000131B
		private void method_4()
		{
		}

		// Token: 0x04000925 RID: 2341
		private AnimationFlyMeleeAttackState animationFlyMeleeAttackState_0;

		// Token: 0x04000926 RID: 2342
		private BHVTaskParamFlyMeleeAttack bhvtaskParamFlyMeleeAttack_0;

		// Token: 0x04000927 RID: 2343
		private BHVFlyingSettings bhvflyingSettings_0;

		// Token: 0x04000928 RID: 2344
		private BHVFlyMeleeAttackSettings bhvflyMeleeAttackSettings_0;

		// Token: 0x04000929 RID: 2345
		private bool bool_1;

		// Token: 0x0400092A RID: 2346
		private bool bool_2;

		// Token: 0x0400092B RID: 2347
		private float float_0;

		// Token: 0x0400092C RID: 2348
		private float float_1;

		// Token: 0x0400092D RID: 2349
		private float float_2;

		// Token: 0x0400092E RID: 2350
		private float float_3;

		// Token: 0x0400092F RID: 2351
		private float float_4;

		// Token: 0x04000930 RID: 2352
		private bool bool_3;

		// Token: 0x04000931 RID: 2353
		private Vector3 vector3_0;

		// Token: 0x04000932 RID: 2354
		private float float_5 = 1f;
	}
}
