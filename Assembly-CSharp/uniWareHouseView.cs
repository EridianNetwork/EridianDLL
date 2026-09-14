using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Core;
using ns0;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;
using UnityEngine;

using System.Diagnostics;
// Token: 0x020008B3 RID: 2227
public class uniWareHouseView : WareHouseView
{
	// Token: 0x06003D2F RID: 15663 RVA: 0x00029497 File Offset: 0x00027697
	public override void vmethod_2()
	{
		base.vmethod_2();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("2014_Warehouse.swf", "Panel_Warehouse", new FuncLoad(this.method_11));
	}

	// Token: 0x06003D30 RID: 15664 RVA: 0x00122874 File Offset: 0x00120A74
	private void method_11(MovieClip movieClip_0)
	{
		this.m_mainPanel = new uniWareHouseView.WareHousePanel((this._arrItems == null) ? 60 : this._arrItems.Length);
		this.m_mainPanel.method_0(movieClip_0);
		movieClip_0.visible = this._bVisible;
		this.m_mainPanel.method_9(new uniWareHouseView.Item_SWAP_Delegate(this.method_13));
		this.m_mainPanel.addEventListener("TidyClicked", new EventDispatcher.EventCallback(this.method_18));
		this.m_mainPanel.addEventListener("Filter", new EventDispatcher.EventCallback(this.method_19));
		this.m_mainPanel.addEventListener("XBtnClicked", new EventDispatcher.EventCallback(this.method_15));
		this.m_mainPanel.addEventListener("showWeaponModel", new EventDispatcher.EventCallback(this.method_16));
		this.m_mainPanel.addEventListener("Item" + GClass53.string_5, new EventDispatcher.EventCallback(this.method_17));
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).GClass41_0.addEventListener("drop", new EventDispatcher.EventCallback(this.method_14));
		DisplayObject childByName = movieClip_0.getChildByName("mcInventoryPosition");
		if (childByName != null)
		{
			MonoSingleton<AppManager>.Instance.GetComponent<GameUIManager>().method_3(this, GClass20.GClass20_0.method_3(childByName, Vector2.zero));
		}
		MonoSingleton<AppManager>.Instance.StartCoroutine(this.method_20());
		for (int i = 0; i < 20; i++)
		{
			movieClip_0.updateFrame(new CEvent(CEvent.ENTER_FRAME, false, false));
		}
		try
		{
			this.vmethod_6();
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06003D31 RID: 15665 RVA: 0x00122A14 File Offset: 0x00120C14
	public override void vmethod_3()
	{
		base.vmethod_3();
		if (this.m_mainPanel != null)
		{
			this.m_mainPanel.method_10(new uniWareHouseView.Item_SWAP_Delegate(this.method_13));
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this.m_mainPanel);
		}
		this.m_mainPanel = null;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("Warehouse.swf");
	}

	// Token: 0x06003D32 RID: 15666 RVA: 0x00122A80 File Offset: 0x00120C80
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		if (this.m_mainPanel != null && !this.m_mainPanel.Boolean_1)
		{
			base.vmethod_1(bool_0, bool_1);
			if (this._bVisible)
			{
				(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_31(this.m_mainPanel);
				this._curFilterPage = -1;
				this.vmethod_6();
			}
			this.m_mainPanel.Boolean_0 = this._bVisible;
			return;
		}
	}

	// Token: 0x06003D33 RID: 15667 RVA: 0x00122AEC File Offset: 0x00120CEC
	protected override void vmethod_6()
	{
		if (this.m_mainPanel != null && this._arrItems != null)
		{
			this._arrItems.Length.ToString();
			int num = 0;
			for (int i = 0; i < this._arrItems.Length; i++)
			{
				if (this._arrItems[i] != null)
				{
					num++;
				}
				UIItemSlotData uiitemSlotData = new UIItemSlotData(this._arrItems[i], "warehouse", i, false);
				this.m_mainPanel.method_5(i, uiitemSlotData);
			}
			this.m_mainPanel.method_8(num, 60);
			this.method_12();
			return;
		}
	}

	// Token: 0x06003D34 RID: 15668 RVA: 0x00122B74 File Offset: 0x00120D74
	protected void method_12()
	{
		if (this._curFilterPage >= 0 && this._curFilterPage < this._arrFilterList.Count)
		{
			base.method_7();
			this.m_mainPanel.method_7(this._curFilterPage, base.method_8(this._curFilterPage));
			return;
		}
		this.m_mainPanel.method_6();
	}

