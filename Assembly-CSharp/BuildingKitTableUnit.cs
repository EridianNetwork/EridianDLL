using System;

// Token: 0x02000150 RID: 336
[Serializable]
public class BuildingKitTableUnit
{
	// Token: 0x060007C0 RID: 1984 RVA: 0x00003197 File Offset: 0x00001397
	private BuildingKitTableUnit()
	{
	}

	// Token: 0x060007C1 RID: 1985 RVA: 0x0000812F File Offset: 0x0000632F
	public BuildingKitTableUnit(uint uint_0, string string_0)
	{
		this.bkID = uint_0;
		this.filePath = string_0;
	}

	// Token: 0x040006CF RID: 1743
	public uint bkID;

	// Token: 0x040006D0 RID: 1744
	public string filePath;
}
