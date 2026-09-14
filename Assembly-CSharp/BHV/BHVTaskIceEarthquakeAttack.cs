using System;
using UnityEngine;

namespace BHV
{
	// Token: 0x020001D9 RID: 473
	public class BHVTaskIceEarthquakeAttack : BHVTask
	{
		// Token: 0x06000A23 RID: 2595 RVA: 0x0000A102 File Offset: 0x00008302
		public BHVTaskIceEarthquakeAttack()
		{
			base.m_Type = BHVTaskType.IceEarthquakeAttack;
		}

		// Token: 0x06000A24 RID: 2596 RVA: 0x0000A112 File Offset: 0x00008312
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamIceEarthquakeAttack_0 = bhvtaskParam_0 as BHVTaskParamIceEarthquakeAttack;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x06000A25 RID: 2597 RVA: 0x0000A127 File Offset: 0x00008327
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamIceEarthquakeAttack_0;
		}

		// Token: 0x06000A26 RID: 2598 RVA: 0x00061C6C File Offset: 0x0005FE6C
		public override void Start()
		{
			base.Start();
			this.animationRadiusAttackState_0 = this.bhvtaskManager_0.m_animationManagerFSM.method_16("RadiusAttack") as AnimationRadiusAttackState;
			this.int_0 = 0;
			this.vector3_0 = this.bhvtaskManager_0.m_entity.transform.position;
			this.vector3_1 = this.bhvtaskManager_0.m_entity.transform.forward;
			this.bhvtaskManager_0.m_animationManagerFSM.vmethod_7(AnimationStateFSM.RadiusAttack);
			if (this.object_0 == null)
			{
				this.object_0 = ResourcesLoader.smethod_0("Entities/Object/Weapon/IceThorn");
			}
			base.m_Status = BHVTaskStatus.RUNNING;
		}

		// Token: 0x06000A27 RID: 2599 RVA: 0x00061D14 File Offset: 0x0005FF14
		public override void Update(float deltaTime)
		{
			this.method_0();
			if (!this.animationRadiusAttackState_0.m_bDoDamage)
			{
				return;
			}
			if (this.int_0 < this.bhvtaskParamIceEarthquakeAttack_0.int_3 && !(this.bhvtaskParamIceEarthquakeAttack_0.gameObject_0 == null))
			{
				this.float_0 += deltaTime;
				if (this.float_0 > this.bhvtaskParamIceEarthquakeAttack_0.float_1)
				{
					this.float_0 = 0f;
					Vector3 vector = this.method_1(this.int_0);
					this.method_2(vector);
					this.vector3_0 = vector;
					this.int_0++;
				}
				return;
			}
			base.m_Status = BHVTaskStatus.SUCCESS;
		}

		// Token: 0x06000A28 RID: 2600 RVA: 0x00061DB8 File Offset: 0x0005FFB8
		private void method_0()
		{
			if (this.bhvtaskParamIceEarthquakeAttack_0.gameObject_0 == null)
			{
				return;
			}
			Vector3 normalized = (this.bhvtaskParamIceEarthquakeAttack_0.gameObject_0.transform.position - this.bhvtaskManager_0.m_entity.transform.position).normalized;
			normalized.y = 0f;
			this.bhvtaskManager_0.m_entity.transform.forward = Vector3.Slerp(this.bhvtaskManager_0.m_entity.transform.forward, normalized, Time.deltaTime * 2f);
		}

		// Token: 0x06000A29 RID: 2601 RVA: 0x00061E58 File Offset: 0x00060058
		private Vector3 method_1(int int_1)
		{
			if (int_1 < this.bhvtaskParamIceEarthquakeAttack_0.int_5)
			{
				this.vector3_1 = (this.bhvtaskParamIceEarthquakeAttack_0.gameObject_0.transform.position - this.vector3_0).normalized;
				this.vector3_1.y = 0f;
			}
			Vector3 vector = this.vector3_0 + this.vector3_1 * this.bhvtaskParamIceEarthquakeAttack_0.float_2;
			RaycastHit raycastHit;
			if (Physics.Raycast(vector + Vector3.up * 2f, -Vector3.up, out raycastHit, 3f, 1 << LayerMask.NameToLayer("Walkable")))
			{
				vector = raycastHit.point;
			}
			else
			{
				vector = this.vector3_0;
			}
			return vector;
		}

		// Token: 0x06000A2A RID: 2602 RVA: 0x00061F24 File Offset: 0x00060124
		private void method_2(Vector3 vector3_2)
		{
			if (this.object_0 == null)
			{
				return;
			}
			GameObject gameObject = (GameObject)global::UnityEngine.Object.Instantiate(this.object_0);
			if (gameObject != null)
			{
				vector3_2.y -= 0.6f;
				gameObject.transform.position = vector3_2;
				Quaternion identity = Quaternion.identity;
				Vector3 eulerAngles = identity.eulerAngles;
				eulerAngles.x = 270f;
				eulerAngles.x = global::UnityEngine.Random.Range(eulerAngles.x - 30f, eulerAngles.x + 30f);
				eulerAngles.y = global::UnityEngine.Random.Range(eulerAngles.y - 30f, eulerAngles.y + 30f);
				eulerAngles.z = global::UnityEngine.Random.Range(eulerAngles.z - 30f, eulerAngles.z + 30f);
				identity.eulerAngles = eulerAngles;
				gameObject.transform.rotation = identity;
				global::UnityEngine.Object.Destroy(gameObject, 3f);
			}
		}

		// Token: 0x04000950 RID: 2384
		private BHVTaskParamIceEarthquakeAttack bhvtaskParamIceEarthquakeAttack_0;

		// Token: 0x04000951 RID: 2385
		private AnimationRadiusAttackState animationRadiusAttackState_0;

		// Token: 0x04000952 RID: 2386
		private int int_0;

		// Token: 0x04000953 RID: 2387
		private float float_0;

		// Token: 0x04000954 RID: 2388
		private Vector3 vector3_0;

		// Token: 0x04000955 RID: 2389
		private Vector3 vector3_1;

		// Token: 0x04000956 RID: 2390
		private global::UnityEngine.Object object_0;
	}
}