	// Token: 0x06003D35 RID: 15669 RVA: 0x00122BCC File Offset: 0x00120DCC
	protected void method_13(UIItemSlotData uiitemSlotData_0, UIItemSlotData uiitemSlotData_1)
	{
		if (uiitemSlotData_1.identifier == "inventory")
		{
			base.method_6(uiitemSlotData_1.index, uiitemSlotData_0.index);
			return;
		}
		if (uiitemSlotData_1.identifier == "warehouse")
		{
			base.method_5(uiitemSlotData_1.index, uiitemSlotData_0.index);
		}
	}

	// Token: 0x06003D36 RID: 15670 RVA: 0x00122C24 File Offset: 0x00120E24
	protected void method_14(CEvent cevent_0)
	{
		if (cevent_0 is GClass55 gClass)
		{
			_ = ((UIItemSlotData)gClass.object_0).identifier == "warehouse";
		}
	}
	// Token: 0x06003D37 RID: 15671 RVA: 0x000294C9 File Offset: 0x000276C9
	protected void method_15(CEvent cevent_0)
	{
		MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InventoryView>().Boolean_1 = false;
	}

	// Token: 0x06003D38 RID: 15672 RVA: 0x00122C58 File Offset: 0x00120E58
	protected void method_16(CEvent cevent_0)
	{
		GClass55 gclass = cevent_0 as GClass55;
		if (gclass != null)
		{
			WeaponDNA weaponDNA = (WeaponDNA)gclass.object_0;
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<WeaponPreviewView>().vmethod_6(weaponDNA, true);
		}
	}

	// Token: 0x06003D39 RID: 15673 RVA: 0x00122C94 File Offset: 0x00120E94
	protected void method_17(CEvent cevent_0)
	{
		UIItemSlotData uiitemSlotData = (UIItemSlotData)(cevent_0 as GClass55).object_0;
		base.method_9(uiitemSlotData);
	}

	// Token: 0x06003D3A RID: 15674 RVA: 0x000294E0 File Offset: 0x000276E0
	protected void method_18(CEvent cevent_0)
	{
		base.method_3();
	}

	// Token: 0x06003D3B RID: 15675 RVA: 0x000294E8 File Offset: 0x000276E8
	protected void method_19(CEvent cevent_0)
	{
		this._curFilterPage = (int)(cevent_0 as GClass55).object_0;
		this.method_12();
	}

	// Token: 0x06003D3C RID: 15676 RVA: 0x00029506 File Offset: 0x00027706
	private IEnumerator method_20()
	{
		for (int i = 0; i < 15; i++)
		{
			yield return new WaitForSeconds(0.2f);
			try
			{
				vmethod_6();
			}
			catch (Exception)
			{
			}
		}
	}
	// Token: 0x04002B18 RID: 11032
	protected uniWareHouseView.WareHousePanel m_mainPanel;

	// Token: 0x04002B19 RID: 11033
	protected int _curFilterPage = -1;

	// Token: 0x020008B4 RID: 2228
	public class WareHousePanel : GClass51
	{
		// Token: 0x06003D3D RID: 15677 RVA: 0x00122CBC File Offset: 0x00120EBC
		public WareHousePanel(int int_0)
		{
			this.SLOT_NUM = int_0;
			this._arrItemSlots = new GClass44[this.SLOT_NUM];
			this._arrFilterSubTitle = new List<Dictionary<int, string>>(4);
			this._arrSubTitleGetter = new List<Func<UIItemSlotData, string>>(4);
			Dictionary<int, string> dictionary = new Dictionary<int, string>();
			dictionary.Add(0, LocalizedString.smethod_0(new LocalizedString("Weapon_SMG")));
			dictionary.Add(1, LocalizedString.smethod_0(new LocalizedString("Weapon_Sniper")));
			dictionary.Add(2, LocalizedString.smethod_0(new LocalizedString("Weapon_Shotgun")));
			dictionary.Add(3, LocalizedString.smethod_0(new LocalizedString("Weapon_Pistol")));
			dictionary.Add(4, LocalizedString.smethod_0(new LocalizedString("Weapon_Combat_Rifle")));
			this._arrFilterSubTitle.Add(dictionary);
			this._arrSubTitleGetter.Add(new Func<UIItemSlotData, string>(this.method_27));
			dictionary = new Dictionary<int, string>();
			dictionary.Add(5, LocalizedString.smethod_0(new LocalizedString("ShieldMOD")));
			dictionary.Add(8, LocalizedString.smethod_0(new LocalizedString("ClassMOD")));
			this._arrFilterSubTitle.Add(dictionary);
			this._arrSubTitleGetter.Add(new Func<UIItemSlotData, string>(this.method_28));
			dictionary = new Dictionary<int, string>();
			dictionary.Add(0, LocalizedString.smethod_0(new LocalizedString("Hair")));
			dictionary.Add(2, LocalizedString.smethod_0(new LocalizedString("Mask")));
			dictionary.Add(3, LocalizedString.smethod_0(new LocalizedString("Coat")));
			dictionary.Add(4, LocalizedString.smethod_0(new LocalizedString("Pants")));
			dictionary.Add(5, LocalizedString.smethod_0(new LocalizedString("Boots")));
			this._arrFilterSubTitle.Add(dictionary);
			this._arrSubTitleGetter.Add(new Func<UIItemSlotData, string>(this.method_29));
			dictionary = new Dictionary<int, string>();
			dictionary.Add(3, LocalizedString.smethod_0(new LocalizedString("Currency")));
			dictionary.Add(6, LocalizedString.smethod_0(new LocalizedString("Material")));
			dictionary.Add(11, LocalizedString.smethod_0(new LocalizedString("Outfit")));
			this._arrFilterSubTitle.Add(dictionary);
			this._arrSubTitleGetter.Add(new Func<UIItemSlotData, string>(this.method_30));
		}

