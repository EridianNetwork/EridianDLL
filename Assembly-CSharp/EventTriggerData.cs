using System;
using System.Collections.Generic;
using Core;

// Token: 0x020000F2 RID: 242
public class EventTriggerData
{
	// Token: 0x060005CB RID: 1483 RVA: 0x00051798 File Offset: 0x0004F998
	public void method_0(string string_0, BaseEventHandler baseEventHandler_0, bool bool_0)
	{
		if (this.Dictionary_0.ContainsKey(string_0))
		{
			if (!bool_0)
			{
				DebugUtils.LogWarning(LogCategory.Audio, "AddEventTriggerByEvent: overwrote existing event: " + string_0);
			}
			else
			{
				this.Dictionary_0[string_0] = baseEventHandler_0;
			}
		}
		else
		{
			this.Dictionary_0.Add(string_0, baseEventHandler_0);
		}
	}

	// Token: 0x1700003E RID: 62
	// (get) Token: 0x060005CC RID: 1484 RVA: 0x0000701C File Offset: 0x0000521C
	public Dictionary<string, BaseEventHandler> Dictionary_0
	{
		get
		{
			return this.m_eventHandlers;
		}
	}

	// Token: 0x1700003F RID: 63
	// (get) Token: 0x060005CD RID: 1485 RVA: 0x00007024 File Offset: 0x00005224
	public List<EventRandomTrigger> List_0
	{
		get
		{
			return this.m_randomTriggers;
		}
	}

	// Token: 0x060005CE RID: 1486 RVA: 0x0000702C File Offset: 0x0000522C
	public void method_1()
	{
		this.m_eventHandlers.Clear();
		this.m_randomTriggers.Clear();
		this.m_moduleFileNames = null;
	}

	// Token: 0x060005CF RID: 1487 RVA: 0x0000704B File Offset: 0x0000524B
	public bool method_2()
	{
		return this.m_moduleFileNames != null && this.m_moduleFileNames.Length > 0;
	}

	// Token: 0x04000527 RID: 1319
	protected string m_fileName;

	// Token: 0x04000528 RID: 1320
	public string[] m_moduleFileNames;

	// Token: 0x04000529 RID: 1321
	protected string m_triggerKind;

	// Token: 0x0400052A RID: 1322
	protected Dictionary<string, BaseEventHandler> m_eventHandlers = new Dictionary<string, BaseEventHandler>();

	// Token: 0x0400052B RID: 1323
	protected List<EventRandomTrigger> m_randomTriggers = new List<EventRandomTrigger>();
}
