using System;
using System.Collections;
using UnityEngine;

// Token: 0x020003F3 RID: 1011
internal class SpawnEvent : StatsEvent
{
	// Token: 0x17000159 RID: 345
	// (get) Token: 0x06001974 RID: 6516 RVA: 0x00012F83 File Offset: 0x00011183
	// (set) Token: 0x06001975 RID: 6517 RVA: 0x00012F8B File Offset: 0x0001118B
	public string EntityName { get; set; }

	// Token: 0x1700015A RID: 346
	// (get) Token: 0x06001976 RID: 6518 RVA: 0x00012F94 File Offset: 0x00011194
	// (set) Token: 0x06001977 RID: 6519 RVA: 0x00012F9C File Offset: 0x0001119C
	public Vector3 Position { get; set; }

	// Token: 0x1700015B RID: 347
	// (get) Token: 0x06001978 RID: 6520 RVA: 0x00012FA5 File Offset: 0x000111A5
	// (set) Token: 0x06001979 RID: 6521 RVA: 0x00012FAD File Offset: 0x000111AD
	public float Orientation { get; set; }

	// Token: 0x1700015C RID: 348
	// (get) Token: 0x0600197A RID: 6522 RVA: 0x00012FB6 File Offset: 0x000111B6
	// (set) Token: 0x0600197B RID: 6523 RVA: 0x00012FBE File Offset: 0x000111BE
	public int Timestamp { get; set; }

	// Token: 0x0600197C RID: 6524 RVA: 0x000847E8 File Offset: 0x000829E8
	public Hashtable imethod_0()
	{
		return new Hashtable
		{
			{ "event_type", "spawn" },
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
