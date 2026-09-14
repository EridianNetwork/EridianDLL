using System;
using System.Collections.Generic;

// Token: 0x02000335 RID: 821
public interface IMailServiceNotificationListener
{
	// Token: 0x0600148B RID: 5259
	void OnGetNewMail(MailInfo newmail);

	// Token: 0x0600148C RID: 5260
	void OnGetMailList(List<MailInfo> mailList);

	// Token: 0x0600148D RID: 5261
	void OnSendMail(int iResult);

	// Token: 0x0600148E RID: 5262
	void OnReadMail(int mailID);

	// Token: 0x0600148F RID: 5263
	void OnDeleteMail(int mailID);

	// Token: 0x06001490 RID: 5264
	void OnGetmailItem(short result, int mailID);
}
