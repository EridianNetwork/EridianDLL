using System;
using System.Collections.Generic;
using Core;

// Token: 0x02000143 RID: 323
public class BuildingKit
{
	// Token: 0x06000753 RID: 1875 RVA: 0x00003197 File Offset: 0x00001397
	public BuildingKit()
	{
	}

	// Token: 0x06000754 RID: 1876 RVA: 0x00007D39 File Offset: 0x00005F39
	public BuildingKit(string string_0)
	{
		this.method_20(string_0);
	}

	// Token: 0x06000756 RID: 1878 RVA: 0x00007D54 File Offset: 0x00005F54
	public uint method_0()
	{
		return this.m_Character.bkID;
	}

	// Token: 0x06000757 RID: 1879 RVA: 0x00007D61 File Offset: 0x00005F61
	public string method_1()
	{
		return this.m_Character.m_sTypeName;
	}

	// Token: 0x06000758 RID: 1880 RVA: 0x00007D6E File Offset: 0x00005F6E
	public string method_2()
	{
		return this.m_Character.m_sCharacterName;
	}

	// Token: 0x06000759 RID: 1881 RVA: 0x00007D7B File Offset: 0x00005F7B
	public string method_3()
	{
		return this.m_Character.m_sSkeletonName;
	}

	// Token: 0x0600075A RID: 1882 RVA: 0x000565FC File Offset: 0x000547FC
	public string method_4()
	{
		return Utility.smethod_1(this.method_3()).ToString() + ".assetbundle";
	}

	// Token: 0x0600075B RID: 1883 RVA: 0x00007D88 File Offset: 0x00005F88
	public int method_5()
	{
		return this.m_Character.m_aParts.Count;
	}

	// Token: 0x0600075C RID: 1884 RVA: 0x00007D9A File Offset: 0x00005F9A
	public string method_6(int int_0)
	{
		if (int_0 >= this.method_5())
		{
			return string.Empty;
		}
		return this.m_Character.m_aParts[int_0].m_sPartName;
	}

	// Token: 0x0600075D RID: 1885 RVA: 0x00007DC1 File Offset: 0x00005FC1
	public int method_7(int int_0)
	{
		if (int_0 >= this.method_5())
		{
			return 0;
		}
		return this.m_Character.m_aParts[int_0].m_aFbxs.Count;
	}

	// Token: 0x0600075E RID: 1886 RVA: 0x00056628 File Offset: 0x00054828
	public string method_8(int int_0, int int_1)
	{
		if (int_0 >= this.method_5())
		{
			return string.Empty;
		}
		if (int_1 >= this.m_Character.m_aParts[int_0].m_aFbxs.Count)
		{
			DebugUtils.LogError(LogCategory.Framework, string.Concat(new object[]
			{
				"part",
				int_0,
				" fbx+",
				int_1,
				"name",
				this.m_Character.m_sCharacterName
			}));
			return string.Empty;
		}
		return this.m_Character.m_aParts[int_0].m_aFbxs[int_1].m_sFileName;
	}

	// Token: 0x0600075F RID: 1887 RVA: 0x000566D4 File Offset: 0x000548D4
	public string method_9(int int_0, int int_1)
	{
		if (int_0 < this.method_5() && !(this.m_Character.m_aParts[int_0].m_aFbxs[int_1].m_sFileName == BuildingKit.emptyPart))
		{
			return Utility.smethod_1(this.method_8(int_0, int_1)).ToString() + ".assetbundle";
		}
		return string.Empty;
	}

	// Token: 0x06000760 RID: 1888 RVA: 0x0005673C File Offset: 0x0005493C
	public int method_10(int int_0, int int_1)
	{
		if (int_0 < this.method_5() && !(this.m_Character.m_aParts[int_0].m_aFbxs[int_1].m_sFileName == BuildingKit.emptyPart))
		{
			return this.m_Character.m_aParts[int_0].m_aFbxs[int_1].m_aMaterials.Count;
		}
		return 0;
	}

	// Token: 0x06000761 RID: 1889 RVA: 0x000567A8 File Offset: 0x000549A8
	public bool method_11()
	{
		List<string> list = new List<string>();
		for (int i = 0; i < this.m_Character.m_aParts[0].m_aFbxs[0].m_aMaterials.Count; i++)
		{
			list.Add(this.m_Character.m_aParts[0].m_aFbxs[0].m_aMaterials[i].m_sMaterial);
		}
		bool flag = true;
		for (int j = 0; j < this.m_Character.m_aParts.Count; j++)
		{
			for (int k = 0; k < this.m_Character.m_aParts[j].m_aFbxs.Count; k++)
			{
				for (int l = 0; l < this.m_Character.m_aParts[j].m_aFbxs[k].m_aMaterials.Count; l++)
				{
					if (this.m_Character.m_aParts[j].m_aFbxs[k].m_aMaterials[l].m_sMaterial != list[l])
					{
						flag = false;
					}
				}
			}
		}
		return flag;
	}

