using System;
using UnityEngine;

// Token: 0x02000B41 RID: 2881
public class CPUSkinning
{
	// Token: 0x06004E80 RID: 20096 RVA: 0x0014C864 File Offset: 0x0014AA64
	public static void smethod_0(SkinnedMeshRenderer skinnedMeshRenderer_0, Mesh mesh_0)
	{
		Mesh sharedMesh = skinnedMeshRenderer_0.sharedMesh;
		if (sharedMesh != null)
		{
			Vector3[] array;
			if (mesh_0.vertices != null)
			{
				if (mesh_0.vertices.Length == sharedMesh.vertices.Length)
				{
					array = mesh_0.vertices;
					goto IL_0048;
				}
			}
			array = new Vector3[sharedMesh.vertices.Length];
			IL_0048:
			Vector3[] vertices = sharedMesh.vertices;
			BoneWeight[] boneWeights = sharedMesh.boneWeights;
			Matrix4x4[] bindposes = sharedMesh.bindposes;
			Transform[] bones = skinnedMeshRenderer_0.bones;
			Vector3 vector = Vector3.zero;
			for (int i = 0; i < vertices.Length; i++)
			{
				array[i] = new Vector3(0f, 0f, 0f);
				BoneWeight boneWeight = boneWeights[i];
				if (boneWeight.weight0 > 0f)
				{
					vector = bindposes[boneWeight.boneIndex0].MultiplyPoint3x4(vertices[i]);
					array[i] += bones[boneWeight.boneIndex0].localToWorldMatrix.MultiplyPoint3x4(vector) * boneWeight.weight0;
				}
				if (boneWeight.weight1 > 0f)
				{
					vector = bindposes[boneWeight.boneIndex1].MultiplyPoint3x4(vertices[i]);
					array[i] += bones[boneWeight.boneIndex1].localToWorldMatrix.MultiplyPoint3x4(vector) * boneWeight.weight1;
				}
				if (boneWeight.weight2 > 0f)
				{
					vector = bindposes[boneWeight.boneIndex2].MultiplyPoint3x4(vertices[i]);
					array[i] += bones[boneWeight.boneIndex2].localToWorldMatrix.MultiplyPoint3x4(vector) * boneWeight.weight2;
				}
				if (boneWeight.weight3 > 0f)
				{
					vector = bindposes[boneWeight.boneIndex3].MultiplyPoint3x4(vertices[i]);
					array[i] += bones[boneWeight.boneIndex3].localToWorldMatrix.MultiplyPoint3x4(vector) * boneWeight.weight3;
				}
				array[i] = skinnedMeshRenderer_0.transform.InverseTransformPoint(array[i]);
			}
			mesh_0.vertices = array;
			mesh_0.triangles = sharedMesh.triangles;
		}
	}

	// Token: 0x06004E81 RID: 20097 RVA: 0x0014CB18 File Offset: 0x0014AD18
	private static bool smethod_1(SkinnedMeshRenderer skinnedMeshRenderer_0, int int_0, out Vector3 vector3_0, bool bool_0)
	{
		bool flag = false;
		vector3_0 = new Vector3(0f, 0f, 0f);
		Mesh sharedMesh = skinnedMeshRenderer_0.sharedMesh;
		if (sharedMesh != null)
		{
			Vector3[] vertices = sharedMesh.vertices;
			BoneWeight[] boneWeights = sharedMesh.boneWeights;
			Matrix4x4[] bindposes = sharedMesh.bindposes;
			Transform[] bones = skinnedMeshRenderer_0.bones;
			Vector3 vector = Vector3.zero;
			Vector3 vector2 = vertices[int_0];
			BoneWeight boneWeight = boneWeights[int_0];
			if (boneWeight.weight0 >= 0f)
			{
				vector = bindposes[boneWeight.boneIndex0].MultiplyPoint3x4(vector2);
				vector3_0 += bones[boneWeight.boneIndex0].localToWorldMatrix.MultiplyPoint3x4(vector) * boneWeight.weight0;
			}
			if (boneWeight.weight1 >= 0f)
			{
				vector = bindposes[boneWeight.boneIndex1].MultiplyPoint3x4(vector2);
				vector3_0 += bones[boneWeight.boneIndex1].localToWorldMatrix.MultiplyPoint3x4(vector) * boneWeight.weight1;
			}
			if (boneWeight.weight2 >= 0f)
			{
				vector = bindposes[boneWeight.boneIndex2].MultiplyPoint3x4(vector2);
				vector3_0 += bones[boneWeight.boneIndex2].localToWorldMatrix.MultiplyPoint3x4(vector) * boneWeight.weight2;
			}
			if (boneWeight.weight3 >= 0f)
			{
				vector = bindposes[boneWeight.boneIndex3].MultiplyPoint3x4(vector2);
				vector3_0 += bones[boneWeight.boneIndex3].localToWorldMatrix.MultiplyPoint3x4(vector) * boneWeight.weight3;
			}
			if (!bool_0)
			{
				vector3_0 = skinnedMeshRenderer_0.transform.InverseTransformPoint(vector3_0);
			}
			flag = true;
		}
		return flag;
	}

	// Token: 0x06004E82 RID: 20098 RVA: 0x0014CD20 File Offset: 0x0014AF20
	public static bool smethod_2(SkinnedMeshRenderer skinnedMeshRenderer_0, int int_0, out Vector3 vector3_0, out Vector3 vector3_1, out Vector3 vector3_2, bool bool_0)
	{
		bool flag = false;
		vector3_0 = new Vector3(0f, 0f, 0f);
		vector3_1 = new Vector3(0f, 0f, 0f);
		vector3_2 = new Vector3(0f, 0f, 0f);
		if (skinnedMeshRenderer_0 != null && int_0 > 0)
		{
			Mesh sharedMesh = skinnedMeshRenderer_0.sharedMesh;
			if (sharedMesh != null && int_0 < sharedMesh.triangles.Length / 3)
			{
				int[] triangles = skinnedMeshRenderer_0.sharedMesh.triangles;
				if (CPUSkinning.smethod_1(skinnedMeshRenderer_0, triangles[3 * int_0], out vector3_0, bool_0) && CPUSkinning.smethod_1(skinnedMeshRenderer_0, triangles[3 * int_0 + 1], out vector3_1, bool_0) && CPUSkinning.smethod_1(skinnedMeshRenderer_0, triangles[3 * int_0 + 2], out vector3_2, bool_0))
				{
					flag = true;
				}
			}
		}
		return flag;
	}
}
