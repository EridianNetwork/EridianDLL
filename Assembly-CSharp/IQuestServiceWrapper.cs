using System;
using System.Collections.Generic;

// Token: 0x02000340 RID: 832
public interface IQuestServiceWrapper : IServiceWrapper
{
	// Token: 0x060014FB RID: 5371
	void imethod_2(int int_0, byte[] byte_0);

	// Token: 0x060014FC RID: 5372
	void imethod_3(int int_0);

	// Token: 0x060014FD RID: 5373
	Dictionary<int, QuestProgress> imethod_4();

	// Token: 0x060014FE RID: 5374
	void imethod_5();

	// Token: 0x060014FF RID: 5375
	void imethod_6(int int_0, int int_1);

	// Token: 0x06001500 RID: 5376
	void imethod_7(TalkToNPCCallback talkToNPCCallback_0, int int_0, int int_1);

	// Token: 0x06001501 RID: 5377
	void imethod_8(BringToNPCCallback bringToNPCCallback_0, int int_0, int int_1);

	// Token: 0x06001502 RID: 5378
	void imethod_9(int int_0, int int_1);
}
