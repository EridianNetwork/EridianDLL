using System;
using System.Collections.Generic;
using Core;
using ns0;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;
using UnityEngine;
using XsdSettings;

// Token: 0x02000800 RID: 2048
public class uniGuildSearchView : GuildSearchView
{
	// Token: 0x06003742 RID: 14146 RVA: 0x000FD574 File Offset: 0x000FB774
	public override void vmethod_2()
	{
		base.vmethod_2();
		this._GuildSkillIcon.Clear();
		for (int i = 0; i < 8; i++)
		{
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("Skill_Buff_icon.swf", Utility.smethod_5("Movie_Skill", Utility.smethod_8(i)), new FuncLoad(this.method_6));
		}
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("Guild_flow.swf", "Panel_Guild", new FuncLoad(this.method_3));
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("Tips.swf", "Panel_Tips_Card", new FuncLoad(this.method_5));
	}

	// Token: 0x06003743 RID: 14147 RVA: 0x000FD628 File Offset: 0x000FB828
	public override void vmethod_3()
	{
		base.vmethod_3();
		this._GuildSkillIcon.Clear();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._guildSearchPanel);
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._guildManagePanel);
		this._guildSearchPanel = null;
		this._guildManagePanel = null;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("Skill_Buff_icon.swf");
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("Guild_flow.swf");
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("Tips.swf");
	}

	// Token: 0x06003744 RID: 14148 RVA: 0x00024ABA File Offset: 0x00022CBA
	private void method_3(MovieClip movieClip_0)
	{
		this._guildSearchPanel = new uniGuildSearchView.GuildSearchPanel();
		this._guildSearchPanel.method_0(movieClip_0);
		this._guildSearchPanel.Boolean_0 = false;
	}

	// Token: 0x06003745 RID: 14149 RVA: 0x00024AE0 File Offset: 0x00022CE0
	private void method_4(MovieClip movieClip_0)
	{
		this._guildManagePanel = new uniGuildSearchView.GuildManagePanel();
		this._guildManagePanel.method_0(movieClip_0);
		this._guildManagePanel.Boolean_0 = false;
	}

	// Token: 0x06003746 RID: 14150 RVA: 0x00024B06 File Offset: 0x00022D06
	private void method_5(MovieClip movieClip_0)
	{
		uniGuildSearchView.GuildTips._itemPanel = new ItemTipsPanel();
		uniGuildSearchView.GuildTips._itemPanel.method_0(movieClip_0);
	}

	// Token: 0x06003747 RID: 14151 RVA: 0x000FD6D4 File Offset: 0x000FB8D4
	private void method_6(MovieClip movieClip_0)
	{
		if (movieClip_0 == null)
		{
			return;
		}
		movieClip_0.name = movieClip_0.getSymbolName();
		if (!this._GuildSkillIcon.ContainsKey(movieClip_0.name))
		{
			this._GuildSkillIcon.Add(movieClip_0.getSymbolName(), movieClip_0);
		}
		if (this._GuildSkillIcon.Count == 8)
		{
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("Guild_flow.swf", "Panel_Guild_owner", new FuncLoad(this.method_4));
		}
	}

	// Token: 0x06003748 RID: 14152 RVA: 0x000FD750 File Offset: 0x000FB950
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		if (!bool_1)
		{
			if (!bool_0)
			{
				base.vmethod_1(bool_0, bool_1);
				if (this._guildSearchPanel.Boolean_0)
				{
					this._guildSearchPanel.Boolean_0 = false;
					(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._guildSearchPanel);
				}
				if (this._guildManagePanel.Boolean_0)
				{
					this._guildManagePanel.Boolean_0 = false;
					(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._guildManagePanel);
				}
				if (bool_0)
				{
					(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("UI_BackMenu_Open_Main");
				}
				else
				{
					(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("UI_BackMenu_Close_Main");
				}
			}
			if (GuildManager.smethod_0().method_6())
			{
				base.vmethod_1(bool_0, bool_1);
				if (bool_0)
				{
					(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_31(this._guildSearchPanel);
				}
				else
				{
					(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._guildSearchPanel);
				}
				this._guildSearchPanel.Boolean_0 = bool_0;
				if (bool_0)
				{
					GuildManager.smethod_0().method_67();
				}
			}
			else if (GuildManager.smethod_0().method_7())
			{
				if (bool_0)
				{
					(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_31(this._guildManagePanel);
				}
				else
				{
					(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._guildManagePanel);
				}
				if (bool_0)
				{
					GuildManager.smethod_0().method_14();
					GuildManager.smethod_0().method_94();
					if (GuildManager.smethod_0().method_8() || GuildManager.smethod_0().method_82())
					{
						GuildManager.smethod_0().method_22();
					}
				}
				base.vmethod_1(bool_0, bool_1);
				this._guildManagePanel.Boolean_0 = bool_0;
			}
		}
		else
		{
			base.vmethod_1(bool_0, bool_1);
			if (!bool_0)
			{
				if (this._guildSearchPanel.Boolean_0)
				{
					this._guildSearchPanel.Boolean_0 = false;
				}
				if (this._guildManagePanel.Boolean_0)
				{
					this._guildManagePanel.Boolean_0 = false;
				}
			}
		}
	}

	// Token: 0x06003749 RID: 14153 RVA: 0x000FD954 File Offset: 0x000FBB54
	public override void vmethod_5(GuildSearchView.GuildSearchPart guildSearchPart_0 = GuildSearchView.GuildSearchPart.e_None)
	{
		if (this._guildSearchPanel != null && this._guildSearchPanel.Boolean_0)
		{
			this._guildSearchPanel.method_18(guildSearchPart_0);
		}
		if (this._guildManagePanel != null && this._guildManagePanel.Boolean_0)
		{
			this._guildManagePanel.method_15(guildSearchPart_0);
		}
	}

	// Token: 0x0600374A RID: 14154 RVA: 0x00024B1E File Offset: 0x00022D1E
	public override void vmethod_6(int int_0)
	{
		if (this._guildSearchPanel != null && this._guildSearchPanel.Boolean_0)
		{
			this._guildSearchPanel.method_16(int_0);
		}
	}

	// Token: 0x0600374B RID: 14155 RVA: 0x00024B41 File Offset: 0x00022D41
	public override int vmethod_7()
	{
		if (this._guildSearchPanel != null && this._guildSearchPanel.Boolean_0)
		{
			return this._guildSearchPanel.method_17();
		}
		return base.vmethod_7();
	}

	// Token: 0x0600374C RID: 14156 RVA: 0x000FD9A4 File Offset: 0x000FBBA4
	public void method_7(MovieClip movieClip_0, string string_0)
	{
		if (movieClip_0 != null && string_0.Length != 0)
		{
			movieClip_0.gotoAndStop("EndFrame");
			MovieClip childByName = movieClip_0.getChildByName<MovieClip>("mcIconImg");
			childByName.visible = false;
			if (movieClip_0.getChildByName<MovieClip>(string_0) == null)
			{
				MovieClip movieClip = null;
				this._GuildSkillIcon.TryGetValue(string_0, out movieClip);
				if (movieClip == null)
				{
					return;
				}
				MovieClip movieClip2 = movieClip.newInstance();
				movieClip2.x = 0f;
				movieClip2.y = 0f;
				movieClip2.name = movieClip.name;
				movieClip_0.addChildAt(movieClip2, movieClip_0.getChildIndex(childByName));
			}
			return;
		}
	}

	// Token: 0x0400264C RID: 9804
	private uniGuildSearchView.GuildSearchPanel _guildSearchPanel;

	// Token: 0x0400264D RID: 9805
	private uniGuildSearchView.GuildManagePanel _guildManagePanel;

	// Token: 0x0400264E RID: 9806
	protected Dictionary<string, MovieClip> _GuildSkillIcon = new Dictionary<string, MovieClip>();

	// Token: 0x02000801 RID: 2049
	private class GuildSearchPanel : GClass51
	{
		// Token: 0x0600374D RID: 14157 RVA: 0x000FDA38 File Offset: 0x000FBC38
		public GuildSearchPanel()
		{
			this._guildButtons = new GClass32[this.GUILD_TOTAL];
			this._guildMessageButtons = new GClass34[this.GUILD_MESSAGE_TOTAL];
		}

		// Token: 0x0600374E RID: 14158 RVA: 0x000FDAAC File Offset: 0x000FBCAC
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.mc_root = this.displayObjectContainer_0 as MovieClip;
			if (this.mc_root == null)
			{
				DebugUtils.LogWarning(LogCategory.GUI, "UIWarning: GuildSearchPanel onInit() 'mc_root' is null! GuildSearchPanel won't work!!!");
				return;
			}
			this.mc_root.visible = false;
			this.mc_root.stopAll();
			this.mc_Total = this.mc_root.getChildByName<MovieClip>("mc_root");
			this.mc_GuildList = this.mc_Total.getChildByName<MovieClip>("mc_search");
			this.mc_GuildMessageList = this.mc_Total.getChildByName<MovieClip>("mc_record");
			this.mc_SearchPanelButton = new GClass40();
			this.mc_SearchPanelButton.method_0(this.mc_Total.getChildByName<MovieClip>("mc_search_btn"));
			this.mc_SearchPanelButton.addEventListener(GClass53.string_4, new EventDispatcher.EventCallback(this.method_12));
			this.mc_SearchPanelButton.String_1 = "GuildPanel";
			this.mc_SearchPanelButton.bool_5 = false;
			this.mc_MessagePanelButton = new GClass40();
			this.mc_MessagePanelButton.method_0(this.mc_Total.getChildByName<MovieClip>("mc_invitation"));
			this.mc_MessagePanelButton.addEventListener(GClass53.string_4, new EventDispatcher.EventCallback(this.method_13));
			this.mc_MessagePanelButton.String_1 = "GuildPanel";
			this.mc_MessagePanelButton.bool_5 = false;
			this.mc_CloseButton = new GClass25();
			this.mc_CloseButton.method_0(this.mc_Total.getChildByName<MovieClip>("mcBtnClose"));
			this.mc_CloseButton.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_8));
			this.mc_SearchButton = new GClass25();
			this.mc_SearchButton.method_0(this.mc_GuildList.getChildByName<MovieClip>("mc_searchBtn"));
			this.mc_SearchButton.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_9));
			this.mc_GuildList.visible = true;
			this.mc_GuildMessageList.visible = false;
			this.mc_QuestCheck = new GClass40();
			this.mc_QuestCheck.method_0(this.mc_GuildList.getChildByName<MovieClip>("mcQuestCheck"));
			this.mc_QuestCheck.addEventListener(GClass53.string_4, new EventDispatcher.EventCallback(this.method_14));
			this.mc_QuestCheck.bool_5 = true;
			this.mc_QuestCheck.String_1 = "quest";
			this.mc_QuestCheck.Boolean_3 = true;
			this.mc_PvECheck = new GClass40();
			this.mc_PvECheck.method_0(this.mc_GuildList.getChildByName<MovieClip>("mcPvECheck"));
			this.mc_PvECheck.addEventListener(GClass53.string_4, new EventDispatcher.EventCallback(this.method_14));
			this.mc_PvECheck.bool_5 = true;
			this.mc_PvECheck.String_1 = "pve";
			this.mc_PvECheck.Boolean_3 = true;
			this.mc_PvPCheck = new GClass40();
			this.mc_PvPCheck.method_0(this.mc_GuildList.getChildByName<MovieClip>("mcPvPCheck"));
			this.mc_PvPCheck.addEventListener(GClass53.string_4, new EventDispatcher.EventCallback(this.method_14));
			this.mc_PvPCheck.bool_5 = true;
			this.mc_PvPCheck.String_1 = "pvp";
			this.mc_PvPCheck.Boolean_3 = true;
			this.mc_SocialCheck = new GClass40();
			this.mc_SocialCheck.method_0(this.mc_GuildList.getChildByName<MovieClip>("mcSocialCheck"));
			this.mc_SocialCheck.addEventListener(GClass53.string_4, new EventDispatcher.EventCallback(this.method_14));
			this.mc_SocialCheck.bool_5 = true;
			this.mc_SocialCheck.String_1 = "social";
			this.mc_SocialCheck.Boolean_3 = true;
			this.mc_LeftButton = new GClass25();
			this.mc_LeftButton.method_0(this.mc_GuildList.getChildByName<MovieClip>("mc_Left"));
			this.mc_LeftButton.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_10));
			this.mc_RightButton = new GClass25();
			this.mc_RightButton.method_0(this.mc_GuildList.getChildByName<MovieClip>("mc_Right"));
			this.mc_RightButton.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_11));
			this.tf_GuildRemain = this.mc_GuildMessageList.getChildByName<TextField>("tf_guildRemain");
			this.tf_GuildRemain.text = string.Empty;
		}

		// Token: 0x0600374F RID: 14159 RVA: 0x000FDEFC File Offset: 0x000FC0FC
		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			if (movieClip.name.StartsWith(this.GUILD_SLOT_PREFIX_NAME))
			{
				int num = Convert.ToInt32(movieClip.name.Substring(this.GUILD_SLOT_PREFIX_NAME.Length, movieClip.name.Length - this.GUILD_SLOT_PREFIX_NAME.Length));
				if (num >= this._guildButtons.Length || num < 0)
				{
					DebugUtils.LogWarning(LogCategory.GUI, string.Concat(new object[]
					{
						"Guild itemSlot name wrong! Index:",
						num,
						" is bigger than sum: ",
						this._guildButtons.Length
					}));
					return true;
				}
				GClass32 gclass = new GClass32();
				gclass.method_0(movieClip);
				this._guildButtons[num] = gclass;
			}
			if (movieClip.name.StartsWith(this.GUILD_MSG_SLOT_PREFIX_NAME))
			{
				int num2 = Convert.ToInt32(movieClip.name.Substring(this.GUILD_MSG_SLOT_PREFIX_NAME.Length, movieClip.name.Length - this.GUILD_MSG_SLOT_PREFIX_NAME.Length));
				if (num2 >= this._guildMessageButtons.Length || num2 < 0)
				{
					DebugUtils.LogWarning(LogCategory.GUI, string.Concat(new object[]
					{
						"Guild message itemSlot name wrong! Index:",
						num2,
						" is bigger than sum: ",
						this._guildMessageButtons.Length
					}));
					return true;
				}
				GClass34 gclass2 = new GClass34();
				gclass2.method_0(movieClip);
				this._guildMessageButtons[num2] = gclass2;
			}
			return false;
		}

		// Token: 0x170002F3 RID: 755
		// (get) Token: 0x06003751 RID: 14161 RVA: 0x00024B6A File Offset: 0x00022D6A
		// (set) Token: 0x06003750 RID: 14160 RVA: 0x000FE06C File Offset: 0x000FC26C
		public virtual bool Boolean_0
		{
			get
			{
				return this.mc_root != null && this.mc_root.visible;
			}
			set
			{
				if (this.mc_root != null)
				{
					GuildManager.smethod_0().method_93();
					if (value)
					{
						this.m_Flag = 0;
						this.m_LastPreference = GuildPreference.All;
						this.mc_LeftButton.Boolean_6 = false;
						this.mc_RightButton.Boolean_6 = false;
						this.mc_QuestCheck.Boolean_3 = true;
						this.mc_PvECheck.Boolean_3 = true;
						this.mc_PvPCheck.Boolean_3 = true;
						this.mc_SocialCheck.Boolean_3 = true;
						this.mc_SearchButton.Boolean_6 = true;
						this.method_5();
						this.mc_SearchPanelButton.Boolean_3 = true;
						this.mc_GuildList.visible = true;
						this.mc_GuildMessageList.visible = false;
					}
					else
					{
						this.method_6();
					}
					this.method_18(GuildSearchView.GuildSearchPart.e_None);
				}
			}
		}

		// Token: 0x06003752 RID: 14162 RVA: 0x00024B81 File Offset: 0x00022D81
		protected void method_5()
		{
			this.mc_root.visible = true;
			this.mc_root.gotoAndPlay("DetailAppear");
		}

		// Token: 0x06003753 RID: 14163 RVA: 0x00024B9F File Offset: 0x00022D9F
		protected void method_6()
		{
			this.mc_root.gotoAndPlay("KeyFrame_2");
			this.mc_root.addFrameScript("KeyFrame_3", new EventDispatcher.EventCallback(this.method_7));
		}

		// Token: 0x06003754 RID: 14164 RVA: 0x00024BCE File Offset: 0x00022DCE
		protected void method_7(CEvent cevent_0)
		{
			this.mc_root.removeEventListener("KeyFrame_3", new EventDispatcher.EventCallback(this.method_7));
			this.mc_root.visible = false;
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this);
		}

		// Token: 0x06003755 RID: 14165 RVA: 0x00024C0E File Offset: 0x00022E0E
		private void method_8(CEvent cevent_0)
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<GuildSearchView>().vmethod_4();
		}

		// Token: 0x06003756 RID: 14166 RVA: 0x000FE130 File Offset: 0x000FC330
		private void method_9(CEvent cevent_0)
		{
			GuildPreference guildPreference = this.method_15();
			this.m_Flag = 0;
			this.mc_LeftButton.Boolean_6 = false;
			this.mc_RightButton.Boolean_6 = false;
			this.m_LastPreference = guildPreference;
			GuildManager.smethod_0().method_33(guildPreference, this.m_nOffset);
		}

		// Token: 0x06003757 RID: 14167 RVA: 0x000FE17C File Offset: 0x000FC37C
		private void method_10(CEvent cevent_0)
		{
			this.m_Flag = -1;
			this.mc_LeftButton.Boolean_6 = false;
			this.mc_RightButton.Boolean_6 = false;
			if (this.m_nSearchStep > 1)
			{
				GuildManager.smethod_0().method_33(this.m_LastPreference, (this.m_nSearchStep - 1) * this.m_nOffset);
			}
			else
			{
				GuildManager.smethod_0().method_33(this.m_LastPreference, this.m_nOffset);
			}
		}

		// Token: 0x06003758 RID: 14168 RVA: 0x00024C25 File Offset: 0x00022E25
		private void method_11(CEvent cevent_0)
		{
			this.m_Flag = 1;
			this.mc_LeftButton.Boolean_6 = false;
			this.mc_RightButton.Boolean_6 = false;
			GuildManager.smethod_0().method_33(this.m_LastPreference, (this.m_nSearchStep + 1) * this.m_nOffset);
		}

		// Token: 0x06003759 RID: 14169 RVA: 0x000FE1E8 File Offset: 0x000FC3E8
		private void method_12(CEvent cevent_0)
		{
			GClass25 gclass = cevent_0.target as GClass25;
			if (gclass == null)
			{
				return;
			}
			if (gclass.Boolean_3 && !this.mc_GuildList.visible)
			{
				this.mc_GuildList.visible = true;
				this.mc_GuildMessageList.visible = false;
				this.method_18(GuildSearchView.GuildSearchPart.e_None);
			}
		}

		// Token: 0x0600375A RID: 14170 RVA: 0x000FE23C File Offset: 0x000FC43C
		private void method_13(CEvent cevent_0)
		{
			GClass25 gclass = cevent_0.target as GClass25;
			if (gclass == null)
			{
				return;
			}
			if (gclass.Boolean_3 && !this.mc_GuildMessageList.visible)
			{
				this.mc_GuildList.visible = false;
				this.mc_GuildMessageList.visible = true;
				this.tf_GuildRemain.text = Utility.smethod_5(LocalizedString.smethod_0(new LocalizedString("GUILD_REMAINING")), Utility.smethod_8(GuildManager.smethod_0().method_65()));
				this.method_18(GuildSearchView.GuildSearchPart.e_None);
			}
		}

		// Token: 0x0600375B RID: 14171 RVA: 0x000FE2BC File Offset: 0x000FC4BC
		private void method_14(CEvent cevent_0)
		{
			if (!(cevent_0.target is GClass25))
			{
				return;
			}
			if (this.method_15() == GuildPreference.None)
			{
				this.mc_SearchButton.Boolean_6 = false;
			}
			else
			{
				this.mc_SearchButton.Boolean_6 = true;
			}
		}

		// Token: 0x0600375C RID: 14172 RVA: 0x000FE2FC File Offset: 0x000FC4FC
		private GuildPreference method_15()
		{
			GuildPreference guildPreference = GuildPreference.None;
			if (this.mc_QuestCheck != null && this.mc_PvECheck != null && this.mc_PvPCheck != null && this.mc_SocialCheck != null)
			{
				if (this.mc_QuestCheck.Boolean_3)
				{
					guildPreference |= GuildPreference.Quest;
				}
				if (this.mc_PvECheck.Boolean_3)
				{
					guildPreference |= GuildPreference.PvE;
				}
				if (this.mc_PvPCheck.Boolean_3)
				{
					guildPreference |= GuildPreference.PvP;
				}
				if (this.mc_SocialCheck.Boolean_3)
				{
					guildPreference |= GuildPreference.Social;
				}
				return guildPreference;
			}
			return GuildPreference.All;
		}

		// Token: 0x0600375D RID: 14173 RVA: 0x000FE374 File Offset: 0x000FC574
		public void method_16(int int_0)
		{
			if (this.m_Flag == 0)
			{
				if (int_0 == this.m_nOffset)
				{
					this.mc_RightButton.Boolean_6 = true;
				}
				this.m_nSearchStep = 1;
			}
			if (this.m_Flag == -1)
			{
				if (int_0 >= this.m_nOffset)
				{
					this.mc_RightButton.Boolean_6 = true;
					this.m_nSearchStep--;
					if (this.m_nSearchStep <= 1)
					{
						this.m_nSearchStep = 1;
					}
					else
					{
						this.mc_LeftButton.Boolean_6 = true;
					}
				}
				else if (int_0 != 0)
				{
					this.m_nSearchStep--;
					if (this.m_nSearchStep <= 1)
					{
						this.m_nSearchStep = 1;
					}
					else
					{
						this.mc_LeftButton.Boolean_6 = true;
					}
				}
				else
				{
					this.m_nSearchStep = 1;
				}
			}
			if (this.m_Flag == 1)
			{
				if (int_0 >= this.m_nOffset)
				{
					this.m_nSearchStep++;
					this.mc_LeftButton.Boolean_6 = true;
					this.mc_RightButton.Boolean_6 = true;
				}
				else
				{
					if (int_0 != 0)
					{
						this.m_nSearchStep++;
					}
					else if (this.m_nSearchStep == 1)
					{
						return;
					}
					this.mc_LeftButton.Boolean_6 = true;
					this.mc_RightButton.Boolean_6 = false;
				}
			}
		}

		// Token: 0x0600375E RID: 14174 RVA: 0x00024C65 File Offset: 0x00022E65
		public int method_17()
		{
			return this.m_Flag;
		}

		// Token: 0x0600375F RID: 14175 RVA: 0x000FE498 File Offset: 0x000FC698
		public void method_18(GuildSearchView.GuildSearchPart guildSearchPart_0 = GuildSearchView.GuildSearchPart.e_None)
		{
			if (this.mc_GuildList != null && this.mc_GuildMessageList != null)
			{
				this.tf_GuildRemain.text = Utility.smethod_5(LocalizedString.smethod_0(new LocalizedString("GUILD_REMAINING")), Utility.smethod_8(GuildManager.smethod_0().method_65()));
				if (this.mc_GuildList.visible)
				{
					int num = GuildManager.smethod_0().method_25();
					if (num > this.GUILD_TOTAL)
					{
						num = this.GUILD_TOTAL;
						DebugUtils.LogWarning(LogCategory.Network, "Guild search result is " + GuildManager.smethod_0().method_25().ToString() + " more than " + this.GUILD_TOTAL.ToString());
					}
					for (int i = 0; i < num; i++)
					{
						this._guildButtons[i].vmethod_14(i);
						this._guildButtons[i].Boolean_1 = true;
					}
					for (int j = num; j < this.GUILD_TOTAL; j++)
					{
						this._guildButtons[j].Boolean_1 = false;
					}
				}
				if (this.mc_GuildMessageList.visible)
				{
					int num2 = GuildManager.smethod_0().method_26();
					for (int k = 0; k < num2; k++)
					{
						this._guildMessageButtons[k].vmethod_14(k);
						this._guildMessageButtons[k].Boolean_1 = true;
					}
					for (int l = num2; l < this.GUILD_MESSAGE_TOTAL; l++)
					{
						this._guildMessageButtons[l].Boolean_1 = false;
					}
				}
				return;
			}
		}

		// Token: 0x0400264F RID: 9807
		public MovieClip mc_root;

		// Token: 0x04002650 RID: 9808
		private MovieClip mc_Total;

		// Token: 0x04002651 RID: 9809
		private GClass40 mc_SearchPanelButton;

		// Token: 0x04002652 RID: 9810
		private GClass40 mc_MessagePanelButton;

		// Token: 0x04002653 RID: 9811
		private GClass25 mc_CloseButton;

		// Token: 0x04002654 RID: 9812
		private GClass25 mc_SearchButton;

		// Token: 0x04002655 RID: 9813
		private MovieClip mc_GuildList;

		// Token: 0x04002656 RID: 9814
		private MovieClip mc_GuildMessageList;

		// Token: 0x04002657 RID: 9815
		private string GUILD_SLOT_PREFIX_NAME = "itemguild";

		// Token: 0x04002658 RID: 9816
		private string GUILD_MSG_SLOT_PREFIX_NAME = "itemMessage";

		// Token: 0x04002659 RID: 9817
		private int GUILD_TOTAL = 14;

		// Token: 0x0400265A RID: 9818
		private int GUILD_MESSAGE_TOTAL = 16;

		// Token: 0x0400265B RID: 9819
		protected GClass32[] _guildButtons;

		// Token: 0x0400265C RID: 9820
		protected GClass34[] _guildMessageButtons;

		// Token: 0x0400265D RID: 9821
		private GClass40 mc_QuestCheck;

		// Token: 0x0400265E RID: 9822
		private GClass40 mc_PvECheck;

		// Token: 0x0400265F RID: 9823
		private GClass40 mc_PvPCheck;

		// Token: 0x04002660 RID: 9824
		private GClass40 mc_SocialCheck;

		// Token: 0x04002661 RID: 9825
		private GClass25 mc_LeftButton;

		// Token: 0x04002662 RID: 9826
		private GClass25 mc_RightButton;

		// Token: 0x04002663 RID: 9827
		private TextField tf_GuildRemain;

		// Token: 0x04002664 RID: 9828
		private int m_Flag;

		// Token: 0x04002665 RID: 9829
		private int m_nOffset = 14;

		// Token: 0x04002666 RID: 9830
		private int m_nSearchStep = 1;

		// Token: 0x04002667 RID: 9831
		private GuildPreference m_LastPreference = GuildPreference.All;
	}

	// Token: 0x02000802 RID: 2050
	public class GuildTips : GClass62
	{
		// Token: 0x06003760 RID: 14176 RVA: 0x00024C6D File Offset: 0x00022E6D
		public GuildTips(GuildSkillData guildSkillData_0)
		{
			this._skill = guildSkillData_0;
		}

		// Token: 0x06003761 RID: 14177 RVA: 0x00024C7C File Offset: 0x00022E7C
		public override DisplayObject vmethod_0()
		{
			if (this._skill == null)
			{
				return null;
			}
			this.method_0();
			return uniGuildSearchView.GuildTips._itemPanel.DisplayObjectContainer_0;
		}

		// Token: 0x06003762 RID: 14178 RVA: 0x000FE5FC File Offset: 0x000FC7FC
		protected void method_0()
		{
			if (this._skill == null)
			{
				return;
			}
			string text = LocalizedString.smethod_0(new LocalizedString(Utility.smethod_5("GUILD_SKILLID_", Utility.smethod_8(this._skill.m_id))));
			if (this._skill.m_type == "scale")
			{
				float value = this._skill.m_value;
				int num = (int)((value - 1f) * 100f);
				text = Utility.smethod_6(Utility.smethod_5(text, "+"), Utility.smethod_8(num), "%");
			}
			if (this._skill.m_type == "postAdd")
			{
				int num2 = (int)this._skill.m_value;
				text = Utility.smethod_6(text, "+", Utility.smethod_8(num2));
			}
			ItemTipsData itemTipsData = new ItemTipsData();
			itemTipsData.level = this._skill.m_unlockLevel;
			if (this._skill.m_unlockLevel > GuildManager.smethod_0().method_100())
			{
				itemTipsData.levelColor = Color.red;
			}
			else
			{
				itemTipsData.levelColor = Color.white;
			}
			ItemElement itemElement = new ItemElement();
			itemElement.eType = ETipsItemType.TEXT;
			itemElement.value = text;
			itemTipsData.attributeList.Add(itemElement);
			uniGuildSearchView.GuildTips._itemPanel.method_5(itemTipsData);
		}

		// Token: 0x04002668 RID: 9832
		protected GuildSkillData _skill;

		// Token: 0x04002669 RID: 9833
		public static ItemTipsPanel _itemPanel;
	}

	// Token: 0x02000803 RID: 2051
	public class GuildSkillIconSlot : GClass24
	{
		// Token: 0x06003764 RID: 14180 RVA: 0x000FE738 File Offset: 0x000FC938
		public void method_10(GuildSkillData guildSkillData_0)
		{
			this._skill = guildSkillData_0;
			this._rootMC.visible = true;
			MovieClip childByName = this._rootMC.getChildByName<MovieClip>("mcSkillTreeIcon");
			uniGuildSearchView uniGuildSearchView = (uniGuildSearchView)MonoSingleton<AppManager>.Instance.method_0().vmethod_5<GuildSearchView>();
			if (childByName != null && uniGuildSearchView != null && this._skill != null)
			{
				uniGuildSearchView.method_7(childByName, "Movie_Skill" + this._rootMC.name.Substring(this._rootMC.name.Length - 1, 1));
			}
			this.method_12();
		}

		// Token: 0x06003765 RID: 14181 RVA: 0x000FE7C8 File Offset: 0x000FC9C8
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this._rootMC = base.DisplayObjectContainer_0 as MovieClip;
			this._rootMC.removeAllEventListeners(MouseEvent.CLICK);
			this._rootMC.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_11));
			if (this._btnMouseCover == null)
			{
				this._btnMouseCover = new GClass25();
			}
			MovieClip childByName = this._rootMC.getChildByName<MovieClip>("mcMouseCover");
			if (childByName != null)
			{
				this._btnMouseCover.method_0(childByName);
			}
		}

		// Token: 0x06003766 RID: 14182 RVA: 0x000FE850 File Offset: 0x000FCA50
		protected void method_11(CEvent cevent_0)
		{
			MouseEvent mouseEvent = (MouseEvent)cevent_0;
			if (mouseEvent != null && mouseEvent.buttonId == 1)
			{
				return;
			}
			if (this._slotStatus == uniGuildSearchView.GuildSkillIconSlot.GuildSkillSlotStatus.eUnlock)
			{
				GuildManager.smethod_0().method_54(this._skill.m_id);
			}
		}

		// Token: 0x06003767 RID: 14183 RVA: 0x000FE890 File Offset: 0x000FCA90
		public void method_12()
		{
			if (this._skill == null)
			{
				return;
			}
			if (!GuildManager.smethod_0().method_56(this._skill.m_id))
			{
				if (GuildManager.smethod_0().method_57(this._skill.m_id))
				{
					this._rootMC.gotoAndStop("complete");
					this._slotStatus = uniGuildSearchView.GuildSkillIconSlot.GuildSkillSlotStatus.eComplete;
				}
				else
				{
					this._rootMC.gotoAndStop("unlock");
					this._slotStatus = uniGuildSearchView.GuildSkillIconSlot.GuildSkillSlotStatus.eUnlock;
				}
			}
			else
			{
				this._rootMC.gotoAndStop("lock");
				this._slotStatus = uniGuildSearchView.GuildSkillIconSlot.GuildSkillSlotStatus.eLock;
			}
			this._btnMouseCover.Boolean_6 = this._slotStatus != uniGuildSearchView.GuildSkillIconSlot.GuildSkillSlotStatus.eLock;
		}

		// Token: 0x0400266A RID: 9834
		protected MovieClip _rootMC;

		// Token: 0x0400266B RID: 9835
		protected uniGuildSearchView.GuildSkillIconSlot.GuildSkillSlotStatus _slotStatus;

		// Token: 0x0400266C RID: 9836
		protected GuildSkillData _skill;

		// Token: 0x0400266D RID: 9837
		protected GClass25 _btnMouseCover;

		// Token: 0x0400266E RID: 9838
		protected ItemTipsPanel m_Tips;

		// Token: 0x02000804 RID: 2052
		public enum GuildSkillSlotStatus
		{
			// Token: 0x04002670 RID: 9840
			eNone,
			// Token: 0x04002671 RID: 9841
			eLock,
			// Token: 0x04002672 RID: 9842
			eUnlock,
			// Token: 0x04002673 RID: 9843
			eUpgrade,
			// Token: 0x04002674 RID: 9844
			eComplete
		}
	}

	// Token: 0x02000805 RID: 2053
	private class GuildManagePanel : GClass51
	{
		// Token: 0x06003768 RID: 14184 RVA: 0x000FE934 File Offset: 0x000FCB34
		public GuildManagePanel()
		{
			this._guildMemberButtons = new GClass33[this.GUILD_MEMBER_TOTAL];
			this._guildApplicationButtons = new GClass31[this.GUILD_APPLICATION_TOTAL];
			this._guildNewsButtons = new GClass35[this.GUILD_NEWS_TOTAL];
			this.m_GuildSkillIconList = new List<uniGuildSearchView.GuildSkillIconSlot>();
			this.m_GuildSkillIconList.Clear();
		}

		// Token: 0x06003769 RID: 14185 RVA: 0x000FE9D4 File Offset: 0x000FCBD4
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.mc_root = this.displayObjectContainer_0 as MovieClip;
			if (this.mc_root == null)
			{
				DebugUtils.LogWarning(LogCategory.GUI, "UIWarning: GuildSearchPanel onInit() 'mc_root' is null! GuildManagePanel won't work!!!");
				return;
			}
			this.mc_root.visible = false;
			this.mc_Total = this.mc_root.getChildByName<MovieClip>("mc_total");
			this.mc_ExpBar = this.mc_Total.getChildByName<MovieClip>("mc_GuildLevel").getChildByName<BadAssMovieClip>("mc_bar");
			this.m_fExpWidth = this.mc_ExpBar.width;
			this.tf_GuildName = this.mc_Total.getChildByName<TextField>("mcGuildName");
			this.tf_GuildLevel = this.mc_Total.getChildByName<MovieClip>("mc_GuildLevel").getChildByName<TextField>("tf_level");
			this.tf_GuildExp = this.mc_Total.getChildByName<MovieClip>("mc_GuildLevel").getChildByName<TextField>("tf_Exp");
			this.tf_GuildDeca = new GClass50();
			this.tf_GuildDeca.method_0(this.mc_Total.getChildByName<MovieClip>("TitleName").getChildByName<MovieClip>("mcsloganInput"));
			this.tf_GuildDeca.Boolean_6 = false;
			this.tf_GuildDeca.Int32_0 = 15;
			this.mc_GuildMemberList = this.mc_Total.getChildByName<MovieClip>("mc_MemberList");
			this.mc_GuildNewsList = this.mc_Total.getChildByName<MovieClip>("mc_NewsList");
			this.mc_GuildApplicationList = this.mc_Total.getChildByName<MovieClip>("mc_ApplicationList");
			this.mc_GuildSkillList = this.mc_Total.getChildByName<MovieClip>("mc_SkillList");
			this.tf_OnlineNum = this.mc_GuildMemberList.getChildByName<TextField>("tf_OnlineMember");
			this.tf_TotalNum = this.mc_GuildMemberList.getChildByName<TextField>("tf_AllMember");
			this.mc_MemberPanelButton = new GClass40();
			this.mc_MemberPanelButton.method_0(this.mc_Total.getChildByName<MovieClip>("mc_member"));
			this.mc_MemberPanelButton.addEventListener(GClass53.string_4, new EventDispatcher.EventCallback(this.method_7));
			this.mc_MemberPanelButton.String_1 = "GuildManagePanel";
			this.mc_MemberPanelButton.bool_5 = false;
			this.mc_NewsPanelButton = new GClass40();
			this.mc_NewsPanelButton.method_0(this.mc_Total.getChildByName<MovieClip>("mc_news"));
			this.mc_NewsPanelButton.addEventListener(GClass53.string_4, new EventDispatcher.EventCallback(this.method_10));
			this.mc_NewsPanelButton.String_1 = "GuildManagePanel";
			this.mc_NewsPanelButton.bool_5 = false;
			this.mc_ApplicationPanelButton = new GClass40();
			this.mc_ApplicationPanelButton.method_0(this.mc_Total.getChildByName<MovieClip>("mc_application"));
			this.mc_ApplicationPanelButton.addEventListener(GClass53.string_4, new EventDispatcher.EventCallback(this.method_11));
			this.mc_ApplicationPanelButton.String_1 = "GuildManagePanel";
			this.mc_ApplicationPanelButton.bool_5 = false;
			this.mc_ActivityButton = new GClass40();
			this.mc_ActivityButton.method_0(this.mc_Total.getChildByName<MovieClip>("mc_activity"));
			this.mc_ActivityButton.Boolean_6 = false;
			this.mc_SkillButton = new GClass40();
			this.mc_SkillButton.method_0(this.mc_Total.getChildByName<MovieClip>("mc_skill"));
			this.mc_SkillButton.addEventListener(GClass53.string_4, new EventDispatcher.EventCallback(this.method_12));
			this.mc_SkillButton.String_1 = "GuildManagePanel";
			this.mc_SkillButton.bool_5 = false;
			this.mc_CloseButton = new GClass25();
			this.mc_CloseButton.method_0(this.mc_Total.getChildByName<MovieClip>("mcBtnClose"));
			this.mc_CloseButton.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_5));
			this.mc_ModifyButton = new GClass25();
			this.mc_ModifyButton.method_0(this.mc_Total.getChildByName<MovieClip>("mc_Modify"));
			this.mc_ModifyButton.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_6));
			this.mc_ModifyButton.Boolean_6 = false;
			this.mc_ResetButton = new GClass25();
			this.mc_ResetButton.method_0(this.mc_GuildSkillList.getChildByName<MovieClip>("mc_reset"));
			this.mc_ResetButton.Boolean_6 = false;
			this.mc_ResetButton.Boolean_1 = false;
			this.tf_SkillTips = this.mc_GuildSkillList.getChildByName<TextField>("tf_Tips");
			this.tf_SkillTips.text = string.Empty;
			this.mc_GuildNewsList.visible = false;
			this.mc_GuildMemberList.visible = false;
			this.mc_GuildApplicationList.visible = false;
			this.mc_GuildSkillList.visible = false;
			this.mc_OnlineBox = new GClass40();
			this.mc_OnlineBox.method_0(this.mc_GuildMemberList.getChildByName<MovieClip>("mc_onlinecheck"));
			this.mc_OnlineBox.bool_5 = true;
			this.mc_OnlineBox.String_1 = "online";
			this.mc_OnlineBox.addEventListener(GClass53.string_4, new EventDispatcher.EventCallback(this.method_13));
			this.mc_ScrollBar = new GClass46();
			this.mc_ScrollBar.method_0(this.mc_Total.getChildByName<MovieClip>("mcScrollingBar"));
			this.mc_ScrollBar.addEventListener("Scrolling", new EventDispatcher.EventCallback(this.method_8));
			GClass45 gclass = this.mc_ScrollBar;
			this.mc_ScrollBar.int_1 = 0;
			gclass.int_0 = 0;
			this.mc_ScrollBar.method_10(this.GUILD_MEMBER_TOTAL, 0, GuildManager.smethod_0().method_72() - this.GUILD_MEMBER_TOTAL, 1);
			this.mc_ScrollBar.Int32_1 = 0;
		}

		// Token: 0x0600376A RID: 14186 RVA: 0x000FEF4C File Offset: 0x000FD14C
		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			if (movieClip.name.StartsWith(this.GUILD_MEMBER_PREFIX_NAME))
			{
				int num = Convert.ToInt32(movieClip.name.Substring(this.GUILD_MEMBER_PREFIX_NAME.Length, movieClip.name.Length - this.GUILD_MEMBER_PREFIX_NAME.Length));
				if (num >= this._guildMemberButtons.Length || num < 0)
				{
					DebugUtils.LogWarning(LogCategory.GUI, string.Concat(new object[]
					{
						"Guild Member itemSlot name wrong! Index:",
						num,
						" is bigger than sum: ",
						this._guildMemberButtons.Length
					}));
					return true;
				}
				GClass33 gclass = new GClass33();
				gclass.method_0(movieClip);
				this._guildMemberButtons[num] = gclass;
			}
			if (movieClip.name.StartsWith(this.GUILD_APPLICATION_PREFIX_NAME))
			{
				int num2 = Convert.ToInt32(movieClip.name.Substring(this.GUILD_APPLICATION_PREFIX_NAME.Length, movieClip.name.Length - this.GUILD_APPLICATION_PREFIX_NAME.Length));
				if (num2 >= this._guildApplicationButtons.Length || num2 < 0)
				{
					DebugUtils.LogWarning(LogCategory.GUI, string.Concat(new object[]
					{
						"Guild application itemSlot name wrong! Index:",
						num2,
						" is bigger than sum: ",
						this._guildApplicationButtons.Length
					}));
					return true;
				}
				GClass31 gclass2 = new GClass31();
				gclass2.method_0(movieClip);
				this._guildApplicationButtons[num2] = gclass2;
			}
			if (movieClip.name.StartsWith(this.GUILD_NEWS_PREFIX_NAME))
			{
				int num3 = Convert.ToInt32(movieClip.name.Substring(this.GUILD_NEWS_PREFIX_NAME.Length, movieClip.name.Length - this.GUILD_NEWS_PREFIX_NAME.Length));
				if (num3 >= this._guildNewsButtons.Length || num3 < 0)
				{
					DebugUtils.LogWarning(LogCategory.GUI, string.Concat(new object[]
					{
						"Guild news itemSlot name wrong! Index:",
						num3,
						" is bigger than sum: ",
						this._guildNewsButtons.Length
					}));
					return true;
				}
				GClass35 gclass3 = new GClass35();
				gclass3.method_0(movieClip);
				this._guildNewsButtons[num3] = gclass3;
			}
			if (movieClip.name.StartsWith(this.GUILD_SKILL_PREFIX_NAME))
			{
				int num4 = Convert.ToInt32(movieClip.name.Substring(this.GUILD_SKILL_PREFIX_NAME.Length, movieClip.name.Length - this.GUILD_SKILL_PREFIX_NAME.Length));
				uniGuildSearchView.GuildSkillIconSlot guildSkillIconSlot = new uniGuildSearchView.GuildSkillIconSlot();
				guildSkillIconSlot.method_0(movieClip);
				guildSkillIconSlot.GInterface1_0 = new uniGuildSearchView.GuildTips(MonoSingleton<GuildProgressionSetting>.Instance.method_0(num4));
				this.m_GuildSkillIconList.Add(guildSkillIconSlot);
				guildSkillIconSlot.method_10(MonoSingleton<GuildProgressionSetting>.Instance.method_0(num4));
			}
			return false;
		}

		// Token: 0x170002F4 RID: 756
		// (get) Token: 0x0600376C RID: 14188 RVA: 0x00024CA0 File Offset: 0x00022EA0
		// (set) Token: 0x0600376B RID: 14187 RVA: 0x000FF208 File Offset: 0x000FD408
		public virtual bool Boolean_0
		{
			get
			{
				return this.mc_root != null && this.mc_root.visible;
			}
			set
			{
				if (this.mc_root != null)
				{
					if (value)
					{
						this.method_9();
						this.method_14();
						this.mc_root.visible = true;
						this.mc_MemberPanelButton.Boolean_3 = true;
						this.mc_GuildMemberList.visible = true;
						this.mc_GuildNewsList.visible = false;
						this.mc_GuildApplicationList.visible = false;
						this.mc_GuildSkillList.visible = false;
					}
					else
					{
						this.tf_GuildDeca.Boolean_2 = false;
						this.mc_root.visible = false;
						this.mc_OnlineBox.Boolean_3 = false;
						if (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InstanceSelectView>().Boolean_0)
						{
							MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InstanceSelectView>().vmethod_20();
						}
					}
				}
			}
		}

		// Token: 0x0600376D RID: 14189 RVA: 0x00024C0E File Offset: 0x00022E0E
		private void method_5(CEvent cevent_0)
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<GuildSearchView>().vmethod_4();
		}

		// Token: 0x0600376E RID: 14190 RVA: 0x00024CB7 File Offset: 0x00022EB7
		private void method_6(CEvent cevent_0)
		{
			GuildManager.smethod_0().method_20(this.tf_GuildDeca.String_0);
			this.tf_GuildDeca.Boolean_2 = false;
		}

		// Token: 0x0600376F RID: 14191 RVA: 0x000FF2C8 File Offset: 0x000FD4C8
		protected void method_7(CEvent cevent_0)
		{
			GClass25 gclass = cevent_0.target as GClass25;
			if (gclass == null)
			{
				return;
			}
			if (gclass.Boolean_3 && !this.mc_GuildMemberList.visible)
			{
				this.mc_ScrollBar.Int32_1 = 0;
				this.mc_GuildMemberList.visible = true;
				this.mc_GuildApplicationList.visible = false;
				this.mc_GuildNewsList.visible = false;
				this.mc_GuildSkillList.visible = false;
				this.method_9();
				this.method_15(GuildSearchView.GuildSearchPart.e_None);
			}
		}

		// Token: 0x06003770 RID: 14192 RVA: 0x00024CDA File Offset: 0x00022EDA
		protected void method_8(CEvent cevent_0)
		{
			if (this.mc_root.visible)
			{
				this.method_15(GuildSearchView.GuildSearchPart.e_None);
			}
		}

		// Token: 0x06003771 RID: 14193 RVA: 0x000FF344 File Offset: 0x000FD544
		private void method_9()
		{
			this.tf_GuildName.text = GuildManager.smethod_0().method_90();
			this.tf_GuildLevel.text = Utility.smethod_5("LV.", Utility.smethod_8(GuildManager.smethod_0().method_91()));
			this.tf_GuildDeca.String_0 = GuildManager.smethod_0().method_92();
			int num = GuildManager.smethod_0().method_3();
			int num2 = GuildManager.smethod_0().method_4();
			int num3 = GuildManager.smethod_0().method_2();
			this.tf_GuildExp.text = string.Empty;
			if (GuildManager.smethod_0().method_99() != 0)
			{
				this.tf_SkillTips.text = LocalizedString.smethod_0(new LocalizedString("GUILD_Skill_Active"));
			}
			else
			{
				this.tf_SkillTips.text = string.Empty;
			}
			if (num2 != 0)
			{
				float num4 = (float)Math.Abs(num3 - num) / (float)(num2 - num) * this.m_fExpWidth;
				if (num4 > this.m_fExpWidth)
				{
					this.mc_ExpBar.Single_0 = this.m_fExpWidth;
				}
				else
				{
					this.mc_ExpBar.Single_0 = num4;
				}
			}
			else
			{
				this.mc_ExpBar.Single_0 = this.m_fExpWidth;
			}
			if (GuildManager.smethod_0().method_8())
			{
				this.tf_GuildDeca.Boolean_2 = false;
				this.tf_GuildDeca.Boolean_6 = true;
				this.mc_ModifyButton.Boolean_6 = true;
			}
			else
			{
				this.tf_GuildDeca.Boolean_2 = false;
				this.tf_GuildDeca.Boolean_6 = false;
				this.mc_ModifyButton.Boolean_6 = false;
			}
			this.tf_OnlineNum.textFormat.color = Color.yellow;
			if (this.m_bOnlineChecked)
			{
				this.tf_OnlineNum.text = Utility.smethod_8(GuildManager.smethod_0().method_73());
			}
			else
			{
				this.tf_OnlineNum.text = Utility.smethod_8(GuildManager.smethod_0().method_72());
			}
			this.tf_TotalNum.text = Utility.smethod_5("/", Utility.smethod_8(GuildManager.smethod_0().method_16()));
		}

		// Token: 0x06003772 RID: 14194 RVA: 0x000FF52C File Offset: 0x000FD72C
		protected void method_10(CEvent cevent_0)
		{
			GClass25 gclass = cevent_0.target as GClass25;
			if (gclass == null)
			{
				return;
			}
			if (gclass.Boolean_3 && !this.mc_GuildNewsList.visible)
			{
				this.mc_ScrollBar.method_10(this.GUILD_NEWS_TOTAL, 0, GuildManager.smethod_0().method_96() - this.GUILD_NEWS_TOTAL, 1);
				this.mc_ScrollBar.Int32_1 = 0;
				this.mc_GuildNewsList.visible = true;
				this.mc_GuildApplicationList.visible = false;
				this.mc_GuildMemberList.visible = false;
				this.mc_GuildSkillList.visible = false;
				this.method_15(GuildSearchView.GuildSearchPart.e_None);
			}
		}

		// Token: 0x06003773 RID: 14195 RVA: 0x000FF5C8 File Offset: 0x000FD7C8
		protected void method_11(CEvent cevent_0)
		{
			GClass25 gclass = cevent_0.target as GClass25;
			if (gclass == null)
			{
				return;
			}
			if (gclass.Boolean_3 && !this.mc_GuildApplicationList.visible)
			{
				this.mc_ScrollBar.method_10(this.GUILD_APPLICATION_TOTAL, 0, GuildManager.smethod_0().method_76() - this.GUILD_APPLICATION_TOTAL, 1);
				this.mc_ScrollBar.Int32_1 = 0;
				this.mc_GuildApplicationList.visible = true;
				this.mc_GuildMemberList.visible = false;
				this.mc_GuildNewsList.visible = false;
				this.mc_GuildSkillList.visible = false;
				this.method_15(GuildSearchView.GuildSearchPart.e_None);
			}
		}

		// Token: 0x06003774 RID: 14196 RVA: 0x000FF664 File Offset: 0x000FD864
		protected void method_12(CEvent cevent_0)
		{
			GClass25 gclass = cevent_0.target as GClass25;
			if (gclass == null)
			{
				return;
			}
			if (gclass.Boolean_3 && !this.mc_GuildSkillList.visible)
			{
				this.mc_GuildSkillList.visible = true;
				this.mc_GuildMemberList.visible = false;
				this.mc_GuildNewsList.visible = false;
				this.mc_GuildApplicationList.visible = false;
				this.method_15(GuildSearchView.GuildSearchPart.e_None);
			}
		}

		// Token: 0x06003775 RID: 14197 RVA: 0x000FF6D0 File Offset: 0x000FD8D0
		protected void method_13(CEvent cevent_0)
		{
			GClass25 gclass = cevent_0.target as GClass25;
			if (gclass == null)
			{
				return;
			}
			if (gclass.Boolean_3)
			{
				this.m_bOnlineChecked = true;
				GuildManager.smethod_0().method_10();
			}
			else
			{
				this.m_bOnlineChecked = false;
				GuildManager.smethod_0().method_11();
			}
		}

		// Token: 0x06003776 RID: 14198 RVA: 0x000FF71C File Offset: 0x000FD91C
		protected void method_14()
		{
			for (int i = 0; i < this._guildMemberButtons.Length; i++)
			{
				this._guildMemberButtons[i].Boolean_1 = false;
			}
			for (int j = 0; j < this._guildApplicationButtons.Length; j++)
			{
				this._guildApplicationButtons[j].Boolean_1 = false;
			}
			for (int k = 0; k < this._guildNewsButtons.Length; k++)
			{
				this._guildNewsButtons[k].Boolean_1 = false;
			}
		}

		// Token: 0x06003777 RID: 14199 RVA: 0x000FF78C File Offset: 0x000FD98C
		public void method_15(GuildSearchView.GuildSearchPart guildSearchPart_0 = GuildSearchView.GuildSearchPart.e_None)
		{
			this.method_9();
			if (this.mc_GuildApplicationList != null && this.mc_GuildMemberList != null && this.mc_GuildNewsList != null && this.mc_GuildSkillList != null)
			{
				if (this.mc_GuildMemberList.visible)
				{
					if (guildSearchPart_0 != GuildSearchView.GuildSearchPart.e_None && guildSearchPart_0 != GuildSearchView.GuildSearchPart.e_GuildMember)
					{
						return;
					}
					int num = ((GuildManager.smethod_0().method_72() <= this.GUILD_MEMBER_TOTAL) ? GuildManager.smethod_0().method_72() : this.GUILD_MEMBER_TOTAL);
					if (this.m_bOnlineChecked)
					{
						num = ((GuildManager.smethod_0().method_73() <= this.GUILD_MEMBER_TOTAL) ? GuildManager.smethod_0().method_73() : this.GUILD_MEMBER_TOTAL);
						this.mc_ScrollBar.method_10(this.GUILD_MEMBER_TOTAL, 0, GuildManager.smethod_0().method_73() - this.GUILD_MEMBER_TOTAL, 1);
					}
					else
					{
						this.mc_ScrollBar.method_10(this.GUILD_MEMBER_TOTAL, 0, GuildManager.smethod_0().method_72() - this.GUILD_MEMBER_TOTAL, 1);
					}
					for (int i = 0; i < num; i++)
					{
						this._guildMemberButtons[i].vmethod_14(this.mc_ScrollBar.Int32_1 + i);
						this._guildMemberButtons[i].Boolean_1 = true;
					}
					for (int j = num; j < this.GUILD_MEMBER_TOTAL; j++)
					{
						this._guildMemberButtons[j].Boolean_1 = false;
					}
				}
				if (this.mc_GuildApplicationList.visible)
				{
					if (guildSearchPart_0 != GuildSearchView.GuildSearchPart.e_None && guildSearchPart_0 != GuildSearchView.GuildSearchPart.e_GuildApplication)
					{
						return;
					}
					int num2 = ((GuildManager.smethod_0().method_76() <= this.GUILD_APPLICATION_TOTAL) ? GuildManager.smethod_0().method_76() : this.GUILD_APPLICATION_TOTAL);
					for (int k = 0; k < num2; k++)
					{
						this._guildApplicationButtons[k].vmethod_14(this.mc_ScrollBar.Int32_1 + k);
						this._guildApplicationButtons[k].Boolean_1 = true;
					}
					for (int l = num2; l < this.GUILD_APPLICATION_TOTAL; l++)
					{
						this._guildApplicationButtons[l].Boolean_1 = false;
					}
				}
				if (this.mc_GuildNewsList.visible)
				{
					if (guildSearchPart_0 != GuildSearchView.GuildSearchPart.e_None && guildSearchPart_0 != GuildSearchView.GuildSearchPart.e_GuildNews)
					{
						return;
					}
					int num3 = ((GuildManager.smethod_0().method_96() <= this.GUILD_NEWS_TOTAL) ? GuildManager.smethod_0().method_96() : this.GUILD_NEWS_TOTAL);
					for (int m = 0; m < num3; m++)
					{
						this._guildNewsButtons[m].vmethod_14(this.mc_ScrollBar.Int32_1 + m);
						this._guildNewsButtons[m].Boolean_1 = true;
					}
					for (int n = num3; n < this.GUILD_NEWS_TOTAL; n++)
					{
						this._guildNewsButtons[n].Boolean_1 = false;
					}
				}
				if (this.mc_GuildSkillList.visible)
				{
					if (guildSearchPart_0 != GuildSearchView.GuildSearchPart.e_None && guildSearchPart_0 != GuildSearchView.GuildSearchPart.e_GuildSkill)
					{
						return;
					}
					for (int num4 = 0; num4 < this.m_GuildSkillIconList.Count; num4++)
					{
						this.m_GuildSkillIconList[num4].method_12();
					}
				}
				return;
			}
		}

		// Token: 0x04002675 RID: 9845
		public MovieClip mc_root;

		// Token: 0x04002676 RID: 9846
		private MovieClip mc_Total;

		// Token: 0x04002677 RID: 9847
		private GClass40 mc_MemberPanelButton;

		// Token: 0x04002678 RID: 9848
		private GClass40 mc_NewsPanelButton;

		// Token: 0x04002679 RID: 9849
		private GClass40 mc_ApplicationPanelButton;

		// Token: 0x0400267A RID: 9850
		private GClass40 mc_ActivityButton;

		// Token: 0x0400267B RID: 9851
		private GClass40 mc_SkillButton;

		// Token: 0x0400267C RID: 9852
		private GClass40 mc_OnlineBox;

		// Token: 0x0400267D RID: 9853
		private GClass25 mc_CloseButton;

		// Token: 0x0400267E RID: 9854
		private GClass25 mc_ModifyButton;

		// Token: 0x0400267F RID: 9855
		private GClass25 mc_ResetButton;

		// Token: 0x04002680 RID: 9856
		private MovieClip mc_GuildMemberList;

		// Token: 0x04002681 RID: 9857
		private MovieClip mc_GuildNewsList;

		// Token: 0x04002682 RID: 9858
		private MovieClip mc_GuildApplicationList;

		// Token: 0x04002683 RID: 9859
		private MovieClip mc_GuildSkillList;

		// Token: 0x04002684 RID: 9860
		private TextField tf_GuildName;

		// Token: 0x04002685 RID: 9861
		private TextField tf_GuildLevel;

		// Token: 0x04002686 RID: 9862
		private GClass50 tf_GuildDeca;

		// Token: 0x04002687 RID: 9863
		private TextField tf_GuildExp;

		// Token: 0x04002688 RID: 9864
		private TextField tf_OnlineNum;

		// Token: 0x04002689 RID: 9865
		private TextField tf_TotalNum;

		// Token: 0x0400268A RID: 9866
		private TextField tf_SkillTips;

		// Token: 0x0400268B RID: 9867
		private BadAssMovieClip mc_ExpBar;

		// Token: 0x0400268C RID: 9868
		private float m_fExpWidth;

		// Token: 0x0400268D RID: 9869
		protected GClass46 mc_ScrollBar;

		// Token: 0x0400268E RID: 9870
		private string GUILD_APPLICATION_PREFIX_NAME = "itemInvitation";

		// Token: 0x0400268F RID: 9871
		private string GUILD_MEMBER_PREFIX_NAME = "elementMember";

		// Token: 0x04002690 RID: 9872
		private string GUILD_NEWS_PREFIX_NAME = "itemNews";

		// Token: 0x04002691 RID: 9873
		private string GUILD_SKILL_PREFIX_NAME = "mc_GuildIcon";

		// Token: 0x04002692 RID: 9874
		private int GUILD_APPLICATION_TOTAL = 14;

		// Token: 0x04002693 RID: 9875
		private int GUILD_MEMBER_TOTAL = 14;

		// Token: 0x04002694 RID: 9876
		private int GUILD_NEWS_TOTAL = 14;

		// Token: 0x04002695 RID: 9877
		private bool m_bOnlineChecked;

		// Token: 0x04002696 RID: 9878
		protected GClass33[] _guildMemberButtons;

		// Token: 0x04002697 RID: 9879
		protected GClass31[] _guildApplicationButtons;

		// Token: 0x04002698 RID: 9880
		protected GClass35[] _guildNewsButtons;

		// Token: 0x04002699 RID: 9881
		protected List<uniGuildSearchView.GuildSkillIconSlot> m_GuildSkillIconList;
	}
}
