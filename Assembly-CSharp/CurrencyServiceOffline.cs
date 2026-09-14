using System;

// Token: 0x0200031F RID: 799
internal class CurrencyServiceOffline : ICurrencyService
{
	// Token: 0x0600136C RID: 4972 RVA: 0x0000EF8C File Offset: 0x0000D18C
	public void imethod_0(OnGotCurrencies onGotCurrencies_0)
	{
		if (onGotCurrencies_0 != null)
		{
			onGotCurrencies_0(-1, 0, -1, -1);
		}
	}

	// Token: 0x0600136D RID: 4973 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_1()
	{
	}

	// Token: 0x0600136E RID: 4974 RVA: 0x0000EF9B File Offset: 0x0000D19B
	public void method_0(OnGotCurrencies onGotCurrencies_0, int int_0)
	{
		if (onGotCurrencies_0 != null)
		{
			onGotCurrencies_0(int_0, 0, -1, -1);
		}
	}

	// Token: 0x0600136F RID: 4975 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_2(OnCurrenciesUpdated onCurrenciesUpdated_0)
	{
	}

	// Token: 0x06001370 RID: 4976 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_3(OnCurrenciesUpdated onCurrenciesUpdated_0)
	{
	}

	// Token: 0x06001371 RID: 4977 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_4(OnSndaPointUpdated onSndaPointUpdated_0)
	{
	}

	// Token: 0x06001372 RID: 4978 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_5(OnSndaPointUpdated onSndaPointUpdated_0)
	{
	}

	// Token: 0x06001373 RID: 4979 RVA: 0x0000311B File Offset: 0x0000131B
	public void method_1(int int_0, int int_1, int int_2, int int_3)
	{
	}
}
