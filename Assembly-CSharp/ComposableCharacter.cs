using System;
using System.Collections.Generic;

// Token: 0x02000142 RID: 322
[Serializable]
public class ComposableCharacter
{
	// Token: 0x06000750 RID: 1872 RVA: 0x00003197 File Offset: 0x00001397
	public ComposableCharacter()
	{
	}

	// Token: 0x06000751 RID: 1873 RVA: 0x00007D11 File Offset: 0x00005F11
	public ComposableCharacter(string string_0, string string_1)
	{
		this.m_sTypeName = string_0;
		this.m_sCharacterName = string_1;
		this.m_aParts = new List<ComposablePart>();
		this.bkID = 0U;
	}

	// Token: 0x06000752 RID: 1874 RVA: 0x0005659C File Offset: 0x0005479C
	public bool method_0(string string_0)
	{
		foreach (ComposablePart composablePart in this.m_aParts)
		{
			if (composablePart.m_sPartName == string_0)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x04000699 RID: 1689
	public uint bkID;

	// Token: 0x0400069A RID: 1690
	public string m_sTypeName;

	// Token: 0x0400069B RID: 1691
	public string m_sCharacterName;

	// Token: 0x0400069C RID: 1692
	public string m_sSkeletonName;

	// Token: 0x0400069D RID: 1693
	public List<ComposablePart> m_aParts;
}
