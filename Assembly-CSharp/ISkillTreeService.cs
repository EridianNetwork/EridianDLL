using System;
using System.Collections.Generic;

// Token: 0x02000303 RID: 771
internal interface ISkillTreeService
{
	// Token: 0x060011F6 RID: 4598
	void imethod_0(GetSkillPointsCallback getSkillPointsCallback_0);

	// Token: 0x060011F7 RID: 4599
	void imethod_1(int int_0, InvestSkillPointCallback investSkillPointCallback_0);

	// Token: 0x060011F8 RID: 4600
	void imethod_2(List<InvestedSkill> list_0, InvestMultipleSkillPointsCallback investMultipleSkillPointsCallback_0);

	// Token: 0x060011F9 RID: 4601
	void imethod_3(ResetSkillPointsCallback resetSkillPointsCallback_0);

	// Token: 0x060011FA RID: 4602
	void imethod_4(SkillPointEarnedCallback skillPointEarnedCallback_0);

	// Token: 0x060011FB RID: 4603
	void imethod_5(SkillPointEarnedCallback skillPointEarnedCallback_0);

	// Token: 0x060011FC RID: 4604
	void imethod_6(int int_0, GetInvestedSkillPointsCallback getInvestedSkillPointsCallback_0);
}
