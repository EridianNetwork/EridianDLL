using System;
using System.Collections;

// Token: 0x020003B3 RID: 947
public class MailInfo
{
	// Token: 0x060017E7 RID: 6119 RVA: 0x0008025C File Offset: 0x0007E45C
	public MailInfo(Hashtable hashtable_0)
	{
		this.MailID = (int)hashtable_0[0];
		this.Mailtype = (MailType)((byte)hashtable_0[1]);
		this.Mailstate = (MailState)((byte)hashtable_0[2]);
		this.SenderID = (int)hashtable_0[3];
		this.SenderName = (string)hashtable_0[4];
		this.ReceiverID = (int)hashtable_0[5];
		this.ReceiverName = (string)hashtable_0[6];
		this.Content = (string)hashtable_0[7];
		this.Expiration = (int)hashtable_0[8];
		Hashtable hashtable = (Hashtable)hashtable_0[9];
		if (hashtable != null)
		{
			this.Item = new InventoryItem(hashtable);
		}
	}

	// Token: 0x04001039 RID: 4153
	public int MailID;

	// Token: 0x0400103A RID: 4154
	public MailState Mailstate;

	// Token: 0x0400103B RID: 4155
	public MailType Mailtype;

	// Token: 0x0400103C RID: 4156
	public int SenderID;

	// Token: 0x0400103D RID: 4157
	public string SenderName;

	// Token: 0x0400103E RID: 4158
	public int ReceiverID;

	// Token: 0x0400103F RID: 4159
	public string ReceiverName;

	// Token: 0x04001040 RID: 4160
	public string Content;

	// Token: 0x04001041 RID: 4161
	public int Expiration;

	// Token: 0x04001042 RID: 4162
	public InventoryItem Item;
}
