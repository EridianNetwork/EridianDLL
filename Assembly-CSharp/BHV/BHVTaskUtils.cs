using System;
using System.Collections.Generic;
using ns0;
using UnityEngine;
using XsdSettings;

namespace BHV
{
	// Token: 0x02000248 RID: 584
	public sealed class BHVTaskUtils
	{
		// Token: 0x06000BE6 RID: 3046 RVA: 0x00067C04 File Offset: 0x00065E04
		public static float smethod_0(GameObject gameObject_0, Entity entity_0)
		{
			float num = 0f;
			if (gameObject_0 != null && entity_0 != null)
			{
				float num2 = (gameObject_0.transform.position - entity_0.transform.position).normalized.y;
				if (num2 > 1f)
				{
					num2 = 1f;
				}
				else if (num2 < -1f)
				{
					num2 = -1f;
				}
				num = Mathf.Asin(num2) * 57.29578f;
			}
			return num;
		}

		// Token: 0x06000BE7 RID: 3047 RVA: 0x00067C84 File Offset: 0x00065E84
		public static float smethod_1(Vector3 vector3_0, Entity entity_0)
		{
			float num = 0f;
			if (entity_0 != null)
			{
				Vector3 forward = entity_0.transform.forward;
				forward.y = 0f;
				Vector3 vector = vector3_0 - entity_0.transform.position;
				vector.y = 0f;
				num = BHVTaskUtils.smethod_8(forward.normalized, vector.normalized);
			}
			return num;
		}

		// Token: 0x06000BE8 RID: 3048 RVA: 0x00067CEC File Offset: 0x00065EEC
		public static float smethod_2(Vector3 vector3_0, Vector3 vector3_1)
		{
			float num = 4f;
			float sqrMagnitude = (vector3_1 - vector3_0).sqrMagnitude;
			if (sqrMagnitude <= num)
			{
				return sqrMagnitude / num;
			}
			return 1f;
		}

		// Token: 0x06000BE9 RID: 3049 RVA: 0x00067D1C File Offset: 0x00065F1C
		public static void smethod_3(float float_0, Entity entity_0, Vector3 vector3_0, ref bool bool_0)
		{
			EntityNpc entityNpc = entity_0 as EntityNpc;
			if (entityNpc != null && entityNpc.m_subType == EntityNpc.EntitySubType.CHR_SoldierTurretBasic)
			{
				return;
			}
			float num = 2f;
			float num2 = 5f;
			if (!bool_0)
			{
				bool_0 = float_0 > num && float_0 < 360f - num;
			}
			else
			{
				Vector3 vector = vector3_0 - entity_0.transform.position;
				vector.y = 0f;
				vector.Normalize();
				float num3 = Time.deltaTime * num2;
				if (float_0 >= num3 && float_0 <= 360f - num3)
				{
					entity_0.transform.forward = Vector3.Slerp(entity_0.transform.forward, vector, num3);
				}
				else
				{
					entity_0.transform.forward = vector;
					bool_0 = false;
				}
			}
		}

		// Token: 0x06000BEA RID: 3050 RVA: 0x00067DD8 File Offset: 0x00065FD8
		public static float smethod_4(Vector3 vector3_0, Entity entity_0)
		{
			if (vector3_0.magnitude > 1E-45f)
			{
				entity_0.transform.rotation = Quaternion.LookRotation(vector3_0);
				Vector3 vector = AIServicePathfinding.AIServicePathfinding_0.method_13(entity_0.vmethod_11());
				if (vector.magnitude > 1E-45f)
				{
					return BHVTaskUtils.smethod_8(vector, vector3_0);
				}
			}
			return 0f;
		}

		// Token: 0x06000BEB RID: 3051 RVA: 0x00067E30 File Offset: 0x00066030
		public static EntityPlayer smethod_5(Vector3 vector3_0, Vector3 vector3_1, Entity entity_0, bool bool_0)
		{
			if (MonoSingleton<EntityManager>.Instance == null)
			{
				return null;
			}
			Skeleton skeleton = entity_0.vmethod_17();
			if (skeleton == null)
			{
				return null;
			}
			Transform transform = skeleton.method_7();
			if (transform == null)
			{
				return null;
			}
			Entity entity = null;
			float num = 0.3f;
			List<Entity> list;
			MonoSingleton<EntityManager>.Instance.method_6(Entity.EntityType.Player, out list);
			Vector3 vector = vector3_1 - vector3_0;
			float num2 = vector.magnitude + num;
			Vector3 position = transform.position;
			if (bool_0)
			{
				position.y = vector3_0.y;
			}
			Ray ray = new Ray(position, vector.normalized);
			for (int i = 0; i < list.Count; i++)
			{
				CollisionManager collisionManager = list[i].vmethod_21();
				if (!(collisionManager == null))
				{
					float num3 = num2;
					global::Debug.smethod_4(ray.origin, ray.origin + ray.direction * num3, Color.red);
					RaycastHit raycastHit;
					if (collisionManager.method_3(ray, out raycastHit, ref num3) && raycastHit.distance < num2)
					{
						num2 = raycastHit.distance;
						entity = list[i];
					}
				}
			}
			return (EntityPlayer)entity;
		}

		// Token: 0x06000BEC RID: 3052 RVA: 0x0000311B File Offset: 0x0000131B
		public static void smethod_6(Entity entity_0)
		{
		}

		// Token: 0x06000BED RID: 3053 RVA: 0x00067F5C File Offset: 0x0006615C
		public static float smethod_7(Vector3 vector3_0, Vector3 vector3_1)
		{
			float num = (vector3_0 - vector3_1).normalized.y;
			if (num > 1f)
			{
				num = 1f;
			}
			else if (num < -1f)
			{
				num = -1f;
			}
			return Mathf.Asin(num) * 57.29578f;
		}

