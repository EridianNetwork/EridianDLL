using System;
using UnityEngine;

// Token: 0x02000B61 RID: 2913
public class TkAnimEventActionLimitHelper : MonoBehaviour
{
	// Token: 0x04003B4C RID: 15180
	public const int NO_VOICE = -1;

	// Token: 0x04003B4D RID: 15181
	[NonSerialized]
	public TkAnimEventAction.LimitRuntime runtime = new TkAnimEventAction.LimitRuntime();

	// Token: 0x04003B4E RID: 15182
	[NonSerialized]
	public int m_currentVoicePriority = -1;

	// Token: 0x04003B4F RID: 15183
	[NonSerialized]
	public TkAudioSource_PlaybackInstance m_currentVoiceInstance;
}
