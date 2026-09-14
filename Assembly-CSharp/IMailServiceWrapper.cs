using System;

// Token: 0x02000334 RID: 820
public interface IMailServiceWrapper : IServiceWrapper
{
	// Token: 0x06001486 RID: 5254
	void imethod_2(OnSendMail onSendMail_0, string string_0, string string_1);

	// Token: 0x06001487 RID: 5255
	void imethod_3(OnGotMailInfo onGotMailInfo_0);

	// Token: 0x06001488 RID: 5256
	void imethod_4(OnReadMail onReadMail_0, int int_0);

	// Token: 0x06001489 RID: 5257
	void imethod_5(OnGetMailItem onGetMailItem_0, int int_0);

	// Token: 0x0600148A RID: 5258
	void imethod_6(OnDeleteMail onDeleteMail_0, int int_0);
}
