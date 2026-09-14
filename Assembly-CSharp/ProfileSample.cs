using System;
using System.IO;
using System.Text;
using Core;
using UnityEngine;

// Token: 0x02000652 RID: 1618
[Serializable]
public class ProfileSample
{
	// Token: 0x060028DE RID: 10462 RVA: 0x000C13AC File Offset: 0x000BF5AC
	public ProfileSample(global::UnityEngine.Object object_0, string string_0, string string_1, int int_0, int int_1, int int_2)
	{
		this.m_clip = object_0 as AudioClip;
		this.m_id = object_0.name;
		this.m_format = string_0;
		this.m_loadType = string_1;
		this.m_loads = int_0;
		this.m_instances = int_1;
		this.m_audioPlays = int_2;
		this.m_memory = (float)Profiler.GetRuntimeMemorySize(object_0) / 1024f / 1024f;
	}

	// Token: 0x17000205 RID: 517
	// (get) Token: 0x060028DF RID: 10463 RVA: 0x0001AD3C File Offset: 0x00018F3C
	public AudioClip clip
	{
		get
		{
			return this.m_clip;
		}
	}

	// Token: 0x17000206 RID: 518
	// (get) Token: 0x060028E0 RID: 10464 RVA: 0x0001AD44 File Offset: 0x00018F44
	public string id
	{
		get
		{
			return this.m_id;
		}
	}

	// Token: 0x17000207 RID: 519
	// (get) Token: 0x060028E1 RID: 10465 RVA: 0x0001AD4C File Offset: 0x00018F4C
	public int loads
	{
		get
		{
			return this.m_loads;
		}
	}

	// Token: 0x17000208 RID: 520
	// (get) Token: 0x060028E2 RID: 10466 RVA: 0x0001AD54 File Offset: 0x00018F54
	public int instances
	{
		get
		{
			return this.m_instances;
		}
	}

	// Token: 0x17000209 RID: 521
	// (get) Token: 0x060028E3 RID: 10467 RVA: 0x0001AD5C File Offset: 0x00018F5C
	public int audioPlays
	{
		get
		{
			return this.m_audioPlays;
		}
	}

	// Token: 0x060028E4 RID: 10468 RVA: 0x0001AD64 File Offset: 0x00018F64
	public void Start()
	{
		if (this.m_started)
		{
			this.method_1();
		}
		this.m_started = true;
	}

	// Token: 0x060028E5 RID: 10469 RVA: 0x0001AD7B File Offset: 0x00018F7B
	public void method_0()
	{
		if (!this.m_started)
		{
			this.method_1();
		}
		this.m_started = false;
	}

	// Token: 0x060028E6 RID: 10470 RVA: 0x0001AD92 File Offset: 0x00018F92
	private void method_1()
	{
		DebugUtils.LogError(LogCategory.Framework, "ProfilerRecording start/stops not balanced");
	}

	// Token: 0x060028E7 RID: 10471 RVA: 0x0001AD9F File Offset: 0x00018F9F
	public void method_2(PipeServerMsg pipeServerMsg_0)
	{
		this.m_wBinary = this.method_3((int)pipeServerMsg_0);
	}

	// Token: 0x060028E8 RID: 10472 RVA: 0x000C1418 File Offset: 0x000BF618
	protected string method_3(int int_0)
	{
		string text = string.Empty;
		while (int_0 > 0)
		{
			text = (int_0 & 1) + text;
			int_0 >>= 1;
		}
		return text.PadLeft(2, '0');
	}

	// Token: 0x060028E9 RID: 10473 RVA: 0x000C1454 File Offset: 0x000BF654
	public byte[] method_4()
	{
		MemoryStream memoryStream = new MemoryStream();
		using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
		{
			binaryWriter.Write(this.m_started);
			binaryWriter.Write(Encoding.UTF8.GetBytes(this.m_wBinary));
			byte[] array = Encoding.UTF8.GetBytes(this.m_id);
			binaryWriter.Write(array.Length);
			binaryWriter.Write(array);
			array = Encoding.UTF8.GetBytes(this.m_format);
			binaryWriter.Write(array.Length);
			binaryWriter.Write(array);
			array = Encoding.UTF8.GetBytes(this.m_loadType);
			binaryWriter.Write(array.Length);
			binaryWriter.Write(array);
			binaryWriter.Write(this.m_loads);
			binaryWriter.Write(this.m_instances);
			binaryWriter.Write(this.m_audioPlays);
			binaryWriter.Write(this.m_memory);
			memoryStream.Seek(0L, SeekOrigin.Begin);
		}
		return memoryStream.ToArray();
	}

	// Token: 0x04001D31 RID: 7473
	private AudioClip m_clip;

	// Token: 0x04001D32 RID: 7474
	[SerializeField]
	private bool m_started;

	// Token: 0x04001D33 RID: 7475
	[SerializeField]
	private string m_wBinary;

	// Token: 0x04001D34 RID: 7476
	[SerializeField]
	private string m_id;

	// Token: 0x04001D35 RID: 7477
	[SerializeField]
	private string m_format;

	// Token: 0x04001D36 RID: 7478
	[SerializeField]
	private string m_loadType;

	// Token: 0x04001D37 RID: 7479
	[SerializeField]
	private int m_loads;

	// Token: 0x04001D38 RID: 7480
	[SerializeField]
	private int m_instances;

	// Token: 0x04001D39 RID: 7481
	[SerializeField]
	private int m_audioPlays;

	// Token: 0x04001D3A RID: 7482
	[SerializeField]
	private float m_memory;
}
