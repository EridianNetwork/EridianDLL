using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

// Token: 0x0200014D RID: 333
public class BuildingKitManager
{
	// Token: 0x0600079E RID: 1950 RVA: 0x00003197 File Offset: 0x00001397
	protected BuildingKitManager()
	{
	}

	// Token: 0x1700005A RID: 90
	// (get) Token: 0x060007A0 RID: 1952 RVA: 0x00057E44 File Offset: 0x00056044
	// (set) Token: 0x060007A1 RID: 1953 RVA: 0x00007F9A File Offset: 0x0000619A
	public static BuildingKitTable BuildingKitTable_0
	{
		get
		{
			if (BuildingKitManager.bkTableStrings == null)
			{
				TextAsset textAsset = ResourcesLoader.smethod_0("BuildingKit/BuildingKitTable/bkTable") as TextAsset;
				using (Stream stream = new MemoryStream(textAsset.bytes))
				{
					XmlSerializer xmlSerializer = new XmlSerializer(typeof(BuildingKitTable));
					BuildingKitManager.bkTableStrings = (BuildingKitTable)xmlSerializer.Deserialize(stream);
				}
				ResourcesLoader.smethod_6(textAsset);
			}
			return BuildingKitManager.bkTableStrings;
		}
		private set
		{
			BuildingKitManager.bkTableStrings = value;
		}
	}

	// Token: 0x060007A2 RID: 1954 RVA: 0x00057EBC File Offset: 0x000560BC
	public static BuildingKit smethod_0(uint uint_0)
	{
		BuildingKit buildingKit = null;
		if (!BuildingKitManager.bkTable.TryGetValue(uint_0, out buildingKit))
		{
			buildingKit = new BuildingKit(BuildingKitManager.BuildingKitTable_0.method_1(uint_0));
			BuildingKitManager.bkTable.Add(uint_0, buildingKit);
		}
		return buildingKit;
	}

	// Token: 0x060007A3 RID: 1955 RVA: 0x00057EF8 File Offset: 0x000560F8
	public static uint smethod_1(string string_0, string string_1)
	{
		string text = string_0 + string_1;
		return Utility.smethod_1(text);
	}

	// Token: 0x040006C4 RID: 1732
	public static string[] shaderTexPropertyNames = new string[]
	{
		"_MainTex", "_MaskTex", "_BumpMap", "_Cube", "_PatternTex", "_Patten0Tex", "_Patten1Tex", "_DecalTex", "_Ramp", "_Mask",
		"_Illum"
	};

	// Token: 0x040006C5 RID: 1733
	public static string[] mergeableShaderTexPropertyNames = new string[] { "_MaskTex", "_BumpMap", "_Patten0Tex", "_Patten1Tex", "_MainTex" };

	// Token: 0x040006C6 RID: 1734
	public static bool OnlineHostMinResMode = false;

	// Token: 0x040006C7 RID: 1735
	private static BuildingKitTable bkTableStrings;

	// Token: 0x040006C8 RID: 1736
	private static Dictionary<uint, BuildingKit> bkTable = new Dictionary<uint, BuildingKit>();
}
