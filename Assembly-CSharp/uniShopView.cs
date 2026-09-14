using System;
using System.Collections.Generic;
using Core;
using ns0;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;
using UnityEngine;
using XsdSettings;

// Token: 0x0200089E RID: 2206
public class uniShopView : ShopView
{
	// Token: 0x06003C8A RID: 15498 RVA: 0x0011E5DC File Offset: 0x0011C7DC
	public override void vmethod_2()
	{
		base.vmethod_2();
		MonoSingleton<AppManager>.Instance.method_0().method_3(this, new Vector2(0f, 0f));
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("2014_CoinShop.swf", "Panel_Shop", new FuncLoad(this.method_11));
		this._inventoryPanel = (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InventoryView>() as uniInventoryView).InventoryPanel_0;
	}

	// Token: 0x06003C8B RID: 15499 RVA: 0x0011E658 File Offset: 0x0011C858
	public override void vmethod_3()
	{
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._panelRoot);
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("2014_CoinShop.swf");
		this._inventoryPanel = null;
		this._panelRoot = null;
		this._shopRoot = null;
	}

	// Token: 0x06003C8C RID: 15500 RVA: 0x0011E6B0 File Offset: 0x0011C8B0
	private void method_11(MovieClip movieClip_0)
	{
		this._mcRoot = movieClip_0;
		this._mcRoot.visible = false;
		this._panelRoot = new GClass51();
		this._panelRoot.method_0(this._mcRoot);
		this._shopRoot = new uniShopView.ShopPanel();
		this._shopRoot.DeleOnClickClose_0 = new uniShopView.ShopPanel.DeleOnClickClose(this.method_15);
		this._shopRoot.DeleOnClickShopItem_0 = new uniShopView.ShopPanel.DeleOnClickShopItem(this.method_16);
		this._shopRoot.DeleOnSwitchTab_0 = new uniShopView.ShopPanel.DeleOnSwitchTab(this.method_17);
		this._mcRoot.addFrameScript("Open", new EventDispatcher.EventCallback(this.method_12));
		this._mcRoot.addFrameScript("Normal", new EventDispatcher.EventCallback(this.method_12));
		this._mcRoot.addFrameScript("Close", new EventDispatcher.EventCallback(this.method_12));
		this._mcRoot.addFrameScript("End", new EventDispatcher.EventCallback(this.method_13));
		MovieClip childByName = this._mcRoot.getChildByName<MovieClip>("mcRoot");
		if (childByName != null)
		{
			this._shopRoot.method_0(childByName);
		}
		MovieClip childByName2 = this._mcRoot.getChildByName<MovieClip>("mcInventoryPosition");
		if (childByName2 != null)
		{
			MonoSingleton<AppManager>.Instance.GetComponent<GameUIManager>().method_3(this, GClass20.GClass20_0.method_3(childByName2, Vector2.zero));
		}
		this._bActive = true;
	}

	// Token: 0x06003C8D RID: 15501 RVA: 0x0011E810 File Offset: 0x0011CA10
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		base.vmethod_1(bool_0, bool_1);
		if (this._inventoryPanel == null)
		{
			this._inventoryPanel = (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InventoryView>() as uniInventoryView).InventoryPanel_0;
		}
		if (this._inventoryPanel != null)
		{
			if (this._bVisible)
			{
				this._inventoryPanel.addEventListener("Item" + MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_14));
			}
			else
			{
				this._inventoryPanel.removeEventListener("Item" + MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_14));
			}
		}
		if (this._mcRoot != null)
		{
			if (bool_0)
			{
				(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_35(this._panelRoot);
				this._mcRoot.visible = true;
				this._mcRoot.gotoAndPlay("Open");
			}
			else
			{
				this._mcRoot.gotoAndPlay("Close");
				if (this._shopRoot != null)
				{
					this._shopRoot.method_5(ShopView.ShopTabState.Shop);
				}
			}
		}
	}

	// Token: 0x06003C8E RID: 15502 RVA: 0x0011E914 File Offset: 0x0011CB14
	protected void method_12(CEvent cevent_0)
	{
		MovieClip childByName = this._mcRoot.getChildByName<MovieClip>("mcRoot");
		if (childByName != null)
		{
			this._shopRoot.method_0(childByName);
		}
	}

	// Token: 0x06003C8F RID: 15503 RVA: 0x00028CD1 File Offset: 0x00026ED1
	protected void method_13(CEvent cevent_0)
	{
		this._mcRoot.visible = false;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._panelRoot);
	}

	// Token: 0x06003C90 RID: 15504 RVA: 0x00028CF9 File Offset: 0x00026EF9
	protected override void vmethod_6()
	{
		base.vmethod_6();
		if (this._shopRoot != null)
		{
			this._shopRoot.method_10(this._onShowItemList);
		}
	}

	// Token: 0x06003C91 RID: 15505 RVA: 0x0011E944 File Offset: 0x0011CB44
	protected override void vmethod_5()
	{
		base.vmethod_5();
		string text = null;
		if (this._bVisible && this._curState == ShopView.ShopTabState.Shop)
		{
			text = this._remainTime.Hours + ":" + this._remainTime.Minutes;
		}
		if (this._shopRoot != null)
		{
			this._shopRoot.method_6(text);
		}
	}

	// Token: 0x06003C92 RID: 15506 RVA: 0x0011E9AC File Offset: 0x0011CBAC
	protected void method_14(CEvent cevent_0)
	{
		GClass55 gclass = cevent_0 as GClass55;
		UIItemSlotData uiitemSlotData = (UIItemSlotData)gclass.object_0;
		base.method_8(uiitemSlotData.index, 1);
	}

	// Token: 0x06003C93 RID: 15507 RVA: 0x00028D1A File Offset: 0x00026F1A
	protected override void vmethod_10()
	{
		base.vmethod_10();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("UI_Vending_Buy");
	}

	// Token: 0x06003C94 RID: 15508 RVA: 0x00028D3B File Offset: 0x00026F3B
	protected override void vmethod_8()
	{
		base.vmethod_8();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("UI_Vending_Sell");
	}

	// Token: 0x06003C95 RID: 15509 RVA: 0x00028D5C File Offset: 0x00026F5C
	protected override void vmethod_9()
	{
		base.vmethod_9();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("UI_Vending_Insufficient_Funds");
	}

	// Token: 0x06003C96 RID: 15510 RVA: 0x00028D7D File Offset: 0x00026F7D
	protected override void vmethod_7()
	{
		base.vmethod_7();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("UI_Vending_No_Money");
	}

	// Token: 0x06003C97 RID: 15511 RVA: 0x0001E5A9 File Offset: 0x0001C7A9
	protected void method_15()
	{
		this.Boolean_1 = false;
	}

	// Token: 0x06003C98 RID: 15512 RVA: 0x00028D9E File Offset: 0x00026F9E
	protected void method_16(ShopView.ShopItemUIData shopItemUIData_0)
	{
		if (this._curState == ShopView.ShopTabState.Shop)
		{
			base.method_5(shopItemUIData_0, 1);
		}
		else if (this._curState == ShopView.ShopTabState.SoldItems)
		{
			base.method_6(shopItemUIData_0, 1);
		}
	}

	// Token: 0x06003C99 RID: 15513 RVA: 0x00028DC4 File Offset: 0x00026FC4
	protected void method_17(ShopView.ShopTabState shopTabState_0)
	{
		base.method_4(shopTabState_0);
	}

	// Token: 0x04002A9A RID: 10906
	protected uniInventoryView.InventoryPanel _inventoryPanel;

	// Token: 0x04002A9B RID: 10907
	protected MovieClip _mcRoot;

	// Token: 0x04002A9C RID: 10908
	protected GClass51 _panelRoot;

	// Token: 0x04002A9D RID: 10909
	protected uniShopView.ShopPanel _shopRoot;

	// Token: 0x0200089F RID: 2207
	protected class ShopPanel : GClass51
	{
		// Token: 0x17000336 RID: 822
		// (set) Token: 0x06003C9B RID: 15515 RVA: 0x00028DCD File Offset: 0x00026FCD
		public uniShopView.ShopPanel.DeleOnClickClose DeleOnClickClose_0
		{
			set
			{
				this._deleOnClickClose = value;
			}
		}

		// Token: 0x06003C9C RID: 15516 RVA: 0x00028DD6 File Offset: 0x00026FD6
		public void method_5(ShopView.ShopTabState shopTabState_0)
		{
			this._curTab = shopTabState_0;
			if (shopTabState_0 == ShopView.ShopTabState.Shop)
			{
				if (this._btnPurchase != null)
				{
					this._btnPurchase.Boolean_3 = true;
				}
			}
			else if (shopTabState_0 == ShopView.ShopTabState.SoldItems && this._btnSold != null)
			{
				this._btnSold.Boolean_3 = true;
			}
		}

		// Token: 0x17000337 RID: 823
		// (set) Token: 0x06003C9D RID: 15517 RVA: 0x00028E11 File Offset: 0x00027011
		public uniShopView.ShopPanel.DeleOnClickShopItem DeleOnClickShopItem_0
		{
			set
			{
				this._deleOnClickShopItem = value;
			}
		}

		// Token: 0x17000338 RID: 824
		// (set) Token: 0x06003C9E RID: 15518 RVA: 0x00028E1A File Offset: 0x0002701A
		public uniShopView.ShopPanel.DeleOnSwitchTab DeleOnSwitchTab_0
		{
			set
			{
				this._deleOnSwitchTab = value;
			}
		}

		// Token: 0x06003C9F RID: 15519 RVA: 0x00028E23 File Offset: 0x00027023
		public void method_6(string string_1)
		{
			if (this._textRefreshTime == null)
			{
			}
		}

		// Token: 0x06003CA0 RID: 15520 RVA: 0x0011EA34 File Offset: 0x0011CC34
		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			bool flag = false;
			if (movieClip.name.Contains("mcItemSlot"))
			{
				int num = Convert.ToInt32(movieClip.name.Substring("mcItemSlot".Length, movieClip.name.Length - "mcItemSlot".Length));
				if (num < 14)
				{
					if (this._itemSlotAry[num] == null)
					{
						this._itemSlotAry[num] = new uniShopView.ShopPanel.ShopItemSlot();
					}
					this._itemSlotAry[num].method_0(movieClip);
					this._itemSlotAry[num].removeAllEventListeners(MouseEvent.CLICK);
					this._itemSlotAry[num].addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_9));
					this._itemSlotAry[num].method_11(new GClass44.GDelegate2((MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InventoryView>() as uniInventoryView).method_21));
					flag = true;
				}
			}
			else
			{
				string name = movieClip.name;
				if (!(name == "mcBtnClose"))
				{
					if (!(name == "mcTabPurchase"))
					{
						if (!(name == "mcTabSold"))
						{
							if (!(name == "mcScrollingBar"))
							{
								if (!(name == "mcItemSpecial"))
								{
									if (name == "mcBackButton")
									{
										movieClip.visible = false;
										flag = true;
									}
								}
								else
								{
									if (this._itemSlotSpecial == null)
									{
										this._itemSlotSpecial = new uniShopView.ShopPanel.ShopItemSlot();
									}
									this._itemSlotSpecial.method_0(movieClip);
									this._itemSlotSpecial.removeAllEventListeners(MouseEvent.CLICK);
									this._itemSlotSpecial.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_9));
									this._itemSlotSpecial.method_11(new GClass44.GDelegate2((MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InventoryView>() as uniInventoryView).method_21));
									movieClip.visible = true;
									DebugUtils.Log(LogCategory.GUI, "[DIAG] mcItemSpecial widget ready");
									this.method_11(0);
									flag = true;
								}
							}
							else
							{
								movieClip.visible = false;
								this._scBar.method_0(movieClip);
								this._scBar.addEventListener("Scrolling", new EventDispatcher.EventCallback(this.method_7));
								GClass45 scBar = this._scBar;
								this._scBar.int_1 = 0;
								scBar.int_0 = 0;
								flag = true;
							}
						}
						else
						{
							this._btnSold.method_0(movieClip);
							this._btnSold.bool_5 = false;
							this._btnSold.String_1 = "ShopButtonGroupName";
							flag = true;
						}
					}
					else
					{
						this._btnPurchase.method_0(movieClip);
						this._btnPurchase.Boolean_3 = true;
						this._btnPurchase.bool_5 = false;
						this._btnPurchase.String_1 = "ShopButtonGroupName";
						this._btnPurchase.GClass17_0.addEventListener(CEvent.CHANGED, new EventDispatcher.EventCallback(this.method_8));
						this._btnPurchase.Boolean_3 = true;
						flag = true;
					}
				}
				else
				{
					this._XBtn.method_0(movieClip);
					this._XBtn.removeAllEventListeners(MouseEvent.CLICK);
					this._XBtn.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_12));
					flag = true;
				}
			}
			return flag;
		}

		// Token: 0x06003CA1 RID: 15521 RVA: 0x0011ED58 File Offset: 0x0011CF58
		protected override void vmethod_0()
		{
			base.vmethod_0();
			MovieClip childByName = base.DisplayObjectContainer_0.getChildByName<MovieClip>("mcTabPurchase");
			if (childByName != null)
			{
				this._btnPurchase.method_0(childByName);
			}
			this._textRefreshTime = base.DisplayObjectContainer_0.getChildByName<TextField>("textRefreshTime");
			if (this._textRefreshTime != null)
			{
				this._textRefreshTime.visible = false;
			}
			this._textDescription = base.DisplayObjectContainer_0.getChildByName<TextField>("textDescription");
			if (this._textDescription != null)
			{
				this._textDescription.text = string.Empty;
			}
			this.method_11(0);
		}

		// Token: 0x06003CA2 RID: 15522 RVA: 0x0011EDEC File Offset: 0x0011CFEC
		protected void method_7(CEvent cevent_0)
		{
			int int32_ = this._scBar.Int32_1;
			this.method_11(int32_);
		}

		// Token: 0x06003CA3 RID: 15523 RVA: 0x0011EE0C File Offset: 0x0011D00C
		protected void method_8(CEvent cevent_0)
		{
			if (this._deleOnSwitchTab == null)
			{
				return;
			}
			if (this._btnPurchase.Boolean_3)
			{
				this._curTab = ShopView.ShopTabState.Shop;
				this._deleOnSwitchTab(ShopView.ShopTabState.Shop);
			}
			else if (this._btnSold.Boolean_3)
			{
				this._curTab = ShopView.ShopTabState.SoldItems;
				this._deleOnSwitchTab(ShopView.ShopTabState.SoldItems);
			}
		}

		// Token: 0x06003CA4 RID: 15524 RVA: 0x0011EE64 File Offset: 0x0011D064
		protected void method_9(CEvent cevent_0)
		{
			uniShopView.ShopPanel.ShopItemSlot shopItemSlot = cevent_0.target as uniShopView.ShopPanel.ShopItemSlot;
			if (shopItemSlot != null && this._deleOnClickShopItem != null)
			{
				ShopView.ShopItemUIData shopItemUIData = shopItemSlot.object_0 as ShopView.ShopItemUIData;
				if (shopItemUIData != null)
				{
					this._deleOnClickShopItem(shopItemUIData);
				}
			}
		}

		// Token: 0x06003CA5 RID: 15525 RVA: 0x0011EEA4 File Offset: 0x0011D0A4
		public void method_10(List<ShopView.ShopItemUIData> list_1)
		{
			this._onShowItemList = list_1;
			if (this._scBar != null && this._onShowItemList != null)
			{
				this._scBar.Boolean_1 = this._curTab == ShopView.ShopTabState.SoldItems && this._onShowItemList.Count > 14;
				int num = this._onShowItemList.Count >> 1;
				this._scBar.method_10(7, 0, num, 1);
			}
			else
			{
				this._scBar.Boolean_1 = false;
			}
			this.method_11(0);
		}

		// Token: 0x06003CA6 RID: 15526 RVA: 0x0011EF20 File Offset: 0x0011D120
		protected void method_11(int int_0)
		{
			if (this._itemSlotSpecial != null)
			{
				ShopView.ShopItemUIData shopItemUIData = null;
				if (this._onShowItemList != null)
				{
					foreach (ShopView.ShopItemUIData shopItemUIData2 in this._onShowItemList)
					{
						if (shopItemUIData2 != null && shopItemUIData2.RelateData != null && (shopItemUIData == null || shopItemUIData2.RelateData.Price > shopItemUIData.RelateData.Price))
						{
							shopItemUIData = shopItemUIData2;
						}
					}
				}
				this._itemSlotSpecial.method_35(shopItemUIData, false);
			}
			if (this._onShowItemList == null)
			{
				foreach (uniShopView.ShopPanel.ShopItemSlot shopItemSlot in this._itemSlotAry)
				{
					if (shopItemSlot != null)
					{
						shopItemSlot.method_35(null, false);
					}
				}
				return;
			}
			int j = 0;
			for (int k = int_0 * 2; k < this._onShowItemList.Count; k++)
			{
				if (j >= this._itemSlotAry.Length)
				{
					break;
				}
				if (this._itemSlotAry[j] != null && this._onShowItemList[k] != null)
				{
					this._itemSlotAry[j].method_35(this._onShowItemList[k], this._curTab == ShopView.ShopTabState.SoldItems);
				}
				j++;
			}
			while (j < this._itemSlotAry.Length)
			{
				if (this._itemSlotAry[j] != null)
				{
					this._itemSlotAry[j].method_35(null, false);
				}
				j++;
			}
		}

		// Token: 0x06003CA7 RID: 15527 RVA: 0x00028E2D File Offset: 0x0002702D
		protected void method_12(CEvent cevent_0)
		{
			if (this._deleOnClickClose != null)
			{
				this._deleOnClickClose();
			}
		}

		// Token: 0x04002A9E RID: 10910
		protected const int MAX_SLOT_COUNT = 14;

		// Token: 0x04002A9F RID: 10911
		protected const string SLOT_NAME_PREFIX = "mcItemSlot";

		// Token: 0x04002AA0 RID: 10912
		protected const string TAB_BTNGROUP_NAME = "ShopButtonGroupName";

		// Token: 0x04002AA1 RID: 10913
		protected ShopView.ShopTabState _curTab;

		// Token: 0x04002AA2 RID: 10914
		protected GClass25 _XBtn = new GClass25();

		// Token: 0x04002AA3 RID: 10915
		protected GClass40 _btnPurchase = new GClass40();

		// Token: 0x04002AA4 RID: 10916
		protected GClass40 _btnSold = new GClass40();

		// Token: 0x04002AA5 RID: 10917
		protected uniShopView.ShopPanel.ShopItemSlot[] _itemSlotAry = new uniShopView.ShopPanel.ShopItemSlot[14];

		// Token: 0x04002AA6 RID: 10918
		protected GClass46 _scBar = new GClass46();

		// Token: 0x04002AA7 RID: 10919
		protected TextField _textRefreshTime;

		// Token: 0x04002AA8 RID: 10920
		protected TextField _textDescription;

		// Token: 0x04002AA9 RID: 10921
		protected List<ShopView.ShopItemUIData> _onShowItemList = new List<ShopView.ShopItemUIData>();

		// Token: 0x04002AAA RID: 10922
		protected uniShopView.ShopPanel.DeleOnClickClose _deleOnClickClose;

		// Token: 0x04002AAB RID: 10923
		protected uniShopView.ShopPanel.DeleOnClickShopItem _deleOnClickShopItem;

		// Token: 0x04002AAC RID: 10924
		protected uniShopView.ShopPanel.DeleOnSwitchTab _deleOnSwitchTab;

		// Token: 0x04002AAE RID: 10926
		protected uniShopView.ShopPanel.ShopItemSlot _itemSlotSpecial;

		// Token: 0x020008A0 RID: 2208
		protected class ShopItemSlot : GClass44
		{
			// Token: 0x06003CA9 RID: 15529 RVA: 0x0011F080 File Offset: 0x0011D280
			protected override void vmethod_0()
			{
				base.vmethod_0();
				this._textPrice = base.DisplayObjectContainer_0.getChildByName<UnityTextField>("textPrice");
				this._textName = base.DisplayObjectContainer_0.getChildByName<UnityTextField>("textName");
				this._textQuantity = base.DisplayObjectContainer_0.getChildByName<UnityTextField>("textNumber");
				if (this._textPrice != null)
				{
					this._textPrice.text = null;
					this._textPrice.visible = false;
					this._defaultColor = this._textPrice.Color_0;
				}
				if (this._textName != null)
				{
					this._textName.text = null;
					this._textName.visible = false;
				}
			}

			// Token: 0x06003CAA RID: 15530 RVA: 0x0011F128 File Offset: 0x0011D328
			public string method_34(ItemDNA itemDNA_0)
			{
				if (itemDNA_0.m_type == ItemType.Material)
				{
					return LocalizedString.smethod_0(new LocalizedString(itemDNA_0.m_materialType.ToString()));
				}
				if (itemDNA_0.m_type == ItemType.Shield)
				{
					return itemDNA_0.method_7().method_3();
				}
				if (itemDNA_0.m_type == ItemType.Weapon)
				{
					return itemDNA_0.method_6().method_4();
				}
				if (itemDNA_0.m_type == ItemType.ClassMode)
				{
					return itemDNA_0.method_8().method_6();
				}
				if (itemDNA_0.m_type == ItemType.Outfit)
				{
					return itemDNA_0.method_9().method_4();
				}
				return itemDNA_0.ToString();
			}

			// Token: 0x06003CAB RID: 15531 RVA: 0x0011F1B4 File Offset: 0x0011D3B4
			public void method_35(ShopView.ShopItemUIData shopItemUIData_0, bool bool_11 = false)
			{
				if (shopItemUIData_0 != null)
				{
					base.DisplayObjectContainer_0.visible = true;
					base.Object_0 = new UIItemSlotData(shopItemUIData_0.RelateData.Item, "Shop_Panel", 0, false);
					base.GInterface1_0 = new ItemTips(shopItemUIData_0.RelateData.Item);
					if (this._textPrice != null)
					{
						int num = shopItemUIData_0.RelateData.Price;
						if (bool_11)
						{
							num = Mathf.FloorToInt((float)num * ServiceWrapperBase<ShopServiceWrapper>.Instance.ShopSetup_0.m_soldRatio);
						}
						this._textPrice.text = "$" + num.ToString();
						this._textPrice.Color_0 = ((shopItemUIData_0.RelateData.Price <= ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_12().BondCurrency) ? this._defaultColor : Color.red);
					}
					if (this._textName != null)
					{
						this._textName.text = this.method_34(shopItemUIData_0.RelateData.Item);
						this._textName.Color_0 = UniUIManager.UniSWFToolClass.smethod_3(shopItemUIData_0.RelateData.Item.ItemRarity_0);
					}
					if (this._textQuantity != null)
					{
						this._textQuantity.visible = shopItemUIData_0.RelateData.Quantity > 1;
						this._textQuantity.text = shopItemUIData_0.RelateData.Quantity.ToString();
					}
				}
				else
				{
					base.Object_0 = null;
					base.GInterface1_0 = null;
					base.DisplayObjectContainer_0.visible = false;
					if (this._textPrice != null)
					{
						this._textPrice.text = null;
					}
					if (this._textName != null)
					{
						this._textName.text = null;
					}
				}
				this.object_0 = shopItemUIData_0;
			}

			// Token: 0x04002AAF RID: 10927
			protected UnityTextField _textPrice;

			// Token: 0x04002AB0 RID: 10928
			protected UnityTextField _textName;

			// Token: 0x04002AB1 RID: 10929
			protected UnityTextField _textQuantity;

			// Token: 0x04002AB2 RID: 10930
			protected Color _defaultColor;
		}

		// Token: 0x020008A1 RID: 2209
		// (Invoke) Token: 0x06003CAD RID: 15533
		public delegate void DeleOnClickClose();

		// Token: 0x020008A2 RID: 2210
		// (Invoke) Token: 0x06003CB1 RID: 15537
		public delegate void DeleOnClickShopItem(ShopView.ShopItemUIData itemData);

		// Token: 0x020008A3 RID: 2211
		// (Invoke) Token: 0x06003CB5 RID: 15541
		public delegate void DeleOnSwitchTab(ShopView.ShopTabState newState);
	}
}
