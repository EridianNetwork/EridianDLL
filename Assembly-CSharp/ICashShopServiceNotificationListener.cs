using System;
using System.Collections.Generic;

// Token: 0x020003ED RID: 1005
public interface ICashShopServiceNotificationListener
{
	// Token: 0x0600192F RID: 6447
	void OnGetCashShop(List<OfferItem> listOfferItems);

	// Token: 0x06001930 RID: 6448
	void OnBuyCashItem(int iResult);
}
