using System;
using UnityEngine;

// Token: 0x02000B6D RID: 2925
[Serializable]
public class TkObjectNameFieldAttribute : PropertyAttribute
{
	// Token: 0x06004F5C RID: 20316 RVA: 0x00033C5A File Offset: 0x00031E5A
	public TkObjectNameFieldAttribute(Type type_0, bool bool_0)
	{
		this.type = type_0;
		this.allowSceneObject = bool_0;
	}

	// Token: 0x04003B64 RID: 15204
	public Type type;

	// Token: 0x04003B65 RID: 15205
	public bool allowSceneObject;
}
