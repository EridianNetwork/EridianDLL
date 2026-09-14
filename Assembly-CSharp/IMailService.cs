using System;

// Token: 0x020002F6 RID: 758
public interface IMailService
{
	// Token: 0x060011A2 RID: 4514
	void imethod_0();

	// Token: 0x060011A3 RID: 4515
	void imethod_1(OnGotMailInfo onGotMailInfo_0);

	// Token: 0x060011A4 RID: 4516
	void imethod_2(OnSendMail onSendMail_0, string string_0, string string_1);

	// Token: 0x060011A5 RID: 4517
	void imethod_3(OnReadMail onReadMail_0, int int_0);

	// Token: 0x060011A6 RID: 4518
	void imethod_4(OnGetMailItem onGetMailItem_0, int int_0);

	// Token: 0x060011A7 RID: 4519
	void imethod_5(OnDeleteMail onDeleteMail_0, int int_0);

	// Token: 0x060011A8 RID: 4520
	void imethod_6(OnNewMail onNewMail_0);

	// Token: 0x060011A9 RID: 4521
	void imethod_7(OnNewMail onNewMail_0);

	// Token: 0x060011AA RID: 4522
	void imethod_8(OnGetMailList onGetMailList_0);

	// Token: 0x060011AB RID: 4523
	void imethod_9(OnGetMailList onGetMailList_0);
}
