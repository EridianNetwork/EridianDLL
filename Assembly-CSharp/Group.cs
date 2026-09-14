using System;
using System.Collections;
using System.Collections.Generic;

// Token: 0x020002DA RID: 730
public class Group
{
	// Token: 0x06001047 RID: 4167 RVA: 0x0000DCE0 File Offset: 0x0000BEE0
	public Group(Hashtable hashtable_0)
	{
		this.method_0(hashtable_0);
	}

	// Token: 0x170000E4 RID: 228
	// (get) Token: 0x06001048 RID: 4168 RVA: 0x0000DCEF File Offset: 0x0000BEEF
	public int Int32_0
	{
		get
		{
			return this.Members.Count + 1;
		}
	}

	// Token: 0x06001049 RID: 4169 RVA: 0x00075C04 File Offset: 0x00073E04
	private void method_0(Hashtable hashtable_0)
	{
		this.Id = (int)hashtable_0[0];
		this.Leader = new Presence((Hashtable)hashtable_0[1]);
		this.Members = new List<Presence>();
		Hashtable hashtable = (Hashtable)hashtable_0[2];
		foreach (object obj in hashtable)
		{
			DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
			this.Members.Add(new Presence((Hashtable)dictionaryEntry.Value));
		}
	}

	// Token: 0x04000DC8 RID: 3528
	public int Id;

	// Token: 0x04000DC9 RID: 3529
	public Presence Leader;

	// Token: 0x04000DCA RID: 3530
	public List<Presence> Members;

	// Token: 0x04000DCB RID: 3531
	public string GameId;
}
