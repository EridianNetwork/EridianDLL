using System;
using UnityEngine;

// Token: 0x02000AD6 RID: 2774
[Serializable]
public class MecanimEventDataEntry
{
	// Token: 0x06004B4F RID: 19279 RVA: 0x00031233 File Offset: 0x0002F433
	public MecanimEventDataEntry()
	{
		this.events = new MecanimEvent[0];
	}

	// Token: 0x06004B50 RID: 19280 RVA: 0x00138CA4 File Offset: 0x00136EA4
	public MecanimEventDataEntry(MecanimEventDataEntry mecanimEventDataEntry_0)
	{
		this.animatorController = mecanimEventDataEntry_0.animatorController;
		this.layer = mecanimEventDataEntry_0.layer;
		this.stateNameHash = mecanimEventDataEntry_0.stateNameHash;
		if (mecanimEventDataEntry_0.events == null)
		{
			this.events = new MecanimEvent[0];
		}
		else
		{
			this.events = new MecanimEvent[mecanimEventDataEntry_0.events.Length];
			for (int i = 0; i < this.events.Length; i++)
			{
				this.events[i] = new MecanimEvent(mecanimEventDataEntry_0.events[i]);
			}
		}
	}

	// Token: 0x040036CE RID: 14030
	public global::UnityEngine.Object animatorController;

	// Token: 0x040036CF RID: 14031
	public string animatorControllerName;

	// Token: 0x040036D0 RID: 14032
	public int layer;

	// Token: 0x040036D1 RID: 14033
	public int stateNameHash;

	// Token: 0x040036D2 RID: 14034
	public MecanimEvent[] events;
}
