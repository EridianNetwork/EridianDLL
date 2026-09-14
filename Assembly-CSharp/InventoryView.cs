using System;
using System.Collections.Generic;
using ns0;
using UnityEngine;
using XsdSettings;

// Token: 0x0200070D RID: 1805
public class InventoryView : BaseView
{
	// Token: 0x06002FC8 RID: 12232 RVA: 0x000DA688 File Offset: 0x000D8888
	public InventoryView()
	{
		this._ammoInfoList = new Dictionary<int, Vector2>();
		for (int i = 0; i < 6; i++)
		{
			this._ammoInfoList.Add(i, new Vector2(0f, 0f));
		}
		this._arrItemComparion = new List<Comparison<UIItemSlotData>>(4);
		this._arrFilterList = new List<List<UIItemSlotData>>(4);
		this._arrNewFlagList = new List<bool>(4);
		this._arrFilterList.Add(new List<UIItemSlotData>());
		this._arrItemComparion.Add(new Comparison<UIItemSlotData>(InventoryView.smethod_0));
		this._arrNewFlagList.Add(false);
		this._arrFilterList.Add(new List<UIItemSlotData>());
		this._arrItemComparion.Add(new Comparison<UIItemSlotData>(InventoryView.smethod_2));
		this._arrNewFlagList.Add(false);
		this._arrFilterList.Add(new List<UIItemSlotData>());
		this._arrItemComparion.Add(new Comparison<UIItemSlotData>(InventoryView.smethod_3));
		this._arrNewFlagList.Add(false);
		this._arrFilterList.Add(new List<UIItemSlotData>());
		this._arrItemComparion.Add(new Comparison<UIItemSlotData>(InventoryView.smethod_4));
		this._arrNewFlagList.Add(false);
	}

	// Token: 0x06002FC9 RID: 12233 RVA: 0x000DA7F0 File Offset: 0x000D89F0
	public override void vmethod_2()
	{
		base.vmethod_2();
		MonoSingleton<AppManager>.Instance.method_0().method_6(this);
		this._iSlotSum = ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_31();
		this._iItemSum = ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_32();
		ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_0(new InventoryServiceWrapper.InventoryUpdateCallback(this.vmethod_6));
		this._currencyListener.view = this;
		ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_0(this._currencyListener);
		ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_22();
	}

	// Token: 0x06002FCA RID: 12234 RVA: 0x000DA870 File Offset: 0x000D8A70
	public override void vmethod_3()
	{
		base.vmethod_3();
		ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_1(this._currencyListener);
		ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_1(new InventoryServiceWrapper.InventoryUpdateCallback(this.vmethod_6));
		MonoSingleton<AppManager>.Instance.method_0().method_7(this);
		this._bVisible = false;
	}

	// Token: 0x06002FCB RID: 12235 RVA: 0x0000311B File Offset: 0x0000131B
	public virtual void vmethod_5(Vector2 vector2_0)
	{
	}

	// Token: 0x06002FCC RID: 12236 RVA: 0x000D8D54 File Offset: 0x000D6F54
	public override bool OnShortCutCMD(string command)
	{
		if (MonoSingleton<Session>.Instance != null)
		{
			PlayerInfoSync localPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer();
			if (localPlayer == null)
			{
				return false;
			}
			Entity entity = localPlayer.GetEntity();
			if (entity == null)
			{
				return false;
			}
			PlayerController component = entity.GetComponent<PlayerController>();
			if (component == null)
			{
				return false;
			}
			if (!component.method_3(PlayerAction.AccessInventory))
			{
				return false;
			}
		}
		if (!this.Boolean_0)
		{
			return false;
		}
		this.Boolean_1 = !this.Boolean_1;
		return true;
	}

