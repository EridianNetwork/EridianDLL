using System;
using System.Collections.Generic;

// Token: 0x02000344 RID: 836
public class QuestServiceWrapperSession : IQuestServiceWrapper, IServiceWrapper
{
	// Token: 0x06001545 RID: 5445 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_0()
	{
	}

	// Token: 0x06001546 RID: 5446 RVA: 0x000039EC File Offset: 0x00001BEC
	public bool imethod_1()
	{
		return true;
	}

	// Token: 0x06001547 RID: 5447 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_2(int int_0, byte[] byte_0)
	{
	}

	// Token: 0x06001548 RID: 5448 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_3(int int_0)
	{
	}

	// Token: 0x06001549 RID: 5449 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_5()
	{
	}

	// Token: 0x0600154A RID: 5450 RVA: 0x00003727 File Offset: 0x00001927
	public Dictionary<int, QuestProgress> imethod_4()
	{
		return null;
	}

	// Token: 0x0600154B RID: 5451 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_6(int int_0, int int_1)
	{
	}

	// Token: 0x0600154C RID: 5452 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_7(TalkToNPCCallback talkToNPCCallback_0, int int_0, int int_1)
	{
	}

	// Token: 0x0600154D RID: 5453 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_8(BringToNPCCallback bringToNPCCallback_0, int int_0, int int_1)
	{
	}

	// Token: 0x0600154E RID: 5454 RVA: 0x0000F919 File Offset: 0x0000DB19
	public void imethod_9(int int_0, int int_1)
	{
		OnAccessSingleton<IQuestService, QuestService, QuestServiceOffline>.Prop_0.imethod_21(int_0, int_1);
	}
}
