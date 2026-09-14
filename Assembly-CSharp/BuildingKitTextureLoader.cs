using System;
using ns0;
using UnityEngine;

// Token: 0x0200014A RID: 330
public class BuildingKitTextureLoader : BuildingKitLoader
{
	// Token: 0x06000791 RID: 1937 RVA: 0x00007F0B File Offset: 0x0000610B
	public BuildingKitTextureLoader(BuildingKit buildingKit_0, int int_0, int int_1, int int_2, int int_3)
	{
		this.kit = buildingKit_0;
		this.nPart = int_0;
		this.nFbx = int_1;
		this.nMate = int_2;
		this.nTex = int_3;
	}

	// Token: 0x06000792 RID: 1938 RVA: 0x000578DC File Offset: 0x00055ADC
	protected override object vmethod_1()
	{
		string text = this.kit.method_19(this.nPart, this.nFbx, this.nMate, this.nTex);
		return (Texture)MonoSingleton<AssetBundleManager>.Instance.method_7(text);
	}

	// Token: 0x06000793 RID: 1939 RVA: 0x00007F38 File Offset: 0x00006138
	protected override uint vmethod_0()
	{
		return Utility.smethod_1(this.kit.method_18(this.nPart, this.nFbx, this.nMate, this.nTex));
	}

	// Token: 0x040006BD RID: 1725
	private BuildingKit kit;

	// Token: 0x040006BE RID: 1726
	private int nPart;

	// Token: 0x040006BF RID: 1727
	private int nFbx;

	// Token: 0x040006C0 RID: 1728
	private int nMate;

	// Token: 0x040006C1 RID: 1729
	private int nTex;
}
