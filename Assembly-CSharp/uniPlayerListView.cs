using System;
using System.Collections.Generic;
using Core;
using ns0;
using pumpkin.display;
using pumpkin.events;
using UnityEngine;

// Token: 0x02000883 RID: 2179
public class uniPlayerListView : PlayerListView
{
	// Token: 0x06003B94 RID: 15252 RVA: 0x00027FC4 File Offset: 0x000261C4
	public override void vmethod_2()
	{
		base.vmethod_2();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_45("PlayerList.swf", "PlayerListPanel", new FuncLoad(this.method_7));
	}

	// Token: 0x06003B95 RID: 15253 RVA: 0x00118768 File Offset: 0x00116968
	private void method_7(MovieClip movieClip_0)
	{
		this._rootPanel = new uniPlayerListView.PlayerListPanel();
		this._rootPanel.method_0(movieClip_0);
		this._rootPanel.menuSelFunc = new uniPlayerListView.MenuSelectedFunc(base.method_6);
		this._rootPanel.addEventListener("Cancel", new EventDispatcher.EventCallback(this.method_10));
		this._rootPanel.addEventListener(CEvent.CHANGED, new EventDispatcher.EventCallback(this.method_8));
	}

	// Token: 0x06003B96 RID: 15254 RVA: 0x001187E0 File Offset: 0x001169E0
	private void method_8(CEvent cevent_0)
	{
		GClass55 gclass = cevent_0 as GClass55;
		if (gclass != null)
		{
			base.method_6((int)gclass.object_0);
		}
	}

