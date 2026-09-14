using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020000E5 RID: 229
public class SoundActionInfo
{
	// Token: 0x0600057C RID: 1404 RVA: 0x00050648 File Offset: 0x0004E848
	public SoundActionInfo()
	{
		this.m_sAudioPrefabName = string.Empty;
		this.m_fInterval = 0f;
		this.m_fDelay = 0f;
		this.m_fDistanceToTrigger = 500f;
		this.m_fFadeTime = 0f;
		this.m_lastTriggerTime = 0f;
		this.m_eAction = AudioEventAction.Play;
	}

	// Token: 0x040004E3 RID: 1251
	public string m_sAudioPrefabName;

	// Token: 0x040004E4 RID: 1252
	[NonSerialized]
	public TkAudioSource m_TkAudioSource;

	// Token: 0x040004E5 RID: 1253
	[NonSerialized]
	public List<TkAudioSource_PlaybackInstance> m_playInstance = new List<TkAudioSource_PlaybackInstance>();

	// Token: 0x040004E6 RID: 1254
	[NonSerialized]
	public GameObject m_audioPrefabObject;

	// Token: 0x040004E7 RID: 1255
	public float m_fInterval;

	// Token: 0x040004E8 RID: 1256
	public float m_fDelay;

	// Token: 0x040004E9 RID: 1257
	public float m_fDistanceToTrigger;

	// Token: 0x040004EA RID: 1258
	public float m_fFadeTime;

	// Token: 0x040004EB RID: 1259
	public AudioEventAction m_eAction;

	// Token: 0x040004EC RID: 1260
	public float m_lastTriggerTime;

	// Token: 0x040004ED RID: 1261
	public bool m_isClassSpecific;

	// Token: 0x040004EE RID: 1262
	public bool m_isLocalPlayerOnly;
}
