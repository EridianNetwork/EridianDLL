using System;
using Core;
using UnityEngine;

// Token: 0x02000B86 RID: 2950
public class VertexDataCache : MonoBehaviour
{
	// Token: 0x06004FCD RID: 20429 RVA: 0x001528F8 File Offset: 0x00150AF8
	[ContextMenu("Cache")]
	public void method_0()
	{
		MeshFilter component = base.GetComponent<MeshFilter>();
		if (!component)
		{
			DebugUtils.LogError(LogCategory.Graphics, "This method requires a mesh filter!");
			return;
		}
		Mesh sharedMesh = component.sharedMesh;
		this.vertices = sharedMesh.vertices;
		this.normals = sharedMesh.normals;
		this.tangents = sharedMesh.tangents;
		this.uv1 = sharedMesh.uv;
		this.uv2 = sharedMesh.uv2;
		this.triangles = sharedMesh.triangles;
	}

	// Token: 0x06004FCE RID: 20430 RVA: 0x00152970 File Offset: 0x00150B70
	public Mesh method_1()
	{
		return new Mesh
		{
			vertices = this.vertices,
			normals = this.normals,
			tangents = this.tangents,
			uv = this.uv1,
			uv2 = this.uv2,
			triangles = this.triangles
		};
	}

	// Token: 0x04003BF7 RID: 15351
	[HideInInspector]
	public Vector3[] vertices;

	// Token: 0x04003BF8 RID: 15352
	[HideInInspector]
	public Vector3[] normals;

	// Token: 0x04003BF9 RID: 15353
	[HideInInspector]
	public Vector4[] tangents;

	// Token: 0x04003BFA RID: 15354
	[HideInInspector]
	public Vector2[] uv1;

	// Token: 0x04003BFB RID: 15355
	[HideInInspector]
	public Vector2[] uv2;

	// Token: 0x04003BFC RID: 15356
	[HideInInspector]
	public int[] triangles;
}
