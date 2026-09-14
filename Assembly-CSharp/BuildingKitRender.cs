using System;
using System.Collections.Generic;
using Core;
using UnityEngine;

// Token: 0x0200014E RID: 334
public class BuildingKitRender
{
	// Token: 0x060007A4 RID: 1956 RVA: 0x00003197 File Offset: 0x00001397
	private BuildingKitRender()
	{
	}

	// Token: 0x060007A5 RID: 1957 RVA: 0x00057F14 File Offset: 0x00056114
	public BuildingKitRender(string string_0, string string_1)
	{
		uint num = BuildingKitManager.smethod_1(string_0, string_1);
		this.mBuildingKit = BuildingKitManager.smethod_0(num);
		this.method_0(num);
	}

	// Token: 0x060007A6 RID: 1958 RVA: 0x00007FA2 File Offset: 0x000061A2
	public BuildingKitRender(uint uint_0)
	{
		this.mBuildingKit = BuildingKitManager.smethod_0(uint_0);
		this.method_0(uint_0);
	}

	// Token: 0x060007A7 RID: 1959 RVA: 0x00007FBD File Offset: 0x000061BD
	public BuildingKitRender(BuildingUnit buildingUnit_0)
	{
		this.mBuildingKit = BuildingKitManager.smethod_0(buildingUnit_0.bkID);
		this.mBuildingUnit = buildingUnit_0;
		this.mGenerator = this.method_1(this.mBuildingKit);
	}

	// Token: 0x060007A8 RID: 1960 RVA: 0x00057F44 File Offset: 0x00056144
	private void method_0(uint uint_0)
	{
		if (this.mBuildingKit != null)
		{
			this.mGenerator = this.method_1(this.mBuildingKit);
			this.mBuildingUnit = new BuildingUnit(this.mBuildingKit.method_5());
			this.mBuildingUnit.bkID = uint_0;
		}
		else
		{
			DebugUtils.Log(LogCategory.Framework, "BuildingKit create fail since the wrong ID!!");
		}
	}

	// Token: 0x060007A9 RID: 1961 RVA: 0x00007FEF File Offset: 0x000061EF
	private BuildingKitGenerator method_1(BuildingKit buildingKit_0)
	{
		if (buildingKit_0.method_1() == "CHAR")
		{
			return new ModularBKTGenerator();
		}
		return new UniformBKTGenerator();
	}

	// Token: 0x060007AA RID: 1962 RVA: 0x0000800E File Offset: 0x0000620E
	public void method_2()
	{
		this.mGenerator.method_0(this.mBuildingUnit);
	}

	// Token: 0x060007AB RID: 1963 RVA: 0x00008021 File Offset: 0x00006221
	public void method_3(bool bool_0 = true)
	{
		this.mGenerator.method_2(this.mBuildingUnit, bool_0);
	}

	// Token: 0x060007AC RID: 1964 RVA: 0x00008035 File Offset: 0x00006235
	public Task method_4(bool bool_0 = true)
	{
		this.mCachingAll = new Task(this.mGenerator.method_1(this.mBuildingUnit, bool_0), true);
		return this.mCachingAll;
	}

	// Token: 0x1700005B RID: 91
	// (get) Token: 0x060007AD RID: 1965 RVA: 0x0000805B File Offset: 0x0000625B
	public bool Boolean_0
	{
		get
		{
			return !this.mCachingAll.Boolean_0;
		}
	}

	// Token: 0x060007AE RID: 1966 RVA: 0x0000806B File Offset: 0x0000626B
	public void method_5(GameObject gameObject_0)
	{
		this.mCharacter = gameObject_0;
	}

	// Token: 0x060007AF RID: 1967 RVA: 0x00008074 File Offset: 0x00006274
	public GameObject method_6()
	{
		this.mCharacter = this.mGenerator.vmethod_0(this.mBuildingUnit);
		return this.mCharacter;
	}

	// Token: 0x060007B0 RID: 1968 RVA: 0x00008093 File Offset: 0x00006293
	public GameObject method_7()
	{
		if (this.mCharacter != null)
		{
			return this.mGenerator.vmethod_1(this.mCharacter, this.mBuildingUnit);
		}
		return this.method_6();
	}

	// Token: 0x060007B1 RID: 1969 RVA: 0x000080C1 File Offset: 0x000062C1
	public global::UnityEngine.Object method_8()
	{
		return (global::UnityEngine.Object)new BuildingKitBoneBodyLoader(this.mBuildingKit).method_2();
	}

