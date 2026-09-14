using System;
using Core;
using ns0;
using UnityEngine;

// Token: 0x02000130 RID: 304
[ExecuteInEditMode]
public class AudioSystem : ComponentMonoSingleton<AudioSystem>, IAudioSubsystem
{
	// Token: 0x060006F3 RID: 1779 RVA: 0x0005567C File Offset: 0x0005387C
	public AudioSystem()
	{
		DebugUtils.Log(LogCategory.Audio, "Creating AudioSystem");
		this.m_subsystems = new IAudioSubsystem[2];
		this.m_subsystems[0] = new AudioResourceManager();
		this.m_subsystems[1] = new TkAudioSubsystem();
	}

	// Token: 0x17000050 RID: 80
	// (get) Token: 0x060006F4 RID: 1780 RVA: 0x000079A3 File Offset: 0x00005BA3
	// (set) Token: 0x060006F5 RID: 1781 RVA: 0x000079AB File Offset: 0x00005BAB
	public bool Boolean_1
	{
		get
		{
			return this.m_enabled;
		}
		set
		{
			this.m_enabled = value;
		}
	}

	// Token: 0x17000051 RID: 81
	// (get) Token: 0x060006F6 RID: 1782 RVA: 0x000079B4 File Offset: 0x00005BB4
	// (set) Token: 0x060006F7 RID: 1783 RVA: 0x000079BC File Offset: 0x00005BBC
	public AudioManager AudioManager_0
	{
		get
		{
			return this.m_controller;
		}
		private set
		{
			this.m_controller = value;
		}
	}

	// Token: 0x060006F8 RID: 1784 RVA: 0x000556D0 File Offset: 0x000538D0
	protected T method_0<T>(EAudioSubsystems eaudioSubsystems_0)
	{
		return (T)((object)this.m_subsystems[(int)eaudioSubsystems_0]);
	}

	// Token: 0x17000052 RID: 82
	// (get) Token: 0x060006F9 RID: 1785 RVA: 0x000079C5 File Offset: 0x00005BC5
	public AudioResourceManager AudioResourceManager_0
	{
		get
		{
			return this.method_0<AudioResourceManager>(EAudioSubsystems.BEGIN);
		}
	}

	// Token: 0x17000053 RID: 83
	// (get) Token: 0x060006FA RID: 1786 RVA: 0x000079CE File Offset: 0x00005BCE
	public TkAudioSubsystem TkAudioSubsystem_0
	{
		get
		{
			return this.method_0<TkAudioSubsystem>(EAudioSubsystems.TKAUDIO);
		}
	}

	// Token: 0x060006FB RID: 1787 RVA: 0x000556EC File Offset: 0x000538EC
	public bool imethod_0()
	{
		if (!m_initialized)
		{
			DebugUtils.Log(LogCategory.Audio, "AudioSystem.Initialize()");
			bool initialized = true;
			for (int i = 0; i < m_subsystems.Length; i++)
			{
				if (!m_subsystems[i].imethod_0())
				{
					initialized = false;
					imethod_1();
					break;
				}
			}
			m_initialized = initialized;
			m_lastEnabled = m_enabled;
		}
		return m_initialized;
	}
	// Token: 0x060006FC RID: 1788 RVA: 0x00055754 File Offset: 0x00053954
	public void imethod_1()
	{
		DebugUtils.Log(LogCategory.Audio, "AudioSystem.Deinitialize()");
		for (int i = this.m_subsystems.Length - 1; i >= 0; i--)
		{
			this.m_subsystems[i].imethod_1();
		}
		this.m_initialized = false;
	}

	// Token: 0x060006FD RID: 1789 RVA: 0x00055798 File Offset: 0x00053998
	public void imethod_2()
	{
		for (int i = 0; i < this.m_subsystems.Length; i++)
		{
			this.m_subsystems[i].imethod_2();
		}
	}

