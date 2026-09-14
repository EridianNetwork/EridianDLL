using System;
using Core;
using ns0;
using UnityEngine;

// Token: 0x02000121 RID: 289
[AddComponentMenu("TkAudio/Source")]
public class TkAudioSource : TkAnimEventAction
{
	// Token: 0x0600066D RID: 1645 RVA: 0x00053644 File Offset: 0x00051844
	public int method_2()
	{
		if (this.m_bus != 0)
		{
			return this.m_bus;
		}
		TkAudioSource tkAudioSource = this.method_9();
		if (tkAudioSource)
		{
			return tkAudioSource.method_2();
		}
		return 0;
	}

	// Token: 0x0600066E RID: 1646 RVA: 0x00053678 File Offset: 0x00051878
	public AudioSource method_3()
	{
		if (this.audioTemplate)
		{
			return this.audioTemplate;
		}
		TkAudioSource tkAudioSource = this.method_9();
		if (tkAudioSource)
		{
			return tkAudioSource.method_3();
		}
		return null;
	}

	// Token: 0x17000045 RID: 69
	// (get) Token: 0x0600066F RID: 1647 RVA: 0x0000759C File Offset: 0x0000579C
	public float Single_0
	{
		get
		{
			return this.m_delay + ((!this.m_delayRandom) ? 0f : global::UnityEngine.Random.Range(-this.m_delayRandomRange, this.m_delayRandomRange));
		}
	}

	// Token: 0x17000046 RID: 70
	// (get) Token: 0x06000670 RID: 1648 RVA: 0x000075C6 File Offset: 0x000057C6
	public bool Boolean_0
	{
		get
		{
			return this.m_playbackInstance != null;
		}
	}

	// Token: 0x06000671 RID: 1649 RVA: 0x000075D4 File Offset: 0x000057D4
	private void method_4()
	{
		if (null == this.m_characterVoiceLimit)
		{
			this.m_characterVoiceLimit = this.method_5();
		}
	}

	// Token: 0x06000672 RID: 1650 RVA: 0x000536B0 File Offset: 0x000518B0
	private CharacterVoice method_5()
	{
		CharacterVoice characterVoice = null;
		TkAudioSource tkAudioSource = this;
		while (tkAudioSource != null)
		{
			characterVoice = tkAudioSource.gameObject.GetComponent<CharacterVoice>();
			if (null != characterVoice)
			{
				break;
			}
			tkAudioSource = this.method_9();
		}
		return characterVoice;
	}

	// Token: 0x06000673 RID: 1651 RVA: 0x000075F0 File Offset: 0x000057F0
	public void method_6(SoundActionInfo soundActionInfo_0)
	{
		this.m_audioEventInfo = soundActionInfo_0;
		if (this.m_audioEventInfo != null && this.m_audioEventInfo.m_fInterval > this.perObjectLimit.minInterval)
		{
			this.perObjectLimit.minInterval = this.m_audioEventInfo.m_fInterval;
		}
	}

	// Token: 0x06000674 RID: 1652 RVA: 0x000536EC File Offset: 0x000518EC
	public string method_7()
	{
		TkAudioSource tkAudioSource = this.method_9();
		if (tkAudioSource)
		{
			return tkAudioSource.method_7() + "/" + base.name;
		}
		return base.name;
	}

	// Token: 0x06000675 RID: 1653 RVA: 0x0000762F File Offset: 0x0000582F
	private void method_8()
	{
		if (!this.m_parentInitialized && base.transform.parent)
		{
			this.m_parentInitialized = true;
			this.m_parent = base.transform.parent.GetComponent<TkAudioSource>();
		}
	}

	// Token: 0x06000676 RID: 1654 RVA: 0x00007668 File Offset: 0x00005868
	public TkAudioSource method_9()
	{
		this.method_8();
		return this.m_parent;
	}

	// Token: 0x06000677 RID: 1655 RVA: 0x00053728 File Offset: 0x00051928
	public override void OnCreate(TkAnimEventAction template)
	{
		TkAudioSource tkAudioSource = template as TkAudioSource;
		if (null == tkAudioSource)
		{
			DebugUtils.LogWarning(LogCategory.Audio, "Template is null or has the wrong class for TkAudioSource: " + this.method_7() + " - " + ((!(null != template)) ? "null" : template.GetType().Name));
		}
		else
		{
			this.method_6(tkAudioSource.m_audioEventInfo);
		}
	}

