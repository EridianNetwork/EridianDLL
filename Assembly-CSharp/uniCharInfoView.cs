using System;
using System.Collections.Generic;
using System.Text;
using ns0;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;
using UnityEngine;
using XsdSettings;

// Token: 0x020007D7 RID: 2007
public class uniCharInfoView : CharInfoView
{
	// Token: 0x170002E4 RID: 740
	// (get) Token: 0x060035C9 RID: 13769 RVA: 0x000235F6 File Offset: 0x000217F6
	// (set) Token: 0x060035C8 RID: 13768 RVA: 0x000235D9 File Offset: 0x000217D9
	public override bool bPVPDisp
	{
		get
		{
			return base.bPVPDisp;
		}
		set
		{
			base.bPVPDisp = value;
			if (this.m_charPanel != null)
			{
				this.m_charPanel.bGreenWord = value;
			}
		}
	}

	// Token: 0x060035CA RID: 13770 RVA: 0x000F5CC4 File Offset: 0x000F3EC4
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		if (this.m_charPanel.Boolean_1)
		{
			return;
		}
		base.vmethod_1(bool_0, bool_1);
		this.vmethod_8(this._bVisible);
		if (this._bVisible)
		{
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_31(this.m_charPanel);
			this.vmethod_9();
			this.vmethod_10();
			this.vmethod_12();
			this.vmethod_15();
			this.vmethod_16();
			this.vmethod_13();
			this.vmethod_14();
			this.vmethod_15();
		}
		this.m_charPanel.Boolean_0 = this._bVisible;
	}

	// Token: 0x060035CB RID: 13771 RVA: 0x000F5D58 File Offset: 0x000F3F58
	public override void vmethod_2()
	{
		base.vmethod_2();
		MonoSingleton<AppManager>.Instance.method_0().method_3(this, new Vector2(0f, 0f));
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("2014_Character_.swf", "Panel_Character", new FuncLoad(this.method_13));
	}

	// Token: 0x060035CC RID: 13772 RVA: 0x000F5DB4 File Offset: 0x000F3FB4
	private void method_13(MovieClip movieClip_0)
	{
		this.m_charPanel = new uniCharInfoView.CharacterPanel();
		this.m_charPanel.method_0(movieClip_0);
		movieClip_0.visible = this._bVisible;
		movieClip_0.x = 430f;
		movieClip_0.y = 15f;
		this.m_charPanel.bGreenWord = this.bPVPDisp;
		uniCharInfoView.CharacterPanel charPanel = this.m_charPanel;
		charPanel.swapFunc = (uniCharInfoView.Item_SWAP_Delegate)Delegate.Combine(charPanel.swapFunc, new uniCharInfoView.Item_SWAP_Delegate(this.method_15));
		uniCharInfoView.CharacterPanel charPanel2 = this.m_charPanel;
		charPanel2.activeFunc = (uniCharInfoView.Index_Delegate)Delegate.Combine(charPanel2.activeFunc, new uniCharInfoView.Index_Delegate(base.method_11));
		uniCharInfoView.CharacterPanel charPanel3 = this.m_charPanel;
		charPanel3.shieldFunc = (uniCharInfoView.Index_Delegate)Delegate.Combine(charPanel3.shieldFunc, new uniCharInfoView.Index_Delegate(this.vmethod_20));
		uniCharInfoView.CharacterPanel charPanel4 = this.m_charPanel;
		charPanel4.classModeFunc = (uniCharInfoView.Index_Delegate)Delegate.Combine(charPanel4.classModeFunc, new uniCharInfoView.Index_Delegate(this.vmethod_20));
		uniCharInfoView.CharacterPanel charPanel5 = this.m_charPanel;
		charPanel5.outFitFunc = (uniCharInfoView.Index_Delegate)Delegate.Combine(charPanel5.outFitFunc, new uniCharInfoView.Index_Delegate(this.vmethod_20));
		this.m_charPanel.addEventListener("showWeaponModel", new EventDispatcher.EventCallback(this.method_16));
		this.m_charPanel.addEventListener("Model_" + MouseEvent.MOUSE_DOWN, new EventDispatcher.EventCallback(this.method_17));
		this.m_charPanel.addEventListener("Model_" + MouseEvent.MOUSE_UP, new EventDispatcher.EventCallback(this.method_18));
		this.m_charPanel.addEventListener("Model_" + MouseEvent.MOUSE_LEAVE, new EventDispatcher.EventCallback(this.method_18));
		DisplayObject childByName = movieClip_0.getChildByName("mcInventoryPosition");
		if (childByName != null)
		{
			MonoSingleton<AppManager>.Instance.method_0().method_3(this, GClass20.GClass20_0.method_3(childByName, Vector2.zero));
		}
	}

	// Token: 0x060035CD RID: 13773 RVA: 0x000F5F94 File Offset: 0x000F4194
	public override void vmethod_3()
	{
		base.vmethod_3();
		if (this.m_charPanel != null)
		{
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this.m_charPanel);
			uniCharInfoView.CharacterPanel charPanel = this.m_charPanel;
			charPanel.swapFunc = (uniCharInfoView.Item_SWAP_Delegate)Delegate.Remove(charPanel.swapFunc, new uniCharInfoView.Item_SWAP_Delegate(this.method_15));
			uniCharInfoView.CharacterPanel charPanel2 = this.m_charPanel;
			charPanel2.activeFunc = (uniCharInfoView.Index_Delegate)Delegate.Remove(charPanel2.activeFunc, new uniCharInfoView.Index_Delegate(base.method_11));
			uniCharInfoView.CharacterPanel charPanel3 = this.m_charPanel;
			charPanel3.shieldFunc = (uniCharInfoView.Index_Delegate)Delegate.Remove(charPanel3.shieldFunc, new uniCharInfoView.Index_Delegate(this.vmethod_20));
			uniCharInfoView.CharacterPanel charPanel4 = this.m_charPanel;
			charPanel4.classModeFunc = (uniCharInfoView.Index_Delegate)Delegate.Remove(charPanel4.classModeFunc, new uniCharInfoView.Index_Delegate(this.vmethod_20));
		}
		this.m_charPanel = null;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("2014_Character_.swf");
	}

	// Token: 0x060035CE RID: 13774 RVA: 0x000F608C File Offset: 0x000F428C
	public void method_14(object object_0, GClass44 gclass44_0)
	{
		if (gclass44_0 == null)
		{
			return;
		}
		if (gclass44_0.movieClip_7 != null)
		{
			gclass44_0.movieClip_7.visible = false;
		}
		Texture2D texture2D = null;
		if (object_0 != null)
		{
			UIItemSlotData uiitemSlotData = (UIItemSlotData)object_0;
			ItemDNA item = uiitemSlotData.item;
			if (item != null)
			{
				texture2D = MonoSingleton<DNAPortrait>.Instance.method_3(item, 0, 0, TexPostEffectMgr.POST_EFFECT_TYPE.POST_EFFECT_UI);
				if (gclass44_0.movieClip_7 != null)
				{
					gclass44_0.movieClip_7.visible = true;
				}
				gclass44_0.Color_0 = UniUIManager.UniSWFToolClass.smethod_3(item.ItemRarity_0);
			}
		}
		GClass43 gclass43_ = gclass44_0.gclass43_0;
		if (gclass43_ != null)
		{
			gclass43_.vmethod_8(texture2D);
		}
		gclass44_0.Boolean_1 = true;
	}

	// Token: 0x060035CF RID: 13775 RVA: 0x000F6114 File Offset: 0x000F4314
	protected override void vmethod_9()
	{
		if (this.m_charPanel == null)
		{
			return;
		}
		int num = 0;
		while (num < this._iWeaponSlotSum && num < this._arrWeapons.Length)
		{
			this.m_charPanel.method_8(num, this._arrWeapons[num]);
			num++;
		}
		this.m_charPanel.method_9(this._iActivedIndex);
	}

	// Token: 0x060035D0 RID: 13776 RVA: 0x000235FE File Offset: 0x000217FE
	protected override void vmethod_10()
	{
		if (this.m_charPanel == null)
		{
			return;
		}
		if (this._playerInfo != null)
		{
			this.m_charPanel.method_11(this._playerInfo);
		}
	}

	// Token: 0x060035D1 RID: 13777 RVA: 0x000F616C File Offset: 0x000F436C
	protected override void vmethod_11()
	{
		if (this.m_charPanel == null)
		{
			return;
		}
		List<string> list = ExtraAttributeStore.smethod_2();
		this.m_charPanel.method_12(list.ToArray());
	}

	// Token: 0x060035D2 RID: 13778 RVA: 0x00023622 File Offset: 0x00021822
	protected override void vmethod_13()
	{
		if (this.m_charPanel == null)
		{
			return;
		}
		this.m_charPanel.method_10();
	}

	// Token: 0x060035D3 RID: 13779 RVA: 0x00023638 File Offset: 0x00021838
	protected override void vmethod_12()
	{
		if (this.m_charPanel == null)
		{
			return;
		}
		this.m_charPanel.method_15(this._ammoInfoList);
	}

	// Token: 0x060035D4 RID: 13780 RVA: 0x00023654 File Offset: 0x00021854
	protected override void vmethod_14()
	{
		if (this.m_charPanel == null)
		{
			return;
		}
		if (ServiceWrapperBase<CharacterServiceWrapper>.Instance.vmethod_2())
		{
			this.m_charPanel.method_13(ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_19());
		}
	}

	// Token: 0x060035D5 RID: 13781 RVA: 0x000F619C File Offset: 0x000F439C
	protected override void vmethod_15()
	{
		if (this.m_charPanel == null)
		{
			return;
		}
		this.m_charPanel.method_5(this._shieldDNA);
		if (MonoSingleton<Session>.Instance && MonoSingleton<Session>.Instance.GetLocalPlayer())
		{
			EntityPlayer entityPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer().GetEntity() as EntityPlayer;
			if (entityPlayer)
			{
				EquipmentInventoryEntity equipmentInventoryEntity = entityPlayer.vmethod_19();
				if (equipmentInventoryEntity != null)
				{
					this.m_charPanel.method_14(equipmentInventoryEntity.vmethod_7());
				}
			}
		}
	}

	// Token: 0x060035D6 RID: 13782 RVA: 0x00023680 File Offset: 0x00021880
	protected override void vmethod_16()
	{
		if (this.m_charPanel == null)
		{
			return;
		}
		this.m_charPanel.method_6(this._classModeDNA);
	}

	// Token: 0x060035D7 RID: 13783 RVA: 0x0002369C File Offset: 0x0002189C
	protected override void vmethod_17()
	{
		base.vmethod_17();
		if (this.m_charPanel == null)
		{
			return;
		}
		this.m_charPanel.method_7(this._arrOutfits);
	}

	// Token: 0x060035D8 RID: 13784 RVA: 0x000F6220 File Offset: 0x000F4420
	protected override void vmethod_18(InventoryServiceWrapper.InventoryUpdateType inventoryUpdateType_0)
	{
		if (!this.m_bPlaySFX)
		{
			return;
		}
		this.m_bPlaySFX = false;
		if (inventoryUpdateType_0 == InventoryServiceWrapper.InventoryUpdateType.EquipItemFail)
		{
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("UI_Vending_No_Money");
		}
		else
		{
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("UI_Inventory_Equip");
		}
	}

	// Token: 0x060035D9 RID: 13785 RVA: 0x000F6278 File Offset: 0x000F4478
	protected void method_15(UIItemSlotData uiitemSlotData_0, UIItemSlotData uiitemSlotData_1)
	{
		if (uiitemSlotData_1.identifier == "inventory")
		{
			if (uiitemSlotData_1.item.m_type == ItemType.Weapon)
			{
				this.m_bPlaySFX = true;
				base.method_10(uiitemSlotData_1.index, uiitemSlotData_0.index);
				return;
			}
		}
		else if (uiitemSlotData_1.identifier == "character")
		{
			if (uiitemSlotData_0.identifier == "inventory")
			{
				this.m_bPlaySFX = true;
				base.method_10(uiitemSlotData_0.index, uiitemSlotData_1.index);
				return;
			}
			base.method_12(uiitemSlotData_1.index, uiitemSlotData_0.index);
		}
	}

	// Token: 0x060035DA RID: 13786 RVA: 0x000F6310 File Offset: 0x000F4510
	protected override void vmethod_19()
	{
		for (int i = 0; i < this._arrWeapons.Length; i++)
		{
			ItemDNA itemDNA = this._arrWeapons[i];
			if (itemDNA != null)
			{
				MonoSingleton<DNAPortrait>.Instance.method_3(itemDNA, 0, 0, TexPostEffectMgr.POST_EFFECT_TYPE.POST_EFFECT_UI);
			}
		}
	}

	// Token: 0x060035DB RID: 13787 RVA: 0x000F634C File Offset: 0x000F454C
	protected void method_16(CEvent cevent_0)
	{
		GClass55 gclass = cevent_0 as GClass55;
		if (gclass != null)
		{
			WeaponDNA weaponDNA = (WeaponDNA)gclass.object_0;
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<WeaponPreviewView>().vmethod_6(weaponDNA, true);
		}
	}

	// Token: 0x060035DC RID: 13788 RVA: 0x000236BE File Offset: 0x000218BE
	protected void method_17(CEvent cevent_0)
	{
		if (this._modelController != null)
		{
			this._modelController.method_0(new Vector3(-0.5f, 0f, 0f));
		}
	}

	// Token: 0x060035DD RID: 13789 RVA: 0x000236ED File Offset: 0x000218ED
	protected void method_18(CEvent cevent_0)
	{
		if (this._modelController != null)
		{
			this._modelController.method_0(Vector3.zero);
		}
	}

	// Token: 0x0400254D RID: 9549
	protected uniCharInfoView.CharacterPanel m_charPanel;

	// Token: 0x0400254E RID: 9550
	protected bool m_bPlaySFX;

	// Token: 0x020007D8 RID: 2008
	protected class CharacterPanel : GClass51
	{
		// Token: 0x060035DE RID: 13790 RVA: 0x000F6388 File Offset: 0x000F4588
		public CharacterPanel()
		{
			this.TITLE_HP = LocalizedString.smethod_0(new LocalizedString("HP"));
			this.TITLE_SHIELD = LocalizedString.smethod_0(new LocalizedString("Shield"));
			this.TITLE_DAMAGE = LocalizedString.smethod_0(new LocalizedString("Damage"));
			this.TITLE_CRITICAL = LocalizedString.smethod_0(new LocalizedString("Critiacl Rate"));
			this._arrItemSlots = new GClass44[this.SLOT_NUM];
			this._arrCheckBoxes = new GClass40[this.SLOT_NUM];
		}

		// Token: 0x170002E5 RID: 741
		// (get) Token: 0x060035E0 RID: 13792 RVA: 0x00023716 File Offset: 0x00021916
		// (set) Token: 0x060035DF RID: 13791 RVA: 0x0002370D File Offset: 0x0002190D
		public bool bGreenWord { get; set; }

		// Token: 0x170002E6 RID: 742
		// (get) Token: 0x060035E2 RID: 13794 RVA: 0x00023727 File Offset: 0x00021927
		// (set) Token: 0x060035E1 RID: 13793 RVA: 0x0002371E File Offset: 0x0002191E
		public int iActivedIndex { get; set; }

		// Token: 0x170002E7 RID: 743
		// (get) Token: 0x060035E3 RID: 13795 RVA: 0x0002372F File Offset: 0x0002192F
		// (set) Token: 0x060035E4 RID: 13796 RVA: 0x0002373C File Offset: 0x0002193C
		public bool Boolean_0
		{
			get
			{
				return this.mcRootMovie.visible;
			}
			set
			{
				if (value)
				{
					this.method_34();
				}
				else
				{
					this.method_35();
				}
			}
		}

		// Token: 0x170002E8 RID: 744
		// (get) Token: 0x060035E5 RID: 13797 RVA: 0x0002374F File Offset: 0x0002194F
		public bool Boolean_1
		{
			get
			{
				return this.mcRootMovie.isPlaying;
			}
		}

		// Token: 0x060035E6 RID: 13798 RVA: 0x000F6448 File Offset: 0x000F4648
		public void method_5(ItemDNA itemDNA_0)
		{
			if (itemDNA_0 != null)
			{
				this.mcShieldSlot.Object_0 = new UIItemSlotData(itemDNA_0, "charShield", 0, false);
				this.mcShieldSlot.GInterface1_0 = new ItemTips(itemDNA_0);
			}
			else
			{
				this.mcShieldSlot.Object_0 = null;
				this.mcShieldSlot.GInterface1_0 = null;
			}
		}

		// Token: 0x060035E7 RID: 13799 RVA: 0x000F649C File Offset: 0x000F469C
		public void method_6(ItemDNA itemDNA_0)
		{
			if (itemDNA_0 != null)
			{
				this.mcClassModeSlot.Object_0 = new UIItemSlotData(itemDNA_0, "charClassMode", 0, false);
				this.mcClassModeSlot.GInterface1_0 = new ItemTips(itemDNA_0);
			}
			else
			{
				this.mcClassModeSlot.Object_0 = null;
				this.mcClassModeSlot.GInterface1_0 = null;
			}
		}

		// Token: 0x060035E8 RID: 13800 RVA: 0x000F64F0 File Offset: 0x000F46F0
		public void method_7(ItemDNA[] itemDNA_0)
		{
			if (itemDNA_0.Length >= 0 && itemDNA_0.Length <= 5)
			{
				if (this.mcHairSlot != null)
				{
					this.mcHairSlot.Object_0 = ((itemDNA_0[0] != null) ? new UIItemSlotData(itemDNA_0[0], "charOutfit", 0, false) : null);
					this.mcHairSlot.GInterface1_0 = ((itemDNA_0[0] != null) ? new ItemTips(itemDNA_0[0]) : null);
				}
				if (this.mcMaskSlot != null)
				{
					this.mcMaskSlot.Object_0 = ((itemDNA_0[1] != null) ? new UIItemSlotData(itemDNA_0[1], "charOutfit", 1, false) : null);
					this.mcMaskSlot.GInterface1_0 = ((itemDNA_0[1] != null) ? new ItemTips(itemDNA_0[1]) : null);
				}
				if (this.mcBodySlot != null)
				{
					this.mcBodySlot.Object_0 = ((itemDNA_0[2] != null) ? new UIItemSlotData(itemDNA_0[2], "charOutfit", 2, false) : null);
					this.mcBodySlot.GInterface1_0 = ((itemDNA_0[2] != null) ? new ItemTips(itemDNA_0[2]) : null);
				}
				if (this.mcPantsSlot != null)
				{
					this.mcPantsSlot.Object_0 = ((itemDNA_0[3] != null) ? new UIItemSlotData(itemDNA_0[3], "charOutfit", 3, false) : null);
					this.mcPantsSlot.GInterface1_0 = ((itemDNA_0[3] != null) ? new ItemTips(itemDNA_0[3]) : null);
				}
				if (this.mcShoeSlot != null)
				{
					this.mcShoeSlot.Object_0 = ((itemDNA_0[4] != null) ? new UIItemSlotData(itemDNA_0[4], "charOutfit", 4, false) : null);
					this.mcShoeSlot.GInterface1_0 = ((itemDNA_0[4] != null) ? new ItemTips(itemDNA_0[4]) : null);
				}
				return;
			}
		}

		// Token: 0x060035E9 RID: 13801 RVA: 0x000F666C File Offset: 0x000F486C
		public void method_8(int int_0, ItemDNA itemDNA_0)
		{
			if (int_0 < this._arrItemSlots.Length && int_0 >= 0)
			{
				if (itemDNA_0 != null)
				{
					if (!this._arrCheckBoxes[int_0].Boolean_6)
					{
						this._arrCheckBoxes[int_0].Boolean_6 = true;
					}
					this._arrItemSlots[int_0].Object_0 = new UIItemSlotData(itemDNA_0, "character", int_0, false);
					this._arrItemSlots[int_0].GInterface1_0 = new ItemTips(itemDNA_0);
				}
				else
				{
					if (this._arrCheckBoxes[int_0].Boolean_3)
					{
						this._arrCheckBoxes[int_0].Boolean_3 = false;
					}
					if (this._arrCheckBoxes[int_0].Boolean_6)
					{
						this._arrCheckBoxes[int_0].Boolean_6 = false;
					}
					this._arrItemSlots[int_0].Object_0 = null;
					this._arrItemSlots[int_0].GInterface1_0 = null;
				}
				return;
			}
		}

		// Token: 0x060035EA RID: 13802 RVA: 0x000F6734 File Offset: 0x000F4934
		public void method_9(int int_0)
		{
			if (int_0 < 0)
			{
				return;
			}
			if (int_0 >= 0 && int_0 < this._arrCheckBoxes.Length)
			{
				this.iActivedIndex = int_0;
				if (!this._arrCheckBoxes[this.iActivedIndex].Boolean_3)
				{
					this._arrCheckBoxes[this.iActivedIndex].Boolean_3 = true;
				}
				return;
			}
		}

		// Token: 0x060035EB RID: 13803 RVA: 0x000F6784 File Offset: 0x000F4984
		public void method_10()
		{
			if (this.mc3DAvatar != null)
			{
				Rect rect = UniUIManager.UniSWFToolClass.smethod_10(MonoSingleton<GraphicsMgr>.Instance.method_22().method_14());
				this.mc3DAvatar.vmethod_9(MonoSingleton<GraphicsMgr>.Instance.method_22().method_13(), rect);
			}
		}

		// Token: 0x060035EC RID: 13804 RVA: 0x0002375C File Offset: 0x0002195C
		public void method_11(PlayerProperties playerProperties_0)
		{
			this._playerInfo = playerProperties_0;
			if (this._playerInfo != null)
			{
				if (this.mcPlayerName != null)
				{
					this.mcPlayerName.text = this._playerInfo.m_name;
				}
				this.method_21();
				this.method_22();
			}
		}

		// Token: 0x060035ED RID: 13805 RVA: 0x000F67CC File Offset: 0x000F49CC
		public void method_12(string[] string_1)
		{
			this.sbExtraAtt.Remove(0, this.sbExtraAtt.Length);
			if (string_1 == null)
			{
				return;
			}
			for (int i = 0; i < string_1.Length; i++)
			{
				this.sbExtraAtt.AppendLine(string_1[i]);
			}
			if (this.mcPropertyPanel != null)
			{
				UnityTextField childByName = this.mcPropertyPanel.getChildByName<UnityTextField>("tfExtraAttribute");
				if (childByName != null)
				{
					childByName.text = this.sbExtraAtt.ToString();
				}
			}
		}

		// Token: 0x060035EE RID: 13806 RVA: 0x000F6840 File Offset: 0x000F4A40
		public void method_13(float float_0)
		{
			if (this.mcPropertyPanel != null)
			{
				UnityTextField childByName = this.mcPropertyPanel.getChildByName<UnityTextField>("tfDamage");
				if (childByName != null)
				{
					childByName.text = ((int)float_0).ToString();
				}
			}
		}

		// Token: 0x060035EF RID: 13807 RVA: 0x000F687C File Offset: 0x000F4A7C
		public void method_14(int int_0)
		{
			if (this.mcPropertyPanel != null)
			{
				UnityTextField childByName = this.mcPropertyPanel.getChildByName<UnityTextField>("tfShield");
				if (childByName != null)
				{
					if (this.bGreenWord)
					{
						childByName.Color_0 = Color.green;
					}
					childByName.text = Utility.smethod_8(int_0);
				}
			}
		}

		// Token: 0x060035F0 RID: 13808 RVA: 0x000F68C4 File Offset: 0x000F4AC4
		private static string smethod_0(AmmoType ammoType_0)
		{
			switch (ammoType_0)
			{
			case AmmoType.SMG:
				return "mcAmmoSMG";
			case AmmoType.SniperRifle:
				return "mcAmmoSniperRifle";
			case AmmoType.Grenade:
				return "mcAmmoGrenade";
			case AmmoType.ShotGun:
				return "mcAmmoShotGun";
			case AmmoType.Pistol:
				return "mcAmmoPistol";
			case AmmoType.AssaultRifle:
				return "mcAmmoAssaultRifle";
			default:
				return string.Empty;
			}
		}

		// Token: 0x060035F1 RID: 13809 RVA: 0x000F691C File Offset: 0x000F4B1C
		private static string smethod_1(AmmoType ammoType_0)
		{
			switch (ammoType_0)
			{
			case AmmoType.SMG:
				return "mcAmmoSMG_max";
			case AmmoType.SniperRifle:
				return "mcAmmoSniperRifle_max";
			case AmmoType.Grenade:
				return "mcAmmoGrenade_max";
			case AmmoType.ShotGun:
				return "mcAmmoShotGun_max";
			case AmmoType.Pistol:
				return "mcAmmoPistol_max";
			case AmmoType.AssaultRifle:
				return "mcAmmoAssaultRifle_max";
			default:
				return string.Empty;
			}
		}

		// Token: 0x060035F2 RID: 13810 RVA: 0x000F6974 File Offset: 0x000F4B74
		public void method_15(Dictionary<int, Vector2> dictionary_0)
		{
			if (this.mcPropertyPanel == null)
			{
				return;
			}
			MovieClip movieClip = this.mcPropertyPanel;
			if (movieClip != null)
			{
				Dictionary<int, Vector2>.Enumerator enumerator = dictionary_0.GetEnumerator();
				while (enumerator.MoveNext())
				{
					DisplayObject displayObject = movieClip;
					KeyValuePair<int, Vector2> keyValuePair = enumerator.Current;
					TextField textField = displayObject.getChildByName<TextField>(uniCharInfoView.CharacterPanel.smethod_0((AmmoType)keyValuePair.Key));
					if (textField != null)
					{
						this.m_stringbuilder.Length = 0;
						StringBuilder stringbuilder = this.m_stringbuilder;
						KeyValuePair<int, Vector2> keyValuePair2 = enumerator.Current;
						stringbuilder.Append(keyValuePair2.Value.x);
						textField.text = this.m_stringbuilder.ToString();
					}
					DisplayObject displayObject2 = movieClip;
					KeyValuePair<int, Vector2> keyValuePair3 = enumerator.Current;
					textField = displayObject2.getChildByName<TextField>(uniCharInfoView.CharacterPanel.smethod_1((AmmoType)keyValuePair3.Key));
					if (textField != null)
					{
						this.m_stringbuilder.Length = 0;
						StringBuilder stringbuilder2 = this.m_stringbuilder;
						KeyValuePair<int, Vector2> keyValuePair4 = enumerator.Current;
						stringbuilder2.Append(keyValuePair4.Value.y);
						textField.text = this.m_stringbuilder.ToString();
					}
				}
			}
		}

		// Token: 0x060035F3 RID: 13811 RVA: 0x000F6A70 File Offset: 0x000F4C70
		public void method_16(bool bool_0)
		{
			int num = this._arrCheckBoxes.Length;
			for (int i = 0; i < num; i++)
			{
				if (this._arrCheckBoxes[i] != null)
				{
					this._arrCheckBoxes[i].Boolean_6 = bool_0;
				}
			}
		}

		// Token: 0x060035F4 RID: 13812 RVA: 0x000F6AAC File Offset: 0x000F4CAC
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.mcRootMovie = base.DisplayObjectContainer_0 as MovieClip;
			if (this.mcRootMovie != null)
			{
				this.mcRootMovie.stop();
				this.mcRootMovie.updateFrame(new CEvent(CEvent.ENTER_FRAME, false, false));
				this.method_21();
				this.method_22();
				this.mcPlayerName = this.mcRootMovie.getChildByName<MovieClip>("mcRoot").getChildByName<TextField>("mcPlayerName");
				if (this._playerInfo != null)
				{
					this.mcPlayerName.text = this._playerInfo.m_name;
				}
				this.mcPrice = this.mcRootMovie.getChildByName<MovieClip>("mcRoot").getChildByName<MovieClip>("mcPrice");
				this.mcPrice.visible = false;
			}
		}

		// Token: 0x060035F5 RID: 13813 RVA: 0x000F6B74 File Offset: 0x000F4D74
		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			int num = UniUIManager.UniSWFToolClass.smethod_6(movieClip.name, this.ITEM_SLOT_PREFIX_NAME);
			if (num >= 0 && num < this._arrItemSlots.Length)
			{
				GClass44 gclass = new GClass44();
				gclass.method_0(movieClip);
				movieClip.updateFrame(new CEvent(CEvent.ENTER_FRAME, false, false));
				TextField childByName = movieClip.getChildByName<TextField>("tfLabel");
				if (childByName != null)
				{
					childByName.text = (num + 1).ToString();
				}
				gclass.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_25));
				gclass.addEventListener("slash", new EventDispatcher.EventCallback(this.method_24));
				gclass.addEventListener("drop", new EventDispatcher.EventCallback(this.method_23));
				gclass.addEventListener(GClass53.string_5, new EventDispatcher.EventCallback(this.method_37));
				gclass.method_11(new GClass44.GDelegate2((MonoSingleton<AppManager>.Instance.method_0().vmethod_5<CharInfoView>() as uniCharInfoView).method_14));
				gclass.method_15(new GClass42.GDelegate0(this.method_17));
				gclass.object_0 = num;
				this._arrItemSlots[num] = gclass;
				return true;
			}
			num = UniUIManager.UniSWFToolClass.smethod_6(movieClip.name, this.ITEM_CHECKBOX_PREFIX_NAME);
			if (num >= 0 && num < this._arrCheckBoxes.Length)
			{
				GClass40 gclass2 = new GClass40();
				gclass2.method_0(movieClip);
				gclass2.bool_5 = false;
				gclass2.String_1 = "characterInfo";
				if (num == 0)
				{
					gclass2.GClass17_0.addEventListener(CEvent.CHANGED, new EventDispatcher.EventCallback(this.method_32));
				}
				gclass2.Object_0 = num;
				this._arrCheckBoxes[num] = gclass2;
				return true;
			}
			bool flag = false;
			string name = movieClip.name;
			switch (name)
			{
			case "mcXButton":
				this.mcXButton = new GClass25();
				this.mcXButton.method_0(movieClip);
				this.mcXButton.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_33));
				flag = true;
				break;
			case "mcAvatar":
				this.mcAvatar = movieClip;
				movieClip.stopAll();
				this.mc3DAvatar = new GClass43();
				this.mc3DAvatar.method_0(movieClip);
				this.mcAvatar.addEventListener(MouseEvent.MOUSE_DOWN, new EventDispatcher.EventCallback(this.method_20));
				this.mcAvatar.addEventListener(MouseEvent.MOUSE_UP, new EventDispatcher.EventCallback(this.method_20));
				this.mcAvatar.addEventListener(MouseEvent.MOUSE_LEAVE, new EventDispatcher.EventCallback(this.method_20));
				flag = true;
				break;
			case "mcTabRadio0":
				this.mcTabRadio0 = new GClass40();
				this.mcTabRadio0.method_0(movieClip);
				this.mcTabRadio0.Boolean_3 = true;
				this.mcTabRadio0.bool_5 = false;
				this.mcTabRadio0.String_1 = "charInfoEquip";
				this.mcTabRadio0.GClass17_0.addEventListener(CEvent.CHANGED, new EventDispatcher.EventCallback(this.method_31));
				this.mcTabRadio0.String_2 = LocalizedString.smethod_0(new LocalizedString("Equipment"));
				flag = true;
				break;
			case "mcTabRadio1":
				this.mcTabRadio1 = new GClass40();
				this.mcTabRadio1.method_0(movieClip);
				this.mcTabRadio1.bool_5 = false;
				this.mcTabRadio1.String_1 = "charInfoEquip";
				this.mcTabRadio1.String_2 = LocalizedString.smethod_0(new LocalizedString("Attribute"));
				flag = true;
				break;
			case "mcShieldSlot":
			{
				MovieClip childByName2 = movieClip.getChildByName<MovieClip>("mcPattern");
				if (childByName2 != null)
				{
					childByName2.visible = true;
					childByName2.gotoAndStop("shieldMod");
				}
				this.mcShieldSlot = new GClass44();
				this.mcShieldSlot.method_0(movieClip);
				movieClip.updateFrame(new CEvent(CEvent.ENTER_FRAME, false, false));
				this.mcShieldSlot.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_26));
				this.mcShieldSlot.addEventListener("slash", new EventDispatcher.EventCallback(this.method_27));
				this.mcShieldSlot.addEventListener("drop", new EventDispatcher.EventCallback(this.method_28));
				this.mcShieldSlot.method_15(new GClass42.GDelegate0(this.method_18));
				this.mcShieldSlot.method_11(new GClass44.GDelegate2((MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InventoryView>() as uniInventoryView).method_21));
				flag = true;
				break;
			}
			case "mcClassModeSlot":
			{
				MovieClip childByName3 = movieClip.getChildByName<MovieClip>("mcPattern");
				if (childByName3 != null)
				{
					childByName3.visible = true;
					childByName3.gotoAndStop("classMod");
				}
				this.mcClassModeSlot = new GClass44();
				this.mcClassModeSlot.method_0(movieClip);
				movieClip.updateFrame(new CEvent(CEvent.ENTER_FRAME, false, false));
				this.mcClassModeSlot.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_26));
				this.mcClassModeSlot.addEventListener("slash", new EventDispatcher.EventCallback(this.method_27));
				this.mcClassModeSlot.addEventListener("drop", new EventDispatcher.EventCallback(this.method_29));
				this.mcClassModeSlot.method_15(new GClass42.GDelegate0(this.method_19));
				this.mcClassModeSlot.method_11(new GClass44.GDelegate2((MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InventoryView>() as uniInventoryView).method_21));
				flag = true;
				break;
			}
			case "mcGranedeSlot":
			{
				MovieClip childByName4 = movieClip.getChildByName<MovieClip>("mcPattern");
				if (childByName4 != null)
				{
					childByName4.visible = true;
					childByName4.gotoAndStop("grenade");
				}
				this.mcGranedeSlot = new GClass44();
				this.mcGranedeSlot.method_0(movieClip);
				movieClip.updateFrame(new CEvent(CEvent.ENTER_FRAME, false, false));
				this.mcGranedeSlot.method_11(new GClass44.GDelegate2((MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InventoryView>() as uniInventoryView).method_21));
				flag = true;
				break;
			}
			case "mcHairSlot":
			{
				MovieClip childByName5 = movieClip.getChildByName<MovieClip>("mcPattern");
				if (childByName5 != null)
				{
					childByName5.visible = true;
					childByName5.gotoAndStop("HAIR");
				}
				this.mcHairSlot = new GClass44();
				this.mcHairSlot.method_0(movieClip);
				movieClip.updateFrame(new CEvent(CEvent.ENTER_FRAME, false, false));
				this.mcHairSlot.addEventListener("drop", new EventDispatcher.EventCallback(this.method_30));
				this.mcHairSlot.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_26));
				this.mcHairSlot.addEventListener("slash", new EventDispatcher.EventCallback(this.method_27));
				this.mcHairSlot.method_11(new GClass44.GDelegate2((MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InventoryView>() as uniInventoryView).method_21));
				flag = true;
				break;
			}
			case "mcMaskSlot":
			{
				MovieClip childByName6 = movieClip.getChildByName<MovieClip>("mcPattern");
				if (childByName6 != null)
				{
					childByName6.visible = true;
					childByName6.gotoAndStop("MASK");
				}
				this.mcMaskSlot = new GClass44();
				this.mcMaskSlot.method_0(movieClip);
				movieClip.updateFrame(new CEvent(CEvent.ENTER_FRAME, false, false));
				this.mcMaskSlot.addEventListener("drop", new EventDispatcher.EventCallback(this.method_30));
				this.mcMaskSlot.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_26));
				this.mcMaskSlot.addEventListener("slash", new EventDispatcher.EventCallback(this.method_27));
				this.mcMaskSlot.method_11(new GClass44.GDelegate2((MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InventoryView>() as uniInventoryView).method_21));
				flag = true;
				break;
			}
			case "mcBodySlot":
			{
				MovieClip childByName7 = movieClip.getChildByName<MovieClip>("mcPattern");
				if (childByName7 != null)
				{
					childByName7.visible = true;
					childByName7.gotoAndStop("BODY");
				}
				this.mcBodySlot = new GClass44();
				this.mcBodySlot.method_0(movieClip);
				movieClip.updateFrame(new CEvent(CEvent.ENTER_FRAME, false, false));
				this.mcBodySlot.addEventListener("drop", new EventDispatcher.EventCallback(this.method_30));
				this.mcBodySlot.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_26));
				this.mcBodySlot.addEventListener("slash", new EventDispatcher.EventCallback(this.method_27));
				this.mcBodySlot.method_11(new GClass44.GDelegate2((MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InventoryView>() as uniInventoryView).method_21));
				flag = true;
				break;
			}
			case "mcPantsSlot":
			{
				MovieClip childByName8 = movieClip.getChildByName<MovieClip>("mcPattern");
				if (childByName8 != null)
				{
					childByName8.visible = true;
					childByName8.gotoAndStop("PANTS");
				}
				this.mcPantsSlot = new GClass44();
				this.mcPantsSlot.method_0(movieClip);
				movieClip.updateFrame(new CEvent(CEvent.ENTER_FRAME, false, false));
				this.mcPantsSlot.addEventListener("drop", new EventDispatcher.EventCallback(this.method_30));
				this.mcPantsSlot.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_26));
				this.mcPantsSlot.addEventListener("slash", new EventDispatcher.EventCallback(this.method_27));
				this.mcPantsSlot.method_11(new GClass44.GDelegate2((MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InventoryView>() as uniInventoryView).method_21));
				flag = true;
				break;
			}
			case "mcShoeSlot":
			{
				MovieClip childByName9 = movieClip.getChildByName<MovieClip>("mcPattern");
				if (childByName9 != null)
				{
					childByName9.visible = true;
					childByName9.gotoAndStop("SHOE");
				}
				this.mcShoeSlot = new GClass44();
				this.mcShoeSlot.method_0(movieClip);
				movieClip.updateFrame(new CEvent(CEvent.ENTER_FRAME, false, false));
				this.mcShoeSlot.addEventListener("drop", new EventDispatcher.EventCallback(this.method_30));
				this.mcShoeSlot.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_26));
				this.mcShoeSlot.addEventListener("slash", new EventDispatcher.EventCallback(this.method_27));
				this.mcShoeSlot.method_11(new GClass44.GDelegate2((MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InventoryView>() as uniInventoryView).method_21));
				flag = true;
				break;
			}
			case "mcPropertyPanel":
				this.mcPropertyPanel = movieClip;
				this.mcPropertyPanel.visible = false;
				this.method_21();
				this.method_22();
				flag = false;
				break;
			case "mcEquipmentPanel":
				this.mcEquipmentPanel = movieClip;
				this.mcEquipmentPanel.visible = true;
				flag = false;
				break;
			case "mcRoot":
				this.mcRoot = movieClip;
				flag = false;
				break;
			case "mcTitleBasic":
				movieClip.getChildByName<TextField>("textField").text = LocalizedString.smethod_0(new LocalizedString("BasicAttribute"));
				flag = true;
				break;
			case "mcTitlePVP":
				movieClip.getChildByName<TextField>("textField").text = LocalizedString.smethod_0(new LocalizedString("PVPAttribute"));
				flag = true;
				break;
			case "mcTitleAddition":
				movieClip.getChildByName<TextField>("textField").text = LocalizedString.smethod_0(new LocalizedString("BonuesAttribute"));
				flag = true;
				break;
			case "mcTitleWeapon":
				movieClip.getChildByName<TextField>("textField").text = LocalizedString.smethod_0(new LocalizedString("Weapon"));
				flag = true;
				break;
			case "mcTitleMOD":
				movieClip.getChildByName<TextField>("textField").text = LocalizedString.smethod_0(new LocalizedString("MOD"));
				flag = true;
				break;
			case "mcTitleOutfit":
				movieClip.getChildByName<TextField>("textField").text = LocalizedString.smethod_0(new LocalizedString("Outfit"));
				flag = true;
				break;
			case "mcPrice":
				movieClip.visible = false;
				this.mcPrice = movieClip;
				flag = true;
				break;
			}
			return flag;
		}

		// Token: 0x060035F6 RID: 13814 RVA: 0x000F786C File Offset: 0x000F5A6C
		private bool method_17(object object_0)
		{
			bool flag;
			try
			{
				if (object_0 == null)
				{
					flag = false;
				}
				else
				{
					UIItemSlotData uiitemSlotData = (UIItemSlotData)object_0;
					if (uiitemSlotData.item == null)
					{
						flag = false;
					}
					else
					{
						flag = uiitemSlotData.item.method_3(ItemType.Weapon);
					}
				}
			}
			catch (InvalidCastException)
			{
				flag = false;
			}
			return flag;
		}

		// Token: 0x060035F7 RID: 13815 RVA: 0x000F78B8 File Offset: 0x000F5AB8
		private bool method_18(object object_0)
		{
			bool flag;
			try
			{
				if (object_0 == null)
				{
					flag = false;
				}
				else
				{
					UIItemSlotData uiitemSlotData = (UIItemSlotData)object_0;
					if (uiitemSlotData.item == null)
					{
						flag = false;
					}
					else
					{
						flag = uiitemSlotData.item.method_3(ItemType.Shield);
					}
				}
			}
			catch (InvalidCastException)
			{
				flag = false;
			}
			return flag;
		}

		// Token: 0x060035F8 RID: 13816 RVA: 0x000F7904 File Offset: 0x000F5B04
		private bool method_19(object object_0)
		{
			bool flag;
			try
			{
				if (object_0 == null)
				{
					flag = false;
				}
				else
				{
					UIItemSlotData uiitemSlotData = (UIItemSlotData)object_0;
					if (uiitemSlotData.item == null)
					{
						flag = false;
					}
					else
					{
						flag = uiitemSlotData.item.method_3(ItemType.ClassMode);
					}
				}
			}
			catch (InvalidCastException)
			{
				flag = false;
			}
			return flag;
		}

		// Token: 0x060035F9 RID: 13817 RVA: 0x00023797 File Offset: 0x00021997
		private void method_20(CEvent cevent_0)
		{
			base.dispatchEvent(new CEvent("Model_" + cevent_0.type));
		}

		// Token: 0x060035FA RID: 13818 RVA: 0x000F7950 File Offset: 0x000F5B50
		private void method_21()
		{
			if (this.mcRoot != null)
			{
				UnityTextField unityTextField = this.mcPropertyPanel.getChildByName<UnityTextField>("hpTitle");
				if (unityTextField != null)
				{
					unityTextField.text = this.TITLE_HP;
				}
				unityTextField = this.mcPropertyPanel.getChildByName<UnityTextField>("shieldTitle");
				if (unityTextField != null)
				{
					unityTextField.text = this.TITLE_SHIELD;
				}
				unityTextField = this.mcPropertyPanel.getChildByName<UnityTextField>("damageTitle");
				if (unityTextField != null)
				{
					unityTextField.text = this.TITLE_DAMAGE;
				}
				unityTextField = this.mcPropertyPanel.getChildByName<UnityTextField>("criticalTitle");
				if (unityTextField != null)
				{
					unityTextField.text = this.TITLE_CRITICAL;
				}
			}
		}

		// Token: 0x060035FB RID: 13819 RVA: 0x000F79E8 File Offset: 0x000F5BE8
		private void method_22()
		{
			if (this._playerInfo != null)
			{
				if (this.mcRoot != null)
				{
					MovieClip movieClip = this.mcRoot.getChildByName<MovieClip>("mcIcon");
					if (movieClip != null)
					{
						movieClip = movieClip.getChildByName<MovieClip>("mcClassIcon");
						if (movieClip != null)
						{
							movieClip.gotoAndStop(this._playerInfo.m_avatarDna.method_5().ToString());
						}
					}
					UnityTextField unityTextField = this.mcRoot.getChildByName<UnityTextField>("tfLevel");
					if (unityTextField != null)
					{
						if (this.bGreenWord)
						{
							unityTextField.Color_0 = Color.green;
						}
						unityTextField.text = Utility.smethod_5("Lv. ", Utility.smethod_8(this._playerInfo.m_level));
					}
				}
				if (this.mcPropertyPanel != null && MonoSingleton<Session>.Instance.GetLocalPlayer())
				{
					EntityPlayer entityPlayer = MonoSingleton<Session>.Instance.GetLocalPlayer().GetEntity() as EntityPlayer;
					if (entityPlayer)
					{
						UnityTextField unityTextField = this.mcPropertyPanel.getChildByName<UnityTextField>("tfHP");
						if (unityTextField != null)
						{
							if (this.bGreenWord)
							{
								unityTextField.Color_0 = Color.green;
							}
							EquipmentInventoryEntity equipmentInventoryEntity = entityPlayer.vmethod_19();
							if (equipmentInventoryEntity != null)
							{
								unityTextField.text = equipmentInventoryEntity.vmethod_4().ToString();
							}
						}
						unityTextField = this.mcPropertyPanel.getChildByName<UnityTextField>("tfCritical");
						if (unityTextField != null)
						{
							unityTextField.text = entityPlayer.vmethod_61().ToString("p1");
						}
					}
				}
			}
		}

		// Token: 0x060035FC RID: 13820 RVA: 0x000F7B4C File Offset: 0x000F5D4C
		protected void method_23(CEvent cevent_0)
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
					uiitemSlotData2 = new UIItemSlotData(null, "character", (int)(gclass.target as GClass44).object_0, false);
				}
				if (this.swapFunc != null)
				{
					this.swapFunc(uiitemSlotData2, uiitemSlotData);
				}
			}
		}

		// Token: 0x060035FD RID: 13821 RVA: 0x000F7BCC File Offset: 0x000F5DCC
		protected void method_24(CEvent cevent_0)
		{
			GClass44 gclass = cevent_0.target as GClass44;
			if (this.iActivedIndex != (int)gclass.object_0)
			{
				gclass.method_16();
			}
		}

		// Token: 0x060035FE RID: 13822 RVA: 0x000F7C00 File Offset: 0x000F5E00
		protected void method_25(CEvent cevent_0)
		{
			GClass53 gclass = cevent_0 as GClass53;
			GClass44 gclass2 = gclass.target as GClass44;
			if (Input.GetKey(KeyCode.LeftShift))
			{
				UIItemSlotData uiitemSlotData = (UIItemSlotData)gclass2.Object_0;
				base.dispatchEvent(new GClass55("showWeaponModel", uiitemSlotData.item.method_6(), true, false));
			}
			else if (this.iActivedIndex != (int)gclass2.object_0)
			{
				gclass2.method_16();
			}
		}

		// Token: 0x060035FF RID: 13823 RVA: 0x000F7C74 File Offset: 0x000F5E74
		protected void method_26(CEvent cevent_0)
		{
			GClass44 gclass = cevent_0.target as GClass44;
			if (gclass != null)
			{
				gclass.method_16();
			}
		}

		// Token: 0x06003600 RID: 13824 RVA: 0x000F7C74 File Offset: 0x000F5E74
		protected void method_27(CEvent cevent_0)
		{
			GClass44 gclass = cevent_0.target as GClass44;
			if (gclass != null)
			{
				gclass.method_16();
			}
		}

		// Token: 0x06003601 RID: 13825 RVA: 0x000F7C98 File Offset: 0x000F5E98
		protected void method_28(CEvent cevent_0)
		{
			GClass55 gclass = cevent_0 as GClass55;
			if (gclass != null)
			{
				UIItemSlotData uiitemSlotData = (UIItemSlotData)((GStruct0)gclass.object_0).object_0;
				if (this.shieldFunc != null && uiitemSlotData.identifier == "inventory" && uiitemSlotData.item.method_3(ItemType.Shield))
				{
					this.shieldFunc(uiitemSlotData.index);
				}
			}
		}

		// Token: 0x06003602 RID: 13826 RVA: 0x000F7D04 File Offset: 0x000F5F04
		protected void method_29(CEvent cevent_0)
		{
			GClass55 gclass = cevent_0 as GClass55;
			if (gclass != null)
			{
				UIItemSlotData uiitemSlotData = (UIItemSlotData)((GStruct0)gclass.object_0).object_0;
				if (this.classModeFunc != null && uiitemSlotData.identifier == "inventory" && uiitemSlotData.item.method_3(ItemType.ClassMode))
				{
					this.classModeFunc(uiitemSlotData.index);
				}
			}
		}

		// Token: 0x06003603 RID: 13827 RVA: 0x000F7D70 File Offset: 0x000F5F70
		protected void method_30(CEvent cevent_0)
		{
			GClass55 gclass = cevent_0 as GClass55;
			if (gclass != null)
			{
				UIItemSlotData uiitemSlotData = (UIItemSlotData)((GStruct0)gclass.object_0).object_0;
				if (this.outFitFunc != null && uiitemSlotData.identifier == "inventory" && uiitemSlotData.item.method_3(ItemType.Outfit))
				{
					this.outFitFunc(uiitemSlotData.index);
				}
			}
		}

		// Token: 0x06003604 RID: 13828 RVA: 0x000237B5 File Offset: 0x000219B5
		protected void method_31(CEvent cevent_0)
		{
			if (this.mcEquipmentPanel != null && this.mcPropertyPanel != null)
			{
				this.mcEquipmentPanel.visible = this.mcTabRadio0.Boolean_3;
				this.mcPropertyPanel.visible = this.mcTabRadio1.Boolean_3;
			}
		}

		// Token: 0x06003605 RID: 13829 RVA: 0x000F7DDC File Offset: 0x000F5FDC
		protected void method_32(CEvent cevent_0)
		{
			GClass17 gclass = cevent_0.target as GClass17;
			if (gclass == null)
			{
				return;
			}
			if (this.activeFunc != null)
			{
				this.activeFunc((int)gclass.Object_0);
			}
		}

		// Token: 0x06003606 RID: 13830 RVA: 0x000237F3 File Offset: 0x000219F3
		protected void method_33(CEvent cevent_0)
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<CharInfoView>().Boolean_1 = false;
		}

		// Token: 0x06003607 RID: 13831 RVA: 0x0002380A File Offset: 0x00021A0A
		protected void method_34()
		{
			this.mcRootMovie.visible = true;
			this.mcRootMovie.gotoAndPlay("Open");
		}

		// Token: 0x06003608 RID: 13832 RVA: 0x00023828 File Offset: 0x00021A28
		protected void method_35()
		{
			this.mcRootMovie.gotoAndPlay("Close");
			this.mcRootMovie.addFrameScript("End", new EventDispatcher.EventCallback(this.method_36));
		}

		// Token: 0x06003609 RID: 13833 RVA: 0x00023857 File Offset: 0x00021A57
		protected void method_36(CEvent cevent_0)
		{
			this.mcRootMovie.removeEventListener("End", new EventDispatcher.EventCallback(this.method_36));
			this.mcRootMovie.visible = false;
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this);
		}

		private void method_37(CEvent cevent_0)
		{
			GClass44 gclass = cevent_0.target as GClass44;
			if (gclass != null)
			{
				UIItemSlotData uiitemSlotData = gclass.Object_0 as UIItemSlotData;
				if (uiitemSlotData != null)
				{
					MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InventoryView>().method_18(uiitemSlotData);
				}
			}
		}

		// Token: 0x0400254F RID: 9551
		public uniCharInfoView.Item_SWAP_Delegate swapFunc;

		// Token: 0x04002550 RID: 9552
		public uniCharInfoView.Index_Delegate activeFunc;

		// Token: 0x04002551 RID: 9553
		public uniCharInfoView.Index_Delegate shieldFunc;

		// Token: 0x04002552 RID: 9554
		public uniCharInfoView.Index_Delegate classModeFunc;

		// Token: 0x04002553 RID: 9555
		public uniCharInfoView.Index_Delegate outFitFunc;

		// Token: 0x04002554 RID: 9556
		protected MovieClip mcRootMovie;

		// Token: 0x04002555 RID: 9557
		protected MovieClip mcRoot;

		// Token: 0x04002556 RID: 9558
		protected MovieClip mcPrice;

		// Token: 0x04002557 RID: 9559
		protected GClass44 mcShieldSlot;

		// Token: 0x04002558 RID: 9560
		protected GClass44 mcClassModeSlot;

		// Token: 0x04002559 RID: 9561
		protected GClass44 mcGranedeSlot;

		// Token: 0x0400255A RID: 9562
		protected GClass44 mcHairSlot;

		// Token: 0x0400255B RID: 9563
		protected GClass44 mcMaskSlot;

		// Token: 0x0400255C RID: 9564
		protected GClass44 mcBodySlot;

		// Token: 0x0400255D RID: 9565
		protected GClass44 mcPantsSlot;

		// Token: 0x0400255E RID: 9566
		protected GClass44 mcShoeSlot;

		// Token: 0x0400255F RID: 9567
		protected GClass44[] _arrItemSlots;

		// Token: 0x04002560 RID: 9568
		protected GClass40[] _arrCheckBoxes;

		// Token: 0x04002561 RID: 9569
		protected TextField mcPlayerName;

		// Token: 0x04002562 RID: 9570
		protected GClass25 mcDetailBtn;

		// Token: 0x04002563 RID: 9571
		protected GClass43 mc3DAvatar;

		// Token: 0x04002564 RID: 9572
		protected MovieClip mcAvatar;

		// Token: 0x04002565 RID: 9573
		public int SLOT_NUM = 4;

		// Token: 0x04002566 RID: 9574
		private string ITEM_SLOT_PREFIX_NAME = "mcItemSlot";

		// Token: 0x04002567 RID: 9575
		private string ITEM_CHECKBOX_PREFIX_NAME = "mcCheck";

		// Token: 0x04002568 RID: 9576
		private PlayerProperties _playerInfo;

		// Token: 0x04002569 RID: 9577
		protected GClass25 mcXButton;

		// Token: 0x0400256A RID: 9578
		protected GClass40 mcTabRadio0;

		// Token: 0x0400256B RID: 9579
		protected GClass40 mcTabRadio1;

		// Token: 0x0400256C RID: 9580
		protected MovieClip mcEquipmentPanel;

		// Token: 0x0400256D RID: 9581
		protected MovieClip mcPropertyPanel;

		// Token: 0x0400256E RID: 9582
		protected string TITLE_HP;

		// Token: 0x0400256F RID: 9583
		protected string TITLE_SHIELD;

		// Token: 0x04002570 RID: 9584
		protected string TITLE_DAMAGE;

		// Token: 0x04002571 RID: 9585
		protected string TITLE_CRITICAL;

		// Token: 0x04002572 RID: 9586
		private StringBuilder sbExtraAtt = new StringBuilder();

		// Token: 0x04002573 RID: 9587
		private StringBuilder m_stringbuilder = new StringBuilder(32, 32);
	}

	// Token: 0x020007D9 RID: 2009
	// (Invoke) Token: 0x0600360B RID: 13835
	public delegate void Item_SWAP_Delegate(UIItemSlotData target, UIItemSlotData from);

	// Token: 0x020007DA RID: 2010
	// (Invoke) Token: 0x0600360F RID: 13839
	public delegate void Index_Delegate(int index);
}
