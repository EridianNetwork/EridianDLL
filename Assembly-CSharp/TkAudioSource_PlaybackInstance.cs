using System;
using ns0;
using UnityEngine;

// Token: 0x02000123 RID: 291
[ExecuteInEditMode]
[AddComponentMenu("Tk/-- internal --")]
public class TkAudioSource_PlaybackInstance : MonoBehaviour
{
	// Token: 0x17000047 RID: 71
	// (get) Token: 0x06000686 RID: 1670 RVA: 0x000076BE File Offset: 0x000058BE
	public bool Boolean_0
	{
		get
		{
			return this.m_stopping >= 0f;
		}
	}

	// Token: 0x06000687 RID: 1671 RVA: 0x000076D0 File Offset: 0x000058D0
	public void method_0()
	{
		this.m_audioSource.PlayDelayed(this.m_startDelay);
	}

	// Token: 0x06000688 RID: 1672 RVA: 0x000076E3 File Offset: 0x000058E3
	public void method_1(bool bool_0 = true)
	{
		if (!bool_0 && this.m_audioSource)
		{
			this.m_audioSource.Stop();
		}
		if (this.m_stopping >= 0f)
		{
			return;
		}
		this.m_stopping = 0f;
	}

	// Token: 0x06000689 RID: 1673 RVA: 0x00007719 File Offset: 0x00005919
	public void method_2()
	{
		this.m_pause = true;
		if (this.m_audioSource)
		{
			this.m_audioSource.Pause();
		}
	}

	// Token: 0x0600068A RID: 1674 RVA: 0x0000773A File Offset: 0x0000593A
	public void method_3()
	{
		if (!this.m_pause)
		{
			return;
		}
		this.m_pause = false;
		if (this.m_audioSource)
		{
			this.m_audioSource.Play();
		}
	}

	// Token: 0x0600068B RID: 1675 RVA: 0x00053E4C File Offset: 0x0005204C
	private void Awake()
	{
		GameObject gameObject_ = TkAudioSystem.TkAudioSystem_0.GameObject_0;
		base.transform.parent = gameObject_.transform;
		global::UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		base.gameObject.hideFlags = HideFlags.DontSave;
	}

	// Token: 0x0600068C RID: 1676 RVA: 0x00007764 File Offset: 0x00005964
	public void method_4(float float_0)
	{
		this.method_5();
		this.method_6();
		this.method_7(float_0);
		this.method_8();
	}

	// Token: 0x0600068D RID: 1677 RVA: 0x00053E8C File Offset: 0x0005208C
	private void method_5()
	{
		if (this.m_src)
		{
			this.m_sourceVolume = this.m_src.m_volume;
			this.m_sourcePitch = this.m_src.m_pitch;
			this.m_sourcePan = this.m_src.m_pan;
			TkAudioSource tkAudioSource = this.m_src.method_9();
			while (tkAudioSource)
			{
				this.m_sourceVolume *= tkAudioSource.m_volume;
				this.m_sourcePitch *= tkAudioSource.m_pitch;
				this.m_sourcePan += tkAudioSource.m_pan;
				tkAudioSource = tkAudioSource.method_9();
			}
		}
	}

	// Token: 0x0600068E RID: 1678 RVA: 0x00053F34 File Offset: 0x00052134
	private void method_6()
	{
		if (this.m_hasHost)
		{
			if (this.m_host)
			{
				base.transform.position = this.m_host.transform.position;
				base.transform.rotation = this.m_host.transform.rotation;
				base.transform.localScale = this.m_host.transform.localScale;
			}
			else if (this.m_destroyAction != TkAudioSource.DestroyAction.KeepPlaying)
			{
				this.method_1(true);
			}
		}
	}

