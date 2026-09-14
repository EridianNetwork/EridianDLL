using System;
using Core;
using UnityEngine;

// Token: 0x020000EC RID: 236
[AddComponentMenu("Event/Auto Trigger")]
public class AutoEventTrigger : MonoBehaviour
{
	// Token: 0x060005AC RID: 1452 RVA: 0x00051650 File Offset: 0x0004F850
	private void Awake()
	{
		this.m_eventTriggerCtl = base.transform.parent.GetComponent<BaseEventTriggerCtl>();
		if (this.m_eventTriggerCtl == null)
		{
			DebugUtils.LogWarning(LogCategory.Framework, "*****EventTriggerCtl Missing! on " + base.gameObject.name);
		}
	}

	// Token: 0x060005AD RID: 1453 RVA: 0x0005169C File Offset: 0x0004F89C
	private void OnTriggerEnter(Collider other)
	{
		if (this.m_eventTriggerCtl == null)
		{
			DebugUtils.LogWarning(LogCategory.Framework, "*****EventTriggerCtl Missing! on " + base.gameObject.name);
			return;
		}
		if (!this.method_0(other.gameObject))
		{
			return;
		}
		if (this.m_type == EventAutoTriggerType.OnEnter || this.m_type == EventAutoTriggerType.OnEnterAndOnExit)
		{
			this.m_eventTriggerCtl.TriggerEventByName(this.m_onEnterEvent);
		}
	}

	// Token: 0x060005AE RID: 1454 RVA: 0x00051704 File Offset: 0x0004F904
	private void OnTriggerExit(Collider other)
	{
		if (this.m_eventTriggerCtl == null)
		{
			DebugUtils.LogWarning(LogCategory.Framework, "*****EventTriggerCtl Missing! on " + base.gameObject.name);
			return;
		}
		if (!this.method_0(other.gameObject))
		{
			return;
		}
		if (this.m_type == EventAutoTriggerType.OnExit || this.m_type == EventAutoTriggerType.OnEnterAndOnExit)
		{
			this.m_eventTriggerCtl.TriggerEventByName(this.m_onExitEvent);
		}
	}

	// Token: 0x060005AF RID: 1455 RVA: 0x00006EA9 File Offset: 0x000050A9
	private bool method_0(GameObject gameObject_0)
	{
		return gameObject_0.GetComponent<EntityPlayer>().vmethod_26();
	}

	// Token: 0x0400050B RID: 1291
	public EventAutoTriggerType m_type;

	// Token: 0x0400050C RID: 1292
	public string m_onEnterEvent;

	// Token: 0x0400050D RID: 1293
	public string m_onExitEvent;

	// Token: 0x0400050E RID: 1294
	private BaseEventTriggerCtl m_eventTriggerCtl;
}
