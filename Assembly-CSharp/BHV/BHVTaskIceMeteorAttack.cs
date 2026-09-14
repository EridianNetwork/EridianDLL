using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x020001DC RID: 476
	public class BHVTaskIceMeteorAttack : BHVTask
	{
		// Token: 0x06000A2F RID: 2607 RVA: 0x0000A165 File Offset: 0x00008365
		public BHVTaskIceMeteorAttack()
		{
			base.m_Type = BHVTaskType.IceMeteorAttack;
		}

		// Token: 0x06000A30 RID: 2608 RVA: 0x0000A175 File Offset: 0x00008375
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamIceMeteorAttack_0 = bhvtaskParam_0 as BHVTaskParamIceMeteorAttack;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000A31 RID: 2609 RVA: 0x0000A18A File Offset: 0x0000838A
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamIceMeteorAttack_0;
		}

		// Token: 0x06000A32 RID: 2610 RVA: 0x000620AC File Offset: 0x000602AC
		public override void Start()
		{
			base.Start();
			this.float_0 = 0f;
			this.int_0 = 0;
			if (this.object_0 == null)
			{
				this.object_0 = ResourcesLoader.smethod_0("Entities/Object/Weapon/IcePick");
			}
			this.transform_0 = this.bhvtaskManager_0.GetComponent<EntityNpcSpiderantTalos>().m_armorBack;
			this.animationIceMeteorAttackState_0 = this.bhvtaskManager_0.m_animationManagerFSM.method_16("IceMeteorAttack") as AnimationIceMeteorAttackState;
			this.bhvtaskManager_0.m_animationManagerFSM.vmethod_7(AnimationStateFSM.IceMeteorAttack);
			base.m_Status = BHVTaskStatus.RUNNING;
		}

		// Token: 0x06000A33 RID: 2611 RVA: 0x00062140 File Offset: 0x00060340
		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			if (base.m_Status == BHVTaskStatus.SUCCESS)
			{
				return;
			}
			if (this.animationIceMeteorAttackState_0.m_meteorStep != EAnimationMeteorStep.MeteorLoop && this.animationIceMeteorAttackState_0.m_meteorStep != EAnimationMeteorStep.MeteorFinish)
			{
				return;
			}
			this.float_0 += deltaTime;
			if (this.float_0 >= (float)this.bhvtaskParamIceMeteorAttack_0.int_4 * 0.5f)
			{
				this.animationIceMeteorAttackState_0.m_meteorStep = EAnimationMeteorStep.MeteorFinish;
			}
			if (this.int_0 != this.bhvtaskParamIceMeteorAttack_0.int_4 && !(this.bhvtaskParamIceMeteorAttack_0.gameObject_0 == null))
			{
				if (this.int_0 < this.bhvtaskParamIceMeteorAttack_0.int_4 && this.float_0 >= (float)(this.int_0 + 1) * 0.5f)
				{
					this.method_1();
					if (this.bhvtaskManager_0.m_animationManagerFSM.m_VFXManager != null)
					{
						this.bhvtaskManager_0.m_animationManagerFSM.m_VFXManager.method_4(ENPCParticleType.E_IceThorn, 2f, true);
					}
				}
				return;
			}
			this.animationIceMeteorAttackState_0.m_meteorStep = EAnimationMeteorStep.MeteorFinish;
			base.m_Status = BHVTaskStatus.SUCCESS;
		}

		// Token: 0x06000A34 RID: 2612 RVA: 0x00062254 File Offset: 0x00060454
		private void method_0()
		{
			Vector3 normalized = (this.bhvtaskParamIceMeteorAttack_0.gameObject_0.transform.position - this.bhvtaskManager_0.m_entity.transform.position).normalized;
			normalized.y = 0f;
			this.bhvtaskManager_0.m_entity.transform.forward = Vector3.Slerp(this.bhvtaskManager_0.m_entity.transform.forward, normalized, Time.deltaTime * 2f);
		}

		// Token: 0x06000A35 RID: 2613 RVA: 0x000622E0 File Offset: 0x000604E0
		private void method_1()
		{
			GameObject gameObject = (GameObject)global::UnityEngine.Object.Instantiate(this.object_0);
			if (gameObject != null)
			{
				Vector3 position = this.transform_0.position;
				position.y += 1.5f;
				gameObject.transform.position = position;
				gameObject.transform.rotation = this.bhvtaskManager_0.m_entity.transform.rotation;
			}
			this.OnInstanciate(gameObject);
		}

		// Token: 0x06000A36 RID: 2614 RVA: 0x0006235C File Offset: 0x0006055C
		public void OnInstanciate(GameObject instance)
		{
			if (instance != null)
			{
				Vector3 vector = this.bhvtaskParamIceMeteorAttack_0.gameObject_0.transform.position;
				if (this.bhvtaskParamIceMeteorAttack_0.eattackMode_0 == BHVTaskParamIceMeteorAttack.EAttackMode.const_0)
				{
					Vector2 vector2 = global::UnityEngine.Random.insideUnitCircle * global::UnityEngine.Random.Range(0f, this.bhvtaskParamIceMeteorAttack_0.float_0);
					vector.x += vector2.x;
					vector.z += vector2.y;
				}
				else
				{
					float magnitude = (this.bhvtaskParamIceMeteorAttack_0.gameObject_0.transform.position - this.bhvtaskManager_0.m_entity.transform.position).magnitude;
					Vector3 normalized = (this.bhvtaskParamIceMeteorAttack_0.gameObject_0.transform.position - this.bhvtaskManager_0.m_entity.transform.position).normalized;
					normalized.y = 0f;
					Vector3 vector3 = Vector3.Cross(normalized, Vector3.up);
					Vector3 vector4 = vector + this.bhvtaskParamIceMeteorAttack_0.float_1 * (float)(this.bhvtaskParamIceMeteorAttack_0.int_4 - 1) * 0.5f * vector3;
					vector = vector4 - vector3 * this.bhvtaskParamIceMeteorAttack_0.float_1 * (float)this.int_0;
					Vector3 normalized2 = (vector - this.bhvtaskManager_0.m_entity.transform.position).normalized;
					normalized2.y = 0f;
					vector = this.bhvtaskManager_0.m_entity.transform.position + normalized2 * magnitude;
				}
				RaycastHit raycastHit;
				if (Physics.Raycast(vector + Vector3.up * 25f, -Vector3.up, out raycastHit, 27f, 1 << LayerMask.NameToLayer("Walkable")))
				{
					vector = raycastHit.point;
				}
				IcePick component = instance.GetComponent<IcePick>();
				if (component != null)
				{
					component.m_vLandPos = vector;
					component.m_BHVTaskManager = this.bhvtaskManager_0;
					component.m_damageRadius = this.bhvtaskParamIceMeteorAttack_0.float_0;
					component.m_damage = this.bhvtaskParamIceMeteorAttack_0.int_3;
					component.m_flyingCurve = AIServiceCurve.AIServiceCurve_0.method_1(AIServiceCurve.ECurveType.EIcePickAttackFlyingCurve, instance.transform.position, vector, 1f);
				}
				this.int_0++;
			}
		}

		// Token: 0x06000A37 RID: 2615 RVA: 0x0000A192 File Offset: 0x00008392
		public override void vmethod_3(bool bool_1)
		{
			base.vmethod_3(bool_1);
			this.animationIceMeteorAttackState_0.m_meteorStep = EAnimationMeteorStep.MeteorFinish;
		}

		// Token: 0x04000961 RID: 2401
		private BHVTaskParamIceMeteorAttack bhvtaskParamIceMeteorAttack_0;

		// Token: 0x04000962 RID: 2402
		private float float_0;

		// Token: 0x04000963 RID: 2403
		private int int_0;

		// Token: 0x04000964 RID: 2404
		private Transform transform_0;

		// Token: 0x04000965 RID: 2405
		private AnimationIceMeteorAttackState animationIceMeteorAttackState_0;

		// Token: 0x04000966 RID: 2406
		private global::UnityEngine.Object object_0;
	}
}
