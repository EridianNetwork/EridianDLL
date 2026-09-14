using System;
using System.Collections.Generic;
using ns0;

// Token: 0x02000750 RID: 1872
public class ShopView : BaseView, ICharacterServiceNotificationListerner, IShopServiceNotificationListerner
{
	// Token: 0x06003171 RID: 12657 RVA: 0x000E12E0 File Offset: 0x000DF4E0
	public override void vmethod_2()
	{
		base.vmethod_2();
		MonoSingleton<AppManager>.Instance.method_0().method_6(this);
		this.Boolean_1 = false;
		ServiceWrapperBase<ShopServiceWrapper>.Instance.method_0(this);
		ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_0(this);
		ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_22();
		MonoSingleton<AppManager>.Instance.method_0().method_0(new GameUIManager.ViewUpdateCB(this.vmethod_5), false);
		this._curState = ShopView.ShopTabState.Shop;
	}

	// Token: 0x06003172 RID: 12658 RVA: 0x000E1350 File Offset: 0x000DF550
	public override void vmethod_3()
	{
		base.vmethod_3();
		MonoSingleton<AppManager>.Instance.method_0().method_7(this);
		ServiceWrapperBase<ShopServiceWrapper>.Instance.method_1(this);
		ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_1(this);
		MonoSingleton<AppManager>.Instance.method_0().method_1(new GameUIManager.ViewUpdateCB(this.vmethod_5));
	}

