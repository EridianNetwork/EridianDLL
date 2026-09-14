using System;
using System.Collections;
using UnityEngine;

// Token: 0x020002D5 RID: 725
public class ExpiringCurrency
{
	// Token: 0x06001010 RID: 4112 RVA: 0x00075A48 File Offset: 0x00073C48
	public ExpiringCurrency(Hashtable hashtable_0)
	{
		this.Count = (int)hashtable_0[0];
		this.mRemainingTime0 = (float)hashtable_0[1];
		this.mCurrentTime0 = Time.time;
	}

	// Token: 0x170000E1 RID: 225
	// (get) Token: 0x06001011 RID: 4113 RVA: 0x0000DB28 File Offset: 0x0000BD28
	// (set) Token: 0x06001012 RID: 4114 RVA: 0x0000DB30 File Offset: 0x0000BD30
	public int Count { get; set; }

	// Token: 0x170000E2 RID: 226
	// (get) Token: 0x06001013 RID: 4115 RVA: 0x0000DB39 File Offset: 0x0000BD39
	public float Single_0
	{
		get
		{
			return this.mRemainingTime0 - (Time.time - this.mCurrentTime0);
		}
	}

	// Token: 0x170000E3 RID: 227
	// (get) Token: 0x06001014 RID: 4116 RVA: 0x0000DB4E File Offset: 0x0000BD4E
	// (set) Token: 0x06001015 RID: 4117 RVA: 0x0000DB56 File Offset: 0x0000BD56
	public int Expires { get; set; }

	// Token: 0x04000DC1 RID: 3521
	private float mRemainingTime0;

	// Token: 0x04000DC2 RID: 3522
	private float mCurrentTime0;
}
