using System;
using Core;
using UnityEngine;

// Token: 0x020000EB RID: 235
[AddComponentMenu("Audio/Audio Event Up Forwarder %#t")]
public class AudioEventUpForwarder : BaseEventTriggerCtl
{
	// Token: 0x060005A4 RID: 1444 RVA: 0x00006DF3 File Offset: 0x00004FF3
	private void Start()
	{
		this.method_1(true);
	}

	// Token: 0x060005A5 RID: 1445 RVA: 0x00006DFC File Offset: 0x00004FFC
	private void Update()
	{
		this.method_1(false);
	}

	// Token: 0x060005A6 RID: 1446 RVA: 0x00006E05 File Offset: 0x00005005
	public AudioEventTriggerCtl method_0()
	{
		return this.m_target;
	}

	// Token: 0x060005A7 RID: 1447 RVA: 0x000515BC File Offset: 0x0004F7BC
	private void method_1(bool bool_0)
	{
		if (bool_0 || null == this.m_target)
		{
			GameObject gameObject = base.gameObject;
			while (null != gameObject.transform.parent)
			{
				gameObject = gameObject.transform.parent.gameObject;
				AudioEventTriggerCtl component = gameObject.GetComponent<AudioEventTriggerCtl>();
				if (null != component)
				{
					DebugUtils.Log(LogCategory.Audio, "AudioEventUpForwarder @: " + Utils.smethod_16(base.gameObject) + " found target @: " + Utils.smethod_16(component.gameObject));
					this.m_target = component;
					break;
				}
			}
		}
	}

	// Token: 0x060005A8 RID: 1448 RVA: 0x00006E0D File Offset: 0x0000500D
	public override EventTriggerData vmethod_0()
	{
		return (!(null != this.method_0())) ? null : this.method_0().vmethod_0();
	}

	// Token: 0x060005A9 RID: 1449 RVA: 0x00006E2B File Offset: 0x0000502B
	public override void TriggerEventByName(string eventName)
	{
		if (null == this.m_target)
		{
			DebugUtils.LogWarning(LogCategory.Audio, "TriggerEventByName: AudioEventUpForwarder @: " + Utils.smethod_16(base.gameObject) + " has no target to respond to event: " + eventName);
		}
		else
		{
			this.m_target.TriggerEventByName(eventName);
		}
	}

	// Token: 0x060005AA RID: 1450 RVA: 0x00006E6A File Offset: 0x0000506A
	public override void ReleaseEventByName(string eventName)
	{
		if (null == this.m_target)
		{
			DebugUtils.LogWarning(LogCategory.Audio, "ReleaseEventByName: AudioEventUpForwarder @: " + Utils.smethod_16(base.gameObject) + " has no target to respond to event: " + eventName);
		}
		else
		{
			this.m_target.ReleaseEventByName(eventName);
		}
	}

	// Token: 0x04000509 RID: 1289
	private const bool FORCE_UPDATE_TARGET = false;

	// Token: 0x0400050A RID: 1290
	private AudioEventTriggerCtl m_target;
}
