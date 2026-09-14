using System;
using System.Collections.Generic;

// Token: 0x02000140 RID: 320
[Serializable]
public class ComposableFBX
{
	// Token: 0x0600074D RID: 1869 RVA: 0x00007CE4 File Offset: 0x00005EE4
	public ComposableFBX()
	{
		this.m_aMaterials = new List<ComposableMaterial>();
	}

	// Token: 0x04000695 RID: 1685
	public string m_sFileName;

	// Token: 0x04000696 RID: 1686
	public List<ComposableMaterial> m_aMaterials;
}