	// Token: 0x06000678 RID: 1656 RVA: 0x0005378C File Offset: 0x0005198C
	public override bool OnPreTrigger(GameObject host, double currentTime)
	{
		if (this.m_audioEventInfo != null && host != null)
		{
			AudioListener audioListener_ = TkAudioSystem.AudioListener_0;
			if (audioListener_ != null)
			{
				float num = Vector3.Distance(audioListener_.transform.position, host.transform.position);
				if (num > this.m_audioEventInfo.m_fDistanceToTrigger)
				{
					return false;
				}
			}
		}
		this.method_4();
		if (!(null != this.m_characterVoiceLimit))
		{
			return true;
		}
		TkAnimEventActionLimitHelper tkAnimEventActionLimitHelper = Tk.smethod_48<TkAnimEventActionLimitHelper>(host);
		if (tkAnimEventActionLimitHelper.m_currentVoiceInstance == null || !tkAnimEventActionLimitHelper.m_currentVoiceInstance.m_audioSource.isPlaying)
		{
			return true;
		}
		if (tkAnimEventActionLimitHelper.m_currentVoicePriority <= this.m_characterVoiceLimit.m_priority)
		{
			return false;
		}
		tkAnimEventActionLimitHelper.m_currentVoiceInstance.method_1(false);
		return true;
	}

	// Token: 0x06000679 RID: 1657 RVA: 0x00053848 File Offset: 0x00051A48
	public override void OnPostTrigger(GameObject host, GameObject obj)
	{
		if (this.m_characterVoiceLimit != null)
		{
			TkAnimEventActionLimitHelper tkAnimEventActionLimitHelper = Tk.smethod_48<TkAnimEventActionLimitHelper>(host);
			tkAnimEventActionLimitHelper.m_currentVoicePriority = this.m_characterVoiceLimit.m_priority;
			tkAnimEventActionLimitHelper.m_currentVoiceInstance = obj.GetComponent<TkAudioSource>().m_playbackInstance;
		}
	}

	// Token: 0x0600067A RID: 1658 RVA: 0x00007676 File Offset: 0x00005876
	public override bool OnAnimEvent()
	{
		if (this.previewInEditor)
		{
			return this.method_10(1f);
		}
		return this.method_11(1f);
	}

	// Token: 0x0600067B RID: 1659 RVA: 0x000076A1 File Offset: 0x000058A1
	public TkAudioSource_PlaybackInstance method_10(float float_0 = 1f)
	{
		return this.method_12(float_0, true);
	}

	// Token: 0x0600067C RID: 1660 RVA: 0x000076AB File Offset: 0x000058AB
	public TkAudioSource_PlaybackInstance method_11(float float_0 = 1f)
	{
		return this.method_12(float_0, false);
	}

	// Token: 0x0600067D RID: 1661 RVA: 0x0005388C File Offset: 0x00051A8C
	private TkAudioSource_PlaybackInstance method_12(float float_0, bool bool_0)
	{
		TkAudioSource_PlaybackInstance tkAudioSource_PlaybackInstance = null;
		TkIAudioClip component = base.GetComponent<TkIAudioClip>();
		if (!component)
		{
			DebugUtils.LogWarning(LogCategory.Audio, "TkIAudioClip Component is missing in" + this.method_7());
		}
		else
		{
			TkAudioSingleClip tkAudioSingleClip = component.vmethod_0(bool_0);
			if (!tkAudioSingleClip)
			{
				DebugUtils.LogWarning(LogCategory.Audio, "TkAudioRandomClip PlayNothing or TkAudioSwitchClip Unsolved swtich case : " + this.method_7());
			}
			else
			{
				TkAudioSource component2 = tkAudioSingleClip.GetComponent<TkAudioSource>();
				if (!component2)
				{
					DebugUtils.LogWarning(LogCategory.Audio, "TkAudioSource is missing in " + tkAudioSingleClip.name);
				}
				else
				{
					component2.m_audioEventInfo = this.m_audioEventInfo;
					tkAudioSource_PlaybackInstance = component2.method_13(this.host, float_0, (!bool_0) ? this.prefab : this, bool_0);
				}
			}
		}
		return tkAudioSource_PlaybackInstance;
	}

