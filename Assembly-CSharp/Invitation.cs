using System;
using System.Collections;

// Token: 0x02000389 RID: 905
public class Invitation
{
	// Token: 0x06001694 RID: 5780 RVA: 0x0007C0F4 File Offset: 0x0007A2F4
	public Invitation(Hashtable hashtable_0)
	{
		this.GuildId = Convert.ToInt32(hashtable_0[0]);
		this.GuildMasterNick = Convert.ToString(hashtable_0[1]);
		this.GuildName = Convert.ToString(hashtable_0[2]);
		this.GuildInviterCharacterId = Convert.ToInt32(hashtable_0[3]);
	}

	// Token: 0x1700011E RID: 286
	// (get) Token: 0x06001695 RID: 5781 RVA: 0x00010A65 File Offset: 0x0000EC65
	// (set) Token: 0x06001696 RID: 5782 RVA: 0x00010A6D File Offset: 0x0000EC6D
	public int GuildId { get; set; }

	// Token: 0x1700011F RID: 287
	// (get) Token: 0x06001697 RID: 5783 RVA: 0x00010A76 File Offset: 0x0000EC76
	// (set) Token: 0x06001698 RID: 5784 RVA: 0x00010A7E File Offset: 0x0000EC7E
	public string GuildName { get; set; }

	// Token: 0x17000120 RID: 288
	// (get) Token: 0x06001699 RID: 5785 RVA: 0x00010A87 File Offset: 0x0000EC87
	// (set) Token: 0x0600169A RID: 5786 RVA: 0x00010A8F File Offset: 0x0000EC8F
	public string GuildMasterNick { get; set; }

	// Token: 0x17000121 RID: 289
	// (get) Token: 0x0600169B RID: 5787 RVA: 0x00010A98 File Offset: 0x0000EC98
	// (set) Token: 0x0600169C RID: 5788 RVA: 0x00010AA0 File Offset: 0x0000ECA0
	public int GuildInviterCharacterId { get; set; }
}
