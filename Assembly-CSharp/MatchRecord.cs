using System;
using System.Collections;
using System.Collections.Generic;
using XsdSettings;

// Token: 0x020003B7 RID: 951
public class MatchRecord
{
	// Token: 0x060017FE RID: 6142 RVA: 0x00080610 File Offset: 0x0007E810
	public MatchRecord(Hashtable hashtable_0)
	{
		this.CharacterId = Convert.ToInt32(hashtable_0[0]);
		this.TotalMatchCount = Convert.ToInt32(hashtable_0[1]);
		this.TotalHonorPoint = Convert.ToInt32(hashtable_0[2]);
		this.TotalWinCount = Convert.ToInt32(hashtable_0[3]);
		this.TotalLossCount = Convert.ToInt32(hashtable_0[4]);
		this.TotalKillCount = Convert.ToInt32(hashtable_0[5]);
		this.TotalDeathCount = Convert.ToInt32(hashtable_0[6]);
		this.TotalMeleeKill = Convert.ToInt32(hashtable_0[7]);
		this.TotalGrenadeKill = Convert.ToInt32(hashtable_0[8]);
		if (hashtable_0[9] != null)
		{
			Hashtable[] array = (Hashtable[])hashtable_0[9];
			this.method_0<GamemodeType>(array, ref this.mMatchTypeFactors);
		}
		if (hashtable_0[10] != null)
		{
			Hashtable[] array2 = (Hashtable[])hashtable_0[10];
			this.method_0<int>(array2, ref this.mLevelTypeFactors);
		}
		if (hashtable_0[11] != null)
		{
			Hashtable[] array3 = (Hashtable[])hashtable_0[11];
			this.method_0<AvatarType>(array3, ref this.mSkillTypeFactors);
		}
		if (hashtable_0[12] != null)
		{
			Hashtable[] array4 = (Hashtable[])hashtable_0[12];
			this.method_0<WeaponType>(array4, ref this.mWeaponTypeFactors);
		}
	}

	// Token: 0x17000139 RID: 313
	// (get) Token: 0x060017FF RID: 6143 RVA: 0x00011D68 File Offset: 0x0000FF68
	// (set) Token: 0x06001800 RID: 6144 RVA: 0x00011D70 File Offset: 0x0000FF70
	public int TotalMatchCount { get; set; }

	// Token: 0x1700013A RID: 314
	// (get) Token: 0x06001801 RID: 6145 RVA: 0x00011D79 File Offset: 0x0000FF79
	// (set) Token: 0x06001802 RID: 6146 RVA: 0x00011D81 File Offset: 0x0000FF81
	public int TotalHonorPoint { get; set; }

	// Token: 0x1700013B RID: 315
	// (get) Token: 0x06001803 RID: 6147 RVA: 0x00011D8A File Offset: 0x0000FF8A
	// (set) Token: 0x06001804 RID: 6148 RVA: 0x00011D92 File Offset: 0x0000FF92
	public int TotalWinCount { get; set; }

	// Token: 0x1700013C RID: 316
	// (get) Token: 0x06001805 RID: 6149 RVA: 0x00011D9B File Offset: 0x0000FF9B
	// (set) Token: 0x06001806 RID: 6150 RVA: 0x00011DA3 File Offset: 0x0000FFA3
	public int TotalLossCount { get; set; }

	// Token: 0x1700013D RID: 317
	// (get) Token: 0x06001807 RID: 6151 RVA: 0x00011DAC File Offset: 0x0000FFAC
	// (set) Token: 0x06001808 RID: 6152 RVA: 0x00011DB4 File Offset: 0x0000FFB4
	public int TotalKillCount { get; set; }

	// Token: 0x1700013E RID: 318
	// (get) Token: 0x06001809 RID: 6153 RVA: 0x00011DBD File Offset: 0x0000FFBD
	// (set) Token: 0x0600180A RID: 6154 RVA: 0x00011DC5 File Offset: 0x0000FFC5
	public int TotalDeathCount { get; set; }

	// Token: 0x1700013F RID: 319
	// (get) Token: 0x0600180B RID: 6155 RVA: 0x00011DCE File Offset: 0x0000FFCE
	// (set) Token: 0x0600180C RID: 6156 RVA: 0x00011DD6 File Offset: 0x0000FFD6
	public int TotalMeleeKill { get; set; }

	// Token: 0x17000140 RID: 320
	// (get) Token: 0x0600180D RID: 6157 RVA: 0x00011DDF File Offset: 0x0000FFDF
	// (set) Token: 0x0600180E RID: 6158 RVA: 0x00011DE7 File Offset: 0x0000FFE7
	public int TotalGrenadeKill { get; set; }

	// Token: 0x17000141 RID: 321
	// (get) Token: 0x0600180F RID: 6159 RVA: 0x00011DF0 File Offset: 0x0000FFF0
	// (set) Token: 0x06001810 RID: 6160 RVA: 0x00011DF8 File Offset: 0x0000FFF8
	public int CharacterId { get; set; }

	// Token: 0x17000142 RID: 322
	// (get) Token: 0x06001811 RID: 6161 RVA: 0x00011E01 File Offset: 0x00010001
	public Dictionary<GamemodeType, Hashtable> Dictionary_0
	{
		get
		{
			return this.mMatchTypeFactors;
		}
	}

	// Token: 0x17000143 RID: 323
	// (get) Token: 0x06001812 RID: 6162 RVA: 0x00011E09 File Offset: 0x00010009
	public Dictionary<int, Hashtable> Dictionary_1
	{
		get
		{
			return this.mLevelTypeFactors;
		}
	}

	// Token: 0x17000144 RID: 324
	// (get) Token: 0x06001813 RID: 6163 RVA: 0x00011E11 File Offset: 0x00010011
	public Dictionary<AvatarType, Hashtable> Dictionary_2
	{
		get
		{
			return this.mSkillTypeFactors;
		}
	}

	// Token: 0x17000145 RID: 325
	// (get) Token: 0x06001814 RID: 6164 RVA: 0x00011E19 File Offset: 0x00010019
	public Dictionary<WeaponType, Hashtable> Dictionary_3
	{
		get
		{
			return this.mWeaponTypeFactors;
		}
	}

	// Token: 0x06001815 RID: 6165 RVA: 0x000807DC File Offset: 0x0007E9DC
	private void method_0<T>(Hashtable[] hashtable_0, ref Dictionary<T, Hashtable> dictionary_0)
	{
		foreach (Hashtable hashtable in hashtable_0)
		{
			Hashtable hashtable2 = new Hashtable();
			T t = (T)((object)hashtable[0]);
			foreach (object obj in hashtable.Keys)
			{
				if ((int)obj != 0)
				{
					int num = Convert.ToInt32(obj) - 1;
					hashtable2[num] = Convert.ToInt32(hashtable[obj]);
				}
			}
			dictionary_0.Add(t, hashtable2);
		}
	}

	// Token: 0x0400104C RID: 4172
	public Dictionary<GamemodeType, Hashtable> mMatchTypeFactors = new Dictionary<GamemodeType, Hashtable>();

	// Token: 0x0400104D RID: 4173
	public Dictionary<int, Hashtable> mLevelTypeFactors = new Dictionary<int, Hashtable>();

	// Token: 0x0400104E RID: 4174
	public Dictionary<AvatarType, Hashtable> mSkillTypeFactors = new Dictionary<AvatarType, Hashtable>();

	// Token: 0x0400104F RID: 4175
	public Dictionary<WeaponType, Hashtable> mWeaponTypeFactors = new Dictionary<WeaponType, Hashtable>();
}