	// Token: 0x06003B97 RID: 15255 RVA: 0x00118808 File Offset: 0x00116A08
	public override void vmethod_3()
	{
		base.vmethod_3();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._rootPanel);
		this._rootPanel.method_5();
		this._rootPanel.menuSelFunc = null;
		this._rootPanel = null;
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_48("PlayerList.swf");
	}

	// Token: 0x06003B98 RID: 15256 RVA: 0x00027FF6 File Offset: 0x000261F6
	public void method_9(Stage stage_0)
	{
		stage_0.addChild(this._rootPanel.DisplayObjectContainer_0);
	}

	// Token: 0x06003B99 RID: 15257 RVA: 0x0011886C File Offset: 0x00116A6C
	protected override void vmethod_5()
	{
		if (this._rootPanel != null)
		{
			(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_31(this._rootPanel);
			this._rootPanel.vmethod_4(this._arrCurrentMenu.ToArray());
			this._rootPanel.vmethod_3(this._subMenu.ToArray());
		}
	}

	// Token: 0x06003B9A RID: 15258 RVA: 0x00028009 File Offset: 0x00026209
	protected override void vmethod_6()
	{
		if (this._rootPanel != null)
		{
			this._rootPanel.vmethod_3(this._subMenu.ToArray());
		}
	}

	// Token: 0x06003B9B RID: 15259 RVA: 0x00028029 File Offset: 0x00026229
	protected override void vmethod_7()
	{
		this._rootPanel.vmethod_5();
		(MonoSingleton<AppManager>.Instance.method_0() as UniUIManager).method_37(this._rootPanel);
	}

	// Token: 0x06003B9C RID: 15260 RVA: 0x00028050 File Offset: 0x00026250
	protected void method_10(CEvent cevent_0)
	{
		base.method_5();
	}

	// Token: 0x040029C6 RID: 10694
	private uniPlayerListView.PlayerListPanel _rootPanel;

	// Token: 0x02000884 RID: 2180
	protected class PlayerListPanel : GClass51
	{
		// Token: 0x06003B9D RID: 15261 RVA: 0x00028058 File Offset: 0x00026258
		public PlayerListPanel()
		{
			this._arrButtonList = new List<GClass25>();
		}

		// Token: 0x06003B9E RID: 15262 RVA: 0x001188C8 File Offset: 0x00116AC8
		protected override void vmethod_0()
		{
			base.vmethod_0();
			this.mcSelf = this.displayObjectContainer_0 as MovieClip;
			this.mcSelf.stopAll();
			if (this.mcSelf == null)
			{
				DebugUtils.LogWarning(LogCategory.GUI, "UIWarning: Button onConfiUI() 'controlMC' is null! UIComponent won't work!!!");
			}
			this.mcSelf.visible = false;
			this._arrButtonList.Clear();
			for (int i = 0; i < 10; i++)
			{
				MovieClip childByName = this.mcSelf.getChildByName<MovieClip>("item" + i);
				GClass25 gclass = new GClass25();
				if (i == 0)
				{
					this.itemHeight = childByName.height;
					this.itemWidth = childByName.width;
				}
				gclass.method_0(childByName);
				gclass.Object_0 = i;
				gclass.addEventListener(MouseEvent.MOUSE_ENTER, new EventDispatcher.EventCallback(this.method_6));
				childByName.visible = false;
				this._arrButtonList.Add(gclass);
			}
			this.selectedIndex = 0;
			this.dataIndex = 0;
			this.scrollBar = new GClass46();
			this.scrollBar.method_0(this.mcSelf.getChildByName<MovieClip>("mcScrollingBar"));
			this.scrollBar.addEventListener("Scrolling", new EventDispatcher.EventCallback(this.OnScrollingList));
			this.mcSelf.addEventListener(GClass56.string_0, new EventDispatcher.EventCallback(this.OnMouseWheel));
		}

		// Token: 0x06003B9F RID: 15263 RVA: 0x00118A20 File Offset: 0x00116C20
		private void OnMouseWheel(CEvent evt)
		{
			GClass56 gclass = evt as GClass56;
			if (gclass != null && this.scrollBar.Boolean_1)
			{
				int num = ((gclass.float_0 <= 0f) ? 1 : (-1));
				this.startRenderIndex += num;
				this.startRenderIndex = Math.Min(this.endRenderIndex, Math.Max(this.startRenderIndex, 0));
				this.scrollBar.Int32_1 = this.startRenderIndex;
				this.dataIndex = this.startRenderIndex + this.selectedIndex;
				base.dispatchEvent(new GClass55(CEvent.CHANGED, this.listData[this.dataIndex].itemData, true, false));
			}
		}

		// Token: 0x06003BA0 RID: 15264 RVA: 0x00118AD4 File Offset: 0x00116CD4
		public void method_5()
		{
			for (int i = 0; i < this._arrButtonList.Count; i++)
			{
				this._arrButtonList[i].removeEventListener(MouseEvent.MOUSE_ENTER, new EventDispatcher.EventCallback(this.method_6));
			}
			this._arrButtonList.Clear();
			this.listData = null;
		}

		// Token: 0x06003BA1 RID: 15265 RVA: 0x00118B2C File Offset: 0x00116D2C
		protected void OnScrollingList(CEvent evt)
		{
			this.startRenderIndex = this.scrollBar.Int32_1;
			this.dataIndex = this.startRenderIndex + this.selectedIndex;
			base.dispatchEvent(new GClass55(CEvent.CHANGED, this.listData[this.dataIndex].itemData, true, false));
			this.vmethod_2(this.listData);
		}

		// Token: 0x06003BA2 RID: 15266 RVA: 0x00118B94 File Offset: 0x00116D94
		protected void method_6(CEvent cevent_0)
		{
			if (cevent_0 == null)
			{
				return;
			}
			GClass25 gclass = cevent_0.target as GClass25;
			if (gclass == null)
			{
				return;
			}
			if (gclass != this.currentSelectButton)
			{
				if (this.currentSelectButton != null)
				{
					this.currentSelectButton.Boolean_3 = false;
				}
				this.currentSelectButton = gclass;
				this.currentSelectButton.Boolean_3 = true;
			}
			this.selectedIndex = (int)gclass.Object_0;
			this.dataIndex = this.startRenderIndex + this.selectedIndex;
			base.dispatchEvent(new GClass55(CEvent.CHANGED, this.listData[this.dataIndex].itemData, true, false));
			this.vmethod_3(null);
		}

		// Token: 0x06003BA3 RID: 15267 RVA: 0x0000311B File Offset: 0x0000131B
		protected void method_7(CEvent cevent_0)
		{
		}

		// Token: 0x06003BA4 RID: 15268 RVA: 0x00118C3C File Offset: 0x00116E3C
		public virtual void vmethod_2(MenuItemDef[] menuItemDef_0)
		{
			for (int i = 0; i < 10; i++)
			{
				if (this._arrButtonList[i] != null)
				{
					this._arrButtonList[i].DisplayObjectContainer_0.visible = i < menuItemDef_0.Length;
					if (this._arrButtonList[i].DisplayObjectContainer_0.visible)
					{
						this._arrButtonList[i].String_2 = menuItemDef_0[this.startRenderIndex + i].itemTitle;
					}
				}
			}
		}

		// Token: 0x06003BA5 RID: 15269 RVA: 0x00118CBC File Offset: 0x00116EBC
		public virtual void vmethod_3(MenuItemDef[] menuItemDef_0 = null)
		{
			this.sublistData = menuItemDef_0;
			if (this.sublistData != null)
			{
				MonoSingleton<AppManager>.Instance.method_0().vmethod_5<PopupMenuView>().method_4(this.sublistData, new Vector2(base.DisplayObjectContainer_0.x + base.DisplayObjectContainer_0.width + (float)this.offsetLeft, base.DisplayObjectContainer_0.y + (float)this.offsetTop + (float)this.selectedIndex * this.itemHeight), new PopupMenuView.MouseClickHooker(this.OnSubmenuSelected));
			}
		}

		// Token: 0x06003BA6 RID: 15270 RVA: 0x00118D44 File Offset: 0x00116F44
		private void OnSubmenuSelected(int index)
		{
			if (!this.mcSelf.getBounds(this.mcSelf).contains(this.mcSelf.mouseX, this.mcSelf.mouseY) && this != null)
			{
				base.dispatchEvent(new CEvent("Cancel"));
			}
		}

		// Token: 0x06003BA7 RID: 15271 RVA: 0x00118D94 File Offset: 0x00116F94
		public virtual void vmethod_4(MenuItemDef[] menuItemDef_0)
		{
			if (this.mcSelf == null)
			{
				return;
			}
			this.mcSelf.visible = true;
			this.startRenderIndex = 0;
			this.endRenderIndex = Math.Max(0, menuItemDef_0.Length - 10);
			this.listData = menuItemDef_0;
			this.vmethod_2(this.listData);
			this.scrollBar.method_10(10, 0, this.endRenderIndex, 1);
			this.scrollBar.Int32_1 = 0;
			if (this.endRenderIndex <= this.startRenderIndex)
			{
				this.scrollBar.Boolean_1 = false;
			}
			else
			{
				this.scrollBar.Boolean_1 = true;
			}
			this.currentSelectButton = this._arrButtonList[0];
			this.currentSelectButton.Boolean_3 = true;
			this.mcSelf.x = ((float)Screen.width - this.mcSelf.width) * 0.5f;
			this.mcSelf.y = ((float)Screen.height - this.mcSelf.height) * 0.5f;
		}

		// Token: 0x06003BA8 RID: 15272 RVA: 0x00118E90 File Offset: 0x00117090
		public virtual void vmethod_5()
		{
			this.mcSelf.visible = false;
			this.startRenderIndex = 0;
			this.endRenderIndex = 0;
			this.selectedIndex = 0;
			this.dataIndex = 0;
			if (this.currentSelectButton != null)
			{
				this.currentSelectButton.Boolean_3 = false;
			}
			MonoSingleton<AppManager>.Instance.method_0().vmethod_5<PopupMenuView>().method_6();
		}

		// Token: 0x06003BA9 RID: 15273 RVA: 0x00118D44 File Offset: 0x00116F44
		protected void method_8(CEvent cevent_0)
		{
			if (!this.mcSelf.getBounds(this.mcSelf).contains(this.mcSelf.mouseX, this.mcSelf.mouseY) && this != null)
			{
				base.dispatchEvent(new CEvent("Cancel"));
			}
		}

		// Token: 0x040029C7 RID: 10695
		protected const int ITEM_SUM = 10;

		// Token: 0x040029C8 RID: 10696
		protected MovieClip mcSelf;

		// Token: 0x040029C9 RID: 10697
		protected List<MovieClip> _arrItemList;

		// Token: 0x040029CA RID: 10698
		protected List<GClass25> _arrButtonList;

		// Token: 0x040029CB RID: 10699
		protected int startRenderIndex;

		// Token: 0x040029CC RID: 10700
		protected int endRenderIndex;

		// Token: 0x040029CD RID: 10701
		protected int selectedIndex;

		// Token: 0x040029CE RID: 10702
		protected int dataIndex;

		// Token: 0x040029CF RID: 10703
		protected int offsetTop = 27;

		// Token: 0x040029D0 RID: 10704
		protected int offsetLeft = -3;

		// Token: 0x040029D1 RID: 10705
		protected float itemHeight;

		// Token: 0x040029D2 RID: 10706
		protected float itemWidth;

		// Token: 0x040029D3 RID: 10707
		protected MenuItemDef[] listData;

		// Token: 0x040029D4 RID: 10708
		protected MenuItemDef[] sublistData;

		// Token: 0x040029D5 RID: 10709
		protected GClass46 scrollBar;

		// Token: 0x040029D6 RID: 10710
		protected GClass25 currentSelectButton;

		// Token: 0x040029D7 RID: 10711
		public uniPlayerListView.MenuSelectedFunc menuSelFunc;
	}

	// Token: 0x02000885 RID: 2181
	// (Invoke) Token: 0x06003BAB RID: 15275
	protected delegate void MenuSelectedFunc(int iIndex);
}
