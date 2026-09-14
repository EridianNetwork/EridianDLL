using System;
using System.Collections.Generic;

// Token: 0x02000301 RID: 769
public interface IShopService
{
	// Token: 0x060011E9 RID: 4585
	void imethod_0(OnGetShop onGetShop_0, int int_0);

	// Token: 0x060011EA RID: 4586
	void imethod_1(OnBuyItem onBuyItem_0, int int_0, int int_1);

	// Token: 0x060011EB RID: 4587
	void imethod_2(OnBuyItem onBuyItem_0, int int_0, int int_1, int int_2);

	// Token: 0x060011EC RID: 4588
	void imethod_3(OnRedeemItem onRedeemItem_0, int int_0, int int_1);

	// Token: 0x060011ED RID: 4589
	void imethod_4(OnRedeemItem onRedeemItem_0, int int_0, int int_1, int int_2);

	// Token: 0x060011EE RID: 4590
	void imethod_5(OnSellItem onSellItem_0, int int_0, int int_1);

	// Token: 0x060011EF RID: 4591
	void imethod_6(OnSellItem onSellItem_0, int int_0, int int_1, int int_2);

	// Token: 0x060011F0 RID: 4592
	void imethod_7(OnGetCashShop onGetCashShop_0);

	// Token: 0x060011F1 RID: 4593
	void imethod_8(OnBuyCashItem onBuyCashItem_0, List<CashShopItem> list_0);
}