	// Token: 0x06002FCD RID: 12237 RVA: 0x000D8DD4 File Offset: 0x000D6FD4
	public override bool vmethod_4()
	{
		if (this.Boolean_1 && MonoSingleton<AppManager>.Instance.method_0().vmethod_5<WeaponPreviewView>().Boolean_1)
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<WeaponPreviewView>().vmethod_5();
			return true;
		}
		if (this.Boolean_1)
		{
			this.Boolean_1 = false;
			return true;
		}
		return base.vmethod_4();
	}

	// Token: 0x06002FCE RID: 12238 RVA: 0x0001F5AE File Offset: 0x0001D7AE
	public virtual void vmethod_6(InventoryServiceWrapper.InventoryUpdateType inventoryUpdateType_0)
	{
		if (inventoryUpdateType_0 != InventoryServiceWrapper.InventoryUpdateType.ChangeActiveWeapon && this.method_7())
		{
			this.vmethod_8();
		}
	}

	// Token: 0x06002FCF RID: 12239 RVA: 0x000DA8C4 File Offset: 0x000D8AC4
	public virtual void vmethod_7()
	{
		if (!ServiceWrapperBase<InventoryServiceWrapper>.Instance.vmethod_2())
		{
			return;
		}
		for (int i = 0; i < 6; i++)
		{
			Vector2 vector = default(Vector2);
			vector.x = (float)ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_9((AmmoType)i);
			vector.y = (float)ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_10((AmmoType)i);
			this._ammoInfoList[i] = vector;
		}
		this.vmethod_11();
	}

	// Token: 0x06002FD0 RID: 12240 RVA: 0x0001F5C2 File Offset: 0x0001D7C2
	public void OnGotMyCurrencies(CurrencyInfo currency)
	{
		this._currencyInfo = currency;
		this.vmethod_9();
		this.vmethod_10();
	}

	// Token: 0x06002FD1 RID: 12241 RVA: 0x000DA92C File Offset: 0x000D8B2C
	public void method_3(ItemDNA itemDNA_0)
	{
		AmmoType ammoType = AmmoType.TOTAL;
		if (itemDNA_0 != null)
		{
			ammoType = itemDNA_0.method_1();
		}
		this.vmethod_12(ammoType);
	}

	// Token: 0x06002FD2 RID: 12242 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void vmethod_8()
	{
	}

	// Token: 0x06002FD3 RID: 12243 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void vmethod_9()
	{
	}

	// Token: 0x06002FD4 RID: 12244 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void vmethod_10()
	{
	}

	// Token: 0x06002FD5 RID: 12245 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void vmethod_11()
	{
	}

	// Token: 0x06002FD6 RID: 12246 RVA: 0x0000311B File Offset: 0x0000131B
	protected virtual void vmethod_12(AmmoType ammoType_0)
	{
	}

	// Token: 0x06002FD7 RID: 12247 RVA: 0x000DA94C File Offset: 0x000D8B4C
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		base.vmethod_1(bool_0, bool_1);
		if (!this._bVisible)
		{
			this._previousItems.Clear();
			for (int i = 0; i < this._arrItems.Count; i++)
			{
				this._arrItems[i].isNew = false;
				if (this._arrItems[i].item != null)
				{
					this._previousItems.Add(this._arrItems[i].item.GetHashCode());
				}
			}
			for (int j = 0; j < this._arrNewFlagList.Count; j++)
			{
				this._arrNewFlagList[j] = false;
			}
		}
	}

	// Token: 0x06002FD8 RID: 12248 RVA: 0x000DA9F8 File Offset: 0x000D8BF8
	private int method_4(ItemType itemType_0)
	{
		int num = 0;
		switch (itemType_0)
		{
		case ItemType.Weapon:
			return 0;
		default:
			return 3;
		case ItemType.Outfit:
			return 2;
		case ItemType.Shield:
		case ItemType.ClassMode:
			return 1;
		}
	}
	// Token: 0x06002FD9 RID: 12249 RVA: 0x000DAA4C File Offset: 0x000D8C4C
	protected void method_5()
	{
		foreach (List<UIItemSlotData> list in this._arrFilterList)
		{
			list.Clear();
		}
		for (int i = 0; i < this._arrItems.Count; i++)
		{
			if (this._arrItems[i].item != null)
			{
				this._arrFilterList[this.method_4(this._arrItems[i].item.m_type)].Add(this._arrItems[i]);
			}
		}
	}

	// Token: 0x06002FDA RID: 12250 RVA: 0x0001F5D7 File Offset: 0x0001D7D7
	protected List<UIItemSlotData> method_6(int int_0)
	{
		if (int_0 >= 0 && int_0 <= this._arrFilterList.Count)
		{
			this._arrFilterList[int_0].Sort(this._arrItemComparion[int_0]);
			return this._arrFilterList[int_0];
		}
		return null;
	}

	// Token: 0x06002FDB RID: 12251 RVA: 0x000DAAE0 File Offset: 0x000D8CE0
	public static int smethod_0(UIItemSlotData uiitemSlotData_0, UIItemSlotData uiitemSlotData_1)
	{
		int num = 0;
		if (uiitemSlotData_0.item == null && uiitemSlotData_1.item != null)
		{
			num = -1;
		}
		if (uiitemSlotData_1.item == null)
		{
			num = 1;
		}
		if (num != 0)
		{
			return num;
		}
		WeaponDNA weaponDNA = uiitemSlotData_0.item.method_6();
		WeaponDNA weaponDNA2 = uiitemSlotData_1.item.method_6();
		num = weaponDNA.method_1() - weaponDNA2.method_1();
		if (num == 0)
		{
			num = InventoryView.smethod_1(uiitemSlotData_0, uiitemSlotData_1);
		}
		if (num == 0)
		{
			num = weaponDNA.m_level - weaponDNA2.m_level;
		}
		if (num == 0)
		{
			num = weaponDNA.m_starLevel - weaponDNA2.m_starLevel;
		}
		return num;
	}

	// Token: 0x06002FDC RID: 12252 RVA: 0x000DAB64 File Offset: 0x000D8D64
	public static int smethod_1(UIItemSlotData uiitemSlotData_0, UIItemSlotData uiitemSlotData_1)
	{
		if (uiitemSlotData_0.item == null)
		{
			if (uiitemSlotData_1.item == null)
			{
				return 0;
			}
			return -1;
		}
		else
		{
			if (uiitemSlotData_1.item == null)
			{
				return 1;
			}
			return uiitemSlotData_1.item.ItemRarity_0 - uiitemSlotData_0.item.ItemRarity_0;
		}
	}

	// Token: 0x06002FDD RID: 12253 RVA: 0x000DABAC File Offset: 0x000D8DAC
	public static int smethod_2(UIItemSlotData uiitemSlotData_0, UIItemSlotData uiitemSlotData_1)
	{
		int num = uiitemSlotData_0.item.m_type - uiitemSlotData_1.item.m_type;
		if (num == 0)
		{
			num = InventoryView.smethod_1(uiitemSlotData_0, uiitemSlotData_1);
		}
		if (num == 0)
		{
			num = uiitemSlotData_0.item.method_0() - uiitemSlotData_1.item.method_0();
		}
		return num;
	}

	// Token: 0x06002FDE RID: 12254 RVA: 0x000DABFC File Offset: 0x000D8DFC
	public static int smethod_3(UIItemSlotData uiitemSlotData_0, UIItemSlotData uiitemSlotData_1)
	{
		OutfitDNA outfitDNA = uiitemSlotData_0.item.method_9();
		OutfitDNA outfitDNA2 = uiitemSlotData_1.item.method_9();
		return outfitDNA.m_avatarSubpart - outfitDNA2.m_avatarSubpart;
	}

	// Token: 0x06002FDF RID: 12255 RVA: 0x0001F616 File Offset: 0x0001D816
	public static int smethod_4(UIItemSlotData uiitemSlotData_0, UIItemSlotData uiitemSlotData_1)
	{
		return InventoryView.smethod_1(uiitemSlotData_0, uiitemSlotData_1);
	}

	// Token: 0x06002FE0 RID: 12256 RVA: 0x000DAC34 File Offset: 0x000D8E34
	protected bool method_7()
	{
		if (!ServiceWrapperBase<InventoryServiceWrapper>.Instance.vmethod_2())
		{
			return false;
		}
		this._arrItems.Clear();
		bool flag = false;
		for (int i = 0; i < this._iSlotSum; i++)
		{
			ItemDNA itemDNA = ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_6(i);
			if (itemDNA != null && !this._previousItems.Contains(itemDNA.GetHashCode()) && MonoSingleton<GuidanceTipsManager>.Instance != null)
			{
				MonoSingleton<GuidanceTipsManager>.Instance.OnObtainItem(itemDNA);
			}
			this._arrItems.Add(new UIItemSlotData(itemDNA, "inventory", i, flag));
		}
		this._iItemSum = ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_32();
		return true;
	}

	// Token: 0x06002FE1 RID: 12257 RVA: 0x000DACD0 File Offset: 0x000D8ED0
	protected void method_8(int int_0, int int_1)
	{
		if (int_0 >= 0 && int_0 < this._iSlotSum && int_1 >= 0 && int_1 < this._iSlotSum)
		{
			if (ServiceWrapperBase<InventoryServiceWrapper>.Instance.vmethod_2())
			{
				if (this._arrItems[int_0] != null && this._arrItems[int_1] != null && this._arrItems[int_0].item != null && this._arrItems[int_1].item != null && this._arrItems[int_1].item.method_3(ItemType.Material) && this._arrItems[int_0].item.method_3(ItemType.Material) && this._arrItems[int_0].item.m_materialType == this._arrItems[int_1].item.m_materialType)
				{
					ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_24((int)((byte)int_0), (int)((byte)int_1));
				}
				else
				{
					ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_11((byte)int_0, (byte)int_1);
				}
			}
			return;
		}
	}

	// Token: 0x06002FE2 RID: 12258 RVA: 0x0001F61F File Offset: 0x0001D81F
	protected void method_9(int int_0, int int_1)
	{
		if (int_1 >= 0 && int_1 < this._iSlotSum)
		{
			if (ServiceWrapperBase<InventoryServiceWrapper>.Instance.vmethod_2())
			{
				ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_35((byte)int_0, (byte)int_1, false);
			}
			return;
		}
	}

	// Token: 0x06002FE3 RID: 12259 RVA: 0x0001F64A File Offset: 0x0001D84A
	protected void method_10()
	{
		if (ServiceWrapperBase<InventoryServiceWrapper>.Instance.vmethod_2())
		{
			ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_23();
		}
	}

	// Token: 0x06002FE4 RID: 12260 RVA: 0x000DADDC File Offset: 0x000D8FDC
	protected void method_11(int int_0)
	{
		this._iDropItemIndex = int_0;
		if (this._arrItems[this._iDropItemIndex].item.method_4())
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDWarningView>().vmethod_7(LocalizedString.smethod_0(new LocalizedString("Warning_Inventory_Discard")), new Delegate_EventProc(this.vmethod_13), new Delegate_EventProc(this.vmethod_14));
		}
		else
		{
			this.vmethod_13();
		}
	}

	// Token: 0x06002FE5 RID: 12261 RVA: 0x0001F662 File Offset: 0x0001D862
	protected void method_12(int int_0)
	{
		if (ServiceWrapperBase<InventoryServiceWrapper>.Instance.vmethod_2())
		{
			ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_14((byte)int_0);
		}
	}

	// Token: 0x06002FE6 RID: 12262 RVA: 0x0001F67C File Offset: 0x0001D87C
	protected void method_13(AvatarSubPart avatarSubPart_0)
	{
		if (ServiceWrapperBase<InventoryServiceWrapper>.Instance.vmethod_2())
		{
			ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_17(avatarSubPart_0);
		}
	}

	// Token: 0x06002FE7 RID: 12263 RVA: 0x000DAE54 File Offset: 0x000D9054
	protected void method_14(UIItemSlotData uiitemSlotData_0)
	{
		List<MenuItemDef> list = new List<MenuItemDef>();
		MenuItemDef menuItemDef;
		if (uiitemSlotData_0.item.method_3(ItemType.Weapon) || uiitemSlotData_0.item.method_3(ItemType.ClassMode) || uiitemSlotData_0.item.method_3(ItemType.Shield) || uiitemSlotData_0.item.method_3(ItemType.Outfit))
		{
			menuItemDef.itemTitle = LocalizedString.smethod_0(new LocalizedString("Equipment"));
			menuItemDef.itemData = uiitemSlotData_0.index;
			menuItemDef.itemFunc = new MenuItemProcessFunc(this.method_15);
			list.Add(menuItemDef);
		}
		menuItemDef.itemTitle = LocalizedString.smethod_0(new LocalizedString("DiscardItem"));
		menuItemDef.itemData = uiitemSlotData_0.index;
		menuItemDef.itemFunc = new MenuItemProcessFunc(this.method_16);
		list.Add(menuItemDef);
		if (uiitemSlotData_0.item.method_3(ItemType.Weapon))
		{
			menuItemDef.itemTitle = LocalizedString.smethod_0(new LocalizedString("PreviewItem"));
			menuItemDef.itemData = uiitemSlotData_0.item.method_6();
			menuItemDef.itemFunc = new MenuItemProcessFunc(this.method_17);
			list.Add(menuItemDef);
		}
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<PopupMenuView>().method_3(list.ToArray());
	}

	// Token: 0x06002FE8 RID: 12264 RVA: 0x000DAF90 File Offset: 0x000D9190
	protected void method_15(object object_0)
	{
		int num = (int)object_0;
		if (num >= 0 && num < this._iSlotSum)
		{
			if (ServiceWrapperBase<InventoryServiceWrapper>.Instance.vmethod_2())
			{
				ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_25((byte)num, 0);
			}
			return;
		}
	}

	// Token: 0x06002FE9 RID: 12265 RVA: 0x0001F695 File Offset: 0x0001D895
	protected void method_16(object object_0)
	{
		this._iDropItemIndex = (int)object_0;
		this.method_11(this._iDropItemIndex);
	}

	// Token: 0x06002FEA RID: 12266 RVA: 0x0001F6AF File Offset: 0x0001D8AF
	protected virtual void vmethod_13()
	{
		if (this._iDropItemIndex >= 0 && this._iDropItemIndex < this._iSlotSum)
		{
			if (ServiceWrapperBase<InventoryServiceWrapper>.Instance.vmethod_2())
			{
				ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_18((byte)this._iDropItemIndex);
			}
			return;
		}
	}

	// Token: 0x06002FEB RID: 12267 RVA: 0x0001F6E6 File Offset: 0x0001D8E6
	protected virtual void vmethod_14()
	{
		this._iDropItemIndex = -1;
	}

	// Token: 0x06002FEC RID: 12268 RVA: 0x0001F6EF File Offset: 0x0001D8EF
	protected void method_17(object object_0)
	{
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<WeaponPreviewView>().vmethod_6((WeaponDNA)object_0, true);
	}

	// Token: 0x0400213C RID: 8508
	protected const int FILTER_TYPE_NUMBER = 4;

	// Token: 0x0400213D RID: 8509
	public const string ITEM_ID_STR = "inventory";

	// Token: 0x0400213E RID: 8510
	protected List<List<UIItemSlotData>> _arrFilterList;

	// Token: 0x0400213F RID: 8511
	protected List<Comparison<UIItemSlotData>> _arrItemComparion;

	// Token: 0x04002140 RID: 8512
	protected List<bool> _arrNewFlagList;

	// Token: 0x04002141 RID: 8513
	protected List<UIItemSlotData> _arrItems = new List<UIItemSlotData>();

	// Token: 0x04002142 RID: 8514
	protected int _iSlotSum = 60;

	// Token: 0x04002143 RID: 8515
	protected int _iItemSum;

	// Token: 0x04002144 RID: 8516
	protected InventoryView.CharInfoNotification _currencyListener = new InventoryView.CharInfoNotification();

	// Token: 0x04002145 RID: 8517
	protected CurrencyInfo _currencyInfo;

	// Token: 0x04002146 RID: 8518
	protected int _iDropItemIndex = -1;

	// Token: 0x04002147 RID: 8519
	protected Dictionary<int, Vector2> _ammoInfoList;

	// Token: 0x04002148 RID: 8520
	private HashSet<int> _previousItems = new HashSet<int>();

	// Token: 0x0200070E RID: 1806
	protected class CharInfoNotification : ICharacterServiceNotificationListerner
	{
		// Token: 0x06002FEE RID: 12270 RVA: 0x0001F70C File Offset: 0x0001D90C
		void ICharacterServiceNotificationListerner.OnGotMyCurrencies(CurrencyInfo currency)
		{
			if (this.view != null)
			{
				this.view.OnGotMyCurrencies(currency);
			}
		}

		// Token: 0x06002FEF RID: 12271 RVA: 0x0000311B File Offset: 0x0000131B
		void ICharacterServiceNotificationListerner.OnExperienceUpdated(int experience)
		{
		}

		// Token: 0x06002FF0 RID: 12272 RVA: 0x0000311B File Offset: 0x0000131B
		void ICharacterServiceNotificationListerner.OnGetPersonalSettings(string strSettings)
		{
		}

		// Token: 0x06002FF1 RID: 12273 RVA: 0x0000311B File Offset: 0x0000131B
		void ICharacterServiceNotificationListerner.OnSetPersonalSettings(int iResult)
		{
		}

		// Token: 0x06002FF2 RID: 12274 RVA: 0x0000311B File Offset: 0x0000131B
		void ICharacterServiceNotificationListerner.OnGetCharacterSettings(string strSettings)
		{
		}

		// Token: 0x06002FF3 RID: 12275 RVA: 0x0000311B File Offset: 0x0000131B
		void ICharacterServiceNotificationListerner.OnSetCharacterSettings(int iResult)
		{
		}

		// Token: 0x04002149 RID: 8521
		public InventoryView view;
	}
}
