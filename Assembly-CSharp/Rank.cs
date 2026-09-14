using System;
using System.Collections;

// Token: 0x020002FC RID: 764
public class Rank
{
	// Token: 0x060011D7 RID: 4567 RVA: 0x00076314 File Offset: 0x00074514
	public Rank(Hashtable hashtable_0)
	{
		this.characterId = Convert.ToInt32(hashtable_0[0]);
		this.rank = Convert.ToInt32(hashtable_0[1]);
		this.level = Convert.ToInt32(hashtable_0[2]);
		this.characterName = Convert.ToString(hashtable_0[3]);
		this.guildId = Convert.ToInt32(hashtable_0[4]);
		this.guildName = Convert.ToString(hashtable_0[5]);
		this.killDeath = (float)(Convert.ToInt32(hashtable_0[6]) / 10000);
		this.LadderValue = (float)(Convert.ToInt32(hashtable_0[7]) / 10000);
	}

	// Token: 0x170000EA RID: 234
	// (get) Token: 0x060011D8 RID: 4568 RVA: 0x0000E196 File Offset: 0x0000C396
	// (set) Token: 0x060011D9 RID: 4569 RVA: 0x0000E19E File Offset: 0x0000C39E
	public int characterId { get; set; }

	// Token: 0x170000EB RID: 235
	// (get) Token: 0x060011DA RID: 4570 RVA: 0x0000E1A7 File Offset: 0x0000C3A7
	// (set) Token: 0x060011DB RID: 4571 RVA: 0x0000E1AF File Offset: 0x0000C3AF
	public int rank { get; set; }

	// Token: 0x170000EC RID: 236
	// (get) Token: 0x060011DC RID: 4572 RVA: 0x0000E1B8 File Offset: 0x0000C3B8
	// (set) Token: 0x060011DD RID: 4573 RVA: 0x0000E1C0 File Offset: 0x0000C3C0
	public int level { get; set; }

	// Token: 0x170000ED RID: 237
	// (get) Token: 0x060011DE RID: 4574 RVA: 0x0000E1C9 File Offset: 0x0000C3C9
	// (set) Token: 0x060011DF RID: 4575 RVA: 0x0000E1D1 File Offset: 0x0000C3D1
	public string characterName { get; set; }

	// Token: 0x170000EE RID: 238
	// (get) Token: 0x060011E0 RID: 4576 RVA: 0x0000E1DA File Offset: 0x0000C3DA
	// (set) Token: 0x060011E1 RID: 4577 RVA: 0x0000E1E2 File Offset: 0x0000C3E2
	public int guildId { get; set; }

	// Token: 0x170000EF RID: 239
	// (get) Token: 0x060011E2 RID: 4578 RVA: 0x0000E1EB File Offset: 0x0000C3EB
	// (set) Token: 0x060011E3 RID: 4579 RVA: 0x0000E1F3 File Offset: 0x0000C3F3
	public string guildName { get; set; }

	// Token: 0x170000F0 RID: 240
	// (get) Token: 0x060011E4 RID: 4580 RVA: 0x0000E1FC File Offset: 0x0000C3FC
	// (set) Token: 0x060011E5 RID: 4581 RVA: 0x0000E204 File Offset: 0x0000C404
	public float killDeath { get; set; }

	// Token: 0x170000F1 RID: 241
	// (get) Token: 0x060011E6 RID: 4582 RVA: 0x0000E20D File Offset: 0x0000C40D
	// (set) Token: 0x060011E7 RID: 4583 RVA: 0x0000E215 File Offset: 0x0000C415
	public float LadderValue { get; set; }
}
