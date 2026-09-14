using System;
using System.Collections.Generic;
using ns0;
using UnityEngine;

namespace BHV
{
	// Token: 0x020001C1 RID: 449
	public class BHVTaskEarthPikeAttack : BHVTask
	{
		// Token: 0x060009A9 RID: 2473 RVA: 0x00009B2A File Offset: 0x00007D2A
		public BHVTaskEarthPikeAttack()
		{
			base.m_Type = BHVTaskType.EarthPikeAttack;
		}

		// Token: 0x060009AA RID: 2474 RVA: 0x00009B3A File Offset: 0x00007D3A
		public override bool vmethod_2(BHVTaskParam bhvtaskParam_0)
		{
			this.bhvtaskParamEarthPikeAttack_0 = bhvtaskParam_0 as BHVTaskParamEarthPikeAttack;
			return base.vmethod_2(bhvtaskParam_0);
		}

		// Token: 0x060009AB RID: 2475 RVA: 0x00009B4F File Offset: 0x00007D4F
		public override BHVTaskParam vmethod_0()
		{
			return this.bhvtaskParamEarthPikeAttack_0;
		}

		// Token: 0x060009AC RID: 2476 RVA: 0x0005E9D8 File Offset: 0x0005CBD8
		public override void Start()
		{
			base.Start();
			this.animationRadiusAttackState_0 = this.bhvtaskManager_0.m_animationManagerFSM.method_16("RadiusAttack") as AnimationRadiusAttackState;
			this.bool_1 = false;
			this.float_0 = 0f;
			this.int_0 = this.bhvtaskParamEarthPikeAttack_0.int_4;
			MonoSingleton<Session>.Instance.method_38(out this.list_0);
			if (this.object_0 == null)
			{
				this.object_0 = ResourcesLoader.smethod_0("Entities/Object/Weapon/IcePickEarth");
			}
			this.bhvearthPikeAttackSettings_0 = this.bhvtaskManager_0.vmethod_0<BHVEarthPikeAttackSettings>();
			this.bhvtaskManager_0.m_animationManagerFSM.vmethod_7(AnimationStateFSM.RadiusAttack);
			base.m_Status = BHVTaskStatus.RUNNING;
		}

		// Token: 0x060009AD RID: 2477 RVA: 0x0005EA88 File Offset: 0x0005CC88
		public override void Update(float deltaTime)
		{
			if (base.m_Status == BHVTaskStatus.SUCCESS)
			{
				return;
			}
			if (this.int_0 == 0)
			{
				if (!this.animationRadiusAttackState_0.m_bDoDamage)
				{
					return;
				}
				base.m_Status = BHVTaskStatus.SUCCESS;
			}
			else if (!this.bool_1)
			{
				this.bool_1 = true;
				this.method_0();
			}
			else
			{
				this.float_0 += Time.deltaTime;
				if (this.float_0 > 3f)
				{
					base.m_Status = BHVTaskStatus.SUCCESS;
					return;
				}
			}
		}

		// Token: 0x060009AE RID: 2478 RVA: 0x0005EAFC File Offset: 0x0005CCFC
		public void method_0()
		{
			if (this.object_0 == null)
			{
				return;
			}
			for (int i = 0; i < 4; i++)
			{
				if (this.bhvtaskParamEarthPikeAttack_0.vector3_0[i].sqrMagnitude < 0.1f)
				{
					return;
				}
				float num = 360f / (float)this.bhvearthPikeAttackSettings_0.m_pikeAmount;
				Vector3 vector = Vector3.Normalize(this.bhvtaskParamEarthPikeAttack_0.vector3_0[0]);
				vector.y = 0f;
				for (int j = 0; j < this.bhvearthPikeAttackSettings_0.m_pikeAmount; j++)
				{
					Vector3 vector2 = Quaternion.Euler(0f, num * (float)j, 0f) * vector;
					Vector3 vector3 = this.bhvtaskParamEarthPikeAttack_0.vector3_0[i] + vector2 * this.bhvearthPikeAttackSettings_0.m_distanceToPlayer;
					RaycastHit raycastHit;
					if (Physics.Raycast(vector3 + Vector3.up * 2f, -Vector3.up, out raycastHit, 5f, 1 << LayerMask.NameToLayer("Walkable")))
					{
						vector3 = raycastHit.point;
					}
					vector3.y -= 4.5f;
					GameObject gameObject = (GameObject)global::UnityEngine.Object.Instantiate(this.object_0);
					if (gameObject != null)
					{
						gameObject.transform.position = vector3;
						Quaternion identity = Quaternion.identity;
						Vector3 eulerAngles = identity.eulerAngles;
						eulerAngles.x = 270f;
						eulerAngles.x = global::UnityEngine.Random.Range(eulerAngles.x - 10f, eulerAngles.x + 10f);
						eulerAngles.y = global::UnityEngine.Random.Range(eulerAngles.y - 10f, eulerAngles.y + 10f);
						eulerAngles.z = global::UnityEngine.Random.Range(eulerAngles.z - 10f, eulerAngles.z + 10f);
						identity.eulerAngles = eulerAngles;
						gameObject.transform.rotation = identity;
						IceThorn component = gameObject.GetComponent<IceThorn>();
						if (component != null)
						{
							component.m_HP = this.bhvtaskParamEarthPikeAttack_0.int_3;
							component.m_maxHP = this.bhvtaskParamEarthPikeAttack_0.int_3;
							component.m_BHVTaskManager = this.bhvtaskManager_0;
							component.m_damage = this.bhvearthPikeAttackSettings_0.m_pikeDamage;
							component.m_damageRadius = this.bhvearthPikeAttackSettings_0.m_pikeDamageRadius;
						}
					}
				}
			}
		}

		// Token: 0x040008B7 RID: 2231
		private BHVTaskParamEarthPikeAttack bhvtaskParamEarthPikeAttack_0;

		// Token: 0x040008B8 RID: 2232
		private BHVEarthPikeAttackSettings bhvearthPikeAttackSettings_0;

		// Token: 0x040008B9 RID: 2233
		private AnimationRadiusAttackState animationRadiusAttackState_0;

		// Token: 0x040008BA RID: 2234
		private bool bool_1;

		// Token: 0x040008BB RID: 2235
		private float float_0;

		// Token: 0x040008BC RID: 2236
		private global::UnityEngine.Object object_0;

		// Token: 0x040008BD RID: 2237
		private int int_0;

		// Token: 0x040008BE RID: 2238
		public List<PlayerInfoSync> list_0;
	}
}
