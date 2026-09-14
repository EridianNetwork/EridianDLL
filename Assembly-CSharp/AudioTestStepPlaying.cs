using System;
using Core;
using ns0;
using UnityEngine;

// Token: 0x02000604 RID: 1540
public class AudioTestStepPlaying : IAudioTestStep
{
	// Token: 0x06002752 RID: 10066 RVA: 0x000BCAF0 File Offset: 0x000BACF0
	public void imethod_0(ProfileSample profileSample_0)
	{
		DebugUtils.Log(LogCategory.Framework, "Playing test for [" + profileSample_0.id + "] is starting...");
		this.m_profileSample = profileSample_0;
		this.m_profileSample.method_2(PipeServerMsg.Play);
		this.m_audio = new AudioSource[this.m_profileSample.instances];
		this.m_duration = this.m_profileSample.clip.length;
		this.m_timer = new Utils.Timer();
		for (int i = 0; i < this.m_profileSample.instances; i++)
		{
			GameObject gameObject = new GameObject(this.m_profileSample.id + "__" + i);
			this.m_audio[i] = gameObject.AddComponent<AudioSource>();
			this.m_audio[i].clip = global::UnityEngine.Object.Instantiate(this.m_profileSample.clip) as AudioClip;
		}
		MonoSingleton<NamedPipeServerController>.Instance.method_1(this.m_profileSample);
	}

	// Token: 0x06002753 RID: 10067 RVA: 0x000BCBDC File Offset: 0x000BADDC
	public bool Update()
	{
		if (this.m_timer.method_1() > 0f)
		{
			return false;
		}
		if (this.m_playCount < this.m_profileSample.audioPlays)
		{
			for (int i = 0; i < this.m_audio.Length; i++)
			{
				this.m_audio[i].Play();
			}
			DebugUtils.Log(LogCategory.Framework, "....");
			this.m_timer.Start(this.m_duration);
			this.m_playCount++;
			return false;
		}
		return true;
	}

	// Token: 0x06002754 RID: 10068 RVA: 0x0001A6AA File Offset: 0x000188AA
	public void imethod_1()
	{
		MonoSingleton<NamedPipeServerController>.Instance.method_2();
		DebugUtils.Log(LogCategory.Framework, "Playing test is complete...");
	}

	// Token: 0x04001C67 RID: 7271
	private ProfileSample m_profileSample;

	// Token: 0x04001C68 RID: 7272
	private int m_playCount;

	// Token: 0x04001C69 RID: 7273
	private AudioSource[] m_audio;

	// Token: 0x04001C6A RID: 7274
	private float m_duration;

	// Token: 0x04001C6B RID: 7275
	private Utils.Timer m_timer;
}
