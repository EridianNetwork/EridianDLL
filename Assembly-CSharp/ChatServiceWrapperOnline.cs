using System;

// Token: 0x020002D2 RID: 722
public class ChatServiceWrapperOnline : IChatServiceWrapper, IServiceWrapper
{
	// Token: 0x06000FF4 RID: 4084 RVA: 0x0000D9C4 File Offset: 0x0000BBC4
	public void imethod_2(OnChat onChat_0, byte byte_0, int int_0, string string_0, string string_1, byte[] byte_1)
	{
		OnAccessSingleton<IChatService, ChatService, ChatServiceOffline>.Prop_0.imethod_1(onChat_0, byte_0, int_0, string_0, string_1, byte_1);
	}

	// Token: 0x06000FF5 RID: 4085 RVA: 0x0000D9D9 File Offset: 0x0000BBD9
	public void imethod_3(OnNewChat onNewChat_0)
	{
		OnAccessSingleton<IChatService, ChatService, ChatServiceOffline>.Prop_0.imethod_2(onNewChat_0);
	}

	// Token: 0x06000FF6 RID: 4086 RVA: 0x0000D9E6 File Offset: 0x0000BBE6
	public void imethod_4(OnNewChat onNewChat_0)
	{
		OnAccessSingleton<IChatService, ChatService, ChatServiceOffline>.Prop_0.imethod_3(onNewChat_0);
	}

	// Token: 0x06000FF7 RID: 4087 RVA: 0x0000D9F3 File Offset: 0x0000BBF3
	public void imethod_5(OnChatOK onChatOK_0)
	{
		OnAccessSingleton<IChatService, ChatService, ChatServiceOffline>.Prop_0.imethod_4(onChatOK_0);
	}

	// Token: 0x06000FF8 RID: 4088 RVA: 0x0000DA00 File Offset: 0x0000BC00
	public void imethod_6(OnChatOK onChatOK_0)
	{
		OnAccessSingleton<IChatService, ChatService, ChatServiceOffline>.Prop_0.imethod_5(onChatOK_0);
	}

	// Token: 0x06000FF9 RID: 4089 RVA: 0x0000DA0D File Offset: 0x0000BC0D
	public void imethod_0()
	{
		this.m_initialized = true;
		OnAccessSingleton<IChatService, ChatService, ChatServiceOffline>.Prop_0.imethod_0();
	}

	// Token: 0x06000FFA RID: 4090 RVA: 0x0000DA20 File Offset: 0x0000BC20
	public bool imethod_1()
	{
		return this.m_initialized;
	}

	// Token: 0x04000DB8 RID: 3512
	private bool m_initialized;
}
