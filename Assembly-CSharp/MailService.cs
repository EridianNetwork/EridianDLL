using System;
using System.Collections;
using System.Collections.Generic;

// Token: 0x020003B4 RID: 948
public class MailService : OnAccessSingleton<IMailService, MailService, MailServiceOffline>, IMailService
{
	// Token: 0x060017E8 RID: 6120 RVA: 0x00080360 File Offset: 0x0007E560
	public MailService()
	{
		PhotonNetwork.onlinePeer.method_5(95, new OperationResponseCallback(this.OnGotMail));
		PhotonNetwork.onlinePeer.method_5(94, new OperationResponseCallback(this.OnSendmail));
		PhotonNetwork.onlinePeer.method_5(93, new OperationResponseCallback(this.OnReadMail));
		PhotonNetwork.onlinePeer.method_5(92, new OperationResponseCallback(this.OnGetMailItem));
		PhotonNetwork.onlinePeer.method_5(91, new OperationResponseCallback(this.OnDeleteMail));
		PhotonNetwork.onlinePeer.method_7(167, new EventCallback(this.OnNewMail));
		PhotonNetwork.onlinePeer.method_7(161, new EventCallback(this.OnGetMailList));
	}

	// Token: 0x060017E9 RID: 6121 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_0()
	{
	}

	// Token: 0x060017EA RID: 6122 RVA: 0x00011C56 File Offset: 0x0000FE56
	private void OnGotMail(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (this.mOnGotMailInfo == null || operationResponse != 0)
		{
		}
	}

	// Token: 0x060017EB RID: 6123 RVA: 0x0008043C File Offset: 0x0007E63C
	private void OnSendmail(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (this.mOnSendMail != null)
		{
			short num = (short)parameters[0];
			this.mOnSendMail(num);
		}
	}

	// Token: 0x060017EC RID: 6124 RVA: 0x0008046C File Offset: 0x0007E66C
	private void OnReadMail(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (this.mOnReadMail != null)
		{
			if (operationResponse == 0)
			{
				int num = (int)parameters[0];
				this.mOnReadMail(operationResponse, num);
			}
			else
			{
				this.mOnReadMail(operationResponse, 0);
			}
		}
	}

	// Token: 0x060017ED RID: 6125 RVA: 0x000804B0 File Offset: 0x0007E6B0
	private void OnGetMailItem(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (this.mOnGetMailItem != null)
		{
			if (operationResponse == 0)
			{
				int num = (int)parameters[0];
				this.mOnGetMailItem(operationResponse, num);
			}
			else
			{
				this.mOnGetMailItem(operationResponse, 0);
			}
		}
	}

	// Token: 0x060017EE RID: 6126 RVA: 0x000804F4 File Offset: 0x0007E6F4
	private void OnDeleteMail(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (this.mOnDeleteMail != null)
		{
			if (operationResponse == 0)
			{
				int num = (int)parameters[0];
				this.mOnDeleteMail(operationResponse, num);
			}
			else
			{
				this.mOnDeleteMail(operationResponse, 0);
			}
		}
	}

	// Token: 0x060017EF RID: 6127 RVA: 0x00080538 File Offset: 0x0007E738
	private void OnNewMail(Dictionary<byte, object> parameters)
	{
		Hashtable hashtable_ = (Hashtable)parameters[0];
		MailInfo info = new MailInfo(hashtable_);
		mOnNewMail.ForEach(delegate(OnNewMail onNewMail_0)
		{
			onNewMail_0(info);
		});
	}
	// Token: 0x060017F0 RID: 6128 RVA: 0x0008057C File Offset: 0x0007E77C
	private void OnGetMailList(Dictionary<byte, object> parameters)
	{
		List<MailInfo> mailInfolist = new List<MailInfo>();
		foreach (object value in parameters.Values)
		{
			Hashtable hashtable_ = (Hashtable)value;
			MailInfo item = new MailInfo(hashtable_);
			mailInfolist.Add(item);
		}
		mOnMailList.ForEach(delegate(OnGetMailList onGetMailList_0)
		{
			onGetMailList_0(mailInfolist);
		});
	}
	// Token: 0x060017F1 RID: 6129 RVA: 0x00011C63 File Offset: 0x0000FE63
	public void imethod_1(OnGotMailInfo onGotMailInfo_0)
	{
		this.mOnGotMailInfo = onGotMailInfo_0;
		PhotonNetwork.onlinePeer.method_3(95, new object[0]);
	}

	// Token: 0x060017F2 RID: 6130 RVA: 0x00011C7F File Offset: 0x0000FE7F
	public void imethod_2(OnSendMail onSendMail_0, string string_0, string string_1)
	{
		this.mOnSendMail = onSendMail_0;
		PhotonNetwork.onlinePeer.method_3(94, new object[] { string_0, string_1 });
	}

	// Token: 0x060017F3 RID: 6131 RVA: 0x00011CA3 File Offset: 0x0000FEA3
	public void imethod_3(OnReadMail onReadMail_0, int int_0)
	{
		this.mOnReadMail = onReadMail_0;
		PhotonNetwork.onlinePeer.method_3(93, new object[] { int_0 });
	}

	// Token: 0x060017F4 RID: 6132 RVA: 0x00011CC8 File Offset: 0x0000FEC8
	public void imethod_4(OnGetMailItem onGetMailItem_0, int int_0)
	{
		this.mOnGetMailItem = onGetMailItem_0;
		PhotonNetwork.onlinePeer.method_3(92, new object[] { int_0 });
	}

	// Token: 0x060017F5 RID: 6133 RVA: 0x00011CED File Offset: 0x0000FEED
	public void imethod_5(OnDeleteMail onDeleteMail_0, int int_0)
	{
		this.mOnDeleteMail = onDeleteMail_0;
		PhotonNetwork.onlinePeer.method_3(91, new object[] { int_0 });
	}

	// Token: 0x060017F6 RID: 6134 RVA: 0x00011D12 File Offset: 0x0000FF12
	public void imethod_6(OnNewMail onNewMail_0)
	{
		this.mOnNewMail.Add(onNewMail_0);
	}

	// Token: 0x060017F7 RID: 6135 RVA: 0x00011D20 File Offset: 0x0000FF20
	public void imethod_7(OnNewMail onNewMail_0)
	{
		this.mOnNewMail.Remove(onNewMail_0);
	}

	// Token: 0x060017F8 RID: 6136 RVA: 0x00011D2F File Offset: 0x0000FF2F
	public void imethod_8(OnGetMailList onGetMailList_0)
	{
		this.mOnMailList.Add(onGetMailList_0);
	}

	// Token: 0x060017F9 RID: 6137 RVA: 0x00011D3D File Offset: 0x0000FF3D
	public void imethod_9(OnGetMailList onGetMailList_0)
	{
		this.mOnMailList.Remove(onGetMailList_0);
	}

	// Token: 0x04001043 RID: 4163
	private List<OnNewMail> mOnNewMail = new List<OnNewMail>();

	// Token: 0x04001044 RID: 4164
	private List<OnGetMailList> mOnMailList = new List<OnGetMailList>();

	// Token: 0x04001045 RID: 4165
	private OnSendMail mOnSendMail;

	// Token: 0x04001046 RID: 4166
	private OnGotMailInfo mOnGotMailInfo;

	// Token: 0x04001047 RID: 4167
	private OnReadMail mOnReadMail;

	// Token: 0x04001048 RID: 4168
	private OnGetMailItem mOnGetMailItem;

	// Token: 0x04001049 RID: 4169
	private OnDeleteMail mOnDeleteMail;
}
