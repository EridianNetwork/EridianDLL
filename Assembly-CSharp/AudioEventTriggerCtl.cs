using System;
using System.Collections.Generic;
using Core;
using ns0;
using UnityEngine;

// Token: 0x020000E7 RID: 231
[AddComponentMenu("Audio/Audio Event Trigger Control %#t")]
[ExecuteInEditMode]
public class AudioEventTriggerCtl : BaseEventTriggerCtl
{
	// Token: 0x1700003A RID: 58
	// (get) Token: 0x06000586 RID: 1414 RVA: 0x00006CF6 File Offset: 0x00004EF6
	private AudioEventTriggerData AudioEventTriggerData_0
	{
		get
		{
			return this.m_data;
		}
	}

	// Token: 0x06000587 RID: 1415 RVA: 0x00006CF6 File Offset: 0x00004EF6
	public override EventTriggerData vmethod_0()
	{
		return this.m_data;
	}

	// Token: 0x1700003B RID: 59
	// (get) Token: 0x06000588 RID: 1416 RVA: 0x00006CFE File Offset: 0x00004EFE
	public string String_0
	{
		get
		{
			if (string.IsNullOrEmpty(this.m_dataFileName))
			{
				this.method_0();
			}
			return this.m_dataFileName;
		}
	}

	// Token: 0x06000589 RID: 1417 RVA: 0x00050B08 File Offset: 0x0004ED08
	public void method_0()
	{
		if (base.gameObject.name.Contains("("))
		{
			this.m_dataFileName = base.gameObject.name.Substring(0, base.gameObject.name.IndexOf("("));
		}
		else
		{
			this.m_dataFileName = base.gameObject.name;
		}
	}

	// Token: 0x0600058A RID: 1418 RVA: 0x00006D19 File Offset: 0x00004F19
	protected virtual void Awake()
	{
		this.method_0();
		this.AudioEventTriggerData_0.method_4(this.String_0, null);
		this.method_2(EventTriggerType.Awake);
	}

	// Token: 0x0600058B RID: 1419 RVA: 0x00050B6C File Offset: 0x0004ED6C
	private void Start()
	{
		this.method_2(EventTriggerType.Start);
		foreach (EventRandomTrigger eventRandomTrigger in this.AudioEventTriggerData_0.List_0)
		{
			eventRandomTrigger.Start();
		}
	}

	// Token: 0x0600058C RID: 1420 RVA: 0x00006D3B File Offset: 0x00004F3B
	private void OnEnable()
	{
		this.method_2(EventTriggerType.OnEnable);
	}

	// Token: 0x0600058D RID: 1421 RVA: 0x00006D44 File Offset: 0x00004F44
	private void OnCollisionEnter()
	{
		this.method_2(EventTriggerType.OnCollisionEnter);
	}

	// Token: 0x0600058E RID: 1422 RVA: 0x00006D4D File Offset: 0x00004F4D
	private void OnTriggerEnter()
	{
		this.method_2(EventTriggerType.OnTriggerEnter);
	}

	// Token: 0x0600058F RID: 1423 RVA: 0x00050BA8 File Offset: 0x0004EDA8
	private void Update()
	{
		if (ComponentMonoSingleton<AudioSystem>.Boolean_0 && ComponentMonoSingleton<AudioSystem>.Instance.Boolean_1)
		{
			for (int i = 0; i < this.AudioEventTriggerData_0.List_0.Count; i++)
			{
				EventRandomTrigger eventRandomTrigger = this.AudioEventTriggerData_0.List_0[i];
				if (eventRandomTrigger.method_0())
				{
					this.TriggerEventByName(eventRandomTrigger.m_eventName);
				}
			}
			return;
		}
	}

	// Token: 0x06000590 RID: 1424 RVA: 0x00050C0C File Offset: 0x0004EE0C
	private void OnDestroy()
	{
		foreach (KeyValuePair<string, BaseEventHandler> keyValuePair in this.AudioEventTriggerData_0.Dictionary_0)
		{
			AudioEventHandler audioEventHandler = keyValuePair.Value as AudioEventHandler;
			audioEventHandler.OnDestroy();
		}
		this.AudioEventTriggerData_0.Dictionary_0.Clear();
	}

	// Token: 0x06000591 RID: 1425 RVA: 0x00050C80 File Offset: 0x0004EE80
	public override void TriggerEventByName(string eventName)
	{
		if (!ComponentMonoSingleton<AudioSystem>.Boolean_0)
		{
			return;
		}
		if (this.m_data.Dictionary_0.ContainsKey(eventName))
		{
			this.m_data.Dictionary_0[eventName].vmethod_0(base.gameObject);
		}
		else
		{
			DebugUtils.LogWarning(LogCategory.Audio, "*****Event: " + eventName + " is missing on " + Utils.smethod_16(base.gameObject));
		}
	}

	// Token: 0x06000592 RID: 1426 RVA: 0x00050CE8 File Offset: 0x0004EEE8
	public override void ReleaseEventByName(string eventName)
	{
		if (!ComponentMonoSingleton<AudioSystem>.Boolean_0)
		{
			return;
		}
		if (this.m_data.Dictionary_0.ContainsKey(eventName))
		{
			this.m_data.Dictionary_0[eventName].vmethod_2(base.gameObject);
		}
		else
		{
			DebugUtils.LogWarning(LogCategory.Audio, "*****Event: " + eventName + " is missing on " + base.gameObject.name);
		}
	}

	// Token: 0x06000593 RID: 1427 RVA: 0x00006D56 File Offset: 0x00004F56
	public override void TriggerEventOnChildren(string eventName)
	{
		if (this.m_data.Dictionary_0.ContainsKey(eventName))
		{
			this.m_data.Dictionary_0[eventName].vmethod_0(base.gameObject);
		}
	}

	// Token: 0x06000594 RID: 1428 RVA: 0x00006D87 File Offset: 0x00004F87
	public bool method_1(string string_0)
	{
		return this.m_data.Dictionary_0.ContainsKey(string_0);
	}

	// Token: 0x06000595 RID: 1429 RVA: 0x00050D50 File Offset: 0x0004EF50
	private void method_2(EventTriggerType eventTriggerType_0)
	{
		foreach (KeyValuePair<string, BaseEventHandler> keyValuePair in this.AudioEventTriggerData_0.Dictionary_0)
		{
			BaseEventHandler value = keyValuePair.Value;
			value.vmethod_1(base.gameObject, eventTriggerType_0);
		}
	}

	// Token: 0x040004F3 RID: 1267
	private string m_dataFileName;

	// Token: 0x040004F4 RID: 1268
	protected AudioEventTriggerData m_data = new AudioEventTriggerData();
}
