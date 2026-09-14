using System;
using System.Collections.Generic;
using Core;
using ns0;
using UnityEngine;

// Token: 0x02000128 RID: 296
[ExecuteInEditMode]
public class AudioPoolManager
{
	// Token: 0x060006BC RID: 1724 RVA: 0x000078C6 File Offset: 0x00005AC6
	public void method_0()
	{
		this.method_2();
	}

	// Token: 0x060006BD RID: 1725 RVA: 0x000078CE File Offset: 0x00005ACE
	public void method_1()
	{
		this.method_10();
		this.method_12();
	}

	// Token: 0x060006BE RID: 1726 RVA: 0x00054A18 File Offset: 0x00052C18
	private void method_2()
	{
		DebugUtils.Log(LogCategory.Audio, "Creating audio pools container");
		this.m_prefabPoolsContainerGO = new GameObject();
		this.m_prefabPoolsContainerGO.name = "AudioPrefabPools";
		this.m_prefabPoolsContainerGO.hideFlags = HideFlags.DontSave;
		global::UnityEngine.Object.DontDestroyOnLoad(this.m_prefabPoolsContainerGO);
		if (MonoSingleton<AudioManager>.Boolean_0)
		{
			Utils.smethod_20(this.m_prefabPoolsContainerGO, MonoSingleton<AudioManager>.Instance.gameObject);
		}
		DebugUtils.Log(LogCategory.Audio, "Creating audio playback instance container");
		this.m_playbackInsPoolsContainerGO = new GameObject();
		this.m_playbackInsPoolsContainerGO.name = "AudioPlaybackPools";
		this.m_playbackInsPoolsContainerGO.hideFlags = HideFlags.DontSave;
		global::UnityEngine.Object.DontDestroyOnLoad(this.m_playbackInsPoolsContainerGO);
		if (MonoSingleton<AudioManager>.Boolean_0)
		{
			Utils.smethod_20(this.m_playbackInsPoolsContainerGO, MonoSingleton<AudioManager>.Instance.gameObject);
		}
	}

	// Token: 0x060006BF RID: 1727 RVA: 0x00054AD8 File Offset: 0x00052CD8
	public GameObject method_3(string string_0, GameObject gameObject_0)
	{
		if (!string.IsNullOrEmpty(string_0))
		{
		}
		PrefabPool prefabPool = this.method_13(string_0, true);
		if (prefabPool == null)
		{
			return null;
		}
		GameObject gameObject = prefabPool.method_2(gameObject_0);
		gameObject.SetActive(true);
		return gameObject;
	}

	// Token: 0x060006C0 RID: 1728 RVA: 0x00054B0C File Offset: 0x00052D0C
	public void method_4(GameObject gameObject_0)
	{
		PrefabPool prefabPool = this.method_13(gameObject_0.name, false);
		if (prefabPool == null)
		{
			DebugUtils.Log(LogCategory.Audio, "Unexpected null pool for: " + gameObject_0.name);
			Tk.smethod_50(gameObject_0);
		}
		else
		{
			this.method_5(gameObject_0);
			gameObject_0.SetActive(false);
			prefabPool.method_4(gameObject_0, true);
		}
	}

	// Token: 0x060006C1 RID: 1729 RVA: 0x00054B60 File Offset: 0x00052D60
	private void method_5(GameObject gameObject_0)
	{
		TkAudioSource tkAudioSource = Tk.smethod_48<TkAudioSource>(gameObject_0);
		if (null != ((TkAudioSource)tkAudioSource.prefab).m_characterVoiceLimit)
		{
			TkAnimEventActionLimitHelper component = tkAudioSource.host.GetComponent<TkAnimEventActionLimitHelper>();
			if (component != null)
			{
				component.m_currentVoiceInstance = null;
			}
		}
		gameObject_0.name = null;
		gameObject_0.transform.parent = null;
		tkAudioSource.prefab = null;
		tkAudioSource.host = null;
		tkAudioSource.locatorName = null;
		tkAudioSource.m_objName = string.Empty;
	}

	// Token: 0x060006C2 RID: 1730 RVA: 0x00054BDC File Offset: 0x00052DDC
	public GameObject method_6(GameObject gameObject_0, GameObject gameObject_1)
	{
		if (!(gameObject_0 == null))
		{
		}
		PrefabPool prefabPool = this.method_14(gameObject_0, true);
		return prefabPool.method_2(gameObject_1);
	}

	// Token: 0x060006C3 RID: 1731 RVA: 0x00054C04 File Offset: 0x00052E04
	public void method_7(TkAudioSource_PlaybackInstance tkAudioSource_PlaybackInstance_0)
	{
		PrefabPool prefabPool = this.method_15(tkAudioSource_PlaybackInstance_0.m_templateName);
		if (prefabPool == null)
		{
			DebugUtils.Log(LogCategory.Audio, "Unexpected null pool for: " + tkAudioSource_PlaybackInstance_0.gameObject.name);
			Tk.smethod_50(tkAudioSource_PlaybackInstance_0.gameObject);
		}
		else
		{
			this.method_8(tkAudioSource_PlaybackInstance_0);
			prefabPool.method_4(tkAudioSource_PlaybackInstance_0.gameObject, true);
		}
	}