	// Token: 0x0600067E RID: 1662 RVA: 0x0005393C File Offset: 0x00051B3C
	private TkAudioSource_PlaybackInstance method_13(GameObject gameObject_0, float float_0, TkAnimEventAction tkAnimEventAction_0, bool bool_0 = false)
	{
		TkAudioSource_PlaybackInstance tkAudioSource_PlaybackInstance = this.method_14(gameObject_0, tkAnimEventAction_0, bool_0);
		if (!this.method_15(tkAudioSource_PlaybackInstance))
		{
			ComponentMonoSingleton<AudioSystem>.Instance.AudioResourceManager_0.m_poolManager.method_7(tkAudioSource_PlaybackInstance);
			DebugUtils.LogWarning(LogCategory.Audio, "TryAddToBus failed : " + this.method_7());
			tkAudioSource_PlaybackInstance = null;
		}
		else
		{
			this.method_16(tkAudioSource_PlaybackInstance, float_0);
			TkAudioSystem.smethod_0(" Play [" + Utils.smethod_16(base.gameObject) + "] -> " + Tk.smethod_28(tkAudioSource_PlaybackInstance));
			tkAudioSource_PlaybackInstance.method_0();
		}
		return tkAudioSource_PlaybackInstance;
	}

	// Token: 0x0600067F RID: 1663 RVA: 0x000539C0 File Offset: 0x00051BC0
	private TkAudioSource_PlaybackInstance method_14(GameObject gameObject_0, TkAnimEventAction tkAnimEventAction_0, bool bool_0)
	{
		AudioSource audioSource = this.method_3();
		GameObject gameObject;
		TkAudioSource_PlaybackInstance tkAudioSource_PlaybackInstance;
		if (!audioSource)
		{
			DebugUtils.LogWarning(LogCategory.Audio, "No Audio Template is assigned to " + this.method_7());
			gameObject = new GameObject();
			tkAudioSource_PlaybackInstance = gameObject.AddComponent<TkAudioSource_PlaybackInstance>();
		}
		else
		{
			if (bool_0)
			{
				gameObject = global::UnityEngine.Object.Instantiate(audioSource.gameObject) as GameObject;
				gameObject.AddComponent<AudioListener>();
			}
			else
			{
				gameObject = ComponentMonoSingleton<AudioSystem>.Instance.AudioResourceManager_0.m_poolManager.method_6(audioSource.gameObject, gameObject_0);
			}
			tkAudioSource_PlaybackInstance = gameObject.GetComponent<TkAudioSource_PlaybackInstance>();
			if (tkAudioSource_PlaybackInstance == null)
			{
				DebugUtils.LogWarning(LogCategory.Audio, "PlaybackInstance is missing in Audio Template" + audioSource.name);
				tkAudioSource_PlaybackInstance = gameObject.AddComponent<TkAudioSource_PlaybackInstance>();
			}
			tkAudioSource_PlaybackInstance.m_templateName = audioSource.gameObject.name;
			tkAudioSource_PlaybackInstance.m_previewInEditor = bool_0;
			if (!tkAudioSource_PlaybackInstance.m_audioSource)
			{
				DebugUtils.LogWarning(LogCategory.Audio, "AudioSource is missing in Audio Template " + audioSource.name);
			}
		}
		gameObject.name = this.method_7();
		if (!tkAudioSource_PlaybackInstance.m_audioSource)
		{
			DebugUtils.LogWarning(LogCategory.Audio, this.method_7() + " has no audio source");
			tkAudioSource_PlaybackInstance.m_audioSource = gameObject.AddComponent<AudioSource>();
		}
		tkAudioSource_PlaybackInstance.m_src = this;
		tkAudioSource_PlaybackInstance.m_actionPrefab = tkAnimEventAction_0;
		tkAudioSource_PlaybackInstance.m_destroyAction = this.m_destroyAction;
		if (gameObject_0)
		{
			tkAudioSource_PlaybackInstance.m_hasHost = true;
			tkAudioSource_PlaybackInstance.m_host = gameObject_0;
		}
		else
		{
			tkAudioSource_PlaybackInstance.m_hasHost = false;
		}
		TkAudioSingleClip component = base.GetComponent<TkAudioSingleClip>();
		if (!component)
		{
			DebugUtils.LogWarning(LogCategory.Audio, "Cannot find TkAudioSingleClip in " + this.method_7());
		}
		else
		{
			tkAudioSource_PlaybackInstance.m_audioSource.clip = component.clip;
		}
		return tkAudioSource_PlaybackInstance;
	}

