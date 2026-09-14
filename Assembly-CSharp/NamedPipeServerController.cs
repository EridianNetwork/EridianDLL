using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Core;
using ns0;

// Token: 0x02000650 RID: 1616
public class NamedPipeServerController : MonoSingleton<NamedPipeServerController>
{
	// Token: 0x060028D2 RID: 10450 RVA: 0x0001ACBF File Offset: 0x00018EBF
	protected override void Awake()
	{
		base.Awake();
		this.m_server = new NamedPipeServer("\\\\.\\pipe\\myNamedPipe", 1);
		this.m_server.Start();
	}

	// Token: 0x060028D3 RID: 10451 RVA: 0x000C1254 File Offset: 0x000BF454
	private IEnumerator Start()
	{
		while (!m_server.Boolean_0)
		{
			yield return null;
		}
		method_0();
	}
	// Token: 0x060028D4 RID: 10452 RVA: 0x000C1270 File Offset: 0x000BF470
	private void method_0()
	{
		try
		{
			string text = "start .\\Tools\\PipeServer\\Perfmonitor.exe";
			Process.Start(new ProcessStartInfo("cmd.exe", "/c " + text)
			{
				UseShellExecute = false,
				RedirectStandardError = true,
				RedirectStandardOutput = true
			});
		}
		catch (Exception ex)
		{
			DebugUtils.LogWarning(LogCategory.Framework, ex.Message);
		}
	}

	// Token: 0x060028D5 RID: 10453 RVA: 0x0001ACE4 File Offset: 0x00018EE4
	private void OnDestroy()
	{
		this.m_server.method_3();
	}

	// Token: 0x060028D6 RID: 10454 RVA: 0x000C12D8 File Offset: 0x000BF4D8
	public void method_1(ProfileSample profileSample_0)
	{
		if (!NamedPipeServerController.m_samples.TryGetValue(profileSample_0.id, out this.m_currentSample))
		{
			this.m_currentSample = profileSample_0;
		}
		NamedPipeServerController.m_samples[profileSample_0.id] = this.m_currentSample;
		this.m_currentSample.Start();
		if (this.m_server != null)
		{
			this.m_server.method_2(this.m_currentSample, this.m_server.clientse);
		}
	}

	// Token: 0x060028D7 RID: 10455 RVA: 0x0001ACF2 File Offset: 0x00018EF2
	public void method_2()
	{
		if (this.m_currentSample != null)
		{
			this.m_currentSample.method_0();
			if (this.m_server != null)
			{
				this.m_server.method_2(this.m_currentSample, this.m_server.clientse);
			}
		}
	}

	// Token: 0x04001D2A RID: 7466
	private NamedPipeServer m_server;

	// Token: 0x04001D2B RID: 7467
	private ProfileSample m_currentSample;

	// Token: 0x04001D2C RID: 7468
	private byte m_profileFlag;

	// Token: 0x04001D2D RID: 7469
	private static Dictionary<string, ProfileSample> m_samples = new Dictionary<string, ProfileSample>();
}