	// Token: 0x060006C4 RID: 1732 RVA: 0x00054C60 File Offset: 0x00052E60
	private void method_8(TkAudioSource_PlaybackInstance tkAudioSource_PlaybackInstance_0)
	{
		tkAudioSource_PlaybackInstance_0.m_templateName = string.Empty;
		tkAudioSource_PlaybackInstance_0.m_src = null;
		tkAudioSource_PlaybackInstance_0.m_actionPrefab = null;
		tkAudioSource_PlaybackInstance_0.m_host = null;
		tkAudioSource_PlaybackInstance_0.m_audioSource.clip = null;
		tkAudioSource_PlaybackInstance_0.gameObject.name = string.Empty;
		tkAudioSource_PlaybackInstance_0.m_stopping = -1f;
		tkAudioSource_PlaybackInstance_0.m_randomPitch = 1f;
		tkAudioSource_PlaybackInstance_0.m_randomPan = 0f;
		tkAudioSource_PlaybackInstance_0.m_randomVolume = 1f;
		tkAudioSource_PlaybackInstance_0.m_sourceVolume = 1f;
		tkAudioSource_PlaybackInstance_0.m_sourcePitch = 1f;
		tkAudioSource_PlaybackInstance_0.m_sourcePan = 0f;
		tkAudioSource_PlaybackInstance_0.m_programCtrlVolume = 1f;
		tkAudioSource_PlaybackInstance_0.m_programCtrlPitch = 1f;
		tkAudioSource_PlaybackInstance_0.m_programCtrlPan = 0f;
		tkAudioSource_PlaybackInstance_0.m_startDelay = 0f;
		tkAudioSource_PlaybackInstance_0.m_previewInEditor = false;
		tkAudioSource_PlaybackInstance_0.m_objName = string.Empty;
	}

	// Token: 0x060006C5 RID: 1733 RVA: 0x00054D34 File Offset: 0x00052F34
	private PrefabPool method_9(string string_0)
	{
		GameObject gameObject = ComponentMonoSingleton<AudioSystem>.Instance.AudioResourceManager_0.method_2(string_0);
		if (gameObject == null)
		{
			DebugUtils.LogError(LogCategory.Audio, "Can't obtain AudioSystem.Instance.ResourceMgr.GetResource: " + string_0);
			return null;
		}
		gameObject.name = string_0;
		PrefabPool prefabPool = new PrefabPool(gameObject, this.m_prefabPoolsContainerGO);
		this.m_audioPrefabPools.Add(string_0, prefabPool);
		return prefabPool;
	}

	// Token: 0x060006C6 RID: 1734 RVA: 0x00054D90 File Offset: 0x00052F90
	private void method_10()
	{
		foreach (KeyValuePair<string, PrefabPool> keyValuePair in this.m_audioPrefabPools)
		{
			keyValuePair.Value.Reset();
		}
		this.m_audioPrefabPools.Clear();
	}

	// Token: 0x060006C7 RID: 1735 RVA: 0x00054DD4 File Offset: 0x00052FD4
	private PrefabPool method_11(GameObject gameObject_0)
	{
		PrefabPool prefabPool = new PrefabPool(gameObject_0, this.m_playbackInsPoolsContainerGO);
		this.m_audioPlaybackInsPools.Add(gameObject_0.name, prefabPool);
		return prefabPool;
	}

	// Token: 0x060006C8 RID: 1736 RVA: 0x00054E04 File Offset: 0x00053004
	private void method_12()
	{
		foreach (KeyValuePair<string, PrefabPool> keyValuePair in this.m_audioPlaybackInsPools)
		{
			keyValuePair.Value.Reset();
		}
		this.m_audioPlaybackInsPools.Clear();
	}

	// Token: 0x060006C9 RID: 1737 RVA: 0x00054E48 File Offset: 0x00053048
	private PrefabPool method_13(string string_0, bool bool_0)
	{
		if (!string.IsNullOrEmpty(string_0))
		{
		}
		PrefabPool prefabPool = null;
		if (!this.m_audioPrefabPools.TryGetValue(string_0, out prefabPool) && bool_0)
		{
			prefabPool = this.method_9(string_0);
		}
		return prefabPool;
	}

	// Token: 0x060006CA RID: 1738 RVA: 0x00054E7C File Offset: 0x0005307C
	private PrefabPool method_14(GameObject gameObject_0, bool bool_0)
	{
		PrefabPool prefabPool = null;
		if (!this.m_audioPlaybackInsPools.TryGetValue(gameObject_0.name, out prefabPool) && bool_0)
		{
			prefabPool = this.method_11(gameObject_0);
		}
		return prefabPool;
	}

	// Token: 0x060006CB RID: 1739 RVA: 0x00054EAC File Offset: 0x000530AC
	private PrefabPool method_15(string string_0)
	{
		PrefabPool prefabPool = null;
		if (!string.IsNullOrEmpty(string_0))
		{
			this.m_audioPlaybackInsPools.TryGetValue(string_0, out prefabPool);
		}
		return prefabPool;
	}

	// Token: 0x04000627 RID: 1575
	private const string PREFAB_POOLS_NAME = "AudioPrefabPools";

	// Token: 0x04000628 RID: 1576
	private const string PLAYBACK_POOLS_NAME = "AudioPlaybackPools";

	// Token: 0x04000629 RID: 1577
	private GameObject m_prefabPoolsContainerGO;

	// Token: 0x0400062A RID: 1578
	private GameObject m_playbackInsPoolsContainerGO;

	// Token: 0x0400062B RID: 1579
	private Dictionary<string, PrefabPool> m_audioPrefabPools = new Dictionary<string, PrefabPool>();

	// Token: 0x0400062C RID: 1580
	private Dictionary<string, PrefabPool> m_audioPlaybackInsPools = new Dictionary<string, PrefabPool>();
}
