using System;
using System.Collections.Generic;

// Token: 0x02000330 RID: 816
internal class SkillTreeServiceOffline : ISkillTreeService
{
	// Token: 0x0600145E RID: 5214 RVA: 0x0000F396 File Offset: 0x0000D596
	public void imethod_0(GetSkillPointsCallback getSkillPointsCallback_0)
	{
		getSkillPointsCallback_0(0, 0, 0, null);
	}

	// Token: 0x0600145F RID: 5215 RVA: 0x0000F3A2 File Offset: 0x0000D5A2
	public void imethod_6(int int_0, GetInvestedSkillPointsCallback getInvestedSkillPointsCallback_0)
	{
		getInvestedSkillPointsCallback_0(int_0, new List<InvestedSkill>());
	}

	// Token: 0x06001460 RID: 5216 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_1(int int_0, InvestSkillPointCallback investSkillPointCallback_0)
	{
	}

	// Token: 0x06001461 RID: 5217 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_2(List<InvestedSkill> list_0, InvestMultipleSkillPointsCallback investMultipleSkillPointsCallback_0)
	{
	}

	// Token: 0x06001462 RID: 5218 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_3(ResetSkillPointsCallback resetSkillPointsCallback_0)
	{
	}

	// Token: 0x06001463 RID: 5219 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_4(SkillPointEarnedCallback skillPointEarnedCallback_0)
	{
	}

	// Token: 0x06001464 RID: 5220 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_5(SkillPointEarnedCallback skillPointEarnedCallback_0)
	{
	}
}
