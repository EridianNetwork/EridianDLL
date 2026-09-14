using System;
using System.Collections.Generic;
using Core;
using UnityEngine;

// Token: 0x02000156 RID: 342
public class UniformBKTGenerator : BuildingKitGenerator
{
	// Token: 0x060007E8 RID: 2024 RVA: 0x00059A9C File Offset: 0x00057C9C
	public override GameObject vmethod_0(BuildingUnit buildingUnit_0)
	{
		this.mUnit = buildingUnit_0;
		this.mKit = BuildingKitManager.smethod_0(buildingUnit_0.bkID);
		global::UnityEngine.Object @object = (global::UnityEngine.Object)new BuildingKitBoneBodyLoader(this.mKit).method_2();
		GameObject gameObject = null;
		try
		{
			gameObject = (GameObject)global::UnityEngine.Object.Instantiate(@object, Vector3.zero, Quaternion.identity);
			gameObject.name = @object.name;
		}
		catch (Exception)
		{
			DebugUtils.LogError(LogCategory.Framework, "Can't Instanciate [" + @object + "]");
		}
		if (gameObject == null)
		{
			DebugUtils.LogError(LogCategory.Framework, "UniformBKTGenerator: bone body failed to load for bkID " + buildingUnit_0.bkID + ", skipping model generation.");
			return null;
		}
		return this.vmethod_1(gameObject, buildingUnit_0);
	}

	// Token: 0x060007E9 RID: 2025 RVA: 0x00059B30 File Offset: 0x00057D30
	public override GameObject vmethod_1(GameObject gameObject_0, BuildingUnit buildingUnit_0)
	{
		this.mKit = BuildingKitManager.smethod_0(buildingUnit_0.bkID);
		this.mUnit = buildingUnit_0;
		this.mCombineInstances = new List<CombineInstance>();
		this.mMaterials = new List<Material>();
		this.mBones = new List<Transform>();
		this.mTransforms = gameObject_0.GetComponentsInChildren<Transform>();
		List<List<int>> list = new List<List<int>>();
		List<int> list2 = new List<int>();
		base.method_3(list, list2);
		if (list.Count > 0)
		{
			this.method_6(list);
		}
		for (int i = 0; i < list2.Count; i++)
		{
			global::UnityEngine.Object @object = (global::UnityEngine.Object)new BuildingKitFbxLoader(this.mKit, list2[i], (int)this.mUnit.mFBXs[list2[i]]).method_2();
			Material material = (Material)new BuildingKitMaterialLoader(this.mKit, list2[i], (int)this.mUnit.mFBXs[list2[i]], (int)this.mUnit.mMats[list2[i]]).method_2();
			for (int j = 0; j < this.mKit.method_16(list2[i], (int)this.mUnit.mFBXs[list2[i]], (int)this.mUnit.mMats[list2[i]]); j++)
			{
				string text = this.mKit.method_17(list2[i], (int)this.mUnit.mFBXs[list2[i]], (int)this.mUnit.mMats[list2[i]], j);
				Texture texture = (Texture)new BuildingKitTextureLoader(this.mKit, list2[i], (int)this.mUnit.mFBXs[list2[i]], (int)this.mUnit.mMats[list2[i]], j).method_2();
				material.SetTexture(text, texture);
			}
			GameObject gameObject = (GameObject)@object;
			this.method_5(gameObject, this.mCombineInstances, this.mMaterials, this.mBones, material, false);
		}
		SkinnedMeshRenderer skinnedMeshRenderer = BuildingKitGenerator.smethod_1(gameObject_0);
		if (skinnedMeshRenderer == null)
		{
			GameObject gameObject2 = new GameObject(BuildingKitGenerator.s_displayObjName);
			skinnedMeshRenderer = gameObject2.AddComponent<SkinnedMeshRenderer>();
			gameObject2.transform.parent = gameObject_0.transform;
			gameObject2.AddComponent<DisplayObjUpdate>();
		}
		if (list2.Count == 0 && list.Count == 1)
		{
			skinnedMeshRenderer.sharedMesh = this.mCombineInstances[0].mesh;
		}
		else
		{
			string text2 = this.mKit.method_1() + this.mKit.method_2() + "FBX";
			for (int k = 0; k < buildingUnit_0.mFBXs.Count; k++)
			{
				string text3 = text2;
				text2 = string.Concat(new object[]
				{
					text3,
					buildingUnit_0.mFBXs[k],
					string.Empty,
					buildingUnit_0.mMats[k]
				});
			}
			Mesh mesh = null;
			uint num = Utility.smethod_1(text2);
			if (!BuildingKitGenerator.s_mergedMesh.TryGetValue(num, out mesh))
			{
				skinnedMeshRenderer.sharedMesh = new Mesh();
				global::UnityEngine.Object sharedMesh = skinnedMeshRenderer.sharedMesh;
				string text3 = "Buildingkit_CombinedMesh" + num;
				skinnedMeshRenderer.sharedMesh.name = text3;
				sharedMesh.name = text3;
				skinnedMeshRenderer.sharedMesh.CombineMeshes(this.mCombineInstances.ToArray(), false, false);
				BuildingKitGenerator.s_mergedMesh.Add(num, skinnedMeshRenderer.sharedMesh);
			}
			else
			{
				skinnedMeshRenderer.sharedMesh = mesh;
			}
		}
		skinnedMeshRenderer.bones = this.mBones.ToArray();
		skinnedMeshRenderer.materials = this.mMaterials.ToArray();
		skinnedMeshRenderer.useLightProbes = true;
		this.mCombineInstances = null;
		this.mMaterials = null;
		this.mBones = null;
		this.mTransforms = null;
		this.mKit = null;
		this.mUnit = null;
		return gameObject_0;
	}

