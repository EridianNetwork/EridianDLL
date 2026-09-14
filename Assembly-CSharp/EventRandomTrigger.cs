using System;
using UnityEngine;

// Token: 0x020000F1 RID: 241
public class EventRandomTrigger
{
	// Token: 0x060005C5 RID: 1477 RVA: 0x00006FC6 File Offset: 0x000051C6
	public void Start()
	{
		this.method_1();
	}

	// Token: 0x060005C6 RID: 1478 RVA: 0x00051770 File Offset: 0x0004F970
	public bool method_0()
	{
		bool flag;
		if (flag = Time.time >= this.m_nextTime)
		{
			this.method_1();
		}
		return flag;
	}

	// Token: 0x060005C7 RID: 1479 RVA: 0x00006FCE File Offset: 0x000051CE
	private void method_1()
	{
		this.m_nextTime = Time.time + global::UnityEngine.Random.Range(this.m_rangeMin, this.m_rangeMax);
	}

	// Token: 0x060005C8 RID: 1480 RVA: 0x00006FED File Offset: 0x000051ED
	public void method_2(bool bool_0)
	{
		this.m_definedInThisEntity = bool_0;
	}

	// Token: 0x060005C9 RID: 1481 RVA: 0x00006FF6 File Offset: 0x000051F6
	public bool method_3()
	{
		return this.m_definedInThisEntity;
	}

	// Token: 0x04000522 RID: 1314
	public string m_eventName = "event name";

	// Token: 0x04000523 RID: 1315
	public float m_rangeMin;

	// Token: 0x04000524 RID: 1316
	public float m_rangeMax = 1f;

	// Token: 0x04000525 RID: 1317
	private bool m_definedInThisEntity = true;

	// Token: 0x04000526 RID: 1318
	private float m_nextTime;
}
