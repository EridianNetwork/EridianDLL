using System;
using UnityEngine;

// Token: 0x02000B56 RID: 2902
public class MeshCombineUtility
{
	// Token: 0x06004EC5 RID: 20165 RVA: 0x0014EB34 File Offset: 0x0014CD34
	public static Mesh smethod_0(MeshCombineUtility.MeshInstance[] meshInstance_0, bool bool_0)
	{
		bool_0 = false;
		int num = 0;
		int num2 = 0;
		foreach (MeshCombineUtility.MeshInstance meshInstance in meshInstance_0)
		{
			if (meshInstance.mesh)
			{
				num += meshInstance.mesh.vertexCount;
			}
		}
		if (!bool_0)
		{
			foreach (MeshCombineUtility.MeshInstance meshInstance2 in meshInstance_0)
			{
				if (meshInstance2.mesh)
				{
					num2 += meshInstance2.mesh.GetTriangles(meshInstance2.subMeshIndex).Length;
				}
			}
		}
		Vector3[] array = new Vector3[num];
		Vector3[] array2 = new Vector3[num];
		Vector4[] array3 = new Vector4[num];
		Vector2[] array4 = new Vector2[num];
		Vector2[] array5 = new Vector2[num];
		Vector2[] array6 = new Vector2[num];
		Color[] array7 = new Color[num];
		int[] array8 = new int[num2];
		int num3 = 0;
		foreach (MeshCombineUtility.MeshInstance meshInstance3 in meshInstance_0)
		{
			if (meshInstance3.mesh)
			{
				MeshCombineUtility.smethod_1(meshInstance3.mesh.vertexCount, meshInstance3.mesh.vertices, array, ref num3, meshInstance3.transform);
			}
		}
		num3 = 0;
		foreach (MeshCombineUtility.MeshInstance meshInstance4 in meshInstance_0)
		{
			if (meshInstance4.mesh)
			{
				Matrix4x4 matrix4x = meshInstance4.transform;
				matrix4x = matrix4x.inverse.transpose;
				MeshCombineUtility.smethod_2(meshInstance4.mesh.vertexCount, meshInstance4.mesh.normals, array2, ref num3, matrix4x);
			}
		}
		num3 = 0;
		foreach (MeshCombineUtility.MeshInstance meshInstance5 in meshInstance_0)
		{
			if (meshInstance5.mesh)
			{
				Matrix4x4 matrix4x2 = meshInstance5.transform;
				matrix4x2 = matrix4x2.inverse.transpose;
				MeshCombineUtility.smethod_6(meshInstance5.mesh.vertexCount, meshInstance5.mesh.tangents, array3, ref num3, matrix4x2);
			}
		}
		num3 = 0;
		foreach (MeshCombineUtility.MeshInstance meshInstance6 in meshInstance_0)
		{
			if (meshInstance6.mesh)
			{
				MeshCombineUtility.smethod_3(meshInstance6.mesh.vertexCount, meshInstance6.mesh.uv, array4, ref num3);
			}
		}
		num3 = 0;
		foreach (MeshCombineUtility.MeshInstance meshInstance7 in meshInstance_0)
		{
			if (meshInstance7.mesh)
			{
				MeshCombineUtility.smethod_3(meshInstance7.mesh.vertexCount, meshInstance7.mesh.uv1, array5, ref num3);
			}
		}
		float num5 = 0f;
		foreach (MeshCombineUtility.MeshInstance meshInstance8 in meshInstance_0)
		{
			if (meshInstance8.mesh)
			{
				num5 += meshInstance8.mesh.bounds.size.x * meshInstance8.mesh.bounds.size.y * meshInstance8.mesh.bounds.size.z;
			}
		}
		num3 = 0;
		float num7 = 0f;
		foreach (MeshCombineUtility.MeshInstance meshInstance9 in meshInstance_0)
		{
			if (meshInstance9.mesh)
			{
				float num9 = meshInstance9.mesh.bounds.size.x * meshInstance9.mesh.bounds.size.y * meshInstance9.mesh.bounds.size.z / num5;
				MeshCombineUtility.smethod_4(meshInstance9.mesh.vertexCount, meshInstance9.mesh.uv2, array6, ref num3, num9, num7);
				num7 += num9;
			}
		}
		num3 = 0;
		foreach (MeshCombineUtility.MeshInstance meshInstance10 in meshInstance_0)
		{
			if (meshInstance10.mesh)
			{
				MeshCombineUtility.smethod_5(meshInstance10.mesh.vertexCount, meshInstance10.mesh.colors, array7, ref num3);
			}
		}
		int num11 = 0;
		int num12 = 0;
		foreach (MeshCombineUtility.MeshInstance meshInstance11 in meshInstance_0)
		{
			if (meshInstance11.mesh)
			{
				int[] triangles = meshInstance11.mesh.GetTriangles(meshInstance11.subMeshIndex);
				for (int num14 = 0; num14 < triangles.Length; num14++)
				{
					array8[num14 + num11] = triangles[num14] + num12;
				}
				num11 += triangles.Length;
				num12 += meshInstance11.mesh.vertexCount;
			}
		}
		return new Mesh
		{
			name = "Combined Mesh",
			vertices = array,
			normals = array2,
			colors = array7,
			uv = array4,
			uv1 = array5,
			uv2 = array6,
			tangents = array3,
			triangles = array8
		};
	}

