using System;
using Core;
using DigitalOpus.MB.Core;
using UnityEngine;

// Token: 0x02000ADB RID: 2779
public class MB2_MeshBaker : MB2_MeshBakerCommon
{
	// Token: 0x06004B61 RID: 19297 RVA: 0x000312E1 File Offset: 0x0002F4E1
	public bool method_3()
	{
		return this.meshCombiner.doUV2();
	}

	// Token: 0x06004B62 RID: 19298 RVA: 0x000312EE File Offset: 0x0002F4EE
	public Mesh method_4()
	{
		return this.meshCombiner.GetMesh();
	}

	// Token: 0x06004B63 RID: 19299 RVA: 0x000312FB File Offset: 0x0002F4FB
	public int method_5()
	{
		return this.meshCombiner.GetLightmapIndex();
	}

	// Token: 0x06004B64 RID: 19300 RVA: 0x00031308 File Offset: 0x0002F508
	public override void vmethod_1()
	{
		this.method_11();
		this.meshCombiner.ClearMesh();
	}

	// Token: 0x06004B65 RID: 19301 RVA: 0x0003131B File Offset: 0x0002F51B
	public override void vmethod_2()
	{
		this.method_11();
		this.meshCombiner.DestroyMesh();
	}

	// Token: 0x06004B66 RID: 19302 RVA: 0x0013950C File Offset: 0x0013770C
	public void method_6()
	{
		if (this.resultSceneObject == null)
		{
			this.resultSceneObject = new GameObject("CombinedMesh-" + base.name);
		}
		this.method_11();
		this.meshCombiner.buildSceneMeshObject(this.resultSceneObject, this.meshCombiner.GetMesh(), false);
		this.method_11();
	}

	// Token: 0x06004B67 RID: 19303 RVA: 0x0003132E File Offset: 0x0002F52E
	public override int vmethod_3()
	{
		return this.meshCombiner.GetNumObjectsInCombined();
	}

	// Token: 0x06004B68 RID: 19304 RVA: 0x0003133B File Offset: 0x0002F53B
	public override int vmethod_4(GameObject gameObject_0)
	{
		return this.meshCombiner.GetNumVerticesFor(gameObject_0);
	}

	// Token: 0x06004B69 RID: 19305 RVA: 0x0013956C File Offset: 0x0013776C
	public override Mesh vmethod_5(GameObject[] gameObject_0, GameObject[] gameObject_1, bool bool_0, bool bool_1)
	{
		if (this.meshCombiner.outputOption == MB2_OutputOptions.bakeIntoSceneObject || (this.meshCombiner.outputOption == MB2_OutputOptions.bakeIntoPrefab && this.meshCombiner.renderType == MB_RenderType.skinnedMeshRenderer))
		{
			this.method_6();
		}
		this.method_11();
		return this.meshCombiner.AddDeleteGameObjects(gameObject_0, gameObject_1, bool_0, bool_1);
	}

	// Token: 0x06004B6A RID: 19306 RVA: 0x00031349 File Offset: 0x0002F549
	public bool method_7(GameObject[] gameObject_0, GameObject[] gameObject_1)
	{
		this.method_11();
		return this.meshCombiner.ShowHideGameObjects(gameObject_0, gameObject_1);
	}

	// Token: 0x06004B6B RID: 19307 RVA: 0x0003135E File Offset: 0x0002F55E
	public override bool vmethod_6(GameObject gameObject_0)
	{
		return this.meshCombiner.CombinedMeshContains(gameObject_0);
	}

	// Token: 0x06004B6C RID: 19308 RVA: 0x0003136C File Offset: 0x0002F56C
	public override void vmethod_7(GameObject[] gameObject_0, bool bool_0 = true)
	{
		this.method_11();
		this.meshCombiner.UpdateGameObjects(gameObject_0, bool_0);
	}

	// Token: 0x06004B6D RID: 19309 RVA: 0x00031381 File Offset: 0x0002F581
	public override void vmethod_8()
	{
		this.method_11();
		this.meshCombiner.Apply();
	}

	// Token: 0x06004B6E RID: 19310 RVA: 0x00031394 File Offset: 0x0002F594
	public void method_8()
	{
		this.method_11();
		this.meshCombiner.ApplyShowHide();
	}

	// Token: 0x06004B6F RID: 19311 RVA: 0x00031381 File Offset: 0x0002F581
	[Obsolete("ApplyAll is deprecated, please use Apply instead.")]
	public void method_9()
	{
		this.method_11();
		this.meshCombiner.Apply();
	}

	// Token: 0x06004B70 RID: 19312 RVA: 0x001395C0 File Offset: 0x001377C0
	public override void vmethod_9(bool bool_0, bool bool_1, bool bool_2, bool bool_3, bool bool_4, bool bool_5, bool bool_6, bool bool_7, bool bool_8 = false)
	{
		this.method_11();
		this.meshCombiner.Apply(bool_0, bool_1, bool_2, bool_3, bool_4, bool_5, bool_6, bool_7, bool_8);
	}

	// Token: 0x06004B71 RID: 19313 RVA: 0x001395F0 File Offset: 0x001377F0
	public void method_10()
	{
		if (this.outputOption == MB2_OutputOptions.bakeMeshAssetsInPlace)
		{
			DebugUtils.LogWarning(LogCategory.Default, "Can't UpdateSkinnedMeshApproximateBounds when output type is bakeMeshAssetsInPlace");
			return;
		}
		if (this.resultSceneObject == null)
		{
			DebugUtils.LogWarning(LogCategory.Default, "Result Scene Object does not exist. No point in calling UpdateSkinnedMeshApproximateBounds.");
			return;
		}
		SkinnedMeshRenderer componentInChildren = this.resultSceneObject.GetComponentInChildren<SkinnedMeshRenderer>();
		if (componentInChildren == null)
		{
			DebugUtils.LogWarning(LogCategory.Default, "No SkinnedMeshRenderer on result scene object.");
			return;
		}
		this.meshCombiner.UpdateSkinnedMeshApproximateBounds();
	}

	// Token: 0x06004B72 RID: 19314 RVA: 0x000313A7 File Offset: 0x0002F5A7
	public override void vmethod_10(string string_0, string string_1)
	{
		this.meshCombiner.SaveMeshsToAssetDatabase(string_0, string_1);
	}

	// Token: 0x06004B73 RID: 19315 RVA: 0x000313B6 File Offset: 0x0002F5B6
	public override void vmethod_11()
	{
		this.meshCombiner.RebuildPrefab(this.resultPrefab);
	}

	// Token: 0x06004B74 RID: 19316 RVA: 0x00139658 File Offset: 0x00137858
	public void method_11()
	{
		this.meshCombiner.name = base.name;
		if (this.resultSceneObject != null)
		{
			this.meshCombiner.targetRenderer = this.resultSceneObject.GetComponentInChildren<Renderer>();
		}
		else
		{
			this.meshCombiner.targetRenderer = null;
		}
		this.meshCombiner.textureBakeResults = this.textureBakeResults;
		this.meshCombiner.renderType = this.renderType;
		this.meshCombiner.outputOption = this.outputOption;
		this.meshCombiner.lightmapOption = this.lightmapOption;
		this.meshCombiner.doNorm = this.doNorm;
		this.meshCombiner.doTan = this.doTan;
		this.meshCombiner.doCol = this.doCol;
		this.meshCombiner.doUV = this.doUV;
		this.meshCombiner.doUV1 = this.doUV1;
	}

	// Token: 0x040036E5 RID: 14053
	[HideInInspector]
	public MB2_MeshCombiner meshCombiner = new MB2_MeshCombiner();
}
