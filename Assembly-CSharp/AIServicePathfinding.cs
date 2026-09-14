using System;
using UnityEngine;

// Token: 0x0200000A RID: 10
public sealed class AIServicePathfinding
{
	// Token: 0x06000027 RID: 39 RVA: 0x000031DA File Offset: 0x000013DA
	private AIServicePathfinding()
	{
	}

	// Token: 0x17000003 RID: 3
	// (get) Token: 0x06000029 RID: 41 RVA: 0x00003216 File Offset: 0x00001416
	public static AIServicePathfinding AIServicePathfinding_0
	{
		get
		{
			return AIServicePathfinding.s_instance;
		}
	}

	// Token: 0x0600002A RID: 42 RVA: 0x0000321D File Offset: 0x0000141D
	public AIServicePathfindingResult method_0(NavMeshAgent navMeshAgent_0, Vector3 vector3_0)
	{
		navMeshAgent_0.SetDestination(vector3_0);
		return AIServicePathfindingResult.SUCCESS;
	}

	// Token: 0x0600002B RID: 43 RVA: 0x00003228 File Offset: 0x00001428
	public AIServicePathfindingResult method_1(NavMeshAgent navMeshAgent_0)
	{
		navMeshAgent_0.ResetPath();
		return AIServicePathfindingResult.SUCCESS;
	}

	// Token: 0x0600002C RID: 44 RVA: 0x00003231 File Offset: 0x00001431
	public AIServicePathfindingResult method_2(NavMeshAgent navMeshAgent_0, float float_0)
	{
		navMeshAgent_0.speed = float_0;
		return AIServicePathfindingResult.SUCCESS;
	}

	// Token: 0x0600002D RID: 45 RVA: 0x0000323B File Offset: 0x0000143B
	public AIServicePathfindingResult method_3(NavMeshAgent navMeshAgent_0, float float_0)
	{
		navMeshAgent_0.angularSpeed = float_0;
		return AIServicePathfindingResult.SUCCESS;
	}

	// Token: 0x0600002E RID: 46 RVA: 0x00003245 File Offset: 0x00001445
	public AIServicePathfindingResult method_4(NavMeshAgent navMeshAgent_0, float float_0)
	{
		navMeshAgent_0.acceleration = float_0;
		return AIServicePathfindingResult.SUCCESS;
	}

	// Token: 0x0600002F RID: 47 RVA: 0x0000324F File Offset: 0x0000144F
	public AIServicePathfindingResult method_5(NavMeshAgent navMeshAgent_0, bool bool_0)
	{
		navMeshAgent_0.updateRotation = bool_0;
		return AIServicePathfindingResult.SUCCESS;
	}

	// Token: 0x06000030 RID: 48 RVA: 0x00003259 File Offset: 0x00001459
	public AIServicePathfindingResult method_6(NavMeshAgent navMeshAgent_0, bool bool_0)
	{
		navMeshAgent_0.updatePosition = bool_0;
		return AIServicePathfindingResult.SUCCESS;
	}

	// Token: 0x06000031 RID: 49 RVA: 0x000358DC File Offset: 0x00033ADC
	public Vector3 method_7(float float_0, NavMeshAgent navMeshAgent_0)
	{
		Vector3 vector = navMeshAgent_0.transform.position + this.method_12(navMeshAgent_0) * float_0;
		vector.y = navMeshAgent_0.transform.position.y;
		return vector;
	}

	// Token: 0x06000032 RID: 50 RVA: 0x00003263 File Offset: 0x00001463
	public AIServicePathfindingResult method_8(float float_0, NavMeshAgent navMeshAgent_0)
	{
		navMeshAgent_0.transform.position = this.method_7(float_0, navMeshAgent_0);
		return AIServicePathfindingResult.SUCCESS;
	}

	// Token: 0x06000033 RID: 51 RVA: 0x00035924 File Offset: 0x00033B24
	public bool method_9(Vector3 vector3_0)
	{
		NavMeshHit navMeshHit;
		if (NavMesh.SamplePosition(vector3_0, out navMeshHit, 1f, 2147483647))
		{
			Vector3 vector = vector3_0 - navMeshHit.position;
			vector.y = 0f;
			if (vector.sqrMagnitude < 0.03f)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06000034 RID: 52 RVA: 0x00035970 File Offset: 0x00033B70
	public bool method_10(NavMeshAgent navMeshAgent_0, Vector3 vector3_0, out Vector3 vector3_1)
	{
		NavMeshHit navMeshHit;
		navMeshAgent_0.Raycast(vector3_0, out navMeshHit);
		if (navMeshHit.hit)
		{
			vector3_1 = navMeshHit.position;
			vector3_1 += navMeshHit.normal * 0.01f;
			vector3_1.y = vector3_0.y;
			return true;
		}
		vector3_1 = vector3_0;
		return false;
	}

	// Token: 0x06000035 RID: 53 RVA: 0x0000311D File Offset: 0x0000131D
	public AIServicePathfindingStatus method_11(NavMeshAgent navMeshAgent_0)
	{
		return AIServicePathfindingStatus.FAILED;
	}

	// Token: 0x06000036 RID: 54 RVA: 0x000359D8 File Offset: 0x00033BD8
	public Vector3 method_12(NavMeshAgent navMeshAgent_0)
	{
		if (navMeshAgent_0 == null)
		{
			return Vector2.zero;
		}
		Vector3 desiredVelocity = navMeshAgent_0.desiredVelocity;
		desiredVelocity.y = 0f;
		return desiredVelocity;
	}

	// Token: 0x06000037 RID: 55 RVA: 0x00035A10 File Offset: 0x00033C10
	public Vector3 method_13(NavMeshAgent navMeshAgent_0)
	{
		if (navMeshAgent_0 == null)
		{
			return Vector3.zero;
		}
		Vector3 desiredVelocity = navMeshAgent_0.desiredVelocity;
		desiredVelocity.y = 0f;
		if (desiredVelocity.sqrMagnitude <= 1E-45f)
		{
			return Vector3.zero;
		}
		return desiredVelocity.normalized;
	}

	// Token: 0x06000038 RID: 56 RVA: 0x00035A5C File Offset: 0x00033C5C
	public bool method_14(NavMeshAgent navMeshAgent_0, Vector3 vector3_0)
	{
		Vector3 vector = navMeshAgent_0.destination - vector3_0;
		vector.y = 0f;
		return vector.sqrMagnitude <= navMeshAgent_0.stoppingDistance * navMeshAgent_0.stoppingDistance;
	}

	// Token: 0x06000039 RID: 57 RVA: 0x00035A9C File Offset: 0x00033C9C
	public bool method_15(NavMeshAgent navMeshAgent_0, Vector3 vector3_0)
	{
		NavMeshHit navMeshHit;
		return navMeshAgent_0 == null || navMeshAgent_0.Raycast(vector3_0, out navMeshHit);
	}

	// Token: 0x04000023 RID: 35
	[HideInInspector]
	public int m_activeMavMeshLayer = 1;

	// Token: 0x04000024 RID: 36
	public float m_normalSpawnMoveDistance = 2f;

	// Token: 0x04000025 RID: 37
	public float m_advanceSpawnMoveDistance = 2f;

	// Token: 0x04000026 RID: 38
	public float m_combatSpawnMoveDistance = 2f;

	// Token: 0x04000027 RID: 39
	private static readonly AIServicePathfinding s_instance = new AIServicePathfinding();
}
