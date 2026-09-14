using System;
using System.Collections.Generic;
using Core;

// Token: 0x0200014F RID: 335
[Serializable]
public class BuildingKitTable
{
	// Token: 0x060007BD RID: 1981 RVA: 0x00008108 File Offset: 0x00006308
	public BuildingKitTable()
	{
		this.bkTable = new List<BuildingKitTableUnit>();
	}

	// Token: 0x060007BE RID: 1982 RVA: 0x0000811B File Offset: 0x0000631B
	public void method_0(uint uint_0, string string_0)
	{
		this.bkTable.Add(new BuildingKitTableUnit(uint_0, string_0));
	}

	// Token: 0x060007BF RID: 1983 RVA: 0x00058690 File Offset: 0x00056890
	public string method_1(uint uint_0)
	{
		for (int i = 0; i < this.bkTable.Count; i++)
		{
			if (this.bkTable[i].bkID == uint_0)
			{
				return this.bkTable[i].filePath;
			}
		}
		DebugUtils.Log(LogCategory.Framework, "Can't find building kit by this ID :" + uint_0);
		return string.Empty;
	}

	// Token: 0x040006CE RID: 1742
	public List<BuildingKitTableUnit> bkTable;
}
