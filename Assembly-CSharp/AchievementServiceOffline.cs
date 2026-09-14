using System;

// Token: 0x0200031A RID: 794
public class AchievementServiceOffline : IAchievementService
{
	// Token: 0x06001334 RID: 4916 RVA: 0x0000EEE3 File Offset: 0x0000D0E3
	public void imethod_0(GetAchievementsCallback getAchievementsCallback_0, int int_0)
	{
		if (getAchievementsCallback_0 != null)
		{
			getAchievementsCallback_0(0, null);
		}
	}

	// Token: 0x06001335 RID: 4917 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_1(OnAchievementUpdated onAchievementUpdated_0)
	{
	}

	// Token: 0x06001336 RID: 4918 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_2(OnAchievementUpdated onAchievementUpdated_0)
	{
	}

	// Token: 0x06001337 RID: 4919 RVA: 0x0000EEF0 File Offset: 0x0000D0F0
	public void method_0(UpdateAchievementCallback updateAchievementCallback_0, int int_0, int int_1, int int_2)
	{
		if (updateAchievementCallback_0 != null)
		{
			updateAchievementCallback_0(false);
		}
	}
}
