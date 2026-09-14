using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using Core;
using ns0;
using UnityEngine;

// Token: 0x0200066B RID: 1643
public class CashShopManager : ICharacterServiceNotificationListerner, ICashShopServiceNotificationListener
{
	// Token: 0x06002955 RID: 10581 RVA: 0x0001B1F4 File Offset: 0x000193F4
	public void OnGotMyCurrencies(CurrencyInfo currency)
	{
		CashShopManager.cashShopView.vmethod_5(currency);
	}

	// Token: 0x06002956 RID: 10582 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnExperienceUpdated(int experience)
	{
	}

	// Token: 0x06002957 RID: 10583 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnGetPersonalSettings(string strSettings)
	{
	}

	// Token: 0x06002958 RID: 10584 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnSetPersonalSettings(int iResult)
	{
	}

	// Token: 0x06002959 RID: 10585 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnGetCharacterSettings(string strSettings)
	{
	}

	// Token: 0x0600295A RID: 10586 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnSetCharacterSettings(int iResult)
	{
	}

	// Token: 0x0600295B RID: 10587 RVA: 0x0001B201 File Offset: 0x00019401
	public void OnGetCashShop(List<OfferItem> listItems)
	{
		if (listItems == null)
		{
			DebugUtils.LogError(LogCategory.Gamelogic, "cash shop offer items list is null");
			return;
		}
		this._listOfferItems = listItems;
		if (this._listOfferItems.Count == 0)
		{
			DebugUtils.LogWarning(LogCategory.Gamelogic, "cash shop offer items list is empty");
		}
		this._isOfferItemLoaded = true;
		this.method_2();
	}

	// Token: 0x0600295C RID: 10588 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnBuyCashItem(int iResult)
	{
	}

	// Token: 0x0600295D RID: 10589 RVA: 0x0001B23E File Offset: 0x0001943E
	public void method_0()
	{
		ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_0(CashShopManager.mInstance);
		ServiceWrapperBase<ShopServiceWrapper>.Instance.method_2(CashShopManager.mInstance);
		if (!this._isCashItemLoaded)
		{
			this.method_6();
		}
	}

	// Token: 0x0600295E RID: 10590 RVA: 0x0001B26C File Offset: 0x0001946C
	public void method_1()
	{
		ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_1(CashShopManager.mInstance);
		ServiceWrapperBase<ShopServiceWrapper>.Instance.method_2(CashShopManager.mInstance);
	}

	// Token: 0x1700020D RID: 525
	// (get) Token: 0x0600295F RID: 10591 RVA: 0x0001B28C File Offset: 0x0001948C
	public static CashShopManager CashShopManager_0
	{
		get
		{
			if (CashShopManager.mInstance == null)
			{
				CashShopManager.mInstance = new CashShopManager();
			}
			return CashShopManager.mInstance;
		}
	}

	// Token: 0x06002960 RID: 10592 RVA: 0x000C2C00 File Offset: 0x000C0E00
	private void method_2()
	{
		if (!this._isOfferItemLoaded)
		{
			ServiceWrapperBase<ShopServiceWrapper>.Instance.method_9();
		}
		if (!this._isCashItemLoaded)
		{
			this.method_6();
		}
		this._listAll.Clear();
		int i = 0;
		int count = this._listOfferItems.Count;
		while (i < count)
		{
			UICashShopItemData uicashShopItemData = new UICashShopItemData();
			OfferItem offerItem = this._listOfferItems[i];
			uicashShopItemData.offerItem = offerItem;
			CashItem cashItem = CashShopManager.dictCashItem[offerItem.ItemId];
			if (cashItem != null)
			{
				uicashShopItemData.cashItem = CashShopManager.dictCashItem[offerItem.ItemId];
			}
			else
			{
				DebugUtils.LogWarning(LogCategory.Gamelogic, "ItemId = " + offerItem.ItemId + " can't find in the cash shop table,please check!");
			}
			this._listAll.Add(uicashShopItemData);
			i++;
		}
	}

	// Token: 0x06002961 RID: 10593 RVA: 0x0001B2A4 File Offset: 0x000194A4
	public List<UICashShopItemData> method_3()
	{
		return this._listAll;
	}

	// Token: 0x06002962 RID: 10594 RVA: 0x0001B2AC File Offset: 0x000194AC
	public List<UICashShopTabData> method_4()
	{
		return this.listTabs;
	}

