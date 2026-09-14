using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020005D0 RID: 1488
public class ObjectTrailEffect : MonoBehaviour
{
	// Token: 0x0600259A RID: 9626 RVA: 0x000B588C File Offset: 0x000B3A8C
	private void Start()
	{
		this.mLastPosition = base.transform.position;
		this.mTrailObject = new GameObject("ObjectTrail");
		this.mTrailObject.transform.parent = null;
		this.mTrailObject.transform.position = Vector3.zero;
		this.mTrailObject.transform.rotation = Quaternion.identity;
		this.mTrailObject.transform.localScale = Vector3.one;
		this.mTrailObject.AddComponent(typeof(MeshFilter));
		this.mTrailObject.AddComponent(typeof(MeshRenderer));
		this.mTrailObject.renderer.material = this.TrailMaterial;
		this.mTrailMesh = new Mesh();
		this.mTrailMesh.name = base.name + "ObjectTrailMesh";
		this.mTrailObject.GetComponent<MeshFilter>().mesh = this.mTrailMesh;
		this.mMinVertexDistanceSqr = this.mMinVertexDistance * this.mMinVertexDistance;
		this.mMaxVertexDistanceSqr = this.mMaxVertexDistance * this.mMaxVertexDistance;
	}

	// Token: 0x0600259B RID: 9627 RVA: 0x000197F9 File Offset: 0x000179F9
	private void OnDestroy()
	{
		global::UnityEngine.Object.DestroyImmediate(this.mTrailObject);
		this.mVerticesPool.method_4();
		this.mUVPool.method_4();
		this.mTrianglesPool.method_4();
		this.mColorsPool.method_4();
	}

	// Token: 0x0600259C RID: 9628 RVA: 0x000B59B0 File Offset: 0x000B3BB0
	private void OnDisable()
	{
		this.mCurrentEmitTime = 0f;
		if (this.mTrailObject)
		{
			this.mTrailObject.SetActive(false);
		}
		this.mVerticesPool.method_3(this.mTrailMesh.vertices);
		this.mUVPool.method_3(this.mTrailMesh.uv);
		this.mTrianglesPool.method_3(this.mTrailMesh.triangles);
		this.mColorsPool.method_3(this.mTrailMesh.colors);
		if (this.mTrailMesh)
		{
			this.mTrailMesh.Clear();
		}
		this.mPoints.Clear();
		this.mSmoothedPoints.Clear();
	}

	// Token: 0x0600259D RID: 9629 RVA: 0x00019832 File Offset: 0x00017A32
	private void OnEnable()
	{
		this.mCurrentEmitTime = this.EmitTime;
		this.mLastPosition = base.transform.position;
		if (this.mTrailObject)
		{
			this.mTrailObject.SetActive(true);
		}
	}

