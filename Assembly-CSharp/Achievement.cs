using System;
using System.Collections;

// Token: 0x020002E5 RID: 741
public class Achievement
{
	// Token: 0x060010DA RID: 4314 RVA: 0x00076264 File Offset: 0x00074464
	public Achievement(Hashtable hashtable_0)
	{
		this.type = Convert.ToInt32(hashtable_0[0]);
		this.stage = Convert.ToInt32(hashtable_0[1]);
		this.progress = Convert.ToInt32(hashtable_0[2]);
		this.date = Convert.ToInt32(hashtable_0[3]);
	}

	// Token: 0x170000E5 RID: 229
	// (get) Token: 0x060010DB RID: 4315 RVA: 0x0000E14A File Offset: 0x0000C34A
	// (set) Token: 0x060010DC RID: 4316 RVA: 0x0000E152 File Offset: 0x0000C352
	public int type { get; set; }

	// Token: 0x170000E6 RID: 230
	// (get) Token: 0x060010DD RID: 4317 RVA: 0x0000E15B File Offset: 0x0000C35B
	// (set) Token: 0x060010DE RID: 4318 RVA: 0x0000E163 File Offset: 0x0000C363
	public int stage { get; set; }

	// Token: 0x170000E7 RID: 231
	// (get) Token: 0x060010DF RID: 4319 RVA: 0x0000E16C File Offset: 0x0000C36C
	// (set) Token: 0x060010E0 RID: 4320 RVA: 0x0000E174 File Offset: 0x0000C374
	public int progress { get; set; }

	// Token: 0x170000E8 RID: 232
	// (get) Token: 0x060010E1 RID: 4321 RVA: 0x0000E17D File Offset: 0x0000C37D
	// (set) Token: 0x060010E2 RID: 4322 RVA: 0x0000E185 File Offset: 0x0000C385
	public int date { get; set; }
}
