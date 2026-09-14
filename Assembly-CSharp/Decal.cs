using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000B44 RID: 2884
public class Decal : MonoBehaviour
{
	// Token: 0x06004E8D RID: 20109 RVA: 0x0003321E File Offset: 0x0003141E
	private void OnDrawGizmosSelected()
	{
		this.method_0();
		Gizmos.matrix = base.transform.localToWorldMatrix;
		Gizmos.DrawWireCube(Vector3.zero, new Vector3(1f, 1f, 5f));
	}

	// Token: 0x06004E8E RID: 20110 RVA: 0x00033254 File Offset: 0x00031454
	public void method_0()
	{
		this.bounds = new Bounds(base.transform.position, base.transform.lossyScale * 1.414214f);
	}

	// Token: 0x06004E8F RID: 20111 RVA: 0x0014D080 File Offset: 0x0014B280
	public void method_1()
	{
		this.maxAngle = Mathf.Clamp(this.maxAngle, 0f, 180f);
		this.angleCosine = Mathf.Cos(this.maxAngle * 0.017453292f);
		this.uvAngle = Mathf.Clamp(this.uvAngle, 0f, 360f);
		this.uCos = Mathf.Cos(this.uvAngle * 0.017453292f);
		this.vSin = Mathf.Sin(this.uvAngle * 0.017453292f);
		if (this.affectedObject == null)
		{
			return;
		}
		Matrix4x4 worldToLocalMatrix = base.transform.worldToLocalMatrix;
		this.method_4(this.affectedObject, worldToLocalMatrix);
		if (this.instanceMesh != null)
		{
			MeshRenderer meshRenderer = base.gameObject.GetComponent<MeshRenderer>();
			if (meshRenderer == null)
			{
				meshRenderer = base.gameObject.AddComponent<MeshRenderer>();
			}
			meshRenderer.material = this.decalMaterial;
			meshRenderer.useLightProbes = true;
			meshRenderer.castShadows = false;
			MeshFilter meshFilter = base.gameObject.GetComponent<MeshFilter>();
			if (meshFilter == null)
			{
				meshFilter = base.gameObject.AddComponent<MeshFilter>();
			}
			else
			{
				global::UnityEngine.Object.DestroyImmediate(meshFilter.sharedMesh);
			}
			meshFilter.mesh = this.instanceMesh;
			this.instanceMesh = null;
		}
	}

	// Token: 0x06004E90 RID: 20112 RVA: 0x0014D1C0 File Offset: 0x0014B3C0
	public void method_2()
	{
		MeshFilter component = base.gameObject.GetComponent<MeshFilter>();
		if (component != null)
		{
			global::UnityEngine.Object.DestroyImmediate(component.sharedMesh);
			global::UnityEngine.Object.DestroyImmediate(component);
		}
		MeshRenderer component2 = base.gameObject.GetComponent<MeshRenderer>();
		if (component2 != null)
		{
			global::UnityEngine.Object.DestroyImmediate(component2);
		}
	}

	// Token: 0x06004E91 RID: 20113 RVA: 0x00033281 File Offset: 0x00031481
	private Vector3 method_3(float[,] float_0, Vector3 vector3_0, int int_0, int int_1)
	{
		return Vector3.Scale(vector3_0, new Vector3((float)int_0, float_0[int_1, int_0], (float)int_1));
	}