	// Token: 0x0600259E RID: 9630 RVA: 0x000B5A68 File Offset: 0x000B3C68
	private void Update()
	{
		this.mCurrentEmitTime -= Time.deltaTime;
		if (this.mCurrentEmitTime <= 0f)
		{
			base.enabled = false;
			return;
		}
		float sqrMagnitude = (this.mLastPosition - base.transform.position).sqrMagnitude;
		if (sqrMagnitude > this.mMinVertexDistanceSqr)
		{
			bool flag = false;
			if (this.mPoints.Count < 3)
			{
				flag = true;
			}
			else
			{
				Vector3 vector = this.mPoints[this.mPoints.Count - 2].TipPosition - this.mPoints[this.mPoints.Count - 3].TipPosition;
				Vector3 vector2 = this.mPoints[this.mPoints.Count - 1].TipPosition - this.mPoints[this.mPoints.Count - 2].TipPosition;
				if (Vector3.Angle(vector, vector2) > this.MaxAngle || sqrMagnitude > this.mMaxVertexDistanceSqr)
				{
					flag = true;
				}
			}
			if (flag)
			{
				ObjectTrailEffect.Point point = new ObjectTrailEffect.Point();
				point.BasePosition = this.BasePoint.position;
				point.TipPosition = this.TipPoint.position;
				point.TimeCreated = Time.time;
				this.mPoints.Add(point);
				this.mLastPosition = base.transform.position;
				if (this.mPoints.Count == 1)
				{
					this.mSmoothedPoints.Add(point);
				}
				else if (this.mPoints.Count > 1)
				{
					for (int i = 0; i < 5; i++)
					{
						this.mSmoothedPoints.Add(point);
					}
				}
				if (this.mPoints.Count >= 4)
				{
					IEnumerable<Vector3> enumerable = ObjectTrailEffectInterpolator.smethod_16(new Vector3[]
					{
						this.mPoints[this.mPoints.Count - 4].TipPosition,
						this.mPoints[this.mPoints.Count - 3].TipPosition,
						this.mPoints[this.mPoints.Count - 2].TipPosition,
						this.mPoints[this.mPoints.Count - 1].TipPosition
					}, 4, false);
					IEnumerable<Vector3> enumerable2 = ObjectTrailEffectInterpolator.smethod_16(new Vector3[]
					{
						this.mPoints[this.mPoints.Count - 4].BasePosition,
						this.mPoints[this.mPoints.Count - 3].BasePosition,
						this.mPoints[this.mPoints.Count - 2].BasePosition,
						this.mPoints[this.mPoints.Count - 1].BasePosition
					}, 4, false);
					List<Vector3> list = new List<Vector3>(enumerable);
					List<Vector3> list2 = new List<Vector3>(enumerable2);
					float timeCreated = this.mPoints[this.mPoints.Count - 4].TimeCreated;
					float timeCreated2 = this.mPoints[this.mPoints.Count - 1].TimeCreated;
					for (int j = 0; j < list.Count; j++)
					{
						int num = this.mSmoothedPoints.Count - (list.Count - j);
						if (num > -1 && num < this.mSmoothedPoints.Count)
						{
							ObjectTrailEffect.Point point2 = new ObjectTrailEffect.Point();
							point2.BasePosition = list2[j];
							point2.TipPosition = list[j];
							point2.TimeCreated = Mathf.Lerp(timeCreated, timeCreated2, (float)j / (float)list.Count);
							this.mSmoothedPoints[num] = point2;
						}
					}
				}
			}
			else
			{
				this.mPoints[this.mPoints.Count - 1].BasePosition = this.BasePoint.position;
				this.mPoints[this.mPoints.Count - 1].TipPosition = this.TipPoint.position;
				this.mSmoothedPoints[this.mSmoothedPoints.Count - 1].BasePosition = this.BasePoint.position;
				this.mSmoothedPoints[this.mSmoothedPoints.Count - 1].TipPosition = this.TipPoint.position;
			}
		}
		else
		{
			if (this.mPoints.Count > 0)
			{
				this.mPoints[this.mPoints.Count - 1].BasePosition = this.BasePoint.position;
				this.mPoints[this.mPoints.Count - 1].TipPosition = this.TipPoint.position;
			}
			if (this.mSmoothedPoints.Count > 0)
			{
				this.mSmoothedPoints[this.mSmoothedPoints.Count - 1].BasePosition = this.BasePoint.position;
				this.mSmoothedPoints[this.mSmoothedPoints.Count - 1].TipPosition = this.TipPoint.position;
			}
		}
		this.method_0(this.mPoints);
		this.method_0(this.mSmoothedPoints);
		this.mVerticesPool.method_3(this.mTrailMesh.vertices);
		this.mUVPool.method_3(this.mTrailMesh.uv);
		this.mTrianglesPool.method_3(this.mTrailMesh.triangles);
		this.mColorsPool.method_3(this.mTrailMesh.colors);
		this.mTrailMesh.Clear();
		List<ObjectTrailEffect.Point> list3 = this.mSmoothedPoints;
		if (list3.Count > 1)
		{
			Vector3[] array = this.mVerticesPool.method_0(list3.Count * 2);
			Vector2[] array2 = this.mUVPool.method_0(list3.Count * 2);
			int[] array3 = this.mTrianglesPool.method_0((list3.Count - 1) * 6);
			Color[] array4 = this.mColorsPool.method_0(list3.Count * 2);
			for (int k = 0; k < list3.Count; k++)
			{
				ObjectTrailEffect.Point point3 = list3[k];
				float num2 = (Time.time - point3.TimeCreated) / this.LifeTime;
				Color color = Color.Lerp(Color.white, Color.clear, num2);
				if (this.Colors != null && this.Colors.Length > 0)
				{
					float num3 = num2 * (float)(this.Colors.Length - 1);
					float num4 = Mathf.Floor(num3);
					float num5 = Mathf.Clamp(Mathf.Ceil(num3), 1f, (float)(this.Colors.Length - 1));
					float num6 = Mathf.InverseLerp(num4, num5, num3);
					if (num4 >= (float)this.Colors.Length)
					{
						num4 = (float)(this.Colors.Length - 1);
					}
					if (num4 < 0f)
					{
						num4 = 0f;
					}
					if (num5 >= (float)this.Colors.Length)
					{
						num5 = (float)(this.Colors.Length - 1);
					}
					if (num5 < 0f)
					{
						num5 = 0f;
					}
					color = Color.Lerp(this.Colors[(int)num4], this.Colors[(int)num5], num6);
				}
				float num7 = 0f;
				if (this.Sizes != null && this.Sizes.Length > 0)
				{
					float num8 = num2 * (float)(this.Sizes.Length - 1);
					float num9 = Mathf.Floor(num8);
					float num10 = Mathf.Clamp(Mathf.Ceil(num8), 1f, (float)(this.Sizes.Length - 1));
					float num11 = Mathf.InverseLerp(num9, num10, num8);
					if (num9 >= (float)this.Sizes.Length)
					{
						num9 = (float)(this.Sizes.Length - 1);
					}
					if (num9 < 0f)
					{
						num9 = 0f;
					}
					if (num10 >= (float)this.Sizes.Length)
					{
						num10 = (float)(this.Sizes.Length - 1);
					}
					if (num10 < 0f)
					{
						num10 = 0f;
					}
					num7 = Mathf.Lerp(this.Sizes[(int)num9], this.Sizes[(int)num10], num11);
				}
				Vector3 vector3 = point3.TipPosition - point3.BasePosition;
				array[k * 2] = point3.BasePosition - vector3 * (num7 * 0.5f);
				array[k * 2 + 1] = point3.TipPosition + vector3 * (num7 * 0.5f);
				array4[k * 2] = (array4[k * 2 + 1] = color);
				float num12 = (float)k / (float)list3.Count;
				array2[k * 2].x = num12;
				array2[k * 2].y = 0f;
				array2[k * 2 + 1].x = num12;
				array2[k * 2 + 1].y = 1f;
				if (k > 0)
				{
					array3[(k - 1) * 6] = k * 2 - 2;
					array3[(k - 1) * 6 + 1] = k * 2 - 1;
					array3[(k - 1) * 6 + 2] = k * 2;
					array3[(k - 1) * 6 + 3] = k * 2 + 1;
					array3[(k - 1) * 6 + 4] = k * 2;
					array3[(k - 1) * 6 + 5] = k * 2 - 1;
				}
			}
			this.mTrailMesh.vertices = array;
			this.mTrailMesh.colors = array4;
			this.mTrailMesh.uv = array2;
			this.mTrailMesh.triangles = array3;
		}
	}

