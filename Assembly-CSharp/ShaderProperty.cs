using System;

// Token: 0x0200013E RID: 318
[Serializable]
public class ShaderProperty
{
	// Token: 0x0600074A RID: 1866 RVA: 0x00056564 File Offset: 0x00054764
	public ShaderProperty()
	{
		this.mType = ShaderPropertyType.Float;
		this.mName = (this.mDesc = string.Empty);
		this.mValue = null;
	}

	// Token: 0x0600074B RID: 1867 RVA: 0x00007C96 File Offset: 0x00005E96
	public ShaderProperty(ShaderPropertyType inType, string inName, string inDesc, string inValue)
	{
		this.mType = inType;
		this.mName = inName;
		this.mDesc = inDesc;
		this.mValue = inValue;
	}

	// Token: 0x0400068C RID: 1676
	public ShaderPropertyType mType;

	// Token: 0x0400068D RID: 1677
	public string mName;

	// Token: 0x0400068E RID: 1678
	public string mDesc;

	// Token: 0x0400068F RID: 1679
	public string mValue;
}
