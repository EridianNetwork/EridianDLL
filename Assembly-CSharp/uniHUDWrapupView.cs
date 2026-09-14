using System;
using Core;
using ns0;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;
using UnityEngine;
using XsdSettings;

// Token: 0x0200084D RID: 2125
public class uniHUDWrapupView : HUDWrapupView
{
	// Token: 0x06003996 RID: 14742 RVA: 0x000266D4 File Offset: 0x000248D4
	public override void vmethod_2()
	{
		base.vmethod_2();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("Wrap_Up.swf", "Whole", new FuncLoad(this.method_3));
	}

	// Token: 0x06003997 RID: 14743 RVA: 0x0010C368 File Offset: 0x0010A568
	public override void vmethod_3()
	{
		base.vmethod_3();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._wrapupPanel);
		this._wrapupPanel = null;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("Wrap_Up.swf");
	}

	// Token: 0x06003998 RID: 14744 RVA: 0x0010C3B8 File Offset: 0x0010A5B8
	private void method_3(MovieClip movieClip_0)
	{
		this._wrapupPanel = new uniHUDWrapupView.WrapupPanel();
		this._wrapupPanel.method_0(movieClip_0);
		this._wrapupPanel.Boolean_0 = false;
		DebugUtils.Log(LogCategory.GUI, ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_9() + "Add Wrap Up!!!" + DateTime.Today.ToString());
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_33(this._wrapupPanel);
		this._wrapupPanel.method_12(string.Empty, 0, 0f, 0, string.Empty, string.Empty, 3f, 0, string.Empty, 0, 0);
	}

	// Token: 0x06003999 RID: 14745 RVA: 0x0010C45C File Offset: 0x0010A65C
	public override void vmethod_6()
	{
		base.vmethod_6();
		if (this._wrapupPanel != null && !this._wrapupPanel.Boolean_0)
		{
			this._wrapupPanel.Boolean_0 = true;
			this._wrapupPanel.method_12(this.m_Name, this.m_Killed, this.m_Detail, this.m_Hurt, this.m_LevelName, LocalizedString.smethod_0(new LocalizedString(this.m_Difficulty.ToString())), this.m_Time, this.m_ExpGained, this.m_instanceGrade.ToString(), this.m_GuildExp, this.m_Money);
		}
	}

	// Token: 0x0600399A RID: 14746 RVA: 0x0010C500 File Offset: 0x0010A700
	public override void vmethod_5()
	{
		MonoSingleton<InputManager>.Instance.method_1(false);
		this._wrapupPanel.Boolean_0 = true;
		this._wrapupPanel.method_12(string.Empty, 0, 0f, 0, string.Empty, string.Empty, 3f, 0, string.Empty, 0, 0);
	}

	// Token: 0x0600399B RID: 14747 RVA: 0x00026706 File Offset: 0x00024906
	public void method_4()
	{
		if (this._wrapupPanel != null)
		{
			this._wrapupPanel.method_8();
		}
	}

	// Token: 0x04002845 RID: 10309
	private uniHUDWrapupView.WrapupPanel _wrapupPanel;

	// Token: 0x0200084E RID: 2126
	private class WrapupPanel : GClass51
	{
		// Token: 0x0600399D RID: 14749 RVA: 0x0010C5AC File Offset: 0x0010A7AC
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.mc_root = this.displayObjectContainer_0 as MovieClip;
			if (this.mc_root == null)
			{
				DebugUtils.LogWarning(LogCategory.GUI, "UIWarning: WrapupPanel onInit() 'mc_root' is null! WrapupPanel won't work!!!");
				return;
			}
			this.mc_Total = this.mc_root.getChildByName<MovieClip>("mc_total");
			this.mc_Energy = this.mc_root.getChildByName<MovieClip>("mc_energy");
			if (this.mc_Energy != null)
			{
				this.mc_Energy.addFrameScript("Full", new EventDispatcher.EventCallback(this.method_5));
				this.mc_Energy.addFrameScript("Normal", new EventDispatcher.EventCallback(this.method_5));
				this.mc_Energy.addFrameScript("empty", new EventDispatcher.EventCallback(this.method_5));
			}
			else
			{
				DebugUtils.Log(LogCategory.GUI, "Energy is null~~~~");
			}
			this.m_textLevelName = this.mc_Total.getChildByName<TextField>("textName");
			this.m_textTime = this.mc_Total.getChildByName<MovieClip>("mc_time").getChildByName<MovieClip>("mc_timeLayer").getChildByName<TextField>("textTime");
			this.m_textHurt = this.mc_Total.getChildByName<TextField>("textHurt");
			this.m_textKilled = this.mc_Total.getChildByName<TextField>("textKilled");
			this.m_textDetail = this.mc_Total.getChildByName<TextField>("textDetail");
			this.m_textDifficulty = this.mc_Total.getChildByName<TextField>("textDifficulty");
			this.m_Grade = this.mc_Total.getChildByName<MovieClip>("mc_grade");
			this.m_textGuildExp = this.mc_Total.getChildByName<MovieClip>("mc_GuildExp").getChildByName<TextField>("textExp");
			this.m_textExp = this.mc_Total.getChildByName<MovieClip>("mc_Exp").getChildByName<TextField>("textExp");
			this.m_textCountDown = this.mc_Total.getChildByName<MovieClip>("mc_countdown").getChildByName<TextField>("textCountDown");
			this.m_textCountDown.text = string.Empty;
			this.m_MoneyClip = this.mc_Total.getChildByName<MovieClip>("mc_Money").getChildByName<TextField>("textExp");
			if (this.m_Grade != null)
			{
				this.m_Grade.visible = false;
			}
			MovieClip childByName = this.mc_Total.getChildByName<MovieClip>("mc_slot1");
			MovieClip childByName2 = this.mc_Total.getChildByName<MovieClip>("mc_slot2");
			this.m_Box1 = new GClass24();
			this.m_Box1.method_0(childByName);
			this.m_Box2 = new GClass24();
			this.m_Box2.method_0(childByName2);
		}

		// Token: 0x17000310 RID: 784
		// (get) Token: 0x0600399F RID: 14751 RVA: 0x00026747 File Offset: 0x00024947
		// (set) Token: 0x0600399E RID: 14750 RVA: 0x0002671B File Offset: 0x0002491B
		public virtual bool Boolean_0
		{
			get
			{
				return this.mc_root != null && this.mc_root.visible;
			}
			set
			{
				MonoSingleton<AppManager>.Instance.method_0().method_15(value, base.String_0);
				if (this.mc_root != null)
				{
					this.mc_root.visible = value;
				}
			}
		}

		// Token: 0x060039A0 RID: 14752 RVA: 0x0010C820 File Offset: 0x0010AA20
		private void method_5(CEvent cevent_0)
		{
			TextField childByName = this.mc_Energy.getChildByName<TextField>("tf_energy");
			childByName.text = Utility.smethod_8(ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_6());
		}

		// Token: 0x060039A1 RID: 14753 RVA: 0x0010C854 File Offset: 0x0010AA54
		private void method_6()
		{
			if (this.mc_Energy != null)
			{
				TextField childByName = this.mc_Energy.getChildByName<TextField>("tf_energy");
				int num = ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_6();
				childByName.text = Utility.smethod_8(num);
				if (num > 2)
				{
					this.mc_Energy.gotoAndStop("Full");
				}
				else if (num <= 0)
				{
					this.mc_Energy.gotoAndStop("empty");
				}
				else
				{
					this.mc_Energy.gotoAndStop("Normal");
				}
			}
		}

		// Token: 0x060039A2 RID: 14754 RVA: 0x0010C8D0 File Offset: 0x0010AAD0
		protected void method_7()
		{
			if (LuckyBoxManager.smethod_0().method_4(false) != 0)
			{
				this.m_bShowSlot1 = true;
				ItemDNA itemDNA = LuckyBoxManager.smethod_0().method_7(0, false);
				if (itemDNA != null)
				{
					MovieClip childByName = this.mc_Total.getChildByName<MovieClip>("mc_slot1").getChildByName<MovieClip>("mc_loading");
					TextField childByName2 = this.mc_Total.getChildByName<MovieClip>("mc_slot1").getChildByName<TextField>("textNumber");
					childByName.visible = false;
					if (itemDNA.m_type == ItemType.Material)
					{
						MovieClip movieClip = (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InventoryView>() as uniInventoryView).method_23(itemDNA);
						movieClip.name = "icon";
						MovieClip childByName3 = this.mc_Total.getChildByName<MovieClip>("mc_slot1").getChildByName<MovieClip>("icons");
						childByName3.stopAll();
						childByName3.addChild(movieClip);
					}
					else if (itemDNA.m_type == ItemType.Money)
					{
						MovieClip movieClip2 = (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InventoryView>() as uniInventoryView).method_22();
						movieClip2.name = "icon";
						MovieClip childByName4 = this.mc_Total.getChildByName<MovieClip>("mc_slot1").getChildByName<MovieClip>("icons");
						childByName4.stopAll();
						childByName4.addChild(movieClip2);
						childByName2.text = itemDNA.m_value.ToString();
					}
					else
					{
						Texture2D texture2D = MonoSingleton<DNAPortrait>.Instance.method_3(itemDNA, 0, 0, TexPostEffectMgr.POST_EFFECT_TYPE.POST_EFFECT_UI);
						GClass43 gclass = new GClass43();
						gclass.method_0(this.mc_Total.getChildByName<MovieClip>("mc_slot1").getChildByName<MovieClip>("icons"));
						gclass.vmethod_8(texture2D);
					}
					if (itemDNA.m_type != ItemType.Money)
					{
						this.m_Box1.GInterface1_0 = new ItemTips(itemDNA);
					}
				}
			}
			if (LuckyBoxManager.smethod_0().method_4(true) != 0)
			{
				this.m_bShowSlot2 = true;
				ItemDNA itemDNA2 = LuckyBoxManager.smethod_0().method_7(0, true);
				if (itemDNA2 != null)
				{
					MovieClip childByName5 = this.mc_Total.getChildByName<MovieClip>("mc_slot2").getChildByName<MovieClip>("mc_loading");
					childByName5.visible = false;
					TextField childByName6 = this.mc_Total.getChildByName<MovieClip>("mc_slot1").getChildByName<TextField>("textNumber");
					if (itemDNA2.m_type == ItemType.Material)
					{
						MovieClip movieClip3 = (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InventoryView>() as uniInventoryView).method_23(itemDNA2);
						movieClip3.name = "icon";
						MovieClip childByName7 = this.mc_Total.getChildByName<MovieClip>("mc_slot2").getChildByName<MovieClip>("icons");
						childByName7.stopAll();
						childByName7.addChild(movieClip3);
					}
					else if (itemDNA2.m_type == ItemType.Money)
					{
						MovieClip movieClip4 = (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InventoryView>() as uniInventoryView).method_22();
						movieClip4.name = "icon";
						MovieClip childByName8 = this.mc_Total.getChildByName<MovieClip>("mc_slot2").getChildByName<MovieClip>("icons");
						childByName8.stopAll();
						childByName8.addChild(movieClip4);
						childByName6.text = itemDNA2.m_value.ToString();
					}
					else
					{
						Texture2D texture2D2 = MonoSingleton<DNAPortrait>.Instance.method_3(itemDNA2, 0, 0, TexPostEffectMgr.POST_EFFECT_TYPE.POST_EFFECT_UI);
						GClass43 gclass2 = new GClass43();
						gclass2.method_0(this.mc_Total.getChildByName<MovieClip>("mc_slot2").getChildByName<MovieClip>("icons"));
						gclass2.vmethod_8(texture2D2);
					}
					if (itemDNA2.m_type != ItemType.Money)
					{
						this.m_Box2.GInterface1_0 = new ItemTips(itemDNA2);
					}
				}
			}
		}

		// Token: 0x060039A3 RID: 14755 RVA: 0x0002675E File Offset: 0x0002495E
		public void method_8()
		{
			if (this.mc_Button != null)
			{
				this.method_7();
				this.mc_Button.Boolean_6 = true;
				this.mc_Button.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_10));
			}
		}

		// Token: 0x060039A4 RID: 14756 RVA: 0x0010CC18 File Offset: 0x0010AE18
		public void method_9()
		{
			if (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDTreasureBoxView>().Boolean_1)
			{
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDTreasureBoxView>().Boolean_1 = false;
			}
			this.mc_root.addFrameScript("fadeoutover", new EventDispatcher.EventCallback(this.method_11));
			this.mc_root.gotoAndPlay("fadeout");
		}

		// Token: 0x060039A5 RID: 14757 RVA: 0x00026797 File Offset: 0x00024997
		private void method_10(CEvent cevent_0)
		{
			this.mc_Total.removeEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_20));
			this.method_9();
		}

		// Token: 0x060039A6 RID: 14758 RVA: 0x0010CC80 File Offset: 0x0010AE80
		private void method_11(CEvent cevent_0)
		{
			this.mc_root.removeFrameScript("fadeoutover", new EventDispatcher.EventCallback(this.method_11));
			this.Boolean_0 = false;
			if (LobbyManager.smethod_0().Lobby_1 != null)
			{
				LobbyManager.smethod_0().method_24();
			}
			Playlist playlist = null;
			if (MonoSingleton<Session>.Instance != null)
			{
				string text = MonoSingleton<Session>.Instance.method_1();
				if (!string.IsNullOrEmpty(text))
				{
					playlist = MatchmakingService.MatchmakingService_0.method_2(text);
				}
			}
			if (playlist != null)
			{
				MonoSingleton<GameFlowManager>.Instance.method_12(playlist.m_id, MatchmakingService.smethod_0(playlist.m_gameMode));
				return;
			}
			GameFlowManager prop_ = MonoSingleton<GameFlowManager>.Instance;
			if (prop_ != null)
			{
				prop_.method_11();
			}
		}

		// Token: 0x060039A7 RID: 14759 RVA: 0x0010CD2C File Offset: 0x0010AF2C
		public void method_12(string string_1, int int_0, float float_0, int int_1, string string_2, string string_3, float float_1, int int_2, string string_4, int int_3, int int_4 = 0)
		{
			if (this.m_Grade != null)
			{
				this.m_Grade.visible = false;
			}
			this.m_bShowGrade = false;
			this.mKilled = int_0;
			this.mDetail = float_0;
			this.mHurt = int_1;
			this.mLevelName = string_2;
			this.mDifficulty = string_3;
			this.mTime = float_1;
			this.m_xpBonus = int_2;
			this.m_Money = int_4;
			this.m_GuildExp = int_3;
			this.mGrade = string_4;
			this.method_13();
			this.method_6();
			this.mc_root.gotoAndPlay("fadein");
			this.mc_root.addFrameScript("normal", new EventDispatcher.EventCallback(this.method_14));
		}

		// Token: 0x060039A8 RID: 14760 RVA: 0x0010CDDC File Offset: 0x0010AFDC
		private void method_13()
		{
			int num = (int)this.mTime;
			int num2 = num / 60;
			int num3 = num - num2 * 60;
			string text = "00";
			string text2 = Utility.smethod_8(num2);
			if (num3 != 0)
			{
				if (num3 < 10)
				{
					text = Utility.smethod_5("0", Utility.smethod_8(num3));
				}
				else
				{
					text = Utility.smethod_8(num3);
				}
			}
			this.m_strTime = Utility.smethod_6(Utility.smethod_5(text2, "'"), text, "''");
		}

		// Token: 0x060039A9 RID: 14761 RVA: 0x0010CE54 File Offset: 0x0010B054
		private void method_14(CEvent cevent_0)
		{
			this.mc_root.stop();
			this.mc_root.removeFrameScript("normal", new EventDispatcher.EventCallback(this.method_14));
			this.mc_Total = this.mc_root.getChildByName<MovieClip>("mc_total");
			this.mc_Total.gotoAndPlay("show detail");
			this.mc_Total.addEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_20));
			if (this.Boolean_0)
			{
				this.m_CountDownTime = 65f;
				this.mc_Total.addEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_19));
				this.mc_Total.addFrameScript("off", new EventDispatcher.EventCallback(this.method_17));
				this.mc_Total.addFrameScript("EXP_showoff", new EventDispatcher.EventCallback(this.method_15));
				this.mc_Total.addFrameScript("get grade", new EventDispatcher.EventCallback(this.method_16));
			}
		}

		// Token: 0x060039AA RID: 14762 RVA: 0x000267BC File Offset: 0x000249BC
		private void method_15(CEvent cevent_0)
		{
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("UI_Wrapup_Pop_up");
			this.mc_Total.removeFrameScript("EXP_showoff", new EventDispatcher.EventCallback(this.method_15));
		}

		// Token: 0x060039AB RID: 14763 RVA: 0x000267F4 File Offset: 0x000249F4
		private void method_16(CEvent cevent_0)
		{
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("UI_Wrapup_Result");
			this.mc_Total.removeFrameScript("get grade", new EventDispatcher.EventCallback(this.method_16));
			this.m_bShowGrade = true;
		}

		// Token: 0x060039AC RID: 14764 RVA: 0x00026833 File Offset: 0x00024A33
		private void method_17(CEvent cevent_0)
		{
			if (!this.m_LuckBoxShow)
			{
				this.method_18();
			}
		}

		// Token: 0x060039AD RID: 14765 RVA: 0x0010CF54 File Offset: 0x0010B154
		private void method_18()
		{
			this.m_LuckBoxShow = true;
			this.mc_Total.removeFrameScript("off", new EventDispatcher.EventCallback(this.method_17));
			this.mc_Button = new GClass25();
			this.mc_Button.method_0(this.mc_Total.getChildByName<MovieClip>("mc_back"));
			if (this.mGrade != "F")
			{
				DebugUtils.Log(LogCategory.GUI, ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_9() + " onStop:Set LuckyBox True!!");
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<HUDTreasureBoxView>().Boolean_1 = true;
			}
			else
			{
				this.mc_Button.Boolean_6 = true;
				this.mc_Button.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_10));
			}
		}

		// Token: 0x060039AE RID: 14766 RVA: 0x0010D018 File Offset: 0x0010B218
		private void method_19(CEvent cevent_0)
		{
			this.m_textCountDown = this.mc_Total.getChildByName<MovieClip>("mc_countdown").getChildByName<TextField>("textCountDown");
			this.m_CountDownTime -= Time.deltaTime;
			int num = (int)(this.m_CountDownTime - this.m_CountDownInterval);
			if (num <= 55 && !this.m_LuckBoxShow)
			{
				this.method_18();
			}
			if (this.m_CountDownTime <= 0f)
			{
				this.m_CountDownTime = 0f;
			}
			if (num <= 0)
			{
				num = 0;
			}
			this.m_textCountDown.text = Utility.smethod_5(Utility.smethod_8(num), "''");
			if (num == 0 && !LuckyBoxManager.smethod_0().m_bLuckyBoxOpened && this.mGrade != "F")
			{
				LuckyBoxManager.smethod_0().method_2();
			}
			if (this.m_CountDownTime == 0f && (!TreasureBoxBehaviour.m_bPlayOpenBox || !TreasureBoxBehaviour.m_bNeedReplay))
			{
				this.mc_Total.removeEventListener(CEvent.ENTER_FRAME, new EventDispatcher.EventCallback(this.method_19));
				this.method_9();
			}
		}

		// Token: 0x060039AF RID: 14767 RVA: 0x0010D11C File Offset: 0x0010B31C
		private void method_20(CEvent cevent_0)
		{
			try
			{
				this.m_textLevelName = this.mc_Total.getChildByName<TextField>("textName");
				this.m_textKilled = this.mc_Total.getChildByName<TextField>("textKilled");
				this.m_textDetail = this.mc_Total.getChildByName<TextField>("textDetail");
				this.m_textTime = this.mc_Total.getChildByName<MovieClip>("mc_time").getChildByName<MovieClip>("mc_timeLayer").getChildByName<TextField>("textTime");
				this.m_textHurt = this.mc_Total.getChildByName<TextField>("textHurt");
				this.m_textDifficulty = this.mc_Total.getChildByName<TextField>("textDifficulty");
				this.m_Grade = this.mc_Total.getChildByName<MovieClip>("mc_grade");
				this.m_textGuildExp = this.mc_Total.getChildByName<MovieClip>("mc_GuildExp").getChildByName<TextField>("textExp");
				this.m_textExp = this.mc_Total.getChildByName<MovieClip>("mc_Exp").getChildByName<TextField>("textExp");
				this.m_MoneyClip = this.mc_Total.getChildByName<MovieClip>("mc_Money").getChildByName<TextField>("textExp");
				MovieClip childByName = this.mc_Total.getChildByName<MovieClip>("mc_slot1");
				MovieClip childByName2 = this.mc_Total.getChildByName<MovieClip>("mc_slot2");
				if (childByName != null)
				{
					if (this.m_bShowSlot1)
					{
						childByName.visible = true;
					}
					else
					{
						childByName.visible = false;
					}
				}
				if (childByName2 != null)
				{
					if (this.m_bShowSlot2)
					{
						childByName2.visible = true;
					}
					else
					{
						childByName2.visible = false;
					}
				}
				if (this.Boolean_0)
				{
					if (this.m_Grade != null)
					{
						this.m_Grade.stopAll();
						this.m_Grade.gotoAndStop(this.mGrade);
						this.m_Grade.visible = this.m_bShowGrade;
					}
					if (this.m_textLevelName != null && this.m_textLevelName.text != this.mLevelName)
					{
						this.m_textLevelName.text = this.mLevelName;
					}
					if (this.m_textKilled != null && this.m_textKilled.text != Utility.smethod_8(this.mKilled))
					{
						this.m_textKilled.text = Utility.smethod_8(this.mKilled);
					}
					if (this.m_textDetail != null && this.m_textDetail.text != Utility.smethod_5(Utility.smethod_9(this.mDetail), "%"))
					{
						this.m_textDetail.text = Utility.smethod_5(Utility.smethod_9(this.mDetail), "%");
					}
					if (this.m_textHurt != null && this.m_textHurt.text != Utility.smethod_8(this.mHurt))
					{
						this.m_textHurt.text = Utility.smethod_8(this.mHurt);
					}
					if (this.m_textDifficulty != null && this.m_textDifficulty.text != this.mDifficulty)
					{
						this.m_textDifficulty.text = this.mDifficulty;
					}
					if (this.m_textLevelName != null && this.m_textLevelName.text != this.mLevelName)
					{
						this.m_textLevelName.text = this.mLevelName;
					}
					if (this.m_textTime != null && this.m_textTime.text != this.m_strTime)
					{
						this.m_textTime.text = this.m_strTime;
					}
					if (this.m_textExp != null)
					{
						UnityTextField unityTextField = (UnityTextField)this.m_textExp;
						unityTextField.Color_0 = Color.magenta;
						string text = Utility.smethod_5("XP ", Utility.smethod_8(this.m_xpBonus));
						if (this.m_xpBonus == 0 && ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_6() <= 0)
						{
							text = Utility.smethod_5(text, LocalizedString.smethod_0(new LocalizedString("No_Energy")));
						}
						if (this.m_textExp.text != text)
						{
							this.m_textExp.text = text;
						}
					}
					if (this.m_MoneyClip != null && this.m_MoneyClip.text != Utility.smethod_8(this.m_Money))
					{
						this.m_MoneyClip.text = Utility.smethod_8(this.m_Money);
					}
					if (this.m_textGuildExp != null && this.m_textGuildExp.text != Utility.smethod_8(this.m_GuildExp))
					{
						this.m_textGuildExp.text = Utility.smethod_8(this.m_GuildExp);
					}
				}
			}
			catch (Exception ex)
			{
				DebugUtils.LogError(LogCategory.GUI, ex.ToString());
			}
		}

		// Token: 0x060039B0 RID: 14768 RVA: 0x0000311B File Offset: 0x0000131B
		private void method_21()
		{
		}

		// Token: 0x04002846 RID: 10310
		public MovieClip mc_root;

		// Token: 0x04002847 RID: 10311
		public MovieClip mc_Total;

		// Token: 0x04002848 RID: 10312
		private TextField m_textLevelName;

		// Token: 0x04002849 RID: 10313
		private TextField m_textDetail;

		// Token: 0x0400284A RID: 10314
		private TextField m_textKilled;

		// Token: 0x0400284B RID: 10315
		private TextField m_textTime;

		// Token: 0x0400284C RID: 10316
		private TextField m_textExp;

		// Token: 0x0400284D RID: 10317
		private TextField m_textGuildExp;

		// Token: 0x0400284E RID: 10318
		private TextField m_textDifficulty;

		// Token: 0x0400284F RID: 10319
		private TextField m_textHurt;

		// Token: 0x04002850 RID: 10320
		private TextField m_textCountDown;

		// Token: 0x04002851 RID: 10321
		private MovieClip m_Grade;

		// Token: 0x04002852 RID: 10322
		private TextField m_MoneyClip;

		// Token: 0x04002853 RID: 10323
		private GClass25 mc_Button;

		// Token: 0x04002854 RID: 10324
		public bool m_LuckBoxShow;

		// Token: 0x04002855 RID: 10325
		public bool m_bShowSlot1;

		// Token: 0x04002856 RID: 10326
		public bool m_bShowSlot2;

		// Token: 0x04002857 RID: 10327
		private int mKilled;

		// Token: 0x04002858 RID: 10328
		private float mDetail;

		// Token: 0x04002859 RID: 10329
		private int mHurt;

		// Token: 0x0400285A RID: 10330
		private string mLevelName = string.Empty;

		// Token: 0x0400285B RID: 10331
		private string mDifficulty = "Normal";

		// Token: 0x0400285C RID: 10332
		private float mTime;

		// Token: 0x0400285D RID: 10333
		private string mGrade = "S";

		// Token: 0x0400285E RID: 10334
		private string m_strTime = string.Empty;

		// Token: 0x0400285F RID: 10335
		private int m_xpBonus;

		// Token: 0x04002860 RID: 10336
		private int m_Money;

		// Token: 0x04002861 RID: 10337
		private int m_GuildExp;

		// Token: 0x04002862 RID: 10338
		private bool m_bShowGrade;

		// Token: 0x04002863 RID: 10339
		private float m_CountDownTime = 65f;

		// Token: 0x04002864 RID: 10340
		private float m_CountDownInterval = 5f;

		// Token: 0x04002865 RID: 10341
		private GClass24 m_Box1;

		// Token: 0x04002866 RID: 10342
		private GClass24 m_Box2;

		// Token: 0x04002867 RID: 10343
		private MovieClip mc_Energy;
	}
}
