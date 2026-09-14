using System;
using System.Collections;
using XsdSettings;

// Token: 0x020002CA RID: 714
public class Character
{
	// Token: 0x06000F51 RID: 3921 RVA: 0x00074C80 File Offset: 0x00072E80
	public Character()
	{
		this.Inventory = new Inventory();
		this.Currency = new CurrencyInfo();
		this.QuestList = new QuestInfo(new Hashtable());
		this.Instances = new InstanceInfo(new Hashtable());
		this.Skills = new global::SkillTree();
	}

	// Token: 0x06000F52 RID: 3922 RVA: 0x0000D46E File Offset: 0x0000B66E
	public Character(Hashtable hashtable_0)
	{
		this.method_0(hashtable_0);
	}

	// Token: 0x06000F53 RID: 3923 RVA: 0x00074CD4 File Offset: 0x00072ED4
	public void method_0(Hashtable hashtable_0)
	{
		this.Id = (int)hashtable_0[0];
		this.AccountId = (int)hashtable_0[1];
		this.Name = (string)hashtable_0[2];
		this.Experience = (int)hashtable_0[3];
		this.Level = (int)hashtable_0[4];
		this.AvatarType = (AvatarType)((int)hashtable_0[5]);
		this.AvatarParts = (string)hashtable_0[6];
		this.AvatarMaterials = (string)hashtable_0[7];
		this.AvatarId = (uint)((int)hashtable_0[8]);
		this.Inventory = new Inventory((Hashtable)hashtable_0[9]);
		this.Currency = new CurrencyInfo((Hashtable)hashtable_0[10]);
		this.QuestList = new QuestInfo((Hashtable)hashtable_0[11]);
		this.Instances = new InstanceInfo((Hashtable)hashtable_0[12]);
		this.Skills = new global::SkillTree((Hashtable)hashtable_0[13]);
		this.TimePlayed = (int)hashtable_0[14];
		this.LadderValue = Convert.ToInt32(hashtable_0[15]);
		this.Tier = (LadderTier)((int)hashtable_0[16]);
		this.Grade = (LadderGrade)((int)hashtable_0[17]);
		this.Energy = (int)hashtable_0[18];
	}

	// Token: 0x170000C8 RID: 200
	// (get) Token: 0x06000F54 RID: 3924 RVA: 0x0000D47D File Offset: 0x0000B67D
	// (set) Token: 0x06000F55 RID: 3925 RVA: 0x0000D485 File Offset: 0x0000B685
	public int Id { get; set; }

	// Token: 0x170000C9 RID: 201
	// (get) Token: 0x06000F56 RID: 3926 RVA: 0x0000D48E File Offset: 0x0000B68E
	// (set) Token: 0x06000F57 RID: 3927 RVA: 0x0000D496 File Offset: 0x0000B696
	public int AccountId { get; set; }

	// Token: 0x170000CA RID: 202
	// (get) Token: 0x06000F58 RID: 3928 RVA: 0x0000D49F File Offset: 0x0000B69F
	// (set) Token: 0x06000F59 RID: 3929 RVA: 0x0000D4A7 File Offset: 0x0000B6A7
	public string Name { get; set; }

	// Token: 0x170000CB RID: 203
	// (get) Token: 0x06000F5A RID: 3930 RVA: 0x0000D4B0 File Offset: 0x0000B6B0
	// (set) Token: 0x06000F5B RID: 3931 RVA: 0x0000D4B8 File Offset: 0x0000B6B8
	public int Experience { get; set; }

	// Token: 0x170000CC RID: 204
	// (get) Token: 0x06000F5C RID: 3932 RVA: 0x0000D4C1 File Offset: 0x0000B6C1
	// (set) Token: 0x06000F5D RID: 3933 RVA: 0x0000D4C9 File Offset: 0x0000B6C9
	public int Level { get; set; }

	// Token: 0x170000CD RID: 205
	// (get) Token: 0x06000F5E RID: 3934 RVA: 0x0000D4D2 File Offset: 0x0000B6D2
	// (set) Token: 0x06000F5F RID: 3935 RVA: 0x0000D4DA File Offset: 0x0000B6DA
	public AvatarType AvatarType { get; set; }

