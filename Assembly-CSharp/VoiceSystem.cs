using System;
using System.Collections.Generic;
using Core;
using UnityEngine;

// Token: 0x020000FB RID: 251
[RequireComponent(typeof(BaseEventTriggerCtl))]
public class VoiceSystem : MonoBehaviour
{
	// Token: 0x060005DF RID: 1503 RVA: 0x000519AC File Offset: 0x0004FBAC
	private void Awake()
	{
		this.m_audioEventCtl = base.GetComponent<BaseEventTriggerCtl>();
		if (this.m_audioEventCtl == null)
		{
			DebugUtils.LogError(LogCategory.Audio, "AudioEventTriggerCtl missing on " + base.name);
		}
		this.m_voices = new Dictionary<string, byte>();
		for (int i = 0; i < this.m_voiceConfigs.Length; i++)
		{
			if (this.m_voices.ContainsKey(this.m_voiceConfigs[i].m_voice))
			{
				DebugUtils.LogError(LogCategory.Audio, "Duplicate Voice Configuration '" + this.m_voiceConfigs[i].m_voice + "'on VoiceSystem owned by: " + base.name);
			}
			else
			{
				this.m_voices.Add(this.m_voiceConfigs[i].m_voice, this.m_voiceConfigs[i].m_priority);
			}
		}
	}

	// Token: 0x060005E0 RID: 1504 RVA: 0x00051A70 File Offset: 0x0004FC70
	public void TryToSpeak(string eventName)
	{
		if (this.m_audioEventCtl == null)
		{
			DebugUtils.LogError(LogCategory.Audio, "AudioEventTriggerCtl missing on VoiceSystem owned by: " + base.name);
			return;
		}
		byte b;
		if (!this.m_voices.TryGetValue(eventName, out b))
		{
			DebugUtils.LogError(LogCategory.Audio, eventName + " missing on VoiceSystem on " + base.name);
			return;
		}
		if (this.m_currentVoice == string.Empty)
		{
			this.m_currentVoice = eventName;
			this.m_priority = b;
			this.m_audioEventCtl.TriggerEventByName(eventName);
			return;
		}
		EventTriggerData eventTriggerData = this.m_audioEventCtl.vmethod_0();
		BaseEventHandler baseEventHandler = null;
		if (eventTriggerData == null)
		{
			DebugUtils.LogError(LogCategory.Audio, "VoiceSystem AudioEventTriggerCtl does not define any EventTriggerData, on VoiceSystem owned by: " + base.name);
		}
		if (!eventTriggerData.Dictionary_0.TryGetValue(this.m_currentVoice, out baseEventHandler))
		{
			DebugUtils.LogError(LogCategory.Audio, "VoiceSystem event '" + eventName + "' is missing in AudioEventTriggerCtl configuration, on VoiceSystem owned by: " + base.name);
		}
		else
		{
			this.m_currentVoice = eventName;
			this.m_priority = b;
			this.m_audioEventCtl.TriggerEventByName(eventName);
		}
	}

	// Token: 0x04000577 RID: 1399
	public VoiceConfig[] m_voiceConfigs;

	// Token: 0x04000578 RID: 1400
	public string m_currentVoice;

	// Token: 0x04000579 RID: 1401
	public byte m_priority;

	// Token: 0x0400057A RID: 1402
	private BaseEventTriggerCtl m_audioEventCtl;

	// Token: 0x0400057B RID: 1403
	private Dictionary<string, byte> m_voices;
}
