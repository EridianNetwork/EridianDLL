using System;
using Core;
using ns0;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;
using UnityEngine;
using XsdSettings;

// Token: 0x02000888 RID: 2184
public class uniPvPFlowView : PvPFlowView
{
	// Token: 0x06003BB9 RID: 15289 RVA: 0x00028100 File Offset: 0x00026300
	public override void vmethod_2()
	{
		base.vmethod_2();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("pvp_match_making.swf", "movie_matchmaking", new FuncLoad(this.method_8));
	}

	// Token: 0x06003BBA RID: 15290 RVA: 0x00119058 File Offset: 0x00117258
	public override void vmethod_3()
	{
		base.vmethod_3();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._pvpFlowPanel);
		this._pvpFlowPanel = null;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("pvp_match_making.swf");
	}

	// Token: 0x06003BBB RID: 15291 RVA: 0x00028132 File Offset: 0x00026332
	private void method_8(MovieClip movieClip_0)
	{
		this._pvpFlowPanel = new uniPvPFlowView.PvPFlowPanel();
		this._pvpFlowPanel.method_0(movieClip_0);
		this._pvpFlowPanel.Boolean_0 = false;
	}

	// Token: 0x06003BBC RID: 15292 RVA: 0x001190A8 File Offset: 0x001172A8
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		if (bool_0)
		{
			if (!LobbyManager.smethod_0().method_0() && GroupManager.smethod_0().method_18() && !GroupManager.smethod_0().method_19())
			{
				return;
			}
			if (!LobbyManager.smethod_0().method_0() && !GroupManager.smethod_0().method_18() && ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_8() < LevelingManager.PVP_UNLOCK_LEVEL)
			{
				return;
			}
			if (MonoSingleton<Session>.Instance.method_17())
			{
				return;
			}
		}
		base.vmethod_1(bool_0, bool_1);
		if (bool_0)
		{
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_31(this._pvpFlowPanel);
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("UI_BackMenu_Open_Main");
			if (!LobbyManager.smethod_0().method_0())
			{
				LobbyManager.smethod_0().method_14();
			}
			else
			{
				LobbyManager.smethod_0().method_8();
			}
			if (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InstanceSelectView>().vmethod_23())
			{
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InstanceSelectView>().vmethod_19();
			}
		}
		else
		{
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("UI_BackMenu_Close_Main");
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._pvpFlowPanel);
		}
		this._pvpFlowPanel.Boolean_0 = bool_0;
	}

	// Token: 0x06003BBD RID: 15293 RVA: 0x00028158 File Offset: 0x00026358
	public override void vmethod_7()
	{
		if (this._pvpFlowPanel != null)
		{
			this._pvpFlowPanel.method_20();
		}
	}

	// Token: 0x06003BBE RID: 15294 RVA: 0x0002816D File Offset: 0x0002636D
	public override void vmethod_5(int int_0)
	{
		if (this._pvpFlowPanel.Boolean_0)
		{
			this._pvpFlowPanel.method_25(int_0);
		}
	}

	// Token: 0x06003BBF RID: 15295 RVA: 0x00028188 File Offset: 0x00026388
	public override void vmethod_6()
	{
		if (this._pvpFlowPanel.Boolean_0)
		{
			this._pvpFlowPanel.method_24();
		}
	}

	// Token: 0x040029DB RID: 10715
	private uniPvPFlowView.PvPFlowPanel _pvpFlowPanel;

	// Token: 0x02000889 RID: 2185
	private class PvPFlowPanel : GClass51
	{
		// Token: 0x06003BC0 RID: 15296 RVA: 0x001191E4 File Offset: 0x001173E4
		public PvPFlowPanel()
		{
			this._roomMemberListButtons = new GClass39[this.ROOM_MEMBER_TOTAL];
			this._roomInvitationListButtons = new GClass38[this.FRIEND_TOTAL];
			this._playerRecordListButtons = new GClass36[this.PLAYER_RECORD_TOTAL];
			this._rankListButtons = new GClass37[this.RANK_LIST_TOTAL];
		}

		// Token: 0x06003BC1 RID: 15297 RVA: 0x00119294 File Offset: 0x00117494
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.mc_root = this.displayObjectContainer_0 as MovieClip;
			this.mc_root.stopAll();
			if (this.mc_root == null)
			{
				DebugUtils.LogWarning(LogCategory.GUI, "UIWarning: PvPFlowPanel onInit() 'mc_root' is null! PvPFlowPanel won't work!!!");
				return;
			}
			this.mc_RoomPanel = this.mc_root.getChildByName<MovieClip>("mc_Room");
			this.mc_CloseBtn = new GClass25();
			this.mc_CloseBtn.method_0(this.mc_root.getChildByName<MovieClip>("mcClose"));
			this.mc_CloseBtn.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_6));
			this.mc_InviteBtn = new GClass25();
			this.mc_InviteBtn.method_0(this.mc_RoomPanel.getChildByName<MovieClip>("mc_invite"));
			this.mc_InviteBtn.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_8));
			this.mc_RankBtn = new GClass25();
			this.mc_RankBtn.method_0(this.mc_RoomPanel.getChildByName<MovieClip>("Btn_rank"));
			this.mc_RankBtn.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_9));
			this.tf_RoomLevel = this.mc_RoomPanel.getChildByName<TextField>("roomlevel");
			this.tf_RoomOwnerName = this.mc_RoomPanel.getChildByName<TextField>("ownername");
			this.tf_RoomOwnerMatchCount = this.mc_RoomPanel.getChildByName<TextField>("ownercount");
			this.tf_RoomOwnerHonor = this.mc_RoomPanel.getChildByName<TextField>("ownerhonor");
			this.tf_RoomOwnerKillDeath = this.mc_RoomPanel.getChildByName<TextField>("ownerkilldeath");
			this.tf_RoomOwnerWinLose = this.mc_RoomPanel.getChildByName<TextField>("ownerwinlose");
			this.mc_InstancePanel = this.mc_root.getChildByName<MovieClip>("mc_subPanel").getChildByName<MovieClip>("mc_instance");
			this.mc_Selected = this.mc_InstancePanel.getChildByName<MovieClip>("mc_All");
			this.mc_GameBtn = new GClass25();
			this.mc_GameBtn.method_0(this.mc_InstancePanel.getChildByName<MovieClip>("mc_All").getChildByName<MovieClip>("mc_boom"));
			this.mc_GameBtn.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_13));
			this.mc_CloseSelectBtn = new GClass25();
			this.mc_CloseSelectBtn.method_0(this.mc_InstancePanel.getChildByName<MovieClip>("mc_All").getChildByName<MovieClip>("mcXButton"));
			this.mc_CloseSelectBtn.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_16));
			this.tf_InstanceDes = this.mc_InstancePanel.getChildByName<MovieClip>("mc_All").getChildByName<TextField>("textField");
			this.mc_InstanceBtn1 = new GClass25();
			this.mc_InstanceBtn1.method_0(this.mc_InstancePanel.getChildByName<MovieClip>("mc_instance1"));
			this.mc_InstanceBtn1.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_26));
			this.mc_InstancePanel.getChildByName<MovieClip>("mc_instance1").getChildByName<MovieClip>("mc_PvP_Instance").gotoAndStop("Relic Alcaid");
			this.mc_InstanceBtn2 = new GClass25();
			this.mc_InstanceBtn2.method_0(this.mc_InstancePanel.getChildByName<MovieClip>("mc_instance2"));
			this.mc_InstanceBtn2.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_27));
			this.mc_InstancePanel.getChildByName<MovieClip>("mc_instance2").getChildByName<MovieClip>("mc_PvP_Instance").gotoAndStop("Final Command");
			this.mc_InstanceBtn3 = new GClass25();
			this.mc_InstanceBtn3.method_0(this.mc_InstancePanel.getChildByName<MovieClip>("mc_instance3"));
			this.mc_InstanceBtn3.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_28));
			this.mc_InstancePanel.getChildByName<MovieClip>("mc_instance3").getChildByName<MovieClip>("mc_PvP_Instance").gotoAndStop("Waterfall");
			this.mc_InstanceBtn4 = new GClass25();
			this.mc_InstanceBtn4.method_0(this.mc_InstancePanel.getChildByName<MovieClip>("mc_instance4"));
			this.mc_InstanceBtn4.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_29));
			this.mc_InstancePanel.getChildByName<MovieClip>("mc_instance4").getChildByName<MovieClip>("mc_PvP_Instance").gotoAndStop("Valley of weeping");
			this.mc_InstanceBtn5 = new GClass25();
			this.mc_InstanceBtn5.method_0(this.mc_InstancePanel.getChildByName<MovieClip>("mc_instance5"));
			this.mc_InstanceBtn5.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_30));
			this.mc_InstancePanel.getChildByName<MovieClip>("mc_instance5").getChildByName<MovieClip>("mc_PvP_Instance").gotoAndStop("PVP_valleytown");
			
			this.mc_InstanceBtn6 = new GClass25();
			this.mc_InstanceBtn6.method_0(this.mc_InstancePanel.getChildByName<MovieClip>("mc_instance6"));
			this.mc_InstanceBtn6.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_31));
			this.mc_InstanceBtn6.Boolean_6 = true;
			this.mc_InstancePanel.getChildByName<MovieClip>("mc_instance6").getChildByName<MovieClip>("mc_PvP_Instance").gotoAndStop("PVP_shipment");

			// this.mc_InstanceBtn7 = new GClass25();
			// this.mc_InstanceBtn7.method_0(this.mc_InstancePanel.getChildByName<MovieClip>("mc_instance7"));
			// this.mc_InstanceBtn7.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_32));
			// this.mc_InstanceBtn7.Boolean_6 = true;
			// this.mc_InstancePanel.getChildByName<MovieClip>("mc_instance7").getChildByName<MovieClip>("mc_PvP_Instance").gotoAndStop("PVP_CTest");

			this.mc_ListPanel = this.mc_root.getChildByName<MovieClip>("mc_subPanel").getChildByName<MovieClip>("mc_List");
			this.mc_BackBtn = new GClass25();
			this.mc_BackBtn.method_0(this.mc_ListPanel.getChildByName<MovieClip>("mc_back"));
			this.mc_BackBtn.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_17));
			this.mc_InfoPanel = this.mc_root.getChildByName<MovieClip>("mc_subPanel").getChildByName<MovieClip>("mc_detail");
			this.mc_ReturnBtn = new GClass25();
			this.mc_ReturnBtn.method_0(this.mc_InfoPanel.getChildByName<MovieClip>("mc_return"));
			this.mc_ReturnBtn.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_18));
			this.mc_RankButton = new GClass40();
			this.mc_RankButton.method_0(this.mc_InfoPanel.getChildByName<MovieClip>("mc_rankPanel"));
			this.mc_RankButton.Boolean_6 = false;
			this.mc_RankButton.Boolean_1 = false;
			this.mc_NearbyFriendButton = new GClass40();
			this.mc_NearbyFriendButton.method_0(this.mc_ListPanel.getChildByName<MovieClip>("mc_nearbyPanel"));
			this.mc_NearbyFriendButton.Boolean_6 = false;
			this.mc_LadderIcon = this.mc_RoomPanel.getChildByName<MovieClip>("mc_LadderIcon");
			this.mc_LadderBar = this.mc_RoomPanel.getChildByName<MovieClip>("mc_LadderBar");
			this.tf_LadderTitle = this.mc_RoomPanel.getChildByName<TextField>("tf_LadderTitle");
			this.tf_LadderPoint = this.mc_RoomPanel.getChildByName<TextField>("myladderpoint");
			this.mc_FriendBar = new GClass46();
			this.mc_FriendBar.method_0(this.mc_ListPanel.getChildByName<MovieClip>("mc_scrollList"));
			this.mc_FriendBar.addEventListener("Scrolling", new EventDispatcher.EventCallback(this.method_19));
			GClass45 gclass = this.mc_FriendBar;
			this.mc_FriendBar.int_1 = 0;
			gclass.int_0 = 0;
			this.mc_FriendBar.Int32_1 = 0;
			this.mc_ListPanel.addEventListener(GClass56.string_0, new EventDispatcher.EventCallback(this.mc_FriendBar.method_12), false);
			this.mc_RankPanel = this.mc_root.getChildByName<MovieClip>("mc_subPanel").getChildByName<MovieClip>("mc_RankList");
			this.mc_RankPanel.visible = false;
			this.mc_RankScrollBar = new GClass46();
			this.mc_RankScrollBar.method_0(this.mc_RankPanel.getChildByName<MovieClip>("mc_scrollList"));
			this.mc_RankScrollBar.addEventListener("Scrolling", new EventDispatcher.EventCallback(this.method_19));
			GClass45 gclass2 = this.mc_RankScrollBar;
			this.mc_RankScrollBar.int_1 = 0;
			gclass2.int_0 = 0;
			this.mc_RankScrollBar.Int32_1 = 0;
			this.mc_RankPanel.addEventListener(GClass56.string_0, new EventDispatcher.EventCallback(this.mc_RankScrollBar.method_12), false);
			this.mc_CloseRankBoardBtn = new GClass25();
			this.mc_CloseRankBoardBtn.method_0(this.mc_RankPanel.getChildByName<MovieClip>("mc_back"));
			this.mc_CloseRankBoardBtn.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_7));
			this.mc_AllCheckBtn = new GClass40();
			this.mc_AllCheckBtn.method_0(this.mc_RankPanel.getChildByName<MovieClip>("mc_checkall"));
			this.mc_AllCheckBtn.addEventListener(GClass53.string_4, new EventDispatcher.EventCallback(this.method_10));
			this.mc_AllCheckBtn.bool_5 = false;
			this.mc_AllCheckBtn.String_1 = "RankBoard";
			this.mc_AllCheckBtn.Boolean_3 = true;
			this.mc_FriendAndGuildBtn = new GClass40();
			this.mc_FriendAndGuildBtn.method_0(this.mc_RankPanel.getChildByName<MovieClip>("mc_checkfriendandguild"));
			this.mc_FriendAndGuildBtn.addEventListener(GClass53.string_4, new EventDispatcher.EventCallback(this.method_11));
			this.mc_FriendAndGuildBtn.bool_5 = false;
			this.mc_FriendAndGuildBtn.String_1 = "RankBoard";
			this.mc_FriendAndGuildBtn.Boolean_3 = false;
		}

		// Token: 0x1700032D RID: 813
		// (get) Token: 0x06003BC3 RID: 15299 RVA: 0x000281A2 File Offset: 0x000263A2
		// (set) Token: 0x06003BC2 RID: 15298 RVA: 0x00119B9C File Offset: 0x00117D9C
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
					this.mc_root.visible = value;
					if (value)
					{
						this.mc_RoomPanel.visible = true;
						this.mc_InstancePanel.visible = true;
						this.mc_ListPanel.visible = false;
						this.mc_InfoPanel.visible = false;
						this.mc_Selected.visible = false;
						this.mc_RankPanel.visible = false;
						this.mc_FriendBar.method_10(this.FRIEND_TOTAL, 0, FriendManager.smethod_0().method_10() - this.FRIEND_TOTAL, 1);
						this.mc_FriendBar.Int32_1 = 0;
						this.mc_RankScrollBar.method_10(this.RANK_LIST_TOTAL, 0, LobbyManager.smethod_0().method_46() - this.RANK_LIST_TOTAL, 1);
						this.mc_RankScrollBar.Int32_1 = 0;
						this.method_20();
					}
				}
				if (value)
				{
					MonoSingleton<GuidanceTipsManager>.Instance.method_2("guidance_pvp");
				}
			}
		}

		// Token: 0x06003BC4 RID: 15300 RVA: 0x00119C88 File Offset: 0x00117E88
		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			if (movieClip.name.StartsWith(this.ROOM_MEMBER_PREFIX_NAME))
			{
				int num = Convert.ToInt32(movieClip.name.Substring(this.ROOM_MEMBER_PREFIX_NAME.Length, movieClip.name.Length - this.ROOM_MEMBER_PREFIX_NAME.Length));
				if (num >= this._roomMemberListButtons.Length || num < 0)
				{
					DebugUtils.LogWarning(LogCategory.GUI, string.Concat(new object[]
					{
						"Room Member itemSlot name wrong! Index:",
						num,
						" is bigger than sum: ",
						this._roomMemberListButtons.Length
					}));
					return true;
				}
				GClass39 gclass = new GClass39();
				gclass.method_0(movieClip);
				this._roomMemberListButtons[num] = gclass;
			}
			if (movieClip.name.StartsWith(this.FRIEND_PREFIX_NAME))
			{
				int num2 = Convert.ToInt32(movieClip.name.Substring(this.FRIEND_PREFIX_NAME.Length, movieClip.name.Length - this.FRIEND_PREFIX_NAME.Length));
				if (num2 >= this._roomInvitationListButtons.Length || num2 < 0)
				{
					DebugUtils.LogWarning(LogCategory.GUI, string.Concat(new object[]
					{
						"Room Friend List itemSlot name wrong! Index:",
						num2,
						" is bigger than sum: ",
						this._roomInvitationListButtons.Length
					}));
					return true;
				}
				GClass38 gclass2 = new GClass38();
				gclass2.method_0(movieClip);
				this._roomInvitationListButtons[num2] = gclass2;
			}
			if (movieClip.name.StartsWith(this.PLAYER_RECORD_PREFIX_NAME))
			{
				int num3 = Convert.ToInt32(movieClip.name.Substring(this.PLAYER_RECORD_PREFIX_NAME.Length, movieClip.name.Length - this.PLAYER_RECORD_PREFIX_NAME.Length));
				if (num3 >= this._playerRecordListButtons.Length || num3 < 0)
				{
					DebugUtils.LogWarning(LogCategory.GUI, string.Concat(new object[]
					{
						"Player Record List itemSlot name wrong! Index:",
						num3,
						" is bigger than sum: ",
						this._playerRecordListButtons.Length
					}));
					return true;
				}
				GClass36 gclass3 = new GClass36();
				gclass3.method_0(movieClip);
				this._playerRecordListButtons[num3] = gclass3;
			}
			if (movieClip.name.StartsWith(this.RANK_LIST_PREFIX_NAME))
			{
				int num4 = Convert.ToInt32(movieClip.name.Substring(this.RANK_LIST_PREFIX_NAME.Length, movieClip.name.Length - this.RANK_LIST_PREFIX_NAME.Length));
				if (num4 >= this._rankListButtons.Length || num4 < 0)
				{
					DebugUtils.LogWarning(LogCategory.GUI, string.Concat(new object[]
					{
						"Rank List itemSlot name wrong! Index:",
						num4,
						" is bigger than sum: ",
						this._rankListButtons.Length
					}));
					return true;
				}
				GClass37 gclass4 = new GClass37();
				gclass4.method_0(movieClip);
				this._rankListButtons[num4] = gclass4;
				this._rankListButtons[num4].Boolean_1 = false;
			}
			return false;
		}

		// Token: 0x06003BC5 RID: 15301 RVA: 0x00119F7C File Offset: 0x0011817C
		protected void method_5()
		{
			Presence presence = LobbyManager.smethod_0().method_6();
			if (presence != null)
			{
				this.tf_LadderPoint.text = Utility.smethod_8(presence.mLadderValue);
				LadderProgressionData ladderProgressionData = MonoSingleton<LadderProgressionSetting>.Instance.method_1(presence.mLadderValue);
				this.tf_LadderTitle.text = LocalizedString.smethod_0(new LocalizedString(ladderProgressionData.m_title));
				this.mc_LadderIcon.gotoAndStop(Utility.smethod_5("level", Utility.smethod_8(ladderProgressionData.m_levelNumber)));
				if (presence.mLadderValue >= MonoSingleton<LadderProgressionSetting>.Instance.method_0())
				{
					this.mc_LadderBar.gotoAndStop(this.mc_LadderBar.totalFrames);
				}
				else
				{
					this.mc_LadderBar.gotoAndStop(this.mc_LadderBar.totalFrames - this.mc_LadderBar.totalFrames * (presence.mLadderValue - ladderProgressionData.m_minLadder) / (ladderProgressionData.m_maxLadder - ladderProgressionData.m_minLadder));
				}
			}
			else
			{
				this.tf_LadderPoint.text = string.Empty;
				this.tf_LadderTitle.text = string.Empty;
			}
		}

		// Token: 0x06003BC6 RID: 15302 RVA: 0x000281B9 File Offset: 0x000263B9
		private void method_6(CEvent cevent_0)
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<PvPFlowView>().vmethod_4();
		}

		// Token: 0x06003BC7 RID: 15303 RVA: 0x0011A090 File Offset: 0x00118290
		private void method_7(CEvent cevent_0)
		{
			if (this.mc_RankPanel.visible)
			{
				this.mc_RankPanel.visible = false;
				this.mc_ListPanel.visible = false;
				this.mc_Selected.visible = false;
				this.mc_InfoPanel.visible = false;
				this.mc_InstancePanel.visible = true;
				this.m_bCheckAll = true;
			}
		}

		// Token: 0x06003BC8 RID: 15304 RVA: 0x0011A0F0 File Offset: 0x001182F0
		private void method_8(CEvent cevent_0)
		{
			if (!this.mc_ListPanel.visible)
			{
				this.mc_RankPanel.visible = false;
				this.mc_InstancePanel.visible = false;
				this.mc_Selected.visible = false;
				this.mc_InfoPanel.visible = false;
				this.mc_ListPanel.visible = true;
				this.mc_FriendBar.method_10(this.FRIEND_TOTAL, 0, FriendManager.smethod_0().method_10() - this.FRIEND_TOTAL, 1);
				this.mc_FriendBar.Int32_1 = 0;
			}
			this.method_20();
		}

		// Token: 0x06003BC9 RID: 15305 RVA: 0x0011A17C File Offset: 0x0011837C
		private void method_9(CEvent cevent_0)
		{
			if (!this.mc_RankPanel.visible)
			{
				this.mc_InstancePanel.visible = false;
				this.mc_Selected.visible = false;
				this.mc_InfoPanel.visible = false;
				this.mc_ListPanel.visible = false;
				this.mc_RankPanel.visible = true;
				this.mc_AllCheckBtn.Boolean_3 = true;
				this.m_bCheckAll = true;
				this.mc_RankScrollBar.method_10(this.RANK_LIST_TOTAL, 0, LobbyManager.smethod_0().method_46() - this.RANK_LIST_TOTAL, 1);
				this.mc_RankScrollBar.Int32_1 = 0;
				LobbyManager.smethod_0().method_43();
			}
		}

		// Token: 0x06003BCA RID: 15306 RVA: 0x0011A224 File Offset: 0x00118424
		private void method_10(CEvent cevent_0)
		{
			GClass25 gclass = cevent_0.target as GClass25;
			if (gclass == null)
			{
				return;
			}
			if (gclass.Boolean_3)
			{
				this.mc_RankScrollBar.method_10(this.RANK_LIST_TOTAL, 0, LobbyManager.smethod_0().method_47() - this.RANK_LIST_TOTAL, 1);
				this.mc_RankScrollBar.Int32_1 = 0;
				this.m_bCheckAll = true;
				this.method_20();
			}
		}

		// Token: 0x06003BCB RID: 15307 RVA: 0x0011A288 File Offset: 0x00118488
		private void method_11(CEvent cevent_0)
		{
			GClass25 gclass = cevent_0.target as GClass25;
			if (gclass == null)
			{
				return;
			}
			if (gclass.Boolean_3)
			{
				this.m_bCheckAll = false;
				this.mc_RankScrollBar.Int32_1 = 0;
				this.method_20();
			}
		}

		// Token: 0x06003BCC RID: 15308 RVA: 0x0011A2C8 File Offset: 0x001184C8
		protected void method_12()
		{
			Presence presence = LobbyManager.smethod_0().method_6();
			if (presence != null)
			{
				this.tf_RoomOwnerHonor.textFormat.color = Color.gray;
				this.tf_RoomLevel.text = string.Empty;
				this.tf_RoomOwnerName.text = presence.mCharacterName;
				this.tf_RoomOwnerMatchCount.text = Utility.smethod_8(presence.mMatchCount);
				this.tf_RoomOwnerHonor.text = "--";
				this.tf_RoomOwnerKillDeath.text = Utility.smethod_6(Utility.smethod_8(presence.mKillCount), "/", Utility.smethod_8(presence.mDeathCount));
				this.tf_RoomOwnerWinLose.text = Utility.smethod_6(Utility.smethod_8(presence.mWinCount), "/", Utility.smethod_8(presence.mLossCount));
			}
			this.method_5();
		}

		// Token: 0x06003BCD RID: 15309 RVA: 0x0011A3A0 File Offset: 0x001185A0
		private void method_13(CEvent cevent_0)
		{
			if (!GroupManager.smethod_0().method_20())
			{
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<ChatView>().method_8(ChatParameter.System, string.Empty, LocalizedString.smethod_0(new LocalizedString("PVP_TeamateWaiting")), 0, string.Empty);
				return;
			}
			if (this.m_nInstanceId != -1)
			{
				Playlist playlist = MatchmakingService.MatchmakingService_0.method_1(this.m_nInstanceId);
				if (playlist == null)
				{
					DebugUtils.LogError(LogCategory.GUI, "Can't get playlist " + this.m_nInstanceId.ToString());
					return;
				}
				if (playlist.m_gameMode == "GameModePvP")
				{
					this.method_21(this.m_nInstanceId, GamemodeType.GamemodeDeathmatch);
				}
				if (playlist.m_gameMode == "GamemodeTeamDeathmatch")
				{
					this.method_21(this.m_nInstanceId, GamemodeType.GamemodeTeamDeathmatch);
				}
				if (playlist.m_gameMode == "GamemodeClaptrapSoccer")
				{
					this.method_21(this.m_nInstanceId, GamemodeType.GamemodeClaptrapSoccer);
				}
			}
		}

		// Token: 0x06003BCE RID: 15310 RVA: 0x000281D0 File Offset: 0x000263D0
		private void method_14(CEvent cevent_0)
		{
			if (this.m_nInstanceId != -1)
			{
				this.method_21(this.m_nInstanceId, GamemodeType.GamemodeDeathmatch);
			}
		}

		// Token: 0x06003BCF RID: 15311 RVA: 0x000281E8 File Offset: 0x000263E8
		private void method_15(CEvent cevent_0)
		{
			if (this.m_nInstanceId != -1)
			{
				this.method_21(this.m_nInstanceId, GamemodeType.GamemodeTeamDeathmatch);
			}
		}

		// Token: 0x06003BD0 RID: 15312 RVA: 0x00028200 File Offset: 0x00026400
		private void method_16(CEvent cevent_0)
		{
			this.m_nInstanceId = -1;
			this.mc_Selected.visible = false;
		}

		// Token: 0x06003BD1 RID: 15313 RVA: 0x0011A484 File Offset: 0x00118684
		private void method_17(CEvent cevent_0)
		{
			if (this.mc_ListPanel.visible)
			{
				this.mc_RankPanel.visible = false;
				this.mc_ListPanel.visible = false;
				this.mc_Selected.visible = false;
				this.mc_InfoPanel.visible = false;
				this.mc_InstancePanel.visible = true;
			}
		}

		// Token: 0x06003BD2 RID: 15314 RVA: 0x0011A4DC File Offset: 0x001186DC
		private void method_18(CEvent cevent_0)
		{
			if (this.mc_InfoPanel.visible)
			{
				this.mc_RankPanel.visible = false;
				this.mc_InfoPanel.visible = false;
				this.mc_Selected.visible = false;
				this.mc_ListPanel.visible = false;
				this.mc_InstancePanel.visible = true;
			}
		}

		// Token: 0x06003BD3 RID: 15315 RVA: 0x00028215 File Offset: 0x00026415
		protected void method_19(CEvent cevent_0)
		{
			if (this.mc_root.visible)
			{
				this.method_20();
			}
		}

		// Token: 0x06003BD4 RID: 15316 RVA: 0x0011A534 File Offset: 0x00118734
		public void method_20()
		{
			this.method_12();
			if (this.mc_RoomPanel.visible)
			{
				int num = LobbyManager.smethod_0().method_5();
				for (int i = 0; i < num; i++)
				{
					this._roomMemberListButtons[i].vmethod_14(i);
					this._roomMemberListButtons[i].Boolean_1 = true;
				}
				for (int j = num; j < this.ROOM_MEMBER_TOTAL; j++)
				{
					this._roomMemberListButtons[j].Boolean_1 = false;
				}
			}
			if (this.mc_ListPanel.visible)
			{
				int num2 = ((FriendManager.smethod_0().method_10() <= this.FRIEND_TOTAL) ? FriendManager.smethod_0().method_10() : this.FRIEND_TOTAL);
				for (int k = 0; k < num2; k++)
				{
					this._roomInvitationListButtons[k].vmethod_14(this.mc_FriendBar.Int32_1 + k);
					this._roomInvitationListButtons[k].Boolean_1 = true;
				}
				for (int l = num2; l < this.FRIEND_TOTAL; l++)
				{
					this._roomInvitationListButtons[l].Boolean_1 = false;
				}
			}
			if (this.mc_RankPanel != null && this.mc_RankPanel.visible)
			{
				int num3;
				if (this.m_bCheckAll)
				{
					this.mc_RankScrollBar.method_10(this.RANK_LIST_TOTAL, 0, LobbyManager.smethod_0().method_46() - this.RANK_LIST_TOTAL, 1);
					num3 = ((LobbyManager.smethod_0().method_46() <= this.RANK_LIST_TOTAL) ? LobbyManager.smethod_0().method_46() : this.RANK_LIST_TOTAL);
				}
				else
				{
					this.mc_RankScrollBar.method_10(this.RANK_LIST_TOTAL, 0, LobbyManager.smethod_0().method_47() - this.RANK_LIST_TOTAL, 1);
					num3 = ((LobbyManager.smethod_0().method_47() <= this.RANK_LIST_TOTAL) ? LobbyManager.smethod_0().method_47() : this.RANK_LIST_TOTAL);
				}
				for (int m = 0; m < num3; m++)
				{
					this._rankListButtons[m].vmethod_15(this.mc_RankScrollBar.Int32_1 + m, this.m_bCheckAll);
					this._rankListButtons[m].Boolean_1 = true;
				}
				for (int n = num3; n < this.RANK_LIST_TOTAL; n++)
				{
					this._rankListButtons[n].Boolean_1 = false;
				}
			}
		}

		// Token: 0x06003BD5 RID: 15317 RVA: 0x0011A760 File Offset: 0x00118960
		private void method_21(int int_0, GamemodeType gamemodeType_0)
		{
			LobbyManager.smethod_0().method_15(gamemodeType_0, int_0);
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<MatchMakingView>().m_gameMode = gamemodeType_0;
			MonoSingleton<AppManager>.Instance.GetComponent<GameUIManager>().Boolean_0 = true;
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<PvPFlowView>().Boolean_1 = false;
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<MatchMakingView>().Boolean_1 = true;
		}

		// Token: 0x06003BD6 RID: 15318 RVA: 0x0011A7C8 File Offset: 0x001189C8
		private void method_22(int int_0)
		{
			if (LobbyManager.smethod_0().method_1())
			{
				Playlist playlist = MatchmakingService.MatchmakingService_0.method_1(int_0);
				if (playlist == null)
				{
					DebugUtils.LogError(LogCategory.GUI, "Can't get playlist " + int_0.ToString());
					return;
				}
				this.m_nInstanceId = int_0;
				if (this.tf_InstanceDes != null)
				{
					if (playlist.m_gameMode == "GameModePvP")
					{
						this.tf_InstanceDes.text = LocalizedString.smethod_0(new LocalizedString("PVPRule_DeathMatch"));
					}
					if (playlist.m_gameMode == "GamemodeTeamDeathmatch")
					{
						this.tf_InstanceDes.text = LocalizedString.smethod_0(new LocalizedString("PVPRule_TeamDeathMatch"));
					}
					if (playlist.m_gameMode == "GamemodeClaptrapSoccer")
					{
						this.tf_InstanceDes.text = LocalizedString.smethod_0(new LocalizedString("PVPRule_ClaptrapSoccer"));
					}
				}
				this.mc_Selected.visible = true;
			}
		}

		// Token: 0x06003BD7 RID: 15319 RVA: 0x0002822A File Offset: 0x0002642A
		private void method_23()
		{
			this.mc_Selected.visible = false;
		}

		// Token: 0x06003BD8 RID: 15320 RVA: 0x0011A8B0 File Offset: 0x00118AB0
		public void method_24()
		{
			if (!this.mc_InfoPanel.visible)
			{
				for (int i = 0; i < this._playerRecordListButtons.Length; i++)
				{
					this._playerRecordListButtons[i].Boolean_1 = false;
				}
				this.mc_RankPanel.visible = false;
				this.mc_Selected.visible = false;
				this.mc_InstancePanel.visible = false;
				this.mc_ListPanel.visible = false;
				this.mc_InfoPanel.visible = true;
			}
		}

		// Token: 0x06003BD9 RID: 15321 RVA: 0x0011A928 File Offset: 0x00118B28
		public void method_25(int int_0)
		{
			if (int_0 != LobbyManager.smethod_0().m_nTargetCharacterId)
			{
				return;
			}
			if (!this.mc_InfoPanel.visible)
			{
				return;
			}
			for (int i = 0; i < this._playerRecordListButtons.Length - 1; i++)
			{
				this._playerRecordListButtons[i].Boolean_1 = true;
			}
			this._playerRecordListButtons[0].method_19(LocalizedString.smethod_0(new LocalizedString("PVP_Total")), string.Empty, false, true);
			this._playerRecordListButtons[1].method_19(LocalizedString.smethod_0(new LocalizedString("PVP_TotalMatches")), Utility.smethod_8(LobbyManager.smethod_0().method_31(int_0)), false, false);
			this._playerRecordListButtons[2].method_19(LocalizedString.smethod_0(new LocalizedString("PVP_HornorValue")), Utility.smethod_8(LobbyManager.smethod_0().method_32(int_0)), true, false);
			this._playerRecordListButtons[3].method_19(LocalizedString.smethod_0(new LocalizedString("PVP_Kill/Death")), LobbyManager.smethod_0().method_33(int_0), false, false);
			this._playerRecordListButtons[4].method_19(LocalizedString.smethod_0(new LocalizedString("PVP_Win/Lose")), LobbyManager.smethod_0().method_34(int_0), false, false);
			this._playerRecordListButtons[5].method_19(LocalizedString.smethod_0(new LocalizedString("PVP_DeathMatch")), string.Empty, false, true);
			this._playerRecordListButtons[6].method_19(LocalizedString.smethod_0(new LocalizedString("PVP_TotalMatch")), Utility.smethod_8(LobbyManager.smethod_0().method_35(int_0)), false, false);
			this._playerRecordListButtons[7].method_19(LocalizedString.smethod_0(new LocalizedString("PVP_HornorValue")), Utility.smethod_8(LobbyManager.smethod_0().method_36(int_0)), true, false);
			this._playerRecordListButtons[8].method_19(LocalizedString.smethod_0(new LocalizedString("PVP_Kill/Death")), LobbyManager.smethod_0().method_37(int_0), false, false);
			this._playerRecordListButtons[9].method_19(LocalizedString.smethod_0(new LocalizedString("PVP_Win/Lose")), LobbyManager.smethod_0().method_38(int_0), false, false);
			this._playerRecordListButtons[10].method_19(LocalizedString.smethod_0(new LocalizedString("PVP_TeamMatch")), string.Empty, false, true);
			this._playerRecordListButtons[11].method_19(LocalizedString.smethod_0(new LocalizedString("PVP_TotalMatch")), Utility.smethod_8(LobbyManager.smethod_0().method_39(int_0)), false, false);
			this._playerRecordListButtons[12].method_19(LocalizedString.smethod_0(new LocalizedString("PVP_HornorValue")), Utility.smethod_8(LobbyManager.smethod_0().method_40(int_0)), true, false);
			this._playerRecordListButtons[13].method_19(LocalizedString.smethod_0(new LocalizedString("PVP_Kill/Death")), LobbyManager.smethod_0().method_41(int_0), false, false);
			this._playerRecordListButtons[14].method_19(LocalizedString.smethod_0(new LocalizedString("PVP_Win/Lose")), LobbyManager.smethod_0().method_42(int_0), false, false);
			this._playerRecordListButtons[15].Boolean_1 = false;
		}

		// Token: 0x06003BDA RID: 15322 RVA: 0x00028238 File Offset: 0x00026438
		private void method_26(CEvent cevent_0)
		{
			this.mc_Selected.getChildByName<MovieClip>("mc_selected").gotoAndStop("Relic Alcaid");
			this.method_22(1001);
		}

		// Token: 0x06003BDB RID: 15323 RVA: 0x0002825F File Offset: 0x0002645F
		private void method_27(CEvent cevent_0)
		{
			this.mc_Selected.getChildByName<MovieClip>("mc_selected").gotoAndStop("Final Command");
			this.method_22(1002);
		}

		// Token: 0x06003BDC RID: 15324 RVA: 0x00028286 File Offset: 0x00026486
		private void method_28(CEvent cevent_0)
		{
			this.mc_Selected.getChildByName<MovieClip>("mc_selected").gotoAndStop("Waterfall");
			this.method_22(1003);
		}

		// Token: 0x06003BDD RID: 15325 RVA: 0x000282AD File Offset: 0x000264AD
		private void method_29(CEvent cevent_0)
		{
			this.mc_Selected.getChildByName<MovieClip>("mc_selected").gotoAndStop("Valley of weeping");
			this.method_22(1006);
		}

		// Token: 0x06003BDE RID: 15326 RVA: 0x000282D4 File Offset: 0x000264D4
		private void method_30(CEvent cevent_0)
		{
			this.mc_Selected.getChildByName<MovieClip>("mc_selected").gotoAndStop("PVP_valleytown");
			this.method_22(1007);
		}

		// Token: 0x06003BDF RID: 15327 RVA: 0x0000311B File Offset: 0x0000131B
		private void method_31(CEvent cevent_0)
		{
			this.mc_Selected.getChildByName<MovieClip>("mc_selected").gotoAndStop("PVP_shipment");
			this.method_22(7002);
		}

		private void method_32(CEvent cevent_0)
		{
			this.mc_Selected.getChildByName<MovieClip>("mc_selected").gotoAndStop("PVP_CTest");
			this.method_22(900000);
		}

		// Token: 0x040029DC RID: 10716
		public MovieClip mc_root;

		// Token: 0x040029DD RID: 10717
		private int ROOM_MEMBER_TOTAL = 8;

		// Token: 0x040029DE RID: 10718
		private string ROOM_MEMBER_PREFIX_NAME = "itemlist";

		// Token: 0x040029DF RID: 10719
		protected GClass39[] _roomMemberListButtons;

		// Token: 0x040029E0 RID: 10720
		private int FRIEND_TOTAL = 15;

		// Token: 0x040029E1 RID: 10721
		private string FRIEND_PREFIX_NAME = "playerlist";

		// Token: 0x040029E2 RID: 10722
		protected GClass38[] _roomInvitationListButtons;

		// Token: 0x040029E3 RID: 10723
		private int PLAYER_RECORD_TOTAL = 16;

		// Token: 0x040029E4 RID: 10724
		private string PLAYER_RECORD_PREFIX_NAME = "playerinfo";

		// Token: 0x040029E5 RID: 10725
		protected GClass36[] _playerRecordListButtons;

		// Token: 0x040029E6 RID: 10726
		private int RANK_LIST_TOTAL = 15;

		// Token: 0x040029E7 RID: 10727
		private string RANK_LIST_PREFIX_NAME = "ranklist";

		// Token: 0x040029E8 RID: 10728
		protected GClass37[] _rankListButtons;

		// Token: 0x040029E9 RID: 10729
		protected MovieClip mc_RoomPanel;

		// Token: 0x040029EA RID: 10730
		protected GClass25 mc_CloseBtn;

		// Token: 0x040029EB RID: 10731
		protected GClass25 mc_InviteBtn;

		// Token: 0x040029EC RID: 10732
		protected GClass25 mc_RankBtn;

		// Token: 0x040029ED RID: 10733
		protected TextField tf_RoomLevel;

		// Token: 0x040029EE RID: 10734
		protected TextField tf_RoomOwnerName;

		// Token: 0x040029EF RID: 10735
		protected TextField tf_RoomOwnerMatchCount;

		// Token: 0x040029F0 RID: 10736
		protected TextField tf_RoomOwnerHonor;

		// Token: 0x040029F1 RID: 10737
		protected TextField tf_RoomOwnerKillDeath;

		// Token: 0x040029F2 RID: 10738
		protected TextField tf_RoomOwnerWinLose;

		// Token: 0x040029F3 RID: 10739
		protected MovieClip mc_InstancePanel;

		// Token: 0x040029F4 RID: 10740
		protected MovieClip mc_Selected;

		// Token: 0x040029F5 RID: 10741
		protected GClass25 mc_GameBtn;

		// Token: 0x040029F6 RID: 10742
		protected GClass25 mc_CloseSelectBtn;

		// Token: 0x040029F7 RID: 10743
		protected TextField tf_InstanceDes;

		// Token: 0x040029F8 RID: 10744
		private int m_nInstanceId = -1;

		// Token: 0x040029F9 RID: 10745
		protected GClass25 mc_InstanceBtn1;

		// Token: 0x040029FA RID: 10746
		protected GClass25 mc_InstanceBtn2;

		// Token: 0x040029FB RID: 10747
		protected GClass25 mc_InstanceBtn3;

		// Token: 0x040029FC RID: 10748
		protected GClass25 mc_InstanceBtn4;

		// Token: 0x040029FD RID: 10749
		protected GClass25 mc_InstanceBtn5;

		// Token: 0x040029FE RID: 10750
		protected GClass25 mc_InstanceBtn6;

		protected GClass25 mc_InstanceBtn7;

		// Token: 0x040029FF RID: 10751
		protected MovieClip mc_ListPanel;

		// Token: 0x04002A00 RID: 10752
		private GClass40 mc_NearbyFriendButton;

		// Token: 0x04002A01 RID: 10753
		protected GClass25 mc_BackBtn;

		// Token: 0x04002A02 RID: 10754
		protected GClass46 mc_FriendBar;

		// Token: 0x04002A03 RID: 10755
		protected MovieClip mc_InfoPanel;

		// Token: 0x04002A04 RID: 10756
		private GClass40 mc_RankButton;

		// Token: 0x04002A05 RID: 10757
		protected GClass25 mc_ReturnBtn;

		// Token: 0x04002A06 RID: 10758
		protected MovieClip mc_LadderIcon;

		// Token: 0x04002A07 RID: 10759
		protected MovieClip mc_LadderBar;

		// Token: 0x04002A08 RID: 10760
		protected TextField tf_LadderTitle;

		// Token: 0x04002A09 RID: 10761
		protected TextField tf_LadderPoint;

		// Token: 0x04002A0A RID: 10762
		protected MovieClip mc_RankPanel;

		// Token: 0x04002A0B RID: 10763
		protected GClass25 mc_CloseRankBoardBtn;

		// Token: 0x04002A0C RID: 10764
		protected GClass46 mc_RankScrollBar;

		// Token: 0x04002A0D RID: 10765
		protected GClass40 mc_AllCheckBtn;

		// Token: 0x04002A0E RID: 10766
		protected GClass40 mc_FriendAndGuildBtn;

		// Token: 0x04002A0F RID: 10767
		protected bool m_bCheckAll = true;
	}
}
