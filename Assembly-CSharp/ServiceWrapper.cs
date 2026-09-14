using System;
using ns0;

// Token: 0x020003EB RID: 1003
public abstract class ServiceWrapper<I, T> : ServiceWrapperBase<T> where I : class, IServiceWrapper where T : class, new()
{
	// Token: 0x06001926 RID: 6438 RVA: 0x00012CE8 File Offset: 0x00010EE8
	protected virtual I vmethod_0()
	{
		if (this.m_wrapperSession != null && this.m_wrapperSession.imethod_1())
		{
			return this.m_wrapperSession;
		}
		return this.m_wrapperOnline;
	}

	// Token: 0x06001927 RID: 6439 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void Reset()
	{
	}

	// Token: 0x06001928 RID: 6440 RVA: 0x00083E34 File Offset: 0x00082034
	public virtual void vmethod_1()
	{
		if (this.m_wrapperOnline != null)
		{
			this.m_wrapperOnline.imethod_0();
		}
		if (this.m_wrapperSession != null)
		{
			this.m_wrapperSession.imethod_0();
		}
		if (this.m_wrapperTown != null)
		{
			this.m_wrapperTown.imethod_0();
		}
	}

	// Token: 0x06001929 RID: 6441 RVA: 0x00083E9C File Offset: 0x0008209C
	public virtual bool vmethod_2()
	{
		IServiceWrapper serviceWrapper = this.vmethod_0();
		return serviceWrapper != null && serviceWrapper.imethod_1();
	}

	// Token: 0x0400111F RID: 4383
	protected I m_wrapperOnline;

	// Token: 0x04001120 RID: 4384
	protected I m_wrapperSession;

	// Token: 0x04001121 RID: 4385
	protected I m_wrapperTown;
}