	// Token: 0x060007EA RID: 2026 RVA: 0x00059F30 File Offset: 0x00058130
	private void method_5(GameObject gameObject_0, List<CombineInstance> list_0, List<Material> list_1, List<Transform> list_2, Material material_0, bool bool_0)
	{
		SkinnedMeshRenderer[] componentsInChildren = gameObject_0.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
		foreach (SkinnedMeshRenderer skinnedMeshRenderer in componentsInChildren)
		{
			if (material_0 != null && material_0.GetType() == typeof(Material))
			{
				skinnedMeshRenderer.sharedMaterial = material_0;
				list_1.Add(skinnedMeshRenderer.sharedMaterial);
			}
			for (int j = 0; j < skinnedMeshRenderer.sharedMesh.subMeshCount; j++)
			{
				CombineInstance item = default(CombineInstance);
				if (bool_0)
				{
					item.mesh = (Mesh)UnityEngine.Object.Instantiate(skinnedMeshRenderer.sharedMesh);
				}
				else
				{
					item.mesh = skinnedMeshRenderer.sharedMesh;
				}
				item.subMeshIndex = j;
				list_0.Add(item);
			}
			Transform[] bones = skinnedMeshRenderer.bones;
			foreach (Transform transform in bones)
			{
				Transform[] array = mTransforms;
				foreach (Transform transform2 in array)
				{
					if (!(transform2.name != transform.name))
					{
						list_2.Add(transform2);
						break;
					}
				}
			}
		}
	}
	// Token: 0x060007EB RID: 2027 RVA: 0x0005A04C File Offset: 0x0005824C
	private void method_6(List<List<int>> list_0)
	{
		List<CombineInstance> list = new List<CombineInstance>();
		List<Material> list2 = new List<Material>();
		List<Transform> list3 = new List<Transform>();
		for (int i = 0; i < list_0.Count; i++)
		{
			list.Clear();
			list2.Clear();
			list3.Clear();
			for (int j = 0; j < list_0[i].Count; j++)
			{
				int num = list_0[i][j];
				global::UnityEngine.Object @object = (global::UnityEngine.Object)new BuildingKitFbxLoader(this.mKit, num, (int)this.mUnit.mFBXs[num]).method_2();
				Material material = (Material)new BuildingKitMaterialLoader(this.mKit, num, (int)this.mUnit.mFBXs[num], (int)this.mUnit.mMats[num]).method_2();
				for (int k = 0; k < this.mKit.method_16(num, (int)this.mUnit.mFBXs[num], (int)this.mUnit.mMats[num]); k++)
				{
					string text = this.mKit.method_17(num, (int)this.mUnit.mFBXs[num], (int)this.mUnit.mMats[num], k);
					Texture texture = (Texture)new BuildingKitTextureLoader(this.mKit, num, (int)this.mUnit.mFBXs[num], (int)this.mUnit.mMats[num], k).method_2();
					material.SetTexture(text, texture);
				}
				GameObject gameObject = (GameObject)@object;
				this.method_5(gameObject, list, list2, list3, material, false);
			}
			Material material2 = list2[0];
			CombineInstance combineInstance = default(CombineInstance);
			string text2 = this.mKit.method_1() + this.mKit.method_2() + "SubFBX";
			for (int l = 0; l < list_0[i].Count; l++)
			{
				text2 = string.Concat(new object[]
				{
					text2,
					list_0[i][l],
					string.Empty,
					this.mUnit.mFBXs[list_0[i][l]]
				});
			}
			uint num2 = Utility.smethod_1(text2);
			Mesh mesh = null;
			if (!BuildingKitGenerator.s_mergedMesh.TryGetValue(num2, out mesh))
			{
				Mesh mesh2 = new Mesh();
				mesh2.name = "Buildingkit_CombinedSubMesh_" + text2;
				mesh2.CombineMeshes(list.ToArray(), true, false);
				combineInstance.mesh = mesh2;
				BuildingKitGenerator.s_mergedMesh.Add(num2, mesh2);
			}
			else
			{
				combineInstance.mesh = mesh;
			}
			combineInstance.subMeshIndex = 0;
			this.mCombineInstances.Add(combineInstance);
			this.mBones.AddRange(list3);
			this.mMaterials.Add(material2);
		}
	}

	// Token: 0x040006E6 RID: 1766
	private List<Transform> mBones;
}
