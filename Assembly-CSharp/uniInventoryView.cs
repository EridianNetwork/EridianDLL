using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using Core;
using ns0;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;
using UnityEngine;
using XsdSettings;

// Token: 0x02000855 RID: 2133
public class uniInventoryView : InventoryView
{
	// Token: 0x060039EF RID: 14831 RVA: 0x0010ED50 File Offset: 0x0010CF50
	public uniInventoryView()
	{
		this._dicClassModeTypeString = new Dictionary<int, string>();
		IEnumerator enumerator = Enum.GetValues(typeof(ClassModeType)).GetEnumerator();
		while (enumerator.MoveNext())
		{
			this._dicClassModeTypeString.Add((int)enumerator.Current, enumerator.Current.ToString());
		}
		this._dicManufacturerTypeString = new Dictionary<int, string>();
		enumerator = Enum.GetValues(typeof(ItemManufacturer)).GetEnumerator();
		while (enumerator.MoveNext())
		{
			this._dicManufacturerTypeString.Add((int)enumerator.Current, enumerator.Current.ToString().ToLower());
		}
		this._dicWeaponTypeString = new Dictionary<int, string>();
		enumerator = Enum.GetValues(typeof(WeaponType)).GetEnumerator();
		while (enumerator.MoveNext())
		{
			this._dicWeaponTypeString.Add((int)enumerator.Current, enumerator.Current.ToString());
		}
		this._dicMaterialTypeString = new Dictionary<int, string>();
		enumerator = Enum.GetValues(typeof(MaterialType)).GetEnumerator();
		while (enumerator.MoveNext())
		{
			this._dicMaterialTypeString.Add((int)enumerator.Current, enumerator.Current.ToString());
		}
	}

	// Token: 0x17000313 RID: 787
	// (get) Token: 0x060039F0 RID: 14832 RVA: 0x00026BA4 File Offset: 0x00024DA4
	public uniInventoryView.InventoryPanel InventoryPanel_0
	{
		get
		{
			return this.m_InventoryPanel;
		}
	}

	// Token: 0x060039F1 RID: 14833 RVA: 0x0010EEBC File Offset: 0x0010D0BC
	public override void vmethod_2()
	{
		base.vmethod_2();
		this._bActive = false;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("2014_Inventory_.swf", "Panel_Inventory", new FuncLoad(this.method_19));
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("2014_Inventory_icon.swf", "MT_Money", new FuncLoad(this.method_18));
		WeaponTips.smethod_0();
	}

	// Token: 0x060039F2 RID: 14834 RVA: 0x00026BAC File Offset: 0x00024DAC
	private void method_18(MovieClip movieClip_0)
	{
		movieClip_0.stopAll();
		this._MoneyIcon = movieClip_0;
	}

	// Token: 0x060039F3 RID: 14835 RVA: 0x0010EF30 File Offset: 0x0010D130
	private void method_19(MovieClip movieClip_0)
	{
		this.m_InventoryPanel = new uniInventoryView.InventoryPanel(this._iSlotSum);
		this.m_InventoryPanel.method_0(movieClip_0);
		movieClip_0.visible = this._bVisible;
		this.m_InventoryPanel.method_15(new uniInventoryView.Item_SWAP_Delegate(this.method_24));
		this.m_InventoryPanel.addEventListener("TidyClicked", new EventDispatcher.EventCallback(this.method_26));
		this.m_InventoryPanel.addEventListener("Filter", new EventDispatcher.EventCallback(this.method_27));
		this.m_InventoryPanel.addEventListener("XBtnClicked", new EventDispatcher.EventCallback(this.method_29));
		this.m_InventoryPanel.addEventListener("showWeaponModel", new EventDispatcher.EventCallback(this.method_30));
		this.m_InventoryPanel.addEventListener("Item" + GClass53.string_5, new EventDispatcher.EventCallback(this.method_31));
		UniUIManager uniUIManager = MonoSingleton<AppManager>.Instance.method_0() as UniUIManager;
		uniUIManager.GClass41_0.addEventListener("drop", new EventDispatcher.EventCallback(this.method_28));
		uniUIManager.method_0(new GameUIManager.ViewUpdateCB(this.method_20), true);
		this._bActive = true;
	}

	// Token: 0x060039F4 RID: 14836 RVA: 0x00026BBB File Offset: 0x00024DBB
	public void method_20()
	{
		if (this.m_InventoryPanel != null)
		{
			this.m_InventoryPanel.method_9();
		}
	}

