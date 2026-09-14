using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

// Token: 0x02000306 RID: 774
public class InventoryBackpackProgression
{
	// Token: 0x06001205 RID: 4613 RVA: 0x00076448 File Offset: 0x00074648
	public InventoryBackpackProgression(Hashtable hashtable_0)
	{
		foreach (object obj in hashtable_0)
		{
			DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
			int num = (int)dictionaryEntry.Key;
			Hashtable hashtable = (Hashtable)dictionaryEntry.Value;
			int num2 = (int)hashtable[0];
			int num3 = (int)hashtable[1];
			this.mLevel2BackpackSize[num] = num2;
			this.mBackpackSize2Price[num2] = num3;
		}
		this.mMaximumBackpackSize = this.mLevel2BackpackSize.Max<KeyValuePair<int, int>>(new Func<KeyValuePair<int, int>, int>(InventoryBackpackProgression.smethod_0));
	}

	// Token: 0x06001206 RID: 4614 RVA: 0x00076544 File Offset: 0x00074744
	public int method_0(int int_0)
	{
		return mLevel2BackpackSize[mLevel2BackpackSize.Where((KeyValuePair<int, int> keyValuePair_0) => keyValuePair_0.Key <= int_0).Max((KeyValuePair<int, int> keyValuePair_0) => keyValuePair_0.Key)];
	}
	// Token: 0x06001207 RID: 4615 RVA: 0x000765A4 File Offset: 0x000747A4
	public int method_1(int int_0, int int_1)
	{
		return mLevel2BackpackSize.Where((KeyValuePair<int, int> keyValuePair_0) => keyValuePair_0.Key <= int_1 && keyValuePair_0.Key > int_0).Sum((KeyValuePair<int, int> keyValuePair_0) => keyValuePair_0.Value);
	}
	// Token: 0x06001208 RID: 4616 RVA: 0x0000E289 File Offset: 0x0000C489
	public int method_2()
	{
		return this.mMaximumBackpackSize;
	}

	// Token: 0x06001209 RID: 4617 RVA: 0x0000E291 File Offset: 0x0000C491
	[CompilerGenerated]
	private static int smethod_0(KeyValuePair<int, int> keyValuePair_0)
	{
		return keyValuePair_0.Value;
	}

	// Token: 0x0600120A RID: 4618 RVA: 0x0000E29A File Offset: 0x0000C49A
	[CompilerGenerated]
	private static int smethod_1(KeyValuePair<int, int> keyValuePair_0)
	{
		return keyValuePair_0.Key;
	}

	// Token: 0x0600120B RID: 4619 RVA: 0x0000E291 File Offset: 0x0000C491
	[CompilerGenerated]
	private static int smethod_2(KeyValuePair<int, int> keyValuePair_0)
	{
		return keyValuePair_0.Value;
	}

	// Token: 0x04000E12 RID: 3602
	private Dictionary<int, int> mLevel2BackpackSize = new Dictionary<int, int>();

	// Token: 0x04000E13 RID: 3603
	private Dictionary<int, int> mBackpackSize2Price = new Dictionary<int, int>();

	// Token: 0x04000E14 RID: 3604
	private int mMaximumBackpackSize;
}
