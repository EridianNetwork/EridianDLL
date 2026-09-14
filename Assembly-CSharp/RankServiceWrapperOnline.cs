using System;

// Token: 0x02000347 RID: 839
public class RankServiceWrapperOnline : IRankServiceWrapper, IServiceWrapper
{
	// Token: 0x06001554 RID: 5460 RVA: 0x0000F954 File Offset: 0x0000DB54
	public bool imethod_1()
	{
		return this.m_initialized;
	}

	// Token: 0x06001555 RID: 5461 RVA: 0x0000F95C File Offset: 0x0000DB5C
	public void imethod_0()
	{
		if (!this.m_isInitializing && !this.m_initialized)
		{
			this.m_isInitializing = true;
			this.m_initialized = true;
		}
	}

	// Token: 0x06001556 RID: 5462 RVA: 0x0000F97C File Offset: 0x0000DB7C
	public void imethod_2(GetRankingCallback getRankingCallback_0, int int_0, int int_1, int int_2)
	{
		OnAccessSingleton<IRankService, RankService, RankServiceOffline>.Prop_0.imethod_0(getRankingCallback_0, int_0, int_1, int_2);
	}

	// Token: 0x04000E89 RID: 3721
	private bool m_isInitializing;

	// Token: 0x04000E8A RID: 3722
	private bool m_initialized;
}
