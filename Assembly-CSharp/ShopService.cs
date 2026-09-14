using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020003DF RID: 991
public class ShopService : OnAccessSingleton<IShopService, ShopService, ShopServiceOffline>, IShopService
{
	// Token: 0x060018E7 RID: 6375 RVA: 0x00082F9C File Offset: 0x0008119C
	public ShopService()
	{
		PhotonNetwork.onlinePeer.method_5(121, new OperationResponseCallback(this.OnGetShopResponse));
		PhotonNetwork.onlinePeer.method_5(120, new OperationResponseCallback(this.OnBuyItemResponse));
		PhotonNetwork.onlinePeer.method_5(119, new OperationResponseCallback(this.OnSellItemResponse));
		PhotonNetwork.onlinePeer.method_5(54, new OperationResponseCallback(this.OnRedeemItemResponse));
		PhotonNetwork.onlinePeer.method_5(49, new OperationResponseCallback(this.OnGetCashShopResponse));
		PhotonNetwork.onlinePeer.method_5(48, new OperationResponseCallback(this.OnBuyCashItemResponse));
	}

	// Token: 0x060018E8 RID: 6376 RVA: 0x000129E6 File Offset: 0x00010BE6
	public void imethod_0(OnGetShop onGetShop_0, int int_0)
	{
		if (onGetShop_0 != null)
		{
			this.mOnGetShop.Add(onGetShop_0);
		}
		PhotonNetwork.onlinePeer.method_3(121, new object[] { int_0 });
	}

	// Token: 0x060018E9 RID: 6377 RVA: 0x00012A13 File Offset: 0x00010C13
	public void imethod_1(OnBuyItem onBuyItem_0, int int_0, int int_1)
	{
		this.imethod_2(onBuyItem_0, int_0, int_1, 1);
	}

	// Token: 0x060018EA RID: 6378 RVA: 0x00012A1F File Offset: 0x00010C1F
	public void imethod_2(OnBuyItem onBuyItem_0, int int_0, int int_1, int int_2)
	{
		if (onBuyItem_0 != null)
		{
			this.mOnBuyItem.Add(onBuyItem_0);
		}
		PhotonNetwork.onlinePeer.method_3(120, new object[] { int_0, int_1, int_2 });
	}

	// Token: 0x060018EB RID: 6379 RVA: 0x00012A5F File Offset: 0x00010C5F
	public void imethod_3(OnRedeemItem onRedeemItem_0, int int_0, int int_1)
	{
		this.imethod_4(onRedeemItem_0, int_0, int_1, 1);
	}

	// Token: 0x060018EC RID: 6380 RVA: 0x00083088 File Offset: 0x00081288
	public void imethod_4(OnRedeemItem onRedeemItem_0, int int_0, int int_1, int int_2)
	{
		if (onRedeemItem_0 != null)
		{
			this.mOnRedeemItem.Add(onRedeemItem_0);
		}
		PhotonNetwork.onlinePeer.method_3(54, new object[]
		{
			int_0,
			int_1 + 14,
			int_2
		});
	}

	// Token: 0x060018ED RID: 6381 RVA: 0x00012A6B File Offset: 0x00010C6B
	public void imethod_5(OnSellItem onSellItem_0, int int_0, int int_1)
	{
		this.imethod_6(onSellItem_0, int_0, int_1, 1);
	}

	// Token: 0x060018EE RID: 6382 RVA: 0x00012A77 File Offset: 0x00010C77
	public void imethod_6(OnSellItem onSellItem_0, int int_0, int int_1, int int_2)
	{
		if (onSellItem_0 != null)
		{
			this.mOnSellItem.Add(onSellItem_0);
		}
		PhotonNetwork.onlinePeer.method_3(119, new object[] { int_0, int_1, int_2 });
	}

	// Token: 0x060018EF RID: 6383 RVA: 0x000830D8 File Offset: 0x000812D8
	private void OnGetShopResponse(short result, Dictionary<byte, object> parameters)
	{
		if (result == 0)
		{
			Shop shop = new Shop((Hashtable)parameters[0]);
			mOnGetShop.ForEach(delegate(OnGetShop onGetShop_0)
			{
				onGetShop_0(shop);
			});
		}
		else
		{
			mOnGetShop.ForEach(delegate(OnGetShop onGetShop_0)
			{
				onGetShop_0(null);
			});
		}
		mOnGetShop.Clear();
	}
	// Token: 0x060018F0 RID: 6384 RVA: 0x00083154 File Offset: 0x00081354
	private void OnBuyItemResponse(short result, Dictionary<byte, object> parameters)
	{
		if (result == 0)
		{
			ItemDNA newItem = ItemDNA.smethod_12((Hashtable)parameters[0]);
			mOnBuyItem.ForEach(delegate(OnBuyItem onBuyItem_0)
			{
				onBuyItem_0(newItem);
			});
		}
		else
		{
			mOnBuyItem.ForEach(delegate(OnBuyItem onBuyItem_0)
			{
				onBuyItem_0(null);
			});
		}
		mOnBuyItem.Clear();
	}
	// Token: 0x060018F1 RID: 6385 RVA: 0x000831D0 File Offset: 0x000813D0
	private void OnSellItemResponse(short result, Dictionary<byte, object> parameters)
	{
		if (result == 0)
		{
			int sellPrice = (int)parameters[0];
			ItemDNA soldItem = ItemDNA.smethod_12((Hashtable)parameters[1]);
			Hashtable hashtable = (Hashtable)parameters[2];
			Dictionary<int, ShopItem> redeemableItems = new Dictionary<int, ShopItem>();
			foreach (DictionaryEntry item in hashtable)
			{
				redeemableItems[(int)item.Key] = new ShopItem((Hashtable)item.Value);
			}
			mOnSellItem.ForEach(delegate(OnSellItem onSellItem_0)
			{
				onSellItem_0(sellPrice, soldItem, redeemableItems);
			});
		}
		else
		{
			mOnSellItem.ForEach(delegate(OnSellItem onSellItem_0)
			{
				onSellItem_0(0, null, null);
			});
		}
		mOnSellItem.Clear();
	}
	// Token: 0x060018F2 RID: 6386 RVA: 0x000832E4 File Offset: 0x000814E4
	private void OnRedeemItemResponse(short result, Dictionary<byte, object> parameters)
	{
		if (result == 0)
		{
			ItemDNA redeemedItem = ItemDNA.smethod_12((Hashtable)parameters[0]);
			Hashtable hashtable = (Hashtable)parameters[1];
			Dictionary<int, ShopItem> redeemableItems = new Dictionary<int, ShopItem>();
			foreach (DictionaryEntry item in hashtable)
			{
				redeemableItems[(int)item.Key] = new ShopItem((Hashtable)item.Value);
			}
			mOnRedeemItem.ForEach(delegate(OnRedeemItem onRedeemItem_0)
			{
				onRedeemItem_0(redeemedItem, redeemableItems);
			});
		}
		else
		{
			mOnRedeemItem.ForEach(delegate(OnRedeemItem onRedeemItem_0)
			{
				onRedeemItem_0(null, null);
			});
		}
		mOnRedeemItem.Clear();
	}
	// Token: 0x060018F3 RID: 6387 RVA: 0x00012AB7 File Offset: 0x00010CB7
	public void imethod_7(OnGetCashShop onGetCashShop_0)
	{
		if (onGetCashShop_0 != null)
		{
			this.mOnGetCashShop.Add(onGetCashShop_0);
		}
		PhotonNetwork.onlinePeer.method_3(49, new object[0]);
	}

