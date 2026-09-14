using System;
using System.Collections.Generic;

// Token: 0x020003EC RID: 1004
public interface IShopServiceNotificationListerner
{
	// Token: 0x0600192A RID: 6442
	void OnBuyItem(ItemDNA itemDna);

	// Token: 0x0600192B RID: 6443
	void OnGetShop(Shop shop);

	// Token: 0x0600192C RID: 6444
	void OnGetSoldItems(Shop soldItems);

	// Token: 0x0600192D RID: 6445
	void OnSellItem(int newBondCurrency, ItemDNA item, Dictionary<int, ShopItem> redeemableItems);

	// Token: 0x0600192E RID: 6446
	void OnRedeemItem(ItemDNA item, Dictionary<int, ShopItem> redeemableItems);
}
