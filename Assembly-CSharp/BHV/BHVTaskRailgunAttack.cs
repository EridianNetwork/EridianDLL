using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x020001FE RID: 510
	public class BHVTaskRailgunAttack : BHVTask
	{
		// Token: 0x06000ABF RID: 2751 RVA: 0x0000A9C4 File Offset: 0x00008BC4
		public BHVTaskRailgunAttack()
		{
			base.m_Type = BHVTaskType.RailgunAttack;
		}

		// Token: 0x06000AC0 RID: 2752 RVA: 0x0000A9D4 File Offset: 0x00008BD4
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamRailgunAttack_0 = bhvtaskParam_0 as BHVTaskParamRailgunAttack;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000AC1 RID: 2753 RVA: 0x0000A9E9 File Offset: 0x00008BE9
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamRailgunAttack_0;
		}

		// Token: 0x06000AC2 RID: 2754 RVA: 0x00064128 File Offset: 0x00062328
		public override void Start()
		{
			base.Start();
			this.float_0 = 0f;
			this.bool_1 = false;
			this.animationRailgunAttackState_0 = this.bhvtaskManager_0.m_animationManagerFSM.method_16("RailgunAttack") as AnimationRailgunAttackState;
			global::UnityEngine.Object @object = ResourcesLoader.smethod_0("Entities/Object/Weapon/PlasmaBall");
			this.method_0(@object, (this.bhvtaskManager_0.m_entity as EntityNpc).m_leftHandWeaponSlot);
			this.method_0(@object, (this.bhvtaskManager_0.m_entity as EntityNpc).m_rightHandWeaponSlot);
			base.m_Status = BHVTaskStatus.RUNNING;
		}

		// Token: 0x06000AC3 RID: 2755 RVA: 0x000641B8 File Offset: 0x000623B8
		public override void Update(float deltaTime)
		{
			this.method_1();
			this.float_0 += Time.deltaTime;
			if (this.float_0 < 1f)
			{
				return;
			}
			if (!this.bool_1)
			{
				this.bool_1 = true;
				this.bhvtaskManager_0.m_animationManagerFSM.vmethod_7(AnimationStateFSM.RailgunAttack);
			}
			if (this.animationRailgunAttackState_0.m_status == AnimationStatus.SUCCESS && this.float_0 > 2f)
			{
				base.m_Status = BHVTaskStatus.SUCCESS;
			}
		}

		// Token: 0x06000AC4 RID: 2756 RVA: 0x00064230 File Offset: 0x00062430
		private void method_0(global::UnityEngine.Object object_0, Transform transform_0)
		{
			if (object_0 == null)
			{
				return;
			}
			GameObject gameObject = (GameObject)global::UnityEngine.Object.Instantiate(object_0, transform_0.position, transform_0.rotation);
			if (gameObject != null)
			{
				gameObject.transform.parent = transform_0;
				PlasmaBall component = gameObject.GetComponent<PlasmaBall>();
				if (component != null)
				{
					component.m_damageRadius = this.bhvtaskParamRailgunAttack_0.float_2;
					component.m_flyingSpeed = this.bhvtaskParamRailgunAttack_0.float_1;
					component.m_damageDuration = this.bhvtaskParamRailgunAttack_0.float_3;
					component.m_damage = this.bhvtaskParamRailgunAttack_0.float_0;
					component.m_chargeTime = 1f;
					component.m_BHVTaskManager = this.bhvtaskManager_0;
					component.m_attackObject = this.bhvtaskParamRailgunAttack_0.gameObject_0;
					component.m_vTargetPos = this.bhvtaskParamRailgunAttack_0.gameObject_0.transform.position + Vector3.up * 1.4f;
				}
			}
		}

		// Token: 0x06000AC5 RID: 2757 RVA: 0x00064328 File Offset: 0x00062528
		private void method_1()
		{
			if (this.bhvtaskParamRailgunAttack_0.gameObject_0 == null)
			{
				return;
			}
			Vector3 normalized = (this.bhvtaskParamRailgunAttack_0.gameObject_0.transform.position - this.bhvtaskManager_0.m_entity.transform.position).normalized;
			normalized.y = 0f;
			this.bhvtaskManager_0.m_entity.transform.forward = Vector3.Slerp(this.bhvtaskManager_0.m_entity.transform.forward, normalized, Time.deltaTime * 2f);
		}

		// Token: 0x040009CF RID: 2511
		private BHVTaskParamRailgunAttack bhvtaskParamRailgunAttack_0;

		// Token: 0x040009D0 RID: 2512
		private AnimationRailgunAttackState animationRailgunAttackState_0;

		// Token: 0x040009D1 RID: 2513
		private float float_0;

		// Token: 0x040009D2 RID: 2514
		private bool bool_1;
	}
}
