using System;
using ns0;

// Token: 0x02000148 RID: 328
public class BuildingKitFbxLoader : BuildingKitLoader
{
	// Token: 0x0600078B RID: 1931 RVA: 0x00007E87 File Offset: 0x00006087
	public BuildingKitFbxLoader(BuildingKit buildingKit_0, int int_0, int int_1)
	{
		this.kit = buildingKit_0;
		this.nPart = int_0;
		this.nFbx = int_1;
	}

	// Token: 0x0600078C RID: 1932 RVA: 0x000577FC File Offset: 0x000559FC
	protected override object vmethod_1()
	{
		string text = this.kit.method_9(this.nPart, this.nFbx);
		return MonoSingleton<AssetBundleManager>.Instance.method_7(text);
	}

	// Token: 0x0600078D RID: 1933 RVA: 0x00007EA4 File Offset: 0x000060A4
	protected override uint vmethod_0()
	{
		return Utility.smethod_1(this.kit.method_8(this.nPart, this.nFbx));
	}

	// Token: 0x040006B5 RID: 1717
	private BuildingKit kit;

	// Token: 0x040006B6 RID: 1718
	private int nPart;

	// Token: 0x040006B7 RID: 1719
	private int nFbx;
}
