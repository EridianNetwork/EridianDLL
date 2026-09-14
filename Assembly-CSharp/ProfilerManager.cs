using System;
using System.IO;
using Core;
using UnityEngine;

// Token: 0x02000653 RID: 1619
public class ProfilerManager
{
	// Token: 0x060028EB RID: 10475 RVA: 0x0001ADD7 File Offset: 0x00018FD7
	public void Start()
	{
		this.method_9();
		this.method_2(1);
	}

	// Token: 0x060028EC RID: 10476 RVA: 0x0001ADE6 File Offset: 0x00018FE6
	public void Update()
	{
		if (Time.frameCount - this.m_startFrameCount > 300)
		{
			this.method_2(this.m_fragment + 1);
		}
	}

	// Token: 0x060028ED RID: 10477 RVA: 0x0001AE09 File Offset: 0x00019009
	public void method_0()
	{
		this.method_1(this.m_fragment + 1);
	}

	// Token: 0x060028EE RID: 10478 RVA: 0x0001AE19 File Offset: 0x00019019
	public void method_1(int int_0)
	{
		this.m_fragment = int_0;
	}

	// Token: 0x060028EF RID: 10479 RVA: 0x0001AE22 File Offset: 0x00019022
	private void method_2(int int_0)
	{
		Profiler.enableBinaryLog = false;
		Profiler.enabled = false;
		this.m_fragment = int_0;
		this.m_startFrameCount = Time.frameCount;
		Profiler.logFile = this.method_3(int_0);
		Profiler.enabled = true;
		Profiler.enableBinaryLog = true;
	}

	// Token: 0x060028F0 RID: 10480 RVA: 0x0001AE5A File Offset: 0x0001905A
	private string method_3(int int_0)
	{
		return string.Format("{0}_{1}", this.m_fileName, int_0);
	}

	// Token: 0x060028F1 RID: 10481 RVA: 0x0001AE72 File Offset: 0x00019072
	public void method_4(string string_0)
	{
		this.m_filePath = string_0;
	}

	// Token: 0x060028F2 RID: 10482 RVA: 0x0001AE7B File Offset: 0x0001907B
	public string method_5()
	{
		return this.m_filePath;
	}

	// Token: 0x060028F3 RID: 10483 RVA: 0x0001AE83 File Offset: 0x00019083
	public string method_6()
	{
		return this.m_fileName;
	}

	// Token: 0x060028F4 RID: 10484 RVA: 0x0001AE8B File Offset: 0x0001908B
	public string method_7(int int_0)
	{
		return this.method_3(int_0);
	}

	// Token: 0x060028F5 RID: 10485 RVA: 0x0001AE94 File Offset: 0x00019094
	public void method_8(string string_0)
	{
		this.m_fileName = string_0;
	}

	// Token: 0x060028F6 RID: 10486 RVA: 0x000C1558 File Offset: 0x000BF758
	private void method_9()
	{
		DirectoryInfo directoryInfo = new DirectoryInfo(this.method_5());
		FileInfo[] files = directoryInfo.GetFiles(this.method_6() + "*.*");
		for (int i = 0; i < files.Length; i++)
		{
			files[i].Delete();
		}
	}

	// Token: 0x060028F7 RID: 10487 RVA: 0x0001AE9D File Offset: 0x0001909D
	public void OnDestroy()
	{
		DebugUtils.Log(LogCategory.Tool, "profiler OnDestroy");
		Profiler.logFile = string.Empty;
		Profiler.enableBinaryLog = false;
		Profiler.enabled = false;
	}

	// Token: 0x060028F8 RID: 10488 RVA: 0x0001AEC1 File Offset: 0x000190C1
	private string method_10(int int_0)
	{
		return string.Format("{0}/{1}", this.method_5(), this.method_3(int_0));
	}

	// Token: 0x060028F9 RID: 10489 RVA: 0x000C15A0 File Offset: 0x000BF7A0
	public void method_11()
	{
		if (Time.time - this.m_lastScreenShot > this.m_screenShotCoolDown)
		{
			Application.CaptureScreenshot(string.Format("{0}_{1}.png", this.method_10(this.m_fragment), Time.frameCount));
			this.m_lastScreenShot = Time.time;
		}
	}

	// Token: 0x04001D3B RID: 7483
	private int m_startFrameCount;

	// Token: 0x04001D3C RID: 7484
	private int m_fragment;

	// Token: 0x04001D3D RID: 7485
	private string m_fileName = "Profile";

	// Token: 0x04001D3E RID: 7486
	private string m_filePath = "./";

	// Token: 0x04001D3F RID: 7487
	private float m_lastScreenShot;

	// Token: 0x04001D40 RID: 7488
	private float m_screenShotCoolDown = 1f;
}
