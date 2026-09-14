using System;
using System.Collections;
using System.Collections.Generic;
using XsdSettings;

// Token: 0x02000314 RID: 788
public class Lobby
{
	// Token: 0x060012D4 RID: 4820 RVA: 0x00076D54 File Offset: 0x00074F54
	public Lobby(Hashtable hashtable_0)
	{
		this.Id = (int)hashtable_0[0];
		this.Owner = (int)hashtable_0[1];
		this.TotalSlots = (int)hashtable_0[2];
		this.IsGroupGame = (bool)hashtable_0[3];
		this.SessionId = (string)hashtable_0[4];
		this.Members = new List<Presence>();
		Hashtable hashtable = (Hashtable)hashtable_0[5];
		for (int i = 0; i < hashtable.Count; i++)
		{
			this.Members.Add(new Presence((Hashtable)hashtable[i]));
		}
		this.Groups = new List<Group>();
		Hashtable hashtable2 = (Hashtable)hashtable_0[6];
		for (int j = 0; j < hashtable2.Count; j++)
		{
			this.Groups.Add(new Group((Hashtable)hashtable2[j]));
		}
		this.GameMode = (GamemodeType)((int)hashtable_0[7]);
		this.Playlist = (int)hashtable_0[8];
		this.Difficulty = (ELevelDifficulty)((int)hashtable_0[9]);
	}

	// Token: 0x170000FA RID: 250
	// (get) Token: 0x060012D5 RID: 4821 RVA: 0x0000EC4B File Offset: 0x0000CE4B
	// (set) Token: 0x060012D6 RID: 4822 RVA: 0x0000EC53 File Offset: 0x0000CE53
	public int Id { get; set; }

	// Token: 0x170000FB RID: 251
	// (get) Token: 0x060012D7 RID: 4823 RVA: 0x0000EC5C File Offset: 0x0000CE5C
	// (set) Token: 0x060012D8 RID: 4824 RVA: 0x0000EC64 File Offset: 0x0000CE64
	public int Owner { get; set; }

	// Token: 0x170000FC RID: 252
	// (get) Token: 0x060012D9 RID: 4825 RVA: 0x0000EC6D File Offset: 0x0000CE6D
	// (set) Token: 0x060012DA RID: 4826 RVA: 0x0000311B File Offset: 0x0000131B
	public int Int32_0
	{
		get
		{
			return this.Members.Count;
		}
		set
		{
		}
	}

	// Token: 0x170000FD RID: 253
	// (get) Token: 0x060012DB RID: 4827 RVA: 0x0000EC7A File Offset: 0x0000CE7A
	// (set) Token: 0x060012DC RID: 4828 RVA: 0x0000311B File Offset: 0x0000131B
	public int Int32_1
	{
		get
		{
			return this.TotalSlots - this.Members.Count;
		}
		set
		{
		}
	}

	// Token: 0x170000FE RID: 254
	// (get) Token: 0x060012DD RID: 4829 RVA: 0x0000EC8E File Offset: 0x0000CE8E
	// (set) Token: 0x060012DE RID: 4830 RVA: 0x0000EC96 File Offset: 0x0000CE96
	public int TotalSlots { get; set; }

	// Token: 0x170000FF RID: 255
	// (get) Token: 0x060012DF RID: 4831 RVA: 0x0000EC9F File Offset: 0x0000CE9F
	// (set) Token: 0x060012E0 RID: 4832 RVA: 0x0000ECA7 File Offset: 0x0000CEA7
	public bool IsGroupGame { get; set; }

	// Token: 0x17000100 RID: 256
	// (get) Token: 0x060012E1 RID: 4833 RVA: 0x0000ECB0 File Offset: 0x0000CEB0
	// (set) Token: 0x060012E2 RID: 4834 RVA: 0x0000ECB8 File Offset: 0x0000CEB8
	public string SessionId { get; set; }

	// Token: 0x17000101 RID: 257
	// (get) Token: 0x060012E3 RID: 4835 RVA: 0x0000ECC1 File Offset: 0x0000CEC1
	// (set) Token: 0x060012E4 RID: 4836 RVA: 0x0000ECC9 File Offset: 0x0000CEC9
	public GamemodeType GameMode { get; set; }

	// Token: 0x17000102 RID: 258
	// (get) Token: 0x060012E5 RID: 4837 RVA: 0x0000ECD2 File Offset: 0x0000CED2
	// (set) Token: 0x060012E6 RID: 4838 RVA: 0x0000ECDA File Offset: 0x0000CEDA
	public int Playlist { get; set; }

