using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000339 RID: 825
internal class PickupGoldEvent : StatsEvent
{
	// Token: 0x17000111 RID: 273
	// (get) Token: 0x060014BC RID: 5308 RVA: 0x0000F5FA File Offset: 0x0000D7FA
	// (set) Token: 0x060014BD RID: 5309 RVA: 0x0000F602 File Offset: 0x0000D802
	public string EntityName { get; set; }

	// Token: 0x17000112 RID: 274
	// (get) Token: 0x060014BE RID: 5310 RVA: 0x0000F60B File Offset: 0x0000D80B
	// (set) Token: 0x060014BF RID: 5311 RVA: 0x0000F613 File Offset: 0x0000D813
	public Vector3 Position { get; set; }

	// Token: 0x17000113 RID: 275
	// (get) Token: 0x060014C0 RID: 5312 RVA: 0x0000F61C File Offset: 0x0000D81C
	// (set) Token: 0x060014C1 RID: 5313 RVA: 0x0000F624 File Offset: 0x0000D824
	public int Amount { get; set; }

	// Token: 0x17000114 RID: 276
	// (get) Token: 0x060014C2 RID: 5314 RVA: 0x0000F62D File Offset: 0x0000D82D
	// (set) Token: 0x060014C3 RID: 5315 RVA: 0x0000F635 File Offset: 0x0000D835
	public int Timestamp { get; set; }

	// Token: 0x060014C4 RID: 5316 RVA: 0x00078708 File Offset: 0x00076908
	public Hashtable imethod_0()
	{
		return new Hashtable
		{
			{ "event_type", "pickup_gold" },
			{ "entity_name", this.EntityName },
			{
				"position_x",
				this.Position.x
			},
			{
				"position_y",
				this.Position.y
			},
			{
				"position_z",
				this.Position.z
			},
			{ "amount", this.Amount },
			{ "ts", this.Timestamp }
		};
	}
}