	// Token: 0x1700005C RID: 92
	// (get) Token: 0x060007B2 RID: 1970 RVA: 0x000080D8 File Offset: 0x000062D8
	// (set) Token: 0x060007B3 RID: 1971 RVA: 0x00057F9C File Offset: 0x0005619C
	public BuildingUnit BuildingUnit_0
	{
		get
		{
			return this.mBuildingUnit;
		}
		set
		{
			if (value.bkID == this.mBuildingUnit.bkID)
			{
				this.mBuildingUnit = value;
				for (int i = 0; i < this.mBuildingUnit.method_3(); i++)
				{
					if (this.mBuildingUnit.method_1(i) != null)
					{
						int num = this.mBuildingKit.method_7(i);
						if (num > 0)
						{
							if ((int)this.mBuildingUnit.mFBXs[i] >= num)
							{
								this.mBuildingUnit.mFBXs[i] = 0;
								DebugUtils.LogError(LogCategory.Framework, string.Concat(new string[]
								{
									"Incorrect Fbx For Part[",
									this.mBuildingKit.method_6(i),
									"]from Building Kit[",
									this.mBuildingKit.method_2(),
									"][",
									this.mBuildingKit.method_1(),
									"]"
								}));
							}
							int num2 = this.mBuildingKit.method_10(i, (int)this.mBuildingUnit.mFBXs[i]);
							if (num2 > 0 && (int)this.mBuildingUnit.mMats[i] >= num2)
							{
								this.mBuildingUnit.mMats[i] = 0;
								DebugUtils.LogError(LogCategory.Framework, string.Concat(new string[]
								{
									"Incorrect Material For Part [",
									this.mBuildingKit.method_6(i),
									"] from Building Kit[",
									this.mBuildingKit.method_2(),
									"][",
									this.mBuildingKit.method_1(),
									"]"
								}));
							}
						}
					}
				}
			}
		}
	}

	// Token: 0x060007B4 RID: 1972 RVA: 0x000080E0 File Offset: 0x000062E0
	public int method_9()
	{
		return this.mBuildingKit.method_5();
	}

	// Token: 0x060007B5 RID: 1973 RVA: 0x00058130 File Offset: 0x00056330
	public bool method_10(int int_0)
	{
		if (int_0 > mBuildingKit.method_5())
		{
			return false;
		}
		if (mBuildingKit.method_7(int_0) < 2)
		{
			return false;
		}
		List<byte> mFBXs;
		List<byte> list = (mFBXs = mBuildingUnit.mFBXs);
		int index;
		int index2 = (index = int_0);
		byte b = mFBXs[index];
		list[index2] = (byte)(b + 1);
		if (mBuildingUnit.mFBXs[int_0] >= mBuildingKit.method_7(int_0))
		{
			mBuildingUnit.mFBXs[int_0] = 0;
		}
		mBuildingUnit.mMats[int_0] = 0;
		return true;
	}
	// Token: 0x060007B6 RID: 1974 RVA: 0x000581C4 File Offset: 0x000563C4
	public bool method_11(int int_0, int int_1)
	{
		if (int_0 > this.mBuildingKit.method_5())
		{
			return false;
		}
		if (this.mBuildingKit.method_7(int_0) <= int_1)
		{
			return false;
		}
		if ((int)this.mBuildingUnit.mFBXs[int_0] == int_1)
		{
			return false;
		}
		this.mBuildingUnit.mFBXs[int_0] = (byte)int_1;
		return true;
	}

	// Token: 0x060007B7 RID: 1975 RVA: 0x0005821C File Offset: 0x0005641C
	public bool method_12(int int_0)
	{
		if (int_0 > mBuildingKit.method_5())
		{
			return false;
		}
		if (mBuildingKit.method_10(int_0, mBuildingUnit.mFBXs[int_0]) < 2)
		{
			return false;
		}
		List<byte> mMats;
		List<byte> list = (mMats = mBuildingUnit.mMats);
		int index;
		int index2 = (index = int_0);
		byte b = mMats[index];
		list[index2] = (byte)(b + 1);
		if (mBuildingUnit.mMats[int_0] >= mBuildingKit.method_10(int_0, mBuildingUnit.mFBXs[int_0]))
		{
			mBuildingUnit.mMats[int_0] = 0;
		}
		return true;
	}
	// Token: 0x060007B8 RID: 1976 RVA: 0x000582C0 File Offset: 0x000564C0
	public bool method_13(int int_0, int int_1)
	{
		if (int_0 > this.mBuildingKit.method_5())
		{
			return false;
		}
		if (this.mBuildingKit.method_10(int_0, (int)this.mBuildingUnit.mFBXs[int_0]) <= int_1)
		{
			return false;
		}
		if ((int)this.mBuildingUnit.mMats[int_0] == int_1)
		{
			return false;
		}
		this.mBuildingUnit.mMats[int_0] = (byte)int_1;
		return true;
	}

