using System;
using UnityEngine;

// Token: 0x02000B69 RID: 2921
[Serializable]
public class TkInspectorHelpBoxAttribute : PropertyAttribute
{
	// Token: 0x06004F59 RID: 20313 RVA: 0x00033C27 File Offset: 0x00031E27
	public TkInspectorHelpBoxAttribute(string string_0, int int_0 = 16, TkInspectorHelpBoxAttribute.Type type_0 = TkInspectorHelpBoxAttribute.Type.None)
	{
		this.message = string_0;
		this.type = type_0;
		this.height = int_0;
	}

	// Token: 0x04003B5A RID: 15194
	public string message;

	// Token: 0x04003B5B RID: 15195
	public TkInspectorHelpBoxAttribute.Type type;

	// Token: 0x04003B5C RID: 15196
	public int height;

	// Token: 0x02000B6A RID: 2922
	public enum Type
	{
		// Token: 0x04003B5E RID: 15198
		None,
		// Token: 0x04003B5F RID: 15199
		Info,
		// Token: 0x04003B60 RID: 15200
		Warning,
		// Token: 0x04003B61 RID: 15201
		Error
	}
}