	// Token: 0x06004EC6 RID: 20166 RVA: 0x0014F0C8 File Offset: 0x0014D2C8
	private static void smethod_1(int int_0, Vector3[] vector3_0, Vector3[] vector3_1, ref int int_1, Matrix4x4 matrix4x4_0)
	{
		for (int i = 0; i < vector3_0.Length; i++)
		{
			vector3_1[i + int_1] = matrix4x4_0.MultiplyPoint(vector3_0[i]);
		}
		int_1 += int_0;
	}

	// Token: 0x06004EC7 RID: 20167 RVA: 0x0014F10C File Offset: 0x0014D30C
	private static void smethod_2(int int_0, Vector3[] vector3_0, Vector3[] vector3_1, ref int int_1, Matrix4x4 matrix4x4_0)
	{
		for (int i = 0; i < vector3_0.Length; i++)
		{
			vector3_1[i + int_1] = matrix4x4_0.MultiplyVector(vector3_0[i]).normalized;
		}
		int_1 += int_0;
	}

	// Token: 0x06004EC8 RID: 20168 RVA: 0x0014F158 File Offset: 0x0014D358
	private static void smethod_3(int int_0, Vector2[] vector2_0, Vector2[] vector2_1, ref int int_1)
	{
		for (int i = 0; i < vector2_0.Length; i++)
		{
			vector2_1[i + int_1] = vector2_0[i];
		}
		int_1 += int_0;
	}

	// Token: 0x06004EC9 RID: 20169 RVA: 0x0014F194 File Offset: 0x0014D394
	private static void smethod_4(int int_0, Vector2[] vector2_0, Vector2[] vector2_1, ref int int_1, float float_0, float float_1)
	{
		for (int i = 0; i < vector2_0.Length; i++)
		{
			vector2_1[i + int_1] = vector2_0[i] * float_0 + new Vector2(float_1, 0f);
		}
		int_1 += int_0;
	}

	// Token: 0x06004ECA RID: 20170 RVA: 0x0014F1E8 File Offset: 0x0014D3E8
	private static void smethod_5(int int_0, Color[] color_0, Color[] color_1, ref int int_1)
	{
		for (int i = 0; i < color_0.Length; i++)
		{
			color_1[i + int_1] = color_0[i];
		}
		int_1 += int_0;
	}

	// Token: 0x06004ECB RID: 20171 RVA: 0x0014F224 File Offset: 0x0014D424
	private static void smethod_6(int int_0, Vector4[] vector4_0, Vector4[] vector4_1, ref int int_1, Matrix4x4 matrix4x4_0)
	{
		for (int i = 0; i < vector4_0.Length; i++)
		{
			Vector4 vector = vector4_0[i];
			Vector3 normalized = new Vector3(vector.x, vector.y, vector.z);
			normalized = matrix4x4_0.MultiplyVector(normalized).normalized;
			vector4_1[i + int_1] = new Vector4(normalized.x, normalized.y, normalized.z, vector.w);
		}
		int_1 += int_0;
	}

	// Token: 0x02000B57 RID: 2903
	public struct MeshInstance
	{
		// Token: 0x04003B23 RID: 15139
		public Mesh mesh;

		// Token: 0x04003B24 RID: 15140
		public int subMeshIndex;

		// Token: 0x04003B25 RID: 15141
		public Matrix4x4 transform;
	}
}
