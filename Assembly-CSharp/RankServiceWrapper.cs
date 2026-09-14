using System;

// Token: 0x02000346 RID: 838
public class RankServiceWrapper : ServiceWrapper<IRankServiceWrapper, RankServiceWrapper>
{
	// Token: 0x06001551 RID: 5457 RVA: 0x0000F92F File Offset: 0x0000DB2F
	public override void vmethod_1()
	{
		this.m_wrapperOnline = new RankServiceWrapperOnline();
		base.vmethod_1();
	}

	// Token: 0x06001552 RID: 5458 RVA: 0x0000F942 File Offset: 0x0000DB42
	public void method_0(GetRankingCallback getRankingCallback_0, int int_0, int int_1, int int_2)
	{
		this.vmethod_0().imethod_2(getRankingCallback_0, int_0, int_1, int_2);
	}
}
