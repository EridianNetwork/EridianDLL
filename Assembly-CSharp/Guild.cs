using System;
using System.Collections;
using System.Collections.Generic;

// Token: 0x0200038A RID: 906
public class Guild
{
	// Token: 0x0600169D RID: 5789 RVA: 0x0007C164 File Offset: 0x0007A364
	public Guild(Hashtable hashtable_0)
	{
		this.Id = Convert.ToInt32(hashtable_0[0]);
		this.Name = Convert.ToString(hashtable_0[1]);
		this.Banner = Convert.ToString(hashtable_0[2]);
		this.Level = Convert.ToInt32(hashtable_0[3]);
		this.Experience = Convert.ToInt32(hashtable_0[4]);
		this.MemberCount = Convert.ToInt32(hashtable_0[5]);
		bool flag = Convert.ToBoolean(hashtable_0[6]);
		bool flag2 = Convert.ToBoolean(hashtable_0[7]);
		bool flag3 = Convert.ToBoolean(hashtable_0[8]);
		bool flag4 = Convert.ToBoolean(hashtable_0[9]);
		this.Preference |= GuildPreference.None;
		if (flag)
		{
			this.Preference |= GuildPreference.Social;
		}
		if (flag2)
		{
			this.Preference |= GuildPreference.Quest;
		}
		if (flag3)
		{
			this.Preference |= GuildPreference.PvP;
		}
		if (flag4)
		{
			this.Preference |= GuildPreference.PvE;
		}
		this.FreeSkillCount = Convert.ToInt32(hashtable_0[10]);
		this.HasVacancy = Convert.ToBoolean(hashtable_0[11]);
		this.MaxMemberCount = Convert.ToInt32(hashtable_0[12]);
		this.MasterAccountId = Convert.ToInt32(hashtable_0[13]);
		this.MasterCharacterId = Convert.ToInt32(hashtable_0[14]);
		if (hashtable_0[15] != null)
		{
			Hashtable[] array = (Hashtable[])hashtable_0[15];
			for (int i = 0; i < array.Length; i++)
			{
				this.mMemberList.Add(new Presence(array[i]));
			}
		}
	}

	// Token: 0x17000122 RID: 290
	// (get) Token: 0x0600169E RID: 5790 RVA: 0x00010AA9 File Offset: 0x0000ECA9
	// (set) Token: 0x0600169F RID: 5791 RVA: 0x00010AB1 File Offset: 0x0000ECB1
	public int Id { get; set; }

	// Token: 0x17000123 RID: 291
	// (get) Token: 0x060016A0 RID: 5792 RVA: 0x00010ABA File Offset: 0x0000ECBA
	// (set) Token: 0x060016A1 RID: 5793 RVA: 0x00010AC2 File Offset: 0x0000ECC2
	public string Name { get; set; }

	// Token: 0x17000124 RID: 292
	// (get) Token: 0x060016A2 RID: 5794 RVA: 0x00010ACB File Offset: 0x0000ECCB
	// (set) Token: 0x060016A3 RID: 5795 RVA: 0x00010AD3 File Offset: 0x0000ECD3
	public string Banner { get; set; }

	// Token: 0x17000125 RID: 293
	// (get) Token: 0x060016A4 RID: 5796 RVA: 0x00010ADC File Offset: 0x0000ECDC
	// (set) Token: 0x060016A5 RID: 5797 RVA: 0x00010AE4 File Offset: 0x0000ECE4
	public int Level { get; set; }

	// Token: 0x17000126 RID: 294
	// (get) Token: 0x060016A6 RID: 5798 RVA: 0x00010AED File Offset: 0x0000ECED
	// (set) Token: 0x060016A7 RID: 5799 RVA: 0x00010AF5 File Offset: 0x0000ECF5
	public int Experience { get; set; }

	// Token: 0x17000127 RID: 295
	// (get) Token: 0x060016A8 RID: 5800 RVA: 0x00010AFE File Offset: 0x0000ECFE
	// (set) Token: 0x060016A9 RID: 5801 RVA: 0x00010B06 File Offset: 0x0000ED06
	public int MemberCount { get; set; }

	// Token: 0x17000128 RID: 296
	// (get) Token: 0x060016AA RID: 5802 RVA: 0x00010B0F File Offset: 0x0000ED0F
	// (set) Token: 0x060016AB RID: 5803 RVA: 0x00010B17 File Offset: 0x0000ED17
	public GuildPreference Preference { get; set; }

	// Token: 0x17000129 RID: 297
	// (get) Token: 0x060016AC RID: 5804 RVA: 0x00010B20 File Offset: 0x0000ED20
	// (set) Token: 0x060016AD RID: 5805 RVA: 0x00010B28 File Offset: 0x0000ED28
	public bool HasVacancy { get; set; }

	// Token: 0x1700012A RID: 298
	// (get) Token: 0x060016AE RID: 5806 RVA: 0x00010B31 File Offset: 0x0000ED31
	// (set) Token: 0x060016AF RID: 5807 RVA: 0x00010B39 File Offset: 0x0000ED39
	public int MaxMemberCount { get; set; }

	// Token: 0x1700012B RID: 299
	// (get) Token: 0x060016B0 RID: 5808 RVA: 0x00010B42 File Offset: 0x0000ED42
	// (set) Token: 0x060016B1 RID: 5809 RVA: 0x00010B4A File Offset: 0x0000ED4A
	public int MasterAccountId { get; set; }

	// Token: 0x1700012C RID: 300
	// (get) Token: 0x060016B2 RID: 5810 RVA: 0x00010B53 File Offset: 0x0000ED53
	// (set) Token: 0x060016B3 RID: 5811 RVA: 0x00010B5B File Offset: 0x0000ED5B
	public int MasterCharacterId { get; set; }

	// Token: 0x1700012D RID: 301
	// (get) Token: 0x060016B4 RID: 5812 RVA: 0x00010B64 File Offset: 0x0000ED64
	// (set) Token: 0x060016B5 RID: 5813 RVA: 0x00010B6C File Offset: 0x0000ED6C
	public int FreeSkillCount { get; set; }

	// Token: 0x1700012E RID: 302
	// (get) Token: 0x060016B6 RID: 5814 RVA: 0x00010B75 File Offset: 0x0000ED75
	public List<Presence> List_0
	{
		get
		{
			return this.mMemberList;
		}
	}

	// Token: 0x04000F7B RID: 3963
	public List<Presence> mMemberList = new List<Presence>();
}
