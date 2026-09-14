using System;
using System.Collections.Generic;
using Core;
using DigitalOpus.MB.Core;
using UnityEngine;

// Token: 0x02000ADC RID: 2780
public abstract class MB2_MeshBakerCommon : MB2_MeshBakerRoot
{
	// Token: 0x06004B76 RID: 19318 RVA: 0x000313F4 File Offset: 0x0002F5F4
	public override List<GameObject> vmethod_0()
	{
		if (this.objsToMesh == null)
		{
			this.objsToMesh = new List<GameObject>();
		}
		return this.objsToMesh;
	}

	// Token: 0x06004B77 RID: 19319 RVA: 0x00139744 File Offset: 0x00137944
	public void method_0(bool bool_0)
	{
		for (int i = 0; i < this.objsToMesh.Count; i++)
		{
			GameObject gameObject = this.objsToMesh[i];
			if (gameObject != null)
			{
				Renderer renderer = MB_Utility.GetRenderer(gameObject);
				if (renderer != null)
				{
					renderer.enabled = bool_0;
				}
			}
		}
	}

	// Token: 0x06004B78 RID: 19320
	public abstract void vmethod_1();

	// Token: 0x06004B79 RID: 19321
	public abstract void vmethod_2();

	// Token: 0x06004B7A RID: 19322
	public abstract int vmethod_3();

	// Token: 0x06004B7B RID: 19323
	public abstract int vmethod_4(GameObject gameObject_0);

	// Token: 0x06004B7C RID: 19324 RVA: 0x0003140F File Offset: 0x0002F60F
	public Mesh method_1(GameObject[] gameObject_0, GameObject[] gameObject_1)
	{
		if (this.textureBakeResults == null)
		{
			DebugUtils.LogError(LogCategory.Default, "Material Bake Results is not set.");
			return null;
		}
		return this.vmethod_5(gameObject_0, gameObject_1, true, this.textureBakeResults.fixOutOfBoundsUVs);
	}

	// Token: 0x06004B7D RID: 19325 RVA: 0x00031440 File Offset: 0x0002F640
	public Mesh method_2(GameObject[] gameObject_0, GameObject[] gameObject_1, bool bool_0)
	{
		if (this.textureBakeResults == null)
		{
			DebugUtils.LogError(LogCategory.Default, "Material Bake Results is not set.");
			return null;
		}
		return this.vmethod_5(gameObject_0, gameObject_1, bool_0, this.textureBakeResults.fixOutOfBoundsUVs);
	}

	// Token: 0x06004B7E RID: 19326
	public abstract Mesh vmethod_5(GameObject[] gameObject_0, GameObject[] gameObject_1, bool bool_0, bool bool_1);

	// Token: 0x06004B7F RID: 19327
	public abstract bool vmethod_6(GameObject gameObject_0);

	// Token: 0x06004B80 RID: 19328
	public abstract void vmethod_7(GameObject[] gameObject_0, bool bool_0 = true);

	// Token: 0x06004B81 RID: 19329
	public abstract void vmethod_8();

	// Token: 0x06004B82 RID: 19330
	public abstract void vmethod_9(bool bool_0, bool bool_1, bool bool_2, bool bool_3, bool bool_4, bool bool_5, bool bool_6, bool bool_7, bool bool_8 = false);

	// Token: 0x06004B83 RID: 19331
	public abstract void vmethod_10(string string_0, string string_1);

	// Token: 0x06004B84 RID: 19332
	public abstract void vmethod_11();

	// Token: 0x040036E6 RID: 14054
	public List<GameObject> objsToMesh;

	// Token: 0x040036E7 RID: 14055
	public bool useObjsToMeshFromTexBaker = true;

	// Token: 0x040036E8 RID: 14056
	[HideInInspector]
	public GameObject resultPrefab;

	// Token: 0x040036E9 RID: 14057
	[HideInInspector]
	public GameObject resultSceneObject;

	// Token: 0x040036EA RID: 14058
	[HideInInspector]
	public MB_RenderType renderType;

	// Token: 0x040036EB RID: 14059
	[HideInInspector]
	public MB2_OutputOptions outputOption;

	// Token: 0x040036EC RID: 14060
	[HideInInspector]
	public MB2_LightmapOptions lightmapOption = MB2_LightmapOptions.ignore_UV2;

	// Token: 0x040036ED RID: 14061
	[HideInInspector]
	public bool doNorm = true;

	// Token: 0x040036EE RID: 14062
	[HideInInspector]
	public bool doTan = true;

	// Token: 0x040036EF RID: 14063
	[HideInInspector]
	public bool doCol;

	// Token: 0x040036F0 RID: 14064
	[HideInInspector]
	public bool doUV = true;

	// Token: 0x040036F1 RID: 14065
	[HideInInspector]
	public bool doUV1;
}
