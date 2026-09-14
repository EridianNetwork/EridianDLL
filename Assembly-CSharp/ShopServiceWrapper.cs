using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Core;
using UnityEngine;
using XsdSettings;

// Token: 0x020003EE RID: 1006
public class ShopServiceWrapper : ServiceWrapper<IServiceWrapper, ShopServiceWrapper>
{
	// Token: 0x17000151 RID: 337
	// (get) Token: 0x06001932 RID: 6450 RVA: 0x00012D4B File Offset: 0x00010F4B
	// (set) Token: 0x06001933 RID: 6451 RVA: 0x00012D53 File Offset: 0x00010F53
	public EconomicSettings m_economicSettings { get; private set; }

	// Token: 0x06001934 RID: 6452 RVA: 0x00012D5C File Offset: 0x00010F5C
	public void method_0(IShopServiceNotificationListerner ishopServiceNotificationListerner_0)
	{
		this.m_notificationListeners.Add(ishopServiceNotificationListerner_0);
	}

	// Token: 0x06001935 RID: 6453 RVA: 0x00012D6A File Offset: 0x00010F6A
	public void method_1(IShopServiceNotificationListerner ishopServiceNotificationListerner_0)
	{
		if (this.m_notificationListeners.Contains(ishopServiceNotificationListerner_0))
		{
			this.m_notificationListeners.Remove(ishopServiceNotificationListerner_0);
		}
	}

	// Token: 0x06001936 RID: 6454 RVA: 0x00012D87 File Offset: 0x00010F87
	public void method_2(ICashShopServiceNotificationListener icashShopServiceNotificationListener_0)
	{
		this.m_cashshopListeners.Add(icashShopServiceNotificationListener_0);
	}

	// Token: 0x06001937 RID: 6455 RVA: 0x00012D95 File Offset: 0x00010F95
	public void method_3(ICashShopServiceNotificationListener icashShopServiceNotificationListener_0)
	{
		if (this.m_cashshopListeners.Contains(icashShopServiceNotificationListener_0))
		{
			this.m_cashshopListeners.Remove(icashShopServiceNotificationListener_0);
		}
	}