		// Token: 0x1700033C RID: 828
		// (get) Token: 0x06003D3E RID: 15678 RVA: 0x00029515 File Offset: 0x00027715
		// (set) Token: 0x06003D3F RID: 15679 RVA: 0x00029522 File Offset: 0x00027722
		public bool Boolean_0
		{
			get
			{
				return this.mcRoot.visible;
			}
			set
			{
				if (value)
				{
					this.method_19();
					return;
				}
				this.method_20();
			}
		}

		// Token: 0x1700033D RID: 829
		// (get) Token: 0x06003D40 RID: 15680 RVA: 0x00029534 File Offset: 0x00027734
		public bool Boolean_1
		{
			get
			{
				return this.mcRoot.isPlaying;
			}
		}

		// Token: 0x1700033E RID: 830
		// (get) Token: 0x06003D41 RID: 15681 RVA: 0x00029541 File Offset: 0x00027741
		// (set) Token: 0x06003D42 RID: 15682 RVA: 0x00029558 File Offset: 0x00027758
		public int Int32_0
		{
			get
			{
				if (this.mcSB != null)
				{
					return this.mcSB.Int32_1;
				}
				return 0;
			}
			set
			{
				if (this.mcSB != null)
				{
					this.mcSB.Int32_1 = value;
				}
			}
		}

		// Token: 0x06003D43 RID: 15683 RVA: 0x00122F30 File Offset: 0x00121130
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.mcRoot = base.DisplayObjectContainer_0 as MovieClip;
			this.mcRoot.stopAll();
			this.tfCountNumber = this.mcRoot.getChildByName("mcRoot").getChildByName<TextField>("tfCountNumber");
		}

		// Token: 0x06003D44 RID: 15684 RVA: 0x00122F80 File Offset: 0x00121180
		public void method_5(int int_0, UIItemSlotData uiitemSlotData_0)
		{
			if (int_0 == 0 && this._arrItemSlots.Length != 0)
			{
				GClass44 gclass = this._arrItemSlots[0];
			}
			if (int_0 >= this._arrItemSlots.Length || int_0 < 0 || this._arrItemSlots[int_0] == null)
			{
				return;
			}
			this._arrItemSlots[int_0].Boolean_4 = false;
			if (uiitemSlotData_0.item != null)
			{
				this._arrItemSlots[int_0].Object_0 = uiitemSlotData_0;
				this._arrItemSlots[int_0].GInterface1_0 = new ItemTips(uiitemSlotData_0.item);
				return;
			}
			this._arrItemSlots[int_0].Object_0 = null;
			this._arrItemSlots[int_0].GInterface1_0 = null;
		}

		// Token: 0x06003D45 RID: 15685 RVA: 0x00123018 File Offset: 0x00121218
		public void method_6()
		{
			DragManagerLayer.Instance.method_3();
			if (this.mcPageAll == null || this.mcPageFilter == null)
			{
				return;
			}
			this.mcPageAll.visible = true;
			this.mcPageFilter.visible = false;
			this.mcPageFilter.removeAllChildren();
			this.mcPageAll.x = this.orinPosAll.x;
			this.mcPageAll.y = this.orinPosAll.y;
			if (this.mcScrollView != null)
			{
				this.mcScrollView.vmethod_8(this.mcPageAll);
			}
		}

		// Token: 0x06003D46 RID: 15686 RVA: 0x001230A8 File Offset: 0x001212A8
		public void method_7(int int_0, List<UIItemSlotData> list_1)
		{
			DragManagerLayer.Instance.method_3();
			if (this.mcPageAll == null || this.mcPageFilter == null)
			{
				return;
			}
			this.mcPageAll.visible = false;
			this.mcPageFilter.visible = true;
			this.mcPageFilter.x = this.orinPosFilter.x;
			this.mcPageFilter.y = this.orinPosFilter.y;
			this.method_26(int_0, list_1);
			if (this.mcScrollView != null)
			{
				this.mcScrollView.vmethod_8(this.mcPageFilter);
			}
		}

