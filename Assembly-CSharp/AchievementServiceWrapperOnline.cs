using System;
using ns0;

// Token: 0x020002C6 RID: 710
public class AchievementServiceWrapperOnline : IAchievementServiceWrapper, IServiceWrapper
{
	// Token: 0x06000F46 RID: 3910 RVA: 0x0000D3D4 File Offset: 0x0000B5D4
	public void imethod_0()
	{
		OnAccessSingleton<IAchievementService, AchievementService, AchievementServiceOffline>.Prop_0.imethod_1(new OnAchievementUpdated(ServiceWrapperBase<AchievementServiceWrapper>.Instance.OnAchievementUpdated));
		this.m_initialized = true;
	}

	// Token: 0x06000F47 RID: 3911 RVA: 0x0000D3F7 File Offset: 0x0000B5F7
	public bool imethod_1()
	{
		return this.m_initialized;
	}

	// Token: 0x06000F48 RID: 3912 RVA: 0x0000D3FF File Offset: 0x0000B5FF
	public void imethod_2(GetAchievementsCallback getAchievementsCallback_0, int int_0)
	{
		OnAccessSingleton<IAchievementService, AchievementService, AchievementServiceOffline>.Prop_0.imethod_0(getAchievementsCallback_0, int_0);
	}

	// Token: 0x04000D81 RID: 3457
	private bool m_initialized;
}