	// Token: 0x06000762 RID: 1890 RVA: 0x000568E4 File Offset: 0x00054AE4
	public List<ShaderProperty> method_12(int int_0, int int_1, int int_2)
	{
		if (int_0 < this.method_5() && !(this.m_Character.m_aParts[int_0].m_aFbxs[int_1].m_sFileName == BuildingKit.emptyPart))
		{
			return this.m_Character.m_aParts[int_0].m_aFbxs[int_1].m_aMaterials[int_2].m_sShaderProperties;
		}
		return null;
	}

	// Token: 0x06000763 RID: 1891 RVA: 0x00056958 File Offset: 0x00054B58
	public string method_13(int int_0, int int_1, int int_2)
	{
		if (int_0 < this.method_5() && !(this.m_Character.m_aParts[int_0].m_aFbxs[int_1].m_sFileName == BuildingKit.emptyPart))
		{
			return this.m_Character.m_aParts[int_0].m_aFbxs[int_1].m_aMaterials[int_2].m_sMaterial;
		}
		return string.Empty;
	}

	// Token: 0x06000764 RID: 1892 RVA: 0x000569D0 File Offset: 0x00054BD0
	public string method_14(int int_0, int int_1, int int_2)
	{
		if (int_0 < this.method_5() && !(this.m_Character.m_aParts[int_0].m_aFbxs[int_1].m_sFileName == BuildingKit.emptyPart))
		{
			return Utility.smethod_1(this.method_13(int_0, int_1, int_2)).ToString() + ".assetbundle";
		}
		return string.Empty;
	}

	// Token: 0x06000765 RID: 1893 RVA: 0x00056A3C File Offset: 0x00054C3C
	public string method_15(int int_0, int int_1, int int_2)
	{
		if (int_0 < this.method_5() && !(this.m_Character.m_aParts[int_0].m_aFbxs[int_1].m_sFileName == BuildingKit.emptyPart))
		{
			return this.m_Character.m_aParts[int_0].m_aFbxs[int_1].m_aMaterials[int_2].m_sShader;
		}
		return string.Empty;
	}

	// Token: 0x06000766 RID: 1894 RVA: 0x00056AB4 File Offset: 0x00054CB4
	public int method_16(int int_0, int int_1, int int_2)
	{
		if (int_0 < this.method_5() && !(this.m_Character.m_aParts[int_0].m_aFbxs[int_1].m_sFileName == BuildingKit.emptyPart))
		{
			return this.m_Character.m_aParts[int_0].m_aFbxs[int_1].m_aMaterials[int_2].m_sTexName.Count;
		}
		return 0;
	}

	// Token: 0x06000767 RID: 1895 RVA: 0x00056B2C File Offset: 0x00054D2C
	public string method_17(int int_0, int int_1, int int_2, int int_3)
	{
		if (int_0 < this.method_5() && !(this.m_Character.m_aParts[int_0].m_aFbxs[int_1].m_sFileName == BuildingKit.emptyPart))
		{
			return this.m_Character.m_aParts[int_0].m_aFbxs[int_1].m_aMaterials[int_2].m_sTexName[int_3];
		}
		return string.Empty;
	}

	// Token: 0x06000768 RID: 1896 RVA: 0x00056BA8 File Offset: 0x00054DA8
	public string method_18(int int_0, int int_1, int int_2, int int_3)
	{
		if (int_0 < this.method_5() && !(this.m_Character.m_aParts[int_0].m_aFbxs[int_1].m_sFileName == BuildingKit.emptyPart))
		{
			return this.m_Character.m_aParts[int_0].m_aFbxs[int_1].m_aMaterials[int_2].m_sTexFileName[int_3];
		}
		return string.Empty;
	}

	// Token: 0x06000769 RID: 1897 RVA: 0x00056C24 File Offset: 0x00054E24
	public string method_19(int int_0, int int_1, int int_2, int int_3)
	{
		if (int_0 < this.method_5() && !(this.m_Character.m_aParts[int_0].m_aFbxs[int_1].m_sFileName == BuildingKit.emptyPart))
		{
			return Utility.smethod_1(this.method_18(int_0, int_1, int_2, int_3)).ToString() + ".assetbundle";
		}
		return string.Empty;
	}

	// Token: 0x0600076A RID: 1898 RVA: 0x00056C90 File Offset: 0x00054E90
	public void method_20(string string_0)
	{
		string text = string_0.ToLower();
		this.m_Character = (ComposableCharacter)new BuildingKitBinaryLoader(text).method_2();
	}

	// Token: 0x0400069E RID: 1694
	public static string emptyPart = "empty";

	// Token: 0x0400069F RID: 1695
	private ComposableCharacter m_Character;
}
