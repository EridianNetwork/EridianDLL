using System;
using System.Collections;
using System.Collections.Generic;

// Token: 0x020003EF RID: 1007
public class SkillTree
{
	// Token: 0x06001949 RID: 6473 RVA: 0x00012E43 File Offset: 0x00011043
	public SkillTree()
	{
		this.Earned = 24;
		this.Unspent = 24;
	}

	// Token: 0x0600194A RID: 6474 RVA: 0x00012E66 File Offset: 0x00011066
	public SkillTree(Hashtable hashtable_0)
	{
		this.method_0(hashtable_0);
	}

	// Token: 0x0600194B RID: 6475 RVA: 0x00084230 File Offset: 0x00082430
	public void method_0(Hashtable hashtable_0)
	{
		this.CharacterId = (int)hashtable_0[0];
		this.Earned = (int)hashtable_0[1];
		this.Unspent = (int)hashtable_0[2];
		Hashtable hashtable = (Hashtable)hashtable_0[3];
		foreach (object obj in hashtable)
		{
			DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
			this.mSkills.Add(new InvestedSkill((int)dictionaryEntry.Key, (int)dictionaryEntry.Value));
		}
	}

	// Token: 0x17000153 RID: 339
	// (get) Token: 0x0600194C RID: 6476 RVA: 0x00012E80 File Offset: 0x00011080
	// (set) Token: 0x0600194D RID: 6477 RVA: 0x00012E88 File Offset: 0x00011088
	public int CharacterId { get; set; }

	// Token: 0x17000154 RID: 340
	// (get) Token: 0x0600194E RID: 6478 RVA: 0x00012E91 File Offset: 0x00011091
	// (set) Token: 0x0600194F RID: 6479 RVA: 0x00012E99 File Offset: 0x00011099
	public int Earned { get; set; }

	// Token: 0x17000155 RID: 341
	// (get) Token: 0x06001950 RID: 6480 RVA: 0x00012EA2 File Offset: 0x000110A2
	// (set) Token: 0x06001951 RID: 6481 RVA: 0x00012EAA File Offset: 0x000110AA
	public int Unspent { get; set; }

	// Token: 0x17000156 RID: 342
	// (get) Token: 0x06001952 RID: 6482 RVA: 0x00012EB3 File Offset: 0x000110B3
	// (set) Token: 0x06001953 RID: 6483 RVA: 0x00012EC0 File Offset: 0x000110C0
	public IEnumerable<InvestedSkill> IEnumerable_0
	{
		get
		{
			return this.mSkills.AsReadOnly();
		}
		set
		{
			this.mSkills = new List<InvestedSkill>(value);
		}
	}

	// Token: 0x04001128 RID: 4392
	private List<InvestedSkill> mSkills = new List<InvestedSkill>();
}