	// Token: 0x06004E92 RID: 20114 RVA: 0x0014D210 File Offset: 0x0014B410
	public void method_4(GameObject gameObject_0, Matrix4x4 matrix4x4_0)
	{
		this.decalCenter = gameObject_0.transform.InverseTransformPoint(base.transform.position);
		this.decalNormal = gameObject_0.transform.InverseTransformDirection(base.transform.up).normalized;
		this.decalBinormal = gameObject_0.transform.InverseTransformDirection(base.transform.right).normalized;
		this.decalTangent = gameObject_0.transform.InverseTransformDirection(base.transform.forward).normalized;
		float num = Mathf.Max(gameObject_0.transform.lossyScale.x, gameObject_0.transform.lossyScale.y);
		this.decalSize = new Vector3(base.transform.lossyScale.x / num, base.transform.lossyScale.x / num, base.transform.lossyScale.x / num);
		this.leftPlane = new Vector4(-this.decalBinormal.x, -this.decalBinormal.y, -this.decalBinormal.z, this.decalSize.y * 0.5f + Vector3.Dot(this.decalCenter, this.decalBinormal));
		this.rightPlane = new Vector4(this.decalBinormal.x, this.decalBinormal.y, this.decalBinormal.z, this.decalSize.y * 0.5f - Vector3.Dot(this.decalCenter, this.decalBinormal));
		this.backPlane = new Vector4(-this.decalTangent.x, -this.decalTangent.y, -this.decalTangent.z, this.decalSize.x * 0.5f + Vector3.Dot(this.decalCenter, this.decalTangent));
		this.frontPlane = new Vector4(this.decalTangent.x, this.decalTangent.y, this.decalTangent.z, this.decalSize.x * 0.5f - Vector3.Dot(this.decalCenter, this.decalTangent));
		this.topPlane = new Vector4(this.decalNormal.x, this.decalNormal.y, this.decalNormal.z, this.decalSize.z * 0.5f - Vector3.Dot(this.decalCenter, this.decalNormal));
		this.bottomPlane = new Vector4(-this.decalNormal.x, -this.decalNormal.y, -this.decalNormal.z, this.decalSize.z * 0.5f + Vector3.Dot(this.decalCenter, this.decalNormal));
		Mesh mesh = null;
		Terrain component = gameObject_0.GetComponent<Terrain>();
		Vector3[] array;
		Vector3[] array2;
		Vector4[] array3;
		int[] array4;
		if (component != null)
		{
			TerrainData terrainData = component.terrainData;
			int heightmapWidth = terrainData.heightmapWidth;
			int heightmapHeight = terrainData.heightmapHeight;
			Vector3 heightmapScale = terrainData.heightmapScale;
			float[,] heights = terrainData.GetHeights(0, 0, heightmapWidth, heightmapHeight);
			int num2 = (int)(this.decalCenter.x / heightmapScale.x);
			int num3 = (int)(this.decalCenter.z / heightmapScale.z);
			int num4 = (int)Mathf.Ceil(this.decalSize.x / heightmapScale.x);
			int num5 = (int)Mathf.Ceil(this.decalSize.z / heightmapScale.z);
			int num6 = ((num4 <= num5) ? num5 : num4);
			num6 = 3 * num6 / 4 + 1;
			array = new Vector3[(num6 * 2 + 1) * (num6 * 2 + 1)];
			array2 = new Vector3[(num6 * 2 + 1) * (num6 * 2 + 1)];
			array3 = new Vector4[(num6 * 2 + 1) * (num6 * 2 + 1)];
			array4 = new int[num6 * 2 * (num6 * 2) * 6];
			int num7 = 0;
			for (int i = num2 - num6; i <= num2 + num6; i++)
			{
				int num8 = ((i >= 0) ? i : 0);
				num8 = ((num8 < heightmapWidth) ? num8 : (heightmapWidth - 1));
				for (int j = num3 - num6; j <= num3 + num6; j++)
				{
					int num9 = ((j >= 0) ? j : 0);
					num9 = ((num9 < heightmapHeight) ? num9 : (heightmapHeight - 1));
					array[num7] = this.method_3(heights, heightmapScale, num8, num9);
					array2[num7] = new Vector3(0f, 1f, 0f);
					array3[num7] = new Vector4(0f, 0f, -1f, -1f);
					num7++;
				}
			}
			num7 = 0;
			int num10 = num6 * 2 + 1;
			for (int k = 0; k < num6 * 2; k++)
			{
				for (int l = 0; l < num6 * 2; l++)
				{
					array4[6 * num7] = k * num10 + l;
					array4[6 * num7 + 1] = k * num10 + l + 1;
					array4[6 * num7 + 2] = (k + 1) * num10 + l;
					array4[6 * num7 + 3] = (k + 1) * num10 + l;
					array4[6 * num7 + 4] = k * num10 + l + 1;
					array4[6 * num7 + 5] = (k + 1) * num10 + l + 1;
					num7++;
				}
			}
			mesh = new Mesh();
			mesh.vertices = array;
			mesh.normals = array2;
			mesh.tangents = array3;
			mesh.triangles = array4;
			mesh.RecalculateNormals();
		}
		else
		{
			if (this.decalMode == DecalMode.MESH_COLLIDER)
			{
				if (gameObject_0.GetComponent<MeshCollider>() != null)
				{
					mesh = gameObject_0.GetComponent<MeshCollider>().sharedMesh;
				}
				else
				{
					mesh = null;
				}
			}
			if (mesh == null || this.decalMode == DecalMode.MESH_FILTER)
			{
				if (gameObject_0.GetComponent<BatchingMeshContainer>() == null)
				{
					return;
				}
				mesh = gameObject_0.GetComponent<BatchingMeshContainer>().m_mesh;
			}
			if (mesh == null)
			{
				return;
			}
		}
		array4 = mesh.triangles;
		array = mesh.vertices;
		array2 = mesh.normals;
		array3 = mesh.tangents;
		this.instanceMesh = this.method_5(this.method_6(array4, array, array2, array3), gameObject_0.transform);
	}