	// Token: 0x060018F4 RID: 6388 RVA: 0x000833E8 File Offset: 0x000815E8
	private void OnGetCashShopResponse(short result, Dictionary<byte, object> parameters)
	{
		Hashtable hashtable = (Hashtable)parameters[0];
		List<OfferItem> itemlist = new List<OfferItem>();
		foreach (DictionaryEntry item2 in hashtable)
		{
			OfferItem item = new OfferItem((Hashtable)item2.Value);
			itemlist.Add(item);
		}
		mOnGetCashShop.ForEach(delegate(OnGetCashShop onGetCashShop_0)
		{
			onGetCashShop_0(itemlist);
		});
		mOnGetCashShop.Clear();
	}
	// Token: 0x060018F5 RID: 6389 RVA: 0x0008349C File Offset: 0x0008169C
	public void imethod_8(OnBuyCashItem onBuyCashItem_0, List<CashShopItem> list_0)
	{
		if (onBuyCashItem_0 != null)
		{
			this.mOnBuyCashItem.Add(onBuyCashItem_0);
		}
		Hashtable hashtable = new Hashtable();
		for (int i = 0; i < list_0.Count; i++)
		{
			Hashtable hashtable2 = new Hashtable
			{
				{
					0,
					list_0[i].OfferId
				},
				{
					1,
					list_0[i].Amount
				}
			};
			hashtable[i] = hashtable2;
		}
		PhotonNetwork.onlinePeer.method_3(48, new object[] { hashtable });
	}

	// Token: 0x060018F6 RID: 6390 RVA: 0x00083538 File Offset: 0x00081738
	private void OnBuyCashItemResponse(short result, Dictionary<byte, object> parameters)
	{
		mOnBuyCashItem.ForEach(delegate(OnBuyCashItem onBuyCashItem_0)
		{
			onBuyCashItem_0(result);
		});
		mOnBuyCashItem.Clear();
	}
	// Token: 0x060018F7 RID: 6391 RVA: 0x00012ADB File Offset: 0x00010CDB
	[CompilerGenerated]
	private static void smethod_0(OnGetShop onGetShop_0)
	{
		onGetShop_0(null);
	}

	// Token: 0x060018F8 RID: 6392 RVA: 0x00012AE4 File Offset: 0x00010CE4
	[CompilerGenerated]
	private static void smethod_1(OnBuyItem onBuyItem_0)
	{
		onBuyItem_0(null);
	}

	// Token: 0x060018F9 RID: 6393 RVA: 0x00012AED File Offset: 0x00010CED
	[CompilerGenerated]
	private static void smethod_2(OnSellItem onSellItem_0)
	{
		onSellItem_0(0, null, null);
	}

	// Token: 0x060018FA RID: 6394 RVA: 0x00012AF8 File Offset: 0x00010CF8
	[CompilerGenerated]
	private static void smethod_3(OnRedeemItem onRedeemItem_0)
	{
		onRedeemItem_0(null, null);
	}

	// Token: 0x040010FB RID: 4347
	private List<OnGetShop> mOnGetShop = new List<OnGetShop>();

	// Token: 0x040010FC RID: 4348
	private List<OnBuyItem> mOnBuyItem = new List<OnBuyItem>();

	// Token: 0x040010FD RID: 4349
	private List<OnSellItem> mOnSellItem = new List<OnSellItem>();

	// Token: 0x040010FE RID: 4350
	private List<OnRedeemItem> mOnRedeemItem = new List<OnRedeemItem>();

	// Token: 0x040010FF RID: 4351
	private List<OnGetCashShop> mOnGetCashShop = new List<OnGetCashShop>();

	// Token: 0x04001100 RID: 4352
	private List<OnBuyCashItem> mOnBuyCashItem = new List<OnBuyCashItem>();
}
