using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000338 RID: 824
internal class MovementEvent : StatsEvent
{
	// Token: 0x1700010D RID: 269
	// (get) Token: 0x060014B2 RID: 5298 RVA: 0x0000F5B6 File Offset: 0x0000D7B6
	// (set) Token: 0x060014B3 RID: 5299 RVA: 0x0000F5BE File Offset: 0x0000D7BE
	public string EntityName { get; set; }

	// Token: 0x1700010E RID: 270
	// (get) Token: 0x060014B4 RID: 5300 RVA: 0x0000F5C7 File Offset: 0x0000D7C7
	// (set) Token: 0x060014B5 RID: 5301 RVA: 0x0000F5CF File Offset: 0x0000D7CF
	public Vector3 Position { get; set; }

	// Token: 0x1700010F RID: 271
	// (get) Token: 0x060014B6 RID: 5302 RVA: 0x0000F5D8 File Offset: 0x0000D7D8
	// (set) Token: 0x060014B7 RID: 5303 RVA: 0x0000F5E0 File Offset: 0x0000D7E0
	public float Orientation { get; set; }

	// Token: 0x17000110 RID: 272
	// (get) Token: 0x060014B8 RID: 5304 RVA: 0x0000F5E9 File Offset: 0x0000D7E9
	// (set) Token: 0x060014B9 RID: 5305 RVA: 0x0000F5F1 File Offset: 0x0000D7F1
	public int Timestamp { get; set; }

	// Token: 0x060014BA RID: 5306 RVA: 0x0007864C File Offset: 0x0007684C
	public Hashtable imethod_0()
	{
		return new Hashtable
		{
			{ "event_type", "movement" },
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
			{ "orientation", this.Orientation },
			{ "ts", this.Timestamp }
		};
	}
}
