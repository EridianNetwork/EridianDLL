using System;
using Core;
using ns0;
using UnityEngine;

// Token: 0x02000603 RID: 1539
public class AudioTestStepLoading : IAudioTestStep
{
	// Token: 0x170001ED RID: 493
	// (get) Token: 0x0600274B RID: 10059 RVA: 0x0001A66A File Offset: 0x0001886A
	private string String_0
	{
		get
		{
			return "file://" + Application.dataPath + "/../assetbundles/AudioTest/";
		}
	}

	// Token: 0x0600274C RID: 10060 RVA: 0x000BC930 File Offset: 0x000BAB30
	public void imethod_0(ProfileSample profileSample_0)
	{
		DebugUtils.Log(LogCategory.Framework, "Loading test for [" + profileSample_0.id + "] is starting...");
		this.m_profileSample = profileSample_0;
		this.m_profileSample.method_2(PipeServerMsg.Load);
		this.m_assets = new AudioClip[this.m_profileSample.instances];
		this.m_timer = new Utils.Timer();
		this.m_downloaded = false;
	}

	// Token: 0x0600274D RID: 10061 RVA: 0x000BC994 File Offset: 0x000BAB94
	public bool Update()
	{
		if (!this.m_downloaded)
		{
			this.method_0();
			return false;
		}
		if (this.m_count < this.m_assets.Length)
		{
			this.m_assets[this.m_count] = this.m_stream.assetBundle.Load(this.m_profileSample.id) as AudioClip;
			this.m_stream.assetBundle.Unload(false);
			this.m_count++;
			return false;
		}
		return this.method_1();
	}

	// Token: 0x0600274E RID: 10062 RVA: 0x0001A688 File Offset: 0x00018888
	public void imethod_1()
	{
		DebugUtils.Log(LogCategory.Framework, "Loading test for [" + this.m_profileSample.id + "] is complete...");
	}

	// Token: 0x0600274F RID: 10063 RVA: 0x000BCA18 File Offset: 0x000BAC18
	private void method_0()
	{
		if (this.m_stream == null)
		{
			this.m_stream = new WWW(this.String_0 + this.m_profileSample.id + ".zip");
		}
		if (!this.m_stream.isDone)
		{
			return;
		}
		MonoSingleton<NamedPipeServerController>.Instance.method_1(this.m_profileSample);
		this.m_timer.Start(0.2f);
		this.m_downloaded = true;
	}

	// Token: 0x06002750 RID: 10064 RVA: 0x000BCA88 File Offset: 0x000BAC88
	private bool method_1()
	{
		if (this.m_timer.method_1() > 0f)
		{
			return false;
		}
		MonoSingleton<NamedPipeServerController>.Instance.method_2();
		this.m_stream.Dispose();
		this.m_stream = null;
		for (int i = 0; i < this.m_assets.Length; i++)
		{
			global::UnityEngine.Object.DestroyImmediate(this.m_assets[i], true);
			this.m_count = 0;
		}
		return true;
	}

	// Token: 0x04001C61 RID: 7265
	private ProfileSample m_profileSample;

	// Token: 0x04001C62 RID: 7266
	private AudioClip[] m_assets;

	// Token: 0x04001C63 RID: 7267
	private WWW m_stream;

	// Token: 0x04001C64 RID: 7268
	private int m_count;

	// Token: 0x04001C65 RID: 7269
	private bool m_downloaded;

	// Token: 0x04001C66 RID: 7270
	private Utils.Timer m_timer;
}
