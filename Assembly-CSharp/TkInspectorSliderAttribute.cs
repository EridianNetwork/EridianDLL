using System;
using UnityEngine;

// Token: 0x02000B6C RID: 2924
public class TkInspectorSliderAttribute : PropertyAttribute
{
	// Token: 0x06004F5B RID: 20315 RVA: 0x00033C44 File Offset: 0x00031E44
	public TkInspectorSliderAttribute(float float_0, float float_1)
	{
		this.min = float_0;
		this.max = float_1;
	}

	// Token: 0x04003B62 RID: 15202
	public float min;

	// Token: 0x04003B63 RID: 15203
	public float max;
}
