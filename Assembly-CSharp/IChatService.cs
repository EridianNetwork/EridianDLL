using System;

// Token: 0x020002EB RID: 747
internal interface IChatService
{
	// Token: 0x06001109 RID: 4361
	void imethod_0();

	// Token: 0x0600110A RID: 4362
	void imethod_1(OnChat onChat_0, byte byte_0, int int_0, string string_0, string string_1, byte[] byte_1);

	// Token: 0x0600110B RID: 4363
	void imethod_2(OnNewChat onNewChat_0);

	// Token: 0x0600110C RID: 4364
	void imethod_3(OnNewChat onNewChat_0);

	// Token: 0x0600110D RID: 4365
	void imethod_4(OnChatOK onChatOK_0);

	// Token: 0x0600110E RID: 4366
	void imethod_5(OnChatOK onChatOK_0);
}
