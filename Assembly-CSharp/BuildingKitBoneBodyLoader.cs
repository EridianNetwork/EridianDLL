using System;
using ns0;

// Token: 0x02000147 RID: 327
public class BuildingKitBoneBodyLoader : BuildingKitLoader
{
	// Token: 0x06000788 RID: 1928 RVA: 0x00007E66 File Offset: 0x00006066
	public BuildingKitBoneBodyLoader(BuildingKit buildingKit_0)
	{
		this.kit = buildingKit_0;
	}

	// Token: 0x06000789 RID: 1929 RVA: 0x000577D4 File Offset: 0x000559D4
	protected override object vmethod_1()
	{
		return MonoSingleton<AssetBundleManager>.Instance.method_7(this.kit.method_4());
	}

	// Token: 0x0600078A RID: 1930 RVA: 0x00007E75 File Offset: 0x00006075
	protected override uint vmethod_0()
	{
		return Utility.smethod_1(this.kit.method_3());
	}

	// Token: 0x040006B4 RID: 1716
	private BuildingKit kit;
}
