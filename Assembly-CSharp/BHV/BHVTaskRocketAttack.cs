using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x02000202 RID: 514
	public class BHVTaskRocketAttack : BHVTask
	{
		// Token: 0x06000AD0 RID: 2768 RVA: 0x0000AAB0 File Offset: 0x00008CB0
		public BHVTaskRocketAttack()
		{
			base.m_Type = BHVTaskType.RocketAttack;
			base.m_Layer = BHVTaskLayer.TOPBODY;
		}

		// Token: 0x06000AD1 RID: 2769 RVA: 0x0000AAC7 File Offset: 0x00008CC7
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamRocketAttack_0 = bhvtaskParam_0 as BHVTaskParamRocketAttack;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000AD2 RID: 2770 RVA: 0x0000AADC File Offset: 0x00008CDC
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamRocketAttack_0;
		}

		// Token: 0x06000AD3 RID: 2771 RVA: 0x00064430 File Offset: 0x00062630
		public override void Start()
		{
			base.Start();
			this.float_0 = 0f;
			this.bool_1 = false;
			this.transform_0 = (this.bhvtaskManager_0.m_entity as EntityNpc).m_leftHandWeaponSlot;
			this.transform_1 = (this.bhvtaskManager_0.m_entity as EntityNpc).m_rightHandWeaponSlot;
			this.object_0 = ResourcesLoader.smethod_0("Entities/Object/Weapon/WPN_Soldier_Turret_Rocket");
			this.bhvtaskTurretRocketSetting_0 = this.bhvtaskManager_0.vmethod_0<BHVTaskTurretRocketSetting>();
		}

		// Token: 0x06000AD4 RID: 2772 RVA: 0x000644AC File Offset: 0x000626AC
		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			if (this.bhvtaskManager_0.m_animationManagerFSM != null && this.bhvtaskManager_0.m_animationManagerFSM.m_animationEventController != null && this.bhvtaskParamRocketAttack_0.gameObject_0 != null)
			{
				this.bhvtaskManager_0.m_animationManagerFSM.m_animationEventController.method_2(this.bhvtaskParamRocketAttack_0.gameObject_0);
			}
			if (this.bhvtaskParamRocketAttack_0.gameObject_0 == null)
			{
				base.m_Status = BHVTaskStatus.SUCCESS;
			}
			if (base.m_Status == BHVTaskStatus.SUCCESS)
			{
				return;
			}
			this.float_0 += deltaTime;
			if (this.float_0 > this.bhvtaskTurretRocketSetting_0.m_fireInterval)
			{
				this.float_0 -= this.bhvtaskTurretRocketSetting_0.m_fireInterval;
				this.method_0();
			}
		}

		// Token: 0x06000AD5 RID: 2773 RVA: 0x00064584 File Offset: 0x00062784
		private void method_0()
		{
			if (this.object_0 == null)
			{
				return;
			}
			Vector3 vector = ((!this.bool_1) ? this.transform_1.position : this.transform_0.position);
			Vector3 normalized = (this.bhvtaskParamRocketAttack_0.gameObject_0.transform.position - vector).normalized;
			global::Debug.smethod_4(vector, this.bhvtaskParamRocketAttack_0.gameObject_0.transform.position, Color.gray);
			this.bool_1 = !this.bool_1;
			Quaternion quaternion = Quaternion.Euler(normalized);
			GameObject gameObject = (GameObject)global::UnityEngine.Object.Instantiate(this.object_0, vector, quaternion);
			if (gameObject != null)
			{
				TurretRocket component = gameObject.GetComponent<TurretRocket>();
				gameObject.transform.forward = normalized;
				component.m_fSpeed = this.bhvtaskTurretRocketSetting_0.m_speed;
				component.m_fLifeTime = this.bhvtaskTurretRocketSetting_0.m_lifeTime;
				component.m_BHVTaskManager = this.bhvtaskManager_0;
				component.m_targetEntity = this.bhvtaskParamRocketAttack_0.gameObject_0.GetComponent<Entity>();
			}
		}

		// Token: 0x06000AD6 RID: 2774 RVA: 0x0000AAE4 File Offset: 0x00008CE4
		public override void vmethod_3(bool bool_2)
		{
			base.vmethod_3(bool_2);
			base.m_Status = BHVTaskStatus.SUCCESS;
		}

		// Token: 0x040009D6 RID: 2518
		private BHVTaskParamRocketAttack bhvtaskParamRocketAttack_0;

		// Token: 0x040009D7 RID: 2519
		private BHVTaskTurretRocketSetting bhvtaskTurretRocketSetting_0;

		// Token: 0x040009D8 RID: 2520
		private float float_0;

		// Token: 0x040009D9 RID: 2521
		private global::UnityEngine.Object object_0;

		// Token: 0x040009DA RID: 2522
		private bool bool_1;

		// Token: 0x040009DB RID: 2523
		private Transform transform_0;

		// Token: 0x040009DC RID: 2524
		private Transform transform_1;
	}
}
