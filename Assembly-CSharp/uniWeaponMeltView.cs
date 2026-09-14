using System;
using System.Collections.Generic;
using ns0;
using pumpkin.display;
using pumpkin.events;
using UnityEngine;
using XsdSettings;

// Token: 0x020008BD RID: 2237
public class uniWeaponMeltView : WeaponMeltView
{
	// Token: 0x06003DA4 RID: 15780 RVA: 0x00125D70 File Offset: 0x00123F70
	public override void vmethod_2()
	{
		base.vmethod_2();
		MonoSingleton<AppManager>.Instance.method_0().method_3(this, new Vector2(753f, 23f));
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("WeaponMelting-2014.swf", "Whole", new FuncLoad(this.method_8));
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("WeaponMelting-2014.swf", "Movie_MeltingCost", new FuncLoad(this.method_7));
		this._inventoryPanel = (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InventoryView>() as uniInventoryView).InventoryPanel_0;
		MonoSingleton<AppManager>.Instance.method_0().method_0(new GameUIManager.ViewUpdateCB(this.method_6), false);
	}

	// Token: 0x06003DA5 RID: 15781 RVA: 0x0002996B File Offset: 0x00027B6B
	protected void method_6()
	{
		if (this.m_Timer.method_6() && this.m_Timer.method_7() && this._meltingPanel != null)
		{
			this._meltingPanel.method_14();
		}
	}

