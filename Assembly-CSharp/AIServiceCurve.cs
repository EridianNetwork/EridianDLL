using System;
using Core;
using UnityEngine;

// Token: 0x02000005 RID: 5
public sealed class AIServiceCurve
{
	// Token: 0x17000002 RID: 2
	// (get) Token: 0x06000016 RID: 22 RVA: 0x000031AB File Offset: 0x000013AB
	public static AIServiceCurve AIServiceCurve_0
	{
		get
		{
			return AIServiceCurve.s_instance;
		}
	}

	// Token: 0x06000017 RID: 23 RVA: 0x0003450C File Offset: 0x0003270C
	public bool method_0(Entity entity_0, Vector3 vector3_0, Vector3 vector3_1, float float_0, float float_1, float float_2, float float_3 = 1.5f)
	{
		if (entity_0 == null)
		{
			return false;
		}
		float sqrMagnitude = (vector3_1 - vector3_0).sqrMagnitude;
		if (sqrMagnitude > float_1 * float_1)
		{
			return false;
		}
		if (sqrMagnitude < float_0 * float_0)
		{
			return false;
		}
		Vector3 vector = AIServiceCurve.Curve.smethod_0(vector3_0, vector3_1, float_3);
		if (Mathf.Abs(vector3_1.y - vector3_0.y) > float_2)
		{
			return false;
		}
		if (Mathf.Abs(vector3_1.y - vector.y) > float_2)
		{
			return false;
		}
		if (Mathf.Abs(vector3_0.y - vector.y) > float_2)
		{
			return false;
		}
		if (AIServicePathfinding.AIServicePathfinding_0 == null)
		{
			return false;
		}
		NavMeshAgent navMeshAgent = entity_0.vmethod_11();
		return !(navMeshAgent == null) && !AIServicePathfinding.AIServicePathfinding_0.method_15(navMeshAgent, vector);
	}

	// Token: 0x06000018 RID: 24 RVA: 0x000345CC File Offset: 0x000327CC
	public AIServiceCurve.Curve method_1(AIServiceCurve.ECurveType ecurveType_0, Vector3 vector3_0, Vector3 vector3_1, float float_0 = 1.5f)
	{
		AIServiceCurve.Curve curve = new AIServiceCurve.Curve();
		if (curve == null)
		{
			DebugUtils.LogError(LogCategory.AI, "Could not allocate curve");
			return null;
		}
		if (ecurveType_0 == AIServiceCurve.ECurveType.EJumpCurve && curve.method_0(vector3_0, vector3_1, float_0))
		{
			return curve;
		}
		if (ecurveType_0 == AIServiceCurve.ECurveType.ESpitCurve && curve.method_1(vector3_0, vector3_1, float_0))
		{
			return curve;
		}
		if (ecurveType_0 == AIServiceCurve.ECurveType.ESpiderWidommakeJumpCurve && curve.method_2(vector3_0, vector3_1, float_0))
		{
			return curve;
		}
		if (ecurveType_0 == AIServiceCurve.ECurveType.EIcePickAttackFlyingCurve && curve.method_3(vector3_0, vector3_1, float_0))
		{
			return curve;
		}
		if (ecurveType_0 == AIServiceCurve.ECurveType.EThrowAxeCurve && curve.method_4(vector3_0, vector3_1, float_0))
		{
			return curve;
		}
		if (ecurveType_0 == AIServiceCurve.ECurveType.EKnoxxJetAttackCurve && curve.method_5(vector3_0, vector3_1))
		{
			return curve;
		}
		if (ecurveType_0 == AIServiceCurve.ECurveType.EKnoxxMissileFlyingCurve && curve.method_6(vector3_0, vector3_1, float_0))
		{
			return curve;
		}
		return null;
	}

	// Token: 0x04000009 RID: 9
	private static readonly AIServiceCurve s_instance = new AIServiceCurve();

