using System;
using Core;
using ns0;
using pumpkin.display;
using pumpkin.events;

// Token: 0x020007FA RID: 2042
public class uniGroupView : GroupView
{
	// Token: 0x0600370F RID: 14095 RVA: 0x00024721 File Offset: 0x00022921
	public override void vmethod_2()
	{
		base.vmethod_2();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("Friend_Group.swf", "GroupRootPanel", new FuncLoad(this.method_3));
	}

	// Token: 0x06003710 RID: 14096 RVA: 0x000FC778 File Offset: 0x000FA978
	public override void vmethod_3()
	{
		base.vmethod_3();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._groupPanel);
		this._groupPanel = null;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("Friend_Group.swf");
	}

	// Token: 0x06003711 RID: 14097 RVA: 0x00024753 File Offset: 0x00022953
	private void method_3(MovieClip movieClip_0)
	{
		this._groupPanel = new uniGroupView.GroupPanel();
		this._groupPanel.method_0(movieClip_0);
		this._groupPanel.Boolean_0 = false;
	}

	// Token: 0x06003712 RID: 14098 RVA: 0x000FC7C8 File Offset: 0x000FA9C8
	protected override void vmethod_1(bool bool_0, bool bool_1 = false)
	{
		base.vmethod_1(bool_0, bool_1);
		if (this._bVisible)
		{
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_31(this._groupPanel);
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("UI_BackMenu_Open_Main");
		}
		else
		{
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).imethod_0("UI_BackMenu_Close_Main");
		}
		this._groupPanel.Boolean_0 = this._bVisible;
	}

	// Token: 0x06003713 RID: 14099 RVA: 0x00024779 File Offset: 0x00022979
	public override void vmethod_5()
	{
		if (this._groupPanel == null)
		{
			return;
		}
		this._groupPanel.method_8(false);
	}

	// Token: 0x04002633 RID: 9779
	private uniGroupView.GroupPanel _groupPanel;

	// Token: 0x020007FB RID: 2043
	private class GroupPanel : GClass51
	{
		// Token: 0x06003714 RID: 14100 RVA: 0x00024790 File Offset: 0x00022990
		public GroupPanel()
		{
			this._arrButtons = new GClass30[this.MESSAGE_TOTAL];
		}

		// Token: 0x06003715 RID: 14101 RVA: 0x000FC848 File Offset: 0x000FAA48
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.mc_root = this.displayObjectContainer_0 as MovieClip;
			if (this.mc_root == null)
			{
				DebugUtils.LogWarning(LogCategory.GUI, "UIWarning: GroupPanel onInit() 'mc_root' is null! InstancePanel won't work!!!");
				return;
			}
			this.mc_root.visible = false;
			this.mc_Close = new GClass25();
			this.mc_Close.method_0(this.mc_root.getChildByName<MovieClip>("group_root").getChildByName<MovieClip>("groupTotal").getChildByName<MovieClip>("mcBtnClose"));
			this.mc_Close.addEventListener(MouseEvent.CLICK, new EventDispatcher.EventCallback(this.method_9));
			this.mc_ScrollBar = new GClass46();
			this.mc_ScrollBar.method_0(this.mc_root.getChildByName<MovieClip>("group_root").getChildByName<MovieClip>("groupTotal").getChildByName<MovieClip>("mcScrollingBar"));
			this.mc_ScrollBar.addEventListener("Scrolling", new EventDispatcher.EventCallback(this.method_10));
			GClass45 gclass = this.mc_ScrollBar;
			this.mc_ScrollBar.int_1 = 0;
			gclass.int_0 = 0;
			this.mc_ScrollBar.method_10(this.MESSAGE_TOTAL, 0, GroupManager.smethod_0().method_3() - this.MESSAGE_TOTAL, 1);
			this.mc_ScrollBar.Int32_1 = 0;
			this.mc_GroupPanel = this.mc_root.getChildByName<MovieClip>("group_root").getChildByName<MovieClip>("groupTotal").getChildByName<MovieClip>("mc_group");
		}

		// Token: 0x170002F0 RID: 752
		// (get) Token: 0x06003717 RID: 14103 RVA: 0x000247DE File Offset: 0x000229DE
		// (set) Token: 0x06003716 RID: 14102 RVA: 0x000247BC File Offset: 0x000229BC
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
						this.method_8(false);
						this.method_5();
					}
					else
					{
						this.method_6();
					}
				}
			}
		}

		// Token: 0x06003718 RID: 14104 RVA: 0x000247F5 File Offset: 0x000229F5
		protected void method_5()
		{
			this.mc_root.visible = true;
			this.mc_root.gotoAndPlay("fade");
		}

		// Token: 0x06003719 RID: 14105 RVA: 0x000FC9B0 File Offset: 0x000FABB0
		protected void method_6()
		{
			MonoSingleton<AppManager>.Instance.method_0().Boolean_2 = false;
			this.mc_root.gotoAndPlay("fadeout");
			this.mc_root.addFrameScript("fadeoutend", new EventDispatcher.EventCallback(this.method_7));
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<InstanceSelectView>().vmethod_17();
		}

		// Token: 0x0600371A RID: 14106 RVA: 0x000FCA10 File Offset: 0x000FAC10
		protected void method_7(CEvent cevent_0)
		{
			this.mc_root.removeEventListener("fadeoutend", new EventDispatcher.EventCallback(this.method_7));
			this.mc_root.visible = false;
			MonoSingleton<AppManager>.Instance.method_0().Boolean_2 = true;
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this);
		}

		// Token: 0x0600371B RID: 14107 RVA: 0x000FCA6C File Offset: 0x000FAC6C
		protected override bool OnWidgetInitialized(ref MovieClip movieClip, Type widgetType)
		{
			if (movieClip.name.StartsWith(this.ITEM_SLOT_PREFIX_NAME))
			{
				int num = Convert.ToInt32(movieClip.name.Substring(this.ITEM_SLOT_PREFIX_NAME.Length, movieClip.name.Length - this.ITEM_SLOT_PREFIX_NAME.Length));
				if (num >= this._arrButtons.Length || num < 0)
				{
					DebugUtils.LogWarning(LogCategory.GUI, string.Concat(new object[]
					{
						"Group itemSlot name wrong! Index:",
						num,
						" is bigger than sum: ",
						this._arrButtons.Length
					}));
					return true;
				}
				GClass30 gclass = new GClass30();
				gclass.method_0(movieClip);
				this._arrButtons[num] = gclass;
			}
			return true;
		}

		// Token: 0x0600371C RID: 14108 RVA: 0x000FCB2C File Offset: 0x000FAD2C
		public void method_8(bool bool_0 = false)
		{
			this.mc_ScrollBar.method_10(this.MESSAGE_TOTAL, 0, GroupManager.smethod_0().method_3() - this.MESSAGE_TOTAL, 1);
			int num = ((GroupManager.smethod_0().method_3() <= this.MESSAGE_TOTAL) ? GroupManager.smethod_0().method_3() : this.MESSAGE_TOTAL);
			for (int i = 0; i < num; i++)
			{
				this._arrButtons[i].vmethod_14(this.mc_ScrollBar.Int32_1 + i);
				this._arrButtons[i].Boolean_1 = true;
			}
			for (int j = num; j < this.MESSAGE_TOTAL; j++)
			{
				if (this._arrButtons[j] != null)
				{
					this._arrButtons[j].Boolean_1 = false;
				}
			}
		}

		// Token: 0x0600371D RID: 14109 RVA: 0x00024813 File Offset: 0x00022A13
		private void method_9(CEvent cevent_0)
		{
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<GroupView>().vmethod_4();
		}

		// Token: 0x0600371E RID: 14110 RVA: 0x0002482A File Offset: 0x00022A2A
		protected void method_10(CEvent cevent_0)
		{
			if (this.mc_root.visible)
			{
				this.method_8(false);
			}
		}

		// Token: 0x04002634 RID: 9780
		public MovieClip mc_root;

		// Token: 0x04002635 RID: 9781
		private int MESSAGE_TOTAL = 18;

		// Token: 0x04002636 RID: 9782
		private string ITEM_SLOT_PREFIX_NAME = "groupItem";

		// Token: 0x04002637 RID: 9783
		protected GClass30[] _arrButtons;

		// Token: 0x04002638 RID: 9784
		private GClass25 mc_Close;

		// Token: 0x04002639 RID: 9785
		protected GClass46 mc_ScrollBar;

		// Token: 0x0400263A RID: 9786
		protected MovieClip mc_GroupPanel;
	}
}
