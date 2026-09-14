using System;
using Core;
using ns0;
using pumpkin.display;
using pumpkin.events;
using pumpkin.text;
using UnityEngine;

// Token: 0x020007F7 RID: 2039
public class uniFriendView : FriendView
{
	// Token: 0x060036F9 RID: 14073 RVA: 0x0002461B File Offset: 0x0002281B
	public override void vmethod_2()
	{
		base.vmethod_2();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("Friend_Group.swf", "RootPanel", new FuncLoad(this.method_3));
	}

	// Token: 0x060036FA RID: 14074 RVA: 0x000FB808 File Offset: 0x000F9A08
	public override void vmethod_3()
	{
		base.vmethod_3();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._friendPanel);
		this._friendPanel = null;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("Friend_Group.swf");
	}

	// Token: 0x060036FB RID: 14075 RVA: 0x0002464D File Offset: 0x0002284D
	private void method_3(MovieClip movieClip_0)
	{
		this._friendPanel = new uniFriendView.FriendPanel();
		this._friendPanel.method_0(movieClip_0);
		this._friendPanel.Boolean_0 = false;
	}

	// Token: 0x060036FC RID: 14076 RVA: 0x000FB858 File Offset: 0x000F9A58
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		base.vmethod_1(bool_0, bool_1);
		if (bool_0)
		{
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_31(this._friendPanel);
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("UI_BackMenu_Open_Main");
		}
		else
		{
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("UI_BackMenu_Close_Main");
		}
		this._friendPanel.Boolean_0 = this._bVisible;
	}

	// Token: 0x060036FD RID: 14077 RVA: 0x00024673 File Offset: 0x00022873
	public override void vmethod_5(bool bool_0 = false)
	{
		if (this._friendPanel != null)
		{
			this._friendPanel.method_15(bool_0);
		}
	}

	// Token: 0x04002610 RID: 9744
	private uniFriendView.FriendPanel _friendPanel;

	// Token: 0x020007F8 RID: 2040
	private enum FRIEND_PANEL_STYLE
	{
		// Token: 0x04002612 RID: 9746
		e_FriendList,
		// Token: 0x04002613 RID: 9747
		e_FriendInvitation,
		// Token: 0x04002614 RID: 9748
		e_FriendSearch
	}

	// Token: 0x020007F9 RID: 2041
	private class FriendPanel : GClass51
	{
		// Token: 0x060036FE RID: 14078 RVA: 0x000FB8D0 File Offset: 0x000F9AD0
		public FriendPanel()
		{
			this._friendButtons = new GClass28[this.FRIEND_TOTAL];
			this._friendInvitationButtons = new GClass27[this.INVITAION_TOTAL];
			this._friendSearchButtons = new GClass29[this.SEARCH_TOTAL];
		}

		// Token: 0x060036FF RID: 14079 RVA: 0x000FB958 File Offset: 0x000F9B58
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.mc_root = this.displayObjectContainer_0 as MovieClip;
			if (this.mc_root == null)
			{
				DebugUtils.LogWarning(LogCategory.GUI, "UIWarning: FriendPanel onInit() 'mc_root' is null! InstancePanel won't work!!!");
				return;
			}
			this.mc_root.visible = false;
			this.mc_root.stopAll();
			MovieClip childByName = this.mc_root.getChildByName<MovieClip>("mc_total").getChildByName<MovieClip>("mc_friend_total");
			this.mc_FriendList = childByName.getChildByName<MovieClip>("mc_friends");
			this.mc_InvitationList = childByName.getChildByName<MovieClip>("mc_invetation");
			this.mc_SearchList = childByName.getChildByName<MovieClip>("mc_search");
			this.mc_SearchTag = childByName.getChildByName<MovieClip>("mc_searchTag");
			this.mc_Character = childByName.getChildByName<MovieClip>("mcIcon").getChildByName<MovieClip>("mcClassIcon");
			this.tf_Name = childByName.getChildByName<TextField>("tfPlayerName");
			this.tf_Level = childByName.getChildByName<TextField>("TitleName");
			this.tf_FriendNum = this.mc_FriendList.getChildByName<TextField>("tf_OnlineMember");
			this.tf_FriendMaxNum = this.mc_FriendList.getChildByName<TextField>("tf_AllMember");
			this.mc_Character.gotoAndStop(MonoSingleton<Session>.Instance.GetLocalPlayer().m_avatarDna.method_5().ToString());
			this.tf_Name.text = MonoSingleton<Session>.Instance.GetLocalPlayer().m_name;
			this.tf_Level.text = "LV." + ServiceWrapperBase<CharacterServiceWrapper>.Instance.method_8();
			this.tf_FriendMaxNum.text = "/" + this.m_nMaxFriendCount;
			this.mc_FriendButton = new GClass40();
			this.mc_InvitationButton = new GClass40();
			this.mc_SearchButton = new GClass40();
			this.mc_BlackListButton = new GClass40();
			this.mc_Close = new GClass25();
			this.mc_Close.method_0(childByName.getChildByName<MovieClip>("mcBtnClose"));
			this.mc_Close.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_12));
			this.mc_searchFriendButton = new GClass25();
			this.mc_searchFriendButton.method_0(this.mc_SearchList.getChildByName<MovieClip>("mc_searchBtn"));
			this.mc_searchFriendButton.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_13));
			this.mcNameInput = new GClass50();
			this.mcNameInput.method_0(this.mc_SearchList.getChildByName<MovieClip>("mcsloganInput"));
			this.mcNameInput.Boolean_2 = false;
			this.mc_FriendButton.method_0(childByName.getChildByName<MovieClip>("mc_friendlist"));
			this.mc_FriendButton.addEventListener(GClass53.string_4, new EventDispatcher.EventCallback(this.method_9));
			this.mc_FriendButton.bool_5 = false;
			this.mc_FriendButton.String_1 = "Friend";
			this.mc_InvitationButton.method_0(childByName.getChildByName<MovieClip>("mc_invitation"));
			this.mc_InvitationButton.addEventListener(GClass53.string_4, new EventDispatcher.EventCallback(this.method_10));
			this.mc_InvitationButton.bool_5 = false;
			this.mc_InvitationButton.String_1 = "Friend";
			this.mc_SearchButton.method_0(childByName.getChildByName<MovieClip>("mc_search_btn"));
			this.mc_SearchButton.addEventListener(GClass53.string_4, new EventDispatcher.EventCallback(this.method_11));
			this.mc_SearchButton.bool_5 = false;
			this.mc_SearchButton.String_1 = "Friend";
			this.mc_BlackListButton.method_0(childByName.getChildByName<MovieClip>("mc_black_btn"));
			this.mc_BlackListButton.Boolean_6 = false;
			this.mc_ScrollBar = new GClass46();
			this.mc_ScrollBar.method_0(childByName.getChildByName<MovieClip>("mcScrollingBar"));
			this.mc_ScrollBar.addEventListener("Scrolling", new EventDispatcher.EventCallback(this.method_14));
			GClass45 gclass = this.mc_ScrollBar;
			this.mc_ScrollBar.int_1 = 0;
			gclass.int_0 = 0;
			this.mc_ScrollBar.Int32_1 = 0;
			this.mc_FriendList.visible = true;
			this.mc_InvitationList.visible = false;
			this.mc_SearchList.visible = false;
			this.mc_SearchTag.visible = false;
		}

		// Token: 0x170002EF RID: 751
		// (get) Token: 0x06003701 RID: 14081 RVA: 0x00024689 File Offset: 0x00022889
		// (set) Token: 0x06003700 RID: 14080 RVA: 0x000FBD80 File Offset: 0x000F9F80
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
						this.method_5();
						if (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InstanceSelectView>().Boolean_0)
						{
							if (MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InstanceSelectView>().vmethod_22())
							{
								this.mc_InvitationButton.Boolean_3 = true;
								this.mc_FriendList.visible = false;
								this.mc_InvitationList.visible = true;
							}
							else
							{
								this.mc_FriendButton.Boolean_3 = true;
								this.mc_FriendList.visible = true;
								this.mc_InvitationList.visible = false;
							}
						}
						else
						{
							this.mc_FriendButton.Boolean_3 = true;
							this.mc_FriendList.visible = true;
							this.mc_InvitationList.visible = false;
						}
						this.mc_SearchList.visible = false;
						this.mc_SearchTag.visible = false;
						this.mcNameInput.Boolean_2 = false;
						this.mcNameInput.String_0 = string.Empty;
						this.method_15(false);
					}
					else
					{
						this.mcNameInput.Boolean_2 = false;
						this.mcNameInput.String_0 = string.Empty;
						MonoSingleton<AppManager>.Instance.method_0().Boolean_2 = false;
						this.method_6();
					}
				}
			}
		}

		// Token: 0x06003702 RID: 14082 RVA: 0x000246A0 File Offset: 0x000228A0
		protected void method_5()
		{
			this.mc_root.visible = true;
			this.mc_root.gotoAndPlay("fade");
		}

		// Token: 0x06003703 RID: 14083 RVA: 0x000FBEB0 File Offset: 0x000FA0B0
		protected void method_6()
		{
			this.mc_root.gotoAndPlay("fadeout");
			this.mc_root.addFrameScript("fadeoutend", new EventDispatcher.EventCallback(this.method_7));
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InstanceSelectView>().vmethod_18();
		}

		// Token: 0x06003704 RID: 14084 RVA: 0x000FBF00 File Offset: 0x000FA100
		protected void method_7(CEvent cevent_0)
		{
			this.mc_root.removeEventListener("fadeoutend", new EventDispatcher.EventCallback(this.method_7));
			this.mc_root.visible = false;
			MonoSingleton<AppManager>.Instance.method_0().Boolean_2 = true;
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this);
		}

		// Token: 0x06003705 RID: 14085 RVA: 0x000FBF5C File Offset: 0x000FA15C
		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			if (movieClip.name.StartsWith(this.FRIEND_SLOT_PREFIX_NAME))
			{
				int num = Convert.ToInt32(movieClip.name.Substring(this.FRIEND_SLOT_PREFIX_NAME.Length, movieClip.name.Length - this.FRIEND_SLOT_PREFIX_NAME.Length));
				if (num >= this._friendButtons.Length || num < 0)
				{
					DebugUtils.LogWarning(LogCategory.GUI, string.Concat(new object[]
					{
						"friend itemSlot name wrong! Index:",
						num,
						" is bigger than sum: ",
						this._friendButtons.Length
					}));
					return true;
				}
				GClass28 gclass = new GClass28();
				gclass.method_0(movieClip);
				this._friendButtons[num] = gclass;
			}
			if (movieClip.name.StartsWith(this.FRIEND_INVITE_PREFIX_NAME))
			{
				int num2 = Convert.ToInt32(movieClip.name.Substring(this.FRIEND_INVITE_PREFIX_NAME.Length, movieClip.name.Length - this.FRIEND_INVITE_PREFIX_NAME.Length));
				if (num2 >= this._friendInvitationButtons.Length || num2 < 0)
				{
					DebugUtils.LogWarning(LogCategory.GUI, string.Concat(new object[]
					{
						"friend invitation itemSlot name wrong! Index:",
						num2,
						" is bigger than sum: ",
						this._friendInvitationButtons.Length
					}));
					return true;
				}
				GClass27 gclass2 = new GClass27();
				gclass2.method_0(movieClip);
				this._friendInvitationButtons[num2] = gclass2;
			}
			if (movieClip.name.StartsWith(this.FRIEND_SEARCH_PREFIX_NAME))
			{
				int num3 = Convert.ToInt32(movieClip.name.Substring(this.FRIEND_SEARCH_PREFIX_NAME.Length, movieClip.name.Length - this.FRIEND_SEARCH_PREFIX_NAME.Length));
				if (num3 >= this._friendSearchButtons.Length || num3 < 0)
				{
					DebugUtils.LogWarning(LogCategory.GUI, string.Concat(new object[]
					{
						"friend search itemSlot name wrong! Index:",
						num3,
						" is bigger than sum: ",
						this._friendSearchButtons.Length
					}));
					return true;
				}
				GClass29 gclass3 = new GClass29();
				gclass3.method_0(movieClip);
				this._friendSearchButtons[num3] = gclass3;
			}
			if (movieClip.name == "mc_onlinecheck")
			{
				this.mc_OnlineBox = new GClass40();
				this.mc_OnlineBox.method_0(movieClip);
				this.mc_OnlineBox.bool_5 = true;
				this.mc_OnlineBox.String_1 = "online";
				this.mc_OnlineBox.addEventListener(GClass53.string_4, new EventDispatcher.EventCallback(this.method_8));
			}
			return true;
		}

		// Token: 0x06003706 RID: 14086 RVA: 0x000FC1EC File Offset: 0x000FA3EC
		protected void method_8(CEvent cevent_0)
		{
			GClass25 gclass = cevent_0.target as GClass25;
			if (gclass == null)
			{
				return;
			}
			if (gclass.Boolean_3)
			{
				this.m_bOnlineChecked = true;
				this.mc_ScrollBar.method_10(this.FRIEND_TOTAL, 0, FriendManager.smethod_0().method_10() - this.FRIEND_TOTAL, 1);
				this.mc_ScrollBar.Int32_1 = 0;
			}
			else
			{
				this.m_bOnlineChecked = false;
				this.mc_ScrollBar.method_10(this.FRIEND_TOTAL, 0, FriendManager.smethod_0().method_17() - this.FRIEND_TOTAL, 1);
				this.mc_ScrollBar.Int32_1 = 0;
			}
			this.method_15(false);
		}

		// Token: 0x06003707 RID: 14087 RVA: 0x000FC288 File Offset: 0x000FA488
		private void method_9(CEvent cevent_0)
		{
			GClass25 gclass = cevent_0.target as GClass25;
			if (gclass == null)
			{
				return;
			}
			if (gclass.Boolean_3 && !this.mc_FriendList.visible)
			{
				this.mc_ScrollBar.method_10(this.FRIEND_TOTAL, 0, FriendManager.smethod_0().method_17() - this.FRIEND_TOTAL, 1);
				this.mc_ScrollBar.Int32_1 = 0;
				this.mc_FriendList.visible = true;
				this.mc_InvitationList.visible = false;
				this.mc_SearchList.visible = false;
				this.mc_SearchTag.visible = false;
				this.mcNameInput.Boolean_2 = false;
				MonoSingleton<AppManager>.Instance.method_0().Boolean_2 = true;
				this.method_15(false);
			}
		}

		// Token: 0x06003708 RID: 14088 RVA: 0x000FC344 File Offset: 0x000FA544
		private void method_10(CEvent cevent_0)
		{
			GClass25 gclass = cevent_0.target as GClass25;
			if (gclass == null)
			{
				return;
			}
			if (gclass.Boolean_3 && !this.mc_InvitationList.visible)
			{
				this.mc_ScrollBar.method_10(this.INVITAION_TOTAL, 0, FriendManager.smethod_0().method_8() - this.INVITAION_TOTAL, 1);
				this.mc_ScrollBar.Int32_1 = 0;
				this.mc_FriendList.visible = false;
				this.mc_InvitationList.visible = true;
				this.mc_SearchList.visible = false;
				this.mc_SearchTag.visible = false;
				this.mcNameInput.Boolean_2 = false;
				MonoSingleton<AppManager>.Instance.method_0().Boolean_2 = true;
				this.method_15(false);
			}
		}

		// Token: 0x06003709 RID: 14089 RVA: 0x000FC400 File Offset: 0x000FA600
		private void method_11(CEvent cevent_0)
		{
			GClass25 gclass = cevent_0.target as GClass25;
			if (gclass == null)
			{
				return;
			}
			if (gclass.Boolean_3 && !this.mc_SearchList.visible)
			{
				this.mc_FriendList.visible = false;
				this.mc_InvitationList.visible = false;
				this.mc_SearchList.visible = true;
				this.mc_SearchTag.visible = false;
				this.mcNameInput.Boolean_2 = true;
				MonoSingleton<AppManager>.Instance.method_0().Boolean_2 = false;
				this.method_15(false);
			}
		}

		// Token: 0x0600370A RID: 14090 RVA: 0x000246BE File Offset: 0x000228BE
		private void method_12(CEvent cevent_0)
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<FriendView>().vmethod_4();
		}

		// Token: 0x0600370B RID: 14091 RVA: 0x000246D5 File Offset: 0x000228D5
		private void method_13(CEvent cevent_0)
		{
			if (this.mcNameInput.String_0 != string.Empty)
			{
				FriendManager.smethod_0().method_22(this.mcNameInput.String_0);
			}
		}

		// Token: 0x0600370C RID: 14092 RVA: 0x00024703 File Offset: 0x00022903
		protected void method_14(CEvent cevent_0)
		{
			if (this.mc_root.visible)
			{
				this.method_15(false);
			}
		}

		// Token: 0x0600370D RID: 14093 RVA: 0x000FC488 File Offset: 0x000FA688
		public void method_15(bool bool_0 = false)
		{
			if (this.mc_FriendList != null && this.mc_InvitationList != null && this.mc_SearchList != null)
			{
				if (this.mc_FriendList.visible)
				{
					this.tf_FriendNum.textFormat.color = Color.yellow;
					this.tf_FriendNum.text = Utility.smethod_8(FriendManager.smethod_0().method_17());
					int num = ((FriendManager.smethod_0().method_17() <= this.FRIEND_TOTAL) ? FriendManager.smethod_0().method_17() : this.FRIEND_TOTAL);
					if (this.m_bOnlineChecked)
					{
						num = ((FriendManager.smethod_0().method_10() <= this.FRIEND_TOTAL) ? FriendManager.smethod_0().method_10() : this.FRIEND_TOTAL);
						this.mc_ScrollBar.method_10(this.FRIEND_TOTAL, 0, FriendManager.smethod_0().method_10() - this.FRIEND_TOTAL, 1);
					}
					else
					{
						this.mc_ScrollBar.method_10(this.FRIEND_TOTAL, 0, FriendManager.smethod_0().method_17() - this.FRIEND_TOTAL, 1);
					}
					for (int i = 0; i < num; i++)
					{
						this._friendButtons[i].vmethod_14(this.mc_ScrollBar.Int32_1 + i);
						this._friendButtons[i].Boolean_1 = true;
					}
					for (int j = num; j < this.FRIEND_TOTAL; j++)
					{
						if (this._friendButtons[j] != null)
						{
							this._friendButtons[j].Boolean_1 = false;
						}
					}
				}
				if (this.mc_InvitationList.visible)
				{
					this.mc_ScrollBar.method_10(this.INVITAION_TOTAL, 0, FriendManager.smethod_0().method_8() - this.INVITAION_TOTAL, 1);
					int num2 = ((FriendManager.smethod_0().method_8() <= this.INVITAION_TOTAL) ? FriendManager.smethod_0().method_8() : this.INVITAION_TOTAL);
					for (int k = 0; k < num2; k++)
					{
						this._friendInvitationButtons[k].vmethod_14(this.mc_ScrollBar.Int32_1 + k);
						this._friendInvitationButtons[k].Boolean_1 = true;
					}
					for (int l = num2; l < this.INVITAION_TOTAL; l++)
					{
						if (this._friendInvitationButtons[l] != null)
						{
							this._friendInvitationButtons[l].Boolean_1 = false;
						}
					}
				}
				if (this.mc_SearchList.visible)
				{
					this.mc_ScrollBar.method_10(this.FRIEND_TOTAL, 0, FriendManager.smethod_0().method_24() - this.FRIEND_TOTAL, 1);
					int num3 = ((FriendManager.smethod_0().method_24() <= this.SEARCH_TOTAL) ? FriendManager.smethod_0().method_24() : this.SEARCH_TOTAL);
					for (int m = 0; m < num3; m++)
					{
						this._friendSearchButtons[m].vmethod_14(this.mc_ScrollBar.Int32_1 + m);
						this._friendSearchButtons[m].Boolean_1 = true;
					}
					for (int n = num3; n < this.SEARCH_TOTAL; n++)
					{
						if (this._friendSearchButtons[n] != null)
						{
							this._friendSearchButtons[n].Boolean_1 = false;
						}
					}
				}
				return;
			}
		}

		// Token: 0x04002615 RID: 9749
		public MovieClip mc_root;

		// Token: 0x04002616 RID: 9750
		private int FRIEND_TOTAL = 14;

		// Token: 0x04002617 RID: 9751
		private int INVITAION_TOTAL = 14;

		// Token: 0x04002618 RID: 9752
		private int SEARCH_TOTAL = 13;

		// Token: 0x04002619 RID: 9753
		private string FRIEND_SLOT_PREFIX_NAME = "elementFriend";

		// Token: 0x0400261A RID: 9754
		private string FRIEND_INVITE_PREFIX_NAME = "itemInvitation";

		// Token: 0x0400261B RID: 9755
		private string FRIEND_SEARCH_PREFIX_NAME = "itemFriend";

		// Token: 0x0400261C RID: 9756
		private bool m_bOnlineChecked;

		// Token: 0x0400261D RID: 9757
		protected GClass28[] _friendButtons;

		// Token: 0x0400261E RID: 9758
		protected GClass27[] _friendInvitationButtons;

		// Token: 0x0400261F RID: 9759
		protected GClass29[] _friendSearchButtons;

		// Token: 0x04002620 RID: 9760
		private MovieClip mc_FriendList;

		// Token: 0x04002621 RID: 9761
		private MovieClip mc_InvitationList;

		// Token: 0x04002622 RID: 9762
		private MovieClip mc_SearchList;

		// Token: 0x04002623 RID: 9763
		private MovieClip mc_SearchTag;

		// Token: 0x04002624 RID: 9764
		private MovieClip mc_Character;

		// Token: 0x04002625 RID: 9765
		private GClass40 mc_FriendButton;

		// Token: 0x04002626 RID: 9766
		private GClass40 mc_InvitationButton;

		// Token: 0x04002627 RID: 9767
		private GClass40 mc_SearchButton;

		// Token: 0x04002628 RID: 9768
		private GClass40 mc_BlackListButton;

		// Token: 0x04002629 RID: 9769
		private GClass40 mc_OnlineBox;

		// Token: 0x0400262A RID: 9770
		private GClass25 mc_searchFriendButton;

		// Token: 0x0400262B RID: 9771
		private GClass25 mc_Close;

		// Token: 0x0400262C RID: 9772
		private TextField tf_Name;

		// Token: 0x0400262D RID: 9773
		private TextField tf_Level;

		// Token: 0x0400262E RID: 9774
		private TextField tf_FriendNum;

		// Token: 0x0400262F RID: 9775
		private TextField tf_FriendMaxNum;

		// Token: 0x04002630 RID: 9776
		private GClass50 mcNameInput;

		// Token: 0x04002631 RID: 9777
		protected GClass46 mc_ScrollBar;

		// Token: 0x04002632 RID: 9778
		private int m_nMaxFriendCount = 30;
	}
}
