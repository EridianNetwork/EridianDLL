using System;

// Token: 0x020002F8 RID: 760
internal interface IMessagingService
{
	// Token: 0x060011AD RID: 4525
	void imethod_0(int int_0, string string_0, int int_1 = 0);

	// Token: 0x060011AE RID: 4526
	void imethod_1(int int_0, string string_0, string string_1, int int_1 = 0);

	// Token: 0x060011AF RID: 4527
	void imethod_2(OnRetrieveMessages onRetrieveMessages_0, string string_0, bool bool_0, int int_0 = 1, int int_1 = 50);

	// Token: 0x060011B0 RID: 4528
	void imethod_3(int int_0);

	// Token: 0x060011B1 RID: 4529
	void imethod_4(int int_0);

	// Token: 0x060011B2 RID: 4530
	void imethod_5(string string_0, OnRecieveMessage onRecieveMessage_0);

	// Token: 0x060011B3 RID: 4531
	void imethod_6(string string_0);
}
