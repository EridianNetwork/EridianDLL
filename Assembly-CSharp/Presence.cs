using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using XsdSettings;

// Token: 0x020003C7 RID: 967
public class Presence
{
	// Token: 0x0600186B RID: 6251 RVA: 0x00081818 File Offset: 0x0007FA18
	public Presence(Dictionary<byte, object> dictionary_0)
	{
		this.mCharacterId = (int)dictionary_0[0];
		this.mIsOnline = Convert.ToBoolean(dictionary_0[1]);
		this.mLastOnline = this.EPOCH.AddSeconds((double)((int)dictionary_0[2])).ToLocalTime();
		this.mCurrentTown = ((dictionary_0[3] != null) ? ((int)dictionary_0[3]) : (-1));
		this.mCharacterLevel = (int)dictionary_0[4];
		this.mCharacterExperience = (int)dictionary_0[5];
		this.mCurrency = (int)dictionary_0[6];
		this.mAvatarType = (AvatarType)((int)dictionary_0[7]);
		string text = (string)dictionary_0[8];
		string text2 = (string)dictionary_0[9];
		uint num = (uint)((int)dictionary_0[10]);
		this.mAvatarDNA = new AvatarDNA();
		this.mAvatarDNA.method_8(this.mAvatarType, text, text2, num);
		this.mCharacterName = (string)dictionary_0[11];
		this.mGroupId = (int)dictionary_0[13];
		this.mLobbyId = (int)dictionary_0[14];
		this.mLadderValue = Convert.ToInt32(dictionary_0[15]);
		this.mCurrentPlaylist = (int)dictionary_0[16];
		this.mMatchCount = ((!dictionary_0.ContainsKey(17)) ? 0 : Convert.ToInt32(dictionary_0[17]));
		this.mWinCount = ((!dictionary_0.ContainsKey(18)) ? 0 : Convert.ToInt32(dictionary_0[18]));
		this.mLossCount = ((!dictionary_0.ContainsKey(19)) ? 0 : Convert.ToInt32(dictionary_0[19]));
		this.mKillCount = ((!dictionary_0.ContainsKey(20)) ? 0 : Convert.ToInt32(dictionary_0[20]));
		this.mDeathCount = ((!dictionary_0.ContainsKey(21)) ? 0 : Convert.ToInt32(dictionary_0[21]));
		this.mHonorPoint = ((!dictionary_0.ContainsKey(22)) ? 0 : Convert.ToInt32(dictionary_0[22]));
	}

	// Token: 0x0600186C RID: 6252 RVA: 0x00081A58 File Offset: 0x0007FC58
	public Presence(Hashtable hashtable_0)
		: this(hashtable_0.Cast<DictionaryEntry>().ToDictionary<DictionaryEntry, byte, object>(new Func<DictionaryEntry, byte>(Presence.smethod_0), new Func<DictionaryEntry, object>(Presence.smethod_1)))
	{
	}

	// Token: 0x0600186D RID: 6253 RVA: 0x00012383 File Offset: 0x00010583
	[CompilerGenerated]
	private static byte smethod_0(DictionaryEntry dictionaryEntry_0)
	{
		return (byte)((int)dictionaryEntry_0.Key);
	}

	// Token: 0x0600186E RID: 6254 RVA: 0x00012392 File Offset: 0x00010592
	[CompilerGenerated]
	private static object smethod_1(DictionaryEntry dictionaryEntry_0)
	{
		return dictionaryEntry_0.Value;
	}

	// Token: 0x0400108D RID: 4237
	public readonly DateTime EPOCH = new DateTime(1970, 1, 1, 0, 0, 0, 0);

	// Token: 0x0400108E RID: 4238
	public int mCharacterId;

	// Token: 0x0400108F RID: 4239
	public bool mIsOnline;

	// Token: 0x04001090 RID: 4240
	public DateTime mLastOnline;

	// Token: 0x04001091 RID: 4241
	public int mCurrentTown;

	// Token: 0x04001092 RID: 4242
	public string mCharacterName;

	// Token: 0x04001093 RID: 4243
	public int mCharacterLevel;

	// Token: 0x04001094 RID: 4244
	public int mCharacterExperience;

	// Token: 0x04001095 RID: 4245
	public int mCurrency;

	// Token: 0x04001096 RID: 4246
	public AvatarType mAvatarType;

	// Token: 0x04001097 RID: 4247
	public int mGroupId;

	// Token: 0x04001098 RID: 4248
	public int mLobbyId;

	// Token: 0x04001099 RID: 4249
	public int mLadderValue;

	// Token: 0x0400109A RID: 4250
	public int mCurrentPlaylist;

	// Token: 0x0400109B RID: 4251
	public int mMatchCount;

	// Token: 0x0400109C RID: 4252
	public int mWinCount;

	// Token: 0x0400109D RID: 4253
	public int mLossCount;

	// Token: 0x0400109E RID: 4254
	public int mKillCount;

	// Token: 0x0400109F RID: 4255
	public int mDeathCount;

	// Token: 0x040010A0 RID: 4256
	public int mHonorPoint;

	// Token: 0x040010A1 RID: 4257
	public AvatarDNA mAvatarDNA;
}
