using System;

// Token: 0x0200032A RID: 810
public class MessagingServiceOffline : IMessagingService
{
	// Token: 0x0600141F RID: 5151 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_0(int int_0, string string_0, int int_1 = 0)
	{
	}

	// Token: 0x06001420 RID: 5152 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_1(int int_0, string string_0, string string_1, int int_1 = 0)
	{
	}

	// Token: 0x06001421 RID: 5153 RVA: 0x0000F2C6 File Offset: 0x0000D4C6
	public void imethod_2(OnRetrieveMessages onRetrieveMessages_0, string string_0, bool bool_0, int int_0 = 1, int int_1 = 50)
	{
		if (onRetrieveMessages_0 != null)
		{
			onRetrieveMessages_0(null);
		}
	}

	// Token: 0x06001422 RID: 5154 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_3(int int_0)
	{
	}

	// Token: 0x06001423 RID: 5155 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_4(int int_0)
	{
	}

	// Token: 0x06001424 RID: 5156 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_5(string string_0, OnRecieveMessage onRecieveMessage_0)
	{
	}

	// Token: 0x06001425 RID: 5157 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_6(string string_0)
	{
	}
}