		// Token: 0x06000BEE RID: 3054 RVA: 0x00067FB0 File Offset: 0x000661B0
		public static float smethod_8(Vector3 vector3_0, Vector3 vector3_1)
		{
			float num = Vector3.Dot(vector3_0, vector3_1);
			if (num > 1f)
			{
				num = 1f;
			}
			else if (num < -1f)
			{
				num = -1f;
			}
			float num2 = Mathf.Acos(num) * 57.29578f;
			if (Vector3.Cross(vector3_0, vector3_1).y < 0f)
			{
				num2 = 360f - num2;
			}
			return num2;
		}

		// Token: 0x06000BEF RID: 3055 RVA: 0x00068010 File Offset: 0x00066210
		public static AnimationStressLevel smethod_9(BHVStressLevel bhvstressLevel_0)
		{
			if (bhvstressLevel_0 == BHVStressLevel.RELAX)
			{
				return AnimationStressLevel.CASUAL;
			}
			if (bhvstressLevel_0 != BHVStressLevel.COMBAT)
			{
				return AnimationStressLevel.CASUAL;
			}
			return AnimationStressLevel.COMBAT;
		}

		// Token: 0x06000BF0 RID: 3056 RVA: 0x0006802C File Offset: 0x0006622C
		public static void smethod_10(Entity entity_0, bool bool_0)
		{
			if (entity_0 != null)
			{
				NavMeshAgent navMeshAgent = entity_0.vmethod_11();
				if (navMeshAgent && navMeshAgent.collider)
				{
					navMeshAgent.collider.enabled = bool_0;
				}
			}
		}

		// Token: 0x06000BF1 RID: 3057 RVA: 0x0006806C File Offset: 0x0006626C
		public static Transform smethod_11(Transform transform_0)
		{
			for (int i = 0; i < transform_0.childCount; i++)
			{
				Transform child = transform_0.GetChild(i);
				if (child.tag == "Target")
				{
					return child;
				}
			}
			return null;
		}

		// Token: 0x06000BF2 RID: 3058 RVA: 0x000680A8 File Offset: 0x000662A8
		public static void smethod_12(Entity entity_0, Entity entity_1, int int_0, AttackSubType attackSubType_0)
		{
			if (entity_0 == null)
			{
				return;
			}
			if (entity_1 == null)
			{
				return;
			}
			BHVTaskManager bhvtaskManager = entity_0.vmethod_14();
			bhvtaskManager.m_actionParameters.m_targetEntity = entity_1.vmethod_0();
			bhvtaskManager.m_actionParameters.m_meleeDamageAmount = int_0;
			bhvtaskManager.m_actionParameters.m_attackSubType = attackSubType_0;
			bhvtaskManager.m_actionParameters.m_bIgnoreAngle = true;
			entity_0.m_ability.method_5("Melee", true, 0);
		}

		// Token: 0x06000BF3 RID: 3059 RVA: 0x00068118 File Offset: 0x00066318
		public static void smethod_13(Entity entity_0, Entity entity_1, int int_0, AttackSubType attackSubType_0)
		{
			if (entity_0 == null)
			{
				return;
			}
			if (entity_1 == null)
			{
				return;
			}
			BHVTaskManager bhvtaskManager = entity_0.vmethod_14();
			bhvtaskManager.m_actionParameters.m_targetEntity = entity_1.vmethod_0();
			bhvtaskManager.m_actionParameters.m_meleeDamageAmount = int_0;
			bhvtaskManager.m_actionParameters.m_attackSubType = attackSubType_0;
			entity_0.m_ability.method_5("Melee", true, 0);
		}

		// Token: 0x06000BF4 RID: 3060 RVA: 0x0006817C File Offset: 0x0006637C
		public static float smethod_14(Vector3 vector3_0, Vector3 vector3_1, Vector3 vector3_2)
		{
			float sqrMagnitude = (vector3_0 - vector3_2).sqrMagnitude;
			float sqrMagnitude2 = (vector3_1 - vector3_2).sqrMagnitude;
			Vector3 vector = ((sqrMagnitude >= sqrMagnitude2) ? (vector3_2 - vector3_1) : (vector3_2 - vector3_0));
			Vector3 vector2 = ((sqrMagnitude >= sqrMagnitude2) ? (vector3_0 - vector3_1).normalized : (vector3_1 - vector3_0).normalized);
			float num = Vector3.Dot(vector, vector2);
			Vector3 vector3 = ((sqrMagnitude >= sqrMagnitude2) ? vector3_1 : vector3_0);
			if (num > 0f)
			{
				vector3 += vector2 * num;
			}
			return (vector3 - vector3_2).sqrMagnitude;
		}

		// Token: 0x06000BF5 RID: 3061 RVA: 0x00068228 File Offset: 0x00066428
		public static void smethod_15(GameObject gameObject_0, bool bool_0)
		{
			Renderer[] componentsInChildren = gameObject_0.GetComponentsInChildren<Renderer>();
			foreach (Renderer renderer in componentsInChildren)
			{
				renderer.enabled = !bool_0;
			}
		}

		// Token: 0x06000BF6 RID: 3062 RVA: 0x0006825C File Offset: 0x0006645C
		public static void smethod_16(Entity entity_0, bool bool_0)
		{
			Renderer[] componentsInChildren = entity_0.gameObject.GetComponentsInChildren<Renderer>();
			foreach (Renderer renderer in componentsInChildren)
			{
				renderer.enabled = !bool_0;
			}
		}
	}
}