	// Token: 0x02000006 RID: 6
	public enum ECurveType
	{
		// Token: 0x0400000B RID: 11
		EJumpCurve,
		// Token: 0x0400000C RID: 12
		ESpiderWidommakeJumpCurve,
		// Token: 0x0400000D RID: 13
		ESpitCurve,
		// Token: 0x0400000E RID: 14
		EIcePickAttackFlyingCurve,
		// Token: 0x0400000F RID: 15
		EThrowAxeCurve,
		// Token: 0x04000010 RID: 16
		EKnoxxJetAttackCurve,
		// Token: 0x04000011 RID: 17
		EKnoxxMissileFlyingCurve,
		// Token: 0x04000012 RID: 18
		EApollyonJumpCurve
	}

	// Token: 0x02000007 RID: 7
	public class Curve
	{
		// Token: 0x0600001A RID: 26 RVA: 0x000031C5 File Offset: 0x000013C5
		public static Vector3 smethod_0(Vector3 vector3_0, Vector3 vector3_1, float float_0)
		{
			return vector3_0 + (vector3_1 - vector3_0) * float_0;
		}

		// Token: 0x0600001B RID: 27 RVA: 0x0003466C File Offset: 0x0003286C
		public bool method_0(Vector3 vector3_0, Vector3 vector3_1, float float_0)
		{
			float num = 3f;
			this.m_curveStartPosition = vector3_0;
			this.m_curveEndPosition = AIServiceCurve.Curve.smethod_0(vector3_0, vector3_1, float_0);
			Vector3 curveEndPosition = this.m_curveEndPosition;
			curveEndPosition.y = vector3_1.y;
			RaycastHit raycastHit;
			if (Physics.Raycast(curveEndPosition, -Vector3.up, out raycastHit, num, 1 << LayerMask.NameToLayer("Walkable")))
			{
				this.m_curveEndPosition.y = raycastHit.point.y;
				while (this.m_animationCurve.length > 0)
				{
					this.m_animationCurve.RemoveKey(0);
				}
				this.m_startKey.time = 0f;
				this.m_startKey.value = vector3_0.y;
				this.m_startKey.inTangent = 0f;
				this.m_startKey.outTangent = 0f;
				this.m_startKey.tangentMode = 10;
				this.m_animationCurve.AddKey(this.m_startKey);
				this.m_topKey.time = 0.66f;
				this.m_topKey.value = vector3_1.y + 0.5f;
				this.m_topKey.inTangent = 0f;
				this.m_topKey.outTangent = 0f;
				this.m_topKey.tangentMode = 10;
				this.m_animationCurve.AddKey(this.m_topKey);
				this.m_endKey.time = 1f;
				this.m_endKey.value = this.m_curveEndPosition.y;
				this.m_endKey.inTangent = 0f;
				this.m_endKey.outTangent = 0f;
				this.m_endKey.tangentMode = 10;
				this.m_animationCurve.AddKey(this.m_endKey);
				this.m_animationCurve.SmoothTangents(0, 0f);
				this.m_animationCurve.SmoothTangents(1, 0f);
				this.m_animationCurve.SmoothTangents(2, 0f);
				this.m_time = 0f;
				return true;
			}
			return false;
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00034874 File Offset: 0x00032A74
		public bool method_1(Vector3 vector3_0, Vector3 vector3_1, float float_0)
		{
			float num = 3f;
			this.m_curveStartPosition = vector3_0;
			this.m_curveEndPosition = AIServiceCurve.Curve.smethod_0(vector3_0, vector3_1, float_0);
			Vector3 curveEndPosition = this.m_curveEndPosition;
			curveEndPosition.y = vector3_1.y;
			RaycastHit raycastHit;
			if (Physics.Raycast(curveEndPosition, -Vector3.up, out raycastHit, num, 1 << LayerMask.NameToLayer("Walkable")))
			{
				this.m_curveEndPosition.y = raycastHit.point.y;
			}
			while (this.m_animationCurve.length > 0)
			{
				this.m_animationCurve.RemoveKey(0);
			}
			this.m_startKey.time = 0f;
			this.m_startKey.value = vector3_0.y;
			this.m_startKey.inTangent = 0f;
			this.m_startKey.outTangent = 0f;
			this.m_startKey.tangentMode = 10;
			this.m_animationCurve.AddKey(this.m_startKey);
			this.m_topKey.time = 1f / float_0;
			this.m_topKey.value = vector3_1.y;
			this.m_topKey.inTangent = 0f;
			this.m_topKey.outTangent = 0f;
			this.m_topKey.tangentMode = 10;
			this.m_animationCurve.AddKey(this.m_topKey);
			this.m_endKey.time = 1f;
			this.m_endKey.value = this.m_curveEndPosition.y;
			this.m_endKey.inTangent = 0f;
			this.m_endKey.outTangent = 0f;
			this.m_endKey.tangentMode = 10;
			this.m_animationCurve.AddKey(this.m_endKey);
			this.m_animationCurve.SmoothTangents(0, 0f);
			this.m_animationCurve.SmoothTangents(1, 0f);
			this.m_animationCurve.SmoothTangents(2, 0f);
			this.m_time = 0f;
			return true;
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00034A74 File Offset: 0x00032C74
		public bool method_2(Vector3 vector3_0, Vector3 vector3_1, float float_0)
		{
			float num = 10f;
			this.m_curveStartPosition = vector3_0;
			this.m_curveEndPosition = AIServiceCurve.Curve.smethod_0(vector3_0, vector3_1, float_0);
			Vector3 curveEndPosition = this.m_curveEndPosition;
			curveEndPosition.y = vector3_1.y;
			RaycastHit raycastHit;
			if (Physics.Raycast(curveEndPosition, -Vector3.up, out raycastHit, num, 1 << LayerMask.NameToLayer("Walkable")))
			{
				this.m_curveEndPosition.y = raycastHit.point.y;
				while (this.m_animationCurve.length > 0)
				{
					this.m_animationCurve.RemoveKey(0);
				}
				this.m_startKey.time = 0f;
				this.m_startKey.value = vector3_0.y;
				this.m_startKey.inTangent = 0f;
				this.m_startKey.outTangent = 0f;
				this.m_startKey.tangentMode = 10;
				this.m_animationCurve.AddKey(this.m_startKey);
				this.m_topKey.time = 0.5f;
				this.m_topKey.value = vector3_1.y + 2f;
				this.m_topKey.inTangent = 0f;
				this.m_topKey.outTangent = 0f;
				this.m_topKey.tangentMode = 10;
				this.m_animationCurve.AddKey(this.m_topKey);
				this.m_endKey.time = 1f;
				this.m_endKey.value = this.m_curveEndPosition.y;
				this.m_endKey.inTangent = 0f;
				this.m_endKey.outTangent = 0f;
				this.m_endKey.tangentMode = 10;
				this.m_animationCurve.AddKey(this.m_endKey);
				this.m_animationCurve.SmoothTangents(0, 0f);
				this.m_animationCurve.SmoothTangents(1, 0f);
				this.m_animationCurve.SmoothTangents(2, 0f);
				this.m_time = 0f;
				return true;
			}
			return false;
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00034C7C File Offset: 0x00032E7C
		public bool method_3(Vector3 vector3_0, Vector3 vector3_1, float float_0)
		{
			float num = 10f;
			this.m_curveStartPosition = vector3_0;
			this.m_curveEndPosition = AIServiceCurve.Curve.smethod_0(vector3_0, vector3_1, float_0);
			Vector3 curveEndPosition = this.m_curveEndPosition;
			curveEndPosition.y = vector3_1.y;
			RaycastHit raycastHit;
			if (Physics.Raycast(curveEndPosition + Vector3.up * 2f, -Vector3.up, out raycastHit, num, 1 << LayerMask.NameToLayer("Walkable")))
			{
				this.m_curveEndPosition.y = raycastHit.point.y + 1.1f;
			}
			while (this.m_animationCurve.length > 0)
			{
				this.m_animationCurve.RemoveKey(0);
			}
			this.m_startKey.time = 0f;
			this.m_startKey.value = vector3_0.y;
			this.m_startKey.inTangent = 0f;
			this.m_startKey.outTangent = 0f;
			this.m_startKey.tangentMode = 10;
			this.m_animationCurve.AddKey(this.m_startKey);
			this.m_topKey.time = 0.75f;
			this.m_topKey.value = vector3_1.y + 10f;
			this.m_topKey.inTangent = 0f;
			this.m_topKey.outTangent = 0f;
			this.m_topKey.tangentMode = 10;
			this.m_animationCurve.AddKey(this.m_topKey);
			this.m_endKey.time = 1f;
			this.m_endKey.value = this.m_curveEndPosition.y;
			this.m_endKey.inTangent = 0f;
			this.m_endKey.outTangent = 0f;
			this.m_endKey.tangentMode = 10;
			this.m_animationCurve.AddKey(this.m_endKey);
			this.m_animationCurve.SmoothTangents(0, 0f);
			this.m_animationCurve.SmoothTangents(1, 0f);
			this.m_animationCurve.SmoothTangents(2, 0f);
			this.m_time = 0f;
			return true;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00034E9C File Offset: 0x0003309C
		public bool method_4(Vector3 vector3_0, Vector3 vector3_1, float float_0)
		{
			this.m_curveStartPosition = vector3_0;
			this.m_curveEndPosition = AIServiceCurve.Curve.smethod_0(vector3_0, vector3_1, float_0);
			Vector3 curveEndPosition = this.m_curveEndPosition;
			curveEndPosition.y = vector3_1.y;
			RaycastHit raycastHit;
			if (Physics.Raycast(curveEndPosition + Vector3.up * 2f, -Vector3.up, out raycastHit, 6f, 1 << LayerMask.NameToLayer("Walkable")))
			{
				this.m_curveEndPosition.y = raycastHit.point.y;
			}
			while (this.m_animationCurve.length > 0)
			{
				this.m_animationCurve.RemoveKey(0);
			}
			this.m_startKey.time = 0f;
			this.m_startKey.value = vector3_0.y;
			this.m_startKey.inTangent = 0f;
			this.m_startKey.outTangent = 0f;
			this.m_startKey.tangentMode = 10;
			this.m_animationCurve.AddKey(this.m_startKey);
			this.m_topKey.time = 0.66f;
			this.m_topKey.value = vector3_1.y;
			this.m_topKey.inTangent = 0f;
			this.m_topKey.outTangent = 0f;
			this.m_topKey.tangentMode = 10;
			this.m_animationCurve.AddKey(this.m_topKey);
			this.m_endKey.time = 1f;
			this.m_endKey.value = this.m_curveEndPosition.y;
			this.m_endKey.inTangent = 0f;
			this.m_endKey.outTangent = 0f;
			this.m_endKey.tangentMode = 10;
			this.m_animationCurve.AddKey(this.m_endKey);
			this.m_animationCurve.SmoothTangents(0, 0f);
			this.m_animationCurve.SmoothTangents(1, 0f);
			this.m_animationCurve.SmoothTangents(2, 0f);
			this.m_time = 0f;
			return true;
		}

		// Token: 0x06000020 RID: 32 RVA: 0x000350AC File Offset: 0x000332AC
		public bool method_5(Vector3 vector3_0, Vector3 vector3_1)
		{
			this.m_curveStartPosition = vector3_0;
			this.m_curveEndPosition = vector3_1;
			while (this.m_animationCurve.length > 0)
			{
				this.m_animationCurve.RemoveKey(0);
			}
			this.m_startKey.time = 0f;
			this.m_startKey.value = vector3_0.y;
			this.m_startKey.inTangent = 0f;
			this.m_startKey.outTangent = 0f;
			this.m_startKey.tangentMode = 10;
			this.m_animationCurve.AddKey(this.m_startKey);
			this.m_topKey.time = 0.5f;
			this.m_topKey.value = this.m_curveEndPosition.y + 5f;
			this.m_topKey.inTangent = 0f;
			this.m_topKey.outTangent = 0f;
			this.m_topKey.tangentMode = 10;
			this.m_animationCurve.AddKey(this.m_topKey);
			this.m_endKey.time = 1f;
			this.m_endKey.value = this.m_curveEndPosition.y;
			this.m_endKey.inTangent = 0f;
			this.m_endKey.outTangent = 0f;
			this.m_endKey.tangentMode = 10;
			this.m_animationCurve.AddKey(this.m_endKey);
			this.m_animationCurve.SmoothTangents(0, 0f);
			this.m_animationCurve.SmoothTangents(1, 0f);
			this.m_animationCurve.SmoothTangents(2, 0f);
			this.m_time = 0f;
			return true;
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00035254 File Offset: 0x00033454
		public bool method_6(Vector3 vector3_0, Vector3 vector3_1, float float_0)
		{
			float num = 10f;
			this.m_curveStartPosition = vector3_0;
			this.m_curveEndPosition = AIServiceCurve.Curve.smethod_0(vector3_0, vector3_1, float_0);
			Vector3 curveEndPosition = this.m_curveEndPosition;
			curveEndPosition.y = vector3_1.y;
			RaycastHit raycastHit;
			if (Physics.Raycast(curveEndPosition + Vector3.up * 2f, -Vector3.up, out raycastHit, num, 1 << LayerMask.NameToLayer("Walkable")))
			{
				this.m_curveEndPosition.y = raycastHit.point.y;
			}
			while (this.m_animationCurve.length > 0)
			{
				this.m_animationCurve.RemoveKey(0);
			}
			this.m_startKey.time = 0f;
			this.m_startKey.value = vector3_0.y;
			this.m_startKey.inTangent = 0f;
			this.m_startKey.outTangent = 0f;
			this.m_startKey.tangentMode = 10;
			this.m_animationCurve.AddKey(this.m_startKey);
			this.m_topKey.time = 0.1f;
			this.m_topKey.value = vector3_1.y + 10f;
			this.m_topKey.inTangent = 0f;
			this.m_topKey.outTangent = 0f;
			this.m_topKey.tangentMode = 10;
			this.m_animationCurve.AddKey(this.m_topKey);
			this.m_endKey.time = 1f;
			this.m_endKey.value = this.m_curveEndPosition.y;
			this.m_endKey.inTangent = 0f;
			this.m_endKey.outTangent = 0f;
			this.m_endKey.tangentMode = 10;
			this.m_animationCurve.AddKey(this.m_endKey);
			this.m_animationCurve.SmoothTangents(0, 0f);
			this.m_animationCurve.SmoothTangents(1, 0f);
			this.m_animationCurve.SmoothTangents(2, 0f);
			this.m_time = 0f;
			return true;
		}

		// Token: 0x06000022 RID: 34 RVA: 0x0003546C File Offset: 0x0003366C
		public bool method_7(Vector3 vector3_0, Vector3 vector3_1, float float_0)
		{
			this.m_curveStartPosition = vector3_0;
			this.m_curveEndPosition = vector3_1;
			while (this.m_animationCurve.length > 0)
			{
				this.m_animationCurve.RemoveKey(0);
			}
			this.m_startKey.time = 0f;
			this.m_startKey.value = vector3_0.y;
			this.m_startKey.inTangent = 0f;
			this.m_startKey.outTangent = 0f;
			this.m_startKey.tangentMode = 10;
			this.m_animationCurve.AddKey(this.m_startKey);
			this.m_topKey.time = 0.5f;
			this.m_topKey.value = vector3_1.y + 3f;
			this.m_topKey.inTangent = 0f;
			this.m_topKey.outTangent = 0f;
			this.m_topKey.tangentMode = 10;
			this.m_animationCurve.AddKey(this.m_topKey);
			this.m_endKey.time = 1f;
			this.m_endKey.value = this.m_curveEndPosition.y;
			this.m_endKey.inTangent = 0f;
			this.m_endKey.outTangent = 0f;
			this.m_endKey.tangentMode = 10;
			this.m_animationCurve.AddKey(this.m_endKey);
			this.m_animationCurve.SmoothTangents(0, 0f);
			this.m_animationCurve.SmoothTangents(1, 0f);
			this.m_animationCurve.SmoothTangents(2, 0f);
			this.m_time = 0f;
			return true;
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00035610 File Offset: 0x00033810
		public bool method_8(Vector3 vector3_0, Vector3 vector3_1, float float_0)
		{
			this.m_curveStartPosition = vector3_0;
			this.m_curveEndPosition = vector3_1;
			while (this.m_animationCurve.length > 0)
			{
				this.m_animationCurve.RemoveKey(0);
			}
			this.m_startKey.time = 0f;
			this.m_startKey.value = vector3_0.y;
			this.m_startKey.inTangent = 0f;
			this.m_startKey.outTangent = 0f;
			this.m_startKey.tangentMode = 10;
			this.m_animationCurve.AddKey(this.m_startKey);
			this.m_topKey.time = 0.5f;
			this.m_topKey.value = vector3_1.y + 1f;
			this.m_topKey.inTangent = 0f;
			this.m_topKey.outTangent = 0f;
			this.m_topKey.tangentMode = 10;
			this.m_animationCurve.AddKey(this.m_topKey);
			this.m_endKey.time = 1f;
			this.m_endKey.value = this.m_curveEndPosition.y;
			this.m_endKey.inTangent = 0f;
			this.m_endKey.outTangent = 0f;
			this.m_endKey.tangentMode = 10;
			this.m_animationCurve.AddKey(this.m_endKey);
			this.m_animationCurve.SmoothTangents(0, 0f);
			this.m_animationCurve.SmoothTangents(1, 0f);
			this.m_animationCurve.SmoothTangents(2, 0f);
			this.m_time = 0f;
			return true;
		}

		// Token: 0x06000024 RID: 36 RVA: 0x000357B4 File Offset: 0x000339B4
		public Vector3 method_9(float float_0)
		{
			Vector3 vector = Vector3.Lerp(this.m_curveStartPosition, this.m_curveEndPosition, float_0);
			vector.y = this.m_animationCurve.Evaluate(float_0);
			return vector;
		}

		// Token: 0x06000025 RID: 37 RVA: 0x000357E8 File Offset: 0x000339E8
		public bool Update(float deltaTime, float speed, out Vector3 newPosition)
		{
			if (speed <= 0f)
			{
				newPosition = this.m_curveStartPosition;
				return false;
			}
			this.m_time += deltaTime;
			Vector3 vector = this.m_curveEndPosition - this.m_curveStartPosition;
			vector.y = 0f;
			float magnitude = vector.magnitude;
			if (magnitude <= 1E-45f)
			{
				newPosition = this.m_curveStartPosition;
				return false;
			}
			float num = this.m_time * speed / magnitude;
			if (num <= 0f)
			{
				newPosition = this.m_curveStartPosition;
				return false;
			}
			if (num >= 1f)
			{
				newPosition = this.m_curveEndPosition;
				return true;
			}
			newPosition = this.method_9(num);
			return false;
		}

		// Token: 0x06000026 RID: 38 RVA: 0x0003589C File Offset: 0x00033A9C
		public void method_10()
		{
			int num = 64;
			for (int i = 0; i < num; i++)
			{
				global::Debug.smethod_4(this.method_9((float)i / (float)num), this.method_9((float)(i + 1) / (float)num), Color.green);
			}
		}

		// Token: 0x04000013 RID: 19
		protected AnimationCurve m_animationCurve = new AnimationCurve();

		// Token: 0x04000014 RID: 20
		protected Vector3 m_curveStartPosition;

		// Token: 0x04000015 RID: 21
		public Vector3 m_curveEndPosition;

		// Token: 0x04000016 RID: 22
		protected Keyframe m_startKey;

		// Token: 0x04000017 RID: 23
		protected Keyframe m_topKey;

		// Token: 0x04000018 RID: 24
		protected Keyframe m_topKey1;

		// Token: 0x04000019 RID: 25
		protected Keyframe m_endKey;

		// Token: 0x0400001A RID: 26
		protected float m_time;
	}
}
