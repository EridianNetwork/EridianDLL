using System;
using Core;
using UnityEngine;

// Token: 0x020000EF RID: 239
public abstract class BaseEventHandler
{
	// Token: 0x060005B1 RID: 1457 RVA: 0x00006ED0 File Offset: 0x000050D0
	public virtual void vmethod_0(GameObject gameObject_0)
	{
		DebugUtils.Log(LogCategory.Framework, "Event:" + this.m_eventName + " is triggered in base class on " + gameObject_0.name);
	}

	// Token: 0x060005B2 RID: 1458 RVA: 0x00006ED0 File Offset: 0x000050D0
	public virtual void vmethod_1(GameObject gameObject_0, EventTriggerType eventTriggerType_0 = EventTriggerType.None)
	{
		DebugUtils.Log(LogCategory.Framework, "Event:" + this.m_eventName + " is triggered in base class on " + gameObject_0.name);
	}

	// Token: 0x060005B3 RID: 1459 RVA: 0x00006EF3 File Offset: 0x000050F3
	public virtual void vmethod_2(GameObject gameObject_0)
	{
		DebugUtils.Log(LogCategory.Framework, "Event:" + this.m_eventName + " is released in base class on " + gameObject_0.name);
	}

	// Token: 0x060005B4 RID: 1460 RVA: 0x0000311D File Offset: 0x0000131D
	public virtual bool Update()
	{
		return false;
	}

	// Token: 0x060005B5 RID: 1461 RVA: 0x00006F16 File Offset: 0x00005116
	public bool method_0()
	{
		return this.m_definedInThisEntity;
	}

	// Token: 0x060005B6 RID: 1462 RVA: 0x00006F1E File Offset: 0x0000511E
	public void method_1(bool bool_0)
	{
		this.m_definedInThisEntity = bool_0;
	}

	// Token: 0x0400051E RID: 1310
	public string m_eventName = "new event";

	// Token: 0x0400051F RID: 1311
	public EventTriggerType m_type;

	// Token: 0x04000520 RID: 1312
	private bool m_definedInThisEntity = true;

	// Token: 0x04000521 RID: 1313
	protected bool m_resourceIsReady;
}
