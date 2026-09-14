using System;

// Token: 0x020004A7 RID: 1191
public class MissionTimer
{
	// Token: 0x06001FE9 RID: 8169 RVA: 0x0001625F File Offset: 0x0001445F
	public double method_0()
	{
		return this.totalDuration - this.method_2();
	}

	// Token: 0x06001FEA RID: 8170 RVA: 0x0001626E File Offset: 0x0001446E
	public double method_1()
	{
		return this.m_timer.method_2();
	}

	// Token: 0x06001FEB RID: 8171 RVA: 0x0001627B File Offset: 0x0001447B
	public double method_2()
	{
		return this.m_timer.method_4();
	}

	// Token: 0x06001FEC RID: 8172 RVA: 0x00016288 File Offset: 0x00014488
	public bool method_3()
	{
		return this.m_timer.method_8();
	}

	// Token: 0x06001FED RID: 8173 RVA: 0x00016295 File Offset: 0x00014495
	public bool method_4()
	{
		return this.m_timer.method_9();
	}

	// Token: 0x06001FEE RID: 8174 RVA: 0x000162A2 File Offset: 0x000144A2
	public void method_5(bool bool_0, double double_0, double double_1, double double_2)
	{
		this.m_timer.method_0(bool_0, double_0, double_1, double_2);
	}

	// Token: 0x0400149C RID: 5276
	private Utils.NetworkTimer m_timer = new Utils.NetworkTimer();

	// Token: 0x0400149D RID: 5277
	private double totalDuration;

	// Token: 0x020004A8 RID: 1192
	public enum EventType
	{
		// Token: 0x0400149F RID: 5279
		Extend,
		// Token: 0x040014A0 RID: 5280
		Pause,
		// Token: 0x040014A1 RID: 5281
		Timeout
	}
}
