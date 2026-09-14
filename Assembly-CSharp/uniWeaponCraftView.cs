using System;
using System.Collections.Generic;
using Core;
using ns0;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;
using UnityEngine;
using XsdSettings;

// Token: 0x020008B7 RID: 2231
public class uniWeaponCraftView : WeaponCraftView
{
	// Token: 0x06003D6A RID: 15722 RVA: 0x00123EC4 File Offset: 0x001220C4
	public override void vmethod_2()
	{
		base.vmethod_2();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("WeaponCraft-2014.swf", "Movie_Whole", new FuncLoad(this.method_7));
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("Tips.swf", "Panel_Tips_Card", new FuncLoad(this.method_8));
	}

	// Token: 0x06003D6B RID: 15723 RVA: 0x00123F2C File Offset: 0x0012212C
	public override void vmethod_3()
	{
		base.vmethod_3();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._craftScreen);
		this._craftScreen = null;
		this._weaponPanel = null;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("WeaponCraft-2014.swf");
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("Tips.swf");
	}

	// Token: 0x06003D6C RID: 15724 RVA: 0x0002973C File Offset: 0x0002793C
	private void method_7(MovieClip movieClip_0)
	{
		this._craftScreen = new uniWeaponCraftView.CraftScreen();
		this._craftScreen.UniWeaponCraftView_0 = this;
		this._craftScreen.method_0(movieClip_0);
		if (this._weaponPanel != null)
		{
			this._craftScreen.method_13(this._weaponPanel);
		}
	}

	// Token: 0x06003D6D RID: 15725 RVA: 0x00123F9C File Offset: 0x0012219C
	private void method_8(MovieClip movieClip_0)
	{
		this._weaponPanel = new uniWeaponCraftView.CraftCardPanel();
		this._weaponPanel.method_0(new MovieClip());
		this._weaponPanel.vmethod_2(movieClip_0);
		if (this._craftScreen != null)
		{
			this._craftScreen.method_13(this._weaponPanel);
		}
	}

	// Token: 0x06003D6E RID: 15726 RVA: 0x00123FEC File Offset: 0x001221EC
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		base.vmethod_1(bool_0, bool_1);
		if (this._bVisible)
		{
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("UI_BackMenu_Open_Main");
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_31(this._craftScreen);
		}
		this._craftScreen.Boolean_0 = this._bVisible;
		if (!this._bVisible)
		{
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("UI_BackMenu_Close_Main");
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._craftScreen);
		}
	}

	// Token: 0x06003D6F RID: 15727 RVA: 0x0002977B File Offset: 0x0002797B
	public override bool vmethod_4()
	{
		if (this.Boolean_1)
		{
			this._craftScreen.method_5();
			NPC_UIFlowController.smethod_0().method_3(NPC_UIFlowController.NPC_UIFlowState.None);
			return true;
		}
		return base.vmethod_4();
	}

	// Token: 0x04002B3E RID: 11070
	private uniWeaponCraftView.CraftScreen _craftScreen;

	// Token: 0x04002B3F RID: 11071
	private uniWeaponCraftView.CraftCardPanel _weaponPanel;

	// Token: 0x020008B8 RID: 2232
	protected class MoneyCostPanel : GClass51
	{
		// Token: 0x06003D71 RID: 15729 RVA: 0x000231B9 File Offset: 0x000213B9
		protected override void vmethod_0()
		{
			base.vmethod_0();
		}

		// Token: 0x06003D72 RID: 15730 RVA: 0x0012408C File Offset: 0x0012228C
		private void method_5(CEvent cevent_0)
		{
			MovieClip movieClip = base.DisplayObjectContainer_0 as MovieClip;
			UnityTextField childByName = movieClip.getChildByName<UnityTextField>("txMoney");
			if (childByName != null)
			{
				childByName.text = "<color='#1CAAFC'><b>$</b></color><color='#FFCC00'> " + Utility.smethod_8(this._iRequireCnt) + "</color>";
			}
		}

		// Token: 0x06003D73 RID: 15731 RVA: 0x001240D4 File Offset: 0x001222D4
		public void method_6(int int_0, int int_1)
		{
			this._iCurCnt = int_0;
			this._iRequireCnt = int_1;
			MovieClip movieClip = base.DisplayObjectContainer_0 as MovieClip;
			UnityTextField childByName = movieClip.getChildByName<UnityTextField>("txMoney");
			string text = Utility.smethod_6("<color='#1CAAFC'><b>$</b></color><color='{0}'> ", Utility.smethod_8(this._iRequireCnt), "</color>");
			string text2 = string.Empty;
			if (childByName != null)
			{
				movieClip.gotoAndStop("normal");
				if (int_1 <= int_0)
				{
					text2 = string.Format(text, "#FFCC00");
				}
				else
				{
					text2 = string.Format(text, "#E31839");
				}
				childByName.text = text2;
			}
		}

		// Token: 0x04002B40 RID: 11072
		protected int _iCurCnt;

		// Token: 0x04002B41 RID: 11073
		protected int _iRequireCnt;
	}

	// Token: 0x020008B9 RID: 2233
	protected class CraftConditionPanel : GClass51
	{
		// Token: 0x06003D75 RID: 15733 RVA: 0x000297D0 File Offset: 0x000279D0
		protected override void vmethod_0()
		{
			base.vmethod_0();
			(this.displayObjectContainer_0 as MovieClip).stopAll();
			this.displayObjectContainer_0.visible = false;
		}

		// Token: 0x06003D76 RID: 15734 RVA: 0x0012415C File Offset: 0x0012235C
		public void method_5(int int_0, int int_1, bool bool_0 = false)
		{
			this.displayObjectContainer_0.visible = true;
			MovieClip movieClip = base.DisplayObjectContainer_0 as MovieClip;
			UnityTextField childByName = movieClip.getChildByName<UnityTextField>("textRequired");
			if (childByName != null)
			{
				childByName.text = Convert.ToString(int_1);
			}
			UnityTextField childByName2 = movieClip.getChildByName<UnityTextField>("textGot");
			if (childByName2 != null)
			{
				childByName2.text = Convert.ToString(int_0);
				childByName2.Color_0 = ((int_1 > int_0) ? this.LACK_COLOR : this.ENOUGH_COLOR);
			}
		}

		// Token: 0x06003D77 RID: 15735 RVA: 0x001241D0 File Offset: 0x001223D0
		public void method_6(MaterialType materialType_0)
		{
			this.displayObjectContainer_0.visible = true;
			MovieClip childByName = base.DisplayObjectContainer_0.getChildByName<MovieClip>("mcMaterialIcon");
			if (childByName != null)
			{
				childByName.gotoAndStop(materialType_0.ToString());
			}
		}

		// Token: 0x04002B42 RID: 11074
		private Color ENOUGH_COLOR = Color.white;

		// Token: 0x04002B43 RID: 11075
		private Color LACK_COLOR = new Color(0.8901961f, 0.09411765f, 0.22352941f);
	}

	// Token: 0x020008BA RID: 2234
	private class CraftScreen : GClass51
	{
		private enum CraftState
		{
			CRAFT_INIT,
			CRAFT_PREVIEW,
			CRAFT,
			CRAFT_OVERVIEW,
			CRAFT_MELTING,
			CRAFT_AGAIN
		}

		private const string OPTION_NAME = "mcOptionButton";

		private const string GUN_PISTOL = "Weapon_Pistol";

		private const string GUN_SMG = "Weapon_SMG";

		private const string GUN_SHOTGUN = "Weapon_Shotgun";

		private const string GUN_SNIPER = "Weapon_Sniper";

		private const string GUN_COMBAT_RIFLE = "Weapon_Combat_Rifle";

		private const int NUM_OF_OPTIONBUTTON = 5;

		private const int NUM_OF_STARS = 9;

		private const float ANIM_TRIGGER_TIME = 1.75f;

		private const float m_rotateSpeed = 100f;

		private uniWeaponCraftView rootView;

		private string[] OPTION_LABEL = new string[5] { "Weapon_Pistol", "Weapon_SMG", "Weapon_Shotgun", "Weapon_Sniper", "Weapon_Combat_Rifle" };

		private MovieClip m_optionPanel;

		private MovieClip m_luckyPanel;

		private MovieClip m_conditionPanel;

		private MovieClip m_craftInfoPanel;

		private MovieClip m_meltInfoPanel;

		private MovieClip m_weaponCardPanel;

		private MovieClip m_topPanel;

		private MovieClip m_succAnim;

		private MovieClip m_buttons;

		private MovieClip mcCardPosition;

		private GClass25 m_craftButton;

		private GClass25 m_againButton;

		private GClass25 m_meltButton;

		private GClass25 m_backButton;

		private GClass25 btnClose;

		private TextField m_weaponName;

		private CraftCardPanel mcRealWeaponCard;

		private bool m_isCraftable;

		private List<MovieClip> m_displayItems = new List<MovieClip>();

		private List<MovieClip> m_fadeInList = new List<MovieClip>();

		private List<MovieClip> m_fadeOutList = new List<MovieClip>();

		private List<CraftConditionPanel> m_conditionPanels = new List<CraftConditionPanel>();

		private MovieClip m_displayMC;

		private MovieClip m_weaponPortaitMC;

		private GClass43 m_weaponPortait;

		protected CraftConditionPanel m_materialPanelA = new CraftConditionPanel();

		protected CraftConditionPanel m_materialPanelB = new CraftConditionPanel();

		protected MoneyCostPanel m_currencyPanel = new MoneyCostPanel();

		protected CraftConditionPanel m_materialPanelC = new CraftConditionPanel();

		protected List<GClass25> m_optionButtons = new List<GClass25>();

		protected string TYPE_CRAFT = "PTL_Weapon_Synthesis";

		protected string TYPE_PISTOL = "PTL_Weapon_Crafting_Pistol";

		protected string TYPE_SHOTGUN = "PTL_Weapon_Crafting_Shotgun";

		protected string TYPE_GARBAGE = string.Empty;

		protected string TYPE_SNIPER = "PTL_Weapon_Crafting_Sniper";

		protected string TYPE_SMG = "PTL_Weapon_Crafting_Smg";

		protected string TYPE_CombatRifle = "PTL_Weapon_Crafting_CombatRifle";

		protected string TYPE_MELTING = "PTL_Weapon_Melting";

		public MovieClip rootMC;

		private ItemDNA m_currentWeaponDNA;

		private WeaponType m_selectedWeaponType;

		private WeaponCraftConfig m_selectedCraftConfig;

		protected GameObject m_ShowingModel;

		private CraftState m_currentState;

		private string m_selectedType;

		protected int _iLastCraftedIndex = -1;

		public uniWeaponCraftView UniWeaponCraftView_0
		{
			set
			{
				rootView = value;
			}
		}

		public bool Boolean_0
		{
			get
			{
				if (rootMC != null)
				{
					return rootMC.visible;
				}
				return false;
			}
			set
			{
				if (rootMC != null)
				{
					rootMC.visible = value;
					if (value)
					{
						method_6();
					}
					else
					{
						method_7();
					}
				}
			}
		}

		public void method_5()
		{
			m_currentState = CraftState.CRAFT_PREVIEW;
		}

		private void method_6()
		{
			if (m_displayMC != null && rootMC.contains(m_displayMC))
			{
				rootMC.removeChild(m_displayMC);
			}
			m_displayMC = new MovieClip();
			switch (m_currentState)
			{
			case CraftState.CRAFT_PREVIEW:
				method_12();
				m_displayMC.addChild(m_topPanel);
				m_displayMC.addChild(m_optionPanel);
				m_fadeInList.Add(m_optionPanel);
				m_fadeInList.Add(m_luckyPanel);
				method_7();
				break;
			case CraftState.CRAFT:
				m_displayMC.addChild(m_topPanel);
				m_displayMC.addChild(m_optionPanel);
				m_displayMC.addChild(m_buttons);
				m_displayMC.addChild(m_conditionPanel);
				method_12(m_craftInfoPanel);
				m_meltButton.Boolean_1 = false;
				m_againButton.Boolean_1 = false;
				m_craftButton.Boolean_1 = true;
				m_fadeInList.Add(m_conditionPanel);
				break;
			case CraftState.CRAFT_OVERVIEW:
				m_displayMC.addChild(m_topPanel);
				m_displayMC.addChild(m_weaponCardPanel);
				m_displayMC.addChild(mcRealWeaponCard.DisplayObjectContainer_0);
				m_displayMC.addChild(m_buttons);
				m_displayMC.addChild(m_succAnim);
				m_fadeInList.Add(m_weaponCardPanel);
				m_displayMC.addChild(m_weaponPortaitMC);
				method_12();
				m_succAnim.play();
				m_meltButton.Boolean_1 = true;
				m_againButton.Boolean_1 = true;
				m_craftButton.Boolean_1 = false;
				break;
			case CraftState.CRAFT_AGAIN:
				m_meltButton.Boolean_1 = true;
				m_againButton.Boolean_1 = true;
				m_craftButton.Boolean_1 = false;
				m_displayMC.addChild(m_weaponCardPanel);
				m_fadeOutList.Add(m_weaponCardPanel);
				method_12();
				break;
			}
			method_8();
			rootMC.addChildAt(m_displayMC, 0);
		}

		private void method_7()
		{
			_iLastCraftedIndex = -1;
			if (m_ShowingModel != null)
			{
				m_ShowingModel.SetActive(value: false);
				UnityEngine.Object.DestroyImmediate(m_ShowingModel);
				m_ShowingModel = null;
				ns0.MonoSingleton<AppManager>.Instance.method_0().method_1(method_37);
			}
		}

		private void method_8()
		{
			for (int i = 0; i < m_displayItems.Count; i++)
			{
				if (m_displayMC.contains(m_displayItems[i]))
				{
					m_displayItems[i].visible = true;
					if (m_displayItems[i] == m_buttons)
					{
						m_buttons.visible = m_craftInfoPanel.visible;
					}
				}
				else
				{
					m_displayItems[i].visible = false;
				}
			}
			foreach (MovieClip fadeIn in m_fadeInList)
			{
				fadeIn.gotoAndPlay("fadein");
			}
			foreach (MovieClip fadeOut in m_fadeOutList)
			{
				fadeOut.gotoAndPlay("fadeout");
			}
			m_fadeInList.Clear();
			m_fadeOutList.Clear();
		}

		protected override void vmethod_0()
		{
			base.vmethod_0();
			rootMC = displayObjectContainer_0 as MovieClip;
			rootMC.visible = false;
			method_6();
			m_currentState = CraftState.CRAFT_PREVIEW;
			if (rootMC == null)
			{
				DebugUtils.LogWarning(LogCategory.GUI, "UIWarning: CraftScreen onInit() 'rootMC' is null! InstancePanel won't work!!!");
			}
		}

		protected override bool OnWidgetInitialized(ref MovieClip mc, Type widgetType)
		{
			bool flag = false;
			flag = method_11(mc);
			switch (mc.name)
			{
			case "mcCardPosition":
				mcCardPosition = mc;
				flag = true;
				break;
			case "mcBackButton":
				m_backButton = new GClass25();
				m_backButton.method_0(mc);
				m_backButton.addEventListener(MouseEvent.CLICK, method_28);
				break;
			case "mcWeaponCard":
				m_weaponCardPanel = mc;
				m_weaponCardPanel.addEventListener(CEvent.ENTER_FRAME, method_25);
				m_displayItems.Add(m_weaponCardPanel);
				flag = false;
				break;
			case "mcOptionList":
				m_optionPanel = mc;
				m_displayItems.Add(m_optionPanel);
				m_optionButtons.Clear();
				flag = false;
				break;
			case "mcTopBar":
				m_topPanel = mc;
				m_displayItems.Add(m_topPanel);
				flag = true;
				break;
			case "mcLuckyPanel":
				m_luckyPanel = mc;
				m_displayItems.Add(m_luckyPanel);
				flag = true;
				break;
			case "mcButtons":
				m_buttons = mc;
				m_displayItems.Add(m_buttons);
				flag = false;
				break;
			case "mcSuccAnim":
				m_succAnim = mc;
				m_succAnim.addFrameScript("animEnd", method_10);
				m_displayItems.Add(m_succAnim);
				flag = true;
				break;
			case "mcCraftCondition":
			{
				m_conditionPanel = mc;
				m_conditionPanel.mouseEnabled = false;
				MovieClip childByName = m_conditionPanel.getChildByName<MovieClip>("mc");
				m_craftInfoPanel = childByName.getChildByName<MovieClip>("mcCraftInfo");
				m_meltInfoPanel = childByName.getChildByName<MovieClip>("mcMeltInfo");
				method_12();
				m_displayItems.Add(m_conditionPanel);
				flag = true;
				break;
			}
			case "mcImage":
				m_weaponPortaitMC = mc;
				m_displayItems.Add(m_weaponPortaitMC);
				m_weaponPortait = new GClass43();
				m_weaponPortait.method_0(m_weaponPortaitMC);
				flag = true;
				break;
			case "mcButtonMelting":
				m_meltButton = new GClass25();
				m_meltButton.method_0(mc);
				m_meltButton.addEventListener(MouseEvent.CLICK, method_28);
				m_meltButton.addEventListener(MouseEvent.MOUSE_ENTER, method_38);
				m_meltButton.addEventListener(MouseEvent.MOUSE_LEAVE, method_39);
				break;
			case "mcButtonAgain":
				m_againButton = new GClass25();
				m_againButton.method_0(mc);
				m_againButton.addEventListener(MouseEvent.CLICK, method_28);
				m_againButton.addEventListener(MouseEvent.MOUSE_ENTER, method_38);
				m_againButton.addEventListener(MouseEvent.MOUSE_LEAVE, method_39);
				break;
			case "mcButtonCraft":
				m_craftButton = new GClass25();
				m_craftButton.method_0(mc);
				m_craftButton.addEventListener(MouseEvent.CLICK, method_28);
				m_currencyPanel.method_0(mc.getChildByName<MovieClip>("mcMoneyInfo"));
				break;
			case "mcBtnClose":
				btnClose = new GClass25();
				btnClose.method_0(mc);
				btnClose.addEventListener(MouseEvent.CLICK, method_9);
				break;
			}
			return flag;
		}

		private void method_9(CEvent cevent_0)
		{
			method_31();
			ns0.MonoSingleton<AppManager>.Instance.method_0().vmethod_5<WeaponCraftView>().vmethod_4();
		}

		private void method_10(CEvent cevent_0)
		{
			m_succAnim.visible = false;
			if (m_displayMC != null && m_displayMC.contains(m_succAnim))
			{
				m_displayMC.removeChild(m_succAnim);
			}
		}

		private bool method_11(MovieClip movieClip_0)
		{
			if (movieClip_0.name.Length > "mcOptionButton".Length)
			{
				string text = movieClip_0.name.Substring(0, "mcOptionButton".Length);
				if (text == "mcOptionButton")
				{
					int num = Convert.ToInt32(movieClip_0.name.Substring("mcOptionButton".Length, movieClip_0.name.Length - "mcOptionButton".Length));
					if (num < OPTION_LABEL.Length && num >= 0)
					{
						GClass25 gClass = new GClass25();
						gClass.method_0(movieClip_0);
						gClass.String_2 = LocalizedString.smethod_0(new LocalizedString(OPTION_LABEL[num]));
						gClass.addEventListener(MouseEvent.CLICK, method_15);
						m_optionButtons.Add(gClass);
						return true;
					}
					DebugUtils.LogWarning(LogCategory.GUI, "Weapon Craft button name wrong! Index:" + num + " is bigger than sum: " + OPTION_LABEL.Length);
					return true;
				}
			}
			return false;
		}

		private void method_12(MovieClip movieClip_0 = null)
		{
			if (m_craftInfoPanel != null)
			{
				m_craftInfoPanel.visible = false;
			}
			if (m_meltInfoPanel != null)
			{
				m_meltInfoPanel.visible = false;
			}
			if (movieClip_0 == m_craftInfoPanel || movieClip_0 == m_meltInfoPanel)
			{
				movieClip_0.visible = m_selectedCraftConfig != null;
				m_buttons.stopAll();
				m_buttons.visible = movieClip_0.visible;
			}
		}

		public void method_13(CraftCardPanel craftCardPanel_0)
		{
			mcRealWeaponCard = craftCardPanel_0;
			if (m_displayMC != null)
			{
				m_displayMC.addChild(mcRealWeaponCard.DisplayObjectContainer_0);
				method_26();
			}
		}

		private void method_14()
		{
			if (m_currentWeaponDNA != null)
			{
				ItemDNA itemDNA_ = ns0.MonoSingleton<AppManager>.Instance.method_0().vmethod_5<CharInfoView>().vmethod_7();
				if (mcRealWeaponCard != null)
				{
					mcRealWeaponCard.vmethod_3(m_currentWeaponDNA, itemDNA_);
				}
			}
		}

		private void method_15(CEvent cevent_0)
		{
			if (rootView.m_particleManager.Boolean_0)
			{
				return;
			}
			GClass25 gClass = cevent_0.currentTarget as GClass25;
			GClass25 gClass2 = method_16();
			if (gClass != gClass2 && gClass != null)
			{
				if (gClass2 != null)
				{
					gClass2.Boolean_3 = false;
				}
				gClass.Boolean_3 = true;
				method_20(gClass.String_2);
				m_selectedType = gClass.String_2;
				m_selectedWeaponType = method_24(gClass.String_2);
				m_currentState = CraftState.CRAFT;
				method_17(m_craftInfoPanel);
				method_6();
			}
		}

		private GClass25 method_16()
		{
			int num = 0;
			while (true)
			{
				if (num < m_optionButtons.Count)
				{
					if (m_optionButtons[num].Boolean_3)
					{
						break;
					}
					num++;
					continue;
				}
				return null;
			}
			return m_optionButtons[num];
		}

		private void method_17(MovieClip movieClip_0)
		{
			int num = ns0.ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_8();
			m_selectedCraftConfig = null;
			for (int i = 0; i < ns0.ServiceWrapperBase<CraftingServiceWrapper>.Instance.m_craftMgr.m_WeaponCraftConfigs.Length; i++)
			{
				if (num >= ns0.ServiceWrapperBase<CraftingServiceWrapper>.Instance.m_craftMgr.m_WeaponCraftConfigs[i].m_MinLevel && num <= ns0.ServiceWrapperBase<CraftingServiceWrapper>.Instance.m_craftMgr.m_WeaponCraftConfigs[i].m_MaxLevel && ns0.ServiceWrapperBase<CraftingServiceWrapper>.Instance.m_craftMgr.m_WeaponCraftConfigs[i].m_WeaponType == m_selectedWeaponType)
				{
					m_selectedCraftConfig = ns0.ServiceWrapperBase<CraftingServiceWrapper>.Instance.m_craftMgr.m_WeaponCraftConfigs[i];
					break;
				}
			}
			if (m_selectedCraftConfig != null)
			{
				method_18(movieClip_0, m_selectedCraftConfig);
				return;
			}
			DebugUtils.LogWarning(LogCategory.GUI, "UIWarning: [WeaponCraft]: Can't find the corresponding weapon with Level: " + num + " with Type: " + m_selectedWeaponType);
		}

		private void method_18(MovieClip movieClip_0, WeaponCraftConfig weaponCraftConfig_0 = null, AcquiredMaterial[] acquiredMaterial_0 = null)
		{
			m_conditionPanels.Clear();
			bool flag = true;
			bool flag2 = movieClip_0 == m_craftInfoPanel;
			m_conditionPanels.Clear();
			m_materialPanelA.method_0(movieClip_0.getChildByName<MovieClip>("mcMaterialInfoA"));
			m_materialPanelB.method_0(movieClip_0.getChildByName<MovieClip>("mcMaterialInfoB"));
			m_materialPanelC.method_0(movieClip_0.getChildByName<MovieClip>("mcMaterialInfoC"));
			m_conditionPanels.Add(m_materialPanelA);
			m_conditionPanels.Add(m_materialPanelB);
			m_conditionPanels.Add(m_materialPanelC);
			if (flag2)
			{
				if (weaponCraftConfig_0 == null)
				{
					return;
				}
				m_craftButton.Boolean_6 = flag;
				int currency = weaponCraftConfig_0.m_Currency;
				int iMyCurrency = rootView._iMyCurrency;
				m_currencyPanel.method_0(m_craftButton.DisplayObjectContainer_0.getChildByName<MovieClip>("mcMoneyInfo"));
				m_currencyPanel.method_6(iMyCurrency, currency);
				if (flag)
				{
					flag = method_19(iMyCurrency, currency);
				}
				m_isCraftable = flag;
				for (int i = 0; i < weaponCraftConfig_0.m_CraftConditions.Length; i++)
				{
					if (m_conditionPanels[i] != null)
					{
						MaterialType matCondition = weaponCraftConfig_0.m_CraftConditions[i].m_MatCondition;
						currency = weaponCraftConfig_0.m_CraftConditions[i].m_MatConditionQuantity;
						iMyCurrency = ns0.ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_33(matCondition);
						m_conditionPanels[i].method_5(iMyCurrency, currency);
						m_conditionPanels[i].method_6(matCondition);
						if (flag && flag2)
						{
							flag = method_19(iMyCurrency, currency);
						}
					}
				}
			}
			else
			{
				if (acquiredMaterial_0 == null)
				{
					return;
				}
				for (int j = 0; j < acquiredMaterial_0.Length; j++)
				{
					if (m_conditionPanels[j] != null)
					{
						MaterialType matCondition = acquiredMaterial_0[j].m_MaterialType;
						int currency = acquiredMaterial_0[j].m_MaterialNums;
						int iMyCurrency = ns0.ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_33(matCondition);
						m_conditionPanels[j].method_5(currency, currency);
						m_conditionPanels[j].method_6(matCondition);
					}
				}
			}
		}

		private bool method_19(int int_0, int int_1)
		{
			return int_1 <= int_0;
		}

		private void method_20(string string_1)
		{
			string_1 = method_22(string_1);
			rootView.m_particleManager.method_4(method_21(string_1), bool_0: false, bool_1: true);
		}

		private string method_21(string string_1)
		{
			string result = string.Empty;
			switch (string_1)
			{
			case "Weapon_Pistol":
				result = TYPE_PISTOL;
				break;
			case "Weapon_Shotgun":
				result = TYPE_SHOTGUN;
				break;
			case "Weapon_Sniper":
				result = TYPE_SNIPER;
				break;
			case "Weapon_SMG":
				result = TYPE_SMG;
				break;
			case "Weapon_Combat_Rifle":
				result = TYPE_CombatRifle;
				break;
			}
			return result;
		}

		private string method_22(string string_1)
		{
			string result = string.Empty;
			string[] oPTION_LABEL = OPTION_LABEL;
			foreach (string text in oPTION_LABEL)
			{
				if (LocalizedString.smethod_0(new LocalizedString(text)) == string_1)
				{
					result = text;
					break;
				}
			}
			return result;
		}

		private void method_23()
		{
			m_weaponPortaitMC.visible = false;
			m_weaponPortait.Boolean_1 = false;
			m_weaponPortait.vmethod_8(ns0.MonoSingleton<DNAPortrait>.Instance.method_3(m_currentWeaponDNA, (int)m_weaponPortaitMC.width, (int)m_weaponPortaitMC.height, TexPostEffectMgr.POST_EFFECT_TYPE.POST_EFFECT_BlUEPRINT));
			m_weaponPortaitMC.visible = true;
			m_weaponPortait.Boolean_1 = true;
		}

		private WeaponType method_24(string string_1)
		{
			WeaponType result = WeaponType.RepeaterPistol;
			string_1 = method_22(string_1);
			switch (string_1)
			{
			case "Weapon_Pistol":
				result = WeaponType.RepeaterPistol;
				break;
			case "Weapon_Shotgun":
				result = WeaponType.ShotGun;
				break;
			case "Weapon_SMG":
				result = WeaponType.SMG;
				break;
			case "Weapon_Sniper":
				result = WeaponType.SniperRifle;
				break;
			case "Weapon_Combat_Rifle":
				result = WeaponType.CombatRifle;
				break;
			}
			return result;
		}

		private void method_25(CEvent cevent_0)
		{
			method_26();
		}

		private void method_26()
		{
			if (mcRealWeaponCard != null)
			{
				Vector2 zero = Vector2.zero;
				zero = GClass20.GClass20_0.method_3(mcCardPosition, zero);
				zero = GClass20.GClass20_0.method_2(mcRealWeaponCard.DisplayObjectContainer_0.parent, zero);
				mcRealWeaponCard.DisplayObjectContainer_0.x = zero.x;
				mcRealWeaponCard.DisplayObjectContainer_0.y = zero.y;
			}
		}

		private void method_27(SmeltResult smeltResult_0, Dictionary<MaterialType, int> dictionary_0)
		{
		}

		private void method_28(CEvent cevent_0)
		{
			GClass25 gClass = cevent_0.currentTarget as GClass25;
			if (rootView.m_particleManager.Boolean_0 || !gClass.Boolean_6)
			{
				return;
			}
			if (cevent_0.currentTarget == m_meltButton)
			{
				if (!ns0.ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_39(null))
				{
					if (_iLastCraftedIndex >= 0)
					{
						ns0.ServiceWrapperBase<CraftingServiceWrapper>.Instance.method_1(method_27, _iLastCraftedIndex);
					}
					m_currentState = CraftState.CRAFT_MELTING;
					rootView.m_particleManager.Single_0 = 0.2f;
					rootView.m_particleManager.Event_0 += method_35;
					rootView.m_particleManager.method_4(TYPE_MELTING, bool_0: true, bool_1: true, method_34);
				}
			}
			else if (cevent_0.currentTarget == m_againButton)
			{
				if (m_isCraftable && !ns0.ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_39(null))
				{
					method_7();
					m_currentState = CraftState.CRAFT_AGAIN;
					if (method_29())
					{
						ns0.ServiceWrapperBase<CraftingServiceWrapper>.Instance.method_2(method_32, m_selectedWeaponType);
					}
					ns0.MonoSingleton<GuidanceTipsManager>.Instance.method_2("guidance_craft");
				}
			}
			else if (cevent_0.currentTarget == m_craftButton)
			{
				if (m_currentState == CraftState.CRAFT && !ns0.ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_39(null))
				{
					if (method_29())
					{
						ns0.ServiceWrapperBase<CraftingServiceWrapper>.Instance.method_2(method_32, m_selectedWeaponType);
					}
					ns0.MonoSingleton<GuidanceTipsManager>.Instance.method_2("guidance_craft");
				}
			}
			else if (cevent_0.currentTarget == m_backButton && m_currentState > CraftState.CRAFT_INIT)
			{
				m_currentState = CraftState.CRAFT_PREVIEW;
				rootView.m_particleManager.method_2();
				method_31();
				method_6();
			}
		}

		private bool method_29()
		{
			int num = ns0.ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_8();
			WeaponCraftConfig weaponCraftConfig = null;
			int i = 0;
			for (int num2 = ns0.ServiceWrapperBase<CraftingServiceWrapper>.Instance.m_craftMgr.m_WeaponCraftConfigs.Length; i < num2; i++)
			{
				if (num >= ns0.ServiceWrapperBase<CraftingServiceWrapper>.Instance.m_craftMgr.m_WeaponCraftConfigs[i].m_MinLevel && num <= ns0.ServiceWrapperBase<CraftingServiceWrapper>.Instance.m_craftMgr.m_WeaponCraftConfigs[i].m_MaxLevel && ns0.ServiceWrapperBase<CraftingServiceWrapper>.Instance.m_craftMgr.m_WeaponCraftConfigs[i].m_WeaponType == m_selectedWeaponType)
				{
					weaponCraftConfig = ns0.ServiceWrapperBase<CraftingServiceWrapper>.Instance.m_craftMgr.m_WeaponCraftConfigs[i];
					break;
				}
			}
			if (weaponCraftConfig == null)
			{
				return false;
			}
			if (ns0.ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_12().BondCurrency < weaponCraftConfig.m_Currency)
			{
				ns0.MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDWarningView>().vmethod_7(LocalizedString.smethod_0(new LocalizedString("Warning_CurrencyInsufficient")), method_30);
				return false;
			}
			int num3 = 0;
			int num4 = weaponCraftConfig.m_CraftConditions.Length;
			while (true)
			{
				if (num3 < num4)
				{
					MaterialType matCondition = weaponCraftConfig.m_CraftConditions[num3].m_MatCondition;
					int matConditionQuantity = weaponCraftConfig.m_CraftConditions[num3].m_MatConditionQuantity;
					int num5 = ns0.ServiceWrapperBase<InventoryServiceWrapper>.Instance.method_33(matCondition);
					if (matConditionQuantity > num5)
					{
						break;
					}
					num3++;
					continue;
				}
				return true;
			}
			ns0.MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDWarningView>().vmethod_7(LocalizedString.smethod_0(new LocalizedString("Weapon_Upgrade_Material")), method_30);
			return false;
		}

		private void method_30()
		{
		}

		private void method_31()
		{
			int i = 0;
			for (int count = m_optionButtons.Count; i < count; i++)
			{
				m_optionButtons[i].Boolean_3 = false;
			}
		}

		public void method_32(bool bool_0, int int_0, ItemDNA itemDNA_0)
		{
			if (bool_0)
			{
				_iLastCraftedIndex = int_0;
				m_currentWeaponDNA = itemDNA_0;
				method_14();
				if (m_currentState == CraftState.CRAFT)
				{
					rootView.m_particleManager.Single_0 = 1.75f;
					rootView.m_particleManager.Event_0 += method_35;
					rootView.m_particleManager.method_4(TYPE_CRAFT, bool_0: true, bool_1: false, method_34);
				}
				else if (m_currentState == CraftState.CRAFT_AGAIN)
				{
					method_6();
					method_20(m_selectedType);
					rootView.m_particleManager.Single_0 = 1.75f;
					rootView.m_particleManager.Event_0 += method_35;
					rootView.m_particleManager.method_4(TYPE_CRAFT, bool_0: true, bool_1: false, method_34);
				}
				method_17(m_craftInfoPanel);
			}
			else
			{
				DebugUtils.LogWarning(LogCategory.GUI, "can't generate weapon type: " + m_selectedWeaponType);
			}
		}

		private void method_33(string string_1, bool bool_0 = false)
		{
			rootView.m_particleManager.Single_0 = 1.75f;
			rootView.m_particleManager.Event_0 += method_35;
			rootView.m_particleManager.method_4(string_1, bool_0: true, bool_0, method_34);
		}

		public void method_34()
		{
			switch (m_currentState)
			{
			case CraftState.CRAFT_MELTING:
				m_currentState = CraftState.CRAFT_PREVIEW;
				method_6();
				break;
			}
			rootView.m_particleManager.Event_1 -= method_34;
		}

		public void method_35()
		{
			switch (m_currentState)
			{
			case CraftState.CRAFT_MELTING:
				method_7();
				rootView.m_particleManager.method_4(TYPE_GARBAGE, bool_0: true);
				break;
			case CraftState.CRAFT:
			case CraftState.CRAFT_AGAIN:
				if (m_weaponPortait != null && m_currentWeaponDNA != null)
				{
					rootView.m_particleManager.method_3(0);
					(ns0.MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("UI_Wep_Upgrade_Glow_Success");
					ns0.MonoSingleton<WeaponFactory>.Instance.method_1(m_currentWeaponDNA.method_6(), method_36);
					m_currentState = CraftState.CRAFT_OVERVIEW;
				}
				else
				{
					m_currentState = CraftState.CRAFT;
				}
				method_6();
				break;
			}
			rootView.m_particleManager.Event_0 -= method_35;
		}

		public void method_36(ref GameObject gameObject_0, WeaponDNA weaponDNA_0)
		{
			m_ShowingModel = gameObject_0;
			SkinnedMeshRenderer skinnedMeshRenderer = BuildingKitGenerator.smethod_1(gameObject_0);
			skinnedMeshRenderer.material.SetTexture("_Cube", ns0.MonoSingleton<LevelLoadingManager>.Instance.m_levelCubemap);
			EntityWeapon.smethod_2(gameObject_0, EntityWeapon.smethod_1(weaponDNA_0.m_attribute));
			m_ShowingModel.transform.parent = rootView.GameObject_0.transform;
			m_ShowingModel.transform.localPosition = rootView.GameObject_0.transform.FindChild("PTL_Weapon_Crafting").localPosition;
			m_ShowingModel.transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
			m_ShowingModel.transform.RotateAround(skinnedMeshRenderer.bounds.center, Vector3.up, 90f);
			ns0.MonoSingleton<AppManager>.Instance.method_0().method_0(method_37);
			(ns0.MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("Itm_Pickup_Gun");
		}

		private void method_37()
		{
			if (!(m_ShowingModel != null))
			{
				return;
			}
			SkinnedMeshRenderer skinnedMeshRenderer = BuildingKitGenerator.smethod_1(m_ShowingModel);
			Vector3 center = skinnedMeshRenderer.bounds.center;
			if (!ns0.MonoSingleton<InputManager>.Instance.method_4("Fire1"))
			{
				return;
			}
			float num = 100f;
			float num2 = (0f - Input.GetAxis("Mouse X")) * num;
			float num3 = Math.Abs(num2);
			if (num3 > 0.01f)
			{
				if (num2 < 0f)
				{
					num *= -1f;
				}
				m_ShowingModel.transform.RotateAround(center, Vector3.up, num * Time.deltaTime);
			}
		}

		private void method_38(CEvent cevent_0)
		{
			if (m_currentState == CraftState.CRAFT_OVERVIEW)
			{
				if (m_displayMC.contains(m_succAnim))
				{
					m_succAnim.visible = false;
					m_displayMC.removeChild(m_succAnim);
				}
				if (cevent_0.currentTarget == m_meltButton.MovieClip_0)
				{
					m_displayMC.addChild(m_conditionPanel);
					m_conditionPanel.gotoAndPlay("fadein");
					method_12(m_meltInfoPanel);
					ns0.ServiceWrapperBase<CraftingServiceWrapper>.Instance.method_0(m_currentWeaponDNA.method_6(), out var acquiredMaterial_);
					method_18(m_meltInfoPanel, null, acquiredMaterial_);
					method_8();
				}
				else if (cevent_0.currentTarget == m_againButton.MovieClip_0)
				{
					m_displayMC.addChild(m_conditionPanel);
					m_conditionPanel.gotoAndPlay("fadein");
					method_12(m_craftInfoPanel);
					method_18(m_craftInfoPanel, m_selectedCraftConfig);
					method_8();
				}
			}
		}

		private void method_39(CEvent cevent_0)
		{
			if (m_currentState == CraftState.CRAFT_OVERVIEW && cevent_0.currentTarget != null && m_displayMC.contains(m_conditionPanel))
			{
				m_displayMC.removeChild(m_conditionPanel);
				method_8();
			}
		}
	}
	// Token: 0x020008BC RID: 2236
	private class CraftCardPanel : ItemCardPanel
	{
		// Token: 0x06003DA2 RID: 15778 RVA: 0x0002993D File Offset: 0x00027B3D
		public override void vmethod_3(ItemDNA itemDNA_0, ItemDNA itemDNA_1)
		{
			base.vmethod_3(itemDNA_0, itemDNA_1);
			this._comparePanel.DisplayObjectContainer_0.visible = false;
		}
	}
}
