using System;

// Token: 0x020002D0 RID: 720
public interface IChatServiceWrapper : IServiceWrapper
{
	// Token: 0x06000FE7 RID: 4071
	void imethod_2(OnChat onChat_0, byte byte_0, int int_0, string string_0, string string_1, byte[] byte_1);

	// Token: 0x06000FE8 RID: 4072
	void imethod_3(OnNewChat onNewChat_0);

	// Token: 0x06000FE9 RID: 4073
	void imethod_4(OnNewChat onNewChat_0);

	// Token: 0x06000FEA RID: 4074
	void imethod_5(OnChatOK onChatOK_0);

	// Token: 0x06000FEB RID: 4075
	void imethod_6(OnChatOK onChatOK_0);
}
