using System;

// Token: 0x02000104 RID: 260
public class TkRTPC_InputAttribute : Attribute
{
	// Token: 0x06000602 RID: 1538 RVA: 0x000071F0 File Offset: 0x000053F0
	public TkRTPC_InputAttribute(string string_0)
	{
		this.m_paramName = string_0;
	}

	// Token: 0x0400058E RID: 1422
	public string m_paramName;
}
