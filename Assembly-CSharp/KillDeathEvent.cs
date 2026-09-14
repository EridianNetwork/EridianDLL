using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000311 RID: 785
internal class KillDeathEvent : StatsEvent
{
	// Token: 0x170000F5 RID: 245
	// (get) Token: 0x060012C9 RID: 4809 RVA: 0x0000EBF6 File Offset: 0x0000CDF6
	// (set) Token: 0x060012CA RID: 4810 RVA: 0x0000EBFE File Offset: 0x0000CDFE
	public string KillingEntityName { get; set; }

	// Token: 0x170000F6 RID: 246
	// (get) Token: 0x060012CB RID: 4811 RVA: 0x0000EC07 File Offset: 0x0000CE07
	// (set) Token: 0x060012CC RID: 4812 RVA: 0x0000EC0F File Offset: 0x0000CE0F
	public string DyingEntityName { get; set; }

	// Token: 0x170000F7 RID: 247
	// (get) Token: 0x060012CD RID: 4813 RVA: 0x0000EC18 File Offset: 0x0000CE18
	// (set) Token: 0x060012CE RID: 4814 RVA: 0x0000EC20 File Offset: 0x0000CE20
	public Vector3 KillerPosition { get; set; }

	// Token: 0x170000F8 RID: 248
	// (get) Token: 0x060012CF RID: 4815 RVA: 0x0000EC29 File Offset: 0x0000CE29
	// (set) Token: 0x060012D0 RID: 4816 RVA: 0x0000EC31 File Offset: 0x0000CE31
	public Vector3 DeathPosition { get; set; }

	// Token: 0x170000F9 RID: 249
	// (get) Token: 0x060012D1 RID: 4817 RVA: 0x0000EC3A File Offset: 0x0000CE3A
	// (set) Token: 0x060012D2 RID: 4818 RVA: 0x0000EC42 File Offset: 0x0000CE42
	public int Timestamp { get; set; }

	// Token: 0x060012D3 RID: 4819 RVA: 0x00076C40 File Offset: 0x00074E40
	public Hashtable imethod_0()
	{
		return new Hashtable
		{
			{ "event_type", "kill_death" },
			{ "killing_entity_name", this.KillingEntityName },
			{ "dying_entity_name", this.DyingEntityName },
			{
				"killer_position_x",
				this.KillerPosition.x
			},
			{
				"killer_position_y",
				this.KillerPosition.y
			},
			{
				"killer_position_z",
				this.KillerPosition.z
			},
			{
				"death_position_x",
				this.DeathPosition.x
			},
			{
				"death_position_y",
				this.DeathPosition.y
			},
			{
				"death_position_z",
				this.DeathPosition.z
			},
			{ "ts", this.Timestamp }
		};
	}
}