		// Token: 0x06003D47 RID: 15687 RVA: 0x0002956E File Offset: 0x0002776E
		public void method_8(int int_0, int int_1)
		{
			if (this.tfCountNumber != null)
			{
				this.tfCountNumber.text = Utility.smethod_6(Utility.smethod_8(int_0), "/", Utility.smethod_8(int_1));
			}
		}

		// Token: 0x06003D48 RID: 15688 RVA: 0x00029599 File Offset: 0x00027799
		public void method_9(uniWareHouseView.Item_SWAP_Delegate item_SWAP_Delegate_0)
		{
			this.swapFunc = (uniWareHouseView.Item_SWAP_Delegate)Delegate.Combine(this.swapFunc, item_SWAP_Delegate_0);
		}

		// Token: 0x06003D49 RID: 15689 RVA: 0x000295B2 File Offset: 0x000277B2
		public void method_10(uniWareHouseView.Item_SWAP_Delegate item_SWAP_Delegate_0)
		{
			this.swapFunc = (uniWareHouseView.Item_SWAP_Delegate)Delegate.Remove(this.swapFunc, item_SWAP_Delegate_0);
		}

		// Token: 0x06003D4A RID: 15690 RVA: 0x00123138 File Offset: 0x00121338
		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			DebugUtils.Log(LogCategory.GUI, "[DIAG] WareHousePanel.OnWidgetInitialized name=" + movieClip.name);
			string text = ((movieClip != null) ? movieClip.name : "<null movieClip>");
			bool flag;
			try
			{
				DebugUtils.Log(LogCategory.GUI, "[DIAG] ITEM_SLOT_PREFIX_NAME=" + ((this.ITEM_SLOT_PREFIX_NAME == null) ? "NULL" : ("\"" + this.ITEM_SLOT_PREFIX_NAME + "\"")));
				if (movieClip.name.Length > this.ITEM_SLOT_PREFIX_NAME.Length && movieClip.name.Substring(0, this.ITEM_SLOT_PREFIX_NAME.Length) == this.ITEM_SLOT_PREFIX_NAME)
				{
					int num = Convert.ToInt32(movieClip.name.Substring(this.ITEM_SLOT_PREFIX_NAME.Length, movieClip.name.Length - this.ITEM_SLOT_PREFIX_NAME.Length));
					if (num < this._arrItemSlots.Length && num >= 0)
					{
						try
						{
							GClass44 gclass = new GClass44();
							gclass.method_0(movieClip);
							movieClip.updateFrame(new CEvent(CEvent.ENTER_FRAME, false, false));
							gclass.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_16));
							gclass.addEventListener(GClass53.string_5, new EventDispatcher.EventCallback(this.method_17));
							gclass.addEventListener(GClass53.string_0, new EventDispatcher.EventCallback(this.method_15));
							gclass.addEventListener(MouseEvent.MOUSE_ENTER, new EventDispatcher.EventCallback(this.method_15));
							gclass.addEventListener(MouseEvent.MOUSE_LEAVE, new EventDispatcher.EventCallback(this.method_15));
							gclass.addEventListener("slash", new EventDispatcher.EventCallback(this.method_14));
							gclass.addEventListener("drop", new EventDispatcher.EventCallback(this.method_13));
							try
							{
								gclass.method_11(new GClass44.GDelegate2((MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InventoryView>() as uniInventoryView).method_21));
							}
							catch (Exception ex)
							{
								DebugUtils.LogError(LogCategory.GUI, "[DIAG] WareHousePanel slot delegate wiring FAILED: " + ex.ToString());
							}
							gclass.object_0 = num;
							this._arrItemSlots[num] = gclass;
							if (num == 0)
							{
								DebugUtils.Log(LogCategory.GUI, "[DIAG] OnWidgetInitialized ASSIGNED slot0 gclass");
							}
						}
						catch (Exception ex2)
						{
							DebugUtils.LogError(LogCategory.GUI, "[DIAG] WareHousePanel ItemSlot" + num.ToString() + " setup CRASHED: " + ex2.ToString());
						}
						return true;
					}
					DebugUtils.LogWarning(LogCategory.GUI, string.Concat(new object[]
					{
						"Inventory itemSlot name wrong! Index:",
						num,
						" is bigger than sum: ",
						this._arrItemSlots.Length
					}));
					flag = true;
				}
				else
				{
					bool flag2 = false;
					string name = movieClip.name;
					if (name != null)
					{
						switch (name.Length)
						{
						case 8:
						{
							char c = name[5];
							if (c != 'A')
							{
								if (c == 'M' && name == "mcTabMod")
								{
									this.mcTabMod = new GClass40();
									this.mcTabMod.method_0(movieClip);
									this.mcTabMod.Boolean_3 = true;
									this.mcTabMod.bool_5 = false;
									this.mcTabMod.String_1 = "WarehouseTab";
									this.mcTabMod.Object_0 = 1;
									this.mcTabMod.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_11));
									flag2 = true;
								}
							}
							else if (name == "mcTabAll")
							{
								this.mcTabAll = new GClass40();
								this.mcTabAll.method_0(movieClip);
								this.mcTabAll.Boolean_3 = true;
								this.mcTabAll.bool_5 = false;
								this.mcTabAll.String_1 = "WarehouseTab";
								this.mcTabAll.Object_0 = -1;
								this.mcTabAll.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_11));
								flag2 = true;
							}
							break;
						}
						case 9:
						{
							char c2 = name[2];
							if (c2 != 'P')
							{
								if (c2 == 'X' && name == "mcXButton")
								{
									this.mcXButton = new GClass25();
									this.mcXButton.method_0(movieClip);
									this.mcXButton.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_18));
									flag2 = true;
								}
							}
							else if (name == "mcPageAll")
							{
								this.mcPageAll = movieClip;
								this.mcPageAll.visible = true;
								this.orinPosAll = new Vector2(this.mcPageAll.x, this.mcPageAll.y);
							}
							break;
						}
						case 10:
							if (name == "mcTabOther")
							{
								this.mcTabOther = new GClass40();
								this.mcTabOther.method_0(movieClip);
								this.mcTabOther.Boolean_3 = true;
								this.mcTabOther.bool_5 = false;
								this.mcTabOther.String_1 = "WarehouseTab";
								this.mcTabOther.Object_0 = 3;
								this.mcTabOther.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_11));
								flag2 = true;
							}
							break;
						case 11:
						{
							char c3 = name[5];
							if (c3 != 'O')
							{
								if (c3 != 'W')
								{
									if (c3 == 'o' && name == "mcUnlockBtn")
									{
										this.mcUnlockBtn = new GClass25();
										this.mcUnlockBtn.method_0(movieClip);
										this.mcUnlockBtn.Boolean_6 = false;
										flag2 = true;
									}
								}
								else if (name == "mcTabWeapon")
								{
									this.mcTabWeapon = new GClass40();
									this.mcTabWeapon.method_0(movieClip);
									this.mcTabWeapon.Boolean_3 = true;
									this.mcTabWeapon.bool_5 = false;
									this.mcTabWeapon.String_1 = "WarehouseTab";
									this.mcTabWeapon.Object_0 = 0;
									this.mcTabWeapon.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_11));
									flag2 = true;
								}
							}
							else if (name == "mcTabOutfit")
							{
								this.mcTabOutfit = new GClass40();
								this.mcTabOutfit.method_0(movieClip);
								this.mcTabOutfit.Boolean_3 = true;
								this.mcTabOutfit.bool_5 = false;
								this.mcTabOutfit.String_1 = "WarehouseTab";
								this.mcTabOutfit.Object_0 = 2;
								this.mcTabOutfit.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_11));
								flag2 = true;
							}
							break;
						}
						case 12:
						{
							char c4 = name[2];
							if (c4 != 'P')
							{
								if (c4 == 'S' && name == "mcScrollView")
								{
									this.mcScrollView = new GClass47();
									this.mcScrollView.method_0(movieClip);
									if (this.mcSB != null)
									{
										this.mcScrollView.GClass46_0 = this.mcSB;
									}
								}
							}
							else if (name == "mcPageFilter")
							{
								this.mcPageFilter = movieClip;
								this.mcPageFilter.visible = false;
								this.orinPosFilter = new Vector2(this.mcPageFilter.x, this.mcPageFilter.y);
							}
							break;
						}
						case 14:
							if (name == "mcScrollingBar")
							{
								this.mcSB = new GClass46();
								this.mcSB.method_0(movieClip);
								this.mcSB.Int32_1 = 0;
								if (base.DisplayObjectContainer_0 is MovieClip)
								{
									(base.DisplayObjectContainer_0 as MovieClip).addEventListener(GClass56.string_0, new EventDispatcher.EventCallback(this.mcSB.method_12), false);
								}
								else
								{
									DebugUtils.LogWarning(LogCategory.GUI, "[DIAG] WareHousePanel mcScrollingBar: DisplayObjectContainer_0 is not a MovieClip!");
								}
								if (this.mcScrollView != null)
								{
									this.mcScrollView.GClass46_0 = this.mcSB;
								}
								flag2 = true;
							}
							break;
						}
					}
					flag = flag2;
				}
			}
			catch (Exception ex3)
			{
				DebugUtils.LogError(LogCategory.GUI, "[DIAG] WareHousePanel.OnWidgetInitialized CRASHED on widget=\"" + text + "\": " + ex3.ToString());
				flag = false;
			}
			return flag;
		}

		// Token: 0x06003D4B RID: 15691 RVA: 0x00110CE0 File Offset: 0x0010EEE0
		protected void method_11(CEvent cevent_0)
		{
			GClass40 gclass = cevent_0.target as GClass40;
			if (gclass != null && gclass.Object_0 != null)
			{
				base.dispatchEvent(new GClass55("Filter", gclass.Object_0, true, false));
			}
		}

		// Token: 0x06003D4C RID: 15692 RVA: 0x000216B0 File Offset: 0x0001F8B0
		protected void method_12(CEvent cevent_0)
		{
			base.dispatchEvent(cevent_0);
		}

		// Token: 0x06003D4D RID: 15693 RVA: 0x001239AC File Offset: 0x00121BAC
		protected void method_13(CEvent cevent_0)
		{
			GClass55 gclass = cevent_0 as GClass55;
			if (gclass != null)
			{
				GStruct0 gstruct = (GStruct0)gclass.object_0;
				UIItemSlotData uiitemSlotData = (UIItemSlotData)gstruct.object_0;
				UIItemSlotData uiitemSlotData2;
				if (gstruct.object_1 != null)
				{
					uiitemSlotData2 = (UIItemSlotData)gstruct.object_1;
				}
				else
				{
					GClass44 gclass2 = gclass.target as GClass44;
					if (gclass2 == null)
					{
						return;
					}
					uiitemSlotData2 = new UIItemSlotData(null, "warehouse", (int)gclass2.object_0, false);
				}
				this.swapFunc(uiitemSlotData2, uiitemSlotData);
			}
		}

		// Token: 0x06003D4E RID: 15694 RVA: 0x00026DD3 File Offset: 0x00024FD3
		protected void method_14(CEvent cevent_0)
		{
			(cevent_0.target as GClass44).method_16();
		}

		// Token: 0x06003D4F RID: 15695 RVA: 0x00110DA0 File Offset: 0x0010EFA0
		protected void method_15(CEvent cevent_0)
		{
			GClass44 gclass = cevent_0.target as GClass44;
			base.dispatchEvent(new GClass55("Item" + cevent_0.type, gclass.Object_0, true, false));
		}

		// Token: 0x06003D50 RID: 15696 RVA: 0x00123A2C File Offset: 0x00121C2C
		protected void method_16(CEvent cevent_0)
		{
			GClass44 gclass = (cevent_0 as GClass53).target as GClass44;
			if (Input.GetKey(KeyCode.LeftShift))
			{
				UIItemSlotData uiitemSlotData = (UIItemSlotData)gclass.Object_0;
				base.dispatchEvent(new GClass55("showWeaponModel", uiitemSlotData.item.method_6(), true, false));
				return;
			}
			if (base.hasEventListener("Item" + cevent_0.type))
			{
				base.dispatchEvent(new GClass55("Item" + cevent_0.type, gclass.Object_0, true, false));
				return;
			}
			gclass.method_16();
		}

		// Token: 0x06003D51 RID: 15697 RVA: 0x00123AC4 File Offset: 0x00121CC4
		protected void method_17(CEvent cevent_0)
		{
			GClass44 gclass = (cevent_0 as GClass53).target as GClass44;
			base.dispatchEvent(new GClass55("Item" + cevent_0.type, gclass.Object_0, true, false));
		}

		// Token: 0x06003D52 RID: 15698 RVA: 0x00026DF8 File Offset: 0x00024FF8
		protected void method_18(CEvent cevent_0)
		{
			base.dispatchEvent(new CEvent("XBtnClicked"));
		}

		// Token: 0x06003D53 RID: 15699 RVA: 0x000295CB File Offset: 0x000277CB
		protected void method_19()
		{
			this.mcRoot.visible = true;
			this.mcRoot.gotoAndPlay("Open");
		}

		// Token: 0x06003D54 RID: 15700 RVA: 0x000295E9 File Offset: 0x000277E9
		protected void method_20()
		{
			this.mcRoot.gotoAndPlay("Close");
			this.mcRoot.addFrameScript("End", new EventDispatcher.EventCallback(this.method_21));
		}

		// Token: 0x06003D55 RID: 15701 RVA: 0x00029618 File Offset: 0x00027818
		protected void method_21(CEvent cevent_0)
		{
			this.mcRoot.removeEventListener("End", new EventDispatcher.EventCallback(this.method_21));
			this.mcRoot.visible = false;
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this);
		}

		// Token: 0x06003D56 RID: 15702 RVA: 0x00029658 File Offset: 0x00027858
		protected void method_22()
		{
			this._ItemSLCacheIdx = 0;
			this._TitleCacheIdx = 0;
			this.mcPageFilter.removeAllChildren();
		}

		// Token: 0x06003D57 RID: 15703 RVA: 0x00029673 File Offset: 0x00027873
		protected void method_23()
		{
			this.method_22();
			this._arrCachedItemSL.Clear();
			this._arrCachedTitle.Clear();
		}

		// Token: 0x06003D58 RID: 15704 RVA: 0x00123B08 File Offset: 0x00121D08
		protected GClass44 method_24(float float_0, float float_1, UIItemSlotData uiitemSlotData_0)
		{
			GClass44 gclass;
			MovieClip movieClip;
			if (this._ItemSLCacheIdx >= this._arrCachedItemSL.Count)
			{
				this._ItemSLCacheIdx = this._arrCachedItemSL.Count;
				gclass = new GClass44();
				movieClip = new BadAssMovieClip("2014_Warehouse.swf", this.ITEM_SLOT_MOVIE_NAME);
				gclass.method_0(movieClip);
				this._arrCachedItemSL.Add(gclass);
			}
			else
			{
				gclass = this._arrCachedItemSL[this._ItemSLCacheIdx];
				movieClip = gclass.DisplayObjectContainer_0 as MovieClip;
			}
			this._ItemSLCacheIdx++;
			movieClip.updateFrame(new CEvent(CEvent.ENTER_FRAME, false, false));
			movieClip.x = float_0;
			movieClip.y = float_1;
			gclass.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_16));
			gclass.addEventListener(GClass53.string_5, new EventDispatcher.EventCallback(this.method_17));
			gclass.addEventListener(GClass53.string_0, new EventDispatcher.EventCallback(this.method_15));
			gclass.addEventListener(MouseEvent.MOUSE_ENTER, new EventDispatcher.EventCallback(this.method_15));
			gclass.addEventListener(MouseEvent.MOUSE_LEAVE, new EventDispatcher.EventCallback(this.method_15));
			gclass.addEventListener("slash", new EventDispatcher.EventCallback(this.method_14));
			gclass.addEventListener("drop", new EventDispatcher.EventCallback(this.method_13));
			gclass.method_11(new GClass44.GDelegate2((MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InventoryView>() as uniInventoryView).method_21));
			gclass.object_0 = uiitemSlotData_0.index;
			gclass.Object_0 = uiitemSlotData_0;
			gclass.GInterface1_0 = new ItemTips(uiitemSlotData_0.item);
			this.mcPageFilter.addChild(movieClip);
			return gclass;
		}

		// Token: 0x06003D59 RID: 15705 RVA: 0x00123CB8 File Offset: 0x00121EB8
		protected MovieClip method_25(float float_0, string string_1)
		{
			MovieClip movieClip;
			if (this._TitleCacheIdx >= this._arrCachedTitle.Count)
			{
				this._TitleCacheIdx = this._arrCachedTitle.Count;
				movieClip = new BadAssMovieClip("2014_Inventory_.swf", this.SUBTITLE_MOVIE_NAME);
				this._arrCachedTitle.Add(movieClip);
			}
			else
			{
				movieClip = this._arrCachedTitle[this._TitleCacheIdx];
			}
			this._TitleCacheIdx++;
			movieClip.y = float_0;
			movieClip.getChildByName<TextField>("textField").text = string_1;
			this.mcPageFilter.addChild(movieClip);
			return movieClip;
		}

		// Token: 0x06003D5A RID: 15706 RVA: 0x00123D50 File Offset: 0x00121F50
		protected void method_26(int int_0, List<UIItemSlotData> list_1)
		{
			if (int_0 >= 0 && int_0 < this._arrSubTitleGetter.Count)
			{
				if (list_1 != null)
				{
					this.method_22();
					float num = 0f;
					float num2 = -61f;
					int num3 = 0;
					string text = string.Empty;
					foreach (UIItemSlotData uiitemSlotData in list_1)
					{
						string text2 = this._arrSubTitleGetter[int_0](uiitemSlotData);
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
							this.method_25(num2, text2);
							num2 += 31f;
						}
						this.method_24(num, num2, uiitemSlotData);
						num += 81f;
						num3++;
					}
				}
				return;
			}
		}

		// Token: 0x06003D5B RID: 15707 RVA: 0x00029691 File Offset: 0x00027891
		[CompilerGenerated]
		private string method_27(UIItemSlotData uiitemSlotData_0)
		{
			return this._arrFilterSubTitle[0][(int)uiitemSlotData_0.item.method_6().method_1()];
		}

		// Token: 0x06003D5C RID: 15708 RVA: 0x000296B4 File Offset: 0x000278B4
		[CompilerGenerated]
		private string method_28(UIItemSlotData uiitemSlotData_0)
		{
			return this._arrFilterSubTitle[1][(int)uiitemSlotData_0.item.m_type];
		}

		// Token: 0x06003D5D RID: 15709 RVA: 0x000296D2 File Offset: 0x000278D2
		[CompilerGenerated]
		private string method_29(UIItemSlotData uiitemSlotData_0)
		{
			return this._arrFilterSubTitle[2][(int)uiitemSlotData_0.item.method_9().m_avatarSubpart];
		}

		// Token: 0x06003D5E RID: 15710 RVA: 0x000296F5 File Offset: 0x000278F5
		[CompilerGenerated]
		private string method_30(UIItemSlotData uiitemSlotData_0)
		{
			return this._arrFilterSubTitle[3][(int)uiitemSlotData_0.item.m_type];
		}

		// Token: 0x04002B1A RID: 11034
		protected const int TITLE_HEIGHT = 31;

		// Token: 0x04002B1B RID: 11035
		protected const int SLOT_HEIGHT = 61;

		// Token: 0x04002B1C RID: 11036
		protected const int SLOT_HOR_SPACE = 81;

		// Token: 0x04002B1D RID: 11037
		protected const int SLOT_START_X = 18;

		// Token: 0x04002B1E RID: 11038
		protected const int LINE_SUM = 5;

		// Token: 0x04002B1F RID: 11039
		protected uniWareHouseView.Item_SWAP_Delegate swapFunc;

		// Token: 0x04002B20 RID: 11040
		protected GClass44[] _arrItemSlots;

		// Token: 0x04002B21 RID: 11041
		protected MovieClip mcRoot;

		// Token: 0x04002B22 RID: 11042
		protected TextField tfCountNumber;

		// Token: 0x04002B23 RID: 11043
		public int SLOT_NUM = 60;

		// Token: 0x04002B24 RID: 11044
		private string ITEM_SLOT_PREFIX_NAME = "mcItemSlot";

		// Token: 0x04002B25 RID: 11045
		protected GClass25 mcXButton;

		// Token: 0x04002B26 RID: 11046
		protected GClass25 mcUnlockBtn;

		// Token: 0x04002B27 RID: 11047
		protected GClass40 mcTabAll;

		// Token: 0x04002B28 RID: 11048
		protected GClass40 mcTabWeapon;

		// Token: 0x04002B29 RID: 11049
		protected GClass40 mcTabMod;

		// Token: 0x04002B2A RID: 11050
		protected GClass40 mcTabOutfit;

		// Token: 0x04002B2B RID: 11051
		protected GClass40 mcTabOther;

		// Token: 0x04002B2C RID: 11052
		protected MovieClip mcPageAll;

		// Token: 0x04002B2D RID: 11053
		protected MovieClip mcPageFilter;

		// Token: 0x04002B2E RID: 11054
		protected Vector2 orinPosAll;

		// Token: 0x04002B2F RID: 11055
		protected Vector2 orinPosFilter;

		// Token: 0x04002B30 RID: 11056
		protected GClass46 mcSB;

		// Token: 0x04002B31 RID: 11057
		protected GClass47 mcScrollView;

		// Token: 0x04002B32 RID: 11058
		protected List<Dictionary<int, string>> _arrFilterSubTitle;

		// Token: 0x04002B33 RID: 11059
		protected List<Func<UIItemSlotData, string>> _arrSubTitleGetter;

		// Token: 0x04002B34 RID: 11060
		protected List<GClass44> _arrCachedItemSL = new List<GClass44>();

		// Token: 0x04002B35 RID: 11061
		protected int _ItemSLCacheIdx;

		// Token: 0x04002B36 RID: 11062
		protected List<MovieClip> _arrCachedTitle = new List<MovieClip>();

		// Token: 0x04002B37 RID: 11063
		protected int _TitleCacheIdx;

		// Token: 0x04002B38 RID: 11064
		private string SUBTITLE_MOVIE_NAME = "Movie_SubTitle";

		// Token: 0x04002B39 RID: 11065
		private string ITEM_SLOT_MOVIE_NAME = "ItemSlot_goodsSlot";
	}

	// Token: 0x020008B5 RID: 2229
	// (Invoke) Token: 0x06003D60 RID: 15712
	public delegate void Item_SWAP_Delegate(UIItemSlotData target, UIItemSlotData from);
}
