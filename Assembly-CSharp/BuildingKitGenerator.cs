using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000144 RID: 324
public abstract class BuildingKitGenerator
{
	// Token: 0x0600076B RID: 1899 RVA: 0x00007DE9 File Offset: 0x00005FE9
	public BuildingKitGenerator()
	{
		if (BuildingKitGenerator.s_mergedMesh == null)
		{
			BuildingKitGenerator.s_mergedMesh = new Dictionary<uint, Mesh>();
		}
	}

	// Token: 0x0600076D RID: 1901 RVA: 0x00056CBC File Offset: 0x00054EBC
	public static void smethod_0()
	{
		if (BuildingKitGenerator.s_mergedMesh == null)
		{
			return;
		}
		foreach (KeyValuePair<uint, Mesh> keyValuePair in BuildingKitGenerator.s_mergedMesh)
		{
			global::UnityEngine.Object.Destroy(keyValuePair.Value);
		}
		BuildingKitGenerator.s_mergedMesh.Clear();
	}

	// Token: 0x0600076E RID: 1902 RVA: 0x00056D08 File Offset: 0x00054F08
	public void method_0(BuildingUnit buildingUnit_0)
	{
		this.mUnit = buildingUnit_0;
		this.mKit = BuildingKitManager.smethod_0(buildingUnit_0.bkID);
		new BuildingKitBoneBodyLoader(this.mKit).method_3();
		for (int i = 0; i < this.mKit.method_5(); i++)
		{
			for (int j = 0; j < this.mKit.method_7(i); j++)
			{
				if (!(this.mKit.method_8(i, j) == BuildingKit.emptyPart))
				{
					new BuildingKitFbxLoader(this.mKit, i, j).method_3();
					for (int k = 0; k < this.mKit.method_10(i, j); k++)
					{
						new BuildingKitMaterialLoader(this.mKit, i, j, k).method_3();
						for (int l = 0; l < this.mKit.method_16(i, j, k); l++)
						{
							new BuildingKitTextureLoader(this.mKit, i, j, k, l).method_3();
						}
					}
				}
			}
		}
	}

	// Token: 0x0600076F RID: 1903 RVA: 0x00056DFC File Offset: 0x00054FFC
	public IEnumerator method_1(BuildingUnit buildingUnit_0, bool bool_0)
	{
		mUnit = buildingUnit_0;
		mKit = BuildingKitManager.smethod_0(buildingUnit_0.bkID);
		new BuildingKitBoneBodyLoader(mKit).method_2();
		for (int iPart = 0; iPart < mKit.method_5(); iPart++)
		{
			for (int iFbx = 0; iFbx < mKit.method_7(iPart); iFbx++)
			{
				if (mKit.method_8(iPart, iFbx) == BuildingKit.emptyPart)
				{
					continue;
				}
				new BuildingKitFbxLoader(mKit, iPart, iFbx).method_2();
				if (!bool_0)
				{
					continue;
				}
				for (int iMaterial = 0; iMaterial < mKit.method_10(iPart, iFbx); iMaterial++)
				{
					new BuildingKitMaterialLoader(mKit, iPart, iFbx, iMaterial).method_2();
					for (int iTexture = 0; iTexture < mKit.method_16(iPart, iFbx, iMaterial); iTexture++)
					{
						new BuildingKitTextureLoader(mKit, iPart, iFbx, iMaterial, iTexture).method_2();
					}
				}
			}
			yield return null;
		}
		yield return null;
	}
	// Token: 0x06000770 RID: 1904 RVA: 0x00056E34 File Offset: 0x00055034
	public void method_2(BuildingUnit buildingUnit_0, bool bool_0)
	{
		this.mUnit = buildingUnit_0;
		this.mKit = BuildingKitManager.smethod_0(buildingUnit_0.bkID);
		new BuildingKitBoneBodyLoader(this.mKit).method_2();
		List<List<int>> list = new List<List<int>>();
		List<int> list2 = new List<int>();
		this.method_3(list, list2);
		for (int i = 0; i < list.Count; i++)
		{
			for (int j = 0; j < list[i].Count; j++)
			{
				int num = list[i][j];
				new BuildingKitFbxLoader(this.mKit, num, (int)this.mUnit.mFBXs[num]).method_2();
				if (bool_0)
				{
					new BuildingKitMaterialLoader(this.mKit, num, (int)this.mUnit.mFBXs[num], (int)this.mUnit.mMats[num]).method_2();
					for (int k = 0; k < this.mKit.method_16(num, (int)this.mUnit.mFBXs[num], (int)this.mUnit.mMats[num]); k++)
					{
						new BuildingKitTextureLoader(this.mKit, num, (int)this.mUnit.mFBXs[num], (int)this.mUnit.mMats[num], k).method_2();
					}
				}
			}
		}
		for (int l = 0; l < list2.Count; l++)
		{
			new BuildingKitFbxLoader(this.mKit, list2[l], (int)this.mUnit.mFBXs[list2[l]]).method_2();
			if (bool_0)
			{
				new BuildingKitMaterialLoader(this.mKit, list2[l], (int)this.mUnit.mFBXs[list2[l]], (int)this.mUnit.mMats[list2[l]]).method_2();
				for (int m = 0; m < this.mKit.method_16(list2[l], (int)this.mUnit.mFBXs[list2[l]], (int)this.mUnit.mMats[list2[l]]); m++)
				{
					new BuildingKitTextureLoader(this.mKit, list2[l], (int)this.mUnit.mFBXs[list2[l]], (int)this.mUnit.mMats[list2[l]], m).method_2();
				}
			}
		}
	}

