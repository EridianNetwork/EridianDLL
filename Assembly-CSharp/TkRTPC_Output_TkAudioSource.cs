using System;

// Token: 0x02000114 RID: 276
public class TkRTPC_Output_TkAudioSource : TkRTPC_OutputComponent
{
	// Token: 0x17000042 RID: 66
	// (get) Token: 0x0600062F RID: 1583 RVA: 0x00007303 File Offset: 0x00005503
	private TkAudioSource TkAudioSource_0
	{
		get
		{
			if (!this.m_source)
			{
				this.m_source = base.gameObject.GetComponent<TkAudioSource>();
			}
			return this.m_source;
		}
	}

	// Token: 0x06000630 RID: 1584 RVA: 0x00007329 File Offset: 0x00005529
	[TkRTPC_Output_Mul(1f, 0f, 1f)]
	private void method_7(float float_0)
	{
		if (this.TkAudioSource_0)
		{
			this.TkAudioSource_0.m_volume = float_0;
		}
	}

	// Token: 0x06000631 RID: 1585 RVA: 0x00007344 File Offset: 0x00005544
	[TkRTPC_Output_Mul(1f, 0f, 1f)]
	private void method_8(float float_0)
	{
		if (this.TkAudioSource_0)
		{
			this.TkAudioSource_0.m_volumeRandomRange = float_0;
		}
	}

	// Token: 0x06000632 RID: 1586 RVA: 0x0000735F File Offset: 0x0000555F
	[TkRTPC_Output_Mul(5f, 0f, 5f)]
	private void method_9(float float_0)
	{
		if (this.TkAudioSource_0)
		{
			this.TkAudioSource_0.m_pitch = float_0;
		}
	}

	// Token: 0x06000633 RID: 1587 RVA: 0x0000737A File Offset: 0x0000557A
	[TkRTPC_Output_Add(5f, 0f, 5f)]
	private void method_10(float float_0)
	{
		if (this.TkAudioSource_0)
		{
			this.TkAudioSource_0.m_pitchRandomRange = float_0;
		}
	}

	// Token: 0x06000634 RID: 1588 RVA: 0x00007395 File Offset: 0x00005595
	[TkRTPC_Output_Add(1f, -1f, 1f)]
	private void method_11(float float_0)
	{
		if (this.TkAudioSource_0)
		{
			this.TkAudioSource_0.m_pan = float_0;
		}
	}

	// Token: 0x06000635 RID: 1589 RVA: 0x000073B0 File Offset: 0x000055B0
	[TkRTPC_Output_Mul(1f, 0f, 1f)]
	private void method_12(float float_0)
	{
		if (this.TkAudioSource_0)
		{
			this.TkAudioSource_0.m_panRandomRange = float_0;
		}
	}

	// Token: 0x06000636 RID: 1590 RVA: 0x000073CB File Offset: 0x000055CB
	[TkRTPC_Output_Add(5f, 0f, 5f)]
	private void method_13(float float_0)
	{
		if (this.TkAudioSource_0)
		{
			this.TkAudioSource_0.m_delay = float_0;
		}
	}

	// Token: 0x06000637 RID: 1591 RVA: 0x000073E6 File Offset: 0x000055E6
	[TkRTPC_Output_Add(5f, 0f, 5f)]
	private void method_14(float float_0)
	{
		if (this.TkAudioSource_0)
		{
			this.TkAudioSource_0.m_delayRandomRange = float_0;
		}
	}

	// Token: 0x040005AA RID: 1450
	private TkAudioSource m_source;
}