	// Token: 0x060006FE RID: 1790 RVA: 0x000557C8 File Offset: 0x000539C8
	public void imethod_3()
	{
		for (int i = this.m_subsystems.Length - 1; i >= 0; i--)
		{
			this.m_subsystems[i].imethod_3();
		}
	}

	// Token: 0x060006FF RID: 1791 RVA: 0x000557F8 File Offset: 0x000539F8
	private static string smethod_1(EAudioSubsystems eaudioSubsystems_0)
	{
		if (eaudioSubsystems_0 == EAudioSubsystems.BEGIN)
		{
			return "EAudioSubsystems.RESOURCE";
		}
		if (eaudioSubsystems_0 != EAudioSubsystems.TKAUDIO)
		{
			return "EAudioSubsystems.NONE";
		}
		return "EAudioSubsystems.TKAUDIO";
	}

	// Token: 0x06000700 RID: 1792 RVA: 0x00055820 File Offset: 0x00053A20
	public void Update()
	{
		if (this.m_enabled != this.m_lastEnabled)
		{
			this.method_5(BusDescriptor.Master, !this.m_enabled);
			this.m_lastEnabled = this.m_enabled;
		}
		for (int i = 0; i < this.m_subsystems.Length; i++)
		{
			this.m_subsystems[i].Update();
		}
	}

	// Token: 0x06000701 RID: 1793 RVA: 0x00055878 File Offset: 0x00053A78
	public void LateUpdate()
	{
		for (int i = 0; i < this.m_subsystems.Length; i++)
		{
			this.m_subsystems[i].LateUpdate();
		}
	}

	// Token: 0x06000702 RID: 1794 RVA: 0x000558A8 File Offset: 0x00053AA8
	public void imethod_4()
	{
		DebugUtils.Log(LogCategory.Framework, "AudioSystem ReleaseMemory - " + Time.time);
		for (int i = 0; i < this.m_subsystems.Length; i++)
		{
			this.m_subsystems[i].imethod_4();
		}
	}

	// Token: 0x06000703 RID: 1795 RVA: 0x000079D7 File Offset: 0x00005BD7
	public void method_1(AudioManager audioManager_0)
	{
		this.m_controller = audioManager_0;
		if (null != this.m_controller)
		{
			this.AudioResourceManager_0.method_1();
		}
	}

	// Token: 0x06000704 RID: 1796 RVA: 0x000079F9 File Offset: 0x00005BF9
	public void method_2(Transform transform_0)
	{
		TkAudioSystem.TkAudioSystem_0.method_2(transform_0);
	}

	// Token: 0x06000705 RID: 1797 RVA: 0x00007A06 File Offset: 0x00005C06
	public void method_3(BusDescriptor busDescriptor_0, float float_0)
	{
		this.TkAudioSubsystem_0.method_1(busDescriptor_0, float_0);
	}

	// Token: 0x06000706 RID: 1798 RVA: 0x00007A15 File Offset: 0x00005C15
	public float method_4(BusDescriptor busDescriptor_0)
	{
		return this.TkAudioSubsystem_0.method_2(busDescriptor_0);
	}

	// Token: 0x06000707 RID: 1799 RVA: 0x00007A23 File Offset: 0x00005C23
	public void method_5(BusDescriptor busDescriptor_0, bool bool_1)
	{
		this.TkAudioSubsystem_0.method_3(busDescriptor_0, bool_1);
	}

	// Token: 0x04000652 RID: 1618
	private IAudioSubsystem[] m_subsystems;

	// Token: 0x04000653 RID: 1619
	private AudioManager m_controller;

	// Token: 0x04000654 RID: 1620
	private bool m_initialized;

	// Token: 0x04000655 RID: 1621
	private bool m_enabled = true;

	// Token: 0x04000656 RID: 1622
	private bool m_lastEnabled = true;

	// Token: 0x04000657 RID: 1623
	public TensityControlSystem Tensity;
}