	// Token: 0x06002963 RID: 10595 RVA: 0x000C2CC0 File Offset: 0x000C0EC0
	public void method_5()
	{
		this.listTabs.Clear();
		UICashShopTabData uicashShopTabData = new UICashShopTabData();
		FilterInfo filterInfo = new FilterInfo("Soldier", "==", "true");
		uicashShopTabData.tabName = "Soldier";
		uicashShopTabData.method_2(new List<FilterInfo> { filterInfo });
		uicashShopTabData.method_0(this._listAll);
		UICashShopTabData uicashShopTabData2 = new UICashShopTabData();
		FilterInfo filterInfo2 = new FilterInfo("Hunter", "==", "true");
		uicashShopTabData2.tabName = "Hunter";
		uicashShopTabData2.method_2(new List<FilterInfo> { filterInfo2 });
		uicashShopTabData2.method_0(this._listAll);
		UICashShopTabData uicashShopTabData3 = new UICashShopTabData();
		FilterInfo filterInfo3 = new FilterInfo("Berserker", "==", "true");
		uicashShopTabData3.tabName = "Berserker";
		uicashShopTabData3.method_2(new List<FilterInfo> { filterInfo3 });
		uicashShopTabData3.method_0(this._listAll);
		UICashShopTabData uicashShopTabData4 = new UICashShopTabData();
		FilterInfo filterInfo4 = new FilterInfo("Siren", "==", "true");
		uicashShopTabData4.tabName = "Siren";
		uicashShopTabData4.method_2(new List<FilterInfo> { filterInfo4 });
		uicashShopTabData4.method_0(this._listAll);
		UICashShopTabData uicashShopTabData5 = new UICashShopTabData();
		FilterInfo filterInfo5 = new FilterInfo("Type", "!=", "Outfit");
		uicashShopTabData5.tabName = "Siren";
		uicashShopTabData5.method_2(new List<FilterInfo> { filterInfo5 });
		uicashShopTabData5.method_0(this._listAll);
		this.listTabs.Add(uicashShopTabData);
		this.listTabs.Add(uicashShopTabData2);
		this.listTabs.Add(uicashShopTabData3);
		this.listTabs.Add(uicashShopTabData4);
		this.listTabs.Add(uicashShopTabData5);
	}

	// Token: 0x06002964 RID: 10596 RVA: 0x000C2E9C File Offset: 0x000C109C
	private void method_6()
	{
		TextAsset textAsset = Resources.Load("Settings/CashShopItemData") as TextAsset;
		if (textAsset == null)
		{
			DebugUtils.LogError(LogCategory.Gamelogic, "CashShop config file CashShopItemData.json is null ");
		}
		CashShopManager.tableItems = JSONObject.Create(textAsset.ToString(), -2, false, false);
		List<string> keys = CashShopManager.tableItems.keys;
		foreach (string text in keys)
		{
			CashItem cashItem = new CashItem();
			JSONObject field = CashShopManager.tableItems.GetField(text);
			FieldInfo[] fields = cashItem.GetType().GetFields();
			int i = 0;
			int num = fields.Length;
			while (i < num)
			{
				FieldInfo fieldInfo = fields[i];
				JSONObject field2 = field.GetField(fieldInfo.Name);
				object obj = null;
				switch (field2.type)
				{
				case JSONObject.Type.STRING:
					obj = field2.str;
					break;
				case JSONObject.Type.NUMBER:
					obj = field2.n;
					break;
				case JSONObject.Type.BOOL:
					obj = field2.b;
					break;
				}
				fieldInfo.SetValue(cashItem, Convert.ChangeType(obj, fieldInfo.FieldType));
				i++;
			}
			CashShopManager.dictCashItem[text] = cashItem;
		}
		Resources.UnloadAsset(textAsset);
		this._isCashItemLoaded = true;
	}

	// Token: 0x06002965 RID: 10597 RVA: 0x000C3008 File Offset: 0x000C1208
	[CompilerGenerated]
	private static bool smethod_0(UICashShopItemData uicashShopItemData_0, FilterInfo filterInfo_0)
	{
		string text = typeof(UICashShopItemData).GetField(filterInfo_0.fieldName).GetValue(uicashShopItemData_0).ToString();
		return (!(filterInfo_0.oprt != "!=")) ? (text != filterInfo_0.fieldValue) : (text == filterInfo_0.fieldValue);
	}

	// Token: 0x04001DA1 RID: 7585
	private static CashShopManager mInstance;

	// Token: 0x04001DA2 RID: 7586
	private static CashShopView cashShopView = null;

	// Token: 0x04001DA3 RID: 7587
	private List<OfferItem> _listOfferItems = new List<OfferItem>();

	// Token: 0x04001DA4 RID: 7588
	private bool _isCashItemLoaded;

	// Token: 0x04001DA5 RID: 7589
	private bool _isOfferItemLoaded;

	// Token: 0x04001DA6 RID: 7590
	public static JSONObject tableItems;

	// Token: 0x04001DA7 RID: 7591
	private List<UICashShopItemData> _listAll = new List<UICashShopItemData>();

	// Token: 0x04001DA8 RID: 7592
	public List<UICashShopTabData> listTabs = new List<UICashShopTabData>();

	// Token: 0x04001DA9 RID: 7593
	public static Dictionary<string, List<UICashShopItemData>> dictTab = null;

	// Token: 0x04001DAA RID: 7594
	public static Dictionary<string, CashItem> dictCashItem = new Dictionary<string, CashItem>();

	// Token: 0x04001DAB RID: 7595
	public static CashShopManager.FilterItem itemFilter = new CashShopManager.FilterItem(CashShopManager.smethod_0);

	// Token: 0x0200066C RID: 1644
	// (Invoke) Token: 0x06002967 RID: 10599
	public delegate bool FilterItem(UICashShopItemData itemData, FilterInfo filter);
}
