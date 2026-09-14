using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Core;
using UnityEngine;

// Token: 0x02000155 RID: 341
public class ModularBKTGenerator : BuildingKitGenerator
{
	// Token: 0x060007E3 RID: 2019 RVA: 0x00058C5C File Offset: 0x00056E5C
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
		this.m_scaleBeforeProcess = gameObject.transform.localScale;
		gameObject.transform.position = Vector3.zero;
		gameObject.transform.rotation = Quaternion.identity;
		gameObject.transform.localScale = Vector3.one;
		this.m_tPoseBoneData = new Dictionary<Transform, TPoseBoneData>();
		this.mTransforms = gameObject.GetComponentsInChildren<Transform>();
		for (int i = 0; i < this.mTransforms.Length; i++)
		{
			Transform transform = this.mTransforms[i];
			if (!this.m_tPoseBoneData.ContainsKey(transform))
			{
				TPoseBoneData tposeBoneData = default(TPoseBoneData);
				tposeBoneData.m_position = transform.position;
				tposeBoneData.m_rotation = transform.rotation;
				if (transform.name == "b_loader")
				{
					tposeBoneData.m_localScale = Vector3.one;
				}
				else
				{
					tposeBoneData.m_localScale = transform.localScale;
				}
				this.m_tPoseBoneData.Add(transform, tposeBoneData);
			}
		}
		return this.vmethod_1(gameObject, buildingUnit_0);
	}

	// Token: 0x060007E4 RID: 2020 RVA: 0x00058DD0 File Offset: 0x00056FD0
	public override GameObject vmethod_1(GameObject gameObject_0, BuildingUnit buildingUnit_0)
	{
		Vector3 position = gameObject_0.transform.position;
		Quaternion rotation = gameObject_0.transform.rotation;
		gameObject_0.transform.position = Vector3.zero;
		gameObject_0.transform.rotation = Quaternion.identity;
		gameObject_0.transform.localScale = Vector3.one;
		this.mKit = BuildingKitManager.smethod_0(buildingUnit_0.bkID);
		this.mUnit = buildingUnit_0;
		this.mMergedObjects = new List<GameObject>();
		this.mCombineInstances = new List<CombineInstance>();
		this.mMaterials = new List<Material>();
		this.mBonesToAssign = new HashSet<Transform>();
		this.mBonesIndex = new Hashtable();
		this.mBonesWeights = new List<BoneWeight>();
		this.mBindposes = new List<Matrix4x4>();
		this.mTransforms = gameObject_0.GetComponentsInChildren<Transform>();
		List<List<int>> list = new List<List<int>>();
		List<int> list2 = new List<int>();
		base.method_3(list, list2);
		for (int i = 0; i < this.mTransforms.Length; i++)
		{
			Transform transform = this.mTransforms[i];
			TPoseBoneData tposeBoneData;
			if (this.m_tPoseBoneData.TryGetValue(transform, out tposeBoneData))
			{
				transform.position = tposeBoneData.m_position;
				transform.rotation = tposeBoneData.m_rotation;
				transform.localScale = tposeBoneData.m_localScale;
			}
		}
		if (list.Count > 0)
		{
			this.method_5(gameObject_0, list);
		}
		for (int j = 0; j < list2.Count; j++)
		{
			global::UnityEngine.Object @object = (global::UnityEngine.Object)new BuildingKitFbxLoader(this.mKit, list2[j], (int)this.mUnit.mFBXs[list2[j]]).method_2();
			Material material = (Material)new BuildingKitMaterialLoader(this.mKit, list2[j], (int)this.mUnit.mFBXs[list2[j]], (int)this.mUnit.mMats[list2[j]]).method_2();
			for (int k = 0; k < this.mKit.method_16(list2[j], (int)this.mUnit.mFBXs[list2[j]], (int)this.mUnit.mMats[list2[j]]); k++)
			{
				string text = this.mKit.method_17(list2[j], (int)this.mUnit.mFBXs[list2[j]], (int)this.mUnit.mMats[list2[j]], k);
				Texture texture = (Texture)new BuildingKitTextureLoader(this.mKit, list2[j], (int)this.mUnit.mFBXs[list2[j]], (int)this.mUnit.mMats[list2[j]], k).method_2();
				material.SetTexture(text, texture);
			}
			GameObject gameObject = (GameObject)@object;
			this.method_6(gameObject_0, gameObject, this.mCombineInstances, this.mMaterials, this.mBonesIndex, this.mBonesToAssign, material, this.mBindposes, this.mBonesWeights);
		}
		for (int l = 0; l < this.mMergedObjects.Count; l++)
		{
			Material material2 = this.mMergedObjects[l].GetComponent<SkinnedMeshRenderer>().material;
			this.method_6(gameObject_0, this.mMergedObjects[l], this.mCombineInstances, this.mMaterials, this.mBonesIndex, this.mBonesToAssign, material2, this.mBindposes, this.mBonesWeights);
			global::UnityEngine.Object.Destroy(this.mMergedObjects[l]);
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
			this.mCombineInstances.RemoveRange(0, list.Count);
			string text2 = this.mKit.method_1() + this.mKit.method_2() + "FBX";
			for (int m = 0; m < buildingUnit_0.mFBXs.Count; m++)
			{
				string text3 = text2;
				text2 = string.Concat(new object[]
				{
					text3,
					buildingUnit_0.mFBXs[m],
					string.Empty,
					buildingUnit_0.mMats[m]
				});
			}
			Mesh mesh = null;
			uint num = Utility.smethod_1(text2);
			if (!BuildingKitGenerator.s_mergedMesh.TryGetValue(num, out mesh))
			{
				int num2 = 0;
				int num3 = 0;
				for (int n = 0; n < this.mCombineInstances.Count; n++)
				{
					num2 += this.mCombineInstances[n].mesh.vertexCount;
					num3 += this.mCombineInstances[n].mesh.tangents.Length;
				}
				skinnedMeshRenderer.sharedMesh = new Mesh();
				global::UnityEngine.Object sharedMesh = skinnedMeshRenderer.sharedMesh;
				string text3 = "Buildingkit_CombinedMesh" + num;
				skinnedMeshRenderer.sharedMesh.name = text3;
				sharedMesh.name = text3;
				skinnedMeshRenderer.sharedMesh.CombineMeshes(this.mCombineInstances.ToArray(), false, true);
				BuildingKitGenerator.s_mergedMesh.Add(num, skinnedMeshRenderer.sharedMesh);
			}
			else
			{
				skinnedMeshRenderer.sharedMesh = mesh;
			}
		}
		skinnedMeshRenderer.bones = this.mBonesToAssign.ToArray<Transform>();
		skinnedMeshRenderer.materials = this.mMaterials.ToArray();
		skinnedMeshRenderer.sharedMesh.bindposes = this.mBindposes.ToArray();
		skinnedMeshRenderer.sharedMesh.boneWeights = this.mBonesWeights.ToArray();
		skinnedMeshRenderer.useLightProbes = true;
		skinnedMeshRenderer.sharedMesh.RecalculateBounds();
		this.mMergedObjects = null;
		this.mCombineInstances = null;
		this.mMaterials = null;
		this.mBonesToAssign = null;
		this.mBonesIndex = null;
		this.mBonesWeights = null;
		this.mBindposes = null;
		this.mTransforms = null;
		this.mKit = null;
		this.mUnit = null;
		gameObject_0.transform.position = position;
		gameObject_0.transform.rotation = rotation;
		gameObject_0.transform.localScale = this.m_scaleBeforeProcess;
		return gameObject_0;
	}

	// Token: 0x060007E5 RID: 2021 RVA: 0x00059440 File Offset: 0x00057640
	private void method_5(GameObject gameObject_0, List<List<int>> list_0)
	{
		List<CombineInstance> list = new List<CombineInstance>();
		HashSet<Transform> hashSet = new HashSet<Transform>();
		Hashtable hashtable = new Hashtable();
		List<Material> list2 = new List<Material>();
		List<Matrix4x4> list3 = new List<Matrix4x4>();
		List<BoneWeight> list4 = new List<BoneWeight>();
		for (int i = 0; i < list_0.Count; i++)
		{
			hashSet.Clear();
			hashtable.Clear();
			list.Clear();
			list2.Clear();
			list3.Clear();
			list4.Clear();
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
				this.method_6(gameObject_0, gameObject, list, list2, hashtable, hashSet, material, list3, list4);
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
			GameObject gameObject2 = new GameObject();
			SkinnedMeshRenderer skinnedMeshRenderer = gameObject2.AddComponent<SkinnedMeshRenderer>();
			skinnedMeshRenderer.bones = hashSet.ToArray<Transform>();
			skinnedMeshRenderer.material = material2;
			if (!BuildingKitGenerator.s_mergedMesh.TryGetValue(num2, out mesh))
			{
				Mesh mesh2 = new Mesh();
				mesh2.name = "Buildingkit_CombinedSubMesh_" + text2;
				mesh2.CombineMeshes(list.ToArray(), true, true);
				combineInstance.mesh = mesh2;
				BuildingKitGenerator.s_mergedMesh.Add(num2, mesh2);
				skinnedMeshRenderer.sharedMesh = mesh2;
				skinnedMeshRenderer.sharedMesh.bindposes = list3.ToArray();
				skinnedMeshRenderer.sharedMesh.boneWeights = list4.ToArray();
			}
			else
			{
				skinnedMeshRenderer.sharedMesh = mesh;
				combineInstance.mesh = mesh;
			}
			combineInstance.subMeshIndex = 0;
			this.mCombineInstances.Add(combineInstance);
			this.mMergedObjects.Add(gameObject2);
		}
	}

	// Token: 0x060007E6 RID: 2022 RVA: 0x000597C0 File Offset: 0x000579C0
	private void method_6(GameObject gameObject_0, GameObject gameObject_1, List<CombineInstance> list_0, List<Material> list_1, Hashtable hashtable_0, HashSet<Transform> hashSet_0, Material material_0, List<Matrix4x4> list_2, List<BoneWeight> list_3)
	{
		SkinnedMeshRenderer[] componentsInChildren = gameObject_1.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
		int num = componentsInChildren.Length;
		for (int i = 0; i < num; i++)
		{
			SkinnedMeshRenderer skinnedMeshRenderer = componentsInChildren[i];
			if (material_0 != null && material_0.GetType() == typeof(Material))
			{
				skinnedMeshRenderer.sharedMaterial = material_0;
				list_1.Add(skinnedMeshRenderer.sharedMaterial);
			}
			for (int j = 0; j < skinnedMeshRenderer.sharedMesh.subMeshCount; j++)
			{
				CombineInstance item = default(CombineInstance);
				item.mesh = skinnedMeshRenderer.sharedMesh;
				item.transform = skinnedMeshRenderer.transform.localToWorldMatrix * gameObject_0.transform.worldToLocalMatrix;
				item.subMeshIndex = j;
				list_0.Add(item);
			}
			for (int k = 0; k < skinnedMeshRenderer.bones.Length; k++)
			{
				try
				{
					bool flag = false;
					string name = skinnedMeshRenderer.bones[k].name;
					for (int l = 0; l < mTransforms.Length; l++)
					{
						if (name == mTransforms[l].name)
						{
							if (hashSet_0.Add(mTransforms[l]))
							{
								list_2.Add(mTransforms[l].worldToLocalMatrix * gameObject_0.transform.localToWorldMatrix);
							}
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						DebugUtils.LogWarning(LogCategory.Framework, "Bone " + name + " not found for part " + skinnedMeshRenderer.gameObject.name);
					}
					if (!hashtable_0.ContainsKey(name))
					{
						int count = hashtable_0.Count;
						hashtable_0.Add(name, count);
					}
				}
				catch (Exception ex)
				{
					DebugUtils.LogError(LogCategory.Framework, ex.Message + " : " + skinnedMeshRenderer.transform.name);
				}
			}
			BoneWeight[] boneWeights = skinnedMeshRenderer.sharedMesh.boneWeights;
			int num2 = boneWeights.Length;
			for (int m = 0; m < num2; m++)
			{
				BoneWeight item2 = boneWeights[m];
				item2.boneIndex0 = (int)hashtable_0[skinnedMeshRenderer.bones[boneWeights[m].boneIndex0].name];
				item2.boneIndex1 = (int)hashtable_0[skinnedMeshRenderer.bones[boneWeights[m].boneIndex1].name];
				item2.boneIndex2 = (int)hashtable_0[skinnedMeshRenderer.bones[boneWeights[m].boneIndex2].name];
				item2.boneIndex3 = (int)hashtable_0[skinnedMeshRenderer.bones[boneWeights[m].boneIndex3].name];
				list_3.Add(item2);
			}
		}
	}
	// Token: 0x040006DF RID: 1759
	private Vector3 m_scaleBeforeProcess;

	// Token: 0x040006E0 RID: 1760
	private List<GameObject> mMergedObjects;

	// Token: 0x040006E1 RID: 1761
	private HashSet<Transform> mBonesToAssign;

	// Token: 0x040006E2 RID: 1762
	private Hashtable mBonesIndex;

	// Token: 0x040006E3 RID: 1763
	private List<BoneWeight> mBonesWeights;

	// Token: 0x040006E4 RID: 1764
	private List<Matrix4x4> mBindposes;

	// Token: 0x040006E5 RID: 1765
	private Dictionary<Transform, TPoseBoneData> m_tPoseBoneData;
}
