using System;
using System.Collections;

// Token: 0x02000386 RID: 902
public class GuildNews
{
	// Token: 0x06001685 RID: 5765 RVA: 0x0007C02C File Offset: 0x0007A22C
	public GuildNews(Hashtable hashtable_0)
	{
		this.PosterAccountId = Convert.ToInt32(hashtable_0[0]);
		this.PosterCharacterId = Convert.ToInt32(hashtable_0[1]);
		this.Reason = (GuildNewsReason)Convert.ToInt32(hashtable_0[2]);
		if (hashtable_0[3] != null)
		{
			this.Objective = Convert.ToInt32(hashtable_0[3]);
			if (hashtable_0[5] != null)
			{
				this.ObjectiveName = Convert.ToString(hashtable_0[5]);
			}
		}
		if (hashtable_0[4] != null)
		{
			this.PosterName = Convert.ToString(hashtable_0[4]);
		}
	}

	// Token: 0x17000118 RID: 280
	// (get) Token: 0x06001686 RID: 5766 RVA: 0x000109FF File Offset: 0x0000EBFF
	// (set) Token: 0x06001687 RID: 5767 RVA: 0x00010A07 File Offset: 0x0000EC07
	public int PosterAccountId { get; set; }

	// Token: 0x17000119 RID: 281
	// (get) Token: 0x06001688 RID: 5768 RVA: 0x00010A10 File Offset: 0x0000EC10
	// (set) Token: 0x06001689 RID: 5769 RVA: 0x00010A18 File Offset: 0x0000EC18
	public int PosterCharacterId { get; set; }

	// Token: 0x1700011A RID: 282
	// (get) Token: 0x0600168A RID: 5770 RVA: 0x00010A21 File Offset: 0x0000EC21
	// (set) Token: 0x0600168B RID: 5771 RVA: 0x00010A29 File Offset: 0x0000EC29
	public GuildNewsReason Reason { get; set; }

	// Token: 0x1700011B RID: 283
	// (get) Token: 0x0600168C RID: 5772 RVA: 0x00010A32 File Offset: 0x0000EC32
	// (set) Token: 0x0600168D RID: 5773 RVA: 0x00010A3A File Offset: 0x0000EC3A
	public int Objective { get; set; }

	// Token: 0x1700011C RID: 284
	// (get) Token: 0x0600168E RID: 5774 RVA: 0x00010A43 File Offset: 0x0000EC43
	// (set) Token: 0x0600168F RID: 5775 RVA: 0x00010A4B File Offset: 0x0000EC4B
	public string PosterName { get; set; }

	// Token: 0x1700011D RID: 285
	// (get) Token: 0x06001690 RID: 5776 RVA: 0x00010A54 File Offset: 0x0000EC54
	// (set) Token: 0x06001691 RID: 5777 RVA: 0x00010A5C File Offset: 0x0000EC5C
	public string ObjectiveName { get; set; }
}
