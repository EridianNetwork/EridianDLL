using System;
using System.Collections.Generic;

// Token: 0x020002C5 RID: 709
public class AchievementServiceWrapper : ServiceWrapper<IAchievementServiceWrapper, AchievementServiceWrapper>
{
	// Token: 0x06000F40 RID: 3904 RVA: 0x0000D395 File Offset: 0x0000B595
	public void method_0(IAchievementServiceNotificationListerner iachievementServiceNotificationListerner_0)
	{
		this.m_listerner.Add(iachievementServiceNotificationListerner_0);
	}

	// Token: 0x06000F41 RID: 3905 RVA: 0x0000D3A3 File Offset: 0x0000B5A3
	public void method_1(IAchievementServiceNotificationListerner iachievementServiceNotificationListerner_0)
	{
		this.m_listerner.Remove(iachievementServiceNotificationListerner_0);
	}

	// Token: 0x06000F42 RID: 3906 RVA: 0x0000D3B2 File Offset: 0x0000B5B2
	public override void vmethod_1()
	{
		this.m_wrapperOnline = new AchievementServiceWrapperOnline();
		base.vmethod_1();
	}

	// Token: 0x06000F43 RID: 3907 RVA: 0x0000D3C5 File Offset: 0x0000B5C5
	public void method_2(GetAchievementsCallback getAchievementsCallback_0, int int_0)
	{
		this.vmethod_0().imethod_2(getAchievementsCallback_0, int_0);
	}

	// Token: 0x06000F44 RID: 3908 RVA: 0x00074C48 File Offset: 0x00072E48
	public void OnAchievementUpdated(Achievement newAchievement)
	{
		for (int i = 0; i < this.m_listerner.Count; i++)
		{
			this.m_listerner[i].OnAchievementUpdated(newAchievement);
		}
	}

	// Token: 0x04000D80 RID: 3456
	private List<IAchievementServiceNotificationListerner> m_listerner = new List<IAchievementServiceNotificationListerner>();
}
