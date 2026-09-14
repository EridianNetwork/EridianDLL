using System;
using System.Collections.Generic;
using ns0;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;
using UnityEngine;
using XsdSettings;

// Token: 0x020008C1 RID: 2241
public class uniWeaponUpgradeView : WeaponUpgradeView
{
	// Token: 0x06003DD9 RID: 15833 RVA: 0x00126FE4 File Offset: 0x001251E4
	public override void vmethod_2()
	{
		base.vmethod_2();
		MonoSingleton<AppManager>.Instance.method_0().method_3(this, new Vector2(753f, 23f));
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("Weapon_upgrade.swf", "WeaponUpgradePanel", new FuncLoad(this.method_5));
		this._inventoryPanel = (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InventoryView>() as uniInventoryView).InventoryPanel_0;
	}

	// Token: 0x06003DDA RID: 15834 RVA: 0x00127060 File Offset: 0x00125260
	private void method_5(MovieClip movieClip_0)
	{
		this._panel = new uniWeaponUpgradeView.WeaponUpgradePanel();
		this._panel.method_0(movieClip_0);
		this._panel.DisplayObjectContainer_0.visible = false;
		this._panel.inventoryView = MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InventoryView>() as uniInventoryView;
		this._panel.addEventListener("ADD_WEAPON_EXPERIENCE", new EventDispatcher.EventCallback(this.OnAddExperience));
		this._panel.addEventListener("ADD_WEAPON_GRADE", new EventDispatcher.EventCallback(this.OnAddWeaponGrade));
	}

	// Token: 0x06003DDB RID: 15835 RVA: 0x00029C3C File Offset: 0x00027E3C
	public override void vmethod_5()
	{
		base.vmethod_5();
		this.weaponIndex = -1;
		this.vmethod_14(null, true, true);
		this._panel.method_23();
	}

