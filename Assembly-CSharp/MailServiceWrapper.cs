using System;
using System.Collections.Generic;
using System.Linq;
using Core;
using ns0;

// Token: 0x02000336 RID: 822
public class MailServiceWrapper : ServiceWrapper<IMailServiceWrapper, MailServiceWrapper>
{
	// Token: 0x06001493 RID: 5267 RVA: 0x0000F490 File Offset: 0x0000D690
	public override void vmethod_1()
	{
		if (!this.m_bInited)
		{
			this.m_wrapperOnline = new MailServiceWrapperOnline();
			base.vmethod_1();
			this.m_bInited = true;
		}
	}

	// Token: 0x06001494 RID: 5268 RVA: 0x00078110 File Offset: 0x00076310
	public void OnNewMail(MailInfo newmail)
	{
		if (this.method_5(newmail))
		{
			this.method_7();
			foreach (IMailServiceNotificationListener mailServiceNotificationListener in this.m_mailListeners)
			{
				mailServiceNotificationListener.OnGetNewMail(newmail);
			}
			MonoSingleton<GuidanceTipsManager>.Instance.OnReceiveMail();
		}
	}

	// Token: 0x06001495 RID: 5269 RVA: 0x0007817C File Offset: 0x0007637C
	public void OnSendMail(short result)
	{
		foreach (IMailServiceNotificationListener mailServiceNotificationListener in this.m_mailListeners)
		{
			mailServiceNotificationListener.OnSendMail((int)result);
		}
	}

	// Token: 0x06001496 RID: 5270 RVA: 0x000781D0 File Offset: 0x000763D0
	public void OnReadMail(short result, int mailID)
	{
		if (result != 0)
		{
			return;
		}
		MailInfo mailInfo = null;
		if (this.m_dicMailInfo.TryGetValue(mailID, out mailInfo))
		{
			mailInfo.Mailstate = MailState.Read;
		}
		this.method_7();
		foreach (IMailServiceNotificationListener mailServiceNotificationListener in this.m_mailListeners)
		{
			mailServiceNotificationListener.OnReadMail(mailID);
		}
	}

	// Token: 0x06001497 RID: 5271 RVA: 0x00078248 File Offset: 0x00076448
	public void OnGetMailList(List<MailInfo> mailList)
	{
		this.method_4(mailList);
		this.method_7();
		foreach (IMailServiceNotificationListener mailServiceNotificationListener in this.m_mailListeners)
		{
			mailServiceNotificationListener.OnGetMailList(mailList);
		}
	}

	// Token: 0x06001498 RID: 5272 RVA: 0x000782A8 File Offset: 0x000764A8
	public void OnDeleteMail(short result, int mailID)
	{
		if (result != 0)
		{
			return;
		}
		if (this.m_dicMailInfo.ContainsKey(mailID))
		{
			this.m_dicMailInfo.Remove(mailID);
		}
		this.method_7();
		foreach (IMailServiceNotificationListener mailServiceNotificationListener in this.m_mailListeners)
		{
			mailServiceNotificationListener.OnDeleteMail(mailID);
		}
		if (this.m_redundantMailCache.Count > 0)
		{
			MailInfo mailInfo = this.m_redundantMailCache[0];
			this.m_redundantMailCache.RemoveAt(0);
			if (this.method_5(mailInfo))
			{
				this.method_7();
				foreach (IMailServiceNotificationListener mailServiceNotificationListener2 in this.m_mailListeners)
				{
					mailServiceNotificationListener2.OnGetNewMail(mailInfo);
				}
			}
		}
	}

	// Token: 0x06001499 RID: 5273 RVA: 0x00078398 File Offset: 0x00076598
	public void OnGetMailItem(short sResult, int iMailID)
	{
		this.method_7();
		foreach (IMailServiceNotificationListener mailServiceNotificationListener in this.m_mailListeners)
		{
			mailServiceNotificationListener.OnGetmailItem(sResult, iMailID);
		}
	}

	// Token: 0x0600149A RID: 5274 RVA: 0x000783F4 File Offset: 0x000765F4
	public List<MailInfo> method_0()
	{
		List<MailInfo> list = new List<MailInfo>(this.m_dicMailInfo.Values.ToArray<MailInfo>());
		list.Sort(new Comparison<MailInfo>(this.method_6));
		return list;
	}

	// Token: 0x0600149B RID: 5275 RVA: 0x0000F4B2 File Offset: 0x0000D6B2
	public void method_1(IMailServiceNotificationListener imailServiceNotificationListener_0)
	{
		this.m_mailListeners.Add(imailServiceNotificationListener_0);
	}

	// Token: 0x0600149C RID: 5276 RVA: 0x0000F4C0 File Offset: 0x0000D6C0
	public int method_2()
	{
		return this.m_iUnreadMailCnt;
	}