	// Token: 0x06004E93 RID: 20115 RVA: 0x0014D880 File Offset: 0x0014BA80
	private Mesh method_5(int int_0, Transform transform_0)
	{
		if (Decal.clippedPolygons == null)
		{
			return null;
		}
		if (Decal.clippedPolygons.Count <= 0)
		{
			return null;
		}
		if (int_0 < 3)
		{
			return null;
		}
		int[] array = new int[(int_0 - 2) * 3];
		Vector3[] array2 = new Vector3[int_0];
		Vector3[] array3 = new Vector3[int_0];
		Vector2[] array4 = new Vector2[int_0];
		Vector4[] array5 = new Vector4[int_0];
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		float num4 = 1f / this.decalSize.x;
		float num5 = 1f / this.decalSize.y;
		foreach (DecalPolygon decalPolygon in Decal.clippedPolygons)
		{
			for (int i = 0; i < decalPolygon.verticeCount; i++)
			{
				array2[num] = decalPolygon.vertice[i];
				array3[num] = decalPolygon.normal[i];
				array5[num] = decalPolygon.tangent[i];
				if (i < decalPolygon.verticeCount - 2)
				{
					array[num2] = num3;
					array[num2 + 1] = num + 1;
					array[num2 + 2] = num + 2;
					num2 += 3;
				}
				num++;
			}
			num3 = num;
		}
		for (int j = 0; j < array2.Length; j++)
		{
			Vector3 vector = array2[j] - this.decalCenter;
			float num6 = Vector3.Dot(vector, this.decalTangent);
			float num7 = Vector3.Dot(vector, this.decalBinormal);
			float num8 = num6 * num4;
			float num9 = num7 * num5;
			float num10 = num8 * this.uCos - num9 * this.vSin + 0.5f;
			float num11 = num8 * this.vSin + num9 * this.uCos + 0.5f;
			num10 *= this.tiling.x;
			num11 *= this.tiling.y;
			num10 += this.offset.x;
			num11 += this.offset.y;
			array4[j] = new Vector2(num10, num11);
		}
		for (int k = 0; k < array2.Length; k++)
		{
			array2[k] += array3[k] * this.pushDistance;
		}
		Matrix4x4 matrix4x = base.transform.worldToLocalMatrix * transform_0.localToWorldMatrix;
		Matrix4x4 transpose = matrix4x.inverse.transpose;
		for (int l = 0; l < array2.Length; l++)
		{
			array2[l] = matrix4x.MultiplyPoint(array2[l]);
			array3[l] = transpose.MultiplyVector(array3[l]).normalized;
		}
		return new Mesh
		{
			vertices = array2,
			normals = array3,
			triangles = array,
			uv = array4,
			uv1 = array4,
			uv2 = array4,
			tangents = array5
		};
	}