	// Token: 0x0600068F RID: 1679 RVA: 0x00053FBC File Offset: 0x000521BC
	private void method_7(float float_0)
	{
		if (this.m_stopping >= 0f)
		{
			if (this.m_bus.m_stopFadeDuration <= 0f)
			{
				this.m_stopping = 1f;
			}
			else
			{
				this.m_stopping += float_0 / this.m_bus.m_stopFadeDuration;
			}
			float num = 1f - this.m_stopping;
			if (this.m_bus.m_stopFadeCurve != null)
			{
				num = this.m_bus.m_stopFadeCurve.Evaluate(num);
			}
			this.m_sourceVolume *= num;
		}
	}

	// Token: 0x06000690 RID: 1680 RVA: 0x0005404C File Offset: 0x0005224C
	private void method_8()
	{
		if (this.m_audioSource)
		{
			this.m_lastUpdateTime = this.m_audioSource.time;
			this.m_audioSource.volume = this.m_sourceVolume * this.m_bus.m_computedVolume * this.m_randomVolume * this.m_programCtrlVolume;
			this.m_audioSource.pitch = this.m_sourcePitch * this.m_bus.m_computedPitch * this.m_randomPitch * this.m_programCtrlPitch;
			if (this.m_audioSource.pitch < 0.1f)
			{
				this.m_audioSource.pitch = 0.1f;
			}
			this.m_audioSource.pan = this.m_sourcePan + this.m_bus.m_computedPan + this.m_randomPan + this.m_programCtrlPan;
			if (this.m_stopping >= 1f)
			{
				this.m_audioSource.Stop();
				return;
			}
		}
	}

	// Token: 0x06000691 RID: 1681 RVA: 0x00054138 File Offset: 0x00052338
	public void method_9(float float_0)
	{
		if (this.m_bus && this.m_audioSource && this.m_audioSource.isPlaying)
		{
			this.method_4(float_0);
			return;
		}
		if (!this.m_previewInEditor)
		{
			if (!string.IsNullOrEmpty(base.gameObject.name))
			{
				ComponentMonoSingleton<AudioSystem>.Instance.AudioResourceManager_0.m_poolManager.method_7(this);
			}
		}
		else
		{
			TkAudioSystem.smethod_7(base.gameObject);
		}
	}

	// Token: 0x06000692 RID: 1682 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnDestroy()
	{
	}

	// Token: 0x04000600 RID: 1536
	[HideInInspector]
	public string m_objName = string.Empty;

	// Token: 0x04000601 RID: 1537
	public TkAudioSource m_src;

	// Token: 0x04000602 RID: 1538
	public AudioSource m_audioSource;

	// Token: 0x04000603 RID: 1539
	public TkAudioBus m_bus;

	// Token: 0x04000604 RID: 1540
	public bool m_hasHost;

	// Token: 0x04000605 RID: 1541
	public GameObject m_host;

	// Token: 0x04000606 RID: 1542
	public float m_programCtrlVolume = 1f;

	// Token: 0x04000607 RID: 1543
	public float m_programCtrlPitch = 1f;

	// Token: 0x04000608 RID: 1544
	public float m_programCtrlPan;

	// Token: 0x04000609 RID: 1545
	public float m_startDelay;

	// Token: 0x0400060A RID: 1546
	public float m_sourceVolume = 1f;

	// Token: 0x0400060B RID: 1547
	public float m_sourcePitch = 1f;

	// Token: 0x0400060C RID: 1548
	public float m_sourcePan;

	// Token: 0x0400060D RID: 1549
	public float m_randomVolume = 1f;

	// Token: 0x0400060E RID: 1550
	public float m_randomPitch = 1f;

	// Token: 0x0400060F RID: 1551
	public float m_randomPan;

	// Token: 0x04000610 RID: 1552
	public float m_lastUpdateTime;

	// Token: 0x04000611 RID: 1553
	public TkAnimEventAction m_actionPrefab;

	// Token: 0x04000612 RID: 1554
	public TkAudioSource.DestroyAction m_destroyAction;

	// Token: 0x04000613 RID: 1555
	public string m_templateName;

	// Token: 0x04000614 RID: 1556
	public bool m_previewInEditor;

	// Token: 0x04000615 RID: 1557
	private bool m_pause;

	// Token: 0x04000616 RID: 1558
	public float m_stopping = -1f;
}