	// Token: 0x0600149D RID: 5277 RVA: 0x0000F4C8 File Offset: 0x0000D6C8
	public void method_3(IMailServiceNotificationListener imailServiceNotificationListener_0)
	{
		this.m_mailListeners.Remove(imailServiceNotificationListener_0);
	}

	// Token: 0x0600149E RID: 5278 RVA: 0x0007842C File Offset: 0x0007662C
	protected void method_4(List<MailInfo> list_0)
	{
		if (list_0 == null)
		{
			return;
		}
		list_0.Sort(new Comparison<MailInfo>(this.method_6));
		foreach (MailInfo mailInfo in list_0)
		{
			this.method_5(mailInfo);
		}
		this.m_redundantMailCache.Sort(new Comparison<MailInfo>(this.method_6));
	}

	// Token: 0x0600149F RID: 5279 RVA: 0x000784A8 File Offset: 0x000766A8
	protected bool method_5(MailInfo mailInfo_0)
	{
		bool flag = false;
		if (this.m_dicMailInfo.Count < MailServiceWrapper.MAILBOX_MAXVOLUME)
		{
			if (!this.m_dicMailInfo.ContainsKey(mailInfo_0.MailID))
			{
				this.m_dicMailInfo.Add(mailInfo_0.MailID, mailInfo_0);
				flag = true;
			}
			else
			{
				DebugUtils.LogError(LogCategory.Gamelogic, "Get duplicate mail ID of " + mailInfo_0.MailID);
			}
		}
		else
		{
			this.m_redundantMailCache.Add(mailInfo_0);
		}
		return flag;
	}

	// Token: 0x060014A0 RID: 5280 RVA: 0x0007851C File Offset: 0x0007671C
	protected int method_6(MailInfo mailInfo_0, MailInfo mailInfo_1)
	{
		DateTime dateTime = MailServiceWrapper.EPOCH.AddSeconds((double)mailInfo_0.Expiration).ToLocalTime();
		DateTime dateTime2 = MailServiceWrapper.EPOCH.AddSeconds((double)mailInfo_1.Expiration).ToLocalTime();
		return -(dateTime - dateTime2).Seconds;
	}

	// Token: 0x060014A1 RID: 5281 RVA: 0x00078578 File Offset: 0x00076778
	protected void method_7()
	{
		this.m_iUnreadMailCnt = 0;
		foreach (MailInfo mailInfo in this.m_dicMailInfo.Values)
		{
			if (mailInfo.Mailstate == MailState.Unread)
			{
				this.m_iUnreadMailCnt++;
			}
		}
	}

	// Token: 0x060014A2 RID: 5282 RVA: 0x0000F4D7 File Offset: 0x0000D6D7
	public void method_8()
	{
		this.vmethod_0().imethod_3(null);
	}

	// Token: 0x060014A3 RID: 5283 RVA: 0x0000F4E5 File Offset: 0x0000D6E5
	public void method_9(string string_0, string string_1)
	{
		this.vmethod_0().imethod_2(new OnSendMail(this.OnSendMail), string_0, string_1);
	}

	// Token: 0x060014A4 RID: 5284 RVA: 0x0000F500 File Offset: 0x0000D700
	public void method_10(int int_0)
	{
		this.vmethod_0().imethod_4(new OnReadMail(this.OnReadMail), int_0);
	}

	// Token: 0x060014A5 RID: 5285 RVA: 0x0000F51A File Offset: 0x0000D71A
	public void method_11(int int_0)
	{
		this.vmethod_0().imethod_6(new OnDeleteMail(this.OnDeleteMail), int_0);
	}

	// Token: 0x060014A6 RID: 5286 RVA: 0x0000F534 File Offset: 0x0000D734
	public void method_12(int int_0)
	{
		this.vmethod_0().imethod_5(new OnGetMailItem(this.OnGetMailItem), int_0);
	}

	// Token: 0x04000E67 RID: 3687
	public static readonly int MAILBOX_MAXVOLUME = 50;

	// Token: 0x04000E68 RID: 3688
	public static readonly TimeSpan MAIL_LIFETIME = new TimeSpan(7, 0, 0, 0);

	// Token: 0x04000E69 RID: 3689
	protected static readonly DateTime EPOCH = new DateTime(1970, 1, 1, 0, 0, 0, 0);

	// Token: 0x04000E6A RID: 3690
	protected Dictionary<int, MailInfo> m_dicMailInfo = new Dictionary<int, MailInfo>();

	// Token: 0x04000E6B RID: 3691
	protected List<MailInfo> m_redundantMailCache = new List<MailInfo>();

	// Token: 0x04000E6C RID: 3692
	protected List<IMailServiceNotificationListener> m_mailListeners = new List<IMailServiceNotificationListener>();

	// Token: 0x04000E6D RID: 3693
	protected bool m_bInited;

	// Token: 0x04000E6E RID: 3694
	protected int m_iUnreadMailCnt;
}
