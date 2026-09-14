using System;
using System.Collections;
using System.Collections.Generic;
using XsdSettings;

// Token: 0x020002D4 RID: 724
public class CurrencyInfo
{
	// Token: 0x06001002 RID: 4098 RVA: 0x0000DA59 File Offset: 0x0000BC59
	public CurrencyInfo()
	{
		this.BondCurrency = 500;
	}

	// Token: 0x06001003 RID: 4099 RVA: 0x0000DA82 File Offset: 0x0000BC82
	public CurrencyInfo(Hashtable hashtable_0)
	{
		this.method_0(hashtable_0);
		OnAccessSingleton<ICurrencyService, CurrencyService, CurrencyServiceOffline>.Prop_0.imethod_2(new OnCurrenciesUpdated(this.OnCurrenciesUpdated));
	}

	// Token: 0x06001004 RID: 4100 RVA: 0x000758E0 File Offset: 0x00073AE0
	public void method_0(Hashtable hashtable_0)
	{
		this.CharacterId = (int)hashtable_0[0];
		this.BondCurrency = (int)hashtable_0[1];
		this.CirculateCurrency = (int)hashtable_0[2];
		this.SpecialCurrency = (int)hashtable_0[3];
		Hashtable hashtable = (Hashtable)hashtable_0[4];
		foreach (object obj in hashtable)
		{
			DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
			this.mKeys[(LuckyBoxRank)((int)dictionaryEntry.Key)] = (int)dictionaryEntry.Value;
		}
		Hashtable hashtable2 = (Hashtable)hashtable_0[5];
		foreach (object obj2 in hashtable2)
		{
			DictionaryEntry dictionaryEntry2 = (DictionaryEntry)obj2;
			Hashtable hashtable3 = (Hashtable)dictionaryEntry2.Value;
			this.mExpiringKeys[(LuckyBoxRank)((int)dictionaryEntry2.Key)] = new ExpiringCurrency(hashtable3);
		}
	}

	// Token: 0x06001005 RID: 4101 RVA: 0x0000DABD File Offset: 0x0000BCBD
	private void OnCurrenciesUpdated(int bondCurrency, int circulateCurrency, int specialCurrency)
	{
		this.BondCurrency = bondCurrency;
		this.CirculateCurrency = circulateCurrency;
		this.SpecialCurrency = specialCurrency;
	}

	// Token: 0x170000DB RID: 219
	// (get) Token: 0x06001006 RID: 4102 RVA: 0x0000DAD4 File Offset: 0x0000BCD4
	// (set) Token: 0x06001007 RID: 4103 RVA: 0x0000DADC File Offset: 0x0000BCDC
	public int CharacterId { get; set; }

	// Token: 0x170000DC RID: 220
	// (get) Token: 0x06001008 RID: 4104 RVA: 0x0000DAE5 File Offset: 0x0000BCE5
	// (set) Token: 0x06001009 RID: 4105 RVA: 0x0000DAED File Offset: 0x0000BCED
	public int BondCurrency { get; set; }

	// Token: 0x170000DD RID: 221
	// (get) Token: 0x0600100A RID: 4106 RVA: 0x0000DAF6 File Offset: 0x0000BCF6
	// (set) Token: 0x0600100B RID: 4107 RVA: 0x0000DAFE File Offset: 0x0000BCFE
	public int CirculateCurrency { get; set; }

	// Token: 0x170000DE RID: 222
	// (get) Token: 0x0600100C RID: 4108 RVA: 0x0000DB07 File Offset: 0x0000BD07
	// (set) Token: 0x0600100D RID: 4109 RVA: 0x0000DB0F File Offset: 0x0000BD0F
	public int SpecialCurrency { get; set; }

	// Token: 0x170000DF RID: 223
	// (get) Token: 0x0600100E RID: 4110 RVA: 0x0000DB18 File Offset: 0x0000BD18
	public Dictionary<LuckyBoxRank, int> Dictionary_0
	{
		get
		{
			return this.mKeys;
		}
	}

	// Token: 0x170000E0 RID: 224
	// (get) Token: 0x0600100F RID: 4111 RVA: 0x0000DB20 File Offset: 0x0000BD20
	public Dictionary<LuckyBoxRank, ExpiringCurrency> Dictionary_1
	{
		get
		{
			return this.mExpiringKeys;
		}
	}

	// Token: 0x04000DBB RID: 3515
	private Dictionary<LuckyBoxRank, int> mKeys = new Dictionary<LuckyBoxRank, int>();

	// Token: 0x04000DBC RID: 3516
	private Dictionary<LuckyBoxRank, ExpiringCurrency> mExpiringKeys = new Dictionary<LuckyBoxRank, ExpiringCurrency>();
}
