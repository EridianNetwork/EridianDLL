using System;
using System.Collections;
using System.Collections.Generic;

// Token: 0x020002E6 RID: 742
public class Achievements
{
	// Token: 0x060010E3 RID: 4323 RVA: 0x000762D4 File Offset: 0x000744D4
	public Achievements(Hashtable[] hashtable_0)
	{
		for (int i = 0; i < hashtable_0.Length; i++)
		{
			this.mAchievements.Add(i, new Achievement(hashtable_0[i]));
		}
	}

	// Token: 0x170000E9 RID: 233
	// (get) Token: 0x060010E4 RID: 4324 RVA: 0x0000E18E File Offset: 0x0000C38E
	public Dictionary<int, Achievement> Dictionary_0
	{
		get
		{
			return this.mAchievements;
		}
	}

	// Token: 0x04000DE7 RID: 3559
	private Dictionary<int, Achievement> mAchievements = new Dictionary<int, Achievement>();
}
