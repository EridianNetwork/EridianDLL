using System;
using UnityEngine;

// Token: 0x02000115 RID: 277
public class TkRTPC_Parameter : ScriptableObject
{
	// Token: 0x06000639 RID: 1593 RVA: 0x00007414 File Offset: 0x00005614
	public bool method_0(float float_0)
	{
		return this.m_min <= float_0 && float_0 <= this.m_max;
	}

	// Token: 0x040005AB RID: 1451
	public float m_min;

	// Token: 0x040005AC RID: 1452
	public float m_max = 1f;

	// Token: 0x040005AD RID: 1453
	public float m_defaultValue;

	// Token: 0x040005AE RID: 1454
	public float m_previewValue;
}