	// Token: 0x0600259F RID: 9631 RVA: 0x000B6474 File Offset: 0x000B4674
	private void method_0(List<ObjectTrailEffect.Point> list_0)
	{
		List<ObjectTrailEffect.Point> list = new List<ObjectTrailEffect.Point>();
		foreach (ObjectTrailEffect.Point point in list_0)
		{
			if (Time.time - point.TimeCreated > this.LifeTime)
			{
				list.Add(point);
			}
		}
		foreach (ObjectTrailEffect.Point point2 in list)
		{
			list_0.Remove(point2);
		}
	}

	// Token: 0x04001B2A RID: 6954
	private const int SubDivisionsCount = 4;

	// Token: 0x04001B2B RID: 6955
	private const int INIT_POINTS_POOL_SIZE = 30;

	// Token: 0x04001B2C RID: 6956
	public Transform BasePoint;

	// Token: 0x04001B2D RID: 6957
	public Transform TipPoint;

	// Token: 0x04001B2E RID: 6958
	public Material TrailMaterial;

	// Token: 0x04001B2F RID: 6959
	public Color[] Colors;

	// Token: 0x04001B30 RID: 6960
	public float[] Sizes;

	// Token: 0x04001B31 RID: 6961
	public float EmitTime = 1f;

	// Token: 0x04001B32 RID: 6962
	public float LifeTime = 1f;

	// Token: 0x04001B33 RID: 6963
	public float MaxAngle = 3f;

	// Token: 0x04001B34 RID: 6964
	private float mCurrentEmitTime;

	// Token: 0x04001B35 RID: 6965
	private float mMinVertexDistance = 0.1f;

	// Token: 0x04001B36 RID: 6966
	private float mMaxVertexDistance = 10f;

	// Token: 0x04001B37 RID: 6967
	private float mMinVertexDistanceSqr;

	// Token: 0x04001B38 RID: 6968
	private float mMaxVertexDistanceSqr;

	// Token: 0x04001B39 RID: 6969
	private List<ObjectTrailEffect.Point> mPoints = new List<ObjectTrailEffect.Point>();

	// Token: 0x04001B3A RID: 6970
	private List<ObjectTrailEffect.Point> mSmoothedPoints = new List<ObjectTrailEffect.Point>();

	// Token: 0x04001B3B RID: 6971
	private ArrayPool<Vector3> mVerticesPool = new ArrayPool<Vector3>();

	// Token: 0x04001B3C RID: 6972
	private ArrayPool<Vector2> mUVPool = new ArrayPool<Vector2>();

	// Token: 0x04001B3D RID: 6973
	private ArrayPool<int> mTrianglesPool = new ArrayPool<int>();

	// Token: 0x04001B3E RID: 6974
	private ArrayPool<Color> mColorsPool = new ArrayPool<Color>();

	// Token: 0x04001B3F RID: 6975
	private GameObject mTrailObject;

	// Token: 0x04001B40 RID: 6976
	private Mesh mTrailMesh;

	// Token: 0x04001B41 RID: 6977
	private Vector3 mLastPosition;

	// Token: 0x020005D1 RID: 1489
	public class Point
	{
		// Token: 0x04001B42 RID: 6978
		public float TimeCreated;

		// Token: 0x04001B43 RID: 6979
		public Vector3 BasePosition;

		// Token: 0x04001B44 RID: 6980
		public Vector3 TipPosition;

		// Token: 0x04001B45 RID: 6981
		public bool Using;
	}
}
