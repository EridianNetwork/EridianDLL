using System;
using System.Collections.Generic;

// Token: 0x0200032F RID: 815
public class ShopServiceOffline : IShopService
{
	// Token: 0x06001454 RID: 5204 RVA: 0x0000F33F File Offset: 0x0000D53F
	public void imethod_0(OnGetShop onGetShop_0, int int_0)
	{
		if (onGetShop_0 != null)
		{
			onGetShop_0(null);
		}
	}

	// Token: 0x06001455 RID: 5205 RVA: 0x0000F34B File Offset: 0x0000D54B
	public void imethod_1(OnBuyItem onBuyItem_0, int int_0, int int_1)
	{
		this.imethod_2(onBuyItem_0, int_0, int_1, 1);
	}

	// Token: 0x06001456 RID: 5206 RVA: 0x0000F357 File Offset: 0x0000D557
	public void imethod_2(OnBuyItem onBuyItem_0, int int_0, int int_1, int int_2)
	{
		if (onBuyItem_0 != null)
		{
			onBuyItem_0(null);
		}
	}

	// Token: 0x06001457 RID: 5207 RVA: 0x0000F363 File Offset: 0x0000D563
	public void imethod_3(OnRedeemItem onRedeemItem_0, int int_0, int int_1)
	{
		this.imethod_4(onRedeemItem_0, int_0, int_1, 1);
	}

	// Token: 0x06001458 RID: 5208 RVA: 0x0000F36F File Offset: 0x0000D56F
	public void imethod_4(OnRedeemItem onRedeemItem_0, int int_0, int int_1, int int_2)
	{
		if (onRedeemItem_0 != null)
		{
			onRedeemItem_0(null, null);
		}
	}

	// Token: 0x06001459 RID: 5209 RVA: 0x0000F37C File Offset: 0x0000D57C
	public void imethod_5(OnSellItem onSellItem_0, int int_0, int int_1)
	{
		this.imethod_6(onSellItem_0, int_0, int_1, 1);
	}

	// Token: 0x0600145A RID: 5210 RVA: 0x0000F388 File Offset: 0x0000D588
	public void imethod_6(OnSellItem onSellItem_0, int int_0, int int_1, int int_2)
	{
		if (onSellItem_0 != null)
		{
			onSellItem_0(0, null, null);
		}
	}

	// Token: 0x0600145B RID: 5211 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_7(OnGetCashShop onGetCashShop_0)
	{
	}

	// Token: 0x0600145C RID: 5212 RVA: 0x0000311B File Offset: 0x0000131B
	public void imethod_8(OnBuyCashItem onBuyCashItem_0, List<CashShopItem> list_0)
	{
	}
}