	// Token: 0x06003DA6 RID: 15782 RVA: 0x00125E34 File Offset: 0x00124034
	public override void vmethod_3()
	{
		base.vmethod_3();
		MonoSingleton<AppManager>.Instance.method_0().method_1(new GameUIManager.ViewUpdateCB(this.method_6));
		this._inventoryPanel = null;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._meltingPanel);
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("WeaponMelting-2014.swf");
		this._meltingPanel = null;
	}

	// Token: 0x06003DA7 RID: 15783 RVA: 0x00125EA4 File Offset: 0x001240A4
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
				(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_31(this._meltingPanel);
				(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("UI_BackMenu_Open_Main");
				this.vmethod_6();
				this._inventoryPanel.addEventListener("Item" + MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_9));
				this._inventoryPanel.addEventListener("Item" + GClass53.string_0, new EventDispatcher.EventCallback(this.method_10));
				this._inventoryPanel.addEventListener("Item" + MouseEvent.MOUSE_ENTER, new EventDispatcher.EventCallback(this.method_11));
				this._inventoryPanel.addEventListener("Item" + MouseEvent.MOUSE_LEAVE, new EventDispatcher.EventCallback(this.method_12));
			}
			else
			{
				(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._meltingPanel);
				(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("UI_BackMenu_Close_Main");
				this._inventoryPanel.removeEventListener("Item" + MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_9));
				this._inventoryPanel.removeEventListener("Item" + GClass53.string_0, new EventDispatcher.EventCallback(this.method_10));
				this._inventoryPanel.removeEventListener("Item" + MouseEvent.MOUSE_ENTER, new EventDispatcher.EventCallback(this.method_11));
				this._inventoryPanel.removeEventListener("Item" + MouseEvent.MOUSE_LEAVE, new EventDispatcher.EventCallback(this.method_12));
			}
		}
		this._meltingPanel.Boolean_0 = this._bVisible;
	}

	// Token: 0x06003DA8 RID: 15784 RVA: 0x0002999A File Offset: 0x00027B9A
	private void method_7(MovieClip movieClip_0)
	{
		if (this._meltingPanel == null)
		{
			this._meltingPanel = new uniWeaponMeltView.MeltingPanel();
		}
		this._meltingPanel.method_7(movieClip_0);
	}

	// Token: 0x06003DA9 RID: 15785 RVA: 0x001260B4 File Offset: 0x001242B4
	private void method_8(MovieClip movieClip_0)
	{
		if (this._meltingPanel == null)
		{
			this._meltingPanel = new uniWeaponMeltView.MeltingPanel();
		}
		this._meltingPanel.method_0(movieClip_0);
		this._meltingPanel.addEventListener("XBtnClicked", new EventDispatcher.EventCallback(this.method_14));
		movieClip_0.visible = this._bVisible;
		DisplayObject childByName = movieClip_0.getChildByName("mcInventoryPosition");
		if (childByName != null)
		{
			MonoSingleton<AppManager>.Instance.method_0().method_3(this, GClass20.GClass20_0.method_3(childByName, Vector2.zero));
		}
	}

	// Token: 0x06003DAA RID: 15786 RVA: 0x000299BB File Offset: 0x00027BBB
	protected override void vmethod_6()
	{
		this._meltingPanel.method_8(this._iCost);
	}

	// Token: 0x06003DAB RID: 15787 RVA: 0x000299CE File Offset: 0x00027BCE
	protected override void vmethod_7()
	{
		if (this._meltingPanel == null)
		{
			return;
		}
		if (this._dicMaterialGained.Count > 0)
		{
			this.m_Timer.Start(3f);
			this._meltingPanel.method_9(this._dicMaterialGained);
		}
	}

	// Token: 0x06003DAC RID: 15788 RVA: 0x0012613C File Offset: 0x0012433C
	protected void method_9(CEvent cevent_0)
	{
		GClass55 gclass = cevent_0 as GClass55;
		UIItemSlotData uiitemSlotData = (UIItemSlotData)gclass.object_0;
		if (uiitemSlotData.item.method_3(ItemType.Weapon))
		{
			base.method_3(uiitemSlotData.item, uiitemSlotData.index);
			MonoSingleton<AppManager>.Instance.method_0().vmethod_26(GameUIManager.CursorManager.CursorType.HammerLift);
			base.method_4();
		}
	}

	// Token: 0x06003DAD RID: 15789 RVA: 0x00126194 File Offset: 0x00124394
	protected void method_10(CEvent cevent_0)
	{
		GClass55 gclass = cevent_0 as GClass55;
		UIItemSlotData uiitemSlotData = (UIItemSlotData)gclass.object_0;
		if (uiitemSlotData.item.m_type == ItemType.Weapon)
		{
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("UI_Wep_Melting_Hammer_Hit_Rnd");
			MonoSingleton<AppManager>.Instance.method_0().vmethod_26(GameUIManager.CursorManager.CursorType.HammerKnock);
		}
		else
		{
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("UI_select");
		}
	}

	// Token: 0x06003DAE RID: 15790 RVA: 0x00126208 File Offset: 0x00124408
	protected void method_11(CEvent cevent_0)
	{
		GClass55 gclass = cevent_0 as GClass55;
		UIItemSlotData uiitemSlotData = (UIItemSlotData)gclass.object_0;
		if (uiitemSlotData.item.m_type == ItemType.Weapon)
		{
			base.method_3(uiitemSlotData.item, uiitemSlotData.index);
		}
		else
		{
			base.method_3(null, -1);
			MonoSingleton<AppManager>.Instance.GetComponent<GameUIManager>().vmethod_26(GameUIManager.CursorManager.CursorType.HammerForbid);
		}
	}

	// Token: 0x06003DAF RID: 15791 RVA: 0x00029A08 File Offset: 0x00027C08
	protected void method_12(CEvent cevent_0)
	{
		MonoSingleton<AppManager>.Instance.GetComponent<GameUIManager>().vmethod_26(GameUIManager.CursorManager.CursorType.HammerLift);
		base.method_3(null, -1);
	}

	// Token: 0x06003DB0 RID: 15792 RVA: 0x00029A22 File Offset: 0x00027C22
	protected void method_13(UIItemSlotData uiitemSlotData_0, UIItemSlotData uiitemSlotData_1)
	{
		if (uiitemSlotData_1.identifier == "inventory")
		{
			base.method_3(uiitemSlotData_1.item, uiitemSlotData_1.index);
		}
	}

	// Token: 0x06003DB1 RID: 15793 RVA: 0x0001E5A9 File Offset: 0x0001C7A9
	protected void method_14(CEvent cevent_0)
	{
		this.Boolean_1 = false;
	}

	// Token: 0x06003DB2 RID: 15794 RVA: 0x00029A48 File Offset: 0x00027C48
	protected void method_15(CEvent cevent_0)
	{
		base.vmethod_10();
	}

	// Token: 0x06003DB3 RID: 15795 RVA: 0x00029A50 File Offset: 0x00027C50
	protected override void vmethod_5(SmeltResult smeltResult_0, Dictionary<MaterialType, int> dictionary_0)
	{
		base.vmethod_5(smeltResult_0, dictionary_0);
	}

	// Token: 0x04002B88 RID: 11144
	private uniWeaponMeltView.MeltingPanel _meltingPanel;

	// Token: 0x04002B89 RID: 11145
	private uniInventoryView.InventoryPanel _inventoryPanel;

	// Token: 0x04002B8A RID: 11146
	private Utils.Timer m_Timer = new Utils.Timer();

	// Token: 0x020008BE RID: 2238
	public class MeltingPanel : GClass51
	{
		// Token: 0x17000343 RID: 835
		// (get) Token: 0x06003DB5 RID: 15797 RVA: 0x00029A77 File Offset: 0x00027C77
		// (set) Token: 0x06003DB6 RID: 15798 RVA: 0x00126264 File Offset: 0x00124464
		public bool Boolean_0
		{
			get
			{
				return this.mcRootMovie.visible;
			}
			set
			{
				this.mcRootMovie.visible = value;
				if (this.mcCostInfo != null)
				{
					if (value)
					{
						GClass20.GClass20_0.method_4(this.mcCostInfo, "cursor");
						this.mcCostInfo.addEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_11));
					}
					else
					{
						this.mcCostInfo.removeEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_11));
						GClass20.GClass20_0.method_7(this.mcCostInfo);
					}
				}
			}
		}

		// Token: 0x17000344 RID: 836
		// (get) Token: 0x06003DB7 RID: 15799 RVA: 0x00029A84 File Offset: 0x00027C84
		public bool Boolean_1
		{
			get
			{
				return this.mcRootMovie.isPlaying;
			}
		}

		// Token: 0x06003DB8 RID: 15800 RVA: 0x00029A91 File Offset: 0x00027C91
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.mcRootMovie = base.DisplayObjectContainer_0 as MovieClip;
			if (this.mcRootMovie == null)
			{
				return;
			}
			this.mcRoot = this.mcRootMovie.getChildByName<MovieClip>("mcRoot");
		}

		// Token: 0x06003DB9 RID: 15801 RVA: 0x001262EC File Offset: 0x001244EC
		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			bool flag = false;
			string name = movieClip.name;
			switch (name)
			{
			case "mcAnimation":
				this.mcAnimation = movieClip;
				this.mcAnimation.gotoAndStop("end");
				this.mcAnimation.addFrameScript("fadein", new EventDispatcher.EventCallback(this.method_6));
				this.mcAnimation.addFrameScript("normal", new EventDispatcher.EventCallback(this.method_6));
				this.mcAnimation.addFrameScript("fadeout", new EventDispatcher.EventCallback(this.method_6));
				this.mcAnimation.addFrameScript("end", new EventDispatcher.EventCallback(this.method_6));
				flag = true;
				break;
			case "mcMaterialInfoA":
				this.mcMaterialInfoA = movieClip;
				flag = true;
				break;
			case "mcMaterialInfoB":
				this.mcMaterialInfoB = movieClip;
				flag = true;
				break;
			case "mcMaterialInfoC":
				this.mcMaterialInfoC = movieClip;
				flag = true;
				break;
			case "mcMaterialCoverA":
				this.mcMaterialCoverA = movieClip;
				flag = true;
				break;
			case "mcMaterialCoverB":
				this.mcMaterialCoverB = movieClip;
				flag = true;
				break;
			case "mcMaterialCoverC":
				this.mcMaterialCoverC = movieClip;
				flag = true;
				break;
			case "mcBtnClose":
				this.btnClose = new GClass25();
				this.btnClose.method_0(movieClip);
				this.btnClose.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_5));
				this.btnClose.Boolean_1 = false;
				break;
			}
			return flag;
		}

		// Token: 0x06003DBA RID: 15802 RVA: 0x00029AC9 File Offset: 0x00027CC9
		private void method_5(CEvent cevent_0)
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<WeaponMeltView>().vmethod_4();
		}

		// Token: 0x06003DBB RID: 15803 RVA: 0x001264D8 File Offset: 0x001246D8
		private void method_6(CEvent cevent_0)
		{
			MovieClip childByName = this.mcAnimation.getChildByName("mcMaterialInfo").getChildByName<MovieClip>("mcMaterialInfoChild");
			this.mcMaterialInfoA = childByName.getChildByName<MovieClip>("mcMaterialInfoA");
			this.mcMaterialInfoA.visible = false;
			this.mcMaterialInfoB = childByName.getChildByName<MovieClip>("mcMaterialInfoB");
			this.mcMaterialInfoB.visible = false;
			this.mcMaterialInfoC = childByName.getChildByName<MovieClip>("mcMaterialInfoC");
			this.mcMaterialInfoC.visible = false;
			this.mcMaterialCoverA = childByName.getChildByName<MovieClip>("mcMaterialCoverA");
			this.mcMaterialCoverA.visible = true;
			this.mcMaterialCoverB = childByName.getChildByName<MovieClip>("mcMaterialCoverB");
			this.mcMaterialCoverB.visible = true;
			this.mcMaterialCoverC = childByName.getChildByName<MovieClip>("mcMaterialCoverC");
			this.mcMaterialCoverC.visible = true;
		}

		// Token: 0x06003DBC RID: 15804 RVA: 0x00029AE0 File Offset: 0x00027CE0
		public void method_7(MovieClip movieClip_0)
		{
			this.mcCostInfo = movieClip_0;
			if (this.mcCostInfo != null)
			{
				this.mcCostInfo.visible = false;
			}
		}

		// Token: 0x06003DBD RID: 15805 RVA: 0x001265B0 File Offset: 0x001247B0
		public void method_8(int int_0)
		{
			if (this.mcCostInfo != null)
			{
				this.mcCostInfo.visible = int_0 > 0;
				UnityTextField childByName = this.mcCostInfo.getChildByName<UnityTextField>("textField");
				if (childByName != null)
				{
					childByName.text = Utility.smethod_5("-$", int_0.ToString());
				}
			}
		}

		// Token: 0x06003DBE RID: 15806 RVA: 0x00126600 File Offset: 0x00124800
		public void method_9(Dictionary<MaterialType, int> dictionary_0)
		{
			if (dictionary_0 != null && dictionary_0.Count > 0)
			{
				this.mcAnimation.gotoAndPlay("fadein");
				Dictionary<MaterialType, int>.Enumerator enumerator = dictionary_0.GetEnumerator();
				if (this.mcMaterialInfoA != null)
				{
					if (enumerator.MoveNext())
					{
						this.mcMaterialInfoA.visible = true;
						this._bCoverAVisible = false;
						KeyValuePair<MaterialType, int> keyValuePair = enumerator.Current;
						MaterialType key = keyValuePair.Key;
						KeyValuePair<MaterialType, int> keyValuePair2 = enumerator.Current;
						this.method_12(key, keyValuePair2.Value, this.mcMaterialInfoA);
					}
					else
					{
						this.mcMaterialInfoA.visible = false;
						this._bCoverAVisible = true;
					}
				}
				if (this.mcMaterialInfoB != null)
				{
					if (enumerator.MoveNext())
					{
						this.mcMaterialInfoB.visible = true;
						this._bCoverBVisible = false;
						KeyValuePair<MaterialType, int> keyValuePair3 = enumerator.Current;
						MaterialType key2 = keyValuePair3.Key;
						KeyValuePair<MaterialType, int> keyValuePair4 = enumerator.Current;
						this.method_12(key2, keyValuePair4.Value, this.mcMaterialInfoB);
					}
					else
					{
						this.mcMaterialInfoB.visible = false;
						this._bCoverBVisible = true;
					}
				}
				if (this.mcMaterialInfoC != null)
				{
					if (enumerator.MoveNext())
					{
						this.mcMaterialInfoC.visible = true;
						this._bCoverCVisible = false;
						KeyValuePair<MaterialType, int> keyValuePair5 = enumerator.Current;
						MaterialType key3 = keyValuePair5.Key;
						KeyValuePair<MaterialType, int> keyValuePair6 = enumerator.Current;
						this.method_12(key3, keyValuePair6.Value, this.mcMaterialInfoC);
					}
					else
					{
						this.mcMaterialInfoC.visible = false;
						this._bCoverCVisible = true;
					}
				}
				if (this.mcMaterialCoverA != null)
				{
					this.mcMaterialCoverA.visible = this._bCoverAVisible;
				}
				if (this.mcMaterialCoverB != null)
				{
					this.mcMaterialCoverB.visible = this._bCoverBVisible;
				}
				if (this.mcMaterialCoverC != null)
				{
					this.mcMaterialCoverC.visible = this._bCoverCVisible;
				}
				return;
			}
		}

		// Token: 0x06003DBF RID: 15807 RVA: 0x001267B0 File Offset: 0x001249B0
		public void method_10(AcquiredMaterial[] acquiredMaterial_0, int int_0)
		{
			this.mcAnimation.gotoAndPlay("fadein");
			if (acquiredMaterial_0 == null)
			{
				return;
			}
			if (this.mcMaterialInfoA != null)
			{
				if (acquiredMaterial_0.Length > 0)
				{
					this.mcMaterialInfoA.visible = true;
					this._bCoverAVisible = false;
					this.method_13(acquiredMaterial_0[0], this.mcMaterialInfoA);
				}
				else
				{
					this.mcMaterialInfoA.visible = false;
					this._bCoverAVisible = true;
				}
			}
			if (this.mcMaterialInfoB != null)
			{
				if (acquiredMaterial_0.Length > 1)
				{
					this.mcMaterialInfoB.visible = true;
					this._bCoverBVisible = false;
					this.method_13(acquiredMaterial_0[1], this.mcMaterialInfoB);
				}
				else
				{
					this.mcMaterialInfoB.visible = false;
					this._bCoverBVisible = true;
				}
			}
			if (this.mcMaterialInfoC != null)
			{
				if (acquiredMaterial_0.Length > 2)
				{
					this.mcMaterialInfoC.visible = true;
					this._bCoverCVisible = false;
					this.method_13(acquiredMaterial_0[2], this.mcMaterialInfoC);
				}
				else
				{
					this.mcMaterialInfoC.visible = false;
					this._bCoverCVisible = true;
				}
			}
			if (this.mcMaterialCoverA != null)
			{
				this.mcMaterialCoverA.visible = this._bCoverAVisible;
			}
			if (this.mcMaterialCoverB != null)
			{
				this.mcMaterialCoverB.visible = this._bCoverBVisible;
			}
			if (this.mcMaterialCoverC != null)
			{
				this.mcMaterialCoverC.visible = this._bCoverCVisible;
			}
		}

		// Token: 0x06003DC0 RID: 15808 RVA: 0x00029AFD File Offset: 0x00027CFD
		private void method_11(CEvent cevent_0)
		{
			this.mcCostInfo.x = this.mcCostInfo.parent.mouseX;
			this.mcCostInfo.y = this.mcCostInfo.parent.mouseY;
		}

		// Token: 0x06003DC1 RID: 15809 RVA: 0x001268EC File Offset: 0x00124AEC
		private void method_12(MaterialType materialType_0, int int_0, MovieClip movieClip_0)
		{
			UnityTextField childByName = movieClip_0.getChildByName<UnityTextField>("textField");
			if (childByName != null)
			{
				childByName.text = Utility.smethod_5("x", Utility.smethod_8(int_0));
			}
			MovieClip childByName2 = movieClip_0.getChildByName<MovieClip>("mcMaterialIcon");
			if (childByName2 != null)
			{
				childByName2.gotoAndStop(materialType_0.ToString());
			}
		}

		// Token: 0x06003DC2 RID: 15810 RVA: 0x00126940 File Offset: 0x00124B40
		private void method_13(AcquiredMaterial acquiredMaterial_0, MovieClip movieClip_0)
		{
			UnityTextField childByName = movieClip_0.getChildByName<UnityTextField>("textField");
			if (childByName != null)
			{
				childByName.text = Utility.smethod_5("x", Utility.smethod_8(acquiredMaterial_0.m_MaterialNums));
			}
			MovieClip childByName2 = movieClip_0.getChildByName<MovieClip>("mcMaterialIcon");
			if (childByName2 != null)
			{
				childByName2.gotoAndStop(acquiredMaterial_0.m_MaterialType.ToString());
			}
		}

		// Token: 0x06003DC3 RID: 15811 RVA: 0x00029B35 File Offset: 0x00027D35
		public void method_14()
		{
			if (this.mcAnimation.currentLabel != "end")
			{
				this.mcAnimation.gotoAndPlay("fadeout");
			}
		}

		// Token: 0x04002B8B RID: 11147
		protected MovieClip mcRootMovie;

		// Token: 0x04002B8C RID: 11148
		protected MovieClip mcRoot;

		// Token: 0x04002B8D RID: 11149
		protected MovieClip mcAnimation;

		// Token: 0x04002B8E RID: 11150
		protected MovieClip mcMaterialInfoA;

		// Token: 0x04002B8F RID: 11151
		protected MovieClip mcMaterialInfoB;

		// Token: 0x04002B90 RID: 11152
		protected MovieClip mcMaterialInfoC;

		// Token: 0x04002B91 RID: 11153
		protected MovieClip mcMaterialCoverA;

		// Token: 0x04002B92 RID: 11154
		protected bool _bCoverAVisible = true;

		// Token: 0x04002B93 RID: 11155
		protected MovieClip mcMaterialCoverB;

		// Token: 0x04002B94 RID: 11156
		protected bool _bCoverBVisible = true;

		// Token: 0x04002B95 RID: 11157
		protected MovieClip mcMaterialCoverC;

		// Token: 0x04002B96 RID: 11158
		protected bool _bCoverCVisible = true;

		// Token: 0x04002B97 RID: 11159
		protected MovieClip mcCostInfo;

		// Token: 0x04002B98 RID: 11160
		protected GClass25 btnClose;
	}
}
