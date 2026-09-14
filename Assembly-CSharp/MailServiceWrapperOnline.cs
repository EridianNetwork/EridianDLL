using System;
using System.Collections.Generic;
using ns0;

// Token: 0x02000337 RID: 823
internal class MailServiceWrapperOnline : IMailServiceWrapper, IServiceWrapper
{
	// Token: 0x060014A8 RID: 5288 RVA: 0x000785E8 File Offset: 0x000767E8
	public void imethod_0()
	{
		if (!this.m_isInitializing && !this.m_initialized)
		{
			this.m_isInitializing = true;
			this.m_initialized = true;
			OnAccessSingleton<IMailService, MailService, MailServiceOffline>.Prop_0.imethod_1(null);
			OnAccessSingleton<IMailService, MailService, MailServiceOffline>.Prop_0.imethod_6(new OnNewMail(this.method_0));
			OnAccessSingleton<IMailService, MailService, MailServiceOffline>.Prop_0.imethod_8(new OnGetMailList(this.method_1));
		}
	}

	// Token: 0x060014A9 RID: 5289 RVA: 0x0000F54E File Offset: 0x0000D74E
	protected void method_0(MailInfo mailInfo_0)
	{
		ServiceWrapperBase<MailServiceWrapper>.Instance.OnNewMail(mailInfo_0);
	}

	// Token: 0x060014AA RID: 5290 RVA: 0x0000F55B File Offset: 0x0000D75B
	protected void method_1(List<MailInfo> list_0)
	{
		ServiceWrapperBase<MailServiceWrapper>.Instance.OnGetMailList(list_0);
	}

	// Token: 0x060014AB RID: 5291 RVA: 0x0000F568 File Offset: 0x0000D768
	public void imethod_3(OnGotMailInfo onGotMailInfo_0)
	{
		OnAccessSingleton<IMailService, MailService, MailServiceOffline>.Prop_0.imethod_1(onGotMailInfo_0);
	}

	// Token: 0x060014AC RID: 5292 RVA: 0x0000F575 File Offset: 0x0000D775
	public void imethod_2(OnSendMail onSendMail_0, string string_0, string string_1)
	{
		OnAccessSingleton<IMailService, MailService, MailServiceOffline>.Prop_0.imethod_2(onSendMail_0, string_0, string_1);
	}

	// Token: 0x060014AD RID: 5293 RVA: 0x0000F584 File Offset: 0x0000D784
	public void imethod_4(OnReadMail onReadMail_0, int int_0)
	{
		OnAccessSingleton<IMailService, MailService, MailServiceOffline>.Prop_0.imethod_3(onReadMail_0, int_0);
	}

	// Token: 0x060014AE RID: 5294 RVA: 0x0000F592 File Offset: 0x0000D792
	public void imethod_5(OnGetMailItem onGetMailItem_0, int int_0)
	{
		OnAccessSingleton<IMailService, MailService, MailServiceOffline>.Prop_0.imethod_4(onGetMailItem_0, int_0);
	}

	// Token: 0x060014AF RID: 5295 RVA: 0x0000F5A0 File Offset: 0x0000D7A0
	public void imethod_6(OnDeleteMail onDeleteMail_0, int int_0)
	{
		OnAccessSingleton<IMailService, MailService, MailServiceOffline>.Prop_0.imethod_5(onDeleteMail_0, int_0);
	}

	// Token: 0x060014B0 RID: 5296 RVA: 0x0000F5AE File Offset: 0x0000D7AE
	public bool imethod_1()
	{
		return this.m_initialized;
	}

	// Token: 0x04000E6F RID: 3695
	private bool m_isInitializing;

	// Token: 0x04000E70 RID: 3696
	private bool m_initialized;
}
