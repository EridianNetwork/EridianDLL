using System;
using XsdSettings;

// Token: 0x02000327 RID: 807
internal class LuckyBoxServiceOffline : ILuckyBoxService
{
	// Token: 0x0600140F RID: 5135 RVA: 0x0000F29E File Offset: 0x0000D49E
	public void imethod_0(OnLuckyBoxOpened onLuckyBoxOpened_0, int int_0, bool bool_0)
	{
		if (onLuckyBoxOpened_0 != null)
		{
			onLuckyBoxOpened_0(false, 0, null, null, null);
		}
	}

	// Token: 0x06001410 RID: 5136 RVA: 0x0000F2AE File Offset: 0x0000D4AE
	public void method_0(OnLuckyBoxAwarded onLuckyBoxAwarded_0, int int_0, int int_1, ELevelDifficulty elevelDifficulty_0, InstanceGrade instanceGrade_0, int int_2)
	{
		if (onLuckyBoxAwarded_0 != null)
		{
			onLuckyBoxAwarded_0(false);
		}
	}
}
