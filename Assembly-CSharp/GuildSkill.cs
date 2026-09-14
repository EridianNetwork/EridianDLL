using System;
using System.Collections;

// Token: 0x02000385 RID: 901
public class GuildSkill
{
	// Token: 0x06001680 RID: 5760 RVA: 0x000109A7 File Offset: 0x0000EBA7
	public GuildSkill(Hashtable hashtable_0)
	{
		this.Id = Convert.ToInt32(hashtable_0[0]);
		this.Grade = Convert.ToInt32(hashtable_0[1]);
	}

	// Token: 0x17000116 RID: 278
	// (get) Token: 0x06001681 RID: 5761 RVA: 0x000109DD File Offset: 0x0000EBDD
	// (set) Token: 0x06001682 RID: 5762 RVA: 0x000109E5 File Offset: 0x0000EBE5
	public int Id { get; set; }

	// Token: 0x17000117 RID: 279
	// (get) Token: 0x06001683 RID: 5763 RVA: 0x000109EE File Offset: 0x0000EBEE
	// (set) Token: 0x06001684 RID: 5764 RVA: 0x000109F6 File Offset: 0x0000EBF6
	public int Grade { get; set; }
}
