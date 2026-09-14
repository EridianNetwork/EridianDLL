using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Core;
using ns0;
using UnityEngine;

// Token: 0x020000E6 RID: 230
[ExecuteInEditMode]
public class AudioEventHandler : BaseEventHandler
{
	// Token: 0x0600057E RID: 1406 RVA: 0x000506B0 File Offset: 0x0004E8B0
	public void OnDestroy()
	{
		foreach (SoundActionInfo soundActionInfo in this.m_soundList)
		{
			soundActionInfo.m_TkAudioSource = null;
		}
		this.m_soundList.Clear();
	}

	// Token: 0x0600057F RID: 1407 RVA: 0x00050710 File Offset: 0x0004E910
	public SoundActionInfo method_2()
	{
		SoundActionInfo soundActionInfo = new SoundActionInfo();
		this.m_soundList.Add(soundActionInfo);
		return soundActionInfo;
	}

	// Token: 0x06000580 RID: 1408 RVA: 0x00050730 File Offset: 0x0004E930
	public override void vmethod_0(GameObject gameObject_0)
	{
		if (ComponentMonoSingleton<AudioSystem>.Boolean_0 && ComponentMonoSingleton<AudioSystem>.Instance.Boolean_1)
		{
			foreach (SoundActionInfo soundActionInfo in this.m_soundList)
			{
				if (!soundActionInfo.m_TkAudioSource)
				{
					GameObject gameObject = ComponentMonoSingleton<AudioSystem>.Instance.AudioResourceManager_0.method_2(soundActionInfo.m_sAudioPrefabName);
					TkAudioSource tkAudioSource = ((!(null != gameObject)) ? null : gameObject.GetComponent<TkAudioSource>());
					if (tkAudioSource)
					{
						soundActionInfo.m_TkAudioSource = tkAudioSource;
						tkAudioSource.method_6(soundActionInfo);
					}
					else
					{
						DebugUtils.LogWarning(LogCategory.Audio, "Audio resource missing: " + soundActionInfo.m_sAudioPrefabName);
					}
				}
				if (soundActionInfo.m_TkAudioSource)
				{
					soundActionInfo.m_playInstance.RemoveAll(new Predicate<TkAudioSource_PlaybackInstance>(AudioEventHandler.smethod_0));
					soundActionInfo.m_playInstance.RemoveAll(new Predicate<TkAudioSource_PlaybackInstance>(AudioEventHandler.smethod_1));
					switch (soundActionInfo.m_eAction)
					{
					case AudioEventAction.Play:
					{
						TkAudioSource tkAudioSource2 = soundActionInfo.m_TkAudioSource.method_0(gameObject_0, null, false) as TkAudioSource;
						if (tkAudioSource2)
						{
							soundActionInfo.m_playInstance.Add(tkAudioSource2.m_playbackInstance);
							continue;
						}
						continue;
					}
					case AudioEventAction.Stop:
					{
						using (List<TkAudioSource_PlaybackInstance>.Enumerator enumerator2 = soundActionInfo.m_playInstance.GetEnumerator())
						{
							while (enumerator2.MoveNext())
							{
								TkAudioSource_PlaybackInstance tkAudioSource_PlaybackInstance = enumerator2.Current;
								if (tkAudioSource_PlaybackInstance)
								{
									tkAudioSource_PlaybackInstance.method_1(true);
								}
							}
							continue;
						}
						break;
					}
					case AudioEventAction.Pause:
						break;
					case AudioEventAction.Resume:
						goto IL_01DB;
					default:
						continue;
					}
					using (List<TkAudioSource_PlaybackInstance>.Enumerator enumerator3 = soundActionInfo.m_playInstance.GetEnumerator())
					{
						while (enumerator3.MoveNext())
						{
							TkAudioSource_PlaybackInstance tkAudioSource_PlaybackInstance2 = enumerator3.Current;
							if (tkAudioSource_PlaybackInstance2)
							{
								tkAudioSource_PlaybackInstance2.method_2();
							}
						}
						continue;
					}
					IL_01DB:
					foreach (TkAudioSource_PlaybackInstance tkAudioSource_PlaybackInstance3 in soundActionInfo.m_playInstance)
					{
						if (tkAudioSource_PlaybackInstance3)
						{
							tkAudioSource_PlaybackInstance3.method_3();
						}
					}
				}
			}
			return;
		}
	}

	// Token: 0x06000581 RID: 1409 RVA: 0x00006CB5 File Offset: 0x00004EB5
	public override void vmethod_1(GameObject gameObject_0, EventTriggerType eventTriggerType_0 = EventTriggerType.None)
	{
		if (this.m_type == eventTriggerType_0)
		{
			this.vmethod_0(gameObject_0);
		}
	}

	// Token: 0x06000582 RID: 1410 RVA: 0x000509D8 File Offset: 0x0004EBD8
	public override void vmethod_2(GameObject gameObject_0)
	{
		if (ComponentMonoSingleton<AudioSystem>.Boolean_0 && ComponentMonoSingleton<AudioSystem>.Instance.Boolean_1)
		{
			foreach (SoundActionInfo soundActionInfo in this.m_soundList)
			{
				if (soundActionInfo.m_TkAudioSource)
				{
					switch (soundActionInfo.m_eAction)
					{
					case AudioEventAction.Play:
					{
						using (List<TkAudioSource_PlaybackInstance>.Enumerator enumerator2 = soundActionInfo.m_playInstance.GetEnumerator())
						{
							while (enumerator2.MoveNext())
							{
								TkAudioSource_PlaybackInstance tkAudioSource_PlaybackInstance = enumerator2.Current;
								if (tkAudioSource_PlaybackInstance)
								{
									tkAudioSource_PlaybackInstance.method_1(true);
								}
							}
							continue;
						}
						break;
					}
					case AudioEventAction.Stop:
						continue;
					case AudioEventAction.Pause:
						break;
					default:
						continue;
					}
					foreach (TkAudioSource_PlaybackInstance tkAudioSource_PlaybackInstance2 in soundActionInfo.m_playInstance)
					{
						if (tkAudioSource_PlaybackInstance2)
						{
							tkAudioSource_PlaybackInstance2.method_3();
						}
					}
				}
			}
			return;
		}
	}

	// Token: 0x06000583 RID: 1411 RVA: 0x00006CC7 File Offset: 0x00004EC7
	[CompilerGenerated]
	private static bool smethod_0(TkAudioSource_PlaybackInstance tkAudioSource_PlaybackInstance_0)
	{
		return tkAudioSource_PlaybackInstance_0 == null;
	}

	// Token: 0x06000584 RID: 1412 RVA: 0x00006CD0 File Offset: 0x00004ED0
	[CompilerGenerated]
	private static bool smethod_1(TkAudioSource_PlaybackInstance tkAudioSource_PlaybackInstance_0)
	{
		return tkAudioSource_PlaybackInstance_0.m_audioSource.clip == null;
	}

	// Token: 0x040004EF RID: 1263
	public float m_distanceToTrigger = 100f;

	// Token: 0x040004F0 RID: 1264
	public List<SoundActionInfo> m_soundList = new List<SoundActionInfo>();
}