	// Token: 0x060007B9 RID: 1977 RVA: 0x0005832C File Offset: 0x0005652C
	public void method_14()
	{
		for (int i = 0; i < this.mBuildingKit.method_5(); i++)
		{
			this.mBuildingUnit.mFBXs[i] = (byte)global::UnityEngine.Random.Range(0, this.mBuildingKit.method_7(i) - 1);
			this.mBuildingUnit.mMats[i] = (byte)global::UnityEngine.Random.Range(0, this.mBuildingKit.method_10(i, (int)this.mBuildingUnit.mFBXs[i]));
		}
	}

	// Token: 0x060007BA RID: 1978 RVA: 0x000080ED File Offset: 0x000062ED
	public void method_15()
	{
		if (this.mCharacter != null)
		{
			global::UnityEngine.Object.Destroy(this.mCharacter);
		}
	}

	// Token: 0x060007BB RID: 1979 RVA: 0x000583AC File Offset: 0x000565AC
	public List<string> method_16(bool bool_0 = true)
	{
		List<string> list = new List<string>();
		list.Add(this.mBuildingKit.method_4());
		for (int i = 0; i < this.mBuildingKit.method_5(); i++)
		{
			if (!(this.mBuildingKit.method_8(i, (int)this.mBuildingUnit.mFBXs[i]) == BuildingKit.emptyPart))
			{
				list.Add(this.mBuildingKit.method_9(i, (int)this.mBuildingUnit.mFBXs[i]));
			}
		}
		for (int j = 0; j < this.mBuildingKit.method_5(); j++)
		{
			if (!(this.mBuildingKit.method_8(j, (int)this.mBuildingUnit.mFBXs[j]) == BuildingKit.emptyPart) && bool_0)
			{
				string text = this.mBuildingKit.method_14(j, (int)this.mBuildingUnit.mFBXs[j], (int)this.mBuildingUnit.mMats[j]);
				list.Add(text);
				for (int k = 0; k < this.mBuildingKit.method_16(j, (int)this.mBuildingUnit.mFBXs[j], (int)this.mBuildingUnit.mMats[j]); k++)
				{
					string text2 = this.mBuildingKit.method_19(j, (int)this.mBuildingUnit.mFBXs[j], (int)this.mBuildingUnit.mMats[j], k);
					list.Add(text2);
				}
			}
		}
		return list;
	}

	// Token: 0x060007BC RID: 1980 RVA: 0x00058530 File Offset: 0x00056730
	public List<string> method_17()
	{
		List<string> list = new List<string>();
		if (!new BuildingKitBoneBodyLoader(this.mBuildingKit).method_4())
		{
			list.Add(this.mBuildingKit.method_4());
		}
		for (int i = 0; i < this.mBuildingKit.method_5(); i++)
		{
			for (int j = 0; j < this.mBuildingKit.method_7(i); j++)
			{
				if (!(this.mBuildingKit.method_8(i, j) == BuildingKit.emptyPart))
				{
					if (!new BuildingKitFbxLoader(this.mBuildingKit, i, j).method_4())
					{
						list.Add(this.mBuildingKit.method_9(i, j));
					}
					for (int k = 0; k < this.mBuildingKit.method_10(i, j); k++)
					{
						string text = this.mBuildingKit.method_14(i, j, k);
						if (!new BuildingKitMaterialLoader(this.mBuildingKit, i, j, k).method_4() && !list.Contains(text))
						{
							list.Add(text);
						}
						for (int l = 0; l < this.mBuildingKit.method_16(i, j, k); l++)
						{
							string text2 = this.mBuildingKit.method_19(i, j, k, l);
							if (!new BuildingKitTextureLoader(this.mBuildingKit, i, j, k, l).method_4() && !list.Contains(text2))
							{
								list.Add(text2);
							}
						}
					}
				}
			}
		}
		return list;
	}

	// Token: 0x040006C9 RID: 1737
	private BuildingKitGenerator mGenerator;

	// Token: 0x040006CA RID: 1738
	public BuildingKit mBuildingKit;

	// Token: 0x040006CB RID: 1739
	private BuildingUnit mBuildingUnit;

	// Token: 0x040006CC RID: 1740
	private GameObject mCharacter;

	// Token: 0x040006CD RID: 1741
	private Task mCachingAll;
}
