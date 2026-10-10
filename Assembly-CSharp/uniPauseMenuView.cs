using System;
using System.Collections.Generic;
using System.Text;
using Core;
using ns0;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;
using UnityEngine;
using XsdSettings;

using System.Runtime.CompilerServices;
// Token: 0x02000876 RID: 2166
public class uniPauseMenuView : PauseMenuView
{
	// Token: 0x06003B29 RID: 15145 RVA: 0x00027B5F File Offset: 0x00025D5F
	public override void vmethod_2()
	{
		base.vmethod_2();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("Setting.swf", "Panel_Root", new FuncLoad(this.method_28));
	}

	// Token: 0x06003B2A RID: 15146 RVA: 0x00116030 File Offset: 0x00114230
	public override void vmethod_3()
	{
		base.vmethod_3();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._panelRoot);
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("Setting.swf");
		this._mcRoot = null;
		this._panelRoot = null;
		this._escMenu = null;
		this._optionsMenu = null;
	}

	// Token: 0x06003B2B RID: 15147 RVA: 0x00116094 File Offset: 0x00114294
	private void method_28(MovieClip movieClip_0)
	{
		this._panelRoot = new GClass51();
		movieClip_0.visible = false;
		this._mcRoot = movieClip_0;
		this._panelRoot.method_0(movieClip_0);
		this._mcEscMenuRoot = movieClip_0.getChildByName<MovieClip>("mcEscMenu");
		this._escMenu = new uniPauseMenuView.EscMenuPanel();
		if (this._mcEscMenuRoot != null)
		{
			this._mcEscMenuRoot.visible = false;
			this._escMenu.method_0(this._mcEscMenuRoot);
			PauseMenuView.EscMenuFunction[] array = (PauseMenuView.EscMenuFunction[])Enum.GetValues(typeof(PauseMenuView.EscMenuFunction));
			foreach (PauseMenuView.EscMenuFunction escMenuFunction in array)
			{
				this._escMenu.removeAllEventListeners(escMenuFunction.ToString());
				this._escMenu.addEventListener(escMenuFunction.ToString(), new EventDispatcher.EventCallback(this.method_38));
			}
		}
		this._escMenu.method_12(this._bRespawnEnable);
		this._escMenu.method_13(this._bLeaveInstanceEnable);
		this._escMenu.method_14(this._bReplayTutorialEnable);
		this._mcOptionMenuAnima = movieClip_0.getChildByName<MovieClip>("mcOptionsMenuAnima");
		this._optionsMenu = new uniPauseMenuView.OptionsMenuPanel();
		if (this._mcOptionMenuAnima != null)
		{
			MovieClip childByName = this._mcOptionMenuAnima.getChildByName<MovieClip>("mcOptionsMenu");
			if (childByName != null)
			{
				this._optionsMenu.method_0(childByName);
				this._optionsMenu.method_5(this._dicSettingsByCategory);
			}
			this._mcOptionMenuAnima.visible = false;
			this._mcOptionMenuAnima.addFrameScript("fadein", new EventDispatcher.EventCallback(this.method_30));
			this._mcOptionMenuAnima.addFrameScript("normal", new EventDispatcher.EventCallback(this.method_30));
			this._mcOptionMenuAnima.addFrameScript("fadeout", new EventDispatcher.EventCallback(this.method_30));
			this._mcOptionMenuAnima.addFrameScript("fadeOutEnd", new EventDispatcher.EventCallback(this.method_29));
		}
		this._bActive = true;
	}

	// Token: 0x06003B2C RID: 15148 RVA: 0x00116288 File Offset: 0x00114488
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		base.vmethod_1(bool_0, bool_1);
		if (this._mcRoot != null)
		{
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("UI_World_Use_Over");
			if (bool_0)
			{
				(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_31(this._panelRoot);
			}
			else
			{
				(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._panelRoot);
			}
			this._mcRoot.visible = bool_0;
			if (!bool_0)
			{
				this.vmethod_5(PauseMenuView.EscMenuState.Root, true);
			}
		}
	}

	// Token: 0x06003B2D RID: 15149 RVA: 0x00116310 File Offset: 0x00114510
	protected override void vmethod_5(PauseMenuView.EscMenuState escMenuState_0, bool bool_0 = false)
	{
		base.vmethod_5(escMenuState_0, bool_0);
		if (this._optionsMenu == null)
		{
			return;
		}
		if (this._curState == PauseMenuView.EscMenuState.Root)
		{
			if (this._mcEscMenuRoot != null)
			{
				this._mcEscMenuRoot.visible = false;
			}
		}
		else if (this._curState == PauseMenuView.EscMenuState.Options && this._mcOptionMenuAnima != null)
		{
			if (bool_0)
			{
				this._mcOptionMenuAnima.visible = false;
			}
			else
			{
				this._mcOptionMenuAnima.gotoAndPlay("fadeout");
			}
		}
		if (escMenuState_0 == PauseMenuView.EscMenuState.Root)
		{
			if (this._mcEscMenuRoot != null)
			{
				this._mcEscMenuRoot.visible = true;
			}
		}
		else if (escMenuState_0 == PauseMenuView.EscMenuState.Options && this._mcOptionMenuAnima != null)
		{
			this._mcOptionMenuAnima.visible = true;
			this._mcOptionMenuAnima.gotoAndPlay("fadein");
		}
		this._optionsMenu.method_5(this._dicSettingsByCategory);
		this._curState = escMenuState_0;
	}

	// Token: 0x06003B2E RID: 15150 RVA: 0x00027B91 File Offset: 0x00025D91
	protected void method_29(CEvent cevent_0)
	{
		this._mcOptionMenuAnima.visible = false;
	}

	// Token: 0x06003B2F RID: 15151 RVA: 0x001163D8 File Offset: 0x001145D8
	protected void method_30(CEvent cevent_0)
	{
		MovieClip childByName = this._mcOptionMenuAnima.getChildByName<MovieClip>("mcOptionsMenu");
		if (childByName != null)
		{
			this._optionsMenu.method_0(this._mcOptionMenuAnima);
			this._optionsMenu.removeAllEventListeners(uniPauseMenuView.EVT_CLICK_BACK);
			this._optionsMenu.addEventListener(uniPauseMenuView.EVT_CLICK_BACK, new EventDispatcher.EventCallback(this.method_31));
			this._optionsMenu.removeAllEventListeners(uniPauseMenuView.EVT_CLICK_RESET);
			this._optionsMenu.addEventListener(uniPauseMenuView.EVT_CLICK_RESET, new EventDispatcher.EventCallback(this.method_32));
			this._optionsMenu.removeAllEventListeners(uniPauseMenuView.EVT_CLICK_SAVE);
			this._optionsMenu.addEventListener(uniPauseMenuView.EVT_CLICK_SAVE, new EventDispatcher.EventCallback(this.method_33));
			this._optionsMenu.removeAllEventListeners(uniPauseMenuView.EVT_SETTINGITEM_DATA_CHANGED);
			this._optionsMenu.addEventListener(uniPauseMenuView.EVT_SETTINGITEM_DATA_CHANGED, new EventDispatcher.EventCallback(this.method_37));
			this._optionsMenu.removeAllEventListeners(uniPauseMenuView.EVT_CLICK_LEFT_KEY);
			this._optionsMenu.addEventListener(uniPauseMenuView.EVT_CLICK_LEFT_KEY, new EventDispatcher.EventCallback(this.method_34));
			this._optionsMenu.removeAllEventListeners(uniPauseMenuView.EVT_CLICK_RIGHT_KEY);
			this._optionsMenu.addEventListener(uniPauseMenuView.EVT_CLICK_RIGHT_KEY, new EventDispatcher.EventCallback(this.method_35));
			this._optionsMenu.removeAllEventListeners(uniPauseMenuView.EVT_CLICK_SETTINGITEM);
			this._optionsMenu.addEventListener(uniPauseMenuView.EVT_CLICK_SETTINGITEM, new EventDispatcher.EventCallback(this.method_36));
		}
	}

	// Token: 0x06003B30 RID: 15152 RVA: 0x00027B9F File Offset: 0x00025D9F
	protected void method_31(CEvent cevent_0)
	{
		if (MonoSingleton<GameSettingMgr>.Instance.method_4())
		{
			base.method_19();
		}
		else
		{
			this.vmethod_5(PauseMenuView.EscMenuState.Root, true);
		}
	}

	// Token: 0x06003B31 RID: 15153 RVA: 0x00027BBD File Offset: 0x00025DBD
	protected void method_32(CEvent cevent_0)
	{
		base.method_20();
	}

	// Token: 0x06003B32 RID: 15154 RVA: 0x00027BC5 File Offset: 0x00025DC5
	protected override void vmethod_7()
	{
		base.method_27(this._optionsMenu.SettingCategory_0);
		this._optionsMenu.method_5(this._dicSettingsByCategory);
	}

	// Token: 0x06003B33 RID: 15155 RVA: 0x00027BE9 File Offset: 0x00025DE9
	protected void method_33(CEvent cevent_0)
	{
		base.method_26();
		this._optionsMenu.method_5(this._dicSettingsByCategory);
	}

	// Token: 0x06003B34 RID: 15156 RVA: 0x00116550 File Offset: 0x00114750
	protected void method_34(CEvent cevent_0)
	{
		GClass55 gclass = cevent_0 as GClass55;
		if (gclass != null && gclass.object_0 != null)
		{
			GameSettingMgr.SettingItemData settingItemData = gclass.object_0 as GameSettingMgr.SettingItemData;
			if (settingItemData != null)
			{
				this._bIsPrimaryKey = true;
				this._onProcessingData = settingItemData;
				base.method_12();
			}
		}
	}

	// Token: 0x06003B35 RID: 15157 RVA: 0x00116594 File Offset: 0x00114794
	protected void method_35(CEvent cevent_0)
	{
		GClass55 gclass = cevent_0 as GClass55;
		if (gclass != null && gclass.object_0 != null)
		{
			GameSettingMgr.SettingItemData settingItemData = gclass.object_0 as GameSettingMgr.SettingItemData;
			if (settingItemData != null)
			{
				this._bIsPrimaryKey = false;
				this._onProcessingData = settingItemData;
				base.method_12();
			}
		}
	}

	// Token: 0x06003B36 RID: 15158 RVA: 0x001165D8 File Offset: 0x001147D8
	protected void method_36(CEvent cevent_0)
	{
		GClass55 gclass = cevent_0 as GClass55;
		if (gclass != null && gclass.object_0 != null)
		{
			GameSettingMgr.SettingItemData settingItemData = gclass.object_0 as GameSettingMgr.SettingItemData;
			if (settingItemData != null)
			{
				base.method_25(settingItemData);
			}
		}
	}

	// Token: 0x06003B37 RID: 15159 RVA: 0x00116610 File Offset: 0x00114810
	protected void method_37(CEvent cevent_0)
	{
		GClass55 gclass = cevent_0 as GClass55;
		if (gclass != null && gclass.object_0 != null)
		{
			GameSettingMgr.SettingItemData settingItemData = gclass.object_0 as GameSettingMgr.SettingItemData;
			if (settingItemData != null && settingItemData.type == GameSettingMgr.SettingItemDataType.ConfigItem && settingItemData.config != null && settingItemData.config.mFunctionType == SettingFunctionType.FullScreen)
			{
				MonoSingleton<GameSettingMgr>.Instance.method_8();
				this.vmethod_5(PauseMenuView.EscMenuState.Options, false);
			}
		}
	}

	// Token: 0x06003B38 RID: 15160 RVA: 0x00116670 File Offset: 0x00114870
	protected void method_38(CEvent cevent_0)
	{
		switch ((int)Enum.Parse(typeof(PauseMenuView.EscMenuFunction), cevent_0.type))
		{
		case 0:
			this.vmethod_6();
			break;
		case 1:
			base.method_9();
			break;
		case 2:
			this.vmethod_5(PauseMenuView.EscMenuState.Options, false);
			break;
		case 3:
			base.method_7();
			break;
		case 4:
			base.method_8();
			break;
		case 5:
			base.method_11();
			break;
		case 6:
			base.method_10();
			break;
		}
	}

	// Token: 0x0400297A RID: 10618
	protected GClass51 _panelRoot;

	// Token: 0x0400297B RID: 10619
	protected uniPauseMenuView.EscMenuPanel _escMenu;

	// Token: 0x0400297C RID: 10620
	protected uniPauseMenuView.OptionsMenuPanel _optionsMenu;

	// Token: 0x0400297D RID: 10621
	protected MovieClip _mcRoot;

	// Token: 0x0400297E RID: 10622
	protected MovieClip _mcOptionMenuAnima;

	// Token: 0x0400297F RID: 10623
	protected MovieClip _mcEscMenuRoot;

	// Token: 0x04002980 RID: 10624
	protected static string EVT_CLICK_BACK = "EvtClickBack";

	// Token: 0x04002981 RID: 10625
	protected static string EVT_CLICK_RESET = "EvtClickReset";

	// Token: 0x04002982 RID: 10626
	protected static string EVT_CLICK_SAVE = "EvtClickSave";

	// Token: 0x04002983 RID: 10627
	protected static string EVT_CLICK_RIGHT_KEY = "EvtClickRightKey";

	// Token: 0x04002984 RID: 10628
	protected static string EVT_CLICK_LEFT_KEY = "EvtClickLeftKey";

	// Token: 0x04002985 RID: 10629
	protected static string EVT_CLICK_SETTINGITEM = "EvtClickSettingItem";

	// Token: 0x04002986 RID: 10630
	protected static string EVT_MOUSE_ENTER_SETTINGITEM = "EvtMouseEnterSettingItem";

	// Token: 0x04002987 RID: 10631
	protected static string EVT_MOUSE_LEAVE_SETTINGITEM = "EvtMouseLeaveSettingItem";

	// Token: 0x04002988 RID: 10632
	protected static string EVT_SETTINGITEM_DATA_CHANGED = "EvtSettingItemDataChanged";

	// Token: 0x02000877 RID: 2167
	protected class EscMenuPanel : GClass51
	{
		// Token: 0x06003B3A RID: 15162 RVA: 0x00116758 File Offset: 0x00114958
		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			bool flag = false;
			string name = movieClip.name;
			if (name != null)
			{
				int length = name.Length;
				if (length <= 10)
				{
					if (length != 7)
					{
						if (length == 10)
						{
							char c = name[3];
							if (c != 'O')
							{
								if (c == 'R' && name == "btnRespawn")
								{
									this._btnRespawn.method_0(movieClip);
									this._btnRespawn.removeAllEventListeners(MouseEvent.CLICK);
									this._btnRespawn.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_8));
									this._btnRespawn.String_2 = LocalizedString.smethod_0(new LocalizedString("Setting_respawn"));
									flag = true;
								}
							}
							else if (name == "btnOptions")
							{
								this._btnOptions.method_0(movieClip);
								this._btnOptions.removeAllEventListeners(MouseEvent.CLICK);
								this._btnOptions.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_5));
								this._btnOptions.String_2 = LocalizedString.smethod_0(new LocalizedString("Setting_option"));
								flag = true;
							}
						}
					}
					else if (name == "btnExit")
					{
						this._btnExitGame.method_0(movieClip);
						this._btnExitGame.removeAllEventListeners(MouseEvent.CLICK);
						this._btnExitGame.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_9));
						this._btnExitGame.String_2 = LocalizedString.smethod_0(new LocalizedString("Setting_quit"));
						flag = true;
					}
				}
				else
				{
					switch (length)
					{
					case 13:
						if (name == "btnBackToGame")
						{
							this._btnBackToGame.method_0(movieClip);
							this._btnBackToGame.removeAllEventListeners(MouseEvent.CLICK);
							this._btnBackToGame.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_7));
							this._btnBackToGame.String_2 = LocalizedString.smethod_0(new LocalizedString("Setting_back_to_game"));
							flag = true;
						}
						break;
					case 14:
					case 16:
						break;
					case 15:
						if (name == "btnQuitInstance")
						{
							this._btnQuitInstance.method_0(movieClip);
							this._btnQuitInstance.removeAllEventListeners(MouseEvent.CLICK);
							this._btnQuitInstance.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_6));
							if (MonoSingleton<Session>.Instance.method_13())
							{
								this._btnQuitInstance.String_2 = LocalizedString.smethod_0(new LocalizedString("Setting_LeaveTutorial"));
							}
							else
							{
								this._btnQuitInstance.String_2 = LocalizedString.smethod_0(new LocalizedString("Setting_LeaveInstance"));
							}
							flag = true;
						}
						break;
					case 17:
						if (name == "btnReplayTutorial")
						{
							this._btnReplayTutorial.method_0(movieClip);
							this._btnReplayTutorial.removeAllEventListeners(MouseEvent.CLICK);
							this._btnReplayTutorial.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_11));
							this._btnReplayTutorial.String_2 = LocalizedString.smethod_0(new LocalizedString("Setting_replay_tutorial"));
							flag = true;
						}
						break;
					default:
						if (length == 21 && name == "btnCharacterSelection")
						{
							this._btnCharacterSelection.method_0(movieClip);
							this._btnCharacterSelection.removeAllEventListeners(MouseEvent.CLICK);
							this._btnCharacterSelection.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_11));
							this._btnCharacterSelection.String_2 = LocalizedString.smethod_0(new LocalizedString("Setting_character_selection"));
							this._btnCharacterSelection.Boolean_6 = true;
							flag = true;
						}
						break;
					}
				}
			}
			return flag;
		}

		// Token: 0x06003B3B RID: 15163 RVA: 0x00116AF4 File Offset: 0x00114CF4
		protected void method_5(CEvent cevent_0)
		{
			GClass55 gclass = new GClass55(PauseMenuView.EscMenuFunction.GameOptions.ToString(), null, true, false);
			base.dispatchEvent(gclass);
		}

		// Token: 0x06003B3C RID: 15164 RVA: 0x00116B20 File Offset: 0x00114D20
		protected void method_6(CEvent cevent_0)
		{
			GClass55 gclass = new GClass55(PauseMenuView.EscMenuFunction.QuitInstance.ToString(), null, true, false);
			base.dispatchEvent(gclass);
		}

		// Token: 0x06003B3D RID: 15165 RVA: 0x00116B4C File Offset: 0x00114D4C
		protected void method_7(CEvent cevent_0)
		{
			GClass55 gclass = new GClass55(PauseMenuView.EscMenuFunction.BackToGame.ToString(), null, true, false);
			base.dispatchEvent(gclass);
		}

		// Token: 0x06003B3E RID: 15166 RVA: 0x00116B78 File Offset: 0x00114D78
		protected void method_8(CEvent cevent_0)
		{
			GClass55 gclass = new GClass55(PauseMenuView.EscMenuFunction.Respawn.ToString(), null, true, false);
			base.dispatchEvent(gclass);
		}

		// Token: 0x06003B3F RID: 15167 RVA: 0x00116BA4 File Offset: 0x00114DA4
		protected void method_9(CEvent cevent_0)
		{
			GClass55 gclass = new GClass55(PauseMenuView.EscMenuFunction.ExitGame.ToString(), null, true, false);
			base.dispatchEvent(gclass);
		}

		// Token: 0x06003B40 RID: 15168 RVA: 0x00116BD0 File Offset: 0x00114DD0
		protected void method_10(CEvent cevent_0)
		{
			GClass55 gclass = new GClass55(PauseMenuView.EscMenuFunction.CharacterSelection.ToString(), null, true, false);
			base.dispatchEvent(gclass);
		}

		// Token: 0x06003B41 RID: 15169 RVA: 0x00116C00 File Offset: 0x00114E00
		protected void method_11(CEvent cevent_0)
		{
			GClass55 gclass = new GClass55(PauseMenuView.EscMenuFunction.CharacterSelection.ToString(), null, true, false);
			base.dispatchEvent(gclass);
		}

		// Token: 0x06003B42 RID: 15170 RVA: 0x00027C02 File Offset: 0x00025E02
		public void method_12(bool bool_0)
		{
			this._btnRespawn.Boolean_6 = bool_0;
		}

		// Token: 0x06003B43 RID: 15171 RVA: 0x00027C10 File Offset: 0x00025E10
		public void method_13(bool bool_0)
		{
			this._btnQuitInstance.Boolean_6 = bool_0;
		}

		// Token: 0x06003B44 RID: 15172 RVA: 0x00027C1E File Offset: 0x00025E1E
		public void method_14(bool bool_0)
		{
			this._btnReplayTutorial.Boolean_6 = bool_0;
		}

		// Token: 0x04002989 RID: 10633
		protected GClass25 _btnBackToGame = new GClass25();

		// Token: 0x0400298A RID: 10634
		protected GClass25 _btnOptions = new GClass25();

		// Token: 0x0400298B RID: 10635
		protected GClass25 _btnQuitInstance = new GClass25();

		// Token: 0x0400298C RID: 10636
		protected GClass25 _btnRespawn = new GClass25();

		// Token: 0x0400298D RID: 10637
		protected GClass25 _btnExitGame = new GClass25();

		// Token: 0x0400298E RID: 10638
		protected GClass25 _btnReplayTutorial = new GClass25();

		// Token: 0x0400298F RID: 10639
		protected GClass25 _btnCharacterSelection = new GClass25();

		// Token: 0x02000878 RID: 2168
		// (Invoke) Token: 0x06003B46 RID: 15174
		protected delegate void onClickBtn();
	}

	// Token: 0x02000879 RID: 2169
	protected class OptionsMenuPanel : GClass51
	{
		protected class SettingCatogoryTab : GClass40
		{
			protected int _iIndex = -1;

			protected SettingCategory _category;

			public int Int32_0 => _iIndex;

			public SettingCategory SettingCategory_0 => _category;

			protected override void vmethod_0()
			{
				base.vmethod_0();
				int num = base.DisplayObjectContainer_0.name.IndexOf('_');
				int num2 = base.DisplayObjectContainer_0.name.LastIndexOf('_');
				if (num2 != -1 && num != -1)
				{
					_iIndex = Convert.ToInt32(base.DisplayObjectContainer_0.name.Substring(num2 + 1));
					_category = (SettingCategory)(int)Enum.Parse(typeof(SettingCategory), base.DisplayObjectContainer_0.name.Substring(num + 1, num2 - num - 1));
				}
				else
				{
					DebugUtils.LogWarning(LogCategory.GUI, "Wrong MovieClip Name " + base.DisplayObjectContainer_0.name);
				}
			}
		}

		protected class SettingMenuList : GClass51
		{
			protected const int ITEM_SLOT_COUNT = 14;

			protected const string ITEM_NAME_PREFIX = "mcItem_";

			protected GClass46 _scBar = new GClass46();

			protected SettingMenuItemContainer[] _itemList = new SettingMenuItemContainer[14];

			protected List<GameSettingMgr.SettingItemData> _dataList = new List<GameSettingMgr.SettingItemData>();

			protected string _strGroupLabel;

			public string String_2
			{
				set
				{
					_strGroupLabel = value;
				}
			}

			protected override void vmethod_0()
			{
				base.DisplayObjectContainer_0.addEventListener(GClass56.string_0, _scBar.method_12, useCapture: false);
			}

			protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
			{
				bool result = false;
				if (movieClip.name.Contains("mcItem_"))
				{
					int num = movieClip.name.IndexOf('_');
					if (num != -1)
					{
						string value = movieClip.name.Substring(num + 1);
						int num2 = Convert.ToInt32(value);
						if (num2 >= 0 && num2 < 14)
						{
							if (_itemList[num2] == null)
							{
								string[] array = new string[6] { EVT_MOUSE_ENTER_SETTINGITEM, EVT_MOUSE_LEAVE_SETTINGITEM, EVT_SETTINGITEM_DATA_CHANGED, EVT_CLICK_SETTINGITEM, EVT_CLICK_LEFT_KEY, EVT_CLICK_RIGHT_KEY };
								_itemList[num2] = new SettingMenuItemContainer();
								string[] array2 = array;
								foreach (string type in array2)
								{
									_itemList[num2].removeAllEventListeners(type);
									_itemList[num2].addEventListener(type, method_6);
								}
								_itemList[num2].String_2 = _strGroupLabel;
							}
							_itemList[num2].method_0(movieClip);
						}
					}
				}
				else if (movieClip.name == "mcScrollingBar")
				{
					_scBar.method_0(movieClip);
					_scBar.removeAllEventListeners("Scrolling");
					_scBar.addEventListener("Scrolling", method_7);
					_scBar.Int32_1 = 0;
					GClass46 scBar = _scBar;
					_scBar.int_0 = 0;
					scBar.int_1 = 0;
					movieClip.visible = false;
					result = true;
				}
				return result;
			}

			public void method_5(List<GameSettingMgr.SettingItemData> list_1 = null, bool bool_0 = false)
			{
				if (list_1 != null)
				{
					_dataList = list_1;
				}
				if (base.DisplayObjectContainer_0 is MovieClip)
				{
					if (bool_0)
					{
						_scBar.Int32_1 = 0;
					}
					_scBar.DisplayObjectContainer_0.visible = _dataList.Count > 14;
					_scBar.method_10(14, 0, _dataList.Count - 14, 1);
					method_8(_scBar.Int32_1);
				}
			}

			protected void method_6(CEvent cevent_0)
			{
				dispatchEvent(cevent_0);
			}

			protected void method_7(CEvent cevent_0)
			{
				method_8(_scBar.Int32_1);
			}

			protected void method_8(int int_0)
			{
				if (int_0 < 0 || int_0 > _dataList.Count)
				{
					return;
				}
				int i = 0;
				if (_dataList != null)
				{
					while (int_0 < _dataList.Count && i < _itemList.Length)
					{
						if (_itemList[i] != null)
						{
							_itemList[i].method_10(_dataList[int_0]);
							_itemList[i].DisplayObjectContainer_0.visible = true;
						}
						int_0++;
						i++;
					}
				}
				for (; i < 14; i++)
				{
					if (_itemList[i] != null)
					{
						_itemList[i].DisplayObjectContainer_0.visible = false;
					}
				}
			}
		}

		protected class SettingMenuItemContainer : GClass51
		{
			protected SettingMenuItem_Button _item_Button = new SettingMenuItem_Button();

			protected SettingMenuItem_Range _item_Range = new SettingMenuItem_Range();

			protected SettingMenuItem_KeyBinding _item_KeyBinding = new SettingMenuItem_KeyBinding();

			protected SettingMenuItem_Options _item_Options = new SettingMenuItem_Options();

			protected string _strGroupLabel;

			protected GameSettingMgr.SettingItemData _settingData;

			public string String_2
			{
				set
				{
					_strGroupLabel = value;
				}
			}

			protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
			{
				bool result = false;
				switch (movieClip.name)
				{
				case "mcSettingItem_Range":
					_item_Range.String_1 = _strGroupLabel;
					_item_Range.method_0(movieClip);
					_item_Range.addEventListener(MouseEvent.CLICK, method_8);
					method_5(_item_Range, EVT_SETTINGITEM_DATA_CHANGED);
					movieClip.visible = false;
					result = true;
					break;
				case "mcSettingItem_KeyBinding":
					_item_KeyBinding.String_1 = _strGroupLabel;
					_item_KeyBinding.method_0(movieClip);
					_item_KeyBinding.addEventListener(MouseEvent.CLICK, method_8);
					method_5(_item_KeyBinding, EVT_SETTINGITEM_DATA_CHANGED);
					method_5(_item_KeyBinding, EVT_CLICK_LEFT_KEY);
					method_5(_item_KeyBinding, EVT_CLICK_RIGHT_KEY);
					movieClip.visible = false;
					result = true;
					break;
				case "mcSettingItem_Options":
					_item_Options.String_1 = _strGroupLabel;
					_item_Options.method_0(movieClip);
					_item_Options.addEventListener(MouseEvent.CLICK, method_8);
					method_5(_item_Options, EVT_SETTINGITEM_DATA_CHANGED);
					movieClip.visible = false;
					result = true;
					break;
				case "mcSettingItem_Button":
					_item_Button.String_1 = _strGroupLabel;
					_item_Button.method_0(movieClip);
					_item_Button.addEventListener(MouseEvent.CLICK, method_8);
					method_5(_item_Button, EVT_SETTINGITEM_DATA_CHANGED);
					movieClip.visible = false;
					result = true;
					break;
				}
				return result;
			}

			protected void method_5(SettingMenuItemBase settingMenuItemBase_0, string string_1)
			{
				if (settingMenuItemBase_0 != null && string_1 != null)
				{
					settingMenuItemBase_0.removeAllEventListeners(string_1);
					settingMenuItemBase_0.addEventListener(string_1, method_9);
				}
			}

			protected override void vmethod_0()
			{
				base.vmethod_0();
				if (base.DisplayObjectContainer_0 is MovieClip movieClip)
				{
					movieClip.removeAllEventListeners(MouseEvent.MOUSE_ENTER);
					movieClip.removeAllEventListeners(MouseEvent.MOUSE_LEAVE);
					movieClip.addEventListener(MouseEvent.MOUSE_ENTER, method_6);
					movieClip.addEventListener(MouseEvent.MOUSE_LEAVE, method_7);
				}
			}

			protected void method_6(CEvent cevent_0)
			{
				dispatchEvent(new GClass55(EVT_MOUSE_ENTER_SETTINGITEM, _settingData));
			}

			protected void method_7(CEvent cevent_0)
			{
				dispatchEvent(new GClass55(EVT_MOUSE_LEAVE_SETTINGITEM, _settingData));
			}

			protected void method_8(CEvent cevent_0)
			{
				dispatchEvent(new GClass55(EVT_CLICK_SETTINGITEM, _settingData));
			}

			protected void method_9(CEvent cevent_0)
			{
				dispatchEvent(cevent_0);
			}

			public void method_10(GameSettingMgr.SettingItemData settingItemData_0)
			{
				_settingData = settingItemData_0;
				_item_Range.DisplayObjectContainer_0.visible = false;
				_item_KeyBinding.DisplayObjectContainer_0.visible = false;
				_item_Options.DisplayObjectContainer_0.visible = false;
				_item_Button.DisplayObjectContainer_0.visible = false;
				SettingMenuItemBase settingMenuItemBase = null;
				if (settingItemData_0.type == GameSettingMgr.SettingItemDataType.ConfigItem)
				{
					if (settingItemData_0.config != null)
					{
						switch (settingItemData_0.config.mDisplayType)
						{
						case SettingDisplayType.Range:
							settingMenuItemBase = _item_Range;
							break;
						case SettingDisplayType.Button:
							settingMenuItemBase = _item_Button;
							break;
						case SettingDisplayType.Options:
						case SettingDisplayType.Toggle:
							settingMenuItemBase = _item_Options;
							break;
						}
					}
				}
				else if (settingItemData_0.type == GameSettingMgr.SettingItemDataType.KeyBinding)
				{
					settingMenuItemBase = _item_KeyBinding;
				}
				if (settingMenuItemBase != null)
				{
					settingMenuItemBase.vmethod_15(settingItemData_0);
					settingMenuItemBase.DisplayObjectContainer_0.visible = true;
					settingMenuItemBase.Boolean_6 = settingItemData_0.bEnable;
				}
			}
		}

		protected class SettingMenuItemBase : GClass40
		{
			protected GameSettingMgr.SettingItemData _settingData;

			protected bool _bInChildMC;

			public GameSettingMgr.SettingItemData SettingItemData_0 => _settingData;

			protected override void vmethod_0()
			{
				base.vmethod_0();
				if (base.DisplayObjectContainer_0 is MovieClip movieClip)
				{
					movieClip.addFrameScript("up", method_23);
					movieClip.addFrameScript("over", method_23);
					movieClip.addFrameScript("down", method_23);
					movieClip.addFrameScript("disabled", method_23);
					movieClip.addFrameScript("selected_up", method_23);
					movieClip.addFrameScript("selected_over", method_23);
					movieClip.addFrameScript("selected_down", method_23);
					movieClip.addFrameScript("selected_disabled", method_23);
				}
			}

			protected override void vmethod_4()
			{
				movieClip_0.mouseChildrenEnabled = false;
				movieClip_0.addEventListener(MouseEvent.MOUSE_ENTER, method_19, useCapture: false);
				movieClip_0.addEventListener(MouseEvent.MOUSE_LEAVE, method_20, useCapture: false);
			}

			protected void method_19(CEvent cevent_0)
			{
				if (!_bInChildMC)
				{
					method_12(cevent_0);
				}
				Boolean_3 = true;
			}

			protected void method_20(CEvent cevent_0)
			{
				if (!_bInChildMC)
				{
					method_13(cevent_0);
				}
			}

			protected void method_21(CEvent cevent_0)
			{
				if (!_bInChildMC)
				{
					method_14(cevent_0);
				}
			}

			protected void method_22(CEvent cevent_0)
			{
				if (!_bInChildMC)
				{
					method_15(cevent_0);
				}
			}

			protected virtual void vmethod_13(CEvent cevent_0)
			{
				_bInChildMC = true;
			}

			protected virtual void vmethod_14(CEvent cevent_0)
			{
				_bInChildMC = false;
			}

			public virtual void vmethod_15(GameSettingMgr.SettingItemData settingItemData_0)
			{
				_settingData = settingItemData_0;
				if (_settingData != null)
				{
					string text = null;
					switch (_settingData.type)
					{
					case GameSettingMgr.SettingItemDataType.KeyBinding:
						text = "Control_" + _settingData.controlAction;
						break;
					case GameSettingMgr.SettingItemDataType.ConfigItem:
						if (_settingData.config != null)
						{
							text = _settingData.config.mTitle;
						}
						break;
					}
					String_2 = LocalizedString.smethod_0(new LocalizedString(text));
				}
				if (base.DisplayObjectContainer_0 is MovieClip movieClip)
				{
					movieClip.mouseChildrenEnabled = true;
				}
			}

			protected void method_23(CEvent cevent_0)
			{
				vmethod_15(_settingData);
			}
		}

		protected class SettingMenuItem_Button : SettingMenuItemBase
		{
		}

		protected class SettingMenuItem_Range : SettingMenuItemBase
		{
			protected SettingMenuRangeBar _rangeBar = new SettingMenuRangeBar();

			protected float _fCurValue;

			[CompilerGenerated]
			private static Dictionary<string, int> f__switch_map28;

			protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
			{
				bool result = false;
				string name = movieClip.name;
				if (name != null)
				{
					if (f__switch_map28 == null)
					{
						Dictionary<string, int> dictionary = new Dictionary<string, int>(1);
						dictionary.Add("mcBar", 0);
						f__switch_map28 = dictionary;
					}
					if (f__switch_map28.TryGetValue(name, out var value) && value == 0)
					{
						_rangeBar.method_0(movieClip);
						_rangeBar.removeAllEventListeners(CEvent.CHANGED);
						_rangeBar.addEventListener(CEvent.CHANGED, method_24);
						movieClip.removeAllEventListeners(MouseEvent.MOUSE_LEAVE);
						movieClip.removeAllEventListeners(MouseEvent.MOUSE_ENTER);
						movieClip.addEventListener(MouseEvent.MOUSE_ENTER, vmethod_13);
						movieClip.addEventListener(MouseEvent.MOUSE_LEAVE, vmethod_14);
					}
				}
				return result;
			}

			public override void vmethod_15(GameSettingMgr.SettingItemData settingItemData_0)
			{
				base.vmethod_15(settingItemData_0);
				if (settingItemData_0 != null && settingItemData_0.config != null && settingItemData_0.config.mRange != null)
				{
					_rangeBar.method_7(settingItemData_0.config.mRange.LeftValue, settingItemData_0.config.mRange.RightValue);
					if (_settingData.bDirty)
					{
						_rangeBar.method_6(settingItemData_0.newValue.fValue);
					}
					else
					{
						_rangeBar.method_6(settingItemData_0.curValue.fValue);
					}
				}
			}

			protected void method_24(CEvent cevent_0)
			{
				if (cevent_0 is GClass55 { object_0: not null } gClass)
				{
					_fCurValue = Convert.ToSingle(gClass.object_0);
					if (_fCurValue != _settingData.curValue.fValue)
					{
						_settingData.bDirty = true;
						_settingData.newValue.fValue = _fCurValue;
						dispatchEvent(new GClass55(EVT_SETTINGITEM_DATA_CHANGED, _settingData));
					}
				}
			}
		}

		protected class SettingMenuRangeBar : GClass51
		{
			protected GClass48 _sliderBar = new GClass48();

			protected TextField _textValue;

			protected float _fLength = 100f;

			protected float _fCurValue = 100f;

			[CompilerGenerated]
			private static Dictionary<string, int> f__switch_map29;

			protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
			{
				bool result = false;
				string name = movieClip.name;
				if (name != null)
				{
					if (f__switch_map29 == null)
					{
						Dictionary<string, int> dictionary = new Dictionary<string, int>(1);
						dictionary.Add("mcSlider", 0);
						f__switch_map29 = dictionary;
					}
					if (f__switch_map29.TryGetValue(name, out var value) && value == 0)
					{
						_sliderBar.method_0(movieClip);
						_sliderBar.removeAllEventListeners(CEvent.CHANGED);
						_sliderBar.addEventListener(CEvent.CHANGED, method_5);
						result = true;
					}
				}
				return result;
			}

			protected override void vmethod_0()
			{
				base.vmethod_0();
				_textValue = base.DisplayObjectContainer_0.getChildByName<TextField>("textValue");
			}

			protected void method_5(CEvent cevent_0)
			{
				if (cevent_0 is GClass55 { object_0: not null } gClass)
				{
					float num = Convert.ToSingle(gClass.object_0);
					method_6(num);
					if (_textValue != null)
					{
						int num2 = Mathf.CeilToInt(num);
						_textValue.text = num2.ToString();
					}
					dispatchEvent(cevent_0);
				}
			}

			public void method_6(float float_0)
			{
				if (_sliderBar.Single_0 != float_0)
				{
					_sliderBar.Single_0 = float_0;
				}
			}

			public void method_7(float float_0, float float_1)
			{
				_sliderBar.Single_2 = float_0;
				_sliderBar.Single_1 = float_1;
				_fLength = float_1 - float_0;
			}
		}

		protected class SettingMenuItem_KeyBinding : SettingMenuItemBase
		{
			protected TextField _textLeftKey;

			protected TextField _textRightKey;

			protected GClass25 _btnLeftKey = new GClass25();

			protected GClass25 _btnRightKey = new GClass25();

			protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
			{
				bool result = false;
				switch (movieClip.name)
				{
				case "mcRightKey":
					_textRightKey = movieClip.getChildByName<TextField>("textValue");
					_btnRightKey.method_0(movieClip);
					_btnRightKey.removeAllEventListeners(MouseEvent.CLICK);
					_btnRightKey.addEventListener(MouseEvent.CLICK, method_25);
					break;
				case "mcLeftKey":
					_textLeftKey = movieClip.getChildByName<TextField>("textValue");
					_btnLeftKey.method_0(movieClip);
					_btnLeftKey.removeAllEventListeners(MouseEvent.CLICK);
					_btnLeftKey.addEventListener(MouseEvent.CLICK, method_24);
					break;
				}
				return result;
			}

			protected void method_24(CEvent cevent_0)
			{
				dispatchEvent(new GClass55(EVT_CLICK_LEFT_KEY, _settingData));
			}

			protected void method_25(CEvent cevent_0)
			{
				dispatchEvent(new GClass55(EVT_CLICK_RIGHT_KEY, _settingData));
			}

			public override void vmethod_15(GameSettingMgr.SettingItemData settingItemData_0)
			{
				base.vmethod_15(settingItemData_0);
				if (settingItemData_0 != null)
				{
					InputManager.InputKeyBinding keyBinding = settingItemData_0.curValue.keyBinding;
					if (settingItemData_0.bDirty)
					{
						keyBinding = settingItemData_0.newValue.keyBinding;
					}
					if (_textLeftKey != null)
					{
						string text = LocalizedString.smethod_0(new LocalizedString(Utility.smethod_5("Key_", keyBinding.primaryKey.ToString())));
						_textLeftKey.text = text;
					}
					if (_textRightKey != null)
					{
						string text2 = LocalizedString.smethod_0(new LocalizedString(Utility.smethod_5("Key_", keyBinding.seconderyKey.ToString())));
						_textRightKey.text = text2;
					}
				}
			}
		}

		protected class SettingMenuItem_Options : SettingMenuItemBase
		{
			protected GClass25 _btnLeft = new GClass25();

			protected GClass25 _btnRight = new GClass25();

			protected List<string> _strValueList = new List<string>();

			protected int _iOnShowIdx;

			protected override void vmethod_0()
			{
				base.vmethod_0();
				_btnLeft.removeAllEventListeners(MouseEvent.CLICK);
				_btnLeft.addEventListener(MouseEvent.CLICK, method_24);
				_btnRight.removeAllEventListeners(MouseEvent.CLICK);
				_btnRight.addEventListener(MouseEvent.CLICK, method_25);
				_iOnShowIdx = 0;
			}

			public override void vmethod_15(GameSettingMgr.SettingItemData settingItemData_0)
			{
				base.vmethod_15(settingItemData_0);
				MovieClip childByName = base.DisplayObjectContainer_0.getChildByName<MovieClip>("btnLeft");
				if (childByName != null)
				{
					_btnLeft.removeAllEventListeners(MouseEvent.CLICK);
					_btnLeft.method_0(childByName);
					_btnLeft.addEventListener(MouseEvent.CLICK, method_24);
					_btnLeft.method_7(MouseEvent.CLICK, "UI_Generic_InGame_Movement");
					childByName.removeAllEventListeners(MouseEvent.MOUSE_LEAVE);
					childByName.removeAllEventListeners(MouseEvent.MOUSE_ENTER);
					childByName.addEventListener(MouseEvent.MOUSE_ENTER, vmethod_13);
					childByName.addEventListener(MouseEvent.MOUSE_LEAVE, vmethod_14);
				}
				MovieClip childByName2 = base.DisplayObjectContainer_0.getChildByName<MovieClip>("btnRight");
				if (childByName2 != null)
				{
					_btnRight.removeAllEventListeners(MouseEvent.CLICK);
					_btnRight.method_7(MouseEvent.CLICK, "UI_Generic_InGame_Movement");
					_btnRight.method_0(childByName2);
					_btnRight.addEventListener(MouseEvent.CLICK, method_25);
					childByName2.removeAllEventListeners(MouseEvent.MOUSE_LEAVE);
					childByName2.removeAllEventListeners(MouseEvent.MOUSE_ENTER);
					childByName2.addEventListener(MouseEvent.MOUSE_ENTER, vmethod_13);
					childByName2.addEventListener(MouseEvent.MOUSE_LEAVE, vmethod_14);
				}
				_strValueList.Clear();
				if (settingItemData_0 == null || settingItemData_0.config == null)
				{
					return;
				}
				if (settingItemData_0.config.mDisplayType == SettingDisplayType.Toggle)
				{
					_strValueList.Add(LocalizedString.smethod_0(new LocalizedString("Setting_Off")));
					_strValueList.Add(LocalizedString.smethod_0(new LocalizedString("Setting_On")));
				}
				else
				{
					switch (settingItemData_0.config.mFunctionType)
					{
					case SettingFunctionType.ScreenResolution:
					{
						IntPair[] mResolutions = settingItemData_0.config.mResolutions;
						foreach (IntPair intPair in mResolutions)
						{
							string item = Utility.smethod_6(Utility.smethod_8(intPair.LeftValue), " * ", Utility.smethod_8(intPair.RightValue));
							_strValueList.Add(item);
						}
						break;
					}
					case SettingFunctionType.OverallQuality:
					{
						XsdSettings.QualityLevel[] mQualitys = settingItemData_0.config.mQualitys;
						for (int i = 0; i < mQualitys.Length; i++)
						{
							XsdSettings.QualityLevel qualityLevel = mQualitys[i];
							StringBuilder stringBuilder2 = new StringBuilder("Setting_");
							stringBuilder2.Append(qualityLevel.ToString());
							_strValueList.Add(LocalizedString.smethod_0(new LocalizedString(stringBuilder2.ToString())));
						}
						break;
					}
					case SettingFunctionType.Language:
						if (settingItemData_0.config.mControlSchemeList != null)
						{
							string[] mControlSchemeList = settingItemData_0.config.mControlSchemeList;
							foreach (string item2 in mControlSchemeList)
							{
								_strValueList.Add(item2);
							}
						}
						break;
					case SettingFunctionType.FrameRate:
					{
						FrameRate[] mFrameRates = settingItemData_0.config.mFrameRates;
						for (int i = 0; i < mFrameRates.Length; i++)
						{
							FrameRate frameRate = mFrameRates[i];
							StringBuilder stringBuilder = new StringBuilder("Setting_");
							stringBuilder.Append(frameRate.ToString());
							_strValueList.Add(LocalizedString.smethod_0(new LocalizedString(stringBuilder.ToString())));
						}
						break;
					}
					case SettingFunctionType.AimSensitivity:
					{
						FrameRate[] mFrameRates = settingItemData_0.config.mFrameRates;
						for (int i = 0; i < mFrameRates.Length; i++)
						{
							FrameRate frameRate = mFrameRates[i];
							StringBuilder stringBuilder = new StringBuilder("Setting_");
							stringBuilder.Append(frameRate.ToString());
							_strValueList.Add(LocalizedString.smethod_0(new LocalizedString(stringBuilder.ToString())));
						}
						break;
					}
					}
				}
				if (settingItemData_0 != null && settingItemData_0.config != null)
				{
					if (settingItemData_0.config.mDisplayType == SettingDisplayType.Options)
					{
						if (settingItemData_0.bDirty)
						{
							_iOnShowIdx = settingItemData_0.newValue.iIndex;
						}
						else
						{
							_iOnShowIdx = settingItemData_0.curValue.iIndex;
						}
					}
					else if (settingItemData_0.config.mDisplayType == SettingDisplayType.Toggle)
					{
						if (settingItemData_0.bDirty)
						{
							_iOnShowIdx = (settingItemData_0.newValue.bOn ? 1 : 0);
						}
						else
						{
							_iOnShowIdx = (settingItemData_0.curValue.bOn ? 1 : 0);
						}
					}
				}
				method_27();
			}

			protected void method_24(CEvent cevent_0)
			{
				_iOnShowIdx--;
				method_27();
				method_26();
			}

			protected void method_25(CEvent cevent_0)
			{
				_iOnShowIdx++;
				method_27();
				method_26();
			}

			protected void method_26()
			{
				if (_settingData.config != null)
				{
					if (_settingData.config.mDisplayType == SettingDisplayType.Options)
					{
						_settingData.newValue.iIndex = _iOnShowIdx;
					}
					else if (_settingData.config.mDisplayType == SettingDisplayType.Toggle)
					{
						_settingData.newValue.bOn = _iOnShowIdx == 1;
					}
				}
				_settingData.bDirty = true;
				dispatchEvent(new GClass55(EVT_SETTINGITEM_DATA_CHANGED, _settingData));
			}

			protected void method_27()
			{
				TextField childByName = base.DisplayObjectContainer_0.getChildByName<TextField>("textValue");
				if (childByName == null)
				{
					return;
				}
				string text = string.Empty;
				if (_strValueList.Count != 0)
				{
					_iOnShowIdx = (_iOnShowIdx + _strValueList.Count) % _strValueList.Count;
					if (_iOnShowIdx < _strValueList.Count)
					{
						text = _strValueList[_iOnShowIdx];
					}
				}
				childByName.text = text;
			}
		}

		protected const string TAB_GROUP_NAME = "GameSettingFuntionTab";

		protected const string ITEMLIST_LEFT_GROUP_LABEL = "TabLeftGroupLabel";

		protected const string ITEMLIST_RIGHT_GROUP_LABEL = "TabRightGroupLabel";

		protected MovieClip _mcRoot;

		protected MovieClip _mcLeftMenuList;

		protected MovieClip _mcRightMenuList;

		protected MovieClip _mcPresetScheme;

		protected MovieClip _mcDescription;

		protected GClass25 _btnBack = new GClass25();

		protected GClass25 _btnSave = new GClass25();

		protected GClass25 _btnReset = new GClass25();

		protected SettingMenuList _leftMenuListPanel = new SettingMenuList();

		protected SettingMenuList _rightMenuListPanel = new SettingMenuList();

		protected SettingCategory _curCategory;

		protected Dictionary<SettingCategory, List<GameSettingMgr.SettingItemData>> _settingConfigData = new Dictionary<SettingCategory, List<GameSettingMgr.SettingItemData>>();

		protected Dictionary<string, SettingCatogoryTab> _tabDic = new Dictionary<string, SettingCatogoryTab>();

		protected GameSettingMgr.SettingItemData _leftPanelOnFocusItem;

		protected bool _bRightPanelOnShow;

		public SettingCategory SettingCategory_0 => _curCategory;

		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			bool result = false;
			if (movieClip.name.Contains("Tab_"))
			{
				SettingCatogoryTab value = null;
				if (!_tabDic.TryGetValue(movieClip.name, out value))
				{
					value = new SettingCatogoryTab();
					value.bool_5 = false;
					_tabDic.Add(movieClip.name, value);
				}
				value.method_0(movieClip);
				TextField childByName = movieClip.getChildByName<TextField>("textField");
				if (childByName != null)
				{
					value.String_2 = childByName.text;
				}
				result = true;
			}
			else
			{
				switch (movieClip.name)
				{
				case "btnBack":
					_btnBack.method_0(movieClip);
					_btnBack.removeAllEventListeners(MouseEvent.CLICK);
					_btnBack.addEventListener(MouseEvent.CLICK, method_12);
					result = true;
					break;
				case "btnReset":
					_btnReset.method_0(movieClip);
					_btnReset.removeAllEventListeners(MouseEvent.CLICK);
					_btnReset.addEventListener(MouseEvent.CLICK, method_14);
					result = true;
					break;
				case "btnSave":
					_btnSave.method_0(movieClip);
					_btnSave.removeAllEventListeners(MouseEvent.CLICK);
					_btnSave.addEventListener(MouseEvent.CLICK, method_13);
					result = true;
					break;
				case "mcLeftDetail":
				{
					_mcLeftMenuList = movieClip;
					MovieClip childByName3 = _mcLeftMenuList.getChildByName<MovieClip>("mcItemList");
					if (childByName3 != null)
					{
						_leftMenuListPanel.String_2 = "TabLeftGroupLabel";
						_leftMenuListPanel.method_0(childByName3);
						_leftMenuListPanel.removeAllEventListeners(EVT_MOUSE_ENTER_SETTINGITEM);
						_leftMenuListPanel.addEventListener(EVT_MOUSE_ENTER_SETTINGITEM, method_8);
						_leftMenuListPanel.removeAllEventListeners(EVT_MOUSE_LEAVE_SETTINGITEM);
						_leftMenuListPanel.addEventListener(EVT_MOUSE_LEAVE_SETTINGITEM, method_9);
						_leftMenuListPanel.removeAllEventListeners(EVT_SETTINGITEM_DATA_CHANGED);
						_leftMenuListPanel.addEventListener(EVT_SETTINGITEM_DATA_CHANGED, method_17);
						_leftMenuListPanel.removeAllEventListeners(EVT_CLICK_SETTINGITEM);
						_leftMenuListPanel.addEventListener(EVT_CLICK_SETTINGITEM, method_7);
					}
					result = true;
					break;
				}
				case "mcRightDetail":
					_rightMenuListPanel.String_2 = "TabRightGroupLabel";
					_rightMenuListPanel.removeAllEventListeners(EVT_CLICK_LEFT_KEY);
					_rightMenuListPanel.removeAllEventListeners(EVT_CLICK_RIGHT_KEY);
					_rightMenuListPanel.addEventListener(EVT_CLICK_LEFT_KEY, method_17);
					_rightMenuListPanel.addEventListener(EVT_CLICK_RIGHT_KEY, method_17);
					_mcRightMenuList = movieClip;
					_mcRightMenuList.visible = false;
					_mcRightMenuList.addFrameScript("normal", method_10);
					_mcRightMenuList.addFrameScript("fadein", method_10);
					_mcRightMenuList.addFrameScript("fadeout", method_10);
					_mcRightMenuList.addFrameScript("fadeoutend", method_11);
					result = true;
					break;
				case "mcPresetScheme":
					_mcPresetScheme = movieClip;
					_mcPresetScheme.visible = false;
					result = true;
					break;
				case "mcDescription":
				{
					_mcDescription = movieClip;
					TextField childByName2 = _mcDescription.getChildByName<TextField>("textDescription");
					if (childByName2 != null)
					{
						childByName2.text = null;
					}
					result = true;
					break;
				}
				}
			}
			return result;
		}

		protected override void vmethod_0()
		{
			base.vmethod_0();
			_mcRoot = base.DisplayObjectContainer_0 as MovieClip;
			List<SettingCatogoryTab> list = new List<SettingCatogoryTab>(_tabDic.Values);
			list.Sort(method_6);
			foreach (SettingCatogoryTab item in list)
			{
				item.String_1 = "GameSettingFuntionTab";
				item.bool_5 = false;
			}
			GClass17.smethod_0("GameSettingFuntionTab")?.addEventListener(CEvent.CHANGED, method_15);
			list[0].Boolean_3 = true;
			method_16();
		}

		public void method_5(Dictionary<SettingCategory, List<GameSettingMgr.SettingItemData>> dictionary_0)
		{
			if (_settingConfigData != dictionary_0)
			{
				_mcRightMenuList.visible = false;
			}
			_settingConfigData = dictionary_0;
			method_16();
		}

		protected int method_6(SettingCatogoryTab settingCatogoryTab_0, SettingCatogoryTab settingCatogoryTab_1)
		{
			return settingCatogoryTab_0.Int32_0 - settingCatogoryTab_1.Int32_0;
		}

		protected void method_7(CEvent cevent_0)
		{
			if (cevent_0 is GClass55 gClass && _leftPanelOnFocusItem != gClass.object_0)
			{
				if (_leftPanelOnFocusItem != null && _leftPanelOnFocusItem.config != null && _leftPanelOnFocusItem.config.mFunctionType == SettingFunctionType.CustomKeyBinding)
				{
					_mcRightMenuList.gotoAndPlay("fadeout");
				}
				GameSettingMgr.SettingItemData settingItemData = gClass.object_0 as GameSettingMgr.SettingItemData;
				if (settingItemData == null || settingItemData.config == null || settingItemData.config.mFunctionType != SettingFunctionType.CustomKeyBinding || _mcRightMenuList == null)
				{
				}
				_leftPanelOnFocusItem = settingItemData;
				dispatchEvent(gClass);
			}
		}

		protected void method_8(CEvent cevent_0)
		{
			if (!(cevent_0 is GClass55 { object_0: GameSettingMgr.SettingItemData { config: not null } object_ }))
			{
				return;
			}
			if (_mcDescription != null)
			{
				TextField childByName = _mcDescription.getChildByName<TextField>("textDescription");
				if (childByName != null)
				{
					childByName.text = LocalizedString.smethod_0(new LocalizedString(object_.config.mDescription));
				}
			}
			if (object_.config.mFunctionType == SettingFunctionType.CustomKeyBinding && !_bRightPanelOnShow)
			{
				_mcRightMenuList.visible = true;
				_mcRightMenuList.gotoAndPlay("fadein");
				_rightMenuListPanel.method_5(object_.children, bool_0: true);
				_bRightPanelOnShow = true;
			}
		}

		protected void method_9(CEvent cevent_0)
		{
			if (!(cevent_0 is GClass55 { object_0: GameSettingMgr.SettingItemData { config: not null } object_ }))
			{
				return;
			}
			if (_mcDescription != null)
			{
				TextField childByName = _mcDescription.getChildByName<TextField>("textDescription");
				if (childByName != null)
				{
					childByName.text = string.Empty;
				}
			}
			if (object_.config.mFunctionType != SettingFunctionType.CustomKeyBinding && _bRightPanelOnShow)
			{
				_mcRightMenuList.gotoAndPlay("fadeout");
				_bRightPanelOnShow = false;
			}
		}

		protected void method_10(CEvent cevent_0)
		{
			MovieClip childByName = _mcRightMenuList.getChildByName<MovieClip>("mcItemList");
			if (childByName != null)
			{
				_rightMenuListPanel.method_0(childByName);
				_rightMenuListPanel.method_5();
			}
		}

		protected void method_11(CEvent cevent_0)
		{
			_mcRightMenuList.visible = false;
		}

		protected void method_12(CEvent cevent_0)
		{
			dispatchEvent(new CEvent(EVT_CLICK_BACK));
		}

		protected void method_13(CEvent cevent_0)
		{
			dispatchEvent(new CEvent(EVT_CLICK_SAVE));
		}

		protected void method_14(CEvent cevent_0)
		{
			dispatchEvent(new CEvent(EVT_CLICK_RESET));
		}

		protected void method_15(CEvent cevent_0)
		{
			if (GClass17.smethod_0("GameSettingFuntionTab").gclass25_0 is SettingCatogoryTab settingCatogoryTab)
			{
				_curCategory = settingCatogoryTab.SettingCategory_0;
				if (settingCatogoryTab.SettingCategory_0 != SettingCategory.Control)
				{
					if (_mcRightMenuList != null)
					{
						_mcRightMenuList.visible = false;
					}
					if (_mcPresetScheme != null)
					{
						_mcPresetScheme.visible = false;
					}
				}
			}
			method_16();
		}

		protected void method_16()
		{
			List<GameSettingMgr.SettingItemData> value = null;
			_settingConfigData.TryGetValue(_curCategory, out value);
			if (_leftMenuListPanel != null)
			{
				_leftMenuListPanel.method_5(value, bool_0: true);
				GClass17.smethod_0("TabLeftGroupLabel")?.method_3(0);
			}
			if (_rightMenuListPanel != null)
			{
				_rightMenuListPanel.method_5();
			}
		}

		protected void method_17(CEvent cevent_0)
		{
			dispatchEvent(cevent_0);
		}
	}
}