	// Token: 0x06003DDC RID: 15836 RVA: 0x001270F0 File Offset: 0x001252F0
	public override void vmethod_3()
	{
		base.vmethod_3();
		this._inventoryPanel = null;
		this._panel.inventoryView = null;
		if (this._panel != null)
		{
			this._panel.method_5();
		}
		MaskManager.smethod_0().method_2();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._panel);
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("Weapon_upgrade.swf");
	}

	// Token: 0x06003DDD RID: 15837 RVA: 0x00029C5F File Offset: 0x00027E5F
	protected override void vmethod_12()
	{
		base.vmethod_12();
		this._panel.method_22();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("UI_Wep_Upgrade_Glow_Success");
	}

	// Token: 0x06003DDE RID: 15838 RVA: 0x00029C8B File Offset: 0x00027E8B
	protected override void vmethod_13()
	{
		base.vmethod_13();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("UI_Wep_Upgrade_Glow_Fail");
	}

	// Token: 0x06003DDF RID: 15839 RVA: 0x00029CAC File Offset: 0x00027EAC
	public override void vmethod_10()
	{
		this._panel.method_25();
		this._panel.method_27();
	}

	// Token: 0x06003DE0 RID: 15840 RVA: 0x00029CC4 File Offset: 0x00027EC4
	public override void vmethod_11()
	{
		this._panel.method_26();
		this._panel.method_28();
	}

	// Token: 0x06003DE1 RID: 15841 RVA: 0x00127168 File Offset: 0x00125368
	public override void vmethod_14(ItemDNA itemDNA_0, bool bool_0 = true, bool bool_1 = true)
	{
		base.vmethod_14(itemDNA_0, bool_0, bool_1);
		if (itemDNA_0 != null)
		{
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("UI_Wep_Upgrade_SelectWep");
			this._panel.method_7(itemDNA_0.method_6(), bool_1);
		}
		else
		{
			this._panel.method_8();
		}
	}

	// Token: 0x06003DE2 RID: 15842 RVA: 0x00029CDC File Offset: 0x00027EDC
	private void method_6(WeaponDNA weaponDNA_0)
	{
		this._panel.method_12(weaponDNA_0);
	}

	// Token: 0x06003DE3 RID: 15843 RVA: 0x00029CEA File Offset: 0x00027EEA
	private void OnAddExperience(CEvent evt)
	{
		this.vmethod_6();
	}

	// Token: 0x06003DE4 RID: 15844 RVA: 0x00029CF2 File Offset: 0x00027EF2
	private void OnAddWeaponGrade(CEvent evt)
	{
		this.vmethod_7();
	}

	// Token: 0x06003DE5 RID: 15845 RVA: 0x00029CFA File Offset: 0x00027EFA
	public override void OnExperienceUpdate(ItemDNA newWeapon)
	{
		base.OnExperienceUpdate(newWeapon);
		if (newWeapon != null)
		{
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("UI_Wep_Upgrade_Charging_Rnd");
		}
	}

	// Token: 0x06003DE6 RID: 15846 RVA: 0x001271BC File Offset: 0x001253BC
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		base.vmethod_1(bool_0, bool_1);
		if (bool_0)
		{
			MonoSingleton<AppManager>.Instance.GetComponent<UniUIManager>().method_31(this._panel);
		}
		else
		{
			MonoSingleton<AppManager>.Instance.GetComponent<UniUIManager>().method_37(this._panel);
		}
		this._panel.DisplayObjectContainer_0.visible = this._bVisible;
		if (this._inventoryPanel == null)
		{
			this._inventoryPanel = (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InventoryView>() as uniInventoryView).InventoryPanel_0;
			this._panel.inventoryView = MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InventoryView>() as uniInventoryView;
		}
		if (this._inventoryPanel != null)
		{
			if (this._bVisible)
			{
				this._inventoryPanel.addEventListener("Item" + MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_7));
				this._inventoryPanel.addEventListener("Item" + GClass53.string_0, new EventDispatcher.EventCallback(this.method_8));
				this._inventoryPanel.addEventListener("Item" + MouseEvent.MOUSE_ENTER, new EventDispatcher.EventCallback(this.method_9));
				this._inventoryPanel.addEventListener("Item" + MouseEvent.MOUSE_LEAVE, new EventDispatcher.EventCallback(this.method_10));
				(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("UI_BackMenu_Open_Main");
			}
			else
			{
				this._inventoryPanel.removeEventListener("Item" + MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_7));
				this._inventoryPanel.removeEventListener("Item" + GClass53.string_0, new EventDispatcher.EventCallback(this.method_8));
				this._inventoryPanel.removeEventListener("Item" + MouseEvent.MOUSE_ENTER, new EventDispatcher.EventCallback(this.method_9));
				this._inventoryPanel.removeEventListener("Item" + MouseEvent.MOUSE_LEAVE, new EventDispatcher.EventCallback(this.method_10));
				(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("UI_BackMenu_Close_Main");
			}
		}
	}

	// Token: 0x06003DE7 RID: 15847 RVA: 0x001273E4 File Offset: 0x001255E4
	protected void method_7(CEvent cevent_0)
	{
		if (this._panel.method_6())
		{
			return;
		}
		GClass55 gclass = cevent_0 as GClass55;
		UIItemSlotData uiitemSlotData = (UIItemSlotData)gclass.object_0;
		if (uiitemSlotData.item.method_3(ItemType.Weapon))
		{
			this.weaponIndex = uiitemSlotData.index;
			this.method_6(uiitemSlotData.item.method_6());
			this.vmethod_14(uiitemSlotData.item, true, true);
		}
	}

	// Token: 0x06003DE8 RID: 15848 RVA: 0x0000311B File Offset: 0x0000131B
	protected void method_8(CEvent cevent_0)
	{
	}

	// Token: 0x06003DE9 RID: 15849 RVA: 0x0000311B File Offset: 0x0000131B
	protected void method_9(CEvent cevent_0)
	{
	}

	// Token: 0x06003DEA RID: 15850 RVA: 0x0000311B File Offset: 0x0000131B
	protected void method_10(CEvent cevent_0)
	{
	}

	// Token: 0x04002BA1 RID: 11169
	private uniInventoryView.InventoryPanel _inventoryPanel;

	// Token: 0x04002BA2 RID: 11170
	private uniWeaponUpgradeView.WeaponUpgradePanel _panel;

	// Token: 0x020008C2 RID: 2242
	private class WeaponUpgradePanel : GClass51
	{
		// Token: 0x06003DED RID: 15853 RVA: 0x0012744C File Offset: 0x0012564C
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.tips = new Dictionary<MovieClip, GClass24>();
			this.mcRootMovie = base.DisplayObjectContainer_0 as MovieClip;
			this.mcRootMovie.addEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.OnEnterFrame));
		}

		// Token: 0x06003DEE RID: 15854 RVA: 0x00029D35 File Offset: 0x00027F35
		public void method_5()
		{
			if (this.tips != null)
			{
				this.tips.Clear();
			}
		}

		// Token: 0x06003DEF RID: 15855 RVA: 0x00029D4A File Offset: 0x00027F4A
		public bool method_6()
		{
			return this._processing;
		}

		// Token: 0x06003DF0 RID: 15856 RVA: 0x00127498 File Offset: 0x00125698
		public void method_7(WeaponDNA weaponDNA_0, bool bool_0)
		{
			this.currentLevel = weaponDNA_0.m_starLevel;
			if (bool_0)
			{
				this.method_14(weaponDNA_0.m_starLevel);
			}
			this.method_13(weaponDNA_0);
			this.method_11(weaponDNA_0);
			this.method_20(weaponDNA_0);
			if (bool_0)
			{
				this.method_16(weaponDNA_0);
			}
			this.method_27();
		}

		// Token: 0x06003DF1 RID: 15857 RVA: 0x00029D52 File Offset: 0x00027F52
		public void method_8()
		{
			this.method_14(0);
			this.method_13(null);
			this.method_10();
			this.method_19();
			this.method_28();
		}

		// Token: 0x06003DF2 RID: 15858 RVA: 0x001274E8 File Offset: 0x001256E8
		private string method_9(List<SingleWeaponAttribute> list_1, ItemElement itemElement_0)
		{
			string text = string.Empty;
			for (int i = 0; i < list_1.Count; i++)
			{
				if (itemElement_0.aType == list_1[i].m_attributeType)
				{
					if (list_1[i].m_affectType == AffectType.Scale)
					{
						text = Utility.smethod_5(Utility.smethod_9(Mathf.Abs(list_1[i].m_value) * 100f), "%");
					}
					else if (list_1[i].m_affectType == AffectType.PostAdd)
					{
						text = list_1[i].m_value.ToString();
					}
				}
			}
			return text;
		}

		// Token: 0x06003DF3 RID: 15859 RVA: 0x00127580 File Offset: 0x00125780
		public void method_10()
		{
			MovieClip movieClip = this._detailMC.getChildByName("mcBody") as MovieClip;
			TextField textField = movieClip.getChildByName("txTitle") as TextField;
			textField.text = LocalizedString.smethod_0(new LocalizedString("Weapon_Upgrade_Preview"));
			TextField textField2 = movieClip.getChildByName("txName") as TextField;
			textField2.text = string.Empty;
			TextField textField3 = movieClip.getChildByName("txLevelNumber") as TextField;
			textField3.text = string.Empty;
			TextField textField4 = movieClip.getChildByName("txLevelLabel") as TextField;
			textField4.visible = false;
			MovieClip movieClip2 = movieClip.getChildByName("mcType") as MovieClip;
			movieClip2.visible = false;
			MovieClip movieClip3 = movieClip.getChildByName("gunbrand") as MovieClip;
			movieClip3.visible = false;
			for (int i = 0; i < uniWeaponUpgradeView.WeaponUpgradePanel.MAX_WEAPON_ATTRIBUTE; i++)
			{
				MovieClip movieClip4 = movieClip.getChildByName("mcDownElem" + i) as MovieClip;
				movieClip4.visible = false;
			}
			for (int j = 0; j < uniWeaponUpgradeView.WeaponUpgradePanel.MAX_WEAPON_EXTRA_INFO; j++)
			{
				UnityTextField unityTextField = movieClip.getChildByName("tfDesc" + j) as UnityTextField;
				unityTextField.visible = false;
			}
		}

		// Token: 0x06003DF4 RID: 15860 RVA: 0x001276C4 File Offset: 0x001258C4
		public void method_11(WeaponDNA weaponDNA_0)
		{
			ItemTipsData itemTipsData = ItemCardPanel.smethod_2(weaponDNA_0, null, true);
			List<SingleWeaponAttribute> list = StarLevelAttributeStore.StarLevelAttributeStore_0.method_0(weaponDNA_0.method_1(), weaponDNA_0.m_starLevel);
			MovieClip movieClip = this._detailMC.getChildByName("mcBody") as MovieClip;
			TextField textField = movieClip.getChildByName("txTitle") as TextField;
			if (weaponDNA_0.m_starLevel < uniWeaponUpgradeView.WeaponUpgradePanel.MAX_LEVEL)
			{
				textField.text = weaponDNA_0.m_starLevel + 1 + LocalizedString.smethod_0(new LocalizedString("Weapon_Upgrade_Star_Preview"));
			}
			else
			{
				textField.text = LocalizedString.smethod_0(new LocalizedString("Weapon_Upgrade_Max"));
			}
			UnityTextField unityTextField = movieClip.getChildByName("txName") as UnityTextField;
			unityTextField.text = itemTipsData.name;
			unityTextField.Color_0 = itemTipsData.nameColor;
			TextField textField2 = movieClip.getChildByName("txLevelNumber") as TextField;
			textField2.text = Utility.smethod_8(itemTipsData.level);
			TextField textField3 = movieClip.getChildByName("txLevelLabel") as TextField;
			textField3.visible = true;
			MovieClip movieClip2 = movieClip.getChildByName("mcType") as MovieClip;
			movieClip2.gotoAndStop(Utility.smethod_5("Weapon_", weaponDNA_0.method_1().ToString()));
			movieClip2.visible = true;
			MovieClip movieClip3 = movieClip.getChildByName("gunbrand") as MovieClip;
			movieClip3.gotoAndStop(itemTipsData.brand);
			movieClip3.visible = true;
			for (int i = 0; i < uniWeaponUpgradeView.WeaponUpgradePanel.MAX_WEAPON_ATTRIBUTE; i++)
			{
				MovieClip movieClip4 = movieClip.getChildByName("mcDownElem" + i) as MovieClip;
				if (i < itemTipsData.attributeList.Count)
				{
					movieClip4.visible = true;
					UnityTextField unityTextField2 = movieClip4.getChildByName("title") as UnityTextField;
					unityTextField2.text = itemTipsData.attributeList[i].title;
					unityTextField2 = movieClip4.getChildByName("value") as UnityTextField;
					string text = string.Empty;
					text = this.method_9(list, itemTipsData.attributeList[i]);
					unityTextField2.text = itemTipsData.attributeList[i].value.ToString();
					unityTextField2 = movieClip4.getChildByName("delta") as UnityTextField;
					MovieClip movieClip5 = movieClip4.getChildByName("arrow") as MovieClip;
					if (text != string.Empty)
					{
						unityTextField2.visible = true;
						unityTextField2.text = text;
						movieClip5.gotoAndStop("up");
					}
					else
					{
						unityTextField2.visible = false;
						movieClip5.gotoAndStop("none");
					}
					MovieClip movieClip6 = movieClip4.getChildByName("iconType") as MovieClip;
					movieClip6.gotoAndStop(itemTipsData.attributeList[i].iconType);
				}
				else
				{
					movieClip4.visible = false;
				}
			}
			for (int j = 0; j < uniWeaponUpgradeView.WeaponUpgradePanel.MAX_WEAPON_EXTRA_INFO; j++)
			{
				UnityTextField unityTextField3 = movieClip.getChildByName("tfDesc" + j) as UnityTextField;
				if (j < itemTipsData.additionAttList.Count)
				{
					unityTextField3.visible = true;
					unityTextField3.text = itemTipsData.additionAttList[j].value.ToString();
				}
				else
				{
					unityTextField3.visible = false;
				}
			}
		}

		// Token: 0x06003DF5 RID: 15861 RVA: 0x00127A0C File Offset: 0x00125C0C
		public void method_12(WeaponDNA weaponDNA_0)
		{
			if (weaponDNA_0.m_starExperience >= StarLevelAttributeStore.StarLevelAttributeStore_0.method_1(weaponDNA_0.method_1(), weaponDNA_0.m_starLevel, weaponDNA_0.m_level, weaponDNA_0.m_rarity) && weaponDNA_0.m_starExperience > 0 && weaponDNA_0.m_starLevel < uniWeaponUpgradeView.WeaponUpgradePanel.MAX_LEVEL)
			{
				this._intensityMC.visible = true;
				this._intensityMC.gotoAndStop("normal");
				this._rechargeMC.visible = false;
				this._rechargeMC.stop();
			}
			else
			{
				this._intensityMC.visible = false;
				this._rechargeMC.visible = true;
				this._rechargeMC.gotoAndStop("normal");
				this._intensityMC.stop();
			}
		}

		// Token: 0x06003DF6 RID: 15862 RVA: 0x00127AC4 File Offset: 0x00125CC4
		private void method_13(WeaponDNA weaponDNA_0)
		{
			TextField textField = this._progressBar.getChildByName("txtExperience") as TextField;
			if (weaponDNA_0 != null)
			{
				if (weaponDNA_0.m_starLevel < uniWeaponUpgradeView.WeaponUpgradePanel.MAX_LEVEL)
				{
					this.upgradeMaxExp = StarLevelAttributeStore.StarLevelAttributeStore_0.method_1(weaponDNA_0.method_1(), weaponDNA_0.m_starLevel, weaponDNA_0.m_level, weaponDNA_0.m_rarity);
					float num = (float)this.upgradeMaxExp;
					float num2 = ((num != 0f) ? ((float)weaponDNA_0.m_starExperience / num) : 0f);
					this.method_15(num2, true);
					textField.text = weaponDNA_0.m_starExperience + "/" + this.upgradeMaxExp;
					this._addEnergy.Boolean_1 = true;
				}
				else
				{
					float num2 = 1f;
					this.upgradeMaxExp = StarLevelAttributeStore.StarLevelAttributeStore_0.method_1(weaponDNA_0.method_1(), weaponDNA_0.m_starLevel - 1, weaponDNA_0.m_level, weaponDNA_0.m_rarity);
					this.method_15(num2, false);
					this._addEnergy.Boolean_1 = false;
					textField.text = this.upgradeMaxExp + "/" + this.upgradeMaxExp;
				}
			}
			else
			{
				this.method_15(0f, false);
				textField.text = "0/0";
				this._intensityMC.visible = false;
				this._rechargeMC.visible = true;
			}
		}

		// Token: 0x06003DF7 RID: 15863 RVA: 0x00127C28 File Offset: 0x00125E28
		public void method_14(int int_0)
		{
			MovieClip movieClip = this._levelIndicatorMC.getChildByName("mcBody") as MovieClip;
			for (int i = 1; i <= uniWeaponUpgradeView.WeaponUpgradePanel.MAX_LEVEL; i++)
			{
				MovieClip movieClip2 = movieClip.getChildByName("s" + i) as MovieClip;
				if (i <= this.currentLevel)
				{
					movieClip2.gotoAndStop("upgraded");
				}
				else
				{
					movieClip2.gotoAndStop("unupgrade");
				}
			}
		}

		// Token: 0x06003DF8 RID: 15864 RVA: 0x00127C98 File Offset: 0x00125E98
		public void method_15(float float_0, bool bool_0)
		{
			this._progressBar.gotoAndStop((int)(Mathf.Min(float_0, 1f) * 50f));
			if (float_0 >= 1f)
			{
				if (bool_0)
				{
					this._progressBar.gotoAndPlay("full");
					(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("UI_Wep_Upgrade_Charge_Complete");
				}
				else
				{
					this._progressBar.gotoAndStop("full");
				}
			}
		}

		// Token: 0x06003DF9 RID: 15865 RVA: 0x00127D10 File Offset: 0x00125F10
		public void method_16(WeaponDNA weaponDNA_0)
		{
			MovieClip movieClip = (MovieClip)this._intensityMC.getChildByName("mcBody").getChildByName("mcMaterial");
			ItemConsume itemConsume = StarLevelAttributeStore.StarLevelAttributeStore_0.method_3(weaponDNA_0.method_1(), weaponDNA_0.m_starLevel);
			if (itemConsume != null)
			{
				this.method_17(movieClip, itemConsume.m_materialType, itemConsume.m_materialNums, ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_33(itemConsume.m_materialType));
				this._intensityWeapon.String_2 = Utility.smethod_5("$", Utility.smethod_8(itemConsume.m_itemNums));
			}
		}

		// Token: 0x06003DFA RID: 15866 RVA: 0x00127D9C File Offset: 0x00125F9C
		private void method_17(MovieClip movieClip_0, MaterialType materialType_0, int int_0, int int_1)
		{
			TextField textField = (TextField)movieClip_0.getChildByName("textNumber");
			ItemDNA itemDNA = ItemDNA.smethod_3(materialType_0, 1);
			if (int_1 < int_0)
			{
				textField.text = Utility.smethod_5(Utility.smethod_6("<color=red>", Utility.smethod_8(int_1), "</color>/"), Utility.smethod_8(int_0));
			}
			else
			{
				textField.text = Utility.smethod_6(Utility.smethod_8(int_1), "/", Utility.smethod_8(int_0));
			}
			if (!this.tips.ContainsKey(movieClip_0))
			{
				this.tips.Add(movieClip_0, new GClass24());
				this.tips[movieClip_0].method_0(movieClip_0);
			}
			this.tips[movieClip_0].GInterface1_0 = new ItemTips(itemDNA);
			textField.visible = true;
			movieClip_0 = movieClip_0.getChildByName("icon") as MovieClip;
			while (movieClip_0.numChildren != 0)
			{
				movieClip_0.removeChildAt(0);
			}
			MovieClip movieClip = this.inventoryView.method_23(itemDNA);
			movieClip_0.addChild(movieClip);
		}

		// Token: 0x06003DFB RID: 15867 RVA: 0x00127E98 File Offset: 0x00126098
		private void method_18(MovieClip movieClip_0)
		{
			TextField textField = (TextField)movieClip_0.getChildByName("textNumber");
			textField.text = "0/0";
			textField.visible = false;
			movieClip_0 = movieClip_0.getChildByName("icon") as MovieClip;
			while (movieClip_0.numChildren != 0)
			{
				movieClip_0.removeChildAt(0);
			}
		}

		// Token: 0x06003DFC RID: 15868 RVA: 0x00127EF0 File Offset: 0x001260F0
		public void method_19()
		{
			MovieClip movieClip = (MovieClip)this._rechargeMC.getChildByName("mcBody").getChildByName("mcRechargeMaterailA");
			MovieClip movieClip2 = (MovieClip)this._rechargeMC.getChildByName("mcBody").getChildByName("mcRechargeMaterailB");
			this.method_18(movieClip);
			this.method_18(movieClip2);
		}

		// Token: 0x06003DFD RID: 15869 RVA: 0x00127F4C File Offset: 0x0012614C
		public void method_20(WeaponDNA weaponDNA_0)
		{
			MovieClip movieClip = (MovieClip)this._rechargeMC.getChildByName("mcBody").getChildByName("mcRechargeMaterailA");
			ConsumedMaterial[] array = StarLevelAttributeStore.StarLevelAttributeStore_0.method_2(weaponDNA_0.method_1());
			if (array.Length > 0)
			{
				this.method_17(movieClip, array[0].m_consumedMaterialType, array[0].m_consumedMaterialNums, ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_33(array[0].m_consumedMaterialType));
			}
			MovieClip movieClip2 = (MovieClip)this._rechargeMC.getChildByName("mcBody").getChildByName("mcRechargeMaterailB");
			if (array.Length > 1)
			{
				movieClip2.visible = true;
				this.method_17(movieClip2, array[1].m_consumedMaterialType, array[1].m_consumedMaterialNums, ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_33(array[1].m_consumedMaterialType));
			}
			else
			{
				movieClip2.visible = false;
			}
		}

		// Token: 0x06003DFE RID: 15870 RVA: 0x00128018 File Offset: 0x00126218
		private void method_21(CEvent cevent_0)
		{
			this.deltaTime += Time.deltaTime;
			if (this.deltaTime >= 1.5f)
			{
				this.method_14(this.currentLevel);
				if (this.currentLevel <= uniWeaponUpgradeView.WeaponUpgradePanel.MAX_LEVEL)
				{
					MovieClip movieClip = (MovieClip)this._levelIndicatorMC.getChildByName("mcBody").getChildByName("s" + this.currentLevel);
					movieClip.gotoAndPlay("upgraded");
				}
				this.mcRootMovie.removeEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_21));
			}
		}

		// Token: 0x06003DFF RID: 15871 RVA: 0x00029D74 File Offset: 0x00027F74
		public void method_22()
		{
			this.deltaTime = 0f;
			this.mcRootMovie.addEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_21));
			this._intensityMC.gotoAndPlay("fadeout");
		}

		// Token: 0x06003E00 RID: 15872 RVA: 0x001280B8 File Offset: 0x001262B8
		public void method_23()
		{
			this._detailMC.gotoAndPlay("fadein");
			this._intensityMC.gotoAndPlay("fadein");
			this._rechargeMC.gotoAndPlay("fadein");
			this._levelIndicatorMC.gotoAndPlay("fadein");
			this._processing = false;
		}

		// Token: 0x06003E01 RID: 15873 RVA: 0x0012810C File Offset: 0x0012630C
		public void method_24()
		{
			this._detailMC.gotoAndPlay("fadeout");
			this._intensityMC.gotoAndPlay("fadeout");
			this._rechargeMC.gotoAndPlay("fadeout");
			this._levelIndicatorMC.gotoAndPlay("fadeout");
		}

		// Token: 0x06003E02 RID: 15874 RVA: 0x0012815C File Offset: 0x0012635C
		private void OnFadeoutComplete(CEvent evt)
		{
			MovieClip movieClip = evt.currentTarget as MovieClip;
			movieClip.visible = false;
		}

		// Token: 0x06003E03 RID: 15875 RVA: 0x00029DAE File Offset: 0x00027FAE
		private void OnIntensityPanelFadeout(CEvent evt)
		{
			this._rechargeMC.visible = true;
			this._intensityMC.visible = false;
			this._rechargeMC.gotoAndPlay("fadein");
		}

		// Token: 0x06003E04 RID: 15876 RVA: 0x00029DD8 File Offset: 0x00027FD8
		private void OnRechargePanelFadeout(CEvent evt)
		{
			this._rechargeMC.visible = false;
			if (!this._intensityMC.visible)
			{
				this._intensityMC.visible = true;
				this._intensityMC.gotoAndPlay("fadein");
			}
		}

		// Token: 0x06003E05 RID: 15877 RVA: 0x00029E0F File Offset: 0x0002800F
		public void method_25()
		{
			this._processing = false;
		}

		// Token: 0x06003E06 RID: 15878 RVA: 0x00029E18 File Offset: 0x00028018
		public void method_26()
		{
			this._processing = true;
		}

		// Token: 0x06003E07 RID: 15879 RVA: 0x00029E21 File Offset: 0x00028021
		public void method_27()
		{
			this._intensityWeapon.Boolean_6 = true;
			this._addEnergy.Boolean_6 = true;
		}

		// Token: 0x06003E08 RID: 15880 RVA: 0x00029E3B File Offset: 0x0002803B
		public void method_28()
		{
			this._intensityWeapon.Boolean_6 = false;
			this._addEnergy.Boolean_6 = false;
		}

		// Token: 0x06003E09 RID: 15881 RVA: 0x00029E55 File Offset: 0x00028055
		private void OnProgressBarFadeoutComplete(CEvent evt)
		{
			this._rechargeMC.gotoAndPlay("fadeout");
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("UI_Panel_Movement");
		}

		// Token: 0x06003E0A RID: 15882 RVA: 0x00029E80 File Offset: 0x00028080
		private void OnEnterFrame(CEvent evt)
		{
			MaskManager.smethod_0().Update(this._progressMask);
		}

		// Token: 0x06003E0B RID: 15883 RVA: 0x0012817C File Offset: 0x0012637C
		private void method_29()
		{
			MovieClip movieClip = this._progressBar.getChildByName("mcProgressBar") as MovieClip;
			this._progressMask = this._progressBar.getChildByName("mcProgressMask") as MovieClip;
			this._progressBar.stop();
			MaskManager.smethod_0().method_0(this._progressMask, new MovieClip[] { movieClip });
		}

		// Token: 0x06003E0C RID: 15884 RVA: 0x00029E92 File Offset: 0x00028092
		private void OnAddExperience(CEvent evt)
		{
			base.dispatchEvent(new CEvent("ADD_WEAPON_EXPERIENCE"));
		}

		// Token: 0x06003E0D RID: 15885 RVA: 0x00029EA5 File Offset: 0x000280A5
		private void OnIntensityWeapon(CEvent evt)
		{
			base.dispatchEvent(new CEvent("ADD_WEAPON_GRADE"));
		}

		// Token: 0x06003E0E RID: 15886 RVA: 0x001281E0 File Offset: 0x001263E0
		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			bool flag = false;
			string name = movieClip.name;
			switch (name)
			{
			case "mcStar":
				this._levelIndicatorMC = movieClip;
				flag = true;
				break;
			case "mcDetail":
				this._detailMC = movieClip;
				flag = true;
				break;
			case "mcRecharge":
				this._rechargeMC = movieClip;
				this._rechargeMC.addFrameScript("end", new EventDispatcher.EventCallback(this.OnRechargePanelFadeout));
				this._progressBar = (MovieClip)this._rechargeMC.getChildByName("mcBody").getChildByName("mcRechargeBar");
				this._progressBar.addFrameScript("fulled", new EventDispatcher.EventCallback(this.OnProgressBarFadeoutComplete));
				this.method_29();
				flag = false;
				break;
			case "mcIntensity":
				this._intensityMC = movieClip;
				this._intensityMC.addFrameScript("end", new EventDispatcher.EventCallback(this.OnIntensityPanelFadeout));
				flag = false;
				break;
			case "btnRight":
				this._addEnergy = new GClass25();
				this._addEnergy.method_0(movieClip);
				this._addEnergy.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.OnAddExperience));
				flag = true;
				break;
			case "mcPurchase":
				this._purchaseMaterial = new GClass25();
				this._purchaseMaterial.method_0(movieClip);
				flag = true;
				break;
			case "mcUpgrade":
				this._intensityWeapon = new GClass25();
				this._intensityWeapon.method_0(movieClip);
				this._intensityWeapon.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.OnIntensityWeapon));
				flag = true;
				break;
			}
			return flag;
		}

		// Token: 0x04002BA3 RID: 11171
		private MovieClip _detailMC;

		// Token: 0x04002BA4 RID: 11172
		private MovieClip _intensityMC;

		// Token: 0x04002BA5 RID: 11173
		private MovieClip _rechargeMC;

		// Token: 0x04002BA6 RID: 11174
		private MovieClip _levelIndicatorMC;

		// Token: 0x04002BA7 RID: 11175
		private MovieClip _progressBar;

		// Token: 0x04002BA8 RID: 11176
		private MovieClip _progressMask;

		// Token: 0x04002BA9 RID: 11177
		private bool _processing;

		// Token: 0x04002BAA RID: 11178
		private GClass25 _addEnergy;

		// Token: 0x04002BAB RID: 11179
		private GClass25 _purchaseMaterial;

		// Token: 0x04002BAC RID: 11180
		private GClass25 _intensityWeapon;

		// Token: 0x04002BAD RID: 11181
		public MovieClip mcRootMovie;

		// Token: 0x04002BAE RID: 11182
		public uniInventoryView inventoryView;

		// Token: 0x04002BAF RID: 11183
		private int currentLevel;

		// Token: 0x04002BB0 RID: 11184
		private Dictionary<MovieClip, GClass24> tips;

		// Token: 0x04002BB1 RID: 11185
		private int upgradeMaxExp;

		// Token: 0x04002BB2 RID: 11186
		private static int MAX_LEVEL = 9;

		// Token: 0x04002BB3 RID: 11187
		private static int MAX_WEAPON_ATTRIBUTE = 7;

		// Token: 0x04002BB4 RID: 11188
		private static int MAX_WEAPON_EXTRA_INFO = 12;

		// Token: 0x04002BB5 RID: 11189
		private float deltaTime;
	}
}
