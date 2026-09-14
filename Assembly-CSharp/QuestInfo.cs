using System;
using System.Collections;
using System.Collections.Generic;

// Token: 0x0200033E RID: 830
public class QuestInfo
{
	// Token: 0x060014F4 RID: 5364 RVA: 0x0000F6F8 File Offset: 0x0000D8F8
	public QuestInfo(Hashtable hashtable_0)
	{
		this.method_0(hashtable_0);
	}

	// Token: 0x060014F5 RID: 5365 RVA: 0x00078ADC File Offset: 0x00076CDC
	public void method_0(Hashtable hashtable_0)
	{
		this.mQuests = new List<QuestProgress>();
		foreach (object obj in hashtable_0)
		{
			DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
			this.mQuests.Add(new QuestProgress((Hashtable)dictionaryEntry.Value));
		}
	}

	// Token: 0x17000115 RID: 277
	// (get) Token: 0x060014F6 RID: 5366 RVA: 0x0000F707 File Offset: 0x0000D907
	// (set) Token: 0x060014F7 RID: 5367 RVA: 0x0000F714 File Offset: 0x0000D914
	public virtual IEnumerable<QuestProgress> Prop_0
	{
		get
		{
			return this.mQuests.AsReadOnly();
		}
		set
		{
			this.mQuests = new List<QuestProgress>(value);
		}
	}

	// Token: 0x04000E7C RID: 3708
	private List<QuestProgress> mQuests;
}
