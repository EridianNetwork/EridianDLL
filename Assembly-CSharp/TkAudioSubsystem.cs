using System;
using Core;

// Token: 0x02000131 RID: 305
public class TkAudioSubsystem : AudioSubsystem
{
	// Token: 0x06000709 RID: 1801 RVA: 0x00007A3A File Offset: 0x00005C3A
	protected override bool vmethod_0()
	{
		TkAudioSystem.TkAudioSystem_0.method_5();
		return true;
	}

	// Token: 0x0600070A RID: 1802 RVA: 0x0000311B File Offset: 0x0000131B
	protected override void vmethod_1()
	{
	}

	// Token: 0x0600070B RID: 1803 RVA: 0x0000311B File Offset: 0x0000131B
	protected override void OnSceneLoaded(bool loaded)
	{
	}

	// Token: 0x0600070C RID: 1804 RVA: 0x0000311B File Offset: 0x0000131B
	public override void Update()
	{
	}

	// Token: 0x0600070D RID: 1805 RVA: 0x00007A47 File Offset: 0x00005C47
	public override void LateUpdate()
	{
		TkAudioSystem.TkAudioSystem_0.method_3();
	}

	// Token: 0x0600070E RID: 1806 RVA: 0x0000311B File Offset: 0x0000131B
	public override void imethod_4()
	{
	}

	// Token: 0x0600070F RID: 1807 RVA: 0x000558F0 File Offset: 0x00053AF0
	public TkAudioBus method_0(BusDescriptor busDescriptor_0)
	{
		TkAudioBus tkAudioBus;
		if (busDescriptor_0 == BusDescriptor.Master)
		{
			tkAudioBus = TkAudioSystem.TkAudioBus_0;
		}
		else
		{
			tkAudioBus = TkAudioSystem.smethod_6(busDescriptor_0.ToString());
		}
		return tkAudioBus;
	}

	// Token: 0x06000710 RID: 1808 RVA: 0x0005591C File Offset: 0x00053B1C
	public void method_1(BusDescriptor busDescriptor_0, float float_0)
	{
		TkAudioBus tkAudioBus = this.method_0(busDescriptor_0);
		if (null != tkAudioBus)
		{
			tkAudioBus.m_volume = float_0;
		}
		else
		{
			DebugUtils.LogWarning(LogCategory.Audio, "Couldn't find bus named: " + busDescriptor_0.ToString());
		}
	}

	// Token: 0x06000711 RID: 1809 RVA: 0x00055960 File Offset: 0x00053B60
	public float method_2(BusDescriptor busDescriptor_0)
	{
		float num = 0f;
		TkAudioBus tkAudioBus = this.method_0(busDescriptor_0);
		if (null != tkAudioBus)
		{
			num = tkAudioBus.m_volume;
		}
		else
		{
			DebugUtils.LogWarning(LogCategory.Audio, "Couldn't find bus named: " + busDescriptor_0.ToString());
		}
		return num;
	}

	// Token: 0x06000712 RID: 1810 RVA: 0x000559AC File Offset: 0x00053BAC
	public void method_3(BusDescriptor busDescriptor_0, bool bool_0)
	{
		TkAudioBus tkAudioBus = this.method_0(busDescriptor_0);
		if (null != tkAudioBus)
		{
			tkAudioBus.m_mute = bool_0;
		}
		else
		{
			DebugUtils.LogWarning(LogCategory.Audio, "Couldn't find bus named: " + busDescriptor_0.ToString());
		}
	}
}
