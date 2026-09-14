using System;
using System.Collections.Generic;

// Token: 0x02000141 RID: 321
[Serializable]
public class ComposablePart
{
	// Token: 0x0600074E RID: 1870 RVA: 0x00003197 File Offset: 0x00001397
	private ComposablePart()
	{
	}

	// Token: 0x0600074F RID: 1871 RVA: 0x00007CF7 File Offset: 0x00005EF7
	public ComposablePart(string string_0)
	{
		this.m_sPartName = string_0;
		this.m_aFbxs = new List<ComposableFBX>();
	}

	// Token: 0x04000697 RID: 1687
	public string m_sPartName;

	// Token: 0x04000698 RID: 1688
	public List<ComposableFBX> m_aFbxs;
}
