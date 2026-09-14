using System;
using System.Collections.Generic;

// Token: 0x020002FA RID: 762
public interface IProgressionService
{
	// Token: 0x060011BC RID: 4540
	void imethod_0(GetUnlockedInstancesCallback getUnlockedInstancesCallback_0 = null);

	// Token: 0x060011BD RID: 4541
	Dictionary<int, int> imethod_1();

	// Token: 0x060011BE RID: 4542
	void imethod_2(InstanceInfo instanceInfo_0);

	// Token: 0x060011BF RID: 4543
	void imethod_3(InstanceUnlockedCallback instanceUnlockedCallback_0);

	// Token: 0x060011C0 RID: 4544
	void imethod_4(InstanceUnlockedCallback instanceUnlockedCallback_0);
}