	// Token: 0x060039F5 RID: 14837 RVA: 0x0010F060 File Offset: 0x0010D260
	public override void vmethod_3()
	{
		base.vmethod_3();
		if (this.m_InventoryPanel != null)
		{
			this.m_InventoryPanel.method_16(new uniInventoryView.Item_SWAP_Delegate(this.method_24));
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this.m_InventoryPanel);
		}
		this.m_InventoryPanel = null;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("2014_Inventory_.swf");
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("2014_Inventory_icon.swf");
	}

	// Token: 0x060039F6 RID: 14838 RVA: 0x0010F0E8 File Offset: 0x0010D2E8
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		base.vmethod_1(bool_0, bool_1);
		if (this._bVisible)
		{
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_31(this.m_InventoryPanel);
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("UI_BackMenu_Open_Main");
			if (this.m_InventoryPanel != null)
			{
				this.m_InventoryPanel.Vector2_0 = this._visiblePos;
			}
			this._curFilterPage = -1;
			this.method_25();
			this.m_InventoryPanel.Boolean_0 = true;
			this.vmethod_9();
			this.vmethod_10();
			this.m_InventoryPanel.method_12(this._arrNewFlagList);
		}
		else
		{
			this.m_InventoryPanel.Boolean_0 = false;
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("UI_BackMenu_Close_Main");
		}
		if (!this._bVisible)
		{
			DragManagerLayer.Instance.method_3();
		}
	}

	// Token: 0x060039F7 RID: 14839 RVA: 0x00026BD0 File Offset: 0x00024DD0
	public override void vmethod_5(Vector2 vector2_0)
	{
		base.vmethod_5(vector2_0);
		this._visiblePos = vector2_0;
		if (this.m_InventoryPanel != null && this.m_InventoryPanel.Boolean_0)
		{
			this.m_InventoryPanel.Vector2_0 = this._visiblePos;
		}
	}

	// Token: 0x060039F8 RID: 14840 RVA: 0x00026C06 File Offset: 0x00024E06
	protected override void vmethod_8()
	{
		if (this.m_InventoryPanel == null)
		{
			return;
		}
		this.m_InventoryPanel.method_10(this._iItemSum, this._iSlotSum);
		this.method_25();
	}

	// Token: 0x060039F9 RID: 14841 RVA: 0x0010F1C4 File Offset: 0x0010D3C4
	public void method_21(object object_0, GClass44 gclass44_0)
	{
		if (gclass44_0 == null)
		{
			return;
		}
		MovieClip childByName = gclass44_0.movieClip_1.getChildByName<MovieClip>("icon");
		if (childByName != null)
		{
			gclass44_0.movieClip_1.removeChild(childByName);
		}
		gclass44_0.movieClip_2 = null;
		gclass44_0.Boolean_4 = false;
		if (gclass44_0.movieClip_7 != null)
		{
			gclass44_0.movieClip_7.visible = false;
		}
		gclass44_0.Int32_0 = -1;
		if (gclass44_0.movieClip_4 != null)
		{
			gclass44_0.movieClip_4.visible = false;
		}
		if (object_0 == null)
		{
			return;
		}
		UIItemSlotData uiitemSlotData = (UIItemSlotData)object_0;
		ItemDNA item = uiitemSlotData.item;
		if (item != null)
		{
			if (item.m_type == ItemType.Material)
			{
				gclass44_0.Int32_0 = item.m_value;
			}
			if (gclass44_0.movieClip_4 != null)
			{
				gclass44_0.movieClip_4.visible = uiitemSlotData.isNew;
			}
			if (gclass44_0.movieClip_7 != null)
			{
				gclass44_0.movieClip_7.visible = true;
			}
			gclass44_0.Color_0 = UniUIManager.UniSWFToolClass.smethod_3(item.ItemRarity_0);
			MovieClip movieClip = this.method_23(item);
			if (movieClip != null)
			{
				movieClip.name = "icon";
				gclass44_0.movieClip_1.stopAll();
				gclass44_0.movieClip_1.addChild(movieClip);
				gclass44_0.movieClip_2 = movieClip;
			}
			else
			{
				gclass44_0.movieClip_2 = null;
			}
		}
	}

	// Token: 0x060039FA RID: 14842 RVA: 0x00026C2E File Offset: 0x00024E2E
	protected override void vmethod_9()
	{
		if (this.m_InventoryPanel != null && this._currencyInfo != null)
		{
			this.m_InventoryPanel.method_7(this._currencyInfo.BondCurrency, this._currencyInfo.SpecialCurrency, this._currencyInfo.CirculateCurrency);
			return;
		}
	}

	// Token: 0x060039FB RID: 14843 RVA: 0x0010F2DC File Offset: 0x0010D4DC
	protected override void vmethod_10()
	{
		if (this.m_InventoryPanel != null && this._currencyInfo != null)
		{
			int num = 0;
			if (this._currencyInfo.Dictionary_0.ContainsKey(LuckyBoxRank.Diamond))
			{
				num = this._currencyInfo.Dictionary_0[LuckyBoxRank.Diamond];
			}
			ExpiringCurrency expiringCurrency = null;
			if (this._currencyInfo.Dictionary_1.ContainsKey(LuckyBoxRank.Diamond))
			{
				expiringCurrency = this._currencyInfo.Dictionary_1[LuckyBoxRank.Diamond];
			}
			this.m_InventoryPanel.method_8(num, expiringCurrency);
			return;
		}
	}

	// Token: 0x060039FC RID: 14844 RVA: 0x00026C6D File Offset: 0x00024E6D
	protected override void vmethod_11()
	{
		if (this.m_InventoryPanel == null)
		{
			return;
		}
		this.m_InventoryPanel.method_5(this._ammoInfoList);
	}

	// Token: 0x060039FD RID: 14845 RVA: 0x00026C89 File Offset: 0x00024E89
	protected override void vmethod_12(AmmoType ammoType_0)
	{
		if (this.m_InventoryPanel == null)
		{
			return;
		}
		this.m_InventoryPanel.method_6(ammoType_0);
	}

	// Token: 0x060039FE RID: 14846 RVA: 0x00026CA0 File Offset: 0x00024EA0
	public MovieClip method_22()
	{
		return new BadAssMovieClip("2014_Inventory_icon.swf", "MT_Money");
	}

	// Token: 0x060039FF RID: 14847 RVA: 0x0010F358 File Offset: 0x0010D558
	public MovieClip method_23(ItemDNA itemDNA_0)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (itemDNA_0.m_type == ItemType.Weapon)
		{
			WeaponDNA weaponDNA = itemDNA_0.method_6();
			stringBuilder.Append("Weapon_").Append(this._dicWeaponTypeString[(int)weaponDNA.method_1()]).Append("_")
				.Append(UniUIManager.UniSWFToolClass._BrandStringMap[(weaponDNA.m_attribute.method_1(AttributeType.ManufactureType) as IntAttributeValue).m_value]);
		}
		else if (itemDNA_0.m_type == ItemType.Shield)
		{
			ShieldDNA shieldDNA = itemDNA_0.method_7();
			stringBuilder.Append("Shield_").Append(this._dicManufacturerTypeString[(int)shieldDNA.m_shieldManufacturer]).Append("_")
				.Append(shieldDNA.method_0());
		}
		else if (itemDNA_0.m_type == ItemType.ClassMode)
		{
			ClassModeDNA classModeDNA = itemDNA_0.method_8();
			stringBuilder.Append("ClassMode_").Append(this._dicClassModeTypeString[(int)classModeDNA.m_cmType]).Append("_")
				.Append(classModeDNA.method_0());
		}
		else if (itemDNA_0.m_type == ItemType.Material)
		{
			stringBuilder.Append(this._dicMaterialTypeString[(int)itemDNA_0.m_materialType]);
		}
		else if (itemDNA_0.m_type == ItemType.Outfit)
		{
			OutfitDNA outfitDNA = itemDNA_0.method_9();
			this.strIconName1 = string.Empty;
			this.strIconName2 = string.Empty;
			if (outfitDNA.method_0(ref this.strIconName1, ref this.strIconName2))
			{
				this.strIconName2 = Path.GetFileNameWithoutExtension(this.strIconName2);
				this.strIconName2 = this.strIconName2.Replace("MAT", "Outfit");
			}
			stringBuilder.Append(this.strIconName2);
		}
		MovieClip movieClip = new BadAssMovieClip("2014_Inventory_icon.swf", stringBuilder.ToString());
		if (movieClip.movieClipInfo != null)
		{
			movieClip.stopAll();
			return movieClip;
		}
		DebugUtils.LogWarning(LogCategory.GUI, "Icon movie can not find name: " + stringBuilder.ToString());
		return null;
	}

	// Token: 0x06003A00 RID: 14848 RVA: 0x0010F53C File Offset: 0x0010D73C
	protected void method_24(UIItemSlotData uiitemSlotData_0, UIItemSlotData uiitemSlotData_1)
	{
		if (uiitemSlotData_1.identifier == "inventory")
		{
			base.method_8(uiitemSlotData_1.index, uiitemSlotData_0.index);
		}
		else if (uiitemSlotData_1.identifier == "character")
		{
			base.method_12(uiitemSlotData_1.index);
		}
		else if (uiitemSlotData_1.identifier == "charOutfit")
		{
			if (uiitemSlotData_1.item != null && uiitemSlotData_1.item.method_3(ItemType.Outfit))
			{
				base.method_13(uiitemSlotData_1.item.method_9().m_avatarSubpart);
			}
		}
		else if (uiitemSlotData_1.identifier == "warehouse")
		{
			base.method_9(uiitemSlotData_1.index, uiitemSlotData_0.index);
		}
	}

	// Token: 0x06003A01 RID: 14849 RVA: 0x0010F5F8 File Offset: 0x0010D7F8
	protected void method_25()
	{
		if (this._curFilterPage >= 0 && this._curFilterPage < this._arrFilterList.Count)
		{
			base.method_5();
			this.m_InventoryPanel.method_14(this._curFilterPage, base.method_6(this._curFilterPage));
		}
		else
		{
			int num = 0;
			while (num < this.m_InventoryPanel.SLOT_NUM && num < this._arrItems.Count)
			{
				this.m_InventoryPanel.method_11(num, this._arrItems[num]);
				num++;
			}
			this.m_InventoryPanel.method_13();
		}
	}

	// Token: 0x06003A02 RID: 14850 RVA: 0x00026CB1 File Offset: 0x00024EB1
	protected void method_26(CEvent cevent_0)
	{
		base.method_10();
	}

	// Token: 0x06003A03 RID: 14851 RVA: 0x00026CB9 File Offset: 0x00024EB9
	protected void method_27(CEvent cevent_0)
	{
		this._curFilterPage = (int)(cevent_0 as GClass55).object_0;
		this.method_25();
	}

	// Token: 0x06003A04 RID: 14852 RVA: 0x0010F690 File Offset: 0x0010D890
	protected void method_28(CEvent cevent_0)
	{
		GClass55 gclass = cevent_0 as GClass55;
		if (gclass != null)
		{
			UIItemSlotData uiitemSlotData = (UIItemSlotData)gclass.object_0;
			if (uiitemSlotData.identifier == "inventory")
			{
				base.method_11(uiitemSlotData.index);
			}
		}
	}

	// Token: 0x06003A05 RID: 14853 RVA: 0x0001E5A9 File Offset: 0x0001C7A9
	protected void method_29(CEvent cevent_0)
	{
		this.Boolean_1 = false;
	}

	// Token: 0x06003A06 RID: 14854 RVA: 0x000F634C File Offset: 0x000F454C
	protected void method_30(CEvent cevent_0)
	{
		GClass55 gclass = cevent_0 as GClass55;
		if (gclass != null)
		{
			WeaponDNA weaponDNA = (WeaponDNA)gclass.object_0;
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<WeaponPreviewView>().vmethod_6(weaponDNA, true);
		}
	}

	// Token: 0x06003A07 RID: 14855 RVA: 0x0010F6D4 File Offset: 0x0010D8D4
	protected void method_31(CEvent cevent_0)
	{
		GClass55 gclass = cevent_0 as GClass55;
		UIItemSlotData uiitemSlotData = (UIItemSlotData)gclass.object_0;
		base.method_14(uiitemSlotData);
	}

	// Token: 0x04002894 RID: 10388
	protected uniInventoryView.InventoryPanel m_InventoryPanel;

	// Token: 0x04002895 RID: 10389
	protected Vector2 _visiblePos = Vector2.zero;

	// Token: 0x04002896 RID: 10390
	protected Dictionary<int, string> _dicClassModeTypeString;

	// Token: 0x04002897 RID: 10391
	protected Dictionary<int, string> _dicManufacturerTypeString;

	// Token: 0x04002898 RID: 10392
	protected Dictionary<int, string> _dicWeaponTypeString;

	// Token: 0x04002899 RID: 10393
	protected Dictionary<int, string> _dicMaterialTypeString;

	// Token: 0x0400289A RID: 10394
	protected MovieClip _MoneyIcon;

	// Token: 0x0400289B RID: 10395
	protected int _curFilterPage = -1;

	// Token: 0x0400289C RID: 10396
	private string strIconName1 = string.Empty;

	// Token: 0x0400289D RID: 10397
	private string strIconName2 = string.Empty;

	// Token: 0x02000856 RID: 2134
	public class InventoryPanel : GClass51
	{
		protected const int TITLE_HEIGHT = 31;

		protected const int SLOT_HEIGHT = 61;

		protected const int SLOT_HOR_SPACE = 81;

		protected const int SLOT_START_X = 18;

		protected const int LINE_SUM = 5;

		protected Item_SWAP_Delegate swapFunc;

		protected GClass44[] _arrItemSlots;

		protected MovieClip mcRootMovie;

		protected MovieClip mcRoot;

		public int SLOT_NUM = 60;

		protected int _iItemSum;

		private string ITEM_SLOT_PREFIX_NAME = "mcItemSlot";

		private string SUBTITLE_MOVIE_NAME = "Movie_SubTitle";

		private string ITEM_SLOT_MOVIE_NAME = "ItemSlot_goodsSlot";

		protected GClass25 mcXButton;

		protected GClass25 mcKeyAddBtn;

		protected GClass25 mcSortBtn;

		protected GClass40 mcTabAll;

		protected GClass40 mcTabWeapon;

		protected GClass40 mcTabMod;

		protected GClass40 mcTabOutfit;

		protected GClass40 mcTabOther;

		protected MovieClip mcNewMarkAll;

		protected MovieClip mcNewMarkWeapon;

		protected MovieClip mcNewMarkMod;

		protected MovieClip mcNewMarkOutfit;

		protected MovieClip mcNewMarkOther;

		protected MovieClip mcPageAll;

		protected MovieClip mcPageFilter;

		protected Vector2 orinPosAll;

		protected Vector2 orinPosFilter;

		protected GClass46 mcSB;

		protected GClass47 mcScrollView;

		protected TextField specialCurrencyTF;

		protected TextField circulateCurrencyTF;

		protected TextField bondCurrencyTF;

		protected TextField keysTF;

		protected TextField expiringKeysTF;

		protected TextField expiringTimeTF;

		protected UnityTextField tfSummary;

		protected ExpiringCurrency expiringKey;

		protected List<Dictionary<int, string>> _arrFilterSubTitle;

		protected List<Func<UIItemSlotData, string>> _arrSubTitleGetter;

		protected MovieClip mcAmmoPistol_bg;

		protected MovieClip mcAmmoSniper_bg;

		protected MovieClip mcAmmoSMG_bg;

		protected MovieClip mcAmmoAssaultRifle_bg;

		protected MovieClip mcAmmoShotGun_bg;

		protected MovieClip mcAmmoGrenade_bg;

		protected int _iCurPageType = -2;

		private StringBuilder stringbuilder = new StringBuilder(32, 32);

		private static StringBuilder _sbAmmoName = new StringBuilder(32, 32);

		protected List<GClass44> _arrCachedItemSL = new List<GClass44>();

		protected int _ItemSLCacheIdx;

		protected List<MovieClip> _arrCachedTitle = new List<MovieClip>();

		protected int _TitleCacheIdx;

		public Vector2 Vector2_0
		{
			get
			{
				return new Vector2(mcRootMovie.x, mcRootMovie.y);
			}
			set
			{
				Vector2 vector = GClass20.GClass20_0.method_2(mcRootMovie.parent, value);
				mcRootMovie.x = vector.x;
				mcRootMovie.y = vector.y;
			}
		}

		public bool Boolean_0
		{
			get
			{
				return mcRootMovie.visible;
			}
			set
			{
				if (value)
				{
					method_32();
				}
				else
				{
					method_33();
				}
			}
		}

		public bool Boolean_1 => mcRootMovie.isPlaying;

		public InventoryPanel(int int_0)
		{
			_arrItemSlots = new GClass44[SLOT_NUM];
			_arrFilterSubTitle = new List<Dictionary<int, string>>(4);
			_arrSubTitleGetter = new List<Func<UIItemSlotData, string>>(4);
			Dictionary<int, string> item = new Dictionary<int, string>
			{
				{
					0,
					LocalizedString.smethod_0(new LocalizedString("Weapon_SMG"))
				},
				{
					1,
					LocalizedString.smethod_0(new LocalizedString("Weapon_Sniper"))
				},
				{
					2,
					LocalizedString.smethod_0(new LocalizedString("Weapon_Shotgun"))
				},
				{
					3,
					LocalizedString.smethod_0(new LocalizedString("Weapon_Pistol"))
				},
				{
					4,
					LocalizedString.smethod_0(new LocalizedString("Weapon_Combat_Rifle"))
				}
			};
			_arrFilterSubTitle.Add(item);
			_arrSubTitleGetter.Add((UIItemSlotData uiitemSlotData_0) => _arrFilterSubTitle[0][(int)uiitemSlotData_0.item.method_6().method_1()]);
			item = new Dictionary<int, string>
			{
				{
					5,
					LocalizedString.smethod_0(new LocalizedString("ShieldMOD"))
				},
				{
					8,
					LocalizedString.smethod_0(new LocalizedString("ClassMOD"))
				}
			};
			_arrFilterSubTitle.Add(item);
			_arrSubTitleGetter.Add((UIItemSlotData uiitemSlotData_0) => _arrFilterSubTitle[1][(int)uiitemSlotData_0.item.m_type]);
			item = new Dictionary<int, string>
			{
				{
					0,
					LocalizedString.smethod_0(new LocalizedString("Hair"))
				},
				{
					2,
					LocalizedString.smethod_0(new LocalizedString("Mask"))
				},
				{
					3,
					LocalizedString.smethod_0(new LocalizedString("Coat"))
				},
				{
					4,
					LocalizedString.smethod_0(new LocalizedString("Pants"))
				},
				{
					5,
					LocalizedString.smethod_0(new LocalizedString("Boots"))
				}
			};
			_arrFilterSubTitle.Add(item);
			_arrSubTitleGetter.Add((UIItemSlotData uiitemSlotData_0) => _arrFilterSubTitle[2][(int)uiitemSlotData_0.item.method_9().m_avatarSubpart]);
			item = new Dictionary<int, string>
			{
				{
					3,
					LocalizedString.smethod_0(new LocalizedString("Currency"))
				},
				{
					6,
					LocalizedString.smethod_0(new LocalizedString("Material"))
				}
			};
			_arrFilterSubTitle.Add(item);
			_arrSubTitleGetter.Add((UIItemSlotData uiitemSlotData_0) => _arrFilterSubTitle[3][(int)uiitemSlotData_0.item.m_type]);
		}

		protected override void vmethod_0()
		{
			base.vmethod_0();
			mcRootMovie = base.DisplayObjectContainer_0 as MovieClip;
			mcRootMovie.stopAll();
			mcRoot = mcRootMovie.getChildByName<MovieClip>("mcRoot");
			mcRoot.stopAll();
			if (mcRoot != null)
			{
				specialCurrencyTF = mcRoot.getChildByName<TextField>("specialCurrency");
				circulateCurrencyTF = mcRoot.getChildByName<TextField>("circulateCurrency");
				bondCurrencyTF = mcRoot.getChildByName<TextField>("bondCurrency");
				keysTF = mcRoot.getChildByName<TextField>("keysTF");
				expiringKeysTF = mcRoot.getChildByName<TextField>("expiringKeysTF");
				expiringTimeTF = mcRoot.getChildByName<TextField>("expiringTimeTF");
				tfSummary = mcRoot.getChildByName<UnityTextField>("tfSummary");
				mcAmmoPistol_bg = mcRoot.getChildByName<MovieClip>("mcAmmoPistol_bg");
				mcAmmoSniper_bg = mcRoot.getChildByName<MovieClip>("mcAmmoSniper_bg");
				mcAmmoSMG_bg = mcRoot.getChildByName<MovieClip>("mcAmmoSMG_bg");
				mcAmmoAssaultRifle_bg = mcRoot.getChildByName<MovieClip>("mcAmmoAssaultRifle_bg");
				mcAmmoShotGun_bg = mcRoot.getChildByName<MovieClip>("mcAmmoShotGun_bg");
				mcAmmoGrenade_bg = mcRoot.getChildByName<MovieClip>("mcAmmoGrenade_bg");
				mcNewMarkAll = mcRoot.getChildByName<MovieClip>("mcNewMarkAll");
				mcNewMarkWeapon = mcRoot.getChildByName<MovieClip>("mcNewMarkWeapon");
				mcNewMarkMod = mcRoot.getChildByName<MovieClip>("mcNewMarkMod");
				mcNewMarkOutfit = mcRoot.getChildByName<MovieClip>("mcNewMarkOutfit");
				mcNewMarkOther = mcRoot.getChildByName<MovieClip>("mcNewMarkOther");
			}
		}

		public void method_5(Dictionary<int, Vector2> dictionary_0)
		{
			if (mcRoot == null)
			{
				return;
			}
			Dictionary<int, Vector2>.Enumerator enumerator = dictionary_0.GetEnumerator();
			while (enumerator.MoveNext())
			{
				TextField childByName = mcRoot.getChildByName<TextField>(smethod_0((AmmoType)enumerator.Current.Key, string.Empty));
				if (childByName != null)
				{
					stringbuilder.Length = 0;
					stringbuilder.Append(enumerator.Current.Value.x);
					childByName.text = stringbuilder.ToString();
				}
				childByName = mcRoot.getChildByName<TextField>(smethod_0((AmmoType)enumerator.Current.Key, "_max"));
				if (childByName != null)
				{
					stringbuilder.Length = 0;
					stringbuilder.Append(enumerator.Current.Value.y);
					childByName.text = stringbuilder.ToString();
				}
			}
		}

		private static string smethod_0(AmmoType ammoType_0, string string_1 = "")
		{
			_sbAmmoName.Length = 0;
			switch (ammoType_0)
			{
			case AmmoType.SMG:
				_sbAmmoName.Append("mcAmmoSMG");
				break;
			case AmmoType.SniperRifle:
				_sbAmmoName.Append("mcAmmoSniperRifle");
				break;
			case AmmoType.Grenade:
				_sbAmmoName.Append("mcAmmoGrenade");
				break;
			case AmmoType.ShotGun:
				_sbAmmoName.Append("mcAmmoShotGun");
				break;
			case AmmoType.Pistol:
				_sbAmmoName.Append("mcAmmoPistol");
				break;
			case AmmoType.AssaultRifle:
				_sbAmmoName.Append("mcAmmoAssaultRifle");
				break;
			}
			_sbAmmoName.Append(string_1);
			return _sbAmmoName.ToString();
		}

		public void method_6(AmmoType ammoType_0)
		{
			if (mcAmmoPistol_bg != null)
			{
				mcAmmoPistol_bg.visible = ammoType_0 == AmmoType.Pistol;
			}
			if (mcAmmoSniper_bg != null)
			{
				mcAmmoSniper_bg.visible = ammoType_0 == AmmoType.SniperRifle;
			}
			if (mcAmmoSMG_bg != null)
			{
				mcAmmoSMG_bg.visible = ammoType_0 == AmmoType.SMG;
			}
			if (mcAmmoAssaultRifle_bg != null)
			{
				mcAmmoAssaultRifle_bg.visible = ammoType_0 == AmmoType.AssaultRifle;
			}
			if (mcAmmoShotGun_bg != null)
			{
				mcAmmoShotGun_bg.visible = ammoType_0 == AmmoType.ShotGun;
			}
			if (mcAmmoGrenade_bg != null)
			{
				mcAmmoGrenade_bg.visible = ammoType_0 == AmmoType.Grenade;
			}
		}

		public void method_7(int int_0, int int_1, int int_2)
		{
			if (specialCurrencyTF != null)
			{
				specialCurrencyTF.text = Utility.smethod_8(int_0);
			}
			if (circulateCurrencyTF != null)
			{
				circulateCurrencyTF.text = Utility.smethod_8(int_1);
			}
			if (bondCurrencyTF != null)
			{
				bondCurrencyTF.text = Utility.smethod_8(int_2);
			}
		}

		public void method_8(int int_0, ExpiringCurrency expiringCurrency_0)
		{
			if (keysTF != null)
			{
				keysTF.text = Utility.smethod_8(int_0);
			}
			expiringKey = expiringCurrency_0;
			if (expiringKeysTF != null && expiringKey != null)
			{
				expiringKeysTF.text = Utility.smethod_8(expiringKey.Count);
			}
			method_9();
		}

		public void method_9()
		{
			if (expiringTimeTF != null)
			{
				if (expiringKey != null && expiringKey.Single_0 >= 0f)
				{
					expiringTimeTF.visible = true;
					TimeSpan timeSpan = TimeSpan.FromSeconds(expiringKey.Single_0);
					StringBuilder stringBuilder = new StringBuilder(timeSpan.Hours.ToString("00")).Append("'").Append(timeSpan.Minutes.ToString("00")).Append("'")
						.Append(timeSpan.Seconds.ToString("00"))
						.Append("\"");
					expiringTimeTF.text = stringBuilder.ToString();
				}
				else
				{
					expiringTimeTF.visible = false;
				}
			}
		}

		public void method_10(int int_0, int int_1)
		{
			_iItemSum = int_0;
			if (tfSummary != null)
			{
				tfSummary.text = Utility.smethod_6(Utility.smethod_8(_iItemSum), "/", Utility.smethod_8(int_1));
			}
		}

		public void method_11(int int_0, UIItemSlotData uiitemSlotData_0)
		{
			if (int_0 < _arrItemSlots.Length && int_0 >= 0 && _arrItemSlots[int_0] != null)
			{
				if (uiitemSlotData_0.item != null)
				{
					_arrItemSlots[int_0].Object_0 = uiitemSlotData_0;
					_arrItemSlots[int_0].GInterface1_0 = new ItemTips(uiitemSlotData_0.item);
				}
				else
				{
					_arrItemSlots[int_0].Object_0 = null;
					_arrItemSlots[int_0].GInterface1_0 = null;
				}
			}
		}

		public void method_12(List<bool> list_1)
		{
			if (list_1 != null && list_1.Count >= 4)
			{
				if (mcNewMarkWeapon != null)
				{
					mcNewMarkWeapon.visible = list_1[0];
				}
				if (mcNewMarkMod != null)
				{
					mcNewMarkMod.visible = list_1[1];
				}
				if (mcNewMarkOutfit != null)
				{
					mcNewMarkOutfit.visible = list_1[2];
				}
				if (mcNewMarkOther != null)
				{
					mcNewMarkOther.visible = list_1[3];
				}
				if (mcNewMarkAll != null)
				{
					mcNewMarkAll.visible = list_1[0] || list_1[1] || list_1[2] || list_1[3];
				}
			}
		}

		public void method_13()
		{
			if (_iCurPageType != -1)
			{
				DragManagerLayer.Instance.method_3();
				mcPageAll.visible = true;
				mcPageFilter.visible = false;
				mcPageFilter.removeAllChildren();
				mcPageAll.x = orinPosAll.x;
				mcPageAll.y = orinPosAll.y;
				if (mcScrollView != null)
				{
					mcScrollView.vmethod_8(mcPageAll);
				}
			}
			_iCurPageType = -1;
		}

		public void method_14(int int_0, List<UIItemSlotData> list_1)
		{
			method_17(int_0, list_1);
			if (_iCurPageType != int_0)
			{
				DragManagerLayer.Instance.method_3();
				mcPageAll.visible = false;
				mcPageFilter.visible = true;
				mcPageFilter.x = orinPosFilter.x;
				mcPageFilter.y = orinPosFilter.y;
				if (mcScrollView != null)
				{
					mcScrollView.vmethod_8(mcPageFilter);
				}
			}
			_iCurPageType = int_0;
		}

		public void method_15(Item_SWAP_Delegate item_SWAP_Delegate_0)
		{
			swapFunc = (Item_SWAP_Delegate)Delegate.Combine(swapFunc, item_SWAP_Delegate_0);
		}

		public void method_16(Item_SWAP_Delegate item_SWAP_Delegate_0)
		{
			swapFunc = (Item_SWAP_Delegate)Delegate.Remove(swapFunc, item_SWAP_Delegate_0);
		}

		protected void method_17(int int_0, List<UIItemSlotData> list_1)
		{
			if (int_0 < 0 || int_0 >= _arrSubTitleGetter.Count || list_1 == null)
			{
				return;
			}
			method_18();
			float num = 0f;
			float num2 = -61f;
			int num3 = 0;
			string text = string.Empty;
			List<UIItemSlotData>.Enumerator enumerator = list_1.GetEnumerator();
			while (enumerator.MoveNext())
			{
				string text2 = _arrSubTitleGetter[int_0](enumerator.Current);
				if (text2 != text)
				{
					num3 = 0;
					text = text2;
				}
				if (num3 % 5 == 0)
				{
					num2 += 61f;
					num = 18f;
				}
				if (num3 == 0)
				{
					method_21(num2, text2);
					num2 += 31f;
				}
				method_20(num, num2, enumerator.Current);
				num += 81f;
				num3++;
			}
		}

		protected void method_18()
		{
			_ItemSLCacheIdx = 0;
			_TitleCacheIdx = 0;
			mcPageFilter.removeAllChildren();
		}

		protected void method_19()
		{
			method_18();
			_arrCachedItemSL.Clear();
			_arrCachedTitle.Clear();
		}

		protected GClass44 method_20(float float_0, float float_1, UIItemSlotData uiitemSlotData_0)
		{
			GClass44 gClass;
			MovieClip movieClip_;
			if (_ItemSLCacheIdx >= _arrCachedItemSL.Count)
			{
				_ItemSLCacheIdx = _arrCachedItemSL.Count;
				gClass = new GClass44();
				movieClip_ = new BadAssMovieClip("2014_Inventory_.swf", ITEM_SLOT_MOVIE_NAME);
				gClass.method_0(movieClip_);
				_arrCachedItemSL.Add(gClass);
			}
			else
			{
				gClass = _arrCachedItemSL[_ItemSLCacheIdx];
			}
			_ItemSLCacheIdx++;
			movieClip_ = gClass.DisplayObjectContainer_0 as MovieClip;
			movieClip_.updateFrame(new CEvent(CEvent.ENTER_FRAME, bubbles: false, cancelable: false));
			movieClip_.x = float_0;
			movieClip_.y = float_1;
			gClass.addEventListener(MouseEvent.CLICK, method_27);
			gClass.addEventListener(GClass53.string_5, method_28);
			gClass.addEventListener(GClass53.string_0, method_26);
			gClass.addEventListener(MouseEvent.MOUSE_ENTER, method_26);
			gClass.addEventListener(MouseEvent.MOUSE_LEAVE, method_26);
			gClass.addEventListener("slash", method_25);
			gClass.addEventListener("drop", method_24);
			gClass.method_11((ns0.MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InventoryView>() as uniInventoryView).method_21);
			gClass.object_0 = uiitemSlotData_0.index;
			gClass.Object_0 = uiitemSlotData_0;
			gClass.GInterface1_0 = new ItemTips(uiitemSlotData_0.item);
			mcPageFilter.addChild(movieClip_);
			return gClass;
		}

		protected MovieClip method_21(float float_0, string string_1)
		{
			MovieClip movieClip;
			if (_TitleCacheIdx >= _arrCachedTitle.Count)
			{
				_TitleCacheIdx = _arrCachedTitle.Count;
				movieClip = new BadAssMovieClip("2014_Inventory_.swf", SUBTITLE_MOVIE_NAME);
				_arrCachedTitle.Add(movieClip);
			}
			else
			{
				movieClip = _arrCachedTitle[_TitleCacheIdx];
			}
			_TitleCacheIdx++;
			movieClip.y = float_0;
			TextField childByName = movieClip.getChildByName<TextField>("textField");
			childByName.text = string_1;
			mcPageFilter.addChild(movieClip);
			return movieClip;
		}

		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			if (movieClip.name.Length > ITEM_SLOT_PREFIX_NAME.Length)
			{
				string text = movieClip.name.Substring(0, ITEM_SLOT_PREFIX_NAME.Length);
				if (text == ITEM_SLOT_PREFIX_NAME)
				{
					int num = Convert.ToInt32(movieClip.name.Substring(ITEM_SLOT_PREFIX_NAME.Length, movieClip.name.Length - ITEM_SLOT_PREFIX_NAME.Length));
					if (num < _arrItemSlots.Length && num >= 0)
					{
						GClass44 gClass = new GClass44();
						gClass.method_0(movieClip);
						movieClip.updateFrame(new CEvent(CEvent.ENTER_FRAME, bubbles: false, cancelable: false));
						gClass.addEventListener(MouseEvent.CLICK, method_27);
						gClass.addEventListener(GClass53.string_5, method_28);
						gClass.addEventListener(GClass53.string_0, method_26);
						gClass.addEventListener(MouseEvent.MOUSE_ENTER, method_26);
						gClass.addEventListener(MouseEvent.MOUSE_LEAVE, method_26);
						gClass.addEventListener("slash", method_25);
						gClass.addEventListener("drop", method_24);
						gClass.method_11((ns0.MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InventoryView>() as uniInventoryView).method_21);
						gClass.object_0 = num;
						_arrItemSlots[num] = gClass;
						return true;
					}
					DebugUtils.LogWarning(LogCategory.GUI, "Inventory itemSlot name wrong! Index:" + num + " is bigger than sum: " + _arrItemSlots.Length);
					return true;
				}
			}
			bool result = false;
			switch (movieClip.name)
			{
			case "mcSortBtn":
				mcSortBtn = new GClass25();
				mcSortBtn.method_0(movieClip);
				mcSortBtn.addEventListener(MouseEvent.CLICK, method_30);
				result = true;
				break;
			case "mcXButton":
				mcXButton = new GClass25();
				mcXButton.method_0(movieClip);
				mcXButton.addEventListener(MouseEvent.CLICK, method_31);
				result = true;
				break;
			case "mcKeyAddBtn":
				mcKeyAddBtn = new GClass25();
				mcKeyAddBtn.method_0(movieClip);
				mcKeyAddBtn.addEventListener(MouseEvent.CLICK, method_29);
				result = true;
				break;
			case "mcScrollingBar":
				mcSB = new GClass46();
				mcSB.method_0(movieClip);
				(base.DisplayObjectContainer_0 as MovieClip).addEventListener(GClass56.string_0, mcSB.method_12, useCapture: false);
				if (mcScrollView != null)
				{
					mcScrollView.GClass46_0 = mcSB;
				}
				mcSB.Int32_1 = 0;
				result = true;
				break;
			case "mcTabAll":
				mcTabAll = new GClass40();
				mcTabAll.method_0(movieClip);
				mcTabAll.Boolean_3 = true;
				mcTabAll.bool_5 = false;
				mcTabAll.String_1 = "InventoryTab";
				mcTabAll.Object_0 = -1;
				mcTabAll.addEventListener(MouseEvent.CLICK, method_22);
				movieClip.userData = -1;
				result = true;
				break;
			case "mcTabWeapon":
				mcTabWeapon = new GClass40();
				mcTabWeapon.method_0(movieClip);
				mcTabWeapon.Boolean_3 = true;
				mcTabWeapon.bool_5 = false;
				mcTabWeapon.String_1 = "InventoryTab";
				mcTabWeapon.Object_0 = 0;
				mcTabWeapon.addEventListener(MouseEvent.CLICK, method_22);
				movieClip.userData = 0;
				result = true;
				break;
			case "mcTabMod":
				mcTabMod = new GClass40();
				mcTabMod.method_0(movieClip);
				mcTabMod.Boolean_3 = true;
				mcTabMod.bool_5 = false;
				mcTabMod.String_1 = "InventoryTab";
				mcTabMod.Object_0 = 1;
				mcTabMod.addEventListener(MouseEvent.CLICK, method_22);
				movieClip.userData = 1;
				result = true;
				break;
			case "mcTabOutfit":
				mcTabOutfit = new GClass40();
				mcTabOutfit.method_0(movieClip);
				mcTabOutfit.Boolean_3 = true;
				mcTabOutfit.bool_5 = false;
				mcTabOutfit.String_1 = "InventoryTab";
				mcTabOutfit.Object_0 = 2;
				mcTabOutfit.addEventListener(MouseEvent.CLICK, method_22);
				movieClip.userData = 2;
				result = true;
				break;
			case "mcTabOther":
				mcTabOther = new GClass40();
				mcTabOther.method_0(movieClip);
				mcTabOther.Boolean_3 = true;
				mcTabOther.bool_5 = false;
				mcTabOther.String_1 = "InventoryTab";
				mcTabOther.Object_0 = 3;
				mcTabOther.addEventListener(MouseEvent.CLICK, method_22);
				movieClip.userData = 3;
				result = true;
				break;
			case "mcPageAll":
				mcPageAll = movieClip;
				mcPageAll.visible = true;
				orinPosAll = new Vector2(mcPageAll.x, mcPageAll.y);
				break;
			case "mcPageFilter":
				mcPageFilter = movieClip;
				mcPageFilter.visible = false;
				orinPosFilter = new Vector2(mcPageFilter.x, mcPageFilter.y);
				break;
			case "mcScrollView":
				mcScrollView = new GClass47();
				mcScrollView.method_0(movieClip);
				if (mcSB != null)
				{
					mcScrollView.GClass46_0 = mcSB;
				}
				break;
			case "mcAmmoPistol_bg":
				mcAmmoPistol_bg = movieClip;
				break;
			case "mcAmmoSniper_bg":
				mcAmmoSniper_bg = movieClip;
				break;
			case "mcAmmoSMG_bg":
				mcAmmoSMG_bg = movieClip;
				break;
			case "mcAmmoAssaultRifle_bg":
				mcAmmoAssaultRifle_bg = movieClip;
				break;
			case "mcAmmoShotGun_bg":
				mcAmmoShotGun_bg = movieClip;
				break;
			case "mcAmmoGrenade_bg":
				mcAmmoGrenade_bg = movieClip;
				break;
			}
			return result;
		}

		protected void method_22(CEvent cevent_0)
		{
			if (cevent_0.target is GClass40 { Object_0: not null } gClass)
			{
				dispatchEvent(new GClass55("Filter", gClass.Object_0));
			}
		}

		protected void method_23(CEvent cevent_0)
		{
			dispatchEvent(cevent_0);
		}

		protected void method_24(CEvent cevent_0)
		{
			if (!(cevent_0 is GClass55 gClass))
			{
				return;
			}
			GStruct0 gStruct = (GStruct0)gClass.object_0;
			UIItemSlotData from = (UIItemSlotData)gStruct.object_0;
			UIItemSlotData target;
			if (gStruct.object_1 != null)
			{
				target = (UIItemSlotData)gStruct.object_1;
			}
			else
			{
				if (!(gClass.target is GClass44 gClass2))
				{
					return;
				}
				target = new UIItemSlotData(null, "inventory", (int)gClass2.object_0);
			}
			swapFunc(target, from);
		}

		protected void method_25(CEvent cevent_0)
		{
			(cevent_0.target as GClass44).method_16();
		}

		protected void method_26(CEvent cevent_0)
		{
			GClass44 gClass = cevent_0.target as GClass44;
			dispatchEvent(new GClass55("Item" + cevent_0.type, gClass.Object_0));
		}

		protected void method_27(CEvent cevent_0)
		{
			GClass53 gClass = cevent_0 as GClass53;
			GClass44 gClass2 = gClass.target as GClass44;
			if (Input.GetKey(KeyCode.LeftShift))
			{
				UIItemSlotData uIItemSlotData = (UIItemSlotData)gClass2.Object_0;
				dispatchEvent(new GClass55("showWeaponModel", uIItemSlotData.item.method_6()));
			}
			else if (hasEventListener("Item" + cevent_0.type))
			{
				dispatchEvent(new GClass55("Item" + cevent_0.type, gClass2.Object_0));
			}
			else
			{
				gClass2.method_16();
			}
		}

		protected void method_28(CEvent cevent_0)
		{
			GClass53 gClass = cevent_0 as GClass53;
			GClass44 gClass2 = gClass.target as GClass44;
			dispatchEvent(new GClass55("Item" + cevent_0.type, gClass2.Object_0));
		}

		protected void method_29(CEvent cevent_0)
		{
		}

		protected void method_30(CEvent cevent_0)
		{
			dispatchEvent(new CEvent("TidyClicked"));
		}

		protected void method_31(CEvent cevent_0)
		{
			dispatchEvent(new CEvent("XBtnClicked"));
		}

		protected void method_32()
		{
			mcRootMovie.visible = true;
			mcTabAll.Boolean_3 = true;
			mcRootMovie.removeEventListener("End", method_34);
			mcRootMovie.gotoAndPlay("Open");
		}

		protected void method_33()
		{
			mcRootMovie.gotoAndPlay("Close");
			mcRootMovie.addFrameScript("End", method_34);
		}

		protected void method_34(CEvent cevent_0)
		{
			mcRootMovie.removeEventListener("End", method_34);
			mcRootMovie.visible = false;
			(ns0.MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this);
		}

		protected void method_35(CEvent cevent_0)
		{
		}

		[CompilerGenerated]
		private string method_36(UIItemSlotData uiitemSlotData_0)
		{
			return _arrFilterSubTitle[0][(int)uiitemSlotData_0.item.method_6().method_1()];
		}

		[CompilerGenerated]
		private string method_37(UIItemSlotData uiitemSlotData_0)
		{
			return _arrFilterSubTitle[1][(int)uiitemSlotData_0.item.m_type];
		}

		[CompilerGenerated]
		private string method_38(UIItemSlotData uiitemSlotData_0)
		{
			return _arrFilterSubTitle[2][(int)uiitemSlotData_0.item.method_9().m_avatarSubpart];
		}

		[CompilerGenerated]
		private string method_39(UIItemSlotData uiitemSlotData_0)
		{
			return _arrFilterSubTitle[3][(int)uiitemSlotData_0.item.m_type];
		}
	}
	// Token: 0x02000857 RID: 2135
	// (Invoke) Token: 0x06003A36 RID: 14902
	public delegate void Item_SWAP_Delegate(UIItemSlotData target, UIItemSlotData from);
}
