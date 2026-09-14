using System;
using Core;
using DigitalOpus.MB.Core;
using UnityEngine;

// Token: 0x02000ADF RID: 2783
public class MB2_MultiMeshBaker : MB2_MeshBakerCommon
{
	// Token: 0x06004B8A RID: 19338 RVA: 0x00031484 File Offset: 0x0002F684
	public override void vmethod_1()
	{
		this.method_3();
		this.meshCombiner.ClearMesh();
	}

	// Token: 0x06004B8B RID: 19339 RVA: 0x00031497 File Offset: 0x0002F697
	public override void vmethod_2()
	{
		this.method_3();
		this.meshCombiner.DestroyMesh();
	}

	// Token: 0x06004B8C RID: 19340 RVA: 0x000314AA File Offset: 0x0002F6AA
	public override int vmethod_3()
	{
		return this.meshCombiner.GetNumObjectsInCombined();
	}

	// Token: 0x06004B8D RID: 19341 RVA: 0x000314B7 File Offset: 0x0002F6B7
	public override int vmethod_4(GameObject gameObject_0)
	{
		return this.meshCombiner.GetNumVerticesFor(gameObject_0);
	}

	// Token: 0x06004B8E RID: 19342 RVA: 0x0013998C File Offset: 0x00137B8C
	public override Mesh vmethod_5(GameObject[] gameObject_0, GameObject[] gameObject_1, bool bool_0, bool bool_1)
	{
		if (this.resultSceneObject == null)
		{
			this.resultSceneObject = new GameObject("CombinedMesh-" + base.name);
		}
		this.method_3();
		return this.meshCombiner.AddDeleteGameObjects(gameObject_0, gameObject_1, bool_0, bool_1);
	}

	// Token: 0x06004B8F RID: 19343 RVA: 0x000314C5 File Offset: 0x0002F6C5
	public override bool vmethod_6(GameObject gameObject_0)
	{
		return this.meshCombiner.CombinedMeshContains(gameObject_0);
	}

	// Token: 0x06004B90 RID: 19344 RVA: 0x000314D3 File Offset: 0x0002F6D3
	public override void vmethod_7(GameObject[] gameObject_0, bool bool_0 = true)
	{
		this.method_3();
		this.meshCombiner.UpdateGameObjects(gameObject_0, bool_0);
	}

	// Token: 0x06004B91 RID: 19345 RVA: 0x000314E8 File Offset: 0x0002F6E8
	public override void vmethod_8()
	{
		this.method_3();
		this.meshCombiner.Apply();
	}

	// Token: 0x06004B92 RID: 19346 RVA: 0x001399DC File Offset: 0x00137BDC
	public override void vmethod_9(bool bool_0, bool bool_1, bool bool_2, bool bool_3, bool bool_4, bool bool_5, bool bool_6, bool bool_7, bool bool_8 = false)
	{
		this.method_3();
		this.meshCombiner.Apply(bool_0, bool_1, bool_2, bool_3, bool_4, bool_5, bool_6, bool_7, bool_8);
	}

	// Token: 0x06004B93 RID: 19347 RVA: 0x000314FB File Offset: 0x0002F6FB
	public override void vmethod_10(string string_0, string string_1)
	{
		this.meshCombiner.SaveMeshsToAssetDatabase(string_0, string_1);
	}

	// Token: 0x06004B94 RID: 19348 RVA: 0x0003150A File Offset: 0x0002F70A
	public override void vmethod_11()
	{
		if (this.renderType == MB_RenderType.skinnedMeshRenderer)
		{
			DebugUtils.LogWarning(LogCategory.Default, "Prefab will not be updated for skinned mesh. This is because all bones need to be included in the prefab for it to be usefull.");
		}
		else
		{
			this.meshCombiner.RebuildPrefab(this.resultPrefab);
		}
	}

	// Token: 0x06004B95 RID: 19349 RVA: 0x00139A0C File Offset: 0x00137C0C
	private void method_3()
	{
		this.meshCombiner.name = base.name;
		this.meshCombiner.textureBakeResults = this.textureBakeResults;
		this.meshCombiner.resultSceneObject = this.resultSceneObject;
		this.meshCombiner.renderType = this.renderType;
		this.meshCombiner.outputOption = this.outputOption;
		this.meshCombiner.lightmapOption = this.lightmapOption;
		this.meshCombiner.doNorm = this.doNorm;
		this.meshCombiner.doTan = this.doTan;
		this.meshCombiner.doCol = this.doCol;
		this.meshCombiner.doUV = this.doUV;
		this.meshCombiner.doUV1 = this.doUV1;
	}

	// Token: 0x040036F7 RID: 14071
	[HideInInspector]
	public MB2_MultiMeshCombiner meshCombiner = new MB2_MultiMeshCombiner();
}