	// Token: 0x06000680 RID: 1664 RVA: 0x00053B54 File Offset: 0x00051D54
	private bool method_15(TkAudioSource_PlaybackInstance tkAudioSource_PlaybackInstance_0)
	{
		bool flag = false;
		int num = this.method_2();
		if (num == 0)
		{
			DebugUtils.LogWarning(LogCategory.Audio, "No Audio Bus is assigned to " + this.method_7());
		}
		else
		{
			TkAudioBus tkAudioBus = TkAudioBus.smethod_0(num);
			if (!tkAudioBus)
			{
				DebugUtils.LogWarning(LogCategory.Audio, "Cannot find TkAudioBus for " + this.method_7());
			}
			else
			{
				tkAudioSource_PlaybackInstance_0.m_bus = tkAudioBus;
				if (tkAudioBus.method_3(tkAudioSource_PlaybackInstance_0))
				{
					flag = true;
				}
			}
		}
		return flag;
	}

	// Token: 0x06000681 RID: 1665 RVA: 0x00053BC0 File Offset: 0x00051DC0
	private void method_16(TkAudioSource_PlaybackInstance tkAudioSource_PlaybackInstance_0, float float_0)
	{
		if (this.m_audioEventInfo != null)
		{
			tkAudioSource_PlaybackInstance_0.m_startDelay += this.m_audioEventInfo.m_fDelay;
		}
		TkAudioSource tkAudioSource = this;
		while (tkAudioSource)
		{
			if (tkAudioSource.m_volumeRandom)
			{
				tkAudioSource_PlaybackInstance_0.m_randomVolume += global::UnityEngine.Random.Range(-tkAudioSource.m_volumeRandomRange, tkAudioSource.m_volumeRandomRange);
			}
			if (tkAudioSource.m_pitchRandom)
			{
				tkAudioSource_PlaybackInstance_0.m_randomPitch += global::UnityEngine.Random.Range(-tkAudioSource.m_pitchRandomRange, tkAudioSource.m_pitchRandomRange);
			}
			if (tkAudioSource.m_panRandom)
			{
				tkAudioSource_PlaybackInstance_0.m_randomPan += global::UnityEngine.Random.Range(-tkAudioSource.m_panRandomRange, tkAudioSource.m_panRandomRange);
			}
			tkAudioSource_PlaybackInstance_0.m_startDelay += tkAudioSource.Single_0;
			if (tkAudioSource_PlaybackInstance_0.m_destroyAction == TkAudioSource.DestroyAction.Inherent)
			{
				tkAudioSource_PlaybackInstance_0.m_destroyAction = tkAudioSource.m_destroyAction;
			}
			tkAudioSource.m_playbackInstance = tkAudioSource_PlaybackInstance_0;
			tkAudioSource = tkAudioSource.method_9();
		}
		tkAudioSource_PlaybackInstance_0.m_programCtrlVolume = float_0;
		tkAudioSource_PlaybackInstance_0.method_4(0f);
	}

	// Token: 0x06000682 RID: 1666 RVA: 0x000076B5 File Offset: 0x000058B5
	public override void vmethod_0(double double_0)
	{
		this.m_triggerTime = double_0;
	}

