using System;
using ns0;
using UnityEngine;

// Token: 0x02000601 RID: 1537
[RequireComponent(typeof(NamedPipeServerController))]
[ExecuteInEditMode]
public class AudioTestManager : MonoSingleton<AudioTestManager>
{
	// Token: 0x170001EC RID: 492
	// (get) Token: 0x06002743 RID: 10051 RVA: 0x0001A66A File Offset: 0x0001886A
	private string String_0
	{
		get
		{
			return "file://" + Application.dataPath + "/../assetbundles/AudioTest/";
		}
	}

	// Token: 0x06002744 RID: 10052 RVA: 0x0001A680 File Offset: 0x00018880
	protected override void Awake()
	{
		base.Awake();
	}

	// Token: 0x06002745 RID: 10053 RVA: 0x000BC794 File Offset: 0x000BA994
	private void Start()
	{
		if (Application.isPlaying && Application.isEditor)
		{
			global::UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
			if (this.m_testSequence != null && this.m_profileSamples != null)
			{
				while (this.m_currentSample < this.m_profileSamples.Length)
				{
					if (this.m_profileSamples[this.m_currentSample] != null)
					{
						this.m_testSequence[this.m_currentStep].imethod_0(this.m_profileSamples[this.m_currentSample]);
						this.m_seqStarted = true;
						break;
					}
					this.m_currentSample++;
				}
			}
		}
	}

	// Token: 0x06002746 RID: 10054 RVA: 0x000BC824 File Offset: 0x000BAA24
	private void Update()
	{
		if (!this.m_seqStarted)
		{
			return;
		}
		if (this.m_currentStep < this.m_testSequence.Length)
		{
			if (this.m_testSequence[this.m_currentStep].Update())
			{
				this.m_testSequence[this.m_currentStep].imethod_1();
				this.m_currentStep++;
				if (this.m_currentStep < this.m_testSequence.Length)
				{
					this.m_testSequence[this.m_currentStep].imethod_0(this.m_profileSamples[this.m_currentSample]);
				}
			}
		}
		else
		{
			if (this.m_async == null)
			{
				this.m_async = Application.LoadLevelAsync("ResourcesLoading");
			}
			if (this.m_async.isDone)
			{
				this.m_async = null;
				this.m_currentSample++;
				if (this.m_currentSample < this.m_profileSamples.Length)
				{
					this.m_currentStep = 0;
					this.m_testSequence[this.m_currentStep].imethod_0(this.m_profileSamples[this.m_currentSample]);
				}
				else
				{
					this.m_seqStarted = false;
				}
			}
		}
	}

	// Token: 0x04001C57 RID: 7255
	public AudioClip[] m_samples;

	// Token: 0x04001C58 RID: 7256
	public int m_numberOfLoad;

	// Token: 0x04001C59 RID: 7257
	public int m_numberOfInstances;

	// Token: 0x04001C5A RID: 7258
	public int m_numberOfAudioPlay;

	// Token: 0x04001C5B RID: 7259
	[HideInInspector]
	public ProfileSample[] m_profileSamples;

	// Token: 0x04001C5C RID: 7260
	private bool m_seqStarted;

	// Token: 0x04001C5D RID: 7261
	private int m_currentStep;

	// Token: 0x04001C5E RID: 7262
	private int m_currentSample;

	// Token: 0x04001C5F RID: 7263
	private AsyncOperation m_async;

	// Token: 0x04001C60 RID: 7264
	private IAudioTestStep[] m_testSequence = new IAudioTestStep[]
	{
		new AudioTestStepLoading(),
		new AudioTestStepPlaying()
	};
}
