using System;
using Core;
using UnityEngine;

// Token: 0x020000F0 RID: 240
[ExecuteInEditMode]
public abstract class BaseEventTriggerCtl : MonoBehaviour
{
	// Token: 0x060005B8 RID: 1464
	public abstract EventTriggerData vmethod_0();

	// Token: 0x060005B9 RID: 1465 RVA: 0x00006F27 File Offset: 0x00005127
	public virtual void vmethod_1(AudioEventName audioEventName_0)
	{
		this.TriggerEventByName(AudioEvents.smethod_0(audioEventName_0));
	}

	// Token: 0x060005BA RID: 1466 RVA: 0x00006F35 File Offset: 0x00005135
	public virtual void vmethod_2(AudioEventName audioEventName_0)
	{
		this.ReleaseEventByName(AudioEvents.smethod_0(audioEventName_0));
	}

	// Token: 0x060005BB RID: 1467 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void TriggerEventByName(string eventName)
	{
	}

	// Token: 0x060005BC RID: 1468 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void ReleaseEventByName(string eventName)
	{
	}

	// Token: 0x060005BD RID: 1469 RVA: 0x00006F43 File Offset: 0x00005143
	protected virtual void TriggerAudioEventMecanim(string eventName)
	{
		this.TriggerEventByName(eventName);
	}

	// Token: 0x060005BE RID: 1470 RVA: 0x00006F4C File Offset: 0x0000514C
	public virtual void ReleaseAudioEventMecanim(string eventName)
	{
		this.ReleaseEventByName(eventName);
	}

	// Token: 0x060005BF RID: 1471 RVA: 0x00006F55 File Offset: 0x00005155
	protected virtual void TriggerNPCLogicEventMecanim(string eventName)
	{
		DebugUtils.LogError(LogCategory.Audio, "TriggerNPCLogicEventMecanim with param " + eventName);
	}

	// Token: 0x060005C0 RID: 1472 RVA: 0x00006F68 File Offset: 0x00005168
	protected virtual void ReleaseNPCLogicEventMecanim(string eventName)
	{
		DebugUtils.LogError(LogCategory.Audio, "ReleaseNPCLogicEventMecanim with param " + eventName);
	}

	// Token: 0x060005C1 RID: 1473 RVA: 0x00006F7B File Offset: 0x0000517B
	protected virtual void TriggerNPCVFXEventMechanim(string eventName)
	{
		DebugUtils.LogError(LogCategory.Audio, "TriggerNPCVFXEventMechanim with param " + eventName);
	}

	// Token: 0x060005C2 RID: 1474 RVA: 0x00006F8E File Offset: 0x0000518E
	protected virtual void ReleaseNPCVFXEventMechanim(string eventName)
	{
		DebugUtils.LogError(LogCategory.Audio, "ReleaseNPCVFXEventMechanim with param " + eventName);
	}

	// Token: 0x060005C3 RID: 1475 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void TriggerEventOnChildren(string eventName)
	{
	}
}