	// Token: 0x06000683 RID: 1667 RVA: 0x00053CBC File Offset: 0x00051EBC
	private void Update()
	{
		if (this.autoDestroy)
		{
			if (string.IsNullOrEmpty(this.m_objName))
			{
				this.m_objName = base.gameObject.name;
			}
			if (this.m_playbackInstance != null)
			{
				if (string.IsNullOrEmpty(this.m_playbackInstance.m_objName))
				{
					this.m_playbackInstance.m_objName = this.m_playbackInstance.gameObject.name;
				}
				if (string.IsNullOrEmpty(this.m_playbackInstance.m_objName) && !string.IsNullOrEmpty(this.m_objName))
				{
					ComponentMonoSingleton<AudioSystem>.Instance.AudioResourceManager_0.m_poolManager.method_4(base.gameObject);
				}
			}
			else if (!string.IsNullOrEmpty(this.m_objName))
			{
				ComponentMonoSingleton<AudioSystem>.Instance.AudioResourceManager_0.m_poolManager.method_4(base.gameObject);
			}
		}
		if (this.m_autoStop && this.prefab != null && AudioSettings.dspTime - ((TkAudioSource)this.prefab).m_triggerTime > this.m_autoStopTime && this.m_playbackInstance != null)
		{
			this.m_playbackInstance.method_1(true);
		}
	}

	// Token: 0x06000684 RID: 1668 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnDestroy()
	{
	}

	// Token: 0x040005E2 RID: 1506
	[NonSerialized]
	public SoundActionInfo m_audioEventInfo;

	// Token: 0x040005E3 RID: 1507
	[TkInspectorAudioBus]
	public int m_bus;

	// Token: 0x040005E4 RID: 1508
	[TkInspectorAudioTemplate]
	public AudioSource audioTemplate;

	// Token: 0x040005E5 RID: 1509
	public TkAudioSource.DestroyAction m_destroyAction;

	// Token: 0x040005E6 RID: 1510
	[HideInInspector]
	public bool m_convertedFromOldBoLAudioSystem;

	// Token: 0x040005E7 RID: 1511
	[TkInspectorSlider(0f, 1f)]
	public float m_volume = 1f;

	// Token: 0x040005E8 RID: 1512
	public bool m_volumeRandom;

	// Token: 0x040005E9 RID: 1513
	[TkInspectorSlider(0f, 1f)]
	public float m_volumeRandomRange = 0.2f;

	// Token: 0x040005EA RID: 1514
	[TkInspectorSlider(0f, 5f)]
	public float m_pitch = 1f;

	// Token: 0x040005EB RID: 1515
	public bool m_pitchRandom;

	// Token: 0x040005EC RID: 1516
	[TkInspectorSlider(0f, 5f)]
	public float m_pitchRandomRange = 0.2f;

	// Token: 0x040005ED RID: 1517
	[TkInspectorSlider(-1f, 1f)]
	public float m_pan;

	// Token: 0x040005EE RID: 1518
	public bool m_panRandom;

	// Token: 0x040005EF RID: 1519
	[TkInspectorSlider(0f, 1f)]
	public float m_panRandomRange = 0.2f;

	// Token: 0x040005F0 RID: 1520
	[TkInspectorSlider(0f, 5f)]
	public float m_delay;

	// Token: 0x040005F1 RID: 1521
	public bool m_delayRandom;

	// Token: 0x040005F2 RID: 1522
	[TkInspectorSlider(0f, 5f)]
	public float m_delayRandomRange = 0.2f;

	// Token: 0x040005F3 RID: 1523
	public bool m_autoStop;

	// Token: 0x040005F4 RID: 1524
	public double m_autoStopTime = 1.0;

	// Token: 0x040005F5 RID: 1525
	private double m_triggerTime;

	// Token: 0x040005F6 RID: 1526
	[HideInInspector]
	public float m_randomRate = 1f;

	// Token: 0x040005F7 RID: 1527
	[NonSerialized]
	public TkAudioSource m_parent;

	// Token: 0x040005F8 RID: 1528
	[NonSerialized]
	public bool m_parentInitialized;

	// Token: 0x040005F9 RID: 1529
	[NonSerialized]
	public TkAudioSource_PlaybackInstance m_playbackInstance;

	// Token: 0x040005FA RID: 1530
	[NonSerialized]
	public CharacterVoice m_characterVoiceLimit;

	// Token: 0x040005FB RID: 1531
	[HideInInspector]
	public string m_objName = string.Empty;

	// Token: 0x02000122 RID: 290
	public enum DestroyAction
	{
		// Token: 0x040005FD RID: 1533
		Inherent,
		// Token: 0x040005FE RID: 1534
		Stop,
		// Token: 0x040005FF RID: 1535
		KeepPlaying
	}
}
