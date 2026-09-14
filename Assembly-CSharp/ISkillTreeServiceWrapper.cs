using System;
using System.Collections.Generic;

// Token: 0x020003F0 RID: 1008
public interface ISkillTreeServiceWrapper : IServiceWrapper
{
	// Token: 0x06001954 RID: 6484
	void imethod_2(GetSkillPointsCallback getSkillPointsCallback_0);

	// Token: 0x06001955 RID: 6485
	void imethod_3(GetInvestedSkillPointsCallback getInvestedSkillPointsCallback_0);

	// Token: 0x06001956 RID: 6486
	void imethod_4(int int_0);

	// Token: 0x06001957 RID: 6487
	void imethod_5(List<InvestedSkill> list_0);

	// Token: 0x06001958 RID: 6488
	void imethod_6();
}
