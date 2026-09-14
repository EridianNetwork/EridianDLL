using System;
using System.Collections.Generic;

// Token: 0x0200036B RID: 875
internal class CurrencyService : OnAccessSingleton<ICurrencyService, CurrencyService, CurrencyServiceOffline>, ICurrencyService
{
	// Token: 0x06001604 RID: 5636 RVA: 0x0007B160 File Offset: 0x00079360
	public CurrencyService()
	{
		PhotonNetwork.onlinePeer.method_5(187, new OperationResponseCallback(this.OnCurrenciesReceived));
		PhotonNetwork.onlinePeer.method_5(156, new OperationResponseCallback(this.OnCurrenciesReceived));
		PhotonNetwork.onlinePeer.method_5(55, new OperationResponseCallback(this.OnGetSndaPoint));
		PhotonNetwork.onlinePeer.method_7(218, new EventCallback(this.OnCurrenciesUpdatedEvent));
		PhotonNetwork.onlinePeer.method_7(156, new EventCallback(this.OnSndaPointUpdatedEvent));
	}

	// Token: 0x06001605 RID: 5637 RVA: 0x000101C2 File Offset: 0x0000E3C2
	public void imethod_0(OnGotCurrencies onGotCurrencies_0)
	{
		this.mOnGotCurrencies = onGotCurrencies_0;
		PhotonNetwork.onlinePeer.method_3(156, new object[0]);
	}

	// Token: 0x06001606 RID: 5638 RVA: 0x000101E1 File Offset: 0x0000E3E1
	public void imethod_1()
	{
		PhotonNetwork.onlinePeer.method_3(55, new object[0]);
	}

	// Token: 0x06001607 RID: 5639 RVA: 0x000101F6 File Offset: 0x0000E3F6
	public void method_0(OnGotCurrencies onGotCurrencies_0, int int_0)
	{
		if (onGotCurrencies_0 != null)
		{
			this.mOnGotCurrencies = onGotCurrencies_0;
		}
		PhotonNetwork.onlinePeer.method_3(187, new object[] { int_0 });
	}

	// Token: 0x06001608 RID: 5640 RVA: 0x0007B210 File Offset: 0x00079410
	private void OnCurrenciesReceived(short operationResponse, Dictionary<byte, object> parameters)
	{
		if (this.mOnGotCurrencies != null)
		{
			if (operationResponse == 0)
			{
				this.mOnGotCurrencies((int)parameters[0], (int)parameters[1], (int)parameters[2], (int)parameters[3]);
			}
			else
			{
				this.mOnGotCurrencies(-1, -1, -1, -1);
			}
			this.mOnGotCurrencies = null;
		}
	}

	// Token: 0x06001609 RID: 5641 RVA: 0x0000311B File Offset: 0x0000131B
	private void OnGetSndaPoint(short operationResponse, Dictionary<byte, object> parameters)
	{
	}

	// Token: 0x0600160A RID: 5642 RVA: 0x0007B27C File Offset: 0x0007947C
	private void OnCurrenciesUpdatedEvent(Dictionary<byte, object> parameters)
	{
		int bondCurrency = (int)parameters[0];
		int specialCurrency = (int)parameters[1];
		int circulateCurrency = (int)parameters[2];
		mOnCurrenciesUpdated.ForEach(delegate(OnCurrenciesUpdated onCurrenciesUpdated_0)
		{
			onCurrenciesUpdated_0(bondCurrency, circulateCurrency, specialCurrency);
		});
	}
	// Token: 0x0600160B RID: 5643 RVA: 0x00010221 File Offset: 0x0000E421
	public void imethod_2(OnCurrenciesUpdated onCurrenciesUpdated_0)
	{
		this.mOnCurrenciesUpdated.Add(onCurrenciesUpdated_0);
	}

	// Token: 0x0600160C RID: 5644 RVA: 0x0001022F File Offset: 0x0000E42F
	public void imethod_3(OnCurrenciesUpdated onCurrenciesUpdated_0)
	{
		this.mOnCurrenciesUpdated.Remove(onCurrenciesUpdated_0);
	}

	// Token: 0x0600160D RID: 5645 RVA: 0x0007B2DC File Offset: 0x000794DC
	private void OnSndaPointUpdatedEvent(Dictionary<byte, object> parameters)
	{
		int result = (int)parameters[0];
		string description = (string)parameters[1];
		int sndapoint = (int)parameters[2];
		mOnSndaPointUpdated.ForEach(delegate(OnSndaPointUpdated onSndaPointUpdated_0)
		{
			onSndaPointUpdated_0(result, description, sndapoint);
		});
	}
	// Token: 0x0600160E RID: 5646 RVA: 0x0001023E File Offset: 0x0000E43E
	public void imethod_4(OnSndaPointUpdated onSndaPointUpdated_0)
	{
		this.mOnSndaPointUpdated.Add(onSndaPointUpdated_0);
	}

	// Token: 0x0600160F RID: 5647 RVA: 0x0001024C File Offset: 0x0000E44C
	public void imethod_5(OnSndaPointUpdated onSndaPointUpdated_0)
	{
		this.mOnSndaPointUpdated.Remove(onSndaPointUpdated_0);
	}

	// Token: 0x06001610 RID: 5648 RVA: 0x0001025B File Offset: 0x0000E45B
	public void method_1(int int_0, int int_1, int int_2, int int_3)
	{
		PhotonNetwork.onlinePeer.method_3(186, new object[] { int_0, int_1, int_2, int_3 });
	}

	// Token: 0x04000EEA RID: 3818
	private List<OnCurrenciesUpdated> mOnCurrenciesUpdated = new List<OnCurrenciesUpdated>();

	// Token: 0x04000EEB RID: 3819
	private List<OnSndaPointUpdated> mOnSndaPointUpdated = new List<OnSndaPointUpdated>();

	// Token: 0x04000EEC RID: 3820
	private OnGotCurrencies mOnGotCurrencies;
}