	// Token: 0x06004E94 RID: 20116 RVA: 0x0014DBF4 File Offset: 0x0014BDF4
	private int method_6(int[] int_0, Vector3[] vector3_0, Vector3[] vector3_1, Vector4[] vector4_0)
	{
		bool flag = vector4_0 != null && vector4_0.Length > 0;
		DecalPolygon decalPolygon = new DecalPolygon();
		int num = 0;
		Decal.clippedPolygons.Clear();
		for (int i = 0; i < int_0.Length; i += 3)
		{
			int num2 = int_0[i];
			Vector3 vector = vector3_1[num2];
			float num3 = Vector3.Dot(vector, this.decalNormal);
			if (num3 > this.angleCosine)
			{
				int num4 = int_0[i + 1];
				int num5 = int_0[i + 2];
				Vector3 vector2 = vector3_0[num2];
				Vector3 vector3 = vector3_0[num4];
				Vector3 vector4 = vector3_0[num5];
				decalPolygon.verticeCount = 3;
				decalPolygon.vertice[0] = vector2;
				decalPolygon.vertice[1] = vector3;
				decalPolygon.vertice[2] = vector4;
				decalPolygon.normal[0] = vector;
				decalPolygon.normal[1] = vector;
				decalPolygon.normal[2] = vector;
				if (flag)
				{
					Vector3 vector5 = vector4_0[num2];
					Vector3 vector6 = vector4_0[num4];
					Vector3 vector7 = vector4_0[num5];
					decalPolygon.tangent[0] = vector5;
					decalPolygon.tangent[1] = vector6;
					decalPolygon.tangent[2] = vector7;
				}
				DecalPolygon decalPolygon2 = DecalPolygon.smethod_0(decalPolygon, this.frontPlane);
				if (decalPolygon2 != null)
				{
					decalPolygon2 = DecalPolygon.smethod_0(decalPolygon2, this.backPlane);
					if (decalPolygon2 != null)
					{
						decalPolygon2 = DecalPolygon.smethod_0(decalPolygon2, this.rightPlane);
						if (decalPolygon2 != null)
						{
							decalPolygon2 = DecalPolygon.smethod_0(decalPolygon2, this.leftPlane);
							if (decalPolygon2 != null)
							{
								decalPolygon2 = DecalPolygon.smethod_0(decalPolygon2, this.bottomPlane);
								if (decalPolygon2 != null)
								{
									decalPolygon2 = DecalPolygon.smethod_0(decalPolygon2, this.topPlane);
									if (decalPolygon2 != null)
									{
										num += decalPolygon2.verticeCount;
										if (decalPolygon2 == decalPolygon)
										{
											decalPolygon2 = decalPolygon2.method_0();
										}
										Decal.clippedPolygons.Add(decalPolygon2);
									}
								}
							}
						}
					}
				}
			}
		}
		return num;
	}

	// Token: 0x06004E95 RID: 20117 RVA: 0x0014DE50 File Offset: 0x0014C050
	public bool method_7()
	{
		Transform transform = base.transform;
		bool flag = false;
		this.maxAngle = Mathf.Clamp(this.maxAngle, 0f, 180f);
		this.uvAngle = Mathf.Clamp(this.uvAngle, 0f, 360f);
		if (this.previousPosition != transform.position)
		{
			flag = true;
		}
		else if (this.previousScale != transform.lossyScale)
		{
			flag = true;
		}
		else if (this.previousRotation != transform.rotation)
		{
			flag = true;
		}
		else if (this.previousPushDistance != this.pushDistance)
		{
			flag = true;
		}
		else if (this.previousTiling != this.tiling)
		{
			flag = true;
		}
		else if (this.previousOffset != this.offset)
		{
			flag = true;
		}
		else if (this.previousMaxAngle != this.maxAngle)
		{
			flag = true;
		}
		else if (this.previousUVAngle != this.uvAngle)
		{
			flag = true;
		}
		this.previousUVAngle = this.uvAngle;
		this.previousMaxAngle = this.maxAngle;
		this.previousTiling = this.tiling;
		this.previousOffset = this.offset;
		this.previousPushDistance = this.pushDistance;
		this.previousPosition = transform.position;
		this.previousRotation = transform.rotation;
		this.previousScale = transform.lossyScale;
		return flag;
	}

	// Token: 0x04003AA9 RID: 15017
	public static int dCount;

