using System;

// Token: 0x0200031D RID: 797
internal class ChatServiceOffline : IChatService
{
	// Token: 0x0600135F RID: 4959 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_0()
	{
	}

	// Token: 0x06001360 RID: 4960 RVA: 0x0000EF3C File Offset: 0x0000D13C
	public void imethod_1(OnChat onChat_0, byte byte_0, int int_0, string string_0, string string_1, byte[] byte_1)
	{
		if (onChat_0 != null)
		{
			onChat_0(-1);
		}
	}

	// Token: 0x06001361 RID: 4961 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_2(OnNewChat onNewChat_0)
	{
	}

	// Token: 0x06001362 RID: 4962 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_3(OnNewChat onNewChat_0)
	{
	}

	// Token: 0x06001363 RID: 4963 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_4(OnChatOK onChatOK_0)
	{
	}

	// Token: 0x06001364 RID: 4964 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_5(OnChatOK onChatOK_0)
	{
	}
}
