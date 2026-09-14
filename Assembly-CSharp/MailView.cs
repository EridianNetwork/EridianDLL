using System;
using System.Collections.Generic;
using ns0;

// Token: 0x02000715 RID: 1813
public class MailView : BaseView, IMailServiceNotificationListener
{
	// Token: 0x06003012 RID: 12306 RVA: 0x0001F81E File Offset: 0x0001DA1E
	public override void vmethod_2()
	{
		base.vmethod_2();
		MonoSingleton<AppManager>.Instance.method_0().method_6(this);
		this._mailInfoList = ServiceWrapperBase<MailServiceWrapper>.Instance.method_0();
		ServiceWrapperBase<MailServiceWrapper>.Instance.method_1(this);
	}

	// Token: 0x06003013 RID: 12307 RVA: 0x0001F851 File Offset: 0x0001DA51
	public override void vmethod_3()
	{
		base.vmethod_3();
		MonoSingleton<AppManager>.Instance.method_0().method_7(this);
		ServiceWrapperBase<MailServiceWrapper>.Instance.method_3(this);
	}

	// Token: 0x06003014 RID: 12308 RVA: 0x0001F874 File Offset: 0x0001DA74
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		base.vmethod_1(bool_0, bool_1);
		if (!bool_0)
		{
			NPC_UIFlowController.smethod_0().method_3(NPC_UIFlowController.NPC_UIFlowState.None);
		}
		MonoSingleton<AppManager>.Instance.method_0().Boolean_2 = !bool_0;
	}

	// Token: 0x06003015 RID: 12309 RVA: 0x0001E0F3 File Offset: 0x0001C2F3
	public override bool vmethod_4()
	{
		if (this.Boolean_1)
		{
			this.Boolean_1 = false;
			return true;
		}
		return base.vmethod_4();
	}

	// Token: 0x06003016 RID: 12310 RVA: 0x0001F89F File Offset: 0x0001DA9F
	protected virtual void vmethod_5()
	{
		this._mailInfoList = ServiceWrapperBase<MailServiceWrapper>.Instance.method_0();
	}

	// Token: 0x06003017 RID: 12311 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void vmethod_6(MailView.MailAnimaState mailAnimaState_0)
	{
	}

	// Token: 0x06003018 RID: 12312 RVA: 0x000DB920 File Offset: 0x000D9B20
	protected void method_3(MailInfo mailInfo_0)
	{
		MenuItemDef[] array = new MenuItemDef[2];
		array[0].itemTitle = LocalizedString.smethod_0(new LocalizedString("MAIL_OPEN"));
		array[0].itemData = mailInfo_0;
		array[0].itemFunc = new MenuItemProcessFunc(this.vmethod_7);
		array[1].itemTitle = LocalizedString.smethod_0(new LocalizedString("MAIL_DELETE"));
		array[1].itemData = mailInfo_0;
		array[1].itemFunc = new MenuItemProcessFunc(this.method_4);
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<PopupMenuView>().method_3(array);
	}

	// Token: 0x06003019 RID: 12313 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void vmethod_7(object object_0)
	{
	}

	// Token: 0x0600301A RID: 12314 RVA: 0x000DB9CC File Offset: 0x000D9BCC
	protected void method_4(object object_0)
	{
		MailInfo mailInfo = object_0 as MailInfo;
		if (mailInfo != null)
		{
			this.vmethod_10(mailInfo.MailID);
		}
	}

	// Token: 0x0600301B RID: 12315 RVA: 0x0001F8B1 File Offset: 0x0001DAB1
	protected virtual void vmethod_8(MailView.NewMailInfoContainer newMailInfoContainer_0)
	{
		this._onSendingMail = newMailInfoContainer_0;
		if (newMailInfoContainer_0.StrReceiverNickName != null && newMailInfoContainer_0.StrMailContent != null)
		{
			ServiceWrapperBase<MailServiceWrapper>.Instance.method_9(newMailInfoContainer_0.StrReceiverNickName, newMailInfoContainer_0.StrMailContent);
		}
	}

	// Token: 0x0600301C RID: 12316 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void vmethod_9(MailInfo mailInfo_0)
	{
	}

	// Token: 0x0600301D RID: 12317 RVA: 0x0001F8E0 File Offset: 0x0001DAE0
	protected virtual void vmethod_10(int int_0)
	{
		ServiceWrapperBase<MailServiceWrapper>.Instance.method_11(int_0);
	}

	// Token: 0x0600301E RID: 12318 RVA: 0x0001F8ED File Offset: 0x0001DAED
	protected virtual void vmethod_11(MailInfo mailInfo_0)
	{
		if (mailInfo_0.Mailstate == MailState.Unread)
		{
			ServiceWrapperBase<MailServiceWrapper>.Instance.method_10(mailInfo_0.MailID);
		}
	}

	// Token: 0x0600301F RID: 12319 RVA: 0x0001F907 File Offset: 0x0001DB07
	protected virtual void vmethod_12(MailInfo mailInfo_0)
	{
		if (mailInfo_0 != null && mailInfo_0.Item != null)
		{
			if (!ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_39(mailInfo_0.Item.mItem))
			{
				ServiceWrapperBase<MailServiceWrapper>.Instance.method_12(mailInfo_0.MailID);
			}
			return;
		}
	}

	// Token: 0x06003020 RID: 12320 RVA: 0x0001F93C File Offset: 0x0001DB3C
	public void OnGetNewMail(MailInfo newmail)
	{
		this.vmethod_5();
	}

	// Token: 0x06003021 RID: 12321 RVA: 0x0001F93C File Offset: 0x0001DB3C
	public void OnGetPlayerMail(List<MailInfo> mailList)
	{
		this.vmethod_5();
	}

	// Token: 0x06003022 RID: 12322 RVA: 0x0001F93C File Offset: 0x0001DB3C
	public void OnGetMailList(List<MailInfo> mailInfoList)
	{
		this.vmethod_5();
	}

	// Token: 0x06003023 RID: 12323 RVA: 0x000DB9F0 File Offset: 0x000D9BF0
	public void OnSendMail(int iResult)
	{
		switch (iResult)
		{
		case 32737:
		case 32738:
		case 32739:
			MonoSingleton<global::ns0.EchoMessageManager>.Instance.method_8("81006");
			break;
		case 32740:
			if (this._onSendingMail != null)
			{
				if (this._onSendingMail.StrReceiverNickName == MonoSingleton<Session>.Instance.GetLocalPlayer().m_name)
				{
					MonoSingleton<global::ns0.EchoMessageManager>.Instance.method_8("81011");
				}
				else
				{
					MonoSingleton<global::ns0.EchoMessageManager>.Instance.method_8("81010");
				}
			}
			break;
		default:
			MonoSingleton<global::ns0.EchoMessageManager>.Instance.method_8("81005");
			this.vmethod_13();
			break;
		}
		this.vmethod_5();
	}

	// Token: 0x06003024 RID: 12324 RVA: 0x0001F93C File Offset: 0x0001DB3C
	public void OnReadMail(int mailID)
	{
		this.vmethod_5();
	}

	// Token: 0x06003025 RID: 12325 RVA: 0x0001F93C File Offset: 0x0001DB3C
	public void OnDeleteMail(int mailID)
	{
		this.vmethod_5();
	}

	// Token: 0x06003026 RID: 12326 RVA: 0x0001F944 File Offset: 0x0001DB44
	public void OnGetmailItem(short result, int mailID)
	{
		if (result == 0)
		{
			this.vmethod_10(mailID);
		}
		this.vmethod_5();
	}

	// Token: 0x06003027 RID: 12327 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void vmethod_13()
	{
	}

	// Token: 0x04002168 RID: 8552
	protected static readonly DateTime EPOCH = new DateTime(1970, 1, 1, 0, 0, 0, 0);

	// Token: 0x04002169 RID: 8553
	protected List<MailInfo> _mailInfoList = new List<MailInfo>();

	// Token: 0x0400216A RID: 8554
	protected MailView.NewMailInfoContainer _onSendingMail;

	// Token: 0x02000716 RID: 1814
	protected enum MailAnimaState
	{
		// Token: 0x0400216C RID: 8556
		None,
		// Token: 0x0400216D RID: 8557
		KickOff,
		// Token: 0x0400216E RID: 8558
		MailList,
		// Token: 0x0400216F RID: 8559
		MailContent,
		// Token: 0x04002170 RID: 8560
		CreateNewMail,
		// Token: 0x04002171 RID: 8561
		Reply,
		// Token: 0x04002172 RID: 8562
		Quit
	}

	// Token: 0x02000717 RID: 1815
	protected class NewMailInfoContainer
	{
		// Token: 0x04002173 RID: 8563
		public string StrReceiverNickName;

		// Token: 0x04002174 RID: 8564
		public string StrMailContent;
	}
}
