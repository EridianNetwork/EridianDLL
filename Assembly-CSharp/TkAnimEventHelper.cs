using System;
using UnityEngine;

// Token: 0x02000B63 RID: 2915
public class TkAnimEventHelper : MonoBehaviour
{
	// Token: 0x06004EEE RID: 20206 RVA: 0x0000311B File Offset: 0x0000131B
	private void Awake()
	{
	}

	// Token: 0x06004EEF RID: 20207 RVA: 0x0014FB28 File Offset: 0x0014DD28
	public void OnTkAnimEvent(int eventId)
	{
		if (!base.enabled)
		{
			return;
		}
		if (this.events == null)
		{
			return;
		}
		if (eventId < 0 || eventId >= this.events.Length)
		{
			return;
		}
		TkAnimEvent tkAnimEvent = this.events[eventId];
		if (tkAnimEvent == null)
		{
			return;
		}
		this.method_0(tkAnimEvent, false);
	}

	// Token: 0x06004EF0 RID: 20208 RVA: 0x00033759 File Offset: 0x00031959
	public void method_0(TkAnimEvent tkAnimEvent_0, bool bool_0)
	{
		if (!base.enabled)
		{
			return;
		}
		if (this.preivewInTkAnimEventWindow != bool_0)
		{
			return;
		}
		TkAnimEventAction.smethod_0(tkAnimEvent_0.actionPath, base.gameObject, tkAnimEvent_0.locatorName, bool_0);
	}

	// Token: 0x04003B51 RID: 15185
	public TkAnimEvent[] events;

	// Token: 0x04003B52 RID: 15186
	[NonSerialized]
	public bool preivewInTkAnimEventWindow;
}
