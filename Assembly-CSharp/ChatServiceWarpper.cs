using System;

// Token: 0x020002D1 RID: 721
internal class ChatServiceWarpper : ServiceWrapper<IChatServiceWrapper, ChatServiceWarpper>
{
	// Token: 0x06000FED RID: 4077 RVA: 0x0000D963 File Offset: 0x0000BB63
	public override void vmethod_1()
	{
		this.m_wrapperOnline = new ChatServiceWrapperOnline();
		base.vmethod_1();
	}

	// Token: 0x06000FEE RID: 4078 RVA: 0x0000D976 File Offset: 0x0000BB76
	public void method_0(OnChat onChat_0, byte byte_0, int int_0, string string_0, string string_1, byte[] byte_1)
	{
		this.m_wrapperOnline.imethod_2(onChat_0, byte_0, int_0, string_0, string_1, byte_1);
	}

	// Token: 0x06000FEF RID: 4079 RVA: 0x0000D98C File Offset: 0x0000BB8C
	public void method_1(OnNewChat onNewChat_0)
	{
		this.m_wrapperOnline.imethod_3(onNewChat_0);
	}

	// Token: 0x06000FF0 RID: 4080 RVA: 0x0000D99A File Offset: 0x0000BB9A
	public void method_2(OnNewChat onNewChat_0)
	{
		this.m_wrapperOnline.imethod_4(onNewChat_0);
	}

	// Token: 0x06000FF1 RID: 4081 RVA: 0x0000D9A8 File Offset: 0x0000BBA8
	public void method_3(OnChatOK onChatOK_0)
	{
		this.m_wrapperOnline.imethod_5(onChatOK_0);
	}

	// Token: 0x06000FF2 RID: 4082 RVA: 0x0000D9B6 File Offset: 0x0000BBB6
	public void method_4(OnChatOK onChatOK_0)
	{
		this.m_wrapperOnline.imethod_6(onChatOK_0);
	}
}
