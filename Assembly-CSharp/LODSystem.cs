using System;
using Core;
using UnityEngine;

// Token: 0x020000D3 RID: 211
public class LODSystem
{
	// Token: 0x060004F3 RID: 1267 RVA: 0x0004C28C File Offset: 0x0004A48C
	public static void smethod_0(GameObject gameObject_0, int int_0)
	{
		if (gameObject_0.GetComponents<MeshFilter>() == null)
		{
			return;
		}
		GameObject[] array = new GameObject[int_0];
		LOD[] array2 = new LOD[int_0];
		Mesh sharedMesh = gameObject_0.GetComponent<MeshFilter>().sharedMesh;
		if (int_0 == 1)
		{
			return;
		}
		LODGroup lodgroup = gameObject_0.AddComponent<LODGroup>();
		for (int i = 1; i < int_0; i++)
		{
			array[i] = (GameObject)global::UnityEngine.Object.Instantiate(gameObject_0, Vector3.zero, Quaternion.identity);
			global::UnityEngine.Object.Destroy(array[i].GetComponent<LODTag>());
		}
		for (int j = 0; j < int_0; j++)
		{
			Renderer[] array3 = new Renderer[1];
			if (j == 0)
			{
				array3[0] = gameObject_0.renderer;
			}
			else
			{
				array[j].transform.parent = gameObject_0.transform;
				array[j].transform.localPosition = Vector3.zero;
				array[j].transform.localRotation = Quaternion.identity;
				array[j].name = "LOD" + j;
				Mesh mesh = new Mesh();
				LODSystem.smethod_2(sharedMesh, mesh, -1);
				array[j].GetComponent<MeshFilter>().mesh = mesh;
				array3[0] = array[j].renderer;
			}
			array2[j] = new LOD(1f / (float)(j + 1), array3);
		}
		lodgroup.SetLODS(array2);
		lodgroup.RecalculateBounds();
	}

	// Token: 0x060004F4 RID: 1268 RVA: 0x0004C3E0 File Offset: 0x0004A5E0
	public static void smethod_1(GameObject gameObject_0, int int_0)
	{
		if (gameObject_0.GetComponents<MeshFilter>() == null)
		{
			return;
		}
		GameObject[] array = new GameObject[int_0];
		LOD[] array2 = new LOD[int_0];
		Mesh sharedMesh = gameObject_0.GetComponent<MeshFilter>().sharedMesh;
		if (gameObject_0.GetComponent<LODGroup>() != null)
		{
			foreach (Renderer renderer in gameObject_0.GetComponentsInChildren<Renderer>())
			{
				if (renderer.gameObject.name.Contains("LOD"))
				{
					global::UnityEngine.Object.DestroyImmediate(renderer.gameObject);
				}
			}
			global::UnityEngine.Object.DestroyImmediate(gameObject_0.GetComponent<LODGroup>());
		}
		if (int_0 == 1)
		{
			return;
		}
		LODGroup lodgroup = gameObject_0.AddComponent<LODGroup>();
		for (int j = 1; j < int_0; j++)
		{
			array[j] = (GameObject)global::UnityEngine.Object.Instantiate(gameObject_0, Vector3.zero, Quaternion.identity);
		}
		for (int k = 0; k < int_0; k++)
		{
			Renderer[] array3 = new Renderer[1];
			if (k == 0)
			{
				array3[0] = gameObject_0.renderer;
			}
			else
			{
				array[k].transform.parent = gameObject_0.transform;
				array[k].transform.localPosition = Vector3.zero;
				array[k].transform.localRotation = Quaternion.identity;
				array[k].name = "LOD" + k;
				Mesh mesh = new Mesh();
				LODSystem.smethod_2(sharedMesh, mesh, -1);
				array[k].GetComponent<MeshFilter>().mesh = mesh;
				array3[0] = array[k].renderer;
			}
			array2[k] = new LOD(1f / (float)(k + 1), array3);
		}
		lodgroup.SetLODS(array2);
		lodgroup.RecalculateBounds();
	}

	// Token: 0x060004F5 RID: 1269 RVA: 0x0004C584 File Offset: 0x0004A784
	private static void smethod_2(Mesh mesh_0, Mesh mesh_1, int int_0)
	{
		QEMInput qeminput = new QEMInput();
		qeminput.m_vertex = mesh_0.vertices;
		qeminput.m_triangle = mesh_0.triangles;
		if (mesh_0.uv != null)
		{
			qeminput.m_uv = mesh_0.uv;
			qeminput.m_uvWeight = 0.05f;
		}
		if (mesh_0.uv2 != null)
		{
			qeminput.m_uv2 = mesh_0.uv2;
			qeminput.m_uv2Weight = 500f;
		}
		if (mesh_0.normals != null)
		{
			qeminput.m_normal = mesh_0.normals;
			qeminput.m_normalWeight = 0.05f;
		}
		if (mesh_0.uv == null)
		{
			DebugUtils.Log(LogCategory.Graphics, "srcMesh.uv == null");
			return;
		}
		if (mesh_0.uv2 == null)
		{
			DebugUtils.Log(LogCategory.Graphics, "srcMesh.uv2 == null");
			return;
		}
		QEMCenter qemcenter = new QEMCenter(qeminput);
		if (int_0 > 0)
		{
			qemcenter.method_6(int_0);
		}
		else if (int_0 < 0)
		{
			qemcenter.method_7();
		}
		qemcenter.method_5(mesh_1);
	}
}