	// Token: 0x06000771 RID: 1905 RVA: 0x000570D8 File Offset: 0x000552D8
	public static SkinnedMeshRenderer smethod_1(GameObject gameObject_0)
	{
		Transform transform = gameObject_0.transform.FindChild(BuildingKitGenerator.s_displayObjName);
		if (transform != null)
		{
			return transform.gameObject.GetComponent<SkinnedMeshRenderer>();
		}
		return null;
	}

	// Token: 0x06000772 RID: 1906
	public abstract GameObject vmethod_0(BuildingUnit buildingUnit_0);

	// Token: 0x06000773 RID: 1907
	public abstract GameObject vmethod_1(GameObject gameObject_0, BuildingUnit buildingUnit_0);

	// Token: 0x06000774 RID: 1908 RVA: 0x00057110 File Offset: 0x00055310
	protected void method_3(List<List<int>> list_0, List<int> list_1)
	{
		List<int> list = new List<int>();
		for (int i = 0; i < this.mKit.method_5(); i++)
		{
			if (!(this.mKit.method_8(i, (int)this.mUnit.mFBXs[i]) == BuildingKit.emptyPart) && !list.Contains(i))
			{
				bool flag = false;
				List<int> list2 = new List<int>();
				for (int j = i + 1; j < this.mKit.method_5(); j++)
				{
					if (!(this.mKit.method_8(j, (int)this.mUnit.mFBXs[j]) == BuildingKit.emptyPart) && !list.Contains(j) && this.method_4(i, j))
					{
						flag = true;
						list2.Add(j);
						list.Add(j);
					}
				}
				if (flag)
				{
					list2.Add(i);
					list.Add(i);
					list_0.Add(list2);
				}
				else
				{
					list_1.Add(i);
				}
			}
		}
	}

	// Token: 0x06000775 RID: 1909 RVA: 0x00057210 File Offset: 0x00055410
	protected bool method_4(int int_0, int int_1)
	{
		byte b = this.mUnit.mFBXs[int_0];
		byte b2 = this.mUnit.mFBXs[int_1];
		byte b3 = this.mUnit.mMats[int_0];
		byte b4 = this.mUnit.mMats[int_1];
		bool flag = false;
		if (this.mKit.method_13(int_0, (int)b, (int)b3) == this.mKit.method_13(int_1, (int)b2, (int)b4))
		{
			return true;
		}
		bool flag2 = this.mKit.method_15(int_0, (int)b, (int)b3) == this.mKit.method_15(int_1, (int)b2, (int)b4);
		bool flag3;
		if (flag3 = this.mKit.method_16(int_0, (int)b, (int)b3) == this.mKit.method_16(int_1, (int)b2, (int)b4))
		{
			for (int i = 0; i < this.mKit.method_16(int_0, (int)b, (int)b3); i++)
			{
				if (this.mKit.method_18(int_0, (int)b, (int)b3, i) != this.mKit.method_18(int_1, (int)b2, (int)b4, i))
				{
					flag3 = false;
					break;
				}
			}
		}
		if (flag2 && flag3)
		{
			for (int j = 0; j < this.mKit.method_16(int_0, (int)b, (int)b3); j++)
			{
				if (this.mKit.method_17(int_0, (int)b, (int)b3, j) != this.mKit.method_17(int_1, (int)b2, (int)b4, j))
				{
					return false;
				}
			}
			List<ShaderProperty> list = this.mKit.method_12(int_0, (int)b, (int)b3);
			List<ShaderProperty> list2 = this.mKit.method_12(int_1, (int)b2, (int)b4);
			if (list != null && list2 != null && list.Count == list2.Count)
			{
				for (int k = 0; k < list.Count; k++)
				{
					ShaderProperty shaderProperty = list[k];
					ShaderProperty shaderProperty2 = list2[k];
					if (shaderProperty.mType == shaderProperty2.mType && shaderProperty.mName == shaderProperty2.mName && shaderProperty.mValue != shaderProperty2.mValue)
					{
						return false;
					}
				}
			}
			return true;
		}
		return flag;
	}

	// Token: 0x040006A0 RID: 1696
	protected List<CombineInstance> mCombineInstances;

	// Token: 0x040006A1 RID: 1697
	protected List<Material> mMaterials;

	// Token: 0x040006A2 RID: 1698
	protected Transform[] mTransforms;

	// Token: 0x040006A3 RID: 1699
	protected BuildingKit mKit;

	// Token: 0x040006A4 RID: 1700
	protected BuildingUnit mUnit;

	// Token: 0x040006A5 RID: 1701
	protected static string s_displayObjName = "displayObj";

	// Token: 0x040006A6 RID: 1702
	protected static Dictionary<uint, Mesh> s_mergedMesh;
}
