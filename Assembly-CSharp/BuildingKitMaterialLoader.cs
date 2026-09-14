using System;
using Core;
using ns0;
using UnityEngine;

// Token: 0x02000149 RID: 329
public class BuildingKitMaterialLoader : BuildingKitLoader
{
	// Token: 0x0600078E RID: 1934 RVA: 0x00007EC2 File Offset: 0x000060C2
	public BuildingKitMaterialLoader(BuildingKit buildingKit_0, int int_0, int int_1, int int_2)
	{
		this.kit = buildingKit_0;
		this.nPart = int_0;
		this.nFbx = int_1;
		this.nMate = int_2;
	}

	// Token: 0x0600078F RID: 1935 RVA: 0x00057830 File Offset: 0x00055A30
	protected override object vmethod_1()
	{
		Material material = null;
		try
		{
			string text = this.kit.method_14(this.nPart, this.nFbx, this.nMate);
			material = (Material)MonoSingleton<AssetBundleManager>.Instance.method_7(text);
		}
		catch (Exception)
		{
		}
		Shader shader = material.shader;
		string name = shader.name;
		material.shader = Shader.Find(name);
		if (shader.GetInstanceID() != material.shader.GetInstanceID())
		{
			if (this.BroadestTestInfo)
			{
				DebugUtils.Log(LogCategory.Framework, "unload duplicate shader " + material.shader.name);
			}
			Resources.UnloadAsset(shader);
		}
		return material;
	}

	// Token: 0x06000790 RID: 1936 RVA: 0x00007EE7 File Offset: 0x000060E7
	protected override uint vmethod_0()
	{
		return Utility.smethod_1(this.kit.method_13(this.nPart, this.nFbx, this.nMate));
	}

	// Token: 0x040006B8 RID: 1720
	private BuildingKit kit;

	// Token: 0x040006B9 RID: 1721
	private int nPart;

	// Token: 0x040006BA RID: 1722
	private int nFbx;

	// Token: 0x040006BB RID: 1723
	private int nMate;

	// Token: 0x040006BC RID: 1724
	private bool BroadestTestInfo;
}