	// Token: 0x04003AAA RID: 15018
	[HideInInspector]
	public GameObject affectedObject;

	// Token: 0x04003AAB RID: 15019
	public float maxAngle = 90f;

	// Token: 0x04003AAC RID: 15020
	private float angleCosine;

	// Token: 0x04003AAD RID: 15021
	[HideInInspector]
	public Bounds bounds;

	// Token: 0x04003AAE RID: 15022
	[HideInInspector]
	public float previousUVAngle;

	// Token: 0x04003AAF RID: 15023
	[HideInInspector]
	public Vector3 previousPosition;

	// Token: 0x04003AB0 RID: 15024
	[HideInInspector]
	public Quaternion previousRotation;

	// Token: 0x04003AB1 RID: 15025
	[HideInInspector]
	public Vector3 previousScale;

	// Token: 0x04003AB2 RID: 15026
	[HideInInspector]
	public float previousMaxAngle;

	// Token: 0x04003AB3 RID: 15027
	[HideInInspector]
	public float previousPushDistance = 0.009f;

	// Token: 0x04003AB4 RID: 15028
	[HideInInspector]
	public Vector2 previousTiling;

	// Token: 0x04003AB5 RID: 15029
	[HideInInspector]
	public Vector2 previousOffset;

	// Token: 0x04003AB6 RID: 15030
	[HideInInspector]
	public bool useMeshCollider;

	// Token: 0x04003AB7 RID: 15031
	public Vector2 tiling = Vector2.one;

	// Token: 0x04003AB8 RID: 15032
	public Vector2 offset = Vector2.zero;

	// Token: 0x04003AB9 RID: 15033
	[HideInInspector]
	public float uvAngle;

	// Token: 0x04003ABA RID: 15034
	private float uCos;

	// Token: 0x04003ABB RID: 15035
	private float vSin;

	// Token: 0x04003ABC RID: 15036
	public Material decalMaterial;

	// Token: 0x04003ABD RID: 15037
	[HideInInspector]
	public DecalMode decalMode;

	// Token: 0x04003ABE RID: 15038
	private static List<DecalPolygon> clippedPolygons = new List<DecalPolygon>(128);

	// Token: 0x04003ABF RID: 15039
	[HideInInspector]
	public Vector4 bottomPlane;

	// Token: 0x04003AC0 RID: 15040
	[HideInInspector]
	public Vector4 topPlane;

	// Token: 0x04003AC1 RID: 15041
	[HideInInspector]
	public Vector4 leftPlane;

	// Token: 0x04003AC2 RID: 15042
	[HideInInspector]
	public Vector4 rightPlane;

	// Token: 0x04003AC3 RID: 15043
	[HideInInspector]
	public Vector4 frontPlane;

	// Token: 0x04003AC4 RID: 15044
	[HideInInspector]
	public Vector4 backPlane;

	// Token: 0x04003AC5 RID: 15045
	[HideInInspector]
	public Vector3 decalNormal;

	// Token: 0x04003AC6 RID: 15046
	[HideInInspector]
	public Vector3 decalCenter;

	// Token: 0x04003AC7 RID: 15047
	[HideInInspector]
	public Vector3 decalTangent;

	// Token: 0x04003AC8 RID: 15048
	[HideInInspector]
	public Vector3 decalBinormal;

	// Token: 0x04003AC9 RID: 15049
	[HideInInspector]
	public Vector3 decalSize;

	// Token: 0x04003ACA RID: 15050
	public float pushDistance = 0.009f;

	// Token: 0x04003ACB RID: 15051
	private Mesh instanceMesh;

	// Token: 0x04003ACC RID: 15052
	public bool checkAutomatically;

	// Token: 0x04003ACD RID: 15053
	public LayerMask affectedLayers;

	// Token: 0x04003ACE RID: 15054
	public bool affectOtherDecals;

	// Token: 0x04003ACF RID: 15055
	public bool affectInactiveRenderers;

	// Token: 0x04003AD0 RID: 15056
	[HideInInspector]
	public bool showAffectedObjectsOptions;

	// Token: 0x04003AD1 RID: 15057
	[HideInInspector]
	public bool showObjects;
}
