using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x02000305 RID: 773
public class InstanceInfo
{
	// Token: 0x060011FF RID: 4607 RVA: 0x0000E24D File Offset: 0x0000C44D
	public InstanceInfo(Hashtable hashtable_0)
	{
		this.vmethod_0(hashtable_0);
	}

	// Token: 0x06001200 RID: 4608 RVA: 0x000763F0 File Offset: 0x000745F0
	public virtual void vmethod_0(Hashtable hashtable_0)
	{
		this.UnlockedInstances = hashtable_0.Cast<DictionaryEntry>().ToDictionary<DictionaryEntry, int, int>(new Func<DictionaryEntry, int>(InstanceInfo.smethod_0), new Func<DictionaryEntry, int>(InstanceInfo.smethod_1));
	}

	// Token: 0x170000F4 RID: 244
	// (get) Token: 0x06001201 RID: 4609 RVA: 0x0000E25C File Offset: 0x0000C45C
	// (set) Token: 0x06001202 RID: 4610 RVA: 0x0000E264 File Offset: 0x0000C464
	public virtual Dictionary<int, int> UnlockedInstances { get; set; }

	// Token: 0x06001203 RID: 4611 RVA: 0x0000E26D File Offset: 0x0000C46D
	[CompilerGenerated]
	private static int smethod_0(DictionaryEntry dictionaryEntry_0)
	{
		return (int)dictionaryEntry_0.Key;
	}

	// Token: 0x06001204 RID: 4612 RVA: 0x0000E27B File Offset: 0x0000C47B
	[CompilerGenerated]
	private static int smethod_1(DictionaryEntry dictionaryEntry_0)
	{
		return (int)dictionaryEntry_0.Value;
	}
}