	// Token: 0x170000CE RID: 206
	// (get) Token: 0x06000F60 RID: 3936 RVA: 0x0000D4E3 File Offset: 0x0000B6E3
	// (set) Token: 0x06000F61 RID: 3937 RVA: 0x0000D4EB File Offset: 0x0000B6EB
	public string AvatarParts { get; set; }

	// Token: 0x170000CF RID: 207
	// (get) Token: 0x06000F62 RID: 3938 RVA: 0x0000D4F4 File Offset: 0x0000B6F4
	// (set) Token: 0x06000F63 RID: 3939 RVA: 0x0000D4FC File Offset: 0x0000B6FC
	public string AvatarMaterials { get; set; }

	// Token: 0x170000D0 RID: 208
	// (get) Token: 0x06000F64 RID: 3940 RVA: 0x0000D505 File Offset: 0x0000B705
	// (set) Token: 0x06000F65 RID: 3941 RVA: 0x0000D50D File Offset: 0x0000B70D
	public uint AvatarId { get; set; }

	// Token: 0x170000D1 RID: 209
	// (get) Token: 0x06000F66 RID: 3942 RVA: 0x0000D516 File Offset: 0x0000B716
	// (set) Token: 0x06000F67 RID: 3943 RVA: 0x0000D51E File Offset: 0x0000B71E
	public int TimePlayed { get; set; }

	// Token: 0x170000D2 RID: 210
	// (get) Token: 0x06000F68 RID: 3944 RVA: 0x0000D527 File Offset: 0x0000B727
	// (set) Token: 0x06000F69 RID: 3945 RVA: 0x0000D52F File Offset: 0x0000B72F
	public int LadderValue { get; set; }

	// Token: 0x170000D3 RID: 211
	// (get) Token: 0x06000F6A RID: 3946 RVA: 0x0000D538 File Offset: 0x0000B738
	// (set) Token: 0x06000F6B RID: 3947 RVA: 0x0000D540 File Offset: 0x0000B740
	public LadderTier Tier { get; set; }

	// Token: 0x170000D4 RID: 212
	// (get) Token: 0x06000F6C RID: 3948 RVA: 0x0000D549 File Offset: 0x0000B749
	// (set) Token: 0x06000F6D RID: 3949 RVA: 0x0000D551 File Offset: 0x0000B751
	public LadderGrade Grade { get; set; }

	// Token: 0x170000D5 RID: 213
	// (get) Token: 0x06000F6E RID: 3950 RVA: 0x0000D55A File Offset: 0x0000B75A
	// (set) Token: 0x06000F6F RID: 3951 RVA: 0x0000D562 File Offset: 0x0000B762
	public int Energy { get; set; }

	// Token: 0x170000D6 RID: 214
	// (get) Token: 0x06000F70 RID: 3952 RVA: 0x0000D56B File Offset: 0x0000B76B
	// (set) Token: 0x06000F71 RID: 3953 RVA: 0x0000D573 File Offset: 0x0000B773
	public Inventory Inventory { get; set; }

	// Token: 0x170000D7 RID: 215
	// (get) Token: 0x06000F72 RID: 3954 RVA: 0x0000D57C File Offset: 0x0000B77C
	// (set) Token: 0x06000F73 RID: 3955 RVA: 0x0000D584 File Offset: 0x0000B784
	public CurrencyInfo Currency { get; set; }

	// Token: 0x170000D8 RID: 216
	// (get) Token: 0x06000F74 RID: 3956 RVA: 0x0000D58D File Offset: 0x0000B78D
	// (set) Token: 0x06000F75 RID: 3957 RVA: 0x0000D595 File Offset: 0x0000B795
	public QuestInfo QuestList { get; set; }

	// Token: 0x170000D9 RID: 217
	// (get) Token: 0x06000F76 RID: 3958 RVA: 0x0000D59E File Offset: 0x0000B79E
	// (set) Token: 0x06000F77 RID: 3959 RVA: 0x0000D5A6 File Offset: 0x0000B7A6
	public InstanceInfo Instances { get; set; }

	// Token: 0x170000DA RID: 218
	// (get) Token: 0x06000F78 RID: 3960 RVA: 0x0000D5AF File Offset: 0x0000B7AF
	// (set) Token: 0x06000F79 RID: 3961 RVA: 0x0000D5B7 File Offset: 0x0000B7B7
	public global::SkillTree Skills { get; set; }
}
