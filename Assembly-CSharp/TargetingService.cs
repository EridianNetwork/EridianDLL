using System;
using System.Collections.Generic;
using BHV;
using ns0;
using UnityEngine;

// Token: 0x02000580 RID: 1408
public class TargetingService
{
	// Token: 0x170001C9 RID: 457
	// (get) Token: 0x06002437 RID: 9271 RVA: 0x00018B6A File Offset: 0x00016D6A
	// (set) Token: 0x06002438 RID: 9272 RVA: 0x00018B71 File Offset: 0x00016D71
	public static int Int32_0
	{
		get
		{
			return TargetingService.s_staticRaycastMask;
		}
		private set
		{
			TargetingService.s_staticRaycastMask = value;
		}
	}

	// Token: 0x170001CA RID: 458
	// (get) Token: 0x06002439 RID: 9273 RVA: 0x00018B79 File Offset: 0x00016D79
	// (set) Token: 0x0600243A RID: 9274 RVA: 0x00018B80 File Offset: 0x00016D80
	public static int Int32_1
	{
		get
		{
			return TargetingService.s_staticRaycastMask_Movement;
		}
		private set
		{
			TargetingService.s_staticRaycastMask_Movement = value;
		}
	}

	// Token: 0x0600243B RID: 9275 RVA: 0x000ACC3C File Offset: 0x000AAE3C
	public static bool smethod_0(Ray ray_0, float float_0)
	{
		RaycastHit[] array = Physics.RaycastAll(ray_0, float_0, TargetingService.s_staticRaycastMask);
		for (int i = 0; i < array.Length; i++)
		{
			if (!array[i].collider.isTrigger)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600243C RID: 9276 RVA: 0x00018B88 File Offset: 0x00016D88
	public static Entity smethod_1(Vector3 vector3_0, Vector3 vector3_1, Entity entity_0, out Collider collider_0, ref float float_0, ColliderType colliderType_0 = ColliderType.WeakPoint, bool bool_0 = false)
	{
		TargetingService.s_ray.origin = vector3_0;
		TargetingService.s_ray.direction = vector3_1.normalized;
		return TargetingService.smethod_2(TargetingService.s_ray, entity_0, out collider_0, ref float_0, colliderType_0, bool_0);
	}

	// Token: 0x0600243D RID: 9277 RVA: 0x000ACC7C File Offset: 0x000AAE7C
	public static Entity smethod_2(Ray ray_0, Entity entity_0, out Collider collider_0, ref float float_0, ColliderType colliderType_0 = ColliderType.WeakPoint, bool bool_0 = false)
	{
		float num = float_0;
		Entity entity = null;
		collider_0 = null;
		RaycastHit raycastHit = default(RaycastHit);
		if (MonoSingleton<Session>.Instance)
		{
			DamageManager damageManager_ = DamageManager.DamageManager_0;
			if (damageManager_ != null)
			{
				List<Entity> list = damageManager_.method_0();
				for (int i = 0; i < list.Count; i++)
				{
					Entity entity2 = list[i];
					if (!(entity2 == null) && ((entity_0 != null && (entity2.vmethod_9() != entity_0.vmethod_9() || bool_0) && entity2 != entity_0) || (entity_0 == null && entity2 != entity_0)))
					{
						Vector3 vector = entity2.transform.position - ray_0.origin;
						Vector3 direction = ray_0.direction;
						vector.y = 0f;
						direction.y = 0f;
						if (Vector3.Dot(vector, direction) > 0f)
						{
							CollisionManager collisionManager = entity2.vmethod_21();
							if (collisionManager != null)
							{
								switch (colliderType_0)
								{
								case ColliderType.WeakPoint:
								{
									Collider collider = collisionManager.method_13();
									if ((collider != null && collider.bounds.Contains(ray_0.origin)) || collisionManager.method_4(ray_0, out raycastHit, ref num))
									{
										num = float_0;
										if (entity2.vmethod_21().method_3(ray_0, out raycastHit, ref num))
										{
											TargetingService.s_lastHitInfo = raycastHit;
											entity = entity2;
											collider_0 = raycastHit.collider;
											float_0 = raycastHit.distance;
										}
									}
									break;
								}
								case ColliderType.BoundingBox:
									if (collisionManager.method_4(ray_0, out raycastHit, ref num))
									{
										TargetingService.s_lastHitInfo = raycastHit;
										entity = entity2;
										collider_0 = raycastHit.collider;
										float_0 = raycastHit.distance;
									}
									break;
								case ColliderType.MovementBounding:
									if (collisionManager.method_5(ray_0, out raycastHit, ref num))
									{
										TargetingService.s_lastHitInfo = raycastHit;
										entity = entity2;
										collider_0 = raycastHit.collider;
										float_0 = raycastHit.distance;
									}
									break;
								}
							}
						}
					}
				}
				if (entity && TargetingService.smethod_0(ray_0, float_0))
				{
					entity = null;
					collider_0 = null;
				}
			}
		}
		return entity;
	}

	// Token: 0x0600243E RID: 9278 RVA: 0x000ACE94 File Offset: 0x000AB094
	public static bool smethod_3(Ray ray_0, Entity entity_0, Entity entity_1, out Collider collider_0, ref float float_0, ColliderType colliderType_0 = ColliderType.WeakPoint)
	{
		collider_0 = null;
		RaycastHit raycastHit = default(RaycastHit);
		bool flag = false;
		CollisionManager collisionManager = entity_1.vmethod_21();
		if (collisionManager)
		{
			switch (colliderType_0)
			{
			case ColliderType.WeakPoint:
				if (collisionManager.method_3(ray_0, out raycastHit, ref float_0))
				{
					flag = true;
					collider_0 = raycastHit.collider;
					float_0 = raycastHit.distance;
				}
				break;
			case ColliderType.BoundingBox:
				if (collisionManager.method_4(ray_0, out raycastHit, ref float_0))
				{
					flag = true;
					collider_0 = raycastHit.collider;
					float_0 = raycastHit.distance;
				}
				break;
			case ColliderType.MovementBounding:
				if (collisionManager.method_5(ray_0, out raycastHit, ref float_0))
				{
					flag = true;
					collider_0 = raycastHit.collider;
					float_0 = raycastHit.distance;
				}
				break;
			}
			if (flag)
			{
				if (!TargetingService.smethod_0(ray_0, float_0))
				{
					return true;
				}
				collider_0 = null;
			}
		}
		return false;
	}

	// Token: 0x0600243F RID: 9279 RVA: 0x000ACF58 File Offset: 0x000AB158
	public static void smethod_4(Entity entity_0, out Vector3 vector3_0, out Vector3 vector3_1)
	{
		vector3_0 = Vector3.zero;
		vector3_1 = Vector3.zero;
		if (TargetingService.s_lastHitEntity)
		{
			vector3_0 = entity_0.transform.InverseTransformPoint(TargetingService.s_lastHitInfo.point);
			vector3_1 = entity_0.transform.InverseTransformDirection(TargetingService.s_lastHitInfo.normal);
		}
	}

	// Token: 0x06002440 RID: 9280 RVA: 0x000ACFC0 File Offset: 0x000AB1C0
	public static bool smethod_5(Entity entity_0, Entity entity_1)
	{
		if (entity_1 == null || entity_0 == null)
		{
			return false;
		}
		BHVTaskManager bhvtaskManager = entity_0.vmethod_14();
		if (bhvtaskManager == null)
		{
			return false;
		}
		if (entity_0.vmethod_9() == entity_1.vmethod_9())
		{
			return false;
		}
		BHVMeleeAttackSettings bhvmeleeAttackSettings = bhvtaskManager.vmethod_0<BHVMeleeAttackSettings>();
		float num;
		if (bhvmeleeAttackSettings == null)
		{
			BHVFlyMeleeAttackSettings bhvflyMeleeAttackSettings = bhvtaskManager.vmethod_0<BHVFlyMeleeAttackSettings>();
			if (bhvflyMeleeAttackSettings == null)
			{
				return false;
			}
			num = bhvflyMeleeAttackSettings.m_meleeAttackDistanceMax;
		}
		else
		{
			num = bhvmeleeAttackSettings.m_attackRange;
		}
		float sqrMagnitude = (entity_1.method_1() - entity_0.method_1()).sqrMagnitude;
		if (sqrMagnitude < num * num + 1f)
		{
			if (bhvtaskManager.m_actionParameters.m_bIgnoreAngle)
			{
				return true;
			}
			Vector3 normalized = (entity_1.method_1() - entity_0.method_1()).normalized;
			if ((double)Vector3.Angle(entity_0.method_2().forward, normalized) < (double)bhvmeleeAttackSettings.m_attackAngle * 0.5)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06002441 RID: 9281 RVA: 0x000AD0B4 File Offset: 0x000AB2B4
	public static Entity smethod_6(Entity entity_0)
	{
		List<Entity> list = DamageManager.DamageManager_0.method_0();
		Entity entity = null;
		float num = float.PositiveInfinity;
		for (int i = 0; i < list.Count; i++)
		{
			if (TargetingService.smethod_5(entity_0, list[i]))
			{
				Vector3 normalized = (list[i].method_1() - entity_0.method_1()).normalized;
				float num2 = Vector3.Angle(entity_0.method_2().forward, normalized);
				if (num > num2)
				{
					num = num2;
					entity = list[i];
				}
			}
		}
		return entity;
	}

	// Token: 0x040018DA RID: 6362
	private static Ray s_ray;

	// Token: 0x040018DB RID: 6363
	private static Entity s_lastHitEntity = null;

	// Token: 0x040018DC RID: 6364
	private static RaycastHit s_lastHitInfo;

	// Token: 0x040018DD RID: 6365
	private static int s_staticRaycastMask = ~((1 << LayerMask.NameToLayer("WeakPoint")) | (1 << LayerMask.NameToLayer("Charactor")) | (1 << LayerMask.NameToLayer("Ragdoll")) | (1 << LayerMask.NameToLayer("Loot")) | (1 << LayerMask.NameToLayer("Ignore Raycast")) | (1 << LayerMask.NameToLayer("DestructibleObj")) | (1 << LayerMask.NameToLayer("Npc")) | (1 << LayerMask.NameToLayer("diegeticUI")) | (1 << LayerMask.NameToLayer("Firebird")) | (1 << LayerMask.NameToLayer("AreaDamage")) | (1 << LayerMask.NameToLayer("MeshWire")) | (1 << LayerMask.NameToLayer("AirWall")));

	// Token: 0x040018DE RID: 6366
	private static int s_staticRaycastMask_Movement = ~((1 << LayerMask.NameToLayer("WeakPoint")) | (1 << LayerMask.NameToLayer("Charactor")) | (1 << LayerMask.NameToLayer("Ragdoll")) | (1 << LayerMask.NameToLayer("Loot")) | (1 << LayerMask.NameToLayer("Ignore Raycast")) | (1 << LayerMask.NameToLayer("Npc")) | (1 << LayerMask.NameToLayer("diegeticUI")) | (1 << LayerMask.NameToLayer("Firebird")) | (1 << LayerMask.NameToLayer("AreaDamage")));
}