	// Token: 0x17000103 RID: 259
	// (get) Token: 0x060012E7 RID: 4839 RVA: 0x0000ECE3 File Offset: 0x0000CEE3
	// (set) Token: 0x060012E8 RID: 4840 RVA: 0x0000ECEB File Offset: 0x0000CEEB
	public ELevelDifficulty Difficulty { get; set; }

	// Token: 0x17000104 RID: 260
	// (get) Token: 0x060012E9 RID: 4841 RVA: 0x0000ECF4 File Offset: 0x0000CEF4
	// (set) Token: 0x060012EA RID: 4842 RVA: 0x0000ECFC File Offset: 0x0000CEFC
	public List<Presence> Members { get; set; }

	// Token: 0x17000105 RID: 261
	// (get) Token: 0x060012EB RID: 4843 RVA: 0x0000ED05 File Offset: 0x0000CF05
	// (set) Token: 0x060012EC RID: 4844 RVA: 0x0000ED0D File Offset: 0x0000CF0D
	public List<Group> Groups { get; set; }

	// Token: 0x17000106 RID: 262
	// (get) Token: 0x060012ED RID: 4845 RVA: 0x0000ED16 File Offset: 0x0000CF16
	// (set) Token: 0x060012EE RID: 4846 RVA: 0x0000ED1E File Offset: 0x0000CF1E
	public bool HasGameStarted { get; set; }

	// Token: 0x17000107 RID: 263
	// (get) Token: 0x060012EF RID: 4847 RVA: 0x00076EC0 File Offset: 0x000750C0
	public int Int32_2
	{
		get
		{
			if (this.Groups.Count > 0)
			{
				int num = 0;
				foreach (Group group in this.Groups)
				{
					num += group.Int32_0;
				}
				return this.Members.Count - num + this.Groups.Count;
			}
			return this.Members.Count;
		}
	}

	// Token: 0x17000108 RID: 264
	// (get) Token: 0x060012F0 RID: 4848 RVA: 0x00076F4C File Offset: 0x0007514C
	public bool Boolean_0
	{
		get
		{
			switch (this.GameMode)
			{
			case GamemodeType.GamemodeTeamDeathmatch:
			case GamemodeType.GamemodeClaptrapSoccer:
				return true;
			default:
				return false;
			}
		}
	}

	// Token: 0x17000109 RID: 265
	// (get) Token: 0x060012F1 RID: 4849 RVA: 0x00076F78 File Offset: 0x00075178
	public bool Boolean_1
	{
		get
		{
			switch (this.GameMode)
			{
			case GamemodeType.GamemodeDeathmatch:
			case GamemodeType.GamemodeTeamDeathmatch:
			case GamemodeType.GamemodeClaptrapSoccer:
				return true;
			default:
				return false;
			}
		}
	}

	// Token: 0x1700010A RID: 266
	// (get) Token: 0x060012F2 RID: 4850 RVA: 0x0000ED27 File Offset: 0x0000CF27
	public bool Boolean_2
	{
		get
		{
			if (this.Boolean_0)
			{
				return this.Int32_2 > 1;
			}
			return !this.Boolean_1 || this.Int32_0 > 1;
		}
	}

	// Token: 0x060012F3 RID: 4851 RVA: 0x00076FA8 File Offset: 0x000751A8
	public void method_0(Presence presence_0)
	{
		if (this.Int32_1 <= 0)
		{
			return;
		}
		foreach (Presence presence in this.Members)
		{
			if (presence.mCharacterId == presence_0.mCharacterId)
			{
				return;
			}
		}
		this.Members.Add(presence_0);
	}

	// Token: 0x060012F4 RID: 4852 RVA: 0x0007701C File Offset: 0x0007521C
	public bool method_1(int int_0)
	{
		foreach (Presence presence in this.Members)
		{
			if (presence.mCharacterId == int_0)
			{
				this.Members.Remove(presence);
				return true;
			}
		}
		return false;
	}

	// Token: 0x060012F5 RID: 4853 RVA: 0x0000ED4E File Offset: 0x0000CF4E
	public void method_2(int int_0)
	{
		this.Owner = int_0;
	}

	// Token: 0x060012F6 RID: 4854 RVA: 0x00077088 File Offset: 0x00075288
	public bool method_3(int int_0)
	{
		return Members.Find((Presence presence_0) => presence_0.mCharacterId == int_0) != null;
	}
}
