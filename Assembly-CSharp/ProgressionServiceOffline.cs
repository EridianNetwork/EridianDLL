using System;
using System.Collections.Generic;

// Token: 0x0200032C RID: 812
public class ProgressionServiceOffline : IProgressionService
{
	// Token: 0x06001432 RID: 5170 RVA: 0x0000F302 File Offset: 0x0000D502
	public void imethod_0(GetUnlockedInstancesCallback getUnlockedInstancesCallback_0 = null)
	{
		if (getUnlockedInstancesCallback_0 != null)
		{
			getUnlockedInstancesCallback_0(new Dictionary<int, int>());
		}
	}

	// Token: 0x06001433 RID: 5171 RVA: 0x0000F312 File Offset: 0x0000D512
	public Dictionary<int, int> imethod_1()
	{
		return new Dictionary<int, int>();
	}

	// Token: 0x06001434 RID: 5172 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_2(InstanceInfo instanceInfo_0)
	{
	}

	// Token: 0x06001435 RID: 5173 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_3(InstanceUnlockedCallback instanceUnlockedCallback_0)
	{
	}

	// Token: 0x06001436 RID: 5174 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_4(InstanceUnlockedCallback instanceUnlockedCallback_0)
	{
	}

	// Token: 0x06001437 RID: 5175 RVA: 0x0000311B File Offset: 0x0000131B
	public void method_0(int int_0, int int_1)
	{
	}

	// Token: 0x06001438 RID: 5176 RVA: 0x0000311B File Offset: 0x0000131B
	public void method_1(int int_0, int int_1, int int_2)
	{
	}
}