	// Token: 0x06003173 RID: 12659 RVA: 0x000E13A8 File Offset: 0x000DF5A8
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		base.vmethod_1(bool_0, bool_1);
		if (!bool_0)
		{
			NPC_UIFlowController.smethod_0().method_3(NPC_UIFlowController.NPC_UIFlowState.None);
			this._curState = ShopView.ShopTabState.Shop;
		}
		if (bool_0)
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_26(GameUIManager.CursorManager.CursorType.Money);
		}
		else
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_26(GameUIManager.CursorManager.CursorType.DefaultCursor);
		}
	}

	// Token: 0x06003174 RID: 12660 RVA: 0x00020246 File Offset: 0x0001E446
	public override bool vmethod_4()
	{
		if (this.Boolean_1)
		{
			this.vmethod_1(false, false);
			return true;
		}
		return base.vmethod_4();
	}

	// Token: 0x06003175 RID: 12661 RVA: 0x00020260 File Offset: 0x0001E460
	public void method_3(int int_0)
	{
		this._iOnShowShopID = int_0;
		this._onShowShop = ServiceWrapperBase<ShopServiceWrapper>.Instance.method_5(int_0, true);
		this.vmethod_6();
	}

	// Token: 0x06003176 RID: 12662 RVA: 0x000E13F8 File Offset: 0x000DF5F8
	protected virtual void vmethod_5()
	{
		if (this._bVisible && this._onShowShop != null && !this._inProcess && this._onShowShop.Int32_0 <= 0)
		{
			ServiceWrapperBase<ShopServiceWrapper>.Instance.method_5(this._iOnShowShopID, true);
			this._inProcess = true;
		}
	}

	// Token: 0x06003177 RID: 12663 RVA: 0x000E1444 File Offset: 0x000DF644
	protected virtual void vmethod_6()
	{
		this._onShowItemList.Clear();
		if (this._curState == ShopView.ShopTabState.None)
		{
			return;
		}
		if (this._curState == ShopView.ShopTabState.Shop)
		{
			if (this._onShowShop != null && this._onShowShop.Dictionary_0 != null)
			{
				for (int i = 0; i < this._onShowShop.Dictionary_0.Count; i++)
				{
					ShopView.ShopItemUIData shopItemUIData = new ShopView.ShopItemUIData();
					shopItemUIData.RelateData = this._onShowShop.Dictionary_0[i];
					shopItemUIData.iIndex = i;
					shopItemUIData.bAffordable = shopItemUIData.RelateData.Price <= this._iMoney;
					this._onShowItemList.Add(shopItemUIData);
				}
			}
		}
		else if (this._curState == ShopView.ShopTabState.SoldItems)
		{
			Dictionary<int, ShopItem> dictionary = ServiceWrapperBase<ShopServiceWrapper>.Instance.method_6();
			if (dictionary != null)
			{
				foreach (KeyValuePair<int, ShopItem> keyValuePair in dictionary)
				{
					ShopView.ShopItemUIData shopItemUIData2 = new ShopView.ShopItemUIData();
					shopItemUIData2.RelateData = keyValuePair.Value;
					shopItemUIData2.iIndex = keyValuePair.Key;
					shopItemUIData2.bAffordable = true;
					this._onShowItemList.Add(shopItemUIData2);
				}
			}
		}
	}

	// Token: 0x06003178 RID: 12664 RVA: 0x00020281 File Offset: 0x0001E481
	protected void method_4(ShopView.ShopTabState shopTabState_0)
	{
		if (shopTabState_0 == this._curState)
		{
			return;
		}
		this._curState = shopTabState_0;
		this.vmethod_6();
	}

	// Token: 0x06003179 RID: 12665 RVA: 0x0002029A File Offset: 0x0001E49A
	protected void method_5(ShopView.ShopItemUIData shopItemUIData_0, int int_0 = 1)
	{
		if (shopItemUIData_0 != null && shopItemUIData_0.RelateData != null && this._onShowShop != null)
		{
			if (this.method_7(shopItemUIData_0.RelateData))
			{
				ServiceWrapperBase<ShopServiceWrapper>.Instance.method_7(this._onShowShop.Id, shopItemUIData_0.iIndex, int_0);
			}
			return;
		}
	}

	// Token: 0x0600317A RID: 12666 RVA: 0x000202DA File Offset: 0x0001E4DA
	protected void method_6(ShopView.ShopItemUIData shopItemUIData_0, int int_0 = 1)
	{
		if (shopItemUIData_0 != null && shopItemUIData_0.RelateData != null && this._onShowShop != null)
		{
			if (this.method_7(shopItemUIData_0.RelateData))
			{
				ServiceWrapperBase<ShopServiceWrapper>.Instance.method_11(shopItemUIData_0.iIndex);
			}
			return;
		}
	}

	// Token: 0x0600317B RID: 12667 RVA: 0x000E1580 File Offset: 0x000DF780
	protected bool method_7(ShopItem shopItem_0)
	{
		bool flag = false;
		if (shopItem_0.Price <= this._iMoney)
		{
			if (!ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_39(shopItem_0.Item))
			{
				flag = true;
			}
			else
			{
				this.vmethod_7();
			}
		}
		else
		{
			this.vmethod_9();
		}
		return flag;
	}

	// Token: 0x0600317C RID: 12668 RVA: 0x000E15C4 File Offset: 0x000DF7C4
	protected void method_8(int int_0, int int_1 = 1)
	{
		if (this._onShowShop != null)
		{
			ItemDNA itemDNA = ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_6(int_0);
			this._iPendingSellIndex = int_0;
			this._iPendingSellQuantity = int_1;
			if (itemDNA.method_4())
			{
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDWarningView>().vmethod_7(LocalizedString.smethod_0(new LocalizedString("Warning_Shop_Sell")), new Delegate_EventProc(this.vmethod_8), new Delegate_EventProc(this.method_9));
			}
			else
			{
				this.vmethod_8();
			}
		}
	}

	// Token: 0x0600317D RID: 12669 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void vmethod_7()
	{
	}

	// Token: 0x0600317E RID: 12670 RVA: 0x0002030E File Offset: 0x0001E50E
	protected virtual void vmethod_8()
	{
		ServiceWrapperBase<ShopServiceWrapper>.Instance.method_8(this._onShowShop.Id, this._iPendingSellIndex, this._iPendingSellQuantity);
		this._iPendingSellIndex = -1;
		this._iPendingSellQuantity = -1;
	}

	// Token: 0x0600317F RID: 12671 RVA: 0x0002033F File Offset: 0x0001E53F
	protected void method_9()
	{
		this._iPendingSellIndex = -1;
		this._iPendingSellQuantity = -1;
	}

	// Token: 0x06003180 RID: 12672 RVA: 0x000E1640 File Offset: 0x000DF840
	protected virtual void vmethod_9()
	{
		string text = LocalizedString.smethod_0(new LocalizedString("FAILURE_INSUFFICIENCY"));
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDWarningView>().vmethod_7(text, new Delegate_EventProc(this.method_10), null);
	}

	// Token: 0x06003181 RID: 12673 RVA: 0x0000311B File Offset: 0x0000131B
	protected void method_10()
	{
	}

	// Token: 0x06003182 RID: 12674 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void vmethod_10()
	{
	}

	// Token: 0x06003183 RID: 12675 RVA: 0x0002034F File Offset: 0x0001E54F
	public void OnBuyItem(ItemDNA itemDna)
	{
		this.vmethod_10();
		this.vmethod_6();
	}

	// Token: 0x06003184 RID: 12676 RVA: 0x0002035D File Offset: 0x0001E55D
	public void OnRedeemItem(ItemDNA itemDna, Dictionary<int, ShopItem> redeemableItems)
	{
		if (this._curState == ShopView.ShopTabState.SoldItems)
		{
			this.vmethod_6();
		}
	}

	// Token: 0x06003185 RID: 12677 RVA: 0x000E1680 File Offset: 0x000DF880
	public void OnGetShop(Shop shop)
	{
		if (MonoSingleton<DNAPortrait>.Instance != null && shop != null && shop.Dictionary_0 != null)
		{
			foreach (ShopItem shopItem in shop.Dictionary_0.Values)
			{
				MonoSingleton<DNAPortrait>.Instance.method_3(shopItem.Item, 0, 0, TexPostEffectMgr.POST_EFFECT_TYPE.POST_EFFECT_UI);
			}
		}
		if (shop != null && shop.Id == this._iOnShowShopID && this._curState == ShopView.ShopTabState.Shop)
		{
			this._onShowShop = shop;
			this._inProcess = false;
			this.vmethod_6();
		}
	}

	// Token: 0x06003186 RID: 12678 RVA: 0x0002035D File Offset: 0x0001E55D
	public void OnGetSoldItems(Shop soldItems)
	{
		if (this._curState == ShopView.ShopTabState.SoldItems)
		{
			this.vmethod_6();
		}
	}

	// Token: 0x06003187 RID: 12679 RVA: 0x0002035D File Offset: 0x0001E55D
	public void OnSellItem(int newBondCurrency, ItemDNA item, Dictionary<int, ShopItem> redeemableItems)
	{
		if (this._curState == ShopView.ShopTabState.SoldItems)
		{
			this.vmethod_6();
		}
	}

	// Token: 0x06003188 RID: 12680 RVA: 0x0002036E File Offset: 0x0001E56E
	public void OnGotMyCurrencies(CurrencyInfo currency)
	{
		if (currency != null)
		{
			this._iMoney = currency.BondCurrency;
			this.vmethod_6();
		}
	}

	// Token: 0x06003189 RID: 12681 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnExperienceUpdated(int experience)
	{
	}

	// Token: 0x0600318A RID: 12682 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnGetPersonalSettings(string strSettings)
	{
	}

	// Token: 0x0600318B RID: 12683 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnSetPersonalSettings(int iReslut)
	{
	}

	// Token: 0x0600318C RID: 12684 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnGetCharacterSettings(string strSettings)
	{
	}

	// Token: 0x0600318D RID: 12685 RVA: 0x0000311B File Offset: 0x0000131B
	public void OnSetCharacterSettings(int iReslut)
	{
	}

	// Token: 0x04002239 RID: 8761
	protected float _fOnHoldingTime;

	// Token: 0x0400223A RID: 8762
	protected int _iOnShowShopID = -1;

	// Token: 0x0400223B RID: 8763
	protected int _iMoney = -1;

	// Token: 0x0400223C RID: 8764
	protected Shop _onShowShop;

	// Token: 0x0400223D RID: 8765
	protected ShopView.ShopTabState _curState;

	// Token: 0x0400223E RID: 8766
	protected TimeSpan _remainTime = default(TimeSpan);

	// Token: 0x0400223F RID: 8767
	protected int _iPendingSellIndex = -1;

	// Token: 0x04002240 RID: 8768
	protected int _iPendingSellQuantity = -1;

	// Token: 0x04002241 RID: 8769
	protected List<ShopView.ShopItemUIData> _onShowItemList = new List<ShopView.ShopItemUIData>();

	// Token: 0x04002242 RID: 8770
	protected bool _inProcess;

	// Token: 0x02000751 RID: 1873
	public enum ShopTabState
	{
		// Token: 0x04002244 RID: 8772
		None,
		// Token: 0x04002245 RID: 8773
		Shop,
		// Token: 0x04002246 RID: 8774
		SoldItems
	}

	// Token: 0x02000752 RID: 1874
	public class ShopItemUIData
	{
		// Token: 0x04002247 RID: 8775
		public int iIndex;

		// Token: 0x04002248 RID: 8776
		public ShopItem RelateData;

		// Token: 0x04002249 RID: 8777
		public bool bAffordable;
	}
}