	// Token: 0x06001938 RID: 6456 RVA: 0x00083EC0 File Offset: 0x000820C0
	public override void vmethod_1()
	{
		base.vmethod_1();
		TextAsset textAsset = (TextAsset)ResourcesLoader.smethod_0("Settings/Shops");
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(ShopSetup));
		this.m_setup = xmlSerializer.Deserialize(new StringReader(textAsset.text)) as ShopSetup;
		Resources.UnloadAsset(textAsset);
		textAsset = (TextAsset)ResourcesLoader.smethod_0("Settings/EconomicSettings");
		xmlSerializer = new XmlSerializer(typeof(EconomicSettings));
		this.m_economicSettings = xmlSerializer.Deserialize(new StringReader(textAsset.text)) as EconomicSettings;
		Resources.UnloadAsset(textAsset);
	}

	// Token: 0x06001939 RID: 6457 RVA: 0x00083F58 File Offset: 0x00082158
	public int method_4(ItemDNA itemDNA_0)
	{
		int num = 0;
		for (int i = 0; i < this.m_economicSettings.m_priceSettings.Length; i++)
		{
			ItemPriceSetting itemPriceSetting = this.m_economicSettings.m_priceSettings[i];
			if (itemPriceSetting.m_adjustements != null && itemDNA_0.m_type == itemPriceSetting.m_itemType)
			{
				num = itemPriceSetting.m_basicValue;
				for (int j = 0; j < itemPriceSetting.m_adjustements.Length; j++)
				{
					if (itemPriceSetting.m_adjustements[j].m_rarety == (WeaponRarity)itemDNA_0.ItemRarity_0)
					{
						return num * (int)((double)itemPriceSetting.m_adjustements[j].m_adjustValue * (double)itemDNA_0.method_0());
					}
				}
			}
		}
		return num;
	}

	// Token: 0x17000152 RID: 338
	// (get) Token: 0x0600193A RID: 6458 RVA: 0x00012DB2 File Offset: 0x00010FB2
	public ShopSetup ShopSetup_0
	{
		get
		{
			return this.m_setup;
		}
	}

	// Token: 0x0600193B RID: 6459 RVA: 0x00083FF4 File Offset: 0x000821F4
	public global::Shop method_5(int int_0, bool bool_1 = false)
	{
		global::Shop shop = null;
		if (!this.m_shops.TryGetValue(int_0, out shop) || bool_1)
		{
			OnAccessSingleton<IShopService, ShopService, ShopServiceOffline>.Prop_0.imethod_0(new OnGetShop(this.OnGetShop), int_0);
		}
		return shop;
	}

	// Token: 0x0600193C RID: 6460 RVA: 0x00012DBA File Offset: 0x00010FBA
	public Dictionary<int, ShopItem> method_6()
	{
		return this.m_soldItemList;
	}

	// Token: 0x0600193D RID: 6461 RVA: 0x00012DC2 File Offset: 0x00010FC2
	public void method_7(int int_0, int int_1, int int_2 = 1)
	{
		OnAccessSingleton<IShopService, ShopService, ShopServiceOffline>.Prop_0.imethod_2(new OnBuyItem(this.OnBuyItem), int_0, int_1, int_2);
	}

	// Token: 0x0600193E RID: 6462 RVA: 0x00012DDD File Offset: 0x00010FDD
	public void method_8(int int_0, int int_1, int int_2 = 1)
	{
		OnAccessSingleton<IShopService, ShopService, ShopServiceOffline>.Prop_0.imethod_6(new OnSellItem(this.OnSellItem), int_0, int_1, int_2);
	}

	// Token: 0x0600193F RID: 6463 RVA: 0x00012DF8 File Offset: 0x00010FF8
	public void method_9()
	{
		OnAccessSingleton<IShopService, ShopService, ShopServiceOffline>.Prop_0.imethod_7(new OnGetCashShop(this.OnGetCashShop));
	}

	// Token: 0x06001940 RID: 6464 RVA: 0x00012E10 File Offset: 0x00011010
	public void method_10(List<CashShopItem> list_0)
	{
		OnAccessSingleton<IShopService, ShopService, ShopServiceOffline>.Prop_0.imethod_8(new OnBuyCashItem(this.OnBuyCashItem), list_0);
	}

	// Token: 0x06001941 RID: 6465 RVA: 0x00084030 File Offset: 0x00082230
	private void OnGetShop(global::Shop shop)
	{
		if (shop == null)
		{
			return;
		}
		if (this.m_shops.ContainsKey(shop.Id))
		{
			this.m_shops[shop.Id] = shop;
		}
		else
		{
			this.m_shops.Add(shop.Id, shop);
		}
		foreach (IShopServiceNotificationListerner shopServiceNotificationListerner in this.m_notificationListeners)
		{
			shopServiceNotificationListerner.OnGetShop(shop);
		}
	}

	// Token: 0x06001942 RID: 6466 RVA: 0x0000311B File Offset: 0x0000131B
	private void OnBuyItem(ItemDNA itemDna)
	{
	}

	// Token: 0x06001943 RID: 6467 RVA: 0x000840C0 File Offset: 0x000822C0
	private void OnSellItem(int newBondCurrency, ItemDNA soldItem, Dictionary<int, ShopItem> redeemableItems)
	{
		this.m_soldItemList.Clear();
		this.m_soldItemList = redeemableItems;
		foreach (IShopServiceNotificationListerner shopServiceNotificationListerner in this.m_notificationListeners)
		{
			shopServiceNotificationListerner.OnSellItem(newBondCurrency, soldItem, redeemableItems);
		}
	}

	// Token: 0x06001944 RID: 6468 RVA: 0x00084128 File Offset: 0x00082328
	private void OnGetCashShop(List<OfferItem> listCashItems)
	{
		if (listCashItems == null)
		{
			return;
		}
		if (listCashItems.Count <= 0)
		{
			DebugUtils.LogWarning(LogCategory.Gamelogic, "cash shop item list is empty!");
		}
		int i = 0;
		int count = this.m_cashshopListeners.Count;
		while (i < count)
		{
			this.m_cashshopListeners[i].OnGetCashShop(listCashItems);
			i++;
		}
	}

	// Token: 0x06001945 RID: 6469 RVA: 0x00084178 File Offset: 0x00082378
	private void OnBuyCashItem(int result)
	{
		DebugUtils.Log(LogCategory.Gamelogic, "OnBuyCashItem result = " + result);
		int i = 0;
		int count = this.m_cashshopListeners.Count;
		while (i < count)
		{
			this.m_cashshopListeners[i].OnBuyCashItem(result);
			i++;
		}
	}

	// Token: 0x06001946 RID: 6470 RVA: 0x00012E29 File Offset: 0x00011029
	public void method_11(int int_0)
	{
		OnAccessSingleton<IShopService, ShopService, ShopServiceOffline>.Prop_0.imethod_3(new OnRedeemItem(this.OnRedeemItem), 0, int_0);
	}

	// Token: 0x06001947 RID: 6471 RVA: 0x000841C8 File Offset: 0x000823C8
	public void OnRedeemItem(ItemDNA item, Dictionary<int, ShopItem> redeemableItems)
	{
		this.m_soldItemList.Clear();
		this.m_soldItemList = redeemableItems;
		foreach (IShopServiceNotificationListerner shopServiceNotificationListerner in this.m_notificationListeners)
		{
			shopServiceNotificationListerner.OnRedeemItem(item, redeemableItems);
		}
	}

	// Token: 0x06001948 RID: 6472 RVA: 0x000039EC File Offset: 0x00001BEC
	public override bool vmethod_2()
	{
		return true;
	}

	// Token: 0x04001122 RID: 4386
	private ShopSetup m_setup;

	// Token: 0x04001123 RID: 4387
	protected List<IShopServiceNotificationListerner> m_notificationListeners = new List<IShopServiceNotificationListerner>();

	// Token: 0x04001124 RID: 4388
	protected List<ICashShopServiceNotificationListener> m_cashshopListeners = new List<ICashShopServiceNotificationListener>();

	// Token: 0x04001125 RID: 4389
	protected Dictionary<int, global::Shop> m_shops = new Dictionary<int, global::Shop>();

	// Token: 0x04001126 RID: 4390
	protected Dictionary<int, ShopItem> m_soldItemList = new Dictionary<int, ShopItem>();
}
